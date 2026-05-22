const express = require("express");
const { readDb, resetDb } = require("../store");

const router = express.Router();

router.get("/export", (req, res) => {
  res.json(readDb());
});

router.get("/health", (req, res) => {
  const db = readDb();
  res.json({
    status: "ok",
    storage: "json-file",
    tables: db.tables.length,
    menuItems: db.menu.length,
    orders: db.orders.length,
    employees: db.employees.length,
    employeeAccounts: db.users.length,
    customers: db.customers.length,
    reservations: db.reservations.length,
    debts: db.debts.length,
    generatedAt: new Date().toISOString()
  });
});

router.post("/reset", (req, res) => {
  resetDb();
  res.json({ success: true, message: "Seed data restored" });
});

module.exports = router;
