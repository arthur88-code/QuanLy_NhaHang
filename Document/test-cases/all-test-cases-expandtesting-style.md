# Restaurant Management System - ExpandTesting Style Test Cases

Generated: 22/05/2026

Format note: this file follows the same simple reading style as ExpandTesting practice test case pages: section title, `### Test Case n`, numbered steps, and expected result.

Accounts used by the cases:

- Admin/staff web and app: `admin / 123`, `staff / 123`, `accountant / 123`, `waiter03 / 123`.
- Customer web: `customer001 / 123` through `customer100 / 123`.

Main URLs:

- Customer web: `http://127.0.0.1:3000/customer/`
- Staff web: `http://127.0.0.1:3000/staff/`
- Admin web: `http://127.0.0.1:3000/admin-web/`
- Backend API: `http://127.0.0.1:3000`

## Authentication And Accounts Automation Test Cases

### Test Case 1: Admin login succeeds with password 123

- **Test ID:** AUTH-001
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Login with admin/123.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Dashboard opens and admin-only modules are visible.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 2: Staff login succeeds with password 123

- **Test ID:** AUTH-002
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Login with staff/123.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Dashboard opens and staff can operate tables, menu, invoices, attendance.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 3: Accountant login succeeds with password 123

- **Test ID:** AUTH-003
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Login with accountant/123.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Attendance and payroll-related data can be accessed according to staff permissions.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 4: Customer login succeeds with password 123

- **Test ID:** AUTH-004
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Login on customer web with customer001/123.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer workspace opens with menu, tables, reservations and history.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 5: Wrong password is rejected

- **Test ID:** AUTH-005
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Submit a valid username with an invalid password.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Login remains on the form and shows an error.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 6: Unknown username is rejected

- **Test ID:** AUTH-006
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Submit a username that does not exist.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- System returns a clear authentication error.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 7: Empty username is rejected

- **Test ID:** AUTH-007
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Leave username empty and submit.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- System does not create a session.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 8: Empty password is rejected

- **Test ID:** AUTH-008
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Leave password empty and submit.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- System does not create a session.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 9: Password is not returned in employee login response

- **Test ID:** AUTH-009
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Call POST /auth/login.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Response contains user data without password.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 10: Password is not returned in customer login response

- **Test ID:** AUTH-010
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Call POST /auth/customer-login.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Response contains customer data without password.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 11: Locked employee account cannot login

- **Test ID:** AUTH-011
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Disable an employee from admin and retry login.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Login fails for that employee account.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 12: Admin can edit an employee account username

- **Test ID:** AUTH-012
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Open employee management and change username.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- New username works and old username no longer works.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 13: Admin can reset employee password to 123

- **Test ID:** AUTH-013
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Edit employee and set password 123.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Employee can login with the reset password.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 14: Staff cannot see admin-only navigation

- **Test ID:** AUTH-014
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Login as staff.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Employee management, payroll admin and web admin tools are hidden.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 15: Admin sees admin-only navigation

- **Test ID:** AUTH-015
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Login as admin.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Employee management, notifications, payroll and web admin tools are visible.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 16: Session can logout on customer web

- **Test ID:** AUTH-016
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Login customer then click logout.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer returns to the login screen.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 17: Customer local session reloads safely

- **Test ID:** AUTH-017
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Login customer and refresh page.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer session reloads from local storage and data is fetched again.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 18: Invalid stored customer session does not crash

- **Test ID:** AUTH-018
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Put invalid session JSON in local storage and reload.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Login screen is shown or session is cleared safely.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 19: Web staff path serves app

- **Test ID:** AUTH-019
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Open /staff/.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Flutter staff/admin login page loads.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 20: Web admin path serves app

- **Test ID:** AUTH-020
- **Test Location:** Customer web / Staff web / Admin web / Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Customer web / Staff web / Admin web / Android app.
2. Open /admin-web/.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Flutter staff/admin login page loads.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

## Customer Web Reservations And Orders Automation Test Cases

### Test Case 21: Customer sees available tables

- **Test ID:** CUST-021
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Login as customer001 and open table area.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Available, reserved and occupied tables are displayed with correct colors.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 22: Customer reserves an available table

- **Test ID:** CUST-022
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Select an available table and submit reservation.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Table changes to reserved and reservation appears in history.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 23: Customer cannot reserve occupied table

- **Test ID:** CUST-023
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Try selecting an occupied table.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Occupied table is disabled for customer.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 24: Customer cannot reserve another customer's reserved table

- **Test ID:** CUST-024
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Try ordering on a reserved table without matching reservation.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- System blocks the action.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 25: Customer can order on own reserved table

- **Test ID:** CUST-025
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Reserve a table, switch to order mode and submit cart.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order is created and table changes to occupied.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 26: Customer order requires at least one menu item

- **Test ID:** CUST-026
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Submit order mode with empty cart.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- System shows validation error.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 27: Customer cart quantity increases

- **Test ID:** CUST-027
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Click Add item twice.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Cart quantity and total increase correctly.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 28: Customer cart quantity decreases

- **Test ID:** CUST-028
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Click minus on a cart item.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Cart quantity and total decrease correctly.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 29: Customer cart removes zero quantity item

- **Test ID:** CUST-029
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Reduce quantity to zero.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Item disappears from cart.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 30: Customer filters menu by category

- **Test ID:** CUST-030
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Click a category tab.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Only matching category items are shown.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 31: Customer refresh keeps server state

- **Test ID:** CUST-031
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Create reservation then refresh page.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Reservation still exists from backend data.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 32: Customer web polls latest table state

- **Test ID:** CUST-032
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Change a table from admin/staff and wait or refresh.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer web shows new table state.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 33: Customer paid history lists paid invoices

- **Test ID:** CUST-033
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Open payment history for customer001.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Paid invoices show total, paidAt and paidBy.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 34: Customer open order appears in order history

- **Test ID:** CUST-034
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Submit a web order and view history.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order appears with status open.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 35: Paid customer order moves to paid history

- **Test ID:** CUST-035
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Admin pays a customer web order.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer web shows it under payment history after reload.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 36: Customer order is linked to customer account

- **Test ID:** CUST-036
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Create order through customer web.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order has customerId, customerName and customerPhone.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 37: Customer reservation is linked to customer account

