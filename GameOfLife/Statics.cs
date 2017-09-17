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
        internal static void GetBoxSize(GameOfLife gol, Control display, out int sizeX, out int sizeY)
        {
            // get size of individual boxes, make it square always
            float reference = Math.Min(display.Width, display.Height);
            sizeX = (int)Math.Floor(reference / gol.Size);
            sizeY = sizeX;
        }

        /// <summary>
        /// checks whether the complete environment is dead/empty
        /// </summary>
        /// <param name="gol"></param>
        /// <returns></returns>
        internal static bool EnvirEmpty(GameOfLife gol)
        {
            bool[,] envir = gol.Envir;
            for (int i = 0; i < gol.Size; i++)
            {
                for (int j = 0; j < gol.Size; j++)
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
