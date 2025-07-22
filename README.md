# Employee CRUD – Angular + .NET 8 Web API

A full‑stack demo application built as part of an interview technical task. It demonstrates clean layering, validation, mapping, and a simple Angular Material UI with CRUD, search, and pagination.

## Tech Stack
- .NET 8 Web API
- Entity Framework Core (SQLite)
- FluentValidation
- AutoMapper
- Swagger / OpenAPI
- Angular + Angular Material

angular-dotnet-employee-crud/
├─ README.md
├─ .gitignore
├─ backend/
│  ├─ Employees.sln
│  └─ src/
│     ├─ Employees.Domain/
│     ├─ Employees.Application/
│     ├─ Employees.Infrastructure/
│     └─ Employees.Api/
│  └─ tests/
│     └─ Employees.IntegrationTests/ (optional)
└─ frontend/
   └─ employees-ui/
      ├─ src/
      │  ├─ app/
      │  │  ├─ core/
      │  │  ├─ features/
      │  │  │  └─ employees/
      │  │  └─ shared/
      │  └─ environments/
      └─ ... Angular standard files


## Quick Start

### 1. Clone
```bash
git clone <this-repo-url>
cd angular-dotnet-employee-crud


cd backend/src/Employees.Api
# Restore & build
dotnet restore
# Apply EF Core migration
dotnet ef database update --project ../Employees.Infrastructure --startup-project .
# Run
dotnet run

cd ../../frontend/employees-ui
npm install
ng serve --proxy-config proxy.conf.json --open
