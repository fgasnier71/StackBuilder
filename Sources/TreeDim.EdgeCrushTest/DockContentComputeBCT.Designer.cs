namespace treeDiM.EdgeCrushTest
{
    partial class DockContentComputeBCT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentComputeBCT));
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.uCtrlOverhang = new treeDiM.Basics.UCtrlDualDouble();
            this.cbPallets = new System.Windows.Forms.ComboBox();
            this.uCtrlCaseWeight = new treeDiM.Basics.UCtrlDouble();
            this.lbPallet = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonMaterialList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelMcKeeFormula = new System.Windows.Forms.ToolStripLabel();
            this.tsCBMcKeeFormula = new System.Windows.Forms.ToolStripComboBox();
            this.uCtrlCaseDimensions = new treeDiM.Basics.UCtrlTriDouble();
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.gridMat = new SourceGrid.Grid();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.lbStackWeight = new System.Windows.Forms.Label();
            this.lbStackCount = new System.Windows.Forms.Label();
            this.lbDefWeight = new System.Windows.Forms.Label();
            this.lbDefCount = new System.Windows.Forms.Label();
            this.lbCountMax = new System.Windows.Forms.Label();
            this.uCtrlNoLayers = new treeDiM.Basics.UCtrlInt();
            this.lbPrintedArea = new System.Windows.Forms.Label();
            this.cbPrintedArea = new System.Windows.Forms.ComboBox();
            this.gridDynamicBCT = new SourceGrid.Grid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
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
            this.splitContainerHoriz.Panel1.Controls.Add(this.uCtrlOverhang);
            this.splitContainerHoriz.Panel1.Controls.Add(this.cbPallets);
            this.splitContainerHoriz.Panel1.Controls.Add(this.uCtrlCaseWeight);
            this.splitContainerHoriz.Panel1.Controls.Add(this.lbPallet);
            this.splitContainerHoriz.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerHoriz.Panel1.Controls.Add(this.uCtrlCaseDimensions);
            // 
            // splitContainerHoriz.Panel2
            // 
            resources.ApplyResources(this.splitContainerHoriz.Panel2, "splitContainerHoriz.Panel2");
            this.splitContainerHoriz.Panel2.Controls.Add(this.splitContainerVert);
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
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMaterialList,
            this.toolStripSeparator1,
            this.toolStripLabelMcKeeFormula,
            this.tsCBMcKeeFormula});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButtonMaterialList
            // 
            resources.ApplyResources(this.toolStripButtonMaterialList, "toolStripButtonMaterialList");
            this.toolStripButtonMaterialList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMaterialList.Name = "toolStripButtonMaterialList";
            this.toolStripButtonMaterialList.Click += new System.EventHandler(this.OnEditMaterialList);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
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
            this.splitContainerVert.Panel2.Controls.Add(this.graphCtrl);
            this.splitContainerVert.Panel2.Controls.Add(this.lbStackWeight);
            this.splitContainerVert.Panel2.Controls.Add(this.lbStackCount);
            this.splitContainerVert.Panel2.Controls.Add(this.lbDefWeight);
            this.splitContainerVert.Panel2.Controls.Add(this.lbDefCount);
            this.splitContainerVert.Panel2.Controls.Add(this.lbCountMax);
            this.splitContainerVert.Panel2.Controls.Add(this.uCtrlNoLayers);
            this.splitContainerVert.Panel2.Controls.Add(this.lbPrintedArea);
            this.splitContainerVert.Panel2.Controls.Add(this.cbPrintedArea);
            this.splitContainerVert.Panel2.Controls.Add(this.gridDynamicBCT);
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
            // graphCtrl
            // 
            resources.ApplyResources(this.graphCtrl, "graphCtrl");
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.Viewer = null;
            // 
            // lbStackWeight
            // 
            resources.ApplyResources(this.lbStackWeight, "lbStackWeight");
            this.lbStackWeight.Name = "lbStackWeight";
            // 
            // lbStackCount
            // 
            resources.ApplyResources(this.lbStackCount, "lbStackCount");
            this.lbStackCount.Name = "lbStackCount";
            // 
            // lbDefWeight
            // 
            resources.ApplyResources(this.lbDefWeight, "lbDefWeight");
            this.lbDefWeight.Name = "lbDefWeight";
            // 
            // lbDefCount
            // 
            resources.ApplyResources(this.lbDefCount, "lbDefCount");
            this.lbDefCount.Name = "lbDefCount";
            // 
            // lbCountMax
            // 
            resources.ApplyResources(this.lbCountMax, "lbCountMax");
            this.lbCountMax.Name = "lbCountMax";
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
            this.cbPrintedArea.SelectedIndexChanged += new System.EventHandler(this.OnComputePalletization);
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
            // DockContentComputeBCT
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerHoriz);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DockContentComputeBCT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel1.PerformLayout();
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            this.splitContainerVert.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonMaterialList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
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
    }
}