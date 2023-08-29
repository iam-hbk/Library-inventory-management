// Fetch all customers
export async function getCustomers() {
    try {
        let response = await fetch("http://localhost:5284/api/customers", {
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
        console.error("Error fetching customers:", error);
        throw error;
    }
}

// Fetch a single customer by ID
export async function getCustomer(id) {
    try {
        let response = await fetch(`http://localhost:5284/api/customers/${id}`, {
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
        console.error(`Error fetching customer ${id}:`, error);
        throw error;
    }
}

// Create a new customer
export async function createCustomer(customer) {
    try {
        let response = await fetch("http://localhost:5284/api/customers", {
            method: "POST",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(customer)
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {
        console.error("Error creating customer:", error);
        throw error;
    }
}

// Update an existing customer
export async function updateCustomer(customer) {
    try {
        let response = await fetch(`http://localhost:5284/api/customers/${customer.id}`, {
            method: "PUT",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(customer)
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {
        console.error(`Error updating customer ${customer.id}:`, error);
        throw error;
    }
}

// Delete a customer by ID
export async function deleteCustomer(id) {
    try {
        let response = await fetch(`http://localhost:5284/api/customers/${id}`, {
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
        console.error(`Error deleting customer ${id}:`, error);
        throw error;
    }
}
