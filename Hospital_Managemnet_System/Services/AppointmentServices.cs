using Hospital_Management_Web_Api.Models.Appointment;
using Hospital_Management_Web_Api.Models.Appointment.DTOs;
using Hospital_Management_Web_Api.Repositories.Interface;
using Hospital_Management_Web_Api.Services.Interface;

namespace Hospital_Management_Web_Api.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;

        // AppointmentService constructor
        public AppointmentService(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        // BookAppointmentAsync service method
        public async Task BookAppointmentAsync(BookAppointmentDto dto)
        {
            if (dto.DoctorCode <= 0)
                throw new Exception("Invalid doctor");



            await _repo.BookAppointmentAsync(dto);
        }

        // CancelAppointmentAsync service method
        public async Task CancelAppointmentAsync(int appointmentId)
        {
            if (appointmentId <= 0)
                throw new Exception("Invalid appointment id");

            await _repo.CancelAppointmentAsync(appointmentId);
        }

        // GetUpcomingAppointmentsAsync service method
        public async Task<List<Appointment>> GetUpcomingAppointmentsAsync()
        {
            return await _repo.GetUpcomingAppointmentsAsync();
        }

        // GetDoctorAppointmentsAsync service method
        public async Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorCode)
        {
            if (doctorCode <= 0)
                throw new Exception("Invalid doctor code");

            return await _repo.GetDoctorAppointmentsAsync(doctorCode);
        }
    }
}