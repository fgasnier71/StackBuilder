namespace treeDiM.StackBuilder.Desktop
{
    partial class DockContentAnalysisCasePallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentAnalysisCasePallet));
            this.toolStripAnalysis = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReportWord = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReportHTML = new System.Windows.Forms.ToolStripButton();
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.graphCtrlSolution = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.gridSolutions = new SourceGrid.Grid();
            this.gbStopCriterions = new System.Windows.Forms.GroupBox();
            this.uCtrlOptMaximumWeight = new treeDiM.StackBuilder.Basics.UCtrlOptDouble();
            this.uCtrlMaxPalletHeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPagePalletCorners = new System.Windows.Forms.TabPage();
            this.cbPalletCorners = new System.Windows.Forms.ComboBox();
            this.chkbPalletCorners = new System.Windows.Forms.CheckBox();
            this.tabPagePalletCap = new System.Windows.Forms.TabPage();
            this.cbPalletCap = new System.Windows.Forms.ComboBox();
            this.chkbPalletCap = new System.Windows.Forms.CheckBox();
            this.tabPagePalletFilm = new System.Windows.Forms.TabPage();
            this.cbPalletFilm = new System.Windows.Forms.ComboBox();
            this.chkbPalletFilm = new System.Windows.Forms.CheckBox();
            this.gbLayer = new System.Windows.Forms.GroupBox();
            this.chkbInterlayer = new System.Windows.Forms.CheckBox();
            this.cbInterlayer = new System.Windows.Forms.ComboBox();
            this.cbLayerType = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboLayer();
            this.bnSymmetryX = new System.Windows.Forms.Button();
            this.bnSymetryY = new System.Windows.Forms.Button();
            this.tbClickLayer = new System.Windows.Forms.TextBox();
            this.toolStripAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).BeginInit();
            this.gbStopCriterions.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tabPagePalletCorners.SuspendLayout();
            this.tabPagePalletCap.SuspendLayout();
            this.tabPagePalletFilm.SuspendLayout();
            this.gbLayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripAnalysis
            // 
            this.toolStripAnalysis.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonBack,
            this.toolStripButtonReportWord,
            this.toolStripButtonReportHTML});
            this.toolStripAnalysis.Location = new System.Drawing.Point(0, 0);
            this.toolStripAnalysis.Name = "toolStripAnalysis";
            this.toolStripAnalysis.Size = new System.Drawing.Size(784, 25);
            this.toolStripAnalysis.TabIndex = 1;
            this.toolStripAnalysis.Text = "Generate MS Word report";
            // 
            // toolStripButtonBack
            // 
            this.toolStripButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBack.Image")));
            this.toolStripButtonBack.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonBack.Name = "toolStripButtonBack";
            this.toolStripButtonBack.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBack.Text = "Back...";
            this.toolStripButtonBack.Click += new System.EventHandler(this.onBack);
            // 
            // toolStripButtonReportWord
            // 
            this.toolStripButtonReportWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReportWord.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReportWord.Image")));
            this.toolStripButtonReportWord.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonReportWord.Name = "toolStripButtonReportWord";
            this.toolStripButtonReportWord.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonReportWord.Text = "Generate MS Word report";
            this.toolStripButtonReportWord.Click += new System.EventHandler(this.onGenerateReportMSWord);
            // 
            // toolStripButtonReportHTML
            // 
            this.toolStripButtonReportHTML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReportHTML.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReportHTML.Image")));
            this.toolStripButtonReportHTML.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonReportHTML.Name = "toolStripButtonReportHTML";
            this.toolStripButtonReportHTML.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonReportHTML.Text = "HTML report";
            this.toolStripButtonReportHTML.Click += new System.EventHandler(this.onGenerateReportHTML);
            // 
            // splitContainerHoriz
            // 
            this.splitContainerHoriz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerHoriz.IsSplitterFixed = true;
            this.splitContainerHoriz.Location = new System.Drawing.Point(0, 25);
            this.splitContainerHoriz.Name = "splitContainerHoriz";
            this.splitContainerHoriz.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerHoriz.Panel1
            // 
            this.splitContainerHoriz.Panel1.Controls.Add(this.splitContainerVert);
            // 
            // splitContainerHoriz.Panel2
            // 
            this.splitContainerHoriz.Panel2.Controls.Add(this.gbStopCriterions);
            this.splitContainerHoriz.Panel2.Controls.Add(this.tabCtrl);
            this.splitContainerHoriz.Panel2.Controls.Add(this.gbLayer);
            this.splitContainerHoriz.Panel2.Controls.Add(this.tbClickLayer);
            this.splitContainerHoriz.Panel2MinSize = 100;
            this.splitContainerHoriz.Size = new System.Drawing.Size(784, 536);
            this.splitContainerHoriz.SplitterDistance = 410;
            this.splitContainerHoriz.TabIndex = 13;
            // 
            // splitContainerVert
            // 
            this.splitContainerVert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVert.Location = new System.Drawing.Point(0, 0);
            this.splitContainerVert.Name = "splitContainerVert";
            // 
            // splitContainerVert.Panel1
            // 
            this.splitContainerVert.Panel1.Controls.Add(this.graphCtrlSolution);
            // 
            // splitContainerVert.Panel2
            // 
            this.splitContainerVert.Panel2.Controls.Add(this.gridSolutions);
            this.splitContainerVert.Size = new System.Drawing.Size(784, 410);
            this.splitContainerVert.SplitterDistance = 586;
            this.splitContainerVert.TabIndex = 1;
            // 
            // graphCtrlSolution
            // 
            this.graphCtrlSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphCtrlSolution.Location = new System.Drawing.Point(0, 0);
            this.graphCtrlSolution.Name = "graphCtrlSolution";
            this.graphCtrlSolution.Size = new System.Drawing.Size(586, 410);
            this.graphCtrlSolution.TabIndex = 1;
            this.graphCtrlSolution.Viewer = null;
            // 
            // gridSolutions
            // 
            this.gridSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSolutions.EnableSort = true;
            this.gridSolutions.Location = new System.Drawing.Point(0, 0);
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridSolutions.Size = new System.Drawing.Size(194, 410);
            this.gridSolutions.TabIndex = 0;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // gbStopCriterions
            // 
            this.gbStopCriterions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbStopCriterions.Controls.Add(this.uCtrlOptMaximumWeight);
            this.gbStopCriterions.Controls.Add(this.uCtrlMaxPalletHeight);
            this.gbStopCriterions.Location = new System.Drawing.Point(253, 5);
            this.gbStopCriterions.Name = "gbStopCriterions";
            this.gbStopCriterions.Size = new System.Drawing.Size(213, 113);
            this.gbStopCriterions.TabIndex = 15;
            this.gbStopCriterions.TabStop = false;
            this.gbStopCriterions.Text = "Stop criterions";
            // 
            // uCtrlOptMaximumWeight
            // 
            this.uCtrlOptMaximumWeight.Location = new System.Drawing.Point(4, 44);
            this.uCtrlOptMaximumWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlOptMaximumWeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlOptMaximumWeight.Name = "uCtrlOptMaximumWeight";
            this.uCtrlOptMaximumWeight.Size = new System.Drawing.Size(206, 20);
            this.uCtrlOptMaximumWeight.TabIndex = 1;
            this.uCtrlOptMaximumWeight.Text = "Maximum weight";
            this.uCtrlOptMaximumWeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlOptMaximumWeight.Value = ((treeDiM.StackBuilder.Basics.OptDouble)(resources.GetObject("uCtrlOptMaximumWeight.Value")));
            // 
            // uCtrlMaxPalletHeight
            // 
            this.uCtrlMaxPalletHeight.Location = new System.Drawing.Point(4, 17);
            this.uCtrlMaxPalletHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMaxPalletHeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMaxPalletHeight.Name = "uCtrlMaxPalletHeight";
            this.uCtrlMaxPalletHeight.Size = new System.Drawing.Size(206, 20);
            this.uCtrlMaxPalletHeight.TabIndex = 0;
            this.uCtrlMaxPalletHeight.Text = "Maximum height";
            this.uCtrlMaxPalletHeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMaxPalletHeight.Value = 0D;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrl.Controls.Add(this.tabPagePalletCorners);
            this.tabCtrl.Controls.Add(this.tabPagePalletCap);
            this.tabCtrl.Controls.Add(this.tabPagePalletFilm);
            this.tabCtrl.Location = new System.Drawing.Point(469, 8);
            this.tabCtrl.Multiline = true;
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(315, 113);
            this.tabCtrl.TabIndex = 14;
            // 
            // tabPagePalletCorners
            // 
            this.tabPagePalletCorners.Controls.Add(this.cbPalletCorners);
            this.tabPagePalletCorners.Controls.Add(this.chkbPalletCorners);
            this.tabPagePalletCorners.Location = new System.Drawing.Point(4, 22);
            this.tabPagePalletCorners.Name = "tabPagePalletCorners";
            this.tabPagePalletCorners.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePalletCorners.Size = new System.Drawing.Size(307, 87);
            this.tabPagePalletCorners.TabIndex = 0;
            this.tabPagePalletCorners.Text = "Pallet Corners";
            this.tabPagePalletCorners.UseVisualStyleBackColor = true;
            // 
            // cbPalletCorners
            // 
            this.cbPalletCorners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalletCorners.FormattingEnabled = true;
            this.cbPalletCorners.Location = new System.Drawing.Point(130, 7);
            this.cbPalletCorners.Name = "cbPalletCorners";
            this.cbPalletCorners.Size = new System.Drawing.Size(150, 21);
            this.cbPalletCorners.TabIndex = 1;
            this.cbPalletCorners.SelectedIndexChanged += new System.EventHandler(this.onPalletProtectionChanged);
            // 
            // chkbPalletCorners
            // 
            this.chkbPalletCorners.AutoSize = true;
            this.chkbPalletCorners.Location = new System.Drawing.Point(7, 7);
            this.chkbPalletCorners.Name = "chkbPalletCorners";
            this.chkbPalletCorners.Size = new System.Drawing.Size(90, 17);
            this.chkbPalletCorners.TabIndex = 0;
            this.chkbPalletCorners.Text = "Pallet corners";
            this.chkbPalletCorners.UseVisualStyleBackColor = true;
            this.chkbPalletCorners.CheckedChanged += new System.EventHandler(this.onPalletProtectionChanged);
            // 
            // tabPagePalletCap
            // 
            this.tabPagePalletCap.Controls.Add(this.cbPalletCap);
            this.tabPagePalletCap.Controls.Add(this.chkbPalletCap);
            this.tabPagePalletCap.Location = new System.Drawing.Point(4, 22);
            this.tabPagePalletCap.Name = "tabPagePalletCap";
            this.tabPagePalletCap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePalletCap.Size = new System.Drawing.Size(307, 87);
            this.tabPagePalletCap.TabIndex = 1;
            this.tabPagePalletCap.Text = "Pallet Cap";
            this.tabPagePalletCap.UseVisualStyleBackColor = true;
            // 
            // cbPalletCap
            // 
            this.cbPalletCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalletCap.FormattingEnabled = true;
            this.cbPalletCap.Location = new System.Drawing.Point(130, 7);
            this.cbPalletCap.Name = "cbPalletCap";
            this.cbPalletCap.Size = new System.Drawing.Size(150, 21);
            this.cbPalletCap.TabIndex = 2;
            this.cbPalletCap.SelectedIndexChanged += new System.EventHandler(this.onPalletProtectionChanged);
            // 
            // chkbPalletCap
            // 
            this.chkbPalletCap.AutoSize = true;
            this.chkbPalletCap.Location = new System.Drawing.Point(7, 7);
            this.chkbPalletCap.Name = "chkbPalletCap";
            this.chkbPalletCap.Size = new System.Drawing.Size(73, 17);
            this.chkbPalletCap.TabIndex = 0;
            this.chkbPalletCap.Text = "Pallet cap";
            this.chkbPalletCap.UseVisualStyleBackColor = true;
            this.chkbPalletCap.CheckedChanged += new System.EventHandler(this.onPalletProtectionChanged);
            // 
            // tabPagePalletFilm
            // 
            this.tabPagePalletFilm.Controls.Add(this.cbPalletFilm);
            this.tabPagePalletFilm.Controls.Add(this.chkbPalletFilm);
            this.tabPagePalletFilm.Location = new System.Drawing.Point(4, 22);
            this.tabPagePalletFilm.Name = "tabPagePalletFilm";
            this.tabPagePalletFilm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePalletFilm.Size = new System.Drawing.Size(307, 87);
            this.tabPagePalletFilm.TabIndex = 2;
            this.tabPagePalletFilm.Text = "Pallet Film";
            this.tabPagePalletFilm.UseVisualStyleBackColor = true;
            // 
            // cbPalletFilm
            // 
            this.cbPalletFilm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalletFilm.FormattingEnabled = true;
            this.cbPalletFilm.Location = new System.Drawing.Point(130, 7);
            this.cbPalletFilm.Name = "cbPalletFilm";
            this.cbPalletFilm.Size = new System.Drawing.Size(150, 21);
            this.cbPalletFilm.TabIndex = 3;
            this.cbPalletFilm.SelectedIndexChanged += new System.EventHandler(this.onPalletProtectionChanged);
            // 
            // chkbPalletFilm
            // 
            this.chkbPalletFilm.AutoSize = true;
            this.chkbPalletFilm.Location = new System.Drawing.Point(7, 7);
            this.chkbPalletFilm.Name = "chkbPalletFilm";
            this.chkbPalletFilm.Size = new System.Drawing.Size(70, 17);
            this.chkbPalletFilm.TabIndex = 0;
            this.chkbPalletFilm.Text = "Pallet film";
            this.chkbPalletFilm.UseVisualStyleBackColor = true;
            this.chkbPalletFilm.CheckedChanged += new System.EventHandler(this.onPalletProtectionChanged);
            // 
            // gbLayer
            // 
            this.gbLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbLayer.Controls.Add(this.chkbInterlayer);
            this.gbLayer.Controls.Add(this.cbInterlayer);
            this.gbLayer.Controls.Add(this.cbLayerType);
            this.gbLayer.Controls.Add(this.bnSymmetryX);
            this.gbLayer.Controls.Add(this.bnSymetryY);
            this.gbLayer.Location = new System.Drawing.Point(4, 5);
            this.gbLayer.Name = "gbLayer";
            this.gbLayer.Size = new System.Drawing.Size(246, 113);
            this.gbLayer.TabIndex = 10;
            this.gbLayer.TabStop = false;
            this.gbLayer.Text = "Double-click a layer...";
            // 
            // chkbInterlayer
            // 
            this.chkbInterlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkbInterlayer.AutoSize = true;
            this.chkbInterlayer.Location = new System.Drawing.Point(8, 19);
            this.chkbInterlayer.Name = "chkbInterlayer";
            this.chkbInterlayer.Size = new System.Drawing.Size(69, 17);
            this.chkbInterlayer.TabIndex = 3;
            this.chkbInterlayer.Text = "Interlayer";
            this.chkbInterlayer.UseVisualStyleBackColor = true;
            this.chkbInterlayer.Click += new System.EventHandler(this.onChkbInterlayerClicked);
            // 
            // cbInterlayer
            // 
            this.cbInterlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbInterlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterlayer.FormattingEnabled = true;
            this.cbInterlayer.Location = new System.Drawing.Point(119, 17);
            this.cbInterlayer.Name = "cbInterlayer";
            this.cbInterlayer.Size = new System.Drawing.Size(121, 21);
            this.cbInterlayer.TabIndex = 4;
            this.cbInterlayer.SelectedIndexChanged += new System.EventHandler(this.onInterlayerChanged);
            // 
            // cbLayerType
            // 
            this.cbLayerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbLayerType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLayerType.FormattingEnabled = true;
            this.cbLayerType.ItemHeight = 58;
            this.cbLayerType.Location = new System.Drawing.Point(8, 45);
            this.cbLayerType.Name = "cbLayerType";
            this.cbLayerType.Size = new System.Drawing.Size(96, 64);
            this.cbLayerType.TabIndex = 7;
            this.cbLayerType.SelectedIndexChanged += new System.EventHandler(this.onLayerTypeChanged);
            // 
            // bnSymmetryX
            // 
            this.bnSymmetryX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnSymmetryX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnSymmetryX.Image = ((System.Drawing.Image)(resources.GetObject("bnSymmetryX.Image")));
            this.bnSymmetryX.Location = new System.Drawing.Point(108, 45);
            this.bnSymmetryX.Name = "bnSymmetryX";
            this.bnSymmetryX.Size = new System.Drawing.Size(64, 64);
            this.bnSymmetryX.TabIndex = 5;
            this.bnSymmetryX.UseVisualStyleBackColor = true;
            this.bnSymmetryX.Click += new System.EventHandler(this.onReflectionX);
            // 
            // bnSymetryY
            // 
            this.bnSymetryY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnSymetryY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnSymetryY.Image = ((System.Drawing.Image)(resources.GetObject("bnSymetryY.Image")));
            this.bnSymetryY.Location = new System.Drawing.Point(176, 45);
            this.bnSymetryY.Name = "bnSymetryY";
            this.bnSymetryY.Size = new System.Drawing.Size(64, 64);
            this.bnSymetryY.TabIndex = 6;
            this.bnSymetryY.UseVisualStyleBackColor = true;
            this.bnSymetryY.Click += new System.EventHandler(this.onReflectionY);
            // 
            // tbClickLayer
            // 
            this.tbClickLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbClickLayer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbClickLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClickLayer.Location = new System.Drawing.Point(5, 41);
            this.tbClickLayer.Multiline = true;
            this.tbClickLayer.Name = "tbClickLayer";
            this.tbClickLayer.Size = new System.Drawing.Size(246, 57);
            this.tbClickLayer.TabIndex = 13;
            this.tbClickLayer.Text = "Double-click a layer to edit pattern / orientation / interlayer.";
            // 
            // DockContentAnalysisCasePallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainerHoriz);
            this.Controls.Add(this.toolStripAnalysis);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DockContentAnalysisCasePallet";
            this.Text = "Case/Pallet analysis...";
            this.SizeChanged += new System.EventHandler(this.onSizeChanged);
            this.toolStripAnalysis.ResumeLayout(false);
            this.toolStripAnalysis.PerformLayout();
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).EndInit();
            this.gbStopCriterions.ResumeLayout(false);
            this.tabCtrl.ResumeLayout(false);
            this.tabPagePalletCorners.ResumeLayout(false);
            this.tabPagePalletCorners.PerformLayout();
            this.tabPagePalletCap.ResumeLayout(false);
            this.tabPagePalletCap.PerformLayout();
            this.tabPagePalletFilm.ResumeLayout(false);
            this.tabPagePalletFilm.PerformLayout();
            this.gbLayer.ResumeLayout(false);
            this.gbLayer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStrip toolStripAnalysis;
        private System.Windows.Forms.ToolStripButton toolStripButtonReportWord;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.SplitContainer splitContainerVert;
        private Graphics.Graphics3DControl graphCtrlSolution;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPagePalletCorners;
        private System.Windows.Forms.ComboBox cbPalletCorners;
        private System.Windows.Forms.CheckBox chkbPalletCorners;
        private System.Windows.Forms.TabPage tabPagePalletCap;
        private System.Windows.Forms.ComboBox cbPalletCap;
        private System.Windows.Forms.CheckBox chkbPalletCap;
        private System.Windows.Forms.TabPage tabPagePalletFilm;
        private System.Windows.Forms.ComboBox cbPalletFilm;
        private System.Windows.Forms.CheckBox chkbPalletFilm;
        private System.Windows.Forms.GroupBox gbLayer;
        private System.Windows.Forms.CheckBox chkbInterlayer;
        private System.Windows.Forms.ComboBox cbInterlayer;
        private treeDiM.StackBuilder.Graphics.Controls.CCtrlComboLayer cbLayerType;
        private System.Windows.Forms.Button bnSymmetryX;
        private System.Windows.Forms.Button bnSymetryY;
        private System.Windows.Forms.TextBox tbClickLayer;
        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.GroupBox gbStopCriterions;
        private Basics.UCtrlDouble uCtrlMaxPalletHeight;
        private Basics.UCtrlOptDouble uCtrlOptMaximumWeight;
        private System.Windows.Forms.ToolStripButton toolStripButtonBack;
        private System.Windows.Forms.ToolStripButton toolStripButtonReportHTML;
    }
}