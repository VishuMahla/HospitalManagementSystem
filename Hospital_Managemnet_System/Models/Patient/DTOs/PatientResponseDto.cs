namespace Hospital_Management_Web_Api.Models.Patient.DTOs
{
    public class PatientResponseDto
    {
        public int PatientCode { get; set; }

        public string FullName { get; set; } = string.Empty;

        public DateTime DOB { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public bool IsActive { get; set; }
    }
}