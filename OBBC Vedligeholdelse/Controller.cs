using System;
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
                    machine.GetAllMachines();
                    break;
                case 2:
                    machine.GetChestMachines();
                    break;                
                case 3:
                    machine.Get
                    break;
                default:
                    break;
            }

        }
    }
}
