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
            if(errorReports[0] == null)
            {
                Console.WriteLine("errorReports[] == null");
            }
            for (int i = 0; i < errorReports.Count; i++)
            {
                Console.WriteLine("hej");
                Console.WriteLine(errorReports[i].ErrorReportID.ToString());
            }
            Console.WriteLine("hej");
        }

        public List<ErrorReport> GetErrorReports()
        {
            return errorReports;
        }
    }
}
