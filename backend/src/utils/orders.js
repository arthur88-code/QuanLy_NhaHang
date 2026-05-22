function money(value) {
  return Number(value || 0);
}

function orderSubtotal(order) {
  return (order.items || []).reduce((sum, item) => sum + money(item.price) * money(item.quantity), 0);
}

function orderTotal(order) {
  return Math.max(orderSubtotal(order) - money(order.discount), 0);
}

function normalizeBatchItems(items) {
  return (items || []).map((item) => ({
    ...item,
    price: money(item.price),
    quantity: money(item.quantity)
  }));
}

function orderBatches(order) {
  const batches = Array.isArray(order.batches) ? order.batches : [];
  if (batches.length > 0) {
    return batches.map((batch, index) => ({
      id: batch.id || index + 1,
      name: batch.name || `Lan ${index + 1}`,
      createdAt: batch.createdAt || order.createdAt,
      createdBy: batch.createdBy || order.staffName || order.customerName || "He thong",
      items: normalizeBatchItems(batch.items)
    }));
  }
  const items = normalizeBatchItems(order.items);
  return items.length
    ? [{
      id: 1,
      name: "Lan 1",
      createdAt: order.createdAt,
      createdBy: order.staffName || order.customerName || "He thong",
      items
    }]
    : [];
}

function flattenBatchItems(batches) {
  const itemMap = new Map();
  for (const batch of batches || []) {
    for (const item of batch.items || []) {
      const current = itemMap.get(item.menuItemId) || {
        menuItemId: item.menuItemId,
        name: item.name,
        price: money(item.price),
        quantity: 0
      };
      current.quantity += money(item.quantity);
      itemMap.set(item.menuItemId, current);
    }
  }
  return Array.from(itemMap.values());
}

function nextBatchName(order) {
  const next = orderBatches(order).length + 1;
  return `Lan ${next}`;
}

function appendBatch(order, items, createdBy) {
  const batches = orderBatches(order);
  const id = batches.reduce((max, batch) => Math.max(max, Number(batch.id || 0)), 0) + 1;
  const batch = {
    id,
    name: `Lan ${batches.length + 1}`,
    createdAt: new Date().toISOString(),
    createdBy: createdBy || order.staffName || order.customerName || "Nhan vien",
    items: normalizeBatchItems(items)
  };
  order.batches = [...batches, batch];
  order.items = flattenBatchItems(order.batches);
  return batch;
}

function withTotals(order) {
  const batches = orderBatches(order);
  const normalized = {
    ...order,
    batches,
    items: order.items && order.items.length ? normalizeBatchItems(order.items) : flattenBatchItems(batches)
  };
  return {
    ...normalized,
    subtotal: orderSubtotal(normalized),
    total: orderTotal(normalized)
  };
}

function canCollect(role) {
  return ["admin", "staff"].includes(String(role || "").toLowerCase());
}

function samePeriod(dateValue, period, anchorDate) {
  const date = new Date(dateValue);
  const anchor = new Date(anchorDate || new Date());
  if (Number.isNaN(date.getTime())) return false;
  if (period === "year") return date.getFullYear() === anchor.getFullYear();
  if (period === "month") {
    return date.getFullYear() === anchor.getFullYear() && date.getMonth() === anchor.getMonth();
  }
  return date.toISOString().slice(0, 10) === anchor.toISOString().slice(0, 10);
}

module.exports = { money, orderSubtotal, orderTotal, orderBatches, flattenBatchItems, appendBatch, nextBatchName, withTotals, canCollect, samePeriod };
