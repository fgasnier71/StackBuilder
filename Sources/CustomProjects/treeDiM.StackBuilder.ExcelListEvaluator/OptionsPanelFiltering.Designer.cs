namespace treeDiM.StackBuilder.ExcelListEvaluator
{
    partial class OptionsPanelFiltering
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
            this.uCtrlLargestDimMin = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.nudStackCountMax = new System.Windows.Forms.NumericUpDown();
            this.lbDrawing = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudStackCountMax)).BeginInit();
            this.SuspendLayout();
            // 
            // uCtrlLargestDimMin
            // 
            this.uCtrlLargestDimMin.Location = new System.Drawing.Point(0, 71);
            this.uCtrlLargestDimMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uCtrlLargestDimMin.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlLargestDimMin.Name = "uCtrlLargestDimMin";
            this.uCtrlLargestDimMin.Size = new System.Drawing.Size(340, 20);
            this.uCtrlLargestDimMin.TabIndex = 5;
            this.uCtrlLargestDimMin.Text = "Skip computation if largest dimension below ";
            this.uCtrlLargestDimMin.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlLargestDimMin.Value = 10D;
            // 
            // nudStackCountMax
            // 
            this.nudStackCountMax.Location = new System.Drawing.Point(242, 44);
            this.nudStackCountMax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudStackCountMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStackCountMax.Name = "nudStackCountMax";
            this.nudStackCountMax.Size = new System.Drawing.Size(61, 20);
            this.nudStackCountMax.TabIndex = 4;
            this.nudStackCountMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbDrawing
            // 
            this.lbDrawing.AutoSize = true;
            this.lbDrawing.Location = new System.Drawing.Point(0, 44);
            this.lbDrawing.Name = "lbDrawing";
            this.lbDrawing.Size = new System.Drawing.Size(203, 13);
            this.lbDrawing.TabIndex = 3;
            this.lbDrawing.Text = "Skip drawing if number of cases exceeds:";
            // 
            // OptionsPanelFiltering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Case filtering";
            this.Controls.Add(this.uCtrlLargestDimMin);
            this.Controls.Add(this.nudStackCountMax);
            this.Controls.Add(this.lbDrawing);
            this.DisplayName = "Case filtering";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "OptionsPanelFiltering";
            this.Size = new System.Drawing.Size(400, 215);
            ((System.ComponentModel.ISupportInitialize)(this.nudStackCountMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Basics.UCtrlDouble uCtrlLargestDimMin;
        private System.Windows.Forms.NumericUpDown nudStackCountMax;
        private System.Windows.Forms.Label lbDrawing;
    }
}