# C# Automated Tests

Open this solution in Visual Studio 2022:

```text
tests/RestaurantManagement.Tests.sln
```

Use this project type when creating it manually:

- For 3 web clients: `MSTest Playwright Test Project`
- For Android app: MSTest project plus `Appium.WebDriver`

This repo already has one combined test project:

```text
tests/RestaurantManagement.E2E
```

## What It Tests

- Customer web: `http://127.0.0.1:3000/customer/`
- Staff web: `http://127.0.0.1:3000/staff/`
- Admin web: `http://127.0.0.1:3000/admin-web/`
- Backend API smoke flows
- Android app launch through Appium, disabled by default until you enable it

The customer web Playwright tests are scenario tests: login, reserve table, create order, append items, pay and verify payment history, validate errors, reload session, logout, category navigation, and mobile layout checks. `WebMatrix60` adds 60 web scenario cases across all 3 web surfaces: 20 customer web cases, 20 staff/employee web cases, and 20 admin web cases. `Business150` adds 150 business scenario cases: 30 customer web, 30 staff web, 30 admin web, 30 Android app business, and 30 sequential customer -> staff -> admin flows. Staff/admin Flutter web entrypoints are loaded by Playwright; their business workflows, plus Android business flows, are verified through the same backend endpoints used by those screens.

## Run Web/API Tests

Start backend first:

```powershell
cd backend
npm start
```

Build Flutter web if you want `/staff/` and `/admin-web/` to load from backend:

```powershell
cd frontend
flutter build web
```

Install Playwright browsers once:

```powershell
cd tests\RestaurantManagement.E2E
dotnet build
powershell -ExecutionPolicy Bypass -File bin\Debug\net10.0\playwright.ps1 install
```

Run:

```powershell
dotnet test tests\RestaurantManagement.Tests.sln
```

In Visual Studio 2022, open `tests/RestaurantManagement.Tests.sln`, then use Test Explorer.

Optional: select `tests/local.runsettings` in Visual Studio via `Test > Configure Run Settings > Select Solution Wide runsettings File`.

To see the browser while Playwright clicks through web tests, set `RMS_SHOW_BROWSER` to `1` in `tests/local.runsettings`. Leave it as `0` for normal headless runs.

## Run Android Appium Test

Install Appium server:

```powershell
npm install -g appium
appium.cmd driver install uiautomator2@4.2.9
```

Use `appium.cmd` from PowerShell if `appium.ps1` is blocked by the execution policy.

Build APK:

```powershell
cd frontend
flutter build apk --debug
```

Start an Android emulator, then run with environment variables:

```powershell
$env:RMS_RUN_ANDROID="1"
$env:RMS_APPIUM_URL="http://127.0.0.1:4723/"
$env:RMS_ANDROID_APK="D:\University\LapTrinhDiDong\Android\restaurant-management-system\frontend\build\app\outputs\flutter-apk\app-debug.apk"
dotnet test tests\RestaurantManagement.Tests.sln --filter TestCategory=Android
```

The C# Android test starts Appium automatically when nothing is listening on `RMS_APPIUM_URL`. If you start Appium manually, make sure `ANDROID_HOME` and `ANDROID_SDK_ROOT` point to the Android SDK folder that contains `platform-tools\adb.exe`.

For app tests that need backend access on emulator, keep backend running at `http://127.0.0.1:3000`; the Flutter app tries emulator fallback `http://10.0.2.2:3000`.

## Useful Environment Variables

- `RMS_BACKEND_URL`: default `http://127.0.0.1:3000`
- `RMS_CUSTOMER_WEB_URL`: default `${RMS_BACKEND_URL}/customer/`
- `RMS_STAFF_WEB_URL`: default `${RMS_BACKEND_URL}/staff/`
- `RMS_ADMIN_WEB_URL`: default `${RMS_BACKEND_URL}/admin-web/`
- `RMS_RUN_ANDROID`: set `1` to enable Android Appium tests
- `RMS_SHOW_BROWSER`: set `1` to show Playwright Chromium during web tests
- `RMS_APPIUM_URL`: default `http://127.0.0.1:4723/`
- `RMS_ANDROID_APK`: path to APK
