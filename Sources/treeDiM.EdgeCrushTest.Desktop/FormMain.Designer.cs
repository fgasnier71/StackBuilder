namespace treeDiM.EdgeCrushTest.Desktop
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMIFile = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMIMode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMIMode1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMIMode2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMIData = new System.Windows.Forms.ToolStripMenuItem();
            this.editMaterialListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPalletListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMIHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMIAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMILogConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel
            // 
            resources.ApplyResources(this.dockPanel, "dockPanel");
            this.dockPanel.Name = "dockPanel";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMIFile,
            this.toolStripMIMode,
            this.toolStripMIData,
            this.toolStripMIHelp});
            resources.ApplyResources(this.menuStripMain, "menuStripMain");
            this.menuStripMain.Name = "menuStripMain";
            // 
            // toolStripMIFile
            // 
            this.toolStripMIFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.toolStripMIFile.Name = "toolStripMIFile";
            resources.ApplyResources(this.toolStripMIFile, "toolStripMIFile");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExit);
            // 
            // toolStripMIMode
            // 
            this.toolStripMIMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMIMode1,
            this.toolStripMIMode2});
            this.toolStripMIMode.Name = "toolStripMIMode";
            resources.ApplyResources(this.toolStripMIMode, "toolStripMIMode");
            // 
            // toolStripMIMode1
            // 
            this.toolStripMIMode1.Name = "toolStripMIMode1";
            resources.ApplyResources(this.toolStripMIMode1, "toolStripMIMode1");
            this.toolStripMIMode1.Click += new System.EventHandler(this.OnMode1);
            // 
            // toolStripMIMode2
            // 
            this.toolStripMIMode2.Name = "toolStripMIMode2";
            resources.ApplyResources(this.toolStripMIMode2, "toolStripMIMode2");
            this.toolStripMIMode2.Click += new System.EventHandler(this.OnMode2);
            // 
            // toolStripMIData
            // 
            this.toolStripMIData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMaterialListToolStripMenuItem,
            this.editPalletListToolStripMenuItem});
            this.toolStripMIData.Name = "toolStripMIData";
            resources.ApplyResources(this.toolStripMIData, "toolStripMIData");
            // 
            // editMaterialListToolStripMenuItem
            // 
            this.editMaterialListToolStripMenuItem.Name = "editMaterialListToolStripMenuItem";
            resources.ApplyResources(this.editMaterialListToolStripMenuItem, "editMaterialListToolStripMenuItem");
            this.editMaterialListToolStripMenuItem.Click += new System.EventHandler(this.OnEditMaterialList);
            // 
            // editPalletListToolStripMenuItem
            // 
            this.editPalletListToolStripMenuItem.Name = "editPalletListToolStripMenuItem";
            resources.ApplyResources(this.editPalletListToolStripMenuItem, "editPalletListToolStripMenuItem");
            this.editPalletListToolStripMenuItem.Click += new System.EventHandler(this.OnEditPalletList);
            // 
            // toolStripMIHelp
            // 
            this.toolStripMIHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMILogConsole,
            this.toolStripSeparator1,
            this.toolStripMIAbout});
            this.toolStripMIHelp.Name = "toolStripMIHelp";
            resources.ApplyResources(this.toolStripMIHelp, "toolStripMIHelp");
            // 
            // toolStripMIAbout
            // 
            this.toolStripMIAbout.Name = "toolStripMIAbout";
            resources.ApplyResources(this.toolStripMIAbout, "toolStripMIAbout");
            this.toolStripMIAbout.Click += new System.EventHandler(this.OnAbout);
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            this.timerMain.Interval = 500;
            this.timerMain.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripMILogConsole
            // 
            this.toolStripMILogConsole.Name = "toolStripMILogConsole";
            resources.ApplyResources(this.toolStripMILogConsole, "toolStripMILogConsole");
            this.toolStripMILogConsole.Click += new System.EventHandler(this.OnShowLogConsole);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.menuStripMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIFile;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIAbout;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIMode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIMode1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIMode2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIData;
        private System.Windows.Forms.ToolStripMenuItem editMaterialListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPalletListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMILogConsole;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

