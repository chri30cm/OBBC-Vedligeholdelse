﻿using System;
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
            switch (areaChoice)
            {
                case 1:
                    Console.Clear();
                    report.GetAllCurrentReports();
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    report.GetSpecificCurrentReports("Bryst");
                    Console.ReadLine();
                    Console.Clear();
                    break;                
                case 3:
                    Console.Clear();
                    report.GetSpecificCurrentReports("Ryg");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    report.GetSpecificCurrentReports("Mave");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    report.GetSpecificCurrentReports("Spinning");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 6:
                    Console.Clear();
                    report.GetSpecificCurrentReports("Ben");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 7:
                    Console.Clear();
                    report.GetSpecificCurrentReports("Arme");
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
                    report.ChangeReportStatus(reportID, "Grøn");
                    Console.WriteLine("works");
                    break;
                case 2:
                    Console.Clear();
                    report.ChangeReportStatus(reportID, "Gul");
                    Console.WriteLine("works");
                    break;
                case 3:
                    Console.Clear();
                    report.ChangeReportStatus(reportID, "Rød");
                    Console.WriteLine("works");
                    break;
                default:
                    Console.WriteLine("Du skal lige vælge et rigtigt tal, bror.");
                    break;
            }
        }
    }
}
