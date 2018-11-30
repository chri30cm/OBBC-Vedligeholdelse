using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    class Controller
    {
        Machines machines = new Machines();
        public void CheckMachine()
        {
            machines.GetAllMachines();
        }
    }
}
