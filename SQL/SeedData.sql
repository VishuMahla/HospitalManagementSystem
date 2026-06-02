CREATE DATABASE Hospital_Management_DB
USE Hospital_Management_DB


-- Creating Table 
-- 1. Patient's Table 
CREATE TABLE Patients
(
 PatientCode INT PRIMARY KEY IDENTITY(1000,1),
 FullName VARCHAR(100) NOT NULL,
 DOB DATE NOT NULL,
 Gender VARCHAR(10) NOT NULL,
 Phone VARCHAR(15) UNIQUE NOT NULL,
 Email VARCHAR(100)  NULL,
 IsActive BIT DEFAULT 1 NOT NULL,
 CreatedAt DATETIME DEFAULT GETDATE(),
 UpdatedAt DATETIME NULL
)

select * from Patients

--2. Doctor's Table
CREATE TABLE Doctors
(
 DoctorCode INT PRIMARY KEY IDENTITY(100,1),
 FullName VARCHAR(100) NOT NULL,
 Specialization VARCHAR(100) NOT NULL,
 Phone VARCHAR(15) UNIQUE NOT NULL,
 ConsultationFee DECIMAL(10,2) NOT NULL CHECK(ConsultationFee > 0),
 IsAvailable BIT DEFAULT 1 NOT NULL,
 CreatedAt DATETIME DEFAULT GETDATE(),
 UpdatedAt DATETIME NULL
)

--3. Appoitment's Tabel
CREATE TABLE Appointments
(
 AppointmentId INT PRIMARY KEY IDENTITY(1,1),
 PatientCode INT NOT NULL,
 DoctorCode INT  NOT NULL,
 AppointmentDate DATETIME NOT NULL,
 AppointmentStatus VARCHAR(15) NOT NULL DEFAULT 'Scheduled'
 CHECK(AppointmentStatus IN ('Scheduled','Completed','Cancelled')),
 CancelledAt DATETIME NULL,
 CreatedAt DATETIME DEFAULT GETDATE(),
 CONSTRAINT FK_Appointment_Patient
 FOREIGN KEY(PatientCode) 

 REFERENCES Patients(PatientCode),
 CONSTRAINT FK_Appointment_dOCTOR

 FOREIGN KEY(DoctorCode)
 REFERENCES Doctors(DoctorCode)


)


drop table Appointments


-- PATIENTS SAMPLE DATA

select * from patients


INSERT INTO Patients
(FullName, DOB, Gender, Phone, Email)
VALUES
('Anirudh Patil', '2003-05-10', 'Male', '9876500001', 'anirudh@gmail.com'),

('Rahul Sharma', '1999-08-14', 'Male', '9876500002', 'rahul@gmail.com'),

('Sneha Reddy', '2001-11-20', 'Female', '9876500003', 'sneha@gmail.com'),

('Priya Nair', '1998-03-25', 'Female', '9876500004', 'priya@gmail.com'),

('Kiran Kumar', '2000-07-12', 'Male', '9876500005', 'kiran@gmail.com');


-- DOCTORS SAMPLE DATA

select * from doctors
INSERT INTO Doctors
(FullName, Specialization, Phone, ConsultationFee)
VALUES
('Dr. Rajesh', 'Cardiology', '9000000001', 800.00),

('Dr. Meena', 'Neurology', '9000000002', 1200.00),

('Dr. Arjun', 'Orthopedics', '9000000003', 700.00),

('Dr. Kavya', 'Dermatology', '9000000004', 500.00),

('Dr. Vikram', 'Pediatrics', '9000000005', 600.00);

select * from Doctors

UPDATE Doctors
SET UpdatedAt = SYSDATETIME();

-- APPOINTMENTS SAMPLE DATA

INSERT INTO Appointments
(PatientCode, DoctorCode, AppointmentDate, AppointmentStatus)
VALUES
(1000, 100, '2026-05-30 10:00:00', 'Scheduled'),

(1001, 101, '2026-05-30 11:00:00', 'Completed'),

(1002, 102, '2026-05-31 09:30:00', 'Scheduled'),

(1003, 103, '2026-06-01 02:00:00', 'Cancelled'),

(1004, 104, '2026-06-02 04:30:00', 'Scheduled');

select * from Appointments



truncate table Doctors
truncate table appointments
truncate table patients


drop table Doctors
drop table appointments
drop table patients


