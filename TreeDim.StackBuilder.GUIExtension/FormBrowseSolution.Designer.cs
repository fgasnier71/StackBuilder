namespace treeDiM.StackBuilder.GUIExtension
{
    partial class FormBrowseSolution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBrowseSolution));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExport = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.gbStopCriterions = new System.Windows.Forms.GroupBox();
            this.uCtrlOptMaximumWeight = new treeDiM.StackBuilder.Basics.UCtrlOptDouble();
            this.uCtrlMaxPalletHeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.gbLayer = new System.Windows.Forms.GroupBox();
            this.cbLayerType = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboLayer();
            this.bnSymmetryX = new System.Windows.Forms.Button();
            this.bnSymetryY = new System.Windows.Forms.Button();
            this.tbClickLayer = new System.Windows.Forms.TextBox();
            this.gridSolution = new SourceGrid.Grid();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.gbStopCriterions.SuspendLayout();
            this.gbLayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonReport,
            this.toolStripButtonExport});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(984, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonReport
            // 
            this.toolStripButtonReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReport.Image")));
            this.toolStripButtonReport.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonReport.Name = "toolStripButtonReport";
            this.toolStripButtonReport.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonReport.Text = "Generate report...";
            this.toolStripButtonReport.Click += new System.EventHandler(this.onGenerateReport);
            // 
            // toolStripButtonExport
            // 
            this.toolStripButtonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExport.Image")));
            this.toolStripButtonExport.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonExport.Name = "toolStripButtonExport";
            this.toolStripButtonExport.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExport.Text = "Export to StackBuilder...";
            this.toolStripButtonExport.Click += new System.EventHandler(this.onExport);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainerHoriz);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridSolution);
            this.splitContainer1.Size = new System.Drawing.Size(984, 536);
            this.splitContainer1.SplitterDistance = 704;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainerHoriz
            // 
            this.splitContainerHoriz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerHoriz.Location = new System.Drawing.Point(0, 0);
            this.splitContainerHoriz.Name = "splitContainerHoriz";
            this.splitContainerHoriz.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerHoriz.Panel1
            // 
            this.splitContainerHoriz.Panel1.Controls.Add(this.graphCtrl);
            // 
            // splitContainerHoriz.Panel2
            // 
            this.splitContainerHoriz.Panel2.Controls.Add(this.gbStopCriterions);
            this.splitContainerHoriz.Panel2.Controls.Add(this.gbLayer);
            this.splitContainerHoriz.Panel2.Controls.Add(this.tbClickLayer);
            this.splitContainerHoriz.Size = new System.Drawing.Size(704, 536);
            this.splitContainerHoriz.SplitterDistance = 432;
            this.splitContainerHoriz.TabIndex = 1;
            // 
            // graphCtrl
            // 
            this.graphCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphCtrl.Location = new System.Drawing.Point(0, 0);
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.Size = new System.Drawing.Size(704, 432);
            this.graphCtrl.TabIndex = 0;
            this.graphCtrl.Viewer = null;
            // 
            // gbStopCriterions
            // 
            this.gbStopCriterions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbStopCriterions.Controls.Add(this.uCtrlOptMaximumWeight);
            this.gbStopCriterions.Controls.Add(this.uCtrlMaxPalletHeight);
            this.gbStopCriterions.Location = new System.Drawing.Point(252, 9);
            this.gbStopCriterions.Name = "gbStopCriterions";
            this.gbStopCriterions.Size = new System.Drawing.Size(213, 83);
            this.gbStopCriterions.TabIndex = 17;
            this.gbStopCriterions.TabStop = false;
            this.gbStopCriterions.Text = "Stop criterions";
            // 
            // uCtrlOptMaximumWeight
            // 
            this.uCtrlOptMaximumWeight.Location = new System.Drawing.Point(4, 41);
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
            this.uCtrlMaxPalletHeight.Location = new System.Drawing.Point(4, 14);
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
            // gbLayer
            // 
            this.gbLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbLayer.Controls.Add(this.cbLayerType);
            this.gbLayer.Controls.Add(this.bnSymmetryX);
            this.gbLayer.Controls.Add(this.bnSymetryY);
            this.gbLayer.Location = new System.Drawing.Point(4, 9);
            this.gbLayer.Name = "gbLayer";
            this.gbLayer.Size = new System.Drawing.Size(246, 83);
            this.gbLayer.TabIndex = 16;
            this.gbLayer.TabStop = false;
            this.gbLayer.Text = "Double-click a layer...";
            // 
            // cbLayerType
            // 
            this.cbLayerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbLayerType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLayerType.FormattingEnabled = true;
            this.cbLayerType.ItemHeight = 58;
            this.cbLayerType.Location = new System.Drawing.Point(8, 15);
            this.cbLayerType.Name = "cbLayerType";
            this.cbLayerType.Size = new System.Drawing.Size(96, 64);
            this.cbLayerType.TabIndex = 7;
            // 
            // bnSymmetryX
            // 
            this.bnSymmetryX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnSymmetryX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnSymmetryX.Image = ((System.Drawing.Image)(resources.GetObject("bnSymmetryX.Image")));
            this.bnSymmetryX.Location = new System.Drawing.Point(108, 15);
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
            this.bnSymetryY.Location = new System.Drawing.Point(176, 15);
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
            this.tbClickLayer.Location = new System.Drawing.Point(4, 25);
            this.tbClickLayer.Multiline = true;
            this.tbClickLayer.Name = "tbClickLayer";
            this.tbClickLayer.Size = new System.Drawing.Size(246, 57);
            this.tbClickLayer.TabIndex = 18;
            this.tbClickLayer.Text = "Double-click a layer to edit pattern / orientation / interlayer.";
            // 
            // gridSolution
            // 
            this.gridSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSolution.EnableSort = true;
            this.gridSolution.Location = new System.Drawing.Point(0, 0);
            this.gridSolution.Name = "gridSolution";
            this.gridSolution.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolution.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridSolution.Size = new System.Drawing.Size(276, 536);
            this.gridSolution.TabIndex = 0;
            this.gridSolution.TabStop = true;
            this.gridSolution.ToolTipText = "";
            // 
            // saveFileDialogExport
            // 
            this.saveFileDialogExport.DefaultExt = "stb";
            this.saveFileDialogExport.Filter = "StackBuilder|*.stb|All files|*.*";
            // 
            // FormBrowseSolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBrowseSolution";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Browse solution...";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.gbStopCriterions.ResumeLayout(false);
            this.gbLayer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonReport;
        private System.Windows.Forms.ToolStripButton toolStripButtonExport;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Graphics.Graphics3DControl graphCtrl;
        private SourceGrid.Grid gridSolution;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.GroupBox gbStopCriterions;
        private Basics.UCtrlOptDouble uCtrlOptMaximumWeight;
        private Basics.UCtrlDouble uCtrlMaxPalletHeight;
        private System.Windows.Forms.GroupBox gbLayer;
        private Graphics.Controls.CCtrlComboLayer cbLayerType;
        private System.Windows.Forms.Button bnSymmetryX;
        private System.Windows.Forms.Button bnSymetryY;
        private System.Windows.Forms.TextBox tbClickLayer;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExport;
    }
}