const express = require("express");
const { readDb } = require("../store");

const router = express.Router();

function hoursBetween(start, end) {
  if (!start || !end) return 0;
  return Math.max((new Date(end).getTime() - new Date(start).getTime()) / 3600000, 0);
}

router.get("/", (req, res) => {
  const db = readDb();
  const month = req.query.month || new Date().toISOString().slice(0, 7);
  const rows = db.employees.map((employee) => {
    const attendance = db.attendance.filter((row) => row.employeeId === employee.id && String(row.date).startsWith(month));
    const days = attendance.length;
    const hours = attendance.reduce((sum, row) => sum + hoursBetween(row.checkIn, row.checkOut), 0);
    const salary = days * Number(employee.salaryPerDay || 0);
    return { employee, days, hours: Math.round(hours * 10) / 10, salary };
  });
  res.json({ month, rows, totalSalary: rows.reduce((sum, row) => sum + row.salary, 0) });
});

module.exports = router;
