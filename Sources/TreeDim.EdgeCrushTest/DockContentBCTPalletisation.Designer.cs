namespace treeDiM.EdgeCrushTest
{
    partial class DockContentBCTPalletisation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentBCTPalletisation));
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.chkbDblWall = new System.Windows.Forms.CheckBox();
            this.uCtrlOverhang = new treeDiM.Basics.UCtrlDualDouble();
            this.cbPallets = new System.Windows.Forms.ComboBox();
            this.uCtrlCaseWeight = new treeDiM.Basics.UCtrlDouble();
            this.lbPallet = new System.Windows.Forms.Label();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelMcKeeFormula = new System.Windows.Forms.ToolStripLabel();
            this.tsCBMcKeeFormula = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelProfile = new System.Windows.Forms.ToolStripLabel();
            this.tsCBProfile = new System.Windows.Forms.ToolStripComboBox();
            this.uCtrlCaseDimensions = new treeDiM.Basics.UCtrlTriDouble();
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.gridMat = new SourceGrid.Grid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbWeightLowestCase = new System.Windows.Forms.Label();
            this.lbDefWeightOnLowestCase = new System.Windows.Forms.Label();
            this.uCtrlNoLayers = new treeDiM.Basics.UCtrlInt();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.lbDefCount = new System.Windows.Forms.Label();
            this.lbStackWeight = new System.Windows.Forms.Label();
            this.lbDefWeight = new System.Windows.Forms.Label();
            this.lbStackCount = new System.Windows.Forms.Label();
            this.gbDynamicBCT = new System.Windows.Forms.GroupBox();
            this.lbPrintedArea = new System.Windows.Forms.Label();
            this.gridDynamicBCT = new SourceGrid.Grid();
            this.cbPrintedArea = new System.Windows.Forms.ComboBox();
            this.lbCountMax = new System.Windows.Forms.Label();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButtonReport = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.gbDynamicBCT.SuspendLayout();
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
            this.splitContainerHoriz.Panel1.Controls.Add(this.chkbDblWall);
            this.splitContainerHoriz.Panel1.Controls.Add(this.uCtrlOverhang);
            this.splitContainerHoriz.Panel1.Controls.Add(this.cbPallets);
            this.splitContainerHoriz.Panel1.Controls.Add(this.uCtrlCaseWeight);
            this.splitContainerHoriz.Panel1.Controls.Add(this.lbPallet);
            this.splitContainerHoriz.Panel1.Controls.Add(this.toolStripMain);
            this.splitContainerHoriz.Panel1.Controls.Add(this.uCtrlCaseDimensions);
            // 
            // splitContainerHoriz.Panel2
            // 
            resources.ApplyResources(this.splitContainerHoriz.Panel2, "splitContainerHoriz.Panel2");
            this.splitContainerHoriz.Panel2.Controls.Add(this.splitContainerVert);
            // 
            // chkbDblWall
            // 
            resources.ApplyResources(this.chkbDblWall, "chkbDblWall");
            this.chkbDblWall.Name = "chkbDblWall";
            this.chkbDblWall.UseVisualStyleBackColor = true;
            this.chkbDblWall.CheckedChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // uCtrlOverhang
            // 
            resources.ApplyResources(this.uCtrlOverhang, "uCtrlOverhang");
            this.uCtrlOverhang.MinValue = -10000D;
            this.uCtrlOverhang.Name = "uCtrlOverhang";
            this.uCtrlOverhang.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOverhang.ValueX = 0D;
            this.uCtrlOverhang.ValueY = 0D;
            this.uCtrlOverhang.ValueChanged += new treeDiM.Basics.UCtrlDualDouble.ValueChangedDelegate(this.OnComputePalletization);
            // 
            // cbPallets
            // 
            resources.ApplyResources(this.cbPallets, "cbPallets");
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            this.cbPallets.Name = "cbPallets";
            this.cbPallets.SelectedIndexChanged += new System.EventHandler(this.OnComputePalletization);
            // 
            // uCtrlCaseWeight
            // 
            resources.ApplyResources(this.uCtrlCaseWeight, "uCtrlCaseWeight");
            this.uCtrlCaseWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlCaseWeight.Name = "uCtrlCaseWeight";
            this.uCtrlCaseWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlCaseWeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnInputChanged);
            // 
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
            // 
            // toolStripMain
            // 
            resources.ApplyResources(this.toolStripMain, "toolStripMain");
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelMcKeeFormula,
            this.tsCBMcKeeFormula,
            this.toolStripSeparator1,
            this.toolStripLabelProfile,
            this.tsCBProfile,
            this.toolStripSeparator2,
            this.tsButtonReport});
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
            this.tsCBMcKeeFormula.BackColor = System.Drawing.SystemColors.Control;
            this.tsCBMcKeeFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCBMcKeeFormula.Items.AddRange(new object[] {
            resources.GetString("tsCBMcKeeFormula.Items"),
            resources.GetString("tsCBMcKeeFormula.Items1")});
            this.tsCBMcKeeFormula.Name = "tsCBMcKeeFormula";
            this.tsCBMcKeeFormula.SelectedIndexChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripLabelProfile
            // 
            resources.ApplyResources(this.toolStripLabelProfile, "toolStripLabelProfile");
            this.toolStripLabelProfile.Name = "toolStripLabelProfile";
            // 
            // tsCBProfile
            // 
            resources.ApplyResources(this.tsCBProfile, "tsCBProfile");
            this.tsCBProfile.BackColor = System.Drawing.SystemColors.Control;
            this.tsCBProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCBProfile.Name = "tsCBProfile";
            this.tsCBProfile.SelectedIndexChanged += new System.EventHandler(this.OnInputChanged);
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
            this.splitContainerVert.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerVert.Panel2.Controls.Add(this.lbCountMax);
            // 
            // gridMat
            // 
            resources.ApplyResources(this.gridMat, "gridMat");
            this.gridMat.EnableSort = false;
            this.gridMat.Name = "gridMat";
            this.gridMat.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridMat.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridMat.SpecialKeys = SourceGrid.GridSpecialKeys.PageDownUp;
            this.gridMat.TabStop = true;
            this.gridMat.ToolTipText = "";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.lbWeightLowestCase);
            this.splitContainer1.Panel1.Controls.Add(this.lbDefWeightOnLowestCase);
            this.splitContainer1.Panel1.Controls.Add(this.uCtrlNoLayers);
            this.splitContainer1.Panel1.Controls.Add(this.graphCtrl);
            this.splitContainer1.Panel1.Controls.Add(this.lbDefCount);
            this.splitContainer1.Panel1.Controls.Add(this.lbStackWeight);
            this.splitContainer1.Panel1.Controls.Add(this.lbDefWeight);
            this.splitContainer1.Panel1.Controls.Add(this.lbStackCount);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.gbDynamicBCT);
            // 
            // lbWeightLowestCase
            // 
            resources.ApplyResources(this.lbWeightLowestCase, "lbWeightLowestCase");
            this.lbWeightLowestCase.Name = "lbWeightLowestCase";
            // 
            // lbDefWeightOnLowestCase
            // 
            resources.ApplyResources(this.lbDefWeightOnLowestCase, "lbDefWeightOnLowestCase");
            this.lbDefWeightOnLowestCase.Name = "lbDefWeightOnLowestCase";
            // 
            // uCtrlNoLayers
            // 
            resources.ApplyResources(this.uCtrlNoLayers, "uCtrlNoLayers");
            this.uCtrlNoLayers.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.uCtrlNoLayers.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlNoLayers.Name = "uCtrlNoLayers";
            this.uCtrlNoLayers.ValueChanged += new treeDiM.Basics.UCtrlInt.ValueChangedDelegate(this.OnComputePalletization);
            // 
            // graphCtrl
            // 
            resources.ApplyResources(this.graphCtrl, "graphCtrl");
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.Viewer = null;
            // 
            // lbDefCount
            // 
            resources.ApplyResources(this.lbDefCount, "lbDefCount");
            this.lbDefCount.Name = "lbDefCount";
            // 
            // lbStackWeight
            // 
            resources.ApplyResources(this.lbStackWeight, "lbStackWeight");
            this.lbStackWeight.Name = "lbStackWeight";
            // 
            // lbDefWeight
            // 
            resources.ApplyResources(this.lbDefWeight, "lbDefWeight");
            this.lbDefWeight.Name = "lbDefWeight";
            // 
            // lbStackCount
            // 
            resources.ApplyResources(this.lbStackCount, "lbStackCount");
            this.lbStackCount.Name = "lbStackCount";
            // 
            // gbDynamicBCT
            // 
            resources.ApplyResources(this.gbDynamicBCT, "gbDynamicBCT");
            this.gbDynamicBCT.Controls.Add(this.lbPrintedArea);
            this.gbDynamicBCT.Controls.Add(this.gridDynamicBCT);
            this.gbDynamicBCT.Controls.Add(this.cbPrintedArea);
            this.gbDynamicBCT.Name = "gbDynamicBCT";
            this.gbDynamicBCT.TabStop = false;
            // 
            // lbPrintedArea
            // 
            resources.ApplyResources(this.lbPrintedArea, "lbPrintedArea");
            this.lbPrintedArea.Name = "lbPrintedArea";
            // 
            // gridDynamicBCT
            // 
            resources.ApplyResources(this.gridDynamicBCT, "gridDynamicBCT");
            this.gridDynamicBCT.EnableSort = true;
            this.gridDynamicBCT.Name = "gridDynamicBCT";
            this.gridDynamicBCT.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridDynamicBCT.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridDynamicBCT.TabStop = true;
            this.gridDynamicBCT.ToolTipText = "";
            // 
            // cbPrintedArea
            // 
            resources.ApplyResources(this.cbPrintedArea, "cbPrintedArea");
            this.cbPrintedArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrintedArea.FormattingEnabled = true;
            this.cbPrintedArea.Name = "cbPrintedArea";
            this.cbPrintedArea.SelectedIndexChanged += new System.EventHandler(this.OnComputePalletization);
            // 
            // lbCountMax
            // 
            resources.ApplyResources(this.lbCountMax, "lbCountMax");
            this.lbCountMax.Name = "lbCountMax";
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // tsButtonReport
            // 
            resources.ApplyResources(this.tsButtonReport, "tsButtonReport");
            this.tsButtonReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonReport.Name = "tsButtonReport";
            this.tsButtonReport.Click += new System.EventHandler(this.OnReport);
            // 
            // DockContentBCTPalletisation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerHoriz);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DockContentBCTPalletisation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel1.PerformLayout();
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            this.splitContainerVert.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.gbDynamicBCT.ResumeLayout(false);
            this.gbDynamicBCT.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.SplitContainer splitContainerVert;
        private Basics.UCtrlTriDouble uCtrlCaseDimensions;
        private SourceGrid.Grid gridMat;
        private SourceGrid.Grid gridDynamicBCT;
        private System.Windows.Forms.Label lbPrintedArea;
        private System.Windows.Forms.ComboBox cbPrintedArea;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMcKeeFormula;
        private System.Windows.Forms.ToolStripComboBox tsCBMcKeeFormula;
        private Basics.UCtrlDouble uCtrlCaseWeight;
        private Basics.UCtrlInt uCtrlNoLayers;
        private Basics.UCtrlDualDouble uCtrlOverhang;
        private System.Windows.Forms.ComboBox cbPallets;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.Label lbCountMax;
        private System.Windows.Forms.Label lbStackWeight;
        private System.Windows.Forms.Label lbStackCount;
        private System.Windows.Forms.Label lbDefWeight;
        private System.Windows.Forms.Label lbDefCount;
        private StackBuilder.Graphics.Graphics3DControl graphCtrl;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbDynamicBCT;
        private System.Windows.Forms.Label lbWeightLowestCase;
        private System.Windows.Forms.Label lbDefWeightOnLowestCase;
        private System.Windows.Forms.CheckBox chkbDblWall;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelProfile;
        private System.Windows.Forms.ToolStripComboBox tsCBProfile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsButtonReport;
    }
}