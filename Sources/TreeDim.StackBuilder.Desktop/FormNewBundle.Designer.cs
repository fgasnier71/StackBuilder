namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewBundle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewBundle));
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbColor = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gbFaceColor = new System.Windows.Forms.GroupBox();
            this.gbWeight = new System.Windows.Forms.GroupBox();
            this.uCtrlWeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.gbDimensions = new System.Windows.Forms.GroupBox();
            this.uCtrlThickness = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlWidth = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlLength = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.lbNoFlats = new System.Windows.Forms.Label();
            this.nudNoFlats = new System.Windows.Forms.NumericUpDown();
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnOk = new System.Windows.Forms.Button();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.bnSendToDB = new System.Windows.Forms.Button();
            this.gbFaceColor.SuspendLayout();
            this.gbWeight.SuspendLayout();
            this.gbDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoFlats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.statusStripDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbColor
            // 
            this.cbColor.Color = System.Drawing.Color.Beige;
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
            resources.GetString("cbColor.Items35")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // lbColor
            // 
            resources.ApplyResources(this.lbColor, "lbColor");
            this.lbColor.Name = "lbColor";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // gbFaceColor
            // 
            this.gbFaceColor.Controls.Add(this.cbColor);
            this.gbFaceColor.Controls.Add(this.lbColor);
            resources.ApplyResources(this.gbFaceColor, "gbFaceColor");
            this.gbFaceColor.Name = "gbFaceColor";
            this.gbFaceColor.TabStop = false;
            // 
            // gbWeight
            // 
            this.gbWeight.Controls.Add(this.uCtrlWeight);
            resources.ApplyResources(this.gbWeight, "gbWeight");
            this.gbWeight.Name = "gbWeight";
            this.gbWeight.TabStop = false;
            // 
            // uCtrlWeight
            // 
            resources.ApplyResources(this.uCtrlWeight, "uCtrlWeight");
            this.uCtrlWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlWeight.Name = "uCtrlWeight";
            this.uCtrlWeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlWeight.Value = 0D;
            this.uCtrlWeight.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.onValueChanged(this.onBundlePropertyChanged);
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            this.tbName.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // gbDimensions
            // 
            this.gbDimensions.Controls.Add(this.uCtrlThickness);
            this.gbDimensions.Controls.Add(this.uCtrlWidth);
            this.gbDimensions.Controls.Add(this.uCtrlLength);
            this.gbDimensions.Controls.Add(this.lbNoFlats);
            this.gbDimensions.Controls.Add(this.nudNoFlats);
            resources.ApplyResources(this.gbDimensions, "gbDimensions");
            this.gbDimensions.Name = "gbDimensions";
            this.gbDimensions.TabStop = false;
            // 
            // uCtrlThickness
            // 
            resources.ApplyResources(this.uCtrlThickness, "uCtrlThickness");
            this.uCtrlThickness.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlThickness.Name = "uCtrlThickness";
            this.uCtrlThickness.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlThickness.Value = 0D;
            this.uCtrlThickness.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.onValueChanged(this.onBundlePropertyChanged);
            // 
            // uCtrlWidth
            // 
            resources.ApplyResources(this.uCtrlWidth, "uCtrlWidth");
            this.uCtrlWidth.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlWidth.Name = "uCtrlWidth";
            this.uCtrlWidth.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlWidth.Value = 0D;
            this.uCtrlWidth.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.onValueChanged(this.onBundlePropertyChanged);
            // 
            // uCtrlLength
            // 
            resources.ApplyResources(this.uCtrlLength, "uCtrlLength");
            this.uCtrlLength.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlLength.Name = "uCtrlLength";
            this.uCtrlLength.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlLength.Value = 0D;
            this.uCtrlLength.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.onValueChanged(this.onBundlePropertyChanged);
            // 
            // lbNoFlats
            // 
            resources.ApplyResources(this.lbNoFlats, "lbNoFlats");
            this.lbNoFlats.Name = "lbNoFlats";
            // 
            // nudNoFlats
            // 
            resources.ApplyResources(this.nudNoFlats, "nudNoFlats");
            this.nudNoFlats.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNoFlats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNoFlats.Name = "nudNoFlats";
            this.nudNoFlats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNoFlats.ValueChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnOk
            // 
            resources.ApplyResources(this.bnOk, "bnOk");
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Name = "bnOk";
            this.bnOk.UseVisualStyleBackColor = true;
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
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.Name = "statusStripDef";
            this.statusStripDef.SizingGrip = false;
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            // 
            // bnSendToDB
            // 
            resources.ApplyResources(this.bnSendToDB, "bnSendToDB");
            this.bnSendToDB.Name = "bnSendToDB";
            this.bnSendToDB.UseVisualStyleBackColor = true;
            this.bnSendToDB.Click += new System.EventHandler(this.onSendToDatabase);
            // 
            // FormNewBundle
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bnSendToDB);
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.gbFaceColor);
            this.Controls.Add(this.graphCtrl);
            this.Controls.Add(this.gbWeight);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.gbDimensions);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewBundle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.gbFaceColor.ResumeLayout(false);
            this.gbFaceColor.PerformLayout();
            this.gbWeight.ResumeLayout(false);
            this.gbDimensions.ResumeLayout(false);
            this.gbDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoFlats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox gbFaceColor;
        private treeDiM.StackBuilder.Graphics.Graphics3DControl graphCtrl;
        private System.Windows.Forms.GroupBox gbWeight;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox gbDimensions;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.NumericUpDown nudNoFlats;
        private System.Windows.Forms.Label lbNoFlats;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private Basics.UCtrlDouble uCtrlWeight;
        private Basics.UCtrlDouble uCtrlThickness;
        private Basics.UCtrlDouble uCtrlWidth;
        private Basics.UCtrlDouble uCtrlLength;
        private System.Windows.Forms.Button bnSendToDB;
    }
}