namespace treeDiM.StackBuilder.Basics
{
    partial class UCtrlTriDouble
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
            this.nudValueX = new System.Windows.Forms.NumericUpDown();
            this.nudValueY = new System.Windows.Forms.NumericUpDown();
            this.nudValueZ = new System.Windows.Forms.NumericUpDown();
            this.lbName = new System.Windows.Forms.Label();
            this.lbUnit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueZ)).BeginInit();
            this.SuspendLayout();
            // 
            // nudValueX
            // 
            this.nudValueX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudValueX.DecimalPlaces = 2;
            this.nudValueX.Location = new System.Drawing.Point(116, 0);
            this.nudValueX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudValueX.Name = "nudValueX";
            this.nudValueX.Size = new System.Drawing.Size(60, 20);
            this.nudValueX.TabIndex = 0;
            this.nudValueX.ValueChanged += new System.EventHandler(this.nudValue_ValueChanged);
            // 
            // nudValueY
            // 
            this.nudValueY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudValueY.DecimalPlaces = 2;
            this.nudValueY.Location = new System.Drawing.Point(181, 0);
            this.nudValueY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudValueY.Name = "nudValueY";
            this.nudValueY.Size = new System.Drawing.Size(60, 20);
            this.nudValueY.TabIndex = 1;
            this.nudValueY.ValueChanged += new System.EventHandler(this.nudValue_ValueChanged);
            // 
            // nudValueZ
            // 
            this.nudValueZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudValueZ.DecimalPlaces = 2;
            this.nudValueZ.Location = new System.Drawing.Point(247, 0);
            this.nudValueZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudValueZ.Name = "nudValueZ";
            this.nudValueZ.Size = new System.Drawing.Size(60, 20);
            this.nudValueZ.TabIndex = 2;
            this.nudValueZ.ValueChanged += new System.EventHandler(this.nudValue_ValueChanged);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(0, 4);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Name";
            // 
            // lbUnit
            // 
            this.lbUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnit.AutoSize = true;
            this.lbUnit.Location = new System.Drawing.Point(315, 4);
            this.lbUnit.Name = "lbUnit";
            this.lbUnit.Size = new System.Drawing.Size(24, 13);
            this.lbUnit.TabIndex = 4;
            this.lbUnit.Text = "unit";
            // 
            // UCtrlTriDouble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbUnit);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.nudValueZ);
            this.Controls.Add(this.nudValueY);
            this.Controls.Add(this.nudValueX);
            this.Name = "UCtrlTriDouble";
            this.Size = new System.Drawing.Size(350, 20);
            this.SizeChanged += new System.EventHandler(this.onSizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nudValueX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudValueX;
        private System.Windows.Forms.NumericUpDown nudValueY;
        private System.Windows.Forms.NumericUpDown nudValueZ;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbUnit;
    }
}
