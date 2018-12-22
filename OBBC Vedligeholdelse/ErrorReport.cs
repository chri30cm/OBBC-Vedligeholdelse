using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    public class ErrorReport
    {
        private int reportID;
        public int ReportID
        {
            get
            {
                return reportID;
            }
            set
            {
                reportID = value;
            }
        }

        public ErrorReport(int reportID)
        {
            this.reportID = reportID;
        }
    }
}
