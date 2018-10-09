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
            this.comboBoxDir = new System.Windows.Forms.ComboBox();
            this.lbDirection = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.rbAbscissa1 = new System.Windows.Forms.RadioButton();
            this.rbAbscissa2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDir
            // 
            this.comboBoxDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDir.FormattingEnabled = true;
            this.comboBoxDir.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.comboBoxDir.Location = new System.Drawing.Point(68, 3);
            this.comboBoxDir.Name = "comboBoxDir";
            this.comboBoxDir.Size = new System.Drawing.Size(55, 21);
            this.comboBoxDir.TabIndex = 0;
            // 
            // lbDirection
            // 
            this.lbDirection.AutoSize = true;
            this.lbDirection.Location = new System.Drawing.Point(3, 6);
            this.lbDirection.Name = "lbDirection";
            this.lbDirection.Size = new System.Drawing.Size(62, 13);
            this.lbDirection.TabIndex = 1;
            this.lbDirection.Text = "Around axis";
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(3, 32);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(44, 13);
            this.lbNumber.TabIndex = 2;
            this.lbNumber.Text = "Number";
            // 
            // nudNumber
            // 
            this.nudNumber.Location = new System.Drawing.Point(68, 32);
            this.nudNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNumber.Name = "nudNumber";
            this.nudNumber.Size = new System.Drawing.Size(55, 20);
            this.nudNumber.TabIndex = 3;
            // 
            // rbAbscissa1
            // 
            this.rbAbscissa1.AutoSize = true;
            this.rbAbscissa1.Location = new System.Drawing.Point(134, 7);
            this.rbAbscissa1.Name = "rbAbscissa1";
            this.rbAbscissa1.Size = new System.Drawing.Size(95, 17);
            this.rbAbscissa1.TabIndex = 4;
            this.rbAbscissa1.TabStop = true;
            this.rbAbscissa1.Text = "Evenly spaced";
            this.rbAbscissa1.UseVisualStyleBackColor = true;
            // 
            // rbAbscissa2
            // 
            this.rbAbscissa2.AutoSize = true;
            this.rbAbscissa2.Location = new System.Drawing.Point(134, 30);
            this.rbAbscissa2.Name = "rbAbscissa2";
            this.rbAbscissa2.Size = new System.Drawing.Size(104, 17);
            this.rbAbscissa2.TabIndex = 5;
            this.rbAbscissa2.TabStop = true;
            this.rbAbscissa2.Text = "Custom positions";
            this.rbAbscissa2.UseVisualStyleBackColor = true;
            // 
            // CtrlStrapperSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbAbscissa2);
            this.Controls.Add(this.rbAbscissa1);
            this.Controls.Add(this.nudNumber);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.lbDirection);
            this.Controls.Add(this.comboBoxDir);
            this.Name = "CtrlStrapperSet";
            this.Size = new System.Drawing.Size(400, 80);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDir;
        private System.Windows.Forms.Label lbDirection;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.RadioButton rbAbscissa1;
        private System.Windows.Forms.RadioButton rbAbscissa2;
    }
}
