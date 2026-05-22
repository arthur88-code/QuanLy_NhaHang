const express = require("express");
const { readDb, writeDb } = require("../store");

const router = express.Router();

router.get("/", (req, res) => {
  res.json(readDb().tables);
});

router.post("/", (req, res) => {
  const db = readDb();
  const table = {
    id: db.nextIds.table++,
    name: req.body.name || `Ban ${db.nextIds.table}`,
    seats: Number(req.body.seats || 4),
    area: req.body.area || "Tang 1",
    status: req.body.status || "available"
  };
  db.tables.push(table);
  writeDb(db);
  res.status(201).json(table);
});

router.patch("/:id", (req, res) => {
  const db = readDb();
  const table = db.tables.find((item) => item.id === Number(req.params.id));
  if (!table) return res.status(404).json({ message: "Khong tim thay ban" });
  Object.assign(table, {
    name: req.body.name ?? table.name,
    seats: req.body.seats == null ? table.seats : Number(req.body.seats),
    area: req.body.area ?? table.area,
    status: req.body.status ?? table.status
  });
  writeDb(db);
  res.json(table);
});

router.delete("/:id", (req, res) => {
  const db = readDb();
  const id = Number(req.params.id);
  if (db.orders.some((order) => order.tableId === id && order.status === "open")) {
    return res.status(409).json({ message: "Ban dang co hoa don mo" });
  }
  db.tables = db.tables.filter((table) => table.id !== id);
  writeDb(db);
  res.json({ success: true });
});

module.exports = router;
