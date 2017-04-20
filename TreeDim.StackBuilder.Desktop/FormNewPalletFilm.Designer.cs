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
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbColor = new System.Windows.Forms.Label();
            this.chkbTransparency = new System.Windows.Forms.CheckBox();
            this.chkbHatching = new System.Windows.Forms.CheckBox();
            this.bnSendToDB = new System.Windows.Forms.Button();
            this.uCtrlSpacing = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlAngle = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.SuspendLayout();
            // 
            // bnOk
            // 
            this.bnOk.Location = new System.Drawing.Point(505, 10);
            // 
            // bnCancel
            // 
            this.bnCancel.Location = new System.Drawing.Point(505, 38);
            // 
            // tbDescription
            // 
            this.tbDescription.Size = new System.Drawing.Size(384, 20);
            // 
            // cbColor
            // 
            this.cbColor.Color = System.Drawing.Color.LightBlue;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
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
            "Color"});
            this.cbColor.Location = new System.Drawing.Point(111, 80);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(75, 22);
            this.cbColor.TabIndex = 24;
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(13, 83);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(31, 13);
            this.lbColor.TabIndex = 25;
            this.lbColor.Text = "Color";
            // 
            // chkbTransparency
            // 
            this.chkbTransparency.AutoSize = true;
            this.chkbTransparency.Location = new System.Drawing.Point(16, 118);
            this.chkbTransparency.Name = "chkbTransparency";
            this.chkbTransparency.Size = new System.Drawing.Size(91, 17);
            this.chkbTransparency.TabIndex = 26;
            this.chkbTransparency.Text = "Transparency";
            this.chkbTransparency.UseVisualStyleBackColor = true;
            // 
            // chkbHatching
            // 
            this.chkbHatching.AutoSize = true;
            this.chkbHatching.Location = new System.Drawing.Point(16, 141);
            this.chkbHatching.Name = "chkbHatching";
            this.chkbHatching.Size = new System.Drawing.Size(69, 17);
            this.chkbHatching.TabIndex = 27;
            this.chkbHatching.Text = "Hatching";
            this.chkbHatching.UseVisualStyleBackColor = true;
            this.chkbHatching.CheckedChanged += new System.EventHandler(this.chkbHatching_CheckedChanged);
            // 
            // bnSendToDB
            // 
            this.bnSendToDB.Location = new System.Drawing.Point(436, 314);
            this.bnSendToDB.Name = "bnSendToDB";
            this.bnSendToDB.Size = new System.Drawing.Size(144, 23);
            this.bnSendToDB.TabIndex = 33;
            this.bnSendToDB.Text = "Send to database";
            this.bnSendToDB.UseVisualStyleBackColor = true;
            this.bnSendToDB.Click += new System.EventHandler(this.onSendToDatabase);
            // 
            // uCtrlSpacing
            // 
            this.uCtrlSpacing.Location = new System.Drawing.Point(25, 165);
            this.uCtrlSpacing.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlSpacing.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlSpacing.Name = "uCtrlSpacing";
            this.uCtrlSpacing.Size = new System.Drawing.Size(185, 20);
            this.uCtrlSpacing.TabIndex = 34;
            this.uCtrlSpacing.Text = "Spacing";
            this.uCtrlSpacing.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlSpacing.Value = 0D;
            // 
            // uCtrlAngle
            // 
            this.uCtrlAngle.Location = new System.Drawing.Point(25, 192);
            this.uCtrlAngle.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlAngle.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlAngle.Name = "uCtrlAngle";
            this.uCtrlAngle.Size = new System.Drawing.Size(185, 20);
            this.uCtrlAngle.TabIndex = 35;
            this.uCtrlAngle.Text = "Angle";
            this.uCtrlAngle.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_NONE;
            this.uCtrlAngle.Value = 0D;
            // 
            // FormNewPalletFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.uCtrlAngle);
            this.Controls.Add(this.uCtrlSpacing);
            this.Controls.Add(this.bnSendToDB);
            this.Controls.Add(this.chkbHatching);
            this.Controls.Add(this.chkbTransparency);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.cbColor);
            this.Name = "FormNewPalletFilm";
            this.Text = "Create new pallet film...";
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
        private Basics.UCtrlDouble uCtrlSpacing;
        private Basics.UCtrlDouble uCtrlAngle;
    }
}
