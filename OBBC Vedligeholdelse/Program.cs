using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse
{
    public class Program
    {
        DatabaseController database = new DatabaseController();
        private static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }
        private void Run()
        {
            database.ReadOnlyAllErrorReports();
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
