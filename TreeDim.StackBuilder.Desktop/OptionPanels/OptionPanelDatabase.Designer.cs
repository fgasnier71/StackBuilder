namespace treeDiM.StackBuilder.Desktop
{
    partial class OptionPanelDatabase
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
            this.chkbCloseAfterImport = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkbCloseAfterImport
            // 
            this.chkbCloseAfterImport.AutoSize = true;
            this.chkbCloseAfterImport.Location = new System.Drawing.Point(4, 4);
            this.chkbCloseAfterImport.Name = "chkbCloseAfterImport";
            this.chkbCloseAfterImport.Size = new System.Drawing.Size(216, 17);
            this.chkbCloseAfterImport.TabIndex = 0;
            this.chkbCloseAfterImport.Text = "Close database browser after item import";
            this.chkbCloseAfterImport.UseVisualStyleBackColor = true;
            // 
            // OptionPanelDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Database";
            this.Controls.Add(this.chkbCloseAfterImport);
            this.DisplayName = "Database browser";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "OptionPanelDatabase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkbCloseAfterImport;
    }
}
