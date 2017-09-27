using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GameOfLife.GameOfLife;

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
        int golSizeX;
        int golSizeY;
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
        private int[] lastMousePosition;
        // for random coloring mostly
        internal static Random RNG = new Random();
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
            this.lastMousePosition = new int[] { -1, -1 };
            // init color dialog
            this.colorDialog = new ColorDialog();
            this.colorDialog.Color = Color.DarkGreen;
            this.form.plColor.BackColor = this.colorDialog.Color;

            // init bg color dialog
            this.bgColorDialog = new ColorDialog();
            this.bgColorDialog.Color = Color.White;
            this.form.plBGColor.BackColor = this.bgColorDialog.Color;

            // get size
            this.golSizeX = (int)this.form.nSizeX.Value;
            this.golSizeY = (int)this.form.nSizeY.Value;
            this.gol = new GameOfLife();
            this.form = form;
            this.form.model = this.gol;
            this.form.display.Cursor = Cursors.Hand;
            SetNeedsInit(true);

            // add some event handlers
            this.form.btNext.Click += OnUpdateClick;
            this.form.btRandomInit.Click += OnInit;
            this.form.display.MouseClick += OnDisplayMouseClick;
            this.form.nSizeY.ValueChanged += OnSizeChanged;
            this.form.nSizeX.ValueChanged += OnSizeChanged;
            this.form.btRunGOL.Click += OnRunGOLClick;
            this.form.nSpeed.ValueChanged += OnSpeedChanged;
            this.form.ResizeEnd += OnFormResizeEnd;
            this.form.SizeChanged += OnFormResizeEnd;
            this.form.btChooseColor.Click += OnChooseColorClick;
            this.form.cbDrawFancy.CheckedChanged += OnUseFancyCheckChanged;
            this.form.cbRandomColoring.CheckedChanged += OnUseRandomColorChanged;
            this.form.cbInfinityEnvir.CheckedChanged += OnInfiniteEnvironmentChanged;
            this.form.btBGColor.Click += OnChooseBGColorClick;
            this.form.cbRandomStaticColors.CheckedChanged += OnRandomStaticColorsCheckanged;
            this.form.cbShowProfile.CheckedChanged += OnShowProfileCheckedChanged;
            this.form.cbInitTypes.SelectedValueChanged += OnInitTypeChanged;
            this.form.display.MouseMove += OnDisplayMouseMove;
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
                        this.fieldColors = new Color[this.golSizeX, this.golSizeY];
                        Random r = new Random();
                        for (int i = 0; i < this.golSizeX; i++)
                        {
                            for (int j = 0; j < this.golSizeY; j++)
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

        #region Running
        /// <summary>
        /// Gets a flag whether currently updates are taking place
        /// </summary>
        internal bool Running
        {
            get
            {
                return this.run;
            }
        }
        #endregion // Running

        #endregion // Properties

        #region Methods

        #region Event Methods

        #region OnInitTypeChanged
        /// <summary>
        /// Handle change of currently selected inittype
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnInitTypeChanged(object sender, EventArgs e)
        {
            InitType it = (InitType)this.form.cbInitTypes.SelectedValue;

            // set options for random init
            bool r = it.Equals(GameOfLife.InitType.Random);
            this.form.nProbability.Enabled = r;
            this.form.probLabel.Enabled = r;

            // toggle message for diagonal init
            bool d = it.Equals(GameOfLife.InitType.Diagonal);
            this.form.lDiagWarning.Visible = d;
        }
        #endregion // OnInitTypeChanged

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

        private void OnFormResizeEnd(object sender, EventArgs e)
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

            this.form.Redraw();
        }

        #region OnUseRandomColorChange
        /// <summary>
        /// Handles case if checkbox for randomcolor-use gets changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion // OnUseRandomColorChange

        #region OnDisplayMouseMove
        /// <summary>
        /// Handles mouse move event on display. checks if left mouse button
        /// is pressed, then toggles the field (once...) currently under
        /// the mouse pointer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDisplayMouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            GameOfLife m = this.gol;
            if (m != null & m.Envir != null)
            {
                Statics.GetFieldFromDisplayPos(x, y, m, this.form.display, out x, out y);
                if (x >= m.SizeX || y >= m.SizeY) return;

                bool nc = (x != this.lastMousePosition[0]) || (y != this.lastMousePosition[1]);
                // a secret
                this.lastMousePosition[0] = x;
                this.lastMousePosition[1] = y;

                if (e.Button == MouseButtons.Left & nc)
                {
                    this.gol.ToggleField(x, y);
                    this.form.Redraw();
                }
            }
        }
        #endregion // OnDisplayMouseMove

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
                this.form.pbProgress.Visible = true;
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
                StopUpdate();
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
                StopUpdate();
                return;
            }

            // check how much time elapsed
            TimeSpan currentTime = stopWatch.Elapsed;
            TimeSpan elapsedTime = currentTime - lastTime;
            if (elapsedTime > TimeSpan.FromSeconds(this.speed))
            {
                lastTime = currentTime;
                this.gol.Update((int)this.form.nGenerations.Value);
                this.form.Redraw();
            }
            // check if we reached a non-existence
            if (Statics.EnvirEmpty(this.gol))
            {
                StopUpdate();
            }
        }
        #endregion // TimerTick

        #region StopUpdate
        /// <summary>
        /// Stops update routine and sets appropriate
        /// variables
        /// </summary>
        private void StopUpdate()
        {
            this.form.btRunGOL.Text = "Start";
            this.timer.Stop();
            this.form.pbProgress.Visible = false;
            this.run = false;
        }
        #endregion // StopUpdate

        #region OnSizeChanged
        private void OnSizeChanged(object sender, EventArgs e)
        {
            SetNeedsInit(true);
            // reset run variables
            if (sender.Equals(this.form.nSizeX))
            {
                this.golSizeX = (int)this.form.nSizeX.Value;
            }
            else if (sender.Equals(this.form.nSizeY))
            {
                this.golSizeY = (int)this.form.nSizeY.Value;
            }
        }
        #endregion // OnSizeChanged

        #region OnInit
        /// <summary>
        /// Inits the environment based on the currently selected
        /// inittype
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnInit(object sender, EventArgs e)
        {
            var v = this.form.cbInitTypes.SelectedValue;
            InitType it = InitType.Random;
            Enum.TryParse<InitType>(v.ToString(), out it);

            this.gol.Init(this.golSizeX, it, this.golSizeY, (float)this.form.nProbability.Value);
            SetNeedsInit(false);
            this.form.Redraw();
        }
        #endregion // OnInit

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
            Statics.GetFieldFromDisplayPos(x, y, this.gol, (Control)sender, out x, out y);

            // toggle the corresponding field
            this.gol.ToggleField(x, y);
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
            this.gol.Update((int)this.form.nGenerations.Value);
            this.form.Redraw();
        }
        #endregion // OnUpdateClick

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
                this.run = false;
                this.form.btRunGOL.Text = "Start";
            }
        }
        #endregion // SetNeedsInit

        #endregion // Methods
    }
}