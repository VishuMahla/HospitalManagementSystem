using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_Web_Api.Models.Appointment.DTOs
{
    public class CancelAppointmentDto
    {
        [Required]
        public int AppointmentId { get; set; }
    }
}
