using Hospital_Management_Web_Api.Models.Doctor;
using Hospital_Management_Web_Api.Models.Doctor.DTOs;
using Hospital_Management_Web_Api.Models.Patient;
using Hospital_Management_Web_Api.Models.Patient.DTOs;

namespace Hospital_Management_Web_Api.Repositories.Interface
{
    public interface IDoctorRepository
    {
        Task AddDoctorAsync(CreateDoctorDto dto);

        Task<List<Doctor>> GetDoctorsAsync();

        Task<List<Doctor>> GetDoctorsBySpecializationAsync(string specialization);
    }
}