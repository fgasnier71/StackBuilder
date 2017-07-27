namespace treeDiM.StackBuilder.Desktop
{
    partial class FormOptimizeCase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptimizeCase));
            this.splitContainerCasePallet = new System.Windows.Forms.SplitContainer();
            this.graphCtrlBoxesLayout = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.graphCtrlPallet = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.btClose = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.chkVerticalOrientationOnly = new System.Windows.Forms.CheckBox();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbBoxDimensions = new System.Windows.Forms.Label();
            this.cbBoxes = new System.Windows.Forms.ComboBox();
            this.lbBox = new System.Windows.Forms.Label();
            this.gbCase = new System.Windows.Forms.GroupBox();
            this.uCtrlPackDimensionsMax = new treeDiM.StackBuilder.Basics.UCtrlTriDouble();
            this.uCtrlPackDimensionsMin = new treeDiM.StackBuilder.Basics.UCtrlTriDouble();
            this.btSetMaximum = new System.Windows.Forms.Button();
            this.btSetMinimum = new System.Windows.Forms.Button();
            this.gbPallet = new System.Windows.Forms.GroupBox();
            this.uCtrlOverhang = new treeDiM.StackBuilder.Basics.UCtrlDualDouble();
            this.uCtrlPalletHeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.lbPalletDimensions = new System.Windows.Forms.Label();
            this.cbPallet = new System.Windows.Forms.ComboBox();
            this.lbPallet = new System.Windows.Forms.Label();
            this.btOptimize = new System.Windows.Forms.Button();
            this.gridSolutions = new SourceGrid.Grid();
            this.btAddCasePalletAnalysis = new System.Windows.Forms.Button();
            this.btAddPackPalletAnalysis = new System.Windows.Forms.Button();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbWrapper = new System.Windows.Forms.GroupBox();
            this.uCtrlTrayHeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.lbWrapperColor = new System.Windows.Forms.Label();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.cbWrapperType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uCtrlSurfacicMass = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlWallThickness = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlNoWalls = new treeDiM.StackBuilder.Basics.Controls.UCtrlTriInt();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCasePallet)).BeginInit();
            this.splitContainerCasePallet.Panel1.SuspendLayout();
            this.splitContainerCasePallet.Panel2.SuspendLayout();
            this.splitContainerCasePallet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlBoxesLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlPallet)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            this.gbCase.SuspendLayout();
            this.gbPallet.SuspendLayout();
            this.statusStripDef.SuspendLayout();
            this.gbWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerCasePallet
            // 
            resources.ApplyResources(this.splitContainerCasePallet, "splitContainerCasePallet");
            this.splitContainerCasePallet.Name = "splitContainerCasePallet";
            // 
            // splitContainerCasePallet.Panel1
            // 
            this.splitContainerCasePallet.Panel1.Controls.Add(this.graphCtrlBoxesLayout);
            // 
            // splitContainerCasePallet.Panel2
            // 
            this.splitContainerCasePallet.Panel2.Controls.Add(this.graphCtrlPallet);
            // 
            // graphCtrlBoxesLayout
            // 
            resources.ApplyResources(this.graphCtrlBoxesLayout, "graphCtrlBoxesLayout");
            this.graphCtrlBoxesLayout.Name = "graphCtrlBoxesLayout";
            this.graphCtrlBoxesLayout.TabStop = false;
            this.graphCtrlBoxesLayout.Viewer = null;
            // 
            // graphCtrlPallet
            // 
            resources.ApplyResources(this.graphCtrlPallet, "graphCtrlPallet");
            this.graphCtrlPallet.Name = "graphCtrlPallet";
            this.graphCtrlPallet.TabStop = false;
            this.graphCtrlPallet.Viewer = null;
            // 
            // btClose
            // 
            resources.ApplyResources(this.btClose, "btClose");
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Name = "btClose";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            resources.ApplyResources(this.groupBox, "groupBox");
            this.groupBox.Controls.Add(this.chkVerticalOrientationOnly);
            this.groupBox.Controls.Add(this.nudNumber);
            this.groupBox.Controls.Add(this.lbNumber);
            this.groupBox.Controls.Add(this.lbBoxDimensions);
            this.groupBox.Controls.Add(this.cbBoxes);
            this.groupBox.Controls.Add(this.lbBox);
            this.groupBox.Name = "groupBox";
            this.groupBox.TabStop = false;
            // 
            // chkVerticalOrientationOnly
            // 
            resources.ApplyResources(this.chkVerticalOrientationOnly, "chkVerticalOrientationOnly");
            this.chkVerticalOrientationOnly.Name = "chkVerticalOrientationOnly";
            this.chkVerticalOrientationOnly.UseVisualStyleBackColor = true;
            // 
            // nudNumber
            // 
            resources.ApplyResources(this.nudNumber, "nudNumber");
            this.nudNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNumber.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNumber.Name = "nudNumber";
            this.nudNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNumber.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // lbNumber
            // 
            resources.ApplyResources(this.lbNumber, "lbNumber");
            this.lbNumber.Name = "lbNumber";
            // 
            // lbBoxDimensions
            // 
            resources.ApplyResources(this.lbBoxDimensions, "lbBoxDimensions");
            this.lbBoxDimensions.Name = "lbBoxDimensions";
            // 
            // cbBoxes
            // 
            this.cbBoxes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxes.FormattingEnabled = true;
            resources.ApplyResources(this.cbBoxes, "cbBoxes");
            this.cbBoxes.Name = "cbBoxes";
            this.cbBoxes.SelectedIndexChanged += new System.EventHandler(this.onSelectedBoxChanged);
            // 
            // lbBox
            // 
            resources.ApplyResources(this.lbBox, "lbBox");
            this.lbBox.Name = "lbBox";
            // 
            // gbCase
            // 
            resources.ApplyResources(this.gbCase, "gbCase");
            this.gbCase.Controls.Add(this.uCtrlPackDimensionsMax);
            this.gbCase.Controls.Add(this.uCtrlPackDimensionsMin);
            this.gbCase.Controls.Add(this.btSetMaximum);
            this.gbCase.Controls.Add(this.btSetMinimum);
            this.gbCase.Name = "gbCase";
            this.gbCase.TabStop = false;
            // 
            // uCtrlPackDimensionsMax
            // 
            resources.ApplyResources(this.uCtrlPackDimensionsMax, "uCtrlPackDimensionsMax");
            this.uCtrlPackDimensionsMax.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlPackDimensionsMax.Name = "uCtrlPackDimensionsMax";
            this.uCtrlPackDimensionsMax.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlPackDimensionsMax.ValueX = 0D;
            this.uCtrlPackDimensionsMax.ValueY = 0D;
            this.uCtrlPackDimensionsMax.ValueZ = 0D;
            // 
            // uCtrlPackDimensionsMin
            // 
            resources.ApplyResources(this.uCtrlPackDimensionsMin, "uCtrlPackDimensionsMin");
            this.uCtrlPackDimensionsMin.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlPackDimensionsMin.Name = "uCtrlPackDimensionsMin";
            this.uCtrlPackDimensionsMin.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlPackDimensionsMin.ValueX = 0D;
            this.uCtrlPackDimensionsMin.ValueY = 0D;
            this.uCtrlPackDimensionsMin.ValueZ = 0D;
            // 
            // btSetMaximum
            // 
            resources.ApplyResources(this.btSetMaximum, "btSetMaximum");
            this.btSetMaximum.Name = "btSetMaximum";
            this.btSetMaximum.UseVisualStyleBackColor = true;
            this.btSetMaximum.Click += new System.EventHandler(this.btSetMaximum_Click);
            // 
            // btSetMinimum
            // 
            resources.ApplyResources(this.btSetMinimum, "btSetMinimum");
            this.btSetMinimum.Name = "btSetMinimum";
            this.btSetMinimum.UseVisualStyleBackColor = true;
            this.btSetMinimum.Click += new System.EventHandler(this.btSetMinimum_Click);
            // 
            // gbPallet
            // 
            resources.ApplyResources(this.gbPallet, "gbPallet");
            this.gbPallet.Controls.Add(this.uCtrlOverhang);
            this.gbPallet.Controls.Add(this.uCtrlPalletHeight);
            this.gbPallet.Controls.Add(this.lbPalletDimensions);
            this.gbPallet.Controls.Add(this.cbPallet);
            this.gbPallet.Controls.Add(this.lbPallet);
            this.gbPallet.Name = "gbPallet";
            this.gbPallet.TabStop = false;
            // 
            // uCtrlOverhang
            // 
            resources.ApplyResources(this.uCtrlOverhang, "uCtrlOverhang");
            this.uCtrlOverhang.Name = "uCtrlOverhang";
            this.uCtrlOverhang.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOverhang.ValueX = 0D;
            this.uCtrlOverhang.ValueY = 0D;
            // 
            // uCtrlPalletHeight
            // 
            resources.ApplyResources(this.uCtrlPalletHeight, "uCtrlPalletHeight");
            this.uCtrlPalletHeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlPalletHeight.Name = "uCtrlPalletHeight";
            this.uCtrlPalletHeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlPalletHeight.Value = 0D;
            // 
            // lbPalletDimensions
            // 
            resources.ApplyResources(this.lbPalletDimensions, "lbPalletDimensions");
            this.lbPalletDimensions.Name = "lbPalletDimensions";
            // 
            // cbPallet
            // 
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.FormattingEnabled = true;
            resources.ApplyResources(this.cbPallet, "cbPallet");
            this.cbPallet.Name = "cbPallet";
            this.cbPallet.SelectedIndexChanged += new System.EventHandler(this.onSelectedPalletChanged);
            // 
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
            // 
            // btOptimize
            // 
            resources.ApplyResources(this.btOptimize, "btOptimize");
            this.btOptimize.Name = "btOptimize";
            this.btOptimize.UseVisualStyleBackColor = true;
            this.btOptimize.Click += new System.EventHandler(this.onbuttonOptimize);
            // 
            // gridSolutions
            // 
            this.gridSolutions.AcceptsInputChar = false;
            resources.ApplyResources(this.gridSolutions, "gridSolutions");
            this.gridSolutions.EnableSort = true;
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // btAddCasePalletAnalysis
            // 
            resources.ApplyResources(this.btAddCasePalletAnalysis, "btAddCasePalletAnalysis");
            this.btAddCasePalletAnalysis.Name = "btAddCasePalletAnalysis";
            this.btAddCasePalletAnalysis.UseVisualStyleBackColor = true;
            this.btAddCasePalletAnalysis.Click += new System.EventHandler(this.btAddCasePalletAnalysis_Click);
            // 
            // btAddPackPalletAnalysis
            // 
            resources.ApplyResources(this.btAddPackPalletAnalysis, "btAddPackPalletAnalysis");
            this.btAddPackPalletAnalysis.Name = "btAddPackPalletAnalysis";
            this.btAddPackPalletAnalysis.UseVisualStyleBackColor = true;
            this.btAddPackPalletAnalysis.Click += new System.EventHandler(this.btAddPackPalletAnalysis_Click);
            // 
            // statusStripDef
            // 
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.Name = "statusStripDef";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            // 
            // gbWrapper
            // 
            this.gbWrapper.Controls.Add(this.uCtrlTrayHeight);
            this.gbWrapper.Controls.Add(this.lbWrapperColor);
            this.gbWrapper.Controls.Add(this.cbColor);
            this.gbWrapper.Controls.Add(this.cbWrapperType);
            this.gbWrapper.Controls.Add(this.label1);
            this.gbWrapper.Controls.Add(this.uCtrlSurfacicMass);
            this.gbWrapper.Controls.Add(this.uCtrlWallThickness);
            this.gbWrapper.Controls.Add(this.uCtrlNoWalls);
            resources.ApplyResources(this.gbWrapper, "gbWrapper");
            this.gbWrapper.Name = "gbWrapper";
            this.gbWrapper.TabStop = false;
            // 
            // uCtrlTrayHeight
            // 
            resources.ApplyResources(this.uCtrlTrayHeight, "uCtrlTrayHeight");
            this.uCtrlTrayHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlTrayHeight.Name = "uCtrlTrayHeight";
            this.uCtrlTrayHeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlTrayHeight.Value = 0D;
            // 
            // lbWrapperColor
            // 
            resources.ApplyResources(this.lbWrapperColor, "lbWrapperColor");
            this.lbWrapperColor.Name = "lbWrapperColor";
            // 
            // cbColor
            // 
            this.cbColor.Color = System.Drawing.Color.LightGray;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
            this.cbColor.FormattingEnabled = true;
            resources.ApplyResources(this.cbColor, "cbColor");
            this.cbColor.Items.AddRange(new object[] {
            resources.GetString("cbColor.Items"),
            resources.GetString("cbColor.Items1"),
            resources.GetString("cbColor.Items2"),
            resources.GetString("cbColor.Items3"),
            resources.GetString("cbColor.Items4"),
            resources.GetString("cbColor.Items5"),
            resources.GetString("cbColor.Items6"),
            resources.GetString("cbColor.Items7"),
            resources.GetString("cbColor.Items8"),
            resources.GetString("cbColor.Items9"),
            resources.GetString("cbColor.Items10"),
            resources.GetString("cbColor.Items11"),
            resources.GetString("cbColor.Items12"),
            resources.GetString("cbColor.Items13"),
            resources.GetString("cbColor.Items14"),
            resources.GetString("cbColor.Items15"),
            resources.GetString("cbColor.Items16"),
            resources.GetString("cbColor.Items17"),
            resources.GetString("cbColor.Items18"),
            resources.GetString("cbColor.Items19"),
            resources.GetString("cbColor.Items20"),
            resources.GetString("cbColor.Items21"),
            resources.GetString("cbColor.Items22"),
            resources.GetString("cbColor.Items23"),
            resources.GetString("cbColor.Items24"),
            resources.GetString("cbColor.Items25"),
            resources.GetString("cbColor.Items26"),
            resources.GetString("cbColor.Items27"),
            resources.GetString("cbColor.Items28")});
            this.cbColor.Name = "cbColor";
            // 
            // cbWrapperType
            // 
            this.cbWrapperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWrapperType.FormattingEnabled = true;
            this.cbWrapperType.Items.AddRange(new object[] {
            resources.GetString("cbWrapperType.Items"),
            resources.GetString("cbWrapperType.Items1"),
            resources.GetString("cbWrapperType.Items2"),
            resources.GetString("cbWrapperType.Items3")});
            resources.ApplyResources(this.cbWrapperType, "cbWrapperType");
            this.cbWrapperType.Name = "cbWrapperType";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // uCtrlSurfacicMass
            // 
            resources.ApplyResources(this.uCtrlSurfacicMass, "uCtrlSurfacicMass");
            this.uCtrlSurfacicMass.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlSurfacicMass.Name = "uCtrlSurfacicMass";
            this.uCtrlSurfacicMass.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_SURFACEMASS;
            this.uCtrlSurfacicMass.Value = 0D;
            // 
            // uCtrlWallThickness
            // 
            resources.ApplyResources(this.uCtrlWallThickness, "uCtrlWallThickness");
            this.uCtrlWallThickness.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlWallThickness.Name = "uCtrlWallThickness";
            this.uCtrlWallThickness.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlWallThickness.Value = 0D;
            // 
            // uCtrlNoWalls
            // 
            resources.ApplyResources(this.uCtrlNoWalls, "uCtrlNoWalls");
            this.uCtrlNoWalls.Name = "uCtrlNoWalls";
            this.uCtrlNoWalls.NoX = 1;
            this.uCtrlNoWalls.NoY = 1;
            this.uCtrlNoWalls.NoZ = 1;
            // 
            // FormOptimizeCase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbWrapper);
            this.Controls.Add(this.splitContainerCasePallet);
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.btAddCasePalletAnalysis);
            this.Controls.Add(this.btAddPackPalletAnalysis);
            this.Controls.Add(this.gridSolutions);
            this.Controls.Add(this.btOptimize);
            this.Controls.Add(this.gbPallet);
            this.Controls.Add(this.gbCase);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.btClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptimizeCase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOptimizeCase_FormClosing);
            this.Load += new System.EventHandler(this.FormOptimizeCase_Load);
            this.splitContainerCasePallet.Panel1.ResumeLayout(false);
            this.splitContainerCasePallet.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCasePallet)).EndInit();
            this.splitContainerCasePallet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlBoxesLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlPallet)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            this.gbCase.ResumeLayout(false);
            this.gbPallet.ResumeLayout(false);
            this.gbPallet.PerformLayout();
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.gbWrapper.ResumeLayout(false);
            this.gbWrapper.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ComboBox cbBoxes;
        private System.Windows.Forms.Label lbBox;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbBoxDimensions;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.GroupBox gbCase;
        private System.Windows.Forms.GroupBox gbPallet;
        private System.Windows.Forms.ComboBox cbPallet;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.Label lbPalletDimensions;
        private System.Windows.Forms.Button btOptimize;
        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private System.Windows.Forms.Button btSetMaximum;
        private System.Windows.Forms.Button btSetMinimum;
        private System.Windows.Forms.SplitContainer splitContainerCasePallet;
        private treeDiM.StackBuilder.Graphics.Graphics3DControl graphCtrlBoxesLayout;
        private treeDiM.StackBuilder.Graphics.Graphics3DControl graphCtrlPallet;
        private System.Windows.Forms.CheckBox chkVerticalOrientationOnly;
        private Basics.UCtrlDouble uCtrlPalletHeight;
        private System.Windows.Forms.Button btAddCasePalletAnalysis;
        private System.Windows.Forms.Button btAddPackPalletAnalysis;
        private Basics.UCtrlDualDouble uCtrlOverhang;
        private Basics.UCtrlTriDouble uCtrlPackDimensionsMin;
        private Basics.UCtrlTriDouble uCtrlPackDimensionsMax;
        private System.Windows.Forms.GroupBox gbWrapper;
        private Basics.Controls.UCtrlTriInt uCtrlNoWalls;
        private System.Windows.Forms.ComboBox cbWrapperType;
        private System.Windows.Forms.Label label1;
        private Basics.UCtrlDouble uCtrlSurfacicMass;
        private Basics.UCtrlDouble uCtrlWallThickness;
        private Basics.UCtrlDouble uCtrlTrayHeight;
        private System.Windows.Forms.Label lbWrapperColor;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
    }
}