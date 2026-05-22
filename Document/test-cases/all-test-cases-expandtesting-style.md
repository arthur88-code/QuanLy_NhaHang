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

## Staff And Admin Table Flow Automation Test Cases

### Test Case 47: Staff sees all 16 seeded tables

- **Test ID:** TABLE-047
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

### Test Case 48: Table cards show three statuses

- **Test ID:** TABLE-048
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

### Test Case 49: Staff opens available table

- **Test ID:** TABLE-049
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

### Test Case 50: Staff order on available table changes status occupied

- **Test ID:** TABLE-050
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

### Test Case 51: Staff-created order does not require customer account

- **Test ID:** TABLE-051
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

### Test Case 52: Staff can add multiple menu items

- **Test ID:** TABLE-052
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

### Test Case 53: Staff can increase item quantity

- **Test ID:** TABLE-053
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

### Test Case 54: Staff can decrease item quantity

- **Test ID:** TABLE-054
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

### Test Case 55: Quantity zero removes item

- **Test ID:** TABLE-055
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

### Test Case 56: One table cannot have two open invoices

- **Test ID:** TABLE-056
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

### Test Case 57: Admin can add table

- **Test ID:** TABLE-057
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

### Test Case 58: Admin can edit table

- **Test ID:** TABLE-058
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

### Test Case 59: Admin can delete available table

- **Test ID:** TABLE-059
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

### Test Case 60: Cannot delete table with open order

- **Test ID:** TABLE-060
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

### Test Case 61: Reserved table remains reserved until order starts

- **Test ID:** TABLE-061
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

### Test Case 62: Reserved table changes occupied when customer orders

- **Test ID:** TABLE-062
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

### Test Case 63: Paid invoice returns table available

- **Test ID:** TABLE-063
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

### Test Case 64: Debt invoice returns table available

- **Test ID:** TABLE-064
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

### Test Case 65: Table refresh updates cross-platform change

- **Test ID:** TABLE-065
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

### Test Case 66: Dashboard counts table statuses

- **Test ID:** TABLE-066
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

### Test Case 67: Selecting menu item does not create invoice immediately

- **Test ID:** TABLE-067
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

### Test Case 68: Top clear button removes all selected menu items

- **Test ID:** TABLE-068
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

### Test Case 69: Cancel selected menu list stops current selection

- **Test ID:** TABLE-069
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

### Test Case 70: Confirm selected menu list creates batch one

- **Test ID:** TABLE-070
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

### Test Case 71: Occupied table can receive additional batch

- **Test ID:** TABLE-071
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

### Test Case 72: Third confirmation creates batch three

- **Test ID:** TABLE-072
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

### Test Case 73: Invoice total sums all batches

- **Test ID:** TABLE-073
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

## Invoices Payment Debt And Customer Links Automation Test Cases

### Test Case 74: Admin sees seeded paid invoices

- **Test ID:** INV-074
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

### Test Case 75: Admin sees seeded open invoices

- **Test ID:** INV-075
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

### Test Case 76: Admin sees seeded debts

- **Test ID:** INV-076
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

### Test Case 77: Pay open invoice as admin

- **Test ID:** INV-077
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

### Test Case 78: Pay open invoice as staff

- **Test ID:** INV-078
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

### Test Case 79: Unknown role cannot pay invoice

- **Test ID:** INV-079
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

### Test Case 80: Cannot pay already paid invoice

- **Test ID:** INV-080
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

### Test Case 81: Payment discount changes total

- **Test ID:** INV-081
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

### Test Case 82: Customer-web invoice payment appears in customer paid history

- **Test ID:** INV-082
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

### Test Case 83: Staff-created invoice payment does not appear in customer paid history

- **Test ID:** INV-083
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

### Test Case 84: Staff can manually enter debt customer name

- **Test ID:** INV-084
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

### Test Case 85: Debt amount equals order total

- **Test ID:** INV-085
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

### Test Case 86: Debt keeps order item details

- **Test ID:** INV-086
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

### Test Case 87: Invoices list newest first

- **Test ID:** INV-087
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

### Test Case 88: Filter open orders works

- **Test ID:** INV-088
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

### Test Case 89: Get open order by table works

- **Test ID:** INV-089
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

### Test Case 90: Paid order cannot receive new item

- **Test ID:** INV-090
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

### Test Case 91: Invalid menu item is rejected

- **Test ID:** INV-091
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

### Test Case 92: Unavailable menu item is rejected

- **Test ID:** INV-092
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

### Test Case 93: Invoice totals survive server restart

- **Test ID:** INV-093
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

### Test Case 94: Invoice includes source customer_web

- **Test ID:** INV-094
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

### Test Case 95: Invoice includes source staff_app

- **Test ID:** INV-095
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

### Test Case 96: Customer order stores phone

- **Test ID:** INV-096
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

