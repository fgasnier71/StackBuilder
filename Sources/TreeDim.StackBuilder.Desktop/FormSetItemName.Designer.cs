namespace treeDiM.StackBuilder.Desktop
{
    partial class FormSetItemName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetItemName));
            this.lbItemName = new System.Windows.Forms.Label();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbItemName
            // 
            resources.ApplyResources(this.lbItemName, "lbItemName");
            this.lbItemName.Name = "lbItemName";
            // 
            // tbItemName
            // 
            resources.ApplyResources(this.tbItemName, "tbItemName");
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.TextChanged += new System.EventHandler(this.OnItemNameChanged);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLbl});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // statusLbl
            // 
            this.statusLbl.Name = "statusLbl";
            resources.ApplyResources(this.statusLbl, "statusLbl");
            // 
            // FormSetItemName
            // 
            this.AcceptButton = this.bnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.tbItemName);
            this.Controls.Add(this.lbItemName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetItemName";
            this.ShowIcon = false;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLbl;
    }
}