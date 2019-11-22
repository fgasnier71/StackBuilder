namespace treeDiM.StackBuilder.Desktop
{
    partial class DockContentAnalysisHCylPallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentAnalysisHCylPallet));
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.graphCtrlSolution = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.gridSolution = new SourceGrid.Grid();
            this.uCtrlMaxWeight = new treeDiM.Basics.UCtrlOptDouble();
            this.uCtrlMaxNumber = new treeDiM.Basics.UCtrlOptInt();
            this.uCtrlMaxHeight = new treeDiM.Basics.UCtrlDouble();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripBBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripBReport = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerHoriz
            // 
            this.splitContainerHoriz.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainerHoriz.Panel2.Controls.Add(this.uCtrlMaxWeight);
            this.splitContainerHoriz.Panel2.Controls.Add(this.uCtrlMaxNumber);
            this.splitContainerHoriz.Panel2.Controls.Add(this.uCtrlMaxHeight);
            this.splitContainerHoriz.Size = new System.Drawing.Size(784, 536);
            this.splitContainerHoriz.SplitterDistance = 458;
            this.splitContainerHoriz.TabIndex = 1;
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
            this.splitContainerVert.Panel2.Controls.Add(this.gridSolution);
            this.splitContainerVert.Size = new System.Drawing.Size(784, 458);
            this.splitContainerVert.SplitterDistance = 628;
            this.splitContainerVert.TabIndex = 0;
            // 
            // graphCtrlSolution
            // 
            this.graphCtrlSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphCtrlSolution.Location = new System.Drawing.Point(0, 0);
            this.graphCtrlSolution.Name = "graphCtrlSolution";
            this.graphCtrlSolution.Size = new System.Drawing.Size(628, 458);
            this.graphCtrlSolution.TabIndex = 0;
            this.graphCtrlSolution.Viewer = null;
            // 
            // gridSolution
            // 
            this.gridSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSolution.EnableSort = true;
            this.gridSolution.Location = new System.Drawing.Point(0, 0);
            this.gridSolution.Name = "gridSolution";
            this.gridSolution.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolution.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridSolution.Size = new System.Drawing.Size(152, 458);
            this.gridSolution.TabIndex = 0;
            this.gridSolution.TabStop = true;
            this.gridSolution.ToolTipText = "";
            // 
            // uCtrlMaxWeight
            // 
            this.uCtrlMaxWeight.Location = new System.Drawing.Point(7, 28);
            this.uCtrlMaxWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMaxWeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMaxWeight.Name = "uCtrlMaxWeight";
            this.uCtrlMaxWeight.Size = new System.Drawing.Size(300, 20);
            this.uCtrlMaxWeight.TabIndex = 2;
            this.uCtrlMaxWeight.Text = "Maximum weight";
            this.uCtrlMaxWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlMaxWeight.ValueChanged += new treeDiM.Basics.UCtrlOptDouble.ValueChangedDelegate(this.OnCriterionChanged);
            // 
            // uCtrlMaxNumber
            // 
            this.uCtrlMaxNumber.Location = new System.Drawing.Point(7, 51);
            this.uCtrlMaxNumber.Minimum = -10000;
            this.uCtrlMaxNumber.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMaxNumber.Name = "uCtrlMaxNumber";
            this.uCtrlMaxNumber.Size = new System.Drawing.Size(300, 20);
            this.uCtrlMaxNumber.TabIndex = 1;
            this.uCtrlMaxNumber.Text = "Maximum number";
            this.uCtrlMaxNumber.ValueChanged += new treeDiM.Basics.UCtrlOptInt.ValueChangedDelegate(this.OnCriterionChanged);
            // 
            // uCtrlMaxHeight
            // 
            this.uCtrlMaxHeight.Location = new System.Drawing.Point(7, 5);
            this.uCtrlMaxHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMaxHeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMaxHeight.Name = "uCtrlMaxHeight";
            this.uCtrlMaxHeight.Size = new System.Drawing.Size(300, 20);
            this.uCtrlMaxHeight.TabIndex = 0;
            this.uCtrlMaxHeight.Text = "Maximum height";
            this.uCtrlMaxHeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMaxHeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnCriterionChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBBack,
            this.toolStripBReport});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(784, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripBBack
            // 
            this.toolStripBBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBBack.Image")));
            this.toolStripBBack.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripBBack.Name = "toolStripBBack";
            this.toolStripBBack.Size = new System.Drawing.Size(23, 22);
            this.toolStripBBack.Text = "Back...";
            // 
            // toolStripBReport
            // 
            this.toolStripBReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBReport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBReport.Image")));
            this.toolStripBReport.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripBReport.Name = "toolStripBReport";
            this.toolStripBReport.Size = new System.Drawing.Size(23, 22);
            this.toolStripBReport.Text = "Generate report...";
            // 
            // DockContentAnalysisHCylPallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainerHoriz);
            this.Controls.Add(this.toolStrip);
            this.Name = "DockContentAnalysisHCylPallet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Horizontal cylinders / pallet analysis...";
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripBBack;
        private System.Windows.Forms.ToolStripButton toolStripBReport;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.SplitContainer splitContainerVert;
        private Graphics.Graphics3DControl graphCtrlSolution;
        private SourceGrid.Grid gridSolution;
        private treeDiM.Basics.UCtrlOptDouble uCtrlMaxWeight;
        private treeDiM.Basics.UCtrlOptInt uCtrlMaxNumber;
        private treeDiM.Basics.UCtrlDouble uCtrlMaxHeight;
    }
}