using NUnit.Framework;
using Reqnroll;

namespace AutoTest.StepDefinitions;

[Binding]
public sealed class FailEvidenceSteps
{
    [Then(@"testcase fail minh hoa ""([^""]+)"" voi ly do ""([^""]+)""")]
    public void ThenTestcaseFailMinhHoa(string id, string reason)
    {
        Assert.Fail($"{id} FAIL minh hoa co chu dich: {reason}");
    }
}
