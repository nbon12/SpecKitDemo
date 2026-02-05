# Implementation Plan: User List Display

**Branch**: `001-user-list` | **Date**: 2025-01-27 | **Spec**: [spec.md](./spec.md)
**Input**: Feature specification from `/specs/001-user-list/spec.md`

## Summary

Create a greenfield web application with an Angular frontend and .NET Core backend API that displays a list of users from a PostgreSQL database. The feature includes setting up the complete infrastructure: PostgreSQL database via docker-compose, .NET Core API with Entity Framework Core, and Angular frontend application. Users can navigate to a users page to view all users in a table format showing username and email address.

## Technical Context

**Language/Version**: 
- Backend: .NET 8.0 (C#)
- Frontend: Angular 17+ with TypeScript 5.x

**Primary Dependencies**: 
- Backend: Entity Framework Core, ASP.NET Core Web API, Npgsql.EntityFrameworkCore.PostgreSQL
- Frontend: Angular CLI, Angular Material (for table component), RxJS
- Infrastructure: Docker, docker-compose, PostgreSQL 15+

**Storage**: PostgreSQL 15+ database

**Testing**: 
- Backend: xUnit, Moq, FluentAssertions
- Frontend: Jasmine, Karma, Angular Testing Utilities
- Contract Testing: OpenAPI schema validation (REQUIRED per constitution)

**Target Platform**: Web application (browser-based frontend, REST API backend)

**Project Type**: Web application (frontend + backend)

**Performance Goals**: 
- Users can view the complete list within 2 seconds of navigating to the page (per SC-001)
- API response time: <500ms for user list retrieval

**Constraints**: 
- Must be startable via `docker-compose up` per constitution
- No pagination initially (YAGNI principle)
- Load all users at once
- Email is required (NOT NULL), username is optional (nullable)
- Both username and email must be unique
- Angular components/services MUST be created using Angular CLI (`ng generate`) per constitution
- .NET API projects MUST be created using `dotnet new webapi -n <name>` per constitution
- Project naming MUST use "Spec Kit Demo" as the base name per constitution (backend: SpecKitDemoApi, frontend: spec-kit-demo)

**Scale/Scope**: 
- Initial implementation: Simple user list display
- No authentication/authorization (handled separately per assumptions)
- Single page: /users route
- MVP scope: Display existing users only (no create/edit/delete)

## Testing Strategy

**Contract Testing**: API contracts are defined in `contracts/users-api.yaml` (OpenAPI 3.0.3). Contract testing is REQUIRED per constitution. The GET /api/users endpoint must have tests that validate:
- Response schema matches the contract (all fields, types, nullable constraints)
- Status codes match the contract (200, 500)
- Content-Type headers match the contract (application/json)
- Required fields are present and correctly typed (id, email)
- Nullable/optional fields are handled correctly (username can be null)
- Error response schemas match the contract (500 error with message field `{ "message": "<string>" }`)

**Test Types Required**:
- Unit tests: Service layer logic (UserService)
- Integration tests: API endpoints with database (UsersController)
- Contract tests: API contract compliance (REQUIRED)
- Frontend service tests: HTTP client interactions (UserService)
- Frontend component tests: Component logic and rendering (UserListComponent)

**Test Isolation**: All tests must use isolated data per test run. Tests must assume parallel execution and potential stale data from previous runs.

**New Tests Needed**: None (all required tests are implemented and passing)

## Constitution Check

*GATE: Must pass before Phase 0 research. Re-check after Phase 1 design.*

### Test-Driven Development (NON-NEGOTIABLE)
✅ **PASS**: Tests will be written before implementation. Backend API tests and frontend component tests required.

### Test Isolation & Data Management
✅ **PASS**: Test data will be namespaced. Each test run will use isolated data. Tests must be independently executable.

### Technology Stack Standards
✅ **PASS**: 
- Angular frontend with TypeScript ✓
- .NET Core backend API ✓
- PostgreSQL database ✓
- RESTful API design ✓

### Simplicity & YAGNI
✅ **PASS**: 
- No pagination (deferred) ✓
- No loading indicators (simple empty table approach) ✓
- No authentication/authorization (out of scope) ✓
- Simple table display only ✓

### Security by Design
⚠️ **DEFERRED**: Authentication/authorization handled separately per assumptions. No security features in this feature scope.

### Observability Standards
⚠️ **DEFERRED**: Observability infrastructure doesn't exist yet. Will be added when infrastructure exists per constitution.

### API Contract Testing (REQUIRED for REST APIs)
✅ **PASS**: API contract exists (contracts/users-api.yaml) and contract tests are implemented to validate:
- Response schema matches OpenAPI specification
- Status codes match contract (200, 500)
- Content-Type headers match contract
- Required fields validation (id, email)
- Nullable fields validation (username)
- Error response schema validation (`{ "message": "<string>" }`)

### Local Development Environment
✅ **PASS**: docker-compose.yaml will be created to start PostgreSQL and all services with single command.

**GATE STATUS (Pre-Phase 0)**: ✅ PASS - Contract testing requirement satisfied. Security and observability deferred as out of scope.

### Post-Phase 1 Design Re-evaluation

After completing Phase 1 design (data model, API contracts, quickstart):

**Test-Driven Development (NON-NEGOTIABLE)**
✅ **PASS**: Design supports TDD approach. API contracts defined for contract testing. Data model enables unit testing of services.

**Test Isolation & Data Management**
✅ **PASS**: Data model design supports test isolation. Each test can use isolated database context. No shared state dependencies.

**Technology Stack Standards**
✅ **PASS**: All design artifacts align with constitution stack:
- Entity Framework Core for data access ✓
- RESTful API design ✓
- Angular Material for UI components ✓
- PostgreSQL schema design ✓

**Simplicity & YAGNI**
✅ **PASS**: Design maintains simplicity:
- Single GET endpoint (no pagination, filtering, sorting) ✓
- Simple data model (single entity, no relationships) ✓
- Minimal API surface area ✓

**Security by Design**
⚠️ **DEFERRED**: Still out of scope. No authentication/authorization in design.

**Observability Standards**
⚠️ **DEFERRED**: Still out of scope. No logging/monitoring in design yet.

**API Contract Testing (REQUIRED for REST APIs)**
✅ **PASS**: API contract exists (contracts/users-api.yaml) and contract tests are implemented per constitution to validate:
- Response schema matches OpenAPI specification (all fields, types, nullable constraints)
- Status codes match contract (200, 500)
- Content-Type headers match contract (application/json)
- Required fields validation (id, email must be present)
- Nullable fields validation (username can be null)
- Error response schema validation (500 error with message field `{ "message": "<string>" }`)

**Local Development Environment**
✅ **PASS**: docker-compose.yaml design documented in quickstart.md. Single command startup maintained.

**Development Tooling Preferences**
✅ **PASS**: Plan specifies use of CLI scaffolding:
- Angular components/services will use `ng generate` commands ✓
- .NET API project will use `dotnet new webapi -n <name>` ✓
- Quickstart.md documents CLI commands for project setup ✓

**Naming Conventions**
✅ **PASS**: Plan uses "Spec Kit Demo" as project name base:
- Backend API project: SpecKitDemoApi (PascalCase, no spaces) ✓
- Frontend application: spec-kit-demo (kebab-case) ✓
- Consistent naming across all artifacts ✓

**GATE STATUS (Post-Phase 1)**: ✅ PASS - API Contract Testing requirement satisfied. All other principles satisfied.

## Project Structure

### Documentation (this feature)

```text
specs/001-user-list/
├── plan.md              # This file (/speckit.plan command output)
├── research.md          # Phase 0 output (/speckit.plan command)
├── data-model.md        # Phase 1 output (/speckit.plan command)
├── quickstart.md        # Phase 1 output (/speckit.plan command)
├── contracts/           # Phase 1 output (/speckit.plan command)
└── tasks.md             # Phase 2 output (/speckit.tasks command - NOT created by /speckit.plan)
```

### Source Code (repository root)

```text
backend/
├── SpecKitDemoApi/
│   ├── Models/
│   │   └── User.cs
│   ├── Services/
│   │   └── UserService.cs
│   ├── Controllers/
│   │   └── UsersController.cs
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   └── Program.cs
└── tests/
    ├── unit/
    │   └── Services/
    │       └── UserServiceTests.cs
    └── integration/
        └── Controllers/
            └── UsersControllerTests.cs

frontend/
├── spec-kit-demo/
│   ├── src/
│   │   ├── app/
│   │   │   ├── components/
│   │   │   │   └── user-list/
│   │   │   │       ├── user-list.component.ts
│   │   │   │       ├── user-list.component.html
│   │   │   │       └── user-list.component.spec.ts
│   │   │   ├── services/
│   │   │   │   └── user.service.ts
│   │   │   ├── models/
│   │   │   │   └── user.model.ts
│   │   │   └── app-routing.module.ts
│   │   └── main.ts
│   └── tests/

docker-compose.yaml
```

**Structure Decision**: Web application structure selected (Option 2) because the feature requires both frontend (Angular) and backend (.NET API) components. The structure separates concerns clearly: backend handles data access and API, frontend handles presentation. Docker-compose.yaml at root for local development environment setup.

## Complexity Tracking

> **Fill ONLY if Constitution Check has violations that must be justified**

| Violation | Why Needed | Simpler Alternative Rejected Because |
|-----------|------------|-------------------------------------|
| Contract testing required | Constitution mandates contract testing for all API endpoints with OpenAPI specs | Manual validation rejected because automated contract tests prevent breaking changes and ensure API consistency |

## Required Test Additions

Based on the updated constitution (API Contract Testing requirement), the following tests are required. **Status: Implemented and passing.**

### Backend Integration Tests (Contract Tests)

**Location**: `backend/SpecKitDemoApi/tests/integration/Controllers/UsersControllerTests.cs`

1. **Contract Schema Validation Test**
   - Validates GET /api/users response schema matches OpenAPI contract
   - Verifies all fields (id, username, email) match contract types
   - Verifies nullable constraints (username can be null)

2. **Required Fields Validation Test**
   - Validates required fields (id, email) are always present in response
   - Verifies email field is never null

3. **Nullable Fields Validation Test**
   - Validates username field can be null per contract
   - Verifies null username is handled correctly in response

4. **Error Response Schema Validation Test**
   - Validates 500 error response matches Error schema from contract
   - Verifies error response contains message field

5. **Status Code Validation Test**
   - Validates all status codes (200, 500) match contract specification
   - Verifies no unexpected status codes are returned

6. **Empty State Response Test**
   - Validates GET /api/users returns 200 OK with empty array when no users exist
   - Verifies empty array response matches contract (array type, not null)

### Frontend Component Tests

**Location**: `frontend/spec-kit-demo/src/app/components/user-list/user-list.component.spec.ts`

1. **Empty State Handling Test (FR-005)**
   - Verifies "No users found" message displays when user list is empty
   - Tests that empty state message is shown in template when `users.length === 0`
   - Validates empty state UI renders correctly without errors
   - Requirement: FR-005, AS #2, SC-004

### Spec Clarifications Incorporated

The following clarifications are now explicitly part of the spec and should be reflected in any future changes:
- Empty state message text: **"No users found."**
- Error state message text: **"An error occurred while loading users. Please try again later."**
- Null/empty username display: render **`-`** in the username column
- API behavior (contract-aligned): `GET /api/users` returns **200** with JSON array on success; returns **500** with JSON error object `{ "message": "<string>" }` on unexpected server error

### Implementation Notes

- Contract tests should use OpenAPI schema validation library (e.g., Microsoft.OpenApi.Validators, or manual validation against contract)
- Tests should validate against the actual contracts/users-api.yaml file
- Contract tests should be part of integration test suite
- All contract tests must pass before API implementation is considered complete per constitution

