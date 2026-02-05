---

description: "Task list template for feature implementation"
---

# Tasks: [FEATURE NAME]

**Input**: Design documents from `/specs/[###-feature-name]/`
**Prerequisites**: plan.md (required), spec.md (required for user stories), research.md, data-model.md, contracts/

**Tests**: Tests are REQUIRED per constitution (TDD is NON-NEGOTIABLE). All test tasks must be completed before implementation tasks. Tests must be written and approved before any implementation code.

**Organization**: Tasks are grouped by user story to enable independent implementation and testing of each story.

## Format: `[ID] [P?] [Story] Description`

- **[P]**: Can run in parallel (different files, no dependencies)
- **[Story]**: Which user story this task belongs to (e.g., US1, US2, US3)
- Include exact file paths in descriptions

## Path Conventions

- **Single project**: `src/`, `tests/` at repository root
- **Web app**: `backend/src/`, `frontend/src/`
- **Mobile**: `api/src/`, `ios/src/` or `android/src/`
- Paths shown below assume single project - adjust based on plan.md structure

<!-- 
  ============================================================================
  IMPORTANT: The tasks below are SAMPLE TASKS for illustration purposes only.
  
  The /speckit.tasks command MUST replace these with actual tasks based on:
  - User stories from spec.md (with their priorities P1, P2, P3...)
  - Feature requirements from plan.md
  - Entities from data-model.md
  - Endpoints from contracts/
  
  Tasks MUST be organized by user story so each story can be:
  - Implemented independently
  - Tested independently
  - Delivered as an MVP increment
  
  DO NOT keep these sample tasks in the generated tasks.md file.
  ============================================================================
-->

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Project initialization and basic structure

- [ ] T001 Create project structure per implementation plan
- [ ] T002 Initialize [language] project with [framework] dependencies
- [ ] T003 [P] Configure linting and formatting tools

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Core infrastructure that MUST be complete before ANY user story can be implemented

**⚠️ CRITICAL**: No user story work can begin until this phase is complete

Examples of foundational tasks (adjust based on your project):

- [ ] T004 Setup database schema and migrations framework
- [ ] T005 [P] Implement authentication/authorization framework
- [ ] T006 [P] Setup API routing and middleware structure
- [ ] T007 Create base models/entities that all stories depend on
- [ ] T008 Configure error handling and logging infrastructure
- [ ] T009 Setup environment configuration management

**Checkpoint**: Foundation ready - user story implementation can now begin in parallel

---

## Phase 3: User Story 1 - [Title] (Priority: P1) 🎯 MVP

**Goal**: [Brief description of what this story delivers]

**Independent Test**: [How to verify this story works on its own]

### Tests for User Story 1 (REQUIRED - TDD NON-NEGOTIABLE)

