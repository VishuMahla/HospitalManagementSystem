using Hospital_Management_Web_Api.Models.Patient;
using Hospital_Management_Web_Api.Models.Patient.DTOs;
using Hospital_Management_Web_Api.Repositories.Interface;
using Hospital_Management_Web_Api.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_Web_Api.Services
{
    public class PatientService : IPatientService
    {
        // getting the object of patient repository
        public readonly IPatientRepository _patientRepository;


        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }



        // ADD PATIENT
        public async Task AddPatientAsync(CreatePatientDto dto)
        {
            if (dto.Phone.Length > 12)
            {
                throw new ValidationException(
                    "Phone number cannot exceed 12 characters.");
            }
            if (dto.DOB > DateTime.Today)
            {
                throw new Exception("DOB cannot be a future date...");
            }
            await _patientRepository.AddPatientAsync(dto);
        }


        // DEACTIVATE PATIENT
        public async Task DeactivatePatientAsync(int patientCode)
        {
            await _patientRepository.DeactivatePatientAsync(patientCode);
        }


        // GET ALL PATIENTS
        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllPatientsAsync();
        }


        // UPDATE PATIENT
        public async Task UpdatePatientAsync(int PatientCode, UpdatePatientDto dto)
        {
            await _patientRepository.UpdatePatientAsync(PatientCode, dto);
        }





        // GET PATIENTS BY ID
        async Task<Patient> IPatientService.GetPatientByIdAsync(int patientCode)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(patientCode);

            if (patient == null)
                throw new KeyNotFoundException($"Patient with ID {patientCode} not found.");

            return patient;
        }


    }
}