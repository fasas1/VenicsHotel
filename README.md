# 🏨 VenicsHotel (ASP.NET Core MVC – Clean Architecture)

**VenicsHotel** is a modular hotel management backend built with **ASP.NET Core MVC** using **Clean Architecture** principles. It emphasizes separation of concerns, scalability, and testability while managing hotel operations such as room bookings, guest management, and user roles.

---

## 🧱 Architecture Overview

The application uses a layered Clean Architecture pattern with the following key layers:

- **Domain** – Contains enterprise business rules (Entities, Enums, Interfaces)
- **Application** – Application-specific business logic (Use Cases, DTOs, Interfaces)
- **Infrastructure** – Implements external concerns like database access, identity
- **WebUI (MVC)** – Handles UI (Razor Views), user interaction, and API endpoints

---

## 🛠️ Tech Stack

- ASP.NET Core MVC (.NET 7)
- Entity Framework Core
- Razor Views
- ASP.NET Identity (JWT or cookie auth)
- SQL Server (via EF Core)
- AutoMapper
- FluentValidation

---

## 📁 Folder Structure

