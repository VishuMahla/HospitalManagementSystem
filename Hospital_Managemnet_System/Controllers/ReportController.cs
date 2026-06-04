using Hospital_Management_Web_Api.Services.Interface;
using Hospital_Managemnet_System.Models.Appointment.DTOs;
using Microsoft.AspNetCore.Mvc;
using Hospital_Management_Web_Api.Models.Report.DTOs;

namespace Hospital_Management_Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        // ReportController constructor
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("appointments")]
        // GetAppointmentReport controller method
        public async Task<IActionResult> GetAppointmentReport()
        {
            List<AppointmentReportDto> reports =
                await _reportService.GetAppointmentReportAsync();

            return Ok(reports);
        }

        [HttpGet("revenue")]
        // GetRevenueBySpecialization controller method
        public async Task<IActionResult> GetRevenueBySpecialization()
        {
            List<RevenueBySpecializationDto> reports =
                await _reportService.GetRevenueBySpecializationAsync();

            return Ok(reports);
        }

        [HttpGet("busy-doctors")]
        // GetDoctorsWithMoreThan2Appointments controller method
        public async Task<IActionResult> GetDoctorsWithMoreThan2Appointments()
        {
            List<DoctorAppointmentStatsDto> reports =
                await _reportService.GetDoctorsWithMoreThan2AppointmentsAsync();

            return Ok(reports);
        }
    }
}