using Payroll_Sys.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Payroll_Sys.Controllers.Data
{
    internal class RegisterDAO
    {
        private string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=aspnet-Payroll Sys-20211117120929;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<RegisterViewModel> FetchAll()
        {
            List<RegisterViewModel> returnList = new List<RegisterViewModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.AspNetUsers";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RegisterViewModel register = new RegisterViewModel();
                        register.Firstname = reader.GetString(12);
                        register.Lastname = reader.GetString(13);
                        register.Email = reader.GetString(1);
                        register.Salary = reader.GetInt32(14);

                        returnList.Add(register);
                    }
                }
            }
            return returnList;
        }

        internal List<RegisterViewModel> SearchForName(string searchPhrase)
        {
            List<RegisterViewModel> returnList = new List<RegisterViewModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.AspNetUsers WHERE Lastname LIKE @searchForMe ";
                

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" +searchPhrase+ "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RegisterViewModel register = new RegisterViewModel();
                        register.Firstname = reader.GetString(12);
                        register.Lastname = reader.GetString(13);
                        register.Email = reader.GetString(1);
                        register.Salary = reader.GetInt32(14);

                        returnList.Add(register);
                    }
                }
            }
            return returnList;

        }

        internal int Delete(int Id)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM dbo.AspNetUsers WHERE Id= @Id";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value=Id;
                connection.Open();

                int deletestr=command.ExecuteNonQuery();

                return deletestr;
                


            }
        }
    }
}