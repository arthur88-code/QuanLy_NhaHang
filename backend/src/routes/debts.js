const express = require("express");
const { readDb, writeDb } = require("../store");
const { canCollect } = require("../utils/orders");

const router = express.Router();

router.get("/", (req, res) => {
  const db = readDb();
  const status = req.query.status;
  const debts = status ? db.debts.filter((debt) => debt.status === status) : db.debts;
  res.json(debts.slice().reverse());
});

router.patch("/:id/pay", (req, res) => {
  if (!canCollect(req.body.role)) return res.status(403).json({ message: "Khong co quyen thu cong no" });
  const db = readDb();
  const debt = db.debts.find((item) => item.id === Number(req.params.id));
  if (!debt) return res.status(404).json({ message: "Khong tim thay cong no" });
  debt.paidAmount = Number(debt.paidAmount || 0) + Number(req.body.amount || 0);
  if (debt.paidAmount >= Number(debt.amount || 0)) {
    debt.status = "paid";
    debt.paidAt = new Date().toISOString();
  }
  writeDb(db);
  res.json(debt);
});

module.exports = router;
