using AutoTest.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace AutoTest.StepDefinitions;

[Binding]
public sealed class CommonSteps
{
    [Given(@"backend dang san sang")]
    public async Task GivenBackendDangSanSang()
    {
        await TestRuntime.Api.AssertReadyAsync();
    }

    [Given(@"he thong du lieu demo duoc reset")]
    public async Task GivenHeThongDuLieuDemoDuocReset()
    {
        await TestRuntime.Api.ResetAsync();
    }

    [Given(@"toi mo web ""([^""]+)""")]
    public void GivenToiMoWeb(string portal)
    {
        TestRuntime.Browser.GoToPortal(portal);
    }

    [When(@"toi dang nhap web Flutter ""([^""]+)"" voi tai khoan ""([^""]+)"" mat khau ""([^""]+)""")]
    public void WhenToiDangNhapWebFlutter(string portal, string username, string password)
    {
        FlutterUi.Login(portal, username, password);
    }

    [Then(@"ung dung Flutter da dang nhap thanh cong")]
    public void ThenUngDungFlutterDaDangNhapThanhCong()
    {
        FlutterUi.WaitUntilReady();
        FlutterUi.AssertNoConnectionError();
    }

    [When(@"toi di den man hinh Flutter so (\d+)")]
    public void WhenToiDiDenManHinhFlutterSo(int index)
    {
        FlutterUi.ClickNav(index);
        FlutterUi.AssertNoConnectionError();
    }

    [Then(@"trang hien thi noi dung ""([^""]+)""")]
    public void ThenTrangHienThiNoiDung(string expectedText)
    {
        TestRuntime.Browser.WaitForBodyText(expectedText);
    }

    [Then(@"trang hien thi mot trong cac noi dung ""([^""]+)"" hoac ""([^""]+)""")]
    public void ThenTrangHienThiMotTrongCacNoiDung(string first, string second)
    {
        TestRuntime.Browser.WaitForAnyBodyText(60, first, second);
    }

    [Then(@"trang khong hien thi loi ket noi")]
    public void ThenTrangKhongHienThiLoiKetNoi()
    {
        FlutterUi.AssertNoConnectionError();
    }

    [Then(@"backend co ban ""([^""]+)""")]
    public async Task ThenBackendCoBan(string tableName)
    {
        await Polling.UntilAsync(
            async () => await TestRuntime.Api.FindTableByNameAsync(tableName) is not null,
            $"Table '{tableName}' was not created.");
    }

    [Then(@"backend co mon ""([^""]+)""")]
    public async Task ThenBackendCoMon(string menuName)
    {
        await Polling.UntilAsync(
            async () => await TestRuntime.Api.FindMenuItemByNameAsync(menuName) is not null,
            $"Menu item '{menuName}' was not created.");
    }

    [Then(@"backend co nhan vien ""([^""]+)""")]
    public async Task ThenBackendCoNhanVien(string employeeName)
    {
        await Polling.UntilAsync(
            async () => await TestRuntime.Api.FindEmployeeByNameAsync(employeeName) is not null,
            $"Employee '{employeeName}' was not created.");
    }

    [Then(@"backend co thong bao ""([^""]+)""")]
    public async Task ThenBackendCoThongBao(string title)
    {
        await Polling.UntilAsync(
            async () => await TestRuntime.Api.FindNotificationByTitleAsync(title) is not null,
            $"Notification '{title}' was not created.");
    }

    [Then(@"trinh duyet dang o giao dien dang nhap khach hang")]
    public void ThenTrinhDuyetDangOGiaoDienDangNhapKhachHang()
    {
        Assert.That(TestRuntime.Browser.WaitVisible(By.CssSelector("#loginView:not(.hidden)")).Displayed, Is.True);
    }
}
