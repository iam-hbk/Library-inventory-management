
# Library Inventory Management System

## Overview

This project is a Library Inventory Management System built using ASP.NET Core and Entity Framework. The system allows you to manage inventory items, customers, and handle checkouts and returns.

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

## Setup

### Prerequisites

- .NET SDK
- PostgreSQL database

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/iam-hbk/Library-inventory-management.git
    ```

2. Navigate to the project directory:

    ```bash
    cd Library-inventory-management
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

## API Endpoints

- `GET /api/Inventory`: Fetch all inventory items
- `POST /api/Inventory`: Add a new inventory item
- `PUT /api/Inventory/{id}`: Update an existing inventory item
- `DELETE /api/Inventory/{id}`: Delete an inventory item

- `GET /api/Customer`: Fetch all customers
- `POST /api/Customer`: Add a new customer

- `GET /api/Checkout/logs`: Fetch all checkouts
- `POST /api/Checkout`: Checkout an item to a customer
- `PUT /api/Checkout/return/{id}`: Return a checked-out item

## Contributing

Feel free to fork the project and submit a pull request with your changes!

---
