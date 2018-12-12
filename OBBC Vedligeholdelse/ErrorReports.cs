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
                    SqlCommand cmd = new SqlCommand("VisAlleAktuelleFejlRapporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseReader(cmd);
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
                        SqlCommand cmd = new SqlCommand("VisSpecifikkeAktuelleFejlRapporter", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Lokation", area));
                        DatabaseReader(cmd);
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
                        SqlCommand cmd = new SqlCommand("ChangeStatus", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@MaskineID", machineID));
                        cmd.Parameters.Add(new SqlParameter("@Status", status));
                        Console.WriteLine("success");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("fejl, " + e.Message);
                    }
                }
            }
        }

        private void DatabaseReader(SqlCommand cmd)
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
        public void InsertReport(string area,string errorReport, string date,string extraInfo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("InsertReport", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Lokation", area));
                        cmd.Parameters.Add(new SqlParameter("@ProblemBeskrivelse", errorReport));
                        cmd.Parameters.Add(new SqlParameter("@Tidspunkt", date));
                        cmd.Parameters.Add(new SqlParameter("@ExtraInfo", extraInfo));
                        DatabaseReader(cmd);
                        Console.WriteLine("success");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("UPS, " + e.Message);
                    }
                }
            }
        }
    }
}
