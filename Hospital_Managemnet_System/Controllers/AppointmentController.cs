using Hospital_Management_Web_Api.Models.Appointment.DTOs;
using Hospital_Management_Web_Api.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentService _service;

        // AppointmentController constructor
        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }


        [HttpPost("book")]
        // BookAppointment method
        public async Task<IActionResult> BookAppointment(BookAppointmentDto dto)
        {
            await _service.BookAppointmentAsync(dto);
            return StatusCode(201, "Appointment booked successfully");
        }

        [HttpDelete("cancel/{id}")]
        // CancelAppointment method
        public async Task<IActionResult> CancelAppointment(int id)
        {
            await _service.CancelAppointmentAsync(id);
            return Ok("Appointment cancelled successfully");
        }

        [HttpGet("upcoming")]
        // GetUpcoming method
        public async Task<IActionResult> GetUpcoming()
        {
            var data = await _service.GetUpcomingAppointmentsAsync();
            return Ok(data);
        }

        [HttpGet("doctor/{doctorCode}")]
        // GetDoctorAppointments method
        public async Task<IActionResult> GetDoctorAppointments(int doctorCode)
        {
            var data = await _service.GetDoctorAppointmentsAsync(doctorCode);
            return Ok(data);
        }
    }
}