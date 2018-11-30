using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OBBC_Vedligeholdelse
{
    class Machines
    {
        private static string connectionString = "Server=; Database=; User Id=; Password=;";
        public void GetAllMachines()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("", con);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd1.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string machineID = reader["machineID"].ToString();
                            string location = reader["location"].ToString();
                            Console.WriteLine($"{machineID} {location}");
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS" + e.Message);
                }
            }
    }
}
