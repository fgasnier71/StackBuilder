namespace treeDiM.PLMPack.DBClient
{
    partial class FormRegister
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
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbPasswordConfirm = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbPasswordConfirm = new System.Windows.Forms.TextBox();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.lbCountry = new System.Windows.Forms.Label();
            this.lbCity = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbWebSite = new System.Windows.Forms.Label();
            this.lbCompany = new System.Windows.Forms.Label();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbWebSite = new System.Windows.Forms.TextBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnOK
            // 
            this.bnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Location = new System.Drawing.Point(497, 13);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 0;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(497, 43);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 1;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(13, 22);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(32, 13);
            this.lbEmail.TabIndex = 2;
            this.lbEmail.Text = "Email";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(13, 53);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(58, 13);
            this.lbUserName.TabIndex = 3;
            this.lbUserName.Text = "User name";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(13, 84);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 4;
            this.lbPassword.Text = "Password";
            // 
            // lbPasswordConfirm
            // 
            this.lbPasswordConfirm.AutoSize = true;
            this.lbPasswordConfirm.Location = new System.Drawing.Point(325, 83);
            this.lbPasswordConfirm.Name = "lbPasswordConfirm";
            this.lbPasswordConfirm.Size = new System.Drawing.Size(90, 13);
            this.lbPasswordConfirm.TabIndex = 5;
            this.lbPasswordConfirm.Text = "Confirm password";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(155, 18);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(192, 20);
            this.tbEmail.TabIndex = 6;
            this.tbEmail.TextChanged += new System.EventHandler(this.onValueChanged);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(155, 49);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(139, 20);
            this.tbUserName.TabIndex = 7;
            this.tbUserName.TextChanged += new System.EventHandler(this.onValueChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(155, 80);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(139, 20);
            this.tbPassword.TabIndex = 8;
            this.tbPassword.TextChanged += new System.EventHandler(this.onValueChanged);
            // 
            // tbPasswordConfirm
            // 
            this.tbPasswordConfirm.Location = new System.Drawing.Point(433, 79);
            this.tbPasswordConfirm.Name = "tbPasswordConfirm";
            this.tbPasswordConfirm.PasswordChar = '*';
            this.tbPasswordConfirm.Size = new System.Drawing.Size(139, 20);
            this.tbPasswordConfirm.TabIndex = 9;
            this.tbPasswordConfirm.TextChanged += new System.EventHandler(this.onValueChanged);
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Location = new System.Drawing.Point(13, 146);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(55, 13);
            this.lbFirstName.TabIndex = 10;
            this.lbFirstName.Text = "First name";
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Location = new System.Drawing.Point(325, 146);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(56, 13);
            this.lbLastName.TabIndex = 11;
            this.lbLastName.Text = "Last name";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(156, 142);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(137, 20);
            this.tbFirstName.TabIndex = 12;
            this.tbFirstName.TextChanged += new System.EventHandler(this.onValueChanged);
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(435, 142);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(137, 20);
            this.tbLastName.TabIndex = 13;
            this.tbLastName.TextChanged += new System.EventHandler(this.onValueChanged);
            // 
            // lbCountry
            // 
            this.lbCountry.AutoSize = true;
            this.lbCountry.Location = new System.Drawing.Point(13, 177);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(43, 13);
            this.lbCountry.TabIndex = 14;
            this.lbCountry.Text = "Country";
            // 
            // lbCity
            // 
            this.lbCity.AutoSize = true;
            this.lbCity.Location = new System.Drawing.Point(325, 177);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(24, 13);
            this.lbCity.TabIndex = 15;
            this.lbCity.Text = "City";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(13, 208);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(76, 13);
            this.lbPhone.TabIndex = 16;
            this.lbPhone.Text = "Phone number";
            // 
            // lbWebSite
            // 
            this.lbWebSite.AutoSize = true;
            this.lbWebSite.Location = new System.Drawing.Point(325, 239);
            this.lbWebSite.Name = "lbWebSite";
            this.lbWebSite.Size = new System.Drawing.Size(49, 13);
            this.lbWebSite.TabIndex = 17;
            this.lbWebSite.Text = "Web site";
            // 
            // lbCompany
            // 
            this.lbCompany.AutoSize = true;
            this.lbCompany.Location = new System.Drawing.Point(13, 239);
            this.lbCompany.Name = "lbCompany";
            this.lbCompany.Size = new System.Drawing.Size(51, 13);
            this.lbCompany.TabIndex = 18;
            this.lbCompany.Text = "Company";
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(155, 204);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(138, 20);
            this.tbPhoneNumber.TabIndex = 20;
            this.tbPhoneNumber.TextChanged += new System.EventHandler(this.onValueChanged);
            // 
            // tbCompany
            // 
            this.tbCompany.Location = new System.Drawing.Point(156, 235);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(137, 20);
            this.tbCompany.TabIndex = 21;
            this.tbCompany.TextChanged += new System.EventHandler(this.onValueChanged);
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(435, 173);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(137, 20);
            this.tbCity.TabIndex = 22;
            this.tbCity.TextChanged += new System.EventHandler(this.onValueChanged);
            // 
            // tbWebSite
            // 
            this.tbWebSite.Location = new System.Drawing.Point(435, 235);
            this.tbWebSite.Name = "tbWebSite";
            this.tbWebSite.Size = new System.Drawing.Size(137, 20);
            this.tbWebSite.TabIndex = 23;
            this.tbWebSite.TextChanged += new System.EventHandler(this.onValueChanged);
            // 
            // cbCountry
            // 
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(155, 173);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(138, 21);
            this.cbCountry.TabIndex = 24;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.onValueChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStrip.Location = new System.Drawing.Point(0, 264);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(584, 22);
            this.statusStrip.TabIndex = 25;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            this.toolStripStatusLabelDef.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabelDef.Text = "Ready";
            // 
            // FormRegister
            // 
            this.AcceptButton = this.bnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(584, 286);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.tbWebSite);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.tbCompany);
            this.Controls.Add(this.tbPhoneNumber);
            this.Controls.Add(this.lbCompany);
            this.Controls.Add(this.lbWebSite);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.lbCity);
            this.Controls.Add(this.lbCountry);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.lbLastName);
            this.Controls.Add(this.lbFirstName);
            this.Controls.Add(this.tbPasswordConfirm);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lbPasswordConfirm);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegister";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Register...";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbPasswordConfirm;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbPasswordConfirm;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label lbCountry;
        private System.Windows.Forms.Label lbCity;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbWebSite;
        private System.Windows.Forms.Label lbCompany;
        private System.Windows.Forms.TextBox tbPhoneNumber;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbWebSite;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
    }
}