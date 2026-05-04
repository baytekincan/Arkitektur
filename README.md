# 🏗️ Arkitektur

A modern .NET 9 backend service designed for architecture-focused applications.

Built with **layered architecture** and **clean design principles**, Arkitektur offers a scalable, maintainable, and production-ready backend solution for architecture-related platforms.

---

## 🚀 Features

- Layered Architecture
- Repository and Unit of Work patterns
- Clean separation of concerns
- JWT Authentication & Authorization
- Role and User management
- FluentValidation integration
- AWS S3 image upload support
- Centralized response model
- Automatic dependency injection with Scrutor
- API documentation with Scalar (OpenAPI)

---

## 🛠 Tech Stack

| Category       | Technology                        |
|----------------|-----------------------------------|
| Backend        | C#, .NET 9                        |
| ORM            | Entity Framework Core             |
| Validation     | FluentValidation                  |
| Mapping        | Mapster                           |
| DI             | Built-in DI + Scrutor             |
| Storage        | AWS S3                            |
| Auth           | JWT                               |
| Database       | SQL Server                        |

---

## 🧱 Project Architecture

```text
Arkitektur
│
├── Arkitektur.Api
│   ├── Controllers        # HTTP endpoints & request handling
│   ├── Properties         # Launch settings & project metadata
│   └── Program.cs         # Application bootstrap & pipeline setup
│
├── Arkitektur.Business
│   ├── Base               # Result pattern & base DTO definitions
│   ├── DTOs               # Request / Response data models
│   ├── Extensions         # Dependency injection & helper extensions
│   ├── Options            # JWT 
│   ├── Services           # Business logic & use case implementations
│   └── Validators         # FluentValidation rules
│
├── Arkitektur.Entity
│   ├── Entities           # Core domain entities
│   ├── Enums              # Domain-specific enums
│
├── Arkitektur.DataAccess
│   ├── Context            # Entity Framework DbContext
│   ├── Extensions         # EF Core & database configuration extensions
│   ├── Interceptors       # EF Core save/change interceptors
│   ├── Migrations         # Database schema migrations
│   ├── Repositories       # Repository implementations
│   └── UOW                # Unit of Work pattern

```

## 🔐 Authentication

JWT-based authentication is implemented.

### Endpoints

| Method | Endpoint                | Description                  |
|--------|-------------------------|------------------------------|
| POST   | `/api/Users/register`   | Register a new user          |
| POST   | `/api/Users/login`      | Login and receive JWT token  |

---

## 👤 Roles & Authorization

| Method | Endpoint                      | Description                    |
|--------|-------------------------------|--------------------------------|
| GET    | `/api/Roles`                  | Get all roles                  |
| POST   | `/api/Roles/CreateRole`       | Create a new role              |
| GET    | `/api/RoleAssings/{userId}`   | Get roles for a specific user  |
| POST   | `/api/RoleAssings`            | Assign roles to a user         |

---

## 📁 Projects

| Method | Endpoint                        | Description                        |
|--------|---------------------------------|------------------------------------|
| GET    | `/api/Projects`                 | Get all projects                   |
| GET    | `/api/Projects/{id}`            | Get project by ID                  |
| GET    | `/api/Projects/WithCategories`  | Get projects with category details |
| POST   | `/api/Projects`                 | Create a new project               |
| PUT    | `/api/Projects`                 | Update project                     |
| DELETE | `/api/Projects/{id}`            | Delete project                     |

---

## 🗂 Categories

| Method | Endpoint                       | Description                    |
|--------|--------------------------------|--------------------------------|
| GET    | `/api/Categories`              | Get all categories             |
| GET    | `/api/Categories/{id}`         | Get category by ID             |
| GET    | `/api/Categories/WithProjects` | Get categories with projects   |
| POST   | `/api/Categories`              | Create a new category          |
| PUT    | `/api/Categories`              | Update category                |
| DELETE | `/api/Categories/{id}`         | Delete category                |

---

## 📅 Appointments

| Method | Endpoint                    | Description           |
|--------|-----------------------------|-----------------------|
| GET    | `/api/Appointments`         | Get all appointments  |
| GET    | `/api/Appointments/{id}`    | Get appointment by ID |
| POST   | `/api/Appointments`         | Create appointment    |
| PUT    | `/api/Appointments`         | Update appointment    |
| DELETE | `/api/Appointments/{id}`    | Delete appointment    |

---

## 🧾 Other Entities

The following entities have full CRUD operations:

- **About**
- **Banners**
- **Features**
- **Chooses**
- **Contacts**

**Example Endpoints:**
- `GET /api/Abouts`
- `GET /api/Banners`
- `GET /api/Features`
- `GET /api/Chooses`
- `GET /api/Contacts`

---

## 🖼 Image Upload (AWS S3)

| Method | Endpoint             |
|--------|----------------------|
| POST   | `/api/Images/upload` |

- **Content Type:** `multipart/form-data`
- **Field Name:** `file`

---

## 📦 Response Structure

All API responses follow a standardized format:

    {
      "success": true,
      "data": {},
      "message": "string"
    }

---

## 📖 API Documentation

You can explore and test the API using Scalar UI:

👉 https://localhost:7083/scalar/

---

## ⚙️ Installation

### 📋 Prerequisites

- .NET 9 SDK  
- SQL Server  
- AWS S3 Bucket (Access Key & Secret Key)

---

### 🚀 Setup

    git clone https://github.com/baytekincan/Arkitektur.git
    cd Arkitektur
    dotnet restore
    dotnet ef database update
    dotnet run

---

## 🌐 Base URL

    https://localhost:7083

---
## 👨‍💻 Author

**Can Baytekin**

[![GitHub](https://img.shields.io/badge/GitHub-baytekincan-181717?style=flat&logo=github&logoColor=white)](https://github.com/baytekincan)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-baytekincan-0A66C2?style=flat&logo=linkedin&logoColor=white)](https://linkedin.com/in/baytekincan)
