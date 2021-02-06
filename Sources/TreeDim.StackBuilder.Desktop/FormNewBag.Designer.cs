namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewBag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewBag));
            this.bnSendToDB = new System.Windows.Forms.Button();
            this.gbDimensions = new System.Windows.Forms.GroupBox();
            this.uCtrlRadius = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlOuterDimensions = new treeDiM.Basics.UCtrlTriDouble();
            this.gbWeight = new System.Windows.Forms.GroupBox();
            this.uCtrlNetWeight = new treeDiM.Basics.UCtrlOptDouble();
            this.uCtrlWeight = new treeDiM.Basics.UCtrlDouble();
            this.gbColor = new System.Windows.Forms.GroupBox();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.label1 = new System.Windows.Forms.Label();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.uCtrlOptBulge = new treeDiM.Basics.UCtrlOptTriDouble();
            this.gbDimensions.SuspendLayout();
            this.gbWeight.SuspendLayout();
            this.gbColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
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
            // bnSendToDB
            // 
            resources.ApplyResources(this.bnSendToDB, "bnSendToDB");
            this.bnSendToDB.Name = "bnSendToDB";
            this.bnSendToDB.UseVisualStyleBackColor = true;
            this.bnSendToDB.Click += new System.EventHandler(this.OnSendToDatabase);
            // 
            // gbDimensions
            // 
            this.gbDimensions.Controls.Add(this.uCtrlOptBulge);
            this.gbDimensions.Controls.Add(this.uCtrlRadius);
            this.gbDimensions.Controls.Add(this.uCtrlOuterDimensions);
            resources.ApplyResources(this.gbDimensions, "gbDimensions");
            this.gbDimensions.Name = "gbDimensions";
            this.gbDimensions.TabStop = false;
            // 
            // uCtrlRadius
            // 
            resources.ApplyResources(this.uCtrlRadius, "uCtrlRadius");
            this.uCtrlRadius.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.uCtrlRadius.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlRadius.Name = "uCtrlRadius";
            this.uCtrlRadius.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlRadius.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnValueChanged);
            // 
            // uCtrlOuterDimensions
            // 
            resources.ApplyResources(this.uCtrlOuterDimensions, "uCtrlOuterDimensions");
            this.uCtrlOuterDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlOuterDimensions.Name = "uCtrlOuterDimensions";
            this.uCtrlOuterDimensions.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOuterDimensions.ValueX = 0D;
            this.uCtrlOuterDimensions.ValueY = 0D;
            this.uCtrlOuterDimensions.ValueZ = 0D;
            this.uCtrlOuterDimensions.ValueChanged += new treeDiM.Basics.UCtrlTriDouble.ValueChangedDelegate(this.OnValueChanged);
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
            0,
            0,
            0,
            0});
            this.uCtrlNetWeight.Name = "uCtrlNetWeight";
            this.uCtrlNetWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlNetWeight.ValueChanged += new treeDiM.Basics.UCtrlOptDouble.ValueChangedDelegate(this.OnValueChanged);
            // 
            // uCtrlWeight
            // 
            resources.ApplyResources(this.uCtrlWeight, "uCtrlWeight");
            this.uCtrlWeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.uCtrlWeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlWeight.Name = "uCtrlWeight";
            this.uCtrlWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            // 
            // gbColor
            // 
            this.gbColor.Controls.Add(this.cbColor);
            this.gbColor.Controls.Add(this.label1);
            resources.ApplyResources(this.gbColor, "gbColor");
            this.gbColor.Name = "gbColor";
            this.gbColor.TabStop = false;
            // 
            // cbColor
            // 
            this.cbColor.Color = System.Drawing.Color.Gray;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
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
            resources.GetString("cbColor.Items102")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // graphCtrl
            // 
            resources.ApplyResources(this.graphCtrl, "graphCtrl");
            this.graphCtrl.AngleHoriz = 45D;
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.TabStop = false;
            this.graphCtrl.Viewer = null;
            // 
            // uCtrlOptBulge
            // 
            this.uCtrlOptBulge.Checked = false;
            resources.ApplyResources(this.uCtrlOptBulge, "uCtrlOptBulge");
            this.uCtrlOptBulge.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlOptBulge.Name = "uCtrlOptBulge";
            this.uCtrlOptBulge.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOptBulge.X = 0D;
            this.uCtrlOptBulge.Y = 0D;
            this.uCtrlOptBulge.Z = 0D;
            // 
            // FormNewBag
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbColor);
            this.Controls.Add(this.gbWeight);
            this.Controls.Add(this.gbDimensions);
            this.Controls.Add(this.graphCtrl);
            this.Controls.Add(this.bnSendToDB);
            this.Name = "FormNewBag";
            this.Controls.SetChildIndex(this.bnOk, 0);
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.bnSendToDB, 0);
            this.Controls.SetChildIndex(this.graphCtrl, 0);
            this.Controls.SetChildIndex(this.gbDimensions, 0);
            this.Controls.SetChildIndex(this.gbWeight, 0);
            this.Controls.SetChildIndex(this.gbColor, 0);
            this.gbDimensions.ResumeLayout(false);
            this.gbWeight.ResumeLayout(false);
            this.gbColor.ResumeLayout(false);
            this.gbColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnSendToDB;
        private Graphics.Graphics3DControl graphCtrl;
        private System.Windows.Forms.GroupBox gbDimensions;
        private treeDiM.Basics.UCtrlTriDouble uCtrlOuterDimensions;
        private treeDiM.Basics.UCtrlDouble uCtrlRadius;
        private System.Windows.Forms.GroupBox gbWeight;
        private treeDiM.Basics.UCtrlDouble uCtrlWeight;
        private treeDiM.Basics.UCtrlOptDouble uCtrlNetWeight;
        private System.Windows.Forms.GroupBox gbColor;
        private System.Windows.Forms.Label label1;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private treeDiM.Basics.UCtrlOptTriDouble uCtrlOptBulge;
    }
}