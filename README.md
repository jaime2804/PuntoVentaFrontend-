# Point of Sale - Web Frontend

## About

Point of sale system developed for a local supermarket in Upala, Costa Rica. Built as a real-world project with full business module coverage including sales, inventory, payroll and cash register management.

## Overview

ASP.NET MVC web application that serves as the frontend for the Point of Sale system. Consumes the PuntoVentaAPI REST API using HttpClient, with session-based authentication backed by JWT tokens.

## Tech Stack

- **Framework:** ASP.NET Core MVC (.NET 8)
- **Views:** Razor Pages (.cshtml)
- **Authentication:** JWT tokens stored in server-side sessions
- **UI Libraries:** Bootstrap, SB Admin 2, jQuery, jQuery UI
- **Components:** Chart.js, DataTables, Select2, SweetAlert, Toastr, FontAwesome

## Architecture
```
PuntoVentaWeb (MVC Frontend)
        ↓ HttpClient
PuntoVentaAPI (REST API Backend)
        ↓ Dapper + Stored Procedures
SQL Server Database
```

## Authentication Flow

1. User submits login credentials
2. MVC app sends request to API
3. API validates and returns JWT token
4. Token is stored in server-side session
5. `FiltroSesiones` attribute protects all routes
6. Each API request includes the JWT token in the header

## Modules

- **Dashboard** - Sales metrics and charts
- **Products** - Product catalog management
- **Categories** - Category management
- **Inventory** - Stock tracking and movements
- **Cart** - Shopping cart and sales processing
- **Invoices** - Invoice generation and consultation
- **Employees** - Employee management
- **Payroll** - Payroll processing
- **Suppliers** - Supplier management
- **Cash Register** - Cash audit (arqueo) and weekly closing

## Related Repository

This project requires the API to be running:
[PuntoVentaAPI](https://github.com/jaime2804/PuntoVentaAPI-)

## Getting Started

### Prerequisites
- .NET 8 SDK
- PuntoVentaAPI running locally

### Installation

1. Clone the repository
```bash
git clone https://github.com/jaime2804/PuntoVentaFrontend-.git
cd PuntoVentaFrontend-
```

2. Create `appsettings.json` based on the example
```bash
cp appsettings.example.json appsettings.json
```

3. Update the API URL in `appsettings.json`

4. Run the project
```bash
dotnet run
```

## Technical Decisions

- **Session-based auth with JWT** - JWT token stored server-side for security, preventing token exposure in the browser
- **FiltroSesiones attribute** - Custom action filter that redirects unauthenticated users to login
- **HttpClient** - Communicates with the REST API, keeping frontend and backend fully decoupled
- **Razor Views** - Server-side rendering for fast initial page loads