- **Test ID:** CUST-037
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Create reservation through customer web.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Reservation has customerId and customer phone.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 38: Customer can add items to own open order

- **Test ID:** CUST-038
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Submit order again on same table/customer.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Existing open order receives more items.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 39: Customer cannot add to another customer open order

- **Test ID:** CUST-039
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Use different customer for a table with open order.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- System returns conflict.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 40: Customer note is saved on order

- **Test ID:** CUST-040
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Submit order with note.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order note is stored in backend export.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 41: Reservation note is saved

- **Test ID:** CUST-041
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Submit reservation with note.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Reservation note appears in history and backend export.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 42: Party size saves correctly

- **Test ID:** CUST-042
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Reserve table with party size 6.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Reservation stores partySize=6.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 43: Reservation default time is valid

- **Test ID:** CUST-043
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Open page and inspect datetime field.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Field contains a future local datetime.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 44: Customer web handles API error

- **Test ID:** CUST-044
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Stop backend then submit action.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- User sees a clear error and page does not freeze.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 45: Customer web image fallback works

- **Test ID:** CUST-045
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Break an image URL and reload.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Layout remains usable without broken text overlap.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 46: Customer web uses white black ocean palette

- **Test ID:** CUST-046
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Open customer web and inspect main surfaces.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer web uses white background, black text and ocean blue primary actions.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 47: Customer top navigation jumps to every section

- **Test ID:** CUST-047
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Click Ban, Mon, Lich su and Da thanh toan.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Page scrolls to the correct section without losing customer session.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 48: Customer table status counters match cards

- **Test ID:** CUST-048
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Compare status strip counts with table cards.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Trong, Da dat and Dang dung counts match backend tables.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 49: Successful customer order clears cart

- **Test ID:** CUST-049
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Submit a customer order with several items.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Cart becomes empty after the server accepts the order.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 50: Customer cannot submit order without selected table

- **Test ID:** CUST-050
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Clear selected table state and submit order.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- System asks the customer to choose a table and does not create an order.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 51: Customer reserved table label shows owner access

- **Test ID:** CUST-051
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Reserve a table then reload as the same customer.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Own reserved table remains selectable for ordering.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 52: Customer web desktop layout has no overlap

- **Test ID:** CUST-052
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Open customer web at 1440px width.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Tables, menu, cart, history and payment sections fit without overlap.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 53: Customer web mobile layout has no overlap

- **Test ID:** CUST-053
- **Test Location:** http://127.0.0.1:3000/customer/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open http://127.0.0.1:3000/customer/.
2. Open customer web at 375px width.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Navigation, table cards, menu cards and cart controls remain usable.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

## Staff And Admin Table Flow Automation Test Cases

### Test Case 54: Staff sees all 16 seeded tables

- **Test ID:** TABLE-054
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Login staff and open Tables.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Sixteen tables are listed after reset.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 55: Table cards show three statuses

- **Test ID:** TABLE-055
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Open Tables after reset.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Available, reserved and occupied labels are visible.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 56: Staff opens available table

- **Test ID:** TABLE-056
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Tap an available table.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order entry screen opens.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 57: Staff order on available table changes status occupied

- **Test ID:** TABLE-057
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Add a menu item from order entry.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Table becomes occupied and open invoice is created.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 58: Staff-created order does not require customer account

- **Test ID:** TABLE-058
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Create order from staff app without customer fields.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order customerId is null or empty and order still works.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 59: Staff can add multiple menu items

- **Test ID:** TABLE-059
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Add three different menu items.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Invoice contains all selected items.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 60: Staff can increase item quantity

- **Test ID:** TABLE-060
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Tap plus on an order item.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Quantity and total increase.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 61: Staff can decrease item quantity

- **Test ID:** TABLE-061
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Tap minus on an order item.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Quantity and total decrease.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 62: Quantity zero removes item

- **Test ID:** TABLE-062
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Decrease item to zero.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Item is removed from invoice.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 63: One table cannot have two open invoices

- **Test ID:** TABLE-063
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Create order twice for same table.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- System returns existing open order.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 64: Admin can add table

- **Test ID:** TABLE-064
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Long press/open add table form.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- New table appears and nextIds updates.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 65: Admin can edit table

- **Test ID:** TABLE-065
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Edit name, seats and area.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Table card shows updated values.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 66: Admin can delete available table

- **Test ID:** TABLE-066
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Delete a table with no open order.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Table is removed.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 67: Cannot delete table with open order

- **Test ID:** TABLE-067
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Try deleting occupied table with open order.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- API blocks with conflict.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 68: Reserved table remains reserved until order starts

- **Test ID:** TABLE-068
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Create reservation only.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Table status is reserved.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 69: Reserved table changes occupied when customer orders

- **Test ID:** TABLE-069
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Customer orders on reserved table.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Admin/staff table status shows occupied.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 70: Paid invoice returns table available

- **Test ID:** TABLE-070
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Pay an open invoice.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Table status changes to available.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 71: Debt invoice returns table available

- **Test ID:** TABLE-071
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Record debt for an open invoice.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Table status changes to available and debt is created.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 72: Table refresh updates cross-platform change

- **Test ID:** TABLE-072
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Change table status on customer web and refresh staff web.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Staff web displays the new status.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 73: Dashboard counts table statuses

- **Test ID:** TABLE-073
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Open dashboard.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Available/reserved/occupied counts match table list.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 74: Selecting menu item does not create invoice immediately

- **Test ID:** TABLE-074
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Open an available table and tap a menu item once.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Item appears in temporary selected list and no invoice is written until confirmation.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 75: Top clear button removes all selected menu items

- **Test ID:** TABLE-075
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Select several menu items then click clear selected list on top.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Temporary list becomes empty and order is unchanged.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 76: Cancel selected menu list stops current selection

- **Test ID:** TABLE-076
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Select items and click Huy bo.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Temporary selected list is cleared without changing invoice.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 77: Confirm selected menu list creates batch one

- **Test ID:** TABLE-077
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Select items on an empty table and confirm.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Invoice is created, table becomes occupied and batch Lan 1 stores selected items.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 78: Occupied table can receive additional batch

