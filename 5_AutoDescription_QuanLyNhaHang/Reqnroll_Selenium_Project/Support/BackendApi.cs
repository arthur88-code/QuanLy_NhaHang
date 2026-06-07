using System.Net.Http.Json;
using System.Text.Json.Nodes;
using NUnit.Framework;

namespace AutoTest.Support;

internal sealed class BackendApi : IDisposable
{
    private readonly HttpClient http = new()
    {
        BaseAddress = new Uri(TestSettings.BackendBaseUrl + "/")
    };

    public async Task AssertReadyAsync()
    {
        using var response = await http.GetAsync("");
        response.EnsureSuccessStatusCode();
        var root = await response.Content.ReadFromJsonAsync<JsonNode>();
        Assert.That(root?["success"]?.GetValue<bool>(), Is.True);
    }

    public async Task ResetAsync()
    {
        _ = await PostJsonAsync("/reset", new { });
    }

    public async Task<JsonNode> GetJsonAsync(string path)
    {
        using var response = await http.GetAsync(Normalize(path));
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<JsonNode>())!;
    }

    public async Task<string> GetStringAsync(string path)
    {
        using var response = await http.GetAsync(Normalize(path));
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<JsonArray> GetArrayAsync(string path)
    {
        return (await GetJsonAsync(path)).AsArray();
    }

    public Task<JsonNode> PostJsonAsync(string path, object body) =>
        SendJsonAsync(HttpMethod.Post, path, body);

    public Task<JsonNode> PutJsonAsync(string path, object body) =>
        SendJsonAsync(HttpMethod.Put, path, body);

    public Task<JsonNode> PatchJsonAsync(string path, object body) =>
        SendJsonAsync(HttpMethod.Patch, path, body);

    public async Task<JsonNode> DeleteJsonAsync(string path)
    {
        using var response = await http.DeleteAsync(Normalize(path));
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<JsonNode>())!;
    }

    public async Task AssertStatusAsync(HttpMethod method, string path, int expectedStatus, object? body = null)
    {
        using var request = new HttpRequestMessage(method, Normalize(path));
        if (body is not null)
        {
            request.Content = JsonContent.Create(body);
        }

        using var response = await http.SendAsync(request);
        Assert.That((int)response.StatusCode, Is.EqualTo(expectedStatus));
    }

    public async Task<JsonNode?> FindTableAsync(int tableId)
    {
        return (await GetArrayAsync("/tables"))
            .FirstOrDefault(item => item?["id"]?.GetValue<int>() == tableId);
    }

    public async Task<JsonNode?> FindTableByNameAsync(string name)
    {
        return (await GetArrayAsync("/tables"))
            .FirstOrDefault(item => string.Equals(item?["name"]?.GetValue<string>(), name, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<JsonNode?> FindCustomerOrderAsync(int customerId, int tableId, string status)
    {
        var orders = await GetArrayAsync("/orders");
        return orders.FirstOrDefault(order =>
            order?["customerId"]?.GetValue<int>() == customerId
            && order?["tableId"]?.GetValue<int>() == tableId
            && string.Equals(order?["status"]?.GetValue<string>(), status, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<JsonNode?> FindOrderAsync(int orderId)
    {
        return (await GetArrayAsync("/orders"))
            .FirstOrDefault(order => order?["id"]?.GetValue<int>() == orderId);
    }

    public async Task<JsonNode?> FindOpenOrderForTableAsync(int tableId)
    {
        using var response = await http.GetAsync(Normalize($"/orders/table/{tableId}/open"));
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<JsonNode>();
    }

    public async Task<JsonNode> CreateStaffOrderWithItemAsync(int tableId, int menuItemId = 1)
    {
        var order = await PostJsonAsync("/orders", new
        {
            tableId,
            staffId = 2,
            staffName = "Nguyen Minh Quan"
        });
        var orderId = order["id"]?.GetValue<int>() ?? 0;
        await PostJsonAsync($"/orders/{orderId}/batches", new
        {
            createdBy = "Nguyen Minh Quan",
            items = new[] { new { menuItemId, quantity = 1 } }
        });

        return (await FindOrderAsync(orderId))!;
    }

    public async Task<JsonNode> CreateDebtAsync(int tableId, string customerName)
    {
        var order = await CreateStaffOrderWithItemAsync(tableId);
        return await PostJsonAsync($"/orders/{order["id"]?.GetValue<int>()}/debt", new
        {
            role = "staff",
            customerName,
            customerPhone = "0909000000",
            note = "auto debt"
        });
    }

    public async Task<JsonNode?> FindDebtAsync(int debtId)
    {
        return (await GetArrayAsync("/debts"))
            .FirstOrDefault(item => item?["id"]?.GetValue<int>() == debtId);
    }

    public async Task<JsonNode> CreateMenuItemAsync(string name)
    {
        return await PostJsonAsync("/menu", new
        {
            name,
            category = "Mon chinh",
            price = 88000,
            imageUrl = "https://example.com/auto-menu.jpg",
            available = true
        });
    }

    public async Task<JsonNode?> FindMenuItemAsync(int menuId)
    {
        return (await GetArrayAsync("/menu"))
            .FirstOrDefault(item => item?["id"]?.GetValue<int>() == menuId);
    }

    public async Task<JsonNode?> FindMenuItemByNameAsync(string name)
    {
        return (await GetArrayAsync("/menu"))
            .FirstOrDefault(item => string.Equals(item?["name"]?.GetValue<string>(), name, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<JsonNode> CreateEmployeeAsync(string name, string username, string accountRole = "staff")
    {
        return await PostJsonAsync("/employees", new
        {
            name,
            role = "Phuc vu",
            phone = "0999999999",
            salaryPerDay = 300000,
            username,
            password = "123",
            accountRole
        });
    }

    public async Task<JsonNode?> FindEmployeeAsync(int employeeId)
    {
        return (await GetArrayAsync("/employees"))
            .FirstOrDefault(item => item?["id"]?.GetValue<int>() == employeeId);
    }

    public async Task<JsonNode?> FindEmployeeByNameAsync(string name)
    {
        return (await GetArrayAsync("/employees"))
            .FirstOrDefault(item => string.Equals(item?["name"]?.GetValue<string>(), name, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<JsonNode?> FindNotificationByTitleAsync(string title)
    {
        return (await GetArrayAsync("/notifications"))
            .FirstOrDefault(item => string.Equals(item?["title"]?.GetValue<string>(), title, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<JsonNode?> FindAttendanceForEmployeeAsync(int employeeId)
    {
        return (await GetArrayAsync("/attendance"))
            .FirstOrDefault(item => item?["employeeId"]?.GetValue<int>() == employeeId);
    }

    public void Dispose()
    {
        http.Dispose();
    }

    private async Task<JsonNode> SendJsonAsync(HttpMethod method, string path, object body)
    {
        using var request = new HttpRequestMessage(method, Normalize(path))
        {
            Content = JsonContent.Create(body)
        };
        using var response = await http.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<JsonNode>())!;
    }

    private static string Normalize(string path) => path.TrimStart('/');
}
