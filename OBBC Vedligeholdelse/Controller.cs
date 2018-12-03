﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    class Controller
    {
        Machines machine = new Machines();
        public void CheckMachine(int områdeValg)
        {
            switch (områdeValg)
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
                default:
                    break;
            }

        }
    }
}
