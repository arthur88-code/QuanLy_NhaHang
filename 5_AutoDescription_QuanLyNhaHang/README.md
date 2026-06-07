# 5_AutoDescription_QuanLyNhaHang

Thư mục này chứa bộ kiểm thử tự động cho hệ thống quản lý nhà hàng, gồm testcase UI Selenium, testcase ma trận API/backend và 5 testcase FAIL minh họa để lấy bằng chứng lỗi.

Công cụ sử dụng:

- Reqnroll + NUnit + C# cho toàn bộ bộ test.
- Selenium WebDriver C# + Google Chrome/ChromeDriver cho 18 testcase UI/web.
- BackendApi/HTTP client trong C# cho 82 testcase ma trận API/backend.

Trạng thái hiện tại: bộ test có 100 testcase chính và 5 testcase FAIL minh họa. Trong 100 testcase chính có 18 scenario UI dùng Selenium và 82 scenario ma trận không mở Chrome.

## Cấu Trúc

```text
5_AutoDescription_QuanLyNhaHang/
  README.md
  AUTO_TEST_CASES.md
  HinhAnh_KetQua/                 # Ảnh chụp PASS/FAIL sau mỗi scenario
  Video_Demo/                     # Đặt video demo nếu quay thêm
  Reqnroll_Selenium_Project/
    AutoTest.csproj
    Features/
      CustomerWeb.feature
      StaffWeb.feature
      AdminWeb.feature
      FailEvidence.feature
    Hooks/
      SeleniumHooks.cs
    StepDefinitions/
      CommonSteps.cs
      CustomerSteps.cs
      StaffSteps.cs
      AdminSteps.cs
    Support/
      BackendApi.cs
      BrowserSession.cs
      FlutterUi.cs
      Polling.cs
      TestRuntime.cs
      TestSettings.cs
```

## Web Được Kiểm Thử Trực Tiếp

- Khách hàng: `http://127.0.0.1:3000/customer/`
- Nhân viên: `http://127.0.0.1:3000/staff/`
- Admin: `http://127.0.0.1:3000/admin-web/`

Tài khoản seed:

| Vai trò | Tài khoản | Mật khẩu |
| --- | --- | --- |
| Khách hàng | `customer001` | `123` |
| Nhân viên | `staff` | `123` |
| Admin | `admin` | `123` |

## Cách Chạy Trong VS Code

Mở terminal tại root project:

```powershell
cd d:\University\LapTrinhDiDong\Android\restaurant-management-system
```

Chạy backend:

```powershell
cd backend
npm install
npm start
```

Nếu Flutter web build chưa có, build frontend:

```powershell
cd ..\frontend
flutter build web
```

Mở terminal khác và chạy auto test:

```powershell
cd d:\University\LapTrinhDiDong\Android\restaurant-management-system\5_AutoDescription_QuanLyNhaHang\Reqnroll_Selenium_Project
dotnet restore
dotnet test --filter "Name!~FAIL"
```

Chạy theo nhóm:

```powershell
dotnet test --filter "Name~KhachHang"
dotnet test --filter "Name~NhanVien"
dotnet test --filter "Name~Admin"
```

Ghi file kết quả TRX:

```powershell
dotnet test --filter "Name!~FAIL" --logger "trx;LogFileName=auto-test-pass.trx"
```

Mở Chrome thật khi debug:

```powershell
$env:RMS_SHOW_BROWSER="1"
dotnet test --filter "Name~KhachHang"
```

Tùy biến URL nếu port thay đổi:

```powershell
$env:RMS_BACKEND_URL="http://127.0.0.1:3000"
$env:RMS_CUSTOMER_WEB_URL="http://127.0.0.1:3000/customer/"
$env:RMS_STAFF_WEB_URL="http://127.0.0.1:3000/staff/"
$env:RMS_ADMIN_WEB_URL="http://127.0.0.1:3000/admin-web/"
dotnet test --filter "Name!~FAIL"
```

## Cách Hoạt Động

Reqnroll đọc các file `.feature` để lấy kịch bản tự nhiên. Mỗi câu Given/When/Then được ánh xạ sang C# trong `StepDefinitions`.

Nhóm 18 testcase UI dùng Selenium mở Chrome và thao tác giao diện:

