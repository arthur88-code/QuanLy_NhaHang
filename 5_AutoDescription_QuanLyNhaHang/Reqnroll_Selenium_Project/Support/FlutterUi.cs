using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutoTest.Support;

internal static class FlutterUi
{
    public static void Login(string portal, string username, string password)
    {
        var browser = TestRuntime.Browser;
        browser.GoToPortal(portal);
        EnableSemantics();

        FillVisibleInputs(username, password);
        ClickRoleButtonAt(0);
        WaitUntilReady();
    }

    public static void EnableSemantics()
    {
        var browser = TestRuntime.Browser;
        browser.WaitUntil(driver =>
        {
            return driver.FindElements(By.CssSelector("input[aria-label]")).Count >= 2
                || driver.FindElements(By.CssSelector("flt-semantics-placeholder")).Count > 0
                || driver.FindElements(By.CssSelector("[role='button']")).Count > 0;
        }, "Flutter semantics placeholder was not found", 60);

        var inputs = browser.Driver.FindElements(By.CssSelector("input[aria-label]"));
        if (inputs.Count < 2)
        {
            var placeholder = browser.Driver.FindElements(By.CssSelector("flt-semantics-placeholder")).FirstOrDefault();
            if (placeholder is not null)
            {
                browser.Click(placeholder);
            }
        }

        browser.WaitUntil(
            driver => driver.FindElements(By.CssSelector("input[aria-label]")).Count >= 2
                || driver.FindElements(By.CssSelector("[role='button']")).Count >= 8,
            "Flutter semantics did not become available",
            60);
    }

    public static void WaitUntilReady()
    {
        TestRuntime.Browser.WaitUntil(
            driver => driver.FindElements(By.CssSelector("[role='button']")).Count >= 8,
            "Flutter app did not reach the authenticated shell",
            60);
    }

    public static void ClickNav(int zeroBasedIndex)
    {
        ClickRoleButtonAt(zeroBasedIndex);
        Thread.Sleep(900);
    }

    public static void ClickLabel(string label)
    {
        var browser = TestRuntime.Browser;
        var element = WaitSemanticsLabel(label, 60);
        if (ShouldClickRightEdge(label, element))
        {
            browser.PointerClickFromTopLeft(element, Math.Max(1, element.Size.Width - 48), Math.Max(1, element.Size.Height / 2));
            TrySemanticFallback(element);
        }
        else
        {
            browser.PointerClick(element);
        }
        Thread.Sleep(450);
    }

    public static void ClickLabelPrefix(string prefix)
    {
        ClickLabel(prefix);
    }

    public static void FillVisibleInputs(params string[] values)
    {
        var browser = TestRuntime.Browser;
        var inputs = WaitTextInputs(values.Length);
        for (var i = 0; i < values.Length; i++)
        {
            var input = inputs[i];
            try
            {
                browser.PointerClick(input);
                input.SendKeys(Keys.Control + "a");
                input.SendKeys(values[i]);
            }
            catch (WebDriverException)
            {
                browser.JavaScript.ExecuteScript(
                    "arguments[0].focus(); arguments[0].value = arguments[1]; arguments[0].dispatchEvent(new Event('input', { bubbles: true })); arguments[0].dispatchEvent(new Event('change', { bubbles: true }));",
                    input,
                    values[i]);
            }
        }
    }

    public static void ClickLastButton()
    {
        var browser = TestRuntime.Browser;
        var buttons = WaitRoleButtons(1, 30);
        browser.PointerClick(buttons.Last());
        Thread.Sleep(800);
    }

    public static void AssertNoConnectionError()
    {
        Assert.That(TestRuntime.Browser.BodyContains("Khong ket noi"), Is.False);
    }

    private static void ClickRoleButtonAt(int zeroBasedIndex)
    {
        var browser = TestRuntime.Browser;
        var buttons = WaitRoleButtons(zeroBasedIndex + 1, 60);
        browser.PointerClick(buttons[zeroBasedIndex]);
    }

