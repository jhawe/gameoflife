using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public class Controller
    {
        GameOfLife gol;
        const int GOL_MIN_SIZE = 5;
        int golSize;
        MainForm form;
        private bool run;
        private Stopwatch stopWatch = Stopwatch.StartNew();
        readonly TimeSpan TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 60);
        readonly TimeSpan MaxElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 10);
        private TimeSpan lastTime;
        private Timer timer;
        private float speed;

        public Controller(MainForm form)
        {
            // member init
            this.form = form;
            // get size
            this.golSize = Int32.Parse(this.form.tbSize.Text);
            this.gol = new GameOfLife(this.golSize);
            this.form = form;
            this.form.model = this.gol;
            // add some event handlers
            this.form.btNext.Click += OnUpdateClick;
            this.form.btRandomInit.Click += OnInitNewClick;
            this.form.display.MouseClick += OnDisplayMouseClick;
            this.form.tbSize.TextChanged += OnSizeChanged;
            this.form.btRunGOL.Click += OnRunGOLClick;
            this.form.tbSpeed.TextChanged += OnSpeedChanged;
            // the special init buttons
            this.form.btBlinker.Click += OnInitBlinker;
            this.form.Redraw();
        }

        private void OnSpeedChanged(object sender, EventArgs e)
        {
            float.TryParse(this.form.tbSpeed.Text, out this.speed);
            if(this.speed < 0.001)
            {
                this.form.tbSpeed.Text = "0.3";
                this.speed = 0.3f;
            }
        }

        private void OnRunGOLClick(object sender, EventArgs e)
        {
            Button rbt = (Button)sender;
            
            this.run = !this.run;
            if (this.run)
            {
                rbt.Text = "Stop";
                // create timer if needed
                if (this.timer == null)
                {
                    this.timer = new Timer();
                    this.timer.Interval = (int)TargetElapsedTime.TotalMilliseconds;
                    this.timer.Tick += TimerTick;
                }
                this.timer.Start();
            } else
            {
                rbt.Text = "Start";
                this.run = false;
                this.timer.Stop();
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            TimeSpan currentTime = stopWatch.Elapsed;
            TimeSpan elapsedTime = currentTime - lastTime;
            if (elapsedTime > TimeSpan.FromSeconds(this.speed))
            {
                lastTime = currentTime;
                this.gol.Update(1);
                this.form.Redraw();
            }
            // check if we reached a non-existence
            if (Statics.EnvirEmpty(this.gol))
            {
                this.form.btRunGOL.Text = "Start";
                this.timer.Stop();
            }
        }        

        private void OnSizeChanged(object sender, EventArgs e)
        {
            string s = ((TextBox)sender).Text;
            Int32.TryParse(s, out this.golSize);
            if (this.golSize < GOL_MIN_SIZE)
            {
                this.golSize = GOL_MIN_SIZE;
                ((TextBox)sender).Text = GOL_MIN_SIZE.ToString();
            }
            this.gol.Size = this.golSize;
        }

        private void OnDisplayMouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // get coordinates
            int x = e.Location.X;
            int y = e.Location.Y;
            // get the according field
            // get size of individual boxes
            int rsize = Statics.GetBoxSize(this.gol, (Control)sender);
            int xn = (int)Math.Floor(x * 1.0 / rsize);
            int yn = (int)Math.Floor(y * 1.0 / rsize);
            // toggle the corresponding field
            this.gol.ToggleField(xn, yn);
            this.form.Redraw();

        }

        private void OnInitBlinker(object sender, EventArgs e)
        {
            this.gol.BlinkerInit(this.golSize);
            this.form.Redraw();
        }

        private void OnInitNewClick(object sender, EventArgs e)
        {
            this.gol.RandomInit(this.golSize);
            this.form.Redraw();
        }

        private void OnUpdateClick(object sender, EventArgs e)
        {
            this.gol.Update(1);
            this.form.Redraw();
        }
    }
}
