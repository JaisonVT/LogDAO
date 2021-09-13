using LogDAO.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogDAO.Services.Data
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=DESKTOP-1IIFCOO\SQLEXPRESS;Initial Catalog=BondGadget;Integrated Security=True";
        internal bool FindUser(LoginModel loginModel)
        {
            bool success = false;

            string query = "select * from dbo.Users where Username=@username and Password=@password";

            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 50).Value = loginModel.Username;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 50).Value = loginModel.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }
    }
}