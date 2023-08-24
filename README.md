
# Inventory Management System

## Overview

This is a simple Inventory Management System built using ASP.NET Core and Entity Framework. The system allows you to manage inventory items and customers, as well as handle checkouts and returns.

## Features

- CRUD operations for inventory items
- CRUD operations for customers
- Checkout items to customers
- Return items and update inventory
- Quantity management for inventory items

## Technologies Used

- ASP.NET Core
- Entity Framework
- PostgreSQL
- ElephantSQL (Cloud-based PostgreSQL database)

## Setup

### Prerequisites

- .NET SDK
- PostgreSQL database
- ElephantSQL account (optional)

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/YourUsername/InventoryManagementSystem.git
    ```

2. Navigate to the project directory:

    ```bash
    cd InventoryManagementSystem
    ```

3. Install the required packages:

    ```bash
    dotnet restore
    ```

4. Update the `appsettings.json` file with your PostgreSQL database connection string.

5. Run the migration to set up the database:

    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

6. Run the project:

    ```bash
    dotnet run
    ```

## Usage

The API provides the following endpoints:

- `GET /api/Inventory`: Fetch all inventory items
- `POST /api/Inventory`: Add a new inventory item
- `PUT /api/Inventory/{id}`: Update an existing inventory item
- `DELETE /api/Inventory/{id}`: Delete an inventory item

- `GET /api/Customer`: Fetch all customers
- `POST /api/Customer`: Add a new customer

- `GET /api/Checkout`: Fetch all checkouts
- `POST /api/Checkout`: Checkout an item to a customer
- `PUT /api/Checkout/return/{id}`: Return a checked-out item

## Contributing

Feel free to fork the project and submit a pull request with your changes!

---

You can add this content to a `README.md` file in the root directory of your project. Feel free to modify it as you see fit!