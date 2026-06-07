using AutoTest.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace AutoTest.StepDefinitions;

[Binding]
public sealed class CustomerSteps
{
    [When(@"toi dang nhap khach hang voi tai khoan ""([^""]+)"" mat khau ""([^""]+)""")]
    public void WhenToiDangNhapKhachHang(string username, string password)
    {
        TestRuntime.Browser.Fill(By.CssSelector("#username"), username);
        TestRuntime.Browser.Fill(By.CssSelector("#password"), password);
        TestRuntime.Browser.Click(By.CssSelector("#loginForm button[type='submit']"));
    }

    [Then(@"khong gian khach hang duoc hien thi")]
    public void ThenKhongGianKhachHangDuocHienThi()
    {
        TestRuntime.Browser.WaitVisible(By.CssSelector("#appView:not(.hidden)"));
        TestRuntime.Browser.WaitUntil(
            driver => driver.FindElements(By.CssSelector("[data-table]")).Count > 0
                && driver.FindElements(By.CssSelector("[data-add]")).Count > 0,
            "Customer workspace did not load tables and menu items.");
    }

    [Then(@"loi dang nhap khach hang hien ""([^""]+)""")]
    public void ThenLoiDangNhapKhachHangHien(string expectedText)
    {
        TestRuntime.Browser.WaitForCssText("#loginError", expectedText);
    }

    [Then(@"khach hang thay ban ""([^""]+)""")]
    public void ThenKhachHangThayBan(string tableName)
    {
        TestRuntime.Browser.WaitForCssText("#tableGrid", tableName);
    }

    [Then(@"khach hang thay mon ""([^""]+)""")]
    public void ThenKhachHangThayMon(string menuName)
    {
        TestRuntime.Browser.WaitForCssText("#menuGrid", menuName);
    }

    [When(@"toi chon ban co ma (\d+)")]
    public void WhenToiChonBanCoMa(int tableId)
    {
        var selector = $"[data-table='{tableId}']";
        TestRuntime.Browser.Click(By.CssSelector(selector));
        TestRuntime.Browser.WaitUntil(
            driver => driver.FindElement(By.CssSelector(selector)).GetDomAttribute("class")?.Contains("selected", StringComparison.OrdinalIgnoreCase) == true,
            $"Table {tableId} was not selected.");
    }

    [When(@"toi chuyen sang che do dat ban")]
    public void WhenToiChuyenSangCheDoDatBan()
    {
        TestRuntime.Browser.Click(By.CssSelector("#modeReserve"));
    }

    [When(@"toi nhap so khach ""([^""]+)"" va ghi chu ""([^""]+)""")]
    public void WhenToiNhapSoKhachVaGhiChu(string partySize, string note)
    {
        TestRuntime.Browser.Fill(By.CssSelector("#partySize"), partySize);
        TestRuntime.Browser.Fill(By.CssSelector("#note"), note);
    }

    [When(@"toi gui yeu cau khach hang")]
    public void WhenToiGuiYeuCauKhachHang()
    {
        TestRuntime.Browser.Click(By.CssSelector("#submitAction"));
    }

    [Then(@"thong bao thao tac khach hang hien ""([^""]+)""")]
    public void ThenThongBaoThaoTacKhachHangHien(string expectedText)
    {
        TestRuntime.Browser.WaitForCssText("#actionMessage", expectedText);
    }

    [Then(@"backend ghi nhan ban (\d+) co trang thai ""([^""]+)""")]
    public async Task ThenBackendGhiNhanBanCoTrangThai(int tableId, string status)
    {
        await Polling.UntilAsync(async () =>
        {
            var table = await TestRuntime.Api.FindTableAsync(tableId);
            return string.Equals(table?["status"]?.GetValue<string>(), status, StringComparison.OrdinalIgnoreCase);
        }, $"Table {tableId} did not reach status '{status}'.");
    }

