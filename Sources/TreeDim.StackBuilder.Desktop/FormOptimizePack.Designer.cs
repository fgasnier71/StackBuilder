namespace treeDiM.StackBuilder.Desktop
{
    partial class FormOptimizePack
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptimizePack));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btClose = new System.Windows.Forms.Button();
            this.gbWrapper = new System.Windows.Forms.GroupBox();
            this.uCtrlTrayHeight = new treeDiM.Basics.UCtrlDouble();
            this.lbWrapperColor = new System.Windows.Forms.Label();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.cbWrapperType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uCtrlSurfacicMass = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlWallThickness = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlNoWalls = new treeDiM.Basics.UCtrlTriInt();
            this.gbPallet = new System.Windows.Forms.GroupBox();
            this.cbPallets = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.uCtrlOverhang = new treeDiM.Basics.UCtrlDualDouble();
            this.uCtrlPalletHeight = new treeDiM.Basics.UCtrlDouble();
            this.lbPalletDimensions = new System.Windows.Forms.Label();
            this.lbPallet = new System.Windows.Forms.Label();
            this.gridSolutions = new SourceGrid.Grid();
            this.gbCase = new System.Windows.Forms.GroupBox();
            this.uCtrlPackDimensionsMax = new treeDiM.Basics.UCtrlTriDouble();
            this.uCtrlPackDimensionsMin = new treeDiM.Basics.UCtrlTriDouble();
            this.btSetMaximum = new System.Windows.Forms.Button();
            this.btSetMinimum = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.cbBoxes = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.chkVerticalOrientationOnly = new System.Windows.Forms.CheckBox();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbBoxDimensions = new System.Windows.Forms.Label();
            this.lbBox = new System.Windows.Forms.Label();
            this.tbAnalysisDescription = new System.Windows.Forms.TextBox();
            this.lbAnalysisDescription = new System.Windows.Forms.Label();
            this.tbAnalysisName = new System.Windows.Forms.TextBox();
            this.lbAnalysisName = new System.Windows.Forms.Label();
            this.graphCtrlSolution = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.graphCtrlPack = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.bnCreateAnalysis = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this._timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gbWrapper.SuspendLayout();
            this.gbPallet.SuspendLayout();
            this.gbCase.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlPack)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.btClose);
            this.splitContainer.Panel1.Controls.Add(this.gbWrapper);
            this.splitContainer.Panel1.Controls.Add(this.gbPallet);
            this.splitContainer.Panel1.Controls.Add(this.gridSolutions);
            this.splitContainer.Panel1.Controls.Add(this.gbCase);
            this.splitContainer.Panel1.Controls.Add(this.groupBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tbAnalysisDescription);
            this.splitContainer.Panel2.Controls.Add(this.lbAnalysisDescription);
            this.splitContainer.Panel2.Controls.Add(this.tbAnalysisName);
            this.splitContainer.Panel2.Controls.Add(this.lbAnalysisName);
            this.splitContainer.Panel2.Controls.Add(this.graphCtrlSolution);
            this.splitContainer.Panel2.Controls.Add(this.graphCtrlPack);
            this.splitContainer.Panel2.Controls.Add(this.bnCreateAnalysis);
            // 
            // btClose
            // 
            resources.ApplyResources(this.btClose, "btClose");
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Name = "btClose";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // gbWrapper
            // 
            resources.ApplyResources(this.gbWrapper, "gbWrapper");
            this.gbWrapper.Controls.Add(this.uCtrlTrayHeight);
            this.gbWrapper.Controls.Add(this.lbWrapperColor);
            this.gbWrapper.Controls.Add(this.cbColor);
            this.gbWrapper.Controls.Add(this.cbWrapperType);
            this.gbWrapper.Controls.Add(this.label1);
            this.gbWrapper.Controls.Add(this.uCtrlSurfacicMass);
            this.gbWrapper.Controls.Add(this.uCtrlWallThickness);
            this.gbWrapper.Controls.Add(this.uCtrlNoWalls);
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
            this.uCtrlTrayHeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlTrayHeight.Value = 0D;
            this.uCtrlTrayHeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnDataChanged);
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
            resources.GetString("cbColor.Items28"),
            resources.GetString("cbColor.Items29"),
            resources.GetString("cbColor.Items30"),
            resources.GetString("cbColor.Items31"),
            resources.GetString("cbColor.Items32"),
            resources.GetString("cbColor.Items33"),
            resources.GetString("cbColor.Items34"),
            resources.GetString("cbColor.Items35"),
            resources.GetString("cbColor.Items36"),
            resources.GetString("cbColor.Items37"),
            resources.GetString("cbColor.Items38"),
            resources.GetString("cbColor.Items39"),
            resources.GetString("cbColor.Items40"),
            resources.GetString("cbColor.Items41")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.OnDataChanged);
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
            this.cbWrapperType.SelectedIndexChanged += new System.EventHandler(this.OnWrapperTypeChanged);
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
            this.uCtrlSurfacicMass.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_SURFACEMASS;
            this.uCtrlSurfacicMass.Value = 0D;
            this.uCtrlSurfacicMass.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnDataChanged);
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
            this.uCtrlWallThickness.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlWallThickness.Value = 0D;
            this.uCtrlWallThickness.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnDataChanged);
            // 
            // uCtrlNoWalls
            // 
            resources.ApplyResources(this.uCtrlNoWalls, "uCtrlNoWalls");
            this.uCtrlNoWalls.Name = "uCtrlNoWalls";
            this.uCtrlNoWalls.NoX = 1;
            this.uCtrlNoWalls.NoY = 1;
            this.uCtrlNoWalls.NoZ = 1;
            this.uCtrlNoWalls.ValueChanged += new treeDiM.Basics.UCtrlTriInt.ValueChangedDelegate(this.OnDataChanged);
            // 
            // gbPallet
            // 
            resources.ApplyResources(this.gbPallet, "gbPallet");
            this.gbPallet.Controls.Add(this.cbPallets);
            this.gbPallet.Controls.Add(this.uCtrlOverhang);
            this.gbPallet.Controls.Add(this.uCtrlPalletHeight);
            this.gbPallet.Controls.Add(this.lbPalletDimensions);
            this.gbPallet.Controls.Add(this.lbPallet);
            this.gbPallet.Name = "gbPallet";
            this.gbPallet.TabStop = false;
            // 
            // cbPallets
            // 
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            resources.ApplyResources(this.cbPallets, "cbPallets");
            this.cbPallets.Name = "cbPallets";
            this.cbPallets.SelectedIndexChanged += new System.EventHandler(this.OnPalletChanged);
            // 
            // uCtrlOverhang
            // 
            resources.ApplyResources(this.uCtrlOverhang, "uCtrlOverhang");
            this.uCtrlOverhang.MinValue = -10000D;
            this.uCtrlOverhang.Name = "uCtrlOverhang";
            this.uCtrlOverhang.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOverhang.ValueX = 0D;
            this.uCtrlOverhang.ValueY = 0D;
            this.uCtrlOverhang.ValueChanged += new treeDiM.Basics.UCtrlDualDouble.ValueChangedDelegate(this.OnDataChanged);
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
            this.uCtrlPalletHeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlPalletHeight.Value = 0D;
            this.uCtrlPalletHeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnDataChanged);
            // 
            // lbPalletDimensions
            // 
            resources.ApplyResources(this.lbPalletDimensions, "lbPalletDimensions");
            this.lbPalletDimensions.Name = "lbPalletDimensions";
            // 
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
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
            this.uCtrlPackDimensionsMax.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlPackDimensionsMax.ValueX = 0D;
            this.uCtrlPackDimensionsMax.ValueY = 0D;
            this.uCtrlPackDimensionsMax.ValueZ = 0D;
            this.uCtrlPackDimensionsMax.ValueChanged += new treeDiM.Basics.UCtrlTriDouble.ValueChangedDelegate(this.OnDataChanged);
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
            this.uCtrlPackDimensionsMin.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlPackDimensionsMin.ValueX = 0D;
            this.uCtrlPackDimensionsMin.ValueY = 0D;
            this.uCtrlPackDimensionsMin.ValueZ = 0D;
            this.uCtrlPackDimensionsMin.ValueChanged += new treeDiM.Basics.UCtrlTriDouble.ValueChangedDelegate(this.OnDataChanged);
            // 
            // btSetMaximum
            // 
            resources.ApplyResources(this.btSetMaximum, "btSetMaximum");
            this.btSetMaximum.Name = "btSetMaximum";
            this.btSetMaximum.UseVisualStyleBackColor = true;
            this.btSetMaximum.Click += new System.EventHandler(this.OnPalletChanged);
            // 
            // btSetMinimum
            // 
            resources.ApplyResources(this.btSetMinimum, "btSetMinimum");
            this.btSetMinimum.Name = "btSetMinimum";
            this.btSetMinimum.UseVisualStyleBackColor = true;
            this.btSetMinimum.Click += new System.EventHandler(this.OnBoxChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.cbBoxes);
            this.groupBox.Controls.Add(this.chkVerticalOrientationOnly);
            this.groupBox.Controls.Add(this.nudNumber);
            this.groupBox.Controls.Add(this.lbNumber);
            this.groupBox.Controls.Add(this.lbBoxDimensions);
            this.groupBox.Controls.Add(this.lbBox);
            resources.ApplyResources(this.groupBox, "groupBox");
            this.groupBox.Name = "groupBox";
            this.groupBox.TabStop = false;
            // 
            // cbBoxes
            // 
            this.cbBoxes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxes.FormattingEnabled = true;
            resources.ApplyResources(this.cbBoxes, "cbBoxes");
            this.cbBoxes.Name = "cbBoxes";
            this.cbBoxes.SelectedIndexChanged += new System.EventHandler(this.OnBoxChanged);
            // 
            // chkVerticalOrientationOnly
            // 
            resources.ApplyResources(this.chkVerticalOrientationOnly, "chkVerticalOrientationOnly");
            this.chkVerticalOrientationOnly.Name = "chkVerticalOrientationOnly";
            this.chkVerticalOrientationOnly.UseVisualStyleBackColor = true;
            this.chkVerticalOrientationOnly.CheckedChanged += new System.EventHandler(this.OnDataChanged);
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
            this.nudNumber.ValueChanged += new System.EventHandler(this.OnDataChanged);
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
            // lbBox
            // 
            resources.ApplyResources(this.lbBox, "lbBox");
            this.lbBox.Name = "lbBox";
            // 
            // tbAnalysisDescription
            // 
            resources.ApplyResources(this.tbAnalysisDescription, "tbAnalysisDescription");
            this.tbAnalysisDescription.Name = "tbAnalysisDescription";
            // 
            // lbAnalysisDescription
            // 
            resources.ApplyResources(this.lbAnalysisDescription, "lbAnalysisDescription");
            this.lbAnalysisDescription.Name = "lbAnalysisDescription";
            // 
            // tbAnalysisName
            // 
            resources.ApplyResources(this.tbAnalysisName, "tbAnalysisName");
            this.tbAnalysisName.Name = "tbAnalysisName";
            // 
            // lbAnalysisName
            // 
            resources.ApplyResources(this.lbAnalysisName, "lbAnalysisName");
            this.lbAnalysisName.Name = "lbAnalysisName";
            // 
            // graphCtrlSolution
            // 
            resources.ApplyResources(this.graphCtrlSolution, "graphCtrlSolution");
            this.graphCtrlSolution.Name = "graphCtrlSolution";
            this.graphCtrlSolution.Viewer = null;
            // 
            // graphCtrlPack
            // 
            resources.ApplyResources(this.graphCtrlPack, "graphCtrlPack");
            this.graphCtrlPack.Name = "graphCtrlPack";
            this.graphCtrlPack.Viewer = null;
            // 
            // bnCreateAnalysis
            // 
            resources.ApplyResources(this.bnCreateAnalysis, "bnCreateAnalysis");
            this.bnCreateAnalysis.Name = "bnCreateAnalysis";
            this.bnCreateAnalysis.UseVisualStyleBackColor = true;
            this.bnCreateAnalysis.Click += new System.EventHandler(this.OnCreateAnalysis);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            // 
            // _timer
            // 
            this._timer.Interval = 50;
            this._timer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // FormOptimizePack
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptimizePack";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.gbWrapper.ResumeLayout(false);
            this.gbWrapper.PerformLayout();
            this.gbPallet.ResumeLayout(false);
            this.gbPallet.PerformLayout();
            this.gbCase.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlPack)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox gbWrapper;
        private treeDiM.Basics.UCtrlDouble uCtrlTrayHeight;
        private System.Windows.Forms.Label lbWrapperColor;
        private System.Windows.Forms.ComboBox cbWrapperType;
        private System.Windows.Forms.Label label1;
        private treeDiM.Basics.UCtrlDouble uCtrlSurfacicMass;
        private treeDiM.Basics.UCtrlDouble uCtrlWallThickness;
        private treeDiM.Basics.UCtrlTriInt uCtrlNoWalls;
        private System.Windows.Forms.GroupBox gbPallet;
        private treeDiM.Basics.UCtrlDualDouble uCtrlOverhang;
        private treeDiM.Basics.UCtrlDouble uCtrlPalletHeight;
        private System.Windows.Forms.Label lbPalletDimensions;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.GroupBox gbCase;
        private treeDiM.Basics.UCtrlTriDouble uCtrlPackDimensionsMax;
        private treeDiM.Basics.UCtrlTriDouble uCtrlPackDimensionsMin;
        private System.Windows.Forms.Button btSetMaximum;
        private System.Windows.Forms.Button btSetMinimum;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.CheckBox chkVerticalOrientationOnly;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbBoxDimensions;
        private System.Windows.Forms.Label lbBox;
        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button bnCreateAnalysis;
        private Graphics.Graphics3DControl graphCtrlPack;
        private Graphics.Graphics3DControl graphCtrlSolution;
        private Graphics.Controls.CCtrlComboFiltered cbBoxes;
        private Graphics.Controls.CCtrlComboFiltered cbPallets;
        private System.Windows.Forms.TextBox tbAnalysisName;
        private System.Windows.Forms.Label lbAnalysisName;
        private System.Windows.Forms.TextBox tbAnalysisDescription;
        private System.Windows.Forms.Label lbAnalysisDescription;
        private System.Windows.Forms.Timer _timer;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
    }
}