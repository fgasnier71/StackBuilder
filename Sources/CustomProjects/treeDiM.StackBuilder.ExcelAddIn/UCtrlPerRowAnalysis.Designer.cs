namespace treeDiM.StackBuilder.ExcelAddIn
{
    partial class UCtrlPerRowAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCtrlPerRowAnalysis));
            this.bnCompute = new System.Windows.Forms.Button();
            this.gpPallets = new System.Windows.Forms.GroupBox();
            this.bnEditPallets = new System.Windows.Forms.Button();
            this.bnRefreshPallets = new System.Windows.Forms.Button();
            this.lbPallets = new System.Windows.Forms.CheckedListBox();
            this.gbConstraints = new System.Windows.Forms.GroupBox();
            this.chkbOnlyZOrientation = new System.Windows.Forms.CheckBox();
            this.uCtrlOverhang = new treeDiM.Basics.UCtrlDualDouble();
            this.uCtrlMaxPalletHeight = new treeDiM.Basics.UCtrlDouble();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.reportFolderSelect = new treeDiM.UserControls.FileSelect();
            this.chkbGenerateReportInFolder = new System.Windows.Forms.CheckBox();
            this.folderSelect = new treeDiM.UserControls.FileSelect();
            this.chkbGenerateImageInFolder = new System.Windows.Forms.CheckBox();
            this.chkbGenerateImageInRow = new System.Windows.Forms.CheckBox();
            this.gpPallets.SuspendLayout();
            this.gbConstraints.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnCompute
            // 
            resources.ApplyResources(this.bnCompute, "bnCompute");
            this.bnCompute.Name = "bnCompute";
            this.bnCompute.UseVisualStyleBackColor = true;
            this.bnCompute.Click += new System.EventHandler(this.OnCompute);
            // 
            // gpPallets
            // 
            resources.ApplyResources(this.gpPallets, "gpPallets");
            this.gpPallets.Controls.Add(this.bnEditPallets);
            this.gpPallets.Controls.Add(this.bnRefreshPallets);
            this.gpPallets.Controls.Add(this.lbPallets);
            this.gpPallets.Name = "gpPallets";
            this.gpPallets.TabStop = false;
            // 
            // bnEditPallets
            // 
            resources.ApplyResources(this.bnEditPallets, "bnEditPallets");
            this.bnEditPallets.Name = "bnEditPallets";
            this.bnEditPallets.UseVisualStyleBackColor = true;
            this.bnEditPallets.Click += new System.EventHandler(this.OnEditPallets);
            // 
            // bnRefreshPallets
            // 
            resources.ApplyResources(this.bnRefreshPallets, "bnRefreshPallets");
            this.bnRefreshPallets.Name = "bnRefreshPallets";
            this.bnRefreshPallets.UseVisualStyleBackColor = true;
            this.bnRefreshPallets.Click += new System.EventHandler(this.OnRefreshPallets);
            // 
            // lbPallets
            // 
            resources.ApplyResources(this.lbPallets, "lbPallets");
            this.lbPallets.FormattingEnabled = true;
            this.lbPallets.Name = "lbPallets";
            // 
            // gbConstraints
            // 
            resources.ApplyResources(this.gbConstraints, "gbConstraints");
            this.gbConstraints.Controls.Add(this.chkbOnlyZOrientation);
            this.gbConstraints.Controls.Add(this.uCtrlOverhang);
            this.gbConstraints.Controls.Add(this.uCtrlMaxPalletHeight);
            this.gbConstraints.Name = "gbConstraints";
            this.gbConstraints.TabStop = false;
            // 
            // chkbOnlyZOrientation
            // 
            resources.ApplyResources(this.chkbOnlyZOrientation, "chkbOnlyZOrientation");
            this.chkbOnlyZOrientation.Name = "chkbOnlyZOrientation";
            this.chkbOnlyZOrientation.UseVisualStyleBackColor = true;
            // 
            // uCtrlOverhang
            // 
            resources.ApplyResources(this.uCtrlOverhang, "uCtrlOverhang");
            this.uCtrlOverhang.MinValue = -10000D;
            this.uCtrlOverhang.Name = "uCtrlOverhang";
            this.uCtrlOverhang.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOverhang.ValueX = 0D;
            this.uCtrlOverhang.ValueY = 0D;
            // 
            // uCtrlMaxPalletHeight
            // 
            resources.ApplyResources(this.uCtrlMaxPalletHeight, "uCtrlMaxPalletHeight");
            this.uCtrlMaxPalletHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMaxPalletHeight.Name = "uCtrlMaxPalletHeight";
            this.uCtrlMaxPalletHeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMaxPalletHeight.Value = 0D;
            // 
            // gbOptions
            // 
            resources.ApplyResources(this.gbOptions, "gbOptions");
            this.gbOptions.Controls.Add(this.reportFolderSelect);
            this.gbOptions.Controls.Add(this.chkbGenerateReportInFolder);
            this.gbOptions.Controls.Add(this.folderSelect);
            this.gbOptions.Controls.Add(this.chkbGenerateImageInFolder);
            this.gbOptions.Controls.Add(this.chkbGenerateImageInRow);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.TabStop = false;
            // 
            // reportFolderSelect
            // 
            resources.ApplyResources(this.reportFolderSelect, "reportFolderSelect");
            this.reportFolderSelect.Name = "reportFolderSelect";
            // 
            // chkbGenerateReportInFolder
            // 
            resources.ApplyResources(this.chkbGenerateReportInFolder, "chkbGenerateReportInFolder");
            this.chkbGenerateReportInFolder.Name = "chkbGenerateReportInFolder";
            this.chkbGenerateReportInFolder.UseVisualStyleBackColor = true;
            this.chkbGenerateReportInFolder.CheckedChanged += new System.EventHandler(this.OnGenerateReportChanged);
            // 
            // folderSelect
            // 
            resources.ApplyResources(this.folderSelect, "folderSelect");
            this.folderSelect.Name = "folderSelect";
            // 
            // chkbGenerateImageInFolder
            // 
            resources.ApplyResources(this.chkbGenerateImageInFolder, "chkbGenerateImageInFolder");
            this.chkbGenerateImageInFolder.Name = "chkbGenerateImageInFolder";
            this.chkbGenerateImageInFolder.UseVisualStyleBackColor = true;
            this.chkbGenerateImageInFolder.CheckedChanged += new System.EventHandler(this.OnGenerateImagesChanged);
            // 
            // chkbGenerateImageInRow
            // 
            resources.ApplyResources(this.chkbGenerateImageInRow, "chkbGenerateImageInRow");
            this.chkbGenerateImageInRow.Name = "chkbGenerateImageInRow";
            this.chkbGenerateImageInRow.UseVisualStyleBackColor = true;
            // 
            // UCtrlPerRowAnalysis
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.gbConstraints);
            this.Controls.Add(this.gpPallets);
            this.Controls.Add(this.bnCompute);
            this.Name = "UCtrlPerRowAnalysis";
            this.gpPallets.ResumeLayout(false);
            this.gbConstraints.ResumeLayout(false);
            this.gbConstraints.PerformLayout();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnCompute;
        private System.Windows.Forms.GroupBox gpPallets;
        private System.Windows.Forms.GroupBox gbConstraints;
        private Basics.UCtrlDouble uCtrlMaxPalletHeight;
        private Basics.UCtrlDualDouble uCtrlOverhang;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.CheckBox chkbOnlyZOrientation;
        private System.Windows.Forms.CheckBox chkbGenerateImageInFolder;
        private System.Windows.Forms.CheckBox chkbGenerateImageInRow;
        private System.Windows.Forms.CheckedListBox lbPallets;
        private UserControls.FileSelect folderSelect;
        private System.Windows.Forms.Button bnRefreshPallets;
        private System.Windows.Forms.Button bnEditPallets;
        private UserControls.FileSelect reportFolderSelect;
        private System.Windows.Forms.CheckBox chkbGenerateReportInFolder;
    }
}
