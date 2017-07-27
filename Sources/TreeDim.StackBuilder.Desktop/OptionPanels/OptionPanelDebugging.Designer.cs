namespace treeDiM.StackBuilder.Desktop
{
    partial class OptionPanelDebugging
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionPanelDebugging));
            this.chkShowLogConsole = new System.Windows.Forms.CheckBox();
            this.bnShowAppFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkShowLogConsole
            // 
            resources.ApplyResources(this.chkShowLogConsole, "chkShowLogConsole");
            this.chkShowLogConsole.Checked = global::treeDiM.StackBuilder.Desktop.Properties.Settings.Default.ShowLogConsole;
            this.chkShowLogConsole.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::treeDiM.StackBuilder.Desktop.Properties.Settings.Default, "ShowLogConsole", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkShowLogConsole.Name = "chkShowLogConsole";
            this.chkShowLogConsole.UseVisualStyleBackColor = true;
            this.chkShowLogConsole.CheckedChanged += new System.EventHandler(this.chkShowLogConsole_CheckedChanged);
            // 
            // bnShowAppFolder
            // 
            resources.ApplyResources(this.bnShowAppFolder, "bnShowAppFolder");
            this.bnShowAppFolder.Name = "bnShowAppFolder";
            this.bnShowAppFolder.UseVisualStyleBackColor = true;
            this.bnShowAppFolder.Click += new System.EventHandler(this.onShowApplicationFolder);
            // 
            // OptionPanelDebugging
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Debugging";
            this.Controls.Add(this.bnShowAppFolder);
            this.Controls.Add(this.chkShowLogConsole);
            this.DisplayName = "Debugging";
            this.Name = "OptionPanelDebugging";
            this.Click += new System.EventHandler(this.onShowApplicationFolder);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkShowLogConsole;
        private System.Windows.Forms.Button bnShowAppFolder;
    }
}
