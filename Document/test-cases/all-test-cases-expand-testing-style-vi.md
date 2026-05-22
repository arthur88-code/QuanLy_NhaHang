# Restaurant Management System - Bo test case tieng Viet

Ban nay duoc sao chep tu file all-test-cases-expandtesting-style.md va chuyen sang tieng Viet de doc/de thi/cong viec QA.

Tai khoan dung trong test:

- Admin/nhan vien web va app: `admin / 123`, `staff / 123`, `accountant / 123`, `waiter03 / 123`.
- Web khach hang: `customer001 / 123` den `customer100 / 123`.

URL chinh:

- Web khach hang: `http://127.0.0.1:3000/customer/`
- Web nhan vien: `http://127.0.0.1:3000/staff/`
- Web admin: `http://127.0.0.1:3000/admin-web/`
- Backend API: `http://127.0.0.1:3000`

## Dang nhap va tai khoan - Test case tu dong

### Test Case 1: Admin login thanh cong voi mat khau 123

- **Ma test:** AUTH-001
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Login voi admin/123.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tong quan mo and admin-chi modules are hien thi.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 2: Nhan vien login thanh cong voi mat khau 123

- **Ma test:** AUTH-002
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Login voi nhan vien/123.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tong quan mo and nhan vien co the operate ban, thuc don, hoa don, cham cong.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 3: Accountant login thanh cong voi mat khau 123

- **Ma test:** AUTH-003
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Login voi accountant/123.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Cham cong and tinh luong-related data co the duoc accessed according to nhan vien permissions.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 4: Khach hang login thanh cong voi mat khau 123

- **Ma test:** AUTH-004
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Login on khach hang web voi customer001/123.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang workspace mo voi thuc don, ban, dat ban and lich su.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 5: Wrong mat khau is bi tu choi

- **Ma test:** AUTH-005
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Submit a valid ten dang nhap voi an invalid mat khau.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Login remains on the form and hien thi an loi.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 6: Unknown ten dang nhap is bi tu choi

- **Ma test:** AUTH-006
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Submit a ten dang nhap that khong exist.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- System tra ve a xoa het authentication loi.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 7: Empty ten dang nhap is bi tu choi

- **Ma test:** AUTH-007
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Leave ten dang nhap empty and submit.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- System khong tao a session.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 8: Empty mat khau is bi tu choi

- **Ma test:** AUTH-008
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Leave mat khau empty and submit.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- System khong tao a session.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 9: Mat khau khong returned in nhan vien login response

- **Ma test:** AUTH-009
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Call POST /auth/login.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Response contains user data khong co mat khau.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 10: Mat khau khong returned in khach hang login response

- **Ma test:** AUTH-010
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Call POST /auth/khach hang-login.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Response contains khach hang data khong co mat khau.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 11: Locked nhan vien tai khoan khong the login

- **Ma test:** AUTH-011
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Disable an nhan vien from admin and retry login.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Login that bai for that nhan vien tai khoan.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 12: Admin co the edit an nhan vien tai khoan ten dang nhap

- **Ma test:** AUTH-012
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. mo nhan vien management and doi ten dang nhap.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- New ten dang nhap works and old ten dang nhap no longer works.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 13: Admin co the reset nhan vien mat khau to 123

- **Ma test:** AUTH-013
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Edit nhan vien and set mat khau 123.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien co the login voi the reset mat khau.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 14: Nhan vien khong the see admin-chi navigation

- **Ma test:** AUTH-014
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Login as nhan vien.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien management, tinh luong admin and web admin tools are bi an.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 15: Admin sees admin-chi navigation

- **Ma test:** AUTH-015
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Login as admin.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien management, thong bao, tinh luong and web admin tools are hien thi.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 16: Session co the logout on khach hang web

- **Ma test:** AUTH-016
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Login khach hang then click logout.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang tra ve to the login man hinh.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 17: Khach hang local session reloads safely

- **Ma test:** AUTH-017
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Login khach hang and refresh page.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang session reloads from local storage and data is fetched again.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 18: Invalid stored khach hang session khong crash

- **Ma test:** AUTH-018
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. Put invalid session JSON in local storage and reload.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Login man hinh is shown or session is cleared safely.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 19: Web nhan vien path serves app

- **Ma test:** AUTH-019
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. mo /nhan vien/.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Flutter nhan vien/admin login page tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 20: Web admin path serves app

- **Ma test:** AUTH-020
- **Vi tri test:** Khach hang web / nhan vien web / admin web / Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo khach hang web / nhan vien web / admin web / Android app.
2. mo /admin-web/.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Flutter nhan vien/admin login page tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

## Web khach hang dat ban va goi mon - Test case tu dong

### Test Case 21: Khach hang sees trong ban

- **Ma test:** CUST-021
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Login as customer001 and mo ban area.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Trong, da dat and dang su dung ban are displayed voi correct colors.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 22: Khach hang reserves an trong ban

- **Ma test:** CUST-022
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Select an trong ban and submit dat ban.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Ban doi to da dat and dat ban xuat hien in lich su.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 23: Khach hang khong the reserve dang su dung ban

- **Ma test:** CUST-023
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Try selecting an dang su dung ban.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Dang su dung ban is disabled for khach hang.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 24: Khach hang khong the reserve another khach hang's da dat ban

- **Ma test:** CUST-024
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Try ordering on a da dat ban khong co matching dat ban.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- System blocks the action.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 25: Khach hang co the don goi mon on own da dat ban

- **Ma test:** CUST-025
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Reserve a ban, switch to don goi mon mode and submit cart.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon is created and ban doi to dang su dung.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 26: Khach hang don goi mon requires at least one thuc don item

- **Ma test:** CUST-026
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Submit don goi mon mode voi empty cart.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- System hien thi validation loi.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 27: Khach hang cart quantity increases

- **Ma test:** CUST-027
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Click Add item twice.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Cart quantity and tong tien increase correctly.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 28: Khach hang cart quantity decreases

- **Ma test:** CUST-028
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Click minus on a cart item.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Cart quantity and tong tien decrease correctly.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 29: Khach hang cart removes zero quantity item

- **Ma test:** CUST-029
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Reduce quantity to zero.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Item disappears from cart.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 30: Khach hang filters thuc don by danh muc

- **Ma test:** CUST-030
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Click a danh muc tab.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Chi matching danh muc items are shown.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 31: Khach hang refresh keeps server state

- **Ma test:** CUST-031
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. tao dat ban then refresh page.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Dat ban still exists from backend data.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 32: Khach hang web polls latest ban state

- **Ma test:** CUST-032
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. doi a ban from admin/nhan vien and wait or refresh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang web hien thi new ban state.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 33: Khach hang da tra lich su lists da tra hoa don

- **Ma test:** CUST-033
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. mo thanh toan lich su for customer001.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Da tra hoa don hien thi tong tien, paidAt and paidBy.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 34: Khach hang mo don goi mon xuat hien in don goi mon lich su

- **Ma test:** CUST-034
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Submit a web don goi mon and view lich su.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon xuat hien voi status mo.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 35: Da tra khach hang don goi mon moves to da tra lich su

- **Ma test:** CUST-035
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. admin pays a khach hang web don goi mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang web hien thi it under thanh toan lich su sau khi reload.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 36: Khach hang don goi mon is linked to khach hang tai khoan

