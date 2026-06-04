using Hospital_Management_Web_Api.Models.Appointment;
using Hospital_Management_Web_Api.Models.Appointment.DTOs;

namespace Hospital_Management_Web_Api.Services.Interface
{
    public interface IAppointmentService
    {
        // BookAppointmentAsync service contract
        Task BookAppointmentAsync(BookAppointmentDto dto);

        // CancelAppointmentAsync service contract
        Task CancelAppointmentAsync(int appointmentId);

        // GetUpcomingAppointmentsAsync service contract
        Task<List<Appointment>> GetUpcomingAppointmentsAsync();

        // GetDoctorAppointmentsAsync service contract
        Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorCode);
    }
}