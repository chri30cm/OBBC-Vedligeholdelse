using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OBBC_Vedligeholdelse
{
    public class Menu
    {
        DatabaseController databaseController = new DatabaseController();
        Controller control = new Controller();
        private const string startMenu = @"..\..\StartMenu.txt";
        private const string firstMenu = @"..\..\FirstMenu.txt";
        private const string secondMenu = @"..\..\SecondMenu.txt";
        private const string thirdMenu = @"..\..\ThirdMenu.txt";
        private const string fourthMenu = @"..\..\FourthMenu.txt";
        private const string fifthMenu = @"..\..\FifthMenu.txt";
        public void Show()
        { 
            bool running = true;
            do
            {
                try
                {
                    ShowSelectedMenu(startMenu);
                    string choice = GetUserChoice();
                    Console.Clear();
                    switch (choice)
                    {
                        case "0":
                            running = false;
                            break;
                        case "1":
                            ShowCurrentReports();
                            break;
                        case "2":
                            CreateNewReport();
                            break;
                        case "3":
                            ChangeStatus();
                            break;
                        case "4":
                            ShowOldReports();
                            break;
                        case "5":
                            ShowExtraInfoReports();
                            break;
                        case "6":
                            databaseController.ReadAndShowErrorReports(); // test
                            Console.ReadLine();
                            break;
                        case "7":
                            databaseController.ReadOnlyAllErrorReports(); // test
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Ugyldigt valg, prøv venligst igen.");
                            Console.ReadLine();
                            break;
                    }
                    Console.Clear();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }    
            }
            while (running);
        }

        private void ShowExtraInfoReports()
        {
            int areaChoice;
            do
            {
                ShowSelectedMenu(fifthMenu);
                if (int.TryParse(Console.ReadLine(), out areaChoice) == false)
                {
                    areaChoice = -1;
                }
            }
            while (control.ShowExtraInfoReports(areaChoice) == false);
        }

        private void ShowOldReports()
        {
            int areaChoice;
            do
            {
                ShowSelectedMenu(fourthMenu);
                if (int.TryParse(Console.ReadLine(), out areaChoice) == false)
                {
                    areaChoice = -1;
                }
            }
            while (control.ShowOldReports(areaChoice) == false);
        }
        public void ShowCurrentReports()
        {
           int areaChoice;
           do
            {
                ShowSelectedMenu(firstMenu);
                if (int.TryParse(Console.ReadLine(), out areaChoice) == false)
                {
                    areaChoice = -1;
                }
            }
            while (control.ShowCurrentReports(areaChoice) == false);
        }
        public void ChangeStatus()
        {
            int reportID;
            int statusChoice;
            do
            {
                Console.WriteLine("Indtast Rapport ID: ");
                int.TryParse(Console.ReadLine(), out reportID);
                Console.Clear();
                ShowSelectedMenu(thirdMenu);
                if (!int.TryParse(Console.ReadLine(), out statusChoice))
                {
                    statusChoice = -1;
                }
            }
            while (!control.ChangeStatus(statusChoice, reportID));
        }
        public void CreateNewReport()
        {
            int areaChoice;
            string errorReport = null;
            string date = null;
            string extraInfo = null;
            do
            {
                ShowSelectedMenu(secondMenu);
                if (!int.TryParse(Console.ReadLine(), out areaChoice))
                {
                    areaChoice = -1;
                }
                if (areaChoice != -1)
                {
                    Console.Clear();
                    Console.WriteLine("Beskriv Problemet med Maskinen");
                    errorReport = Console.ReadLine();
                    Console.Clear();
                    date = CurrentOrManual();
                    Console.Clear();
                    Console.WriteLine($"Har du Extra information af tilføje? \nHvis ingen Extra information, tryk blot enter. ");
                    Console.WriteLine();
                    Console.WriteLine(": " + (extraInfo = Console.ReadLine()));
                }
            }
            while (!control.CreateNewReport(areaChoice, errorReport, date, extraInfo));
        }
        public void ShowSelectedMenu(string selectedMenu)
        {
            try
            {
                using (StreamReader sr = new StreamReader(selectedMenu))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Filen kunne ikke læses");
                Console.WriteLine(e.Message);
            }
        }
        private string GetUserChoice()
        {
            Console.WriteLine();
            Console.Write("Indtast dit valg: ");
            return Console.ReadLine();
        }
        private string CreateDate()
        {
            Console.WriteLine("Indtast dag (f.eks 25)");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast måned (f.eks 12)");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast år (f.eks 2018)");
            int year = int.Parse(Console.ReadLine());
          
            string date = $"{day}-{month}-{year}";
            return date;
        }
        private string CurrentOrManual()
        {
            string result = null;
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Vil du manuelt skrive dato, eller vælge nuværende tidspunkt?");
                Console.WriteLine("1: Manuelt");
                Console.WriteLine("2: Nuværende tidspunkt");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                        result = CreateDate();
                        running = false;
                }
                else if (choice == 2)
                {
                        result = DateTime.Now.ToString("yyyy-MM-dd H:mm");
                        running = false;
                }
                else
                {
                    Console.WriteLine("Forkert input ");
                }
            }
            return result;
        }
    }
}
