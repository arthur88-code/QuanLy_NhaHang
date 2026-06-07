using Microsoft.Playwright;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace RestaurantManagement.E2E;

[TestClass]
public sealed class WebScenarioTests
{
    private const int CustomerId = 1;
    private const int ScenarioTableId = 7;

    private static readonly HttpClient Http = new()
    {
        BaseAddress = new Uri(TestConfig.BackendBaseUrl)
    };

    [TestMethod]
    [TestCategory("Web")]
    public async Task CustomerWeb_LoginShowsCustomerWorkspace()
    {
        await ResetAsync();
        await WithPageAsync(async page =>
        {
            await LoginCustomerAsync(page);

            Assert.IsNotNull(await page.WaitForSelectorAsync("text=So do ban"));
            Assert.IsNotNull(await page.WaitForSelectorAsync("text=Thuc don"));
            Assert.IsNotNull(await page.WaitForSelectorAsync("text=Lich su da xac nhan"));
        });
    }

    [TestMethod]
    [TestCategory("Web")]
    public async Task CustomerWeb_ReserveTableUpdatesHistoryAndBackend()
    {
        await ResetAsync();
        await WithPageAsync(async page =>
        {
            await LoginCustomerAsync(page);
            await SelectTableAsync(page, ScenarioTableId);

            await page.Locator("#modeReserve").ClickAsync();
            await page.Locator("#partySize").FillAsync("3");
            await page.Locator("#note").FillAsync("VS web reserve scenario");
            await page.Locator("#submitAction").ClickAsync();

            await WaitForTextAsync(page, "#actionMessage", "Da dat ban");
            await WaitForTextAsync(page, "#reservationList", "Ban 7");

            var table = await FindTableAsync(ScenarioTableId);
            Assert.AreEqual("reserved", table?["status"]?.GetValue<string>());
            Assert.IsGreaterThan(0, table?["reservationId"]?.GetValue<int>() ?? 0);

            var bootstrap = await GetJsonAsync($"/customer-api/bootstrap?customerId={CustomerId}");
            var reservation = bootstrap["reservations"]?.AsArray()
                .FirstOrDefault(item => item?["tableId"]?.GetValue<int>() == ScenarioTableId);
            Assert.IsNotNull(reservation);
            Assert.AreEqual("confirmed", reservation?["status"]?.GetValue<string>());
            Assert.AreEqual("VS web reserve scenario", reservation?["note"]?.GetValue<string>());
        });
    }

    [TestMethod]
    [TestCategory("Web")]
    public async Task CustomerWeb_OrderCartAndAppendItemsCreatesOpenInvoice()
    {
        await ResetAsync();
        await WithPageAsync(async page =>
        {
            await LoginCustomerAsync(page);
            await SelectTableAsync(page, ScenarioTableId);

            await AddMenuItemAsync(page, 1);
            await AddMenuItemAsync(page, 36);
            await WaitForTextAsync(page, "#cartCount", "2");
            await page.Locator("#note").FillAsync("VS web order scenario");
            await page.Locator("#submitAction").ClickAsync();
            await WaitForTextAsync(page, "#actionMessage", "Da gui mon");

            var order = await FindCustomerOrderAsync(CustomerId, ScenarioTableId, "open");
            var orderId = order?["id"]?.GetValue<int>() ?? 0;
            Assert.IsGreaterThan(0, orderId);
            Assert.AreEqual("customer_web", order?["source"]?.GetValue<string>());
            Assert.AreEqual(2, order?["items"]?.AsArray().Count);
            await WaitForTextAsync(page, "#orderList", $"HD #{orderId}");

            await AddMenuItemAsync(page, 2);
            await page.Locator("#submitAction").ClickAsync();
            await WaitForTextAsync(page, "#actionMessage", "Da gui mon");

            var updatedOrder = await FindOrderAsync(orderId);
            Assert.AreEqual(3, updatedOrder?["items"]?.AsArray().Count);
            Assert.IsGreaterThanOrEqualTo(2, updatedOrder?["batches"]?.AsArray().Count ?? 0);

            var table = await FindTableAsync(ScenarioTableId);
            Assert.AreEqual("occupied", table?["status"]?.GetValue<string>());
            Assert.AreEqual(orderId, table?["activeOrderId"]?.GetValue<int>());
        });
    }

    [TestMethod]
    [TestCategory("Web")]
    public async Task CustomerWeb_PaidOrderMovesToPaymentHistoryAndFreesTable()
    {
        await ResetAsync();
        await WithPageAsync(async page =>
        {
            await LoginCustomerAsync(page);
            await SelectTableAsync(page, ScenarioTableId);

            await AddMenuItemAsync(page, 1);
            await page.Locator("#submitAction").ClickAsync();
            await WaitForTextAsync(page, "#actionMessage", "Da gui mon");

            var order = await FindCustomerOrderAsync(CustomerId, ScenarioTableId, "open");
            var orderId = order?["id"]?.GetValue<int>() ?? 0;
            Assert.IsGreaterThan(0, orderId);

            await PostJsonAsync($"/orders/{orderId}/pay", new
            {
                role = "admin",
                userName = "VS Web Test",
                discount = 0
            });

            await page.Locator("#refreshBtn").ClickAsync();
            await WaitForTextAsync(page, "#paymentList", $"HD #{orderId}");

            var table = await FindTableAsync(ScenarioTableId);
            Assert.AreEqual("available", table?["status"]?.GetValue<string>());

            var paidHistory = await GetArrayAsync($"/customer-api/paid-history?customerId={CustomerId}");
            Assert.IsTrue(paidHistory.Any(item => item?["id"]?.GetValue<int>() == orderId));
        });
    }

