using Hospital_Management_Web_Api.Models.Doctor.DTOs;
using Hospital_Management_Web_Api.Services;
using Hospital_Management_Web_Api.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorServices)
        {
            _doctorService = doctorServices;
        }




        [HttpPost]
        public async Task<IActionResult> AddDoctor(CreateDoctorDto dto)
        {
            await _doctorService.AddDoctorAsync(dto);

            return StatusCode(201, "Doctor added successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _doctorService.GetDoctorsAsync();

            return Ok(doctors);
        }


        [HttpGet("specialization/{specialization}")]
        public async Task<IActionResult> GetDoctorsBySpecialization(string specialization)
        {
            var doctors =
                await _doctorService
                .GetDoctorsBySpecializationAsync(specialization);

            return Ok(doctors);
        }

    }
}