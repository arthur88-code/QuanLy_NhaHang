const express = require("express");
const { readDb, writeDb } = require("../store");

const router = express.Router();

router.get("/", (req, res) => {
  res.json(readDb().menu);
});

router.post("/", (req, res) => {
  const db = readDb();
  const item = {
    id: db.nextIds.menu++,
    name: req.body.name || "Mon moi",
    category: req.body.category || "Khac",
    price: Number(req.body.price || 0),
    available: req.body.available ?? true,
    imageUrl: req.body.imageUrl || "https://images.unsplash.com/photo-1504674900247-0877df9cc836?auto=format&fit=crop&w=600&q=70"
  };
  db.menu.push(item);
  writeDb(db);
  res.status(201).json(item);
});

router.put("/:id", (req, res) => {
  const db = readDb();
  const item = db.menu.find((entry) => entry.id === Number(req.params.id));
  if (!item) return res.status(404).json({ message: "Khong tim thay mon" });
  Object.assign(item, {
    name: req.body.name ?? item.name,
    category: req.body.category ?? item.category,
    price: req.body.price == null ? item.price : Number(req.body.price),
    available: req.body.available ?? item.available,
    imageUrl: req.body.imageUrl ?? item.imageUrl
  });
  writeDb(db);
  res.json(item);
});

router.delete("/:id", (req, res) => {
  const db = readDb();
  db.menu = db.menu.filter((item) => item.id !== Number(req.params.id));
  writeDb(db);
  res.json({ success: true });
});

module.exports = router;
