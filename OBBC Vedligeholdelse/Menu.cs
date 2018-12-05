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
                        ShowMachines();
                        break;
                    case "2":
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
            Console.WriteLine("1. Vis Maskiner");
            Console.WriteLine("2. Ændre status på maskiner");
            Console.WriteLine("3.Maskine Mangler Del");
            Console.WriteLine("4. Tilføj Maskine");
            Console.WriteLine("5. Fjern Maskine");
            Console.WriteLine("6. Find Specifik Maskine ");
            Console.WriteLine("0. Exit");
            Console.WriteLine("----------------------------------");
        }

        private string GetUserChoice()
        {
            Console.WriteLine();
            Console.Write("Indtast dit valg: ");
            return Console.ReadLine();
        }

        public void ShowMachines()
        {
            Console.WriteLine("------------Vælg Område-----------");
            Console.WriteLine("1. Vis alle maskiner");
            Console.WriteLine("2. Vis Bryst maskiner");
            Console.WriteLine("3. Vis Ryg maskiner");
            Console.WriteLine("4. Vis Mave maskiner");
            Console.WriteLine("5. Vis Spinningsmaskiner");
            Console.WriteLine("6.-");
            int input = int.Parse(Console.ReadLine());
            control.ShowMachines(input);
        }

        public void ChangeStatus()
        {
            Console.WriteLine("MaskinID: ");
            int machineID = int.Parse(Console.ReadLine());
            Console.WriteLine("vælg ændring på maskine");
            Console.WriteLine("1. Maskine repareret");
            Console.WriteLine("2. Maskine er i gang med at blive ordnet");
            Console.WriteLine("3. Maskine er gået i stykker");
            int input = int.Parse(Console.ReadLine());
            control.ChangeStatus(input, machineID);
        }
    }
}
