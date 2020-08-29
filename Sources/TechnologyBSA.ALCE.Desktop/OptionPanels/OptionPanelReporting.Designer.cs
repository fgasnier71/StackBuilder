namespace treeDiM.StackBuilder.Desktop
{
    partial class OptionPanelReporting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionPanelReporting));
            this.fileSelectCtrlReportTemplate = new treeDiM.UserControls.FileSelect();
            this.label1 = new System.Windows.Forms.Label();
            this.fileSelectCompanyLogo = new treeDiM.UserControls.FileSelect();
            this.lbReportTemplate = new System.Windows.Forms.Label();
            this.gbMSWordMargins = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMargins = new System.Windows.Forms.TabPage();
            this.lbCmRight = new System.Windows.Forms.Label();
            this.lbCmLeft = new System.Windows.Forms.Label();
            this.lbcmBottom = new System.Windows.Forms.Label();
            this.lbcm = new System.Windows.Forms.Label();
            this.nudRight = new System.Windows.Forms.NumericUpDown();
            this.nudBottom = new System.Windows.Forms.NumericUpDown();
            this.nudLeft = new System.Windows.Forms.NumericUpDown();
            this.nudTop = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lbLeft = new System.Windows.Forms.Label();
            this.lbBottom = new System.Windows.Forms.Label();
            this.lbTop = new System.Windows.Forms.Label();
            this.tabImageDeletion = new System.Windows.Forms.TabPage();
            this.uCtrlTimeBeforeDeletion = new treeDiM.Basics.UCtrlOptInt();
            this.gbMSWordMargins.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMargins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).BeginInit();
            this.tabImageDeletion.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSelectCtrlReportTemplate
            // 
            resources.ApplyResources(this.fileSelectCtrlReportTemplate, "fileSelectCtrlReportTemplate");
            this.fileSelectCtrlReportTemplate.Filter = "XSLT Stylesheet (.xsl)|*.xsl";
            this.fileSelectCtrlReportTemplate.Name = "fileSelectCtrlReportTemplate";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // fileSelectCompanyLogo
            // 
            resources.ApplyResources(this.fileSelectCompanyLogo, "fileSelectCompanyLogo");
            this.fileSelectCompanyLogo.Filter = "Image file (.bmp;.gif;.jpg;.png)|*.bmp;*.gif;*.jpg;*.png";
            this.fileSelectCompanyLogo.Name = "fileSelectCompanyLogo";
            // 
            // lbReportTemplate
            // 
            resources.ApplyResources(this.lbReportTemplate, "lbReportTemplate");
            this.lbReportTemplate.Name = "lbReportTemplate";
            // 
            // gbMSWordMargins
            // 
            resources.ApplyResources(this.gbMSWordMargins, "gbMSWordMargins");
            this.gbMSWordMargins.Controls.Add(this.tabControl1);
            this.gbMSWordMargins.Name = "gbMSWordMargins";
            this.gbMSWordMargins.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMargins);
            this.tabControl1.Controls.Add(this.tabImageDeletion);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabMargins
            // 
            this.tabMargins.Controls.Add(this.lbCmRight);
            this.tabMargins.Controls.Add(this.lbCmLeft);
            this.tabMargins.Controls.Add(this.lbcmBottom);
            this.tabMargins.Controls.Add(this.lbcm);
            this.tabMargins.Controls.Add(this.nudRight);
            this.tabMargins.Controls.Add(this.nudBottom);
            this.tabMargins.Controls.Add(this.nudLeft);
            this.tabMargins.Controls.Add(this.nudTop);
            this.tabMargins.Controls.Add(this.label2);
            this.tabMargins.Controls.Add(this.lbLeft);
            this.tabMargins.Controls.Add(this.lbBottom);
            this.tabMargins.Controls.Add(this.lbTop);
            resources.ApplyResources(this.tabMargins, "tabMargins");
            this.tabMargins.Name = "tabMargins";
            this.tabMargins.UseVisualStyleBackColor = true;
            // 
            // lbCmRight
            // 
            resources.ApplyResources(this.lbCmRight, "lbCmRight");
            this.lbCmRight.Name = "lbCmRight";
            // 
            // lbCmLeft
            // 
            resources.ApplyResources(this.lbCmLeft, "lbCmLeft");
            this.lbCmLeft.Name = "lbCmLeft";
            // 
            // lbcmBottom
            // 
            resources.ApplyResources(this.lbcmBottom, "lbcmBottom");
            this.lbcmBottom.Name = "lbcmBottom";
            // 
            // lbcm
            // 
            resources.ApplyResources(this.lbcm, "lbcm");
            this.lbcm.Name = "lbcm";
            // 
            // nudRight
            // 
            this.nudRight.DecimalPlaces = 1;
            resources.ApplyResources(this.nudRight, "nudRight");
            this.nudRight.Name = "nudRight";
            // 
            // nudBottom
            // 
            this.nudBottom.DecimalPlaces = 1;
            resources.ApplyResources(this.nudBottom, "nudBottom");
            this.nudBottom.Name = "nudBottom";
            // 
            // nudLeft
            // 
            this.nudLeft.DecimalPlaces = 1;
            resources.ApplyResources(this.nudLeft, "nudLeft");
            this.nudLeft.Name = "nudLeft";
            // 
            // nudTop
            // 
            this.nudTop.DecimalPlaces = 1;
            this.nudTop.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.nudTop, "nudTop");
            this.nudTop.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTop.Name = "nudTop";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lbLeft
            // 
            resources.ApplyResources(this.lbLeft, "lbLeft");
            this.lbLeft.Name = "lbLeft";
            // 
            // lbBottom
            // 
            resources.ApplyResources(this.lbBottom, "lbBottom");
            this.lbBottom.Name = "lbBottom";
            // 
            // lbTop
            // 
            resources.ApplyResources(this.lbTop, "lbTop");
            this.lbTop.Name = "lbTop";
            // 
            // tabImageDeletion
            // 
            this.tabImageDeletion.Controls.Add(this.uCtrlTimeBeforeDeletion);
            resources.ApplyResources(this.tabImageDeletion, "tabImageDeletion");
            this.tabImageDeletion.Name = "tabImageDeletion";
            this.tabImageDeletion.UseVisualStyleBackColor = true;
            // 
            // uCtrlTimeBeforeDeletion
            // 
            resources.ApplyResources(this.uCtrlTimeBeforeDeletion, "uCtrlTimeBeforeDeletion");
            this.uCtrlTimeBeforeDeletion.Minimum = -10000;
            this.uCtrlTimeBeforeDeletion.Name = "uCtrlTimeBeforeDeletion";
            // 
            // OptionPanelReporting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Reports";
            this.Controls.Add(this.gbMSWordMargins);
            this.Controls.Add(this.lbReportTemplate);
            this.Controls.Add(this.fileSelectCompanyLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileSelectCtrlReportTemplate);
            this.DisplayName = "Reports";
            this.Name = "OptionPanelReporting";
            this.gbMSWordMargins.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabMargins.ResumeLayout(false);
            this.tabMargins.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).EndInit();
            this.tabImageDeletion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private treeDiM.UserControls.FileSelect fileSelectCtrlReportTemplate;
        private System.Windows.Forms.Label label1;
        private treeDiM.UserControls.FileSelect fileSelectCompanyLogo;
        private System.Windows.Forms.Label lbReportTemplate;
        private System.Windows.Forms.GroupBox gbMSWordMargins;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMargins;
        private System.Windows.Forms.Label lbCmRight;
        private System.Windows.Forms.Label lbCmLeft;
        private System.Windows.Forms.Label lbcmBottom;
        private System.Windows.Forms.Label lbcm;
        private System.Windows.Forms.NumericUpDown nudRight;
        private System.Windows.Forms.NumericUpDown nudBottom;
        private System.Windows.Forms.NumericUpDown nudLeft;
        private System.Windows.Forms.NumericUpDown nudTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbLeft;
        private System.Windows.Forms.Label lbBottom;
        private System.Windows.Forms.Label lbTop;
        private System.Windows.Forms.TabPage tabImageDeletion;
        private treeDiM.Basics.UCtrlOptInt uCtrlTimeBeforeDeletion;
    }
}
