import * as checkout from './lib/checkout_api.js';
import * as customer from './lib/customer_api.js';
import * as inventory from './lib/inventory_api.js';

document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("add-inventory-form").addEventListener("submit", addInventoryItem);
    document.getElementById("add-customer-form").addEventListener("submit", addCustomer);
    document.getElementById("load-inventory").addEventListener("click", loadInventory);
    document.getElementById("load-customers").addEventListener("click", loadCustomers);
    document.getElementById("load-checkouts").addEventListener("click", loadCheckouts);
});

async function loadInventory() {
    try {
        const items = await inventory.getInventory();
        displayInventory(items);
    } catch (err) {
        console.error(err);
    }
}

async function loadCustomers() {
    try {
        const customers = await customer.getCustomers();
        displayCustomers(customers);
    } catch (err) {
        console.error(err);
    }
}

async function loadCheckouts() {
    try {
        const checkouts = await checkout.getCheckouts();
        displayCheckouts(checkouts);
    } catch (err) {
        console.error(err);
    }
}

function displayInventory(items) {
    const inventoryList = document.getElementById("inventory-list");
    inventoryList.innerHTML = items.map(item => `
        <div class="p-2 border-b">
            <span>${item.name}</span>
            <button data-id="${item.id}" class="edit-inventory bg-yellow-500 text-white p-1 rounded">Edit</button>
            <button data-id="${item.id}" class="delete-inventory bg-red-500 text-white p-1 rounded">Delete</button>
        </div>
    `).join("");

    document.querySelectorAll(".edit-inventory").forEach(button => {
        button.addEventListener("click", event => editInventoryItem(event.target.dataset.id));
    });
    document.querySelectorAll(".delete-inventory").forEach(button => {
        button.addEventListener("click", event => deleteInventoryItem(event.target.dataset.id));
    });
}

function displayCustomers(customers) {
    const customerList = document.getElementById("customer-list");
    customerList.innerHTML = customers.map(cust => `
        <div class="p-2 border-b">
            <span>${cust.name}</span>
            <button data-id="${cust.id}" class="edit-customer bg-yellow-500 text-white p-1 rounded">Edit</button>
            <button data-id="${cust.id}" class="delete-customer bg-red-500 text-white p-1 rounded">Delete</button>
        </div>
    `).join("");

    document.querySelectorAll(".edit-customer").forEach(button => {
        button.addEventListener("click", event => editCustomer(event.target.dataset.id));
    });
    document.querySelectorAll(".delete-customer").forEach(button => {
        button.addEventListener("click", event => deleteCustomer(event.target.dataset.id));
    });
}

function displayCheckouts(checkouts) {
    const checkoutList = document.getElementById("checkout-list");
    checkoutList.innerHTML = checkouts.map(chk => `
        <div class="p-2 border-b">
            <span>Item: ${chk.itemName}, Customer: ${chk.customerName}</span>
            <button data-id="${chk.id}" class="return-item bg-green-500 text-white p-1 rounded">Return</button>
        </div>
    `).join("");
}




async function addInventoryItem(event) {
    event.preventDefault();
    const itemName = document.getElementById("new-item-name").value;
    try {
        await inventory.createInventoryItem({ name: itemName });
        loadInventory();  // Reload the inventory list
    } catch (err) {
        console.error(err);
    }
}

async function addCustomer(event) {
    event.preventDefault();
    const customerName = document.getElementById("new-customer-name").value;
    try {
        await customer.createCustomer({ name: customerName });
        loadCustomers();  // Reload the customer list
    } catch (err) {
        console.error(err);
    }
}

async function editInventoryItem(id) {
    const itemName = prompt("New name for the item:");
    if (itemName) {
        try {
            await inventory.updateInventoryItem({ id, name: itemName });
            loadInventory();  // Reload the inventory list
        } catch (err) {
            console.error(err);
        }
    }
}

async function deleteInventoryItem(id) {
    if (confirm("Are you sure you want to delete this item?")) {
        try {
            await inventory.deleteInventoryItem(id);
            loadInventory();  // Reload the inventory list
        } catch (err) {
            console.error(err);
        }
    }
}

async function editCustomer(id) {
    const customerName = prompt("New name for the customer:");
    if (customerName) {
        try {
            await customer.updateCustomer({ id, name: customerName });
            loadCustomers();  // Reload the customer list
        } catch (err) {
            console.error(err);
        }
    }
}

async function deleteCustomer(id) {
    if (confirm("Are you sure you want to delete this customer?")) {
        try {
            await customer.deleteCustomer(id);
            loadCustomers();  // Reload the customer list
        } catch (err) {
            console.error(err);
        }
    }
}