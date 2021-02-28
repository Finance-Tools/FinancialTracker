using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialTracker
{
    class MainConsole
    {
        [STAThread]
        public static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                Console.WriteLine("Hello From Console");
            }
            else
            {
                Console.WriteLine("Hello From GUI");
                RunApplication();
            }
        }


        private static void RunApplication()
        {
            var application = new App();
            application.InitializeComponent();
            application.Run();
        }
    }
}
