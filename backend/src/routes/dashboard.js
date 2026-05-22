const express = require("express");
const { readDb } = require("../store");
const { orderTotal, withTotals, samePeriod } = require("../utils/orders");

const router = express.Router();

router.get("/", (req, res) => {
  const db = readDb();
  const paidToday = db.orders.filter((order) => order.status === "paid" && samePeriod(order.paidAt, "day", new Date()));
  const openDebts = db.debts.filter((debt) => debt.status === "open");
  res.json({
    tableCount: db.tables.length,
    availableTables: db.tables.filter((table) => table.status === "available").length,
    reservedTables: db.tables.filter((table) => table.status === "reserved").length,
    occupiedTables: db.tables.filter((table) => table.status === "occupied").length,
    openOrders: db.orders.filter((order) => order.status === "open").length,
    menuItems: db.menu.length,
    employeeCount: db.employees.filter((employee) => employee.active).length,
    customerCount: db.customers.filter((customer) => customer.active !== false).length,
    activeReservations: db.reservations.filter((reservation) => ["confirmed", "seated"].includes(reservation.status)).length,
    openDebtAmount: openDebts.reduce((sum, debt) => sum + Number(debt.amount || 0) - Number(debt.paidAmount || 0), 0),
    revenueToday: paidToday.reduce((sum, order) => sum + orderTotal(order), 0),
    heroImageUrl: db.settings.heroImageUrl,
    recentOrders: db.orders.slice(-5).reverse().map(withTotals),
    notifications: db.notifications.slice(-3).reverse()
  });
});

module.exports = router;
