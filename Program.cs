using System;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp5
{
    

    public static class Program
    {    
        [STAThread]
        static void Main()
        {
            StreamWriter us = new StreamWriter("Active.txt", false);
            us.Close();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Application.Run(new MainForm());
        }
    }
}