- **Test ID:** TABLE-078
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Open an occupied table with open invoice, select more items and confirm.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Existing invoice receives batch Lan 2 and total increases.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 79: Third confirmation creates batch three

- **Test ID:** TABLE-079
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Confirm another selected list on the same open invoice.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Invoice shows Lan 3 under previous batches.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 80: Invoice total sums all batches

- **Test ID:** TABLE-080
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Create at least two batches on one table.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Invoice total equals the sum of every item in all batches.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 81: Long press table opens admin actions

- **Test ID:** TABLE-081
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Login admin and long press a table card.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Action sheet shows add, edit and delete choices.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 82: Staff cannot delete table from action sheet

- **Test ID:** TABLE-082
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Login staff and long press a table card.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Delete/admin-only table controls are not available to staff.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 83: Add table form requires usable values

- **Test ID:** TABLE-083
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Open add table and submit empty name or invalid seats.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- No broken table card is created.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 84: Edit table preserves id and updates visible fields

- **Test ID:** TABLE-084
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Edit a table name, area and seats.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Same table id remains and card displays new details.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 85: Table grid mobile card height is stable

- **Test ID:** TABLE-085
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Open table screen on Android/mobile width.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- No bottom overflow stripe appears under Goi mon buttons.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 86: Refresh table list has no async setState error

- **Test ID:** TABLE-086
- **Test Location:** Flutter app / /staff/ / /admin-web/
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Flutter app / /staff/ / /admin-web/.
2. Pull refresh or tap refresh on table screen.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- No setState callback returned a Future error appears.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

## Invoices Payment Debt And Customer Links Automation Test Cases

### Test Case 87: Admin sees seeded paid invoices

- **Test ID:** INV-087
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Open invoices after reset.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- At least six paid invoices are present.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 88: Admin sees seeded open invoices

- **Test ID:** INV-088
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Open invoices after reset.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- At least two open invoices are present.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 89: Admin sees seeded debts

- **Test ID:** INV-089
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Open debt screen after reset.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Seeded debt records are present.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 90: Pay open invoice as admin

- **Test ID:** INV-090
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. POST /orders/:id/pay with role admin.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order status becomes paid and paidBy is saved.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 91: Pay open invoice as staff

- **Test ID:** INV-091
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. POST /orders/:id/pay with role staff.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order status becomes paid and paidBy is saved.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 92: Unknown role cannot pay invoice

- **Test ID:** INV-092
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. POST /orders/:id/pay with role guest.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- API returns 403.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 93: Cannot pay already paid invoice

- **Test ID:** INV-093
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Pay the same invoice twice.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Second attempt returns not open error.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 94: Payment discount changes total

- **Test ID:** INV-094
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Pay with discount 10000.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order total equals subtotal minus discount.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 95: Customer-web invoice payment appears in customer paid history

- **Test ID:** INV-095
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Create customer order then pay it from admin.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Paid order is returned by /customer-api/paid-history.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 96: Staff-created invoice payment does not appear in customer paid history

- **Test ID:** INV-096
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Create staff order without customerId and pay.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- No customer paid history receives the invoice.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 97: Staff can manually enter debt customer name

- **Test ID:** INV-097
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Record debt with customerName and phone.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Debt stores entered customer info.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 98: Debt amount equals order total

- **Test ID:** INV-098
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Record debt on an invoice.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Debt amount matches order total after discount.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 99: Debt keeps order item details

- **Test ID:** INV-099
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Open debt-linked order.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order items remain intact.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 100: Invoices list newest first

- **Test ID:** INV-100
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Call GET /orders.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Most recent order appears first.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 101: Filter open orders works

- **Test ID:** INV-101
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Call GET /orders?status=open.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Only open orders are returned.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 102: Get open order by table works

- **Test ID:** INV-102
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Call /orders/table/:tableId/open.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Open order or null is returned correctly.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 103: Paid order cannot receive new item

- **Test ID:** INV-103
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. POST item to paid order.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- API rejects because invoice is not open.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 104: Invalid menu item is rejected

- **Test ID:** INV-104
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Add item with unknown menuItemId.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- API returns item unavailable/not found.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 105: Unavailable menu item is rejected

- **Test ID:** INV-105
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Disable menu item and add it.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- API rejects unavailable item.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 106: Invoice totals survive server restart

- **Test ID:** INV-106
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Create invoice then restart backend.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Invoice total is still correct from JSON data.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 107: Invoice includes source customer_web

- **Test ID:** INV-107
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Create order from customer web.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order source is customer_web.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 108: Invoice includes source staff_app

- **Test ID:** INV-108
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Create order from staff/admin app.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order source is staff_app.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 109: Customer order stores phone

- **Test ID:** INV-109
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Create customer order.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order customerPhone matches customer account.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 110: Payment closes seated reservation

- **Test ID:** INV-110
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Order from reservation then pay.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Reservation status becomes completed.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 111: Debt closes seated reservation

- **Test ID:** INV-111
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Order from reservation then record debt.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Reservation status becomes completed.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 112: Invoice filter All returns every status

- **Test ID:** INV-112
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Open invoices and choose Tat ca.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Paid, open and debt invoices can appear in the list.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 113: Invoice filter Paid returns only paid

- **Test ID:** INV-113
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Choose Da tra filter.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Only invoices with status paid are listed.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 114: Invoice filter Open returns active tables

- **Test ID:** INV-114
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Choose Dang dung filter.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Only open invoices for occupied tables are listed.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 115: Clicking invoice expands details

- **Test ID:** INV-115
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Click an invoice card.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer info, staff info, batches, items and total are visible.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 116: Invoice details show batch labels

- **Test ID:** INV-116
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Open an invoice with several confirmations.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Lan 1, Lan 2 and later batches are displayed separately.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 117: Invoice payment dialog cancel keeps invoice open

- **Test ID:** INV-117
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Open pay dialog then click Huy.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Invoice status remains open and table remains occupied.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 118: Invoice payment blank discount is treated as zero

- **Test ID:** INV-118
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Open pay dialog, leave discount blank and confirm.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Payment succeeds with no invalid total.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 119: Invoice debt dialog cancel keeps invoice open

- **Test ID:** INV-119
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Open debt dialog then click Huy.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Invoice status remains open and no debt is created.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 120: Invoice debt creates debt list record

