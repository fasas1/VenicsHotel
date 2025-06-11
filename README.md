# 🏨 VenicsHotel (ASP.NET Core MVC – Clean Architecture)

---

## 🚀 Features by Layer

### ✅ Domain
- Entities and domain logic
- Value objects & domain events

### 🛠️ Application
- Commands & Queries via **MediatR**
- FluentValidation for input
- AutoMapper for DTO/view-model mapping

### 💾 Infrastructure
- EF Core DbContext & migrations
- ASP.NET Identity for roles (Admin, Staff, Guest)
- Repository abstractions for persistence

### 🌐 WebUI (MVC)
- Razor Pages & Controllers
- Forms for booking, user registration, login
- Role-based UI navigation
- Server-side validation feedback

---

## 🛠️ Getting Started

### 🔧 Prerequisites
- [.NET 7+ SDK]
- SQL Server (LocalDB or full)
- Visual Studio or VS Code

### ✅ Setup Steps

```bash
git clone https://github.com/fasas1/VenicsHotel.git
cd VenicsHotel

# Restore and build
dotnet restore
dotnet build

# Apply migrations
cd Infrastructure
dotnet ef migrations add InitialCreate -p Infrastructure -s WebUI
dotnet ef database update -p Infrastructure -s WebUI

# Run the application
cd WebUI
dotnet run
