using System;
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
        string reportID;
        string location;
        string errorDescription;
        string time;
        string extraInfo;
        string status;
        int iReportID;
        private const string errorReportsPath = @"..\..\ErrorReports.txt";
        SqlDataReader reader;
        SqlConnection con;
        SqlCommand cmd;
        ReportFactory reportFactory = new ReportFactory();
        
        public void GetAllCurrentReports()
        {
            using (con = new SqlConnection(DynamicConnectionString()))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("VisAlleAktuelleFejlRapporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseCurrentReportsWriter(cmd);
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS, " + e.Message);
                }
            }
        }




        public void GetSpecificCurrentReports(string area)
        {
            using (con = new SqlConnection(DynamicConnectionString()))
            {
                {
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand("VisSpecifikkeAktuelleFejlRapporter", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Lokation", area));
                        DatabaseCurrentReportsWriter(cmd);
                       
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
            using (con = new SqlConnection(DynamicConnectionString()))
            {
                {
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand("ÆndreStatus", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@RapportID", reportID));
                        cmd.Parameters.Add(new SqlParameter("@Status", status));
                        cmd.ExecuteReader();
                        Console.WriteLine("Rapporten fik ændret status");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Fejl, " + e.Message);
                    }
                }
            }
        }
        public void CreateReport(string area,string errorReport, string time,string extraInfo)
        {
            using (con = new SqlConnection(DynamicConnectionString()))
            {
                {
                    try
                    { 
                        con.Open();
                        cmd = new SqlCommand("InsertReport", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Lokation", area));
                        cmd.Parameters.Add(new SqlParameter("@ProblemBeskrivelse", errorReport));
                        cmd.Parameters.Add(new SqlParameter("@Tidspunkt", time));
                        cmd.Parameters.Add(new SqlParameter("@ExtraInfo", extraInfo));
                        DatabaseReader(cmd);
                        Console.WriteLine("Rapporten blev oprettet!");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("UPS, " + e.Message);
                    }
                }
            }
        }

        public void GetSpecificExtraInfoReports(string area)
        {
            using (con = new SqlConnection(DynamicConnectionString()))
            {
                {
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand("VisSpecifikkeMedExtraNote", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Lokation", area));
                        DatabaseCurrentReportsWriter(cmd);

                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("UPS, " + e.Message);
                    }
                }
            }
        }

        public void GetAllExtraInfoReports()
        {
            using (con = new SqlConnection(DynamicConnectionString()))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("VisAlleMedExtraNote", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseCurrentReportsWriter(cmd);
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS, " + e.Message);
                }
            }
        }
        public void GetSpecificOldReports(string area)
        {
            using (con = new SqlConnection(DynamicConnectionString()))
            {
                {
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand("VisSpecifikkeRepareredeFejlRapporter", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Lokation", area));
                        DatabaseOldReportsWriter(cmd);

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
            using (con = new SqlConnection(DynamicConnectionString()))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("VisAlleRepareredeFejlRapporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseOldReportsWriter(cmd);
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS, " + e.Message);
                }
            }
        }
        private string DynamicConnectionString()
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

        private void DatabaseCurrentReportsWriter(SqlCommand cmd)
        {
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    reportID = reader["RapportID"].ToString();
                    location = reader["Lokation"].ToString();
                    errorDescription = reader["ProblemBeskrivelse"].ToString();
                    time = reader["Tidspunkt"].ToString();
                    extraInfo = reader["ExtraInfo"].ToString();
                    status = reader["Status"].ToString();
                    if (status == "Gul")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"RapportID: {reportID} \nLokation: {location} \nProblembeskrivelse: {errorDescription} \nTidspunkt:  {time} \nExtra Info: {extraInfo}");
                        Console.WriteLine();
                    }
                    else if (status == "Rød")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"RapportID: {reportID} \nLokation: {location} \nProblembeskrivelse: {errorDescription} \nTidspunkt:  {time} \nExtra Info: {extraInfo}");
                        Console.WriteLine();
                    }
                    else if (status == "Grøn" == true)
                    {

                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void DatabaseOldReportsWriter(SqlCommand cmd)
        {
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    reportID = reader["RapportID"].ToString();
                    location = reader["Lokation"].ToString();
                    errorDescription = reader["ProblemBeskrivelse"].ToString();
                    time = reader["Tidspunkt"].ToString();
                    extraInfo = reader["ExtraInfo"].ToString();
                    status = reader["Status"].ToString();
                    if (status == "Grøn")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"RapportID: {reportID} \nLokation: {location} \nProblembeskrivelse: {errorDescription} \nTidspunkt:  {time} \nExtra Info: {extraInfo}");
                        Console.WriteLine();
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // JULEMANDENS GAVER <3
        // JULEMANDENS GAVER <3
        // JULEMANDENS GAVER <3 HERUNDER:

        public void ReadAndShowErrorReports()
        {
            using (con = new SqlConnection(DynamicConnectionString()))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("VisAlleAktuelleFejlRapporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseReader(cmd);
                    reportFactory.ShowAllCurrentErrorReports();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS, " + e.Message);
                }
            }
        }

        public void ReadOnlyAllErrorReports()
        {
            using (con = new SqlConnection(DynamicConnectionString()))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("VisAlleAktuelleFejlRapporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseReader(cmd);
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS, " + e.Message);
                }
            }
        }

        private void DatabaseReader(SqlCommand cmd)
        {
            reader = cmd.ExecuteReader();
            ErrorReport errorReport;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    reportID = reader["RapportID"].ToString();
                    location = reader["Lokation"].ToString();
                    errorDescription = reader["ProblemBeskrivelse"].ToString();
                    time = reader["Tidspunkt"].ToString();
                    extraInfo = reader["ExtraInfo"].ToString();
                    status = reader["Status"].ToString();
                    iReportID = int.Parse(reportID);

                    if (extraInfo != "")
                    {
                        errorReport = new ErrorReport(iReportID, location, errorDescription, time, extraInfo, status);
                        if(errorReport == null)
                        {
                            Console.WriteLine("errorReport findes ikke");
                        }
                        else
                        {
                            reportFactory.AddReport(errorReport);
                        }
                    }
                    else
                    {
                        errorReport = new ErrorReport(iReportID, location, errorDescription, time, status);
                        if (errorReport == null)
                        {
                            Console.WriteLine("errorReport findes ikke");
                        }
                        else
                        {
                            reportFactory.AddReport(errorReport);
                        }
                    }
                }
            }
            TextWriter();
        }

        private void TextWriter()
        {
            List<ErrorReport> errorReportList = reportFactory.GetErrorReports();
            using (StreamWriter streamWriter = new StreamWriter(errorReportsPath))
            {
                foreach (ErrorReport eReport in errorReportList)
                {
                    //if (!IsStringInFile(eReport.ReportID.ToString()))
                    //{
                        if (eReport.Status == "Gul")
                        {
                            streamWriter.WriteLine("Console.ForegroundColor = ConsoleColor.Yellow");
                        }
                        else if (eReport.Status == "Rød")
                        {
                            streamWriter.WriteLine("Console.ForegroundColor = ConsoleColor.Red");
                        }
                        streamWriter.WriteLine("[------------------------------------]");
                        streamWriter.WriteLine("    Fejlrapport ID: " + eReport.ReportID.ToString());
                        streamWriter.WriteLine("    Maskine lokation: " + eReport.Location);
                        streamWriter.WriteLine("    Problembeskrivelse: " + eReport.ErrorDescription);
                        streamWriter.WriteLine("    Tidspunkt: " + eReport.Time);
                        if (eReport.ExtraInfo != null)
                        {
                            streamWriter.WriteLine("    Extra information: " + eReport.ExtraInfo);
                        }
                        streamWriter.WriteLine("[------------------------------------]");
                    //}
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private bool IsStringInFile(string searchThis)
        {

            return File.ReadAllText(errorReportsPath).Contains(searchThis);

        }
    }
}
