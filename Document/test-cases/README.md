# Bộ test case Quản Lý Nhà Hàng

Ngày tạo: 21/05/2026  
Ngôn ngữ: Tiếng Việt + English  
Tổng số: 26 file Excel, 338 test case

## File nên mở trước

- `00_summary/00_master_test_report.xlsx`: báo cáo tổng hợp số lượng case theo từng workbook.
- `00_summary/01_executed_smoke_tests.xlsx`: các smoke test đã chạy thật và có kết quả `Pass / Đạt`.

## Cây thư mục

- `01_mobile_app`: test app Android/mobile theo từng chức năng.
- `02_web_app`: test bản web, responsive, web admin và báo cáo.
- `03_api_backend`: test API/backend theo từng nhóm route.
- `04_cross_platform`: test end-to-end, phân quyền, bảo mật và UI/UX.

## Quy ước kết quả

- `Pass / Đạt`: đã chạy và đúng expected output.
- `Fail / Không đạt`: đã chạy nhưng không đúng expected output.
- `Pending / Chưa chạy`: đã viết case, chờ chạy thủ công hoặc automation sau.

Hiện có 10 case smoke test `Pass / Đạt`, 0 case `Fail / Không đạt`, 328 case `Pending / Chưa chạy`.

## Cách cập nhật lại bộ Excel

Chạy từ thư mục gốc dự án:

```powershell
python tools\generate_test_cases.py
```

Script sẽ sinh lại toàn bộ file Excel trong `Document/test-cases`, kiểm tra ID không trùng, và xác nhận workbook mở được bằng `openpyxl`.