- **Test ID:** INV-120
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Record debt with customer name, phone and note.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Debt screen lists the new debt linked to that order.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 121: Paid invoice hides pay and debt actions

- **Test ID:** INV-121
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Expand a paid invoice.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Da tra and Ghi no buttons are not shown.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 122: Invoice refresh has no async setState error

- **Test ID:** INV-122
- **Test Location:** Orders API / Invoices screen / Customer history
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Orders API / Invoices screen / Customer history.
2. Tap invoice refresh repeatedly.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- No setState callback returned a Future error appears.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

## Menu Catalog Images And Categories Automation Test Cases

### Test Case 123: Seed menu has at least 40 items

- **Test ID:** MENU-123
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Reset data and call GET /menu.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- At least 40 menu items exist.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 124: Seed menu has drinks

- **Test ID:** MENU-124
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Filter menu category Do uong.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Drink items are present.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 125: Seed menu has snacks

- **Test ID:** MENU-125
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Filter menu category An vat.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Snack items are present.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 126: Seed menu has main dishes

- **Test ID:** MENU-126
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Filter menu category Mon chinh.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Main dish items are present.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 127: Seed menu has desserts

- **Test ID:** MENU-127
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Filter menu category Trang mieng.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Dessert items are present.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 128: Every menu item has imageUrl

- **Test ID:** MENU-128
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Inspect GET /menu response.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Each item has a non-empty imageUrl.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 129: Food image URL uses item-specific query

- **Test ID:** MENU-129
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Inspect seeded imageUrl.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Image query contains terms related to item name.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 130: Admin can add menu item

- **Test ID:** MENU-130
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Create new menu item.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Item appears in menu list and customer web if available.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 131: Admin can edit menu price

- **Test ID:** MENU-131
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Update price of an item.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- New price appears in app and web.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 132: Admin can edit menu category

- **Test ID:** MENU-132
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Update category of an item.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Item moves to new category tab.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 133: Admin can hide menu item

- **Test ID:** MENU-133
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Set available=false.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Item does not appear in order entry/customer web.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 134: Admin can re-enable menu item

- **Test ID:** MENU-134
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Set available=true.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Item appears again.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 135: Delete menu item removes it

- **Test ID:** MENU-135
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Delete a menu item.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Item is absent from menu list.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 136: Invalid price is handled

- **Test ID:** MENU-136
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Submit non-numeric price.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- System normalizes or rejects without crash.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 137: Menu image failure does not break layout

- **Test ID:** MENU-137
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Use a bad image URL.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Fallback/empty image area keeps layout stable.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 138: Customer category tabs include all categories

- **Test ID:** MENU-138
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Open customer web menu.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Tabs match menu categories.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 139: Staff order entry only lists available items

- **Test ID:** MENU-139
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Disable an item then open order entry.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Disabled item is hidden.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 140: Menu card text fits

- **Test ID:** MENU-140
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Inspect long item name.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Text does not overflow card.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 141: Menu total uses latest price

- **Test ID:** MENU-141
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Update item price then add to order.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Order item price uses updated value.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 142: Menu count appears on admin health

- **Test ID:** MENU-142
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Call /admin/health.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- menuItems equals menu array length.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 143: Menu dialog cancel does not save changes

- **Test ID:** MENU-143
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Open add/edit menu dialog then click Huy.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Menu list stays unchanged.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 144: Menu availability toggle persists after refresh

- **Test ID:** MENU-144
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Toggle an item hidden/visible then refresh.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- The availability icon and API value remain updated.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 145: Menu image URL can be edited

- **Test ID:** MENU-145
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Edit imageUrl for one item.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Staff app and customer web load the updated image URL.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 146: Menu list remains usable with 50 plus items

- **Test ID:** MENU-146
- **Test Location:** Menu API / Staff app / Customer web
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Menu API / Staff app / Customer web.
2. Open menu after seeded data loads.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Scrolling remains smooth and every item card is reachable.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

## Employees Attendance Payroll Automation Test Cases

### Test Case 147: Seed has 12 employees

- **Test ID:** EMP-147
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Reset and call /employees.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Twelve employees are returned.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 148: Each employee has an account

- **Test ID:** EMP-148
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Inspect /employees response.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Each employee has account username and role.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 149: Admin creates employee and account

- **Test ID:** EMP-149
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Create employee from admin screen.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Employee and login account are created.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 150: Admin edits employee role

- **Test ID:** EMP-150
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Change role field.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Role updates in list.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 151: Admin edits salary

- **Test ID:** EMP-151
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Change salaryPerDay.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Payroll uses new salary.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 152: Admin locks employee

- **Test ID:** EMP-152
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Delete/lock employee.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Employee active=false and account cannot login.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 153: Username uniqueness is enforced

- **Test ID:** EMP-153
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Create employee with existing username.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- System generates or rejects duplicate safely.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 154: Default new employee password is 123

- **Test ID:** EMP-154
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Create employee without password.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Employee can login with 123.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 155: Seed attendance spans multiple months

- **Test ID:** EMP-155
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Inspect /attendance and payroll for March-May.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Attendance data exists across months.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 156: Attendance workday is 10 hours

- **Test ID:** EMP-156
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Inspect seeded checkIn/checkOut.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- 08:00-18:00 equals 10 hours.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 157: Payroll calculates March days

- **Test ID:** EMP-157
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Call /payroll?month=2026-03.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Days and salary match attendance rows.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 158: Payroll salary uses 300000 per day

- **Test ID:** EMP-158
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Check employee with 21 days.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Salary equals 6,300,000 VND.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 159: Check-in creates row for today

- **Test ID:** EMP-159
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. POST /attendance/check-in.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Row is created or existing row returned.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 160: Duplicate check-in does not duplicate day

- **Test ID:** EMP-160
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Call check-in twice same employee/date.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Only one row exists for that employee/date.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 161: Check-out saves end time

- **Test ID:** EMP-161
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. PATCH /attendance/:id/check-out.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- checkOut becomes non-null.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 162: Attendance list can filter date

- **Test ID:** EMP-162
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. GET /attendance?date=2026-03-03.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Rows for only that date return.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 163: Inactive employee remains in historical payroll

