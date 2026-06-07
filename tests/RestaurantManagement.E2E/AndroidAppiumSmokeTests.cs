using System.Diagnostics;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace RestaurantManagement.E2E;

[TestClass]
public sealed class AndroidAppiumSmokeTests
{
    [TestMethod]
    [TestCategory("Android")]
    public void AndroidApp_LaunchesWithAppium()
    {
        if (!TestConfig.RunAndroid)
        {
            Assert.Inconclusive("Set RMS_RUN_ANDROID=1 to run Android Appium tests.");
        }

        if (!File.Exists(TestConfig.AndroidApkPath))
        {
            Assert.Inconclusive($"APK not found: {TestConfig.AndroidApkPath}. Build with: cd frontend && flutter build apk --debug");
        }

        using var appiumServer = EnsureAppiumServer();

        var options = new AppiumOptions
        {
            PlatformName = "Android",
            AutomationName = "UiAutomator2",
            DeviceName = "Android Emulator",
            App = TestConfig.AndroidApkPath
        };
        options.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AppPackage, "com.duyencocong.restaurantmanager");
        options.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AppActivity, ".MainActivity");
        options.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AutoGrantPermissions, true);
        options.AddAdditionalAppiumOption(MobileCapabilityType.NewCommandTimeout, 120);

        using var driver = new AndroidDriver(new Uri(TestConfig.AppiumServerUrl), options, TimeSpan.FromSeconds(180));
        Assert.IsNotNull(driver);
        Assert.AreEqual("com.duyencocong.restaurantmanager", driver.CurrentPackage);
    }

    internal static IDisposable EnsureAppiumServer()
    {
        if (IsAppiumReady())
        {
            return new NoopDisposable();
        }

        var appiumCommand = FindOnPath(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "appium.cmd" : "appium");
        if (appiumCommand is null)
        {
            Assert.Inconclusive("Appium command not found. Install with: npm install -g appium");
        }

        var serverUri = new Uri(TestConfig.AppiumServerUrl);
        if (!serverUri.IsLoopback)
        {
            Assert.Inconclusive($"Appium is not running at {TestConfig.AppiumServerUrl}.");
        }

        var startInfo = new ProcessStartInfo
        {
            FileName = appiumCommand,
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        startInfo.ArgumentList.Add("--address");
        startInfo.ArgumentList.Add(serverUri.Host);
        startInfo.ArgumentList.Add("--port");
        startInfo.ArgumentList.Add(serverUri.Port.ToString());

        var androidSdkRoot = FindAndroidSdkRoot();
        if (androidSdkRoot is not null)
        {
            startInfo.Environment["ANDROID_HOME"] = androidSdkRoot;
            startInfo.Environment["ANDROID_SDK_ROOT"] = androidSdkRoot;
        }

        var process = Process.Start(startInfo)
            ?? throw new InvalidOperationException("Could not start Appium.");
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        for (var i = 0; i < 60; i++)
        {
            if (IsAppiumReady())
            {
                return new OwnedProcess(process);
            }

            Thread.Sleep(500);
        }

        StopProcessTree(process);
        Assert.Inconclusive($"Appium did not start at {TestConfig.AppiumServerUrl}.");
        return new NoopDisposable();
    }

    private static bool IsAppiumReady()
    {
        try
        {
            using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(1) };
            using var response = http.GetAsync($"{TestConfig.AppiumServerUrl}/status").GetAwaiter().GetResult();
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    private static string? FindAndroidSdkRoot()
    {
        foreach (var key in new[] { "ANDROID_SDK_ROOT", "ANDROID_HOME" })
        {
            var value = Environment.GetEnvironmentVariable(key);
            if (IsAndroidSdkRoot(value))
            {
                return value;
            }
        }

        var adb = FindOnPath(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "adb.exe" : "adb");
        var platformTools = adb is null ? null : Directory.GetParent(adb)?.FullName;
        var sdkRoot = platformTools is null ? null : Directory.GetParent(platformTools)?.FullName;
        return IsAndroidSdkRoot(sdkRoot) ? sdkRoot : null;
    }

    private static bool IsAndroidSdkRoot(string? path)
    {
        return !string.IsNullOrWhiteSpace(path)
            && File.Exists(Path.Combine(path, "platform-tools", RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "adb.exe" : "adb"));
    }

    private static string? FindOnPath(string fileName)
    {
        var paths = (Environment.GetEnvironmentVariable("PATH") ?? string.Empty)
            .Split(Path.PathSeparator, StringSplitOptions.RemoveEmptyEntries);
        foreach (var path in paths)
        {
            var candidate = Path.Combine(path.Trim(), fileName);
            if (File.Exists(candidate))
            {
                return candidate;
            }
        }

        return null;
    }

    private static void StopProcessTree(Process process)
    {
        try
        {
            if (!process.HasExited)
            {
                process.Kill(entireProcessTree: true);
            }
        }
        catch
        {
            // Best-effort cleanup for local Appium started by this test.
        }
        finally
        {
            process.Dispose();
        }
    }

    private sealed class OwnedProcess(Process process) : IDisposable
    {
        public void Dispose()
        {
            StopProcessTree(process);
        }
    }

    private sealed class NoopDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
