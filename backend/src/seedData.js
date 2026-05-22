const defaultPassword = "123";

function seedEmployees() {
  return [
    { id: 1, name: "Admin", role: "Quan ly", phone: "0900000001", salaryPerDay: 300000, active: true },
    { id: 2, name: "Nguyen Minh Quan", role: "Phuc vu", phone: "0900000002", salaryPerDay: 300000, active: true },
    { id: 3, name: "Tran Thu Ngan", role: "Thu ngan", phone: "0900000003", salaryPerDay: 300000, active: true },
    { id: 4, name: "Le Hoai An", role: "Ke toan", phone: "0900000004", salaryPerDay: 300000, active: true },
    { id: 5, name: "Pham Bao Chau", role: "Phuc vu", phone: "0900000005", salaryPerDay: 300000, active: true },
    { id: 6, name: "Do Quang Huy", role: "Bep truong", phone: "0900000006", salaryPerDay: 300000, active: true },
    { id: 7, name: "Bui Thanh Tam", role: "Pha che", phone: "0900000007", salaryPerDay: 300000, active: true },
    { id: 8, name: "Vo My Linh", role: "Le tan", phone: "0900000008", salaryPerDay: 300000, active: true },
    { id: 9, name: "Hoang Gia Bao", role: "Giam sat ca", phone: "0900000009", salaryPerDay: 300000, active: true },
    { id: 10, name: "Dang Van Khoa", role: "Bao ve", phone: "0900000010", salaryPerDay: 300000, active: true },
    { id: 11, name: "Ngo Kim Anh", role: "Phu bep", phone: "0900000011", salaryPerDay: 300000, active: true },
    { id: 12, name: "Phan Hai Nam", role: "Phuc vu", phone: "0900000012", salaryPerDay: 300000, active: true }
  ];
}

function seedUsers(employees) {
  const accounts = [
    { username: "admin", employeeId: 1, role: "admin" },
    { username: "staff", employeeId: 2, role: "staff" },
    { username: "cashier", employeeId: 3, role: "staff" },
    { username: "accountant", employeeId: 4, role: "staff" },
    { username: "waiter02", employeeId: 5, role: "staff" },
    { username: "chef", employeeId: 6, role: "staff" },
    { username: "barista", employeeId: 7, role: "staff" },
    { username: "reception", employeeId: 8, role: "staff" },
    { username: "supervisor", employeeId: 9, role: "staff" },
    { username: "guard", employeeId: 10, role: "staff" },
    { username: "kitchen", employeeId: 11, role: "staff" },
    { username: "waiter03", employeeId: 12, role: "staff" }
  ];

  return accounts.map((account, index) => {
    const employee = employees.find((item) => item.id === account.employeeId);
    return {
      id: index + 1,
      username: account.username,
      password: defaultPassword,
      name: employee?.name || account.username,
      role: account.role,
      employeeId: account.employeeId,
      active: true
    };
  });
}

function seedCustomers() {
  const baseNames = [
    "Nguyen Bao Tran",
    "Pham Hoang Kiet",
    "Le Minh Khue",
    "Tran Gia Han",
    "Dang Tuan Anh",
    "Vo Ngoc Mai",
    "Bui Thanh Son",
    "Huynh Nhat Linh",
    "Do Khanh Vy",
    "Ngo Quoc Bao",
    "Phan Thuy Dung",
    "Vu Minh Chau",
    "Cao Duc Huy",
    "Dinh My Tam",
    "Lam Hai Yen",
    "Truong Anh Thu",
    "Mai Quang Minh",
    "Ly Hoang Phuc",
    "Ta Kim Ngan",
    "Ha Bao Ngoc",
    "Nguyen Gia Phat",
    "Tran Ngoc Han",
    "Le Quynh Anh",
    "Pham Minh Tri",
    "Do Tien Dat",
    "Vo Lan Chi",
    "Bui Khanh Nam",
    "Huynh Tue Nhi",
    "Dang Viet Hoang",
    "Ngo Phuong Uyen"
  ];
  const families = ["Nguyen", "Tran", "Le", "Pham", "Hoang", "Vo", "Bui", "Dang", "Do", "Mai"];
  const middles = ["Minh", "Gia", "Bao", "Ngoc", "Thanh", "Hoai", "Quang", "My", "Khanh", "Nhat"];
  const givens = ["An", "Binh", "Chi", "Dung", "Hao", "Kien", "Linh", "Nam", "Phuc", "Vy"];
  const names = Array.from({ length: 100 }, (_, index) => {
    if (baseNames[index]) return baseNames[index];
    return `${families[index % families.length]} ${middles[index % middles.length]} ${givens[index % givens.length]} ${String(index + 1).padStart(3, "0")}`;
  });

  return names.map((name, index) => {
    const id = index + 1;
    const code = String(id).padStart(3, "0");
    return {
      id,
      username: `customer${code}`,
      password: defaultPassword,
      name,
      phone: `0988${String(id).padStart(6, "0")}`,
      email: `customer${code}@example.com`,
      tier: id <= 5 ? "diamond" : id <= 12 ? "gold" : id <= 22 ? "silver" : "standard",
      note: id <= 5 ? "Khach VIP dat ban thuong xuyen" : "",
      active: true,
      createdAt: `2026-${id <= 35 ? "03" : id <= 70 ? "04" : "05"}-${String((id % 24) + 1).padStart(2, "0")}T09:00:00+07:00`
    };
  });
}