-- =========================
-- PATIENTS
-- =========================
INSERT INTO Patients
(
    FullName,
    DOB,
    Gender,
    Phone,
    Email
)
VALUES
('Rahul Sharma','1995-04-15','Male','9876543210','rahul@gmail.com'),
('Priya Patel','1998-08-22','Female','9876543211','priya@gmail.com'),
('Amit Verma','1992-12-10','Male','9876543212','amit@gmail.com'),
('Sneha Reddy','2000-03-05','Female','9876543213','sneha@gmail.com'),
('Vikram Singh','1988-11-18','Male','9876543214','vikram@gmail.com'),
('Anjali Gupta','1997-09-30','Female','9876543215','anjali@gmail.com'),
('Karan Mehta','1994-07-12','Male','9876543216','karan@gmail.com'),
('Pooja Nair','1999-01-25','Female','9876543217','pooja@gmail.com'),
('Arjun Rao','1991-05-08','Male','9876543218','arjun@gmail.com'),
('Neha Joshi','1996-10-14','Female','9876543219','neha@gmail.com');


-- =========================
-- DOCTORS
-- =========================
INSERT INTO Doctors
(
    FullName,
    Specialization,
    Phone,
    ConsultationFee
)
VALUES
('Dr. Rajesh Kumar','Cardiology','9000000001',800),
('Dr. Meena Iyer','Dermatology','9000000002',600),
('Dr. Suresh Reddy','Orthopedics','9000000003',1000),
('Dr. Kavita Sharma','Pediatrics','9000000004',700),
('Dr. Arvind Gupta','Neurology','9000000005',1200);





-- =========================
-- APPOINTMENTS
-- =========================
INSERT INTO Appointments
(
    PatientCode,
    DoctorCode,
    AppointmentDate,
    AppointmentStatus,
    CancelledAt
)
VALUES
(1000,100,'2026-06-05 10:00:00','Scheduled',NULL),
(1001,101,'2026-06-05 11:00:00','Scheduled',NULL),
(1002,102,'2026-05-20 09:30:00','Completed',NULL),
(1003,103,'2026-05-18 14:00:00','Completed',NULL),
(1004,104,'2026-06-06 15:00:00','Scheduled',NULL),
(1005,100,'2026-05-15 12:00:00','Cancelled','2026-05-14 09:00:00'),
(1006,101,'2026-05-22 16:30:00','Completed',NULL),
(1007,102,'2026-06-07 10:30:00','Scheduled',NULL),
(1008,103,'2026-05-10 13:00:00','Cancelled','2026-05-09 18:00:00'),
(1009,104,'2026-06-08 17:00:00','Scheduled',NULL),
(1000,101,'2026-05-12 11:00:00','Completed',NULL),
(1001,102,'2026-06-10 09:00:00','Scheduled',NULL),
(1002,103,'2026-05-28 15:30:00','Completed',NULL),
(1003,104,'2026-06-12 10:00:00','Scheduled',NULL),
(1004,100,'2026-05-30 12:30:00','Completed',NULL);





   
-- patient queries
--ADDING PATIENT

CREATE PROCEDURE sp_AddPatient
(
    @FullName VARCHAR(100),
    @DOB DATE,
    @Gender VARCHAR(10),
    @Phone VARCHAR(15),
    @Email VARCHAR(100)
)
AS
BEGIN
    BEGIN TRY

        BEGIN TRANSACTION;

        INSERT INTO Patients
        (
            FullName,
            DOB,
            Gender,
            Phone,
            Email,
            IsActive,
            CreatedAt,
            UpdatedAt
        )
        VALUES
        (
            @FullName,
            @DOB,
            @Gender,
            @Phone,
            @Email,
            1,
            GETDATE(),
            GETDATE()
        );

        COMMIT;

    END TRY

    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK;

        THROW;

    END CATCH
END


exec sp_AddPatient 'Anirudh Patil101', '2004-05-10', 'Male', '9876509901', 'anirudh@gmail.com'
select * from Patients

-- UPDATE PATIENT
ALTER PROCEDURE sp_UpdatePatient
(
    @PatientCode INT,
    @FullName VARCHAR(100) = NULL,
    @DOB DATE = NULL,
    @Gender VARCHAR(10) = NULL,
    @Phone VARCHAR(15) = NULL,
    @Email VARCHAR(100) = NULL
)
AS
BEGIN
    BEGIN TRY

        BEGIN TRANSACTION;

        UPDATE Patients
        SET
            FullName = ISNULL(NULLIF(@FullName, ''), FullName),

            DOB = ISNULL(@DOB, DOB),

            Gender = ISNULL(NULLIF(@Gender, ''), Gender),

            Phone = ISNULL(NULLIF(@Phone, ''), Phone),

            Email = ISNULL(NULLIF(@Email, ''), Email),

            UpdatedAt = GETDATE()

        WHERE PatientCode = @PatientCode;

        IF @@ROWCOUNT = 0
        BEGIN
            THROW 50001, 'Patient not found', 1;
        END

        COMMIT;

    END TRY

    BEGIN CATCH

      
            ROLLBACK;

        THROW;

    END CATCH
