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
                Console.WriteLine("Error Report ID: " + report.ErrorReportID.ToString());
                Console.WriteLine();
            }
        }

        public List<ErrorReport> GetErrorReports()
        {
            return errorReports;
        }
    }
}
