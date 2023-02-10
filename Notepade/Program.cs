using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepade
{
    static class Program
    {
        //Eng.Rasheed Adnan Al-Wahbany ^_^
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arr)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Form1());
           if(arr.Length>0)
                Application.Run(new trying(arr));
           else
                Application.Run(new trying());
        }
    }
}
