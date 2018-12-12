﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OBBC_Vedligeholdelse
{
    public class Menu
    {
        Controller control = new Controller();
        private const string startMenu = @"..\..\StartMenu.txt";
        private const string firstMenu = @"..\..\StartMenu.txt";


        public void Show()
        {
            bool running = true;
            do
            {
                ShowSelectedMenu(startMenu);
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

        private void ShowSelectedMenu(string selectedMenu)
            
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
            Console.Clear();
           string date = CurrentOrManual();
            
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
            string result = null;
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("vil du manuelt skrive dato, eller vælge nuværende tidspunkt?");
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
                        result = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
                        running = false;
                }
                else
                {
                    Console.WriteLine("hov hov du, ");
                }
            }
            return result;
        }
    }
}
