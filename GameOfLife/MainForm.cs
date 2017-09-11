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
            this.controller = new Controller(this);            
        }

        internal void Redraw()
        {
            GameOfLife m = this.model;

            // get generation info
            this.lGeneration.Text = m.Generation.ToString();

            // get picture box graphics
            Bitmap bm = new Bitmap(this.display.Width, this.display.Height);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(Color.Gray);
            int sizeX = 0;
            int sizeY = 0;
            // get size of individual boxes
            Statics.GetBoxSize(m, this.display, out sizeX, out sizeY);

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

                    g.FillRectangle(b, new Rectangle(i * sizeX, j * sizeY, sizeX, sizeY));
                }

            }
            this.display.CreateGraphics().DrawImage(bm, new Point(0, 0));
            this.Invalidate();
        }
    }
}
