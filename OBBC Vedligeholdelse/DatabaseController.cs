﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace OBBC_Vedligeholdelse 
{
    public class DatabaseController
    {
        public void GetAllCurrentReports()
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
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
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
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
        public void ChangeReportStatus(int reportID, string status)
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("ÆndreStatus", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@RapportID", reportID));
                        cmd.Parameters.Add(new SqlParameter("@Status", status));
                        cmd.ExecuteReader();
                        Console.WriteLine("success");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("fejl, " + e.Message);
                    }
                }
            }
        }
        public void InsertReport(string area,string errorReport, string date,string extraInfo)
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
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
        private void DatabaseReader(SqlCommand cmd)
        {
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    
                    string reportID = reader["RapportID"].ToString();
                    string location = reader["Lokation"].ToString();
                    string PB = reader["ProblemBeskrivelse"].ToString();
                    string time = reader["Tidspunkt"].ToString();
                    string extraInfo = reader["ExtraInfo"].ToString();
                    string status = reader["Status"].ToString();
                    if (status == "Gul")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(DataWriter(reportID, location, PB, time, extraInfo));
                        Console.WriteLine();
                    }
                    else if (status == "Rød")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(DataWriter(reportID, location, PB, time, extraInfo));
                        Console.WriteLine();
                    }
                   
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void DatabaseReaderGreen(SqlCommand cmd)
        {
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string reportID = reader["RapportID"].ToString();
                    string location = reader["Lokation"].ToString();
                    string PB = reader["ProblemBeskrivelse"].ToString();
                    string time = reader["Tidspunkt"].ToString();
                    string extraInfo = reader["ExtraInfo"].ToString();
                    string status = reader["Status"].ToString();
                    if (status == "Grøn")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(DataWriter(reportID, location, PB, time, extraInfo));
                        Console.WriteLine();
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public string DynamicConnectionString()
        {
            string _connectionString = null;
            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\DatabaseAccess.txt"))
                {
                    string line;
                    string[] connectionArray;
                    string server;
                    string database;
                    string userId;
                    string password;
                    while ((line = sr.ReadLine()) != null)
                    {
                        connectionArray = line.Split(':');
                        server = connectionArray[0].ToString();
                        database = connectionArray[1].ToString();
                        userId = connectionArray[2].ToString();
                        password = connectionArray[3].ToString();
                        _connectionString = $"Server={server}; Database= {database}; User Id= {userId}; Password= {password}";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Filen kunne ikke læses");
                Console.WriteLine(e.Message);
            }
            return _connectionString;
        }
        internal void GetSpecificExtraInfoReports(string area)
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("VisSpecifikkeMedExtraNote", con);
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

        internal void GetAllExtraInfoReports()
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("VisAlleMedExtraNote", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseReader(cmd);
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS, " + e.Message);
                }
            }
        }
        public void GetSpecificOldReports(string area)
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("VisSpecifikkeRepareredeFejlRapporter", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Lokation", area));
                        DatabaseReaderGreen(cmd);

                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("UPS, " + e.Message);
                    }
                }
            }
        }

        public void GetAllOldReports()
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("VisAlleRepareredeFejlRapporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseReaderGreen(cmd);
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS, " + e.Message);
                }
            }
        }
        private string DataWriter(string reportID, string location, string PB, string time, string extraInfo)
        {
            return $"RapportID: {reportID} \nLokation: {location} \nProblembeskrivelse: {PB} \nTidspunkt:  {time} \nExtra Info: {extraInfo}";
        }
    }
}