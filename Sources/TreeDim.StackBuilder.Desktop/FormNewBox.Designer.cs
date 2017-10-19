namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewBox));
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lbFace = new System.Windows.Forms.Label();
            this.gbDimensions = new System.Windows.Forms.GroupBox();
            this.uCtrlDimensionsInner = new treeDiM.StackBuilder.Basics.UCtrlOptTriDouble();
            this.uCtrlDimensionsOuter = new treeDiM.StackBuilder.Basics.UCtrlTriDouble();
            this.cbFace = new System.Windows.Forms.ComboBox();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.gbFaceColor = new System.Windows.Forms.GroupBox();
            this.btBitmaps = new System.Windows.Forms.Button();
            this.chkAllFaces = new System.Windows.Forms.CheckBox();
            this.gbWeight = new System.Windows.Forms.GroupBox();
            this.vcWeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlNetWeight = new treeDiM.StackBuilder.Basics.UCtrlOptDouble();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbTape = new System.Windows.Forms.GroupBox();
            this.uCtrlTapeWidth = new treeDiM.StackBuilder.Basics.UCtrlOptDouble();
            this.cbTapeColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbTapeColor = new System.Windows.Forms.Label();
            this.bnSaveToDB = new System.Windows.Forms.Button();
            this.gbDimensions.SuspendLayout();
            this.gbFaceColor.SuspendLayout();
            this.gbWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.statusStripDef.SuspendLayout();
            this.gbTape.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnOK
            // 
            resources.ApplyResources(this.bnOK, "bnOK");
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Name = "bnOK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // lbFace
            // 
            resources.ApplyResources(this.lbFace, "lbFace");
            this.lbFace.Name = "lbFace";
            // 
            // gbDimensions
            // 
            resources.ApplyResources(this.gbDimensions, "gbDimensions");
            this.gbDimensions.Controls.Add(this.uCtrlDimensionsInner);
            this.gbDimensions.Controls.Add(this.uCtrlDimensionsOuter);
            this.gbDimensions.Name = "gbDimensions";
            this.gbDimensions.TabStop = false;
            // 
            // uCtrlDimensionsInner
            // 
            resources.ApplyResources(this.uCtrlDimensionsInner, "uCtrlDimensionsInner");
            this.uCtrlDimensionsInner.Checked = false;
            this.uCtrlDimensionsInner.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlDimensionsInner.Name = "uCtrlDimensionsInner";
            this.uCtrlDimensionsInner.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDimensionsInner.Value = ((Sharp3D.Math.Core.Vector3D)(resources.GetObject("uCtrlDimensionsInner.Value")));
            this.uCtrlDimensionsInner.X = 0D;
            this.uCtrlDimensionsInner.Y = 0D;
            this.uCtrlDimensionsInner.Z = 0D;
            this.uCtrlDimensionsInner.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlOptTriDouble.ValueChangedDelegate(this.OnBoxPropertyChanged);
            // 
            // uCtrlDimensionsOuter
            // 
            resources.ApplyResources(this.uCtrlDimensionsOuter, "uCtrlDimensionsOuter");
            this.uCtrlDimensionsOuter.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlDimensionsOuter.Name = "uCtrlDimensionsOuter";
            this.uCtrlDimensionsOuter.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDimensionsOuter.ValueX = 0D;
            this.uCtrlDimensionsOuter.ValueY = 0D;
            this.uCtrlDimensionsOuter.ValueZ = 0D;
            this.uCtrlDimensionsOuter.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlTriDouble.ValueChangedDelegate(this.OnBoxPropertyChanged);
            // 
            // cbFace
            // 
            resources.ApplyResources(this.cbFace, "cbFace");
            this.cbFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFace.FormattingEnabled = true;
            this.cbFace.Items.AddRange(new object[] {
            resources.GetString("cbFace.Items"),
            resources.GetString("cbFace.Items1"),
            resources.GetString("cbFace.Items2"),
            resources.GetString("cbFace.Items3"),
            resources.GetString("cbFace.Items4"),
            resources.GetString("cbFace.Items5")});
            this.cbFace.Name = "cbFace";
            this.cbFace.SelectedIndexChanged += new System.EventHandler(this.OnSelectedFaceChanged);
            // 
            // cbColor
            // 
            resources.ApplyResources(this.cbColor, "cbColor");
            this.cbColor.Color = System.Drawing.Color.Chocolate;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
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
            resources.GetString("cbColor.Items41"),
            resources.GetString("cbColor.Items42"),
            resources.GetString("cbColor.Items43"),
            resources.GetString("cbColor.Items44"),
            resources.GetString("cbColor.Items45"),
            resources.GetString("cbColor.Items46"),
            resources.GetString("cbColor.Items47"),
            resources.GetString("cbColor.Items48"),
            resources.GetString("cbColor.Items49"),
            resources.GetString("cbColor.Items50"),
            resources.GetString("cbColor.Items51"),
            resources.GetString("cbColor.Items52"),
            resources.GetString("cbColor.Items53"),
            resources.GetString("cbColor.Items54"),
            resources.GetString("cbColor.Items55"),
            resources.GetString("cbColor.Items56"),
            resources.GetString("cbColor.Items57"),
            resources.GetString("cbColor.Items58"),
            resources.GetString("cbColor.Items59"),
            resources.GetString("cbColor.Items60"),
            resources.GetString("cbColor.Items61"),
            resources.GetString("cbColor.Items62"),
            resources.GetString("cbColor.Items63"),
            resources.GetString("cbColor.Items64"),
            resources.GetString("cbColor.Items65"),
            resources.GetString("cbColor.Items66"),
            resources.GetString("cbColor.Items67"),
            resources.GetString("cbColor.Items68"),
            resources.GetString("cbColor.Items69"),
            resources.GetString("cbColor.Items70"),
            resources.GetString("cbColor.Items71"),
            resources.GetString("cbColor.Items72"),
            resources.GetString("cbColor.Items73"),
            resources.GetString("cbColor.Items74"),
            resources.GetString("cbColor.Items75"),
            resources.GetString("cbColor.Items76"),
            resources.GetString("cbColor.Items77"),
            resources.GetString("cbColor.Items78"),
            resources.GetString("cbColor.Items79"),
            resources.GetString("cbColor.Items80"),
            resources.GetString("cbColor.Items81"),
            resources.GetString("cbColor.Items82"),
            resources.GetString("cbColor.Items83"),
            resources.GetString("cbColor.Items84"),
            resources.GetString("cbColor.Items85"),
            resources.GetString("cbColor.Items86"),
            resources.GetString("cbColor.Items87"),
            resources.GetString("cbColor.Items88"),
            resources.GetString("cbColor.Items89"),
            resources.GetString("cbColor.Items90"),
            resources.GetString("cbColor.Items91"),
            resources.GetString("cbColor.Items92"),
            resources.GetString("cbColor.Items93"),
            resources.GetString("cbColor.Items94"),
            resources.GetString("cbColor.Items95"),
            resources.GetString("cbColor.Items96"),
            resources.GetString("cbColor.Items97"),
            resources.GetString("cbColor.Items98"),
            resources.GetString("cbColor.Items99"),
            resources.GetString("cbColor.Items100"),
            resources.GetString("cbColor.Items101"),
            resources.GetString("cbColor.Items102"),
            resources.GetString("cbColor.Items103")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.OnFaceColorChanged);
            // 
            // gbFaceColor
            // 
            resources.ApplyResources(this.gbFaceColor, "gbFaceColor");
            this.gbFaceColor.Controls.Add(this.btBitmaps);
            this.gbFaceColor.Controls.Add(this.chkAllFaces);
            this.gbFaceColor.Controls.Add(this.cbColor);
            this.gbFaceColor.Controls.Add(this.cbFace);
            this.gbFaceColor.Controls.Add(this.lbFace);
            this.gbFaceColor.Name = "gbFaceColor";
            this.gbFaceColor.TabStop = false;
            // 
            // btBitmaps
            // 
            resources.ApplyResources(this.btBitmaps, "btBitmaps");
            this.btBitmaps.Name = "btBitmaps";
            this.btBitmaps.UseVisualStyleBackColor = true;
            this.btBitmaps.Click += new System.EventHandler(this.OnEditTextures);
            // 
            // chkAllFaces
            // 
            resources.ApplyResources(this.chkAllFaces, "chkAllFaces");
            this.chkAllFaces.Name = "chkAllFaces";
            this.chkAllFaces.UseVisualStyleBackColor = true;
            this.chkAllFaces.CheckedChanged += new System.EventHandler(this.OnAllFacesColorCheckedChanged);
            // 
            // gbWeight
            // 
            resources.ApplyResources(this.gbWeight, "gbWeight");
            this.gbWeight.Controls.Add(this.vcWeight);
            this.gbWeight.Controls.Add(this.uCtrlNetWeight);
            this.gbWeight.Name = "gbWeight";
            this.gbWeight.TabStop = false;
            // 
            // vcWeight
            // 
            resources.ApplyResources(this.vcWeight, "vcWeight");
            this.vcWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.vcWeight.Name = "vcWeight";
            this.vcWeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_MASS;
            this.vcWeight.Value = 0D;
            this.vcWeight.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.ValueChangedDelegate(this.OnBoxPropertyChanged);
            // 
            // uCtrlNetWeight
            // 
            resources.ApplyResources(this.uCtrlNetWeight, "uCtrlNetWeight");
            this.uCtrlNetWeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlNetWeight.Name = "uCtrlNetWeight";
            this.uCtrlNetWeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlNetWeight.Value = ((treeDiM.StackBuilder.Basics.OptDouble)(resources.GetObject("uCtrlNetWeight.Value")));
            this.uCtrlNetWeight.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlOptDouble.ValueChangedDelegate(this.OnBoxPropertyChanged);
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            this.tbName.TextChanged += new System.EventHandler(this.OnNameDescriptionChanged);
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.TextChanged += new System.EventHandler(this.OnNameDescriptionChanged);
            // 
            // graphCtrl
            // 
            resources.ApplyResources(this.graphCtrl, "graphCtrl");
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.TabStop = false;
            this.graphCtrl.Viewer = null;
            // 
            // statusStripDef
            // 
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStripDef.Name = "statusStripDef";
            this.statusStripDef.SizingGrip = false;
            // 
            // toolStripStatusLabelDef
            // 
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            // 
            // gbTape
            // 
            resources.ApplyResources(this.gbTape, "gbTape");
            this.gbTape.Controls.Add(this.uCtrlTapeWidth);
            this.gbTape.Controls.Add(this.cbTapeColor);
            this.gbTape.Controls.Add(this.lbTapeColor);
            this.gbTape.Name = "gbTape";
            this.gbTape.TabStop = false;
            // 
            // uCtrlTapeWidth
            // 
            resources.ApplyResources(this.uCtrlTapeWidth, "uCtrlTapeWidth");
            this.uCtrlTapeWidth.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlTapeWidth.Name = "uCtrlTapeWidth";
            this.uCtrlTapeWidth.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlTapeWidth.Value = ((treeDiM.StackBuilder.Basics.OptDouble)(resources.GetObject("uCtrlTapeWidth.Value")));
            this.uCtrlTapeWidth.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlOptDouble.ValueChangedDelegate(this.OnTapeWidthChecked);
            // 
            // cbTapeColor
            // 
            resources.ApplyResources(this.cbTapeColor, "cbTapeColor");
            this.cbTapeColor.Color = System.Drawing.Color.Chocolate;
            this.cbTapeColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTapeColor.DropDownHeight = 1;
            this.cbTapeColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTapeColor.DropDownWidth = 1;
            this.cbTapeColor.Items.AddRange(new object[] {
            resources.GetString("cbTapeColor.Items"),
            resources.GetString("cbTapeColor.Items1"),
            resources.GetString("cbTapeColor.Items2"),
            resources.GetString("cbTapeColor.Items3"),
            resources.GetString("cbTapeColor.Items4"),
            resources.GetString("cbTapeColor.Items5"),
            resources.GetString("cbTapeColor.Items6"),
            resources.GetString("cbTapeColor.Items7"),
            resources.GetString("cbTapeColor.Items8"),
            resources.GetString("cbTapeColor.Items9"),
            resources.GetString("cbTapeColor.Items10"),
            resources.GetString("cbTapeColor.Items11"),
            resources.GetString("cbTapeColor.Items12"),
            resources.GetString("cbTapeColor.Items13"),
            resources.GetString("cbTapeColor.Items14"),
            resources.GetString("cbTapeColor.Items15"),
            resources.GetString("cbTapeColor.Items16"),
            resources.GetString("cbTapeColor.Items17"),
            resources.GetString("cbTapeColor.Items18"),
            resources.GetString("cbTapeColor.Items19"),
            resources.GetString("cbTapeColor.Items20"),
            resources.GetString("cbTapeColor.Items21"),
            resources.GetString("cbTapeColor.Items22"),
            resources.GetString("cbTapeColor.Items23"),
            resources.GetString("cbTapeColor.Items24"),
            resources.GetString("cbTapeColor.Items25"),
            resources.GetString("cbTapeColor.Items26"),
            resources.GetString("cbTapeColor.Items27"),
            resources.GetString("cbTapeColor.Items28"),
            resources.GetString("cbTapeColor.Items29"),
            resources.GetString("cbTapeColor.Items30"),
            resources.GetString("cbTapeColor.Items31"),
            resources.GetString("cbTapeColor.Items32"),
            resources.GetString("cbTapeColor.Items33"),
            resources.GetString("cbTapeColor.Items34"),
            resources.GetString("cbTapeColor.Items35"),
            resources.GetString("cbTapeColor.Items36"),
            resources.GetString("cbTapeColor.Items37"),
            resources.GetString("cbTapeColor.Items38"),
            resources.GetString("cbTapeColor.Items39"),
            resources.GetString("cbTapeColor.Items40"),
            resources.GetString("cbTapeColor.Items41"),
            resources.GetString("cbTapeColor.Items42"),
            resources.GetString("cbTapeColor.Items43"),
            resources.GetString("cbTapeColor.Items44"),
            resources.GetString("cbTapeColor.Items45"),
            resources.GetString("cbTapeColor.Items46"),
            resources.GetString("cbTapeColor.Items47"),
            resources.GetString("cbTapeColor.Items48"),
            resources.GetString("cbTapeColor.Items49"),
            resources.GetString("cbTapeColor.Items50"),
            resources.GetString("cbTapeColor.Items51"),
            resources.GetString("cbTapeColor.Items52"),
            resources.GetString("cbTapeColor.Items53"),
            resources.GetString("cbTapeColor.Items54"),
            resources.GetString("cbTapeColor.Items55"),
            resources.GetString("cbTapeColor.Items56"),
            resources.GetString("cbTapeColor.Items57"),
            resources.GetString("cbTapeColor.Items58"),
            resources.GetString("cbTapeColor.Items59"),
            resources.GetString("cbTapeColor.Items60"),
            resources.GetString("cbTapeColor.Items61"),
            resources.GetString("cbTapeColor.Items62"),
            resources.GetString("cbTapeColor.Items63"),
            resources.GetString("cbTapeColor.Items64"),
            resources.GetString("cbTapeColor.Items65"),
            resources.GetString("cbTapeColor.Items66"),
            resources.GetString("cbTapeColor.Items67"),
            resources.GetString("cbTapeColor.Items68"),
            resources.GetString("cbTapeColor.Items69"),
            resources.GetString("cbTapeColor.Items70"),
            resources.GetString("cbTapeColor.Items71"),
            resources.GetString("cbTapeColor.Items72"),
            resources.GetString("cbTapeColor.Items73"),
            resources.GetString("cbTapeColor.Items74"),
            resources.GetString("cbTapeColor.Items75"),
            resources.GetString("cbTapeColor.Items76"),
            resources.GetString("cbTapeColor.Items77"),
            resources.GetString("cbTapeColor.Items78"),
            resources.GetString("cbTapeColor.Items79"),
            resources.GetString("cbTapeColor.Items80"),
            resources.GetString("cbTapeColor.Items81"),
            resources.GetString("cbTapeColor.Items82"),
            resources.GetString("cbTapeColor.Items83"),
            resources.GetString("cbTapeColor.Items84"),
            resources.GetString("cbTapeColor.Items85"),
            resources.GetString("cbTapeColor.Items86"),
            resources.GetString("cbTapeColor.Items87"),
            resources.GetString("cbTapeColor.Items88"),
            resources.GetString("cbTapeColor.Items89"),
            resources.GetString("cbTapeColor.Items90"),
            resources.GetString("cbTapeColor.Items91"),
            resources.GetString("cbTapeColor.Items92"),
            resources.GetString("cbTapeColor.Items93"),
            resources.GetString("cbTapeColor.Items94"),
            resources.GetString("cbTapeColor.Items95"),
            resources.GetString("cbTapeColor.Items96"),
            resources.GetString("cbTapeColor.Items97"),
            resources.GetString("cbTapeColor.Items98"),
            resources.GetString("cbTapeColor.Items99"),
            resources.GetString("cbTapeColor.Items100"),
            resources.GetString("cbTapeColor.Items101"),
            resources.GetString("cbTapeColor.Items102"),
            resources.GetString("cbTapeColor.Items103"),
            resources.GetString("cbTapeColor.Items104")});
            this.cbTapeColor.Name = "cbTapeColor";
            this.cbTapeColor.SelectedColorChanged += new System.EventHandler(this.OnFaceColorChanged);
            // 
            // lbTapeColor
            // 
            resources.ApplyResources(this.lbTapeColor, "lbTapeColor");
            this.lbTapeColor.Name = "lbTapeColor";
            // 
            // bnSaveToDB
            // 
            resources.ApplyResources(this.bnSaveToDB, "bnSaveToDB");
            this.bnSaveToDB.Name = "bnSaveToDB";
            this.bnSaveToDB.UseVisualStyleBackColor = true;
            this.bnSaveToDB.Click += new System.EventHandler(this.OnSaveToDatabase);
            // 
            // FormNewBox
            // 
            this.AcceptButton = this.bnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.bnSaveToDB);
            this.Controls.Add(this.gbTape);
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.graphCtrl);
            this.Controls.Add(this.gbWeight);
            this.Controls.Add(this.gbFaceColor);
            this.Controls.Add(this.gbDimensions);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.gbDimensions.ResumeLayout(false);
            this.gbFaceColor.ResumeLayout(false);
            this.gbFaceColor.PerformLayout();
            this.gbWeight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.gbTape.ResumeLayout(false);
            this.gbTape.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label lbFace;
        private System.Windows.Forms.GroupBox gbDimensions;
        private System.Windows.Forms.ComboBox cbFace;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.GroupBox gbFaceColor;
        private System.Windows.Forms.GroupBox gbWeight;
        private treeDiM.StackBuilder.Graphics.Graphics3DControl graphCtrl;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private System.Windows.Forms.CheckBox chkAllFaces;
        private System.Windows.Forms.Button btBitmaps;
        private System.Windows.Forms.GroupBox gbTape;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbTapeColor;
        private System.Windows.Forms.Label lbTapeColor;
        private Basics.UCtrlOptDouble uCtrlNetWeight;
        private Basics.UCtrlDouble vcWeight;
        private Basics.UCtrlTriDouble uCtrlDimensionsOuter;
        private Basics.UCtrlOptTriDouble uCtrlDimensionsInner;
        private Basics.UCtrlOptDouble uCtrlTapeWidth;
        private System.Windows.Forms.Button bnSaveToDB;
    }
}