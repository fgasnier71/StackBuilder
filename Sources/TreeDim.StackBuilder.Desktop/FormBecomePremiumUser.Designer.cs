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
            this.lbEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.bnSend = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.rbSubscription1 = new System.Windows.Forms.RadioButton();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.rbSubscription2 = new System.Windows.Forms.RadioButton();
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
            // lbEmail
            // 
            resources.ApplyResources(this.lbEmail, "lbEmail");
            this.lbEmail.Name = "lbEmail";
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
            // rbSubscription1
            // 
            resources.ApplyResources(this.rbSubscription1, "rbSubscription1");
            this.rbSubscription1.Name = "rbSubscription1";
            this.rbSubscription1.TabStop = true;
            this.rbSubscription1.UseVisualStyleBackColor = true;
            this.rbSubscription1.CheckedChanged += new System.EventHandler(this.OnPaymentModeChanged);
            // 
            // webBrowser
            // 
            this.webBrowser.AllowWebBrowserDrop = false;
            resources.ApplyResources(this.webBrowser, "webBrowser");
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Url = new System.Uri("http://www.plmpack.com/stackbuilder/premium/paypal_small.htm", System.UriKind.Absolute);
            // 
            // rbSubscription2
            // 
            resources.ApplyResources(this.rbSubscription2, "rbSubscription2");
            this.rbSubscription2.Name = "rbSubscription2";
            this.rbSubscription2.TabStop = true;
            this.rbSubscription2.UseVisualStyleBackColor = true;
            this.rbSubscription2.CheckedChanged += new System.EventHandler(this.OnPaymentModeChanged);
            // 
            // FormBecomePremiumUser
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.rbSubscription2);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.rbSubscription1);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnSend);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lbEmail);
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
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Button bnSend;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.RadioButton rbSubscription1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.RadioButton rbSubscription2;
    }
}