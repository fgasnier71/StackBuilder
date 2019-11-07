namespace treeDiM.StackBuilder.Desktop
{
    partial class FormBecomePremiumUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBecomePremiumUser));
            this.linkLabelPremiumVsFree = new System.Windows.Forms.LinkLabel();
            this.lbSubscribe = new System.Windows.Forms.Label();
            this.cbSubscriptionDuration = new System.Windows.Forms.ComboBox();
            this.lbProposal = new System.Windows.Forms.Label();
            this.cbPaymentMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.bnSend = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkLabelPremiumVsFree
            // 
            resources.ApplyResources(this.linkLabelPremiumVsFree, "linkLabelPremiumVsFree");
            this.linkLabelPremiumVsFree.Name = "linkLabelPremiumVsFree";
            this.linkLabelPremiumVsFree.TabStop = true;
            this.linkLabelPremiumVsFree.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnPremiumVsFreeClicked);
            // 
            // lbSubscribe
            // 
            resources.ApplyResources(this.lbSubscribe, "lbSubscribe");
            this.lbSubscribe.Name = "lbSubscribe";
            // 
            // cbSubscriptionDuration
            // 
            resources.ApplyResources(this.cbSubscriptionDuration, "cbSubscriptionDuration");
            this.cbSubscriptionDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubscriptionDuration.FormattingEnabled = true;
            this.cbSubscriptionDuration.Items.AddRange(new object[] {
            resources.GetString("cbSubscriptionDuration.Items"),
            resources.GetString("cbSubscriptionDuration.Items1")});
            this.cbSubscriptionDuration.Name = "cbSubscriptionDuration";
            // 
            // lbProposal
            // 
            resources.ApplyResources(this.lbProposal, "lbProposal");
            this.lbProposal.Name = "lbProposal";
            // 
            // cbPaymentMode
            // 
            resources.ApplyResources(this.cbPaymentMode, "cbPaymentMode");
            this.cbPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentMode.FormattingEnabled = true;
            this.cbPaymentMode.Items.AddRange(new object[] {
            resources.GetString("cbPaymentMode.Items"),
            resources.GetString("cbPaymentMode.Items1")});
            this.cbPaymentMode.Name = "cbPaymentMode";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tbEmail
            // 
            resources.ApplyResources(this.tbEmail, "tbEmail");
            this.tbEmail.Name = "tbEmail";
            // 
            // bnSend
            // 
            resources.ApplyResources(this.bnSend, "bnSend");
            this.bnSend.Name = "bnSend";
            this.bnSend.UseVisualStyleBackColor = true;
            this.bnSend.Click += new System.EventHandler(this.OnSendClicked);
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // FormBecomePremiumUser
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnSend);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPaymentMode);
            this.Controls.Add(this.lbProposal);
            this.Controls.Add(this.cbSubscriptionDuration);
            this.Controls.Add(this.lbSubscribe);
            this.Controls.Add(this.linkLabelPremiumVsFree);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBecomePremiumUser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelPremiumVsFree;
        private System.Windows.Forms.Label lbSubscribe;
        private System.Windows.Forms.ComboBox cbSubscriptionDuration;
        private System.Windows.Forms.Label lbProposal;
        private System.Windows.Forms.ComboBox cbPaymentMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Button bnSend;
        private System.Windows.Forms.Button bnCancel;
    }
}