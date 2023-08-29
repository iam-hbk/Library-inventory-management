import * as customer_api from "../lib/customer_api.js";

document.addEventListener("DOMContentLoaded", () => {
    loadCustomers();
    document.getElementById("add-customer-form").addEventListener("submit", addCustomer);
});

async function loadCustomers() {
    showSpinner();
    try {
        const customers = await customer_api.getCustomers();
        displayCustomers(customers);
    } catch (err) {
        console.error(err);
    } finally {
        hideSpinner();
    }
}

async function addCustomer(event) {
    event.preventDefault();
    showSpinner();
    const customerName = document.getElementById("new-customer-name").value;
    try {
        await customer_api.createCustomer({ name: customerName });
        loadCustomers();
    } catch (err) {
        console.error(err);
    } finally {
        hideSpinner();
    }
}


function displayCustomers(customers) {
    const customerList = document.getElementById("customer-list");
    customerList.innerHTML = `
        <table class="min-w-full bg-white">
            <thead class="bg-gray-800 text-white">
                <tr>
                    <th class="w-1/4 text-left py-3 px-4">Customer Name</th>
                    <th class="w-1/4 text-left py-3 px-4">Customer Email</th>
                    <th class="text-left py-3 px-4">Actions</th>
                </tr>
            </thead>
            <tbody class="text-gray-700">
                ${customers.map(customer => `
                    <tr>
                        <td class="text-left py-3 px-4">${customer.name}</td>
                        <td class="text-left py-3 px-4">${customer.email}</td>
                        <td class="text-left py-3 px-4">
                            <button data-id="${customer.id}" class="edit-customer bg-yellow-500 text-white p-1 rounded">Edit</button>
                            <button data-id="${customer.id}" class="delete-customer bg-red-500 text-white p-1 rounded">Delete</button>
                        </td>
                    </tr>
                `).join('')}
            </tbody>
        </table>
    `;

    // Adding event listeners for edit and delete buttons
    document.querySelectorAll('.edit-customer').forEach(button => {
        button.addEventListener('click', async (event) => {
            const id = event.target.getAttribute('data-id');
            // Fetch the existing customer and populate the edit form
            // Call your API to edit the customer
        });
    });

    document.querySelectorAll('.delete-customer').forEach(button => {
        button.addEventListener('click', async (event) => {
            const id = event.target.getAttribute('data-id');
            try {
                await customer_api.deleteCustomer(id);
                loadCustomers();  // Reload the customer list
            } catch (err) {
                console.error(`Error deleting customer ${id}:`, err);
            }
        });
    });
}

function showSpinner() {
    document.getElementById('loading-spinner').style.display = 'flex';
}

function hideSpinner() {
    document.getElementById('loading-spinner').style.display = 'none';
}