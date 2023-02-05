using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThemeParkTycoonGame
{
    /*
     * I got all the icons from icons8
     * 
     * I used the 'color' icon-set, which has a lot more icons. Just change 'amusement' in the URL below to search for something:
     * 
     * https://icons8.com/icon/set/amusement/color
     * 
     * For example: https://icons8.com/icon/set/ice-cream/color
     */
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
            Application.Run(new UI.ManagerForm());
        }
    }
}
