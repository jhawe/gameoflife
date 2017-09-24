using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class GameOfLife
    {
        #region Enums

        #region InitType
        /// <summary>
        /// Define the possible types of init
        /// </summary>
        public enum InitType
        {
            Random,
            Blinker,
            Gleiter,
            Pentamino
        }
        #endregion // InitType 

        #endregion // Enums

        #region Class Member
        /// <summary>
        /// class member definitions
        /// </summary>
        private bool[,] envir; // the current 'living environment'
        private bool[,] init; // always holds the initial field
        private int[,] profile; // holds the profile, i.e. how often a cell was visited
        private int sizeX;
        private int sizeY;
        private const int ENVIR_SIZE = 6;
        private int generation = 1;
        private bool infinite = true;
        private ParallelOptions po = null;
        #endregion // Class Member

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GameOfLife()
        {
            // set our parallelization options
            this.po = new ParallelOptions();
            this.po.MaxDegreeOfParallelism = Environment.ProcessorCount / 2;
        }
        #endregion // Constructor

        #region Properties

        #region Profile
        /// <summary>
        /// Gets the count profile for the current GOL instance
        /// </summary>
        internal int[,] Profile
        {
            get
            {
                if (this.profile == null)
                {
                    this.profile = new int[this.sizeX, this.sizeY];
                }
                return this.profile;
            }
        }
        #endregion // Profile

        #region Generation
        /// <summary>
        /// Gets the current generation number
        /// </summary>
        internal int Generation
        {
            get
            {
                return this.generation;
            }
        }
        #endregion // Generation

        #region Envir
        /// <summary>
        /// Gets the current GOL environment
        /// </summary>
        internal bool[,] Envir
        {
            get
            {
                return this.envir;
            }
        }
        #endregion // Envir

        #region SizeX
        /// <summary>
        /// Size of the current GOL instance
        /// </summary>
        internal int SizeX
        {
            get
            {
                return this.sizeX;
            }
            set
            {
                this.sizeX = value;
            }
        }
        #endregion // SizeX

        #region SizeY
        /// <summary>
        /// Size of the current GOL instance
        /// </summary>
        internal int SizeY
        {
            get
            {
                return this.sizeY;
            }
            set
            {
                this.sizeY = value;
            }
        }
        #endregion // SizeY

        #region Infinite
        /// <summary>
        /// Sets/gets flag whether the environment is infinite (i.e. goes across boundaries)
        /// or not
        /// </summary>
        public bool Infinite
        {
            get
            {
                return this.infinite;
            }
            internal set
            {
                this.infinite = value;
            }
        }
        #endregion // Infinite

        #endregion // Properties

        #region Methods

        #region UpdateProfile
        /// <summary>
        /// UPdates the games count profile for each cell
        /// </summary>
        /// <param name="envir"></param>
        private void UpdateProfile(bool[,] envir)
        {
            if (this.profile == null)
            {
                this.profile = new int[this.sizeX, this.sizeY];
            }
            for (int i = 0; i < this.sizeX; i++)
            {
                for (int j = 0; j < this.sizeY; j++)
                {
                    if (envir[i, j])
                    {
                        this.profile[i, j]++;
                    }
                }
            }
        }
        #endregion // UpdateProfile

        #region ToggleField
        /// <summary>
        /// Toggles a field to be dead or alive depedening on 
        /// its current state
        /// </summary>
        /// <param name="xn">X position of field</param>
        /// <param name="yn">Y position of field</param>
        internal void ToggleField(int xn, int yn)
        {
            if (xn >= 0 && xn < this.sizeX && yn >= 0 && yn < this.sizeY)
            {
                this.envir[xn, yn] = !this.envir[xn, yn];
                // update profile
                if (this.envir[xn, yn])
                {
                    this.profile[xn, yn]++;
                }
            }
        }
        #endregion // ToggleField

        #region Init
        /// <summary>
        /// Initializes a new environment for the GOL instance
        /// </summary>
        /// <param name="sizeX"></param>
        /// <param name="it"></param>
        /// <param name="sizeY"></param>
        /// <param name="prob"></param>
        internal void Init(int sizeX, InitType it, int sizeY = -1, float prob = 0.3f)
        {
            // check whether we want a square environment
            if (sizeY == -1)
            {
                sizeY = sizeX;
            }

            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.generation = 1;
            bool[,] init = new bool[sizeX, sizeY];
            this.profile = new int[sizeX, sizeY];

            switch (it)
            {
                case InitType.Random:
                    RandomInit(init, prob);
                    break;
                case InitType.Pentamino:
                    PentominoInit(init);
                    break;
                case InitType.Gleiter:
                    GleiterInit(init);
                    break;
                case InitType.Blinker:
                    BlinkerInit(init);
                    break;
                default:
                    throw new Exception("Init type is not supported");
            }

            this.envir = (bool[,])init.Clone();
            this.init = init;
            UpdateProfile(this.init);
        }
        #endregion // Init

        #region BlinkerInit
        /// <summary>
        /// Simple 'Blinker' init, placing three living cells
        /// right next to each other on init
        /// </summary>
        /// <param name="size">The size of the environment</param>
        private void BlinkerInit(bool[,] init)
        {
            // we set three living cells next to each other
            // in one line
            int half = Math.Min(this.sizeX, this.sizeY) / 2;
            init[half, half] = true;
            init[half - 1, half] = true;
            init[half + 1, half] = true;
        }
        #endregion // BlinkerInit

        #region RandomInit
        /// <summary>
        /// Performs random initialization of the environment
        /// </summary>
        /// <param name="size">The size of the environment</param>
        private void RandomInit(bool[,] init, float prob = 0.3f)
        {
            var r = new Random();
            for (int i = 0; i < this.sizeX; i++)
            {
                for (int j = 0; j < this.sizeY; j++)
                {
                    if (r.NextDouble() < prob)
                    {
                        init[i, j] = true;
                        this.profile[i, j]++;
                    }
                }
            }
            this.envir = (bool[,])init.Clone();
            this.init = init;
        }
        #endregion // RandomInit

        #region GleiterInit
        /// <summary>
        /// Initializes a "gleiter" in the middle of the environment
        /// </summary>
        /// <param name="size"></param>
        private void GleiterInit(bool[,] init)
        {
            // we set three living cells next to each other
            // in one line
            int half = Math.Min(this.sizeX, this.sizeY) / 2;
            init[half, half] = true;
            init[half - 1, half] = true;
            init[half + 1, half] = true;
            // one on the top of the last one
            init[half + 1, half - 1] = true;
            // one on top left of the last one
            init[half, half - 2] = true;
        }
        #endregion // GleiterInit

        #region PentominoInit
        /// <summary>
        /// Initializes a "Pentomino" in the middle of the environment
        /// </summary>
        /// <param name="size"></param>
        private void PentominoInit(bool[,] init)
        {
            // we set three living cells next to each other
            // in one vertical line
            int half = Math.Min(this.sizeX, this.sizeY) / 2;
            init[half, half] = true;
            init[half, half - 1] = true;
            init[half, half + 1] = true;
            // one to the left of the middle one
            init[half - 1, half] = true;
            // one on top left of the last one
            init[half + 1, half - 1] = true;
        }
        #endregion // PentominoInit

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
            bool[,] copy = new bool[this.sizeX, this.sizeY];

            // perform some updates...
            for (int i = 0; i < generations; i++)
            {
                this.generation++;

                // apply our update                 
                ApplyRules(out copy);
                this.envir = (bool[,])copy.Clone();

                // update the count profile
                UpdateProfile(this.envir);
            }
            // set the new environment
            this.envir = copy;
        }
        #endregion // Update

        #region ApplyRules
        /// <summary>
        /// Applies the GOL rules to all cells of an environment and
        /// saves the result in the supplied copied environment
        /// </summary>
        /// <param name="envir"></param>
        /// <param name="copy"></param>        
        private void ApplyRules(out bool[,] copy)
        {
            bool[,] o = (bool[,])this.envir.Clone();

            int sx = this.sizeX;
            int sy = this.sizeY;
            ParallelOptions po = this.po;
            // iterate over all cells and apply the rules
            Parallel.For(0, sx * sy, po, idx =>
            {
                int i = (int)Math.Floor(idx * 1.0f / sy);
                int j = (int)Math.Floor(idx * 1.0f % sy);

                int sum = SumNeighbourHood(i, j);

                if (this.envir[i, j])
                {
                    // living cell

                    // rule 1) and 3) in the guide, let's the cell die
                    // rule 2) is implicit
                    if (sum < 2 || sum > 3)
                    {
                        o[i, j] = false;
                    }
                }
                else
                {
                    // dead cell

                    // rule 4)
                    if (sum == 3)
                    {
                        o[i, j] = true;
                    }
                }
            });
            copy = o;
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
        internal int[] GetNeighbourhood(int x, int y)
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
                    int maxXIdx = this.sizeX - 1;
                    int maxYIdx = this.sizeY - 1;
                    if (Infinite)
                    {
                        if (nx < 0) nx = maxXIdx;
                        if (ny < 0) ny = maxYIdx;
                        if (nx > maxXIdx) nx = 0;
                        if (ny > maxYIdx) ny = 0;
                    }
                    // in that case, the field is not infinite
                    // but the field would be outside the envir,
                    // so we dont count the current field
                    if (nx < 0 || ny < 0 || nx > maxXIdx || ny > maxYIdx)
                    {
                        result[ridx] = 0;
                        continue;
                    }

                    // now get the value at the current position
                    bool v = this.envir[nx, ny];

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

        #region SumNeighbourHood
        /// <summary>
        /// Sum up the neighbourhood fields for a specific cell
        /// </summary>
        /// <param name="envir"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        internal int SumNeighbourHood(int x, int y)
        {
            int[] neighbourhood = GetNeighbourhood(x, y);
            int sum = 0;
            // calculate sum
            foreach (int s in neighbourhood)
            {
                sum += s;
            }
            return (sum);
        } 
        #endregion // SumNeighbourHood

        #region Override Methods

        #region ToString
        /// <summary>
        /// Creates string representation of the GOL instance
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.sizeX; i++)
            {
                for (int j = 0; j < this.sizeY; j++)
                {
                    sb.Append(this.envir[i, j]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        #endregion // ToString

        #endregion // Override Methods

        #endregion // Methods
    }
}
