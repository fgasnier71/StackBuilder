namespace treeDiM.StackBuilder.ExcelListEvaluator
{
    partial class OptionsPanelImageSize
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
            this.lbImageSize = new System.Windows.Forms.Label();
            this.nudImageSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lbImageSize
            // 
            this.lbImageSize.AutoSize = true;
            this.lbImageSize.Location = new System.Drawing.Point(6, 26);
            this.lbImageSize.Name = "lbImageSize";
            this.lbImageSize.Size = new System.Drawing.Size(57, 13);
            this.lbImageSize.TabIndex = 0;
            this.lbImageSize.Text = "Image size";
            // 
            // nudImageSize
            // 
            this.nudImageSize.Location = new System.Drawing.Point(236, 24);
            this.nudImageSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudImageSize.Name = "nudImageSize";
            this.nudImageSize.Size = new System.Drawing.Size(80, 20);
            this.nudImageSize.TabIndex = 1;
            // 
            // OptionsPanelImageSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Image size";
            this.Controls.Add(this.nudImageSize);
            this.Controls.Add(this.lbImageSize);
            this.DisplayName = "Image size";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "OptionsPanelImageSize";
            this.Size = new System.Drawing.Size(400, 215);
            ((System.ComponentModel.ISupportInitialize)(this.nudImageSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbImageSize;
        private System.Windows.Forms.NumericUpDown nudImageSize;
    }
}
