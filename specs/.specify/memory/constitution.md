<!--
Sync Impact Report:
Version: 1.1.0 → 1.2.0
Added Sections:
  - Database Migration Requirements (within Development Workflow)
  - Naming Conventions (within Development Workflow)
Modified Sections:
  - Development Tooling Preferences (added EF Core Migrations requirement)
Templates Updated:
  ✅ plan-template.md (Constitution Check section - no changes needed)
  ✅ spec-template.md (verified alignment - no changes needed)
  ✅ tasks-template.md (verified alignment - no changes needed)
-->

# Spec Kit Demo Constitution

## Core Principles

### Test-Driven Development (NON-NEGOTIABLE)

Always write tests first, then implement minimum code to make tests pass. Red-Green-Refactor cycle strictly enforced. All features must have tests before implementation begins. Tests must be written and approved before any implementation code.

**Rationale**: Ensures code quality, prevents regressions, and enforces clear requirements before implementation begins.

### Test Isolation & Data Management

Test data must be namespaced and isolated per test run. Tests must assume parallel execution and potential stale data from previous runs. Queries must only verify data from the current test run's namespace. Each test must be independently executable without dependencies on other tests.

**Rationale**: Enables reliable parallel test execution and prevents test interdependencies that cause flaky test results.

### Technology Stack Standards

Angular frontend with TypeScript. .NET Core backend API. Entity Framework Core. PostgreSQL database. RESTful API design principles. If message queue is needed, implement with RabbitMQ.

**Rationale**: Establishes consistent technology choices across the project to reduce complexity and enable team collaboration.

### Simplicity & YAGNI (You Aren't Gonna Need It)

Implement only what's needed for current requirements. Avoid premature optimization and over-engineering. Start simple, add complexity only when justified by actual needs. Prefer simple solutions over complex ones.

**Rationale**: Reduces maintenance burden, accelerates delivery, and prevents unnecessary complexity that hinders future development.

### Security by Design

When authentication, authorization, or data protection features are added, they must follow industry-standard patterns. Security considerations must be addressed in the planning phase, not as an afterthought. All security features must be implemented consistently across all services. Security must be testable and verifiable.

**Rationale**: Ensures security is built into features from the start rather than retrofitted, reducing vulnerabilities and technical debt.

### Observability Standards

When logging, monitoring, or error tracking is added, it must follow structured logging patterns. Observability must be consistent across all services. All features must include appropriate observability from the start when observability infrastructure exists. Logging and monitoring must not expose sensitive information.

**Rationale**: Enables effective debugging, performance monitoring, and operational insights while maintaining security and privacy.

## Development Workflow

### Feature Branch Strategy

Each feature uses a small, focused branch following the pattern 001-feature-name, 002-feature-name, etc. One feature per branch.

### Pull Request Process

All features require a Pull Request to GitHub for code review before merge. PRs must be reviewed and approved before merging.

### Quality Gates

All Pull Requests must pass automated .NET unit tests via GitHub Actions before merge. Tests must pass for PR approval.

### Code Review

All PRs require review before merge. Reviews must verify compliance with constitution principles.

### Local Development Environment

The local project must be able to be started up using `docker-compose up`. All services, databases, and dependencies required for local development must be defined in `docker-compose.yaml` and start successfully with a single command.

The local project must also be able to be started up using "dotnet run" and "ng serve". And they should be able to reach the same docker database.

**Rationale**: Ensures consistent development environments across all team members and simplifies onboarding by eliminating manual setup steps.

### Development Tooling Preferences

When creating new Angular features, components, services, or other Angular artifacts, use the Angular CLI scaffolding commands (e.g., `ng generate component`, `ng generate service`) rather than manually creating files. This ensures consistent structure, proper imports, and follows Angular best practices.

When creating new .NET API projects, use `dotnet new webapi -n <name>` to scaffold the project structure rather than manually creating project files.

**Rationale**: CLI scaffolding ensures consistency across the codebase, reduces human error, and automatically generates boilerplate code following framework conventions. This reduces setup time and prevents structural inconsistencies.

### Database Migration Requirements

All changes to database tables MUST be made using Entity Framework Core Migrations. Migrations MUST be created using the EF Core CLI (e.g., `dotnet ef migrations add <MigrationName>`). Direct database schema changes are prohibited. All migrations must be version-controlled and applied through the migration system.

**Rationale**: Migrations provide version control for database schema, enable reproducible deployments, support rollback capabilities, and ensure consistency across development, staging, and production environments.

### Naming Conventions

When naming project artifacts that require a project name (e.g., .NET API projects, database schemas, service names, or other project-scoped identifiers), use the official project name: "Spec Kit Demo". This name must be used consistently across all code, configuration, and documentation.

**Rationale**: Consistent project naming ensures clarity, prevents confusion, and maintains a unified identity across all project artifacts and documentation.

## Governance

Constitution supersedes all other practices and guidelines. Amendments require documentation, justification, and approval. All PRs and reviews must verify compliance with constitution principles. Complexity must be justified and documented. Violations of constitution principles must be addressed before merge.

**Version**: 1.2.0 | **Ratified**: 2025-02-04 | **Last Amended**: 2026-02-04
