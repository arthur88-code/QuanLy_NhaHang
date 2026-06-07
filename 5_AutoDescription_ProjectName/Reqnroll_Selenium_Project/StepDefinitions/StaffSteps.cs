using AutoTest.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace AutoTest.StepDefinitions;

[Binding]
public sealed class StaffSteps
{
    [When(@"staff tao ban ""([^""]+)"" so ghe ""([^""]+)"" khu ""([^""]+)""")]
    public void WhenStaffTaoBanSoGheKhu(string tableName, string seats, string area)
    {
        FlutterUi.ClickNav(1);
        FlutterUi.ClickLabel("action-add-table");
        FlutterUi.FillVisibleInputs(tableName, seats, area);
        FlutterUi.ClickLastButton();
    }

    [When(@"staff goi mon co ma (\d+) cho ban (\d+)")]
    public async Task WhenStaffGoiMonCoMaChoBan(int menuId, int tableId)
    {
        FlutterUi.ClickNav(1);
        FlutterUi.ClickLabelPrefix($"table-card-{tableId}-");
        await TestRuntime.Api.CreateStaffOrderWithItemAsync(tableId, menuId);
        TestRuntime.Set("staffOrderTableId", tableId);
    }

    [Then(@"backend co hoa don staff mo tai ban (\d+)")]
    public async Task ThenBackendCoHoaDonStaffMoTaiBan(int tableId)
    {
        await Polling.UntilAsync(async () =>
        {
            var order = await TestRuntime.Api.FindOpenOrderForTableAsync(tableId);
            if (order is null)
            {
                return false;
            }

            TestRuntime.Set("staffOrderId", order["id"]?.GetValue<int>() ?? 0);
            return order["batches"]?.AsArray().Count > 0;
        }, $"Open staff order on table {tableId} was not created.");
    }

    [Given(@"backend co hoa don mo cua staff tai ban (\d+)")]
    public async Task GivenBackendCoHoaDonMoCuaStaffTaiBan(int tableId)
    {
        var order = await TestRuntime.Api.CreateStaffOrderWithItemAsync(tableId);
        TestRuntime.Set("staffOrderId", order["id"]?.GetValue<int>() ?? 0);
        TestRuntime.Set("staffOrderTableId", tableId);
    }

    [When(@"staff thanh toan hoa don hien tai")]
    public void WhenStaffThanhToanHoaDonHienTai()
    {
        var orderId = TestRuntime.Get<int>("staffOrderId");
        FlutterUi.ClickNav(3);
        FlutterUi.ClickLabelPrefix($"invoice-card-{orderId}-");
        FlutterUi.ClickLabel($"invoice-pay-{orderId}");
        FlutterUi.FillVisibleInputs("0");
        FlutterUi.ClickLastButton();
    }

    [Then(@"backend ghi nhan hoa don hien tai co trang thai ""([^""]+)""")]
    public async Task ThenBackendGhiNhanHoaDonHienTaiCoTrangThai(string status)
    {
        var orderId = TestRuntime.Get<int>("staffOrderId");
        await Polling.UntilAsync(async () =>
        {
            var order = await TestRuntime.Api.FindOrderAsync(orderId);
            return string.Equals(order?["status"]?.GetValue<string>(), status, StringComparison.OrdinalIgnoreCase);
        }, $"Order {orderId} did not reach status '{status}'.");
    }

    [When(@"staff ghi no hoa don hien tai cho khach ""([^""]+)""")]
    public void WhenStaffGhiNoHoaDonHienTaiChoKhach(string customerName)
    {
        var orderId = TestRuntime.Get<int>("staffOrderId");
        FlutterUi.ClickNav(3);
        FlutterUi.ClickLabelPrefix($"invoice-card-{orderId}-");
        FlutterUi.ClickLabel($"invoice-debt-{orderId}");
        FlutterUi.FillVisibleInputs(customerName, "0909000000", "auto debt note");
        FlutterUi.ClickLastButton();
    }

    [Given(@"backend co cong no cua khach ""([^""]+)""")]
    public async Task GivenBackendCoCongNoCuaKhach(string customerName)
    {
        var result = await TestRuntime.Api.CreateDebtAsync(7, customerName);
        TestRuntime.Set("debtId", result["debt"]?["id"]?.GetValue<int>() ?? 0);
    }

    [When(@"staff thu het cong no hien tai")]
    public void WhenStaffThuHetCongNoHienTai()
    {
        var debtId = TestRuntime.Get<int>("debtId");
        FlutterUi.ClickNav(4);
        FlutterUi.ClickLabel($"debt-pay-{debtId}");
    }

    [Then(@"backend ghi nhan cong no hien tai da ""([^""]+)""")]
    public async Task ThenBackendGhiNhanCongNoHienTaiDa(string status)
    {
        var debtId = TestRuntime.Get<int>("debtId");
        await Polling.UntilAsync(async () =>
        {
            var debt = await TestRuntime.Api.FindDebtAsync(debtId);
            return string.Equals(debt?["status"]?.GetValue<string>(), status, StringComparison.OrdinalIgnoreCase);
        }, $"Debt {debtId} did not reach status '{status}'.");
    }

    [When(@"staff cham cong vao ca va ra ca")]
    public async Task WhenStaffChamCongVaoCaVaRaCa()
    {
        FlutterUi.ClickNav(6);
        FlutterUi.ClickLabel("action-check-in");
        FlutterUi.ClickLastButton();

        await Polling.UntilAsync(async () =>
        {
            var attendance = await TestRuntime.Api.FindAttendanceForEmployeeAsync(2);
            if (attendance is null || attendance["checkOut"] is not null)
            {
                return false;
            }

            TestRuntime.Set("attendanceId", attendance["id"]?.GetValue<int>() ?? 0);
            return true;
        }, "Attendance check-in for employee 2 was not created.");

        var attendanceId = TestRuntime.Get<int>("attendanceId");
        await TestRuntime.Api.PatchJsonAsync($"/attendance/{attendanceId}/check-out", new { });
        TestRuntime.Browser.Driver.FindElement(By.TagName("body")).SendKeys(Keys.Escape);
        Thread.Sleep(300);
    }

    [Then(@"backend ghi nhan cham cong hien tai da ra ca")]
    public async Task ThenBackendGhiNhanChamCongHienTaiDaRaCa()
    {
        var attendanceId = TestRuntime.Get<int>("attendanceId");
        await Polling.UntilAsync(async () =>
        {
            var rows = await TestRuntime.Api.GetArrayAsync("/attendance");
            var row = rows.FirstOrDefault(item => item?["id"]?.GetValue<int>() == attendanceId);
            return !string.IsNullOrWhiteSpace(row?["checkOut"]?.GetValue<string>());
        }, $"Attendance {attendanceId} was not checked out.");
    }

    [Then(@"staff xem duoc thong bao noi bo")]
    public async Task ThenStaffXemDuocThongBaoNoiBo()
    {
        var notifications = await TestRuntime.Api.GetArrayAsync("/notifications");
        var titles = notifications
            .Select(item => item?["title"]?.GetValue<string>() ?? string.Empty)
            .ToArray();
        Assert.That(titles, Does.Contain("Kiem kho do uong").Or.Contain("Ca toi"));
    }
}
