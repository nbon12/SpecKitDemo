# Tasks: User List Display

**Input**: Design documents from `/specs/001-user-list/`
**Prerequisites**: plan.md (required), spec.md (required for user stories), research.md, data-model.md, contracts/

**Tests**: Tests are REQUIRED per constitution (TDD is NON-NEGOTIABLE). All test tasks must be completed before implementation tasks.

**Organization**: Tasks are grouped by user story to enable independent implementation and testing of each story.

## Format: `[ID] [P?] [Story] Description`

- **[P]**: Can run in parallel (different files, no dependencies)
- **[Story]**: Which user story this task belongs to (e.g., US1, US2, US3)
- Include exact file paths in descriptions

## Path Conventions

- **Web app**: `backend/SpecKitDemoApi/`, `frontend/spec-kit-demo/`
- Paths follow plan.md structure with constitution naming conventions

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Project initialization and basic structure

- [ ] T001 Create docker-compose.yaml at repository root with PostgreSQL service
- [ ] T002 [P] Create backend directory structure
- [ ] T003 [P] Create frontend directory structure
- [ ] T004 Create backend project using `dotnet new webapi -n SpecKitDemoApi` in backend/ directory (per constitution)
- [ ] T005 Create frontend project using `ng new spec-kit-demo` in frontend/ directory (per constitution naming convention)
- [ ] T006 [P] Add Angular Material to frontend using `ng add @angular/material` in frontend/spec-kit-demo/

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Core infrastructure that MUST be complete before ANY user story can be implemented

**⚠️ CRITICAL**: No user story work can begin until this phase is complete

- [ ] T007 Add Entity Framework Core packages to backend: `dotnet add package Microsoft.EntityFrameworkCore` in backend/SpecKitDemoApi/
- [ ] T008 Add Entity Framework Core Design Tools to backend: `dotnet add package Microsoft.EntityFrameworkCore.Design` in backend/SpecKitDemoApi/
- [ ] T009 Add PostgreSQL provider to backend: `dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL` in backend/SpecKitDemoApi/
- [ ] T010 Create ApplicationDbContext in backend/SpecKitDemoApi/Data/ApplicationDbContext.cs
- [ ] T011 Configure database connection string in backend/SpecKitDemoApi/appsettings.json
- [ ] T012 Configure EF Core in backend/SpecKitDemoApi/Program.cs (AddDbContext, UseNpgsql)
- [ ] T013 Create User model in backend/SpecKitDemoApi/Models/User.cs with Id, Username (nullable), Email (required) properties
- [ ] T014 Configure User entity in ApplicationDbContext with unique constraints on Username and Email in backend/SpecKitDemoApi/Data/ApplicationDbContext.cs
- [ ] T015 Create initial EF Core migration using `dotnet ef migrations add InitialCreate` in backend/SpecKitDemoApi/ (per constitution)
- [ ] T016 Apply migration to database using `dotnet ef database update` in backend/SpecKitDemoApi/ (per constitution)
- [ ] T017 Configure CORS in backend/SpecKitDemoApi/Program.cs to allow requests from http://localhost:4200

**Checkpoint**: Foundation ready - user story implementation can now begin in parallel

---

## Phase 3: User Story 1 - View User List (Priority: P1) 🎯 MVP

**Goal**: Display all users in a table format on the /users page with username and email address columns

**Independent Test**: Navigate to http://localhost:4200/users and verify that all users from the database are displayed in a table format with username and email address columns. This can be tested independently without any other features.

### Tests for User Story 1 (REQUIRED - TDD NON-NEGOTIABLE)

> **NOTE: Write these tests FIRST, ensure they FAIL before implementation**

