using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AutoTest.Support;

internal sealed class BrowserSession : IDisposable
{
    private readonly WebDriverWait wait;

    public BrowserSession()
    {
        var options = new ChromeOptions();
        options.AddArgument("--window-size=1366,900");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-search-engine-choice-screen");
        options.AddArgument("--lang=vi-VN");
        options.AddUserProfilePreference("intl.accept_languages", "vi-VN,vi,en-US,en");

        if (!TestSettings.ShowBrowser)
        {
            options.AddArgument("--headless=new");
        }

        if (!string.IsNullOrWhiteSpace(TestSettings.ChromeBinary))
        {
            options.BinaryLocation = TestSettings.ChromeBinary;
        }

        Driver = new ChromeDriver(options);
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(150);
        wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30))
        {
            PollingInterval = TimeSpan.FromMilliseconds(250)
        };
        wait.IgnoreExceptionTypes(
            typeof(NoSuchElementException),
            typeof(StaleElementReferenceException),
            typeof(ElementClickInterceptedException));
    }

    public IWebDriver Driver { get; }

    public IJavaScriptExecutor JavaScript => (IJavaScriptExecutor)Driver;

    public void GoTo(string url)
    {
        Driver.Navigate().GoToUrl(url);
        WaitForDocumentReady();
    }

    public void GoToPortal(string portal)
    {
        GoTo(TestSettings.PortalUrl(portal));
    }

    public IWebElement WaitVisible(By locator, int timeoutSeconds = 30)
    {
        return NewWait(timeoutSeconds).Until(driver =>
        {
            var element = driver.FindElements(locator).FirstOrDefault(item => IsUsable(item));
            return element;
        })!;
    }

    public IReadOnlyList<IWebElement> WaitVisibleMany(By locator, int minimumCount = 1, int timeoutSeconds = 30)
    {
        return NewWait(timeoutSeconds).Until(driver =>
        {
            var elements = driver.FindElements(locator).Where(IsUsable).ToList();
            return elements.Count >= minimumCount ? elements : null;
        })!;
    }

    public void Click(By locator, int timeoutSeconds = 30)
    {
        var element = WaitVisible(locator, timeoutSeconds);
        Click(element);
    }

    public void Click(IWebElement element)
    {
        ScrollIntoView(element);
        try
        {
            element.Click();
        }
        catch (WebDriverException)
        {
            JavaScript.ExecuteScript("arguments[0].click();", element);
        }
    }

    public void PointerClick(IWebElement element)
    {
        ScrollIntoView(element);
        new Actions(Driver)
            .MoveToElement(element)
            .Pause(TimeSpan.FromMilliseconds(100))
            .Click()
            .Perform();
    }

    public void PointerClickFromTopLeft(IWebElement element, int offsetX, int offsetY)
    {
        ScrollIntoView(element);
        var centerOffsetX = offsetX - (element.Size.Width / 2);
        var centerOffsetY = offsetY - (element.Size.Height / 2);
        try
        {
            new Actions(Driver)
                .MoveToElement(element)
                .MoveByOffset(centerOffsetX, centerOffsetY)
                .Pause(TimeSpan.FromMilliseconds(100))
                .Click()
                .Perform();
        }
        catch (WebDriverException)
        {
            // The JavaScript dispatch below is the fallback for merged Flutter semantics rows.
        }

        try
        {
            JavaScript.ExecuteScript(
                """
                const element = arguments[0];
                const offsetX = arguments[1];
                const offsetY = arguments[2];
                const rect = element.getBoundingClientRect();
                const x = rect.left + offsetX;
                const y = rect.top + offsetY;
                const target = document.elementFromPoint(x, y) || element;
                for (const type of ['pointerdown', 'mousedown', 'pointerup', 'mouseup', 'click']) {
                  target.dispatchEvent(new MouseEvent(type, {
                    bubbles: true,
                    cancelable: true,
                    composed: true,
                    clientX: x,
                    clientY: y,
                    view: window
                  }));
                }
                """,
                element,
                offsetX,
                offsetY);
        }
        catch (WebDriverException)
        {
            // If Flutter already handled the pointer action, the semantics node may be stale here.
        }
    }

    public void Fill(By locator, string value, int timeoutSeconds = 30)
    {
        var element = WaitVisible(locator, timeoutSeconds);
        ScrollIntoView(element);
        element.SendKeys(Keys.Control + "a");
        element.SendKeys(value);
    }

    public void WaitUntil(Func<IWebDriver, bool> condition, string message, int timeoutSeconds = 30)
    {
        try
        {
            NewWait(timeoutSeconds).Until(driver => condition(driver));
        }
        catch (WebDriverTimeoutException error)
        {
            Assert.Fail($"{message}. Last error: {error.Message}");
        }
    }

    public void WaitForCssText(string selector, string expectedText, int timeoutSeconds = 30)
    {
        WaitUntil(
            driver => driver.FindElements(By.CssSelector(selector))
                .Any(item => (item.Text ?? string.Empty).Contains(expectedText, StringComparison.OrdinalIgnoreCase)
                    || (item.GetDomProperty("textContent") ?? string.Empty).Contains(expectedText, StringComparison.OrdinalIgnoreCase)),
            $"Text '{expectedText}' was not found in selector '{selector}'",
            timeoutSeconds);
    }

    public void WaitForBodyText(string expectedText, int timeoutSeconds = 30)
    {
        WaitUntil(
            driver => BodyText(driver).Contains(expectedText, StringComparison.OrdinalIgnoreCase),
            $"Body text '{expectedText}' was not found",
            timeoutSeconds);
    }

    public void WaitForAnyBodyText(int timeoutSeconds = 30, params string[] expectedTexts)
    {
        WaitUntil(
            driver => expectedTexts.Any(text => BodyText(driver).Contains(text, StringComparison.OrdinalIgnoreCase)),
            $"None of the expected body texts were found: {string.Join(", ", expectedTexts)}",
            timeoutSeconds);
    }

    public bool BodyContains(string text)
    {
        return BodyText(Driver).Contains(text, StringComparison.OrdinalIgnoreCase);
    }

    public void SetViewport(int width, int height)
    {
        Driver.Manage().Window.Size = new System.Drawing.Size(width, height);
    }

    public void ScrollToTop()
    {
        JavaScript.ExecuteScript("window.scrollTo(0, 0);");
        Driver.FindElement(By.TagName("body")).SendKeys(Keys.Home);
        Thread.Sleep(250);
    }

    public void ScrollToBottom()
    {
        JavaScript.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        Driver.FindElement(By.TagName("body")).SendKeys(Keys.End);
        Thread.Sleep(250);
    }

    public string TakeScreenshot(string scenarioTitle, string status)
    {
        var safeTitle = string.Concat(scenarioTitle.Select(ch => char.IsLetterOrDigit(ch) ? ch : '_'));
        var fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}_{status}_{safeTitle}.png";
        var path = Path.Combine(TestSettings.EvidenceDirectory, fileName);
        Directory.CreateDirectory(TestSettings.EvidenceDirectory);
        ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(path);
        return path;
    }

    public void Dispose()
    {
        Driver.Quit();
        Driver.Dispose();
    }

    private void WaitForDocumentReady()
    {
        WaitUntil(
            driver => string.Equals(JavaScript.ExecuteScript("return document.readyState")?.ToString(), "complete", StringComparison.OrdinalIgnoreCase),
            "Document did not finish loading",
            45);
    }

    private WebDriverWait NewWait(int timeoutSeconds)
    {
        var localWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds))
        {
            PollingInterval = TimeSpan.FromMilliseconds(250)
        };
        localWait.IgnoreExceptionTypes(
            typeof(NoSuchElementException),
            typeof(StaleElementReferenceException),
            typeof(ElementClickInterceptedException));
        return localWait;
    }

    private void ScrollIntoView(IWebElement element)
    {
        JavaScript.ExecuteScript("arguments[0].scrollIntoView({block:'center', inline:'center'});", element);
    }

    private static bool IsUsable(IWebElement element)
    {
        try
        {
            return element.Displayed && element.Enabled;
        }
        catch (StaleElementReferenceException)
        {
            return false;
        }
    }

    private static string BodyText(IWebDriver driver)
    {
        return driver.FindElement(By.TagName("body")).Text ?? string.Empty;
    }
}
