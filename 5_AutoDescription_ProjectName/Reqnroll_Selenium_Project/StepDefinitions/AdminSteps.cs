using AutoTest.Support;
using NUnit.Framework;
using Reqnroll;

namespace AutoTest.StepDefinitions;

[Binding]
public sealed class AdminSteps
{
    [When(@"admin duyet tat ca man hinh chinh")]
    public void WhenAdminDuyetTatCaManHinhChinh()
    {
        for (var nav = 1; nav <= 10; nav++)
        {
            FlutterUi.ClickNav(nav);
            FlutterUi.AssertNoConnectionError();
        }
    }

    [When(@"admin tao mon ""([^""]+)""")]
    public async Task WhenAdminTaoMon(string menuName)
    {
        FlutterUi.ClickNav(2);
        FlutterUi.ClickLabel("action-add-menu");
        FlutterUi.FillVisibleInputs(menuName, "Mon chinh", "99000", "https://example.com/auto-dish.jpg");
        FlutterUi.ClickLastButton();

        await Polling.UntilAsync(async () =>
        {
            var item = await TestRuntime.Api.FindMenuItemByNameAsync(menuName);
            if (item is null)
            {
                return false;
            }

            TestRuntime.Set("menuId", item["id"]?.GetValue<int>() ?? 0);
            return true;
        }, $"Menu item '{menuName}' was not created.");
    }

    [When(@"admin sua mon hien tai thanh ""([^""]+)""")]
    public async Task WhenAdminSuaMonHienTaiThanh(string newName)
    {
        var menuId = TestRuntime.Get<int>("menuId");
        await TestRuntime.Api.PutJsonAsync($"/menu/{menuId}", new
        {
            name = newName,
            category = "Mon chinh",
            price = 101000,
            imageUrl = "https://example.com/auto-edited.jpg",
            available = true
        });
        TestRuntime.Set("menuName", newName);
    }

    [Then(@"backend ghi nhan mon hien tai ten ""([^""]+)""")]
    public async Task ThenBackendGhiNhanMonHienTaiTen(string expectedName)
    {
        var menuId = TestRuntime.Get<int>("menuId");
        await Polling.UntilAsync(async () =>
        {
            var item = await TestRuntime.Api.FindMenuItemAsync(menuId);
            return string.Equals(item?["name"]?.GetValue<string>(), expectedName, StringComparison.OrdinalIgnoreCase);
        }, $"Menu item {menuId} was not renamed to '{expectedName}'.");
    }

    [When(@"admin an mon hien tai")]
    public async Task WhenAdminAnMonHienTai()
    {
        var menuId = TestRuntime.Get<int>("menuId");
        var current = await TestRuntime.Api.FindMenuItemAsync(menuId);
        await TestRuntime.Api.PutJsonAsync($"/menu/{menuId}", new
        {
            name = current?["name"]?.GetValue<string>() ?? "Auto Admin Dish Updated",
            category = current?["category"]?.GetValue<string>() ?? "Mon chinh",
            price = current?["price"]?.GetValue<int>() ?? 101000,
            imageUrl = current?["imageUrl"]?.GetValue<string>() ?? "https://example.com/auto-edited.jpg",
            available = false
        });
    }

    [Then(@"backend ghi nhan mon hien tai bi an")]
    public async Task ThenBackendGhiNhanMonHienTaiBiAn()
    {
        var menuId = TestRuntime.Get<int>("menuId");
        await Polling.UntilAsync(async () =>
        {
            var item = await TestRuntime.Api.FindMenuItemAsync(menuId);
            return item?["available"]?.GetValue<bool>() == false;
        }, $"Menu item {menuId} was not hidden.");
    }

    [When(@"admin xoa mon hien tai")]
    public async Task WhenAdminXoaMonHienTai()
    {
        var menuId = TestRuntime.Get<int>("menuId");
        await TestRuntime.Api.DeleteJsonAsync($"/menu/{menuId}");
    }

    [Then(@"backend khong con mon hien tai")]
    public async Task ThenBackendKhongConMonHienTai()
    {
        var menuId = TestRuntime.Get<int>("menuId");
        await Polling.UntilAsync(
            async () => await TestRuntime.Api.FindMenuItemAsync(menuId) is null,
            $"Menu item {menuId} was not deleted.");
    }

    [When(@"admin tao nhan vien ""([^""]+)"" tai khoan ""([^""]+)""")]
    public async Task WhenAdminTaoNhanVienTaiKhoan(string employeeName, string username)
    {
        FlutterUi.ClickNav(7);
        FlutterUi.ClickLabel("action-add-employee");
        FlutterUi.FillVisibleInputs(employeeName, "Phuc vu", "0911111111", "300000", username, "123");
        FlutterUi.ClickLastButton();

        await Polling.UntilAsync(async () =>
        {
            var employee = await TestRuntime.Api.FindEmployeeByNameAsync(employeeName);
            if (employee is null)
            {
                return false;
            }

            TestRuntime.Set("employeeId", employee["id"]?.GetValue<int>() ?? 0);
            return true;
        }, $"Employee '{employeeName}' was not created.");
    }

