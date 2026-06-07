# Danh Sách Testcase Tự Động

Bảng này thay thế testcase mẫu bằng các kịch bản tự động đang được cài đặt trong `Reqnroll_Selenium_Project`. Nhóm UI dùng Selenium WebDriver C#, nhóm ma trận `AUTO-001` đến `AUTO-082` chạy bằng Reqnroll/NUnit/C# qua API/backend và không mở Chrome. Ngoài 100 testcase chính, có thêm 5 testcase FAIL minh họa để chạy riêng khi cần bằng chứng lỗi.

| ID | Web | Scenario | Mục tiêu | Kết quả mong đợi |
| --- | --- | --- | --- | --- |
| CUST-01 | Customer | Khách hàng đăng nhập thành công và xem khu làm việc | Kiểm tra login hợp lệ và workspace | Hiện bàn, thực đơn, thông tin khách |
| CUST-02 | Customer | Khách hàng đăng nhập sai mật khẩu | Kiểm tra validation tài khoản | Hiện lỗi `Sai tài khoản khách hàng hoặc mật khẩu` |
| CUST-03 | Customer | Khách hàng lọc danh mục thực đơn để tìm đồ uống | Kiểm tra lọc/tìm món theo danh mục | Hiện `Trà đào cam sả`, không hiện `Phở bò tái` |
| CUST-04 | Customer | Khách hàng đặt bàn và backend cập nhật trạng thái | Kiểm tra thêm dữ liệu đặt bàn | UI báo đã đặt bàn, backend bàn 7 `reserved` |
| CUST-05 | Customer | Khách hàng thêm món và gửi hóa đơn mở | Kiểm tra thêm món/giỏ hàng/gửi đơn | Backend có hóa đơn open với 2 dòng món |
| CUST-06 | Customer | Khách hàng xem lịch sử thanh toán sau khi admin xác nhận | Kiểm tra lịch sử thanh toán | Hóa đơn xuất hiện trong payment history, bàn available |
| CUST-07 | Customer | Khách hàng reload responsive và đăng xuất | Kiểm tra session, responsive, logout | App load trên mobile viewport, logout xóa localStorage |
| STAFF-01 | Staff | Nhân viên đăng nhập và đi qua các màn hình chính | Kiểm tra login và sidebar | Các màn hình không lỗi kết nối |
| STAFF-02 | Staff | Nhân viên thêm bàn mới trên giao diện | Kiểm tra thêm bàn | Backend có `Bàn Auto Staff` |
| STAFF-03 | Staff | Nhân viên gọi món cho bàn trên giao diện | Kiểm tra vào màn hình bàn và tạo order | Backend có hóa đơn open tại bàn 7 |
| STAFF-04 | Staff | Nhân viên thanh toán hóa đơn | Kiểm tra thu tiền | Backend ghi nhận order `paid` |
| STAFF-05 | Staff | Nhân viên ghi nợ và thu nợ | Kiểm tra công nợ | Order thành `debt`, debt thành `paid` |
| STAFF-06 | Staff | Nhân viên chấm công và xem thông báo | Kiểm tra attendance/notification | Attendance có checkout, thông báo hiển thị |
| ADMIN-01 | Admin | Admin đăng nhập và duyệt tất cả màn hình | Kiểm tra quyền admin/sidebar | Duyệt 10 màn hình không lỗi kết nối |
| ADMIN-02 | Admin | Admin tạo, sửa, ẩn và xóa món ăn | Kiểm tra CRUD menu | Tạo, sửa tên, ẩn, xóa món thành công |
| ADMIN-03 | Admin | Admin tạo, sửa và khóa tài khoản nhân viên | Kiểm tra quản lý tài khoản | Tạo, sửa, khóa nhân viên thành công |
| ADMIN-04 | Admin | Admin tạo và xóa thông báo | Kiểm tra notification | Tạo và xóa thông báo thành công |
| ADMIN-05 | Admin | Admin xem bảng lương và reset demo | Kiểm tra payroll/reset | Payroll tháng 2026-05 có dữ liệu, reset về 16 bàn |

Lệnh chạy toàn bộ:

```powershell
cd 5_AutoDescription_QuanLyNhaHang\Reqnroll_Selenium_Project
dotnet test --filter "Name!~FAIL"
```

## Ma Trận Bổ Sung 82 Testcase

Các testcase sau nằm trong `Features/ComprehensiveMatrix.feature`, chạy bằng Reqnroll/NUnit/C# và được ánh xạ trong `StepDefinitions/MatrixSteps.cs`. Đây là nhóm kiểm thử API/backend, không dùng Selenium WebDriver.

