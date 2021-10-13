using System;
using System.Windows.Forms;

namespace Communicating_Vessels
{
    internal static class Main_Code
    {
        internal static Main_Window main_window;
        internal static Add_Liquid add_Liquid;
        
        [MTAThread]

        internal static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_Window());
        }
    }
}