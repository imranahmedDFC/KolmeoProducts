# Kolmeo Products API
This is a simple API for managing products, built using ASP.NET Core and Entity Framework Core.

## Description
The Kolmeo Products API allows you to add and retrieve products through a public endpoint. It provides basic Create, Read, and Update operations for managing products. The API is built using ASP.NET Core and utilizes Entity Framework Core for data persistence.

## Installation
To run the API locally, follow these steps:

1. Clone the repository to your local machine.
2. Open the project in Visual Studio.
3. Build the solution to restore NuGet packages.
4. Run the project.

## Usage
Once the API is up and running, you can interact with it using an HTTP client or tools like Postman. The API provides the following endpoints:

* GET /api/products/getproducts: Retrieve all products.
* GET /api/products/GetProductById/{id}: Retrieve a specific product by ID.
* POST /api/products/addproduct: Add a new product.
* PUT /api/products/updateproduct?id={id}: Update an existing product by ID.

## Examples
Here are some example requests and responses for the API endpoints:
* Retrieve all products:
    GET /api/products/getproducts
    Response: 200 OK
    `{
    "success": true,
    "message": null,
    "data": null,
    "products": [
        {
            "id": 1,
            "name": "Prod 1",
            "description": "Test 1 Prod",
            "price": 100
        },
        {
            "id": 2,
            "name": "Prod 2",
            "description": "Test 2 Prod",
            "price": 200
        }
    ]
}`

* Retrieve a specific product by ID:
    GET /api/products/GetProductById/{id}
    `
      {
        "success": true,
        "message": null,
        "data": {
            "id": 1,
            "name": "Prod 2",
            "description": "Test 2 Prod",
            "price": 100
        },
        "products": null
      }
    `

* Add a new product:
  POST /api/products/addproduct
  Request Body:
    `{
      "name": "New Product",
      "description": "New Product description",
      "price": 29.99
    }`
  Response: 200 OK
    `{
    "success": true,
    "message": [
        "Product with ID 1 created successfully!"
    ],
    "data": null,
    "products": null
    }` 

* Update an existing product by ID:
  PUT /api/products/updateproduct?id={id}
  Request Body:
    `{      
      "price": 29.99
    }`
  Response: 200 OK
    `{
    "success": true,
    "message": [
        "Product with ID 1 updated successfully!"
    ],
    "data": null,
    "products": null
    }` 
