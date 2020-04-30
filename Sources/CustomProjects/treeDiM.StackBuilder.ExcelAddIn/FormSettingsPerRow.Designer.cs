namespace treeDiM.StackBuilder.ExcelAddIn
{
    partial class FormSettingsPerRow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettingsPerRow));
            this.bnOk = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.gbInputColumns = new System.Windows.Forms.GroupBox();
            this.cbWeight = new System.Windows.Forms.ComboBox();
            this.cbHeight = new System.Windows.Forms.ComboBox();
            this.cbWidth = new System.Windows.Forms.ComboBox();
            this.cbLength = new System.Windows.Forms.ComboBox();
            this.cbDescription = new System.Windows.Forms.ComboBox();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.chkbDescription = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.cbOutputStart = new System.Windows.Forms.ComboBox();
            this.lbStartOutput = new System.Windows.Forms.Label();
            this.gbAdditionalProperties = new System.Windows.Forms.GroupBox();
            this.nudImageSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.gpConditions = new System.Windows.Forms.GroupBox();
            this.nudMaxCountImage = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.uCtrlMinDimensions = new treeDiM.Basics.UCtrlDouble();
            this.label8 = new System.Windows.Forms.Label();
            this.cbUnitSystem = new System.Windows.Forms.ComboBox();
            this.gbInputColumns.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.gbAdditionalProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageSize)).BeginInit();
            this.gpConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCountImage)).BeginInit();
            this.SuspendLayout();
            // 
            // bnOk
            // 
            resources.ApplyResources(this.bnOk, "bnOk");
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Name = "bnOk";
            this.bnOk.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // gbInputColumns
            // 
            this.gbInputColumns.Controls.Add(this.cbWeight);
            this.gbInputColumns.Controls.Add(this.cbHeight);
            this.gbInputColumns.Controls.Add(this.cbWidth);
            this.gbInputColumns.Controls.Add(this.cbLength);
            this.gbInputColumns.Controls.Add(this.cbDescription);
            this.gbInputColumns.Controls.Add(this.cbName);
            this.gbInputColumns.Controls.Add(this.chkbDescription);
            this.gbInputColumns.Controls.Add(this.label5);
            this.gbInputColumns.Controls.Add(this.lbHeight);
            this.gbInputColumns.Controls.Add(this.lbWidth);
            this.gbInputColumns.Controls.Add(this.lbLength);
            this.gbInputColumns.Controls.Add(this.lbName);
            resources.ApplyResources(this.gbInputColumns, "gbInputColumns");
            this.gbInputColumns.Name = "gbInputColumns";
            this.gbInputColumns.TabStop = false;
            // 
            // cbWeight
            // 
            this.cbWeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWeight.FormattingEnabled = true;
            resources.ApplyResources(this.cbWeight, "cbWeight");
            this.cbWeight.Name = "cbWeight";
            // 
            // cbHeight
            // 
            this.cbHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHeight.FormattingEnabled = true;
            resources.ApplyResources(this.cbHeight, "cbHeight");
            this.cbHeight.Name = "cbHeight";
            // 
            // cbWidth
            // 
            this.cbWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWidth.FormattingEnabled = true;
            resources.ApplyResources(this.cbWidth, "cbWidth");
            this.cbWidth.Name = "cbWidth";
            // 
            // cbLength
            // 
            this.cbLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLength.FormattingEnabled = true;
            resources.ApplyResources(this.cbLength, "cbLength");
            this.cbLength.Name = "cbLength";
            // 
            // cbDescription
            // 
            this.cbDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDescription.FormattingEnabled = true;
            resources.ApplyResources(this.cbDescription, "cbDescription");
            this.cbDescription.Name = "cbDescription";
            // 
            // cbName
            // 
            this.cbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbName.FormattingEnabled = true;
            resources.ApplyResources(this.cbName, "cbName");
            this.cbName.Name = "cbName";
            // 
            // chkbDescription
            // 
            resources.ApplyResources(this.chkbDescription, "chkbDescription");
            this.chkbDescription.Name = "chkbDescription";
            this.chkbDescription.UseVisualStyleBackColor = true;
            this.chkbDescription.CheckedChanged += new System.EventHandler(this.OnDescriptionChecked);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lbHeight
            // 
            resources.ApplyResources(this.lbHeight, "lbHeight");
            this.lbHeight.Name = "lbHeight";
            // 
            // lbWidth
            // 
            resources.ApplyResources(this.lbWidth, "lbWidth");
            this.lbWidth.Name = "lbWidth";
            // 
            // lbLength
            // 
            resources.ApplyResources(this.lbLength, "lbLength");
            this.lbLength.Name = "lbLength";
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Name = "lbName";
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.cbOutputStart);
            this.gbOutput.Controls.Add(this.lbStartOutput);
            resources.ApplyResources(this.gbOutput, "gbOutput");
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.TabStop = false;
            // 
            // cbOutputStart
            // 
            this.cbOutputStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputStart.FormattingEnabled = true;
            resources.ApplyResources(this.cbOutputStart, "cbOutputStart");
            this.cbOutputStart.Name = "cbOutputStart";
            // 
            // lbStartOutput
            // 
            resources.ApplyResources(this.lbStartOutput, "lbStartOutput");
            this.lbStartOutput.Name = "lbStartOutput";
            // 
            // gbAdditionalProperties
            // 
            this.gbAdditionalProperties.Controls.Add(this.nudImageSize);
            this.gbAdditionalProperties.Controls.Add(this.label1);
            resources.ApplyResources(this.gbAdditionalProperties, "gbAdditionalProperties");
            this.gbAdditionalProperties.Name = "gbAdditionalProperties";
            this.gbAdditionalProperties.TabStop = false;
            // 
            // nudImageSize
            // 
            resources.ApplyResources(this.nudImageSize, "nudImageSize");
            this.nudImageSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudImageSize.Name = "nudImageSize";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // gpConditions
            // 
            this.gpConditions.Controls.Add(this.nudMaxCountImage);
            this.gpConditions.Controls.Add(this.label2);
            this.gpConditions.Controls.Add(this.uCtrlMinDimensions);
            resources.ApplyResources(this.gpConditions, "gpConditions");
            this.gpConditions.Name = "gpConditions";
            this.gpConditions.TabStop = false;
            // 
            // nudMaxCountImage
            // 
            resources.ApplyResources(this.nudMaxCountImage, "nudMaxCountImage");
            this.nudMaxCountImage.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxCountImage.Name = "nudMaxCountImage";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // uCtrlMinDimensions
            // 
            resources.ApplyResources(this.uCtrlMinDimensions, "uCtrlMinDimensions");
            this.uCtrlMinDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlMinDimensions.Name = "uCtrlMinDimensions";
            this.uCtrlMinDimensions.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cbUnitSystem
            // 
            this.cbUnitSystem.FormattingEnabled = true;
            this.cbUnitSystem.Items.AddRange(new object[] {
            resources.GetString("cbUnitSystem.Items"),
            resources.GetString("cbUnitSystem.Items1"),
            resources.GetString("cbUnitSystem.Items2"),
            resources.GetString("cbUnitSystem.Items3")});
            resources.ApplyResources(this.cbUnitSystem, "cbUnitSystem");
            this.cbUnitSystem.Name = "cbUnitSystem";
            // 
            // FormSettingsPerRow
            // 
            this.AcceptButton = this.bnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.cbUnitSystem);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gpConditions);
            this.Controls.Add(this.gbAdditionalProperties);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbInputColumns);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettingsPerRow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.gbInputColumns.ResumeLayout(false);
            this.gbInputColumns.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.gbAdditionalProperties.ResumeLayout(false);
            this.gbAdditionalProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageSize)).EndInit();
            this.gpConditions.ResumeLayout(false);
            this.gpConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCountImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.GroupBox gbInputColumns;
        private System.Windows.Forms.ComboBox cbWeight;
        private System.Windows.Forms.ComboBox cbHeight;
        private System.Windows.Forms.ComboBox cbWidth;
        private System.Windows.Forms.ComboBox cbLength;
        private System.Windows.Forms.ComboBox cbDescription;
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.CheckBox chkbDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.ComboBox cbOutputStart;
        private System.Windows.Forms.Label lbStartOutput;
        private System.Windows.Forms.GroupBox gbAdditionalProperties;
        private System.Windows.Forms.NumericUpDown nudImageSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpConditions;
        private treeDiM.Basics.UCtrlDouble uCtrlMinDimensions;
        private System.Windows.Forms.NumericUpDown nudMaxCountImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbUnitSystem;
    }
}