import * as inventory_api from "../lib/inventory_api.js"
document.addEventListener("DOMContentLoaded", () => {
    loadInventory();
    document.getElementById("add-inventory-form").addEventListener("submit", addInventoryItem);
});

async function loadInventory() {
    try {
        const items = await inventory_api.getInventory();
        console.log("Items fetched:", items);
        displayInventory(items);
    } catch (err) {
        console.error(err);
    }
}


async function addInventoryItem(event) {
    event.preventDefault();
    showSpinner();
    const itemName = document.getElementById("new-item-name").value;
    const itemQuantity = document.getElementById("new-item-quantity").value;
    const itemType = document.getElementById("new-item-type").value;
    try {
        await inventory_api.createInventoryItem({ name: itemName, quantity: itemQuantity, type: itemType });
        loadInventory();  // Reload the inventory list
    } catch (err) {
        console.error(err);
    }finally{
        hideSpinner();
    }
}


function displayInventory(items) {
    const inventoryList = document.getElementById("inventory-list");
    inventoryList.innerHTML = `
        <table class="min-w-full bg-white">
            <thead class="bg-gray-800 text-white">
                <tr>
                    <th class="w-1/4 text-left py-3 px-4">Item Name</th>
                    <th class="w-1/4 text-left py-3 px-4">Quantity</th>
                    <th class="w-1/4 text-left py-3 px-4">Type</th>
                    <th class="text-left py-3 px-4">Actions</th>
                </tr>
            </thead>
            <tbody class="text-gray-700">
                ${items.map(item => `
                    <tr>
                        <td class="text-left py-3 px-4">${item.name}</td>
                        <td class="text-left py-3 px-4">${item.quantity}</td>
                        <td class="text-left py-3 px-4">${item.type}</td>
                        <td class="text-left py-3 px-4">
                            <button data-id="${item.id}" class="edit-inventory bg-yellow-500 text-white p-1 rounded">Edit</button>
                            <button data-id="${item.id}" class="delete-inventory bg-red-500 text-white p-1 rounded">Delete</button>
                        </td>
                    </tr>
                `).join('')}
            </tbody>
        </table>
    `;

    // Add event listeners for edit and delete buttons
    document.querySelectorAll('.edit-inventory').forEach(button => {
        button.addEventListener('click', async (event) => {
            const id = event.target.getAttribute('data-id');
            try {
                const item = await inventory_api.getInventoryItem(id);
                populateEditForm(item);
            } catch (err) {
                console.error(`Error fetching inventory item ${id}:`, err);
            }
        });
    });

    document.getElementById('edit-inventory-form').addEventListener('submit', async (event) => {
        event.preventDefault();
        showSpinner();
        const id = document.getElementById('edit-item-id').value;
        const updatedItem = {
            id,
            name: document.getElementById('edit-item-name').value,
            quantity: document.getElementById('edit-item-quantity').value,
            type: document.getElementById('edit-item-type').value
        };
        try {
            await inventory_api.updateInventoryItem(updatedItem);
            loadInventory();  // Reload the inventory list
            document.getElementById('edit-inventory-modal').style.display = 'none';  // Hide the modal
            alert('Item successfully updated.');  // Show confirmation alert
        } catch (err) {
            console.error(`Error updating inventory item ${id}:`, err);
        } finally {
            hideSpinner();
        }
    });



    document.getElementById('close-edit-modal').addEventListener('click', () => {
        document.getElementById('edit-inventory-modal').style.display = 'none';
    });
    document.getElementById('edit-inventory-modal').addEventListener('click', (event) => {
        if (event.target.id === 'edit-inventory-modal') {
            document.getElementById('edit-inventory-modal').style.display = 'none';
        }
    });



    function populateEditForm(item) {
        const editForm = document.getElementById('edit-inventory-form');
        editForm.querySelector('#edit-item-name').value = item.name;
        editForm.querySelector('#edit-item-quantity').value = item.quantity;
        editForm.querySelector('#edit-item-type').value = item.type;
        editForm.querySelector('#edit-item-id').value = item.id;

        // Show the modal
        document.getElementById('edit-inventory-modal').style.display = 'flex';
    }

    document.querySelectorAll('.delete-inventory').forEach(button => {
        button.addEventListener('click', async (event) => {
            const id = event.target.getAttribute('data-id');
            try {
                await inventory_api.deleteInventoryItem(id);
                loadInventory();  // Reload the inventory list
            } catch (err) {
                console.error(`Error deleting inventory item ${id}:`, err);
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
