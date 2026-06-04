using Hospital_Management_Web_Api.Helpers;
using Hospital_Management_Web_Api.Models.Patient;
using Hospital_Management_Web_Api.Models.Patient.DTOs;
using Hospital_Management_Web_Api.Repositories.Interface;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Numerics;

namespace Hospital_Management_Web_Api.Repositories
{
    public class PatientRepository : IPatientRepository
    {

        private readonly DatabaseHelper _dbHelper;

        // PatientRepository constructor
        public PatientRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }




        // AddPatientAsync repository method
        public async Task AddPatientAsync(CreatePatientDto dto)
        {
            try
            {
                using (SqlConnection con = _dbHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_AddPatient", con);
                    cmd.Parameters.AddWithValue("@FullName", dto.FullName);
                    cmd.Parameters.AddWithValue("@DOB", dto.DOB);
                    cmd.Parameters.AddWithValue("@Gender", dto.Gender);
                    cmd.Parameters.AddWithValue("@Phone", dto.Phone);
                    cmd.Parameters.AddWithValue("@Email", dto.Email ?? (object)DBNull.Value);

                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();
                    var rowsAffected = await cmd.ExecuteNonQueryAsync();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Failed to add patient.");
                    }


                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        // DeactivatePatientAsync repository method
        public async Task DeactivatePatientAsync(int patientCode)
        {
            try
            {
                using (SqlConnection con = _dbHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_DeactivatePatient", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientCode", patientCode);
                    await con.OpenAsync();
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Failed to deactivate patient.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        // UpdatePatientAsync repository method
        public async Task UpdatePatientAsync(int patientCode, UpdatePatientDto dto)
        {
            try
            {
                using (SqlConnection con = _dbHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdatePatient", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientCode", patientCode);
                    cmd.Parameters.AddWithValue("@FullName", dto.FullName);
                    cmd.Parameters.AddWithValue("@DOB", dto.DOB);

                    cmd.Parameters.AddWithValue("@Gender", dto.Gender);

                    cmd.Parameters.AddWithValue("@Phone", dto.Phone);

                    cmd.Parameters.AddWithValue("@Email", dto.Email);

                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();
                    var rowsAffected = await cmd.ExecuteNonQueryAsync();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Failed to add patient.");
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }


        }
        // GetAllPatientsAsync repository method
        async Task<List<Patient>> IPatientRepository.GetAllPatientsAsync()
        {
            using (SqlConnection con = _dbHelper.GetConnection())
            {
                List<Patient> patients = new List<Patient>();

                SqlCommand cmd = new SqlCommand("sp_GetAllPatients", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    patients.Add(new Patient
                    {
                        PatientCode = Convert.ToInt32(reader["PatientCode"]),
                        FullName = reader["FullName"].ToString(),
                        DOB = Convert.ToDateTime(reader["DOB"]),
                        Gender = reader["Gender"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"]?.ToString(),
                        IsActive = Convert.ToBoolean(reader["IsActive"])
                    });
                }
                return patients;
            }
        }

        // GetPatientByIdAsync repository method
        async Task<Patient?> IPatientRepository.GetPatientByIdAsync(int patientCode)
        {
            try
            {
                using (SqlConnection con = _dbHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_GetPatientById", con);
                    cmd.Parameters.AddWithValue("@PatientCode", patientCode);
                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Patient
                            {
                                PatientCode = Convert.ToInt32(reader["PatientCode"]),
                                FullName = reader["FullName"].ToString(),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                Gender = reader["Gender"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Email = reader["Email"]?.ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}