namespace treeDiM.StackBuilder.Plugin
{
    partial class FormNewINTEX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewINTEX));
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lbRefDescription = new System.Windows.Forms.Label();
            this.cbRefDescription = new System.Windows.Forms.ComboBox();
            this.lbUPC = new System.Windows.Forms.Label();
            this.lbGenCode = new System.Windows.Forms.Label();
            this.tbUPC = new System.Windows.Forms.TextBox();
            this.tbGenCode = new System.Windows.Forms.TextBox();
            this.lbPallet = new System.Windows.Forms.Label();
            this.cbPallet = new System.Windows.Forms.ComboBox();
            this.lbFilePath = new System.Windows.Forms.Label();
            this.fileSelectCtrl = new treeDiM.UserControls.FileSelect();
            this.lbCase = new System.Windows.Forms.Label();
            this.cbCases = new System.Windows.Forms.ComboBox();
            this.chkUseIntermediatePacking = new System.Windows.Forms.CheckBox();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.uCtrlTriDimensions = new treeDiM.StackBuilder.Basics.UCtrlTriDouble();
            this.uCtrlWeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlThickness = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlPalletHeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.statusStripDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnOK
            // 
            resources.ApplyResources(this.bnOK, "bnOK");
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Name = "bnOK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // lbRefDescription
            // 
            resources.ApplyResources(this.lbRefDescription, "lbRefDescription");
            this.lbRefDescription.Name = "lbRefDescription";
            // 
            // cbRefDescription
            // 
            resources.ApplyResources(this.cbRefDescription, "cbRefDescription");
            this.cbRefDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRefDescription.FormattingEnabled = true;
            this.cbRefDescription.Name = "cbRefDescription";
            this.cbRefDescription.SelectedIndexChanged += new System.EventHandler(this.cbRefDescription_SelectedIndexChanged);
            // 
            // lbUPC
            // 
            resources.ApplyResources(this.lbUPC, "lbUPC");
            this.lbUPC.Name = "lbUPC";
            // 
            // lbGenCode
            // 
            resources.ApplyResources(this.lbGenCode, "lbGenCode");
            this.lbGenCode.Name = "lbGenCode";
            // 
            // tbUPC
            // 
            resources.ApplyResources(this.tbUPC, "tbUPC");
            this.tbUPC.Name = "tbUPC";
            this.tbUPC.ReadOnly = true;
            // 
            // tbGenCode
            // 
            resources.ApplyResources(this.tbGenCode, "tbGenCode");
            this.tbGenCode.Name = "tbGenCode";
            this.tbGenCode.ReadOnly = true;
            // 
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
            // 
            // cbPallet
            // 
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.FormattingEnabled = true;
            resources.ApplyResources(this.cbPallet, "cbPallet");
            this.cbPallet.Name = "cbPallet";
            this.cbPallet.SelectedIndexChanged += new System.EventHandler(this.cbPallet_SelectedIndexChanged);
            // 
            // lbFilePath
            // 
            resources.ApplyResources(this.lbFilePath, "lbFilePath");
            this.lbFilePath.Name = "lbFilePath";
            // 
            // fileSelectCtrl
            // 
            resources.ApplyResources(this.fileSelectCtrl, "fileSelectCtrl");
            this.fileSelectCtrl.Filter = "StackBuilder (*.stb) |*.stb";
            this.fileSelectCtrl.Name = "fileSelectCtrl";
            this.fileSelectCtrl.SaveMode = true;
            // 
            // lbCase
            // 
            resources.ApplyResources(this.lbCase, "lbCase");
            this.lbCase.Name = "lbCase";
            // 
            // cbCases
            // 
            this.cbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCases.FormattingEnabled = true;
            resources.ApplyResources(this.cbCases, "cbCases");
            this.cbCases.Name = "cbCases";
            this.cbCases.SelectedIndexChanged += new System.EventHandler(this.cbCases_SelectedIndexChanged);
            // 
            // chkUseIntermediatePacking
            // 
            resources.ApplyResources(this.chkUseIntermediatePacking, "chkUseIntermediatePacking");
            this.chkUseIntermediatePacking.Name = "chkUseIntermediatePacking";
            this.chkUseIntermediatePacking.UseVisualStyleBackColor = true;
            this.chkUseIntermediatePacking.CheckedChanged += new System.EventHandler(this.chkUseIntermediatePacking_CheckedChanged);
            // 
            // statusStripDef
            // 
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.Name = "statusStripDef";
            this.statusStripDef.SizingGrip = false;
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            // 
            // uCtrlTriDimensions
            // 
            resources.ApplyResources(this.uCtrlTriDimensions, "uCtrlTriDimensions");
            this.uCtrlTriDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlTriDimensions.Name = "uCtrlTriDimensions";
            this.uCtrlTriDimensions.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlTriDimensions.ValueX = 0D;
            this.uCtrlTriDimensions.ValueY = 0D;
            this.uCtrlTriDimensions.ValueZ = 0D;
            // 
            // uCtrlWeight
            // 
            resources.ApplyResources(this.uCtrlWeight, "uCtrlWeight");
            this.uCtrlWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlWeight.Name = "uCtrlWeight";
            this.uCtrlWeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlWeight.Value = 0D;
            // 
            // uCtrlThickness
            // 
            resources.ApplyResources(this.uCtrlThickness, "uCtrlThickness");
            this.uCtrlThickness.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlThickness.Name = "uCtrlThickness";
            this.uCtrlThickness.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlThickness.Value = 0D;
            // 
            // uCtrlPalletHeight
            // 
            resources.ApplyResources(this.uCtrlPalletHeight, "uCtrlPalletHeight");
            this.uCtrlPalletHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlPalletHeight.Name = "uCtrlPalletHeight";
            this.uCtrlPalletHeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlPalletHeight.Value = 0D;
            // 
            // FormNewINTEX
            // 
            this.AcceptButton = this.bnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.uCtrlPalletHeight);
            this.Controls.Add(this.uCtrlThickness);
            this.Controls.Add(this.uCtrlWeight);
            this.Controls.Add(this.uCtrlTriDimensions);
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.chkUseIntermediatePacking);
            this.Controls.Add(this.cbCases);
            this.Controls.Add(this.lbCase);
            this.Controls.Add(this.fileSelectCtrl);
            this.Controls.Add(this.lbFilePath);
            this.Controls.Add(this.cbPallet);
            this.Controls.Add(this.lbPallet);
            this.Controls.Add(this.tbGenCode);
            this.Controls.Add(this.tbUPC);
            this.Controls.Add(this.lbGenCode);
            this.Controls.Add(this.lbUPC);
            this.Controls.Add(this.cbRefDescription);
            this.Controls.Add(this.lbRefDescription);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewINTEX";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewINTEX_FormClosing);
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label lbRefDescription;
        private System.Windows.Forms.ComboBox cbRefDescription;
        private System.Windows.Forms.Label lbUPC;
        private System.Windows.Forms.Label lbGenCode;
        private System.Windows.Forms.TextBox tbUPC;
        private System.Windows.Forms.TextBox tbGenCode;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.ComboBox cbPallet;
        private System.Windows.Forms.Label lbFilePath;
        private treeDiM.UserControls.FileSelect fileSelectCtrl;
        private System.Windows.Forms.Label lbCase;
        private System.Windows.Forms.ComboBox cbCases;
        private System.Windows.Forms.CheckBox chkUseIntermediatePacking;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private Basics.UCtrlTriDouble uCtrlTriDimensions;
        private Basics.UCtrlDouble uCtrlWeight;
        private Basics.UCtrlDouble uCtrlThickness;
        private Basics.UCtrlDouble uCtrlPalletHeight;
    }
}