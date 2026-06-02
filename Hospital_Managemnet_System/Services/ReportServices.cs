using Hospital_Management_Web_Api.Models.Report.DTOs;
using Hospital_Management_Web_Api.Repositories.Interface;
using Hospital_Managemnet_System.Models.Appointment.DTOs;

namespace Hospital_Management_Web_Api.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AppointmentReportDto>> GetAppointmentReportAsync()
        {
            return await _repository.GetAppointmentReportAsync();
        }

        public async Task<List<RevenueBySpecializationDto>> GetRevenueBySpecializationAsync()
        {
            return await _repository.GetRevenueBySpecializationAsync();
        }

        public async Task<List<DoctorAppointmentStatsDto>> GetDoctorsWithMoreThan2AppointmentsAsync()
        {
            return await _repository.GetDoctorsWithMoreThan2AppointmentsAsync();
        }
    }
}