USE Hospital_Management_DB

sp_AddDoctor
sp_GetDoctors
sp_GetDoctorsBySpecialization

DROP TABLE Doctors
drop table appointments
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


-- ADD DOCTOR
ALTER PROCEDURE sp_AddDoctor
    @FullName VARCHAR(100),
    @Specialization VARCHAR(100),
    @Phone VARCHAR(15),
    @ConsultationFee DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY

        BEGIN TRANSACTION;

        INSERT INTO Doctors
        (
            FullName,
            Specialization,
            Phone,
            ConsultationFee,
            IsAvailable,
            CreatedAt,
            UpdatedAt
        )
        VALUES
        (
            @FullName,
            @Specialization,
            @Phone,
            @ConsultationFee,
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

-- GET DOCTOR

CREate PROCEDURE sp_GetDoctors
AS
BEGIN
    BEGIN TRY

        SELECT
            DoctorCode,
            FullName,
            Specialization,
            Phone,
            ConsultationFee,
            IsAvailable,
            CreatedAt,
            UpdatedAt
        FROM Doctors;

    END TRY

    BEGIN CATCH
        THROW;
    END CATCH
END



-- get doctor by specialization

alter PROCEDURE sp_GetDoctorsBySpecialization
    @Specialization VARCHAR(100),
    @IsAvailable BIT = NULL
AS
BEGIN
    BEGIN TRY

        SELECT
            DoctorCode,
            FullName,
            Specialization,
            Phone,
            ConsultationFee,
            IsAvailable,
            CreatedAt,
            UpdatedAt
        FROM Doctors
        WHERE Specialization = @Specialization
          AND (@IsAvailable IS NULL OR IsAvailable = @IsAvailable);

    END TRY

    BEGIN CATCH

        THROW;

    END CATCH
END

