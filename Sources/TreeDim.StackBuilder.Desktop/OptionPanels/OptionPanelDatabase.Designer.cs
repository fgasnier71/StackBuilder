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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionPanelDatabase));
            this.chkbCloseAfterImport = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkbCloseAfterImport
            // 
            resources.ApplyResources(this.chkbCloseAfterImport, "chkbCloseAfterImport");
            this.chkbCloseAfterImport.Name = "chkbCloseAfterImport";
            this.chkbCloseAfterImport.UseVisualStyleBackColor = true;
            // 
            // OptionPanelDatabase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Database";
            this.Controls.Add(this.chkbCloseAfterImport);
            this.DisplayName = "Database browser";
            this.Name = "OptionPanelDatabase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkbCloseAfterImport;
    }
}
