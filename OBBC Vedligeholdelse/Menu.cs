using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    class Menu
    {
        Controller controller = new Controller();
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
                        CheckMachine();
                        break;
                    //case "2":    --- Flere funktioner...
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

        public void CheckMachine()
        {
            Console.WriteLine("------------Vælg Område-----------");
            Console.WriteLine("1. Vis alle maskiner");
            Console.WriteLine("2. Vis Bryst maskiner");
            Console.WriteLine("-");
            Console.WriteLine("-");
            int input = int.Parse(Console.ReadLine());
            controller.CheckMachine(input);
        }
    }
}
