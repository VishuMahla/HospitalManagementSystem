using Hospital_Management_Web_Api.Models.Appointment;
using Hospital_Management_Web_Api.Models.Appointment.DTOs;

namespace Hospital_Management_Web_Api.Repositories.Interface
{
    public interface IAppointmentRepository
    {
        // BookAppointmentAsync repository contract
        Task BookAppointmentAsync(BookAppointmentDto dto);

        // CancelAppointmentAsync repository contract
        Task CancelAppointmentAsync(int appointmentId);

        // GetUpcomingAppointmentsAsync repository contract
        Task<List<Appointment>> GetUpcomingAppointmentsAsync();

        // GetDoctorAppointmentsAsync repository contract
        Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorCode);

        // GetPatientAppointmentsAsync repository contract
        Task<List<Appointment>> GetPatientAppointmentsAsync(int patientCode);
    }
}