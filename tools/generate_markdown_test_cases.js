const fs = require("fs");
const path = require("path");

const outFile = path.join(__dirname, "..", "Document", "test-cases", "all-test-cases-expandtesting-style.md");
const today = "22/05/2026";

const groups = [
  {
    title: "Authentication And Accounts",
    prefix: "AUTH",
    location: "Customer web / Staff web / Admin web / Android app",
    cases: [
      ["Admin login succeeds with password 123", "Login with admin/123.", "Dashboard opens and admin-only modules are visible."],
      ["Staff login succeeds with password 123", "Login with staff/123.", "Dashboard opens and staff can operate tables, menu, invoices, attendance."],
      ["Accountant login succeeds with password 123", "Login with accountant/123.", "Attendance and payroll-related data can be accessed according to staff permissions."],
      ["Customer login succeeds with password 123", "Login on customer web with customer001/123.", "Customer workspace opens with menu, tables, reservations and history."],
      ["Wrong password is rejected", "Submit a valid username with an invalid password.", "Login remains on the form and shows an error."],
      ["Unknown username is rejected", "Submit a username that does not exist.", "System returns a clear authentication error."],
      ["Empty username is rejected", "Leave username empty and submit.", "System does not create a session."],
      ["Empty password is rejected", "Leave password empty and submit.", "System does not create a session."],
      ["Password is not returned in employee login response", "Call POST /auth/login.", "Response contains user data without password."],
      ["Password is not returned in customer login response", "Call POST /auth/customer-login.", "Response contains customer data without password."],
      ["Locked employee account cannot login", "Disable an employee from admin and retry login.", "Login fails for that employee account."],
      ["Admin can edit an employee account username", "Open employee management and change username.", "New username works and old username no longer works."],
      ["Admin can reset employee password to 123", "Edit employee and set password 123.", "Employee can login with the reset password."],
      ["Staff cannot see admin-only navigation", "Login as staff.", "Employee management, payroll admin and web admin tools are hidden."],
      ["Admin sees admin-only navigation", "Login as admin.", "Employee management, notifications, payroll and web admin tools are visible."],
      ["Session can logout on customer web", "Login customer then click logout.", "Customer returns to the login screen."],
      ["Customer local session reloads safely", "Login customer and refresh page.", "Customer session reloads from local storage and data is fetched again."],
      ["Invalid stored customer session does not crash", "Put invalid session JSON in local storage and reload.", "Login screen is shown or session is cleared safely."],
      ["Web staff path serves app", "Open /staff/.", "Flutter staff/admin login page loads."],
      ["Web admin path serves app", "Open /admin-web/.", "Flutter staff/admin login page loads."]
    ]
  },
  {
    title: "Customer Web Reservations And Orders",
    prefix: "CUST",
    location: "http://127.0.0.1:3000/customer/",
    cases: [
      ["Customer sees available tables", "Login as customer001 and open table area.", "Available, reserved and occupied tables are displayed with correct colors."],
      ["Customer reserves an available table", "Select an available table and submit reservation.", "Table changes to reserved and reservation appears in history."],
      ["Customer cannot reserve occupied table", "Try selecting an occupied table.", "Occupied table is disabled for customer."],
      ["Customer cannot reserve another customer's reserved table", "Try ordering on a reserved table without matching reservation.", "System blocks the action."],
      ["Customer can order on own reserved table", "Reserve a table, switch to order mode and submit cart.", "Order is created and table changes to occupied."],
      ["Customer order requires at least one menu item", "Submit order mode with empty cart.", "System shows validation error."],
      ["Customer cart quantity increases", "Click Add item twice.", "Cart quantity and total increase correctly."],
      ["Customer cart quantity decreases", "Click minus on a cart item.", "Cart quantity and total decrease correctly."],
      ["Customer cart removes zero quantity item", "Reduce quantity to zero.", "Item disappears from cart."],
      ["Customer filters menu by category", "Click a category tab.", "Only matching category items are shown."],
      ["Customer refresh keeps server state", "Create reservation then refresh page.", "Reservation still exists from backend data."],
      ["Customer web polls latest table state", "Change a table from admin/staff and wait or refresh.", "Customer web shows new table state."],
      ["Customer paid history lists paid invoices", "Open payment history for customer001.", "Paid invoices show total, paidAt and paidBy."],
      ["Customer open order appears in order history", "Submit a web order and view history.", "Order appears with status open."],
      ["Paid customer order moves to paid history", "Admin pays a customer web order.", "Customer web shows it under payment history after reload."],
      ["Customer order is linked to customer account", "Create order through customer web.", "Order has customerId, customerName and customerPhone."],
      ["Customer reservation is linked to customer account", "Create reservation through customer web.", "Reservation has customerId and customer phone."],
      ["Customer can add items to own open order", "Submit order again on same table/customer.", "Existing open order receives more items."],
      ["Customer cannot add to another customer open order", "Use different customer for a table with open order.", "System returns conflict."],
      ["Customer note is saved on order", "Submit order with note.", "Order note is stored in backend export."],
      ["Reservation note is saved", "Submit reservation with note.", "Reservation note appears in history and backend export."],
      ["Party size saves correctly", "Reserve table with party size 6.", "Reservation stores partySize=6."],
      ["Reservation default time is valid", "Open page and inspect datetime field.", "Field contains a future local datetime."],
      ["Customer web handles API error", "Stop backend then submit action.", "User sees a clear error and page does not freeze."],
      ["Customer web image fallback works", "Break an image URL and reload.", "Layout remains usable without broken text overlap."]
      ,["Customer web uses white black ocean palette", "Open customer web and inspect main surfaces.", "Customer web uses white background, black text and ocean blue primary actions."]
    ]
  },
  {
    title: "Staff And Admin Table Flow",
    prefix: "TABLE",
    location: "Flutter app / /staff/ / /admin-web/",
    cases: [
      ["Staff sees all 16 seeded tables", "Login staff and open Tables.", "Sixteen tables are listed after reset."],
      ["Table cards show three statuses", "Open Tables after reset.", "Available, reserved and occupied labels are visible."],
      ["Staff opens available table", "Tap an available table.", "Order entry screen opens."],
      ["Staff order on available table changes status occupied", "Add a menu item from order entry.", "Table becomes occupied and open invoice is created."],
      ["Staff-created order does not require customer account", "Create order from staff app without customer fields.", "Order customerId is null or empty and order still works."],
      ["Staff can add multiple menu items", "Add three different menu items.", "Invoice contains all selected items."],
      ["Staff can increase item quantity", "Tap plus on an order item.", "Quantity and total increase."],
      ["Staff can decrease item quantity", "Tap minus on an order item.", "Quantity and total decrease."],
      ["Quantity zero removes item", "Decrease item to zero.", "Item is removed from invoice."],
      ["One table cannot have two open invoices", "Create order twice for same table.", "System returns existing open order."],
      ["Admin can add table", "Long press/open add table form.", "New table appears and nextIds updates."],
      ["Admin can edit table", "Edit name, seats and area.", "Table card shows updated values."],
      ["Admin can delete available table", "Delete a table with no open order.", "Table is removed."],
      ["Cannot delete table with open order", "Try deleting occupied table with open order.", "API blocks with conflict."],
      ["Reserved table remains reserved until order starts", "Create reservation only.", "Table status is reserved."],
      ["Reserved table changes occupied when customer orders", "Customer orders on reserved table.", "Admin/staff table status shows occupied."],
      ["Paid invoice returns table available", "Pay an open invoice.", "Table status changes to available."],
      ["Debt invoice returns table available", "Record debt for an open invoice.", "Table status changes to available and debt is created."],
      ["Table refresh updates cross-platform change", "Change table status on customer web and refresh staff web.", "Staff web displays the new status."],
      ["Dashboard counts table statuses", "Open dashboard.", "Available/reserved/occupied counts match table list."]
      ,["Selecting menu item does not create invoice immediately", "Open an available table and tap a menu item once.", "Item appears in temporary selected list and no invoice is written until confirmation."]
      ,["Top clear button removes all selected menu items", "Select several menu items then click clear selected list on top.", "Temporary list becomes empty and order is unchanged."]
      ,["Cancel selected menu list stops current selection", "Select items and click Huy bo.", "Temporary selected list is cleared without changing invoice."]
      ,["Confirm selected menu list creates batch one", "Select items on an empty table and confirm.", "Invoice is created, table becomes occupied and batch Lan 1 stores selected items."]
      ,["Occupied table can receive additional batch", "Open an occupied table with open invoice, select more items and confirm.", "Existing invoice receives batch Lan 2 and total increases."]
      ,["Third confirmation creates batch three", "Confirm another selected list on the same open invoice.", "Invoice shows Lan 3 under previous batches."]
      ,["Invoice total sums all batches", "Create at least two batches on one table.", "Invoice total equals the sum of every item in all batches."]
    ]
  },
  {
    title: "Invoices Payment Debt And Customer Links",
    prefix: "INV",
    location: "Orders API / Invoices screen / Customer history",
    cases: [
      ["Admin sees seeded paid invoices", "Open invoices after reset.", "At least six paid invoices are present."],
      ["Admin sees seeded open invoices", "Open invoices after reset.", "At least two open invoices are present."],
      ["Admin sees seeded debts", "Open debt screen after reset.", "Seeded debt records are present."],
      ["Pay open invoice as admin", "POST /orders/:id/pay with role admin.", "Order status becomes paid and paidBy is saved."],
      ["Pay open invoice as staff", "POST /orders/:id/pay with role staff.", "Order status becomes paid and paidBy is saved."],
      ["Unknown role cannot pay invoice", "POST /orders/:id/pay with role guest.", "API returns 403."],
      ["Cannot pay already paid invoice", "Pay the same invoice twice.", "Second attempt returns not open error."],
      ["Payment discount changes total", "Pay with discount 10000.", "Order total equals subtotal minus discount."],
      ["Customer-web invoice payment appears in customer paid history", "Create customer order then pay it from admin.", "Paid order is returned by /customer-api/paid-history."],
      ["Staff-created invoice payment does not appear in customer paid history", "Create staff order without customerId and pay.", "No customer paid history receives the invoice."],
      ["Staff can manually enter debt customer name", "Record debt with customerName and phone.", "Debt stores entered customer info."],
      ["Debt amount equals order total", "Record debt on an invoice.", "Debt amount matches order total after discount."],
      ["Debt keeps order item details", "Open debt-linked order.", "Order items remain intact."],
      ["Invoices list newest first", "Call GET /orders.", "Most recent order appears first."],
      ["Filter open orders works", "Call GET /orders?status=open.", "Only open orders are returned."],
      ["Get open order by table works", "Call /orders/table/:tableId/open.", "Open order or null is returned correctly."],
      ["Paid order cannot receive new item", "POST item to paid order.", "API rejects because invoice is not open."],
      ["Invalid menu item is rejected", "Add item with unknown menuItemId.", "API returns item unavailable/not found."],
      ["Unavailable menu item is rejected", "Disable menu item and add it.", "API rejects unavailable item."],
      ["Invoice totals survive server restart", "Create invoice then restart backend.", "Invoice total is still correct from JSON data."],
      ["Invoice includes source customer_web", "Create order from customer web.", "Order source is customer_web."],
      ["Invoice includes source staff_app", "Create order from staff/admin app.", "Order source is staff_app."],
      ["Customer order stores phone", "Create customer order.", "Order customerPhone matches customer account."],
      ["Payment closes seated reservation", "Order from reservation then pay.", "Reservation status becomes completed."],
      ["Debt closes seated reservation", "Order from reservation then record debt.", "Reservation status becomes completed."]
      ,["Invoice filter All returns every status", "Open invoices and choose Tat ca.", "Paid, open and debt invoices can appear in the list."]
      ,["Invoice filter Paid returns only paid", "Choose Da tra filter.", "Only invoices with status paid are listed."]
      ,["Invoice filter Open returns active tables", "Choose Dang dung filter.", "Only open invoices for occupied tables are listed."]
      ,["Clicking invoice expands details", "Click an invoice card.", "Customer info, staff info, batches, items and total are visible."]
      ,["Invoice details show batch labels", "Open an invoice with several confirmations.", "Lan 1, Lan 2 and later batches are displayed separately."]
    ]
  },
  {
    title: "Menu Catalog Images And Categories",
    prefix: "MENU",
    location: "Menu API / Staff app / Customer web",
    cases: [
      ["Seed menu has at least 40 items", "Reset data and call GET /menu.", "At least 40 menu items exist."],
      ["Seed menu has drinks", "Filter menu category Do uong.", "Drink items are present."],
      ["Seed menu has snacks", "Filter menu category An vat.", "Snack items are present."],
      ["Seed menu has main dishes", "Filter menu category Mon chinh.", "Main dish items are present."],
      ["Seed menu has desserts", "Filter menu category Trang mieng.", "Dessert items are present."],
      ["Every menu item has imageUrl", "Inspect GET /menu response.", "Each item has a non-empty imageUrl."],
      ["Food image URL uses item-specific query", "Inspect seeded imageUrl.", "Image query contains terms related to item name."],
      ["Admin can add menu item", "Create new menu item.", "Item appears in menu list and customer web if available."],
      ["Admin can edit menu price", "Update price of an item.", "New price appears in app and web."],
      ["Admin can edit menu category", "Update category of an item.", "Item moves to new category tab."],
      ["Admin can hide menu item", "Set available=false.", "Item does not appear in order entry/customer web."],
      ["Admin can re-enable menu item", "Set available=true.", "Item appears again."],
      ["Delete menu item removes it", "Delete a menu item.", "Item is absent from menu list."],
      ["Invalid price is handled", "Submit non-numeric price.", "System normalizes or rejects without crash."],
      ["Menu image failure does not break layout", "Use a bad image URL.", "Fallback/empty image area keeps layout stable."],
      ["Customer category tabs include all categories", "Open customer web menu.", "Tabs match menu categories."],
      ["Staff order entry only lists available items", "Disable an item then open order entry.", "Disabled item is hidden."],
      ["Menu card text fits", "Inspect long item name.", "Text does not overflow card."],
      ["Menu total uses latest price", "Update item price then add to order.", "Order item price uses updated value."],
      ["Menu count appears on admin health", "Call /admin/health.", "menuItems equals menu array length."]
    ]
  },
  {
    title: "Employees Attendance Payroll",
    prefix: "EMP",
    location: "Employees / Attendance / Payroll",
    cases: [
      ["Seed has 12 employees", "Reset and call /employees.", "Twelve employees are returned."],
      ["Each employee has an account", "Inspect /employees response.", "Each employee has account username and role."],
      ["Admin creates employee and account", "Create employee from admin screen.", "Employee and login account are created."],
      ["Admin edits employee role", "Change role field.", "Role updates in list."],
      ["Admin edits salary", "Change salaryPerDay.", "Payroll uses new salary."],
      ["Admin locks employee", "Delete/lock employee.", "Employee active=false and account cannot login."],
      ["Username uniqueness is enforced", "Create employee with existing username.", "System generates or rejects duplicate safely."],
      ["Default new employee password is 123", "Create employee without password.", "Employee can login with 123."],
      ["Seed attendance spans multiple months", "Inspect /attendance and payroll for March-May.", "Attendance data exists across months."],
      ["Attendance workday is 10 hours", "Inspect seeded checkIn/checkOut.", "08:00-18:00 equals 10 hours."],
      ["Payroll calculates March days", "Call /payroll?month=2026-03.", "Days and salary match attendance rows."],
      ["Payroll salary uses 300000 per day", "Check employee with 21 days.", "Salary equals 6,300,000 VND."],
      ["Check-in creates row for today", "POST /attendance/check-in.", "Row is created or existing row returned."],
      ["Duplicate check-in does not duplicate day", "Call check-in twice same employee/date.", "Only one row exists for that employee/date."],
      ["Check-out saves end time", "PATCH /attendance/:id/check-out.", "checkOut becomes non-null."],
      ["Attendance list can filter date", "GET /attendance?date=2026-03-03.", "Rows for only that date return."],
      ["Inactive employee remains in historical payroll", "Deactivate employee with past attendance.", "Historical rows still calculate without data loss."],
      ["Employee phone is editable", "Edit phone.", "New phone appears in employee list."],
      ["Account role can change to admin", "Edit accountRole admin.", "Employee can login and see admin features."],
      ["Account role can change back to staff", "Edit accountRole staff.", "Employee no longer sees admin-only features."]
    ]
  },
  {
    title: "Dashboard Statistics Notifications Admin",
    prefix: "ADM",
    location: "Dashboard / Stats / Notifications / Admin export",
    cases: [
      ["Dashboard shows table count", "Open dashboard.", "Table count equals /tables length."],
      ["Dashboard shows available count", "Open dashboard.", "Available count equals tables with available status."],
      ["Dashboard shows reserved count", "Open dashboard.", "Reserved count equals tables with reserved status."],
      ["Dashboard shows occupied count", "Open dashboard.", "Occupied count equals tables with occupied status."],
      ["Dashboard shows open orders", "Open dashboard.", "Open order count equals /orders?status=open."],
      ["Dashboard shows customer count", "Open dashboard.", "Customer count equals active customers."],
      ["Revenue today includes only paid today", "Pay an invoice today then open dashboard.", "Revenue today increases by invoice total."],
      ["Stats month revenue works", "Call /stats?period=month.", "Only paid orders in month are included."],
      ["Stats top items works", "Call stats after paid orders.", "Top items include quantity and revenue."],
      ["Debt open amount works", "Create debt and open dashboard.", "Open debt amount increases."],
      ["Admin health counts data", "Call /admin/health.", "Counts match exported arrays."],
      ["Admin export returns JSON", "Call /admin/export.", "Export includes users, employees, customers, tables, menu and orders."],
      ["Reset restores seed data", "POST /admin/reset.", "Counts return to seed values."],
      ["Notification list shows latest", "Open dashboard.", "Latest notifications are visible."],
      ["Admin creates notification", "Create notification from admin screen.", "Staff can see new notification."],
      ["Notification audience all is visible to all roles", "Create audience all.", "Admin and staff both see it."],
      ["Notification audience staff is visible to staff", "Create audience staff.", "Staff sees it in notifications."],
      ["Admin web checklist displays", "Open web admin screen.", "Operational checklist appears."],
      ["Admin export preview scrolls", "Open web admin screen.", "Large JSON preview is selectable and constrained."],
      ["Stats do not count debt as paid revenue", "Create debt order.", "Revenue does not include debt order as paid revenue."]
      ,["Stats can switch to another day", "Open stats and move to previous day.", "Metrics reload for the selected day."]
      ,["Stats can switch to another month", "Choose month mode and move previous/next.", "Metrics reload for the selected month."]
      ,["Stats can switch to another year", "Choose year mode and move previous/next.", "Metrics reload for the selected year."]
      ,["Stats date picker changes anchor date", "Use the calendar button to choose a date.", "Stats API is called with the selected date."]
    ]
  },
  {
    title: "Cross Platform And Deployment",
    prefix: "E2E",
    location: "Backend + Customer web + Staff web + Android app",
    cases: [
      ["Customer reservation appears in staff web", "Reserve from customer web then open /staff/.", "Staff table list shows reserved."],
      ["Customer order appears in admin invoices", "Order from customer web then open /admin-web/ invoices.", "Open invoice appears."],
      ["Admin payment updates customer web history", "Pay customer order from admin web.", "Customer payment history shows paid invoice."],
      ["Staff payment updates customer web history", "Pay customer order from staff app.", "Customer payment history shows paid invoice."],
      ["Android app can use same backend as web", "Build app with proper API_BASE_URL or adb reverse.", "App reads the same tables/orders as web."],
      ["Staff web and admin web share backend data", "Create table in admin web and view staff web.", "New table appears after refresh."],
      ["Customer web and staff web use same table statuses", "Change status via customer flow.", "Staff/admin see same status."],
      ["Backend restart keeps JSON data", "Create data then restart backend.", "Data persists from restaurant.json."],
      ["Flutter web build is served from backend", "Open /staff/ after flutter build web.", "Web app loads from backend server."],
      ["Admin web path is independent from customer web", "Open /admin-web/ and /customer/ in two tabs.", "Both apps load different UIs."],
      ["Customer web light luxury theme loads", "Open /customer/.", "Palette is light ivory/gold with readable contrast."],
      ["No text overlap on customer mobile viewport", "Resize customer web to mobile width.", "Buttons, cards and history rows do not overlap."],
      ["No text overlap on staff web mobile viewport", "Resize /staff/ to mobile width.", "Flutter layout remains usable."],
      ["Customer payment history excludes unpaid orders", "Create open order and inspect payment list.", "Open order does not appear in paid history."],
      ["Customer payment history includes only linked customer orders", "Pay staff-created order without customerId.", "Customer paid history is unchanged."],
      ["API bootstrap is complete", "Call /customer-api/bootstrap.", "Response includes settings, customer, tables, menu, reservations, orders and paidOrders."],
      ["LAN deployment can use explicit API_BASE_URL", "Build app with LAN IP.", "Installed app connects to backend on same network."],
      ["Emulator deployment uses fallback 10.0.2.2", "Run app on Android emulator without dart-define.", "App tries backend at 10.0.2.2:3000."],
      ["USB deployment works with adb reverse", "Run adb reverse tcp:3000 tcp:3000.", "Installed debug app can reach localhost backend."],
      ["Customer web works without separate frontend server", "Run only backend and open /customer/.", "Customer web loads and calls same backend."],
      ["Staff/admin web works without separate frontend server after build", "Run backend and open /staff/.", "Flutter web loads from backend build output."],
      ["Reset then all three clients read seed data", "POST /reset then refresh customer/staff/admin.", "All clients show seed counts and statuses."],
      ["Concurrent customer and staff action stays consistent", "Customer orders while staff views tables.", "Only one open order exists and status is occupied."],
      ["Paid table becomes available everywhere", "Pay any open order.", "Customer/staff/admin all show table available after refresh."],
      ["Health endpoint stays ok after full scenario", "Run reservation, order, pay, employee edit then call health.", "Health status remains ok."]
      ,["Android Studio can run the app", "Open frontend/android in Android Studio and run the debug configuration.", "App launches and connects to backend when API URL is reachable."]
      ,["Android Studio emulator uses backend fallback", "Run app from Android Studio on emulator with backend running locally.", "App can reach backend through emulator fallback or explicit dart define."]
      ,["Android Studio physical device uses LAN or adb reverse", "Run app from Android Studio on a phone.", "App connects when adb reverse is active or API_BASE_URL uses the computer LAN IP."]
    ]
  }
];

