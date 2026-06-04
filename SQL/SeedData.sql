
USE Hospital_Management_DB


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


exec sp_help 'Doctors'

select name from sys.procedures