- [ ] T018 [P] [US1] Create unit test for UserService.GetUsers() in backend/SpecKitDemoApi/tests/unit/Services/UserServiceTests.cs
- [ ] T019 [P] [US1] Create integration test for GET /api/users endpoint in backend/SpecKitDemoApi/tests/integration/Controllers/UsersControllerTests.cs
- [ ] T020 [P] [US1] Create unit test for UserService in frontend/spec-kit-demo/src/app/services/user.service.spec.ts - test HTTP call to /api/users
- [ ] T021 [P] [US1] Create component test for UserListComponent in frontend/spec-kit-demo/src/app/components/user-list/user-list.component.spec.ts

### Implementation for User Story 1

#### Backend Implementation

- [ ] T022 [US1] Implement UserService in backend/SpecKitDemoApi/Services/UserService.cs with GetUsers() method that returns all users from database
- [ ] T023 [US1] Implement UsersController in backend/SpecKitDemoApi/Controllers/UsersController.cs with GET /api/users endpoint that calls UserService
- [ ] T024 [US1] Add error handling to UsersController for database errors (returns 500 with user-friendly message) in backend/SpecKitDemoApi/Controllers/UsersController.cs
- [ ] T025 [US1] Register UserService in dependency injection container in backend/SpecKitDemoApi/Program.cs

#### Frontend Implementation

- [ ] T026 [P] [US1] Generate UserListComponent using `ng generate component user-list` in frontend/spec-kit-demo/src/app/components/ (per constitution)
- [ ] T027 [P] [US1] Generate UserService using `ng generate service user` in frontend/spec-kit-demo/src/app/services/ (per constitution)
- [ ] T028 [US1] Create User model interface in frontend/spec-kit-demo/src/app/models/user.model.ts with id, username (nullable), email properties
- [ ] T029 [US1] Implement UserService.getUsers() method in frontend/spec-kit-demo/src/app/services/user.service.ts to call GET /api/users
- [ ] T030 [US1] Configure HttpClient in frontend/spec-kit-demo/src/app/app.config.ts (or app.module.ts) for API calls
- [ ] T031 [US1] Implement UserListComponent to fetch users from UserService and display in Angular Material table in frontend/spec-kit-demo/src/app/components/user-list/user-list.component.ts
- [ ] T032 [US1] Add Angular Material table to user-list.component.html with columns for username and email in frontend/spec-kit-demo/src/app/components/user-list/user-list.component.html
- [ ] T033 [US1] Handle empty state in UserListComponent (display message when no users exist) in frontend/spec-kit-demo/src/app/components/user-list/user-list.component.html
- [ ] T034 [US1] Handle error state in UserListComponent (display user-friendly error message) in frontend/spec-kit-demo/src/app/components/user-list/user-list.component.ts
- [ ] T035 [US1] Add route for /users page in frontend/spec-kit-demo/src/app/app-routing.module.ts (or app.config.ts)
- [ ] T036 [US1] Add navigation link to /users route in app component (if needed) in frontend/spec-kit-demo/src/app/app.component.html

**Checkpoint**: At this point, User Story 1 should be fully functional and testable independently. Navigate to /users page and verify all users are displayed.

---

## Phase 4: Polish & Cross-Cutting Concerns

**Purpose**: Improvements that affect the feature

- [ ] T037 [P] Verify all tests pass: `dotnet test` in backend/SpecKitDemoApi/ and `ng test` in frontend/spec-kit-demo/
- [ ] T038 [P] Run quickstart.md validation - verify all setup steps work correctly
- [ ] T039 Code cleanup and refactoring (remove unused code, improve naming)
- [ ] T040 Update README.md with setup and run instructions (if exists)
- [ ] T041 Verify docker-compose.yaml starts PostgreSQL successfully
- [ ] T042 Verify backend API runs with `dotnet run` in backend/SpecKitDemoApi/
- [ ] T043 Verify frontend runs with `ng serve` in frontend/spec-kit-demo/
- [ ] T044 Verify end-to-end flow: database → API → frontend displays users correctly

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies - can start immediately
- **Foundational (Phase 2)**: Depends on Setup completion - BLOCKS all user stories
- **User Story 1 (Phase 3)**: Depends on Foundational phase completion
- **Polish (Phase 4)**: Depends on User Story 1 completion

