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
        public string Location
        {
            get;
            set;
        }
        public string ErrorDescription
        {
            get;
            set;
        }
        public string Time
        {
            get;
            set;
        }
        public string ExtraInfo
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }

        public ErrorReport(int reportID, string location, string errorDescription, string time, string extraInfo, string status)
        {
            this.reportID = reportID;
            Location = location;
            ErrorDescription = errorDescription;
            Time = time;
            ExtraInfo = extraInfo;
            Status = status;
        }
        public ErrorReport(int reportID, string location, string errorDescription, string time, string status)
        {
            this.reportID = reportID;
            Location = location;
            ErrorDescription = errorDescription;
            Time = time;
            Status = status;
        }
    }
}
