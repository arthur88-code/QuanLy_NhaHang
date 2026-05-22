using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace RestaurantManagement.E2E;

[TestClass]
public sealed class WebSmokeTests
{
    [TestMethod]
    [TestCategory("Web")]
    public async Task CustomerWeb_LoginShowsCustomerWorkspace()
    {
        await WithPageAsync(async page =>
        {
            await page.GotoAsync(TestConfig.CustomerWebUrl);

            await page.Locator("#username").FillAsync("customer001");
            await page.Locator("#password").FillAsync("123");
            await page.GetByRole(AriaRole.Button, new() { Name = "Dang nhap" }).ClickAsync();

            Assert.IsNotNull(await page.WaitForSelectorAsync("text=So do ban"));
            Assert.IsNotNull(await page.WaitForSelectorAsync("text=Thuc don"));
            Assert.IsNotNull(await page.WaitForSelectorAsync("text=Lich su da xac nhan"));
        });
    }

    [TestMethod]
    [TestCategory("Web")]
    public async Task StaffWeb_IsServedByBackend()
    {
        await WithPageAsync(async page =>
        {
            var response = await page.GotoAsync(TestConfig.StaffWebUrl);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Ok);
            StringAssert.Matches(
                await page.TitleAsync(),
                new Regex("Quan Ly Nha Hang|Quản Lý Nhà Hàng|Restaurant", RegexOptions.IgnoreCase));
        });
    }

    [TestMethod]
    [TestCategory("Web")]
    public async Task AdminWeb_IsServedByBackend()
    {
        await WithPageAsync(async page =>
        {
            var response = await page.GotoAsync(TestConfig.AdminWebUrl);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Ok);
            StringAssert.Matches(
                await page.TitleAsync(),
                new Regex("Quan Ly Nha Hang|Quản Lý Nhà Hàng|Restaurant", RegexOptions.IgnoreCase));
        });
    }

    private static async Task WithPageAsync(Func<IPage, Task> action)
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });
        var page = await browser.NewPageAsync();
        await action(page);
    }
}
