using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_Web_Api.Models.Doctor.DTOs
{
    public class CreateDoctorDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Specialization { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal ConsultationFee { get; set; }
    }
}
