namespace treeDiM.Basics
{
    partial class UCtrlDualDouble
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
            this.lbName = new System.Windows.Forms.Label();
            this.lbUnit = new System.Windows.Forms.Label();
            this.nudValueY = new System.Windows.Forms.NumericUpDown();
            this.nudValueX = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueX)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.AutoEllipsis = true;
            this.lbName.Location = new System.Drawing.Point(0, 2);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(128, 20);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // lbUnit
            // 
            this.lbUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnit.AutoSize = true;
            this.lbUnit.Location = new System.Drawing.Point(265, 4);
            this.lbUnit.Name = "lbUnit";
            this.lbUnit.Size = new System.Drawing.Size(24, 13);
            this.lbUnit.TabIndex = 6;
            this.lbUnit.Text = "unit";
            // 
            // nudValueY
            // 
            this.nudValueY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudValueY.DecimalPlaces = 2;
            this.nudValueY.Location = new System.Drawing.Point(200, 0);
            this.nudValueY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudValueY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudValueY.Name = "nudValueY";
            this.nudValueY.Size = new System.Drawing.Size(60, 20);
            this.nudValueY.TabIndex = 5;
            this.nudValueY.ValueChanged += new System.EventHandler(this.OnValueChangedLocal);
            // 
            // nudValueX
            // 
            this.nudValueX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudValueX.DecimalPlaces = 2;
            this.nudValueX.Location = new System.Drawing.Point(134, 0);
            this.nudValueX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudValueX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudValueX.Name = "nudValueX";
            this.nudValueX.Size = new System.Drawing.Size(60, 20);
            this.nudValueX.TabIndex = 7;
            this.nudValueX.ValueChanged += new System.EventHandler(this.OnValueChangedLocal);
            // 
            // UCtrlDualDouble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudValueX);
            this.Controls.Add(this.lbUnit);
            this.Controls.Add(this.nudValueY);
            this.Controls.Add(this.lbName);
            this.Name = "UCtrlDualDouble";
            this.Size = new System.Drawing.Size(300, 20);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nudValueY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbUnit;
        private System.Windows.Forms.NumericUpDown nudValueY;
        private System.Windows.Forms.NumericUpDown nudValueX;
    }
}
