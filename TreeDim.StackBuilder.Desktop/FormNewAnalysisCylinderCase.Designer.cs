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
            this.lbCylinder = new System.Windows.Forms.Label();
            this.lbCase = new System.Windows.Forms.Label();
            this.cbCylinders = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbCases = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.checkBoxBestLayersOnly = new System.Windows.Forms.CheckBox();
            this.uCtrlLayerList = new treeDiM.StackBuilder.Graphics.UCtrlLayerList();
            this.graphCtrlCylinder = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlCylinder)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Size = new System.Drawing.Size(592, 20);
            // 
            // bnCancel
            // 
            this.bnCancel.Location = new System.Drawing.Point(706, 4);
            // 
            // lbCylinder
            // 
            this.lbCylinder.AutoSize = true;
            this.lbCylinder.Location = new System.Drawing.Point(8, 67);
            this.lbCylinder.Name = "lbCylinder";
            this.lbCylinder.Size = new System.Drawing.Size(44, 13);
            this.lbCylinder.TabIndex = 13;
            this.lbCylinder.Text = "Cylinder";
            // 
            // lbCase
            // 
            this.lbCase.AutoSize = true;
            this.lbCase.Location = new System.Drawing.Point(367, 67);
            this.lbCase.Name = "lbCase";
            this.lbCase.Size = new System.Drawing.Size(31, 13);
            this.lbCase.TabIndex = 14;
            this.lbCase.Text = "Case";
            // 
            // cbCylinders
            // 
            this.cbCylinders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCylinders.FormattingEnabled = true;
            this.cbCylinders.Location = new System.Drawing.Point(104, 63);
            this.cbCylinders.Name = "cbCylinders";
            this.cbCylinders.Size = new System.Drawing.Size(145, 21);
            this.cbCylinders.TabIndex = 15;
            this.cbCylinders.SelectedIndexChanged += new System.EventHandler(this.onIputChanged);
            // 
            // cbCases
            // 
            this.cbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCases.FormattingEnabled = true;
            this.cbCases.Location = new System.Drawing.Point(432, 63);
            this.cbCases.Name = "cbCases";
            this.cbCases.Size = new System.Drawing.Size(145, 21);
            this.cbCases.TabIndex = 16;
            this.cbCases.SelectedIndexChanged += new System.EventHandler(this.onIputChanged);
            // 
            // checkBoxBestLayersOnly
            // 
            this.checkBoxBestLayersOnly.AutoSize = true;
            this.checkBoxBestLayersOnly.Location = new System.Drawing.Point(7, 517);
            this.checkBoxBestLayersOnly.Name = "checkBoxBestLayersOnly";
            this.checkBoxBestLayersOnly.Size = new System.Drawing.Size(128, 17);
            this.checkBoxBestLayersOnly.TabIndex = 29;
            this.checkBoxBestLayersOnly.Text = "Show best layers only";
            this.checkBoxBestLayersOnly.UseVisualStyleBackColor = true;
            // 
            // uCtrlLayerList
            // 
            this.uCtrlLayerList.AutoScroll = true;
            this.uCtrlLayerList.ButtonSizes = new System.Drawing.Size(150, 150);
            this.uCtrlLayerList.Location = new System.Drawing.Point(0, 218);
            this.uCtrlLayerList.Name = "uCtrlLayerList";
            this.uCtrlLayerList.Size = new System.Drawing.Size(784, 289);
            this.uCtrlLayerList.TabIndex = 30;
            // 
            // graphCtrlCylinder
            // 
            this.graphCtrlCylinder.Location = new System.Drawing.Point(104, 92);
            this.graphCtrlCylinder.Name = "graphCtrlCylinder";
            this.graphCtrlCylinder.Size = new System.Drawing.Size(110, 110);
            this.graphCtrlCylinder.TabIndex = 31;
            this.graphCtrlCylinder.Viewer = null;
            // 
            // FormNewAnalysisCylinderCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.graphCtrlCylinder);
            this.Controls.Add(this.uCtrlLayerList);
            this.Controls.Add(this.checkBoxBestLayersOnly);
            this.Controls.Add(this.cbCases);
            this.Controls.Add(this.cbCylinders);
            this.Controls.Add(this.lbCase);
            this.Controls.Add(this.lbCylinder);
            this.Name = "FormNewAnalysisCylinderCase";
            this.Text = "Create new cylinder analysis...";
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
            this.Controls.SetChildIndex(this.graphCtrlCylinder, 0);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlCylinder)).EndInit();
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
        private Graphics.Graphics3DControl graphCtrlCylinder;
    }
}