- **Ma test:** CUST-036
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. tao don goi mon through khach hang web.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon has customerId, customerName and customerPhone.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 37: Khach hang dat ban is linked to khach hang tai khoan

- **Ma test:** CUST-037
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. tao dat ban through khach hang web.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Dat ban has customerId and khach hang phone.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 38: Khach hang co the add items to own mo don goi mon

- **Ma test:** CUST-038
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Submit don goi mon again on cung ban/khach hang.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Existing mo don goi mon receives more items.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 39: Khach hang khong the add to another khach hang mo don goi mon

- **Ma test:** CUST-039
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Use different khach hang for a ban voi mo don goi mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- System tra ve conflict.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 40: Khach hang note is saved on don goi mon

- **Ma test:** CUST-040
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Submit don goi mon voi note.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon note is stored in backend export.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 41: Dat ban note is saved

- **Ma test:** CUST-041
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Submit dat ban voi note.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Dat ban note xuat hien in lich su and backend export.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 42: Party size saves correctly

- **Ma test:** CUST-042
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Reserve ban voi party size 6.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Dat ban luu partySize=6.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 43: Dat ban default time is valid

- **Ma test:** CUST-043
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. mo page and inspect datetime truong.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Truong contains a future local datetime.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 44: Khach hang web handles API loi

- **Ma test:** CUST-044
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Stop backend then submit action.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- User sees a xoa het loi and page khong freeze.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 45: Khach hang web image fallback works

- **Ma test:** CUST-045
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Break an image URL and reload.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Bo cuc remains usable khong co broken text overlap.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 46: Khach hang web uses white black ocean palette

- **Ma test:** CUST-046
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. mo khach hang web and inspect main surfaces.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang web uses white background, black text and ocean blue primary actions.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 47: Khach hang top navigation jumps to every section

- **Ma test:** CUST-047
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Click Ban, Mon, Lich su and Da thanh toan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Page scrolls to the correct section khong co losing khach hang session.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 48: Khach hang ban status counters match cards

- **Ma test:** CUST-048
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Compare status strip so luong voi ban cards.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Trong, Da dat and Dang dung so luong match backend ban.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 49: Successful khach hang don goi mon clears cart

- **Ma test:** CUST-049
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Submit a khach hang don goi mon voi several items.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Cart becomes empty sau khi the server accepts the don goi mon.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 50: Khach hang khong the submit don goi mon khong co da chon ban

- **Ma test:** CUST-050
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. xoa het da chon ban state and submit don goi mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- System asks the khach hang to choose a ban and khong tao an don goi mon.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 51: Khach hang da dat ban label hien thi owner access

- **Ma test:** CUST-051
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. Reserve a ban then reload as the cung khach hang.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Own da dat ban remains selectable for ordering.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 52: Khach hang web desktop bo cuc has no overlap

- **Ma test:** CUST-052
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. mo khach hang web at 1440px width.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Ban, thuc don, cart, lich su and thanh toan sections fit khong co overlap.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 53: Khach hang web mobile bo cuc has no overlap

- **Ma test:** CUST-053
- **Vi tri test:** Http://127.0.0.1:3000/khach hang/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo http://127.0.0.1:3000/khach hang/.
2. mo khach hang web at 375px width.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Navigation, ban cards, thuc don cards and cart controls remain usable.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

## Luong ban an cua nhan vien va admin - Test case tu dong

### Test Case 54: Nhan vien sees tat ca 16 seeded ban

- **Ma test:** TABLE-054
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Login nhan vien and mo ban.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Sixteen ban are duoc liet ke sau khi reset.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 55: Ban cards hien thi three statuses

- **Ma test:** TABLE-055
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. mo ban sau khi reset.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Trong, da dat and dang su dung labels are hien thi.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 56: Nhan vien mo trong ban

- **Ma test:** TABLE-056
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Tap an trong ban.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon entry man hinh mo.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 57: Nhan vien don goi mon on trong ban doi status dang su dung

- **Ma test:** TABLE-057
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Add a thuc don item from don goi mon entry.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Ban becomes dang su dung and mo hoa don is created.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 58: Nhan vien-created don goi mon khong require khach hang tai khoan

- **Ma test:** TABLE-058
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. tao don goi mon from nhan vien app khong co khach hang fields.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon customerId is null or empty and don goi mon still works.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 59: Nhan vien co the add multiple thuc don items

- **Ma test:** TABLE-059
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Add three different thuc don items.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Hoa don contains tat ca da chon items.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 60: Nhan vien co the increase item quantity

- **Ma test:** TABLE-060
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Tap plus on an don goi mon item.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Quantity and tong tien increase.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 61: Nhan vien co the decrease item quantity

- **Ma test:** TABLE-061
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Tap minus on an don goi mon item.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Quantity and tong tien decrease.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 62: Quantity zero removes item

- **Ma test:** TABLE-062
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Decrease item to zero.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Item is removed from hoa don.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 63: One ban khong the have two mo hoa don

- **Ma test:** TABLE-063
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. tao don goi mon twice for cung ban.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- System tra ve existing mo don goi mon.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 64: Admin co the add ban

- **Ma test:** TABLE-064
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Long press/mo add ban form.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- New ban xuat hien and nextIds cap nhat.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 65: Admin co the edit ban

- **Ma test:** TABLE-065
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Edit name, seats and area.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Ban card hien thi updated values.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 66: Admin co the xoa trong ban

- **Ma test:** TABLE-066
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. xoa a ban voi no mo don goi mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Ban is removed.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 67: Khong the xoa ban voi mo don goi mon

- **Ma test:** TABLE-067
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Try deleting dang su dung ban voi mo don goi mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- API blocks voi conflict.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 68: Da dat ban remains da dat until don goi mon starts

- **Ma test:** TABLE-068
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. tao dat ban chi.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Ban status is da dat.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 69: Da dat ban doi dang su dung when khach hang don goi mon

- **Ma test:** TABLE-069
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. khach hang don goi mon on da dat ban.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Admin/nhan vien ban status hien thi dang su dung.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 70: Da tra hoa don tra ve ban trong

- **Ma test:** TABLE-070
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Pay an mo hoa don.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Ban status doi to trong.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 71: Cong no hoa don tra ve ban trong

- **Ma test:** TABLE-071
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Record cong no for an mo hoa don.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Ban status doi to trong and cong no is created.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 72: Ban refresh cap nhat cross-platform doi

- **Ma test:** TABLE-072
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. doi ban status on khach hang web and refresh nhan vien web.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien web displays the new status.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 73: Tong quan so luong ban statuses

- **Ma test:** TABLE-073
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. mo tong quan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Trong/da dat/dang su dung so luong match ban list.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 74: Selecting thuc don item khong tao hoa don immediately

- **Ma test:** TABLE-074
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. mo an trong ban and tap a thuc don item once.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Item xuat hien in tam da chon list and no hoa don is written until confirmation.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 75: Top xoa het nut removes tat ca da chon thuc don items

- **Ma test:** TABLE-075
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Select several thuc don items then click xoa het da chon list on top.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tam list becomes empty and don goi mon is unchanged.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 76: Huy da chon thuc don list stops current lua chon

- **Ma test:** TABLE-076
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Select items and click Huy bo.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tam da chon list is cleared khong co changing hoa don.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 77: Xac nhan da chon thuc don list tao lan goi mon one

