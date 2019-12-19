namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewAnalysisHCylTruck
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCylinders = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbTrucks = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Size = new System.Drawing.Size(682, 20);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cylinders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Trucks";
            // 
            // cbCylinders
            // 
            this.cbCylinders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCylinders.FormattingEnabled = true;
            this.cbCylinders.Location = new System.Drawing.Point(104, 63);
            this.cbCylinders.Name = "cbCylinders";
            this.cbCylinders.Size = new System.Drawing.Size(145, 21);
            this.cbCylinders.TabIndex = 15;
            // 
            // cbTrucks
            // 
            this.cbTrucks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrucks.FormattingEnabled = true;
            this.cbTrucks.Location = new System.Drawing.Point(435, 63);
            this.cbTrucks.Name = "cbTrucks";
            this.cbTrucks.Size = new System.Drawing.Size(144, 21);
            this.cbTrucks.TabIndex = 16;
            // 
            // FormNewAnalysisHCylTruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbTrucks);
            this.Controls.Add(this.cbCylinders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormNewAnalysisHCylTruck";
            this.Text = "Create new Cylinder/Truck analysis...";
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbCylinders, 0);
            this.Controls.SetChildIndex(this.cbTrucks, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Graphics.Controls.CCtrlComboFiltered cbCylinders;
        private Graphics.Controls.CCtrlComboFiltered cbTrucks;
    }
}