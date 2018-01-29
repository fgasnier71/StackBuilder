namespace treeDiM.StackBuilder.Basics.Controls
{
    partial class UCtrlTriInt
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
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.nudZ = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).BeginInit();
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
            this.lbName.Size = new System.Drawing.Size(103, 20);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // nudX
            // 
            this.nudX.Location = new System.Drawing.Point(109, 0);
            this.nudX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(60, 20);
            this.nudX.TabIndex = 1;
            this.nudX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudX.ValueChanged += new System.EventHandler(this.OnValueChangedLocal);
            // 
            // nudY
            // 
            this.nudY.Location = new System.Drawing.Point(173, 0);
            this.nudY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(60, 20);
            this.nudY.TabIndex = 2;
            this.nudY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudY.ValueChanged += new System.EventHandler(this.OnValueChangedLocal);
            // 
            // nudZ
            // 
            this.nudZ.Location = new System.Drawing.Point(237, 0);
            this.nudZ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudZ.Name = "nudZ";
            this.nudZ.Size = new System.Drawing.Size(60, 20);
            this.nudZ.TabIndex = 3;
            this.nudZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudZ.ValueChanged += new System.EventHandler(this.OnValueChangedLocal);
            // 
            // UCtrlTriInt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudZ);
            this.Controls.Add(this.nudY);
            this.Controls.Add(this.nudX);
            this.Controls.Add(this.lbName);
            this.Name = "UCtrlTriInt";
            this.Size = new System.Drawing.Size(300, 20);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.NumericUpDown nudZ;
    }
}