function seedTables() {
  return [
    { id: 1, name: "Ban 1", seats: 4, area: "Tang 1", status: "available" },
    { id: 2, name: "Ban 2", seats: 4, area: "Tang 1", status: "available" },
    { id: 3, name: "Ban 3", seats: 6, area: "Tang 1", status: "occupied", activeOrderId: 8 },
    { id: 4, name: "Ban VIP 1", seats: 8, area: "VIP", status: "available" },
    { id: 5, name: "Ban 5", seats: 2, area: "Tang 1", status: "available" },
    { id: 6, name: "Ban 6", seats: 4, area: "San vuon", status: "reserved", reservationId: 1 },
    { id: 7, name: "Ban 7", seats: 4, area: "Tang 1", status: "available" },
    { id: 8, name: "Ban 8", seats: 6, area: "Tang 1", status: "available" },
    { id: 9, name: "Ban 9", seats: 4, area: "Tang 2", status: "available" },
    { id: 10, name: "Ban 10", seats: 6, area: "Tang 2", status: "available" },
    { id: 11, name: "Ban 11", seats: 4, area: "Tang 2", status: "occupied", activeOrderId: 9 },
    { id: 12, name: "Ban 12", seats: 8, area: "Tang 2", status: "reserved", reservationId: 2 },
    { id: 13, name: "Ban VIP 2", seats: 10, area: "VIP", status: "available" },
    { id: 14, name: "Ban San Vuon 1", seats: 4, area: "San vuon", status: "available" },
    { id: 15, name: "Ban San Vuon 2", seats: 6, area: "San vuon", status: "available" },
    { id: 16, name: "Ban Gia Dinh", seats: 12, area: "Tang 2", status: "available" }
  ];
}

