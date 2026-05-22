const express = require("express");
const { defaultPassword } = require("../seedData");
const { readDb, writeDb } = require("../store");

const router = express.Router();

function employeeWithAccount(employee, db) {
  const account = db.users.find((user) => Number(user.employeeId) === Number(employee.id));
  return { ...employee, account: account ? { ...account, password: undefined } : null };
}

function slug(text) {
  return String(text || "staff")
    .normalize("NFD")
    .replace(/[\u0300-\u036f]/g, "")
    .toLowerCase()
    .replace(/[^a-z0-9]+/g, "")
    .slice(0, 16) || "staff";
}

function uniqueUsername(db, base, ignoreUserId = null) {
  let username = base || "staff";
  let suffix = 1;
  while (db.users.some((user) => user.id !== ignoreUserId && user.username === username)) {
    suffix += 1;
    username = `${base}${suffix}`;
  }
  return username;
}

router.get("/", (req, res) => {
  const db = readDb();
  res.json(db.employees.map((employee) => employeeWithAccount(employee, db)));
});

router.post("/", (req, res) => {
  const db = readDb();
  const employee = {
    id: db.nextIds.employee++,
    name: req.body.name || "Nhan vien moi",
    role: req.body.role || "Phuc vu",
    phone: req.body.phone || "",
    salaryPerDay: Number(req.body.salaryPerDay || 300000),
    active: req.body.active ?? true
  };
  db.employees.push(employee);

  const username = uniqueUsername(db, req.body.username || slug(employee.name));
  const account = {
    id: db.nextIds.user++,
    username,
    password: req.body.password || defaultPassword,
    name: employee.name,
    role: req.body.accountRole === "admin" ? "admin" : "staff",
    employeeId: employee.id,
    active: employee.active
  };
  db.users.push(account);
  writeDb(db);
  res.status(201).json(employeeWithAccount(employee, db));
});

router.put("/:id", (req, res) => {
  const db = readDb();
  const employee = db.employees.find((item) => item.id === Number(req.params.id));
  if (!employee) return res.status(404).json({ message: "Khong tim thay nhan vien" });
  Object.assign(employee, {
    name: req.body.name ?? employee.name,
    role: req.body.role ?? employee.role,
    phone: req.body.phone ?? employee.phone,
    salaryPerDay: req.body.salaryPerDay == null ? employee.salaryPerDay : Number(req.body.salaryPerDay),
    active: req.body.active ?? employee.active
  });

  let account = db.users.find((user) => Number(user.employeeId) === Number(employee.id));
  if (!account) {
    account = {
      id: db.nextIds.user++,
      username: uniqueUsername(db, req.body.username || slug(employee.name)),
      password: req.body.password || defaultPassword,
      name: employee.name,
      role: req.body.accountRole === "admin" ? "admin" : "staff",
      employeeId: employee.id,
      active: employee.active
    };
    db.users.push(account);
  } else {
    account.name = employee.name;
    account.active = employee.active;
    if (req.body.username) account.username = uniqueUsername(db, req.body.username, account.id);
    if (req.body.password) account.password = req.body.password;
    if (req.body.accountRole) account.role = req.body.accountRole === "admin" ? "admin" : "staff";
  }

  writeDb(db);
  res.json(employeeWithAccount(employee, db));
});

router.delete("/:id", (req, res) => {
  const db = readDb();
  const employee = db.employees.find((item) => item.id === Number(req.params.id));
  if (!employee) return res.status(404).json({ message: "Khong tim thay nhan vien" });
  employee.active = false;
  const account = db.users.find((user) => Number(user.employeeId) === Number(employee.id));
  if (account) account.active = false;
  writeDb(db);
  res.json(employeeWithAccount(employee, db));
});

module.exports = router;