    [TestMethod]
    [TestCategory("Web")]
    public async Task CustomerWeb_ShowsValidationErrorsReloadsSessionAndLogsOut()
    {
        await ResetAsync();
        await WithPageAsync(async page =>
        {
            await page.GotoAsync(TestConfig.CustomerWebUrl, new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await page.Locator("#username").FillAsync("customer001");
            await page.Locator("#password").FillAsync("wrong-password");
            await page.GetByRole(AriaRole.Button, new() { Name = "Dang nhap" }).ClickAsync();
            await WaitForTextAsync(page, "#loginError", "Sai tai khoan khach hang hoac mat khau");
            Assert.IsFalse(await page.Locator("#appView:not(.hidden)").IsVisibleAsync());

            await LoginCustomerAsync(page, alreadyOnPage: true);
            await page.Locator("#submitAction").ClickAsync();
            await WaitForTextAsync(page, "#actionMessage", "Chua chon mon hop le");

            await page.ReloadAsync(new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await WaitForAppAsync(page);
            await page.Locator("#logoutBtn").ClickAsync();
            Assert.IsTrue(await page.Locator("#loginView:not(.hidden)").IsVisibleAsync());

            var storedSession = await page.EvaluateAsync<string?>("() => localStorage.getItem('restaurantCustomer')");
            Assert.IsNull(storedSession);
        });
    }

    [TestMethod]
    [TestCategory("Web")]
    public async Task CustomerWeb_NavigationCategoryFilterAndResponsiveLayoutWork()
    {
        await ResetAsync();
        await WithPageAsync(async page =>
        {
            await LoginCustomerAsync(page);

            Assert.IsTrue(await page.Locator("[data-table='6']").IsDisabledAsync());

            await page.Locator("[data-jump='menu']").ClickAsync();
            await page.Locator("[data-category='Do uong']").ClickAsync();
            await WaitForTextAsync(page, "#menuGrid", "Tra dao cam sa");
            Assert.AreNotEqual(true, (await page.Locator("#menuGrid").TextContentAsync())?.Contains("Pho bo tai"));

            await page.Locator("[data-jump='history']").ClickAsync();
            Assert.IsTrue(await page.Locator("#history").IsVisibleAsync());

            await page.SetViewportSizeAsync(390, 844);
            await page.ReloadAsync(new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await WaitForAppAsync(page);
            Assert.IsTrue(await page.Locator(".topbar").IsVisibleAsync());
            Assert.IsTrue(await page.Locator("#tableGrid").IsVisibleAsync());
            Assert.IsTrue(await page.Locator("#menuGrid").IsVisibleAsync());
        });
    }

    [TestMethod]
    [TestCategory("Web")]
    public async Task StaffWeb_IsServedByBackend()
    {
        await WithPageAsync(async page =>
        {
            await AssertFlutterWebServedAsync(page, TestConfig.StaffWebUrl);
        });
    }

    [TestMethod]
    [TestCategory("Web")]
    public async Task AdminWeb_IsServedByBackend()
    {
        await WithPageAsync(async page =>
        {
            await AssertFlutterWebServedAsync(page, TestConfig.AdminWebUrl);
        });
    }

    [TestMethod]
    [TestCategory("Web")]
    [TestCategory("WebMatrix60")]
    [DataRow("CUST-01", "Customer web login accepts seeded account")]
    [DataRow("CUST-02", "Customer web login rejects bad password")]
    [DataRow("CUST-03", "Customer bootstrap returns seed workspace")]
    [DataRow("CUST-04", "Customer reserves available table")]
    [DataRow("CUST-05", "Customer cannot reserve another customer's table")]
    [DataRow("CUST-06", "Customer creates order on available table")]
    [DataRow("CUST-07", "Customer order requires menu items")]
    [DataRow("CUST-08", "Customer appends items to own open order")]
    [DataRow("CUST-09", "Customer cannot append to another customer's table")]
    [DataRow("CUST-10", "Customer paid history shows paid order")]
    [DataRow("CUST-11", "Customer reservation can become seated order")]
    [DataRow("CUST-12", "Customer cannot use unavailable reserved table")]
    [DataRow("CUST-13", "Customer menu exposes expected categories")]
    [DataRow("CUST-14", "Customer reservation saves note")]
    [DataRow("CUST-15", "Customer order saves note")]
    [DataRow("CUST-16", "Customer reservation saves party size")]
    [DataRow("CUST-17", "Customer order total matches selected items")]
    [DataRow("CUST-18", "Customer payment completes seated reservation")]
    [DataRow("CUST-19", "Customer bootstrap separates paid orders")]
    [DataRow("CUST-20", "Customer actions notify staff")]
    [DataRow("STAFF-01", "Staff web entrypoint is hosted")]
    [DataRow("STAFF-02", "Staff login accepts seeded staff account")]
    [DataRow("STAFF-03", "Staff login rejects bad password")]
    [DataRow("STAFF-04", "Staff table list returns seed tables")]
    [DataRow("STAFF-05", "Staff creates table")]
    [DataRow("STAFF-06", "Staff updates table")]
    [DataRow("STAFF-07", "Staff deletes free table")]
    [DataRow("STAFF-08", "Staff cannot delete table with open order")]
    [DataRow("STAFF-09", "Staff creates open order")]
    [DataRow("STAFF-10", "Staff reuses existing open order")]
    [DataRow("STAFF-11", "Staff adds order item")]
    [DataRow("STAFF-12", "Staff creates second order batch")]
    [DataRow("STAFF-13", "Staff patches item quantity")]
    [DataRow("STAFF-14", "Staff removes item with zero quantity")]
    [DataRow("STAFF-15", "Staff collects payment")]
    [DataRow("STAFF-16", "Staff records debt")]
    [DataRow("STAFF-17", "Staff partially pays debt")]
    [DataRow("STAFF-18", "Staff fully pays debt")]
    [DataRow("STAFF-19", "Staff checks in attendance")]
    [DataRow("STAFF-20", "Staff checks out attendance")]
    [DataRow("ADMIN-01", "Admin web entrypoint is hosted")]
    [DataRow("ADMIN-02", "Admin login accepts seeded account")]
    [DataRow("ADMIN-03", "Admin health reports seed counts")]
    [DataRow("ADMIN-04", "Admin export includes core collections")]
    [DataRow("ADMIN-05", "Admin reset restores changed seed")]
    [DataRow("ADMIN-06", "Admin creates employee and account")]
    [DataRow("ADMIN-07", "Admin updates employee account")]
    [DataRow("ADMIN-08", "Admin disables employee account")]
    [DataRow("ADMIN-09", "Admin creates menu item")]
    [DataRow("ADMIN-10", "Admin updates menu item")]
    [DataRow("ADMIN-11", "Admin deletes menu item")]
    [DataRow("ADMIN-12", "Admin creates notification")]
    [DataRow("ADMIN-13", "Admin deletes notification")]
    [DataRow("ADMIN-14", "Admin dashboard reports counts")]
    [DataRow("ADMIN-15", "Admin stats day endpoint works")]
    [DataRow("ADMIN-16", "Admin stats month endpoint works")]
    [DataRow("ADMIN-17", "Admin stats year endpoint works")]
    [DataRow("ADMIN-18", "Admin payroll month endpoint works")]
    [DataRow("ADMIN-19", "Admin can pay customer web order")]
    [DataRow("ADMIN-20", "Admin web documents customer page")]
    public async Task Web_60_FunctionScenarioMatrix(string scenarioId, string title)
    {
        await ResetAsync();
        await RunWebMatrixScenarioAsync(scenarioId);
    }

    private static async Task WithPageAsync(Func<IPage, Task> action)
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new()
        {
            Channel = TestConfig.BrowserChannel,
            Headless = !TestConfig.ShowBrowser,
            SlowMo = TestConfig.ShowBrowser ? 250 : null
        });
        var page = await browser.NewPageAsync();
        await action(page);
    }

    private static async Task RunWebMatrixScenarioAsync(string scenarioId)
    {
        switch (scenarioId)
        {
            case "CUST-01":
                {
                    var login = await PostJsonAsync("/auth/customer-login", new { username = "customer001", password = "123" });
                    Assert.AreEqual(CustomerId, login["customer"]?["id"]?.GetValue<int>());
                    break;
                }
            case "CUST-02":
                await AssertStatusAsync(HttpMethod.Post, "/auth/customer-login", 401, new { username = "customer001", password = "bad" });
                break;
            case "CUST-03":
                {
                    var bootstrap = await GetJsonAsync($"/customer-api/bootstrap?customerId={CustomerId}");
                    Assert.AreEqual(16, bootstrap["tables"]?.AsArray().Count);
                    Assert.AreEqual(52, bootstrap["menu"]?.AsArray().Count);
                    break;
                }
            case "CUST-04":
                {
                    var reservation = await CreateReservationAsync(CustomerId, ScenarioTableId, note: "matrix reserve");
                    Assert.AreEqual("confirmed", reservation["reservation"]?["status"]?.GetValue<string>());
                    Assert.AreEqual("reserved", reservation["table"]?["status"]?.GetValue<string>());
                    break;
                }
            case "CUST-05":
                await AssertStatusAsync(HttpMethod.Post, "/customer-api/reservations", 409, new
                {
                    customerId = CustomerId,
                    tableId = 6,
                    partySize = 4,
                    reservedAt = "2026-06-01T18:00:00+07:00"
                });
                break;
            case "CUST-06":
                {
                    var order = await CreateCustomerOrderAsync(CustomerId, ScenarioTableId, new[] { new MenuRow(1, 2) });
                    Assert.AreEqual("open", order["order"]?["status"]?.GetValue<string>());
                    Assert.AreEqual("occupied", order["table"]?["status"]?.GetValue<string>());
                    break;
                }
            case "CUST-07":
                await AssertStatusAsync(HttpMethod.Post, "/customer-api/orders", 400, new
                {
                    customerId = CustomerId,
                    tableId = ScenarioTableId,
                    items = Array.Empty<object>()
                });
                break;
            case "CUST-08":
                {
                    var created = await CreateCustomerOrderAsync(CustomerId, ScenarioTableId, new[] { new MenuRow(1, 1) });
                    var updated = await CreateCustomerOrderAsync(CustomerId, ScenarioTableId, new[] { new MenuRow(2, 1) });
                    Assert.AreEqual(created["order"]?["id"]?.GetValue<int>(), updated["order"]?["id"]?.GetValue<int>());
                    Assert.AreEqual(2, updated["order"]?["items"]?.AsArray().Count);
                    break;
                }
            case "CUST-09":
                await CreateCustomerOrderAsync(CustomerId, ScenarioTableId, new[] { new MenuRow(1, 1) });
                await AssertStatusAsync(HttpMethod.Post, "/customer-api/orders", 409, new
                {
                    customerId = 2,
                    tableId = ScenarioTableId,
                    items = new[] { new { menuItemId = 2, quantity = 1 } }
                });
                break;
            case "CUST-10":
                {
                    var created = await CreateCustomerOrderAsync(CustomerId, ScenarioTableId, new[] { new MenuRow(1, 1) });
                    var orderId = created["order"]?["id"]?.GetValue<int>() ?? 0;
                    await PayOrderAsync(orderId, "admin", "Matrix Admin");
                    var paidHistory = await GetArrayAsync($"/customer-api/paid-history?customerId={CustomerId}");
                    Assert.IsTrue(paidHistory.Any(item => item?["id"]?.GetValue<int>() == orderId));
                    break;
                }
            case "CUST-11":
                {
                    var reservation = await CreateReservationAsync(CustomerId, ScenarioTableId);
                    var reservationId = reservation["reservation"]?["id"]?.GetValue<int>();
                    var order = await CreateCustomerOrderAsync(CustomerId, ScenarioTableId, new[] { new MenuRow(1, 1) }, reservationId);
                    Assert.AreEqual(reservationId, order["order"]?["reservationId"]?.GetValue<int>());
                    Assert.AreEqual("occupied", order["table"]?["status"]?.GetValue<string>());
                    break;
                }
            case "CUST-12":
                {
                    var bootstrap = await GetJsonAsync($"/customer-api/bootstrap?customerId={CustomerId}");
                    var table6 = bootstrap["tables"]?.AsArray().FirstOrDefault(item => item?["id"]?.GetValue<int>() == 6);
                    Assert.AreEqual("reserved", table6?["status"]?.GetValue<string>());
                    Assert.AreNotEqual(true, bootstrap["reservations"]?.AsArray().Any(item => item?["tableId"]?.GetValue<int>() == 6));
                    break;
                }
            case "CUST-13":
                {
                    var bootstrap = await GetJsonAsync($"/customer-api/bootstrap?customerId={CustomerId}");
                    var categories = bootstrap["menu"]?.AsArray()
                        .Select(item => item?["category"]?.GetValue<string>())
                        .Where(item => item is not null)
                        .Distinct()
                        .ToArray();
                    CollectionAssert.Contains(categories!, "Do uong");
                    CollectionAssert.Contains(categories!, "Mon chinh");
                    break;
                }
            case "CUST-14":
                {
                    var created = await CreateReservationAsync(CustomerId, ScenarioTableId, note: "matrix note");
                    Assert.AreEqual("matrix note", created["reservation"]?["note"]?.GetValue<string>());
                    break;
                }
            case "CUST-15":
                {
                    var created = await CreateCustomerOrderAsync(CustomerId, ScenarioTableId, new[] { new MenuRow(1, 1) }, note: "matrix order note");
                    Assert.AreEqual("matrix order note", created["order"]?["note"]?.GetValue<string>());
                    break;
                }
            case "CUST-16":
                {
                    var created = await CreateReservationAsync(CustomerId, ScenarioTableId, partySize: 6);
                    Assert.AreEqual(6, created["reservation"]?["partySize"]?.GetValue<int>());
                    break;
                }
            case "CUST-17":
                {
                    var created = await CreateCustomerOrderAsync(CustomerId, ScenarioTableId, new[] { new MenuRow(1, 2), new MenuRow(36, 1) });
                    Assert.AreEqual(162000, created["order"]?["total"]?.GetValue<int>());
                    break;
                }
            case "CUST-18":
                {
                    var reservation = await CreateReservationAsync(CustomerId, ScenarioTableId);
                    var order = await CreateCustomerOrderAsync(CustomerId, ScenarioTableId, new[] { new MenuRow(1, 1) }, reservation["reservation"]?["id"]?.GetValue<int>());
                    await PayOrderAsync(order["order"]?["id"]?.GetValue<int>() ?? 0, "staff", "Matrix Staff");
                    var reservations = await GetArrayAsync($"/customer-api/reservations?customerId={CustomerId}");
                    Assert.IsTrue(reservations.Any(item => item?["status"]?.GetValue<string>() == "completed"));
                    break;
                }
            case "CUST-19":
                {
                    var created = await CreateCustomerOrderAsync(CustomerId, ScenarioTableId, new[] { new MenuRow(1, 1) });
                    await PayOrderAsync(created["order"]?["id"]?.GetValue<int>() ?? 0, "admin", "Matrix Admin");
                    var bootstrap = await GetJsonAsync($"/customer-api/bootstrap?customerId={CustomerId}");
                    foreach (var item in bootstrap["paidOrders"]!.AsArray())
                    {
                        Assert.AreEqual("paid", item?["status"]?.GetValue<string>());
                    }
                    break;
                }
            case "CUST-20":
                {
                    await CreateReservationAsync(CustomerId, ScenarioTableId);
                    var notifications = await GetArrayAsync("/notifications");
                    Assert.IsTrue(notifications.Any(item => item?["title"]?.GetValue<string>() == "Khach dat ban"));
                    break;
                }
            case "STAFF-01":
                await AssertHtmlContainsAsync(TestConfig.StaffWebUrl, "flutter_bootstrap.js");
                break;
            case "STAFF-02":
                {
                    var login = await PostJsonAsync("/auth/login", new { username = "staff", password = "123" });
                    Assert.AreEqual("staff", login["user"]?["role"]?.GetValue<string>());
                    break;
                }
            case "STAFF-03":
                await AssertStatusAsync(HttpMethod.Post, "/auth/login", 401, new { username = "staff", password = "bad" });
                break;
            case "STAFF-04":
                Assert.AreEqual(16, (await GetArrayAsync("/tables")).Count);
                break;
            case "STAFF-05":
                {
                    var table = await CreateTableAsync("Ban Matrix", 4, "Tang Test");
                    Assert.AreEqual("Ban Matrix", table["name"]?.GetValue<string>());
                    break;
                }
            case "STAFF-06":
                {
                    var table = await CreateTableAsync("Ban Matrix", 4, "Tang Test");
                    var updated = await PatchJsonAsync($"/tables/{table["id"]?.GetValue<int>()}", new { name = "Ban Matrix Updated", seats = 8 });
                    Assert.AreEqual("Ban Matrix Updated", updated["name"]?.GetValue<string>());
                    Assert.AreEqual(8, updated["seats"]?.GetValue<int>());
                    break;
                }
            case "STAFF-07":
                {
                    var table = await CreateTableAsync("Ban Delete", 2, "Tang Test");
                    var deleted = await DeleteJsonAsync($"/tables/{table["id"]?.GetValue<int>()}");
                    Assert.IsTrue(deleted["success"]?.GetValue<bool>());
                    break;
                }
            case "STAFF-08":
                {
                    await CreateStaffOrderAsync(ScenarioTableId);
                    await AssertStatusAsync(HttpMethod.Delete, $"/tables/{ScenarioTableId}", 409);
                    break;
                }
            case "STAFF-09":
                {
                    var order = await CreateStaffOrderAsync(ScenarioTableId);
                    Assert.AreEqual("open", order["status"]?.GetValue<string>());
                    break;
                }
            case "STAFF-10":
                {
                    var first = await CreateStaffOrderAsync(ScenarioTableId);
                    var second = await CreateStaffOrderAsync(ScenarioTableId);
                    Assert.AreEqual(first["id"]?.GetValue<int>(), second["id"]?.GetValue<int>());
                    break;
                }
            case "STAFF-11":
                {
                    var order = await CreateStaffOrderAsync(ScenarioTableId);
                    var updated = await PostJsonAsync($"/orders/{order["id"]?.GetValue<int>()}/items", new { menuItemId = 1, quantity = 2, createdBy = "Matrix Staff" });
                    Assert.AreEqual(1, updated["items"]?.AsArray().Count);
                    Assert.AreEqual(2, updated["items"]?[0]?["quantity"]?.GetValue<int>());
                    break;
                }
            case "STAFF-12":
                {
                    var order = await CreateStaffOrderAsync(ScenarioTableId);
                    await AddBatchAsync(order["id"]?.GetValue<int>() ?? 0, 1, 1);
                    var updated = await AddBatchAsync(order["id"]?.GetValue<int>() ?? 0, 2, 1);
                    Assert.AreEqual(2, updated["batches"]?.AsArray().Count);
                    break;
                }
            case "STAFF-13":
                {
                    var order = await CreateStaffOrderAsync(ScenarioTableId);
                    await AddBatchAsync(order["id"]?.GetValue<int>() ?? 0, 1, 1);
                    var updated = await PatchJsonAsync($"/orders/{order["id"]?.GetValue<int>()}/items/1", new { quantity = 5 });
                    Assert.AreEqual(5, updated["items"]?[0]?["quantity"]?.GetValue<int>());
                    break;
                }
            case "STAFF-14":
                {
                    var order = await CreateStaffOrderAsync(ScenarioTableId);
                    await AddBatchAsync(order["id"]?.GetValue<int>() ?? 0, 1, 1);
                    var updated = await PatchJsonAsync($"/orders/{order["id"]?.GetValue<int>()}/items/1", new { quantity = 0 });
                    Assert.AreEqual(0, updated["items"]?.AsArray().Count);
                    break;
                }
            case "STAFF-15":
                {
                    var order = await CreateStaffOrderAsync(ScenarioTableId);
                    await AddBatchAsync(order["id"]?.GetValue<int>() ?? 0, 1, 1);
                    var paid = await PayOrderAsync(order["id"]?.GetValue<int>() ?? 0, "staff", "Matrix Staff");
                    Assert.AreEqual("paid", paid["status"]?.GetValue<string>());
                    break;
                }
            case "STAFF-16":
                {
                    var order = await CreateStaffOrderAsync(ScenarioTableId);
                    await AddBatchAsync(order["id"]?.GetValue<int>() ?? 0, 1, 1);
                    var result = await PostJsonAsync($"/orders/{order["id"]?.GetValue<int>()}/debt", new { role = "staff", customerName = "Matrix Debt", customerPhone = "0909", dueDate = "2026-06-30" });
                    Assert.AreEqual("debt", result["order"]?["status"]?.GetValue<string>());
                    Assert.AreEqual("open", result["debt"]?["status"]?.GetValue<string>());
                    break;
                }
            case "STAFF-17":
                {
                    var debt = await GetDebtAsync(1);
                    var updated = await PatchJsonAsync("/debts/1/pay", new { role = "staff", amount = 1000 });
                    Assert.AreEqual("open", updated["status"]?.GetValue<string>());
                    Assert.IsGreaterThan(debt["paidAmount"]?.GetValue<int>() ?? 0, updated["paidAmount"]?.GetValue<int>() ?? 0);
                    break;
                }
            case "STAFF-18":
                {
                    var debt = await GetDebtAsync(1);
                    var remaining = (debt["amount"]?.GetValue<int>() ?? 0) - (debt["paidAmount"]?.GetValue<int>() ?? 0);
                    var updated = await PatchJsonAsync("/debts/1/pay", new { role = "staff", amount = remaining });
                    Assert.AreEqual("paid", updated["status"]?.GetValue<string>());
                    break;
                }
            case "STAFF-19":
                {
                    var row = await PostJsonAsync("/attendance/check-in", new { employeeId = 2, date = "2026-06-01", note = "Matrix check-in" });
                    Assert.AreEqual(2, row["employeeId"]?.GetValue<int>());
                    Assert.AreEqual("2026-06-01", row["date"]?.GetValue<string>());
                    break;
                }
            case "STAFF-20":
                {
                    var row = await PostJsonAsync("/attendance/check-in", new { employeeId = 2, date = "2026-06-01", note = "Matrix check-in" });
                    var updated = await PatchJsonAsync($"/attendance/{row["id"]?.GetValue<int>()}/check-out", new { note = "Matrix check-out" });
                    Assert.IsFalse(string.IsNullOrWhiteSpace(updated["checkOut"]?.GetValue<string>()));
                    break;
                }
            case "ADMIN-01":
                await AssertHtmlContainsAsync(TestConfig.AdminWebUrl, "flutter_bootstrap.js");
                break;
            case "ADMIN-02":
                {
                    var login = await PostJsonAsync("/auth/login", new { username = "admin", password = "123" });
                    Assert.AreEqual("admin", login["user"]?["role"]?.GetValue<string>());
                    break;
                }
            case "ADMIN-03":
                {
                    var health = await GetJsonAsync("/admin/health");
                    Assert.AreEqual("ok", health["status"]?.GetValue<string>());
                    Assert.AreEqual(16, health["tables"]?.GetValue<int>());
                    Assert.AreEqual(52, health["menuItems"]?.GetValue<int>());
                    break;
                }
            case "ADMIN-04":
                {
                    var export = await GetJsonAsync("/admin/export");
                    Assert.AreEqual(16, export["tables"]?.AsArray().Count);
                    Assert.AreEqual(100, export["customers"]?.AsArray().Count);
                    break;
                }
            case "ADMIN-05":
                {
                    await CreateTableAsync("Ban Before Reset", 2, "Tang Test");
                    Assert.AreEqual(17, (await GetJsonAsync("/admin/health"))["tables"]?.GetValue<int>());
                    await PostJsonAsync("/admin/reset", new { });
                    Assert.AreEqual(16, (await GetJsonAsync("/admin/health"))["tables"]?.GetValue<int>());
                    break;
                }
            case "ADMIN-06":
                {
                    var employee = await CreateEmployeeAsync("Matrix Employee", "matrixemployee", "staff");
                    Assert.AreEqual("matrixemployee", employee["account"]?["username"]?.GetValue<string>());
                    break;
                }
            case "ADMIN-07":
                {
                    var employee = await CreateEmployeeAsync("Matrix Employee", "matrixemployee", "staff");
                    var updated = await PutJsonAsync($"/employees/{employee["id"]?.GetValue<int>()}", new { username = "matrixadmin", password = "456", accountRole = "admin" });
                    Assert.AreEqual("matrixadmin", updated["account"]?["username"]?.GetValue<string>());
                    Assert.AreEqual("admin", updated["account"]?["role"]?.GetValue<string>());
                    break;
                }
            case "ADMIN-08":
                {
                    var employee = await CreateEmployeeAsync("Matrix Employee", "matrixemployee", "staff");
                    var deleted = await DeleteJsonAsync($"/employees/{employee["id"]?.GetValue<int>()}");
                    Assert.IsFalse(deleted["active"]?.GetValue<bool>());
                    await AssertStatusAsync(HttpMethod.Post, "/auth/login", 401, new { username = "matrixemployee", password = "123" });
                    break;
                }
            case "ADMIN-09":
                {
                    var item = await CreateMenuItemAsync("Matrix Dish");
                    Assert.AreEqual("Matrix Dish", item["name"]?.GetValue<string>());
                    break;
                }
            case "ADMIN-10":
                {
                    var item = await CreateMenuItemAsync("Matrix Dish");
                    var updated = await PutJsonAsync($"/menu/{item["id"]?.GetValue<int>()}", new { name = "Matrix Dish Updated", price = 99000, available = false });
                    Assert.AreEqual("Matrix Dish Updated", updated["name"]?.GetValue<string>());
                    Assert.IsFalse(updated["available"]?.GetValue<bool>());
                    break;
                }
            case "ADMIN-11":
                {
                    var item = await CreateMenuItemAsync("Matrix Dish");
                    var deleted = await DeleteJsonAsync($"/menu/{item["id"]?.GetValue<int>()}");
                    Assert.IsTrue(deleted["success"]?.GetValue<bool>());
                    break;
                }
            case "ADMIN-12":
                {
                    var notification = await PostJsonAsync("/notifications", new { title = "Matrix Notice", body = "Body", audience = "all" });
                    Assert.AreEqual("Matrix Notice", notification["title"]?.GetValue<string>());
                    break;
                }
            case "ADMIN-13":
                {
                    var notification = await PostJsonAsync("/notifications", new { title = "Matrix Notice", body = "Body", audience = "all" });
                    var deleted = await DeleteJsonAsync($"/notifications/{notification["id"]?.GetValue<int>()}");
                    Assert.IsTrue(deleted["success"]?.GetValue<bool>());
                    break;
                }
            case "ADMIN-14":
                {
                    var dashboard = await GetJsonAsync("/dashboard");
                    Assert.AreEqual(16, dashboard["tableCount"]?.GetValue<int>());
                    Assert.AreEqual(12, dashboard["employeeCount"]?.GetValue<int>());
                    break;
                }
            case "ADMIN-15":
                {
                    var stats = await GetJsonAsync("/stats?period=day&date=2026-05-20T12:00:00Z");
                    Assert.AreEqual("day", stats["period"]?.GetValue<string>());
                    Assert.IsGreaterThan(0, stats["revenue"]?.GetValue<int>() ?? 0);
                    break;
                }
            case "ADMIN-16":
                {
                    var stats = await GetJsonAsync("/stats?period=month&date=2026-05-10T12:00:00Z");
                    Assert.AreEqual("month", stats["period"]?.GetValue<string>());
                    Assert.IsGreaterThan(0, stats["orderCount"]?.GetValue<int>() ?? 0);
                    break;
                }
            case "ADMIN-17":
                {
                    var stats = await GetJsonAsync("/stats?period=year&date=2026-05-10T12:00:00Z");
                    Assert.AreEqual("year", stats["period"]?.GetValue<string>());
                    Assert.IsGreaterThan(0, stats["topItems"]?.AsArray().Count ?? 0);
                    break;
                }
            case "ADMIN-18":
                {
                    var payroll = await GetJsonAsync("/payroll?month=2026-05");
                    Assert.AreEqual("2026-05", payroll["month"]?.GetValue<string>());
                    Assert.AreEqual(12, payroll["rows"]?.AsArray().Count);
                    break;
                }
            case "ADMIN-19":
                {
                    var created = await CreateCustomerOrderAsync(CustomerId, ScenarioTableId, new[] { new MenuRow(1, 1) });
                    var paid = await PayOrderAsync(created["order"]?["id"]?.GetValue<int>() ?? 0, "admin", "Matrix Admin");
                    Assert.AreEqual("paid", paid["status"]?.GetValue<string>());
                    break;
                }
            case "ADMIN-20":
                await AssertHtmlContainsAsync(TestConfig.CustomerWebUrl, "loginForm");
                break;
            default:
                Assert.Fail($"Unknown web scenario: {scenarioId}");
                break;
        }
    }

    private static async Task LoginCustomerAsync(IPage page, bool alreadyOnPage = false)
    {
        if (!alreadyOnPage)
        {
            await page.GotoAsync(TestConfig.CustomerWebUrl, new() { WaitUntil = WaitUntilState.DOMContentLoaded });
        }

        await page.Locator("#username").FillAsync("customer001");
        await page.Locator("#password").FillAsync("123");
        await page.GetByRole(AriaRole.Button, new() { Name = "Dang nhap" }).ClickAsync();
        await WaitForAppAsync(page);
    }

    private static async Task WaitForAppAsync(IPage page)
    {
        await page.WaitForSelectorAsync("#appView:not(.hidden)");
        await page.WaitForFunctionAsync("() => document.querySelectorAll('[data-table]').length > 0");
        await page.WaitForFunctionAsync("() => document.querySelectorAll('[data-add]').length > 0");
    }

    private static async Task SelectTableAsync(IPage page, int tableId)
    {
        var table = page.Locator($"[data-table='{tableId}']");
        await table.ClickAsync();
        await WaitForClassAsync(page, $"[data-table='{tableId}']", "selected");
    }

    private static async Task AddMenuItemAsync(IPage page, int menuItemId)
    {
        await page.Locator($"[data-add='{menuItemId}']").ClickAsync();
    }

    private static async Task WaitForTextAsync(IPage page, string selector, string expectedText)
    {
        await page.WaitForFunctionAsync(
            @"([selector, expectedText]) => document.querySelector(selector)?.textContent.includes(expectedText)",
            new[] { selector, expectedText });
    }

    private static async Task WaitForClassAsync(IPage page, string selector, string expectedClass)
    {
        await page.WaitForFunctionAsync(
            @"([selector, expectedClass]) => document.querySelector(selector)?.classList.contains(expectedClass)",
            new[] { selector, expectedClass });
    }

    private static async Task AssertFlutterWebServedAsync(IPage page, string url)
    {
        var response = await page.GotoAsync(url, new() { WaitUntil = WaitUntilState.DOMContentLoaded });
        Assert.IsNotNull(response);
        Assert.IsTrue(response.Ok);
        StringAssert.Matches(
            await page.TitleAsync(),
            new Regex("Qu.*n L.* Nh.* H.*ng|Restaurant", RegexOptions.IgnoreCase));
    }

    private static async Task AssertHtmlContainsAsync(string url, string expectedText)
    {
        var html = await Http.GetStringAsync(url);
        StringAssert.Contains(html, expectedText);
    }

    private static async Task AssertStatusAsync(HttpMethod method, string path, int expectedStatus, object? body = null)
    {
        using var request = new HttpRequestMessage(method, path);
        if (body is not null)
        {
            request.Content = JsonContent.Create(body);
        }

        using var response = await Http.SendAsync(request);
        Assert.AreEqual(expectedStatus, (int)response.StatusCode);
    }

    private static async Task ResetAsync()
    {
        await PostJsonAsync("/reset", new { });
    }

    private static async Task<JsonNode> GetJsonAsync(string path)
    {
        var response = await Http.GetAsync(path);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<JsonNode>())!;
    }

