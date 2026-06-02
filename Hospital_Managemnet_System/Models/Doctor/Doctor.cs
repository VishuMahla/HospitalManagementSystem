using Hospital_Management_Web_Api.Models.Common;

namespace Hospital_Management_Web_Api.Models.Doctor
{
    public class Doctor : PersonBase
    {
        public int DoctorCode { get; set; }

        public string Specialization { get; set; } = string.Empty;

        public decimal ConsultationFee { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}