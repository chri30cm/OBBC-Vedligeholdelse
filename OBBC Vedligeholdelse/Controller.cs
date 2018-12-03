using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    public class Controller
    {
        Machines machine = new Machines();
        public void ShowMachines(int area)
        {
            switch (area)
            {
                case 1:
                    Console.Clear();
                    machine.GetAllMachines();
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    machine.GetSpecificMachines("Bryst");
                    Console.ReadLine();
                    break;                
                case 3:
                    Console.Clear();
                    machine.GetSpecificMachines("Ryg");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.Clear();
                    machine.GetSpecificMachines("Mave");
                    Console.ReadLine();
                    break;
                case 5:
                    Console.Clear();
                    machine.GetSpecificMachines("");
                    Console.ReadLine();
                    break;
                case 6:
                    Console.Clear();
                    machine.GetSpecificMachines("Ben");
                    Console.ReadLine();
                    break;
                case 7:
                    Console.Clear();
                    machine.GetSpecificMachines("Arme");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Du skal lige vælge et rigtigt tal, bror.");
                    break;
            }

        }
    }
}
