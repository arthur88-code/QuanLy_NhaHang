# 5_AutoDescription_ProjectName

Thu muc nay chua bo kiem thu tu dong giao dien web cho he thong quan ly nha hang.

Cong cu su dung:

- Selenium WebDriver C#
- Reqnroll
- NUnit
- Google Chrome / ChromeDriver qua Selenium Manager

Ket qua hien tai: `dotnet test --no-build` pass `18/18` scenario.

## Cau truc

```text
5_AutoDescription_ProjectName/
  README.md
  AUTO_TEST_CASES.md
  HinhAnh_KetQua/                 # Anh chup PASS/FAIL sau moi scenario
  Video_Demo/                     # Dat video demo neu quay them
  Reqnroll_Selenium_Project/
    AutoTest.csproj
    Features/
      CustomerWeb.feature
      StaffWeb.feature
      AdminWeb.feature
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

## Web duoc test truc tiep

- Khach hang: `http://127.0.0.1:3000/customer/`
- Nhan vien: `http://127.0.0.1:3000/staff/`
- Admin: `http://127.0.0.1:3000/admin-web/`

Tai khoan seed:

| Vai tro | Tai khoan | Mat khau |
| --- | --- | --- |
| Khach hang | `customer001` | `123` |
| Nhan vien | `staff` | `123` |
| Admin | `admin` | `123` |

## Cach chay trong VS Code

Mo terminal tai root project:

```powershell
cd d:\University\LapTrinhDiDong\Android\restaurant-management-system
```

Chay backend:

```powershell
cd backend
npm install
npm start
```

Neu Flutter web build chua co, build frontend:

```powershell
cd ..\frontend
flutter build web
```

Mo terminal khac va chay auto test:

```powershell
cd d:\University\LapTrinhDiDong\Android\restaurant-management-system\5_AutoDescription_ProjectName\Reqnroll_Selenium_Project
dotnet restore
dotnet test
```

Chay theo nhom:

```powershell
dotnet test --filter "Name~KhachHang"
dotnet test --filter "Name~NhanVien"
dotnet test --filter "Name~Admin"
```

Ghi file ket qua TRX:

```powershell
dotnet test --logger "trx;LogFileName=auto-test.trx"
```

Mo Chrome that khi debug:

```powershell
$env:RMS_SHOW_BROWSER="1"
dotnet test --filter "Name~KhachHang"
```

Tuy bien URL neu port thay doi:

```powershell
$env:RMS_BACKEND_URL="http://127.0.0.1:3000"
$env:RMS_CUSTOMER_WEB_URL="http://127.0.0.1:3000/customer/"
$env:RMS_STAFF_WEB_URL="http://127.0.0.1:3000/staff/"
$env:RMS_ADMIN_WEB_URL="http://127.0.0.1:3000/admin-web/"
dotnet test
```

## Cach hoat dong

Reqnroll doc cac file `.feature` de lay kich ban tu nhien. Moi cau Given/When/Then duoc map sang C# trong `StepDefinitions`.

Selenium mo Chrome va thao tac UI:

- Customer web la HTML nen dung CSS selector ro rang: `#username`, `#tableGrid`, `[data-add]`, ...
- Staff/Admin la Flutter web nen dung semantics/ARIA label: `action-add-table`, `invoice-pay-*`, `action-reset-demo`, ...
- Mot so action cua Flutter build hien tai merge semantics thanh row lon; voi cac thao tac row kho kich hoat bang Selenium, test mo UI de xac nhan man hinh va dung API backend de hoan tat state, sau do assert du lieu that.

Moi scenario deu:

1. Kiem tra backend san sang.
2. Reset du lieu demo qua `/reset`.
3. Mo dung web can test.
4. Thao tac UI bang Selenium.
5. Kiem tra ket qua hien thi va/hoac trang thai backend.
6. Chup screenshot vao `HinhAnh_KetQua`.

## Bang chung ket qua

Sau moi scenario, hook `SeleniumHooks` chup anh:

- PASS: `HinhAnh_KetQua/*_PASS_*.png`
- FAIL: `HinhAnh_KetQua/*_FAIL_*.png`

Khi can nop minh chung, chay:

```powershell
dotnet test --logger "trx;LogFileName=auto-test.trx"
```

Sau do lay:

- Anh trong `HinhAnh_KetQua`
- File `.trx` trong `Reqnroll_Selenium_Project/TestResults`
- Ma nguon auto test trong `Reqnroll_Selenium_Project`

## Ghi chu ky thuat

- ChromeDriver duoc Selenium Manager tu dong resolve, khong can tai tay neu Chrome da cai.
- Neu may co Chrome o duong dan dac biet, set `RMS_CHROME_BINARY`.
- Tat ca test dat `[assembly: NonParallelizable]` vi backend demo dung chung du lieu seed va moi scenario deu reset data.

## Cập Nhật Bổ Sung: Bộ Kiểm Thử 100 Testcase

Phần trên là README ban đầu của bộ 18 scenario UI. Bộ auto test hiện đã được mở rộng thành `100` testcase Reqnroll/NUnit:

- `18` testcase UI/web chạy Selenium trực tiếp trên Chrome.
- `82` testcase ma trận toàn diện chạy qua Reqnroll + C# + API/backend để bao phủ nghiệp vụ, phân quyền, dữ liệu, lỗi, phục hồi và phi chức năng.

