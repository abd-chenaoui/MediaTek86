using System;
using System.Windows.Forms;
using MediaTek86.controleur;

namespace MediaTek86
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Controleur();
        }
    }
}
