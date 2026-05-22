const express = require("express");
const cors = require("cors");
const path = require("path");

const { ensureStore } = require("./src/store");
const authRoutes = require("./src/routes/auth");
const dashboardRoutes = require("./src/routes/dashboard");
const tableRoutes = require("./src/routes/tables");
const menuRoutes = require("./src/routes/menu");
const orderRoutes = require("./src/routes/orders");
const debtRoutes = require("./src/routes/debts");
const statsRoutes = require("./src/routes/stats");
const employeeRoutes = require("./src/routes/employees");
const attendanceRoutes = require("./src/routes/attendance");
const notificationRoutes = require("./src/routes/notifications");
const payrollRoutes = require("./src/routes/payroll");
const adminRoutes = require("./src/routes/admin");
const customerRoutes = require("./src/routes/customer");

const app = express();
const PORT = Number(process.env.PORT || 3000);
const flutterWebDir = path.join(__dirname, "..", "frontend", "build", "web");

app.use(cors());
app.use(express.json());
app.use("/customer", express.static(path.join(__dirname, "public", "customer")));

app.get("/", (req, res) => {
  res.json({ success: true, message: "Restaurant API is running" });
});

app.use("/auth", authRoutes);
app.use("/dashboard", dashboardRoutes);
app.use("/tables", tableRoutes);
app.use("/menu", menuRoutes);
app.use("/orders", orderRoutes);
app.use("/debts", debtRoutes);
app.use("/stats", statsRoutes);
app.use("/employees", employeeRoutes);
app.use("/attendance", attendanceRoutes);
app.use("/notifications", notificationRoutes);
app.use("/payroll", payrollRoutes);
app.use("/admin", adminRoutes);
app.use("/customer-api", customerRoutes);

app.use(express.static(flutterWebDir, { index: false }));
app.use("/staff", express.static(flutterWebDir, { index: false }));
app.use("/admin-web", express.static(flutterWebDir, { index: false }));
app.get(/^\/(staff|admin-web)(\/.*)?$/, (req, res) => {
  res.sendFile(path.join(flutterWebDir, "index.html"), (error) => {
    if (error) {
      res.status(503).json({
        success: false,
        message: "Chua co Flutter web build. Chay: cd frontend && flutter build web"
      });
    }
  });
});

app.post("/reset", (req, res) => {
  const { resetDb } = require("./src/store");
  resetDb();
  res.json({ success: true, message: "Seed data restored" });
});

ensureStore();
app.listen(PORT, "0.0.0.0", () => {
  console.log(`Restaurant API running at http://0.0.0.0:${PORT}`);
});