- **Test ID:** EMP-163
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Deactivate employee with past attendance.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Historical rows still calculate without data loss.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 164: Employee phone is editable

- **Test ID:** EMP-164
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Edit phone.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- New phone appears in employee list.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 165: Account role can change to admin

- **Test ID:** EMP-165
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Edit accountRole admin.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Employee can login and see admin features.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 166: Account role can change back to staff

- **Test ID:** EMP-166
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Edit accountRole staff.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Employee no longer sees admin-only features.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 167: Employee edit dialog cancel does not save

- **Test ID:** EMP-167
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Open employee edit dialog and click Huy.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Employee details remain unchanged.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 168: Employee delete deactivates login account

- **Test ID:** EMP-168
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Delete an employee from admin.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Employee active=false and linked account cannot login.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 169: Attendance refresh has no async setState error

- **Test ID:** EMP-169
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Refresh attendance screen repeatedly.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- No setState callback returned a Future error appears.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 170: Payroll month picker accepts YYYY-MM

- **Test ID:** EMP-170
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Open payroll month dialog and enter 2026-04.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Payroll reloads for April 2026.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 171: Payroll invalid month does not crash UI

- **Test ID:** EMP-171
- **Test Location:** Employees / Attendance / Payroll
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Employees / Attendance / Payroll.
2. Enter an invalid month value.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Screen remains usable and shows safe empty/error state.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

## Dashboard Statistics Notifications Admin Automation Test Cases

### Test Case 172: Dashboard shows table count

- **Test ID:** ADM-172
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Open dashboard.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Table count equals /tables length.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 173: Dashboard shows available count

- **Test ID:** ADM-173
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Open dashboard.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Available count equals tables with available status.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 174: Dashboard shows reserved count

- **Test ID:** ADM-174
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Open dashboard.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Reserved count equals tables with reserved status.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 175: Dashboard shows occupied count

- **Test ID:** ADM-175
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Open dashboard.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Occupied count equals tables with occupied status.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 176: Dashboard shows open orders

- **Test ID:** ADM-176
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Open dashboard.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Open order count equals /orders?status=open.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 177: Dashboard shows customer count

- **Test ID:** ADM-177
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Open dashboard.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer count equals active customers.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 178: Revenue today includes only paid today

- **Test ID:** ADM-178
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Pay an invoice today then open dashboard.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Revenue today increases by invoice total.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 179: Stats month revenue works

- **Test ID:** ADM-179
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Call /stats?period=month.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Only paid orders in month are included.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 180: Stats top items works

- **Test ID:** ADM-180
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Call stats after paid orders.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Top items include quantity and revenue.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 181: Debt open amount works

- **Test ID:** ADM-181
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Create debt and open dashboard.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Open debt amount increases.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 182: Admin health counts data

- **Test ID:** ADM-182
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Call /admin/health.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Counts match exported arrays.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 183: Admin export returns JSON

- **Test ID:** ADM-183
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Call /admin/export.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Export includes users, employees, customers, tables, menu and orders.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 184: Reset restores seed data

- **Test ID:** ADM-184
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. POST /admin/reset.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Counts return to seed values.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 185: Notification list shows latest

- **Test ID:** ADM-185
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Open dashboard.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Latest notifications are visible.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 186: Admin creates notification

- **Test ID:** ADM-186
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Create notification from admin screen.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Staff can see new notification.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 187: Notification audience all is visible to all roles

- **Test ID:** ADM-187
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Create audience all.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Admin and staff both see it.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 188: Notification audience staff is visible to staff

- **Test ID:** ADM-188
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Create audience staff.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Staff sees it in notifications.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 189: Admin web checklist displays

- **Test ID:** ADM-189
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Open web admin screen.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Operational checklist appears.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 190: Admin export preview scrolls

- **Test ID:** ADM-190
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Open web admin screen.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Large JSON preview is selectable and constrained.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 191: Stats do not count debt as paid revenue

- **Test ID:** ADM-191
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Create debt order.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Revenue does not include debt order as paid revenue.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 192: Stats can switch to another day

- **Test ID:** ADM-192
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Open stats and move to previous day.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Metrics reload for the selected day.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 193: Stats can switch to another month

- **Test ID:** ADM-193
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Choose month mode and move previous/next.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Metrics reload for the selected month.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 194: Stats can switch to another year

- **Test ID:** ADM-194
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Choose year mode and move previous/next.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Metrics reload for the selected year.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 195: Stats date picker changes anchor date

- **Test ID:** ADM-195
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Use the calendar button to choose a date.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Stats API is called with the selected date.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 196: Notification delete removes item

- **Test ID:** ADM-196
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Delete a notification as admin.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Notification no longer appears after refresh.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 197: Notification form cancel does not create item

- **Test ID:** ADM-197
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Open notification form then cancel.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Notification count stays unchanged.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 198: Dashboard refresh has no async setState error

- **Test ID:** ADM-198
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Refresh dashboard repeatedly.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Dashboard reloads without Future setState overlay.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 199: Web admin export count matches dashboard

- **Test ID:** ADM-199
- **Test Location:** Dashboard / Stats / Notifications / Admin export
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Dashboard / Stats / Notifications / Admin export.
2. Open web admin export and compare counts.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Export counts match dashboard and health endpoints.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

## Cross Platform And Deployment Automation Test Cases

### Test Case 200: Customer reservation appears in staff web

- **Test ID:** E2E-200
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Reserve from customer web then open /staff/.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Staff table list shows reserved.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 201: Customer order appears in admin invoices

- **Test ID:** E2E-201
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Order from customer web then open /admin-web/ invoices.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Open invoice appears.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 202: Admin payment updates customer web history

- **Test ID:** E2E-202
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Pay customer order from admin web.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer payment history shows paid invoice.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 203: Staff payment updates customer web history

- **Test ID:** E2E-203
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Pay customer order from staff app.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer payment history shows paid invoice.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 204: Android app can use same backend as web

- **Test ID:** E2E-204
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Build app with proper API_BASE_URL or adb reverse.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- App reads the same tables/orders as web.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 205: Staff web and admin web share backend data

- **Test ID:** E2E-205
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Create table in admin web and view staff web.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- New table appears after refresh.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 206: Customer web and staff web use same table statuses

