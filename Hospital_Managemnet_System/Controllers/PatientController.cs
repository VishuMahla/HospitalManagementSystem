using Hospital_Management_Web_Api.Models.Patient.DTOs;
using Hospital_Management_Web_Api.Services.Interface;
using Hospital_Managemnet_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly EmailServices _emailService;

       
        public PatientController(IPatientService patientService, EmailServices emailServices)
        {
            _patientService = patientService;
            _emailService = emailServices;
        }

        

        // to get all the Patients
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {

            var patients = await _patientService.GetAllPatientsAsync();

            return Ok(patients);
        }


        // to add the patient
        [HttpPost]
        public async Task<ActionResult> AddPatient(CreatePatientDto dto)
        {
            await _patientService.AddPatientAsync(dto);
            string? email = dto.Email;

            if (!string.IsNullOrWhiteSpace(email))

            {

                await _emailService.SendEmailAsync(

                    email, //this is email

                    "Registration Successful",     // this is subject 

                    $@"<html>
                        <body>
                            <h2>Welcome to Nestera HOSPITALS</h2>
                            <p>Hi <strong> {dto.FullName} </strong> ,</p>
                            <p>Your registration was successful on {DateTime.Now:dd MMMM yyyy hh:mm tt} .</p>
                            <p>Thank you for choosing us.</p>
                               <br>
                            <p> Regards, <p>
                            <p> <strong> Nestera Hospital </strong> </p>
                        </body>
                      </html>");
            }
            return StatusCode(201, "Patient added successfully");
        }


        // 
        [HttpPut("{patientCode}")]
        public async Task<IActionResult> UpdatePatient(int patientCode, UpdatePatientDto dto)
        {
            await _patientService.UpdatePatientAsync(patientCode, dto);

            return NoContent(); //  standard for update
        }




        [HttpPatch("/Deactivate/{patientCode}")]
        public async Task DeactivatePatient(int patientCode)
        {
            var patient = await _patientService.GetPatientByIdAsync(patientCode);
            if(patient is not null)
            {
                if (!string.IsNullOrWhiteSpace(patient.Email))

                {

                    await _emailService.SendEmailAsync(

                        patient.Email,

                        "Account Deactivation Notice",

                        $@"

                    <html>
                    <body>
                        <h2>Nestera HOSPITALS</h2>
                        <p>Hello <strong>{patient.FullName}</strong>,</p>

                        <p>Your account has been temporarily deactivated.</p>

                        <p>Thank you for your understanding.</p>

                        <br/>
                        <p>Regards,</p>
                        <p><strong>Nestera HOSPITALS</strong></p>
                    </body>
                    </html>");

                }
            }
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