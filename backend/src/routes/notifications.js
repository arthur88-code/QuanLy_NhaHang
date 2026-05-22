const express = require("express");
const { readDb, writeDb } = require("../store");

const router = express.Router();

router.get("/", (req, res) => {
  res.json(readDb().notifications.slice().reverse());
});

router.post("/", (req, res) => {
  const db = readDb();
  const notification = {
    id: db.nextIds.notification++,
    title: req.body.title || "Thong bao",
    body: req.body.body || "",
    audience: req.body.audience || "all",
    createdAt: new Date().toISOString()
  };
  db.notifications.push(notification);
  writeDb(db);
  res.status(201).json(notification);
});

router.delete("/:id", (req, res) => {
  const db = readDb();
  db.notifications = db.notifications.filter((item) => item.id !== Number(req.params.id));
  writeDb(db);
  res.json({ success: true });
});

module.exports = router;
