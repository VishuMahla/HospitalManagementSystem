using System.ComponentModel.DataAnnotations;

namespace Hospital_Managemnet_System.Models.Appointment.DTOs
{
    public class AppointmentReportDto
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }

        public string AppointmentStatus { get; set; } = string.Empty;
        public decimal ConsultationFee { get; set; }
    }
}
