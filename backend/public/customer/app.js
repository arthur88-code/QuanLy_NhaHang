const state = {
  customer: null,
  tables: [],
  menu: [],
  reservations: [],
  orders: [],
  paidOrders: [],
  selectedTableId: null,
  category: "Tat ca",
  mode: "order",
  cart: new Map(),
  poller: null
};

const $ = (selector) => document.querySelector(selector);
const money = (value) => `${Number(value || 0).toLocaleString("vi-VN")} VND`;

function iconRefresh() {
  if (window.lucide) window.lucide.createIcons();
}

function setMessage(text, isError = false) {
  const target = $("#actionMessage");
  target.textContent = text || "";
  target.style.color = isError ? "#ff9aa4" : "";
}

async function api(path, options = {}) {
  const response = await fetch(path, {
    ...options,
    headers: {
      "Content-Type": "application/json",
      ...(options.headers || {})
    }
  });
  const data = response.headers.get("content-type")?.includes("application/json")
    ? await response.json()
    : null;
  if (!response.ok) throw new Error(data?.message || `Loi API ${response.status}`);
  return data;
}

function saveSession(customer) {
  localStorage.setItem("restaurantCustomer", JSON.stringify(customer));
}

function readSession() {
  try {
    return JSON.parse(localStorage.getItem("restaurantCustomer") || "null");
  } catch (_) {
    return null;
  }
}

async function login(username, password) {
  const result = await api("/auth/customer-login", {
    method: "POST",
    body: JSON.stringify({ username, password })
  });
  state.customer = result.customer;
  saveSession(result.customer);
  await showApp();
}

async function loadBootstrap() {
  if (!state.customer) return;
  const data = await api(`/customer-api/bootstrap?customerId=${state.customer.id}`);
  state.tables = data.tables || [];
  state.menu = data.menu || [];
  state.reservations = data.reservations || [];
  state.orders = data.orders || [];
  state.paidOrders = data.paidOrders || state.orders.filter((item) => item.status === "paid");
  if (!state.selectedTableId && state.tables.length) {
    const ownReserved = state.tables.find((table) => canUseTable(table) && table.status === "reserved");
    const firstAvailable = state.tables.find((table) => table.status === "available");
    state.selectedTableId = (ownReserved || firstAvailable || state.tables[0]).id;
  }
  render();
}

async function showApp() {
  $("#loginView").classList.add("hidden");
  $("#appView").classList.remove("hidden");
  $("#customerName").textContent = state.customer?.name || "";
  $("#welcomeTitle").textContent = `${state.customer?.name || "Khach hang"}, chon ban va goi mon.`;
  await loadBootstrap();
  clearInterval(state.poller);
  state.poller = setInterval(loadBootstrap, 15000);
}

function showLogin() {
  clearInterval(state.poller);
  state.customer = null;
  localStorage.removeItem("restaurantCustomer");
  $("#appView").classList.add("hidden");
  $("#loginView").classList.remove("hidden");
  iconRefresh();
}

function selectedTable() {
  return state.tables.find((table) => Number(table.id) === Number(state.selectedTableId));
}

function ownReservationForTable(table) {
  return state.reservations.find((reservation) =>
    Number(reservation.tableId) === Number(table.id) &&
    ["confirmed", "seated"].includes(reservation.status)
  );
}

function canUseTable(table) {
  if (table.status === "available") return true;
  if (table.status === "reserved") return Boolean(ownReservationForTable(table));
  return false;
}

function statusLabel(status, table) {
  if (status === "occupied") return "Dang su dung";
  if (status === "reserved") return ownReservationForTable(table) ? "Ban cua ban" : "Da dat";
  return "Trong";
}

function renderStats() {
  $("#statAvailable").textContent = state.tables.filter((item) => item.status === "available").length;
  $("#statReserved").textContent = state.tables.filter((item) => item.status === "reserved").length;
  $("#statOccupied").textContent = state.tables.filter((item) => item.status === "occupied").length;
  $("#cartCount").textContent = Array.from(state.cart.values()).reduce((sum, item) => sum + item.quantity, 0);
}

