namespace treeDiM.StackBuilder.ExcelListEvaluator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMIFile = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMITools = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMISettings = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbFilePath = new System.Windows.Forms.Label();
            this.fileSelectExcel = new treeDiM.UserControls.FileSelect();
            this.graphCtrlPallet = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.uCtrlPalletDimensions = new treeDiM.StackBuilder.Basics.UCtrlTriDouble();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPallet = new System.Windows.Forms.TabPage();
            this.uCtrlMaximumPalletHeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.cbPalletType = new System.Windows.Forms.ComboBox();
            this.lbPalletType = new System.Windows.Forms.Label();
            this.tabContainer = new System.Windows.Forms.TabPage();
            this.uCtrlTruckDimensions = new treeDiM.StackBuilder.Basics.UCtrlTriDouble();
            this.lbCaseLoaded = new System.Windows.Forms.Label();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.fsOutputImages = new treeDiM.UserControls.FileSelect();
            this.chkbGenerateImageFolder = new System.Windows.Forms.CheckBox();
            this.chkbGenerateImage = new System.Windows.Forms.CheckBox();
            this.chkbOpenFile = new System.Windows.Forms.CheckBox();
            this.fsOutputExcelFile = new treeDiM.UserControls.FileSelect();
            this.lbOutputFilePath = new System.Windows.Forms.Label();
            this.bnGenerate = new System.Windows.Forms.Button();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.chkbOnlyVerticalOrientation = new System.Windows.Forms.CheckBox();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlPallet)).BeginInit();
            this.gbInput.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tabPallet.SuspendLayout();
            this.tabContainer.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMIFile,
            this.toolStripMITools});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
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
            // toolStripMITools
            // 
            this.toolStripMITools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMISettings});
            this.toolStripMITools.Name = "toolStripMITools";
            resources.ApplyResources(this.toolStripMITools, "toolStripMITools");
            // 
            // toolStripMISettings
            // 
            this.toolStripMISettings.Name = "toolStripMISettings";
            resources.ApplyResources(this.toolStripMISettings, "toolStripMISettings");
            this.toolStripMISettings.Click += new System.EventHandler(this.OnSettings);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            resources.ApplyResources(this.statusLabel, "statusLabel");
            // 
            // lbFilePath
            // 
            resources.ApplyResources(this.lbFilePath, "lbFilePath");
            this.lbFilePath.Name = "lbFilePath";
            // 
            // fileSelectExcel
            // 
            resources.ApplyResources(this.fileSelectExcel, "fileSelectExcel");
            this.fileSelectExcel.Name = "fileSelectExcel";
            this.fileSelectExcel.FileNameChanged += new System.EventHandler(this.OnInputFilePathChanged);
            // 
            // graphCtrlPallet
            // 
            resources.ApplyResources(this.graphCtrlPallet, "graphCtrlPallet");
            this.graphCtrlPallet.Name = "graphCtrlPallet";
            this.graphCtrlPallet.Viewer = null;
            // 
            // uCtrlPalletDimensions
            // 
            resources.ApplyResources(this.uCtrlPalletDimensions, "uCtrlPalletDimensions");
            this.uCtrlPalletDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlPalletDimensions.Name = "uCtrlPalletDimensions";
            this.uCtrlPalletDimensions.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlPalletDimensions.Value = ((Sharp3D.Math.Core.Vector3D)(resources.GetObject("uCtrlPalletDimensions.Value")));
            this.uCtrlPalletDimensions.ValueX = 0D;
            this.uCtrlPalletDimensions.ValueY = 0D;
            this.uCtrlPalletDimensions.ValueZ = 0D;
            this.uCtrlPalletDimensions.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlTriDouble.ValueChangedDelegate(this.OnDataChanged);
            // 
            // gbInput
            // 
            resources.ApplyResources(this.gbInput, "gbInput");
            this.gbInput.Controls.Add(this.chkbOnlyVerticalOrientation);
            this.gbInput.Controls.Add(this.tabCtrl);
            this.gbInput.Controls.Add(this.lbCaseLoaded);
            this.gbInput.Controls.Add(this.fileSelectExcel);
            this.gbInput.Controls.Add(this.lbFilePath);
            this.gbInput.Controls.Add(this.graphCtrlPallet);
            this.gbInput.Name = "gbInput";
            this.gbInput.TabStop = false;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPallet);
            this.tabCtrl.Controls.Add(this.tabContainer);
            resources.ApplyResources(this.tabCtrl, "tabCtrl");
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.OnModeChanged);
            // 
            // tabPallet
            // 
            this.tabPallet.Controls.Add(this.uCtrlMaximumPalletHeight);
            this.tabPallet.Controls.Add(this.uCtrlPalletDimensions);
            this.tabPallet.Controls.Add(this.cbPalletType);
            this.tabPallet.Controls.Add(this.lbPalletType);
            resources.ApplyResources(this.tabPallet, "tabPallet");
            this.tabPallet.Name = "tabPallet";
            this.tabPallet.UseVisualStyleBackColor = true;
            // 
            // uCtrlMaximumPalletHeight
            // 
            resources.ApplyResources(this.uCtrlMaximumPalletHeight, "uCtrlMaximumPalletHeight");
            this.uCtrlMaximumPalletHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMaximumPalletHeight.Name = "uCtrlMaximumPalletHeight";
            this.uCtrlMaximumPalletHeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMaximumPalletHeight.Value = 0D;
            // 
            // cbPalletType
            // 
            this.cbPalletType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalletType.FormattingEnabled = true;
            resources.ApplyResources(this.cbPalletType, "cbPalletType");
            this.cbPalletType.Name = "cbPalletType";
            this.cbPalletType.SelectedIndexChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // lbPalletType
            // 
            resources.ApplyResources(this.lbPalletType, "lbPalletType");
            this.lbPalletType.Name = "lbPalletType";
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.uCtrlTruckDimensions);
            resources.ApplyResources(this.tabContainer, "tabContainer");
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.UseVisualStyleBackColor = true;
            // 
            // uCtrlTruckDimensions
            // 
            resources.ApplyResources(this.uCtrlTruckDimensions, "uCtrlTruckDimensions");
            this.uCtrlTruckDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlTruckDimensions.Name = "uCtrlTruckDimensions";
            this.uCtrlTruckDimensions.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlTruckDimensions.Value = ((Sharp3D.Math.Core.Vector3D)(resources.GetObject("uCtrlTruckDimensions.Value")));
            this.uCtrlTruckDimensions.ValueX = 0D;
            this.uCtrlTruckDimensions.ValueY = 0D;
            this.uCtrlTruckDimensions.ValueZ = 0D;
            this.uCtrlTruckDimensions.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlTriDouble.ValueChangedDelegate(this.OnDataChanged);
            // 
            // lbCaseLoaded
            // 
            resources.ApplyResources(this.lbCaseLoaded, "lbCaseLoaded");
            this.lbCaseLoaded.Name = "lbCaseLoaded";
            // 
            // gbOutput
            // 
            resources.ApplyResources(this.gbOutput, "gbOutput");
            this.gbOutput.Controls.Add(this.fsOutputImages);
            this.gbOutput.Controls.Add(this.chkbGenerateImageFolder);
            this.gbOutput.Controls.Add(this.chkbGenerateImage);
            this.gbOutput.Controls.Add(this.chkbOpenFile);
            this.gbOutput.Controls.Add(this.fsOutputExcelFile);
            this.gbOutput.Controls.Add(this.lbOutputFilePath);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.TabStop = false;
            // 
            // fsOutputImages
            // 
            resources.ApplyResources(this.fsOutputImages, "fsOutputImages");
            this.fsOutputImages.Name = "fsOutputImages";
            this.fsOutputImages.SaveMode = true;
            this.fsOutputImages.FileNameChanged += new System.EventHandler(this.OnImageFolderChanged);
            // 
            // chkbGenerateImageFolder
            // 
            resources.ApplyResources(this.chkbGenerateImageFolder, "chkbGenerateImageFolder");
            this.chkbGenerateImageFolder.Name = "chkbGenerateImageFolder";
            this.chkbGenerateImageFolder.UseVisualStyleBackColor = true;
            this.chkbGenerateImageFolder.CheckedChanged += new System.EventHandler(this.OnImageFolderChecked);
            // 
            // chkbGenerateImage
            // 
            resources.ApplyResources(this.chkbGenerateImage, "chkbGenerateImage");
            this.chkbGenerateImage.Name = "chkbGenerateImage";
            this.chkbGenerateImage.UseVisualStyleBackColor = true;
            // 
            // chkbOpenFile
            // 
            resources.ApplyResources(this.chkbOpenFile, "chkbOpenFile");
            this.chkbOpenFile.Name = "chkbOpenFile";
            this.chkbOpenFile.UseVisualStyleBackColor = true;
            // 
            // fsOutputExcelFile
            // 
            resources.ApplyResources(this.fsOutputExcelFile, "fsOutputExcelFile");
            this.fsOutputExcelFile.Name = "fsOutputExcelFile";
            this.fsOutputExcelFile.SaveMode = true;
            // 
            // lbOutputFilePath
            // 
            resources.ApplyResources(this.lbOutputFilePath, "lbOutputFilePath");
            this.lbOutputFilePath.Name = "lbOutputFilePath";
            // 
            // bnGenerate
            // 
            resources.ApplyResources(this.bnGenerate, "bnGenerate");
            this.bnGenerate.Name = "bnGenerate";
            this.bnGenerate.UseVisualStyleBackColor = true;
            this.bnGenerate.Click += new System.EventHandler(this.OnGenerate);
            // 
            // richTextBoxLog
            // 
            resources.ApplyResources(this.richTextBoxLog, "richTextBoxLog");
            this.richTextBoxLog.Name = "richTextBoxLog";
            // 
            // chkbAllowOnlyVerticalOrientation
            // 
            resources.ApplyResources(this.chkbOnlyVerticalOrientation, "chkbAllowOnlyVerticalOrientation");
            this.chkbOnlyVerticalOrientation.Name = "chkbAllowOnlyVerticalOrientation";
            this.chkbOnlyVerticalOrientation.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.bnGenerate);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlPallet)).EndInit();
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.tabCtrl.ResumeLayout(false);
            this.tabPallet.ResumeLayout(false);
            this.tabPallet.PerformLayout();
            this.tabContainer.ResumeLayout(false);
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMITools;
        private System.Windows.Forms.ToolStripMenuItem toolStripMISettings;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label lbFilePath;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIFile;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private UserControls.FileSelect fileSelectExcel;
        private Graphics.Graphics3DControl graphCtrlPallet;
        private Basics.UCtrlTriDouble uCtrlPalletDimensions;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.ComboBox cbPalletType;
        private System.Windows.Forms.Label lbPalletType;
        private Basics.UCtrlTriDouble uCtrlTruckDimensions;
        private Basics.UCtrlDouble uCtrlMaximumPalletHeight;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.CheckBox chkbOpenFile;
        private System.Windows.Forms.Button bnGenerate;
        private UserControls.FileSelect fsOutputExcelFile;
        private System.Windows.Forms.Label lbOutputFilePath;
        private System.Windows.Forms.Label lbCaseLoaded;
        private System.Windows.Forms.CheckBox chkbGenerateImage;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPallet;
        private System.Windows.Forms.TabPage tabContainer;
        private System.Windows.Forms.CheckBox chkbGenerateImageFolder;
        private UserControls.FileSelect fsOutputImages;
        private System.Windows.Forms.CheckBox chkbOnlyVerticalOrientation;
    }
}

