namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewPalletCorners
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
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.lbColor = new System.Windows.Forms.Label();
            this.cbColorCorners = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.uCtrlLength = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlWidth = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlThickness = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlWeight = new treeDiM.Basics.UCtrlDouble();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
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
            // lbDescription
            // 
            this.lbDescription.Location = new System.Drawing.Point(13, 38);
            // 
            // tbDescription
            // 
            this.tbDescription.Size = new System.Drawing.Size(384, 20);
            // 
            // graphCtrl
            // 
            this.graphCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphCtrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.graphCtrl.Location = new System.Drawing.Point(221, 70);
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.Size = new System.Drawing.Size(358, 237);
            this.graphCtrl.TabIndex = 20;
            this.graphCtrl.TabStop = false;
            this.graphCtrl.Viewer = null;
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(13, 181);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(31, 13);
            this.lbColor.TabIndex = 21;
            this.lbColor.Text = "Color";
            // 
            // cbColorCorners
            // 
            this.cbColorCorners.Color = System.Drawing.Color.Chocolate;
            this.cbColorCorners.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColorCorners.DropDownHeight = 1;
            this.cbColorCorners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorCorners.DropDownWidth = 1;
            this.cbColorCorners.IntegralHeight = false;
            this.cbColorCorners.ItemHeight = 16;
            this.cbColorCorners.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color"});
            this.cbColorCorners.Location = new System.Drawing.Point(111, 178);
            this.cbColorCorners.Name = "cbColorCorners";
            this.cbColorCorners.Size = new System.Drawing.Size(66, 22);
            this.cbColorCorners.TabIndex = 22;
            this.cbColorCorners.SelectedColorChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // uCtrlLength
            // 
            this.uCtrlLength.Location = new System.Drawing.Point(13, 70);
            this.uCtrlLength.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.uCtrlLength.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlLength.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlLength.Name = "uCtrlLength";
            this.uCtrlLength.Size = new System.Drawing.Size(195, 20);
            this.uCtrlLength.TabIndex = 26;
            this.uCtrlLength.Text = "Length";
            this.uCtrlLength.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlLength.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnValueChanged);
            // 
            // uCtrlWidth
            // 
            this.uCtrlWidth.Location = new System.Drawing.Point(13, 97);
            this.uCtrlWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.uCtrlWidth.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlWidth.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlWidth.Name = "uCtrlWidth";
            this.uCtrlWidth.Size = new System.Drawing.Size(195, 20);
            this.uCtrlWidth.TabIndex = 27;
            this.uCtrlWidth.Text = "Width";
            this.uCtrlWidth.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlWidth.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnValueChanged);
            // 
            // uCtrlThickness
            // 
            this.uCtrlThickness.Location = new System.Drawing.Point(13, 124);
            this.uCtrlThickness.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.uCtrlThickness.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlThickness.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlThickness.Name = "uCtrlThickness";
            this.uCtrlThickness.Size = new System.Drawing.Size(195, 20);
            this.uCtrlThickness.TabIndex = 28;
            this.uCtrlThickness.Text = "Thickness";
            this.uCtrlThickness.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlThickness.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnValueChanged);
            // 
            // uCtrlWeight
            // 
            this.uCtrlWeight.Location = new System.Drawing.Point(13, 151);
            this.uCtrlWeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.uCtrlWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlWeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlWeight.Name = "uCtrlWeight";
            this.uCtrlWeight.Size = new System.Drawing.Size(195, 20);
            this.uCtrlWeight.TabIndex = 29;
            this.uCtrlWeight.Text = "Weight";
            this.uCtrlWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlWeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnValueChanged);
            // 
            // FormNewPalletCorners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.uCtrlWeight);
            this.Controls.Add(this.uCtrlThickness);
            this.Controls.Add(this.uCtrlWidth);
            this.Controls.Add(this.uCtrlLength);
            this.Controls.Add(this.cbColorCorners);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.graphCtrl);
            this.Name = "FormNewPalletCorners";
            this.Text = "Create new pallet corner protector...";
            this.Controls.SetChildIndex(this.bnOk, 0);
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.graphCtrl, 0);
            this.Controls.SetChildIndex(this.lbColor, 0);
            this.Controls.SetChildIndex(this.cbColorCorners, 0);
            this.Controls.SetChildIndex(this.uCtrlLength, 0);
            this.Controls.SetChildIndex(this.uCtrlWidth, 0);
            this.Controls.SetChildIndex(this.uCtrlThickness, 0);
            this.Controls.SetChildIndex(this.uCtrlWeight, 0);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private treeDiM.StackBuilder.Graphics.Graphics3DControl graphCtrl;
        private System.Windows.Forms.Label lbColor;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColorCorners;
        private treeDiM.Basics.UCtrlDouble uCtrlLength;
        private treeDiM.Basics.UCtrlDouble uCtrlWidth;
        private treeDiM.Basics.UCtrlDouble uCtrlThickness;
        private treeDiM.Basics.UCtrlDouble uCtrlWeight;
    }
}
