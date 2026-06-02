using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_Web_Api.Models.Patient.DTOs
{
    public class CreatePatientDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }
    }
}