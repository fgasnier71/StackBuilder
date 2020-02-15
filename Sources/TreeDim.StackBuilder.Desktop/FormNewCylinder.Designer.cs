namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewCylinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewCylinder));
            this.gbDimensions = new System.Windows.Forms.GroupBox();
            this.uCtrlHeight = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlDiameterInner = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlDiameterOuter = new treeDiM.Basics.UCtrlDouble();
            this.gbWeight = new System.Windows.Forms.GroupBox();
            this.uCtrlNetWeight = new treeDiM.Basics.UCtrlOptDouble();
            this.uCtrlWeight = new treeDiM.Basics.UCtrlDouble();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.gbFaceColor = new System.Windows.Forms.GroupBox();
            this.cbColorWallInner = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbColorWallOuter = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbWallColor = new System.Windows.Forms.Label();
            this.cbColorTop = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbTop = new System.Windows.Forms.Label();
            this.bnSendToDB = new System.Windows.Forms.Button();
            this.gbDimensions.SuspendLayout();
            this.gbWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.gbFaceColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnOk
            // 
            resources.ApplyResources(this.bnOk, "bnOk");
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            // 
            // gbDimensions
            // 
            this.gbDimensions.Controls.Add(this.uCtrlHeight);
            this.gbDimensions.Controls.Add(this.uCtrlDiameterInner);
            this.gbDimensions.Controls.Add(this.uCtrlDiameterOuter);
            resources.ApplyResources(this.gbDimensions, "gbDimensions");
            this.gbDimensions.Name = "gbDimensions";
            this.gbDimensions.TabStop = false;
            // 
            // uCtrlHeight
            // 
            resources.ApplyResources(this.uCtrlHeight, "uCtrlHeight");
            this.uCtrlHeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlHeight.Name = "uCtrlHeight";
            this.uCtrlHeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlHeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnValueChanged);
            // 
            // uCtrlDiameterInner
            // 
            resources.ApplyResources(this.uCtrlDiameterInner, "uCtrlDiameterInner");
            this.uCtrlDiameterInner.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlDiameterInner.Name = "uCtrlDiameterInner";
            this.uCtrlDiameterInner.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDiameterInner.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnValueChanged);
            // 
            // uCtrlDiameterOuter
            // 
            resources.ApplyResources(this.uCtrlDiameterOuter, "uCtrlDiameterOuter");
            this.uCtrlDiameterOuter.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlDiameterOuter.Name = "uCtrlDiameterOuter";
            this.uCtrlDiameterOuter.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDiameterOuter.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnValueChanged);
            // 
            // gbWeight
            // 
            this.gbWeight.Controls.Add(this.uCtrlNetWeight);
            this.gbWeight.Controls.Add(this.uCtrlWeight);
            resources.ApplyResources(this.gbWeight, "gbWeight");
            this.gbWeight.Name = "gbWeight";
            this.gbWeight.TabStop = false;
            // 
            // uCtrlNetWeight
            // 
            resources.ApplyResources(this.uCtrlNetWeight, "uCtrlNetWeight");
            this.uCtrlNetWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlNetWeight.Name = "uCtrlNetWeight";
            this.uCtrlNetWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlNetWeight.ValueChanged += new treeDiM.Basics.UCtrlOptDouble.ValueChangedDelegate(this.OnValueChanged);
            // 
            // uCtrlWeight
            // 
            resources.ApplyResources(this.uCtrlWeight, "uCtrlWeight");
            this.uCtrlWeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlWeight.Name = "uCtrlWeight";
            this.uCtrlWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlWeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnValueChanged);
            // 
            // graphCtrl
            // 
            resources.ApplyResources(this.graphCtrl, "graphCtrl");
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.TabStop = false;
            this.graphCtrl.Viewer = null;
            // 
            // gbFaceColor
            // 
            this.gbFaceColor.Controls.Add(this.cbColorWallInner);
            this.gbFaceColor.Controls.Add(this.label1);
            this.gbFaceColor.Controls.Add(this.cbColorWallOuter);
            this.gbFaceColor.Controls.Add(this.lbWallColor);
            this.gbFaceColor.Controls.Add(this.cbColorTop);
            this.gbFaceColor.Controls.Add(this.lbTop);
            resources.ApplyResources(this.gbFaceColor, "gbFaceColor");
            this.gbFaceColor.Name = "gbFaceColor";
            this.gbFaceColor.TabStop = false;
            // 
            // cbColorWallInner
            // 
            this.cbColorWallInner.Color = System.Drawing.Color.LightSkyBlue;
            this.cbColorWallInner.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColorWallInner.DropDownHeight = 1;
            this.cbColorWallInner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorWallInner.DropDownWidth = 1;
            resources.ApplyResources(this.cbColorWallInner, "cbColorWallInner");
            this.cbColorWallInner.Items.AddRange(new object[] {
            resources.GetString("cbColorWallInner.Items"),
            resources.GetString("cbColorWallInner.Items1"),
            resources.GetString("cbColorWallInner.Items2"),
            resources.GetString("cbColorWallInner.Items3"),
            resources.GetString("cbColorWallInner.Items4"),
            resources.GetString("cbColorWallInner.Items5"),
            resources.GetString("cbColorWallInner.Items6"),
            resources.GetString("cbColorWallInner.Items7"),
            resources.GetString("cbColorWallInner.Items8"),
            resources.GetString("cbColorWallInner.Items9"),
            resources.GetString("cbColorWallInner.Items10"),
            resources.GetString("cbColorWallInner.Items11"),
            resources.GetString("cbColorWallInner.Items12"),
            resources.GetString("cbColorWallInner.Items13"),
            resources.GetString("cbColorWallInner.Items14"),
            resources.GetString("cbColorWallInner.Items15"),
            resources.GetString("cbColorWallInner.Items16"),
            resources.GetString("cbColorWallInner.Items17"),
            resources.GetString("cbColorWallInner.Items18"),
            resources.GetString("cbColorWallInner.Items19"),
            resources.GetString("cbColorWallInner.Items20"),
            resources.GetString("cbColorWallInner.Items21"),
            resources.GetString("cbColorWallInner.Items22"),
            resources.GetString("cbColorWallInner.Items23"),
            resources.GetString("cbColorWallInner.Items24"),
            resources.GetString("cbColorWallInner.Items25"),
            resources.GetString("cbColorWallInner.Items26"),
            resources.GetString("cbColorWallInner.Items27"),
            resources.GetString("cbColorWallInner.Items28"),
            resources.GetString("cbColorWallInner.Items29"),
            resources.GetString("cbColorWallInner.Items30"),
            resources.GetString("cbColorWallInner.Items31"),
            resources.GetString("cbColorWallInner.Items32"),
            resources.GetString("cbColorWallInner.Items33"),
            resources.GetString("cbColorWallInner.Items34"),
            resources.GetString("cbColorWallInner.Items35"),
            resources.GetString("cbColorWallInner.Items36"),
            resources.GetString("cbColorWallInner.Items37"),
            resources.GetString("cbColorWallInner.Items38"),
            resources.GetString("cbColorWallInner.Items39"),
            resources.GetString("cbColorWallInner.Items40"),
            resources.GetString("cbColorWallInner.Items41"),
            resources.GetString("cbColorWallInner.Items42"),
            resources.GetString("cbColorWallInner.Items43"),
            resources.GetString("cbColorWallInner.Items44"),
            resources.GetString("cbColorWallInner.Items45"),
            resources.GetString("cbColorWallInner.Items46"),
            resources.GetString("cbColorWallInner.Items47"),
            resources.GetString("cbColorWallInner.Items48"),
            resources.GetString("cbColorWallInner.Items49"),
            resources.GetString("cbColorWallInner.Items50"),
            resources.GetString("cbColorWallInner.Items51"),
            resources.GetString("cbColorWallInner.Items52"),
            resources.GetString("cbColorWallInner.Items53"),
            resources.GetString("cbColorWallInner.Items54"),
            resources.GetString("cbColorWallInner.Items55"),
            resources.GetString("cbColorWallInner.Items56"),
            resources.GetString("cbColorWallInner.Items57"),
            resources.GetString("cbColorWallInner.Items58"),
            resources.GetString("cbColorWallInner.Items59"),
            resources.GetString("cbColorWallInner.Items60"),
            resources.GetString("cbColorWallInner.Items61"),
            resources.GetString("cbColorWallInner.Items62"),
            resources.GetString("cbColorWallInner.Items63"),
            resources.GetString("cbColorWallInner.Items64"),
            resources.GetString("cbColorWallInner.Items65"),
            resources.GetString("cbColorWallInner.Items66"),
            resources.GetString("cbColorWallInner.Items67"),
            resources.GetString("cbColorWallInner.Items68"),
            resources.GetString("cbColorWallInner.Items69"),
            resources.GetString("cbColorWallInner.Items70"),
            resources.GetString("cbColorWallInner.Items71"),
            resources.GetString("cbColorWallInner.Items72"),
            resources.GetString("cbColorWallInner.Items73"),
            resources.GetString("cbColorWallInner.Items74"),
            resources.GetString("cbColorWallInner.Items75"),
            resources.GetString("cbColorWallInner.Items76"),
            resources.GetString("cbColorWallInner.Items77"),
            resources.GetString("cbColorWallInner.Items78"),
            resources.GetString("cbColorWallInner.Items79"),
            resources.GetString("cbColorWallInner.Items80"),
            resources.GetString("cbColorWallInner.Items81"),
            resources.GetString("cbColorWallInner.Items82"),
            resources.GetString("cbColorWallInner.Items83"),
            resources.GetString("cbColorWallInner.Items84"),
            resources.GetString("cbColorWallInner.Items85"),
            resources.GetString("cbColorWallInner.Items86"),
            resources.GetString("cbColorWallInner.Items87"),
            resources.GetString("cbColorWallInner.Items88"),
            resources.GetString("cbColorWallInner.Items89"),
            resources.GetString("cbColorWallInner.Items90"),
            resources.GetString("cbColorWallInner.Items91"),
            resources.GetString("cbColorWallInner.Items92"),
            resources.GetString("cbColorWallInner.Items93"),
            resources.GetString("cbColorWallInner.Items94")});
            this.cbColorWallInner.Name = "cbColorWallInner";
            this.cbColorWallInner.SelectedColorChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbColorWallOuter
            // 
            this.cbColorWallOuter.Color = System.Drawing.Color.LightSkyBlue;
            this.cbColorWallOuter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColorWallOuter.DropDownHeight = 1;
            this.cbColorWallOuter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorWallOuter.DropDownWidth = 1;
            resources.ApplyResources(this.cbColorWallOuter, "cbColorWallOuter");
            this.cbColorWallOuter.Items.AddRange(new object[] {
            resources.GetString("cbColorWallOuter.Items"),
            resources.GetString("cbColorWallOuter.Items1"),
            resources.GetString("cbColorWallOuter.Items2"),
            resources.GetString("cbColorWallOuter.Items3"),
            resources.GetString("cbColorWallOuter.Items4"),
            resources.GetString("cbColorWallOuter.Items5"),
            resources.GetString("cbColorWallOuter.Items6"),
            resources.GetString("cbColorWallOuter.Items7"),
            resources.GetString("cbColorWallOuter.Items8"),
            resources.GetString("cbColorWallOuter.Items9"),
            resources.GetString("cbColorWallOuter.Items10"),
            resources.GetString("cbColorWallOuter.Items11"),
            resources.GetString("cbColorWallOuter.Items12"),
            resources.GetString("cbColorWallOuter.Items13"),
            resources.GetString("cbColorWallOuter.Items14"),
            resources.GetString("cbColorWallOuter.Items15"),
            resources.GetString("cbColorWallOuter.Items16"),
            resources.GetString("cbColorWallOuter.Items17"),
            resources.GetString("cbColorWallOuter.Items18"),
            resources.GetString("cbColorWallOuter.Items19"),
            resources.GetString("cbColorWallOuter.Items20"),
            resources.GetString("cbColorWallOuter.Items21"),
            resources.GetString("cbColorWallOuter.Items22"),
            resources.GetString("cbColorWallOuter.Items23"),
            resources.GetString("cbColorWallOuter.Items24"),
            resources.GetString("cbColorWallOuter.Items25"),
            resources.GetString("cbColorWallOuter.Items26"),
            resources.GetString("cbColorWallOuter.Items27"),
            resources.GetString("cbColorWallOuter.Items28"),
            resources.GetString("cbColorWallOuter.Items29"),
            resources.GetString("cbColorWallOuter.Items30"),
            resources.GetString("cbColorWallOuter.Items31"),
            resources.GetString("cbColorWallOuter.Items32"),
            resources.GetString("cbColorWallOuter.Items33"),
            resources.GetString("cbColorWallOuter.Items34"),
            resources.GetString("cbColorWallOuter.Items35"),
            resources.GetString("cbColorWallOuter.Items36"),
            resources.GetString("cbColorWallOuter.Items37"),
            resources.GetString("cbColorWallOuter.Items38"),
            resources.GetString("cbColorWallOuter.Items39"),
            resources.GetString("cbColorWallOuter.Items40"),
            resources.GetString("cbColorWallOuter.Items41"),
            resources.GetString("cbColorWallOuter.Items42"),
            resources.GetString("cbColorWallOuter.Items43"),
            resources.GetString("cbColorWallOuter.Items44"),
            resources.GetString("cbColorWallOuter.Items45"),
            resources.GetString("cbColorWallOuter.Items46"),
            resources.GetString("cbColorWallOuter.Items47"),
            resources.GetString("cbColorWallOuter.Items48"),
            resources.GetString("cbColorWallOuter.Items49"),
            resources.GetString("cbColorWallOuter.Items50"),
            resources.GetString("cbColorWallOuter.Items51"),
            resources.GetString("cbColorWallOuter.Items52"),
            resources.GetString("cbColorWallOuter.Items53"),
            resources.GetString("cbColorWallOuter.Items54"),
            resources.GetString("cbColorWallOuter.Items55"),
            resources.GetString("cbColorWallOuter.Items56"),
            resources.GetString("cbColorWallOuter.Items57"),
            resources.GetString("cbColorWallOuter.Items58"),
            resources.GetString("cbColorWallOuter.Items59"),
            resources.GetString("cbColorWallOuter.Items60"),
            resources.GetString("cbColorWallOuter.Items61"),
            resources.GetString("cbColorWallOuter.Items62"),
            resources.GetString("cbColorWallOuter.Items63"),
            resources.GetString("cbColorWallOuter.Items64"),
            resources.GetString("cbColorWallOuter.Items65"),
            resources.GetString("cbColorWallOuter.Items66"),
            resources.GetString("cbColorWallOuter.Items67"),
            resources.GetString("cbColorWallOuter.Items68"),
            resources.GetString("cbColorWallOuter.Items69"),
            resources.GetString("cbColorWallOuter.Items70"),
            resources.GetString("cbColorWallOuter.Items71"),
            resources.GetString("cbColorWallOuter.Items72"),
            resources.GetString("cbColorWallOuter.Items73"),
            resources.GetString("cbColorWallOuter.Items74"),
            resources.GetString("cbColorWallOuter.Items75"),
            resources.GetString("cbColorWallOuter.Items76"),
            resources.GetString("cbColorWallOuter.Items77"),
            resources.GetString("cbColorWallOuter.Items78"),
            resources.GetString("cbColorWallOuter.Items79"),
            resources.GetString("cbColorWallOuter.Items80"),
            resources.GetString("cbColorWallOuter.Items81"),
            resources.GetString("cbColorWallOuter.Items82"),
            resources.GetString("cbColorWallOuter.Items83"),
            resources.GetString("cbColorWallOuter.Items84"),
            resources.GetString("cbColorWallOuter.Items85"),
            resources.GetString("cbColorWallOuter.Items86"),
            resources.GetString("cbColorWallOuter.Items87"),
            resources.GetString("cbColorWallOuter.Items88"),
            resources.GetString("cbColorWallOuter.Items89"),
            resources.GetString("cbColorWallOuter.Items90"),
            resources.GetString("cbColorWallOuter.Items91"),
            resources.GetString("cbColorWallOuter.Items92"),
            resources.GetString("cbColorWallOuter.Items93")});
            this.cbColorWallOuter.Name = "cbColorWallOuter";
            this.cbColorWallOuter.SelectedColorChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lbWallColor
            // 
            resources.ApplyResources(this.lbWallColor, "lbWallColor");
            this.lbWallColor.Name = "lbWallColor";
            // 
            // cbColorTop
            // 
            this.cbColorTop.Color = System.Drawing.Color.Gray;
            this.cbColorTop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColorTop.DropDownHeight = 1;
            this.cbColorTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorTop.DropDownWidth = 1;
            resources.ApplyResources(this.cbColorTop, "cbColorTop");
            this.cbColorTop.Items.AddRange(new object[] {
            resources.GetString("cbColorTop.Items"),
            resources.GetString("cbColorTop.Items1"),
            resources.GetString("cbColorTop.Items2"),
            resources.GetString("cbColorTop.Items3"),
            resources.GetString("cbColorTop.Items4"),
            resources.GetString("cbColorTop.Items5"),
            resources.GetString("cbColorTop.Items6"),
            resources.GetString("cbColorTop.Items7"),
            resources.GetString("cbColorTop.Items8"),
            resources.GetString("cbColorTop.Items9"),
            resources.GetString("cbColorTop.Items10"),
            resources.GetString("cbColorTop.Items11"),
            resources.GetString("cbColorTop.Items12"),
            resources.GetString("cbColorTop.Items13"),
            resources.GetString("cbColorTop.Items14"),
            resources.GetString("cbColorTop.Items15"),
            resources.GetString("cbColorTop.Items16"),
            resources.GetString("cbColorTop.Items17"),
            resources.GetString("cbColorTop.Items18"),
            resources.GetString("cbColorTop.Items19"),
            resources.GetString("cbColorTop.Items20"),
            resources.GetString("cbColorTop.Items21"),
            resources.GetString("cbColorTop.Items22"),
            resources.GetString("cbColorTop.Items23"),
            resources.GetString("cbColorTop.Items24"),
            resources.GetString("cbColorTop.Items25"),
            resources.GetString("cbColorTop.Items26"),
            resources.GetString("cbColorTop.Items27"),
            resources.GetString("cbColorTop.Items28"),
            resources.GetString("cbColorTop.Items29"),
            resources.GetString("cbColorTop.Items30"),
            resources.GetString("cbColorTop.Items31"),
            resources.GetString("cbColorTop.Items32"),
            resources.GetString("cbColorTop.Items33"),
            resources.GetString("cbColorTop.Items34"),
            resources.GetString("cbColorTop.Items35"),
            resources.GetString("cbColorTop.Items36"),
            resources.GetString("cbColorTop.Items37"),
            resources.GetString("cbColorTop.Items38"),
            resources.GetString("cbColorTop.Items39"),
            resources.GetString("cbColorTop.Items40"),
            resources.GetString("cbColorTop.Items41"),
            resources.GetString("cbColorTop.Items42"),
            resources.GetString("cbColorTop.Items43"),
            resources.GetString("cbColorTop.Items44"),
            resources.GetString("cbColorTop.Items45"),
            resources.GetString("cbColorTop.Items46"),
            resources.GetString("cbColorTop.Items47"),
            resources.GetString("cbColorTop.Items48"),
            resources.GetString("cbColorTop.Items49"),
            resources.GetString("cbColorTop.Items50"),
            resources.GetString("cbColorTop.Items51"),
            resources.GetString("cbColorTop.Items52"),
            resources.GetString("cbColorTop.Items53"),
            resources.GetString("cbColorTop.Items54"),
            resources.GetString("cbColorTop.Items55"),
            resources.GetString("cbColorTop.Items56"),
            resources.GetString("cbColorTop.Items57"),
            resources.GetString("cbColorTop.Items58"),
            resources.GetString("cbColorTop.Items59"),
            resources.GetString("cbColorTop.Items60"),
            resources.GetString("cbColorTop.Items61"),
            resources.GetString("cbColorTop.Items62"),
            resources.GetString("cbColorTop.Items63"),
            resources.GetString("cbColorTop.Items64"),
            resources.GetString("cbColorTop.Items65"),
            resources.GetString("cbColorTop.Items66"),
            resources.GetString("cbColorTop.Items67"),
            resources.GetString("cbColorTop.Items68"),
            resources.GetString("cbColorTop.Items69"),
            resources.GetString("cbColorTop.Items70"),
            resources.GetString("cbColorTop.Items71"),
            resources.GetString("cbColorTop.Items72"),
            resources.GetString("cbColorTop.Items73"),
            resources.GetString("cbColorTop.Items74"),
            resources.GetString("cbColorTop.Items75"),
            resources.GetString("cbColorTop.Items76"),
            resources.GetString("cbColorTop.Items77"),
            resources.GetString("cbColorTop.Items78"),
            resources.GetString("cbColorTop.Items79"),
            resources.GetString("cbColorTop.Items80"),
            resources.GetString("cbColorTop.Items81"),
            resources.GetString("cbColorTop.Items82"),
            resources.GetString("cbColorTop.Items83"),
            resources.GetString("cbColorTop.Items84"),
            resources.GetString("cbColorTop.Items85"),
            resources.GetString("cbColorTop.Items86"),
            resources.GetString("cbColorTop.Items87"),
            resources.GetString("cbColorTop.Items88"),
            resources.GetString("cbColorTop.Items89"),
            resources.GetString("cbColorTop.Items90"),
            resources.GetString("cbColorTop.Items91"),
            resources.GetString("cbColorTop.Items92")});
            this.cbColorTop.Name = "cbColorTop";
            this.cbColorTop.SelectedColorChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lbTop
            // 
            resources.ApplyResources(this.lbTop, "lbTop");
            this.lbTop.Name = "lbTop";
            // 
            // bnSendToDB
            // 
            resources.ApplyResources(this.bnSendToDB, "bnSendToDB");
            this.bnSendToDB.Name = "bnSendToDB";
            this.bnSendToDB.UseVisualStyleBackColor = true;
            this.bnSendToDB.Click += new System.EventHandler(this.OnSendToDatabase);
            // 
            // FormNewCylinder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bnSendToDB);
            this.Controls.Add(this.gbFaceColor);
            this.Controls.Add(this.graphCtrl);
            this.Controls.Add(this.gbWeight);
            this.Controls.Add(this.gbDimensions);
            this.Name = "FormNewCylinder";
            this.Controls.SetChildIndex(this.gbDimensions, 0);
            this.Controls.SetChildIndex(this.gbWeight, 0);
            this.Controls.SetChildIndex(this.graphCtrl, 0);
            this.Controls.SetChildIndex(this.gbFaceColor, 0);
            this.Controls.SetChildIndex(this.bnSendToDB, 0);
            this.Controls.SetChildIndex(this.bnOk, 0);
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.gbDimensions.ResumeLayout(false);
            this.gbWeight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.gbFaceColor.ResumeLayout(false);
            this.gbFaceColor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDimensions;
        private System.Windows.Forms.GroupBox gbWeight;
        private treeDiM.StackBuilder.Graphics.Graphics3DControl graphCtrl;
        private System.Windows.Forms.GroupBox gbFaceColor;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColorWallOuter;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColorWallInner;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColorTop;
        private System.Windows.Forms.Label lbWallColor;
        private System.Windows.Forms.Label lbTop;
        private System.Windows.Forms.Label label1;
        private treeDiM.Basics.UCtrlDouble uCtrlHeight;
        private treeDiM.Basics.UCtrlDouble uCtrlDiameterInner;
        private treeDiM.Basics.UCtrlDouble uCtrlDiameterOuter;
        private treeDiM.Basics.UCtrlOptDouble uCtrlNetWeight;
        private treeDiM.Basics.UCtrlDouble uCtrlWeight;
        private System.Windows.Forms.Button bnSendToDB;
    }
}