function seedMenu() {
  const imageQueries = {
    "Pho bo tai": "pho bo vietnamese beef noodle soup",
    "Pho ga xe": "vietnamese chicken pho noodle soup",
    "Bun bo Hue": "bun bo hue vietnamese spicy noodle soup",
    "Com tam suon bi cha": "vietnamese broken rice pork chop",
    "Com ga xoi mo": "vietnamese chicken rice",
    "Mi xao hai san": "seafood stir fried noodles",
    "Hu tieu Nam Vang": "hu tieu nam vang noodle soup",
    "Banh canh cua": "vietnamese crab tapioca noodle soup",
    "Bun cha Ha Noi": "bun cha hanoi grilled pork noodles",
    "Banh mi bo kho": "vietnamese beef stew baguette",
    "Ca kho to": "vietnamese caramelized fish clay pot",
    "Bo luc lac khoai tay": "shaking beef with fries",
    "Suon cay sot me": "spicy tamarind pork ribs",
    "Ga roti mat ong": "honey roasted chicken",
    "Tom rang muoi": "salt and pepper shrimp",
    "Muc xao sa te": "spicy sauteed squid",
    "Rau muong xao bo": "morning glory stir fry beef",
    "Canh chua ca": "vietnamese sour fish soup",
    "Lau Thai hai san": "thai seafood hotpot",
    "Lau ga la e": "vietnamese chicken hotpot",
    "Set nuong bo my": "grilled beef barbecue platter",
    "Ba chi nuong sa te": "grilled pork belly satay",
    "Goi cuon tom thit": "vietnamese fresh spring rolls shrimp pork",
    "Cha gio hai san": "seafood fried spring rolls",
    "Salad ca ngu": "tuna salad",
    "Goi ngo sen tom": "lotus stem shrimp salad",
    "Khoai tay chien": "french fries",
    "Nem chua ran": "vietnamese fried fermented pork roll",
    "Xuc xich chien": "fried sausage",
    "Pho mai que": "mozzarella sticks",
    "Banh trang tron": "vietnamese rice paper salad",
    "Ca vien chien": "fried fish balls",
    "Ga popcorn": "popcorn chicken",
    "Khoai lang ken": "fried sweet potato balls",
    "Takoyaki": "takoyaki",
    "Tra dao cam sa": "peach orange lemongrass tea",
    "Tra vai hat chia": "lychee chia tea",
    "Ca phe sua da": "vietnamese iced milk coffee",
    "Bac xiu": "vietnamese bac xiu coffee milk",
    "Nuoc cam ep": "fresh orange juice",
    "Nuoc ep dua hau": "watermelon juice",
    "Sinh to bo": "avocado smoothie",
    "Soda chanh": "lime soda",
    "Tra sua tran chau": "bubble milk tea",
    "Matcha latte": "matcha latte",
    "Pepsi lon": "cola can",
    "Nuoc suoi": "bottled water",
    "Bia Sai Gon": "lager beer glass",
    "Banh flan": "creme caramel flan",
    "Che khuc bach": "vietnamese almond panna cotta dessert",
    "Sua chua nep cam": "black sticky rice yogurt",
    "Trai cay thap cam": "mixed fresh fruit platter"
  };
  const rows = [
    ["Pho bo tai", "Mon chinh", 65000],
    ["Pho ga xe", "Mon chinh", 58000],
    ["Bun bo Hue", "Mon chinh", 68000],
    ["Com tam suon bi cha", "Mon chinh", 72000],
    ["Com ga xoi mo", "Mon chinh", 70000],
    ["Mi xao hai san", "Mon chinh", 85000],
    ["Hu tieu Nam Vang", "Mon chinh", 68000],
    ["Banh canh cua", "Mon chinh", 75000],
    ["Bun cha Ha Noi", "Mon chinh", 69000],
    ["Banh mi bo kho", "Mon chinh", 79000],
    ["Ca kho to", "Mon chinh", 95000],
    ["Bo luc lac khoai tay", "Mon chinh", 115000],
    ["Suon cay sot me", "Mon chinh", 105000],
    ["Ga roti mat ong", "Mon chinh", 98000],
    ["Tom rang muoi", "Mon chinh", 125000],
    ["Muc xao sa te", "Mon chinh", 118000],
    ["Rau muong xao bo", "Mon chinh", 68000],
    ["Canh chua ca", "Mon chinh", 88000],
    ["Lau Thai hai san", "Lau nuong", 269000],
    ["Lau ga la e", "Lau nuong", 239000],
    ["Set nuong bo my", "Lau nuong", 299000],
    ["Ba chi nuong sa te", "Lau nuong", 169000],
    ["Goi cuon tom thit", "Khai vi", 39000],
    ["Cha gio hai san", "Khai vi", 55000],
    ["Salad ca ngu", "Khai vi", 59000],
    ["Goi ngo sen tom", "Khai vi", 69000],
    ["Khoai tay chien", "An vat", 42000],
    ["Nem chua ran", "An vat", 48000],
    ["Xuc xich chien", "An vat", 35000],
    ["Pho mai que", "An vat", 39000],
    ["Banh trang tron", "An vat", 35000],
    ["Ca vien chien", "An vat", 45000],
    ["Ga popcorn", "An vat", 52000],
    ["Khoai lang ken", "An vat", 36000],
    ["Takoyaki", "An vat", 59000],
    ["Tra dao cam sa", "Do uong", 32000],
    ["Tra vai hat chia", "Do uong", 34000],
    ["Ca phe sua da", "Do uong", 30000],
    ["Bac xiu", "Do uong", 32000],
    ["Nuoc cam ep", "Do uong", 42000],
    ["Nuoc ep dua hau", "Do uong", 38000],
    ["Sinh to bo", "Do uong", 45000],
    ["Soda chanh", "Do uong", 35000],
    ["Tra sua tran chau", "Do uong", 42000],
    ["Matcha latte", "Do uong", 48000],
    ["Pepsi lon", "Do uong", 22000],
    ["Nuoc suoi", "Do uong", 12000],
    ["Bia Sai Gon", "Do uong", 28000],
    ["Banh flan", "Trang mieng", 28000],
    ["Che khuc bach", "Trang mieng", 39000],
    ["Sua chua nep cam", "Trang mieng", 32000],
    ["Trai cay thap cam", "Trang mieng", 59000]
  ];

  const imageTagPath = (query) => query
    .toLowerCase()
    .replace(/[^a-z0-9\s]/g, " ")
    .split(/\s+/)
    .filter(Boolean)
    .slice(0, 5)
    .join(",");

  return rows.map(([name, category, price], index) => ({
    id: index + 1,
    name,
    category,
    price,
    available: true,
    imageUrl: `https://loremflickr.com/600/420/${imageTagPath(imageQueries[name] || `${name} food`)}?lock=${index + 1}`
  }));
}

