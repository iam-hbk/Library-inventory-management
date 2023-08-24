// Fetch all checkout logs
export async function getCheckouts() {
    try {
        let response = await fetch("http://localhost:5284/api/checkout/logs", {
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
        console.error("Error fetching checkout logs:", error);
        throw error;
    }
}

// Perform a checkout
export async function checkout(item) {
    try {
        let response = await fetch("http://localhost:5284/api/checkout", {
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
        console.error("Error during checkout:", error);
        throw error;
    }
}

// Return a checked-out item
export async function returnItem(id) {
    try {
        let response = await fetch(`http://localhost:5284/api/checkout/return/${id}`, {
            method: "PUT",
            headers: {
                "Accept": "application/json"
            }
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {
        console.error(`Error returning item ${id}:`, error);
        throw error;
    }
}
