const fs = require("fs");
const path = require("path");

const { defaultPassword, seedData } = require("./seedData");
const { orderBatches, flattenBatchItems } = require("./utils/orders");

const dataDir = path.join(__dirname, "..", "data");
const dataFile = path.join(dataDir, "restaurant.json");

function maxId(items) {
  return (items || []).reduce((max, item) => Math.max(max, Number(item.id || 0)), 0);
}

function mergeSeeded(existing, seeded) {
  const byId = new Map((existing || []).map((item) => [Number(item.id), item]));
  const merged = seeded.map((item) => ({ ...item, ...(byId.get(Number(item.id)) || {}) }));
  const seededIds = new Set(seeded.map((item) => Number(item.id)));
  const extras = (existing || []).filter((item) => !seededIds.has(Number(item.id)));
  return [...merged, ...extras];
}

function normalizeStatus(status) {
  const value = String(status || "").toLowerCase();
  if (["occupied", "reserved", "available"].includes(value)) return value;
  if (["dang su dung", "dang dung", "using"].includes(value)) return "occupied";
  if (["da dat", "booked"].includes(value)) return "reserved";
  return "available";
}

function normalizeDb(db = {}) {
  const seed = seedData();
  const employees = mergeSeeded(db.employees, seed.employees).map((employee) => ({
    ...employee,
    salaryPerDay: Number(employee.salaryPerDay || 300000),
    active: employee.active ?? true
  }));

  const users = mergeSeeded(db.users, seed.users).map((user) => {
    const employee = employees.find((item) => item.id === Number(user.employeeId));
    return {
      ...user,
      password: defaultPassword,
      name: employee?.name || user.name || user.username,
      role: user.role === "admin" ? "admin" : "staff",
      active: user.active ?? employee?.active ?? true
    };
  });

  const customers = mergeSeeded(db.customers, seed.customers).map((customer) => ({
    ...customer,
    password: defaultPassword,
    active: customer.active ?? true
  }));

  const tables = mergeSeeded(db.tables, seed.tables).map((table) => ({
    ...table,
    seats: Number(table.seats || 4),
    status: normalizeStatus(table.status)
  }));

  const menu = mergeSeeded(db.menu, seed.menu).map((item) => ({
    ...item,
    price: Number(item.price || 0),
    available: item.available ?? true
  }));

  const orders = (db.orders && db.orders.length ? db.orders : seed.orders).map((order) => {
    const batches = orderBatches(order);
    return {
      ...order,
      discount: Number(order.discount || 0),
      batches,
      items: flattenBatchItems(batches)
    };
  });

  const debts = db.debts && db.debts.length ? db.debts : seed.debts;
  const attendance = db.attendance && db.attendance.length ? db.attendance : seed.attendance;
  const reservations = db.reservations && db.reservations.length ? db.reservations : seed.reservations;
  const notifications = db.notifications && db.notifications.length ? db.notifications : seed.notifications;

  const nextIds = { ...seed.nextIds, ...(db.nextIds || {}) };
  nextIds.user = Math.max(nextIds.user || 1, maxId(users) + 1);
  nextIds.employee = Math.max(nextIds.employee || 1, maxId(employees) + 1);
  nextIds.customer = Math.max(nextIds.customer || 1, maxId(customers) + 1);
  nextIds.table = Math.max(nextIds.table || 1, maxId(tables) + 1);
  nextIds.menu = Math.max(nextIds.menu || 1, maxId(menu) + 1);
  nextIds.order = Math.max(nextIds.order || 1, maxId(orders) + 1);
  nextIds.debt = Math.max(nextIds.debt || 1, maxId(debts) + 1);
  nextIds.attendance = Math.max(nextIds.attendance || 1, maxId(attendance) + 1);
  nextIds.notification = Math.max(nextIds.notification || 1, maxId(notifications) + 1);
  nextIds.reservation = Math.max(nextIds.reservation || 1, maxId(reservations) + 1);

  return {
    ...seed,
    ...db,
    users,
    employees,
    customers,
    tables,
    menu,
    orders,
    debts,
    attendance,
    notifications,
    settings: { ...seed.settings, ...(db.settings || {}) },
    reservations,
    nextIds
  };
}

function ensureStore() {
  fs.mkdirSync(dataDir, { recursive: true });
  if (!fs.existsSync(dataFile)) {
    fs.writeFileSync(dataFile, JSON.stringify(seedData(), null, 2));
    return;
  }
  writeDb(normalizeDb(JSON.parse(fs.readFileSync(dataFile, "utf8"))));
}

function readDb() {
  ensureStore();
  return normalizeDb(JSON.parse(fs.readFileSync(dataFile, "utf8")));
}

function writeDb(db) {
  fs.writeFileSync(dataFile, JSON.stringify(db, null, 2));
}

function resetDb() {
  writeDb(seedData());
}

module.exports = { ensureStore, readDb, writeDb, resetDb };
