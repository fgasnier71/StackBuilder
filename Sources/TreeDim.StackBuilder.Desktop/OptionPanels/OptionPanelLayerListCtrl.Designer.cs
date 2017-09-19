namespace treeDiM.StackBuilder.Desktop
{
    partial class OptionPanelLayerListCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionPanelLayerListCtrl));
            this.rbView1 = new System.Windows.Forms.RadioButton();
            this.rbView2 = new System.Windows.Forms.RadioButton();
            this.lbThumbSize = new System.Windows.Forms.Label();
            this.cbThumbSize = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // rbView1
            // 
            resources.ApplyResources(this.rbView1, "rbView1");
            this.rbView1.Name = "rbView1";
            this.rbView1.UseVisualStyleBackColor = true;
            // 
            // rbView2
            // 
            resources.ApplyResources(this.rbView2, "rbView2");
            this.rbView2.Checked = true;
            this.rbView2.Name = "rbView2";
            this.rbView2.TabStop = true;
            this.rbView2.UseVisualStyleBackColor = true;
            // 
            // lbThumbSize
            // 
            resources.ApplyResources(this.lbThumbSize, "lbThumbSize");
            this.lbThumbSize.Name = "lbThumbSize";
            // 
            // cbThumbSize
            // 
            resources.ApplyResources(this.cbThumbSize, "cbThumbSize");
            this.cbThumbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThumbSize.FormattingEnabled = true;
            this.cbThumbSize.Items.AddRange(new object[] {
            resources.GetString("cbThumbSize.Items"),
            resources.GetString("cbThumbSize.Items1"),
            resources.GetString("cbThumbSize.Items2"),
            resources.GetString("cbThumbSize.Items3")});
            this.cbThumbSize.Name = "cbThumbSize";
            // 
            // OptionPanelLayerListCtrl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Layer view";
            this.Controls.Add(this.cbThumbSize);
            this.Controls.Add(this.lbThumbSize);
            this.Controls.Add(this.rbView2);
            this.Controls.Add(this.rbView1);
            this.DisplayName = "Layer view control";
            this.Name = "OptionPanelLayerListCtrl";
            this.Load += new System.EventHandler(this.OptionPanelLayerListCtrl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbView1;
        private System.Windows.Forms.RadioButton rbView2;
        private System.Windows.Forms.Label lbThumbSize;
        private System.Windows.Forms.ComboBox cbThumbSize;
    }
}
