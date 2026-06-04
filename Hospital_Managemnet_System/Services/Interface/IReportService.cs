using Hospital_Management_Web_Api.Models.Report.DTOs;
using Hospital_Managemnet_System.Models.Appointment.DTOs;

public interface IReportService
{
    // GetAppointmentReportAsync service contract
    Task<List<AppointmentReportDto>> GetAppointmentReportAsync();

    // GetRevenueBySpecializationAsync service contract
    Task<List<RevenueBySpecializationDto>> GetRevenueBySpecializationAsync();

    // GetDoctorsWithMoreThan2AppointmentsAsync service contract
    Task<List<DoctorAppointmentStatsDto>> GetDoctorsWithMoreThan2AppointmentsAsync();
}