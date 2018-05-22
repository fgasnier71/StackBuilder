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
            this.uCtrlOverhang = new treeDiM.StackBuilder.Basics.UCtrlDualDouble();
            this.uCtrlMaxPalletHeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.folderSelect = new treeDiM.UserControls.FileSelect();
            this.chkbGenerateImageInFolder = new System.Windows.Forms.CheckBox();
            this.chkbGenerateImageInRow = new System.Windows.Forms.CheckBox();
            this.chkbGenerateReportInFolder = new System.Windows.Forms.CheckBox();
            this.reportFolderSelect = new treeDiM.UserControls.FileSelect();
            this.gpPallets.SuspendLayout();
            this.gbConstraints.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnCompute
            // 
            this.bnCompute.Location = new System.Drawing.Point(11, 413);
            this.bnCompute.Name = "bnCompute";
            this.bnCompute.Size = new System.Drawing.Size(75, 23);
            this.bnCompute.TabIndex = 0;
            this.bnCompute.Text = "Compute";
            this.bnCompute.UseVisualStyleBackColor = true;
            this.bnCompute.Click += new System.EventHandler(this.OnCompute);
            // 
            // gpPallets
            // 
            this.gpPallets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpPallets.Controls.Add(this.bnEditPallets);
            this.gpPallets.Controls.Add(this.bnRefreshPallets);
            this.gpPallets.Controls.Add(this.lbPallets);
            this.gpPallets.Location = new System.Drawing.Point(4, 4);
            this.gpPallets.Name = "gpPallets";
            this.gpPallets.Size = new System.Drawing.Size(293, 150);
            this.gpPallets.TabIndex = 1;
            this.gpPallets.TabStop = false;
            this.gpPallets.Text = "Pallets";
            // 
            // bnEditPallets
            // 
            this.bnEditPallets.Image = ((System.Drawing.Image)(resources.GetObject("bnEditPallets.Image")));
            this.bnEditPallets.Location = new System.Drawing.Point(3, 20);
            this.bnEditPallets.Name = "bnEditPallets";
            this.bnEditPallets.Size = new System.Drawing.Size(79, 36);
            this.bnEditPallets.TabIndex = 2;
            this.bnEditPallets.UseVisualStyleBackColor = true;
            this.bnEditPallets.Click += new System.EventHandler(this.OnEditPallets);
            // 
            // bnRefreshPallets
            // 
            this.bnRefreshPallets.Location = new System.Drawing.Point(7, 121);
            this.bnRefreshPallets.Name = "bnRefreshPallets";
            this.bnRefreshPallets.Size = new System.Drawing.Size(75, 23);
            this.bnRefreshPallets.TabIndex = 1;
            this.bnRefreshPallets.Text = "Refresh";
            this.bnRefreshPallets.UseVisualStyleBackColor = true;
            this.bnRefreshPallets.Click += new System.EventHandler(this.OnRefreshPallets);
            // 
            // lbPallets
            // 
            this.lbPallets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPallets.FormattingEnabled = true;
            this.lbPallets.Location = new System.Drawing.Point(87, 20);
            this.lbPallets.Name = "lbPallets";
            this.lbPallets.Size = new System.Drawing.Size(200, 124);
            this.lbPallets.TabIndex = 0;
            // 
            // gbConstraints
            // 
            this.gbConstraints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConstraints.Controls.Add(this.chkbOnlyZOrientation);
            this.gbConstraints.Controls.Add(this.uCtrlOverhang);
            this.gbConstraints.Controls.Add(this.uCtrlMaxPalletHeight);
            this.gbConstraints.Location = new System.Drawing.Point(4, 161);
            this.gbConstraints.Name = "gbConstraints";
            this.gbConstraints.Size = new System.Drawing.Size(293, 97);
            this.gbConstraints.TabIndex = 2;
            this.gbConstraints.TabStop = false;
            this.gbConstraints.Text = "Constraints";
            // 
            // chkbOnlyZOrientation
            // 
            this.chkbOnlyZOrientation.AutoSize = true;
            this.chkbOnlyZOrientation.Location = new System.Drawing.Point(7, 74);
            this.chkbOnlyZOrientation.Name = "chkbOnlyZOrientation";
            this.chkbOnlyZOrientation.Size = new System.Drawing.Size(175, 17);
            this.chkbOnlyZOrientation.TabIndex = 2;
            this.chkbOnlyZOrientation.Text = "Only vertical orientation allowed";
            this.chkbOnlyZOrientation.UseVisualStyleBackColor = true;
            // 
            // uCtrlOverhang
            // 
            this.uCtrlOverhang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uCtrlOverhang.Location = new System.Drawing.Point(7, 47);
            this.uCtrlOverhang.MinValue = -10000D;
            this.uCtrlOverhang.Name = "uCtrlOverhang";
            this.uCtrlOverhang.Size = new System.Drawing.Size(280, 20);
            this.uCtrlOverhang.TabIndex = 1;
            this.uCtrlOverhang.Text = "Overhang";
            this.uCtrlOverhang.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOverhang.ValueX = 0D;
            this.uCtrlOverhang.ValueY = 0D;
            // 
            // uCtrlMaxPalletHeight
            // 
            this.uCtrlMaxPalletHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uCtrlMaxPalletHeight.Location = new System.Drawing.Point(7, 20);
            this.uCtrlMaxPalletHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMaxPalletHeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMaxPalletHeight.Name = "uCtrlMaxPalletHeight";
            this.uCtrlMaxPalletHeight.Size = new System.Drawing.Size(280, 20);
            this.uCtrlMaxPalletHeight.TabIndex = 0;
            this.uCtrlMaxPalletHeight.Text = "Pallet height";
            this.uCtrlMaxPalletHeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMaxPalletHeight.Value = 0D;
            // 
            // gbOptions
            // 
            this.gbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOptions.Controls.Add(this.reportFolderSelect);
            this.gbOptions.Controls.Add(this.chkbGenerateReportInFolder);
            this.gbOptions.Controls.Add(this.folderSelect);
            this.gbOptions.Controls.Add(this.chkbGenerateImageInFolder);
            this.gbOptions.Controls.Add(this.chkbGenerateImageInRow);
            this.gbOptions.Location = new System.Drawing.Point(4, 265);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(293, 142);
            this.gbOptions.TabIndex = 3;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // folderSelect
            // 
            this.folderSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderSelect.Location = new System.Drawing.Point(7, 68);
            this.folderSelect.Name = "folderSelect";
            this.folderSelect.Size = new System.Drawing.Size(280, 20);
            this.folderSelect.TabIndex = 2;
            // 
            // chkbGenerateImageInFolder
            // 
            this.chkbGenerateImageInFolder.AutoSize = true;
            this.chkbGenerateImageInFolder.Location = new System.Drawing.Point(7, 44);
            this.chkbGenerateImageInFolder.Name = "chkbGenerateImageInFolder";
            this.chkbGenerateImageInFolder.Size = new System.Drawing.Size(149, 17);
            this.chkbGenerateImageInFolder.TabIndex = 1;
            this.chkbGenerateImageInFolder.Text = "Generate images in folder:";
            this.chkbGenerateImageInFolder.UseVisualStyleBackColor = true;
            this.chkbGenerateImageInFolder.CheckedChanged += new System.EventHandler(this.OnGenerateImagesChanged);
            // 
            // chkbGenerateImageInRow
            // 
            this.chkbGenerateImageInRow.AutoSize = true;
            this.chkbGenerateImageInRow.Location = new System.Drawing.Point(7, 20);
            this.chkbGenerateImageInRow.Name = "chkbGenerateImageInRow";
            this.chkbGenerateImageInRow.Size = new System.Drawing.Size(135, 17);
            this.chkbGenerateImageInRow.TabIndex = 0;
            this.chkbGenerateImageInRow.Text = "Generate image in row.";
            this.chkbGenerateImageInRow.UseVisualStyleBackColor = true;
            // 
            // chkbGenerateReport
            // 
            this.chkbGenerateReportInFolder.AutoSize = true;
            this.chkbGenerateReportInFolder.Location = new System.Drawing.Point(7, 95);
            this.chkbGenerateReportInFolder.Name = "chkbGenerateReport";
            this.chkbGenerateReportInFolder.Size = new System.Drawing.Size(143, 17);
            this.chkbGenerateReportInFolder.TabIndex = 3;
            this.chkbGenerateReportInFolder.Text = "Generate report in folder:";
            this.chkbGenerateReportInFolder.UseVisualStyleBackColor = true;
            this.chkbGenerateReportInFolder.CheckedChanged += new System.EventHandler(this.OnGenerateReportChanged);
            // 
            // folderSelectReport
            // 
            this.reportFolderSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportFolderSelect.Location = new System.Drawing.Point(6, 117);
            this.reportFolderSelect.Name = "folderSelectReport";
            this.reportFolderSelect.Size = new System.Drawing.Size(280, 20);
            this.reportFolderSelect.TabIndex = 4;
            // 
            // UCtrlPerRowAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.gbConstraints);
            this.Controls.Add(this.gpPallets);
            this.Controls.Add(this.bnCompute);
            this.Name = "UCtrlPerRowAnalysis";
            this.Size = new System.Drawing.Size(300, 650);
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
