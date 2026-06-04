using Hospital_Management_Web_Api.Models.Doctor;
using Hospital_Management_Web_Api.Models.Doctor.DTOs;

namespace Hospital_Management_Web_Api.Services.Interface
{
    public interface IDoctorService
    {
        // AddDoctorAsync service contract
        Task AddDoctorAsync(CreateDoctorDto dto);

        // GetDoctorsAsync service contract
        Task<List<Doctor>> GetDoctorsAsync();

        // GetDoctorsBySpecializationAsync service contract
        Task<List<Doctor>> GetDoctorsBySpecializationAsync(string specialization);
    }
}