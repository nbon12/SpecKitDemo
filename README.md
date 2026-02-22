# Spec Kit Demo - User List Display

A full-stack web application demonstrating a user list display feature with Angular frontend and .NET Core backend API.

## Features

- Display list of users in a table format
- Angular Material UI components
- RESTful API with Entity Framework Core
- PostgreSQL database
- Test-driven development with comprehensive test coverage

## Prerequisites

- Docker and Docker Compose
- .NET 8.0 SDK
- Node.js 18+ and npm
- Angular CLI: `npm install -g @angular/cli`

## Quick Start

### 1. Start PostgreSQL Database

```bash
docker-compose up -d
```

### 2. Run Backend API

```bash
cd backend/SpecKitDemoApi
dotnet ef database update  # Apply migrations
dotnet run
```

The API will be available at `http://localhost:5000` (or check `launchSettings.json` for the configured port).

### 3. Run Frontend

```bash
cd frontend/spec-kit-demo
ng serve
```

The frontend will be available at `http://localhost:4200`.

### 4. View Application

Navigate to `http://localhost:4200/users` to see the user list.

## Project Structure

```
.
├── backend/
│   └── SpecKitDemoApi/          # .NET 8.0 Web API
│       ├── Controllers/         # API controllers
│       ├── Services/            # Business logic
│       ├── Models/              # Data models
│       ├── Data/                # EF Core DbContext
│       └── tests/               # Test projects
├── frontend/
│   └── spec-kit-demo/           # Angular 17+ application
│       └── src/app/
│           ├── components/      # Angular components
│           ├── services/        # Angular services
│           └── models/          # TypeScript interfaces
└── docker-compose.yaml          # PostgreSQL service
```

## Database Configuration

The connection string is configured in `backend/SpecKitDemoApi/appsettings.json`:

```
Host=localhost;Port=5432;Database=speckit_demo;Username=speckit_user;Password=speckit_password
```

### Create Sample Data

You can insert sample users using SQL:

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

## API Endpoints

- `GET /api/users` - Retrieve all users

## Development

### Backend Development

- Uses Entity Framework Core code-first migrations
- Migrations: `dotnet ef migrations add <name>`
- Apply migrations: `dotnet ef database update`

### Frontend Development

- Uses Angular CLI for scaffolding (per constitution)
- Components: `ng generate component <name>`
- Services: `ng generate service <name>`

## Troubleshooting

### Database Connection Issues

- Verify PostgreSQL is running: `docker ps`
- Check connection string in `appsettings.json`
- Ensure database exists and migrations are applied

### CORS Issues

- Verify CORS is configured in `Program.cs` for `http://localhost:4200`
- Check browser console for CORS errors

### Port Conflicts

- Backend: 5000 (HTTP) or 5001 (HTTPS)
- Frontend: 4200
- PostgreSQL: 5432

## License

This is a demo project for SpecKit workflow demonstration.