### Test Case 97: Payment closes seated reservation

- **Test ID:** INV-097
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

### Test Case 98: Debt closes seated reservation

- **Test ID:** INV-098
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

### Test Case 99: Invoice filter All returns every status

- **Test ID:** INV-099
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

### Test Case 100: Invoice filter Paid returns only paid

- **Test ID:** INV-100
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

### Test Case 101: Invoice filter Open returns active tables

- **Test ID:** INV-101
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

### Test Case 102: Clicking invoice expands details

- **Test ID:** INV-102
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

### Test Case 103: Invoice details show batch labels

- **Test ID:** INV-103
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

## Menu Catalog Images And Categories Automation Test Cases

### Test Case 104: Seed menu has at least 40 items

- **Test ID:** MENU-104
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

### Test Case 105: Seed menu has drinks

- **Test ID:** MENU-105
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

### Test Case 106: Seed menu has snacks

- **Test ID:** MENU-106
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

### Test Case 107: Seed menu has main dishes

- **Test ID:** MENU-107
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

### Test Case 108: Seed menu has desserts

- **Test ID:** MENU-108
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

### Test Case 109: Every menu item has imageUrl

- **Test ID:** MENU-109
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

### Test Case 110: Food image URL uses item-specific query

- **Test ID:** MENU-110
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

### Test Case 111: Admin can add menu item

- **Test ID:** MENU-111
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

### Test Case 112: Admin can edit menu price

- **Test ID:** MENU-112
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

### Test Case 113: Admin can edit menu category

- **Test ID:** MENU-113
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

### Test Case 114: Admin can hide menu item

- **Test ID:** MENU-114
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

### Test Case 115: Admin can re-enable menu item

- **Test ID:** MENU-115
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

### Test Case 116: Delete menu item removes it

- **Test ID:** MENU-116
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

### Test Case 117: Invalid price is handled

- **Test ID:** MENU-117
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

### Test Case 118: Menu image failure does not break layout

- **Test ID:** MENU-118
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

### Test Case 119: Customer category tabs include all categories

- **Test ID:** MENU-119
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

### Test Case 120: Staff order entry only lists available items

- **Test ID:** MENU-120
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

### Test Case 121: Menu card text fits

- **Test ID:** MENU-121
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

### Test Case 122: Menu total uses latest price

- **Test ID:** MENU-122
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

### Test Case 123: Menu count appears on admin health

- **Test ID:** MENU-123
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

## Employees Attendance Payroll Automation Test Cases

### Test Case 124: Seed has 12 employees

- **Test ID:** EMP-124
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

### Test Case 125: Each employee has an account

- **Test ID:** EMP-125
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

### Test Case 126: Admin creates employee and account

- **Test ID:** EMP-126
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

### Test Case 127: Admin edits employee role

- **Test ID:** EMP-127
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

### Test Case 128: Admin edits salary

- **Test ID:** EMP-128
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

### Test Case 129: Admin locks employee

- **Test ID:** EMP-129
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

### Test Case 130: Username uniqueness is enforced

- **Test ID:** EMP-130
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

### Test Case 131: Default new employee password is 123

- **Test ID:** EMP-131
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

### Test Case 132: Seed attendance spans multiple months

- **Test ID:** EMP-132
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

### Test Case 133: Attendance workday is 10 hours

- **Test ID:** EMP-133
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

### Test Case 134: Payroll calculates March days

- **Test ID:** EMP-134
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

### Test Case 135: Payroll salary uses 300000 per day

- **Test ID:** EMP-135
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

### Test Case 136: Check-in creates row for today

- **Test ID:** EMP-136
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

### Test Case 137: Duplicate check-in does not duplicate day

- **Test ID:** EMP-137
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

### Test Case 138: Check-out saves end time

- **Test ID:** EMP-138
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

### Test Case 139: Attendance list can filter date

- **Test ID:** EMP-139
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

### Test Case 140: Inactive employee remains in historical payroll

- **Test ID:** EMP-140
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

### Test Case 141: Employee phone is editable

- **Test ID:** EMP-141
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

### Test Case 142: Account role can change to admin

- **Test ID:** EMP-142
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

### Test Case 143: Account role can change back to staff

- **Test ID:** EMP-143
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

## Dashboard Statistics Notifications Admin Automation Test Cases

### Test Case 144: Dashboard shows table count

- **Test ID:** ADM-144
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

### Test Case 145: Dashboard shows available count

- **Test ID:** ADM-145
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

### Test Case 146: Dashboard shows reserved count

- **Test ID:** ADM-146
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

### Test Case 147: Dashboard shows occupied count

- **Test ID:** ADM-147
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

### Test Case 148: Dashboard shows open orders

- **Test ID:** ADM-148
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

### Test Case 149: Dashboard shows customer count

- **Test ID:** ADM-149
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

