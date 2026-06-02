namespace Hospital_Management_Web_Api.Models.Appointment
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public int PatientCode { get; set; }

        public int DoctorCode { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string AppointmentStatus { get; set; } = string.Empty;

        public DateTime? CancelledAt { get; set; }
    }
}