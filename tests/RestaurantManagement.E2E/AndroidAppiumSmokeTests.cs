using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

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

        var options = new AppiumOptions
        {
            PlatformName = "Android",
            AutomationName = "UiAutomator2"
        };
        options.AddAdditionalAppiumOption("app", TestConfig.AndroidApkPath);
        options.AddAdditionalAppiumOption("appPackage", "com.duyencocong.restaurantmanager");
        options.AddAdditionalAppiumOption("appActivity", ".MainActivity");
        options.AddAdditionalAppiumOption("autoGrantPermissions", true);
        options.AddAdditionalAppiumOption("newCommandTimeout", 120);

        using var driver = new AndroidDriver(new Uri(TestConfig.AppiumServerUrl), options, TimeSpan.FromSeconds(180));
        Assert.IsNotNull(driver);
        Assert.AreEqual("com.duyencocong.restaurantmanager", driver.CurrentPackage);
    }
}
