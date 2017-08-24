namespace treeDiM.StackBuilder.Desktop
{
    partial class OptionPanelPlugins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionPanelPlugins));
            this.fileSelectPlugin = new treeDiM.UserControls.FileSelect();
            this.chkbUsePlugin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // fileSelectPlugin
            // 
            resources.ApplyResources(this.fileSelectPlugin, "fileSelectPlugin");
            this.fileSelectPlugin.Name = "fileSelectPlugin";
            // 
            // chkbUsePlugin
            // 
            resources.ApplyResources(this.chkbUsePlugin, "chkbUsePlugin");
            this.chkbUsePlugin.Name = "chkbUsePlugin";
            this.chkbUsePlugin.UseVisualStyleBackColor = true;
            this.chkbUsePlugin.CheckedChanged += new System.EventHandler(this.OnCheckUsePlugin);
            // 
            // OptionPanelPlugins
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Plugins";
            this.Controls.Add(this.chkbUsePlugin);
            this.Controls.Add(this.fileSelectPlugin);
            this.DisplayName = "Plugins";
            this.Name = "OptionPanelPlugins";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.FileSelect fileSelectPlugin;
        private System.Windows.Forms.CheckBox chkbUsePlugin;
    }
}
