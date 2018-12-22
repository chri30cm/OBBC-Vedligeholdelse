using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    public class ErrorReport
    {
        public int ErrorReportID
        {
            get;
            set;
        }

        public ErrorReport(int reportID)
        {
            ErrorReportID = reportID;
        }
    }
}
