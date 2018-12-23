using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    // JULEMANDENS GAVER <3
    // JULEMANDENS GAVER <3
    // JULEMANDENS GAVER <3

    class ReportFactory
    {
        List<ErrorReport> errorReports = new List<ErrorReport>();
        public void AddReport(ErrorReport errorReport)
        {
            errorReports.Add(errorReport);
        }
        public void ShowSpecificErrorReports(string area)
        {
            if (errorReports.Count != 0)
            {
                foreach (ErrorReport report in errorReports)
                {
                    if (report.Location == area)
                    {
                        if (report.Status == "Gul")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("[------------------------------------]");
                            Console.WriteLine("    Fejlrapport ID: " + report.ReportID.ToString());
                            Console.WriteLine("    Maskine lokation: " + report.Location);
                            Console.WriteLine("    Problembeskrivelse: " + report.ErrorDescription);
                            Console.WriteLine("    Tidspunkt: " + report.Time);
                            if (report.ExtraInfo != null)
                            {
                                Console.WriteLine("    Extra information: " + report.ExtraInfo);
                            }
                            Console.WriteLine("[------------------------------------]");
                        }
                        else if (report.Status == "Rød")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("[------------------------------------]");
                            Console.WriteLine("    Fejlrapport ID: " + report.ReportID.ToString());
                            Console.WriteLine("    Maskine lokation: " + report.Location);
                            Console.WriteLine("    Problembeskrivelse: " + report.ErrorDescription);
                            Console.WriteLine("    Tidspunkt: " + report.Time);
                            if (report.ExtraInfo != null)
                            {
                                Console.WriteLine("    Extra information: " + report.ExtraInfo);
                            }
                            Console.WriteLine("[------------------------------------]");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Der findes ingen rapport med den valgte lokation");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else
            {
                Console.WriteLine("listen er tom :'( PepeHands");
            }
        }

        public void ShowAllCurrentErrorReports()
        {
            if(errorReports.Count != 0)
            {
                foreach (ErrorReport report in errorReports)
                {

                    if (report.Status == "Gul")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("[------------------------------------]");
                        Console.WriteLine("    Fejlrapport ID: " + report.ReportID.ToString());
                        Console.WriteLine("    Maskine lokation: " + report.Location);
                        Console.WriteLine("    Problembeskrivelse: " + report.ErrorDescription);
                        Console.WriteLine("    Tidspunkt: " + report.Time);
                        if (report.ExtraInfo != null)
                        {
                            Console.WriteLine("    Extra information: " + report.ExtraInfo);
                        }
                        Console.WriteLine("[------------------------------------]");
                    }
                    else if (report.Status == "Rød")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[------------------------------------]");
                        Console.WriteLine("    Fejlrapport ID: " + report.ReportID.ToString());
                        Console.WriteLine("    Maskine lokation: " + report.Location);
                        Console.WriteLine("    Problembeskrivelse: " + report.ErrorDescription);
                        Console.WriteLine("    Tidspunkt: " + report.Time);
                        if (report.ExtraInfo != null)
                        {
                            Console.WriteLine("    Extra information: " + report.ExtraInfo);
                        }
                        Console.WriteLine("[------------------------------------]");
                    }
                }
            }
            else
            {
                Console.WriteLine("listen er tom :'( PepeHands");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        public List<ErrorReport> GetErrorReports ()
        {
            return errorReports;
        }
    }
}