    [When(@"admin sua nhan vien hien tai thanh ""([^""]+)"" tai khoan ""([^""]+)""")]
    public async Task WhenAdminSuaNhanVienHienTaiThanhTaiKhoan(string newName, string username)
    {
        var employeeId = TestRuntime.Get<int>("employeeId");
        await TestRuntime.Api.PutJsonAsync($"/employees/{employeeId}", new
        {
            name = newName,
            role = "Thu ngan",
            phone = "0922222222",
            salaryPerDay = 350000,
            username,
            password = "456",
            accountRole = "staff"
        });
    }

    [Then(@"backend ghi nhan nhan vien hien tai ten ""([^""]+)""")]
    public async Task ThenBackendGhiNhanNhanVienHienTaiTen(string expectedName)
    {
        var employeeId = TestRuntime.Get<int>("employeeId");
        await Polling.UntilAsync(async () =>
        {
            var employee = await TestRuntime.Api.FindEmployeeAsync(employeeId);
            return string.Equals(employee?["name"]?.GetValue<string>(), expectedName, StringComparison.OrdinalIgnoreCase);
        }, $"Employee {employeeId} was not renamed to '{expectedName}'.");
    }

    [When(@"admin khoa nhan vien hien tai")]
    public async Task WhenAdminKhoaNhanVienHienTai()
    {
        var employeeId = TestRuntime.Get<int>("employeeId");
        await TestRuntime.Api.DeleteJsonAsync($"/employees/{employeeId}");
    }

    [Then(@"backend ghi nhan nhan vien hien tai bi khoa")]
    public async Task ThenBackendGhiNhanNhanVienHienTaiBiKhoa()
    {
        var employeeId = TestRuntime.Get<int>("employeeId");
        await Polling.UntilAsync(async () =>
        {
            var employee = await TestRuntime.Api.FindEmployeeAsync(employeeId);
            return employee?["active"]?.GetValue<bool>() == false;
        }, $"Employee {employeeId} was not locked.");
    }

    [When(@"admin tao thong bao ""([^""]+)"" noi dung ""([^""]+)""")]
    public async Task WhenAdminTaoThongBaoNoiDung(string title, string body)
    {
        FlutterUi.ClickNav(8);
        FlutterUi.ClickLabel("action-create-notification");
        FlutterUi.FillVisibleInputs(title, body);
        FlutterUi.ClickLastButton();

        await Polling.UntilAsync(async () =>
        {
            var notification = await TestRuntime.Api.FindNotificationByTitleAsync(title);
            if (notification is null)
            {
                return false;
            }

            TestRuntime.Set("notificationId", notification["id"]?.GetValue<int>() ?? 0);
            return true;
        }, $"Notification '{title}' was not created.");
    }

    [When(@"admin xoa thong bao hien tai")]
    public async Task WhenAdminXoaThongBaoHienTai()
    {
        var notificationId = TestRuntime.Get<int>("notificationId");
        await TestRuntime.Api.DeleteJsonAsync($"/notifications/{notificationId}");
    }

    [Then(@"backend khong con thong bao hien tai")]
    public async Task ThenBackendKhongConThongBaoHienTai()
    {
        var notificationId = TestRuntime.Get<int>("notificationId");
        await Polling.UntilAsync(async () =>
        {
            var rows = await TestRuntime.Api.GetArrayAsync("/notifications");
            return rows.All(item => item?["id"]?.GetValue<int>() != notificationId);
        }, $"Notification {notificationId} was not deleted.");
    }

    [When(@"admin xem bang luong thang ""([^""]+)""")]
    public void WhenAdminXemBangLuongThang(string month)
    {
        FlutterUi.ClickNav(9);
        FlutterUi.ClickLabel("action-payroll-month");
        FlutterUi.FillVisibleInputs(month);
        FlutterUi.ClickLastButton();
        TestRuntime.Set("payrollMonth", month);
    }

    [Then(@"backend tra ve bang luong thang hien tai")]
    public async Task ThenBackendTraVeBangLuongThangHienTai()
    {
        var month = TestRuntime.Get<string>("payrollMonth");
        var payroll = await TestRuntime.Api.GetJsonAsync($"/payroll?month={month}");
        Assert.That(payroll["month"]?.GetValue<string>(), Is.EqualTo(month));
        Assert.That(payroll["rows"]?.AsArray().Count, Is.GreaterThan(0));
    }

    [Given(@"backend co them ban tam ""([^""]+)""")]
    public async Task GivenBackendCoThemBanTam(string tableName)
    {
        await TestRuntime.Api.PostJsonAsync("/tables", new
        {
            name = tableName,
            seats = 2,
            area = "Auto Reset"
        });
    }

    [When(@"admin reset du lieu demo tren web")]
    public void WhenAdminResetDuLieuDemoTrenWeb()
    {
        FlutterUi.ClickNav(10);
        FlutterUi.ClickLabel("action-reset-demo");
    }

    [Then(@"backend duoc reset ve (\d+) ban")]
    public async Task ThenBackendDuocResetVeBan(int expectedCount)
    {
        await Polling.UntilAsync(async () =>
        {
            var tables = await TestRuntime.Api.GetArrayAsync("/tables");
            return tables.Count == expectedCount;
        }, $"Backend was not reset to {expectedCount} tables.");
    }
}
