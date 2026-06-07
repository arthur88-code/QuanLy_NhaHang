Feature: Ma trận kiểm thử tự động toàn diện
  Các testcase này bổ sung phạm vi chức năng và phi chức năng để tổng bộ Reqnroll đạt khoảng 100 scenario.

  Background:
    Given backend dang san sang
    And he thong du lieu demo duoc reset

  Scenario Outline: Ma trận kiểm thử <id> - <tieu_de>
    When tôi chạy testcase tự động "<id>"
    Then testcase "<id>" đạt yêu cầu

    Examples:
      | id       | tieu_de                                      |
      | AUTO-001 | Đăng nhập nhân viên hợp lệ                   |
      | AUTO-002 | Đăng nhập admin hợp lệ                       |
      | AUTO-003 | Đăng nhập khách hàng hợp lệ                  |
      | AUTO-004 | Từ chối mật khẩu sai của nhân viên           |
      | AUTO-005 | Từ chối mật khẩu sai của khách hàng          |
      | AUTO-006 | Từ chối tài khoản nhân viên đã khóa          |
      | AUTO-007 | Tài khoản nhân viên quyền admin đăng nhập    |
      | AUTO-008 | Tự sinh username không trùng                 |
      | AUTO-009 | Bootstrap khách hàng trả về bàn và món       |
      | AUTO-010 | Bootstrap khách hàng không tồn tại           |
      | AUTO-011 | Danh sách đặt bàn của khách seed             |
      | AUTO-012 | Khách đặt bàn trống thành công               |
      | AUTO-013 | Khách không đặt được bàn đang dùng           |
      | AUTO-014 | Khách gọi món rỗng bị từ chối                |
      | AUTO-015 | Khách tạo hóa đơn web                        |
      | AUTO-016 | Khách gọi thêm món vào hóa đơn mở            |
      | AUTO-017 | Khách khác không dùng bàn đang mở hóa đơn    |
      | AUTO-018 | Khách xem lịch sử hóa đơn đã thanh toán      |
      | AUTO-019 | Danh sách bàn seed có 16 bàn                 |
      | AUTO-020 | Tạo bàn mới                                  |
      | AUTO-021 | Cập nhật thông tin bàn                       |
      | AUTO-022 | Xóa bàn trống                                |
      | AUTO-023 | Không xóa bàn có hóa đơn mở                  |
      | AUTO-024 | Bao phủ trạng thái bàn                       |
      | AUTO-025 | Hóa đơn mở gắn activeOrderId vào bàn         |
      | AUTO-026 | Reset khôi phục số bàn                       |
      | AUTO-027 | Danh sách thực đơn seed có 52 món            |
      | AUTO-028 | Tạo món mặc định                             |
      | AUTO-029 | Tạo món tùy chỉnh                            |
      | AUTO-030 | Cập nhật giá món                             |
      | AUTO-031 | Ẩn món khỏi thực đơn                         |
      | AUTO-032 | Xóa món                                      |
      | AUTO-033 | Món bị ẩn không hiện ở web khách             |
      | AUTO-034 | Không gọi được món bị ẩn                     |
      | AUTO-035 | Danh sách hóa đơn seed                       |
      | AUTO-036 | Nhân viên tạo hóa đơn mở                     |
      | AUTO-037 | Lấy hóa đơn mở theo bàn                      |
      | AUTO-038 | Tái sử dụng hóa đơn mở cùng bàn              |
      | AUTO-039 | Thêm batch món vào hóa đơn                   |
      | AUTO-040 | Thêm một dòng món vào hóa đơn                |
      | AUTO-041 | Cập nhật số lượng món                        |
      | AUTO-042 | Số lượng bằng 0 xóa dòng món                 |
      | AUTO-043 | Thanh toán hóa đơn                           |
      | AUTO-044 | Không cho vai trò sai thu tiền               |
      | AUTO-045 | Ghi công nợ hóa đơn                          |
      | AUTO-046 | Lọc hóa đơn đã thanh toán                    |
      | AUTO-047 | Danh sách công nợ seed                       |
      | AUTO-048 | Lọc công nợ mở                               |
      | AUTO-049 | Thanh toán công nợ một phần                  |
      | AUTO-050 | Thanh toán hết công nợ                       |
      | AUTO-051 | Công nợ không tồn tại trả lỗi                |
      | AUTO-052 | Vai trò sai không thu công nợ                |
      | AUTO-053 | Danh sách nhân viên seed                     |
      | AUTO-054 | Tạo nhân viên kèm tài khoản                  |
      | AUTO-055 | Username nhân viên không trùng               |
      | AUTO-056 | Cập nhật hồ sơ nhân viên                     |
      | AUTO-057 | Khóa nhân viên                               |
      | AUTO-058 | Tài khoản bị khóa không đăng nhập            |
      | AUTO-059 | Tạo nhân viên quyền admin                    |
      | AUTO-060 | API nhân viên không lộ password              |
      | AUTO-061 | Lấy chấm công theo ngày                      |
      | AUTO-062 | Check-in nhân viên                           |
      | AUTO-063 | Check-in cùng ngày không tạo trùng           |
      | AUTO-064 | Check-out nhân viên                          |
      | AUTO-065 | Check-out id không tồn tại trả lỗi           |
      | AUTO-066 | Bảng lương tháng có dữ liệu                  |
      | AUTO-067 | Dashboard trả về số liệu tổng quan           |
      | AUTO-068 | Dashboard giới hạn dữ liệu gần đây           |
      | AUTO-069 | Thống kê ngày                                |
      | AUTO-070 | Thống kê tháng                               |
      | AUTO-071 | Thống kê năm                                 |
      | AUTO-072 | Payroll đúng tháng yêu cầu                   |
      | AUTO-073 | Admin health                                 |
      | AUTO-074 | Admin export đủ collection                   |
      | AUTO-075 | Admin reset khôi phục seed                   |
      | AUTO-076 | Tạo thông báo                                |
      | AUTO-077 | Xóa thông báo                                |
      | AUTO-078 | Web khách được phục vụ                       |
      | AUTO-079 | Web nhân viên được phục vụ                   |
      | AUTO-080 | Web admin được phục vụ                       |
      | AUTO-081 | API root sẵn sàng                            |
      | AUTO-082 | Dashboard phản hồi dưới ngưỡng               |
