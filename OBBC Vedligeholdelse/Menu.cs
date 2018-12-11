using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    public class Menu
    {
        Controller control = new Controller();
        public void Show()
        {
            bool running = true;
            do
            {
                ShowMenu();
                string choice = GetUserChoice();
                switch (choice)
                {
                    case "0":
                        running = false;
                        break;
                    case "1":
                        Console.Clear();
                        ShowCurrentReports();
                        break;
                    case "2":
                        Console.Clear();
                        CreateNewReport();
                        break;
                    case "3":
                        Console.Clear();
                        ChangeStatus();
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg.");
                        Console.ReadLine();
                        break;
                }
            } while (running);
        }

        private void ShowMenu()
        {
            Console.WriteLine("-------Vedligeholdelse OBBC-------");
            Console.WriteLine();
            Console.WriteLine("1. Vis Aktuelle Fejl Rapporter");
            Console.WriteLine("2. Opret Fejlmelding");
            Console.WriteLine("3. Ændre på fejlstatus");
            Console.WriteLine("4. Maskine Mangler Del");
            Console.WriteLine("5. Find Specifik dato");
            Console.WriteLine("0. Exit");
            Console.WriteLine("----------------------------------");
        }

        private string GetUserChoice()
        {
            Console.WriteLine();
            Console.Write("Indtast dit valg: ");
            return Console.ReadLine();
        }

        public void ShowCurrentReports()
        {
            Console.WriteLine("------------Vælg Område-----------");
            Console.WriteLine("1. Vis alle aktuelle Rapporter");
            Console.WriteLine("2. Vis Bryst Rapporter");
            Console.WriteLine("3. Vis Ryg Rapporter");
            Console.WriteLine("4. Vis Mave Rapporter");
            Console.WriteLine("5. Vis Spinnings-Rapporter"); 
            Console.WriteLine("6. Vis Ben Rapporter");
            Console.WriteLine("7. Vis Arme Rapporter");
            int areaChoice = int.Parse(Console.ReadLine());
            control.ShowCurrentReports(areaChoice);
        }

        public void ChangeStatus()
        {
            Console.WriteLine("Indtast Rapport ID: ");
            int reportID = int.Parse(Console.ReadLine());
            Console.WriteLine("Vælg status for maskine");
            Console.WriteLine("1. Maskine repareret");
            Console.WriteLine("2. Maskine er i gang med at blive ordnet");
            Console.WriteLine("3. Maskine er gået i stykker");
            int statusChoice = int.Parse(Console.ReadLine());
            control.ChangeStatus(statusChoice, reportID);
        }

        public void CreateNewReport()
        {
            Console.WriteLine("------------Vælg Område-----------");
            Console.WriteLine("1. Bryst");
            Console.WriteLine("2. Ryg");
            Console.WriteLine("3. Mave");
            Console.WriteLine("4. Spinning");
            Console.WriteLine("5. Ben");
            Console.WriteLine("6. Arme");
            int areaChoice = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Beskriv Problemet med Maskinen");
            string errorReport = Console.ReadLine();
            CurrentOrManual();
            string date = CreateDate();
            Console.Clear();
            Console.WriteLine("Har du Extra information af tilføje?");
            string extraInfo = Console.ReadLine();
            control.CreateNewReport(areaChoice, errorReport, date, extraInfo);
        }

        private string CreateDate()
        {
            Console.WriteLine("indtast dag (f.eks 25)");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("indtast måned (f.eks 12)");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("indtast år (f.eks 2018)");
            int year = int.Parse(Console.ReadLine());
            string date = $"{day}-{month}-{year}";
            return date;
        }

        private string CurrentOrManual()
        {
            Console.WriteLine("vil du manuelt skrive dato, eller vælge nuværende tidspunkt?");
            Console.WriteLine("1: Manuelt");
            Console.WriteLine("2: Nuværende tidspunkt");
            int choice = int.Parse(Console.ReadLine());
            string result = null;
            bool running = true;
            while (running)
            {
                if (choice == 1)
                {
                    result = CreateDate();
                    running = false;
                }
                else if (choice == 2)
                {
                    result = "default";
                    running = false;
                }
                else
                {
                    throw new Exception("hov hov, du skal lige putte et ordenligt input, bror.");
                } 
            }
            return result;
        }
    }
}
