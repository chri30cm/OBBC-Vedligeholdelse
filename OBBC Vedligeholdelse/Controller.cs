using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    public class Controller
    {
        ErrorReports report = new ErrorReports();
        public void ShowCurrentReports(int areaChoice)
        {
            Console.Clear();
            switch (areaChoice)
            {
                case 1:
                    report.GetAllCurrentReports();                    
                    break;
                case 2:
                    report.GetSpecificCurrentReports("Bryst");
                    break;                
                case 3:
                    report.GetSpecificCurrentReports("Ryg");
                    break;
                case 4:
                    report.GetSpecificCurrentReports("Mave");
                    break;
                case 5:
                    report.GetSpecificCurrentReports("Spinning");
                    break;
                case 6:
                    report.GetSpecificCurrentReports("Ben");
                    break;
                case 7:                    
                    report.GetSpecificCurrentReports("Arme");
                    break;
                default:
                    Console.WriteLine("Du skal lige vælge et rigtigt tal, bror.");
                    break;
            }
            Console.ReadLine();
            Console.Clear();

        }
        public void ChangeStatus(int statusChoice, int reportID)
        {
            Console.Clear();
            switch (statusChoice)
            {
                case 1:
                    report.ChangeReportStatus(reportID, "Grøn");
                    break;
                case 2:
                    report.ChangeReportStatus(reportID, "Gul");
                    break;
                case 3:
                    report.ChangeReportStatus(reportID, "Rød");
                    break;
                default:
                    Console.WriteLine("Du skal lige vælge et rigtigt tal, bror.");
                    break;
            }
        }

        public void CreateNewReport(int areaChoice, string errorReport, string date, string extraInfo)
        {
            Console.Clear();
            switch (areaChoice)
            {
                case 1:                   
                    report.InsertReport("Bryst",errorReport,date,extraInfo);                   
                    break;
                case 2:                    
                    report.InsertReport("Ryg", errorReport, date, extraInfo);                   
                    break;
                case 3:               
                    report.InsertReport("Mave", errorReport, date, extraInfo);                    
                    break;
                case 4:                   
                    report.InsertReport("Spinning", errorReport, date, extraInfo);                   
                    break;
                case 5:                    
                    report.InsertReport("Ben", errorReport, date, extraInfo);                    
                    break;
                case 6:                    
                    report.InsertReport("Arme", errorReport, date, extraInfo);                    
                    break;            
                default:
                    Console.WriteLine("Du skal lige vælge et rigtigt tal, bror.");
                    break;
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