> **NOTE: Write these tests FIRST, ensure they FAIL before implementation**
>
> **GENERATION INSTRUCTIONS FOR /speckit.tasks COMMAND**:
> 
> For each user story, systematically generate test tasks by:
> 
> 1. **From Acceptance Scenarios (spec.md)**: Create at least one test per acceptance scenario
> 2. **From Functional Requirements (spec.md)**: Create at least one test per functional requirement (FR-XXX)
> 3. **From Edge Cases (spec.md)**: Create at least one test per edge case identified
> 4. **From Success Criteria (spec.md)**: Create tests that verify measurable outcomes (SC-XXX)
> 5. **From Error Handling Requirements**: Create tests for all error scenarios (FR-006, EC #1, etc.)
> 6. **From Constraint Requirements**: Create tests for database/validation constraints (FR-007, FR-008, FR-009, etc.)
> 
> **Test Task Format**: `T[ID][SubID] [P?] [US#] [Test Type]: [Specific Scenario] - [Expected Behavior]`
> - Include requirement reference: `**Requirement**: FR-XXX or AS #X or EC #X`
> - Include file path: `**File**: [path/to/test/file]`
> - Include test description: `**Test**: [Specific test case]`

#### Backend Unit Tests

<!-- 
  GENERATE FROM SPEC.MD:
  - For each service/entity, create unit tests for:
    * Happy path scenarios (AS #1, AS #3)
    * Empty state scenarios (AS #2, FR-005)
    * Error scenarios (FR-006, EC #1)
    * Constraint validation (FR-007, FR-008, FR-009)
    * Edge cases (EC #2, EC #4)
-->

- [ ] T010a [P] [US1] Unit test: [Service].[Method]() returns [expected] when [condition]
  - **Requirement**: [FR-XXX or AS #X]
  - **File**: tests/unit/services/[service]_tests.[ext]
  - **Test**: [Specific test case description]

- [ ] T010b [P] [US1] Unit test: [Service].[Method]() returns empty list when no data exists
  - **Requirement**: FR-005, AS #2
  - **File**: tests/unit/services/[service]_tests.[ext]
  - **Test**: Given empty database, when [Method]() called, then returns empty list

- [ ] T010c [P] [US1] Unit test: [Service].[Method]() handles errors gracefully
  - **Requirement**: FR-006, EC #1
  - **File**: tests/unit/services/[service]_tests.[ext]
  - **Test**: Given database unavailable, when [Method]() called, then throws/returns appropriate error

#### Backend Integration Tests

<!-- 
  GENERATE FROM SPEC.MD AND CONTRACTS:
  - For each API endpoint in contracts/, create integration tests for:
    * 200 OK responses with data (AS #1, AS #3)
    * 200 OK responses with empty data (AS #2, FR-005)
    * 500 error responses (FR-006, EC #1)
    * Contract compliance (response matches OpenAPI spec)
    * Content type verification
-->

- [ ] T011a [P] [US1] Integration test: [HTTP Method] [endpoint] returns 200 OK with [data]
  - **Requirement**: [FR-XXX], AS #1, AS #3
  - **File**: tests/integration/[endpoint]_tests.[ext]
  - **Test**: Given [condition], when [HTTP Method] [endpoint] called, then returns 200 with correct data

- [ ] T011b [P] [US1] Integration test: [HTTP Method] [endpoint] returns 200 OK with empty array when no data
  - **Requirement**: FR-005, AS #2
  - **File**: tests/integration/[endpoint]_tests.[ext]
  - **Test**: Given empty database, when [HTTP Method] [endpoint] called, then returns 200 with empty array

- [ ] T011c [P] [US1] Integration test: [HTTP Method] [endpoint] returns 500 when database error
  - **Requirement**: FR-006, EC #1
  - **File**: tests/integration/[endpoint]_tests.[ext]
  - **Test**: Given database unavailable, when [HTTP Method] [endpoint] called, then returns 500 with error message

- [ ] T011d [P] [US1] Integration test: [HTTP Method] [endpoint] response matches OpenAPI contract
  - **Requirement**: [Contract validation]
  - **File**: tests/integration/[endpoint]_tests.[ext]
  - **Test**: When [HTTP Method] [endpoint] called, then response schema matches contracts/[api].yaml

#### Frontend Service Tests

<!-- 
  GENERATE FROM SPEC.MD:
  - For each service that makes HTTP calls, create tests for:
    * HTTP request made correctly
    * Observable/Promise returns data
    * Error handling
-->

- [ ] T012a [P] [US1] Unit test: [Service].[Method]() makes HTTP [Method] request to [endpoint]
  - **Requirement**: [FR-XXX]
  - **File**: [frontend]/src/app/services/[service].spec.[ext]
  - **Test**: When [Method]() called, then HttpClient.[method]() called with correct URL

- [ ] T012b [P] [US1] Unit test: [Service].[Method]() handles HTTP errors
  - **Requirement**: FR-006, EC #1
  - **File**: [frontend]/src/app/services/[service].spec.[ext]
  - **Test**: Given HTTP error response, when [Method]() called, then error handled gracefully

#### Frontend Component Tests

<!-- 
  GENERATE FROM SPEC.MD:
  - For each component, create tests for:
    * Component renders correctly with data (AS #1, AS #3)
    * Component displays empty state (AS #2, FR-005)
    * Component displays error message (FR-006, EC #1)
    * Component handles edge cases (EC #2, EC #4)
    * Template rendering verification
-->

- [ ] T013a [P] [US1] Component test: [Component] displays [element] when data loaded
  - **Requirement**: FR-001, FR-003, FR-004, AS #1, AS #3
  - **File**: [frontend]/src/app/components/[component]/[component].spec.[ext]
  - **Test**: Given [data], when component rendered, then [element] displays with correct content

- [ ] T013b [P] [US1] Component test: [Component] displays empty state message when no data
  - **Requirement**: FR-005, AS #2, SC-004
  - **File**: [frontend]/src/app/components/[component]/[component].spec.[ext]
  - **Test**: Given empty data, when component rendered, then empty state message displayed

- [ ] T013c [P] [US1] Component test: [Component] displays error message on failure
  - **Requirement**: FR-006, EC #1
  - **File**: [frontend]/src/app/components/[component]/[component].spec.[ext]
  - **Test**: Given API error, when component loads, then error message displayed to user

### Implementation for User Story 1

> **NOTE**: Each implementation task should have corresponding test tasks above.
> Verify that all test tasks pass before marking implementation tasks complete.
> Reference the Test-to-Implementation Mapping table below for traceability.

- [ ] T014 [P] [US1] Create [Entity1] model in src/models/[entity1].py
- [ ] T015 [P] [US1] Create [Entity2] model in src/models/[entity2].py
- [ ] T016 [US1] Implement [Service] in src/services/[service].py (depends on T014, T015)
- [ ] T017 [US1] Implement [endpoint/feature] in src/[location]/[file].py
- [ ] T018 [US1] Add validation and error handling
- [ ] T019 [US1] Add logging for user story 1 operations

### Test-to-Implementation Mapping for User Story 1

| Implementation Task | Test Tasks That Verify It | Requirements Covered |
|---------------------|---------------------------|----------------------|
| T016: Implement [Service] | T010a, T010b, T010c | FR-XXX, AS #X, EC #X |
| T017: Implement [endpoint] | T011a, T011b, T011c, T011d | FR-XXX, AS #X, EC #X |
| T018: Add error handling | T010c, T011c, T012b, T013c | FR-006, EC #1 |
| T019: Add logging | [Logging tests if applicable] | [Requirements] |

**Checkpoint**: At this point, User Story 1 should be fully functional and testable independently

---

## Phase 4: User Story 2 - [Title] (Priority: P2)

**Goal**: [Brief description of what this story delivers]

**Independent Test**: [How to verify this story works on its own]

### Tests for User Story 2 (REQUIRED - TDD NON-NEGOTIABLE)

> **NOTE: Write these tests FIRST, ensure they FAIL before implementation**
>
> **GENERATION**: Follow same pattern as User Story 1 - generate tests from:
> - Acceptance Scenarios, Functional Requirements, Edge Cases, Success Criteria
> - Use format: `T[ID][SubID] [P?] [US2] [Test Type]: [Scenario] - [Expected]`
> - Include requirement references and file paths

#### Backend Unit Tests

- [ ] T020a [P] [US2] Unit test: [Service].[Method]() returns [expected] when [condition]
  - **Requirement**: [FR-XXX or AS #X]
  - **File**: tests/unit/services/[service]_tests.[ext]
  - **Test**: [Specific test case description]

#### Backend Integration Tests

- [ ] T021a [P] [US2] Integration test: [HTTP Method] [endpoint] returns 200 OK with [data]
  - **Requirement**: [FR-XXX], AS #1, AS #3
  - **File**: tests/integration/[endpoint]_tests.[ext]
  - **Test**: Given [condition], when [HTTP Method] [endpoint] called, then returns 200 with correct data

#### Frontend Service Tests

- [ ] T022a [P] [US2] Unit test: [Service].[Method]() makes HTTP [Method] request to [endpoint]
  - **Requirement**: [FR-XXX]
  - **File**: [frontend]/src/app/services/[service].spec.[ext]
  - **Test**: When [Method]() called, then HttpClient.[method]() called with correct URL

#### Frontend Component Tests

- [ ] T023a [P] [US2] Component test: [Component] displays [element] when data loaded
  - **Requirement**: FR-001, FR-003, FR-004, AS #1, AS #3
  - **File**: [frontend]/src/app/components/[component]/[component].spec.[ext]
  - **Test**: Given [data], when component rendered, then [element] displays with correct content

### Implementation for User Story 2

> **NOTE**: Each implementation task should have corresponding test tasks above.
> Verify that all test tasks pass before marking implementation tasks complete.

- [ ] T024 [P] [US2] Create [Entity] model in src/models/[entity].py
- [ ] T025 [US2] Implement [Service] in src/services/[service].py
- [ ] T026 [US2] Implement [endpoint/feature] in src/[location]/[file].py
- [ ] T027 [US2] Integrate with User Story 1 components (if needed)

### Test-to-Implementation Mapping for User Story 2

| Implementation Task | Test Tasks That Verify It | Requirements Covered |
|---------------------|---------------------------|----------------------|
| T025: Implement [Service] | T020a, [additional tests] | FR-XXX, AS #X |
| T026: Implement [endpoint] | T021a, [additional tests] | FR-XXX, AS #X |

**Checkpoint**: At this point, User Stories 1 AND 2 should both work independently

---

## Phase 5: User Story 3 - [Title] (Priority: P3)

**Goal**: [Brief description of what this story delivers]

**Independent Test**: [How to verify this story works on its own]

### Tests for User Story 3 (REQUIRED - TDD NON-NEGOTIABLE)

> **NOTE: Write these tests FIRST, ensure they FAIL before implementation**
>
> **GENERATION**: Follow same pattern as User Story 1 - generate tests from:
> - Acceptance Scenarios, Functional Requirements, Edge Cases, Success Criteria
> - Use format: `T[ID][SubID] [P?] [US3] [Test Type]: [Scenario] - [Expected]`
> - Include requirement references and file paths

#### Backend Unit Tests

- [ ] T028a [P] [US3] Unit test: [Service].[Method]() returns [expected] when [condition]
  - **Requirement**: [FR-XXX or AS #X]
  - **File**: tests/unit/services/[service]_tests.[ext]
  - **Test**: [Specific test case description]

#### Backend Integration Tests

- [ ] T029a [P] [US3] Integration test: [HTTP Method] [endpoint] returns 200 OK with [data]
  - **Requirement**: [FR-XXX], AS #1, AS #3
  - **File**: tests/integration/[endpoint]_tests.[ext]
  - **Test**: Given [condition], when [HTTP Method] [endpoint] called, then returns 200 with correct data

#### Frontend Service Tests

- [ ] T030a [P] [US3] Unit test: [Service].[Method]() makes HTTP [Method] request to [endpoint]
  - **Requirement**: [FR-XXX]
  - **File**: [frontend]/src/app/services/[service].spec.[ext]
  - **Test**: When [Method]() called, then HttpClient.[method]() called with correct URL

#### Frontend Component Tests

- [ ] T031a [P] [US3] Component test: [Component] displays [element] when data loaded
  - **Requirement**: FR-001, FR-003, FR-004, AS #1, AS #3
  - **File**: [frontend]/src/app/components/[component]/[component].spec.[ext]
  - **Test**: Given [data], when component rendered, then [element] displays with correct content

### Implementation for User Story 3

> **NOTE**: Each implementation task should have corresponding test tasks above.
> Verify that all test tasks pass before marking implementation tasks complete.

- [ ] T032 [P] [US3] Create [Entity] model in src/models/[entity].py
- [ ] T033 [US3] Implement [Service] in src/services/[service].py
- [ ] T034 [US3] Implement [endpoint/feature] in src/[location]/[file].py

### Test-to-Implementation Mapping for User Story 3

| Implementation Task | Test Tasks That Verify It | Requirements Covered |
|---------------------|---------------------------|----------------------|
| T033: Implement [Service] | T028a, [additional tests] | FR-XXX, AS #X |
| T034: Implement [endpoint] | T029a, [additional tests] | FR-XXX, AS #X |

**Checkpoint**: All user stories should now be independently functional

---

[Add more user story phases as needed, following the same pattern]

---

## Phase N: Polish & Cross-Cutting Concerns

**Purpose**: Improvements that affect multiple user stories

- [ ] TXXX [P] Documentation updates in docs/
- [ ] TXXX Code cleanup and refactoring
- [ ] TXXX Performance optimization across all stories
- [ ] TXXX [P] Additional unit tests in tests/unit/ (if needed for coverage gaps)
- [ ] TXXX Security hardening
- [ ] TXXX Run quickstart.md validation

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies - can start immediately
- **Foundational (Phase 2)**: Depends on Setup completion - BLOCKS all user stories
- **User Stories (Phase 3+)**: All depend on Foundational phase completion
  - User stories can then proceed in parallel (if staffed)
  - Or sequentially in priority order (P1 → P2 → P3)
- **Polish (Final Phase)**: Depends on all desired user stories being complete

### User Story Dependencies

- **User Story 1 (P1)**: Can start after Foundational (Phase 2) - No dependencies on other stories
- **User Story 2 (P2)**: Can start after Foundational (Phase 2) - May integrate with US1 but should be independently testable
- **User Story 3 (P3)**: Can start after Foundational (Phase 2) - May integrate with US1/US2 but should be independently testable

### Within Each User Story

- Tests MUST be written and FAIL before implementation (TDD NON-NEGOTIABLE)
- Models before services
- Services before endpoints
- Core implementation before integration
- Story complete before moving to next priority
- Verify all test tasks pass before marking implementation tasks complete

### Parallel Opportunities

- All Setup tasks marked [P] can run in parallel
- All Foundational tasks marked [P] can run in parallel (within Phase 2)
- Once Foundational phase completes, all user stories can start in parallel (if team capacity allows)
- All tests for a user story marked [P] can run in parallel
- Models within a story marked [P] can run in parallel
- Different user stories can be worked on in parallel by different team members

---

## Parallel Example: User Story 1

```bash
# Launch all tests for User Story 1 together (REQUIRED - TDD):
Task: "Unit test: [Service].[Method]() returns [expected] when [condition]"
Task: "Integration test: [HTTP Method] [endpoint] returns 200 OK with [data]"
Task: "Component test: [Component] displays [element] when data loaded"

# Launch all models for User Story 1 together:
Task: "Create [Entity1] model in src/models/[entity1].py"
Task: "Create [Entity2] model in src/models/[entity2].py"
```

---

## Implementation Strategy

### MVP First (User Story 1 Only)

1. Complete Phase 1: Setup
2. Complete Phase 2: Foundational (CRITICAL - blocks all stories)
3. Complete Phase 3: User Story 1
4. **STOP and VALIDATE**: Test User Story 1 independently
5. Deploy/demo if ready

### Incremental Delivery

1. Complete Setup + Foundational → Foundation ready
2. Add User Story 1 → Test independently → Deploy/Demo (MVP!)
3. Add User Story 2 → Test independently → Deploy/Demo
4. Add User Story 3 → Test independently → Deploy/Demo
5. Each story adds value without breaking previous stories

### Parallel Team Strategy

With multiple developers:

1. Team completes Setup + Foundational together
2. Once Foundational is done:
   - Developer A: User Story 1
   - Developer B: User Story 2
   - Developer C: User Story 3
3. Stories complete and integrate independently

---

## Notes

- [P] tasks = different files, no dependencies
- [Story] label maps task to specific user story for traceability
- Each user story should be independently completable and testable
- Tests are MANDATORY (TDD NON-NEGOTIABLE per constitution)
- Verify tests fail before implementing (red phase)
- Each test task must reference requirements (FR-XXX, AS #X, EC #X)
- Each implementation task should have corresponding test tasks
- Use Test-to-Implementation Mapping tables for traceability
- Commit after each task or logical group
- Stop at any checkpoint to validate story independently
- Avoid: vague tasks, same file conflicts, cross-story dependencies that break independence
