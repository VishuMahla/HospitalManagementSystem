using Hospital_Management_Web_Api.Models.Patient.DTOs;
using Hospital_Management_Web_Api.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }




        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {

            var patients = await _patientService.GetAllPatientsAsync();

            return Ok(patients);
        }

        [HttpPost]
        public async Task<ActionResult> AddPatient(CreatePatientDto dto)
        {
            await _patientService.AddPatientAsync(dto);

            return StatusCode(201, "Patient added successfully");
        }

        [HttpPut("{patientCode}")]
        public async Task<IActionResult> UpdatePatient(int patientCode, UpdatePatientDto dto)
        {
            await _patientService.UpdatePatientAsync(patientCode, dto);

            return NoContent(); // ✅ standard for update
        }




        [HttpPatch("/Deactivate/{patientCode}")]
        public async Task DeactivatePatient(int patientCode)
        {
            await _patientService.DeactivatePatientAsync(patientCode);
        }

        [HttpGet("{patientCode}")]
        public async Task<IActionResult> GetPatientById(int patientCode)
        {

            var patient = await _patientService.GetPatientByIdAsync(patientCode);

            if (patient == null)
                throw new Exception("no patient exist with this patientId");
            return Ok(patient);

        }



    }


}