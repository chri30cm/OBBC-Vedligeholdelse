using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    class ReportFactory
    {
        List<ErrorReport> errorReports = new List<ErrorReport>();
        public void AddReport(ErrorReport errorReport)
        {
            errorReports.Add(errorReport);
        }

        public void ShowErrorReports()
        {
            foreach (ErrorReport report in errorReports)
            {
                if(report.Status == "Gul")
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
                }
                else if(report.Status == "Rød")
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
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
