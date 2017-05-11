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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btClose = new System.Windows.Forms.Button();
            this.gbWrapper = new System.Windows.Forms.GroupBox();
            this.uCtrlTrayHeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.lbWrapperColor = new System.Windows.Forms.Label();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.cbWrapperType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uCtrlSurfacicMass = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlWallThickness = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlNoWalls = new treeDiM.StackBuilder.Basics.Controls.UCtrlTriInt();
            this.gbPallet = new System.Windows.Forms.GroupBox();
            this.cbPallets = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.uCtrlOverhang = new treeDiM.StackBuilder.Basics.UCtrlDualDouble();
            this.uCtrlPalletHeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.lbPalletDimensions = new System.Windows.Forms.Label();
            this.lbPallet = new System.Windows.Forms.Label();
            this.gridSolutions = new SourceGrid.Grid();
            this.gbCase = new System.Windows.Forms.GroupBox();
            this.uCtrlPackDimensionsMax = new treeDiM.StackBuilder.Basics.UCtrlTriDouble();
            this.uCtrlPackDimensionsMin = new treeDiM.StackBuilder.Basics.UCtrlTriDouble();
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
            this._timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStrip.Location = new System.Drawing.Point(0, 719);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(634, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            this.toolStripStatusLabelDef.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabelDef.Text = "toolStripStatusLabelDef";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
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
            this.splitContainer.Size = new System.Drawing.Size(634, 719);
            this.splitContainer.SplitterDistance = 509;
            this.splitContainer.TabIndex = 1;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btClose.Location = new System.Drawing.Point(556, 3);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 17;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // gbWrapper
            // 
            this.gbWrapper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWrapper.Controls.Add(this.uCtrlTrayHeight);
            this.gbWrapper.Controls.Add(this.lbWrapperColor);
            this.gbWrapper.Controls.Add(this.cbColor);
            this.gbWrapper.Controls.Add(this.cbWrapperType);
            this.gbWrapper.Controls.Add(this.label1);
            this.gbWrapper.Controls.Add(this.uCtrlSurfacicMass);
            this.gbWrapper.Controls.Add(this.uCtrlWallThickness);
            this.gbWrapper.Controls.Add(this.uCtrlNoWalls);
            this.gbWrapper.Location = new System.Drawing.Point(3, 226);
            this.gbWrapper.Name = "gbWrapper";
            this.gbWrapper.Size = new System.Drawing.Size(628, 118);
            this.gbWrapper.TabIndex = 16;
            this.gbWrapper.TabStop = false;
            this.gbWrapper.Text = "Wrapper";
            // 
            // uCtrlTrayHeight
            // 
            this.uCtrlTrayHeight.Location = new System.Drawing.Point(331, 38);
            this.uCtrlTrayHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlTrayHeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlTrayHeight.Name = "uCtrlTrayHeight";
            this.uCtrlTrayHeight.Size = new System.Drawing.Size(237, 20);
            this.uCtrlTrayHeight.TabIndex = 30;
            this.uCtrlTrayHeight.Text = "Tray height";
            this.uCtrlTrayHeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlTrayHeight.Value = 0D;
            this.uCtrlTrayHeight.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.onValueChanged(this.onDataChanged);
            // 
            // lbWrapperColor
            // 
            this.lbWrapperColor.AutoSize = true;
            this.lbWrapperColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbWrapperColor.Location = new System.Drawing.Point(331, 16);
            this.lbWrapperColor.Name = "lbWrapperColor";
            this.lbWrapperColor.Size = new System.Drawing.Size(31, 13);
            this.lbWrapperColor.TabIndex = 29;
            this.lbWrapperColor.Text = "Color";
            // 
            // cbColor
            // 
            this.cbColor.Color = System.Drawing.Color.LightGray;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.IntegralHeight = false;
            this.cbColor.ItemHeight = 16;
            this.cbColor.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color"});
            this.cbColor.Location = new System.Drawing.Point(470, 11);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(61, 22);
            this.cbColor.TabIndex = 28;
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.onDataChanged);
            // 
            // cbWrapperType
            // 
            this.cbWrapperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWrapperType.FormattingEnabled = true;
            this.cbWrapperType.Items.AddRange(new object[] {
            "Polyethylene",
            "Paper",
            "Cardboard",
            "Tray"});
            this.cbWrapperType.Location = new System.Drawing.Point(114, 12);
            this.cbWrapperType.Name = "cbWrapperType";
            this.cbWrapperType.Size = new System.Drawing.Size(195, 21);
            this.cbWrapperType.TabIndex = 27;
            this.cbWrapperType.SelectedIndexChanged += new System.EventHandler(this.onWrapperTypeChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Wrapper type";
            // 
            // uCtrlSurfacicMass
            // 
            this.uCtrlSurfacicMass.Location = new System.Drawing.Point(9, 91);
            this.uCtrlSurfacicMass.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlSurfacicMass.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlSurfacicMass.Name = "uCtrlSurfacicMass";
            this.uCtrlSurfacicMass.Size = new System.Drawing.Size(203, 20);
            this.uCtrlSurfacicMass.TabIndex = 25;
            this.uCtrlSurfacicMass.Text = "Surfacic mass";
            this.uCtrlSurfacicMass.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_SURFACEMASS;
            this.uCtrlSurfacicMass.Value = 0D;
            this.uCtrlSurfacicMass.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.onValueChanged(this.onDataChanged);
            // 
            // uCtrlWallThickness
            // 
            this.uCtrlWallThickness.Location = new System.Drawing.Point(9, 64);
            this.uCtrlWallThickness.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlWallThickness.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlWallThickness.Name = "uCtrlWallThickness";
            this.uCtrlWallThickness.Size = new System.Drawing.Size(203, 20);
            this.uCtrlWallThickness.TabIndex = 24;
            this.uCtrlWallThickness.Text = "Wall thickness";
            this.uCtrlWallThickness.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlWallThickness.Value = 0D;
            this.uCtrlWallThickness.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.onValueChanged(this.onDataChanged);
            // 
            // uCtrlNoWalls
            // 
            this.uCtrlNoWalls.Location = new System.Drawing.Point(9, 38);
            this.uCtrlNoWalls.Name = "uCtrlNoWalls";
            this.uCtrlNoWalls.NoX = 1;
            this.uCtrlNoWalls.NoY = 1;
            this.uCtrlNoWalls.NoZ = 1;
            this.uCtrlNoWalls.Size = new System.Drawing.Size(300, 20);
            this.uCtrlNoWalls.TabIndex = 23;
            this.uCtrlNoWalls.Text = "Number of walls";
            this.uCtrlNoWalls.ValueChanged += new treeDiM.StackBuilder.Basics.Controls.UCtrlTriInt.onValueChanged(this.onDataChanged);
            // 
            // gbPallet
            // 
            this.gbPallet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPallet.Controls.Add(this.cbPallets);
            this.gbPallet.Controls.Add(this.uCtrlOverhang);
            this.gbPallet.Controls.Add(this.uCtrlPalletHeight);
            this.gbPallet.Controls.Add(this.lbPalletDimensions);
            this.gbPallet.Controls.Add(this.lbPallet);
            this.gbPallet.Location = new System.Drawing.Point(327, 31);
            this.gbPallet.Name = "gbPallet";
            this.gbPallet.Size = new System.Drawing.Size(304, 116);
            this.gbPallet.TabIndex = 15;
            this.gbPallet.TabStop = false;
            this.gbPallet.Text = "Pallet";
            // 
            // cbPallets
            // 
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            this.cbPallets.Location = new System.Drawing.Point(73, 19);
            this.cbPallets.Name = "cbPallets";
            this.cbPallets.Size = new System.Drawing.Size(188, 21);
            this.cbPallets.TabIndex = 5;
            this.cbPallets.SelectedIndexChanged += new System.EventHandler(this.onPalletChanged);
            // 
            // uCtrlOverhang
            // 
            this.uCtrlOverhang.Location = new System.Drawing.Point(6, 88);
            this.uCtrlOverhang.Name = "uCtrlOverhang";
            this.uCtrlOverhang.Size = new System.Drawing.Size(292, 20);
            this.uCtrlOverhang.TabIndex = 4;
            this.uCtrlOverhang.Text = "Overhang";
            this.uCtrlOverhang.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOverhang.ValueX = 0D;
            this.uCtrlOverhang.ValueY = 0D;
            this.uCtrlOverhang.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDualDouble.onValueChanged(this.onDataChanged);
            // 
            // uCtrlPalletHeight
            // 
            this.uCtrlPalletHeight.Location = new System.Drawing.Point(6, 62);
            this.uCtrlPalletHeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlPalletHeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlPalletHeight.Name = "uCtrlPalletHeight";
            this.uCtrlPalletHeight.Size = new System.Drawing.Size(292, 20);
            this.uCtrlPalletHeight.TabIndex = 3;
            this.uCtrlPalletHeight.Text = "Maximum pallet height";
            this.uCtrlPalletHeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlPalletHeight.Value = 0D;
            this.uCtrlPalletHeight.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.onValueChanged(this.onDataChanged);
            // 
            // lbPalletDimensions
            // 
            this.lbPalletDimensions.AutoSize = true;
            this.lbPalletDimensions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPalletDimensions.Location = new System.Drawing.Point(76, 43);
            this.lbPalletDimensions.Name = "lbPalletDimensions";
            this.lbPalletDimensions.Size = new System.Drawing.Size(65, 13);
            this.lbPalletDimensions.TabIndex = 2;
            this.lbPalletDimensions.Text = "(dimensions)";
            // 
            // lbPallet
            // 
            this.lbPallet.AutoSize = true;
            this.lbPallet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPallet.Location = new System.Drawing.Point(8, 19);
            this.lbPallet.Name = "lbPallet";
            this.lbPallet.Size = new System.Drawing.Size(33, 13);
            this.lbPallet.TabIndex = 0;
            this.lbPallet.Text = "Pallet";
            // 
            // gridSolutions
            // 
            this.gridSolutions.AcceptsInputChar = false;
            this.gridSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSolutions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gridSolutions.EnableSort = true;
            this.gridSolutions.Location = new System.Drawing.Point(0, 350);
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridSolutions.Size = new System.Drawing.Size(634, 159);
            this.gridSolutions.TabIndex = 6;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // gbCase
            // 
            this.gbCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCase.Controls.Add(this.uCtrlPackDimensionsMax);
            this.gbCase.Controls.Add(this.uCtrlPackDimensionsMin);
            this.gbCase.Controls.Add(this.btSetMaximum);
            this.gbCase.Controls.Add(this.btSetMinimum);
            this.gbCase.Location = new System.Drawing.Point(3, 152);
            this.gbCase.Name = "gbCase";
            this.gbCase.Size = new System.Drawing.Size(628, 69);
            this.gbCase.TabIndex = 14;
            this.gbCase.TabStop = false;
            this.gbCase.Text = "Pack constraints";
            // 
            // uCtrlPackDimensionsMax
            // 
            this.uCtrlPackDimensionsMax.Location = new System.Drawing.Point(11, 42);
            this.uCtrlPackDimensionsMax.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlPackDimensionsMax.Name = "uCtrlPackDimensionsMax";
            this.uCtrlPackDimensionsMax.Size = new System.Drawing.Size(410, 20);
            this.uCtrlPackDimensionsMax.TabIndex = 24;
            this.uCtrlPackDimensionsMax.Text = "Max. pack dimensions";
            this.uCtrlPackDimensionsMax.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlPackDimensionsMax.ValueX = 0D;
            this.uCtrlPackDimensionsMax.ValueY = 0D;
            this.uCtrlPackDimensionsMax.ValueZ = 0D;
            this.uCtrlPackDimensionsMax.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlTriDouble.onValueChanged(this.onDataChanged);
            // 
            // uCtrlPackDimensionsMin
            // 
            this.uCtrlPackDimensionsMin.Location = new System.Drawing.Point(11, 16);
            this.uCtrlPackDimensionsMin.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlPackDimensionsMin.Name = "uCtrlPackDimensionsMin";
            this.uCtrlPackDimensionsMin.Size = new System.Drawing.Size(410, 20);
            this.uCtrlPackDimensionsMin.TabIndex = 23;
            this.uCtrlPackDimensionsMin.Text = "Min. pack dimensions";
            this.uCtrlPackDimensionsMin.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlPackDimensionsMin.ValueX = 0D;
            this.uCtrlPackDimensionsMin.ValueY = 0D;
            this.uCtrlPackDimensionsMin.ValueZ = 0D;
            this.uCtrlPackDimensionsMin.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlTriDouble.onValueChanged(this.onDataChanged);
            // 
            // btSetMaximum
            // 
            this.btSetMaximum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btSetMaximum.Location = new System.Drawing.Point(426, 43);
            this.btSetMaximum.Name = "btSetMaximum";
            this.btSetMaximum.Size = new System.Drawing.Size(112, 21);
            this.btSetMaximum.TabIndex = 18;
            this.btSetMaximum.Text = "Set maximum";
            this.btSetMaximum.UseVisualStyleBackColor = true;
            this.btSetMaximum.Click += new System.EventHandler(this.onPalletChanged);
            // 
            // btSetMinimum
            // 
            this.btSetMinimum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btSetMinimum.Location = new System.Drawing.Point(426, 16);
            this.btSetMinimum.Name = "btSetMinimum";
            this.btSetMinimum.Size = new System.Drawing.Size(112, 21);
            this.btSetMinimum.TabIndex = 17;
            this.btSetMinimum.Text = "Set minimum";
            this.btSetMinimum.UseVisualStyleBackColor = true;
            this.btSetMinimum.Click += new System.EventHandler(this.onBoxChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.cbBoxes);
            this.groupBox.Controls.Add(this.chkVerticalOrientationOnly);
            this.groupBox.Controls.Add(this.nudNumber);
            this.groupBox.Controls.Add(this.lbNumber);
            this.groupBox.Controls.Add(this.lbBoxDimensions);
            this.groupBox.Controls.Add(this.lbBox);
            this.groupBox.Location = new System.Drawing.Point(3, 30);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(318, 117);
            this.groupBox.TabIndex = 13;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Box (inner product)";
            // 
            // cbBoxes
            // 
            this.cbBoxes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxes.FormattingEnabled = true;
            this.cbBoxes.Location = new System.Drawing.Point(74, 20);
            this.cbBoxes.Name = "cbBoxes";
            this.cbBoxes.Size = new System.Drawing.Size(183, 21);
            this.cbBoxes.TabIndex = 6;
            this.cbBoxes.SelectedIndexChanged += new System.EventHandler(this.onBoxChanged);
            // 
            // chkVerticalOrientationOnly
            // 
            this.chkVerticalOrientationOnly.AutoSize = true;
            this.chkVerticalOrientationOnly.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkVerticalOrientationOnly.Location = new System.Drawing.Point(16, 84);
            this.chkVerticalOrientationOnly.Name = "chkVerticalOrientationOnly";
            this.chkVerticalOrientationOnly.Size = new System.Drawing.Size(183, 17);
            this.chkVerticalOrientationOnly.TabIndex = 5;
            this.chkVerticalOrientationOnly.Text = "Only allow vertical box orientation";
            this.chkVerticalOrientationOnly.UseVisualStyleBackColor = true;
            this.chkVerticalOrientationOnly.CheckedChanged += new System.EventHandler(this.onDataChanged);
            // 
            // nudNumber
            // 
            this.nudNumber.Location = new System.Drawing.Point(191, 59);
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
            this.nudNumber.Size = new System.Drawing.Size(66, 20);
            this.nudNumber.TabIndex = 4;
            this.nudNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNumber.ValueChanged += new System.EventHandler(this.onDataChanged);
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbNumber.Location = new System.Drawing.Point(13, 63);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(131, 13);
            this.lbNumber.TabIndex = 3;
            this.lbNumber.Text = "Number of boxes per case";
            // 
            // lbBoxDimensions
            // 
            this.lbBoxDimensions.AutoSize = true;
            this.lbBoxDimensions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbBoxDimensions.Location = new System.Drawing.Point(78, 44);
            this.lbBoxDimensions.Name = "lbBoxDimensions";
            this.lbBoxDimensions.Size = new System.Drawing.Size(85, 13);
            this.lbBoxDimensions.TabIndex = 2;
            this.lbBoxDimensions.Text = "(box dimensions)";
            // 
            // lbBox
            // 
            this.lbBox.AutoSize = true;
            this.lbBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbBox.Location = new System.Drawing.Point(15, 20);
            this.lbBox.Name = "lbBox";
            this.lbBox.Size = new System.Drawing.Size(25, 13);
            this.lbBox.TabIndex = 0;
            this.lbBox.Text = "Box";
            // 
            // tbAnalysisDescription
            // 
            this.tbAnalysisDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAnalysisDescription.Location = new System.Drawing.Point(119, 182);
            this.tbAnalysisDescription.Name = "tbAnalysisDescription";
            this.tbAnalysisDescription.Size = new System.Drawing.Size(374, 20);
            this.tbAnalysisDescription.TabIndex = 14;
            // 
            // lbAnalysisDescription
            // 
            this.lbAnalysisDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbAnalysisDescription.AutoSize = true;
            this.lbAnalysisDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAnalysisDescription.Location = new System.Drawing.Point(6, 186);
            this.lbAnalysisDescription.Name = "lbAnalysisDescription";
            this.lbAnalysisDescription.Size = new System.Drawing.Size(99, 13);
            this.lbAnalysisDescription.TabIndex = 13;
            this.lbAnalysisDescription.Text = "Analysis description";
            // 
            // tbAnalysisName
            // 
            this.tbAnalysisName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAnalysisName.Location = new System.Drawing.Point(118, 156);
            this.tbAnalysisName.Name = "tbAnalysisName";
            this.tbAnalysisName.Size = new System.Drawing.Size(159, 20);
            this.tbAnalysisName.TabIndex = 12;
            // 
            // lbAnalysisName
            // 
            this.lbAnalysisName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbAnalysisName.AutoSize = true;
            this.lbAnalysisName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAnalysisName.Location = new System.Drawing.Point(5, 160);
            this.lbAnalysisName.Name = "lbAnalysisName";
            this.lbAnalysisName.Size = new System.Drawing.Size(74, 13);
            this.lbAnalysisName.TabIndex = 11;
            this.lbAnalysisName.Text = "Analysis name";
            // 
            // graphCtrlSolution
            // 
            this.graphCtrlSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphCtrlSolution.Location = new System.Drawing.Point(318, 3);
            this.graphCtrlSolution.Name = "graphCtrlSolution";
            this.graphCtrlSolution.Size = new System.Drawing.Size(316, 147);
            this.graphCtrlSolution.TabIndex = 9;
            this.graphCtrlSolution.Viewer = null;
            // 
            // graphCtrlPack
            // 
            this.graphCtrlPack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.graphCtrlPack.Location = new System.Drawing.Point(3, 3);
            this.graphCtrlPack.Name = "graphCtrlPack";
            this.graphCtrlPack.Size = new System.Drawing.Size(309, 147);
            this.graphCtrlPack.TabIndex = 8;
            this.graphCtrlPack.Viewer = null;
            // 
            // bnCreateAnalysis
            // 
            this.bnCreateAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCreateAnalysis.Location = new System.Drawing.Point(500, 179);
            this.bnCreateAnalysis.Name = "bnCreateAnalysis";
            this.bnCreateAnalysis.Size = new System.Drawing.Size(131, 23);
            this.bnCreateAnalysis.TabIndex = 7;
            this.bnCreateAnalysis.Text = "Create analysis";
            this.bnCreateAnalysis.UseVisualStyleBackColor = true;
            this.bnCreateAnalysis.Click += new System.EventHandler(this.onCreateAnalysis);
            // 
            // _timer
            // 
            this._timer.Interval = 50;
            this._timer.Tick += new System.EventHandler(this.onTimerTick);
            // 
            // FormOptimizePack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 741);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 780);
            this.Name = "FormOptimizePack";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Find optimal pack...";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox gbWrapper;
        private Basics.UCtrlDouble uCtrlTrayHeight;
        private System.Windows.Forms.Label lbWrapperColor;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.ComboBox cbWrapperType;
        private System.Windows.Forms.Label label1;
        private Basics.UCtrlDouble uCtrlSurfacicMass;
        private Basics.UCtrlDouble uCtrlWallThickness;
        private Basics.Controls.UCtrlTriInt uCtrlNoWalls;
        private System.Windows.Forms.GroupBox gbPallet;
        private Basics.UCtrlDualDouble uCtrlOverhang;
        private Basics.UCtrlDouble uCtrlPalletHeight;
        private System.Windows.Forms.Label lbPalletDimensions;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.GroupBox gbCase;
        private Basics.UCtrlTriDouble uCtrlPackDimensionsMax;
        private Basics.UCtrlTriDouble uCtrlPackDimensionsMin;
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
    }
}