| ID | Nhóm | Scenario | Mục tiêu | Kết quả mong đợi |
| --- | --- | --- | --- | --- |
| AUTO-001 | Đăng nhập | Đăng nhập nhân viên hợp lệ | Kiểm tra tài khoản staff seed | Trả về role `staff` |
| AUTO-002 | Đăng nhập | Đăng nhập admin hợp lệ | Kiểm tra tài khoản admin seed | Trả về role `admin` |
| AUTO-003 | Đăng nhập | Đăng nhập khách hàng hợp lệ | Kiểm tra tài khoản customer seed | Trả về customer id `1` |
| AUTO-004 | Đăng nhập | Từ chối mật khẩu sai của nhân viên | Kiểm tra validation auth | HTTP 401 |
| AUTO-005 | Đăng nhập | Từ chối mật khẩu sai của khách hàng | Kiểm tra validation customer auth | HTTP 401 |
| AUTO-006 | Đăng nhập | Từ chối tài khoản nhân viên đã khóa | Kiểm tra account disabled | Không đăng nhập được |
| AUTO-007 | Đăng nhập | Tài khoản nhân viên quyền admin đăng nhập | Kiểm tra phân quyền admin mới | Role trả về `admin` |
| AUTO-008 | Đăng nhập | Tự sinh username không trùng | Kiểm tra unique username | Username mới không trùng `staff` |
| AUTO-009 | Web khách hàng | Bootstrap khách hàng trả về bàn và món | Kiểm tra dữ liệu đầu vào web khách | Có 16 bàn và 52 món |
| AUTO-010 | Web khách hàng | Bootstrap khách hàng không tồn tại | Kiểm tra dữ liệu với customer id sai | Customer trả về null |
| AUTO-011 | Web khách hàng | Danh sách đặt bàn của khách seed | Kiểm tra lịch đặt bàn | Có đặt bàn seed tại bàn 6 |
| AUTO-012 | Web khách hàng | Khách đặt bàn trống thành công | Kiểm tra đặt bàn | Reservation `confirmed` |
| AUTO-013 | Web khách hàng | Khách không đặt được bàn đang dùng | Kiểm tra ràng buộc trạng thái bàn | HTTP 409 |
| AUTO-014 | Web khách hàng | Khách gọi món rỗng bị từ chối | Kiểm tra validation giỏ món | HTTP 400 |
| AUTO-015 | Web khách hàng | Khách tạo hóa đơn web | Kiểm tra tạo order từ web khách | Source là `customer_web` |
| AUTO-016 | Web khách hàng | Khách gọi thêm món vào hóa đơn mở | Kiểm tra append món | Cùng order id, tăng số dòng món |
| AUTO-017 | Web khách hàng | Khách khác không dùng bàn đang mở hóa đơn | Kiểm tra xung đột khách | HTTP 409 |
| AUTO-018 | Web khách hàng | Khách xem lịch sử hóa đơn đã thanh toán | Kiểm tra paid history | Paid history chứa hóa đơn vừa trả |
| AUTO-019 | Quản lý bàn | Danh sách bàn seed có 16 bàn | Kiểm tra seed data | Trả về 16 bàn |
| AUTO-020 | Quản lý bàn | Tạo bàn mới | Kiểm tra thêm bàn | Bàn mới có id lớn hơn seed |
| AUTO-021 | Quản lý bàn | Cập nhật thông tin bàn | Kiểm tra sửa bàn | Số ghế cập nhật đúng |
| AUTO-022 | Quản lý bàn | Xóa bàn trống | Kiểm tra xóa bàn | Không còn bàn vừa xóa |
| AUTO-023 | Quản lý bàn | Không xóa bàn có hóa đơn mở | Kiểm tra ràng buộc xóa | HTTP 409 |
| AUTO-024 | Quản lý bàn | Bao phủ trạng thái bàn | Kiểm tra available/reserved/occupied | Có đủ 3 trạng thái |
| AUTO-025 | Quản lý bàn | Hóa đơn mở gắn activeOrderId vào bàn | Kiểm tra liên kết bàn-hóa đơn | Bàn có `activeOrderId` |
| AUTO-026 | Quản lý bàn | Reset khôi phục số bàn | Kiểm tra reset dữ liệu | Bàn quay về 16 |
| AUTO-027 | Quản lý thực đơn | Danh sách thực đơn seed có 52 món | Kiểm tra seed menu | Trả về 52 món |
| AUTO-028 | Quản lý thực đơn | Tạo món mặc định | Kiểm tra giá trị mặc định | Tên món là `Mon moi` |
| AUTO-029 | Quản lý thực đơn | Tạo món tùy chỉnh | Kiểm tra thêm món | Category và giá đúng |
| AUTO-030 | Quản lý thực đơn | Cập nhật giá món | Kiểm tra sửa giá | Giá đổi thành 99000 |
| AUTO-031 | Quản lý thực đơn | Ẩn món khỏi thực đơn | Kiểm tra toggle available | `available=false` |
| AUTO-032 | Quản lý thực đơn | Xóa món | Kiểm tra xóa menu | Không còn món vừa xóa |
| AUTO-033 | Quản lý thực đơn | Món bị ẩn không hiện ở web khách | Kiểm tra lọc menu customer | Bootstrap khách không chứa món ẩn |
| AUTO-034 | Quản lý thực đơn | Không gọi được món bị ẩn | Kiểm tra validation order | HTTP 400 |
| AUTO-035 | Hóa đơn | Danh sách hóa đơn seed | Kiểm tra seed orders | Có 10 hóa đơn |
| AUTO-036 | Hóa đơn | Nhân viên tạo hóa đơn mở | Kiểm tra tạo hóa đơn staff | Status `open` |
| AUTO-037 | Hóa đơn | Lấy hóa đơn mở theo bàn | Kiểm tra endpoint open order | Trả về đúng id |
| AUTO-038 | Hóa đơn | Tái sử dụng hóa đơn mở cùng bàn | Kiểm tra không tạo trùng hóa đơn | Trả về cùng id |
| AUTO-039 | Hóa đơn | Thêm batch món vào hóa đơn | Kiểm tra order batch | Có 1 batch |
| AUTO-040 | Hóa đơn | Thêm một dòng món vào hóa đơn | Kiểm tra add item | Có 1 dòng món |
| AUTO-041 | Hóa đơn | Cập nhật số lượng món | Kiểm tra sửa quantity | Quantity bằng 5 |
| AUTO-042 | Hóa đơn | Số lượng bằng 0 xóa dòng món | Kiểm tra remove item | Danh sách món rỗng |
| AUTO-043 | Hóa đơn | Thanh toán hóa đơn | Kiểm tra pay order | Status `paid` |
| AUTO-044 | Hóa đơn | Không cho vai trò sai thu tiền | Kiểm tra phân quyền thu tiền | HTTP 403 |
| AUTO-045 | Hóa đơn | Ghi công nợ hóa đơn | Kiểm tra debt order | Debt status `open` |
| AUTO-046 | Hóa đơn | Lọc hóa đơn đã thanh toán | Kiểm tra filter status | Danh sách paid chứa hóa đơn |
| AUTO-047 | Công nợ | Danh sách công nợ seed | Kiểm tra seed debts | Có ít nhất 2 công nợ |
| AUTO-048 | Công nợ | Lọc công nợ mở | Kiểm tra query status | Tất cả status là `open` |
| AUTO-049 | Công nợ | Thanh toán công nợ một phần | Kiểm tra partial payment | Vẫn `open` |
| AUTO-050 | Công nợ | Thanh toán hết công nợ | Kiểm tra full payment | Status `paid` |
| AUTO-051 | Công nợ | Công nợ không tồn tại trả lỗi | Kiểm tra id sai | HTTP 404 |
| AUTO-052 | Công nợ | Vai trò sai không thu công nợ | Kiểm tra phân quyền | HTTP 403 |
| AUTO-053 | Nhân viên | Danh sách nhân viên seed | Kiểm tra seed employees | Có 12 nhân viên |
| AUTO-054 | Nhân viên | Tạo nhân viên kèm tài khoản | Kiểm tra tạo account | Username đúng |
| AUTO-055 | Nhân viên | Username nhân viên không trùng | Kiểm tra unique username | Username được đổi khác |
| AUTO-056 | Nhân viên | Cập nhật hồ sơ nhân viên | Kiểm tra sửa nhân viên | Role cập nhật đúng |
| AUTO-057 | Nhân viên | Khóa nhân viên | Kiểm tra disable employee | Active false |
| AUTO-058 | Nhân viên | Tài khoản bị khóa không đăng nhập | Kiểm tra khóa tài khoản | HTTP 401 |
| AUTO-059 | Nhân viên | Tạo nhân viên quyền admin | Kiểm tra account role admin | Đăng nhập ra role admin |
| AUTO-060 | Nhân viên | API nhân viên không lộ password | Kiểm tra bảo mật response | Không trả password |
| AUTO-061 | Chấm công | Lấy chấm công theo ngày | Kiểm tra attendance query | Có dữ liệu ngày seed |
| AUTO-062 | Chấm công | Check-in nhân viên | Kiểm tra tạo attendance | Employee id đúng |
| AUTO-063 | Chấm công | Check-in cùng ngày không tạo trùng | Kiểm tra idempotent | Hai lần trả cùng id |
| AUTO-064 | Chấm công | Check-out nhân viên | Kiểm tra checkout | Có `checkOut` |
| AUTO-065 | Chấm công | Check-out id không tồn tại trả lỗi | Kiểm tra id sai | HTTP 404 |
| AUTO-066 | Tính lương | Bảng lương tháng có dữ liệu | Kiểm tra payroll | 12 dòng và tổng lương > 0 |
| AUTO-067 | Tổng quan | Dashboard trả về số liệu tổng quan | Kiểm tra dashboard | 16 bàn, 100 khách |
| AUTO-068 | Tổng quan | Dashboard giới hạn dữ liệu gần đây | Kiểm tra recent lists | Recent orders <= 5, notifications <= 3 |
| AUTO-069 | Thống kê | Thống kê ngày | Kiểm tra period day | Period `day` |
| AUTO-070 | Thống kê | Thống kê tháng | Kiểm tra period month | Order count > 0 |
| AUTO-071 | Thống kê | Thống kê năm | Kiểm tra top items | Có top items |
| AUTO-072 | Tính lương | Payroll đúng tháng yêu cầu | Kiểm tra query month | Month là `2026-05` |
| AUTO-073 | Admin | Admin health | Kiểm tra health endpoint | Status `ok` |
| AUTO-074 | Admin | Admin export đủ collection | Kiểm tra export dữ liệu | Có tables và customers |
| AUTO-075 | Admin | Admin reset khôi phục seed | Kiểm tra reset admin | Tables về 16 |
| AUTO-076 | Thông báo | Tạo thông báo | Kiểm tra create notification | Title đúng |
| AUTO-077 | Thông báo | Xóa thông báo | Kiểm tra delete notification | Không còn thông báo |
| AUTO-078 | Web entrypoint | Web khách được phục vụ | Kiểm tra HTML customer | Có `loginForm` |
| AUTO-079 | Web entrypoint | Web nhân viên được phục vụ | Kiểm tra Flutter staff | Có `flutter_bootstrap.js` |
| AUTO-080 | Web entrypoint | Web admin được phục vụ | Kiểm tra Flutter admin | Có `flutter_bootstrap.js` |
| AUTO-081 | API Backend | API root sẵn sàng | Kiểm tra backend online | Root trả success |
| AUTO-082 | Performance | Dashboard phản hồi dưới ngưỡng | Kiểm tra thời gian phản hồi | Dưới 3000 ms |

