namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewHAnalysis
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.bnNext = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // bnNext
            // 
            this.bnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnNext.Location = new System.Drawing.Point(706, 512);
            this.bnNext.Name = "bnNext";
            this.bnNext.Size = new System.Drawing.Size(74, 24);
            this.bnNext.TabIndex = 17;
            this.bnNext.Text = "Next >";
            this.bnNext.UseVisualStyleBackColor = true;
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(104, 35);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(676, 20);
            this.tbDescription.TabIndex = 16;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(104, 7);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(145, 20);
            this.tbName.TabIndex = 14;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDescription.Location = new System.Drawing.Point(5, 35);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(60, 13);
            this.lbDescription.TabIndex = 15;
            this.lbDescription.Text = "Description";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbName.Location = new System.Drawing.Point(6, 10);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 13;
            this.lbName.Text = "Name";
            // 
            // FormNewHAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.bnNext);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.statusStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewHAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "New heterogeneous analysis... ";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button bnNext;
        protected System.Windows.Forms.TextBox tbDescription;
        protected System.Windows.Forms.TextBox tbName;
        protected System.Windows.Forms.Label lbDescription;
        protected System.Windows.Forms.Label lbName;
    }
}