- **Ma test:** TABLE-077
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Select items on an empty ban and xac nhan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Hoa don is created, ban becomes dang su dung and lan goi mon Lan 1 luu da chon items.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 78: Dang su dung ban co the receive additional lan goi mon

- **Ma test:** TABLE-078
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. mo an dang su dung ban voi mo hoa don, select more items and xac nhan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Existing hoa don receives lan goi mon Lan 2 and tong tien increases.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 79: Thu ba confirmation tao lan goi mon three

- **Ma test:** TABLE-079
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. xac nhan another da chon list on the cung mo hoa don.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Hoa don hien thi Lan 3 under previous cac lan goi mon.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 80: Hoa don tong tien sums tat ca cac lan goi mon

- **Ma test:** TABLE-080
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. tao at least two cac lan goi mon on one ban.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Hoa don tong tien equals the sum of every item in tat ca cac lan goi mon.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 81: Long press ban mo admin actions

- **Ma test:** TABLE-081
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Login admin and long press a ban card.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Action sheet hien thi add, edit and xoa choices.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 82: Nhan vien khong the xoa ban from action sheet

- **Ma test:** TABLE-082
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Login nhan vien and long press a ban card.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Xoa/admin-chi ban controls are not trong to nhan vien.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 83: Add ban form requires usable values

- **Ma test:** TABLE-083
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. mo add ban and submit empty name or invalid seats.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- No broken ban card is created.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 84: Edit ban preserves id and cap nhat hien thi fields

- **Ma test:** TABLE-084
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Edit a ban name, area and seats.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Cung ban id remains and card displays new chi tiet.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 85: Ban grid mobile card height is stable

- **Ma test:** TABLE-085
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. mo ban man hinh on Android/mobile width.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- No bottom tran giao dien stripe xuat hien under Goi mon buttons.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 86: Refresh ban list has no async setState loi

- **Ma test:** TABLE-086
- **Vi tri test:** Flutter app / /nhan vien/ / /admin-web/
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Flutter app / /nhan vien/ / /admin-web/.
2. Pull refresh or tap refresh on ban man hinh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- No setState callback returned a Future loi xuat hien.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

## Hoa don thanh toan cong no va lien ket khach hang - Test case tu dong

### Test Case 87: Admin sees seeded da tra hoa don

- **Ma test:** INV-087
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. mo hoa don sau khi reset.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- At least six da tra hoa don are ton tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 88: Admin sees seeded mo hoa don

- **Ma test:** INV-088
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. mo hoa don sau khi reset.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- At least two mo hoa don are ton tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 89: Admin sees seeded debts

- **Ma test:** INV-089
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. mo cong no man hinh sau khi reset.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Seeded cong no records are ton tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 90: Pay mo hoa don as admin

- **Ma test:** INV-090
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. POST /don goi mon/:id/pay voi role admin.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon status becomes da tra and paidBy is saved.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 91: Pay mo hoa don as nhan vien

- **Ma test:** INV-091
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. POST /don goi mon/:id/pay voi role nhan vien.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon status becomes da tra and paidBy is saved.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 92: Unknown role khong the pay hoa don

- **Ma test:** INV-092
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. POST /don goi mon/:id/pay voi role guest.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- API tra ve 403.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 93: Khong the pay already da tra hoa don

- **Ma test:** INV-093
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Pay the cung hoa don twice.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Thu hai attempt tra ve not mo loi.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 94: Thanh toan discount doi tong tien

- **Ma test:** INV-094
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Pay voi discount 10000.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon tong tien equals subtotal minus discount.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 95: Khach hang-web hoa don thanh toan xuat hien in khach hang da tra lich su

- **Ma test:** INV-095
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. tao khach hang don goi mon then pay it from admin.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Da tra don goi mon is returned by /khach hang-API/da tra-lich su.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 96: Nhan vien-created hoa don thanh toan khong appear in khach hang da tra lich su

- **Ma test:** INV-096
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. tao nhan vien don goi mon khong co customerId and pay.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- No khach hang da tra lich su receives the hoa don.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 97: Nhan vien co the manually enter cong no khach hang name

- **Ma test:** INV-097
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Record cong no voi customerName and phone.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Cong no luu entered khach hang info.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 98: Cong no amount equals don goi mon tong tien

- **Ma test:** INV-098
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Record cong no on an hoa don.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Cong no amount matches don goi mon tong tien sau khi discount.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 99: Cong no keeps don goi mon item chi tiet

- **Ma test:** INV-099
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. mo cong no-linked don goi mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon items remain intact.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 100: Hoa don list newest dau tien

- **Ma test:** INV-100
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Call GET /don goi mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Most recent don goi mon xuat hien dau tien.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 101: Bo loc mo don goi mon works

- **Ma test:** INV-101
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Call GET /don goi mon?status=mo.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Chi mo don goi mon are returned.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 102: Get mo don goi mon by ban works

- **Ma test:** INV-102
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Call /don goi mon/ban/:tableId/mo.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Mo don goi mon or null is returned correctly.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 103: Da tra don goi mon khong the receive new item

- **Ma test:** INV-103
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. POST item to da tra don goi mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- API rejects because hoa don khong mo.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 104: Invalid thuc don item is bi tu choi

- **Ma test:** INV-104
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Add item voi unknown menuItemId.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- API tra ve item unavailable/not found.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 105: Unavailable thuc don item is bi tu choi

- **Ma test:** INV-105
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Disable thuc don item and add it.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- API rejects unavailable item.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 106: Hoa don totals survive server restart

- **Ma test:** INV-106
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. tao hoa don then restart backend.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Hoa don tong tien is still correct from JSON data.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 107: Hoa don includes source customer_web

- **Ma test:** INV-107
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. tao don goi mon from khach hang web.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon source is customer_web.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 108: Hoa don includes source staff_app

- **Ma test:** INV-108
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. tao don goi mon from nhan vien/admin app.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon source is staff_app.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 109: Khach hang don goi mon luu phone

- **Ma test:** INV-109
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. tao khach hang don goi mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon customerPhone matches khach hang tai khoan.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 110: Thanh toan closes seated dat ban

- **Ma test:** INV-110
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. don goi mon from dat ban then pay.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Dat ban status becomes completed.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 111: Cong no closes seated dat ban

- **Ma test:** INV-111
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. don goi mon from dat ban then record cong no.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Dat ban status becomes completed.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 112: Hoa don bo loc tat ca tra ve every status

- **Ma test:** INV-112
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. mo hoa don and choose Tat ca.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Da tra, mo and cong no hoa don co the appear in the list.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 113: Hoa don bo loc da tra tra ve chi da tra

- **Ma test:** INV-113
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Choose Da tra bo loc.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Chi hoa don voi status da tra are duoc liet ke.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 114: Hoa don bo loc mo tra ve active ban

- **Ma test:** INV-114
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Choose Dang dung bo loc.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Chi mo hoa don for dang su dung ban are duoc liet ke.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 115: Clicking hoa don expands chi tiet

- **Ma test:** INV-115
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Click an hoa don card.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang info, nhan vien info, cac lan goi mon, items and tong tien are hien thi.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 116: Hoa don chi tiet hien thi lan goi mon labels

- **Ma test:** INV-116
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. mo an hoa don voi several confirmations.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Lan 1, Lan 2 and later cac lan goi mon are displayed separately.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 117: Hoa don thanh toan dialog huy keeps hoa don mo

