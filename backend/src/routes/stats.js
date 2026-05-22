const express = require("express");
const { readDb } = require("../store");
const { orderTotal, samePeriod } = require("../utils/orders");

const router = express.Router();

router.get("/", (req, res) => {
  const db = readDb();
  const period = req.query.period || "day";
  const date = req.query.date || new Date().toISOString();
  const paid = db.orders.filter((order) => order.status === "paid" && samePeriod(order.paidAt, period, date));
  const debts = db.debts.filter((debt) => samePeriod(debt.createdAt, period, date));
  const itemMap = new Map();

  for (const order of paid) {
    for (const item of order.items || []) {
      const current = itemMap.get(item.menuItemId) || { name: item.name, quantity: 0, revenue: 0 };
      current.quantity += Number(item.quantity || 0);
      current.revenue += Number(item.quantity || 0) * Number(item.price || 0);
      itemMap.set(item.menuItemId, current);
    }
  }

  res.json({
    period,
    date,
    orderCount: paid.length,
    revenue: paid.reduce((sum, order) => sum + orderTotal(order), 0),
    debtCreated: debts.reduce((sum, debt) => sum + Number(debt.amount || 0), 0),
    debtOpen: db.debts.filter((debt) => debt.status === "open").reduce((sum, debt) => sum + Number(debt.amount || 0) - Number(debt.paidAmount || 0), 0),
    topItems: Array.from(itemMap.values()).sort((a, b) => b.quantity - a.quantity).slice(0, 5),
    paidOrders: paid.map((order) => ({ id: order.id, tableName: order.tableName, paidAt: order.paidAt, total: orderTotal(order) }))
  });
});

module.exports = router;
