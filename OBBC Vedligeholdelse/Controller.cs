using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    public class Controller
    {
        ErrorReports reports = new ErrorReports();
        public void ShowCurrentReports(int areaChoice)
        {
            switch (areaChoice)
            {
                case 1:
                    Console.Clear();
                    reports.GetAllCurrentReports();
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    reports.GetSpecificCurrentReports("Bryst");
                    Console.ReadLine();
                    Console.Clear();
                    break;                
                case 3:
                    Console.Clear();
                    reports.GetSpecificCurrentReports("Ryg");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    reports.GetSpecificCurrentReports("Mave");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    reports.GetSpecificCurrentReports("Spinning");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 6:
                    Console.Clear();
                    reports.GetSpecificCurrentReports("Ben");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 7:
                    Console.Clear();
                    reports.GetSpecificCurrentReports("Arme");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Du skal lige vælge et rigtigt tal, bror.");
                    break;
            }

        }
        public void ChangeStatus(int statusChoice, int reportID)
        {
            switch (statusChoice)
            {
                case 1:
                    Console.Clear();
                    reports.ChangeReportStatus(reportID, "Grøn");
                    Console.WriteLine("works");
                    break;
                case 2:
                    Console.Clear();
                    reports.ChangeReportStatus(reportID, "Gul");
                    Console.WriteLine("works");
                    break;
                case 3:
                    Console.Clear();
                    reports.ChangeReportStatus(reportID, "Rød");
                    Console.WriteLine("works");
                    break;
                default:
                    Console.WriteLine("Du skal lige vælge et rigtigt tal, bror.");
                    break;
            }
        }
    }
}
