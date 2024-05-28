using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFA_Front
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new registerForm());
            //Application.Run(new Form1());
            Application.Run(new login());
            // Application.Run(new user());
            //Application.Run(new profile());
            //Application.Run(new course());
        }
    }
}
