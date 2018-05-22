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
            this.label1 = new System.Windows.Forms.Label();
            this.nudImageSize = new System.Windows.Forms.NumericUpDown();
            this.gpConditions = new System.Windows.Forms.GroupBox();
            this.uCtrlMinDimensions = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMaxCountImage = new System.Windows.Forms.NumericUpDown();
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
            this.bnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Location = new System.Drawing.Point(389, 3);
            this.bnOk.Name = "bnOk";
            this.bnOk.Size = new System.Drawing.Size(75, 23);
            this.bnOk.TabIndex = 0;
            this.bnOk.Text = "OK";
            this.bnOk.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(389, 32);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 1;
            this.bnCancel.Text = "Cancel";
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
            this.gbInputColumns.Location = new System.Drawing.Point(12, 3);
            this.gbInputColumns.Name = "gbInputColumns";
            this.gbInputColumns.Size = new System.Drawing.Size(175, 201);
            this.gbInputColumns.TabIndex = 15;
            this.gbInputColumns.TabStop = false;
            this.gbInputColumns.Text = "Input columns";
            // 
            // cbWeight
            // 
            this.cbWeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWeight.FormattingEnabled = true;
            this.cbWeight.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cbWeight.Location = new System.Drawing.Point(112, 146);
            this.cbWeight.Name = "cbWeight";
            this.cbWeight.Size = new System.Drawing.Size(45, 21);
            this.cbWeight.TabIndex = 26;
            // 
            // cbHeight
            // 
            this.cbHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHeight.FormattingEnabled = true;
            this.cbHeight.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cbHeight.Location = new System.Drawing.Point(112, 120);
            this.cbHeight.Name = "cbHeight";
            this.cbHeight.Size = new System.Drawing.Size(45, 21);
            this.cbHeight.TabIndex = 25;
            // 
            // cbWidth
            // 
            this.cbWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWidth.FormattingEnabled = true;
            this.cbWidth.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cbWidth.Location = new System.Drawing.Point(112, 94);
            this.cbWidth.Name = "cbWidth";
            this.cbWidth.Size = new System.Drawing.Size(45, 21);
            this.cbWidth.TabIndex = 24;
            // 
            // cbLength
            // 
            this.cbLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLength.FormattingEnabled = true;
            this.cbLength.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cbLength.Location = new System.Drawing.Point(112, 68);
            this.cbLength.Name = "cbLength";
            this.cbLength.Size = new System.Drawing.Size(45, 21);
            this.cbLength.TabIndex = 23;
            // 
            // cbDescription
            // 
            this.cbDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDescription.FormattingEnabled = true;
            this.cbDescription.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cbDescription.Location = new System.Drawing.Point(112, 42);
            this.cbDescription.Name = "cbDescription";
            this.cbDescription.Size = new System.Drawing.Size(45, 21);
            this.cbDescription.TabIndex = 22;
            // 
            // cbName
            // 
            this.cbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbName.FormattingEnabled = true;
            this.cbName.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cbName.Location = new System.Drawing.Point(112, 16);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(45, 21);
            this.cbName.TabIndex = 21;
            // 
            // chkbDescription
            // 
            this.chkbDescription.AutoSize = true;
            this.chkbDescription.Location = new System.Drawing.Point(8, 44);
            this.chkbDescription.Name = "chkbDescription";
            this.chkbDescription.Size = new System.Drawing.Size(79, 17);
            this.chkbDescription.TabIndex = 20;
            this.chkbDescription.Text = "Description";
            this.chkbDescription.UseVisualStyleBackColor = true;
            this.chkbDescription.CheckedChanged += new System.EventHandler(this.OnDescriptionChecked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Weight";
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(8, 123);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(38, 13);
            this.lbHeight.TabIndex = 18;
            this.lbHeight.Text = "Height";
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(8, 98);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(35, 13);
            this.lbWidth.TabIndex = 17;
            this.lbWidth.Text = "Width";
            // 
            // lbLength
            // 
            this.lbLength.AutoSize = true;
            this.lbLength.Location = new System.Drawing.Point(9, 71);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(40, 13);
            this.lbLength.TabIndex = 16;
            this.lbLength.Text = "Length";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(8, 20);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 15;
            this.lbName.Text = "Name";
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.cbOutputStart);
            this.gbOutput.Controls.Add(this.lbStartOutput);
            this.gbOutput.Location = new System.Drawing.Point(194, 3);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(187, 52);
            this.gbOutput.TabIndex = 16;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output columns";
            // 
            // cbOutputStart
            // 
            this.cbOutputStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputStart.FormattingEnabled = true;
            this.cbOutputStart.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cbOutputStart.Location = new System.Drawing.Point(136, 17);
            this.cbOutputStart.Name = "cbOutputStart";
            this.cbOutputStart.Size = new System.Drawing.Size(45, 21);
            this.cbOutputStart.TabIndex = 22;
            // 
            // lbStartOutput
            // 
            this.lbStartOutput.AutoSize = true;
            this.lbStartOutput.Location = new System.Drawing.Point(6, 20);
            this.lbStartOutput.Name = "lbStartOutput";
            this.lbStartOutput.Size = new System.Drawing.Size(29, 13);
            this.lbStartOutput.TabIndex = 0;
            this.lbStartOutput.Text = "Start";
            // 
            // gbAdditionalProperties
            // 
            this.gbAdditionalProperties.Controls.Add(this.nudImageSize);
            this.gbAdditionalProperties.Controls.Add(this.label1);
            this.gbAdditionalProperties.Location = new System.Drawing.Point(194, 164);
            this.gbAdditionalProperties.Name = "gbAdditionalProperties";
            this.gbAdditionalProperties.Size = new System.Drawing.Size(263, 40);
            this.gbAdditionalProperties.TabIndex = 17;
            this.gbAdditionalProperties.TabStop = false;
            this.gbAdditionalProperties.Text = "Additional properties";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image size";
            // 
            // nudImageSize
            // 
            this.nudImageSize.Location = new System.Drawing.Point(158, 16);
            this.nudImageSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudImageSize.Name = "nudImageSize";
            this.nudImageSize.Size = new System.Drawing.Size(57, 20);
            this.nudImageSize.TabIndex = 1;
            // 
            // gpConditions
            // 
            this.gpConditions.Controls.Add(this.nudMaxCountImage);
            this.gpConditions.Controls.Add(this.label2);
            this.gpConditions.Controls.Add(this.uCtrlMinDimensions);
            this.gpConditions.Location = new System.Drawing.Point(194, 62);
            this.gpConditions.Name = "gpConditions";
            this.gpConditions.Size = new System.Drawing.Size(263, 102);
            this.gpConditions.TabIndex = 18;
            this.gpConditions.TabStop = false;
            this.gpConditions.Text = "Processing conditions";
            // 
            // uCtrlMinDimensions
            // 
            this.uCtrlMinDimensions.Location = new System.Drawing.Point(7, 19);
            this.uCtrlMinDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlMinDimensions.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMinDimensions.Name = "uCtrlMinDimensions";
            this.uCtrlMinDimensions.Size = new System.Drawing.Size(245, 20);
            this.uCtrlMinDimensions.TabIndex = 2;
            this.uCtrlMinDimensions.Text = "Min. dimensions";
            this.uCtrlMinDimensions.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMinDimensions.Value = 0D;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max. count for image generation";
            // 
            // nudMaxCountImage
            // 
            this.nudMaxCountImage.Location = new System.Drawing.Point(158, 61);
            this.nudMaxCountImage.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxCountImage.Name = "nudMaxCountImage";
            this.nudMaxCountImage.Size = new System.Drawing.Size(57, 20);
            this.nudMaxCountImage.TabIndex = 4;
            // 
            // FormSettingsPerRow
            // 
            this.AcceptButton = this.bnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(469, 211);
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
            this.Text = "Define input columns for per row analyses...";
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
        private Basics.UCtrlDouble uCtrlMinDimensions;
        private System.Windows.Forms.NumericUpDown nudMaxCountImage;
        private System.Windows.Forms.Label label2;
    }
}