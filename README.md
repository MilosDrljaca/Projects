# Project Management Application

A multi-layer ASP.NET Core MVC application built using Clean Architecture and Layered Architecture principles.  
The system manages **Projects**, **Managers**, and the relationship between them.  
The architecture ensures maintainability, testability, and clear separation of concerns.

---

## ⭐ Architecture Overview

The solution is organized into four logical layers:

### **1. Domain Layer**
Contains pure domain entities independent from any framework.

- `Manager.cs`
- `Project.cs`

### **2. Data Access Layer (Infrastructure)**
Implements persistence using Entity Framework Core and the Repository Pattern.

Includes:
- `ApplicationDbContext.cs`
- `Repositories/`
- `Migrations/`
- `CustomExceptions/`

Database engine used:
- **SQL Server**
- Managed with **SQL Server Management Studio (SSMS)**

### **3. Service Layer (Business Logic)**
Handles core system logic and validation.

Includes:
- `Interfaces/` (service contracts)
- `ManagerService.cs`
- `ProjectService.cs`
- `CustomException/`

### **4. MVC Layer (Presentation Layer)**
ASP.NET Core MVC application used to interact with the system.

Contains:
- Controllers (`ProjectController`, `ManagerController`)
- Views (Razor Views)
- ViewModels (`PaginatedList`, `ErrorViewModel`)
- Static files in `wwwroot/`
- `Program.cs` / `Startup.cs`

---

## 📁 Folder Structure

```
Solution 'Projects'
│
├── Domain
│   ├── DataAccessLayer
│   │   ├── ApplicationDbContext.cs
│   │   ├── Migrations/
│   │   ├── Repositories/
│   │   └── CustomExceptions/
│   ├── DomainModel
│       ├── Manager.cs
│       └── Project.cs
│
├── Service
│   └── Services
│       ├── Interfaces/
│       ├── CustomException/
│       ├── Models/
│       ├── ManagerService.cs
│       └── ProjectService.cs
│
└── MVC
    └── Projects
        ├── Controllers/
        ├── Models/
        ├── Views/
        ├── wwwroot/
        ├── appsettings.json
        ├── Program.cs
        └── Startup.cs
```

---

## 🔄 Request Flow

```
User Request
   ↓
Controller
   ↓
Service Layer
   ↓
Repository
   ↓
EF Core
   ↓
Database (SQL Server)
   ↓
Controller returns View
```

---

## 🗄️ Database Setup (Required Before Running)

This project uses **Entity Framework Core Code-First Migrations**.

Before starting the application for the first time, run:

### Using Package Manager Console:
```
update-database
```

### Using .NET CLI:
```
dotnet ef database update
```

This will:
- Create the SQL Server database
- Apply all migrations
- Create required tables (`Projects`, `Managers`, …)

---

## ▶️ Running the Application

### **Using .NET CLI**
```
dotnet build
dotnet run --project Projects
```

The application will typically run on:

- `http://localhost:5000`  
- `https://localhost:5001`

### **Using Visual Studio**
1. Set `Projects` (MVC project) as **Startup Project**
2. Build: *Build > Build Solution*
3. Run:
   - *Debug > Start Debugging*
   - or *Debug > Start Without Debugging*

---

## 🔐 HTTPS Certificate Notes (Local Development)

ASP.NET Core uses a **developer HTTPS certificate**.  
If you see this message in terminal:

```
The ASP.NET Core developer certificate is not trusted.
```

Trust it with:

```
dotnet dev-certs https --trust
```

If Chrome still shows *“Your connection is not private”*:

1. Visit: `chrome://net-internals/#hsts`
2. Delete HSTS for domain `localhost`
3. Clear SSL cache (Control Panel → Internet Options → Content → Clear SSL state)
4. Restart Chrome

---

## 🧰 Tech Stack

- ASP.NET Core MVC  
- Entity Framework Core (Code-First)  
- SQL Server & SQL Server Management Studio (SSMS)  
- C# / LINQ  
- Razor Views  
- Bootstrap / JavaScript  
- Visual Studio  
- .NET CLI / EF Core Tools  

---

## 📝 Summary

This project follows a clean layered architecture with clear separation between domain, data, service, and presentation layers.  
The solution is fully extensible and suitable for real-world CRUD solutions involving business logic, database access, and MVC presentation.

