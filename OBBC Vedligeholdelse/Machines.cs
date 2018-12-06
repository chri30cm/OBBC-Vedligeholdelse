using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OBBC_Vedligeholdelse
{
    public class Machines
    {
        private const string connectionString = "Server=EALSQL1.eal.local; Database= CANE; User Id= C_STUDENT01; Password= C_OPENDB01";
        public void GetAllMachines()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("ShowAllMachines", con);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    ReadandWrite(cmd1);
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS, " + e.Message);
                }
            }
        }

        public void GetSpecificMachines(string machineType)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                {
                    try
                    {
                        con.Open();

                        SqlCommand cmd2 = new SqlCommand("ShowSpecificMachines", con);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add(new SqlParameter("@MaskineOmråde", machineType));

                        ReadandWrite(cmd2);
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("UPS, " + e.Message);
                    }
                }
            }
        }

        public void ChangeMachineStatus(int machineID, string status)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                {
                    try
                    {
                        con.Open();

                        SqlCommand cmd2 = new SqlCommand("ChangeStatus", con);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add(new SqlParameter("@MaskineID", machineID));
                        cmd2.Parameters.Add(new SqlParameter("@Status", status));
                        Console.WriteLine("still");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("UPS, " + e.Message);
                    }
                }
            }
        }

        private void ReadandWrite(SqlCommand cmd)
        {
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string machineID = reader["MaskineID"].ToString();
                    string location = reader["MaskineOmråde"].ToString();
                    string log = reader["LogID"].ToString();
                    string note = reader["Note"].ToString();
                    //string status = reader["Status"].ToString();
                    Console.WriteLine($"MaskineID: {machineID}, Lokation: {location}, Log: {log}, Note:  {note}");
                }
            }
        }
    }
}
