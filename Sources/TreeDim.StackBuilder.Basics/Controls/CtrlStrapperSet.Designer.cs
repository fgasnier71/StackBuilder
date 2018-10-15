namespace treeDiM.StackBuilder.Basics.Controls
{
    partial class CtrlStrapperSet
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlStrapperSet));
            this.cbDir = new System.Windows.Forms.ComboBox();
            this.lbDirection = new System.Windows.Forms.Label();
            this.bnEditAbscissa = new System.Windows.Forms.Button();
            this.uCtrlEvenSpacing = new treeDiM.StackBuilder.Basics.UCtrlOptDouble();
            this.uCtrlWidth = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlNumber = new treeDiM.StackBuilder.Basics.UCtrlInt();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbDir
            // 
            this.cbDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDir.FormattingEnabled = true;
            this.cbDir.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.cbDir.Location = new System.Drawing.Point(218, 10);
            this.cbDir.Name = "cbDir";
            this.cbDir.Size = new System.Drawing.Size(55, 21);
            this.cbDir.TabIndex = 0;
            this.cbDir.SelectedIndexChanged += new System.EventHandler(this.OnDirectionChanged);
            // 
            // lbDirection
            // 
            this.lbDirection.AutoSize = true;
            this.lbDirection.Location = new System.Drawing.Point(173, 12);
            this.lbDirection.Name = "lbDirection";
            this.lbDirection.Size = new System.Drawing.Size(26, 13);
            this.lbDirection.TabIndex = 1;
            this.lbDirection.Text = "Axis";
            // 
            // bnEditAbscissa
            // 
            this.bnEditAbscissa.Location = new System.Drawing.Point(507, 38);
            this.bnEditAbscissa.Name = "bnEditAbscissa";
            this.bnEditAbscissa.Size = new System.Drawing.Size(24, 19);
            this.bnEditAbscissa.TabIndex = 5;
            this.bnEditAbscissa.Text = "...";
            this.bnEditAbscissa.UseVisualStyleBackColor = true;
            this.bnEditAbscissa.Click += new System.EventHandler(this.OnEditAbscissa);
            // 
            // uCtrlEvenSpacing
            // 
            this.uCtrlEvenSpacing.Location = new System.Drawing.Point(293, 37);
            this.uCtrlEvenSpacing.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlEvenSpacing.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlEvenSpacing.Name = "uCtrlEvenSpacing";
            this.uCtrlEvenSpacing.Size = new System.Drawing.Size(208, 20);
            this.uCtrlEvenSpacing.TabIndex = 4;
            this.uCtrlEvenSpacing.Text = "Even spacing";
            this.uCtrlEvenSpacing.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlEvenSpacing.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlOptDouble.ValueChangedDelegate(this.OnSpacingChanged);
            // 
            // uCtrlWidth
            // 
            this.uCtrlWidth.Location = new System.Drawing.Point(6, 9);
            this.uCtrlWidth.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlWidth.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlWidth.Name = "uCtrlWidth";
            this.uCtrlWidth.Size = new System.Drawing.Size(165, 20);
            this.uCtrlWidth.TabIndex = 3;
            this.uCtrlWidth.Text = "Width";
            this.uCtrlWidth.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlWidth.Value = 0D;
            this.uCtrlWidth.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.ValueChangedDelegate(this.OnStrapperChanged);
            // 
            // uCtrlNumber
            // 
            this.uCtrlNumber.Location = new System.Drawing.Point(293, 12);
            this.uCtrlNumber.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlNumber.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlNumber.Name = "uCtrlNumber";
            this.uCtrlNumber.Size = new System.Drawing.Size(171, 20);
            this.uCtrlNumber.TabIndex = 2;
            this.uCtrlNumber.Text = "Number";
            this.uCtrlNumber.Value = 0;
            this.uCtrlNumber.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlInt.ValueChangedDelegate(this.OnNumberChanged);
            // 
            // cbColor
            // 
            this.cbColor.Color = System.Drawing.Color.Black;
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
            "Color"});
            this.cbColor.Location = new System.Drawing.Point(73, 35);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(61, 22);
            this.cbColor.TabIndex = 6;
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.OnStrapperChanged);
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(6, 38);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(31, 13);
            this.lbColor.TabIndex = 7;
            this.lbColor.Text = "Color";
            // 
            // CtrlStrapperSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.bnEditAbscissa);
            this.Controls.Add(this.uCtrlEvenSpacing);
            this.Controls.Add(this.uCtrlWidth);
            this.Controls.Add(this.uCtrlNumber);
            this.Controls.Add(this.lbDirection);
            this.Controls.Add(this.cbDir);
            this.Name = "CtrlStrapperSet";
            this.Size = new System.Drawing.Size(540, 60);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDir;
        private System.Windows.Forms.Label lbDirection;
        private UCtrlInt uCtrlNumber;
        private UCtrlDouble uCtrlWidth;
        private UCtrlOptDouble uCtrlEvenSpacing;
        private System.Windows.Forms.Button bnEditAbscissa;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.Label lbColor;
    }
}
