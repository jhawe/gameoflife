using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class GameOfLife
    {
        #region Class Member
        /// <summary>
        /// class member definitions
        /// </summary>
        private bool[,] envir; // the current 'living environment'
        private bool[,] init; // always holds the initial field
        private int size;
        private const int ENVIR_SIZE = 6;
        #endregion // Class Member

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public GameOfLife(int size = ENVIR_SIZE) : this(null, size)
        {
            // member init
        }

        public GameOfLife(bool[,] init, int size = ENVIR_SIZE)
        {
            if (size < 5)
            {
                throw new Exception("Size has to be >= 5!");
            }

            // member init
            this.envir = init;
            this.init = init;
            this.size = size;
            if (this.envir == null)
            {
                RandomInit(size);
            }
        }
        #endregion // Constructor

        #region Properties
        internal bool[,] Envir
        {
            get
            {
                return this.envir;
            }
        }

        internal int Size
        {
            get
            {
                return this.size;
            }
        }
        #endregion // Properties

        #region Methods

        #region BlinkerInit
        /// <summary>
        /// Simple 'Blinker' init, placing three living cells
        /// right next to each other on init
        /// </summary>
        /// <param name="size">The size of the environment</param>
        internal void BlinkerInit(int size = ENVIR_SIZE)
        {
            bool[,] init = new bool[size, size];

            // we set three living cells next to each other
            // in one line
            int half = size / 2;
            init[half, half] = true;
            init[half - 1, half] = true;
            init[half + 1, half] = true;
            this.envir = (bool[,])init.Clone();
            this.init = init;
        } 
        #endregion // BlinkerInit

        #region RandomInit
        /// <summary>
        /// Performs random initialization of the environment
        /// </summary>
        /// <param name="size">The size of the environment</param>
        internal void RandomInit(int size = ENVIR_SIZE)
        {
            bool[,] init = new bool[size, size];

            var r = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (r.NextDouble() < 0.3)
                    {
                        init[i, j] = true;
                    }
                }
            }
            this.envir = (bool[,])init.Clone();
            this.init = init;
        }
        #endregion // RandomInit

        #region Update
        /// <summary>
        /// performs an update of the gol, i.e. calculates the next
        /// generation(s)
        /// </summary>
        /// <param name="generations">Number of generations to update,i.e. how
        /// many updates to perform
        /// </param>
        public void Update(int generations = 1)
        {
            // local var
            bool[,] envir = this.envir;
            bool[,] copy = new bool[this.size, this.size];

            // perform some updates...
            for (int i = 0; i < generations; i++)
            {
                // apply our update                 
                ApplyRules(envir, out copy);
                envir = (bool[,])copy.Clone();
            }
            // set the new environment
            this.envir = copy;
        }
        #endregion // Update

        #region ApplyRules
        /// <summary>
        /// 
        /// </summary>
        /// <param name="envir"></param>
        /// <param name="copy"></param>        
        private void ApplyRules(bool[,] envir, out bool[,] copy)
        {
            copy = (bool[,])envir.Clone();

            // iterate over all cells and apply the rules
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    int[] neighbourhood = GetNeighbourhood(envir, i, j);
                    int sum = 0;
                    // calculate sum
                    foreach (int s in neighbourhood)
                    {
                        sum += s;
                    }

                    if (envir[i, j])
                    {
                        // living cell

                        // rule 1) and 3) in the guide, let's the cell die
                        // rule 2) is implicit
                        if (sum < 2 || sum > 3)
                        {
                            copy[i, j] = false;
                        }
                    }
                    else
                    {
                        // dead cell

                        // rule 4)
                        if (sum == 3)
                        {
                            copy[i, j] = true;
                        }
                    }
                }
            }
        }
        #endregion // ApplyRules

        #region GetNeighbourhood
        /// <summary>
        /// gets the neighbourhood summarized as an integer
        /// array, i.e. each "1" represents a living cell, 
        /// each "0" a dead cell
        /// </summary>
        /// <param name="envir">The envir to get the neighbourhood
        /// from</param>
        /// <param name="x">The x coordiante of the cell for which to get 
        /// the neighbourhood</param>
        /// /// <param name="y">The y coordiante of the cell for which to get 
        /// the neighbourhood</param>
        /// <returns></returns>
        private int[] GetNeighbourhood(bool[,] envir, int x, int y)
        {
            // results vector
            int[] result = new int[8];
            int ridx = 0;

            // iterate over all possible neighbouring fields
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    // the main cell itself, skip it
                    if (i == j && i == 0) continue;
                    // get neighbour coordinates
                    int nx = x + i;
                    int ny = y + j;
                    // check outside x/y coordinate
                    int maxIdx = this.size - 1;
                    if (nx < 0) nx = maxIdx;
                    if (ny < 0) ny = maxIdx;
                    if (nx > maxIdx) nx = 0;
                    if (ny > maxIdx) ny = 0;
                    // now get the value at the current position
                    bool v = envir[nx, ny];

                    if (v)
                    {
                        result[ridx] = 1;
                    }
                    else
                    {
                        result[ridx] = 0;
                    }

                    // increase running idx
                    ridx++;
                }
            }
            return result;
        }
        #endregion // GetNeighbourhood

        #region Override Methods

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    sb.Append(this.envir[i, j]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        #endregion // Override Methods

        #endregion // Methods
    }
}
