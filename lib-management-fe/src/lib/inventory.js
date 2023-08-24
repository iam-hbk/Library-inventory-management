// Fetch all inventory items
export async function getInventory() {
    try {
        let response = await fetch("http://localhost:5284/api/inventory", {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {
        console.error("Error fetching inventory:", error);
        throw error;
    }
}

// Fetch a single inventory item by ID
export async function getInventoryItem(id) {
    try {
        let response = await fetch(`http://localhost:5284/api/inventory/${id}`, {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {
        console.error(`Error fetching inventory item ${id}:`, error);
        throw error;
    }
}

// Create a new inventory item
export async function createInventoryItem(item) {
    try {
        let response = await fetch("http://localhost:5284/api/inventory", {
            method: "POST",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(item)
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {
        console.error("Error creating inventory item:", error);
        throw error;
    }
}

// Update an existing inventory item
export async function updateInventoryItem(item) {
    try {
        let response = await fetch(`http://localhost:5284/api/inventory/${item.id}`, {
            method: "PUT",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(item)
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {
        console.error(`Error updating inventory item ${item.id}:`, error);
        throw error;
    }
}

// Delete an inventory item by ID
export async function deleteInventoryItem(id) {
    try {
        let response = await fetch(`http://localhost:5284/api/inventory/${id}`, {
            method: "DELETE",
            headers: {
                "Accept": "application/json"
            }
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {
        console.error(`Error deleting inventory item ${id}:`, error);
        throw error;
    }
}
