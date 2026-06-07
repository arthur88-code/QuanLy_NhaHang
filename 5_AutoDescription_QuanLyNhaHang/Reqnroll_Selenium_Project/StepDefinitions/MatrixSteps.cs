using System.Diagnostics;
using System.Net;
using System.Text.Json.Nodes;
using AutoTest.Support;
using NUnit.Framework;
using Reqnroll;

namespace AutoTest.StepDefinitions;

[Binding]
public sealed class MatrixSteps
{
    [When(@"tôi chạy testcase tự động ""([^""]+)""")]
    public async Task WhenToiChayTestcaseTuDong(string id)
    {
        await RunCaseAsync(id);
        TestRuntime.Set($"matrix-{id}", true);
    }

    [Then(@"testcase ""([^""]+)"" đạt yêu cầu")]
    public void ThenTestcaseDatYeuCau(string id)
    {
        Assert.That(TestRuntime.Get<bool>($"matrix-{id}"), Is.True);
    }

    private static async Task RunCaseAsync(string id)
    {
        switch (id)
        {
            case "AUTO-001":
                Assert.That((await TestRuntime.Api.PostJsonAsync("/auth/login", new { username = "staff", password = "123" }))["user"]?["role"]?.GetValue<string>(), Is.EqualTo("staff"));
                break;
            case "AUTO-002":
                Assert.That((await TestRuntime.Api.PostJsonAsync("/auth/login", new { username = "admin", password = "123" }))["user"]?["role"]?.GetValue<string>(), Is.EqualTo("admin"));
                break;
            case "AUTO-003":
                Assert.That((await TestRuntime.Api.PostJsonAsync("/auth/customer-login", new { username = "customer001", password = "123" }))["customer"]?["id"]?.GetValue<int>(), Is.EqualTo(1));
                break;
            case "AUTO-004":
                await TestRuntime.Api.AssertStatusAsync(HttpMethod.Post, "/auth/login", 401, new { username = "staff", password = "bad" });
                break;
            case "AUTO-005":
                await TestRuntime.Api.AssertStatusAsync(HttpMethod.Post, "/auth/customer-login", 401, new { username = "customer001", password = "bad" });
                break;
            case "AUTO-006":
                {
                    var employee = await TestRuntime.Api.CreateEmployeeAsync("Auto Locked Login", "autolockedlogin");
                    await TestRuntime.Api.DeleteJsonAsync($"/employees/{employee["id"]?.GetValue<int>()}");
                    await TestRuntime.Api.AssertStatusAsync(HttpMethod.Post, "/auth/login", 401, new { username = "autolockedlogin", password = "123" });
                    break;
                }
            case "AUTO-007":
                await TestRuntime.Api.CreateEmployeeAsync("Auto Admin Role", "autoadminrole", "admin");
                Assert.That((await TestRuntime.Api.PostJsonAsync("/auth/login", new { username = "autoadminrole", password = "123" }))["user"]?["role"]?.GetValue<string>(), Is.EqualTo("admin"));
                break;
            case "AUTO-008":
                {
                    var employee = await TestRuntime.Api.CreateEmployeeAsync("Auto Unique Username", "staff");
                    Assert.That(employee["account"]?["username"]?.GetValue<string>(), Is.Not.EqualTo("staff"));
                    break;
                }
            case "AUTO-009":
                {
                    var bootstrap = await TestRuntime.Api.GetJsonAsync("/customer-api/bootstrap?customerId=1");
                    Assert.That(bootstrap["tables"]?.AsArray().Count, Is.EqualTo(16));
                    Assert.That(bootstrap["menu"]?.AsArray().Count, Is.EqualTo(52));
                    break;
                }
            case "AUTO-010":
                Assert.That((await TestRuntime.Api.GetJsonAsync("/customer-api/bootstrap?customerId=999"))["customer"], Is.Null);
                break;
            case "AUTO-011":
                Assert.That((await TestRuntime.Api.GetArrayAsync("/customer-api/reservations?customerId=10")).Any(item => item?["tableId"]?.GetValue<int>() == 6), Is.True);
                break;
            case "AUTO-012":
                Assert.That((await CreateReservationAsync(1, 7))["reservation"]?["status"]?.GetValue<string>(), Is.EqualTo("confirmed"));
                break;
            case "AUTO-013":
                await TestRuntime.Api.AssertStatusAsync(HttpMethod.Post, "/customer-api/reservations", 409, new { customerId = 1, tableId = 3, partySize = 4 });
                break;
            case "AUTO-014":
                await TestRuntime.Api.AssertStatusAsync(HttpMethod.Post, "/customer-api/orders", 400, new { customerId = 1, tableId = 7, items = Array.Empty<object>() });
                break;
            case "AUTO-015":
                {
                    var created = await CreateCustomerOrderAsync(1, 7, new[] { new MenuRow(1, 1) });
                    Assert.That(created["order"]?["source"]?.GetValue<string>(), Is.EqualTo("customer_web"));
                    break;
                }
            case "AUTO-016":
                {
                    var first = await CreateCustomerOrderAsync(1, 7, new[] { new MenuRow(1, 1) });
                    var second = await CreateCustomerOrderAsync(1, 7, new[] { new MenuRow(2, 1) });
                    Assert.That(second["order"]?["id"]?.GetValue<int>(), Is.EqualTo(first["order"]?["id"]?.GetValue<int>()));
                    Assert.That(second["order"]?["items"]?.AsArray().Count, Is.EqualTo(2));
                    break;
                }
            case "AUTO-017":
                await CreateCustomerOrderAsync(1, 7, new[] { new MenuRow(1, 1) });
                await TestRuntime.Api.AssertStatusAsync(HttpMethod.Post, "/customer-api/orders", 409, new { customerId = 2, tableId = 7, items = new[] { new { menuItemId = 2, quantity = 1 } } });
                break;
            case "AUTO-018":
                {
                    var created = await CreateCustomerOrderAsync(1, 7, new[] { new MenuRow(1, 1) });
                    var orderId = created["order"]?["id"]?.GetValue<int>() ?? 0;
                    await PayOrderAsync(orderId, "admin", "Auto Admin");
                    Assert.That((await TestRuntime.Api.GetArrayAsync("/customer-api/paid-history?customerId=1")).Any(item => item?["id"]?.GetValue<int>() == orderId), Is.True);
                    break;
                }
            case "AUTO-019":
                Assert.That((await TestRuntime.Api.GetArrayAsync("/tables")).Count, Is.EqualTo(16));
                break;
            case "AUTO-020":
                Assert.That((await CreateTableAsync("Auto Matrix Table"))["id"]?.GetValue<int>(), Is.GreaterThan(16));
                break;
            case "AUTO-021":
                {
                    var table = await CreateTableAsync("Auto Patch Table");
                    var updated = await TestRuntime.Api.PatchJsonAsync($"/tables/{table["id"]?.GetValue<int>()}", new { name = "Auto Patch Table Updated", seats = 6, area = "Auto Area" });
                    Assert.That(updated["seats"]?.GetValue<int>(), Is.EqualTo(6));
                    break;
                }
            case "AUTO-022":
                {
                    var table = await CreateTableAsync("Auto Delete Table");
                    await TestRuntime.Api.DeleteJsonAsync($"/tables/{table["id"]?.GetValue<int>()}");
                    Assert.That(await TestRuntime.Api.FindTableByNameAsync("Auto Delete Table"), Is.Null);
                    break;
                }
            case "AUTO-023":
                await TestRuntime.Api.CreateStaffOrderWithItemAsync(7);
                await TestRuntime.Api.AssertStatusAsync(HttpMethod.Delete, "/tables/7", 409);
                break;
            case "AUTO-024":
                {
                    var statuses = (await TestRuntime.Api.GetArrayAsync("/tables")).Select(item => item?["status"]?.GetValue<string>()).ToArray();
                    Assert.That(statuses, Does.Contain("available").And.Contain("reserved").And.Contain("occupied"));
                    break;
                }
            case "AUTO-025":
                {
                    var order = await TestRuntime.Api.CreateStaffOrderWithItemAsync(7);
                    Assert.That((await TestRuntime.Api.FindTableAsync(7))?["activeOrderId"]?.GetValue<int>(), Is.EqualTo(order["id"]?.GetValue<int>()));
                    break;
                }
            case "AUTO-026":
                await CreateTableAsync("Auto Before Reset");
                await TestRuntime.Api.PostJsonAsync("/admin/reset", new { });
                Assert.That((await TestRuntime.Api.GetArrayAsync("/tables")).Count, Is.EqualTo(16));
                break;
            case "AUTO-027":
                Assert.That((await TestRuntime.Api.GetArrayAsync("/menu")).Count, Is.EqualTo(52));
                break;
            case "AUTO-028":
                Assert.That((await TestRuntime.Api.PostJsonAsync("/menu", new { }))["name"]?.GetValue<string>(), Is.EqualTo("Mon moi"));
                break;
            case "AUTO-029":
                {
                    var item = await TestRuntime.Api.PostJsonAsync("/menu", new { name = "Auto Custom Dish", category = "Auto", price = 123000, imageUrl = "https://example.com/auto.jpg" });
                    Assert.That(item["category"]?.GetValue<string>(), Is.EqualTo("Auto"));
                    Assert.That(item["price"]?.GetValue<int>(), Is.EqualTo(123000));
                    break;
                }
            case "AUTO-030":
                {
                    var item = await TestRuntime.Api.CreateMenuItemAsync("Auto Price Dish");
                    var updated = await TestRuntime.Api.PutJsonAsync($"/menu/{item["id"]?.GetValue<int>()}", new { name = "Auto Price Dish", category = "Mon chinh", price = 99000, imageUrl = "https://example.com/a.jpg", available = true });
                    Assert.That(updated["price"]?.GetValue<int>(), Is.EqualTo(99000));
                    break;
                }
            case "AUTO-031":
                {
                    var item = await TestRuntime.Api.CreateMenuItemAsync("Auto Hidden Dish");
                    var updated = await TestRuntime.Api.PutJsonAsync($"/menu/{item["id"]?.GetValue<int>()}", new { name = "Auto Hidden Dish", category = "Mon chinh", price = 88000, imageUrl = "https://example.com/a.jpg", available = false });
                    Assert.That(updated["available"]?.GetValue<bool>(), Is.False);
                    break;
                }
            case "AUTO-032":
                {
                    var item = await TestRuntime.Api.CreateMenuItemAsync("Auto Delete Dish");
                    await TestRuntime.Api.DeleteJsonAsync($"/menu/{item["id"]?.GetValue<int>()}");
                    Assert.That(await TestRuntime.Api.FindMenuItemAsync(item["id"]?.GetValue<int>() ?? 0), Is.Null);
                    break;
                }
            case "AUTO-033":
                {
                    var item = await TestRuntime.Api.CreateMenuItemAsync("Auto Customer Hidden Dish");
                    await TestRuntime.Api.PutJsonAsync($"/menu/{item["id"]?.GetValue<int>()}", new { name = "Auto Customer Hidden Dish", category = "Mon chinh", price = 88000, imageUrl = "https://example.com/a.jpg", available = false });
                    var bootstrap = await TestRuntime.Api.GetJsonAsync("/customer-api/bootstrap?customerId=1");
                    Assert.That(bootstrap["menu"]?.AsArray().Any(row => row?["id"]?.GetValue<int>() == item["id"]?.GetValue<int>()), Is.False);
                    break;
                }
            case "AUTO-034":
                {
                    var item = await TestRuntime.Api.CreateMenuItemAsync("Auto Unavailable Order Dish");
                    await TestRuntime.Api.PutJsonAsync($"/menu/{item["id"]?.GetValue<int>()}", new { name = "Auto Unavailable Order Dish", category = "Mon chinh", price = 88000, imageUrl = "https://example.com/a.jpg", available = false });
                    await TestRuntime.Api.AssertStatusAsync(HttpMethod.Post, "/customer-api/orders", 400, new { customerId = 1, tableId = 7, items = new[] { new { menuItemId = item["id"]?.GetValue<int>(), quantity = 1 } } });
                    break;
                }
            case "AUTO-035":
                Assert.That((await TestRuntime.Api.GetArrayAsync("/orders")).Count, Is.EqualTo(10));
                break;
            case "AUTO-036":
                Assert.That((await CreateStaffOrderAsync(7))["status"]?.GetValue<string>(), Is.EqualTo("open"));
                break;
            case "AUTO-037":
                {
                    var order = await CreateStaffOrderAsync(7);
                    Assert.That((await TestRuntime.Api.FindOpenOrderForTableAsync(7))?["id"]?.GetValue<int>(), Is.EqualTo(order["id"]?.GetValue<int>()));
                    break;
                }
            case "AUTO-038":
                {
                    var first = await CreateStaffOrderAsync(7);
                    var second = await CreateStaffOrderAsync(7);
                    Assert.That(second["id"]?.GetValue<int>(), Is.EqualTo(first["id"]?.GetValue<int>()));
                    break;
                }
            case "AUTO-039":
                {
                    var order = await CreateStaffOrderAsync(7);
                    var updated = await AddBatchAsync(order["id"]?.GetValue<int>() ?? 0, 1, 2);
                    Assert.That(updated["batches"]?.AsArray().Count, Is.EqualTo(1));
                    break;
                }
            case "AUTO-040":
                {
                    var order = await CreateStaffOrderAsync(7);
                    var updated = await TestRuntime.Api.PostJsonAsync($"/orders/{order["id"]?.GetValue<int>()}/items", new { menuItemId = 1, quantity = 2, createdBy = "Auto Staff" });
                    Assert.That(updated["items"]?.AsArray().Count, Is.EqualTo(1));
                    break;
                }
            case "AUTO-041":
                {
                    var order = await TestRuntime.Api.CreateStaffOrderWithItemAsync(7);
                    var updated = await TestRuntime.Api.PatchJsonAsync($"/orders/{order["id"]?.GetValue<int>()}/items/1", new { quantity = 5 });
                    Assert.That(updated["items"]?[0]?["quantity"]?.GetValue<int>(), Is.EqualTo(5));
                    break;
                }
            case "AUTO-042":
                {
                    var order = await TestRuntime.Api.CreateStaffOrderWithItemAsync(7);
                    var updated = await TestRuntime.Api.PatchJsonAsync($"/orders/{order["id"]?.GetValue<int>()}/items/1", new { quantity = 0 });
                    Assert.That(updated["items"]?.AsArray().Count, Is.EqualTo(0));
                    break;
                }
            case "AUTO-043":
                {
                    var order = await TestRuntime.Api.CreateStaffOrderWithItemAsync(7);
                    Assert.That((await PayOrderAsync(order["id"]?.GetValue<int>() ?? 0, "staff", "Auto Staff"))["status"]?.GetValue<string>(), Is.EqualTo("paid"));
                    break;
                }
            case "AUTO-044":
                {
                    var order = await TestRuntime.Api.CreateStaffOrderWithItemAsync(7);
                    await TestRuntime.Api.AssertStatusAsync(HttpMethod.Post, $"/orders/{order["id"]?.GetValue<int>()}/pay", 403, new { role = "customer", userName = "Bad", discount = 0 });
                    break;
                }
            case "AUTO-045":
                {
                    var order = await TestRuntime.Api.CreateStaffOrderWithItemAsync(7);
                    var result = await TestRuntime.Api.PostJsonAsync($"/orders/{order["id"]?.GetValue<int>()}/debt", new { role = "staff", customerName = "Auto Debt", customerPhone = "0909" });
                    Assert.That(result["debt"]?["status"]?.GetValue<string>(), Is.EqualTo("open"));
                    break;
                }
            case "AUTO-046":
                {
                    var order = await TestRuntime.Api.CreateStaffOrderWithItemAsync(7);
                    await PayOrderAsync(order["id"]?.GetValue<int>() ?? 0, "admin", "Auto Admin");
                    Assert.That((await TestRuntime.Api.GetArrayAsync("/orders?status=paid")).Any(item => item?["id"]?.GetValue<int>() == order["id"]?.GetValue<int>()), Is.True);
                    break;
                }
            case "AUTO-047":
                Assert.That((await TestRuntime.Api.GetArrayAsync("/debts")).Count, Is.GreaterThanOrEqualTo(2));
                break;
            case "AUTO-048":
                Assert.That((await TestRuntime.Api.GetArrayAsync("/debts?status=open")).All(item => item?["status"]?.GetValue<string>() == "open"), Is.True);
                break;
            case "AUTO-049":
                Assert.That((await TestRuntime.Api.PatchJsonAsync("/debts/1/pay", new { role = "staff", amount = 1000 }))["status"]?.GetValue<string>(), Is.EqualTo("open"));
                break;
            case "AUTO-050":
                {
                    var debt = (await TestRuntime.Api.GetArrayAsync("/debts")).First(item => item?["id"]?.GetValue<int>() == 1)!;
                    var remaining = (debt["amount"]?.GetValue<int>() ?? 0) - (debt["paidAmount"]?.GetValue<int>() ?? 0);
                    Assert.That((await TestRuntime.Api.PatchJsonAsync("/debts/1/pay", new { role = "staff", amount = remaining }))["status"]?.GetValue<string>(), Is.EqualTo("paid"));
                    break;
                }
            case "AUTO-051":
                await TestRuntime.Api.AssertStatusAsync(HttpMethod.Patch, "/debts/999/pay", 404, new { role = "staff", amount = 1 });
                break;
            case "AUTO-052":
                await TestRuntime.Api.AssertStatusAsync(HttpMethod.Patch, "/debts/1/pay", 403, new { role = "guest", amount = 1 });
                break;
            case "AUTO-053":
                Assert.That((await TestRuntime.Api.GetArrayAsync("/employees")).Count, Is.EqualTo(12));
                break;
            case "AUTO-054":
                Assert.That((await TestRuntime.Api.CreateEmployeeAsync("Auto Employee Matrix", "autoempmatrix"))["account"]?["username"]?.GetValue<string>(), Is.EqualTo("autoempmatrix"));
                break;
            case "AUTO-055":
                Assert.That((await TestRuntime.Api.CreateEmployeeAsync("Auto Duplicate Staff", "staff"))["account"]?["username"]?.GetValue<string>(), Is.Not.EqualTo("staff"));
                break;
            case "AUTO-056":
                {
                    var employee = await TestRuntime.Api.CreateEmployeeAsync("Auto Employee Update", "autoempupdate");
                    var updated = await TestRuntime.Api.PutJsonAsync($"/employees/{employee["id"]?.GetValue<int>()}", new { name = "Auto Employee Updated", role = "Thu ngan", phone = "0912", salaryPerDay = 350000, username = "autoempupdated", password = "456", accountRole = "staff" });
                    Assert.That(updated["role"]?.GetValue<string>(), Is.EqualTo("Thu ngan"));
                    break;
                }
            case "AUTO-057":
                {
                    var employee = await TestRuntime.Api.CreateEmployeeAsync("Auto Employee Delete", "autoempdelete");
                    Assert.That((await TestRuntime.Api.DeleteJsonAsync($"/employees/{employee["id"]?.GetValue<int>()}"))["active"]?.GetValue<bool>(), Is.False);
                    break;
                }
            case "AUTO-058":
                {
                    var employee = await TestRuntime.Api.CreateEmployeeAsync("Auto Login Lock", "autologinlock");
                    await TestRuntime.Api.DeleteJsonAsync($"/employees/{employee["id"]?.GetValue<int>()}");
                    await TestRuntime.Api.AssertStatusAsync(HttpMethod.Post, "/auth/login", 401, new { username = "autologinlock", password = "123" });
                    break;
                }
            case "AUTO-059":
                await TestRuntime.Api.CreateEmployeeAsync("Auto Employee Admin Login", "autoempadminlogin", "admin");
                Assert.That((await TestRuntime.Api.PostJsonAsync("/auth/login", new { username = "autoempadminlogin", password = "123" }))["user"]?["role"]?.GetValue<string>(), Is.EqualTo("admin"));
                break;
            case "AUTO-060":
                Assert.That((await TestRuntime.Api.GetArrayAsync("/employees")).First()?["account"]?["password"], Is.Null);
                break;
            case "AUTO-061":
                Assert.That((await TestRuntime.Api.GetArrayAsync("/attendance?date=2026-03-03")).Count, Is.GreaterThan(0));
                break;
            case "AUTO-062":
                Assert.That((await TestRuntime.Api.PostJsonAsync("/attendance/check-in", new { employeeId = 2, date = "2026-06-01", note = "Auto" }))["employeeId"]?.GetValue<int>(), Is.EqualTo(2));
                break;
            case "AUTO-063":
                {
                    var first = await TestRuntime.Api.PostJsonAsync("/attendance/check-in", new { employeeId = 2, date = "2026-06-01", note = "Auto" });
                    var second = await TestRuntime.Api.PostJsonAsync("/attendance/check-in", new { employeeId = 2, date = "2026-06-01", note = "Auto again" });
                    Assert.That(second["id"]?.GetValue<int>(), Is.EqualTo(first["id"]?.GetValue<int>()));
                    break;
                }
            case "AUTO-064":
                {
                    var row = await TestRuntime.Api.PostJsonAsync("/attendance/check-in", new { employeeId = 2, date = "2026-06-01", note = "Auto" });
                    Assert.That((await TestRuntime.Api.PatchJsonAsync($"/attendance/{row["id"]?.GetValue<int>()}/check-out", new { note = "Out" }))["checkOut"]?.GetValue<string>(), Is.Not.Empty);
                    break;
                }
            case "AUTO-065":
                await TestRuntime.Api.AssertStatusAsync(HttpMethod.Patch, "/attendance/99999/check-out", 404, new { });
                break;
            case "AUTO-066":
                {
                    var payroll = await TestRuntime.Api.GetJsonAsync("/payroll?month=2026-05");
                    Assert.That(payroll["rows"]?.AsArray().Count, Is.EqualTo(12));
                    Assert.That(payroll["totalSalary"]?.GetValue<int>(), Is.GreaterThan(0));
                    break;
                }
            case "AUTO-067":
                {
                    var dashboard = await TestRuntime.Api.GetJsonAsync("/dashboard");
                    Assert.That(dashboard["tableCount"]?.GetValue<int>(), Is.EqualTo(16));
                    Assert.That(dashboard["customerCount"]?.GetValue<int>(), Is.EqualTo(100));
                    break;
                }
            case "AUTO-068":
                {
                    var dashboard = await TestRuntime.Api.GetJsonAsync("/dashboard");
                    Assert.That(dashboard["recentOrders"]?.AsArray().Count, Is.LessThanOrEqualTo(5));
                    Assert.That(dashboard["notifications"]?.AsArray().Count, Is.LessThanOrEqualTo(3));
                    break;
                }
            case "AUTO-069":
                Assert.That((await TestRuntime.Api.GetJsonAsync("/stats?period=day&date=2026-05-20T12:00:00Z"))["period"]?.GetValue<string>(), Is.EqualTo("day"));
                break;
            case "AUTO-070":
                Assert.That((await TestRuntime.Api.GetJsonAsync("/stats?period=month&date=2026-05-10T12:00:00Z"))["orderCount"]?.GetValue<int>(), Is.GreaterThan(0));
                break;
            case "AUTO-071":
                Assert.That((await TestRuntime.Api.GetJsonAsync("/stats?period=year&date=2026-05-10T12:00:00Z"))["topItems"]?.AsArray().Count, Is.GreaterThan(0));
                break;
            case "AUTO-072":
                Assert.That((await TestRuntime.Api.GetJsonAsync("/payroll?month=2026-05"))["month"]?.GetValue<string>(), Is.EqualTo("2026-05"));
                break;
            case "AUTO-073":
                Assert.That((await TestRuntime.Api.GetJsonAsync("/admin/health"))["status"]?.GetValue<string>(), Is.EqualTo("ok"));
                break;
            case "AUTO-074":
                {
                    var export = await TestRuntime.Api.GetJsonAsync("/admin/export");
                    Assert.That(export["tables"]?.AsArray().Count, Is.EqualTo(16));
                    Assert.That(export["customers"]?.AsArray().Count, Is.EqualTo(100));
                    break;
                }
            case "AUTO-075":
                await CreateTableAsync("Auto Admin Reset");
                await TestRuntime.Api.PostJsonAsync("/admin/reset", new { });
                Assert.That((await TestRuntime.Api.GetJsonAsync("/admin/health"))["tables"]?.GetValue<int>(), Is.EqualTo(16));
                break;
            case "AUTO-076":
                Assert.That((await TestRuntime.Api.PostJsonAsync("/notifications", new { title = "Auto Notice Matrix", body = "Body", audience = "all" }))["title"]?.GetValue<string>(), Is.EqualTo("Auto Notice Matrix"));
                break;
            case "AUTO-077":
                {
                    var notice = await TestRuntime.Api.PostJsonAsync("/notifications", new { title = "Auto Delete Notice", body = "Body", audience = "all" });
                    await TestRuntime.Api.DeleteJsonAsync($"/notifications/{notice["id"]?.GetValue<int>()}");
                    Assert.That(await TestRuntime.Api.FindNotificationByTitleAsync("Auto Delete Notice"), Is.Null);
                    break;
                }
            case "AUTO-078":
                Assert.That(await TestRuntime.Api.GetStringAsync("/customer/"), Does.Contain("loginForm"));
                break;
            case "AUTO-079":
                Assert.That(await TestRuntime.Api.GetStringAsync("/staff/"), Does.Contain("flutter_bootstrap.js"));
                break;
            case "AUTO-080":
                Assert.That(await TestRuntime.Api.GetStringAsync("/admin-web/"), Does.Contain("flutter_bootstrap.js"));
                break;
            case "AUTO-081":
                await TestRuntime.Api.AssertReadyAsync();
                break;
            case "AUTO-082":
                {
                    var stopwatch = Stopwatch.StartNew();
                    await TestRuntime.Api.GetJsonAsync("/dashboard");
                    stopwatch.Stop();
                    Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(3000));
                    break;
                }
            default:
                Assert.Fail($"Chưa định nghĩa testcase ma trận: {id}");
                break;
        }
    }

    private static Task<JsonNode> CreateReservationAsync(int customerId, int tableId, int partySize = 4)
    {
        return TestRuntime.Api.PostJsonAsync("/customer-api/reservations", new
        {
            customerId,
            tableId,
            partySize,
            reservedAt = "2026-06-01T18:30:00+07:00",
            note = "Auto matrix reservation"
        });
    }

    private static Task<JsonNode> CreateCustomerOrderAsync(int customerId, int tableId, IEnumerable<MenuRow> items)
    {
        return TestRuntime.Api.PostJsonAsync("/customer-api/orders", new
        {
            customerId,
            tableId,
            partySize = 4,
            reservedAt = "2026-06-01T18:30:00+07:00",
            note = "Auto matrix order",
            items
        });
    }

    private static Task<JsonNode> CreateTableAsync(string name)
    {
        return TestRuntime.Api.PostJsonAsync("/tables", new
        {
            name,
            seats = 4,
            area = "Auto Matrix"
        });
    }

    private static Task<JsonNode> CreateStaffOrderAsync(int tableId)
    {
        return TestRuntime.Api.PostJsonAsync("/orders", new
        {
            tableId,
            staffId = 2,
            staffName = "Nguyen Minh Quan"
        });
    }

    private static Task<JsonNode> AddBatchAsync(int orderId, int menuItemId, int quantity)
    {
        return TestRuntime.Api.PostJsonAsync($"/orders/{orderId}/batches", new
        {
            createdBy = "Auto Staff",
            items = new[] { new { menuItemId, quantity } }
        });
    }

    private static Task<JsonNode> PayOrderAsync(int orderId, string role, string userName)
    {
        return TestRuntime.Api.PostJsonAsync($"/orders/{orderId}/pay", new
        {
            role,
            userName,
            discount = 0
        });
    }

    private sealed record MenuRow(int MenuItemId, int Quantity);
}
