using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using UserMedication.Models;

namespace UserMedication.DAL
{
    public class UserMedicationDAL
    {
        private readonly IConfiguration _config;
        public UserMedicationDAL(IConfiguration config)
        {
            _config = config;
        }
        public async Task<bool> SeedData(DataTable UsersData, DataTable UserMedicationDT)
        {
            bool res = false;
            try
            {
                SqlConnection conn = new SqlConnection(_config.GetConnectionString("connectionString"));
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_SaveUsersData", conn))
                {

                    cmd.Parameters.Add(new SqlParameter("@UsersData", UsersData));
                    cmd.Parameters.Add(new SqlParameter("@UserMedicationData", UserMedicationDT));
                    cmd.CommandType = CommandType.StoredProcedure;
                    res = Convert.ToBoolean(await cmd.ExecuteScalarAsync());
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return res;
        }

        public async Task<bool> UpdateUser(UserMedicationData userMedicationData)
        {
            bool res = false;
            try
            {
                SqlConnection conn = new SqlConnection(_config.GetConnectionString("connectionString"));
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_UpdateUser", conn))
                {

                    cmd.Parameters.Add(new SqlParameter("@Name", userMedicationData.Name));
                    cmd.Parameters.Add(new SqlParameter("@Email", userMedicationData.Email));
                    cmd.Parameters.Add(new SqlParameter("@ProvinceID", userMedicationData.Province));
                    cmd.Parameters.Add(new SqlParameter("@IsActive", userMedicationData.IsActive));
                    cmd.Parameters.Add(new SqlParameter("@UserId", userMedicationData.UserId));
                    DataTable dt = new DataTable();
                    dt.Columns.Add("MedicationID");
                    dt.Columns.Add("UserID");
                    foreach (var med in userMedicationData.Medication)
                    {
                        dt.Rows.Add(med, userMedicationData.UserId);
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    res = Convert.ToBoolean(await cmd.ExecuteScalarAsync());
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return res;
        }

        public async Task<DataTable> GellAllUserMedication()
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(_config.GetConnectionString("connectionString"));
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GellAllUserMedication", conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    table.Load(dr);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return table;
        }

        public async Task<bool> AddUser(UserMedicationData userMedicationData)
        {
            bool res = false;
            try
            {
                SqlConnection conn = new SqlConnection(_config.GetConnectionString("connectionString"));
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_CreateNewUser", conn))
                {

                    cmd.Parameters.Add(new SqlParameter("@Name", userMedicationData.Name));
                    cmd.Parameters.Add(new SqlParameter("@Email", userMedicationData.Email));
                    cmd.Parameters.Add(new SqlParameter("@ProvinceID", userMedicationData.Province));
                    cmd.Parameters.Add(new SqlParameter("@IsActive", userMedicationData.IsActive));
                    DataTable dt = new DataTable();
                    dt.Columns.Add("MedicationID");
                    foreach (var med in userMedicationData.Medication)
                    {
                        dt.Rows.Add(med);
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserMedicationData", dt));
                    res = Convert.ToBoolean(await cmd.ExecuteScalarAsync());
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return res;
        }


        public async Task<bool> DeactivateUser(int UserID)
        {
            bool res = false;
            try
            {


                SqlConnection conn = new SqlConnection(_config.GetConnectionString("connectionString"));
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_DeactivateUser", conn))
                {

                    cmd.Parameters.Add(new SqlParameter("@UserId", UserID));

                    cmd.CommandType = CommandType.StoredProcedure;
                    res = Convert.ToBoolean(await cmd.ExecuteScalarAsync());
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return res;
        }
    }
}

