namespace AutoTest.Support;

internal static class TestRuntime
{
    private static readonly AsyncLocal<BrowserSession?> BrowserSlot = new();
    private static readonly AsyncLocal<BackendApi?> ApiSlot = new();
    private static readonly AsyncLocal<Dictionary<string, object?>> DataSlot = new();

    public static BrowserSession Browser =>
        BrowserSlot.Value ??= new BrowserSession();

    public static bool IsBrowserStarted => BrowserSlot.Value is not null;

    public static BackendApi Api =>
        ApiSlot.Value ?? throw new InvalidOperationException("Backend API client is not initialized.");

    public static Dictionary<string, object?> Data =>
        DataSlot.Value ??= new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);

    public static void StartScenario()
    {
        Directory.CreateDirectory(TestSettings.EvidenceDirectory);
        ApiSlot.Value = new BackendApi();
        BrowserSlot.Value = null;
        DataSlot.Value = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
    }

    public static void EndScenario()
    {
        BrowserSlot.Value?.Dispose();
        ApiSlot.Value?.Dispose();
        BrowserSlot.Value = null;
        ApiSlot.Value = null;
        DataSlot.Value = null!;
    }

    public static void Set<T>(string key, T value)
    {
        Data[key] = value;
    }

    public static T Get<T>(string key)
    {
        return Data.TryGetValue(key, out var value) && value is T typed
            ? typed
            : throw new InvalidOperationException($"Scenario value '{key}' was not found.");
    }
}
