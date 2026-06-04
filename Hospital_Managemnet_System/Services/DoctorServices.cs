using Hospital_Management_Web_Api.Models.Doctor;
using Hospital_Management_Web_Api.Models.Doctor.DTOs;
using Hospital_Management_Web_Api.Models.Patient;
using Hospital_Management_Web_Api.Repositories;
using Hospital_Management_Web_Api.Repositories.Interface;
using Hospital_Management_Web_Api.Services.Interface;

namespace Hospital_Management_Web_Api.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        // DoctorService constructor
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }



        // AddDoctorAsync service method
        public async Task AddDoctorAsync(CreateDoctorDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new Exception("Doctor name is required.");

            if (string.IsNullOrWhiteSpace(dto.Specialization))
                throw new Exception("Specialization is required.");

            if (dto.ConsultationFee <= 0)
                throw new Exception("Consultation fee must be greater than zero.");

            await _doctorRepository.AddDoctorAsync(dto);
        }

        // GetDoctorsAsync service method
        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            return await _doctorRepository.GetDoctorsAsync();
        }

        // Get_doctorRepository1 helper method
        public IDoctorRepository Get_doctorRepository1()
        {
            return _doctorRepository;
        }

        // GetDoctorsBySpecializationAsync service method
        public async Task<List<Doctor>> GetDoctorsBySpecializationAsync(
            string specialization)
        {
            if (string.IsNullOrWhiteSpace(specialization))
                throw new Exception("Specialization is required.");

            return await _doctorRepository.GetDoctorsBySpecializationAsync(specialization);
        }


    }
}