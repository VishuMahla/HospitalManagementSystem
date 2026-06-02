namespace Hospital_Management_Web_Api.Models.Doctor.DTOs
{
    public class DoctorResponseDto
    {
        public int DoctorCode { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public decimal ConsultationFee { get; set; }

        public bool IsAvailable { get; set; }
    }
} 