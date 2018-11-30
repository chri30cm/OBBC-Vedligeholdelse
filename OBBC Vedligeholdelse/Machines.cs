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
        private static string connectionString = "Server=EALSQL1.eal.local; Database= C_DB01_2018; User Id= C_STUDENT01; Password= C_OPENDB01";
        public void GetAllMachines()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("ShowMachines", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    
                    SqlDataReader reader = cmd1.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string machineID = reader["MaskineID"].ToString();
                            string location = reader["MaskineOmråde"].ToString();
                            string log = reader["LogID"].ToString();
                            string note = reader["Note"].ToString();
                            Console.WriteLine($"MaskineID: {machineID}, Lokation: {location}, Log: {log}, Note:  {note}");
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
}
