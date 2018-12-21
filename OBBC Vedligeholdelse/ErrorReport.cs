using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    public class ErrorReport
    {
        List<ErrorReport> errorReportList = new List<ErrorReport>();
        private int errorReport;
        public int ErrorReportID
        {
            get
            {
                return errorReport;
            }
            set
            {
                errorReport = value;
            }
        }

        public ErrorReport(int errorReport)
        {
            this.errorReport = errorReport;
        }
        public ErrorReport() { }

        public void AddReport(ErrorReport errorReport)
        {
            errorReportList.Add(errorReport);
        }

        public void ShowErrorReports()
        {
            foreach(ErrorReport report in errorReportList)
            {
                Console.WriteLine(report.ToString());
            }
        }
    }
}