Lý do tách như vậy: các màn Customer/Staff/Admin vẫn được kiểm thử bằng Selenium thật; các kiểm thử lặp lại sâu về dữ liệu được đưa vào ma trận API để chạy nhanh, ổn định và đủ rộng. Chrome chỉ được mở khi scenario thật sự cần Selenium.

Lệnh kiểm tra số lượng testcase:

```powershell
cd d:\University\LapTrinhDiDong\Android\restaurant-management-system\5_AutoDescription_ProjectName\Reqnroll_Selenium_Project
dotnet test --no-build --list-tests
```

Chạy riêng ma trận 82 testcase:

```powershell
dotnet test --filter "Name~AUTO-"
```

Chạy toàn bộ 100 testcase:

```powershell
dotnet test
```

## Cấu Trúc Chi Tiết Và Vai Trò Từng File

| Đường dẫn | Vai trò |
| --- | --- |
| `README.md` | Tài liệu chính: công cụ, phạm vi, cách chạy trong VS Code, cách lấy bằng chứng ảnh/video, cấu trúc mã nguồn. |
| `AUTO_TEST_CASES.md` | Danh mục testcase tự động bằng tiếng Việt, gồm 18 testcase UI và 82 testcase ma trận. |
| `TestCase.xlsx` | File Excel testcase tự động dùng để nộp, đã cập nhật theo bộ 100 testcase. |
| `AutoDescription.docx` | Tài liệu mô tả auto test: mục tiêu, công cụ, quy trình chạy, ảnh/video kết quả và mã nguồn auto test. |
| `HinhAnh_KetQua/` | Lưu ảnh chụp màn hình sau các scenario có mở Chrome. Tên file có `_PASS_` hoặc `_FAIL_`. |
| `Video_Demo/README.md` | Kịch bản quay video demo từng cảnh: chuẩn bị, chạy test, xem kết quả, giải thích source. |
| `Reqnroll_Selenium_Project/AutoTest.csproj` | Project C# cấu hình NUnit, Reqnroll, Selenium WebDriver và Selenium Support. |
| `Reqnroll_Selenium_Project/Features/CustomerWeb.feature` | Kịch bản tự nhiên cho web khách hàng: đăng nhập, lọc món, đặt bàn, gọi món, thanh toán, responsive, logout. |
| `Reqnroll_Selenium_Project/Features/StaffWeb.feature` | Kịch bản tự nhiên cho web nhân viên: đăng nhập, điều hướng, thêm bàn, gọi món, thanh toán, công nợ, chấm công. |
| `Reqnroll_Selenium_Project/Features/AdminWeb.feature` | Kịch bản tự nhiên cho web admin: điều hướng, món ăn, nhân viên, thông báo, bảng lương, reset demo. |
| `Reqnroll_Selenium_Project/Features/ComprehensiveMatrix.feature` | Ma trận 82 testcase bổ sung, bao phủ gần toàn bộ chức năng backend và web entrypoint. |
| `Reqnroll_Selenium_Project/StepDefinitions/CommonSteps.cs` | Các bước dùng chung: kiểm tra backend, reset dữ liệu, mở web, đăng nhập Flutter, kiểm tra nội dung. |
| `Reqnroll_Selenium_Project/StepDefinitions/CustomerSteps.cs` | StepDefinitions Selenium cho trang Customer HTML. |
| `Reqnroll_Selenium_Project/StepDefinitions/StaffSteps.cs` | StepDefinitions cho nghiệp vụ Staff, kết hợp UI Flutter semantics và assert backend. |
| `Reqnroll_Selenium_Project/StepDefinitions/AdminSteps.cs` | StepDefinitions cho nghiệp vụ Admin, quản lý món, nhân viên, thông báo, lương, reset. |
| `Reqnroll_Selenium_Project/StepDefinitions/MatrixSteps.cs` | 82 testcase ma trận, mỗi ID `AUTO-xxx` ánh xạ tới một kiểm thử tự động cụ thể. |
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
3. Mở terminal auto test: `cd 5_AutoDescription_ProjectName\Reqnroll_Selenium_Project`.
4. Chạy `dotnet test --list-tests` để cho thấy tổng 100 testcase.
5. Chạy `dotnet test --filter "Name~AUTO-"` để demo 82 testcase ma trận chạy nhanh.
6. Chạy `dotnet test --filter "Name~KhachHang"` để quay Chrome thao tác web khách hàng.
7. Chạy `dotnet test --filter "Name~NhanVien"` hoặc `Name~Admin` để quay thêm web Flutter.
8. Mở thư mục `HinhAnh_KetQua` cho thấy ảnh PASS.
9. Mở `AUTO_TEST_CASES.md`, `TestCase.xlsx`, `AutoDescription.docx` để chứng minh testcase, mô tả và tài liệu nộp.
10. Kết thúc bằng màn hình terminal có dòng Passed.



## Lưu Ý Bằng Chứng

- Test UI có mở Chrome sẽ sinh ảnh trong `HinhAnh_KetQua`.
- Test ma trận API không mở Chrome nên bằng chứng chính là log `dotnet test`, file `.trx` nếu bật logger, và bảng testcase trong `AUTO_TEST_CASES.md`/`TestCase.xlsx`.
- Khi nộp bài, nén toàn bộ thư mục `5_AutoDescription_ProjectName` để có đủ: mô tả testcase, công cụ, ảnh/video kết quả và mã nguồn Auto Test.
