namespace treeDiM.PLMPack.DBClient
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.bnOk = new System.Windows.Forms.Button();
            this.bnRegister = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbEmail
            // 
            resources.ApplyResources(this.lbEmail, "lbEmail");
            this.lbEmail.Name = "lbEmail";
            // 
            // lbPassword
            // 
            resources.ApplyResources(this.lbPassword, "lbPassword");
            this.lbPassword.Name = "lbPassword";
            // 
            // tbUserName
            // 
            resources.ApplyResources(this.tbUserName, "tbUserName");
            this.tbUserName.Name = "tbUserName";
            // 
            // tbPassword
            // 
            resources.ApplyResources(this.tbPassword, "tbPassword");
            this.tbPassword.Name = "tbPassword";
            // 
            // bnOk
            // 
            resources.ApplyResources(this.bnOk, "bnOk");
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Name = "bnOk";
            this.bnOk.UseVisualStyleBackColor = true;
            // 
            // bnRegister
            // 
            resources.ApplyResources(this.bnRegister, "bnRegister");
            this.bnRegister.Name = "bnRegister";
            this.bnRegister.UseVisualStyleBackColor = true;
            this.bnRegister.Click += new System.EventHandler(this.bnRegister_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onForgotPassword);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.bnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bnRegister);
            this.Controls.Add(this.bnOk);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbEmail);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Button bnRegister;
        private System.Windows.Forms.Button button1;
    }
}