function renderTables() {
  $("#tableGrid").innerHTML = state.tables.map((table) => {
    const disabled = !canUseTable(table);
    const selected = Number(table.id) === Number(state.selectedTableId);
    return `
      <button class="table-card ${selected ? "selected" : ""}" data-table="${table.id}" ${disabled ? "disabled" : ""}>
        <span class="table-main">
          <span>
            <span class="table-name">${table.name}</span>
            <span class="table-area">${table.area} - ${table.seats} ghe</span>
          </span>
          <i data-lucide="armchair"></i>
        </span>
        <span class="table-status status-${table.status}">${statusLabel(table.status, table)}</span>
      </button>
    `;
  }).join("");

  document.querySelectorAll("[data-table]").forEach((button) => {
    button.addEventListener("click", () => {
      state.selectedTableId = Number(button.dataset.table);
      setMessage("");
      render();
    });
  });
}

function categories() {
  return ["Tat ca", ...Array.from(new Set(state.menu.map((item) => item.category)))];
}

function renderCategories() {
  $("#categoryTabs").innerHTML = categories().map((category) => `
    <button class="${state.category === category ? "active" : ""}" data-category="${category}">${category}</button>
  `).join("");
  document.querySelectorAll("[data-category]").forEach((button) => {
    button.addEventListener("click", () => {
      state.category = button.dataset.category;
      renderMenu();
      renderCategories();
    });
  });
}

function renderMenu() {
  const items = state.category === "Tat ca"
    ? state.menu
    : state.menu.filter((item) => item.category === state.category);
  $("#menuGrid").innerHTML = items.map((item) => `
    <article class="menu-card">
      <img src="${item.imageUrl}" alt="${item.name}" loading="lazy" />
      <div class="menu-card-body">
        <h4>${item.name}</h4>
        <div class="menu-meta">
          <span>${item.category}</span>
          <strong>${money(item.price)}</strong>
        </div>
        <button class="add-btn" data-add="${item.id}">
          <i data-lucide="plus"></i>
          Them mon
        </button>
      </div>
    </article>
  `).join("");
  document.querySelectorAll("[data-add]").forEach((button) => {
    button.addEventListener("click", () => addToCart(Number(button.dataset.add)));
  });
  iconRefresh();
}

function addToCart(menuItemId) {
  const item = state.menu.find((row) => Number(row.id) === Number(menuItemId));
  if (!item) return;
  const current = state.cart.get(menuItemId) || { ...item, quantity: 0 };
  current.quantity += 1;
  state.cart.set(menuItemId, current);
  renderCart();
  renderStats();
}

function changeQuantity(menuItemId, delta) {
  const current = state.cart.get(menuItemId);
  if (!current) return;
  current.quantity += delta;
  if (current.quantity <= 0) state.cart.delete(menuItemId);
  renderCart();
  renderStats();
}

function renderCart() {
  const items = Array.from(state.cart.values());
  if (!items.length) {
    $("#cartItems").innerHTML = `<p class="empty">Chua co mon trong gio.</p>`;
    $("#cartTotal").textContent = money(0);
    return;
  }
  $("#cartItems").innerHTML = items.map((item) => `
    <div class="cart-row">
      <div class="cart-row-top">
        <strong>${item.name}</strong>
        <span>${money(item.price * item.quantity)}</span>
      </div>
      <div class="qty-control">
        <button class="qty-btn" data-dec="${item.id}" title="Giam"><i data-lucide="minus"></i></button>
        <span>${item.quantity}</span>
        <button class="qty-btn" data-inc="${item.id}" title="Tang"><i data-lucide="plus"></i></button>
      </div>
    </div>
  `).join("");
  $("#cartTotal").textContent = money(items.reduce((sum, item) => sum + item.price * item.quantity, 0));
  document.querySelectorAll("[data-dec]").forEach((button) => {
    button.addEventListener("click", () => changeQuantity(Number(button.dataset.dec), -1));
  });
  document.querySelectorAll("[data-inc]").forEach((button) => {
    button.addEventListener("click", () => changeQuantity(Number(button.dataset.inc), 1));
  });
  iconRefresh();
}

