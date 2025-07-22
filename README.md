# Employee CRUD – Angular + .NET 8 Web API

<img width="1852" height="775" alt="Edit Employee" src="https://github.com/user-attachments/assets/0fd9abb4-6c91-4905-acff-775ef9ec3cc3" />
<img width="1857" height="776" alt="Add Employee" src="https://github.com/user-attachments/assets/a151aac5-37a5-40db-bd79-4051c5961dab" />
<img width="1895" height="741" alt="Get Employee" src="https://github.com/user-attachments/assets/23db4513-9beb-4ac4-bbe1-db483e81e435" />
<img width="1855" height="775" alt="Delete Emplyee" src="https://github.com/user-attachments/assets/9614786a-b6c8-412c-b31c-700947fb368f" />



A full‑stack demo application built as part of an interview technical task. It demonstrates clean layering, validation, mapping, and a simple Angular Material UI with CRUD, search, and pagination.

## Tech Stack
- .NET 8 Web API
- Entity Framework Core (SQLite)
- FluentValidation
- AutoMapper
- Swagger / OpenAPI
- Angular + Angular Material


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



