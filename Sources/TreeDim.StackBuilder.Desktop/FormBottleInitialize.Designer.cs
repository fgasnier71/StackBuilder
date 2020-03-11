namespace treeDiM.StackBuilder.Desktop
{
    partial class FormBottleInitialize
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
            this.uCtrlMaxDiameter = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlHeight = new treeDiM.Basics.UCtrlDouble();
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uCtrlMaxDiameter
            // 
            this.uCtrlMaxDiameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uCtrlMaxDiameter.Location = new System.Drawing.Point(2, 7);
            this.uCtrlMaxDiameter.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlMaxDiameter.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMaxDiameter.Name = "uCtrlMaxDiameter";
            this.uCtrlMaxDiameter.Size = new System.Drawing.Size(267, 20);
            this.uCtrlMaxDiameter.TabIndex = 0;
            this.uCtrlMaxDiameter.Text = "Maximum diameter";
            this.uCtrlMaxDiameter.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            // 
            // uCtrlHeight
            // 
            this.uCtrlHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uCtrlHeight.Location = new System.Drawing.Point(2, 33);
            this.uCtrlHeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlHeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlHeight.Name = "uCtrlHeight";
            this.uCtrlHeight.Size = new System.Drawing.Size(267, 20);
            this.uCtrlHeight.TabIndex = 1;
            this.uCtrlHeight.Text = "Height";
            this.uCtrlHeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            // 
            // bnOK
            // 
            this.bnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Location = new System.Drawing.Point(277, 7);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 2;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(277, 34);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 3;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // FormBottleInitialize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 61);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.uCtrlHeight);
            this.Controls.Add(this.uCtrlMaxDiameter);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 100);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 100);
            this.Name = "FormBottleInitialize";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Initialize diameter and height";
            this.ResumeLayout(false);

        }

        #endregion

        private treeDiM.Basics.UCtrlDouble uCtrlMaxDiameter;
        private treeDiM.Basics.UCtrlDouble uCtrlHeight;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
    }
}