    private static async Task<JsonArray> GetArrayAsync(string path)
    {
        return (await GetJsonAsync(path)).AsArray();
    }

    private static async Task<JsonNode> PostJsonAsync(string path, object body)
    {
        var response = await Http.PostAsJsonAsync(path, body);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<JsonNode>())!;
    }

    private static async Task<JsonNode> PutJsonAsync(string path, object body)
    {
        var response = await Http.PutAsJsonAsync(path, body);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<JsonNode>())!;
    }

    private static async Task<JsonNode> PatchJsonAsync(string path, object body)
    {
        var response = await Http.PatchAsJsonAsync(path, body);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<JsonNode>())!;
    }

    private static async Task<JsonNode> DeleteJsonAsync(string path)
    {
        var response = await Http.DeleteAsync(path);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<JsonNode>())!;
    }

    private static Task<JsonNode> CreateReservationAsync(
        int customerId,
        int tableId,
        int partySize = 4,
        string note = "",
        string reservedAt = "2026-06-01T18:30:00+07:00")
    {
        return PostJsonAsync("/customer-api/reservations", new
        {
            customerId,
            tableId,
            partySize,
            reservedAt,
            note
        });
    }

    private static Task<JsonNode> CreateCustomerOrderAsync(
        int customerId,
        int tableId,
        IEnumerable<MenuRow> items,
        int? reservationId = null,
        string note = "")
    {
        return PostJsonAsync("/customer-api/orders", new
        {
            customerId,
            tableId,
            reservationId,
            partySize = 4,
            reservedAt = "2026-06-01T18:30:00+07:00",
            note,
            items
        });
    }

    private static Task<JsonNode> CreateTableAsync(string name, int seats, string area)
    {
        return PostJsonAsync("/tables", new
        {
            name,
            seats,
            area,
            status = "available"
        });
    }

    private static Task<JsonNode> CreateStaffOrderAsync(int tableId)
    {
        return PostJsonAsync("/orders", new
        {
            tableId,
            staffId = 2,
            staffName = "Matrix Staff"
        });
    }

    private static Task<JsonNode> AddBatchAsync(int orderId, int menuItemId, int quantity)
    {
        return PostJsonAsync($"/orders/{orderId}/batches", new
        {
            createdBy = "Matrix Staff",
            items = new[]
            {
                new { menuItemId, quantity }
            }
        });
    }

    private static Task<JsonNode> PayOrderAsync(int orderId, string role, string userName)
    {
        return PostJsonAsync($"/orders/{orderId}/pay", new
        {
            role,
            userName,
            discount = 0
        });
    }

    private static async Task<JsonNode> GetDebtAsync(int debtId)
    {
        var debts = await GetArrayAsync("/debts");
        return debts.First(debt => debt?["id"]?.GetValue<int>() == debtId)!;
    }

    private static Task<JsonNode> CreateEmployeeAsync(string name, string username, string accountRole)
    {
        return PostJsonAsync("/employees", new
        {
            name,
            role = "Phuc vu",
            phone = "0900000999",
            salaryPerDay = 350000,
            username,
            password = "123",
            accountRole
        });
    }

    private static Task<JsonNode> CreateMenuItemAsync(string name)
    {
        return PostJsonAsync("/menu", new
        {
            name,
            category = "Matrix",
            price = 88000,
            available = true,
            imageUrl = "https://example.com/matrix-dish.jpg"
        });
    }

    private static async Task<JsonNode?> FindTableAsync(int tableId)
    {
        var tables = await GetArrayAsync("/tables");
        return tables.FirstOrDefault(table => table?["id"]?.GetValue<int>() == tableId);
    }

    private static async Task<JsonNode?> FindOrderAsync(int orderId)
    {
        var orders = await GetArrayAsync("/orders");
        return orders.FirstOrDefault(order => order?["id"]?.GetValue<int>() == orderId);
    }

    private static async Task<JsonNode?> FindCustomerOrderAsync(int customerId, int tableId, string status)
    {
        var orders = await GetArrayAsync("/orders");
        return orders.FirstOrDefault(order =>
            order?["customerId"]?.GetValue<int>() == customerId
            && order?["tableId"]?.GetValue<int>() == tableId
            && order?["status"]?.GetValue<string>() == status);
    }

    private sealed record MenuRow(int MenuItemId, int Quantity);
}
