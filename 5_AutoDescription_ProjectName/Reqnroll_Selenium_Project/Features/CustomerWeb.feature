Feature: Customer web auto tests
  Reqnroll mo ta cac kich ban Selenium cho cong khach hang http://127.0.0.1:3000/customer/

  Background:
    Given backend dang san sang
    And he thong du lieu demo duoc reset

  Scenario: Khach hang dang nhap thanh cong va xem khu lam viec
    Given toi mo web "customer"
    When toi dang nhap khach hang voi tai khoan "customer001" mat khau "123"
    Then khong gian khach hang duoc hien thi
    And khach hang thay ban "Ban 7"
    And khach hang thay mon "Pho bo tai"

  Scenario: Khach hang dang nhap sai mat khau
    Given toi mo web "customer"
    When toi dang nhap khach hang voi tai khoan "customer001" mat khau "wrong-password"
    Then loi dang nhap khach hang hien "Sai tai khoan khach hang hoac mat khau"
    And trinh duyet dang o giao dien dang nhap khach hang

  Scenario: Khach hang loc danh muc thuc don de tim do uong
    Given toi mo web "customer"
    When toi dang nhap khach hang voi tai khoan "customer001" mat khau "123"
    Then khong gian khach hang duoc hien thi
    When toi loc danh muc khach hang "Do uong"
    Then luoi mon khach hang hien "Tra dao cam sa" va khong hien "Pho bo tai"

  Scenario: Khach hang dat ban va backend cap nhat trang thai
    Given toi mo web "customer"
    When toi dang nhap khach hang voi tai khoan "customer001" mat khau "123"
    Then khong gian khach hang duoc hien thi
    When toi chon ban co ma 7
    And toi chuyen sang che do dat ban
    And toi nhap so khach "3" va ghi chu "auto reserve from reqnroll"
    And toi gui yeu cau khach hang
    Then thong bao thao tac khach hang hien "Da dat ban"
    And backend ghi nhan ban 7 co trang thai "reserved"

  Scenario: Khach hang them mon va gui hoa don mo
    Given toi mo web "customer"
    When toi dang nhap khach hang voi tai khoan "customer001" mat khau "123"
    Then khong gian khach hang duoc hien thi
    When toi chon ban co ma 7
    And toi them mon co ma 1 vao gio
    And toi them mon co ma 36 vao gio
    Then gio hang khach hang co "2" mon
    When toi gui yeu cau khach hang
    Then thong bao thao tac khach hang hien "Da gui mon"
    And backend co hoa don mo cua khach hang 1 tai ban 7 voi 2 dong mon

  Scenario: Khach hang xem lich su thanh toan sau khi admin xac nhan
    Given toi mo web "customer"
    When toi dang nhap khach hang voi tai khoan "customer001" mat khau "123"
    Then khong gian khach hang duoc hien thi
    When toi chon ban co ma 7
    And toi them mon co ma 1 vao gio
    And toi gui yeu cau khach hang
    Then thong bao thao tac khach hang hien "Da gui mon"
    And backend co hoa don mo cua khach hang 1 tai ban 7 voi 1 dong mon
    When admin thanh toan hoa don mo cua khach hang 1 tai ban 7
    Then khach hang thay hoa don vua thanh toan
    And backend ghi nhan ban 7 co trang thai "available"

  Scenario: Khach hang reload responsive va dang xuat
    Given toi mo web "customer"
    When toi dang nhap khach hang voi tai khoan "customer001" mat khau "123"
    Then khong gian khach hang duoc hien thi
    When toi doi viewport khach hang thanh 390 x 844 va tai lai
    Then khong gian khach hang duoc hien thi
    When toi dang xuat khach hang
    Then trinh duyet dang o giao dien dang nhap khach hang
    And session khach hang duoc xoa
