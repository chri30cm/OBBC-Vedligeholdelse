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
            Console.WriteLine("hej");
            foreach (ErrorReport report in errorReports)
            {
                Console.WriteLine("shit det godt");
                Console.WriteLine(report.ErrorReportID.ToString());
            }
            Console.WriteLine("haj");
        }

        public List<ErrorReport> GetErrorReports()
        {
            return errorReports;
        }
    }
}