- **Ma test:** INV-117
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. mo pay dialog then click Huy.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Hoa don status remains mo and ban remains dang su dung.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 118: Hoa don thanh toan blank discount is treated as zero

- **Ma test:** INV-118
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. mo pay dialog, leave discount blank and xac nhan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Thanh toan thanh cong voi no invalid tong tien.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 119: Hoa don cong no dialog huy keeps hoa don mo

- **Ma test:** INV-119
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. mo cong no dialog then click Huy.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Hoa don status remains mo and no cong no is created.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 120: Hoa don cong no tao cong no list record

- **Ma test:** INV-120
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Record cong no voi khach hang name, phone and note.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Cong no man hinh lists the new cong no linked to that don goi mon.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 121: Da tra hoa don hides pay and cong no actions

- **Ma test:** INV-121
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Expand a da tra hoa don.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Da tra and Ghi no buttons are not shown.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 122: Hoa don refresh has no async setState loi

- **Ma test:** INV-122
- **Vi tri test:** Don goi mon API / hoa don man hinh / khach hang lich su
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo don goi mon API / hoa don man hinh / khach hang lich su.
2. Tap hoa don refresh repeatedly.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- No setState callback returned a Future loi xuat hien.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

## Thuc don hinh anh va danh muc - Test case tu dong

### Test Case 123: Du lieu mau thuc don has at least 40 items

- **Ma test:** MENU-123
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. reset data and call GET /thuc don.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- At least 40 thuc don items exist.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 124: Du lieu mau thuc don has drinks

- **Ma test:** MENU-124
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. bo loc thuc don danh muc Do uong.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Drink items are ton tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 125: Du lieu mau thuc don has snacks

- **Ma test:** MENU-125
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. bo loc thuc don danh muc An vat.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Snack items are ton tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 126: Du lieu mau thuc don has main dishes

- **Ma test:** MENU-126
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. bo loc thuc don danh muc Mon chinh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Main dish items are ton tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 127: Du lieu mau thuc don has desserts

- **Ma test:** MENU-127
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. bo loc thuc don danh muc Trang mieng.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Dessert items are ton tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 128: Every thuc don item has imageUrl

- **Ma test:** MENU-128
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. Inspect GET /thuc don response.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Each item has a non-empty imageUrl.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 129: Food image URL uses item-specific query

- **Ma test:** MENU-129
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. Inspect seeded imageUrl.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Image query contains terms related to item name.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 130: Admin co the add thuc don item

- **Ma test:** MENU-130
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. tao new thuc don item.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Item xuat hien in thuc don list and khach hang web if trong.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 131: Admin co the edit thuc don price

- **Ma test:** MENU-131
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. cap nhat price of an item.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- New price xuat hien in app and web.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 132: Admin co the edit thuc don danh muc

- **Ma test:** MENU-132
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. cap nhat danh muc of an item.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Item moves to new danh muc tab.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 133: Admin co the hide thuc don item

- **Ma test:** MENU-133
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. Set trong=false.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Item khong appear in don goi mon entry/khach hang web.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 134: Admin co the re-enable thuc don item

- **Ma test:** MENU-134
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. Set trong=true.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Item xuat hien again.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 135: Xoa thuc don item removes it

- **Ma test:** MENU-135
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. xoa a thuc don item.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Item is absent from thuc don list.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 136: Invalid price is handled

- **Ma test:** MENU-136
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. Submit non-numeric price.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- System normalizes or rejects khong co crash.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 137: Thuc don image failure khong break bo cuc

- **Ma test:** MENU-137
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. Use a bad image URL.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Fallback/empty image area keeps bo cuc stable.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 138: Khach hang danh muc tabs include tat ca danh muc

- **Ma test:** MENU-138
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. mo khach hang web thuc don.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tabs match thuc don danh muc.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 139: Nhan vien don goi mon entry chi lists trong items

- **Ma test:** MENU-139
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. Disable an item then mo don goi mon entry.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Disabled item is bi an.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 140: Thuc don card text fits

- **Ma test:** MENU-140
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. Inspect long item name.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Text khong tran giao dien card.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 141: Thuc don tong tien uses latest price

- **Ma test:** MENU-141
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. cap nhat item price then add to don goi mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Don goi mon item price uses updated value.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 142: Thuc don so luong xuat hien on admin health

- **Ma test:** MENU-142
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. Call /admin/health.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- MenuItems equals thuc don array length.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 143: Thuc don dialog huy khong save doi

- **Ma test:** MENU-143
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. mo add/edit thuc don dialog then click Huy.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Thuc don list stays unchanged.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 144: Thuc don availability toggle persists sau khi refresh

- **Ma test:** MENU-144
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. Toggle an item bi an/hien thi then refresh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- The availability icon and API value remain updated.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 145: Thuc don image URL co the duoc edited

- **Ma test:** MENU-145
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. Edit imageUrl for one item.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien app and khach hang web tai the updated image URL.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 146: Thuc don list remains usable voi 50 plus items

- **Ma test:** MENU-146
- **Vi tri test:** Thuc don API / nhan vien app / khach hang web
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo thuc don API / nhan vien app / khach hang web.
2. mo thuc don sau khi seeded data tai.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Scrolling remains smooth and every item card is reachable.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

## Nhan vien cham cong va tinh luong - Test case tu dong

### Test Case 147: Du lieu mau has 12 nhan vien

- **Ma test:** EMP-147
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. reset and call /nhan vien.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Twelve nhan vien are returned.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 148: Each nhan vien has an tai khoan

- **Ma test:** EMP-148
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. Inspect /nhan vien response.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Each nhan vien has tai khoan ten dang nhap and role.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 149: Admin tao nhan vien and tai khoan

- **Ma test:** EMP-149
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. tao nhan vien from admin man hinh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien and login tai khoan are created.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 150: Admin edits nhan vien role

- **Ma test:** EMP-150
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. doi role truong.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Role cap nhat in list.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 151: Admin edits salary

- **Ma test:** EMP-151
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. doi salaryPerDay.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tinh luong uses new salary.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 152: Admin locks nhan vien

- **Ma test:** EMP-152
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. xoa/lock nhan vien.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien active=false and tai khoan khong the login.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 153: Ten dang nhap uniqueness is enforced

- **Ma test:** EMP-153
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. tao nhan vien voi existing ten dang nhap.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- System generates or rejects trung lap safely.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 154: Default new nhan vien mat khau is 123

- **Ma test:** EMP-154
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. tao nhan vien khong co mat khau.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien co the login voi 123.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 155: Du lieu mau cham cong spans multiple months

- **Ma test:** EMP-155
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. Inspect /cham cong and tinh luong for March-May.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Cham cong data exists across months.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 156: Cham cong workday is 10 hours

- **Ma test:** EMP-156
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. Inspect seeded checkIn/checkOut.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- 08:00-18:00 equals 10 hours.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 157: Tinh luong calculates March days

- **Ma test:** EMP-157
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. Call /tinh luong?month=2026-03.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Days and salary match cham cong rows.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 158: Tinh luong salary uses 300000 per day

- **Ma test:** EMP-158
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. Check nhan vien voi 21 days.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Salary equals 6,300,000 VND.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 159: Check-in tao row for today

- **Ma test:** EMP-159
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. POST /cham cong/check-in.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Row is created or existing row returned.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 160: Trung lap check-in khong trung lap day

- **Ma test:** EMP-160
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. Call check-in twice cung nhan vien/date.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Chi one row exists for that nhan vien/date.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 161: Check-out saves end time

