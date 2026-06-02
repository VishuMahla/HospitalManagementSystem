# 🏥 Hospital Appointment & Patient Management System

A backend REST API built with **ASP.NET Core**, **C#**, **ADO.NET**, and **SQL Server** to manage patients, doctors, and appointment bookings for City General Hospital.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Database Design](#database-design)
- [Stored Procedures](#stored-procedures)
- [API Endpoints](#api-endpoints)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Key Design Decisions](#key-design-decisions)

---

## Overview

This system provides a fully working REST API backend that handles:

- **Patient Management** — Register, update, deactivate patients with soft-delete
- **Doctor Management** — Store profiles, specializations, availability, and consultation fees
- **Appointment Booking** — Schedule, cancel, and track appointments with transaction safety
- **Reporting** — Revenue by specialization, duplicate booking detection, upcoming appointments

---

## Tech Stack

| Layer | Technology |
|---|---|
| Language | C# (.NET 8) |
| Framework | ASP.NET Core Web API |
| Data Access | ADO.NET |
| Database | Microsoft SQL Server (Express) |
| Testing | Postman |

---

## Project Structure

```
Hospital_Management_Web_Api/
│
├── Controllers/
│   ├── PatientsController.cs
│   ├── DoctorsController.cs
│   └── AppointmentsController.cs
│
├── Domain/
│   ├── BaseEntity.cs               # Abstract base class
│   ├── Patient.cs
│   ├── Doctor.cs
│   └── Appointment.cs
│
├── Repositories/
│   ├── Interfaces/
│   │   ├── IPatientRepository.cs
│   │   └── IAppointmentRepository.cs
│   ├── PatientRepository.cs        # ADO.NET + stored procedure calls
│   └── AppointmentRepository.cs
│
├── Services/
│   ├── PatientService.cs
│   ├── DoctorService.cs
│   └── AppointmentService.cs
│
├── Middleware/
│   ├── RequestLoggingMiddleware.cs
│   └── ExceptionHandlingMiddleware.cs
│
├── Exceptions/
│   ├── NotFoundException.cs
│   ├── ConflictException.cs
│   └── ValidationException.cs
│
├── appsettings.json
└── Program.cs
```

---

## Database Design

Database name: `Hospital_Management_DB`

### Patients Table

```sql
CREATE TABLE Patients (
    PatientCode   INT PRIMARY KEY IDENTITY(1,1),
    FullName      VARCHAR(100) NOT NULL,
    DateOfBirth   DATE NOT NULL,
    Gender        VARCHAR(10) NOT NULL CHECK (Gender IN ('Male', 'Female', 'Other')),
    Phone         VARCHAR(15) UNIQUE NOT NULL,
    Email         VARCHAR(100) UNIQUE NULL,
    IsActive      BIT DEFAULT 1 NOT NULL,
    CreatedAt     DATETIME DEFAULT GETDATE()
)
```

### Doctors Table

```sql
CREATE TABLE Doctors (
    DoctorCode       INT PRIMARY KEY IDENTITY(100,1),
    FullName         VARCHAR(100) NOT NULL,
    Specialization   VARCHAR(100) NOT NULL,
    Phone            VARCHAR(15) UNIQUE NOT NULL,
    ConsultationFee  DECIMAL(10,2) NOT NULL CHECK (ConsultationFee > 0),
    IsAvailable      BIT DEFAULT 1 NOT NULL,
    CreatedAt        DATETIME DEFAULT GETDATE(),
    UpdatedAt        DATETIME NULL
)
```

### Appointments Table

```sql
CREATE TABLE Appointments (
    AppointmentId     INT PRIMARY KEY IDENTITY(1,1),
    PatientCode       INT NOT NULL REFERENCES Patients(PatientCode),
    DoctorCode        INT NOT NULL REFERENCES Doctors(DoctorCode),
    AppointmentDate   DATETIME NOT NULL,
    AppointmentStatus VARCHAR(15) NOT NULL DEFAULT 'Scheduled'
                      CHECK (AppointmentStatus IN ('Scheduled', 'Completed', 'Cancelled')),
    CancelledAt       DATETIME NULL,
    CreatedAt         DATETIME DEFAULT GETDATE()
)
```

---

## Stored Procedures

All database operations are performed **exclusively through stored procedures** — no inline SQL anywhere in the application code.

### Appointments

| Procedure | Description |
|---|---|
| `sp_BookAppointment` | Books an appointment inside a transaction; validates date and doctor availability |
| `sp_CancelAppointment` | Cancels a scheduled appointment and logs `CancelledAt`; rolls back if not found |
| `sp_GetUpcomingAppointments` | Returns all scheduled appointments with a future date |
| `sp_GetDoctorAppointments` | Returns all appointments (any status) for a given doctor |
| `sp_GetPatientAppointments` | Returns all appointments for a given patient |

### Doctors

| Procedure | Description |
|---|---|
| `sp_AddDoctor` | Inserts a new doctor record inside a transaction |
| `sp_GetDoctors` | Returns all doctor records |
| `sp_GetDoctorsBySpecialization` | Filters doctors by specialization with optional availability filter |

### Example — `sp_BookAppointment`

```sql
CREATE PROCEDURE sp_BookAppointment
    @PatientCode INT,
    @DoctorCode  INT,
    @AppointmentDate DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Reject past dates
        IF @AppointmentDate < GETDATE()
            THROW 50001, 'Appointment date cannot be in the past', 1;

        -- Reject unavailable doctors
        IF NOT EXISTS (
            SELECT 1 FROM Doctors
            WHERE DoctorCode = @DoctorCode AND IsAvailable = 1
        )
            THROW 50002, 'Doctor is unavailable', 1;

        INSERT INTO Appointments (PatientCode, DoctorCode, AppointmentDate, AppointmentStatus, CreatedAt)
        VALUES (@PatientCode, @DoctorCode, @AppointmentDate, 'Scheduled', GETDATE());

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
```

---

## API Endpoints

Base URL: `https://localhost:{port}/api`

### Patients

| Method | Endpoint | Description | Response |
|---|---|---|---|
| `POST` | `/patients` | Register a new patient | `201 Created` |
| `GET` | `/patients` | List all active patients (with calculated age) | `200 OK` |
| `PUT` | `/patients/{code}` | Update patient details | `204 No Content` |
| `DELETE` | `/patients/{code}` | Deactivate patient (soft delete) | `204 No Content` |

### Doctors

| Method | Endpoint | Description | Response |
|---|---|---|---|
| `POST` | `/doctors` | Add a new doctor | `201 Created` |
| `GET` | `/doctors` | List all doctors | `200 OK` |
| `GET` | `/doctors?spec={s}` | Filter doctors by specialization | `200 OK` |

### Appointments

| Method | Endpoint | Description | Response |
|---|---|---|---|
| `POST` | `/appointments` | Book a new appointment | `201 Created` |
| `PATCH` | `/appointments/{id}/cancel` | Cancel a scheduled appointment | `204 No Content` |
| `GET` | `/appointments/upcoming` | Get all upcoming scheduled appointments | `200 OK` |
| `GET` | `/appointments/doctor/{code}` | Get appointments for a specific doctor | `200 OK` |

### Reports

| Method | Endpoint | Description | Response |
|---|---|---|---|
| `GET` | `/reports/revenue` | Revenue grouped by specialization | `200 OK` |

### Error Response Format

All errors return a consistent JSON body:

```json
{
  "error": "Doctor is unavailable",
  "statusCode": 409
}
```

| Status Code | Meaning |
|---|---|
| `400` | Validation error (e.g. past appointment date) |
| `404` | Record not found |
| `409` | Conflict (e.g. doctor unavailable, duplicate booking) |
| `500` | Unexpected server error |

---

## Architecture

```
Client / Postman
      ↓
ASP.NET Core Web API  (Controllers)
      ↓
   Service Layer       (Business logic, validation)
      ↓
 Repository Layer      (ADO.NET, calls stored procedures)
      ↓
  SQL Server           (Stored procedures, tables)
```

### Middleware Pipeline

```
Request → ExceptionHandlingMiddleware → RequestLoggingMiddleware → Controller
```

- **`RequestLoggingMiddleware`** — logs HTTP method, path, status code, and response time for every request
- **`ExceptionHandlingMiddleware`** — catches typed exceptions globally and converts them to structured JSON error responses; no try/catch needed in controllers

### Typed Exceptions

| Exception | HTTP Status | When thrown |
|---|---|---|
| `NotFoundException` | 404 | Patient/Doctor/Appointment not found |
| `ConflictException` | 409 | Doctor unavailable, already cancelled |
| `ValidationException` | 400 | Past date, invalid status transition |

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server or SQL Server Express
- Postman (optional, for testing)

### 1. Set up the Database

Run the SQL scripts in this order inside SQL Server Management Studio (SSMS):

```
1. doctors procedures.sql        ← creates Doctors table + stored procedures
2. Appointments Procedures.sql   ← creates Appointments table + stored procedures
```

> Make sure to create the `Hospital_Management_DB` database first:
> ```sql
> CREATE DATABASE Hospital_Management_DB;
> ```

### 2. Configure the Connection String

Open `appsettings.json` and update the connection string to point to your SQL Server instance:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME\\SQLEXPRESS;Database=Hospital_Management_DB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Replace `YOUR_SERVER_NAME` with your machine name or server address.

### 3. Run the API

```bash
cd Hospital_Management_Web_Api
dotnet run
```

The API will start at `https://localhost:5001` (or the port shown in the console).

### 4. Test with Postman

Import the Postman collection (if provided) or manually hit the endpoints listed above.

**Example — Book an appointment:**

```
POST https://localhost:5001/api/appointments
Content-Type: application/json

{
  "patientCode": 1,
  "doctorCode": 100,
  "appointmentDate": "2025-12-01T10:00:00"
}
```

---

## Configuration

| Key | Location | Description |
|---|---|---|
| `ConnectionStrings:DefaultConnection` | `appsettings.json` | SQL Server connection string |
| `Logging:LogLevel:Default` | `appsettings.json` | Default log level (`Information`) |
| `Logging:LogLevel:Microsoft.AspNetCore` | `appsettings.json` | Framework log level (`Warning`) |

---

## Key Design Decisions

**Soft Delete** — Patients are never permanently removed. `IsActive = 0` deactivates them while preserving historical appointment data.

**Stored Procedures Only** — All reads and writes go through stored procedures. No inline SQL in application code. This keeps business logic in one place and improves security.

**Transactions** — `sp_BookAppointment` and `sp_CancelAppointment` both use `BEGIN TRANSACTION` / `COMMIT` / `ROLLBACK`, ensuring data consistency even if something fails mid-operation.

**Interface Abstraction** — Repositories implement interfaces (`IPatientRepository`, `IAppointmentRepository`), making the code testable and swappable without changing business logic.

**Global Middleware** — Logging and exception handling are registered once in `Program.cs` and apply to every request automatically, keeping controllers clean.

**Doctor Identity** — Doctor codes start at `100` (`IDENTITY(100,1)`) to distinguish them from patient codes which start at `1`.
