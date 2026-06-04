using Hospital_Management_Web_Api.Models.Patient;
using Hospital_Management_Web_Api.Models.Patient.DTOs;

namespace Hospital_Management_Web_Api.Services.Interface
{
    public interface IPatientService
    {
        // AddPatientAsync service contract
        Task AddPatientAsync(CreatePatientDto dto);

        // UpdatePatientAsync service contract
        Task UpdatePatientAsync(int atientCode, UpdatePatientDto dto);

        // DeactivatePatientAsync service contract
        Task DeactivatePatientAsync(int patientCode);


        // GetPatientByIdAsync service contract
        Task<Patient?> GetPatientByIdAsync(int patientCode);

        // GetAllPatientsAsync service contract
        Task<List<Patient>> GetAllPatientsAsync();
    }
}