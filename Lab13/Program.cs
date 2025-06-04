using System;
using System.Windows.Forms;

namespace MyWinApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize(); // якщо .NET 6+
            Application.Run(new MainForm());
        }
    }
}
