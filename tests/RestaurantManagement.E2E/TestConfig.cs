namespace RestaurantManagement.E2E;

internal static class TestConfig
{
    public static string BackendBaseUrl =>
        ReadUrl("RMS_BACKEND_URL", "http://127.0.0.1:3000");

    public static string CustomerWebUrl =>
        ReadUrl("RMS_CUSTOMER_WEB_URL", $"{BackendBaseUrl}/customer/");

    public static string StaffWebUrl =>
        ReadUrl("RMS_STAFF_WEB_URL", $"{BackendBaseUrl}/staff/");

    public static string AdminWebUrl =>
        ReadUrl("RMS_ADMIN_WEB_URL", $"{BackendBaseUrl}/admin-web/");

    public static string AppiumServerUrl =>
        ReadUrl("RMS_APPIUM_URL", "http://127.0.0.1:4723/");

    public static string AndroidApkPath =>
        Environment.GetEnvironmentVariable("RMS_ANDROID_APK")
        ?? Path.GetFullPath(Path.Combine(
            AppContext.BaseDirectory,
            "..",
            "..",
            "..",
            "..",
            "..",
            "frontend",
            "build",
            "app",
            "outputs",
            "flutter-apk",
            "app-debug.apk"));

    public static bool RunAndroid =>
        IsTruthy(Environment.GetEnvironmentVariable("RMS_RUN_ANDROID"));

    public static bool ShowBrowser =>
        IsTruthy(Environment.GetEnvironmentVariable("RMS_SHOW_BROWSER"));

    public static string BrowserChannel =>
        Environment.GetEnvironmentVariable("RMS_BROWSER_CHANNEL") ?? "chrome";

    private static string ReadUrl(string key, string fallback)
    {
        var value = Environment.GetEnvironmentVariable(key);
        return string.IsNullOrWhiteSpace(value) ? fallback.TrimEnd('/') : value.TrimEnd('/');
    }

    private static bool IsTruthy(string? value)
    {
        return value?.Equals("1", StringComparison.OrdinalIgnoreCase) == true
            || value?.Equals("true", StringComparison.OrdinalIgnoreCase) == true
            || value?.Equals("yes", StringComparison.OrdinalIgnoreCase) == true;
    }
}
