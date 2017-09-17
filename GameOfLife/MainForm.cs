﻿using System;
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

            // get generation info
            this.lGeneration.Text = "Generation: " + m.Generation.ToString();

            // flag whether to use 'fancy graphics'
            bool fancy = this.controller.DrawFancy;
            // flag whether to use random colors
            bool random = this.controller.UseRandomColor;

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

            // for random coloring
            Random rnd = new Random();
            for (int i = 0; i < m.Size; i++)
            {
                for (int j = 0; j < m.Size; j++)
                {
                    bool v = m.Envir[i, j];
                    Brush b;
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
                            // create a random color
                            c = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                        }
                        b = new SolidBrush(c);
                    }
                    else
                    {
                        b = new SolidBrush(Color.White);
                    }
                    // draw the actual field
                    g.FillRectangle(b, new Rectangle(i * sizeX, j * sizeY, sizeX, sizeY));
                }

            }
            // draw the buffer to the display
            this.display.CreateGraphics().DrawImage(bm, new Point(0, 0));
            this.Invalidate();
        } 
        #endregion // Redraw
    }
}