- **Test ID:** E2E-206
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Change status via customer flow.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Staff/admin see same status.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 207: Backend restart keeps JSON data

- **Test ID:** E2E-207
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Create data then restart backend.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Data persists from restaurant.json.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 208: Flutter web build is served from backend

- **Test ID:** E2E-208
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Open /staff/ after flutter build web.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Web app loads from backend server.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 209: Admin web path is independent from customer web

- **Test ID:** E2E-209
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Open /admin-web/ and /customer/ in two tabs.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Both apps load different UIs.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 210: Customer web white black ocean theme loads

- **Test ID:** E2E-210
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Open /customer/.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Palette is white, black and ocean blue with readable contrast.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 211: No text overlap on customer mobile viewport

- **Test ID:** E2E-211
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Resize customer web to mobile width.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Buttons, cards and history rows do not overlap.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 212: No text overlap on staff web mobile viewport

- **Test ID:** E2E-212
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Resize /staff/ to mobile width.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Flutter layout remains usable.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 213: Customer payment history excludes unpaid orders

- **Test ID:** E2E-213
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Create open order and inspect payment list.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Open order does not appear in paid history.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 214: Customer payment history includes only linked customer orders

- **Test ID:** E2E-214
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Pay staff-created order without customerId.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer paid history is unchanged.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 215: API bootstrap is complete

- **Test ID:** E2E-215
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Call /customer-api/bootstrap.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Response includes settings, customer, tables, menu, reservations, orders and paidOrders.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 216: LAN deployment can use explicit API_BASE_URL

- **Test ID:** E2E-216
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Build app with LAN IP.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Installed app connects to backend on same network.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 217: Emulator deployment uses fallback 10.0.2.2

- **Test ID:** E2E-217
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Run app on Android emulator without dart-define.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- App tries backend at 10.0.2.2:3000.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 218: USB deployment works with adb reverse

- **Test ID:** E2E-218
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Run adb reverse tcp:3000 tcp:3000.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Installed debug app can reach localhost backend.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 219: Customer web works without separate frontend server

- **Test ID:** E2E-219
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Run only backend and open /customer/.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer web loads and calls same backend.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 220: Staff/admin web works without separate frontend server after build

- **Test ID:** E2E-220
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Run backend and open /staff/.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Flutter web loads from backend build output.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 221: Reset then all three clients read seed data

- **Test ID:** E2E-221
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. POST /reset then refresh customer/staff/admin.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- All clients show seed counts and statuses.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 222: Concurrent customer and staff action stays consistent

- **Test ID:** E2E-222
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Customer orders while staff views tables.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Only one open order exists and status is occupied.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 223: Paid table becomes available everywhere

- **Test ID:** E2E-223
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Pay any open order.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer/staff/admin all show table available after refresh.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 224: Health endpoint stays ok after full scenario

- **Test ID:** E2E-224
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Run reservation, order, pay, employee edit then call health.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Health status remains ok.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 225: Android Studio can run the app

- **Test ID:** E2E-225
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Open frontend/android in Android Studio and run the debug configuration.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- App launches and connects to backend when API URL is reachable.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 226: Android Studio emulator uses backend fallback

- **Test ID:** E2E-226
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Run app from Android Studio on emulator with backend running locally.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- App can reach backend through emulator fallback or explicit dart define.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 227: Android Studio physical device uses LAN or adb reverse

- **Test ID:** E2E-227
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Run app from Android Studio on a phone.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- App connects when adb reverse is active or API_BASE_URL uses the computer LAN IP.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 228: Customer web action changes Android app table screen

- **Test ID:** E2E-228
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Reserve/order from customer web then refresh Android table screen.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Android app shows reserved or occupied status from the same backend.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 229: Android payment changes customer web payment history

- **Test ID:** E2E-229
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Pay a customer-linked order from Android app.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer web payment history includes the paid invoice.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 230: Staff web order changes Android invoice list

- **Test ID:** E2E-230
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Create a staff web order then open Android invoices.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Android app lists the same open invoice.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 231: Admin web employee change affects Android login

- **Test ID:** E2E-231
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Change employee account in admin web then login on Android.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Android login uses the updated account data.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

## Android App Deep Regression Automation Test Cases

### Test Case 232: Android app launches to login screen

- **Test ID:** APP-232
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Install debug APK and open app.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Login screen shows logo, app name, username, password and login button.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 233: Android admin login reaches dashboard

- **Test ID:** APP-233
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Login on emulator with admin/123.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Dashboard loads without connection error.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 234: Android staff login reaches dashboard

- **Test ID:** APP-234
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Login on emulator with staff/123.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Staff dashboard loads and admin-only modules are hidden.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 235: Android customer account cannot login on staff app

- **Test ID:** APP-235
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Try customer001/123 in Flutter app login.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Login is rejected because customer accounts use customer web only.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 236: Android drawer opens navigation

- **Test ID:** APP-236
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Tap hamburger menu.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Navigation drawer opens and every role-allowed screen is reachable.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 237: Android table screen has no overflow

- **Test ID:** APP-237
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open Quan ly ban on emulator.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- No yellow/black overflow stripe appears on table cards.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 238: Android invoice refresh has no setState Future error

- **Test ID:** APP-238
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open Hoa don and tap refresh.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- No snackbar/error overlay says setState callback returned a Future.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 239: Android attendance refresh has no setState Future error

- **Test ID:** APP-239
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open Cham cong and refresh.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- No setState Future error is shown.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 240: Android table refresh has no setState Future error

- **Test ID:** APP-240
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open Ban and refresh.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- No setState Future error is shown.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 241: Android order entry temporary selection works

- **Test ID:** APP-241
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open table and tap menu item.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Selected item appears in temporary list; invoice is unchanged before confirm.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 242: Android order entry clear selected list works

- **Test ID:** APP-242
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Select several items and tap top clear button.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Temporary list becomes empty.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 243: Android order entry cancel works

- **Test ID:** APP-243
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Select items and tap Huy bo.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Temporary list clears and table/order data stays unchanged.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 244: Android order entry confirm creates batch