- Customer web là HTML nên dùng CSS selector rõ ràng: `#username`, `#tableGrid`, `[data-add]`, ...
- Staff/Admin là Flutter web nên dùng semantics/ARIA label: `action-add-table`, `invoice-pay-*`, `action-reset-demo`, ...
- Một số action của Flutter build hiện tại merge semantics thành row lớn; với các thao tác row khó kích hoạt bằng Selenium, test mở UI để xác nhận màn hình và dùng API backend để hoàn tất state, sau đó assert dữ liệu thật.

Nhóm 82 testcase ma trận nằm trong `Features/ComprehensiveMatrix.feature` và `StepDefinitions/MatrixSteps.cs`. Nhóm này vẫn chạy trong cùng project Reqnroll/NUnit/C#, nhưng kiểm thử chủ yếu qua `BackendApi`/HTTP và assert dữ liệu backend; Selenium không được dùng cho nhóm này.

Mỗi scenario UI thường:

1. Kiểm tra backend sẵn sàng.
2. Reset dữ liệu demo qua `/reset`.
3. Mở đúng web cần test.
4. Thao tác UI bằng Selenium.
5. Kiểm tra kết quả hiển thị và/hoặc trạng thái backend.
6. Chụp screenshot vào `HinhAnh_KetQua`.

Mỗi scenario ma trận thường:

1. Kiểm tra backend sẵn sàng.
2. Reset dữ liệu demo qua `/reset`.
3. Gọi API/backend bằng C#.
4. Assert trạng thái HTTP, dữ liệu trả về và dữ liệu lưu trong backend.

## Bằng Chứng Kết Quả

Với scenario UI có mở Chrome, hook `SeleniumHooks` chụp ảnh:

- PASS: `HinhAnh_KetQua/*_PASS_*.png`
- FAIL: `HinhAnh_KetQua/*_FAIL_*.png`

Với 82 testcase ma trận API/backend, bằng chứng chính là log `dotnet test`, file `.trx` nếu bật logger, và danh sách testcase trong `AUTO_TEST_CASES.md`/`TestCase.xlsx`.

Với 5 testcase FAIL minh họa, chạy riêng bằng:

```powershell
dotnet test --filter "Name~FAIL"
```

Lệnh này được thiết kế để trả kết quả failed. Nếu scenario đã mở Chrome, hook sẽ lưu ảnh `_FAIL_` trong `HinhAnh_KetQua`.

Khi cần nộp minh chứng, chạy:

```powershell
dotnet test --filter "Name!~FAIL" --logger "trx;LogFileName=auto-test-pass.trx"
dotnet test --filter "Name~FAIL" --logger "trx;LogFileName=auto-test-fail.trx"
```

Sau đó lấy:

- Ảnh trong `HinhAnh_KetQua`
- File `.trx` trong `Reqnroll_Selenium_Project/TestResults`
- Mã nguồn auto test trong `Reqnroll_Selenium_Project`

## Ghi Chú Kỹ Thuật

- ChromeDriver được Selenium Manager tự động resolve, không cần tải tay nếu Chrome đã cài.
- Nếu máy có Chrome ở đường dẫn đặc biệt, set `RMS_CHROME_BINARY`.
- Tất cả test đặt `[assembly: NonParallelizable]` vì backend demo dùng chung dữ liệu seed và mỗi scenario đều reset data.

## Cập Nhật Bổ Sung: Bộ Kiểm Thử 100 Pass Và 5 Fail

Phần trên là README ban đầu của bộ 18 scenario UI. Bộ auto test hiện đã được mở rộng thành `100` testcase Reqnroll/NUnit:

- `18` testcase UI/web chạy Selenium trực tiếp trên Chrome.
- `82` testcase ma trận toàn diện chạy qua Reqnroll + NUnit + C# + API/backend để bao phủ nghiệp vụ, phân quyền, dữ liệu, lỗi, phục hồi và phi chức năng; nhóm này không dùng Selenium WebDriver.
- `5` testcase FAIL minh họa nằm trong `FailEvidence.feature`, dùng để tạo log/screenshot lỗi khi cần nộp bằng chứng fail.

Lý do tách như vậy: các màn Customer/Staff/Admin vẫn được kiểm thử bằng Selenium thật; các kiểm thử lặp lại sâu về dữ liệu được đưa vào ma trận API để chạy nhanh, ổn định và đủ rộng. Chrome chỉ được mở khi scenario thật sự cần kiểm tra UI.

Lệnh kiểm tra số lượng testcase:

```powershell
cd d:\University\LapTrinhDiDong\Android\restaurant-management-system\5_AutoDescription_QuanLyNhaHang\Reqnroll_Selenium_Project
dotnet test --list-tests
```

Chạy riêng ma trận 82 testcase:

