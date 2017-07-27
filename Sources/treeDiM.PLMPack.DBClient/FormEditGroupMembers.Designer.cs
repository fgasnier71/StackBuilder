namespace treeDiM.PLMPack.DBClient
{
    partial class FormEditGroupMembers
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
            this.lbListOfUsers = new System.Windows.Forms.Label();
            this.listboxUsers = new System.Windows.Forms.ListBox();
            this.bnAdd = new System.Windows.Forms.Button();
            this.bnRemove = new System.Windows.Forms.Button();
            this.lbUserToRemove = new System.Windows.Forms.Label();
            this.tbUserToAdd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bnExit
            // 
            this.bnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnExit.Location = new System.Drawing.Point(497, 12);
            this.bnExit.Name = "bnExit";
            this.bnExit.Size = new System.Drawing.Size(75, 23);
            this.bnExit.TabIndex = 0;
            this.bnExit.Text = "Exit";
            this.bnExit.UseVisualStyleBackColor = true;
            // 
            // lbListOfUsers
            // 
            this.lbListOfUsers.AutoSize = true;
            this.lbListOfUsers.Location = new System.Drawing.Point(13, 13);
            this.lbListOfUsers.Name = "lbListOfUsers";
            this.lbListOfUsers.Size = new System.Drawing.Size(76, 13);
            this.lbListOfUsers.TabIndex = 1;
            this.lbListOfUsers.Text = "Users of group";
            // 
            // listboxUsers
            // 
            this.listboxUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listboxUsers.FormattingEnabled = true;
            this.listboxUsers.Location = new System.Drawing.Point(16, 30);
            this.listboxUsers.Name = "listboxUsers";
            this.listboxUsers.Size = new System.Drawing.Size(134, 225);
            this.listboxUsers.TabIndex = 2;
            this.listboxUsers.SelectedIndexChanged += new System.EventHandler(this.onUpdateUI);
            // 
            // bnAdd
            // 
            this.bnAdd.Location = new System.Drawing.Point(170, 30);
            this.bnAdd.Name = "bnAdd";
            this.bnAdd.Size = new System.Drawing.Size(75, 23);
            this.bnAdd.TabIndex = 3;
            this.bnAdd.Text = "Add";
            this.bnAdd.UseVisualStyleBackColor = true;
            this.bnAdd.Click += new System.EventHandler(this.onUserAdd);
            // 
            // bnRemove
            // 
            this.bnRemove.Location = new System.Drawing.Point(170, 60);
            this.bnRemove.Name = "bnRemove";
            this.bnRemove.Size = new System.Drawing.Size(75, 23);
            this.bnRemove.TabIndex = 4;
            this.bnRemove.Text = "Remove";
            this.bnRemove.UseVisualStyleBackColor = true;
            this.bnRemove.Click += new System.EventHandler(this.onUserRemove);
            // 
            // lbUserToRemove
            // 
            this.lbUserToRemove.AutoSize = true;
            this.lbUserToRemove.Location = new System.Drawing.Point(251, 65);
            this.lbUserToRemove.Name = "lbUserToRemove";
            this.lbUserToRemove.Size = new System.Drawing.Size(55, 13);
            this.lbUserToRemove.TabIndex = 5;
            this.lbUserToRemove.Text = "userName";
            // 
            // tbUserToAdd
            // 
            this.tbUserToAdd.Location = new System.Drawing.Point(254, 32);
            this.tbUserToAdd.Name = "tbUserToAdd";
            this.tbUserToAdd.Size = new System.Drawing.Size(124, 20);
            this.tbUserToAdd.TabIndex = 6;
            this.tbUserToAdd.TextChanged += new System.EventHandler(this.onUpdateUI);
            // 
            // FormEditGroupMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnExit;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.tbUserToAdd);
            this.Controls.Add(this.lbUserToRemove);
            this.Controls.Add(this.bnRemove);
            this.Controls.Add(this.bnAdd);
            this.Controls.Add(this.listboxUsers);
            this.Controls.Add(this.lbListOfUsers);
            this.Controls.Add(this.bnExit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditGroupMembers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add / Remove group members";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnExit;
        private System.Windows.Forms.Label lbListOfUsers;
        private System.Windows.Forms.ListBox listboxUsers;
        private System.Windows.Forms.Button bnAdd;
        private System.Windows.Forms.Button bnRemove;
        private System.Windows.Forms.Label lbUserToRemove;
        private System.Windows.Forms.TextBox tbUserToAdd;
    }
}