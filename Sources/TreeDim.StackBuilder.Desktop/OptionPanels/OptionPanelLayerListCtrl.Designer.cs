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
            this.rbView1 = new System.Windows.Forms.RadioButton();
            this.rbView2 = new System.Windows.Forms.RadioButton();
            this.lbThumbSize = new System.Windows.Forms.Label();
            this.cbThumbSize = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // rbView1
            // 
            this.rbView1.AutoSize = true;
            this.rbView1.Location = new System.Drawing.Point(18, 14);
            this.rbView1.Name = "rbView1";
            this.rbView1.Size = new System.Drawing.Size(39, 17);
            this.rbView1.TabIndex = 0;
            this.rbView1.Text = "2D";
            this.rbView1.UseVisualStyleBackColor = true;
            // 
            // rbView2
            // 
            this.rbView2.AutoSize = true;
            this.rbView2.Checked = true;
            this.rbView2.Location = new System.Drawing.Point(76, 14);
            this.rbView2.Name = "rbView2";
            this.rbView2.Size = new System.Drawing.Size(39, 17);
            this.rbView2.TabIndex = 1;
            this.rbView2.TabStop = true;
            this.rbView2.Text = "3D";
            this.rbView2.UseVisualStyleBackColor = true;
            // 
            // lbThumbSize
            // 
            this.lbThumbSize.AutoSize = true;
            this.lbThumbSize.Location = new System.Drawing.Point(18, 52);
            this.lbThumbSize.Name = "lbThumbSize";
            this.lbThumbSize.Size = new System.Drawing.Size(77, 13);
            this.lbThumbSize.TabIndex = 2;
            this.lbThumbSize.Text = "Thumbnail size";
            // 
            // cbThumbSize
            // 
            this.cbThumbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThumbSize.FormattingEnabled = true;
            this.cbThumbSize.Items.AddRange(new object[] {
            "75 x 75",
            "100 x 100",
            "150 x 150",
            "200 x 200"});
            this.cbThumbSize.Location = new System.Drawing.Point(130, 49);
            this.cbThumbSize.Name = "cbThumbSize";
            this.cbThumbSize.Size = new System.Drawing.Size(121, 21);
            this.cbThumbSize.TabIndex = 3;
            // 
            // OptionPanelLayerListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Layer view";
            this.Controls.Add(this.cbThumbSize);
            this.Controls.Add(this.lbThumbSize);
            this.Controls.Add(this.rbView2);
            this.Controls.Add(this.rbView1);
            this.DisplayName = "Layer view control";
            this.Location = new System.Drawing.Point(0, 0);
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
