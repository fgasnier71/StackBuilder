namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewPalletFilm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewPalletFilm));
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbColor = new System.Windows.Forms.Label();
            this.chkbTransparency = new System.Windows.Forms.CheckBox();
            this.chkbHatching = new System.Windows.Forms.CheckBox();
            this.bnSendToDB = new System.Windows.Forms.Button();
            this.uCtrlSpacing = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlAngle = new treeDiM.Basics.UCtrlDouble();
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
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            // 
            // lbDescription
            // 
            resources.ApplyResources(this.lbDescription, "lbDescription");
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            // 
            // cbColor
            // 
            resources.ApplyResources(this.cbColor, "cbColor");
            this.cbColor.Color = System.Drawing.Color.LightBlue;
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
            resources.GetString("cbColor.Items16")});
            this.cbColor.Name = "cbColor";
            // 
            // lbColor
            // 
            resources.ApplyResources(this.lbColor, "lbColor");
            this.lbColor.Name = "lbColor";
            // 
            // chkbTransparency
            // 
            resources.ApplyResources(this.chkbTransparency, "chkbTransparency");
            this.chkbTransparency.Name = "chkbTransparency";
            this.chkbTransparency.UseVisualStyleBackColor = true;
            // 
            // chkbHatching
            // 
            resources.ApplyResources(this.chkbHatching, "chkbHatching");
            this.chkbHatching.Name = "chkbHatching";
            this.chkbHatching.UseVisualStyleBackColor = true;
            this.chkbHatching.CheckedChanged += new System.EventHandler(this.OnChkbHatchingCheckedChanged);
            // 
            // bnSendToDB
            // 
            resources.ApplyResources(this.bnSendToDB, "bnSendToDB");
            this.bnSendToDB.Name = "bnSendToDB";
            this.bnSendToDB.UseVisualStyleBackColor = true;
            this.bnSendToDB.Click += new System.EventHandler(this.OnSendToDatabase);
            // 
            // uCtrlSpacing
            // 
            resources.ApplyResources(this.uCtrlSpacing, "uCtrlSpacing");
            this.uCtrlSpacing.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlSpacing.Name = "uCtrlSpacing";
            this.uCtrlSpacing.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            // 
            // uCtrlAngle
            // 
            resources.ApplyResources(this.uCtrlAngle, "uCtrlAngle");
            this.uCtrlAngle.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlAngle.Name = "uCtrlAngle";
            this.uCtrlAngle.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_NONE;
            // 
            // FormNewPalletFilm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.uCtrlAngle);
            this.Controls.Add(this.uCtrlSpacing);
            this.Controls.Add(this.bnSendToDB);
            this.Controls.Add(this.chkbHatching);
            this.Controls.Add(this.chkbTransparency);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.cbColor);
            this.Name = "FormNewPalletFilm";
            this.Controls.SetChildIndex(this.bnOk, 0);
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.cbColor, 0);
            this.Controls.SetChildIndex(this.lbColor, 0);
            this.Controls.SetChildIndex(this.chkbTransparency, 0);
            this.Controls.SetChildIndex(this.chkbHatching, 0);
            this.Controls.SetChildIndex(this.bnSendToDB, 0);
            this.Controls.SetChildIndex(this.uCtrlSpacing, 0);
            this.Controls.SetChildIndex(this.uCtrlAngle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.CheckBox chkbTransparency;
        private System.Windows.Forms.CheckBox chkbHatching;
        private System.Windows.Forms.Button bnSendToDB;
        private treeDiM.Basics.UCtrlDouble uCtrlSpacing;
        private treeDiM.Basics.UCtrlDouble uCtrlAngle;
    }
}
