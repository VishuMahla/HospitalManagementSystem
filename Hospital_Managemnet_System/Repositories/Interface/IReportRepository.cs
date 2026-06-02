using Hospital_Management_Web_Api.Models.Report.DTOs;
using Hospital_Managemnet_System.Models.Appointment.DTOs;

public interface IReportRepository
{
    Task<List<AppointmentReportDto>> GetAppointmentReportAsync();

    Task<List<RevenueBySpecializationDto>> GetRevenueBySpecializationAsync();

    Task<List<DoctorAppointmentStatsDto>> GetDoctorsWithMoreThan2AppointmentsAsync();
}