- **Ma test:** EMP-161
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. PATCH /cham cong/:id/check-out.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- CheckOut becomes non-null.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 162: Cham cong list co the bo loc date

- **Ma test:** EMP-162
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. GET /cham cong?date=2026-03-03.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Rows for chi that date tra ve.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 163: Inactive nhan vien remains in historical tinh luong

- **Ma test:** EMP-163
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. Deactivate nhan vien voi past cham cong.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Historical rows still calculate khong co data loss.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 164: Nhan vien phone is editable

- **Ma test:** EMP-164
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. Edit phone.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- New phone xuat hien in nhan vien list.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 165: Tai khoan role co the doi to admin

- **Ma test:** EMP-165
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. Edit accountRole admin.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien co the login and see admin features.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 166: Tai khoan role co the doi back to nhan vien

- **Ma test:** EMP-166
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. Edit accountRole nhan vien.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien no longer sees admin-chi features.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 167: Nhan vien edit dialog huy khong save

- **Ma test:** EMP-167
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. mo nhan vien edit dialog and click Huy.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien chi tiet remain unchanged.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 168: Nhan vien xoa deactivates login tai khoan

- **Ma test:** EMP-168
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. xoa an nhan vien from admin.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien active=false and linked tai khoan khong the login.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 169: Cham cong refresh has no async setState loi

- **Ma test:** EMP-169
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. Refresh cham cong man hinh repeatedly.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- No setState callback returned a Future loi xuat hien.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 170: Tinh luong month picker accepts YYYY-MM

- **Ma test:** EMP-170
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. mo tinh luong month dialog and enter 2026-04.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tinh luong reloads for April 2026.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 171: Tinh luong invalid month khong crash UI

- **Ma test:** EMP-171
- **Vi tri test:** Nhan vien / cham cong / tinh luong
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo nhan vien / cham cong / tinh luong.
2. Enter an invalid month value.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Man hinh remains usable and hien thi safe empty/loi state.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

## Tong quan thong ke thong bao va quan tri - Test case tu dong

### Test Case 172: Tong quan hien thi ban so luong

- **Ma test:** ADM-172
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. mo tong quan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Ban so luong equals /ban length.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 173: Tong quan hien thi trong so luong

- **Ma test:** ADM-173
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. mo tong quan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Trong so luong equals ban voi trong status.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 174: Tong quan hien thi da dat so luong

- **Ma test:** ADM-174
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. mo tong quan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Da dat so luong equals ban voi da dat status.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 175: Tong quan hien thi dang su dung so luong

- **Ma test:** ADM-175
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. mo tong quan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Dang su dung so luong equals ban voi dang su dung status.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 176: Tong quan hien thi mo don goi mon

- **Ma test:** ADM-176
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. mo tong quan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Mo don goi mon so luong equals /don goi mon?status=mo.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 177: Tong quan hien thi khach hang so luong

- **Ma test:** ADM-177
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. mo tong quan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang so luong equals active khach hang.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 178: Doanh thu today includes chi da tra today

- **Ma test:** ADM-178
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. Pay an hoa don today then mo tong quan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Doanh thu today increases by hoa don tong tien.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 179: Thong ke month doanh thu works

- **Ma test:** ADM-179
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. Call /thong ke?period=month.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Chi da tra don goi mon in month are included.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 180: Thong ke top items works

- **Ma test:** ADM-180
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. Call thong ke sau khi da tra don goi mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Top items include quantity and doanh thu.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 181: Cong no mo amount works

- **Ma test:** ADM-181
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. tao cong no and mo tong quan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Mo cong no amount increases.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 182: Admin health so luong data

- **Ma test:** ADM-182
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. Call /admin/health.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- So luong match exported arrays.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 183: Admin export tra ve JSON

- **Ma test:** ADM-183
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. Call /admin/export.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Export includes users, nhan vien, khach hang, ban, thuc don and don goi mon.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 184: Reset restores du lieu mau data

- **Ma test:** ADM-184
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. POST /admin/reset.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- So luong tra ve to du lieu mau values.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 185: Thong bao list hien thi latest

- **Ma test:** ADM-185
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. mo tong quan.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Latest thong bao are hien thi.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 186: Admin tao thong bao

- **Ma test:** ADM-186
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. tao thong bao from admin man hinh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien co the see new thong bao.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 187: Thong bao audience tat ca is hien thi to tat ca roles

- **Ma test:** ADM-187
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. tao audience tat ca.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Admin and nhan vien both see it.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 188: Thong bao audience nhan vien is hien thi to nhan vien

- **Ma test:** ADM-188
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. tao audience nhan vien.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien sees it in thong bao.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 189: Admin web checklist displays

- **Ma test:** ADM-189
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. mo web admin man hinh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Operational checklist xuat hien.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 190: Admin export preview scrolls

- **Ma test:** ADM-190
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. mo web admin man hinh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Large JSON preview is selectable and constrained.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 191: Thong ke khong so luong cong no as da tra doanh thu

- **Ma test:** ADM-191
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. tao cong no don goi mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Doanh thu khong include cong no don goi mon as da tra doanh thu.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 192: Thong ke co the switch to another day

- **Ma test:** ADM-192
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. mo thong ke and move to previous day.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Metrics reload for the da chon day.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 193: Thong ke co the switch to another month

- **Ma test:** ADM-193
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. Choose month mode and move previous/next.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Metrics reload for the da chon month.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 194: Thong ke co the switch to another year

- **Ma test:** ADM-194
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. Choose year mode and move previous/next.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Metrics reload for the da chon year.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 195: Thong ke date picker doi anchor date

- **Ma test:** ADM-195
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. Use the calendar nut to choose a date.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Thong ke API is called voi the da chon date.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 196: Thong bao xoa removes item

- **Ma test:** ADM-196
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. xoa a thong bao as admin.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Thong bao no longer xuat hien sau khi refresh.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 197: Thong bao form huy khong tao item

- **Ma test:** ADM-197
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. mo thong bao form then huy.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Thong bao so luong stays unchanged.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 198: Tong quan refresh has no async setState loi

- **Ma test:** ADM-198
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. Refresh tong quan repeatedly.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tong quan reloads khong co Future setState overlay.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 199: Web admin export so luong matches tong quan

- **Ma test:** ADM-199
- **Vi tri test:** Tong quan / thong ke / thong bao / admin export
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo tong quan / thong ke / thong bao / admin export.
2. mo web admin export and compare so luong.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Export so luong match tong quan and health endpoints.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

## Lien ket da nen tang va trien khai - Test case tu dong

### Test Case 200: Khach hang dat ban xuat hien in nhan vien web

- **Ma test:** E2E-200
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. Reserve from khach hang web then mo /nhan vien/.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien ban list hien thi da dat.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 201: Khach hang don goi mon xuat hien in admin hoa don

- **Ma test:** E2E-201
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. don goi mon from khach hang web then mo /admin-web/ hoa don.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Mo hoa don xuat hien.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 202: Admin thanh toan cap nhat khach hang web lich su

- **Ma test:** E2E-202
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. Pay khach hang don goi mon from admin web.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang thanh toan lich su hien thi da tra hoa don.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 203: Nhan vien thanh toan cap nhat khach hang web lich su