    private static IWebElement WaitSemanticsLabel(string label, int timeoutSeconds)
    {
        var browser = TestRuntime.Browser;
        var deadline = DateTime.UtcNow.AddSeconds(timeoutSeconds);
        Exception? lastError = null;

        while (DateTime.UtcNow < deadline)
        {
            try
            {
                var exact = FindSemanticsCandidates(label, exact: true);
                var candidates = exact.Count > 0 ? exact : FindSemanticsCandidates(label, exact: false);
                var selected = candidates.FirstOrDefault(item => string.Equals(item.GetDomAttribute("role"), "button", StringComparison.OrdinalIgnoreCase))
                    ?? candidates.FirstOrDefault();
                if (selected is not null)
                {
                    return selected;
                }

                browser.Driver.FindElement(By.TagName("body")).SendKeys(Keys.PageDown);
                Thread.Sleep(300);
            }
            catch (Exception error) when (error is WebDriverException or InvalidOperationException)
            {
                lastError = error;
                Thread.Sleep(300);
            }
        }

        throw new WebDriverTimeoutException(
            $"Timed out waiting for Flutter semantics label '{label}'.",
            lastError);
    }

    private static IReadOnlyList<IWebElement> FindSemanticsCandidates(string label, bool exact)
    {
        var literal = XPathLiteral(label);
        var predicate = exact
            ? $"@aria-label={literal}"
            : $"contains(@aria-label,{literal})";
        return TestRuntime.Browser.Driver
            .FindElements(By.XPath($"//*[{predicate}]"))
            .Where(IsPointerTarget)
            .ToList();
    }

    private static bool ShouldClickRightEdge(string label, IWebElement element)
    {
        if (element.Size.Width <= 260)
        {
            return false;
        }

        var rightEdgePrefixes = new[]
        {
            "action-",
            "debt-pay-",
            "attendance-checkout-",
            "notification-delete-",
            "order-add-menu-",
            "order-increment-menu-"
        };
        return rightEdgePrefixes.Any(prefix => label.StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
    }

    private static void TrySemanticFallback(IWebElement element)
    {
        var browser = TestRuntime.Browser;
        try
        {
            Thread.Sleep(100);
            element.Click();
        }
        catch (WebDriverException)
        {
            // Keep trying alternate activation paths below.
        }

        try
        {
            browser.JavaScript.ExecuteScript("arguments[0].click();", element);
        }
        catch (WebDriverException)
        {
            // Keep trying alternate activation paths below.
        }

        try
        {
            Thread.Sleep(150);
            element.SendKeys(Keys.Enter);
            element.SendKeys(Keys.Space);
        }
        catch (WebDriverException)
        {
            // Pointer click is the primary path; these are only Flutter semantics fallbacks.
        }
    }

    private static IReadOnlyList<IWebElement> WaitRoleButtons(int minimumCount, int timeoutSeconds)
    {
        IReadOnlyList<IWebElement>? selected = null;
        var wait = NewWait(timeoutSeconds);
        wait.Until(driver =>
        {
            var buttons = driver.FindElements(By.CssSelector("[role='button']"))
                .Where(IsPointerTarget)
                .ToList();
            selected = buttons;
            return buttons.Count >= minimumCount;
        });
        return selected!;
    }

    private static IReadOnlyList<IWebElement> WaitTextInputs(int minimumCount)
    {
        IReadOnlyList<IWebElement>? selected = null;
        var wait = NewWait(30);
        wait.Until(driver =>
        {
            var all = driver.FindElements(By.CssSelector("input[aria-label], textarea[aria-label]"))
                .Where(item => item.Enabled && item.Size.Width > 0 && item.Size.Height > 0)
                .ToList();
            if (all.Count < minimumCount)
            {
                all = driver.FindElements(By.CssSelector("input[aria-label], textarea[aria-label]"))
                    .Where(item => item.Enabled)
                    .ToList();
            }

            selected = all;
            return all.Count >= minimumCount;
        });
        return selected!;
    }

    private static bool IsPointerTarget(IWebElement element)
    {
        try
        {
            return element.Displayed && element.Enabled && element.Size.Width > 0 && element.Size.Height > 0;
        }
        catch (StaleElementReferenceException)
        {
            return false;
        }
    }

    private static WebDriverWait NewWait(int timeoutSeconds)
    {
        var wait = new WebDriverWait(TestRuntime.Browser.Driver, TimeSpan.FromSeconds(timeoutSeconds))
        {
            PollingInterval = TimeSpan.FromMilliseconds(250)
        };
        wait.IgnoreExceptionTypes(
            typeof(NoSuchElementException),
            typeof(StaleElementReferenceException),
            typeof(ElementClickInterceptedException));
        return wait;
    }

    private static string XPathLiteral(string value)
    {
        if (!value.Contains('\''))
        {
            return $"'{value}'";
        }

        return "concat('" + value.Replace("'", "',\"'\",'") + "')";
    }
}
