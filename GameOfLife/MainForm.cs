using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class MainForm : Form
    {
        #region Class Member
        internal GameOfLife model;
        private Controller controller;
        #endregion // Class Member

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            // member init
            InitializeComponent();
            this.controller = new Controller(this);
        }
        #endregion // Constructor

        #region Redraw
        /// <summary>
        /// Redraws the current GOL instance to the display
        /// </summary>
        internal void Redraw()
        {
            if (this.controller == null)
            {
                return;
            }

            GameOfLife m = this.model;

            // show generation info
            this.lGeneration.Text = "Generation: " + m.Generation.ToString();

            // flag whether to use 'fancy graphics' i.e. gradient coloring
            bool fancy = this.controller.DrawFancy;
            // flag whether to use random colors
            bool random = this.controller.UseRandomColor;

            // show only the profile
            bool showProfile = this.controller.ShowProfile;

            // field color 
            Color fc = this.controller.FieldColor;

            // get image buffer to draw fields on before
            // drawing on display
            Bitmap bm = new Bitmap(this.display.Width, this.display.Height);
            Graphics g = Graphics.FromImage(bm);

            g.Clear(Color.Gray);
            int sizeX = 0;
            int sizeY = 0;
            // get size of individual boxes
            Statics.GetBoxSize(m, this.display, out sizeX, out sizeY);

            // set background color
            Color bgCol = this.controller.BGColor;
            if (this.controller.FlickerBG && Controller.RNG.NextDouble() > 0.7)
            {
                bgCol = Color.Transparent;
            }

            // iterate over each field and draw it
            for (int i = 0; i < m.SizeX; i++)
            {
                for (int j = 0; j < m.SizeY; j++)
                {
                    // get the brush
                    Brush b = GetBrush(m, i, j, fc, bgCol, fancy, random, showProfile);

                    // draw the actual field
                    g.FillRectangle(b, new Rectangle(i * sizeX, j * sizeY, sizeX, sizeY));
                }
            }
            // draw the buffer to the display
            this.display.CreateGraphics().DrawImage(bm, new Point(0, 0));
            this.Invalidate();
        }
        #endregion // Redraw

        #region GetBrush
        /// <summary>
        /// Gets the brush to be used for drawing a specific field for the given model
        /// </summary>
        /// <param name="m">the current model instance</param>
        /// <param name="i">the fields i position</param>
        /// <param name="j">the fields j position</param>
        /// <param name="fc">the specified field color</param>
        /// <param name="bgCol">the specified background color</param>
        /// <param name="fancy">flag whether to use color gradients</param>
        /// <param name="random">glag whether to use random coloring</param>
        /// <param name="showProfile">flag whether to show the profile information instead
        /// of whether cells are currently dead or animate</param>
        /// <returns></returns>
        private Brush GetBrush(GameOfLife m, int i, int j, Color fc, Color bgCol, bool fancy, bool random, bool showProfile)
        {
            Brush b;
            // should we display the profile?
            if (showProfile)
            {
                // we had one visit at least for the current cell
                if (m.Profile[i, j] > 0)
                {
                    int v = Math.Min(m.Profile[i, j], 255);
                    b = new SolidBrush(Color.FromArgb(v, 255 - v, 0));
                }
                else
                {
                    // no visit yet, draw bgColor
                    b = new SolidBrush(bgCol);
                }
            }
            else
            {
                // draw the currently living cells in the colors
                // specified by the options
                bool v = m.Envir[i, j];
                if (v)
                {
                    Color c = fc;
                    // if we use fancy/gradient coloring, use color depending on 
                    // number of neighbouring living fields
                    if (fancy)
                    {
                        int[] n = m.GetNeighbourhood(m.Envir, i, j);
                        int sum = 0;
                        for (int z = 0; z < n.Length; z++) { sum += n[z]; }
                        c = ControlPaint.Light(fc, 1 - (sum * 1.0f) / n.Length);

                    }
                    // supercedes fancy/gradient coloring
                    if (random)
                    {
                        if (this.controller.StaticRandomColors)
                        {
                            c = this.controller.RandomFieldColors[i, j];
                        }
                        else
                        {
                            // create a random color
                            c = Color.FromArgb(Controller.RNG.Next(256),
                                Controller.RNG.Next(256),
                                Controller.RNG.Next(256));

                        }
                    }
                    b = new SolidBrush(c);
                }
                else
                {
                    b = new SolidBrush(bgCol);
                }
            }
            return b;
        } 
        #endregion // GetBrush
    }
}
