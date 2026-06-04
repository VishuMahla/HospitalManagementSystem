using Hospital_Management_Web_Api.Models.Patient;
using Hospital_Management_Web_Api.Models.Patient.DTOs;

namespace Hospital_Management_Web_Api.Repositories.Interface
{
    public interface IPatientRepository
    {
        // AddPatientAsync repository contract
        Task AddPatientAsync(CreatePatientDto dto);

        // UpdatePatientAsync repository contract
        Task UpdatePatientAsync(int patientCode, UpdatePatientDto dto);

        // DeactivatePatientAsync repository contract
        Task DeactivatePatientAsync(int patientCode);

        // GetAllPatientsAsync repository contract
        Task<List<Patient>> GetAllPatientsAsync();

        // GetPatientByIdAsync repository contract
        Task<Patient?> GetPatientByIdAsync(int patientCode);
    }
}