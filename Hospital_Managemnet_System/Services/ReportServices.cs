using Hospital_Management_Web_Api.Models.Report.DTOs;
using Hospital_Management_Web_Api.Repositories.Interface;
using Hospital_Managemnet_System.Models.Appointment.DTOs;

namespace Hospital_Management_Web_Api.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        // ReportService constructor
        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        // GetAppointmentReportAsync service method
        public async Task<List<AppointmentReportDto>> GetAppointmentReportAsync()
        {
            return await _repository.GetAppointmentReportAsync();
        }

        // GetRevenueBySpecializationAsync service method
        public async Task<List<RevenueBySpecializationDto>> GetRevenueBySpecializationAsync()
        {
            return await _repository.GetRevenueBySpecializationAsync();
        }

        // GetDoctorsWithMoreThan2AppointmentsAsync service method
        public async Task<List<DoctorAppointmentStatsDto>> GetDoctorsWithMoreThan2AppointmentsAsync()
        {
            return await _repository.GetDoctorsWithMoreThan2AppointmentsAsync();
        }
    }
}