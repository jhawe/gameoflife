using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Controller
    {
        GameOfLife gol;
        MainForm form;

        public Controller(int size, MainForm form)
        {
            this.gol = new GameOfLife(size);
            this.form = form;
            this.form.model = this.gol;
            this.form.button1.Click += OnUpdateClick;
            this.form.button2.Click += OnInitNewClick;

            // the special init buttons
            this.form.btBlinker.Click += OnInitBlinker;
            this.form.Redraw();
        }

        private void OnInitBlinker(object sender, EventArgs e)
        {
            this.gol.BlinkerInit(this.gol.Size);
            this.form.Redraw();
        }

        private void OnInitNewClick(object sender, EventArgs e)
        {
            this.gol.RandomInit(this.gol.Size);
            this.form.Redraw();
        }

        private void OnUpdateClick(object sender, EventArgs e)
        {
            this.gol.Update(1);
            this.form.Redraw();
        }
    }
}
