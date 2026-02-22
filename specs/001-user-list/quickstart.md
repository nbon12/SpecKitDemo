# Quickstart Guide: User List Display

**Feature**: User List Display  
**Date**: 2025-01-27

## Overview

This guide provides step-by-step instructions for setting up and running the User List Display feature locally.

## Prerequisites

- Docker and Docker Compose installed
- .NET 8.0 SDK installed
- Node.js 18+ and npm installed
- Angular CLI installed globally: `npm install -g @angular/cli`

## Setup Steps

### 1. Start PostgreSQL Database

```bash
# From repository root
docker-compose up -d
```

This starts PostgreSQL in a Docker container. The database will be available at `localhost:5432`.

### 2. Initialize Backend (.NET API)

```bash
# Create backend project using dotnet CLI (per constitution)
cd backend
dotnet new webapi -n SpecKitDemoApi
cd SpecKitDemoApi
```

**Note**: Per constitution, .NET API projects must be created using `dotnet new webapi -n <name>` and must use "Spec Kit Demo" as the project name base (SpecKitDemoApi for backend).

# Add required packages
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

# Create database migration
dotnet ef migrations add InitialCreate
dotnet ef database update

# Run the API
dotnet run
```

The API will be available at `http://localhost:5000` (or the port configured in `launchSettings.json`).

### 3. Initialize Frontend (Angular)

```bash
# Create Angular project (if not exists) - per constitution naming convention
cd frontend
ng new spec-kit-demo
cd spec-kit-demo

# Add Angular Material
ng add @angular/material

# Generate user-list component using Angular CLI (per constitution)
ng generate component user-list
# Or shorthand: ng g c user-list

# Generate user service using Angular CLI (per constitution)
ng generate service user
# Or shorthand: ng g s user

# Run the frontend
ng serve
```

The frontend will be available at `http://localhost:4200`.

**Note**: Per constitution, all Angular components and services must be created using Angular CLI scaffolding commands (`ng generate`) rather than manually creating files. The frontend project name uses "spec-kit-demo" (kebab-case) per constitution naming convention.

### 4. Verify Setup

1. Navigate to `http://localhost:4200/users` in your browser
2. You should see the users page (may be empty if no users in database)
3. Check browser console and network tab for any errors

## Database Configuration

### Connection String

The backend should use this connection string (adjust as needed):

```
Host=localhost;Port=5432;Database=userlistdb;Username=postgres;Password=postgres
```

### Create Sample Data

You can insert sample users directly into the database:

```sql
INSERT INTO "Users" ("Username", "Email") VALUES
('johndoe', 'john@example.com'),
(NULL, 'jane@example.com'),
('bobsmith', 'bob@example.com');
```

## Testing

### Backend Tests

```bash
cd backend/SpecKitDemoApi
dotnet test
```

### Frontend Tests

```bash
cd frontend/spec-kit-demo
ng test
```

## Troubleshooting

### Database Connection Issues

- Verify PostgreSQL is running: `docker ps`
- Check connection string matches docker-compose.yaml configuration
- Verify database exists: `docker exec -it <container-name> psql -U postgres -l`

### CORS Issues

If the frontend cannot call the backend API:
- Ensure CORS is configured in `Program.cs` to allow requests from `http://localhost:4200`
- Check browser console for CORS error messages

### Port Conflicts

- Backend default: 5000 (HTTP) or 5001 (HTTPS)
- Frontend default: 4200
- PostgreSQL default: 5432
- Adjust ports in configuration files if conflicts occur

## Next Steps

After setup is complete:
1. Review the [data model](./data-model.md) for database schema details
2. Review the [API contracts](./contracts/users-api.yaml) for endpoint specifications
3. Follow the [tasks.md](./tasks.md) (when generated) for implementation steps

## Development Workflow

1. **Start services**: `docker-compose up -d` (database)
2. **Run backend**: `cd backend/SpecKitDemoApi && dotnet run`
3. **Run frontend**: `cd frontend/spec-kit-demo && ng serve`
4. **Make changes**: Edit code, tests will run automatically
5. **Verify**: Check browser at `http://localhost:4200/users`

## Environment Variables

### Backend

- `ConnectionStrings__DefaultConnection`: PostgreSQL connection string
- `ASPNETCORE_ENVIRONMENT`: Set to `Development` for local development

### Frontend

- `API_BASE_URL`: Backend API URL (default: `http://localhost:5000/api`)

## Docker Compose Configuration

The `docker-compose.yaml` should include:

```yaml
version: '3.8'
services:
  postgres:
    image: postgres:15
    environment:
      POSTGRES_DB: userlistdb
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: postgres
    ports:
      - "5432:5432"
    volumes:
      - postgres_data:/var/lib/postgresql/data

volumes:
  postgres_data:
```

## Notes

- Database data persists in Docker volume `postgres_data`
- To reset database: `docker-compose down -v` (removes volume)
- Backend and frontend run outside Docker for easier development
- Production deployment would containerize all services

