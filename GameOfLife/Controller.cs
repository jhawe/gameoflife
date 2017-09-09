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
            this.golSize = (int)this.form.nSize.Value;
            this.gol = new GameOfLife(this.golSize);
            this.form = form;
            this.form.model = this.gol;
            this.form.display.Cursor = Cursors.Hand;
            // add some event handlers
            this.form.btNext.Click += OnUpdateClick;
            this.form.btRandomInit.Click += OnInitNewClick;
            this.form.display.MouseClick += OnDisplayMouseClick;
            this.form.nSize.ValueChanged += OnSizeChanged;
            this.form.btRunGOL.Click += OnRunGOLClick;
            this.form.nSpeed.ValueChanged += OnSpeedChanged;
            this.form.Resize += OnFormResize;
            this.form.SizeChanged += OnFormResize;
            this.form.ResizeEnd += OnFormResize;
            // the special init buttons
            this.form.btBlinker.Click += OnInitBlinker;
            this.form.Redraw();
        }        

        private void OnFormResize(object sender, EventArgs e)
        {
            this.form.Redraw();
        }

        private void OnSpeedChanged(object sender, EventArgs e)
        {            
            this.speed = (float)this.form.nSpeed.Value;            
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
            this.run = false;
            this.golSize = (int)this.form.nSize.Value;            
            this.gol.Size = this.golSize;
        }

        private void OnDisplayMouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // get coordinates
            int x = e.Location.X;
            int y = e.Location.Y;
            // get the according field
            // get size of individual boxes
            int sizeX = 0;
            int sizeY = 0;
            Statics.GetBoxSize(this.gol, (Control)sender, out sizeX, out sizeY);
            int xn = (int)Math.Floor(x * 1.0 / sizeX);
            int yn = (int)Math.Floor(y * 1.0 / sizeY);
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
            this.gol.RandomInit(this.golSize, (float)this.form.nProbability.Value);
            this.form.Redraw();
        }

        private void OnUpdateClick(object sender, EventArgs e)
        {
            this.gol.Update(1);
            this.form.Redraw();
        }
    }
}
