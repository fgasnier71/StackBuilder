namespace treeDiM.StackBuilder.Desktop
{
    partial class OptionPanelPalletEdition
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
            this.uCtrlDistAbove = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.SuspendLayout();
            // 
            // uCtrlDistAbove
            // 
            this.uCtrlDistAbove.Location = new System.Drawing.Point(4, 4);
            this.uCtrlDistAbove.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlDistAbove.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlDistAbove.Name = "uCtrlDistAbove";
            this.uCtrlDistAbove.Size = new System.Drawing.Size(333, 20);
            this.uCtrlDistAbove.TabIndex = 0;
            this.uCtrlDistAbove.Text = "Distance above selected layer";
            this.uCtrlDistAbove.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDistAbove.Value = 0D;
            // 
            // OptionPanelPalletEdition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Pallet edition";
            this.Controls.Add(this.uCtrlDistAbove);
            this.DisplayName = "Pallet edition parameters";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "OptionPanelPalletEdition";
            this.ResumeLayout(false);

        }

        #endregion

        private Basics.UCtrlDouble uCtrlDistAbove;
    }
}