```powershell
dotnet test --filter "Name~AUTO-"
```

Chạy toàn bộ 100 testcase chính, loại 5 testcase FAIL minh họa:

```powershell
dotnet test --filter "Name!~FAIL"
```

Chạy riêng 5 testcase FAIL minh họa:

```powershell
dotnet test --filter "Name~FAIL"
```

## Cấu Trúc Chi Tiết Và Vai Trò Từng File

| Đường dẫn | Vai trò |
| --- | --- |
| `README.md` | Tài liệu chính: công cụ, phạm vi, cách chạy trong VS Code, cách lấy bằng chứng ảnh/video, cấu trúc mã nguồn. |
| `AUTO_TEST_CASES.md` | Danh mục testcase tự động bằng tiếng Việt, gồm 18 testcase UI, 82 testcase ma trận và 5 testcase FAIL minh họa. |
| `TestCase.xlsx` | File Excel testcase tự động dùng để nộp, đã cập nhật theo bộ 100 testcase chính và sheet 5 testcase FAIL. |
| `AutoDescription.docx` | Tài liệu mô tả auto test: mục tiêu, công cụ, quy trình chạy, ảnh/video kết quả và mã nguồn auto test. |
| `HinhAnh_KetQua/` | Lưu ảnh chụp màn hình sau các scenario có mở Chrome. Tên file có `_PASS_` hoặc `_FAIL_`. |
| `Video_Demo/README.md` | Kịch bản quay video demo từng cảnh: chuẩn bị, chạy test, xem kết quả, giải thích source. |
| `Reqnroll_Selenium_Project/AutoTest.csproj` | Project C# cấu hình NUnit, Reqnroll, Selenium WebDriver và Selenium Support. |
| `Reqnroll_Selenium_Project/Features/CustomerWeb.feature` | Kịch bản tự nhiên cho web khách hàng: đăng nhập, lọc món, đặt bàn, gọi món, thanh toán, responsive, logout. |
| `Reqnroll_Selenium_Project/Features/StaffWeb.feature` | Kịch bản tự nhiên cho web nhân viên: đăng nhập, điều hướng, thêm bàn, gọi món, thanh toán, công nợ, chấm công. |
| `Reqnroll_Selenium_Project/Features/AdminWeb.feature` | Kịch bản tự nhiên cho web admin: điều hướng, món ăn, nhân viên, thông báo, bảng lương, reset demo. |
| `Reqnroll_Selenium_Project/Features/ComprehensiveMatrix.feature` | Ma trận 82 testcase bổ sung, chạy qua Reqnroll/C# và API/backend, không dùng Selenium. |
| `Reqnroll_Selenium_Project/Features/FailEvidence.feature` | 5 testcase FAIL minh họa, chạy riêng bằng filter `Name~FAIL` để tạo bằng chứng lỗi. |
| `Reqnroll_Selenium_Project/StepDefinitions/CommonSteps.cs` | Các bước dùng chung: kiểm tra backend, reset dữ liệu, mở web, đăng nhập Flutter, kiểm tra nội dung. |
| `Reqnroll_Selenium_Project/StepDefinitions/CustomerSteps.cs` | StepDefinitions Selenium cho trang Customer HTML. |
| `Reqnroll_Selenium_Project/StepDefinitions/StaffSteps.cs` | StepDefinitions cho nghiệp vụ Staff, kết hợp UI Flutter semantics và assert backend. |
| `Reqnroll_Selenium_Project/StepDefinitions/AdminSteps.cs` | StepDefinitions cho nghiệp vụ Admin, quản lý món, nhân viên, thông báo, lương, reset. |
| `Reqnroll_Selenium_Project/StepDefinitions/MatrixSteps.cs` | 82 testcase ma trận, mỗi ID `AUTO-xxx` ánh xạ tới một kiểm thử API/backend tự động cụ thể. |
| `Reqnroll_Selenium_Project/StepDefinitions/FailEvidenceSteps.cs` | StepDefinitions fail có chủ đích cho 5 testcase `FAIL-001` đến `FAIL-005`. |
| `Reqnroll_Selenium_Project/Hooks/SeleniumHooks.cs` | Hook Before/After scenario: khởi tạo runtime, chụp ảnh khi có browser, dọn tài nguyên. |
| `Reqnroll_Selenium_Project/Support/BrowserSession.cs` | Wrapper Selenium ChromeDriver: mở URL, click/fill, wait, screenshot, viewport. |
| `Reqnroll_Selenium_Project/Support/FlutterUi.cs` | Helper thao tác Flutter web qua semantics/ARIA label. |
| `Reqnroll_Selenium_Project/Support/BackendApi.cs` | HTTP client dùng trong test để reset seed, gọi API, assert trạng thái backend. |
| `Reqnroll_Selenium_Project/Support/Polling.cs` | Helper chờ điều kiện bất đồng bộ như dữ liệu được cập nhật. |
| `Reqnroll_Selenium_Project/Support/TestRuntime.cs` | Quản lý state theo scenario: API client, browser lazy-load, dữ liệu tạm. |
| `Reqnroll_Selenium_Project/Support/TestSettings.cs` | Cấu hình URL, thư mục bằng chứng, biến môi trường. |
| `Reqnroll_Selenium_Project/Properties/AssemblyInfo.cs` | Đặt NUnit `NonParallelizable` để tránh xung đột reset dữ liệu seed. |