Tổng cộng: 18 testcase UI + 82 testcase ma trận = 100 testcase tự động.

## Testcase FAIL Minh Họa

Các testcase sau nằm trong `Features/FailEvidence.feature`. Đây là 5 testcase thất bại có chủ đích, dùng để tạo log/screenshot FAIL khi cần nộp bằng chứng lỗi. Không chạy chung với 100 testcase chính.

Lệnh chạy riêng:

```powershell
dotnet test --filter "Name~FAIL"
```

| ID | Web | Scenario | Mục tiêu | Kết quả mong đợi |
| --- | --- | --- | --- | --- |
| FAIL-001 | Customer | Sai kỳ vọng login khách hàng | Minh họa lỗi khi kỳ vọng khách tự đăng nhập dù chưa nhập tài khoản | Test fail có chủ đích và sinh ảnh `_FAIL_` |
| FAIL-002 | Customer | Sai kỳ vọng danh sách món | Minh họa lỗi khi kỳ vọng món không tồn tại xuất hiện trong thực đơn | Test fail có chủ đích và sinh ảnh `_FAIL_` |
| FAIL-003 | Staff | Sai kỳ vọng web nhân viên | Minh họa lỗi khi kỳ vọng nhân viên vào dashboard dù chưa đăng nhập | Test fail có chủ đích và sinh ảnh `_FAIL_` |
| FAIL-004 | Admin | Sai kỳ vọng web admin | Minh họa lỗi khi kỳ vọng admin vào màn quản trị dù chưa đăng nhập | Test fail có chủ đích và sinh ảnh `_FAIL_` |
| FAIL-005 | Customer | Sai kỳ vọng lịch sử thanh toán khách hàng | Minh họa lỗi khi kỳ vọng lịch sử thanh toán hiện dù chưa đăng nhập | Test fail có chủ đích và sinh ảnh `_FAIL_` |

Tổng khi tính cả bằng chứng fail: 100 testcase chính + 5 testcase FAIL minh họa = 105 testcase được liệt kê.