function orderSubtotal(order) {
  return (order.items || []).reduce((sum, item) => sum + Number(item.price || 0) * Number(item.quantity || 0), 0);
}

function orderTotal(order) {
  return Math.max(orderSubtotal(order) - Number(order.discount || 0), 0);
}

function seedOrders({ tables, employees, customers, menu }) {
  const makeItems = (rows) => rows.map(([menuItemId, quantity]) => {
    const menuItem = menu.find((item) => item.id === menuItemId);
    return { menuItemId, name: menuItem.name, price: menuItem.price, quantity };
  });

  const makeOrder = ({
    id,
    tableId,
    staffId,
    customerId,
    status,
    createdAt,
    paidAt = null,
    paidBy = null,
    discount = 0,
    items
  }) => {
    const table = tables.find((item) => item.id === tableId);
    const staff = employees.find((item) => item.id === staffId);
    const customer = customers.find((item) => item.id === customerId);
    return {
      id,
      tableId,
      tableName: table.name,
      staffId,
      staffName: staff.name,
      customerId,
      customerName: customer.name,
      customerPhone: customer.phone,
      status,
      source: "staff_app",
      createdAt,
      paidAt,
      paidBy,
      discount,
      items: makeItems(items)
    };
  };

  return [
    makeOrder({ id: 1, tableId: 1, staffId: 2, customerId: 1, status: "paid", createdAt: "2026-03-12T11:05:00+07:00", paidAt: "2026-03-12T12:18:00+07:00", paidBy: "Nguyen Minh Quan", discount: 10000, items: [[1, 2], [36, 2], [27, 1]] }),
    makeOrder({ id: 2, tableId: 4, staffId: 3, customerId: 2, status: "paid", createdAt: "2026-04-05T18:15:00+07:00", paidAt: "2026-04-05T20:02:00+07:00", paidBy: "Tran Thu Ngan", discount: 20000, items: [[19, 1], [23, 2], [39, 3], [49, 2]] }),
    makeOrder({ id: 3, tableId: 8, staffId: 5, customerId: 3, status: "paid", createdAt: "2026-04-20T12:10:00+07:00", paidAt: "2026-04-20T13:30:00+07:00", paidBy: "Pham Bao Chau", discount: 0, items: [[4, 2], [24, 1], [38, 2], [50, 1]] }),
    makeOrder({ id: 4, tableId: 2, staffId: 2, customerId: 4, status: "paid", createdAt: "2026-05-02T19:00:00+07:00", paidAt: "2026-05-02T21:05:00+07:00", paidBy: "Nguyen Minh Quan", discount: 15000, items: [[21, 1], [22, 2], [35, 2], [45, 4]] }),
    makeOrder({ id: 5, tableId: 5, staffId: 7, customerId: 5, status: "paid", createdAt: "2026-05-12T09:25:00+07:00", paidAt: "2026-05-12T10:10:00+07:00", paidBy: "Bui Thanh Tam", discount: 0, items: [[7, 1], [37, 1], [47, 1]] }),
    makeOrder({ id: 6, tableId: 9, staffId: 3, customerId: 6, status: "paid", createdAt: "2026-05-20T18:35:00+07:00", paidAt: "2026-05-20T20:15:00+07:00", paidBy: "Tran Thu Ngan", discount: 30000, items: [[12, 2], [26, 1], [40, 2], [52, 1]] }),
    makeOrder({ id: 7, tableId: 10, staffId: 3, customerId: 7, status: "debt", createdAt: "2026-05-14T18:00:00+07:00", paidAt: "2026-05-14T19:45:00+07:00", paidBy: "Tran Thu Ngan", discount: 0, items: [[16, 1], [25, 1], [41, 2]] }),
    makeOrder({ id: 8, tableId: 3, staffId: 5, customerId: 8, status: "open", createdAt: "2026-05-21T18:05:00+07:00", items: [[3, 2], [28, 1], [36, 2]] }),
    makeOrder({ id: 9, tableId: 11, staffId: 2, customerId: 9, status: "open", createdAt: "2026-05-21T18:22:00+07:00", items: [[5, 1], [31, 2], [42, 1]] }),
    makeOrder({ id: 10, tableId: 14, staffId: 8, customerId: 11, status: "debt", createdAt: "2026-04-28T13:20:00+07:00", paidAt: "2026-04-28T14:30:00+07:00", paidBy: "Vo My Linh", discount: 10000, items: [[18, 1], [30, 2], [44, 2]] })
  ];
}

