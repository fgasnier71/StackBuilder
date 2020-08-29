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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageWrapper = new System.Windows.Forms.TabPage();
            this.chkbWrapper = new System.Windows.Forms.CheckBox();
            this.uCtrlWrapperWalls = new treeDiM.Basics.UCtrlTriInt();
            this.cbWrapperColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbWrapperColor = new System.Windows.Forms.Label();
            this.uCtrlWrapperSurfMass = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlWrapperThickness = new treeDiM.Basics.UCtrlDouble();
            this.cbWrapperType = new System.Windows.Forms.ComboBox();
            this.tabPageTray = new System.Windows.Forms.TabPage();
            this.uCtrlTraySurfMass = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlTrayWalls = new treeDiM.Basics.UCtrlTriInt();
            this.uCtrlTrayThickness = new treeDiM.Basics.UCtrlDouble();
            this.chkbTray = new System.Windows.Forms.CheckBox();
            this.cbTrayColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.uCtrlTrayHeight = new treeDiM.Basics.UCtrlDouble();
            this.btClose = new System.Windows.Forms.Button();
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
            this.tabControl1.SuspendLayout();
            this.tabPageWrapper.SuspendLayout();
            this.tabPageTray.SuspendLayout();
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
            this.splitContainer.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer.Panel1.Controls.Add(this.btClose);
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
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPageWrapper);
            this.tabControl1.Controls.Add(this.tabPageTray);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPageWrapper
            // 
            this.tabPageWrapper.Controls.Add(this.chkbWrapper);
            this.tabPageWrapper.Controls.Add(this.uCtrlWrapperWalls);
            this.tabPageWrapper.Controls.Add(this.cbWrapperColor);
            this.tabPageWrapper.Controls.Add(this.lbWrapperColor);
            this.tabPageWrapper.Controls.Add(this.uCtrlWrapperSurfMass);
            this.tabPageWrapper.Controls.Add(this.uCtrlWrapperThickness);
            this.tabPageWrapper.Controls.Add(this.cbWrapperType);
            resources.ApplyResources(this.tabPageWrapper, "tabPageWrapper");
            this.tabPageWrapper.Name = "tabPageWrapper";
            this.tabPageWrapper.UseVisualStyleBackColor = true;
            // 
            // chkbWrapper
            // 
            resources.ApplyResources(this.chkbWrapper, "chkbWrapper");
            this.chkbWrapper.Name = "chkbWrapper";
            this.chkbWrapper.UseVisualStyleBackColor = true;
            this.chkbWrapper.CheckedChanged += new System.EventHandler(this.OnWrapperCheckChanged);
            // 
            // uCtrlWrapperWalls
            // 
            resources.ApplyResources(this.uCtrlWrapperWalls, "uCtrlWrapperWalls");
            this.uCtrlWrapperWalls.Name = "uCtrlWrapperWalls";
            this.uCtrlWrapperWalls.NoX = 1;
            this.uCtrlWrapperWalls.NoY = 1;
            this.uCtrlWrapperWalls.NoZ = 1;
            this.uCtrlWrapperWalls.ValueChanged += new treeDiM.Basics.UCtrlTriInt.ValueChangedDelegate(this.OnDataChanged);
            // 
            // cbWrapperColor
            // 
            this.cbWrapperColor.Color = System.Drawing.Color.LightGray;
            this.cbWrapperColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbWrapperColor.DropDownHeight = 1;
            this.cbWrapperColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWrapperColor.DropDownWidth = 1;
            this.cbWrapperColor.FormattingEnabled = true;
            resources.ApplyResources(this.cbWrapperColor, "cbWrapperColor");
            this.cbWrapperColor.Items.AddRange(new object[] {
            resources.GetString("cbWrapperColor.Items"),
            resources.GetString("cbWrapperColor.Items1"),
            resources.GetString("cbWrapperColor.Items2"),
            resources.GetString("cbWrapperColor.Items3"),
            resources.GetString("cbWrapperColor.Items4"),
            resources.GetString("cbWrapperColor.Items5"),
            resources.GetString("cbWrapperColor.Items6"),
            resources.GetString("cbWrapperColor.Items7"),
            resources.GetString("cbWrapperColor.Items8"),
            resources.GetString("cbWrapperColor.Items9"),
            resources.GetString("cbWrapperColor.Items10"),
            resources.GetString("cbWrapperColor.Items11"),
            resources.GetString("cbWrapperColor.Items12"),
            resources.GetString("cbWrapperColor.Items13"),
            resources.GetString("cbWrapperColor.Items14"),
            resources.GetString("cbWrapperColor.Items15"),
            resources.GetString("cbWrapperColor.Items16"),
            resources.GetString("cbWrapperColor.Items17"),
            resources.GetString("cbWrapperColor.Items18"),
            resources.GetString("cbWrapperColor.Items19"),
            resources.GetString("cbWrapperColor.Items20"),
            resources.GetString("cbWrapperColor.Items21"),
            resources.GetString("cbWrapperColor.Items22"),
            resources.GetString("cbWrapperColor.Items23"),
            resources.GetString("cbWrapperColor.Items24"),
            resources.GetString("cbWrapperColor.Items25"),
            resources.GetString("cbWrapperColor.Items26"),
            resources.GetString("cbWrapperColor.Items27"),
            resources.GetString("cbWrapperColor.Items28"),
            resources.GetString("cbWrapperColor.Items29"),
            resources.GetString("cbWrapperColor.Items30"),
            resources.GetString("cbWrapperColor.Items31"),
            resources.GetString("cbWrapperColor.Items32"),
            resources.GetString("cbWrapperColor.Items33"),
            resources.GetString("cbWrapperColor.Items34"),
            resources.GetString("cbWrapperColor.Items35"),
            resources.GetString("cbWrapperColor.Items36"),
            resources.GetString("cbWrapperColor.Items37"),
            resources.GetString("cbWrapperColor.Items38"),
            resources.GetString("cbWrapperColor.Items39"),
            resources.GetString("cbWrapperColor.Items40"),
            resources.GetString("cbWrapperColor.Items41"),
            resources.GetString("cbWrapperColor.Items42"),
            resources.GetString("cbWrapperColor.Items43"),
            resources.GetString("cbWrapperColor.Items44"),
            resources.GetString("cbWrapperColor.Items45")});
            this.cbWrapperColor.Name = "cbWrapperColor";
            this.cbWrapperColor.SelectedColorChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // lbWrapperColor
            // 
            resources.ApplyResources(this.lbWrapperColor, "lbWrapperColor");
            this.lbWrapperColor.Name = "lbWrapperColor";
            // 
            // uCtrlWrapperSurfMass
            // 
            resources.ApplyResources(this.uCtrlWrapperSurfMass, "uCtrlWrapperSurfMass");
            this.uCtrlWrapperSurfMass.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlWrapperSurfMass.Name = "uCtrlWrapperSurfMass";
            this.uCtrlWrapperSurfMass.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_SURFACEMASS;
            this.uCtrlWrapperSurfMass.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnDataChanged);
            // 
            // uCtrlWrapperThickness
            // 
            resources.ApplyResources(this.uCtrlWrapperThickness, "uCtrlWrapperThickness");
            this.uCtrlWrapperThickness.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlWrapperThickness.Name = "uCtrlWrapperThickness";
            this.uCtrlWrapperThickness.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlWrapperThickness.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnDataChanged);
            // 
            // cbWrapperType
            // 
            this.cbWrapperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWrapperType.FormattingEnabled = true;
            this.cbWrapperType.Items.AddRange(new object[] {
            resources.GetString("cbWrapperType.Items"),
            resources.GetString("cbWrapperType.Items1"),
            resources.GetString("cbWrapperType.Items2")});
            resources.ApplyResources(this.cbWrapperType, "cbWrapperType");
            this.cbWrapperType.Name = "cbWrapperType";
            this.cbWrapperType.SelectedIndexChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // tabPageTray
            // 
            this.tabPageTray.Controls.Add(this.uCtrlTraySurfMass);
            this.tabPageTray.Controls.Add(this.uCtrlTrayWalls);
            this.tabPageTray.Controls.Add(this.uCtrlTrayThickness);
            this.tabPageTray.Controls.Add(this.chkbTray);
            this.tabPageTray.Controls.Add(this.cbTrayColor);
            this.tabPageTray.Controls.Add(this.uCtrlTrayHeight);
            resources.ApplyResources(this.tabPageTray, "tabPageTray");
            this.tabPageTray.Name = "tabPageTray";
            this.tabPageTray.UseVisualStyleBackColor = true;
            // 
            // uCtrlTraySurfMass
            // 
            resources.ApplyResources(this.uCtrlTraySurfMass, "uCtrlTraySurfMass");
            this.uCtrlTraySurfMass.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlTraySurfMass.Name = "uCtrlTraySurfMass";
            this.uCtrlTraySurfMass.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_SURFACEMASS;
            // 
            // uCtrlTrayWalls
            // 
            resources.ApplyResources(this.uCtrlTrayWalls, "uCtrlTrayWalls");
            this.uCtrlTrayWalls.Name = "uCtrlTrayWalls";
            this.uCtrlTrayWalls.NoX = 1;
            this.uCtrlTrayWalls.NoY = 1;
            this.uCtrlTrayWalls.NoZ = 1;
            // 
            // uCtrlTrayThickness
            // 
            resources.ApplyResources(this.uCtrlTrayThickness, "uCtrlTrayThickness");
            this.uCtrlTrayThickness.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlTrayThickness.Name = "uCtrlTrayThickness";
            this.uCtrlTrayThickness.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            // 
            // chkbTray
            // 
            resources.ApplyResources(this.chkbTray, "chkbTray");
            this.chkbTray.Name = "chkbTray";
            this.chkbTray.UseVisualStyleBackColor = true;
            this.chkbTray.CheckedChanged += new System.EventHandler(this.OnTrayCheckChanged);
            // 
            // cbTrayColor
            // 
            this.cbTrayColor.Color = System.Drawing.Color.LightGray;
            this.cbTrayColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTrayColor.DropDownHeight = 1;
            this.cbTrayColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrayColor.DropDownWidth = 1;
            this.cbTrayColor.FormattingEnabled = true;
            resources.ApplyResources(this.cbTrayColor, "cbTrayColor");
            this.cbTrayColor.Items.AddRange(new object[] {
            resources.GetString("cbTrayColor.Items"),
            resources.GetString("cbTrayColor.Items1"),
            resources.GetString("cbTrayColor.Items2"),
            resources.GetString("cbTrayColor.Items3"),
            resources.GetString("cbTrayColor.Items4"),
            resources.GetString("cbTrayColor.Items5"),
            resources.GetString("cbTrayColor.Items6"),
            resources.GetString("cbTrayColor.Items7"),
            resources.GetString("cbTrayColor.Items8"),
            resources.GetString("cbTrayColor.Items9"),
            resources.GetString("cbTrayColor.Items10"),
            resources.GetString("cbTrayColor.Items11"),
            resources.GetString("cbTrayColor.Items12"),
            resources.GetString("cbTrayColor.Items13"),
            resources.GetString("cbTrayColor.Items14"),
            resources.GetString("cbTrayColor.Items15"),
            resources.GetString("cbTrayColor.Items16"),
            resources.GetString("cbTrayColor.Items17"),
            resources.GetString("cbTrayColor.Items18"),
            resources.GetString("cbTrayColor.Items19"),
            resources.GetString("cbTrayColor.Items20"),
            resources.GetString("cbTrayColor.Items21"),
            resources.GetString("cbTrayColor.Items22"),
            resources.GetString("cbTrayColor.Items23"),
            resources.GetString("cbTrayColor.Items24"),
            resources.GetString("cbTrayColor.Items25"),
            resources.GetString("cbTrayColor.Items26"),
            resources.GetString("cbTrayColor.Items27"),
            resources.GetString("cbTrayColor.Items28"),
            resources.GetString("cbTrayColor.Items29"),
            resources.GetString("cbTrayColor.Items30"),
            resources.GetString("cbTrayColor.Items31"),
            resources.GetString("cbTrayColor.Items32"),
            resources.GetString("cbTrayColor.Items33"),
            resources.GetString("cbTrayColor.Items34"),
            resources.GetString("cbTrayColor.Items35"),
            resources.GetString("cbTrayColor.Items36"),
            resources.GetString("cbTrayColor.Items37"),
            resources.GetString("cbTrayColor.Items38"),
            resources.GetString("cbTrayColor.Items39"),
            resources.GetString("cbTrayColor.Items40"),
            resources.GetString("cbTrayColor.Items41"),
            resources.GetString("cbTrayColor.Items42"),
            resources.GetString("cbTrayColor.Items43"),
            resources.GetString("cbTrayColor.Items44"),
            resources.GetString("cbTrayColor.Items45"),
            resources.GetString("cbTrayColor.Items46"),
            resources.GetString("cbTrayColor.Items47")});
            this.cbTrayColor.Name = "cbTrayColor";
            // 
            // uCtrlTrayHeight
            // 
            resources.ApplyResources(this.uCtrlTrayHeight, "uCtrlTrayHeight");
            this.uCtrlTrayHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uCtrlTrayHeight.Name = "uCtrlTrayHeight";
            this.uCtrlTrayHeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            // 
            // btClose
            // 
            resources.ApplyResources(this.btClose, "btClose");
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Name = "btClose";
            this.btClose.UseVisualStyleBackColor = true;
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
            this.tabControl1.ResumeLayout(false);
            this.tabPageWrapper.ResumeLayout(false);
            this.tabPageWrapper.PerformLayout();
            this.tabPageTray.ResumeLayout(false);
            this.tabPageTray.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageWrapper;
        private System.Windows.Forms.TabPage tabPageTray;
        private System.Windows.Forms.CheckBox chkbWrapper;
        private treeDiM.Basics.UCtrlTriInt uCtrlWrapperWalls;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbWrapperColor;
        private System.Windows.Forms.Label lbWrapperColor;
        private treeDiM.Basics.UCtrlDouble uCtrlWrapperSurfMass;
        private treeDiM.Basics.UCtrlDouble uCtrlWrapperThickness;
        private System.Windows.Forms.ComboBox cbWrapperType;
        private treeDiM.Basics.UCtrlDouble uCtrlTraySurfMass;
        private treeDiM.Basics.UCtrlTriInt uCtrlTrayWalls;
        private treeDiM.Basics.UCtrlDouble uCtrlTrayThickness;
        private System.Windows.Forms.CheckBox chkbTray;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbTrayColor;
        private treeDiM.Basics.UCtrlDouble uCtrlTrayHeight;
    }
}