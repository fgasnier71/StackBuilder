namespace treeDiM.EdgeCrushTest
{
    partial class DockContentReverseBCT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentReverseBCT));
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.uCtrlForceApplied = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlCaseDimensions = new treeDiM.Basics.UCtrlTriDouble();
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.gridMat = new SourceGrid.Grid();
            this.gbDynamicBCT = new System.Windows.Forms.GroupBox();
            this.lbPrintedArea = new System.Windows.Forms.Label();
            this.cbPrintedArea = new System.Windows.Forms.ComboBox();
            this.gridDynamicBCT = new SourceGrid.Grid();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelMcKeeFormula = new System.Windows.Forms.ToolStripLabel();
            this.tsCBMcKeeFormula = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            this.gbDynamicBCT.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerHoriz
            // 
            resources.ApplyResources(this.splitContainerHoriz, "splitContainerHoriz");
            this.splitContainerHoriz.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerHoriz.Name = "splitContainerHoriz";
            // 
            // splitContainerHoriz.Panel1
            // 
            resources.ApplyResources(this.splitContainerHoriz.Panel1, "splitContainerHoriz.Panel1");
            this.splitContainerHoriz.Panel1.Controls.Add(this.uCtrlForceApplied);
            this.splitContainerHoriz.Panel1.Controls.Add(this.uCtrlCaseDimensions);
            // 
            // splitContainerHoriz.Panel2
            // 
            resources.ApplyResources(this.splitContainerHoriz.Panel2, "splitContainerHoriz.Panel2");
            this.splitContainerHoriz.Panel2.Controls.Add(this.splitContainerVert);
            // 
            // uCtrlForceApplied
            // 
            resources.ApplyResources(this.uCtrlForceApplied, "uCtrlForceApplied");
            this.uCtrlForceApplied.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlForceApplied.Name = "uCtrlForceApplied";
            this.uCtrlForceApplied.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_FORCE;
            this.uCtrlForceApplied.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnInputChanged);
            // 
            // uCtrlCaseDimensions
            // 
            resources.ApplyResources(this.uCtrlCaseDimensions, "uCtrlCaseDimensions");
            this.uCtrlCaseDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlCaseDimensions.Name = "uCtrlCaseDimensions";
            this.uCtrlCaseDimensions.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlCaseDimensions.ValueX = 0D;
            this.uCtrlCaseDimensions.ValueY = 0D;
            this.uCtrlCaseDimensions.ValueZ = 0D;
            this.uCtrlCaseDimensions.ValueChanged += new treeDiM.Basics.UCtrlTriDouble.ValueChangedDelegate(this.OnInputChanged);
            // 
            // splitContainerVert
            // 
            resources.ApplyResources(this.splitContainerVert, "splitContainerVert");
            this.splitContainerVert.Name = "splitContainerVert";
            // 
            // splitContainerVert.Panel1
            // 
            resources.ApplyResources(this.splitContainerVert.Panel1, "splitContainerVert.Panel1");
            this.splitContainerVert.Panel1.Controls.Add(this.gridMat);
            // 
            // splitContainerVert.Panel2
            // 
            resources.ApplyResources(this.splitContainerVert.Panel2, "splitContainerVert.Panel2");
            this.splitContainerVert.Panel2.Controls.Add(this.gbDynamicBCT);
            // 
            // gridMat
            // 
            resources.ApplyResources(this.gridMat, "gridMat");
            this.gridMat.EnableSort = false;
            this.gridMat.Name = "gridMat";
            this.gridMat.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridMat.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridMat.TabStop = true;
            this.gridMat.ToolTipText = "";
            // 
            // gbDynamicBCT
            // 
            resources.ApplyResources(this.gbDynamicBCT, "gbDynamicBCT");
            this.gbDynamicBCT.Controls.Add(this.lbPrintedArea);
            this.gbDynamicBCT.Controls.Add(this.cbPrintedArea);
            this.gbDynamicBCT.Controls.Add(this.gridDynamicBCT);
            this.gbDynamicBCT.Name = "gbDynamicBCT";
            this.gbDynamicBCT.TabStop = false;
            // 
            // lbPrintedArea
            // 
            resources.ApplyResources(this.lbPrintedArea, "lbPrintedArea");
            this.lbPrintedArea.Name = "lbPrintedArea";
            // 
            // cbPrintedArea
            // 
            resources.ApplyResources(this.cbPrintedArea, "cbPrintedArea");
            this.cbPrintedArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrintedArea.FormattingEnabled = true;
            this.cbPrintedArea.Name = "cbPrintedArea";
            this.cbPrintedArea.SelectedIndexChanged += new System.EventHandler(this.OnComputeDynamicBCT);
            // 
            // gridDynamicBCT
            // 
            resources.ApplyResources(this.gridDynamicBCT, "gridDynamicBCT");
            this.gridDynamicBCT.EnableSort = false;
            this.gridDynamicBCT.Name = "gridDynamicBCT";
            this.gridDynamicBCT.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridDynamicBCT.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridDynamicBCT.TabStop = true;
            this.gridDynamicBCT.ToolTipText = "";
            // 
            // toolStripMain
            // 
            resources.ApplyResources(this.toolStripMain, "toolStripMain");
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelMcKeeFormula,
            this.tsCBMcKeeFormula});
            this.toolStripMain.Name = "toolStripMain";
            // 
            // toolStripLabelMcKeeFormula
            // 
            resources.ApplyResources(this.toolStripLabelMcKeeFormula, "toolStripLabelMcKeeFormula");
            this.toolStripLabelMcKeeFormula.Name = "toolStripLabelMcKeeFormula";
            // 
            // tsCBMcKeeFormula
            // 
            resources.ApplyResources(this.tsCBMcKeeFormula, "tsCBMcKeeFormula");
            this.tsCBMcKeeFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCBMcKeeFormula.Items.AddRange(new object[] {
            resources.GetString("tsCBMcKeeFormula.Items"),
            resources.GetString("tsCBMcKeeFormula.Items1")});
            this.tsCBMcKeeFormula.Name = "tsCBMcKeeFormula";
            this.tsCBMcKeeFormula.SelectedIndexChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // DockContentReverseBCT
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerHoriz);
            this.Controls.Add(this.toolStripMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DockContentReverseBCT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            this.gbDynamicBCT.ResumeLayout(false);
            this.gbDynamicBCT.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMcKeeFormula;
        private System.Windows.Forms.ToolStripComboBox tsCBMcKeeFormula;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private Basics.UCtrlDouble uCtrlForceApplied;
        private Basics.UCtrlTriDouble uCtrlCaseDimensions;
        private System.Windows.Forms.SplitContainer splitContainerVert;
        private SourceGrid.Grid gridMat;
        private System.Windows.Forms.GroupBox gbDynamicBCT;
        private SourceGrid.Grid gridDynamicBCT;
        private System.Windows.Forms.Label lbPrintedArea;
        private System.Windows.Forms.ComboBox cbPrintedArea;
    }
}