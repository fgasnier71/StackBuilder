namespace treeDiM.StackBuilder.GUIExtension
{
    partial class UCtrlCase
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
            this.uCtrlDimensions = new treeDiM.Basics.UCtrlTriDouble();
            this.uCtrlWeight = new treeDiM.Basics.UCtrlDouble();
            this.SuspendLayout();
            // 
            // uCtrlDimensions
            // 
            this.uCtrlDimensions.Location = new System.Drawing.Point(3, 10);
            this.uCtrlDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlDimensions.Name = "uCtrlDimensions";
            this.uCtrlDimensions.Size = new System.Drawing.Size(300, 20);
            this.uCtrlDimensions.TabIndex = 1;
            this.uCtrlDimensions.Text = "Dimensions";
            this.uCtrlDimensions.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDimensions.ValueX = 0D;
            this.uCtrlDimensions.ValueY = 0D;
            this.uCtrlDimensions.ValueZ = 0D;
            // 
            // uCtrlWeight
            // 
            this.uCtrlWeight.Location = new System.Drawing.Point(3, 36);
            this.uCtrlWeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlWeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlWeight.Name = "uCtrlWeight";
            this.uCtrlWeight.Size = new System.Drawing.Size(176, 20);
            this.uCtrlWeight.TabIndex = 2;
            this.uCtrlWeight.Text = "Weight";
            this.uCtrlWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlWeight.Value = 0D;
            // 
            // UCtrlCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.uCtrlWeight);
            this.Controls.Add(this.uCtrlDimensions);
            this.Name = "UCtrlCase";
            this.Size = new System.Drawing.Size(300, 110);
            this.Controls.SetChildIndex(this.uCtrlDimensions, 0);
            this.Controls.SetChildIndex(this.uCtrlWeight, 0);
            this.ResumeLayout(false);
        }
        #endregion

        private treeDiM.Basics.UCtrlTriDouble uCtrlDimensions;
        private treeDiM.Basics.UCtrlDouble uCtrlWeight;
    }
}
