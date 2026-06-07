# Hướng Dẫn Quay Video Demo Auto Test

Thư mục này dùng để lưu video kết quả kiểm thử tự động. Có thể quay bằng OBS Studio, Xbox Game Bar hoặc công cụ quay màn hình của Windows.

## Chuẩn Bị

1. Mở VS Code tại:

```powershell
d:\University\LapTrinhDiDong\Android\restaurant-management-system
```

2. Mở terminal backend:

```powershell
cd backend
npm start
```

3. Mở terminal auto test:

```powershell
cd 5_AutoDescription_QuanLyNhaHang\Reqnroll_Selenium_Project
```

## Cảnh 1: Giới Thiệu Cấu Trúc

Quay màn hình VS Code và mở các file:

- `README.md`
- `AUTO_TEST_CASES.md`
- `Reqnroll_Selenium_Project/Features`
- `Reqnroll_Selenium_Project/StepDefinitions`

Nội dung cần nói: bộ test chạy trong project Reqnroll/NUnit/C#. 18 testcase UI dùng Selenium WebDriver C# để test trực tiếp 3 web Customer, Staff, Admin; 82 testcase ma trận dùng C# gọi API/backend và không mở Chrome; 5 testcase FAIL minh họa chạy riêng để lấy bằng chứng lỗi.

## Cảnh 2: Kiểm Tra Tổng Số Testcase

Chạy:

```powershell
dotnet test --list-tests
```

Quay phần danh sách test để thấy có 100 testcase chính và 5 testcase FAIL minh họa, gồm nhóm UI, nhóm `AUTO-001` đến `AUTO-082`, và nhóm `FAIL-001` đến `FAIL-005`.

## Cảnh 3: Chạy Ma Trận 82 Testcase

Chạy:

```powershell
dotnet test --filter "Name~AUTO-"
```

Quay kết quả Passed. Đây là phần kiểm thử API/backend toàn diện nhanh cho auth, khách hàng, bàn, món, hóa đơn, công nợ, nhân viên, chấm công, thống kê, admin và phi chức năng; phần này không dùng Selenium và không mở Chrome.

## Cảnh 4: Chạy 5 Testcase FAIL Minh Họa

Chạy:

```powershell
dotnet test --filter "Name~FAIL"
```

Quay kết quả Failed. Đây là nhóm testcase thất bại có chủ đích để tạo bằng chứng lỗi. Sau khi chạy, mở `HinhAnh_KetQua` để xem các ảnh `_FAIL_`.

## Cảnh 5: Demo Web Khách Hàng Bằng Selenium

Chạy:

```powershell
$env:RMS_SHOW_BROWSER="1"
dotnet test --filter "Name~KhachHang"
```

Các điểm cần quay:

- Chrome mở `http://127.0.0.1:3000/customer/`.
- Đăng nhập khách hàng.
- Lọc danh mục món.
- Đặt bàn hoặc gửi món.
- Đăng xuất hoặc kiểm tra responsive.

## Cảnh 6: Demo Web Nhân Viên Và Admin

Chạy một trong hai lệnh:

```powershell
$env:RMS_SHOW_BROWSER="1"
dotnet test --filter "Name~NhanVien"
```

```powershell
$env:RMS_SHOW_BROWSER="1"
dotnet test --filter "Name~Admin"
```

Các điểm cần quay:

- Đăng nhập Staff/Admin.
- Sidebar Flutter web.
- Thêm bàn, thanh toán, công nợ hoặc tạo món/thông báo.
- Terminal hiển thị Passed.

## Cảnh 7: Xem Bằng Chứng Sau Khi Chạy

Mở:

```text
5_AutoDescription_QuanLyNhaHang/HinhAnh_KetQua
```

Quay các ảnh `_PASS_`. Nếu có file `.trx`, mở thư mục:

```text
Reqnroll_Selenium_Project/TestResults
```

## Cảnh 8: Tài Liệu Nộp

Mở lần lượt:

- `AutoDescription.docx`
- `TestCase.xlsx`
- `AUTO_TEST_CASES.md`
- `README.md`

Nội dung cần nói: các file này mô tả testcase tự động, công cụ sử dụng, hình ảnh/video kết quả kiểm thử và mã nguồn Auto Test.