## Phạm Vi 100 Testcase

Các nhóm chính:

- Đăng nhập và phân quyền: nhân viên, admin, khách hàng, mật khẩu sai, tài khoản khóa.
- Web khách hàng: bootstrap, đặt bàn, gọi món, thanh toán, lịch sử, lọc món, responsive, logout.
- Quản lý bàn: danh sách, thêm, sửa, xóa, trạng thái, bàn có hóa đơn mở.
- Quản lý thực đơn: danh sách, thêm, sửa giá, ẩn, xóa, món không khả dụng.
- Gọi món và hóa đơn: tạo hóa đơn, batch món, cập nhật số lượng, thanh toán, ghi nợ, lọc trạng thái.
- Công nợ: danh sách, lọc mở, thanh toán một phần, thanh toán đủ, phân quyền.
- Nhân viên: danh sách, tạo tài khoản, cập nhật, khóa, đăng nhập sau khi khóa.
- Chấm công và tính lương: check-in, check-out, idempotent, payroll theo tháng.
- Tổng quan, thống kê, admin export/reset, thông báo.
- Web entrypoint và phi chức năng nhẹ: web được phục vụ, API root, dashboard phản hồi dưới ngưỡng.

## Hướng Dẫn Quay Video Kết Quả Kiểm Thử

Nên quay bằng OBS Studio, Xbox Game Bar hoặc công cụ quay màn hình sẵn có. File video đặt trong `Video_Demo/`.

Trình tự quay đề xuất:

1. Mở VS Code tại project `restaurant-management-system`.
2. Mở terminal chạy backend: `cd backend && npm start`.
3. Mở terminal auto test: `cd 5_AutoDescription_QuanLyNhaHang\Reqnroll_Selenium_Project`.
4. Chạy `dotnet test --list-tests` để cho thấy 100 testcase chính và 5 testcase FAIL minh họa.
5. Chạy `dotnet test --filter "Name~AUTO-"` để demo 82 testcase ma trận API/backend chạy nhanh, không mở Chrome.
6. Chạy `dotnet test --filter "Name~KhachHang"` để quay Chrome thao tác web khách hàng.
7. Chạy `dotnet test --filter "Name~NhanVien"` hoặc `Name~Admin` để quay thêm web Flutter.
8. Chạy `dotnet test --filter "Name~FAIL"` nếu cần quay 5 testcase FAIL minh họa.
9. Mở thư mục `HinhAnh_KetQua` cho thấy ảnh PASS/FAIL.
10. Mở `AUTO_TEST_CASES.md`, `TestCase.xlsx`, `AutoDescription.docx` để chứng minh testcase, mô tả và tài liệu nộp.
11. Kết thúc bằng màn hình terminal có dòng Passed cho nhóm chính và Failed cho nhóm minh họa lỗi.



## Lưu Ý Bằng Chứng

- Test UI có mở Chrome sẽ sinh ảnh trong `HinhAnh_KetQua`.
- Test ma trận API/backend không dùng Selenium và không mở Chrome nên bằng chứng chính là log `dotnet test`, file `.trx` nếu bật logger, và bảng testcase trong `AUTO_TEST_CASES.md`/`TestCase.xlsx`.
- Test FAIL minh họa được thiết kế để thất bại có chủ đích, chỉ chạy khi cần bằng chứng lỗi bằng `dotnet test --filter "Name~FAIL"`.
- Khi nộp bài, nén toàn bộ thư mục `5_AutoDescription_QuanLyNhaHang` để có đủ: mô tả testcase, công cụ, ảnh/video kết quả và mã nguồn Auto Test.
