namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewAnalysis
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
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnNext = new System.Windows.Forms.Button();
            this.statusStripDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripDef
            // 
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStripDef.Location = new System.Drawing.Point(0, 539);
            this.statusStripDef.Name = "statusStripDef";
            this.statusStripDef.Size = new System.Drawing.Size(784, 22);
            this.statusStripDef.TabIndex = 5;
            this.statusStripDef.Text = "statusStripDef";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            this.toolStripStatusLabelDef.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabelDef.Text = "toolStripStatusLabelDef";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(104, 34);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(585, 20);
            this.tbDescription.TabIndex = 10;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(104, 6);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(145, 20);
            this.tbName.TabIndex = 8;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDescription.Location = new System.Drawing.Point(5, 34);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(60, 13);
            this.lbDescription.TabIndex = 9;
            this.lbDescription.Text = "Description";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbName.Location = new System.Drawing.Point(6, 9);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 7;
            this.lbName.Text = "Name";
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnCancel.Location = new System.Drawing.Point(698, 4);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(74, 24);
            this.bnCancel.TabIndex = 11;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnNext
            // 
            this.bnNext.Location = new System.Drawing.Point(698, 511);
            this.bnNext.Name = "bnNext";
            this.bnNext.Size = new System.Drawing.Size(74, 24);
            this.bnNext.TabIndex = 12;
            this.bnNext.Text = "Next >";
            this.bnNext.UseVisualStyleBackColor = true;
            this.bnNext.Click += new System.EventHandler(this.onButtonNext);
            // 
            // FormNewAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.bnNext);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.statusStripDef);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FormNewAnalysis";
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.StatusStrip statusStripDef;
        protected System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        protected System.Windows.Forms.TextBox tbDescription;
        protected System.Windows.Forms.TextBox tbName;
        protected System.Windows.Forms.Label lbDescription;
        protected System.Windows.Forms.Label lbName;
        protected System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnNext;
    }
}