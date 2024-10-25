# Employee Management API

## Overview
This project provides a backend API for managing employees, departments, and companies. Built with **ASP.NET Core 6.0 and MS SQL Server**, the project incorporates **AutoMapper** for seamless data mapping, **MediatR with CQRS** for a clean separation of responsibilities, and **Swagger** for comprehensive API documentation.

## Features
- **Employee Management:** Add, update, view, and delete employee, including department and company details.
- **Filter & Pagination:** Retrieve employee, department, company data with filter and pagination support.
- **Department & Company Management:** Full CRUD operations for departments, employees and companies.
- **Clean Architecture:** Implements CQRS with MediatR for organized, scalable code.
- **API Documentation:** Includes Swagger for user-friendly, interactive documentation.

## Technologies Used
- **ASP.NET Core 6.0**: Framework for building the web API.
- **Entity Framework Core**: ORM for database interaction using the Code First approach.
- **MsSQL**: Database management system.
- **MediatR**: For implementing CQRS (Command Query Responsibility Segregation).
- **AutoMapper:** For mapping domain models to Data Transfer Objects (DTOs).
- **Swagger**: For API documentation and testing.

## Getting Started

### Prerequisites
- [.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Rider](https://www.jetbrains.com/rider/) for development (optional).

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/jsiya/employee-management.git
   cd employee-management
   
2. Set up the database:
   -Update the appsettings.json file with your SQL Server connection string.
   -Apply migrations to set up the database schema:
   ```bash
   dotnet ef database update
3. Start the application:
   ```bash
   dotnet run
4. Access the API documentation by navigating to http://localhost:<port>/swagger.


## 📌 API Endpoints

| Resource       | Method | Endpoint                   | Description                        |
|----------------|--------|----------------------------|------------------------------------|
| **Employee**   | GET    | `/api/employees`          | Get a list of employees       |
|                | GET    | `/api/employees/{id}`     | Get details of a specific employee |
|                | POST   | `/api/employees`          | Add a new employee                 |
|                | PUT    | `/api/employees/{id}`     | Update an employee                 |
|                | DELETE | `/api/employees/{id}`     | Delete an employee                 |
| **Department** | GET    | `/api/departments`        | Get a list of departments     |
|                | GET    | `/api/departments/{id}`   | Get details of a specific department |
|                | POST   | `/api/departments`        | Add a new department               |
|                | PUT    | `/api/departments/{id}`   | Update a department                |
|                | DELETE | `/api/departments/{id}`   | Delete a department                |
| **Company**    | GET    | `/api/companies`          | Get a list of companies       |
|                | GET    | `/api/companies/{id}`     | Get details of a specific company  |
|                | POST   | `/api/companies`          | Add a new company                  |
|                | PUT    | `/api/companies/{id}`     | Update a company                   |
|                | DELETE | `/api/companies/{id}`     | Delete a company                   |

## 📌 Filtering and Pagination
The API supports filtering and pagination for retrieving employee data efficiently. Below are some examples:

**Employee Filtering**
To filter employees based on specific criteria, use query parameters:
| Parameter           | Type | Description                        |
|---------------------|-------|------------------------------------|
| **DepartmentId**    | int    | Filter employees by department ID      |
| **CompanyId**       | int    | Get a list of departments     |

**Example request:**
```bash
    GET /api/employees?DepartmentId=2&CompanyId=1
```

**Pagination**
To filter employees based on specific criteria, use query parameters:
| Parameter           | Type | Description                        |
|---------------------|-------|------------------------------------|
| **Page**    | int    | Page number (starting from 1)     |
| **PageSize**       | int    | Number of results per page     |

**Example request:**
```bash
    GET /api/employees?Page=1&PageSize=10
```

**Combined Example**
```bash
GET api/employees?CompanyId=9&Page=2&PageSize=10