- **Test ID:** APP-244
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Select items then tap Xac nhan chon mon.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Invoice shows Lan 1 and table becomes occupied.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 245: Android occupied table can add second batch

- **Test ID:** APP-245
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open the occupied table and confirm more items.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Invoice shows Lan 2.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 246: Android invoice details expand

- **Test ID:** APP-246
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open Hoa don and tap an invoice.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Invoice detail shows batches, items and total.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 247: Android invoice filter all works

- **Test ID:** APP-247
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Tap Tat ca on invoice screen.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- All invoice statuses are listed.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 248: Android invoice filter paid works

- **Test ID:** APP-248
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Tap Da tra.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Only paid invoices are listed.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 249: Android invoice filter active works

- **Test ID:** APP-249
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Tap Dang dung.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Only open active invoices are listed.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 250: Android payment returns table available

- **Test ID:** APP-250
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Pay an open invoice from app.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Invoice is paid and related table becomes available after refresh.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 251: Android debt flow returns table available

- **Test ID:** APP-251
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Record debt for an open invoice.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Debt is created and table becomes available.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 252: Android stats day selector works

- **Test ID:** APP-252
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open stats and choose day mode.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Day metrics load.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 253: Android stats month selector works

- **Test ID:** APP-253
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open stats and choose month mode.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Month metrics load.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 254: Android stats year selector works

- **Test ID:** APP-254
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open stats and choose year mode.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Year metrics load.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 255: Android stats previous and next buttons work

- **Test ID:** APP-255
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Tap Truoc and Sau on stats.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Anchor date changes and metrics reload.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 256: Android date picker changes stats

- **Test ID:** APP-256
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open stats date picker and choose a date.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Stats reload for selected date.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 257: Android employee account management opens

- **Test ID:** APP-257
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Login admin and open Nhan vien.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Employee list shows account username and role.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 258: Android employee account edit saves

- **Test ID:** APP-258
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Edit an employee account field.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Employee/account data is saved after refresh.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 259: Android check-in creates attendance

- **Test ID:** APP-259
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open Cham cong and tap Vao ca.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Attendance row appears for selected employee.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 260: Android check-out completes attendance

- **Test ID:** APP-260
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Tap Ra ca on an open attendance row.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Row changes to completed state.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 261: Android app survives backend outage

- **Test ID:** APP-261
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Stop backend and refresh a screen.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- App shows connection error and does not crash.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 262: Android menu screen opens and scrolls

- **Test ID:** APP-262
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open Quan ly mon an on emulator.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Menu list with images scrolls without layout overflow.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 263: Android debt screen opens and can collect debt

- **Test ID:** APP-263
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open Cong no and tap Thu du on an open debt.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Debt becomes paid or completed after refresh.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 264: Android payroll screen opens month picker

- **Test ID:** APP-264
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open payroll and tap month button.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Month dialog opens and reloads selected month.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 265: Android notifications screen opens

- **Test ID:** APP-265
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open notifications from drawer.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Notification list renders and can refresh.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 266: Android employee screen is admin-only

- **Test ID:** APP-266
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Login staff and inspect drawer.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Employee management screen is hidden from staff role.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 267: Android drawer text fits narrow width

- **Test ID:** APP-267
- **Test Location:** Android emulator / Android Studio / Flutter app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Android emulator / Android Studio / Flutter app.
2. Open drawer on emulator.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Navigation labels fit without clipping or overflow.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

## Visual Studio Automation Project Automation Test Cases

### Test Case 268: Solution opens in Visual Studio 2022

- **Test ID:** VS-268
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Open tests/RestaurantManagement.Tests.sln.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Solution loads without missing project errors.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 269: Test Explorer discovers API tests

- **Test ID:** VS-269
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Open Test Explorer after build.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- API smoke tests are listed.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 270: Test Explorer discovers web tests

- **Test ID:** VS-270
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Open Test Explorer after build.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Web Playwright tests are listed.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 271: Test Explorer discovers Android test

- **Test ID:** VS-271
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Open Test Explorer after build.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Android Appium launch test is listed.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 272: Runsettings file can be selected

- **Test ID:** VS-272
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Select tests/local.runsettings.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Environment variables are available to tests.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 273: API test category can run alone

- **Test ID:** VS-273
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Run filter TestCategory!=Web&TestCategory!=Android.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Only API tests run and pass when backend is running.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 274: Web test category can run alone

- **Test ID:** VS-274
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Run filter TestCategory=Web.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Only Playwright web tests run.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 275: Android test is skipped by default

- **Test ID:** VS-275
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Run all tests with RMS_RUN_ANDROID=0.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Android test is inconclusive/skipped instead of failing because Appium is not enabled.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 276: Android test can be enabled

- **Test ID:** VS-276
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Set RMS_RUN_ANDROID=1 and start Appium.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Android Appium smoke test attempts to launch APK.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 277: Playwright browsers install command works

- **Test ID:** VS-277
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Run playwright.ps1 install after dotnet build.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Browser binaries are installed for Playwright tests.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 278: C# test project uses MSTest

- **Test ID:** VS-278
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Inspect csproj packages.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- MSTest package and test adapter are present.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 279: C# test project uses Playwright

- **Test ID:** VS-279
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Inspect csproj packages.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Microsoft.Playwright.MSTest is present.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 280: C# test project uses Appium

- **Test ID:** VS-280
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Inspect csproj packages.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Appium.WebDriver is present.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 281: Generated catalog test file compiles

- **Test ID:** VS-281
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Build solution after generating all catalog tests.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- All generated test case methods compile.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 282: Generated catalog count matches markdown

- **Test ID:** VS-282
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Compare Test Explorer catalog count with markdown count.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Every documented test case has a matching catalog test method.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 283: Automated smoke tests are separated from catalog tests

- **Test ID:** VS-283
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Run automated category filters.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Manual/catalog tests do not block automated smoke runs.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 284: Backend URL can be overridden

- **Test ID:** VS-284
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Set RMS_BACKEND_URL to another host.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Tests use the configured backend URL.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 285: Customer URL can be overridden

- **Test ID:** VS-285
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Set RMS_CUSTOMER_WEB_URL.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer web tests use that URL.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 286: Staff URL can be overridden

