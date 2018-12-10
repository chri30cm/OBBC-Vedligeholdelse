using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OBBC_Vedligeholdelse 
{
    public class ErrorReports
    {
        private const string connectionString = "Server=EALSQL1.eal.local; Database= CANE; User Id= C_STUDENT01; Password= C_OPENDB01";
        public void GetAllCurrentReports()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("VisAlleAktuelleFejlRapporter", con);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    ReadandWrite(cmd1);
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS, " + e.Message);
                }
            }
        }

        public void GetSpecificCurrentReports(string area)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                {
                    try
                    {
                        con.Open();

                        SqlCommand cmd2 = new SqlCommand("VisSpecifikkeAktuelleFejlRapporter", con);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add(new SqlParameter("@Lokation", area));

                        ReadandWrite(cmd2);
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("UPS, " + e.Message);
                    }
                }
            }
        }

        public void ChangeReportStatus(int machineID, string status)
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
                    string rapportID = reader["RapportID"].ToString();
                    string lokation = reader["Lokation"].ToString();
                    string PB = reader["ProblemBeskrivelse"].ToString();
                    string tidspunkt = reader["Tidspunkt"].ToString();
                    string extraInfo = reader["ExtraInfo"].ToString();
                    Console.WriteLine($"RapportID: {rapportID} \nLokation: {lokation} \nProblembeskrivelse: {PB} \nTidspunkt:  {tidspunkt} \nExtra Info: {extraInfo}");
                    Console.WriteLine();
                }
            }
        }
    }
}
