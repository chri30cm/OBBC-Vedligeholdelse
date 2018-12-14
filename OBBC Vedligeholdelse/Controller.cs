using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    public class Controller
    {
        DatabaseController databaseController = new DatabaseController();
        public void ShowCurrentReports(int areaChoice)
        {
            Console.Clear();
            switch (areaChoice)
            {
                case 1:
                    databaseController.GetAllCurrentReports();                    
                    break;
                case 2:
                    databaseController.GetSpecificCurrentReports("Bryst");
                    break;                
                case 3:
                    databaseController.GetSpecificCurrentReports("Ryg");
                    break;
                case 4:
                    databaseController.GetSpecificCurrentReports("Mave");
                    break;
                case 5:
                    databaseController.GetSpecificCurrentReports("Spinning");
                    break;
                case 6:
                    databaseController.GetSpecificCurrentReports("Ben");
                    break;
                case 7:                    
                    databaseController.GetSpecificCurrentReports("Arme");
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
                    databaseController.ChangeReportStatus(reportID, "Grøn");
                    break;
                case 2:
                    databaseController.ChangeReportStatus(reportID, "Gul");
                    break;
                case 3:
                    databaseController.ChangeReportStatus(reportID, "Rød");
                    break;
                default:
                    Console.WriteLine("Du skal lige vælge et rigtigt tal, bror.");
                    break;
            }
            Console.ReadLine();
        }
        public void CreateNewReport(int areaChoice, string errorReport, string date, string extraInfo)
        {
            Console.Clear();
            switch (areaChoice)
            {
                case 1:                   
                    databaseController.InsertReport("Bryst",errorReport,date,extraInfo);                   
                    break;
                case 2:                    
                    databaseController.InsertReport("Ryg", errorReport, date, extraInfo);                   
                    break;
                case 3:               
                    databaseController.InsertReport("Mave", errorReport, date, extraInfo);                    
                    break;
                case 4:                   
                    databaseController.InsertReport("Spinning", errorReport, date, extraInfo);                   
                    break;
                case 5:                    
                    databaseController.InsertReport("Ben", errorReport, date, extraInfo);                    
                    break;
                case 6:                    
                    databaseController.InsertReport("Arme", errorReport, date, extraInfo);                    
                    break;            
                default:
                    Console.WriteLine("Området ekstisterer ikke!" +
                        "   ");
                    break;
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