- **Test ID:** VS-286
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Set RMS_STAFF_WEB_URL.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Staff web tests use that URL.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 287: Admin URL can be overridden

- **Test ID:** VS-287
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Set RMS_ADMIN_WEB_URL.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Admin web tests use that URL.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 288: Generated catalog includes app scenarios

- **Test ID:** VS-288
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Inspect GeneratedTestCaseCatalogTests.cs.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Android app scenario methods are present with TestCategory APP.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 289: Generated catalog includes customer web scenarios

- **Test ID:** VS-289
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Inspect GeneratedTestCaseCatalogTests.cs.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Customer web scenario methods are present with TestCategory CUST.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 290: Generated catalog includes staff admin web scenarios

- **Test ID:** VS-290
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Inspect GeneratedTestCaseCatalogTests.cs.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Staff/admin web scenario methods are present with TABLE, INV and ADM categories.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 291: Generated catalog tests are ignored by default

- **Test ID:** VS-291
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Run dotnet test automated filters.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Catalog/manual scenario methods do not fail the smoke automation run.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 292: Runsettings keeps local URLs in one place

- **Test ID:** VS-292
- **Test Location:** Visual Studio 2022 / tests solution
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Visual Studio 2022 / tests solution.
2. Open tests/local.runsettings.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Backend, customer, staff, admin, Appium and Android flags are configured centrally.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

## Documentation Data And Recovery Automation Test Cases

### Test Case 293: README lists all main URLs

- **Test ID:** DOC-293
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open README.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Backend, customer web, staff web, admin web and Android app instructions are present.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 294: README lists all employee accounts

- **Test ID:** DOC-294
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open account section.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Twelve employee/admin usernames and password 123 are documented.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 295: README lists customer account pattern

- **Test ID:** DOC-295
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open account section.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- customer001 through customer100 with password 123 are documented.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 296: README explains Android Studio run

- **Test ID:** DOC-296
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open Android Studio section.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Emulator, USB reverse and LAN IP options are documented.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 297: README explains order batch behavior

- **Test ID:** DOC-297
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open business UI section.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Temporary selection, confirm, cancel and Lan 1/Lan 2 behavior are documented.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 298: Markdown test cases exist

- **Test ID:** DOC-298
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open all-test-cases-expandtesting-style.md.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Markdown file exists and contains all test cases.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 299: Vietnamese Markdown copy exists

- **Test ID:** DOC-299
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open all-test-cases-expandtesting-style-vi.md.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Vietnamese markdown copy exists.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 300: Word test cases exist

- **Test ID:** DOC-300
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open all-test-cases-expandtesting-style.docx.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Word document exists.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 301: Excel test cases exist

- **Test ID:** DOC-301
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open all-test-cases-expandtesting-style.xlsx.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Excel workbook exists.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 302: Vietnamese Word test cases exist

- **Test ID:** DOC-302
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open all-test-cases-expandtesting-style-vi.docx.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Vietnamese Word document exists.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 303: Vietnamese Excel test cases exist

- **Test ID:** DOC-303
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open all-test-cases-expandtesting-style-vi.xlsx.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Vietnamese Excel workbook exists.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 304: Test case IDs are unique

- **Test ID:** DOC-304
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Parse all markdown test case IDs.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- No duplicate Test ID exists.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 305: Test case numbering is continuous

- **Test ID:** DOC-305
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Parse Test Case numbers.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Numbers start at 1 and increase without gaps.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 306: Office export count matches markdown

- **Test ID:** DOC-306
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Compare generated docx/xlsx count with markdown count.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- All formats have the same test case count.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 307: Visual Studio generated test count matches markdown

- **Test ID:** DOC-307
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Compare generated C# catalog methods with markdown count.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- No documented test case is missing from Visual Studio tests.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 308: Reset restores seed counts

- **Test ID:** DOC-308
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. POST /reset then call /admin/health.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Seed counts return to expected values.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 309: Restaurant JSON is not committed

- **Test ID:** DOC-309
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Inspect git status and .gitignore.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- backend/data/restaurant.json remains ignored.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 310: Build folders are not committed

- **Test ID:** DOC-310
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Inspect .gitignore.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- frontend/build and test bin/obj folders are ignored.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 311: Tools folder remains ignored if desired

- **Test ID:** DOC-311
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Inspect .gitignore.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- tools/ is ignored and will not be re-added accidentally.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 312: Backend logs are ignored

- **Test ID:** DOC-312
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Inspect .gitignore.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- backend/logs is ignored.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 313: Project can recover after deleting data JSON

- **Test ID:** DOC-313
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Delete restaurant.json and start backend.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Store recreates seed data.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 314: Project can recover after reset during open clients

- **Test ID:** DOC-314
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Run /reset while clients are open then refresh.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Clients reload seed data cleanly.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 315: Test documentation generation is repeatable

- **Test ID:** DOC-315
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Run node tools/generate_markdown_test_cases.js twice.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Output count and IDs remain stable.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 316: Office export generation is repeatable

- **Test ID:** DOC-316
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Run python tools/export_test_cases_office.py twice.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Docx/xlsx output count remains stable.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 317: Visual Studio catalog generation is repeatable

- **Test ID:** DOC-317
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Run python tools/generate_vs_test_catalog.py twice.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Generated C# compiles and count remains stable.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 318: Dash-name markdown alias exists

- **Test ID:** DOC-318
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open all-test-cases-expand-testing-style.md.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Dash-name copy exists for the requested file name.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 319: Dash-name Vietnamese markdown alias exists

- **Test ID:** DOC-319
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open all-test-cases-expand-testing-style-vi.md.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Dash-name Vietnamese copy exists and matches case count.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 320: Vietnamese document count matches English

- **Test ID:** DOC-320
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Count Test Case headings in both markdown files.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- English and Vietnamese versions contain the same number of cases.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 321: Locked Excel export creates updated fallback

- **Test ID:** DOC-321
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Keep the original Excel file open and run export.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Script writes an updated fallback workbook instead of stopping.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 322: README documents Visual Studio test catalog

- **Test ID:** DOC-322
- **Test Location:** README / Document test cases / JSON seed data
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open README / Document test cases / JSON seed data.
2. Open README test section.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- README explains generated catalog tests and automated smoke tests.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

Total test cases: 322
