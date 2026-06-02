using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_Web_Api.Models.Report.DTOs
{
    public class DoctorAppointmentStatsDto
    {
        [Required]
        public int DoctorCode { get; set; }

        [Required]
        public string DoctorName { get; set; } = string.Empty;

        [Required]
        public string Specialization { get; set; } = string.Empty;

        [Required]
        public int AppointmentCount { get; set; }
    }
}
