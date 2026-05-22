const express = require("express");
const { readDb, writeDb } = require("../store");
const { appendBatch, withTotals, orderTotal, canCollect } = require("../utils/orders");

const router = express.Router();

function getOpenOrderForTable(db, tableId) {
  return db.orders.find((order) => order.tableId === tableId && order.status === "open");
}

function resolveCustomer(db, body) {
  const customer = db.customers.find((item) => item.id === Number(body.customerId));
  return {
    customerId: customer?.id || body.customerId || null,
    customerName: customer?.name || body.customerName || "",
    customerPhone: customer?.phone || body.customerPhone || ""
  };
}

function closeTableForOrder(db, order) {
  const table = db.tables.find((item) => item.id === order.tableId);
  if (!table) return;
  table.status = "available";
  delete table.activeOrderId;
  const reservation = db.reservations.find((item) => item.id === Number(order.reservationId) || (item.tableId === table.id && item.status === "seated"));
  if (reservation) reservation.status = "completed";
}

router.get("/", (req, res) => {
  const db = readDb();
  const status = req.query.status;
  const orders = status ? db.orders.filter((order) => order.status === status) : db.orders;
  res.json(orders.slice().reverse().map(withTotals));
});

router.get("/table/:tableId/open", (req, res) => {
  const db = readDb();
  const order = getOpenOrderForTable(db, Number(req.params.tableId));
  res.json(order ? withTotals(order) : null);
});

router.post("/", (req, res) => {
  const db = readDb();
  const tableId = Number(req.body.tableId);
  const table = db.tables.find((item) => item.id === tableId);
  if (!table) return res.status(404).json({ message: "Khong tim thay ban" });

  const existing = getOpenOrderForTable(db, tableId);
  if (existing) return res.json(withTotals(existing));

  const staff = db.employees.find((employee) => employee.id === Number(req.body.staffId));
  const customer = resolveCustomer(db, req.body);
  const order = {
    id: db.nextIds.order++,
    tableId,
    tableName: table.name,
    staffId: staff?.id || req.body.staffId || null,
    staffName: staff?.name || req.body.staffName || "Nhan vien",
    ...customer,
    status: "open",
    source: req.body.source || "staff_app",
    createdAt: new Date().toISOString(),
    paidAt: null,
    discount: 0,
    items: []
  };
  table.status = "occupied";
  table.activeOrderId = order.id;
  db.orders.push(order);
  writeDb(db);
  res.status(201).json(withTotals(order));
});

router.post("/:id/items", (req, res) => {
  const db = readDb();
  const order = db.orders.find((item) => item.id === Number(req.params.id));
  if (!order || order.status !== "open") return res.status(404).json({ message: "Hoa don khong mo" });

  const menuItem = db.menu.find((item) => item.id === Number(req.body.menuItemId));
  if (!menuItem || !menuItem.available) return res.status(404).json({ message: "Mon khong kha dung" });

  const quantity = Number(req.body.quantity || 1);
  appendBatch(order, [{ menuItemId: menuItem.id, name: menuItem.name, price: menuItem.price, quantity }], req.body.createdBy || order.staffName);
  writeDb(db);
  res.json(withTotals(order));
});

router.post("/:id/batches", (req, res) => {
  const db = readDb();
  const order = db.orders.find((item) => item.id === Number(req.params.id));
  if (!order || order.status !== "open") return res.status(404).json({ message: "Hoa don khong mo" });

  const items = [];
  for (const row of req.body.items || []) {
    const menuItem = db.menu.find((item) => item.id === Number(row.menuItemId));
    if (!menuItem || !menuItem.available) return res.status(404).json({ message: "Mon khong kha dung" });
    const quantity = Number(row.quantity || 0);
    if (quantity > 0) {
      items.push({ menuItemId: menuItem.id, name: menuItem.name, price: menuItem.price, quantity });
    }
  }
  if (items.length === 0) return res.status(400).json({ message: "Chua co mon de xac nhan" });

  appendBatch(order, items, req.body.createdBy || order.staffName);
  writeDb(db);
  res.json(withTotals(order));
});

router.patch("/:id/items/:menuItemId", (req, res) => {
  const db = readDb();
  const order = db.orders.find((item) => item.id === Number(req.params.id));
  if (!order || order.status !== "open") return res.status(404).json({ message: "Hoa don khong mo" });
  const menuItemId = Number(req.params.menuItemId);
  const quantity = Number(req.body.quantity || 0);
  order.items = quantity <= 0
    ? order.items.filter((item) => item.menuItemId !== menuItemId)
    : order.items.map((item) => item.menuItemId === menuItemId ? { ...item, quantity } : item);
  order.batches = order.items.length
    ? [{
      id: 1,
      name: "Lan 1",
      createdAt: order.createdAt,
      createdBy: order.staffName || "Nhan vien",
      items: order.items
    }]
    : [];
  writeDb(db);
  res.json(withTotals(order));
});

router.post("/:id/pay", (req, res) => {
  if (!canCollect(req.body.role)) return res.status(403).json({ message: "Khong co quyen thu tien" });
  const db = readDb();
  const order = db.orders.find((item) => item.id === Number(req.params.id));
  if (!order || order.status !== "open") return res.status(404).json({ message: "Hoa don khong mo" });
  order.discount = Number(req.body.discount || 0);
  order.status = "paid";
  order.paidAt = new Date().toISOString();
  order.paidBy = req.body.userName || "Nhan vien";
  closeTableForOrder(db, order);
  writeDb(db);
  res.json(withTotals(order));
});

router.post("/:id/debt", (req, res) => {
  if (!canCollect(req.body.role)) return res.status(403).json({ message: "Khong co quyen ghi cong no" });
  const db = readDb();
  const order = db.orders.find((item) => item.id === Number(req.params.id));
  if (!order || order.status !== "open") return res.status(404).json({ message: "Hoa don khong mo" });
  order.discount = Number(req.body.discount || 0);
  order.status = "debt";
  order.paidAt = new Date().toISOString();
  order.customerName = req.body.customerName || "Khach le";
  order.customerPhone = req.body.customerPhone || "";
  const amount = orderTotal(order);
  const debt = {
    id: db.nextIds.debt++,
    orderId: order.id,
    customerName: order.customerName,
    customerPhone: order.customerPhone,
    amount,
    paidAmount: 0,
    status: "open",
    dueDate: req.body.dueDate || "",
    note: req.body.note || "",
    createdAt: new Date().toISOString()
  };
  db.debts.push(debt);
  closeTableForOrder(db, order);
  writeDb(db);
  res.json({ order: withTotals(order), debt });
});

module.exports = router;
