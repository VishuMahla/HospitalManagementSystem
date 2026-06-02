using Hospital_Management_Web_Api.Models.Appointment;
using Hospital_Management_Web_Api.Models.Appointment.DTOs;

namespace Hospital_Management_Web_Api.Services.Interface
{
    public interface IAppointmentService
    {
        Task BookAppointmentAsync(BookAppointmentDto dto);
        Task CancelAppointmentAsync(int appointmentId);
        Task<List<Appointment>> GetUpcomingAppointmentsAsync();
        Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorCode);
    }
}