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
        internal GameOfLife model;
        private Controller controller;
        //internal Bitmap bbDisplay;

        public MainForm()
        {
            InitializeComponent();
            this.controller = new Controller(this);

            /*  this.SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer, true);

              // code for those eventhandlers borrowed and adapted from 
              // https://stackoverflow.com/a/7835149
              this.ResizeEnd += new EventHandler(CreateBackBufferHandler);
              this.Load += new EventHandler(CreateBackBufferHandler);
              this.Paint += new PaintEventHandler(PaintHandler);
              */
        }

        /*
        void PaintHandler(object sender, PaintEventArgs e)
        {
            if (this.bbDisplay != null)
            {
                e.Graphics.DrawImageUnscaled(this.bbDisplay, Point.Empty);
            }
        }

        void CreateBackBufferHandler(object sender, EventArgs e)
        {
            if (this.bbDisplay != null)
                this.bbDisplay.Dispose();

            this.bbDisplay = (Bitmap)this.display.Image;
            //new Bitmap(this.display.Width, this.display.Height);
        }
        */

        internal void Redraw()
        {
            GameOfLife m = this.model;

            // get picture box graphics
            Graphics g = this.display.CreateGraphics();
            g.Clear(Color.Gray);
            // get size of individual boxes
            int rsize = Statics.GetBoxSize(m, this.display);

            for (int i = 0; i < m.Size; i++)
            {
                for (int j = 0; j < m.Size; j++)
                {
                    bool v = m.Envir[i, j];
                    Brush b;
                    if (v)
                    {
                        b = new SolidBrush(Color.Black);
                    }
                    else
                    {
                        b = new SolidBrush(Color.White);
                    }

                    g.FillRectangle(b, new Rectangle(i * rsize, j * rsize, rsize, rsize));
                }

            }
            this.Invalidate();
        }
    }
}
