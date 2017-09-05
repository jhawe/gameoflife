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
        public MainForm()
        {
            InitializeComponent();
            this.controller = new Controller(16, this);
        }

        internal void Redraw()
        {
            GameOfLife m = this.model;

            // get picture box graphics
            Graphics g = this.display.CreateGraphics();
            g.Clear(Color.White);
            // get size of individual boxes
            int rsize = (int)Math.Min(this.display.Height, this.display.Width);
            rsize /= m.Size;

            for (int i = 0; i < m.Size; i++)
            {
                for(int j = 0; j < m.Size; j++)
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
