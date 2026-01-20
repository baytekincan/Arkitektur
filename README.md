# Arkitektur

.NET 9 backend service designed for architecture-focused applications.
Built with a **layered architecture** and **common design patterns**, Arkitektur serves as a scalable backend for individuals and organizations in the architecture domain.

---

## 🛠 Tech Stack & Libraries

| Category             | Tools / Libraries                  |
| -------------------- | ---------------------------------- |
| Backend              | C#, .NET 9                         |
| Data Access          | Entity Framework Core (Code-First) |
| Validation           | FluentValidation                   |
| Object Mapping       | Mapster                            |
| Dependency Injection | Built-in DI, Scrutor               |
| Storage              | AWS S3                             |
| Authentication       | JWT *(planned)*                    |

---

## 📦 Key Features

- Layered architecture (**API / Business / Entity / DataAccess**)
- Centralized business logic in the Business layer
- Repository & Unit of Work patterns
- Consistent API responses with **Result / Result<T>**
- Request validation using **FluentValidation**
- Automatic dependency registration with **Scrutor**
- AWS S3–based image storage
- API documentation via **Scalar**

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

---

## 🔌 API Endpoints

### 📁 Projects

| Method | Endpoint                       | Description                        |
| ------ | ------------------------------ | ---------------------------------- |
| GET    | `/api/Projects`                | Get all projects                   |
| GET    | `/api/Projects/{id}`           | Get project by id                  |
| GET    | `/api/Projects/WithCategories` | Get projects with category details |
| POST   | `/api/Projects`                | Create a new project               |
| PUT    | `/api/Projects`                | Update an existing project         |
| DELETE | `/api/Projects/{id}`           | Delete a project                   |

**POST / PUT Request Body**

```json
{
  "imageUrl": "string",
  "title": "string",
  "description": "string",
  "item1": "string",
  "item2": "string",
  "item3": "string",
  "categoryId": 1
}
```

**Required:** `imageUrl`, `title`, `description`, `item1`, `item2`, `item3`, `categoryId`

---

### 🗂 Categories

| Method | Endpoint                       | Description                          |
| ------ | ------------------------------ | ------------------------------------ |
| GET    | `/api/Categories`              | Get all categories                   |
| GET    | `/api/Categories/{id}`         | Get category by id                   |
| GET    | `/api/Categories/WithProjects` | Get categories with related projects |
| POST   | `/api/Categories`              | Create a new category                |
| PUT    | `/api/Categories`              | Update an existing category          |
| DELETE | `/api/Categories/{id}`         | Delete a category                    |

**POST / PUT Request Body**

```json
{
  "categoryName": "string"
}
```

**Required:** `categoryName`

---

### 📅 Appointments

| Method | Endpoint                 | Description                    |
| ------ | ------------------------ | ------------------------------ |
| GET    | `/api/Appointments`      | Get all appointments           |
| GET    | `/api/Appointments/{id}` | Get appointment by id          |
| POST   | `/api/Appointments`      | Create a new appointment       |
| PUT    | `/api/Appointments`      | Update an existing appointment |
| DELETE | `/api/Appointments/{id}` | Delete an appointment          |

**POST Request Body**

```json
{
  "nameSurname": "string",
  "email": "string",
  "appointmentDate": "2025-01-01T10:00:00Z",
  "phoneNumber": "string",
  "serviceName": "string",
  "message": "string"
}
```

**Required:** `nameSurname`, `email`, `appointmentDate`, `phoneNumber`, `serviceName`, `message`

---

### 🖼 Images (AWS S3)

| Method | Endpoint             | Description            |
| ------ | -------------------- | ---------------------- |
| POST   | `/api/Images/upload` | Upload image to AWS S3 |

**Request Type:** `multipart/form-data`

| Field | Type | Required |
| ----- | ---- | -------- |
| file  | File | ✅        |

---

### 📌 Other Endpoints

Additional resources are available.
Please explore the API documentation for the full list of endpoints.

---

## 📖 API Documentation

* **Scalar UI**:
  `https://localhost:7083/scalar/`

---

## ⚙️ Installation

### Prerequisites

* .NET 9 SDK
* SQL Server
* AWS S3 bucket and credentials

---

### Setup Steps

```bash
git clone https://github.com/baytekincan/Arkitektur.git
cd Arkitektur
dotnet restore
dotnet ef database update
dotnet run
```

The API will be available at:

```text
https://localhost:7083
```

---

## 🔐 Authentication

JWT-based authentication is **planned** and will be integrated in future versions.

---