### Test Case 150: Revenue today includes only paid today

- **Test ID:** ADM-150
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

### Test Case 151: Stats month revenue works

- **Test ID:** ADM-151
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

### Test Case 152: Stats top items works

- **Test ID:** ADM-152
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

### Test Case 153: Debt open amount works

- **Test ID:** ADM-153
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

### Test Case 154: Admin health counts data

- **Test ID:** ADM-154
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

### Test Case 155: Admin export returns JSON

- **Test ID:** ADM-155
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

### Test Case 156: Reset restores seed data

- **Test ID:** ADM-156
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

### Test Case 157: Notification list shows latest

- **Test ID:** ADM-157
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

### Test Case 158: Admin creates notification

- **Test ID:** ADM-158
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

### Test Case 159: Notification audience all is visible to all roles

- **Test ID:** ADM-159
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

### Test Case 160: Notification audience staff is visible to staff

- **Test ID:** ADM-160
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

### Test Case 161: Admin web checklist displays

- **Test ID:** ADM-161
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

### Test Case 162: Admin export preview scrolls

- **Test ID:** ADM-162
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

### Test Case 163: Stats do not count debt as paid revenue

- **Test ID:** ADM-163
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

### Test Case 164: Stats can switch to another day

- **Test ID:** ADM-164
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

### Test Case 165: Stats can switch to another month

- **Test ID:** ADM-165
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

### Test Case 166: Stats can switch to another year

- **Test ID:** ADM-166
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

### Test Case 167: Stats date picker changes anchor date

- **Test ID:** ADM-167
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

## Cross Platform And Deployment Automation Test Cases

### Test Case 168: Customer reservation appears in staff web

- **Test ID:** E2E-168
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

### Test Case 169: Customer order appears in admin invoices

- **Test ID:** E2E-169
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

### Test Case 170: Admin payment updates customer web history

- **Test ID:** E2E-170
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

### Test Case 171: Staff payment updates customer web history

- **Test ID:** E2E-171
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

### Test Case 172: Android app can use same backend as web

- **Test ID:** E2E-172
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

### Test Case 173: Staff web and admin web share backend data

- **Test ID:** E2E-173
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

### Test Case 174: Customer web and staff web use same table statuses

- **Test ID:** E2E-174
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

### Test Case 175: Backend restart keeps JSON data

- **Test ID:** E2E-175
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

### Test Case 176: Flutter web build is served from backend

- **Test ID:** E2E-176
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

### Test Case 177: Admin web path is independent from customer web

- **Test ID:** E2E-177
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

### Test Case 178: Customer web light luxury theme loads

- **Test ID:** E2E-178
- **Test Location:** Backend + Customer web + Staff web + Android app
- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.

**Steps:**
1. Open Backend + Customer web + Staff web + Android app.
2. Open /customer/.
3. Refresh the related web/app screen or call the related API endpoint.
4. Compare UI state with backend JSON/API response.

**Expected Result:**
- Palette is light ivory/gold with readable contrast.
- No crash, broken layout, duplicate orphan record, or stale status remains.

**Status:** Pending manual execution

### Test Case 179: No text overlap on customer mobile viewport

- **Test ID:** E2E-179
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

### Test Case 180: No text overlap on staff web mobile viewport

- **Test ID:** E2E-180
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

### Test Case 181: Customer payment history excludes unpaid orders

- **Test ID:** E2E-181
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

### Test Case 182: Customer payment history includes only linked customer orders

- **Test ID:** E2E-182
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

### Test Case 183: API bootstrap is complete

- **Test ID:** E2E-183
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

### Test Case 184: LAN deployment can use explicit API_BASE_URL

- **Test ID:** E2E-184
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

### Test Case 185: Emulator deployment uses fallback 10.0.2.2

- **Test ID:** E2E-185
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

### Test Case 186: USB deployment works with adb reverse

- **Test ID:** E2E-186
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

### Test Case 187: Customer web works without separate frontend server

- **Test ID:** E2E-187
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

### Test Case 188: Staff/admin web works without separate frontend server after build

- **Test ID:** E2E-188
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

### Test Case 189: Reset then all three clients read seed data

- **Test ID:** E2E-189
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

### Test Case 190: Concurrent customer and staff action stays consistent

- **Test ID:** E2E-190
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

### Test Case 191: Paid table becomes available everywhere

- **Test ID:** E2E-191
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

### Test Case 192: Health endpoint stays ok after full scenario

- **Test ID:** E2E-192
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

### Test Case 193: Android Studio can run the app

- **Test ID:** E2E-193
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

### Test Case 194: Android Studio emulator uses backend fallback

- **Test ID:** E2E-194
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

### Test Case 195: Android Studio physical device uses LAN or adb reverse

- **Test ID:** E2E-195
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

Total test cases: 195
