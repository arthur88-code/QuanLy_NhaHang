namespace AutoTest.Support;

internal static class TestSettings
{
    public static string ProjectDirectory =>
        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

    public static string AutoDescriptionDirectory =>
        Path.GetFullPath(Path.Combine(ProjectDirectory, ".."));

    public static string RepositoryRoot =>
        Path.GetFullPath(Path.Combine(AutoDescriptionDirectory, ".."));

    public static string EvidenceDirectory =>
        Path.Combine(AutoDescriptionDirectory, "HinhAnh_KetQua");

    public static string BackendBaseUrl =>
        ReadUrl("RMS_BACKEND_URL", "http://127.0.0.1:3000");

    public static string CustomerWebUrl =>
        ReadUrl("RMS_CUSTOMER_WEB_URL", $"{BackendBaseUrl}/customer/");

    public static string StaffWebUrl =>
        ReadUrl("RMS_STAFF_WEB_URL", $"{BackendBaseUrl}/staff/");

    public static string AdminWebUrl =>
        ReadUrl("RMS_ADMIN_WEB_URL", $"{BackendBaseUrl}/admin-web/");

    public static bool ShowBrowser =>
        IsTruthy(Environment.GetEnvironmentVariable("RMS_SHOW_BROWSER"));

    public static string? ChromeBinary =>
        Environment.GetEnvironmentVariable("RMS_CHROME_BINARY");

    public static string PortalUrl(string portal)
    {
        return portal.Trim().ToLowerInvariant() switch
        {
            "customer" or "khach hang" => CustomerWebUrl,
            "staff" or "nhan vien" => StaffWebUrl,
            "admin" or "admin-web" => AdminWebUrl,
            _ => throw new InvalidOperationException($"Unknown portal: {portal}")
        };
    }

    private static string ReadUrl(string key, string fallback)
    {
        var value = Environment.GetEnvironmentVariable(key);
        var selected = string.IsNullOrWhiteSpace(value) ? fallback : value;
        return selected.TrimEnd('/');
    }

    private static bool IsTruthy(string? value)
    {
        return string.Equals(value, "1", StringComparison.OrdinalIgnoreCase)
            || string.Equals(value, "true", StringComparison.OrdinalIgnoreCase)
            || string.Equals(value, "yes", StringComparison.OrdinalIgnoreCase);
    }
}
