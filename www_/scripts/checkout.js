import * as checkout_api from '../lib/checkout_api.js';

document.addEventListener("DOMContentLoaded", () => {
    loadCheckouts();
});

async function loadCheckouts() {
    try {
        const checkouts = await checkout_api.getCheckouts();
        displayCheckouts(checkouts);
    } catch (err) {
        console.error(err);
    }
}

function displayCheckouts(checkouts) {
    const checkoutList = document.getElementById("checkout-list");
    console.log(checkouts);
    checkoutList.innerHTML = checkouts.map(chk => `
        <div class="p-2 border-b">
            <span>Item: ${chk.itemName}, Customer: ${chk.customerName}</span>
            <button data-id="${chk.id}" class="return-item bg-green-500 text-white p-1 rounded">Return</button>
        </div>
    `).join("");
    //Event listener to return items
    document.querySelectorAll('.return-item').forEach(button => {
        button.addEventListener('click', async (event) => {
            const id = event.target.getAttribute('data-id');
            try {
                await checkout_api.returnItem(id);
                loadCheckouts();  // Reload the checkout list
            } catch (err) {
                console.error(`Error returning item ${id}:`, err);
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