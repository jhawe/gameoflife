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
        #region GetBoxSize
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
            sizeX = (int)Math.Floor(reference / gol.SizeX);
            sizeY = (int)Math.Floor(reference / gol.SizeY);
        }
        #endregion // GetBoxSize

        #region EnvirEmpty
        /// <summary>
        /// checks whether the complete environment is dead/empty
        /// </summary>
        /// <param name="gol"></param>
        /// <returns></returns>
        internal static bool EnvirEmpty(GameOfLife gol)
        {
            bool[,] envir = gol.Envir;
            for (int i = 0; i < gol.SizeX; i++)
            {
                for (int j = 0; j < gol.SizeY; j++)
                {
                    if (envir[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion // EnvirEmpty

        #region GetFieldFromDisplayPos
        /// <summary>
        /// Gets the GOl field according to the display /client position
        /// </summary>
        /// <param name="x">client x position</param>
        /// <param name="y">client y position</param>
        /// <param name="gol">The game of life instance</param>
        /// <param name="display">The display instance</param>
        /// <param name="x1">The result x coordinate</param>
        /// <param name="y1">The result y coordinate</param>
        internal static void GetFieldFromDisplayPos(int x, int y, GameOfLife gol, Control display, out int x1, out int y1)
        {
            // get size of individual boxes            
            Statics.GetBoxSize(gol, display, out x1, out y1);
            x1 = (int)Math.Floor(x * 1.0 / x1);
            y1 = (int)Math.Floor(y * 1.0 / y1);
        }
        #endregion //GetFieldFromDisplayPos
    }
}
