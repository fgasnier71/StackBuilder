namespace PLMPackLibClient
{
    partial class FormEditGroupsOfInterest
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
            this.bnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbGroupsOfInterest = new System.Windows.Forms.ListBox();
            this.lbGroups = new System.Windows.Forms.ListBox();
            this.bnToGroups = new System.Windows.Forms.Button();
            this.bnToInterest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chkbAllGroups = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bnExit
            // 
            this.bnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnExit.Location = new System.Drawing.Point(477, 13);
            this.bnExit.Name = "bnExit";
            this.bnExit.Size = new System.Drawing.Size(75, 23);
            this.bnExit.TabIndex = 0;
            this.bnExit.Text = "Exit";
            this.bnExit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Groups of interest";
            // 
            // lbGroupsOfInterest
            // 
            this.lbGroupsOfInterest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbGroupsOfInterest.FormattingEnabled = true;
            this.lbGroupsOfInterest.Location = new System.Drawing.Point(16, 30);
            this.lbGroupsOfInterest.Name = "lbGroupsOfInterest";
            this.lbGroupsOfInterest.Size = new System.Drawing.Size(148, 173);
            this.lbGroupsOfInterest.TabIndex = 2;
            // 
            // lbGroups
            // 
            this.lbGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbGroups.FormattingEnabled = true;
            this.lbGroups.Location = new System.Drawing.Point(288, 30);
            this.lbGroups.Name = "lbGroups";
            this.lbGroups.Size = new System.Drawing.Size(148, 173);
            this.lbGroups.TabIndex = 3;
            // 
            // bnToGroups
            // 
            this.bnToGroups.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bnToGroups.Location = new System.Drawing.Point(190, 111);
            this.bnToGroups.Name = "bnToGroups";
            this.bnToGroups.Size = new System.Drawing.Size(75, 23);
            this.bnToGroups.TabIndex = 4;
            this.bnToGroups.Text = ">";
            this.bnToGroups.UseVisualStyleBackColor = true;
            this.bnToGroups.Click += new System.EventHandler(this.onToGroups);
            // 
            // bnToInterest
            // 
            this.bnToInterest.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bnToInterest.Location = new System.Drawing.Point(190, 141);
            this.bnToInterest.Name = "bnToInterest";
            this.bnToInterest.Size = new System.Drawing.Size(75, 23);
            this.bnToInterest.TabIndex = 5;
            this.bnToInterest.Text = "<";
            this.bnToInterest.UseVisualStyleBackColor = true;
            this.bnToInterest.Click += new System.EventHandler(this.onToInterest);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Groups";
            // 
            // chkbAllGroups
            // 
            this.chkbAllGroups.AutoSize = true;
            this.chkbAllGroups.Location = new System.Drawing.Point(288, 210);
            this.chkbAllGroups.Name = "chkbAllGroups";
            this.chkbAllGroups.Size = new System.Drawing.Size(101, 17);
            this.chkbAllGroups.TabIndex = 7;
            this.chkbAllGroups.Text = "Show all groups";
            this.chkbAllGroups.UseVisualStyleBackColor = true;
            this.chkbAllGroups.CheckedChanged += new System.EventHandler(this.onShowAllGroups);
            // 
            // FormEditGroupsOfInterest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnExit;
            this.ClientSize = new System.Drawing.Size(564, 261);
            this.Controls.Add(this.chkbAllGroups);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bnToInterest);
            this.Controls.Add(this.bnToGroups);
            this.Controls.Add(this.lbGroups);
            this.Controls.Add(this.lbGroupsOfInterest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnExit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditGroupsOfInterest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add/Remove groups of interest...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbGroupsOfInterest;
        private System.Windows.Forms.ListBox lbGroups;
        private System.Windows.Forms.Button bnToGroups;
        private System.Windows.Forms.Button bnToInterest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkbAllGroups;
    }
}