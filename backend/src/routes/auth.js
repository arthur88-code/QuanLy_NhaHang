const express = require("express");
const { readDb } = require("../store");

const router = express.Router();

router.post("/login", (req, res) => {
  const { username, password } = req.body;
  const db = readDb();
  const user = db.users.find((item) => item.username === username && item.password === password && item.active !== false);
  if (!user) return res.status(401).json({ success: false, message: "Sai tai khoan hoac mat khau" });
  const employee = db.employees.find((item) => item.id === user.employeeId);
  const { password: _password, ...safeUser } = user;
  res.json({ success: true, user: { ...safeUser, employee } });
});

router.post("/customer-login", (req, res) => {
  const { username, password } = req.body;
  const db = readDb();
  const customer = db.customers.find((item) => item.username === username && item.password === password && item.active !== false);
  if (!customer) return res.status(401).json({ success: false, message: "Sai tai khoan khach hang hoac mat khau" });
  const { password: _password, ...safeCustomer } = customer;
  res.json({ success: true, customer: safeCustomer });
});

module.exports = router;
