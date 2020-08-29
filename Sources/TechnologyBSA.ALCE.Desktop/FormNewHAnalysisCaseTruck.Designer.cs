namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewHAnalysisCaseTruck
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
            this.cbTrucks = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.lbTruck = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz1)).BeginInit();
            this.splitContainerHoriz1.Panel1.SuspendLayout();
            this.splitContainerHoriz1.Panel2.SuspendLayout();
            this.splitContainerHoriz1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz2)).BeginInit();
            this.splitContainerHoriz2.Panel1.SuspendLayout();
            this.splitContainerHoriz2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Size = new System.Drawing.Size(728, 20);
            // 
            // splitContainerHoriz1
            // 
            this.splitContainerHoriz1.Size = new System.Drawing.Size(800, 428);
            // 
            // splitContainerHoriz2
            // 
            this.splitContainerHoriz2.Size = new System.Drawing.Size(800, 370);
            this.splitContainerHoriz2.SplitterDistance = 336;
            // 
            // splitContainerVert
            // 
            // 
            // splitContainerVert.Panel1
            // 
            this.splitContainerVert.Panel1.Controls.Add(this.cbTrucks);
            this.splitContainerVert.Panel1.Controls.Add(this.lbTruck);
            this.splitContainerVert.Size = new System.Drawing.Size(800, 336);
            this.splitContainerVert.SplitterDistance = 276;
            // 
            // gridContent
            // 
            this.gridContent.Location = new System.Drawing.Point(0, 34);
            this.gridContent.Size = new System.Drawing.Size(273, 299);
            // 
            // gridSolutions
            // 
            this.gridSolutions.Size = new System.Drawing.Size(520, 48);
            // 
            // cbTrucks
            // 
            this.cbTrucks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTrucks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrucks.FormattingEnabled = true;
            this.cbTrucks.Location = new System.Drawing.Point(102, 7);
            this.cbTrucks.Name = "cbTrucks";
            this.cbTrucks.Size = new System.Drawing.Size(155, 21);
            this.cbTrucks.TabIndex = 6;
            this.cbTrucks.SelectedIndexChanged += new System.EventHandler(this.OnDataModifiedOverride);
            // 
            // lbTruck
            // 
            this.lbTruck.AutoSize = true;
            this.lbTruck.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTruck.Location = new System.Drawing.Point(9, 10);
            this.lbTruck.Name = "lbTruck";
            this.lbTruck.Size = new System.Drawing.Size(35, 13);
            this.lbTruck.TabIndex = 5;
            this.lbTruck.Text = "Truck";
            // 
            // FormNewHAnalysisCaseTruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FormNewHAnalysisCaseTruck";
            this.Text = "Create new heterogeneous case/truck analysis...";
            this.splitContainerHoriz1.Panel1.ResumeLayout(false);
            this.splitContainerHoriz1.Panel1.PerformLayout();
            this.splitContainerHoriz1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz1)).EndInit();
            this.splitContainerHoriz1.ResumeLayout(false);
            this.splitContainerHoriz2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz2)).EndInit();
            this.splitContainerHoriz2.ResumeLayout(false);
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Graphics.Controls.CCtrlComboFiltered cbTrucks;
        private System.Windows.Forms.Label lbTruck;
    }
}