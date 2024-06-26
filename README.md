# Project Overview

This repository hosts an Azure Functions application that serves as a REST API for efficient data management. The structure of the project and detailed guidance on managing database migrations using Entity Framework Core tools are provided below.

## Project Structure

- **Config**: Includes all necessary configurations for the application's functionality. Be sure to set up the required environment variables in this directory.
- **Controllers**: Contains REST controllers that manage the API endpoints. Each controller handles the requests and responses for its respective endpoints.
- **Migrations**: Stores the database migration files, which allow for version-controlled, incremental modifications to the database schema.
- **Models**: Holds the data models that represent the database entities, essential for ORM (Object-Relational Mapping) operations.

## Manage Migrations

These steps will guide you on how to effectively manage your database migrations. It's assumed that .NET Core is installed and set up on your system.

### Prerequisites

Make sure you have installed:
- **.NET Core SDK**: Necessary for executing .NET commands. You can download it from [here](https://dotnet.microsoft.com/download).
- **Entity Framework Core Tools**: Tools required for database migration management.

### Installation

1. **Install Entity Framework Core Tools**
   Use the following command to install EF Core command-line tools globally on your machine. These tools are essential for creating and managing database migrations.

   ```bash
   dotnet tool install --global dotnet-ef --version 3.*
   ```

1. **Set the Database Connection String**

Configure your database connection string through your environment variables:

   ```bash
   $env:DefaultConnection="{connectionString}"
   ```

Replace {connectionString} with your actual database connection string.


This section is focused on setting up the necessary tools and environment for managing database migrations, specifically installing EF Core tools and configuring the database connection string.

3. Update migrations
dotnet ef migrations add {migrationName}

4. Apply changes to database
dotnet ef database update


To implement clean arch with DTO validation check out : https://medium.com/@yusufsarikaya023/clean-architecture-in-serverless-azure-function-713582c7dc9b
