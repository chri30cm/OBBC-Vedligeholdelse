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
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    machine.GetSpecificMachines("Bryst");
                    Console.ReadLine();
                    Console.Clear();
                    break;                
                case 3:
                    Console.Clear();
                    machine.GetSpecificMachines("Ryg");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    machine.GetSpecificMachines("Mave");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    machine.GetSpecificMachines("Spinning");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 6:
                    Console.Clear();
                    machine.GetSpecificMachines("Ben");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 7:
                    Console.Clear();
                    machine.GetSpecificMachines("Arme");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Du skal lige vælge et rigtigt tal, bror.");
                    break;
            }

        }
        public void ChangeStatus(int statusChoice, int machineID)
        {
            switch (statusChoice)
            {
                case 1:
                    Console.Clear();
                    machine.ChangeMachineStatus(machineID, "Grøn");
                    Console.WriteLine("works");
                    break;
                case 2:
                    Console.Clear();
                    machine.ChangeMachineStatus(machineID, "Gul");
                    Console.WriteLine("works");
                    break;
                case 3:
                    Console.Clear();
                    machine.ChangeMachineStatus(machineID, "Rød");
                    Console.WriteLine("works");
                    break;
                default:
                    Console.WriteLine("Du skal lige vælge et rigtigt tal, bror.");
                    break;
            }
        }
    }
}
