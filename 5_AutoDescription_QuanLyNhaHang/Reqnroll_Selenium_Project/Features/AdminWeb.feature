Feature: Admin web auto tests
  Reqnroll mo ta cac kich ban Selenium cho cong admin http://127.0.0.1:3000/admin-web/

  Background:
    Given backend dang san sang
    And he thong du lieu demo duoc reset

  Scenario: Admin dang nhap va duyet tat ca man hinh
    When toi dang nhap web Flutter "admin" voi tai khoan "admin" mat khau "123"
    Then ung dung Flutter da dang nhap thanh cong
    When admin duyet tat ca man hinh chinh
    Then trang khong hien thi loi ket noi

  Scenario: Admin tao sua an va xoa mon an
    When toi dang nhap web Flutter "admin" voi tai khoan "admin" mat khau "123"
    And admin tao mon "Auto Admin Dish"
    Then backend co mon "Auto Admin Dish"
    When admin sua mon hien tai thanh "Auto Admin Dish Updated"
    Then backend ghi nhan mon hien tai ten "Auto Admin Dish Updated"
    When admin an mon hien tai
    Then backend ghi nhan mon hien tai bi an
    When admin xoa mon hien tai
    Then backend khong con mon hien tai

  Scenario: Admin tao sua va khoa tai khoan nhan vien
    When toi dang nhap web Flutter "admin" voi tai khoan "admin" mat khau "123"
    And admin tao nhan vien "Auto Employee" tai khoan "autoemployee"
    Then backend co nhan vien "Auto Employee"
    When admin sua nhan vien hien tai thanh "Auto Employee Updated" tai khoan "autoemployee2"
    Then backend ghi nhan nhan vien hien tai ten "Auto Employee Updated"
    When admin khoa nhan vien hien tai
    Then backend ghi nhan nhan vien hien tai bi khoa

  Scenario: Admin tao va xoa thong bao
    When toi dang nhap web Flutter "admin" voi tai khoan "admin" mat khau "123"
    And admin tao thong bao "Auto Notice" noi dung "Thong bao tu Selenium Reqnroll"
    Then backend co thong bao "Auto Notice"
    When admin xoa thong bao hien tai
    Then backend khong con thong bao hien tai

  Scenario: Admin xem bang luong va reset demo
    Given backend co them ban tam "Ban Before Auto Reset"
    When toi dang nhap web Flutter "admin" voi tai khoan "admin" mat khau "123"
    And admin xem bang luong thang "2026-05"
    Then backend tra ve bang luong thang hien tai
    When admin reset du lieu demo tren web
    Then backend duoc reset ve 16 ban
