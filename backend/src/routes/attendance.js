const express = require("express");
const { readDb, writeDb } = require("../store");

const router = express.Router();

router.get("/", (req, res) => {
  const db = readDb();
  const date = req.query.date || new Date().toISOString().slice(0, 10);
  const rows = db.attendance
    .filter((row) => row.date === date)
    .map((row) => ({ ...row, employee: db.employees.find((employee) => employee.id === row.employeeId) }));
  res.json(rows);
});

router.post("/check-in", (req, res) => {
  const db = readDb();
  const employeeId = Number(req.body.employeeId);
  const date = req.body.date || new Date().toISOString().slice(0, 10);
  let row = db.attendance.find((item) => item.employeeId === employeeId && item.date === date);
  if (!row) {
    row = { id: db.nextIds.attendance++, employeeId, date, checkIn: new Date().toISOString(), checkOut: null, note: req.body.note || "" };
    db.attendance.push(row);
  }
  writeDb(db);
  res.json(row);
});

router.patch("/:id/check-out", (req, res) => {
  const db = readDb();
  const row = db.attendance.find((item) => item.id === Number(req.params.id));
  if (!row) return res.status(404).json({ message: "Khong tim thay cham cong" });
  row.checkOut = new Date().toISOString();
  row.note = req.body.note ?? row.note;
  writeDb(db);
  res.json(row);
});

module.exports = router;
