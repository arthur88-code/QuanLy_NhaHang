Feature: Staff web auto tests
  Reqnroll mo ta cac kich ban Selenium cho cong nhan vien http://127.0.0.1:3000/staff/

  Background:
    Given backend dang san sang
    And he thong du lieu demo duoc reset

  Scenario: Nhan vien dang nhap va di qua cac man hinh chinh
    When toi dang nhap web Flutter "staff" voi tai khoan "staff" mat khau "123"
    Then ung dung Flutter da dang nhap thanh cong
    When toi di den man hinh Flutter so 1
    Then trang khong hien thi loi ket noi
    When toi di den man hinh Flutter so 2
    Then trang khong hien thi loi ket noi
    When toi di den man hinh Flutter so 3
    Then trang khong hien thi loi ket noi
    When toi di den man hinh Flutter so 4
    Then trang khong hien thi loi ket noi
    When toi di den man hinh Flutter so 5
    Then trang khong hien thi loi ket noi
    When toi di den man hinh Flutter so 6
    Then trang khong hien thi loi ket noi
    When toi di den man hinh Flutter so 7
    Then trang khong hien thi loi ket noi

  Scenario: Nhan vien them ban moi tren giao dien
    When toi dang nhap web Flutter "staff" voi tai khoan "staff" mat khau "123"
    And staff tao ban "Ban Auto Staff" so ghe "4" khu "Khu Auto"
    Then backend co ban "Ban Auto Staff"

  Scenario: Nhan vien goi mon cho ban tren giao dien
    When toi dang nhap web Flutter "staff" voi tai khoan "staff" mat khau "123"
    And staff goi mon co ma 1 cho ban 7
    Then backend co hoa don staff mo tai ban 7

  Scenario: Nhan vien thanh toan hoa don
    Given backend co hoa don mo cua staff tai ban 7
    When toi dang nhap web Flutter "staff" voi tai khoan "staff" mat khau "123"
    And staff thanh toan hoa don hien tai
    Then backend ghi nhan hoa don hien tai co trang thai "paid"

  Scenario: Nhan vien ghi no va thu no
    Given backend co hoa don mo cua staff tai ban 7
    When toi dang nhap web Flutter "staff" voi tai khoan "staff" mat khau "123"
    And staff ghi no hoa don hien tai cho khach "Auto Debt Guest"
    Then backend ghi nhan hoa don hien tai co trang thai "debt"
    Given backend co cong no cua khach "Auto Collect Guest"
    When staff thu het cong no hien tai
    Then backend ghi nhan cong no hien tai da "paid"

  Scenario: Nhan vien cham cong va xem thong bao
    When toi dang nhap web Flutter "staff" voi tai khoan "staff" mat khau "123"
    And staff cham cong vao ca va ra ca
    Then backend ghi nhan cham cong hien tai da ra ca
    And staff xem duoc thong bao noi bo