- **Ma test:** E2E-203
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. Pay khach hang don goi mon from nhan vien app.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang thanh toan lich su hien thi da tra hoa don.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 204: Android app co the use cung backend as web

- **Ma test:** E2E-204
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. build app voi proper API_BASE_URL or adb reverse.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- App reads the cung ban/don goi mon as web.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 205: Nhan vien web and admin web share backend data

- **Ma test:** E2E-205
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. tao ban in admin web and view nhan vien web.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- New ban xuat hien sau khi refresh.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 206: Khach hang web and nhan vien web use cung ban statuses

- **Ma test:** E2E-206
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. doi status via khach hang flow.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien/admin see cung status.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 207: Backend restart keeps JSON data

- **Ma test:** E2E-207
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. tao data then restart backend.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Data persists from restaurant.JSON.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 208: Flutter web build is served from backend

- **Ma test:** E2E-208
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. mo /nhan vien/ sau khi flutter build web.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Web app tai from backend server.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 209: Admin web path is independent from khach hang web

- **Ma test:** E2E-209
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. mo /admin-web/ and /khach hang/ in two tabs.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Both apps tai different UIs.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 210: Khach hang web white black ocean theme tai

- **Ma test:** E2E-210
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. mo /khach hang/.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Palette is white, black and ocean blue voi readable contrast.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 211: No text overlap on khach hang mobile viewport

- **Ma test:** E2E-211
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. Resize khach hang web to mobile width.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Buttons, cards and lich su rows khong overlap.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 212: No text overlap on nhan vien web mobile viewport

- **Ma test:** E2E-212
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. Resize /nhan vien/ to mobile width.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Flutter bo cuc remains usable.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 213: Khach hang thanh toan lich su excludes unpaid don goi mon

- **Ma test:** E2E-213
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. tao mo don goi mon and inspect thanh toan list.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Mo don goi mon khong appear in da tra lich su.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 214: Khach hang thanh toan lich su includes chi linked khach hang don goi mon

- **Ma test:** E2E-214
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. Pay nhan vien-created don goi mon khong co customerId.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang da tra lich su is unchanged.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 215: API bootstrap is complete

- **Ma test:** E2E-215
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. Call /khach hang-API/bootstrap.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Response includes settings, khach hang, ban, thuc don, dat ban, don goi mon and paidOrders.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 216: LAN deployment co the use explicit API_BASE_URL

- **Ma test:** E2E-216
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. build app voi LAN IP.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Installed app connects to backend on cung network.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 217: Emulator deployment uses fallback 10.0.2.2

- **Ma test:** E2E-217
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. chay app on Android emulator khong co dart-define.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- App tries backend at 10.0.2.2:3000.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 218: USB deployment works voi adb reverse

- **Ma test:** E2E-218
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. chay adb reverse tcp:3000 tcp:3000.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Installed debug app co the reach localhost backend.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 219: Khach hang web works khong co separate frontend server

- **Ma test:** E2E-219
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. chay chi backend and mo /khach hang/.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang web tai and calls cung backend.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 220: Nhan vien/admin web works khong co separate frontend server sau khi build

- **Ma test:** E2E-220
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. chay backend and mo /nhan vien/.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Flutter web tai from backend build output.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 221: Reset then tat ca three clients read du lieu mau data

- **Ma test:** E2E-221
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. POST /reset then refresh khach hang/nhan vien/admin.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tat ca clients hien thi du lieu mau so luong and statuses.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 222: Concurrent khach hang and nhan vien action stays consistent

- **Ma test:** E2E-222
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. khach hang don goi mon while nhan vien views ban.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Chi one mo don goi mon exists and status is dang su dung.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 223: Da tra ban becomes trong everywhere

- **Ma test:** E2E-223
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. Pay any mo don goi mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang/nhan vien/admin tat ca hien thi ban trong sau khi refresh.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 224: Health endpoint stays ok sau khi full scenario

- **Ma test:** E2E-224
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. chay dat ban, don goi mon, pay, nhan vien edit then call health.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Health status remains ok.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 225: Android Studio co the chay the app

- **Ma test:** E2E-225
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. mo frontend/Android in Android Studio and chay the debug configuration.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- App launches and connects to backend when API URL is reachable.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 226: Android Studio emulator uses backend fallback

- **Ma test:** E2E-226
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. chay app from Android Studio on emulator voi backend dang chay locally.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- App co the reach backend through emulator fallback or explicit dart define.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 227: Android Studio physical device uses LAN or adb reverse

- **Ma test:** E2E-227
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. chay app from Android Studio on a phone.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- App connects when adb reverse is active or API_BASE_URL uses the computer LAN IP.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 228: Khach hang web action doi Android app ban man hinh

- **Ma test:** E2E-228
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. Reserve/don goi mon from khach hang web then refresh Android ban man hinh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Android app hien thi da dat or dang su dung status from the cung backend.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 229: Android thanh toan doi khach hang web thanh toan lich su

- **Ma test:** E2E-229
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. Pay a khach hang-linked don goi mon from Android app.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang web thanh toan lich su includes the da tra hoa don.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 230: Nhan vien web don goi mon doi Android hoa don list

- **Ma test:** E2E-230
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. tao a nhan vien web don goi mon then mo Android hoa don.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Android app lists the cung mo hoa don.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 231: Admin web nhan vien doi affects Android login

- **Ma test:** E2E-231
- **Vi tri test:** Backend + khach hang web + nhan vien web + Android app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo backend + khach hang web + nhan vien web + Android app.
2. doi nhan vien tai khoan in admin web then login on Android.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Android login uses the updated tai khoan data.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

## Hoi quy sau tren Android app - Test case tu dong

### Test Case 232: Android app launches to login man hinh

- **Ma test:** APP-232
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Install debug APK and mo app.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Login man hinh hien thi logo, app name, ten dang nhap, mat khau and login nut.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 233: Android admin login reaches tong quan

- **Ma test:** APP-233
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Login on emulator voi admin/123.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tong quan tai khong co connection loi.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 234: Android nhan vien login reaches tong quan

- **Ma test:** APP-234
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Login on emulator voi nhan vien/123.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien tong quan tai and admin-chi modules are bi an.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 235: Android khach hang tai khoan khong the login on nhan vien app

- **Ma test:** APP-235
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Try customer001/123 in Flutter app login.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Login is bi tu choi because khach hang tai khoan use khach hang web chi.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 236: Android drawer mo navigation

- **Ma test:** APP-236
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Tap hamburger thuc don.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Navigation drawer mo and every role-allowed man hinh is reachable.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 237: Android ban man hinh has no tran giao dien

- **Ma test:** APP-237
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo Quan ly ban on emulator.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- No yellow/black tran giao dien stripe xuat hien on ban cards.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 238: Android hoa don refresh has no setState Future loi

- **Ma test:** APP-238
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo Hoa don and tap refresh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- No snackbar/loi overlay says setState callback returned a Future.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 239: Android cham cong refresh has no setState Future loi

- **Ma test:** APP-239
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo Cham cong and refresh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- No setState Future loi is shown.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 240: Android ban refresh has no setState Future loi

- **Ma test:** APP-240
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo Ban and refresh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- No setState Future loi is shown.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 241: Android don goi mon entry tam lua chon works

- **Ma test:** APP-241
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo ban and tap thuc don item.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Da chon item xuat hien in tam list; hoa don is unchanged truoc khi xac nhan.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 242: Android don goi mon entry xoa het da chon list works

