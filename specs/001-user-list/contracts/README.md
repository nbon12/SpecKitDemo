# API Contracts

This directory contains API contract specifications for the User List Display feature.

## Files

- `users-api.yaml`: OpenAPI 3.0.3 specification for the Users API endpoint

## Endpoints

### GET /api/users

Retrieves all users from the database.

**Response**: Array of User objects

**Example Response**:
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

**Error Responses**:
- `500 Internal Server Error`: Server error occurred

## Data Models

### User

- `id` (integer, required): Unique identifier
- `username` (string, nullable, optional): Optional username, must be unique when present
- `email` (string, required): Required email address, must be unique

## Notes

- No pagination (deferred per YAGNI)
- Returns all users in single response
- Username can be null
- Email is always present

