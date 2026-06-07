Feature: Bang chung testcase fail
  Nam testcase nay dung de tao bang chung FAIL rieng khi can nop minh chung.
  Khong tinh vao bo 100 testcase chinh.

  Background:
    Given backend dang san sang
    And he thong du lieu demo duoc reset

  Scenario Outline: FAIL-<id> - <tieu_de>
    Given toi mo web "<web>"
    Then testcase fail minh hoa "FAIL-<id>" voi ly do "<ly_do>"

    Examples:
      | id  | web      | tieu_de                                      | ly_do                                                       |
      | 001 | customer | Sai ky vong login khach hang                 | Mong doi trang khach hang tu dang nhap khi chua nhap account |
      | 002 | customer | Sai ky vong danh sach mon                    | Mong doi mon khong ton tai xuat hien trong thuc don          |
      | 003 | staff    | Sai ky vong web nhan vien                    | Mong doi nhan vien vao dashboard khi chua dang nhap          |
      | 004 | admin    | Sai ky vong web admin                        | Mong doi admin vao man quan tri khi chua dang nhap           |
      | 005 | customer | Sai ky vong lich su thanh toan khach hang    | Mong doi lich su thanh toan hien khi chua dang nhap          |
