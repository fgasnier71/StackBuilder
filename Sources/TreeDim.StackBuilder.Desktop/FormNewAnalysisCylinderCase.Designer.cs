namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewAnalysisCylinderCase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewAnalysisCylinderCase));
            this.lbCylinder = new System.Windows.Forms.Label();
            this.lbCase = new System.Windows.Forms.Label();
            this.cbCylinders = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbCases = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.checkBoxBestLayersOnly = new System.Windows.Forms.CheckBox();
            this.uCtrlLayerList = new treeDiM.StackBuilder.Graphics.UCtrlLayerList();
            this.lbSelect = new System.Windows.Forms.Label();
            this.uCtrlPackable = new treeDiM.StackBuilder.Graphics.Controls.UCtrlPackable();
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
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            // 
            // lbCylinder
            // 
            resources.ApplyResources(this.lbCylinder, "lbCylinder");
            this.lbCylinder.Name = "lbCylinder";
            // 
            // lbCase
            // 
            resources.ApplyResources(this.lbCase, "lbCase");
            this.lbCase.Name = "lbCase";
            // 
            // cbCylinders
            // 
            resources.ApplyResources(this.cbCylinders, "cbCylinders");
            this.cbCylinders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCylinders.FormattingEnabled = true;
            this.cbCylinders.Name = "cbCylinders";
            this.cbCylinders.SelectedIndexChanged += new System.EventHandler(this.onCylinderChanged);
            // 
            // cbCases
            // 
            resources.ApplyResources(this.cbCases, "cbCases");
            this.cbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCases.FormattingEnabled = true;
            this.cbCases.Name = "cbCases";
            this.cbCases.SelectedIndexChanged += new System.EventHandler(this.onInputChanged);
            // 
            // checkBoxBestLayersOnly
            // 
            resources.ApplyResources(this.checkBoxBestLayersOnly, "checkBoxBestLayersOnly");
            this.checkBoxBestLayersOnly.Name = "checkBoxBestLayersOnly";
            this.checkBoxBestLayersOnly.UseVisualStyleBackColor = true;
            this.checkBoxBestLayersOnly.CheckedChanged += new System.EventHandler(this.onInputChanged);
            // 
            // uCtrlLayerList
            // 
            resources.ApplyResources(this.uCtrlLayerList, "uCtrlLayerList");
            this.uCtrlLayerList.ButtonSizes = new System.Drawing.Size(150, 150);
            this.uCtrlLayerList.Name = "uCtrlLayerList";
            this.uCtrlLayerList.Show3D = true;
            this.uCtrlLayerList.SingleSelection = false;
            // 
            // lbSelect
            // 
            resources.ApplyResources(this.lbSelect, "lbSelect");
            this.lbSelect.Name = "lbSelect";
            // 
            // uCtrlPackable
            // 
            resources.ApplyResources(this.uCtrlPackable, "uCtrlPackable");
            this.uCtrlPackable.Name = "uCtrlPackable";
            // 
            // FormNewAnalysisCylinderCase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uCtrlPackable);
            this.Controls.Add(this.lbSelect);
            this.Controls.Add(this.uCtrlLayerList);
            this.Controls.Add(this.checkBoxBestLayersOnly);
            this.Controls.Add(this.cbCases);
            this.Controls.Add(this.cbCylinders);
            this.Controls.Add(this.lbCase);
            this.Controls.Add(this.lbCylinder);
            this.Name = "FormNewAnalysisCylinderCase";
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.lbCylinder, 0);
            this.Controls.SetChildIndex(this.lbCase, 0);
            this.Controls.SetChildIndex(this.cbCylinders, 0);
            this.Controls.SetChildIndex(this.cbCases, 0);
            this.Controls.SetChildIndex(this.checkBoxBestLayersOnly, 0);
            this.Controls.SetChildIndex(this.uCtrlLayerList, 0);
            this.Controls.SetChildIndex(this.lbSelect, 0);
            this.Controls.SetChildIndex(this.uCtrlPackable, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCylinder;
        private System.Windows.Forms.Label lbCase;
        private Graphics.Controls.CCtrlComboFiltered cbCylinders;
        private Graphics.Controls.CCtrlComboFiltered cbCases;
        private System.Windows.Forms.CheckBox checkBoxBestLayersOnly;
        private Graphics.UCtrlLayerList uCtrlLayerList;
        private System.Windows.Forms.Label lbSelect;
        private Graphics.Controls.UCtrlPackable uCtrlPackable;
    }
}