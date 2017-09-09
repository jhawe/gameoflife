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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btRunGOL = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btBlinker = new System.Windows.Forms.Button();
            this.btRandomInit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.display = new System.Windows.Forms.PictureBox();
            this.nSize = new System.Windows.Forms.NumericUpDown();
            this.nSpeed = new System.Windows.Forms.NumericUpDown();
            this.nProbability = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nProbability)).BeginInit();
            this.groupBox4.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.display);
            this.splitContainer1.Size = new System.Drawing.Size(826, 488);
            this.splitContainer1.SplitterDistance = 276;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btRunGOL);
            this.groupBox3.Controls.Add(this.btNext);
            this.groupBox3.Location = new System.Drawing.Point(12, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 56);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Controls";
            // 
            // btRunGOL
            // 
            this.btRunGOL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRunGOL.Location = new System.Drawing.Point(179, 19);
            this.btRunGOL.Name = "btRunGOL";
            this.btRunGOL.Size = new System.Drawing.Size(75, 23);
            this.btRunGOL.TabIndex = 8;
            this.btRunGOL.Text = "Run";
            this.btRunGOL.UseVisualStyleBackColor = true;
            // 
            // btNext
            // 
            this.btNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNext.Location = new System.Drawing.Point(115, 19);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(61, 23);
            this.btNext.TabIndex = 0;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.btBlinker);
            this.groupBox2.Location = new System.Drawing.Point(13, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 64);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Special inits";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(171, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(89, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btBlinker
            // 
            this.btBlinker.Location = new System.Drawing.Point(7, 20);
            this.btBlinker.Name = "btBlinker";
            this.btBlinker.Size = new System.Drawing.Size(75, 23);
            this.btBlinker.TabIndex = 0;
            this.btBlinker.Text = "BlinkerInit";
            this.btBlinker.UseVisualStyleBackColor = true;
            // 
            // btRandomInit
            // 
            this.btRandomInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRandomInit.Location = new System.Drawing.Point(177, 55);
            this.btRandomInit.Name = "btRandomInit";
            this.btRandomInit.Size = new System.Drawing.Size(75, 23);
            this.btRandomInit.TabIndex = 5;
            this.btRandomInit.Text = "Init";
            this.btRandomInit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.nSpeed);
            this.groupBox1.Controls.Add(this.nSize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 81);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Update speed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Size";
            // 
            // display
            // 
            this.display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.display.Location = new System.Drawing.Point(0, 0);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(546, 488);
            this.display.TabIndex = 0;
            this.display.TabStop = false;
            // 
            // nSize
            // 
            this.nSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nSize.Location = new System.Drawing.Point(198, 20);
            this.nSize.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nSize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nSize.Name = "nSize";
            this.nSize.Size = new System.Drawing.Size(57, 20);
            this.nSize.TabIndex = 8;
            this.nSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
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
            this.nSpeed.Location = new System.Drawing.Point(198, 46);
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
            // nProbability
            // 
            this.nProbability.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nProbability.DecimalPlaces = 2;
            this.nProbability.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nProbability.Location = new System.Drawing.Point(193, 23);
            this.nProbability.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nProbability.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nProbability.Name = "nProbability";
            this.nProbability.Size = new System.Drawing.Size(59, 20);
            this.nProbability.TabIndex = 10;
            this.nProbability.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Probability of living cell";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.nProbability);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btRandomInit);
            this.groupBox4.Location = new System.Drawing.Point(12, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(261, 84);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Random initialization";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 488);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "GameOfLife";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nProbability)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.PictureBox display;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btNext;
        internal System.Windows.Forms.Button btRandomInit;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btBlinker;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button btRunGOL;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.NumericUpDown nSpeed;
        internal System.Windows.Forms.NumericUpDown nSize;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.NumericUpDown nProbability;
        private System.Windows.Forms.Label label2;
    }
}

