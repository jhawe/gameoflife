using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public class Controller
    {
        #region Class Member
        /// <summary>
        /// Class member definitions
        /// </summary>
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
        private bool needsInit;
        private ColorDialog colorDialog;
        private ColorDialog bgColorDialog;
        private Color[,] fieldColors;
        #endregion // Class Member

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="form"></param>
        public Controller(MainForm form)
        {
            // member init
            this.form = form;
            this.fieldColors = null;

            SetNeedsInit(true);
            // init color dialog
            this.colorDialog = new ColorDialog();
            this.colorDialog.Color = Color.DarkGreen;
            this.form.plColor.BackColor = this.colorDialog.Color;

            // init bg color dialog
            this.bgColorDialog = new ColorDialog();
            this.bgColorDialog.Color = Color.White;
            this.form.plBGColor.BackColor = this.bgColorDialog.Color;

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
            this.form.btChooseColor.Click += OnChooseColorClick;
            this.form.cbDrawFancy.CheckedChanged += OnUseFancyCheckChanged;
            this.form.cbRandomColoring.CheckedChanged += OnUseRandomColorChanged;
            this.form.cbInfinityEnvir.CheckedChanged += OnInfiniteEnvironmentChanged;
            this.form.btBGColor.Click += OnChooseBGColorClick;
            this.form.cbRandomStaticColors.CheckedChanged += OnRandomStaticColorsCheckanged;
            this.form.cbShowProfile.CheckedChanged += OnShowProfileCheckedChanged;
            // the special init buttons
            this.form.btBlinker.Click += OnInitBlinker;
            this.form.btGleiter.Click += OnInitGleiter;
            this.form.btPentomino.Click += OnInitPentomino;
            this.form.Redraw();
        }
        #endregion // Constructor

        #region Properties

        #region RandomFieldColors
        /// <summary>
        /// Gets a matrix of colors corresponding
        /// to the cells available in the environment
        /// colors are set randomly for each field
        /// </summary>
        internal Color[,] RandomFieldColors
        {
            get
            {
                if (this.fieldColors == null)
                {
                    // check whether to even use static random field
                    // colors
                    if (UseRandomColor && StaticRandomColors)
                    {
                        this.fieldColors = new Color[this.golSize, this.golSize];
                        Random r = new Random();
                        for (int i = 0; i < this.golSize; i++)
                        {
                            for (int j = 0; j < this.golSize; j++)
                            {
                                Color c = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                                this.fieldColors[i, j] = c;
                            }
                        }
                    }
                }
                return this.fieldColors;
            }
        }
        #endregion // RandomFieldColors

        #region DrawFancy
        /// <summary>
        /// Gets a value whether to use fancy drawing
        /// of the GOL instance
        /// </summary>
        internal bool DrawFancy
        {
            get
            {
                return this.form.cbDrawFancy.Checked;
            }
        }
        #endregion // DrawFancy

        #region FlickerBG
        /// <summary>
        /// Gets flag whether to flicker the background when drawing
        /// </summary>
        internal bool FlickerBG
        {
            get
            {
                return this.form.cbFlickerBG.Checked;
            }
        }
        #endregion //FlickerBG

        #region StaticRandomColors
        /// <summary>
        /// Gets a flag whether to use static random colors
        /// </summary>
        internal bool StaticRandomColors
        {
            get
            {
                return this.form.cbRandomStaticColors.Checked;
            }
        }
        #endregion // StaticRandomColors

        #region ShowProfile
        /// <summary>
        /// Gets a flag whether to show the profile
        /// </summary>
        internal bool ShowProfile
        {
            get
            {
                return this.form.cbShowProfile.Checked;
            }
        }
        #endregion // ShowProfile

        #region BGColor
        /// <summary>
        /// Gets the field color to be used for drawing
        /// </summary>
        internal Color BGColor
        {
            get
            {
                return this.bgColorDialog.Color;
            }
        }
        #endregion // BGColor

        #region FieldColor
        /// <summary>
        /// Gets the field color to be used for drawing
        /// </summary>
        internal Color FieldColor
        {
            get
            {
                return this.colorDialog.Color;
            }
        }
        #endregion // FieldColor

        #region UseRandomColor
        /// <summary>
        /// Gets flag whether to use random coloring of fields
        /// </summary>
        internal bool UseRandomColor
        {
            get
            {
                return this.form.cbRandomColoring.Checked;
            }
        }
        #endregion // UseRandomColor


        #endregion // Properties

        #region Methods

        #region Event Methods

        #region OnChooseColorClick
        /// <summary>
        /// Handles click on choose color button. Opens color dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChooseColorClick(object sender, EventArgs e)
        {
            DialogResult dr = this.colorDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.form.plColor.BackColor = this.colorDialog.Color;
                this.form.Redraw();
            }
        }
        #endregion // OnChooseColorClick

        private void OnFormResize(object sender, EventArgs e)
        {
            this.form.Redraw();
        }

        private void OnSpeedChanged(object sender, EventArgs e)
        {
            this.speed = (float)this.form.nSpeed.Value;
        }

        private void OnUseFancyCheckChanged(object sender, EventArgs e)
        {
            this.form.Redraw();
        }

        #region OnChooseBGColorClick
        /// <summary>
        /// handles click on button to choose bg color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChooseBGColorClick(object sender, EventArgs e)
        {
            DialogResult dr = this.bgColorDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.form.plBGColor.BackColor = this.bgColorDialog.Color;
                this.form.Redraw();
            }
        }
        #endregion // OnChooseBGColorClick

        private void OnRandomStaticColorsCheckanged(object sender, EventArgs e)
        {
            this.form.Redraw();
        }


        private void OnShowProfileCheckedChanged(object sender, EventArgs e)
        {
            bool v = this.form.cbShowProfile.Checked;
            // enable/disable controls
            this.form.cbFlickerBG.Enabled = !v;            
            this.form.cbRandomColoring.Enabled = !v;
            this.form.cbDrawFancy.Enabled = !v;
            this.form.btChooseColor.Enabled = !v;
            this.form.btBGColor.Enabled = !v;

            this.form.Redraw();
        }

        private void OnUseRandomColorChanged(object sender, EventArgs e)
        {
            bool rc = this.form.cbRandomColoring.Checked;
            // enable disable other color controls
            this.form.cbDrawFancy.Enabled = !rc;
            this.form.btChooseColor.Enabled = !rc;
            this.form.plColor.Enabled = !rc;
            this.form.cbRandomStaticColors.Enabled = rc;

            this.form.Redraw();
        }

        #region OnRunGOLClick
        /// <summary>
        /// Handles Click on "Start" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRunGOLClick(object sender, EventArgs e)
        {
            Button rbt = (Button)sender;
            if (!this.run)
            {
                this.run = true;
                rbt.Text = "Stop";
                // create timer if needed
                if (this.timer == null)
                {
                    this.timer = new Timer();
                    this.timer.Interval = (int)TargetElapsedTime.TotalMilliseconds;
                    this.timer.Tick += TimerTick;
                }
                this.timer.Start();
            }
            else
            {
                rbt.Text = "Start";
                this.run = false;
                this.timer.Stop();
            }
        }
        #endregion // OnRunGOLClick

        #region TimerTick
        /// <summary>
        /// Handles timer tick event. Calculates new generation
        /// and updates view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, EventArgs e)
        {
            // check whether we somewhere stopped the timer
            if (!this.run || this.needsInit)
            {
                this.timer.Stop();
                return;
            }

            // check how much time elapsed
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
                this.run = false;
            }
        }
        #endregion // TimerTick

        #region OnSizeChanged
        private void OnSizeChanged(object sender, EventArgs e)
        {
            // reset run variables
            // TODO implement dedicated 'togglerun' method
            this.run = false;
            this.form.btRunGOL.Text = "Start";
            this.golSize = (int)this.form.nSize.Value;
            this.gol.Size = this.golSize;
            SetNeedsInit(true);
        }
        #endregion // OnSizeChanged

        #region OnInfiniteEnvironmentChanged
        /// <summary>
        /// Handles checked change event o finfinitie envir toggle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnInfiniteEnvironmentChanged(object sender, EventArgs e)
        {
            this.gol.Infinite = this.form.cbInfinityEnvir.Checked;
            this.form.Redraw();
        }
        #endregion // OnInfiniteEnvironmentChanged

        #region OnDisplayMouseClick
        /// <summary>
        /// Handles click on the display and toggles the corresponding field
        /// under the mouse cursor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion // OnDisplayMouseClick

        #region OnUpdateClick
        /// <summary>
        /// Handles click on update button. performs single update of the
        /// GOL instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUpdateClick(object sender, EventArgs e)
        {
            this.gol.Update(1);
            this.form.Redraw();
        }
        #endregion // OnUpdateClick

        #region Init Methods

        private void OnInitPentomino(object sender, EventArgs e)
        {
            this.gol.PentominoInit(this.golSize);
            SetNeedsInit(false);
            this.form.Redraw();
        }

        private void OnInitGleiter(object sender, EventArgs e)
        {
            this.gol.GleiterInit(this.golSize);
            SetNeedsInit(false);
            this.form.Redraw();
        }

        private void OnInitBlinker(object sender, EventArgs e)
        {
            this.gol.BlinkerInit(this.golSize);
            SetNeedsInit(false);
            this.form.Redraw();
        }

        private void OnInitNewClick(object sender, EventArgs e)
        {
            this.gol.RandomInit(this.golSize, (float)this.form.nProbability.Value);
            SetNeedsInit(false);
            this.form.Redraw();
        }

        #endregion // Init Methods

        #endregion // Event Methods 

        #region SetNeedsInit
        /// <summary>
        /// Sets whether the GOL needs initialization
        /// or not, considerung relevant control
        /// </summary>
        /// <param name="value"></param>
        private void SetNeedsInit(bool value)
        {
            this.needsInit = value;
            // disable/enable start and next button
            this.form.btRunGOL.Enabled = !this.needsInit;
            this.form.btNext.Enabled = !this.needsInit;

            // reset random colors if necessary
            if (this.needsInit)
            {
                this.fieldColors = null;                
            }
        }
        #endregion // SetNeedsInit

        #endregion // Methods
    }
}