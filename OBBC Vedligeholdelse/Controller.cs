using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    class Controller
    {
        Machine machine = new Machine();
        public void CheckMachine()
        {
            machine.GetAllMachines();
        }
    }
}
