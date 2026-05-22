using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace RestaurantManagement.E2E;

[TestClass]
public sealed class ApiSmokeTests
{
    private readonly HttpClient _http = new()
    {
        BaseAddress = new Uri(TestConfig.BackendBaseUrl)
    };

    [TestMethod]
    [TestCategory("Api")]
    public async Task Health_ReturnsSeedCounts()
    {
        await PostJsonAsync("/reset", new { });
        var health = await GetJsonAsync("/admin/health");

        Assert.AreEqual("ok", health["status"]?.GetValue<string>());
        Assert.AreEqual(16, health["tables"]?.GetValue<int>());
        Assert.AreEqual(52, health["menuItems"]?.GetValue<int>());
        Assert.AreEqual(100, health["customers"]?.GetValue<int>());
        Assert.AreEqual(12, health["employeeAccounts"]?.GetValue<int>());
    }

    [TestMethod]
    [TestCategory("Api")]
    public async Task CustomerOrderFlow_LinksCustomerAndReturnsTableAvailableAfterPayment()
    {
        await PostJsonAsync("/reset", new { });

        var login = await PostJsonAsync("/auth/customer-login", new
        {
            username = "customer001",
            password = "123"
        });
        var customerId = login["customer"]?["id"]?.GetValue<int>() ?? 0;

        var reservation = await PostJsonAsync("/customer-api/reservations", new
        {
            customerId,
            tableId = 7,
            partySize = 4,
            reservedAt = "2026-05-22T19:30:00+07:00",
            note = "C# smoke reservation"
        });

        var order = await PostJsonAsync("/customer-api/orders", new
        {
            customerId,
            tableId = 7,
            reservationId = reservation["reservation"]?["id"]?.GetValue<int>(),
            note = "C# smoke order",
            items = new[]
            {
                new { menuItemId = 1, quantity = 2 },
                new { menuItemId = 36, quantity = 1 }
            }
        });
        var orderId = order["order"]?["id"]?.GetValue<int>() ?? 0;

        Assert.AreEqual(customerId, order["order"]?["customerId"]?.GetValue<int>());
        Assert.AreEqual("open", order["order"]?["status"]?.GetValue<string>());

        var paid = await PostJsonAsync($"/orders/{orderId}/pay", new
        {
            role = "admin",
            userName = "Admin",
            discount = 0
        });

        Assert.AreEqual("paid", paid["status"]?.GetValue<string>());

        var tables = await GetArrayAsync("/tables");
        var table7 = tables.First(table => table?["id"]?.GetValue<int>() == 7);
        Assert.AreEqual("available", table7?["status"]?.GetValue<string>());

        var paidHistory = await GetArrayAsync($"/customer-api/paid-history?customerId={customerId}");
        Assert.IsTrue(paidHistory.Any(item => item?["id"]?.GetValue<int>() == orderId));

        await PostJsonAsync("/reset", new { });
    }

    [TestMethod]
    [TestCategory("Api")]
    public async Task StaffOrderFlow_CreatesBatchesWithoutCustomerAccount()
    {
        await PostJsonAsync("/reset", new { });

        var order = await PostJsonAsync("/orders", new
        {
            tableId = 7,
            staffId = 2,
            staffName = "Nguyen Minh Quan"
        });
        var orderId = order["id"]?.GetValue<int>() ?? 0;

        var batch1 = await PostJsonAsync($"/orders/{orderId}/batches", new
        {
            createdBy = "Nguyen Minh Quan",
            items = new[] { new { menuItemId = 1, quantity = 2 } }
        });
        var batch2 = await PostJsonAsync($"/orders/{orderId}/batches", new
        {
            createdBy = "Nguyen Minh Quan",
            items = new[] { new { menuItemId = 2, quantity = 1 } }
        });

        Assert.IsNull(batch2["customerId"]);
        Assert.AreEqual(2, batch2["batches"]?.AsArray().Count);
        Assert.AreEqual("Lan 1", batch1["batches"]?[0]?["name"]?.GetValue<string>());
        Assert.AreEqual("Lan 2", batch2["batches"]?[1]?["name"]?.GetValue<string>());

        await PostJsonAsync("/reset", new { });
    }

    private async Task<JsonNode> GetJsonAsync(string path)
    {
        var response = await _http.GetAsync(path);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<JsonNode>())!;
    }

    private async Task<JsonArray> GetArrayAsync(string path)
    {
        var node = await GetJsonAsync(path);
        return node.AsArray();
    }

    private async Task<JsonNode> PostJsonAsync(string path, object body)
    {
        var response = await _http.PostAsJsonAsync(path, body);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<JsonNode>())!;
    }
}
