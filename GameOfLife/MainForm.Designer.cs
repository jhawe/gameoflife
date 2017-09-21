namespace GameOfLife
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lGeneration = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nProbability = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btRandomInit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.cbShowProfile = new System.Windows.Forms.CheckBox();
            this.cbRandomStaticColors = new System.Windows.Forms.CheckBox();
            this.plBGColor = new System.Windows.Forms.Panel();
            this.btBGColor = new System.Windows.Forms.Button();
            this.cbInfinityEnvir = new System.Windows.Forms.CheckBox();
            this.cbFlickerBG = new System.Windows.Forms.CheckBox();
            this.cbRandomColoring = new System.Windows.Forms.CheckBox();
            this.plColor = new System.Windows.Forms.Panel();
            this.btChooseColor = new System.Windows.Forms.Button();
            this.cbDrawFancy = new System.Windows.Forms.CheckBox();
            this.btRunGOL = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nSizeX = new System.Windows.Forms.NumericUpDown();
            this.nGenerations = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nSpeed = new System.Windows.Forms.NumericUpDown();
            this.nSizeY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.display = new System.Windows.Forms.PictureBox();
            this.cbInitTypes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nProbability)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbProgress);
            this.splitContainer1.Panel1.Controls.Add(this.lGeneration);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btRunGOL);
            this.splitContainer1.Panel1.Controls.Add(this.btNext);
            this.splitContainer1.Panel1MinSize = 276;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.display);
            this.splitContainer1.Size = new System.Drawing.Size(890, 541);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 0;
            // 
            // lGeneration
            // 
            this.lGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lGeneration.AutoSize = true;
            this.lGeneration.Location = new System.Drawing.Point(12, 519);
            this.lGeneration.Name = "lGeneration";
            this.lGeneration.Size = new System.Drawing.Size(0, 13);
            this.lGeneration.TabIndex = 14;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cbInitTypes);
            this.groupBox4.Controls.Add(this.nProbability);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btRandomInit);
            this.groupBox4.Location = new System.Drawing.Point(12, 140);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(282, 84);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Initialization";
            // 
            // nProbability
            // 
            this.nProbability.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nProbability.DecimalPlaces = 2;
            this.nProbability.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nProbability.Location = new System.Drawing.Point(131, 58);
            this.nProbability.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nProbability.Name = "nProbability";
            this.nProbability.Size = new System.Drawing.Size(59, 20);
            this.nProbability.TabIndex = 10;
            this.nProbability.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Probability of living cell";
            // 
            // btRandomInit
            // 
            this.btRandomInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRandomInit.Location = new System.Drawing.Point(201, 21);
            this.btRandomInit.Name = "btRandomInit";
            this.btRandomInit.Size = new System.Drawing.Size(75, 23);
            this.btRandomInit.TabIndex = 5;
            this.btRandomInit.Text = "Init";
            this.btRandomInit.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cbShowProfile);
            this.groupBox3.Controls.Add(this.cbRandomStaticColors);
            this.groupBox3.Controls.Add(this.plBGColor);
            this.groupBox3.Controls.Add(this.btBGColor);
            this.groupBox3.Controls.Add(this.cbFlickerBG);
            this.groupBox3.Controls.Add(this.cbRandomColoring);
            this.groupBox3.Controls.Add(this.plColor);
            this.groupBox3.Controls.Add(this.btChooseColor);
            this.groupBox3.Controls.Add(this.cbDrawFancy);
            this.groupBox3.Location = new System.Drawing.Point(12, 230);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(284, 142);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Visuals";
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.Location = new System.Drawing.Point(219, 407);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(75, 12);
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbProgress.TabIndex = 15;
            this.pbProgress.Visible = false;
            // 
            // cbShowProfile
            // 
            this.cbShowProfile.AutoSize = true;
            this.cbShowProfile.Location = new System.Drawing.Point(6, 119);
            this.cbShowProfile.Name = "cbShowProfile";
            this.cbShowProfile.Size = new System.Drawing.Size(84, 17);
            this.cbShowProfile.TabIndex = 17;
            this.cbShowProfile.Text = "Show profile";
            this.cbShowProfile.UseVisualStyleBackColor = true;
            // 
            // cbRandomStaticColors
            // 
            this.cbRandomStaticColors.AutoSize = true;
            this.cbRandomStaticColors.Enabled = false;
            this.cbRandomStaticColors.Location = new System.Drawing.Point(155, 72);
            this.cbRandomStaticColors.Name = "cbRandomStaticColors";
            this.cbRandomStaticColors.Size = new System.Drawing.Size(79, 17);
            this.cbRandomStaticColors.TabIndex = 16;
            this.cbRandomStaticColors.Text = "fixed colors";
            this.cbRandomStaticColors.UseVisualStyleBackColor = true;
            // 
            // plBGColor
            // 
            this.plBGColor.Location = new System.Drawing.Point(230, 20);
            this.plBGColor.Name = "plBGColor";
            this.plBGColor.Size = new System.Drawing.Size(22, 21);
            this.plBGColor.TabIndex = 12;
            // 
            // btBGColor
            // 
            this.btBGColor.Location = new System.Drawing.Point(155, 18);
            this.btBGColor.Name = "btBGColor";
            this.btBGColor.Size = new System.Drawing.Size(70, 23);
            this.btBGColor.TabIndex = 15;
            this.btBGColor.Text = "BG color";
            this.btBGColor.UseVisualStyleBackColor = true;
            // 
            // cbInfinityEnvir
            // 
            this.cbInfinityEnvir.AutoSize = true;
            this.cbInfinityEnvir.Checked = true;
            this.cbInfinityEnvir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInfinityEnvir.Location = new System.Drawing.Point(9, 99);
            this.cbInfinityEnvir.Name = "cbInfinityEnvir";
            this.cbInfinityEnvir.Size = new System.Drawing.Size(118, 17);
            this.cbInfinityEnvir.TabIndex = 14;
            this.cbInfinityEnvir.Text = "Infinite environment";
            this.cbInfinityEnvir.UseVisualStyleBackColor = true;
            // 
            // cbFlickerBG
            // 
            this.cbFlickerBG.AutoSize = true;
            this.cbFlickerBG.Location = new System.Drawing.Point(6, 96);
            this.cbFlickerBG.Name = "cbFlickerBG";
            this.cbFlickerBG.Size = new System.Drawing.Size(117, 17);
            this.cbFlickerBG.TabIndex = 13;
            this.cbFlickerBG.Text = "Flicker background";
            this.cbFlickerBG.UseVisualStyleBackColor = true;
            // 
            // cbRandomColoring
            // 
            this.cbRandomColoring.AutoSize = true;
            this.cbRandomColoring.Location = new System.Drawing.Point(6, 72);
            this.cbRandomColoring.Name = "cbRandomColoring";
            this.cbRandomColoring.Size = new System.Drawing.Size(143, 17);
            this.cbRandomColoring.TabIndex = 12;
            this.cbRandomColoring.Text = "Random stained coloring";
            this.cbRandomColoring.UseVisualStyleBackColor = true;
            // 
            // plColor
            // 
            this.plColor.Location = new System.Drawing.Point(91, 20);
            this.plColor.Name = "plColor";
            this.plColor.Size = new System.Drawing.Size(22, 21);
            this.plColor.TabIndex = 11;
            // 
            // btChooseColor
            // 
            this.btChooseColor.Location = new System.Drawing.Point(6, 19);
            this.btChooseColor.Name = "btChooseColor";
            this.btChooseColor.Size = new System.Drawing.Size(77, 23);
            this.btChooseColor.TabIndex = 10;
            this.btChooseColor.Text = "Field color";
            this.btChooseColor.UseVisualStyleBackColor = true;
            // 
            // cbDrawFancy
            // 
            this.cbDrawFancy.AutoSize = true;
            this.cbDrawFancy.Location = new System.Drawing.Point(6, 48);
            this.cbDrawFancy.Name = "cbDrawFancy";
            this.cbDrawFancy.Size = new System.Drawing.Size(126, 17);
            this.cbDrawFancy.TabIndex = 9;
            this.cbDrawFancy.Text = "Use gradient coloring";
            this.cbDrawFancy.UseVisualStyleBackColor = true;
            // 
            // btRunGOL
            // 
            this.btRunGOL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRunGOL.Location = new System.Drawing.Point(219, 378);
            this.btRunGOL.Name = "btRunGOL";
            this.btRunGOL.Size = new System.Drawing.Size(75, 23);
            this.btRunGOL.TabIndex = 8;
            this.btRunGOL.Text = "Run";
            this.btRunGOL.UseVisualStyleBackColor = true;
            // 
            // btNext
            // 
            this.btNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNext.Location = new System.Drawing.Point(152, 378);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(61, 23);
            this.btNext.TabIndex = 0;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.nSizeX);
            this.groupBox1.Controls.Add(this.nGenerations);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nSpeed);
            this.groupBox1.Controls.Add(this.nSizeY);
            this.groupBox1.Controls.Add(this.cbInfinityEnvir);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 122);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // nSizeX
            // 
            this.nSizeX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nSizeX.Location = new System.Drawing.Point(152, 20);
            this.nSizeX.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nSizeX.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nSizeX.Name = "nSizeX";
            this.nSizeX.Size = new System.Drawing.Size(57, 20);
            this.nSizeX.TabIndex = 12;
            this.nSizeX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nGenerations
            // 
            this.nGenerations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nGenerations.Location = new System.Drawing.Point(219, 74);
            this.nGenerations.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nGenerations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nGenerations.Name = "nGenerations";
            this.nGenerations.Size = new System.Drawing.Size(57, 20);
            this.nGenerations.TabIndex = 11;
            this.nGenerations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Generations per update";
            // 
            // nSpeed
            // 
            this.nSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nSpeed.DecimalPlaces = 2;
            this.nSpeed.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nSpeed.Location = new System.Drawing.Point(219, 46);
            this.nSpeed.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nSpeed.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nSpeed.Name = "nSpeed";
            this.nSpeed.Size = new System.Drawing.Size(57, 20);
            this.nSpeed.TabIndex = 9;
            this.nSpeed.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // nSizeY
            // 
            this.nSizeY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nSizeY.Location = new System.Drawing.Point(219, 20);
            this.nSizeY.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nSizeY.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nSizeY.Name = "nSizeY";
            this.nSizeY.Size = new System.Drawing.Size(57, 20);
            this.nSizeY.TabIndex = 8;
            this.nSizeY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Update interval (in sec)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Size (x / y)";
            // 
            // display
            // 
            this.display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.display.Location = new System.Drawing.Point(0, 0);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(589, 541);
            this.display.TabIndex = 0;
            this.display.TabStop = false;
            // 
            // cbInitTypes
            // 
            this.cbInitTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInitTypes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbInitTypes.FormattingEnabled = true;
            this.cbInitTypes.Location = new System.Drawing.Point(9, 23);
            this.cbInitTypes.Name = "cbInitTypes";
            this.cbInitTypes.Size = new System.Drawing.Size(181, 21);
            this.cbInitTypes.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 541);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "GameOfLife";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nProbability)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.PictureBox display;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btNext;
        internal System.Windows.Forms.Button btRandomInit;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button btRunGOL;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.NumericUpDown nSpeed;
        internal System.Windows.Forms.NumericUpDown nSizeY;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.NumericUpDown nProbability;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lGeneration;
        internal System.Windows.Forms.CheckBox cbDrawFancy;
        internal System.Windows.Forms.Button btChooseColor;
        internal System.Windows.Forms.Panel plColor;
        internal System.Windows.Forms.CheckBox cbRandomColoring;
        internal System.Windows.Forms.CheckBox cbFlickerBG;
        internal System.Windows.Forms.CheckBox cbInfinityEnvir;
        internal System.Windows.Forms.Panel plBGColor;
        internal System.Windows.Forms.Button btBGColor;
        internal System.Windows.Forms.CheckBox cbRandomStaticColors;
        internal System.Windows.Forms.CheckBox cbShowProfile;
        internal System.Windows.Forms.NumericUpDown nGenerations;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ProgressBar pbProgress;
        internal System.Windows.Forms.NumericUpDown nSizeX;
        internal System.Windows.Forms.ComboBox cbInitTypes;
    }
}

