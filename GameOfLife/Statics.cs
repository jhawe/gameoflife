using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    internal class Statics
    {
        /// <summary>
        /// gets the box size for individual cells given the currnet
        /// GoL instane and the display on which it should be drawn
        /// </summary>
        /// <param name="gol"></param>
        /// <param name="display"></param>
        /// <returns></returns>
        internal static int GetBoxSize(GameOfLife gol, Control display)
        {
            // get size of individual boxes
            int rsize = (int)Math.Min(display.Height, display.Width);
            rsize /= gol.Size;
            return (rsize);
        }

        /// <summary>
        /// checks whether the complete environment is dead/empty
        /// </summary>
        /// <param name="gol"></param>
        /// <returns></returns>
        internal static bool EnvirEmpty(GameOfLife gol)
        {
            bool[,] envir = gol.Envir;
            for(int i = 0; i < gol.Size; i++)
            {
                for(int j = 0;j<gol.Size; j++)
                {
                    if (envir[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