    [When(@"toi them mon co ma (\d+) vao gio")]
    public void WhenToiThemMonCoMaVaoGio(int menuId)
    {
        TestRuntime.Browser.Click(By.CssSelector($"[data-add='{menuId}']"));
    }

    [Then(@"gio hang khach hang co ""([^""]+)"" mon")]
    public void ThenGioHangKhachHangCoMon(string expectedCount)
    {
        TestRuntime.Browser.WaitForCssText("#cartCount", expectedCount);
    }

    [Then(@"backend co hoa don mo cua khach hang (\d+) tai ban (\d+) voi (\d+) dong mon")]
    public async Task ThenBackendCoHoaDonMoCuaKhachHangTaiBanVoiDongMon(int customerId, int tableId, int expectedItems)
    {
        await Polling.UntilAsync(async () =>
        {
            var order = await TestRuntime.Api.FindCustomerOrderAsync(customerId, tableId, "open");
            if (order is null)
            {
                return false;
            }

            TestRuntime.Set("customerOrderId", order["id"]?.GetValue<int>() ?? 0);
            return order["items"]?.AsArray().Count == expectedItems;
        }, $"Open customer order on table {tableId} was not created with {expectedItems} items.");
    }

    [When(@"admin thanh toan hoa don mo cua khach hang (\d+) tai ban (\d+)")]
    public async Task WhenAdminThanhToanHoaDonMoCuaKhachHangTaiBan(int customerId, int tableId)
    {
        var order = await TestRuntime.Api.FindCustomerOrderAsync(customerId, tableId, "open");
        Assert.That(order, Is.Not.Null);
        var orderId = order!["id"]?.GetValue<int>() ?? 0;
        TestRuntime.Set("customerOrderId", orderId);
        await TestRuntime.Api.PostJsonAsync($"/orders/{orderId}/pay", new
        {
            role = "admin",
            userName = "Auto Admin",
            discount = 0
        });
    }

    [Then(@"khach hang thay hoa don vua thanh toan")]
    public void ThenKhachHangThayHoaDonVuaThanhToan()
    {
        var orderId = TestRuntime.Get<int>("customerOrderId");
        TestRuntime.Browser.Click(By.CssSelector("#refreshBtn"));
        TestRuntime.Browser.WaitForCssText("#paymentList", $"HD #{orderId}");
    }

    [When(@"toi loc danh muc khach hang ""([^""]+)""")]
    public void WhenToiLocDanhMucKhachHang(string category)
    {
        TestRuntime.Browser.Click(By.CssSelector("[data-jump='menu']"));
        TestRuntime.Browser.Click(By.CssSelector($"[data-category='{category}']"));
    }

    [Then(@"luoi mon khach hang hien ""([^""]+)"" va khong hien ""([^""]+)""")]
    public void ThenLuoiMonKhachHangHienVaKhongHien(string visibleItem, string hiddenItem)
    {
        TestRuntime.Browser.WaitForCssText("#menuGrid", visibleItem);
        var text = TestRuntime.Browser.WaitVisible(By.CssSelector("#menuGrid")).Text;
        Assert.That(text, Does.Not.Contain(hiddenItem));
    }

    [When(@"toi doi viewport khach hang thanh (\d+) x (\d+) va tai lai")]
    public void WhenToiDoiViewportKhachHangThanhVaTaiLai(int width, int height)
    {
        TestRuntime.Browser.SetViewport(width, height);
        TestRuntime.Browser.Driver.Navigate().Refresh();
        ThenKhongGianKhachHangDuocHienThi();
    }

    [When(@"toi dang xuat khach hang")]
    public void WhenToiDangXuatKhachHang()
    {
        TestRuntime.Browser.Click(By.CssSelector("#logoutBtn"));
    }

    [Then(@"session khach hang duoc xoa")]
    public void ThenSessionKhachHangDuocXoa()
    {
        var value = TestRuntime.Browser.JavaScript.ExecuteScript("return localStorage.getItem('restaurantCustomer');");
        Assert.That(value, Is.Null);
    }
}
