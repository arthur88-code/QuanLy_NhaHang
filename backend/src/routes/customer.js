const express = require("express");
const { readDb, writeDb } = require("../store");
const { appendBatch, withTotals } = require("../utils/orders");

const router = express.Router();

function safeCustomer(customer) {
  if (!customer) return null;
  const { password: _password, ...safe } = customer;
  return safe;
}

function findCustomer(db, customerId) {
  return db.customers.find((item) => item.id === Number(customerId) && item.active !== false);
}

function orderItemsFromMenu(db, rows) {
  const items = [];
  for (const row of rows || []) {
    const menuItem = db.menu.find((item) => item.id === Number(row.menuItemId) && item.available !== false);
    if (!menuItem) return null;
    const quantity = Number(row.quantity || 0);
    if (quantity <= 0) continue;
    items.push({ menuItemId: menuItem.id, name: menuItem.name, price: menuItem.price, quantity });
  }
  return items;
}

function pushNotification(db, title, body) {
  db.notifications.push({
    id: db.nextIds.notification++,
    title,
    body,
    audience: "staff",
    createdAt: new Date().toISOString()
  });
}

router.get("/bootstrap", (req, res) => {
  const db = readDb();
  const customer = findCustomer(db, req.query.customerId);
  res.json({
    settings: db.settings,
    customer: safeCustomer(customer),
    tables: db.tables,
    menu: db.menu.filter((item) => item.available !== false),
    reservations: customer ? db.reservations.filter((item) => item.customerId === customer.id).slice().reverse() : [],
    orders: customer ? db.orders.filter((item) => item.customerId === customer.id).slice().reverse().map(withTotals) : [],
    paidOrders: customer ? db.orders.filter((item) => item.customerId === customer.id && item.status === "paid").slice().reverse().map(withTotals) : []
  });
});

router.get("/paid-history", (req, res) => {
  const db = readDb();
  const customer = findCustomer(db, req.query.customerId);
  if (!customer) return res.status(404).json({ message: "Khong tim thay khach hang" });
  res.json(db.orders.filter((item) => item.customerId === customer.id && item.status === "paid").slice().reverse().map(withTotals));
});

router.get("/reservations", (req, res) => {
  const db = readDb();
  const customer = findCustomer(db, req.query.customerId);
  if (!customer) return res.status(404).json({ message: "Khong tim thay khach hang" });
  res.json(db.reservations.filter((item) => item.customerId === customer.id).slice().reverse());
});

router.post("/reservations", (req, res) => {
  const db = readDb();
  const customer = findCustomer(db, req.body.customerId);
  if (!customer) return res.status(404).json({ message: "Khong tim thay khach hang" });
  const table = db.tables.find((item) => item.id === Number(req.body.tableId));
  if (!table) return res.status(404).json({ message: "Khong tim thay ban" });
  if (table.status !== "available") return res.status(409).json({ message: "Ban nay khong con trong" });

  const reservation = {
    id: db.nextIds.reservation++,
    tableId: table.id,
    tableName: table.name,
    customerId: customer.id,
    customerName: customer.name,
    customerPhone: customer.phone,
    partySize: Number(req.body.partySize || table.seats || 1),
    reservedAt: req.body.reservedAt || new Date().toISOString(),
    status: "confirmed",
    note: req.body.note || "",
    createdAt: new Date().toISOString()
  };
  table.status = "reserved";
  table.reservationId = reservation.id;
  db.reservations.push(reservation);
  pushNotification(db, "Khach dat ban", `${customer.name} dat ${table.name} luc ${reservation.reservedAt}.`);
  writeDb(db);
  res.status(201).json({ reservation, table });
});

router.post("/orders", (req, res) => {
  const db = readDb();
  const customer = findCustomer(db, req.body.customerId);
  if (!customer) return res.status(404).json({ message: "Khong tim thay khach hang" });
  const table = db.tables.find((item) => item.id === Number(req.body.tableId));
  if (!table) return res.status(404).json({ message: "Khong tim thay ban" });
  const items = orderItemsFromMenu(db, req.body.items);
  if (!items || items.length === 0) return res.status(400).json({ message: "Chua chon mon hop le" });

  const openOrder = db.orders.find((order) => order.tableId === table.id && order.status === "open");
  if (openOrder) {
    if (Number(openOrder.customerId) !== Number(customer.id)) {
      return res.status(409).json({ message: "Ban dang co hoa don cua khach khac" });
    }
    appendBatch(openOrder, items, customer.name);
    pushNotification(db, "Khach goi them mon", `${customer.name} vua goi them mon cho ${table.name}.`);
    writeDb(db);
    return res.json({ order: withTotals(openOrder), table });
  }

  let reservation = null;
  if (table.status === "reserved") {
    reservation = db.reservations.find((item) => item.id === Number(req.body.reservationId || table.reservationId));
    if (!reservation || Number(reservation.customerId) !== Number(customer.id)) {
      return res.status(409).json({ message: "Ban da duoc khach khac dat truoc" });
    }
    reservation.status = "seated";
  } else if (table.status !== "available") {
    return res.status(409).json({ message: "Ban dang duoc su dung" });
  }

  const order = {
    id: db.nextIds.order++,
    tableId: table.id,
    tableName: table.name,
    reservationId: reservation?.id || null,
    staffId: null,
    staffName: "Khach hang dat qua web",
    customerId: customer.id,
    customerName: customer.name,
    customerPhone: customer.phone,
    status: "open",
    source: "customer_web",
    createdAt: new Date().toISOString(),
    paidAt: null,
    discount: 0,
    note: req.body.note || "",
    items: [],
    batches: []
  };
  appendBatch(order, items, customer.name);

  table.status = "occupied";
  table.activeOrderId = order.id;
  delete table.reservationId;
  db.orders.push(order);
  pushNotification(db, "Khach goi mon", `${customer.name} tao hoa don #${order.id} tai ${table.name}.`);
  writeDb(db);
  res.status(201).json({ order: withTotals(order), table });
});

module.exports = router;
