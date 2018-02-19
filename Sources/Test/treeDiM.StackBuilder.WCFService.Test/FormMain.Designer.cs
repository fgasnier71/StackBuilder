namespace treeDiM.StackBuilder.WCFService.Test
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.bnExit = new System.Windows.Forms.Button();
            this.chkbAllowX = new System.Windows.Forms.CheckBox();
            this.chkbAllowY = new System.Windows.Forms.CheckBox();
            this.chkbAllowZ = new System.Windows.Forms.CheckBox();
            this.lbCaseDim = new System.Windows.Forms.Label();
            this.lbPalletDim = new System.Windows.Forms.Label();
            this.lbMaxPalletHeight = new System.Windows.Forms.Label();
            this.nudCaseDimX = new System.Windows.Forms.NumericUpDown();
            this.nudCaseDimY = new System.Windows.Forms.NumericUpDown();
            this.nudCaseDimZ = new System.Windows.Forms.NumericUpDown();
            this.nudPalletDimX = new System.Windows.Forms.NumericUpDown();
            this.nudPalletDimY = new System.Windows.Forms.NumericUpDown();
            this.nudMaxPalletHeight = new System.Windows.Forms.NumericUpDown();
            this.gbAllowedOrientations = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudCaseWeight = new System.Windows.Forms.NumericUpDown();
            this.nudPalletWeight = new System.Windows.Forms.NumericUpDown();
            this.nudPalletDimZ = new System.Windows.Forms.NumericUpDown();
            this.pbStackbuilder = new System.Windows.Forms.PictureBox();
            this.lbLoadedPalletDim = new System.Windows.Forms.Label();
            this.lbLoadedPalletWeight = new System.Windows.Forms.Label();
            this.lbLoadedPalletEfficiency = new System.Windows.Forms.Label();
            this.lbLoadedPalletDimValues = new System.Windows.Forms.Label();
            this.lbLoadedPalletWeightValue = new System.Windows.Forms.Label();
            this.lbLoadedPalletEfficiencyValue = new System.Windows.Forms.Label();
            this.bnCompute = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.lbCaseCount = new System.Windows.Forms.Label();
            this.lbLoadedPalletCaseCountValue = new System.Windows.Forms.Label();
            this.lbOverhang = new System.Windows.Forms.Label();
            this.nudOverhangY = new System.Windows.Forms.NumericUpDown();
            this.nudOverhangX = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseDimX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseDimY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseDimZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletDimX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletDimY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPalletHeight)).BeginInit();
            this.gbAllowedOrientations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletDimZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStackbuilder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangX)).BeginInit();
            this.SuspendLayout();
            // 
            // bnExit
            // 
            this.bnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnExit.Location = new System.Drawing.Point(666, 13);
            this.bnExit.Name = "bnExit";
            this.bnExit.Size = new System.Drawing.Size(75, 23);
            this.bnExit.TabIndex = 0;
            this.bnExit.Text = "Exit";
            this.bnExit.UseVisualStyleBackColor = true;
            this.bnExit.Click += new System.EventHandler(this.OnExit);
            // 
            // chkbAllowX
            // 
            this.chkbAllowX.AutoSize = true;
            this.chkbAllowX.Location = new System.Drawing.Point(6, 19);
            this.chkbAllowX.Name = "chkbAllowX";
            this.chkbAllowX.Size = new System.Drawing.Size(33, 17);
            this.chkbAllowX.TabIndex = 1;
            this.chkbAllowX.Text = "X";
            this.chkbAllowX.UseVisualStyleBackColor = true;
            // 
            // chkbAllowY
            // 
            this.chkbAllowY.AutoSize = true;
            this.chkbAllowY.Location = new System.Drawing.Point(46, 19);
            this.chkbAllowY.Name = "chkbAllowY";
            this.chkbAllowY.Size = new System.Drawing.Size(33, 17);
            this.chkbAllowY.TabIndex = 2;
            this.chkbAllowY.Text = "Y";
            this.chkbAllowY.UseVisualStyleBackColor = true;
            // 
            // chkbAllowZ
            // 
            this.chkbAllowZ.AutoSize = true;
            this.chkbAllowZ.Location = new System.Drawing.Point(86, 19);
            this.chkbAllowZ.Name = "chkbAllowZ";
            this.chkbAllowZ.Size = new System.Drawing.Size(33, 17);
            this.chkbAllowZ.TabIndex = 3;
            this.chkbAllowZ.Text = "Z";
            this.chkbAllowZ.UseVisualStyleBackColor = true;
            // 
            // lbCaseDim
            // 
            this.lbCaseDim.AutoSize = true;
            this.lbCaseDim.Location = new System.Drawing.Point(12, 13);
            this.lbCaseDim.Name = "lbCaseDim";
            this.lbCaseDim.Size = new System.Drawing.Size(53, 13);
            this.lbCaseDim.TabIndex = 4;
            this.lbCaseDim.Text = "Case dim.";
            // 
            // lbPalletDim
            // 
            this.lbPalletDim.AutoSize = true;
            this.lbPalletDim.Location = new System.Drawing.Point(12, 43);
            this.lbPalletDim.Name = "lbPalletDim";
            this.lbPalletDim.Size = new System.Drawing.Size(55, 13);
            this.lbPalletDim.TabIndex = 5;
            this.lbPalletDim.Text = "Pallet dim.";
            // 
            // lbMaxPalletHeight
            // 
            this.lbMaxPalletHeight.AutoSize = true;
            this.lbMaxPalletHeight.Location = new System.Drawing.Point(12, 75);
            this.lbMaxPalletHeight.Name = "lbMaxPalletHeight";
            this.lbMaxPalletHeight.Size = new System.Drawing.Size(90, 13);
            this.lbMaxPalletHeight.TabIndex = 6;
            this.lbMaxPalletHeight.Text = "Max. pallet height";
            // 
            // nudCaseDimX
            // 
            this.nudCaseDimX.DecimalPlaces = 1;
            this.nudCaseDimX.Location = new System.Drawing.Point(148, 11);
            this.nudCaseDimX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCaseDimX.Name = "nudCaseDimX";
            this.nudCaseDimX.Size = new System.Drawing.Size(74, 20);
            this.nudCaseDimX.TabIndex = 7;
            // 
            // nudCaseDimY
            // 
            this.nudCaseDimY.DecimalPlaces = 1;
            this.nudCaseDimY.Location = new System.Drawing.Point(228, 11);
            this.nudCaseDimY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCaseDimY.Name = "nudCaseDimY";
            this.nudCaseDimY.Size = new System.Drawing.Size(74, 20);
            this.nudCaseDimY.TabIndex = 8;
            // 
            // nudCaseDimZ
            // 
            this.nudCaseDimZ.DecimalPlaces = 1;
            this.nudCaseDimZ.Location = new System.Drawing.Point(308, 11);
            this.nudCaseDimZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCaseDimZ.Name = "nudCaseDimZ";
            this.nudCaseDimZ.Size = new System.Drawing.Size(74, 20);
            this.nudCaseDimZ.TabIndex = 9;
            // 
            // nudPalletDimX
            // 
            this.nudPalletDimX.DecimalPlaces = 1;
            this.nudPalletDimX.Location = new System.Drawing.Point(148, 41);
            this.nudPalletDimX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPalletDimX.Name = "nudPalletDimX";
            this.nudPalletDimX.Size = new System.Drawing.Size(74, 20);
            this.nudPalletDimX.TabIndex = 10;
            // 
            // nudPalletDimY
            // 
            this.nudPalletDimY.DecimalPlaces = 1;
            this.nudPalletDimY.Location = new System.Drawing.Point(228, 40);
            this.nudPalletDimY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPalletDimY.Name = "nudPalletDimY";
            this.nudPalletDimY.Size = new System.Drawing.Size(74, 20);
            this.nudPalletDimY.TabIndex = 11;
            // 
            // nudMaxPalletHeight
            // 
            this.nudMaxPalletHeight.DecimalPlaces = 1;
            this.nudMaxPalletHeight.Location = new System.Drawing.Point(148, 73);
            this.nudMaxPalletHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxPalletHeight.Name = "nudMaxPalletHeight";
            this.nudMaxPalletHeight.Size = new System.Drawing.Size(74, 20);
            this.nudMaxPalletHeight.TabIndex = 12;
            // 
            // gbAllowedOrientations
            // 
            this.gbAllowedOrientations.Controls.Add(this.chkbAllowX);
            this.gbAllowedOrientations.Controls.Add(this.chkbAllowY);
            this.gbAllowedOrientations.Controls.Add(this.chkbAllowZ);
            this.gbAllowedOrientations.Location = new System.Drawing.Point(450, 67);
            this.gbAllowedOrientations.Name = "gbAllowedOrientations";
            this.gbAllowedOrientations.Size = new System.Drawing.Size(142, 42);
            this.gbAllowedOrientations.TabIndex = 13;
            this.gbAllowedOrientations.TabStop = false;
            this.gbAllowedOrientations.Text = "Allowed orientations";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(447, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Case weight";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Pallet weight";
            // 
            // nudCaseWeight
            // 
            this.nudCaseWeight.DecimalPlaces = 1;
            this.nudCaseWeight.Location = new System.Drawing.Point(519, 13);
            this.nudCaseWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCaseWeight.Name = "nudCaseWeight";
            this.nudCaseWeight.Size = new System.Drawing.Size(74, 20);
            this.nudCaseWeight.TabIndex = 16;
            // 
            // nudPalletWeight
            // 
            this.nudPalletWeight.DecimalPlaces = 1;
            this.nudPalletWeight.Location = new System.Drawing.Point(520, 41);
            this.nudPalletWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPalletWeight.Name = "nudPalletWeight";
            this.nudPalletWeight.Size = new System.Drawing.Size(74, 20);
            this.nudPalletWeight.TabIndex = 17;
            // 
            // nudPalletDimZ
            // 
            this.nudPalletDimZ.DecimalPlaces = 1;
            this.nudPalletDimZ.Location = new System.Drawing.Point(309, 41);
            this.nudPalletDimZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPalletDimZ.Name = "nudPalletDimZ";
            this.nudPalletDimZ.Size = new System.Drawing.Size(74, 20);
            this.nudPalletDimZ.TabIndex = 18;
            // 
            // pbStackbuilder
            // 
            this.pbStackbuilder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbStackbuilder.Location = new System.Drawing.Point(2, 131);
            this.pbStackbuilder.Name = "pbStackbuilder";
            this.pbStackbuilder.Size = new System.Drawing.Size(520, 290);
            this.pbStackbuilder.TabIndex = 19;
            this.pbStackbuilder.TabStop = false;
            // 
            // lbLoadedPalletDim
            // 
            this.lbLoadedPalletDim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLoadedPalletDim.AutoSize = true;
            this.lbLoadedPalletDim.Location = new System.Drawing.Point(528, 191);
            this.lbLoadedPalletDim.Name = "lbLoadedPalletDim";
            this.lbLoadedPalletDim.Size = new System.Drawing.Size(126, 13);
            this.lbLoadedPalletDim.TabIndex = 20;
            this.lbLoadedPalletDim.Text = "Loaded pallet dimensions";
            // 
            // lbLoadedPalletWeight
            // 
            this.lbLoadedPalletWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLoadedPalletWeight.AutoSize = true;
            this.lbLoadedPalletWeight.Location = new System.Drawing.Point(528, 221);
            this.lbLoadedPalletWeight.Name = "lbLoadedPalletWeight";
            this.lbLoadedPalletWeight.Size = new System.Drawing.Size(105, 13);
            this.lbLoadedPalletWeight.TabIndex = 21;
            this.lbLoadedPalletWeight.Text = "Loaded pallet weight";
            // 
            // lbLoadedPalletEfficiency
            // 
            this.lbLoadedPalletEfficiency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLoadedPalletEfficiency.AutoSize = true;
            this.lbLoadedPalletEfficiency.Location = new System.Drawing.Point(528, 251);
            this.lbLoadedPalletEfficiency.Name = "lbLoadedPalletEfficiency";
            this.lbLoadedPalletEfficiency.Size = new System.Drawing.Size(115, 13);
            this.lbLoadedPalletEfficiency.TabIndex = 22;
            this.lbLoadedPalletEfficiency.Text = "LoadedPalletEfficiency";
            // 
            // lbLoadedPalletDimValues
            // 
            this.lbLoadedPalletDimValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLoadedPalletDimValues.AutoSize = true;
            this.lbLoadedPalletDimValues.Location = new System.Drawing.Point(660, 191);
            this.lbLoadedPalletDimValues.Name = "lbLoadedPalletDimValues";
            this.lbLoadedPalletDimValues.Size = new System.Drawing.Size(78, 13);
            this.lbLoadedPalletDimValues.TabIndex = 23;
            this.lbLoadedPalletDimValues.Text = ": 0 x 0 x 0 (mm)";
            // 
            // lbLoadedPalletWeightValue
            // 
            this.lbLoadedPalletWeightValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLoadedPalletWeightValue.AutoSize = true;
            this.lbLoadedPalletWeightValue.Location = new System.Drawing.Point(660, 221);
            this.lbLoadedPalletWeightValue.Name = "lbLoadedPalletWeightValue";
            this.lbLoadedPalletWeightValue.Size = new System.Drawing.Size(40, 13);
            this.lbLoadedPalletWeightValue.TabIndex = 24;
            this.lbLoadedPalletWeightValue.Text = ": 0 (kg)";
            // 
            // lbLoadedPalletEfficiencyValue
            // 
            this.lbLoadedPalletEfficiencyValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLoadedPalletEfficiencyValue.AutoSize = true;
            this.lbLoadedPalletEfficiencyValue.Location = new System.Drawing.Point(660, 251);
            this.lbLoadedPalletEfficiencyValue.Name = "lbLoadedPalletEfficiencyValue";
            this.lbLoadedPalletEfficiencyValue.Size = new System.Drawing.Size(36, 13);
            this.lbLoadedPalletEfficiencyValue.TabIndex = 25;
            this.lbLoadedPalletEfficiencyValue.Text = ": 0 (%)";
            // 
            // bnCompute
            // 
            this.bnCompute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCompute.Location = new System.Drawing.Point(603, 102);
            this.bnCompute.Name = "bnCompute";
            this.bnCompute.Size = new System.Drawing.Size(138, 23);
            this.bnCompute.TabIndex = 26;
            this.bnCompute.Text = "Call WCF service";
            this.bnCompute.UseVisualStyleBackColor = true;
            this.bnCompute.Click += new System.EventHandler(this.OnCompute);
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.Location = new System.Drawing.Point(2, 427);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(751, 76);
            this.rtbLog.TabIndex = 27;
            this.rtbLog.Text = "";
            // 
            // lbCaseCount
            // 
            this.lbCaseCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCaseCount.AutoSize = true;
            this.lbCaseCount.Location = new System.Drawing.Point(528, 164);
            this.lbCaseCount.Name = "lbCaseCount";
            this.lbCaseCount.Size = new System.Drawing.Size(61, 13);
            this.lbCaseCount.TabIndex = 28;
            this.lbCaseCount.Text = "Case count";
            // 
            // lbLoadedPalletCaseCountValue
            // 
            this.lbLoadedPalletCaseCountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLoadedPalletCaseCountValue.AutoSize = true;
            this.lbLoadedPalletCaseCountValue.Location = new System.Drawing.Point(663, 164);
            this.lbLoadedPalletCaseCountValue.Name = "lbLoadedPalletCaseCountValue";
            this.lbLoadedPalletCaseCountValue.Size = new System.Drawing.Size(19, 13);
            this.lbLoadedPalletCaseCountValue.TabIndex = 29;
            this.lbLoadedPalletCaseCountValue.Text = ": 0";
            // 
            // lbOverhang
            // 
            this.lbOverhang.AutoSize = true;
            this.lbOverhang.Location = new System.Drawing.Point(13, 107);
            this.lbOverhang.Name = "lbOverhang";
            this.lbOverhang.Size = new System.Drawing.Size(54, 13);
            this.lbOverhang.TabIndex = 30;
            this.lbOverhang.Text = "Overhang";
            // 
            // nudOverhangY
            // 
            this.nudOverhangY.DecimalPlaces = 1;
            this.nudOverhangY.Location = new System.Drawing.Point(228, 105);
            this.nudOverhangY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudOverhangY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudOverhangY.Name = "nudOverhangY";
            this.nudOverhangY.Size = new System.Drawing.Size(74, 20);
            this.nudOverhangY.TabIndex = 32;
            // 
            // nudOverhangX
            // 
            this.nudOverhangX.DecimalPlaces = 1;
            this.nudOverhangX.Location = new System.Drawing.Point(148, 105);
            this.nudOverhangX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudOverhangX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudOverhangX.Name = "nudOverhangX";
            this.nudOverhangX.Size = new System.Drawing.Size(74, 20);
            this.nudOverhangX.TabIndex = 31;
            // 
            // FormMain
            // 
            this.AcceptButton = this.bnExit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnExit;
            this.ClientSize = new System.Drawing.Size(753, 502);
            this.Controls.Add(this.nudOverhangY);
            this.Controls.Add(this.nudOverhangX);
            this.Controls.Add(this.lbOverhang);
            this.Controls.Add(this.lbLoadedPalletCaseCountValue);
            this.Controls.Add(this.lbCaseCount);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.bnCompute);
            this.Controls.Add(this.lbLoadedPalletEfficiencyValue);
            this.Controls.Add(this.lbLoadedPalletWeightValue);
            this.Controls.Add(this.lbLoadedPalletDimValues);
            this.Controls.Add(this.lbLoadedPalletEfficiency);
            this.Controls.Add(this.lbLoadedPalletWeight);
            this.Controls.Add(this.lbLoadedPalletDim);
            this.Controls.Add(this.pbStackbuilder);
            this.Controls.Add(this.nudPalletDimZ);
            this.Controls.Add(this.nudPalletWeight);
            this.Controls.Add(this.nudCaseWeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbAllowedOrientations);
            this.Controls.Add(this.nudMaxPalletHeight);
            this.Controls.Add(this.nudPalletDimY);
            this.Controls.Add(this.nudPalletDimX);
            this.Controls.Add(this.nudCaseDimZ);
            this.Controls.Add(this.nudCaseDimY);
            this.Controls.Add(this.nudCaseDimX);
            this.Controls.Add(this.lbMaxPalletHeight);
            this.Controls.Add(this.lbPalletDim);
            this.Controls.Add(this.lbCaseDim);
            this.Controls.Add(this.bnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "treeDiM.StackBuilder.WCFService.Test";
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseDimX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseDimY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseDimZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletDimX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletDimY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPalletHeight)).EndInit();
            this.gbAllowedOrientations.ResumeLayout(false);
            this.gbAllowedOrientations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletDimZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStackbuilder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnExit;
        private System.Windows.Forms.CheckBox chkbAllowX;
        private System.Windows.Forms.CheckBox chkbAllowY;
        private System.Windows.Forms.CheckBox chkbAllowZ;
        private System.Windows.Forms.Label lbCaseDim;
        private System.Windows.Forms.Label lbPalletDim;
        private System.Windows.Forms.Label lbMaxPalletHeight;
        private System.Windows.Forms.NumericUpDown nudCaseDimX;
        private System.Windows.Forms.NumericUpDown nudCaseDimY;
        private System.Windows.Forms.NumericUpDown nudCaseDimZ;
        private System.Windows.Forms.NumericUpDown nudPalletDimX;
        private System.Windows.Forms.NumericUpDown nudPalletDimY;
        private System.Windows.Forms.NumericUpDown nudMaxPalletHeight;
        private System.Windows.Forms.GroupBox gbAllowedOrientations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudCaseWeight;
        private System.Windows.Forms.NumericUpDown nudPalletWeight;
        private System.Windows.Forms.NumericUpDown nudPalletDimZ;
        private System.Windows.Forms.PictureBox pbStackbuilder;
        private System.Windows.Forms.Label lbLoadedPalletDim;
        private System.Windows.Forms.Label lbLoadedPalletWeight;
        private System.Windows.Forms.Label lbLoadedPalletEfficiency;
        private System.Windows.Forms.Label lbLoadedPalletDimValues;
        private System.Windows.Forms.Label lbLoadedPalletWeightValue;
        private System.Windows.Forms.Label lbLoadedPalletEfficiencyValue;
        private System.Windows.Forms.Button bnCompute;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label lbCaseCount;
        private System.Windows.Forms.Label lbLoadedPalletCaseCountValue;
        private System.Windows.Forms.Label lbOverhang;
        private System.Windows.Forms.NumericUpDown nudOverhangY;
        private System.Windows.Forms.NumericUpDown nudOverhangX;
    }
}

