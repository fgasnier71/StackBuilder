namespace treeDiM.StackBuilder.GUIExtension
{
    partial class UCtrlBundle
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
            this.uCtrlDimensions = new treeDiM.Basics.UCtrlDualDouble();
            this.uCtrlUnitThickness = new treeDiM.Basics.UCtrlDouble();
            this.lbNoFlats = new System.Windows.Forms.Label();
            this.nudNoFlats = new System.Windows.Forms.NumericUpDown();
            this.uCtrlUnitWeight = new treeDiM.Basics.UCtrlDouble();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoFlats)).BeginInit();
            this.SuspendLayout();
            // 
            // uCtrlDimensions
            // 
            this.uCtrlDimensions.Location = new System.Drawing.Point(3, 3);
            this.uCtrlDimensions.Name = "uCtrlDimensions";
            this.uCtrlDimensions.Size = new System.Drawing.Size(274, 20);
            this.uCtrlDimensions.TabIndex = 1;
            this.uCtrlDimensions.Text = "Dimensions";
            this.uCtrlDimensions.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDimensions.ValueX = 0D;
            this.uCtrlDimensions.ValueY = 0D;
            // 
            // uCtrlUnitThickness
            // 
            this.uCtrlUnitThickness.Location = new System.Drawing.Point(3, 31);
            this.uCtrlUnitThickness.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlUnitThickness.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlUnitThickness.Name = "uCtrlUnitThickness";
            this.uCtrlUnitThickness.Size = new System.Drawing.Size(212, 20);
            this.uCtrlUnitThickness.TabIndex = 2;
            this.uCtrlUnitThickness.Text = "Unit thickness";
            this.uCtrlUnitThickness.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlUnitThickness.Value = 0D;
            // 
            // lbNoFlats
            // 
            this.lbNoFlats.AutoSize = true;
            this.lbNoFlats.Location = new System.Drawing.Point(4, 89);
            this.lbNoFlats.Name = "lbNoFlats";
            this.lbNoFlats.Size = new System.Drawing.Size(78, 13);
            this.lbNoFlats.TabIndex = 3;
            this.lbNoFlats.Text = "Number of flats";
            // 
            // nudNoFlats
            // 
            this.nudNoFlats.Location = new System.Drawing.Point(117, 85);
            this.nudNoFlats.Name = "nudNoFlats";
            this.nudNoFlats.Size = new System.Drawing.Size(60, 20);
            this.nudNoFlats.TabIndex = 4;
            // 
            // uCtrlUnitWeight
            // 
            this.uCtrlUnitWeight.Location = new System.Drawing.Point(3, 58);
            this.uCtrlUnitWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlUnitWeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlUnitWeight.Name = "uCtrlUnitWeight";
            this.uCtrlUnitWeight.Size = new System.Drawing.Size(212, 20);
            this.uCtrlUnitWeight.TabIndex = 5;
            this.uCtrlUnitWeight.Text = "Unit weight";
            this.uCtrlUnitWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlUnitWeight.Value = 0D;
            // 
            // UCtrlBundle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.uCtrlUnitWeight);
            this.Controls.Add(this.nudNoFlats);
            this.Controls.Add(this.lbNoFlats);
            this.Controls.Add(this.uCtrlUnitThickness);
            this.Controls.Add(this.uCtrlDimensions);
            this.Name = "UCtrlBundle";
            ((System.ComponentModel.ISupportInitialize)(this.nudNoFlats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private treeDiM.Basics.UCtrlDualDouble uCtrlDimensions;
        private treeDiM.Basics.UCtrlDouble uCtrlUnitThickness;
        private System.Windows.Forms.Label lbNoFlats;
        private System.Windows.Forms.NumericUpDown nudNoFlats;
        private treeDiM.Basics.UCtrlDouble uCtrlUnitWeight;
    }
}