- **Ma test:** APP-242
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Select several items and tap top xoa het nut.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tam list becomes empty.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 243: Android don goi mon entry huy works

- **Ma test:** APP-243
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Select items and tap Huy bo.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tam list clears and ban/don goi mon data stays unchanged.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 244: Android don goi mon entry xac nhan tao lan goi mon

- **Ma test:** APP-244
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Select items then tap Xac nhan chon mon.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Hoa don hien thi Lan 1 and ban becomes dang su dung.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 245: Android dang su dung ban co the add thu hai lan goi mon

- **Ma test:** APP-245
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo the dang su dung ban and xac nhan more items.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Hoa don hien thi Lan 2.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 246: Android hoa don chi tiet expand

- **Ma test:** APP-246
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo Hoa don and tap an hoa don.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Hoa don chi tiet hien thi cac lan goi mon, items and tong tien.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 247: Android hoa don bo loc tat ca works

- **Ma test:** APP-247
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Tap Tat ca on hoa don man hinh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tat ca hoa don statuses are duoc liet ke.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 248: Android hoa don bo loc da tra works

- **Ma test:** APP-248
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Tap Da tra.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Chi da tra hoa don are duoc liet ke.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 249: Android hoa don bo loc active works

- **Ma test:** APP-249
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Tap Dang dung.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Chi mo active hoa don are duoc liet ke.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 250: Android thanh toan tra ve ban trong

- **Ma test:** APP-250
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Pay an mo hoa don from app.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Hoa don is da tra and related ban becomes trong sau khi refresh.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 251: Android cong no flow tra ve ban trong

- **Ma test:** APP-251
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Record cong no for an mo hoa don.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Cong no is created and ban becomes trong.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 252: Android thong ke day selector works

- **Ma test:** APP-252
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo thong ke and choose day mode.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Day metrics tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 253: Android thong ke month selector works

- **Ma test:** APP-253
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo thong ke and choose month mode.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Month metrics tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 254: Android thong ke year selector works

- **Ma test:** APP-254
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo thong ke and choose year mode.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Year metrics tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 255: Android thong ke previous and next buttons work

- **Ma test:** APP-255
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Tap Truoc and Sau on thong ke.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Anchor date doi and metrics reload.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 256: Android date picker doi thong ke

- **Ma test:** APP-256
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo thong ke date picker and choose a date.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Thong ke reload for da chon date.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 257: Android nhan vien tai khoan management mo

- **Ma test:** APP-257
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Login admin and mo Nhan vien.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien list hien thi tai khoan ten dang nhap and role.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 258: Android nhan vien tai khoan edit saves

- **Ma test:** APP-258
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Edit an nhan vien tai khoan truong.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien/tai khoan data is saved sau khi refresh.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 259: Android check-in tao cham cong

- **Ma test:** APP-259
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo Cham cong and tap Vao ca.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Cham cong row xuat hien for da chon nhan vien.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 260: Android check-out completes cham cong

- **Ma test:** APP-260
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Tap Ra ca on an mo cham cong row.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Row doi to completed state.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 261: Android app survives backend outage

- **Ma test:** APP-261
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Stop backend and refresh a man hinh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- App hien thi connection loi and khong crash.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 262: Android thuc don man hinh mo and scrolls

- **Ma test:** APP-262
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo Quan ly mon an on emulator.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Thuc don list voi images scrolls khong co bo cuc tran giao dien.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 263: Android cong no man hinh mo and co the collect cong no

- **Ma test:** APP-263
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo Cong no and tap Thu du on an mo cong no.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Cong no becomes da tra or completed sau khi refresh.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 264: Android tinh luong man hinh mo month picker

- **Ma test:** APP-264
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo tinh luong and tap month nut.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Month dialog mo and reloads da chon month.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 265: Android thong bao man hinh mo

- **Ma test:** APP-265
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo thong bao from drawer.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Thong bao list renders and co the refresh.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 266: Android nhan vien man hinh is admin-chi

- **Ma test:** APP-266
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. Login nhan vien and inspect drawer.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien management man hinh is bi an from nhan vien role.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 267: Android drawer text fits narrow width

- **Ma test:** APP-267
- **Vi tri test:** Android emulator / Android Studio / Flutter app
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Android emulator / Android Studio / Flutter app.
2. mo drawer on emulator.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Navigation labels fit khong co clipping or tran giao dien.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

## Project test tu dong Visual Studio - Test case tu dong

### Test Case 268: Solution mo in Visual Studio 2022

- **Ma test:** VS-268
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. mo tests/RestaurantManagement.Tests.sln.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Solution tai khong co thieu project errors.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 269: Test Explorer discovers API tests

- **Ma test:** VS-269
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. mo Test Explorer sau khi build.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- API smoke tests are duoc liet ke.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 270: Test Explorer discovers web tests

- **Ma test:** VS-270
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. mo Test Explorer sau khi build.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Web Playwright tests are duoc liet ke.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 271: Test Explorer discovers Android test

- **Ma test:** VS-271
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. mo Test Explorer sau khi build.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Android Appium launch test is duoc liet ke.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 272: Runsettings file co the duoc da chon

- **Ma test:** VS-272
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. Select tests/local.runsettings.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Environment variables are trong to tests.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 273: API test danh muc co the chay alone

- **Ma test:** VS-273
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. chay bo loc TestCategory!=web&TestCategory!=Android.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Chi API tests chay and pass when backend is dang chay.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 274: Web test danh muc co the chay alone

- **Ma test:** VS-274
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. chay bo loc TestCategory=web.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Chi Playwright web tests chay.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 275: Android test is skipped by default

- **Ma test:** VS-275
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. chay tat ca tests voi RMS_RUN_ANDROID=0.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Android test is inconclusive/skipped instead of failing because Appium khong enabled.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 276: Android test co the duoc enabled

- **Ma test:** VS-276
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. Set RMS_RUN_ANDROID=1 and start Appium.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Android Appium smoke test attempts to launch APK.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 277: Playwright browsers install command works

- **Ma test:** VS-277
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. chay playwright.ps1 install sau khi dotnet build.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Browser binaries are installed for Playwright tests.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 278: C# test project uses MSTest

- **Ma test:** VS-278
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. Inspect csproj packages.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- MSTest package and test adapter are ton tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 279: C# test project uses Playwright

- **Ma test:** VS-279
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. Inspect csproj packages.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Microsoft.Playwright.MSTest is ton tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 280: C# test project uses Appium

- **Ma test:** VS-280
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. Inspect csproj packages.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Appium.WebDriver is ton tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 281: Generated catalog test file compiles

- **Ma test:** VS-281
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. build solution sau khi generating tat ca catalog tests.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tat ca generated test case methods bien dich.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 282: Generated catalog so luong matches Markdown

- **Ma test:** VS-282
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. Compare Test Explorer catalog so luong voi Markdown so luong.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Every documented test case has a matching catalog test method.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 283: Automated smoke tests are separated from catalog tests

- **Ma test:** VS-283
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. chay automated danh muc filters.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Manual/catalog tests khong block automated smoke runs.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 284: Backend URL co the duoc overridden

- **Ma test:** VS-284
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. Set RMS_BACKEND_URL to another host.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tests use the configured backend URL.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 285: Khach hang URL co the duoc overridden

- **Ma test:** VS-285
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. Set RMS_CUSTOMER_WEB_URL.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang web tests use that URL.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 286: Nhan vien URL co the duoc overridden

