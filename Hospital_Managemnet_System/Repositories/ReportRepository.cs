using Hospital_Management_Web_Api.Helpers;
using Hospital_Management_Web_Api.Models.Report.DTOs;
using Hospital_Managemnet_System.Models.Appointment.DTOs;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hospital_Management_Web_Api.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public ReportRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<List<AppointmentReportDto>> GetAppointmentReportAsync()
        {
            List<AppointmentReportDto> list = new();

            using SqlConnection con = _dbHelper.GetConnection();
            using SqlCommand cmd = new("sp_GetAppointmentReport", con);

            cmd.CommandType = CommandType.StoredProcedure;

            await con.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                list.Add(new AppointmentReportDto
                {
                    AppointmentId = Convert.ToInt32(reader["AppointmentId"]),
                    PatientName = reader["PatientName"].ToString()!,
                    DoctorName = reader["DoctorName"].ToString()!,
                    Specialization = reader["Specialization"].ToString()!,
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                    AppointmentStatus = reader["AppointmentStatus"].ToString()!,
                    ConsultationFee = Convert.ToDecimal(reader["ConsultationFee"])
                });
            }

            return list;
        }

        public async Task<List<RevenueBySpecializationDto>> GetRevenueBySpecializationAsync()
        {
            List<RevenueBySpecializationDto> list = new();

            using SqlConnection con = _dbHelper.GetConnection();
            using SqlCommand cmd = new("sp_GetRevenueBySpecialization", con);

            cmd.CommandType = CommandType.StoredProcedure;

            await con.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                list.Add(new RevenueBySpecializationDto
                {
                    Specialization = reader["Specialization"].ToString()!,
                    TotalAppointments = Convert.ToInt32(reader["TotalAppointments"]),
                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                });
            }

            return list;
        }

        public async Task<List<DoctorAppointmentStatsDto>> GetDoctorsWithMoreThan2AppointmentsAsync()
        {
            List<DoctorAppointmentStatsDto> list = new();

            using SqlConnection con = _dbHelper.GetConnection();
            using SqlCommand cmd = new("sp_GetDoctorsWithMoreThan2Appointments", con);

            cmd.CommandType = CommandType.StoredProcedure;

            await con.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                list.Add(new DoctorAppointmentStatsDto
                {
                    DoctorCode = Convert.ToInt32(reader["DoctorCode"]),
                    DoctorName = reader["FullName"].ToString()!,
                    Specialization = reader["Specialization"].ToString()!,
                    AppointmentCount = Convert.ToInt32(reader["AppointmentCount"])
                });
            }

            return list;
        }
    }
}