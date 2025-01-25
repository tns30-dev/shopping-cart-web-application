# Shopping Cart Web Application


## Overview

The Shopping Cart Web Application is a the project designed for managing and purchasing products. It features user authentication, customer management, product cataloging, purchasing history tracking, cart management, and activation key assignment. The system is designed with a focus on functionality, ease of use, and robust backend support.

## Features

- **User Authentication**: Secure login using password hashes.
- **Customer Management**: Store and manage customer details.
- **Product Management**: Add, update, and display products with descriptions, prices, and images.
- **Product Cart Management**: Perform cart management operations such as adding or removing products.
- **Purchasing History**: Logged-in users can view their purchasing history.
- **Activation Keys**: Associate activation keys with products and customers for licensing.

## Technologies Used

- **Backend**: ASP.NET Core with Entity Framework Core.
- **Frontend**: Razor, JavaScript
- **Database**: MySQL
- **ORM**: Entity Framework Core
- **Programming Language**: C#

## Setup Instructions

### Prerequisites

1. .NET SDK installed ([Download](https://dotnet.microsoft.com/download)).
2. MySQL database installed and running.

### Steps

1. Clone this repository:
   ```bash
   git clone git@github.com:tns30-dev/shopping-cart-web-application.git
   ```
2. Navigate to the project directory:
   ```bash
   cd SoftwareSellingCA
   ```
3. Update the database connection string in `MyDbContext.cs`:
   ```csharp
   optionsBuilder.UseMySql(
       "server=localhost;user=root;password=[your_password];database=shoppingcartdb;port=3306;",
       new MySqlServerVersion(new Version(8, 0, 36))
   );
   ```
4. Apply migrations and update the database:
   ```bash
   dotnet ef database update
   ```
5. Run the application:
   ```bash
   dotnet run
   ```

## Usage

1. Launch the application.
2. Authenticate using one of the predefined users:
   - Username: `chris`, Password: `chris123`
   - Username: `emily`, Password: `emily123`
3. Explore product details, manage the product cart, view customer purchasing history, and products search bar.

## Credits

1. Built by Thet Naung Soe and Soh Yong Sheng.
2. Submitted as module project for NUS-ISS Graduate Certificate in Enterprise Solutions Development.



