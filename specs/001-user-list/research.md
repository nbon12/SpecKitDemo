# Research: User List Display Feature

**Date**: 2025-01-27  
**Feature**: User List Display  
**Purpose**: Document technical decisions and best practices for implementation

## Technology Stack Decisions

### Backend: .NET Core with Entity Framework Core

**Decision**: Use .NET 8.0 with Entity Framework Core and Npgsql provider for PostgreSQL

**Rationale**: 
- Constitution mandates .NET Core backend
- Entity Framework Core is the standard ORM for .NET
- Npgsql is the official PostgreSQL provider for EF Core
- Provides code-first migrations for database schema management
- Supports async/await patterns for better performance

**Alternatives considered**:
- Dapper: More lightweight but requires more manual SQL
- ADO.NET: Too low-level, more boilerplate code
- **Chosen**: EF Core for better developer experience and alignment with .NET ecosystem

### CLI Scaffolding (Constitution Requirement)

**Decision**: Use `dotnet new webapi -n <name>` for .NET API project creation

**Rationale**:
- Constitution mandates use of `dotnet new webapi -n <name>` for new API projects
- Ensures consistent project structure and configuration
- Automatically includes necessary NuGet packages and project files
- Reduces setup time and prevents structural inconsistencies

**Implementation**:
- Project creation: `dotnet new webapi -n SpecKitDemoApi` (per constitution naming convention)
- This creates the standard ASP.NET Core Web API project structure

**Alternatives considered**:
- Manual project file creation: Higher risk of missing dependencies or incorrect configuration
- **Chosen**: `dotnet new webapi` per constitution requirement

### Frontend: Angular with Angular Material

**Decision**: Use Angular 17+ with Angular Material Table component

**Rationale**:
- Constitution mandates Angular frontend
- Angular Material provides pre-built, accessible table component
- Reduces custom CSS/styling effort
- Follows Material Design principles
- Built-in support for data binding and async operations

**Alternatives considered**:
- Custom table component: More work, less consistent
- Third-party table libraries: Additional dependencies
- **Chosen**: Angular Material for simplicity and consistency

### Database: PostgreSQL via Docker Compose

**Decision**: Use PostgreSQL 15+ in Docker container, managed via docker-compose.yaml

**Rationale**:
- Constitution mandates PostgreSQL
- Docker Compose required for local development environment
- Ensures consistent database setup across team
- Easy to reset/recreate database for testing
- Standard PostgreSQL features (unique constraints, NOT NULL) support requirements

**Alternatives considered**:
- SQLite: Simpler but doesn't match production stack
- In-memory database: Not suitable for integration testing
- **Chosen**: PostgreSQL in Docker for production-like environment

## API Design Patterns

### RESTful API Endpoint

**Decision**: Single GET endpoint `/api/users` returning all users

**Rationale**:
- Simple, follows REST conventions
- No pagination needed per YAGNI (deferred)
- Returns JSON array of user objects
- Easy to consume from Angular HttpClient

**Response Format**:
```json
[
  {
    "id": 1,
    "username": "johndoe",
    "email": "john@example.com"
  },
  {
    "id": 2,
    "username": null,
    "email": "jane@example.com"
  }
]
```

**Alternatives considered**:
- GraphQL: Overkill for simple read operation
- Pagination: Deferred per YAGNI
- **Chosen**: Simple REST GET endpoint

## Database Schema Design

### Users Table Structure

**Decision**: Users table with id (primary key), username (nullable, unique), email (required, unique)

**Rationale**:
- id as primary key: Standard practice, enables efficient joins
- username nullable: Per clarifications, username is optional
- email NOT NULL: Per clarifications, email is required
- Unique constraints: Both username and email must be unique per clarifications
- Indexes on unique columns for performance

**Schema**:
```sql
CREATE TABLE Users (
    Id SERIAL PRIMARY KEY,
    Username VARCHAR(255) NULL UNIQUE,
    Email VARCHAR(255) NOT NULL UNIQUE
);
```

**Alternatives considered**:
- UUID primary keys: More complex, not needed for MVP
- Composite unique constraint: Less flexible than separate constraints
- **Chosen**: Simple integer primary key with separate unique constraints

## Frontend Architecture

### Component Structure

**Decision**: Single feature component (UserListComponent) with service layer (UserService)

**Rationale**:
- Separation of concerns: Component handles UI, service handles data
- Service can be reused if user data needed elsewhere
- Easier to test: Service can be mocked in component tests
- Follows Angular best practices

**Data Flow**:
1. Component calls UserService.getUsers()
2. Service makes HTTP GET to /api/users
3. Service returns Observable<User[]>
4. Component subscribes and binds to template

**Alternatives considered**:
- Direct HTTP calls in component: Less reusable, harder to test
- State management (NgRx): Overkill for simple read-only list
- **Chosen**: Service pattern for clean separation

### CLI Scaffolding (Constitution Requirement)

**Decision**: Use Angular CLI for all Angular artifact creation

**Rationale**:
- Constitution mandates use of Angular CLI scaffolding
- Ensures consistent structure and proper imports
- Reduces human error in file creation
- Automatically generates boilerplate following Angular conventions

**Implementation**:
- Component: `ng generate component user-list` (or `ng g c user-list`)
- Service: `ng generate service user` (or `ng g s user`)
- Model/interface: Can be manually created or use `ng generate interface user`

**Alternatives considered**:
- Manual file creation: Higher risk of structural inconsistencies
- **Chosen**: Angular CLI per constitution requirement

## Error Handling

**Decision**: Handle errors at service level, display user-friendly messages in component

**Rationale**:
- Centralized error handling in service
- Component shows appropriate UI feedback
- Prevents technical error messages from reaching users
- Aligns with FR-006 requirement

**Error Scenarios**:
- Network errors: Show "Unable to load users. Please try again."
- Empty data: Show "No users found." (per FR-005)
- Server errors: Show generic error message

## Development Environment Setup

**Decision**: Single docker-compose.yaml with PostgreSQL service

**Rationale**:
- Constitution requires docker-compose for local development
- Single command startup: `docker-compose up`
- Backend and frontend run outside Docker (standard for development)
- PostgreSQL in container ensures consistency

**docker-compose.yaml structure**:
- PostgreSQL service with volume for data persistence
- Environment variables for database configuration
- Health checks for service readiness

## Testing Strategy

**Decision**: Unit tests for services, integration tests for API endpoints

**Rationale**:
- Constitution mandates TDD (tests first)
- Unit tests: Fast, isolated, test business logic
- Integration tests: Verify API contracts and database interactions
- Test isolation: Each test uses namespaced data per constitution

**Test Structure**:
- Backend: xUnit for .NET tests
- Frontend: Jasmine/Karma for Angular tests
- Test data: Isolated per test run, no shared state

## Summary

All technical decisions align with constitution principles:
- ✅ Technology stack matches constitution standards
- ✅ YAGNI applied (no pagination, simple loading)
- ✅ TDD approach for all code
- ✅ Docker Compose for local development
- ✅ CLI scaffolding required (Angular CLI for components/services, dotnet new for API projects)
- ✅ Simple, maintainable architecture

No unresolved technical questions remain. Ready for Phase 1 design.

