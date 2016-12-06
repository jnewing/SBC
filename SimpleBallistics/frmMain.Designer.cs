namespace SimpleBallistics
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numZeroRange = new System.Windows.Forms.NumericUpDown();
            this.numBulletWeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numMaxRange = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numBC = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numMuzzleVelocity = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numSightHeight = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbAtmosphere = new System.Windows.Forms.CheckBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.clRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDrop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCorrectionMOA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCorrectionMIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clClicks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVelocity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEnergy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbClicks = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZeroRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBulletWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMuzzleVelocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSightHeight)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(944, 479);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clRange,
            this.clDrop,
            this.clCorrectionMOA,
            this.clCorrectionMIL,
            this.clClicks,
            this.clTime,
            this.clVelocity,
            this.clEnergy});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 153);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(938, 323);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(938, 144);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.numZeroRange, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.numBulletWeight, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.numMaxRange, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label8, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.numBC, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.numMuzzleVelocity, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.label10, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.numSightHeight, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.label11, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.label12, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.cbAtmosphere, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbClicks, 7, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnCalc, 8, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(932, 125);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drag Model:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Zero Range:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bullet Weight:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "G1",
            "G2",
            "G3",
            "G5",
            "G6",
            "G7",
            "G8"});
            this.comboBox1.Location = new System.Drawing.Point(123, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(61, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // numZeroRange
            // 
            this.numZeroRange.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numZeroRange.Location = new System.Drawing.Point(123, 28);
            this.numZeroRange.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numZeroRange.Name = "numZeroRange";
            this.numZeroRange.Size = new System.Drawing.Size(119, 20);
            this.numZeroRange.TabIndex = 4;
            this.numZeroRange.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numBulletWeight
            // 
            this.numBulletWeight.Location = new System.Drawing.Point(123, 53);
            this.numBulletWeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numBulletWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBulletWeight.Name = "numBulletWeight";
            this.numBulletWeight.Size = new System.Drawing.Size(119, 20);
            this.numBulletWeight.TabIndex = 5;
            this.numBulletWeight.Value = new decimal(new int[] {
            140,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Max Range:";
            // 
            // numMaxRange
            // 
            this.numMaxRange.Location = new System.Drawing.Point(123, 78);
            this.numMaxRange.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numMaxRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxRange.Name = "numMaxRange";
            this.numMaxRange.Size = new System.Drawing.Size(119, 20);
            this.numMaxRange.TabIndex = 7;
            this.numMaxRange.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "yd";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "gr";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "yd";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(362, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "B.C.";
            // 
            // numBC
            // 
            this.numBC.DecimalPlaces = 3;
            this.numBC.Location = new System.Drawing.Point(395, 28);
            this.numBC.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBC.Name = "numBC";
            this.numBC.Size = new System.Drawing.Size(119, 20);
            this.numBC.TabIndex = 12;
            this.numBC.Value = new decimal(new int[] {
            607,
            0,
            0,
            196608});
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(306, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Muzzle Velocity:";
            // 
            // numMuzzleVelocity
            // 
            this.numMuzzleVelocity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMuzzleVelocity.Location = new System.Drawing.Point(395, 53);
            this.numMuzzleVelocity.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numMuzzleVelocity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMuzzleVelocity.Name = "numMuzzleVelocity";
            this.numMuzzleVelocity.Size = new System.Drawing.Size(119, 20);
            this.numMuzzleVelocity.TabIndex = 14;
            this.numMuzzleVelocity.Value = new decimal(new int[] {
            2732,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(321, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Sight Height:";
            // 
            // numSightHeight
            // 
            this.numSightHeight.DecimalPlaces = 2;
            this.numSightHeight.Location = new System.Drawing.Point(395, 78);
            this.numSightHeight.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSightHeight.Name = "numSightHeight";
            this.numSightHeight.Size = new System.Drawing.Size(119, 20);
            this.numSightHeight.TabIndex = 16;
            this.numSightHeight.Value = new decimal(new int[] {
            260,
            0,
            0,
            131072});
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(520, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "fps";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(520, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "in";
            // 
            // cbAtmosphere
            // 
            this.cbAtmosphere.AutoSize = true;
            this.cbAtmosphere.Location = new System.Drawing.Point(568, 28);
            this.cbAtmosphere.Name = "cbAtmosphere";
            this.cbAtmosphere.Size = new System.Drawing.Size(118, 17);
            this.cbAtmosphere.TabIndex = 20;
            this.cbAtmosphere.Text = "Enable Atmosphere";
            this.cbAtmosphere.UseVisualStyleBackColor = true;
            this.cbAtmosphere.CheckedChanged += new System.EventHandler(this.cbAtmosphere_CheckedChanged);
            // 
            // btnCalc
            // 
            this.btnCalc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCalc.Location = new System.Drawing.Point(705, 28);
            this.btnCalc.Name = "btnCalc";
            this.tableLayoutPanel2.SetRowSpan(this.btnCalc, 2);
            this.btnCalc.Size = new System.Drawing.Size(133, 44);
            this.btnCalc.TabIndex = 19;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = global::SimpleBallistics.Properties.Resources.printer;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = global::SimpleBallistics.Properties.Resources.documents;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::SimpleBallistics.Properties.Resources.cross;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint_1);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // clRange
            // 
            this.clRange.HeaderText = "Range";
            this.clRange.Name = "clRange";
            this.clRange.ReadOnly = true;
            // 
            // clDrop
            // 
            this.clDrop.HeaderText = "Drop (Inches)";
            this.clDrop.Name = "clDrop";
            this.clDrop.ReadOnly = true;
            // 
            // clCorrectionMOA
            // 
            this.clCorrectionMOA.HeaderText = "Correction (MOA)";
            this.clCorrectionMOA.Name = "clCorrectionMOA";
            this.clCorrectionMOA.ReadOnly = true;
            // 
            // clCorrectionMIL
            // 
            this.clCorrectionMIL.HeaderText = "Correction (MIL)";
            this.clCorrectionMIL.Name = "clCorrectionMIL";
            this.clCorrectionMIL.ReadOnly = true;
            // 
            // clClicks
            // 
            this.clClicks.HeaderText = "Clicks";
            this.clClicks.Name = "clClicks";
            this.clClicks.ReadOnly = true;
            // 
            // clTime
            // 
            this.clTime.HeaderText = "Time";
            this.clTime.Name = "clTime";
            this.clTime.ReadOnly = true;
            // 
            // clVelocity
            // 
            this.clVelocity.HeaderText = "Velocity";
            this.clVelocity.Name = "clVelocity";
            this.clVelocity.ReadOnly = true;
            // 
            // clEnergy
            // 
            this.clEnergy.HeaderText = "Energy";
            this.clEnergy.Name = "clEnergy";
            this.clEnergy.ReadOnly = true;
            // 
            // cbClicks
            // 
            this.cbClicks.AutoSize = true;
            this.cbClicks.Location = new System.Drawing.Point(568, 53);
            this.cbClicks.Name = "cbClicks";
            this.cbClicks.Size = new System.Drawing.Size(90, 17);
            this.cbClicks.TabIndex = 21;
            this.cbClicks.Text = "Enable Clicks";
            this.cbClicks.UseVisualStyleBackColor = true;
            this.cbClicks.CheckedChanged += new System.EventHandler(this.cbClicks_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 503);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(960, 542);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Ballistics";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZeroRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBulletWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMuzzleVelocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSightHeight)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numZeroRange;
        private System.Windows.Forms.NumericUpDown numBulletWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numMaxRange;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numBC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numMuzzleVelocity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numSightHeight;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbAtmosphere;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDrop;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCorrectionMOA;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCorrectionMIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn clClicks;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVelocity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEnergy;
        private System.Windows.Forms.CheckBox cbClicks;
    }
}