### User Story 1 Dependencies

- **User Story 1 (P1)**: Can start after Foundational (Phase 2) - No dependencies on other stories
- Tests MUST be written and FAIL before implementation (TDD requirement)
- Backend: UserService (T022) before UsersController (T023)
- Frontend: User model (T028) before UserService (T029), UserService before Component (T031)
- Component template (T032) after component implementation (T031)

### Within User Story 1

- Tests (T018-T021) MUST be written FIRST and FAIL before implementation
- Backend: UserService (T022) before UsersController (T023)
- Frontend: User model (T028) before UserService (T029), UserService before Component (T031)
- Component template (T032) after component implementation (T031)

### Parallel Opportunities

- **Phase 1**: T002 and T003 can run in parallel (different directories)
- **Phase 2**: T007, T008, T009 can run in parallel (different package installations)
- **Phase 3 Tests**: T018, T019, T020, T021 can run in parallel (different test files)
- **Phase 3 Frontend Setup**: T026, T027, T028 can run in parallel (different files)
- **Phase 4**: T037, T038, T039, T040 can run in parallel (different files/commands)

---

## Parallel Example: User Story 1

```bash
# Launch all tests for User Story 1 together:
Task T018: "Create unit test for UserService.GetUsers() in backend/SpecKitDemoApi/tests/unit/Services/UserServiceTests.cs"
Task T019: "Create integration test for GET /api/users endpoint in backend/SpecKitDemoApi/tests/integration/Controllers/UsersControllerTests.cs"
Task T020: "Create unit test for UserService in frontend/spec-kit-demo/src/app/services/user.service.spec.ts"
Task T021: "Create component test for UserListComponent in frontend/spec-kit-demo/src/app/components/user-list/user-list.component.spec.ts"

# Launch frontend setup tasks together:
Task T026: "Generate UserListComponent using ng generate component user-list"
Task T027: "Generate UserService using ng generate service user"
Task T028: "Create User model interface in frontend/spec-kit-demo/src/app/models/user.model.ts"
```

---

## Implementation Strategy

### MVP First (User Story 1 Only)

1. Complete Phase 1: Setup (T001-T006)
2. Complete Phase 2: Foundational (T007-T017) - **CRITICAL - blocks all stories**
3. Complete Phase 3: User Story 1 (T018-T036)
   - Write tests first (T018-T021) - ensure they FAIL
   - Implement backend (T022-T025)
   - Implement frontend (T026-T036)
4. **STOP and VALIDATE**: Test User Story 1 independently
   - Start PostgreSQL: `docker-compose up -d`
   - Start backend: `cd backend/SpecKitDemoApi && dotnet run`
   - Start frontend: `cd frontend/spec-kit-demo && ng serve`
   - Navigate to http://localhost:4200/users
   - Verify users are displayed correctly
5. Complete Phase 4: Polish (T037-T044)
6. Deploy/demo if ready

### Incremental Delivery

1. Complete Setup + Foundational → Foundation ready
2. Add User Story 1 → Test independently → Deploy/Demo (MVP!)
3. Each story adds value without breaking previous stories

---

## Notes

- [P] tasks = different files, no dependencies
- [US1] label maps task to User Story 1 for traceability
- User Story 1 should be independently completable and testable
- Verify tests fail before implementing (TDD requirement)
- Commit after each task or logical group
- Stop at checkpoint to validate story independently
- Use CLI scaffolding per constitution:
  - Angular: `ng generate component`, `ng generate service`
  - .NET: `dotnet new webapi -n SpecKitDemoApi`
- EF Core migrations: Use `dotnet ef migrations add` and `dotnet ef database update` per constitution
- Project naming: Use "Spec Kit Demo" as base (SpecKitDemoApi for backend, spec-kit-demo for frontend) per constitution
