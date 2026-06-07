using AutoTest.Support;
using Reqnroll;

namespace AutoTest.Hooks;

[Binding]
public sealed class SeleniumHooks
{
    private readonly ScenarioContext scenarioContext;

    public SeleniumHooks(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        TestRuntime.StartScenario();
    }

    [AfterScenario]
    public void AfterScenario()
    {
        try
        {
            if (TestRuntime.IsBrowserStarted)
            {
                var status = scenarioContext.TestError is null ? "PASS" : "FAIL";
                var path = TestRuntime.Browser.TakeScreenshot(scenarioContext.ScenarioInfo.Title, status);
                TestRuntime.Set("lastScreenshot", path);
            }
        }
        catch
        {
            // Screenshot evidence is helpful, but it should not hide the real test failure.
        }
        finally
        {
            TestRuntime.EndScenario();
        }
    }
}