END




-- DEACTIVATE PATIENT
CREATE PROCEDURE sp_DeactivatePatient
    @PatientCode INT
AS
BEGIN
    BEGIN TRY

        BEGIN TRANSACTION;

        UPDATE Patients
        SET
            IsActive = 0,
            UpdatedAt = GETDATE()
        WHERE PatientCode = @PatientCode
          AND IsActive = 1;

        IF @@ROWCOUNT = 0
        BEGIN
            THROW 50002, 'Patient not found or already deactivated', 1;
        END

        COMMIT;

    END TRY

    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK;

        THROW;

    END CATCH
END



--GET ALL PATIENTS

CREATE PROCEDURE sp_GetAllPatients
AS
BEGIN
    BEGIN TRY

        SELECT *
    FROM Patients
    WHERE IsActive = 1;

    END TRY

    BEGIN CATCH
        THROW;
    END CATCH
END


-- get patient by id

CREATE PROCEDURE sp_GetPatientById
    @PatientCode INT
AS
BEGIN
    BEGIN TRY

        SELECT
            PatientCode,
            FullName,
            DOB,
            Gender,
            Phone,
            Email,
            IsActive,
            CreatedAt,
            UpdatedAt
        FROM Patients
        WHERE PatientCode = @PatientCode
          AND IsActive = 1;

        IF @@ROWCOUNT = 0
        BEGIN
            THROW 50003, 'Patient not found', 1;
        END

    END TRY

    BEGIN CATCH

        THROW;

    END CATCH
END




CREATE PROCEDURE sp_GetAppointmentReport
AS
BEGIN
    SELECT
        A.AppointmentId,
        P.FullName AS PatientName,
        D.FullName AS DoctorName,
        D.Specialization,
        A.AppointmentDate,
        A.AppointmentStatus,
        D.ConsultationFee
    FROM Appointments A
    INNER JOIN Patients P
        ON A.PatientCode = P.PatientCode
    INNER JOIN Doctors D
        ON A.DoctorCode = D.DoctorCode
    ORDER BY A.AppointmentDate DESC;
END
GO




CREATE PROCEDURE sp_GetRevenueBySpecialization
AS
BEGIN
    SELECT
        D.Specialization,
        COUNT(A.AppointmentId) AS TotalAppointments,
        SUM(D.ConsultationFee) AS TotalRevenue
    FROM Appointments A
    INNER JOIN Doctors D
        ON A.DoctorCode = D.DoctorCode
    WHERE A.AppointmentStatus <> 'Cancelled'
    GROUP BY D.Specialization
    ORDER BY TotalRevenue DESC;
END
GO




CREATE PROCEDURE sp_GetDoctorsWithMoreThan2Appointments
AS
BEGIN
    SELECT
        D.DoctorCode,
        D.FullName,
        D.Specialization,
        COUNT(A.AppointmentId) AS AppointmentCount
    FROM Doctors D
    INNER JOIN Appointments A
        ON D.DoctorCode = A.DoctorCode
    GROUP BY
        D.DoctorCode,
        D.FullName,
        D.Specialization
    HAVING COUNT(A.AppointmentId) > 2
    ORDER BY AppointmentCount DESC;
END
GO

-- get upcomming appointments
ALTER PROCEDURE sp_GetUpcomingAppointments
AS
BEGIN
    BEGIN TRY
SELECT            AppointmentId,            PatientCode,            DoctorCode,            AppointmentDate,            AppointmentStatus,            CancelledAt

        FROM Appointments

        WHERE AppointmentDate >= GETDATE()AND AppointmentStatus = 'Scheduled'ORDER BY AppointmentDate;END TRY
        BEGIN CATCH
        THROW;
        END CATCH
END

CREATE PROCEDURE sp_UpdateCompletedAppointments
AS
BEGIN
    BEGIN TRY
    UPDATE Appointments

        SET AppointmentStatus = 'Completed'WHERE AppointmentStatus = 'Scheduled'AND AppointmentDate < GETDATE();
        END
        TRY
        BEGIN CATCH
        THROW;END CATCH
        END
        GO