function testCaseMarkdown(group, test, number) {
  const id = `${group.prefix}-${String(number).padStart(3, "0")}`;
  return [
    `### Test Case ${number}: ${test[0]}`,
    "",
    `- **Test ID:** ${id}`,
    `- **Test Location:** ${group.location}`,
    "- **Preconditions:** Backend is running at `http://127.0.0.1:3000`; demo data has been reset unless the case says otherwise.",
    "",
    "**Steps:**",
    `1. Open ${group.location}.`,
    `2. ${test[1]}`,
    "3. Refresh the related web/app screen or call the related API endpoint.",
    "4. Compare UI state with backend JSON/API response.",
    "",
    "**Expected Result:**",
    `- ${test[2]}`,
    "- No crash, broken layout, duplicate orphan record, or stale status remains.",
    "",
    "**Status:** Pending manual execution",
    ""
  ].join("\n");
}

let index = 1;
const lines = [
  "# Restaurant Management System - ExpandTesting Style Test Cases",
  "",
  `Generated: ${today}`,
  "",
  "Format note: this file follows the same simple reading style as ExpandTesting practice test case pages: section title, `### Test Case n`, numbered steps, and expected result.",
  "",
  "Accounts used by the cases:",
  "",
  "- Admin/staff web and app: `admin / 123`, `staff / 123`, `accountant / 123`, `waiter03 / 123`.",
  "- Customer web: `customer001 / 123` through `customer100 / 123`.",
  "",
  "Main URLs:",
  "",
  "- Customer web: `http://127.0.0.1:3000/customer/`",
  "- Staff web: `http://127.0.0.1:3000/staff/`",
  "- Admin web: `http://127.0.0.1:3000/admin-web/`",
  "- Backend API: `http://127.0.0.1:3000`",
  ""
];

for (const group of groups) {
  lines.push(`## ${group.title} Automation Test Cases`, "");
  for (const test of group.cases) {
    lines.push(testCaseMarkdown(group, test, index));
    index += 1;
  }
}

lines.push(`Total test cases: ${index - 1}`, "");

fs.mkdirSync(path.dirname(outFile), { recursive: true });
fs.writeFileSync(outFile, lines.join("\n"), "utf8");
console.log(`created=${outFile}`);
console.log(`total_cases=${index - 1}`);