function renderHistory() {
  $("#reservationList").innerHTML = state.reservations.length
    ? state.reservations.map((item) => `
      <div class="history-row">
        <div class="history-row-top">
          <strong>${item.tableName}</strong>
          <span>${item.status}</span>
        </div>
        <span>${item.reservedAt}</span>
        <small>${item.partySize} khach - ${item.note || ""}</small>
      </div>
    `).join("")
    : `<p class="empty">Chua co lich dat ban.</p>`;

  $("#orderList").innerHTML = state.orders.length
    ? state.orders.map((item) => `
      <div class="history-row">
        <div class="history-row-top">
          <strong>${item.tableName} - HD #${item.id}</strong>
          <span>${item.status}</span>
        </div>
        <span>${money(item.total)}</span>
        <small>${(item.items || []).map((row) => `${row.name} x${row.quantity}`).join(", ")}</small>
      </div>
    `).join("")
    : `<p class="empty">Chua co hoa don.</p>`;

  $("#paymentList").innerHTML = state.paidOrders.length
    ? state.paidOrders.map((item) => `
      <div class="history-row paid-row">
        <div class="history-row-top">
          <strong>${item.tableName} - HD #${item.id}</strong>
          <span>${money(item.total)}</span>
        </div>
        <span>Da thanh toan: ${item.paidAt || ""}</span>
        <small>Xac nhan boi: ${item.paidBy || "Nhan vien"} - ${(item.items || []).map((row) => `${row.name} x${row.quantity}`).join(", ")}</small>
      </div>
    `).join("")
    : `<p class="empty">Chua co lich su thanh toan.</p>`;
}

function renderMode() {
  $("#modeOrder").classList.toggle("active", state.mode === "order");
  $("#modeReserve").classList.toggle("active", state.mode === "reserve");
  $("#submitAction").innerHTML = state.mode === "order"
    ? `<i data-lucide="send"></i> Gui mon`
    : `<i data-lucide="calendar-check"></i> Dat ban`;
  iconRefresh();
}

function render() {
  renderStats();
  renderTables();
  renderCategories();
  renderMenu();
  renderCart();
  renderHistory();
  renderMode();
  iconRefresh();
}

async function submitBooking(event) {
  event.preventDefault();
  const table = selectedTable();
  if (!table) return setMessage("Hay chon ban.", true);
  const bodyBase = {
    customerId: state.customer.id,
    tableId: table.id,
    partySize: Number($("#partySize").value || 1),
    reservedAt: $("#reservedAt").value,
    note: $("#note").value.trim()
  };

  try {
    $("#submitAction").disabled = true;
    if (state.mode === "reserve") {
      await api("/customer-api/reservations", {
        method: "POST",
        body: JSON.stringify(bodyBase)
      });
      setMessage("Da dat ban. Trang thai ban da cap nhat sang Da dat.");
    } else {
      const cartItems = Array.from(state.cart.values()).map((item) => ({
        menuItemId: item.id,
        quantity: item.quantity
      }));
      const reservation = ownReservationForTable(table);
      await api("/customer-api/orders", {
        method: "POST",
        body: JSON.stringify({ ...bodyBase, reservationId: reservation?.id, items: cartItems })
      });
      state.cart.clear();
      setMessage("Da gui mon. Hoa don mo da xuat hien ben admin/nhan vien.");
    }
    await loadBootstrap();
  } catch (error) {
    setMessage(error.message, true);
  } finally {
    $("#submitAction").disabled = false;
  }
}

function setDefaultDateTime() {
  const now = new Date();
  now.setHours(now.getHours() + 2, 0, 0, 0);
  const local = new Date(now.getTime() - now.getTimezoneOffset() * 60000).toISOString().slice(0, 16);
  $("#reservedAt").value = local;
}

function bindEvents() {
  $("#loginForm").addEventListener("submit", async (event) => {
    event.preventDefault();
    $("#loginError").textContent = "";
    try {
      await login($("#username").value.trim(), $("#password").value.trim());
    } catch (error) {
      $("#loginError").textContent = error.message;
    }
  });
  $("#logoutBtn").addEventListener("click", showLogin);
  $("#refreshBtn").addEventListener("click", loadBootstrap);
  $("#bookingForm").addEventListener("submit", submitBooking);
  $("#modeOrder").addEventListener("click", () => {
    state.mode = "order";
    renderMode();
  });
  $("#modeReserve").addEventListener("click", () => {
    state.mode = "reserve";
    renderMode();
  });
  document.querySelectorAll("[data-jump]").forEach((button) => {
    button.addEventListener("click", () => document.getElementById(button.dataset.jump).scrollIntoView({ block: "start" }));
  });
}

async function init() {
  bindEvents();
  setDefaultDateTime();
  const customer = readSession();
  if (customer?.id) {
    state.customer = customer;
    await showApp();
  } else {
    showLogin();
  }
}

init();