- **Ma test:** VS-286
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. Set RMS_STAFF_WEB_URL.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien web tests use that URL.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 287: Admin URL co the duoc overridden

- **Ma test:** VS-287
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. Set RMS_ADMIN_WEB_URL.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Admin web tests use that URL.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 288: Generated catalog includes app scenarios

- **Ma test:** VS-288
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. Inspect GeneratedTestCaseCatalogTests.cs.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Android app scenario methods are ton tai voi TestCategory app.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 289: Generated catalog includes khach hang web scenarios

- **Ma test:** VS-289
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. Inspect GeneratedTestCaseCatalogTests.cs.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Khach hang web scenario methods are ton tai voi TestCategory CUST.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 290: Generated catalog includes nhan vien admin web scenarios

- **Ma test:** VS-290
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. Inspect GeneratedTestCaseCatalogTests.cs.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Nhan vien/admin web scenario methods are ton tai voi ban, INV and ADM danh muc.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 291: Generated catalog tests are ignored by default

- **Ma test:** VS-291
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. chay dotnet test automated filters.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Catalog/manual scenario methods khong fail the smoke automation chay.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 292: Runsettings keeps local URLs in one place

- **Ma test:** VS-292
- **Vi tri test:** Visual Studio 2022 / tests solution
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo Visual Studio 2022 / tests solution.
2. mo tests/local.runsettings.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Backend, khach hang, nhan vien, admin, Appium and Android flags are configured centrally.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

## Tai lieu du lieu va khoi phuc - Test case tu dong

### Test Case 293: README lists tat ca main URLs

- **Ma test:** DOC-293
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo README.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Backend, khach hang web, nhan vien web, admin web and Android app instructions are ton tai.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 294: README lists tat ca nhan vien tai khoan

- **Ma test:** DOC-294
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo tai khoan section.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Twelve nhan vien/admin usernames and mat khau 123 are documented.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 295: README lists khach hang tai khoan pattern

- **Ma test:** DOC-295
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo tai khoan section.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Customer001 den customer100 voi mat khau 123 are documented.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 296: README explains Android Studio chay

- **Ma test:** DOC-296
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo Android Studio section.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Emulator, USB reverse and LAN IP options are documented.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 297: README explains don goi mon lan goi mon behavior

- **Ma test:** DOC-297
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo business UI section.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tam lua chon, xac nhan, huy and Lan 1/Lan 2 behavior are documented.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 298: Markdown test cases exist

- **Ma test:** DOC-298
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo tat ca-test-cases-expandtesting-style.md.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Markdown file exists and contains tat ca test cases.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 299: Vietnamese Markdown copy exists

- **Ma test:** DOC-299
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo tat ca-test-cases-expandtesting-style-vi.md.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Vietnamese Markdown copy exists.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 300: Word test cases exist

- **Ma test:** DOC-300
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo tat ca-test-cases-expandtesting-style.docx.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Word document exists.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 301: Excel test cases exist

- **Ma test:** DOC-301
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo tat ca-test-cases-expandtesting-style.xlsx.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Excel workbook exists.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 302: Vietnamese Word test cases exist

- **Ma test:** DOC-302
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo tat ca-test-cases-expandtesting-style-vi.docx.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Vietnamese Word document exists.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 303: Vietnamese Excel test cases exist

- **Ma test:** DOC-303
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo tat ca-test-cases-expandtesting-style-vi.xlsx.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Vietnamese Excel workbook exists.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 304: Test case IDs are unique

- **Ma test:** DOC-304
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. Parse tat ca Markdown test case IDs.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- No trung lap Test ID exists.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 305: Test case numbering is continuous

- **Ma test:** DOC-305
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. Parse Test Case numbers.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Numbers start at 1 and increase khong co gaps.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 306: Office export so luong matches Markdown

- **Ma test:** DOC-306
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. Compare generated docx/xlsx so luong voi Markdown so luong.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tat ca formats have the cung test case so luong.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 307: Visual Studio generated test so luong matches Markdown

- **Ma test:** DOC-307
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. Compare generated C# catalog methods voi Markdown so luong.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- No documented test case is thieu from Visual Studio tests.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 308: Reset restores du lieu mau so luong

- **Ma test:** DOC-308
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. POST /reset then call /admin/health.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Du lieu mau so luong tra ve to expected values.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 309: Restaurant JSON khong committed

- **Ma test:** DOC-309
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. Inspect git status and .gitignore.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Backend/data/restaurant.JSON remains ignored.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 310: Build folders are not committed

- **Ma test:** DOC-310
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. Inspect .gitignore.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Frontend/build and test bin/obj folders are ignored.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 311: Tools folder remains ignored if desired

- **Ma test:** DOC-311
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. Inspect .gitignore.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Tools/ is ignored and will not be re-added accidentally.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 312: Backend logs are ignored

- **Ma test:** DOC-312
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. Inspect .gitignore.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Backend/logs is ignored.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 313: Project co the recover sau khi deleting data JSON

- **Ma test:** DOC-313
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. xoa restaurant.JSON and start backend.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Luu recreates du lieu mau data.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 314: Project co the recover sau khi reset during mo clients

- **Ma test:** DOC-314
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. chay /reset while clients are mo then refresh.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Clients reload du lieu mau data cleanly.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 315: Test documentation generation is repeatable

- **Ma test:** DOC-315
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. chay node tools/generate_markdown_test_cases.js twice.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Output so luong and IDs remain stable.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 316: Office export generation is repeatable

- **Ma test:** DOC-316
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. chay python tools/export_test_cases_office.py twice.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Docx/xlsx output so luong remains stable.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 317: Visual Studio catalog generation is repeatable

- **Ma test:** DOC-317
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. chay python tools/generate_vs_test_catalog.py twice.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Generated C# compiles and so luong remains stable.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 318: Dash-name Markdown alias exists

- **Ma test:** DOC-318
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo tat ca-test-cases-expand-testing-style.md.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Dash-name copy exists for the requested file name.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 319: Dash-name Vietnamese Markdown alias exists

- **Ma test:** DOC-319
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo tat ca-test-cases-expand-testing-style-vi.md.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Dash-name Vietnamese copy exists and matches case so luong.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 320: Vietnamese document so luong matches English

- **Ma test:** DOC-320
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. so luong Test Case headings in both Markdown files.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- English and Vietnamese versions contain the cung number of cases.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 321: Locked Excel export tao updated fallback

- **Ma test:** DOC-321
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. Keep the original Excel file mo and chay export.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- Script writes an updated fallback workbook instead of stopping.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

### Test Case 322: README documents Visual Studio test catalog

- **Ma test:** DOC-322
- **Vi tri test:** README / Document test cases / JSON du lieu mau data
- **Dieu kien truoc:** Backend dang chay tai `http://127.0.0.1:3000`; du lieu demo da reset tru khi case noi khac.

**Cac buoc:**
1. mo README / Document test cases / JSON du lieu mau data.
2. mo README test section.
3. Refresh the related web/app man hinh or call the related API endpoint.
4. Compare UI state voi backend JSON/API response.

**Ket qua mong doi:**
- README explains generated catalog tests and automated smoke tests.
No crash, broken bo cuc, trung lap orphan record, or stale status remains.

**Trang thai:** Cho chay thu cong / tu dong hoa dan

Tong so test case: 322
