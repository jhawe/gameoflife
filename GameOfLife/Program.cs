using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // create game of life
            GameOfLife gol = new GameOfLife(5);

            // test implementation
            Console.WriteLine(gol.ToString());
            gol.Update(3);
            Console.WriteLine(gol.ToString());


            Application.Run(new MainForm());
        }
    }
}
