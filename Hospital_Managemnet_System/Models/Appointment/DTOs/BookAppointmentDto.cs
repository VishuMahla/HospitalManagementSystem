using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_Web_Api.Models.Appointment.DTOs
{
    public class BookAppointmentDto
    {
        [Required]
        public int PatientCode { get; set; }

        [Required]
        public int DoctorCode { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }

        public string? PatientName { get; internal set; }
    }
}
