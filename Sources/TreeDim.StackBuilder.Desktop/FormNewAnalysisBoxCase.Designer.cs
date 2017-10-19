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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewAnalysisBoxCase));
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
            resources.ApplyResources(this.tbDescription, "tbDescription");
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            // 
            // lbDescription
            // 
            resources.ApplyResources(this.lbDescription, "lbDescription");
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            // 
            // checkBoxBestLayersOnly
            // 
            resources.ApplyResources(this.checkBoxBestLayersOnly, "checkBoxBestLayersOnly");
            this.checkBoxBestLayersOnly.Name = "checkBoxBestLayersOnly";
            this.checkBoxBestLayersOnly.UseVisualStyleBackColor = true;
            this.checkBoxBestLayersOnly.CheckedChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // lbBox
            // 
            resources.ApplyResources(this.lbBox, "lbBox");
            this.lbBox.Name = "lbBox";
            // 
            // lbCase
            // 
            resources.ApplyResources(this.lbCase, "lbCase");
            this.lbCase.Name = "lbCase";
            // 
            // cbCases
            // 
            resources.ApplyResources(this.cbCases, "cbCases");
            this.cbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCases.FormattingEnabled = true;
            this.cbCases.Name = "cbCases";
            this.cbCases.SelectedIndexChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // cbBoxes
            // 
            resources.ApplyResources(this.cbBoxes, "cbBoxes");
            this.cbBoxes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxes.FormattingEnabled = true;
            this.cbBoxes.Name = "cbBoxes";
            this.cbBoxes.SelectedIndexChanged += new System.EventHandler(this.OnBoxChanged);
            // 
            // uCtrlLayerList
            // 
            resources.ApplyResources(this.uCtrlLayerList, "uCtrlLayerList");
            this.uCtrlLayerList.ButtonSizes = new System.Drawing.Size(150, 150);
            this.uCtrlLayerList.Name = "uCtrlLayerList";
            this.uCtrlLayerList.Show3D = true;
            this.uCtrlLayerList.SingleSelection = false;
            // 
            // uCtrlCaseOrientation
            // 
            resources.ApplyResources(this.uCtrlCaseOrientation, "uCtrlCaseOrientation");
            this.uCtrlCaseOrientation.AllowedOrientations = new bool[] {
        false,
        false,
        true};
            this.uCtrlCaseOrientation.Name = "uCtrlCaseOrientation";
            this.uCtrlCaseOrientation.CheckedChanged += new treeDiM.StackBuilder.Graphics.uCtrlCaseOrientation.CheckChanged(this.OnInputChanged);
            // 
            // FormNewAnalysisBoxCase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbCase);
            this.Controls.Add(this.lbBox);
            this.Controls.Add(this.checkBoxBestLayersOnly);
            this.Controls.Add(this.cbCases);
            this.Controls.Add(this.cbBoxes);
            this.Controls.Add(this.uCtrlLayerList);
            this.Controls.Add(this.uCtrlCaseOrientation);
            this.Name = "FormNewAnalysisBoxCase";
            this.Controls.SetChildIndex(this.uCtrlCaseOrientation, 0);
            this.Controls.SetChildIndex(this.uCtrlLayerList, 0);
            this.Controls.SetChildIndex(this.cbBoxes, 0);
            this.Controls.SetChildIndex(this.cbCases, 0);
            this.Controls.SetChildIndex(this.checkBoxBestLayersOnly, 0);
            this.Controls.SetChildIndex(this.lbBox, 0);
            this.Controls.SetChildIndex(this.lbCase, 0);
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