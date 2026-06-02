namespace Hospital_Management_Web_Api.Models.Report.DTOs
{
    public class RevenueBySpecializationDto
    {
        public string Specialization { get; set; } = string.Empty;
        public int TotalAppointments { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}