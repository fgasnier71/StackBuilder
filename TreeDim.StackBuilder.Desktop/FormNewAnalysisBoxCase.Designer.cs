namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewAnalysisBoxCase
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
            this.checkBoxBestLayersOnly = new System.Windows.Forms.CheckBox();
            this.lbBox = new System.Windows.Forms.Label();
            this.lbCase = new System.Windows.Forms.Label();
            this.cbCases = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbBoxes = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.uCtrlLayerList = new treeDiM.StackBuilder.Graphics.UCtrlLayerList();
            this.uCtrlCaseOrientation = new treeDiM.StackBuilder.Graphics.uCtrlCaseOrientation();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Size = new System.Drawing.Size(573, 20);
            // 
            // lbDescription
            // 
            this.lbDescription.Location = new System.Drawing.Point(6, 34);
            // 
            // bnCancel
            // 
            this.bnCancel.Location = new System.Drawing.Point(873, 4);
            // 
            // checkBoxBestLayersOnly
            // 
            this.checkBoxBestLayersOnly.AutoSize = true;
            this.checkBoxBestLayersOnly.Location = new System.Drawing.Point(8, 517);
            this.checkBoxBestLayersOnly.Name = "checkBoxBestLayersOnly";
            this.checkBoxBestLayersOnly.Size = new System.Drawing.Size(128, 17);
            this.checkBoxBestLayersOnly.TabIndex = 28;
            this.checkBoxBestLayersOnly.Text = "Show best layers only";
            this.checkBoxBestLayersOnly.UseVisualStyleBackColor = true;
            this.checkBoxBestLayersOnly.CheckedChanged += new System.EventHandler(this.onInputChanged);
            // 
            // lbBox
            // 
            this.lbBox.AutoSize = true;
            this.lbBox.Location = new System.Drawing.Point(6, 67);
            this.lbBox.Name = "lbBox";
            this.lbBox.Size = new System.Drawing.Size(25, 13);
            this.lbBox.TabIndex = 29;
            this.lbBox.Text = "Box";
            // 
            // lbCase
            // 
            this.lbCase.AutoSize = true;
            this.lbCase.Location = new System.Drawing.Point(322, 67);
            this.lbCase.Name = "lbCase";
            this.lbCase.Size = new System.Drawing.Size(31, 13);
            this.lbCase.TabIndex = 30;
            this.lbCase.Text = "Case";
            // 
            // cbCases
            // 
            this.cbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCases.FormattingEnabled = true;
            this.cbCases.Location = new System.Drawing.Point(426, 64);
            this.cbCases.Name = "cbCases";
            this.cbCases.Size = new System.Drawing.Size(145, 21);
            this.cbCases.TabIndex = 27;
            this.cbCases.SelectedIndexChanged += new System.EventHandler(this.onInputChanged);
            // 
            // cbBoxes
            // 
            this.cbBoxes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxes.FormattingEnabled = true;
            this.cbBoxes.Location = new System.Drawing.Point(104, 64);
            this.cbBoxes.Name = "cbBoxes";
            this.cbBoxes.Size = new System.Drawing.Size(145, 21);
            this.cbBoxes.TabIndex = 26;
            this.cbBoxes.SelectedIndexChanged += new System.EventHandler(this.onBoxChanged);
            // 
            // uCtrlLayerList
            // 
            this.uCtrlLayerList.AutoScroll = true;
            this.uCtrlLayerList.ButtonSizes = new System.Drawing.Size(150, 150);
            this.uCtrlLayerList.Location = new System.Drawing.Point(0, 218);
            this.uCtrlLayerList.Name = "uCtrlLayerList";
            this.uCtrlLayerList.Size = new System.Drawing.Size(784, 289);
            this.uCtrlLayerList.TabIndex = 25;
            // 
            // uCtrlCaseOrientation
            // 
            this.uCtrlCaseOrientation.AllowedOrientations = new bool[] {
        false,
        false,
        true};
            this.uCtrlCaseOrientation.Location = new System.Drawing.Point(8, 100);
            this.uCtrlCaseOrientation.Name = "uCtrlCaseOrientation";
            this.uCtrlCaseOrientation.Size = new System.Drawing.Size(288, 110);
            this.uCtrlCaseOrientation.TabIndex = 24;
            this.uCtrlCaseOrientation.CheckedChanged += new treeDiM.StackBuilder.Graphics.uCtrlCaseOrientation.CheckChanged(this.onInputChanged);
            // 
            // FormNewAnalysisBoxCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lbCase);
            this.Controls.Add(this.lbBox);
            this.Controls.Add(this.checkBoxBestLayersOnly);
            this.Controls.Add(this.cbCases);
            this.Controls.Add(this.cbBoxes);
            this.Controls.Add(this.uCtrlLayerList);
            this.Controls.Add(this.uCtrlCaseOrientation);
            this.Name = "FormNewAnalysisBoxCase";
            this.Text = "FormNewAnalysisBoxCase";
            this.Controls.SetChildIndex(this.uCtrlCaseOrientation, 0);
            this.Controls.SetChildIndex(this.uCtrlLayerList, 0);
            this.Controls.SetChildIndex(this.cbBoxes, 0);
            this.Controls.SetChildIndex(this.cbCases, 0);
            this.Controls.SetChildIndex(this.checkBoxBestLayersOnly, 0);
            this.Controls.SetChildIndex(this.lbBox, 0);
            this.Controls.SetChildIndex(this.lbCase, 0);
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Graphics.uCtrlCaseOrientation uCtrlCaseOrientation;
        private Graphics.UCtrlLayerList uCtrlLayerList;
        private Graphics.Controls.CCtrlComboFiltered cbBoxes;
        private Graphics.Controls.CCtrlComboFiltered cbCases;
        private System.Windows.Forms.CheckBox checkBoxBestLayersOnly;
        private System.Windows.Forms.Label lbBox;
        private System.Windows.Forms.Label lbCase;
    }
}