function seedDebts(orders) {
  const debtOrders = orders.filter((order) => order.status === "debt");
  return debtOrders.map((order, index) => ({
    id: index + 1,
    orderId: order.id,
    customerId: order.customerId,
    customerName: order.customerName,
    customerPhone: order.customerPhone,
    amount: orderTotal(order),
    paidAmount: index === 0 ? 50000 : 0,
    status: "open",
    dueDate: index === 0 ? "2026-05-31" : "2026-06-05",
    note: index === 0 ? "Khach hen chuyen khoan cuoi thang" : "Cong no tiec gia dinh",
    createdAt: order.paidAt || order.createdAt
  }));
}

function seedAttendance() {
  const rows = [];
  const employeeIds = [2, 3, 4, 5, 7, 8];
  const start = new Date(Date.UTC(2026, 2, 3));
  const end = new Date(Date.UTC(2026, 4, 20));
  let id = 1;

  for (let day = new Date(start); day <= end; day.setUTCDate(day.getUTCDate() + 1)) {
    const weekday = day.getUTCDay();
    if (weekday === 0 || weekday === 6) continue;
    const date = day.toISOString().slice(0, 10);
    for (const employeeId of employeeIds) {
      rows.push({
        id: id++,
        employeeId,
        date,
        checkIn: `${date}T08:00:00+07:00`,
        checkOut: `${date}T18:00:00+07:00`,
        note: "Ca 10h"
      });
    }
  }

  return rows;
}

function seedData() {
  const employees = seedEmployees();
  const users = seedUsers(employees);
  const customers = seedCustomers();
  const tables = seedTables();
  const menu = seedMenu();
  const orders = seedOrders({ tables, employees, customers, menu });
  const debts = seedDebts(orders);
  const attendance = seedAttendance();
  const reservations = [
    { id: 1, tableId: 6, tableName: "Ban 6", customerId: 10, customerName: customers[9].name, customerPhone: customers[9].phone, partySize: 4, reservedAt: "2026-05-22T18:30:00+07:00", status: "confirmed", note: "Khach chon ban san vuon" },
    { id: 2, tableId: 12, tableName: "Ban 12", customerId: 12, customerName: customers[11].name, customerPhone: customers[11].phone, partySize: 8, reservedAt: "2026-05-24T19:00:00+07:00", status: "confirmed", note: "Sinh nhat gia dinh" }
  ];

  return {
    users,
    employees,
    customers,
    tables,
    menu,
    orders,
    debts,
    attendance,
    notifications: [
      { id: 1, title: "Ca toi", body: "Kiem tra lai ban VIP truoc 18:00.", audience: "all", createdAt: "2026-05-21T10:00:00+07:00" },
      { id: 2, title: "Kiem kho do uong", body: "Pha che cap nhat ton kho nuoc ep va tra sua.", audience: "staff", createdAt: "2026-05-20T09:30:00+07:00" }
    ],
    settings: {
      heroImageUrl: "https://images.unsplash.com/photo-1517248135467-4c7edcad34c4?auto=format&fit=crop&w=1400&q=75"
    },
    reservations,
    nextIds: {
      user: users.length + 1,
      table: tables.length + 1,
      menu: menu.length + 1,
      order: orders.length + 1,
      debt: debts.length + 1,
      employee: employees.length + 1,
      attendance: attendance.length + 1,
      notification: 3,
      customer: customers.length + 1,
      reservation: reservations.length + 1
    }
  };
}

module.exports = { defaultPassword, seedData };
