# TaskLink

A home-services marketplace connecting customers with skilled artisans (electricians, carpenters, mechanics, plumbers, and more).

Built with **ASP.NET Core 8 MVC**, **Entity Framework Core**, and **SQL Server** as part of the CIT 301 — Internet Programming II semester project at the University of Ghana.

---

## Features

- **Customer & Provider registration** with role-based flows
- **Provider profile creation** — trade, bio, location, contact, availability
- **Search & filter** providers by trade and location
- **Provider detail page** with direct call and WhatsApp contact links
- **ASP.NET Core Identity** authentication

---

## Tech Stack

| Layer | Technology |
|---|---|
| Web Framework | ASP.NET Core 8 MVC |
| UI | Razor Views + Bootstrap 5 |
| ORM | Entity Framework Core 8 |
| Database | SQL Server (LocalDB for dev) |
| Auth | ASP.NET Core Identity |
| Deployment | Docker → Render / Railway |

---

## Getting Started (Local)

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server or SQL Server Express (LocalDB works)
- Visual Studio Code with C# Dev Kit extension

### Run locally

```bash
# 1. Clone the repo
git clone https://github.com/YOUR_USERNAME/TaskLink.git
cd TaskLink

# 2. Restore packages
cd TaskLink
dotnet restore

# 3. Apply database migrations
dotnet ef database update

# 4. Run
dotnet run
```

App will be available at `https://localhost:5001` (or the port shown in the terminal).

### Connection string
The default connection string in `appsettings.json` uses SQL Server LocalDB:
```
Server=(localdb)\mssqllocaldb;Database=TaskLinkDb;Trusted_Connection=True
```
For production, set the `ConnectionStrings__DefaultConnection` environment variable in your deployment platform.

---

## Project Structure

```
TaskLink/
├── Controllers/          # HomeController, AccountController, ProviderController
├── Models/               # ApplicationUser, ProviderProfile, ViewModels
├── Data/                 # AppDbContext + EF Core migrations
├── Views/                # Razor Views (Home, Account, Provider, Shared)
├── wwwroot/              # Static assets (CSS, JS)
├── Program.cs
└── appsettings.json
```

---

## Team — CIT 301 Group

| Name | Index Number | Role |
|---|---|---|
| Immanuel Oheneba Debe | 22243130 | Team Lead / Project Coordinator |
| Benedicta Emefa Kumah | 10737998 | Frontend Development |
| Jonas Kudzo Amuzu | 22198544 | Frontend Development |
| Cedric Dzodzodzi | 22046156 | Backend Development |
| David Edu Turkson | 22012947 | Backend Development |
| Glorious James Okyere | 22031299 | Backend Development |
| Adjei Asaph Adjetey | 22242385 | Database & Data Access |
| Nana Adwoa Aforo Osei | 22028283 | Database & Data Access |
| Selina Odoi | 22013807 | Testing & QA |
| Bilson Priscilla Essirifua | 22015128 | Testing & QA |
| Emerald Aryee | 22032619 | Documentation & Presentation |
| Meshach Ashitei Amarh | 22231662 | Documentation & Presentation |
