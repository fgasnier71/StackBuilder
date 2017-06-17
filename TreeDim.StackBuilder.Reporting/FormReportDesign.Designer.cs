namespace treeDiM.StackBuilder.Reporting
{
    partial class FormReportDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportDesign));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolSBReportWord = new System.Windows.Forms.ToolStripButton();
            this.toolSBReportHTML = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSBDimensions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._treeView = new System.Windows.Forms.TreeView();
            this.tabCtrlImageParam = new System.Windows.Forms.TabControl();
            this.tabPageDetail = new System.Windows.Forms.TabPage();
            this.cbFontSizeDetail = new treeDiM.StackBuilder.Reporting.ComboFontSize();
            this.lbFontSizeDetail = new System.Windows.Forms.Label();
            this.cbHTMLSizeDetail = new treeDiM.StackBuilder.Reporting.ComboImgSize();
            this.lbHTMLSizeDetail = new System.Windows.Forms.Label();
            this.cbDefinitionDetail = new treeDiM.StackBuilder.Reporting.ComboImageDefinition();
            this.lbDefinitionDetail = new System.Windows.Forms.Label();
            this.tabPageLargeImg = new System.Windows.Forms.TabPage();
            this.cbFontSizeLarge = new treeDiM.StackBuilder.Reporting.ComboFontSize();
            this.cbHTMLSizeLarge = new treeDiM.StackBuilder.Reporting.ComboImgSize();
            this.cbDefinitionLarge = new treeDiM.StackBuilder.Reporting.ComboImageDefinition();
            this.lbFontSizeLarge = new System.Windows.Forms.Label();
            this.lbHTMLSizeLarge = new System.Windows.Forms.Label();
            this.lbDefinitionLarge = new System.Windows.Forms.Label();
            this._webBrowser = new System.Windows.Forms.WebBrowser();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabCtrlImageParam.SuspendLayout();
            this.tabPageDetail.SuspendLayout();
            this.tabPageLargeImg.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelDef});
            this.statusStrip.Location = new System.Drawing.Point(0, 639);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(884, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabelDef
            // 
            this.statusLabelDef.Name = "statusLabelDef";
            this.statusLabelDef.Size = new System.Drawing.Size(39, 17);
            this.statusLabelDef.Text = "Ready";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSBReportWord,
            this.toolSBReportHTML,
            this.toolStripSeparator1,
            this.toolSBDimensions,
            this.toolStripSeparator2});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(884, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolSBReportWord
            // 
            this.toolSBReportWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSBReportWord.Image = ((System.Drawing.Image)(resources.GetObject("toolSBReportWord.Image")));
            this.toolSBReportWord.ImageTransparentColor = System.Drawing.Color.White;
            this.toolSBReportWord.Name = "toolSBReportWord";
            this.toolSBReportWord.Size = new System.Drawing.Size(23, 22);
            this.toolSBReportWord.Text = "Word";
            this.toolSBReportWord.Click += new System.EventHandler(this.onReportMSWord);
            // 
            // toolSBReportHTML
            // 
            this.toolSBReportHTML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSBReportHTML.Image = ((System.Drawing.Image)(resources.GetObject("toolSBReportHTML.Image")));
            this.toolSBReportHTML.ImageTransparentColor = System.Drawing.Color.White;
            this.toolSBReportHTML.Name = "toolSBReportHTML";
            this.toolSBReportHTML.Size = new System.Drawing.Size(23, 22);
            this.toolSBReportHTML.Text = "HTML";
            this.toolSBReportHTML.Click += new System.EventHandler(this.onReportHTML);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolSBDimensions
            // 
            this.toolSBDimensions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSBDimensions.Image = ((System.Drawing.Image)(resources.GetObject("toolSBDimensions.Image")));
            this.toolSBDimensions.ImageTransparentColor = System.Drawing.Color.White;
            this.toolSBDimensions.Name = "toolSBDimensions";
            this.toolSBDimensions.Size = new System.Drawing.Size(23, 22);
            this.toolSBDimensions.Text = "Show / Hide dimensions";
            this.toolSBDimensions.Click += new System.EventHandler(this.onShowDimensions);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._webBrowser);
            this.splitContainer1.Size = new System.Drawing.Size(884, 614);
            this.splitContainer1.SplitterDistance = 165;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this._treeView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabCtrlImageParam);
            this.splitContainer2.Size = new System.Drawing.Size(165, 614);
            this.splitContainer2.SplitterDistance = 480;
            this.splitContainer2.TabIndex = 1;
            // 
            // _treeView
            // 
            this._treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._treeView.Location = new System.Drawing.Point(0, 0);
            this._treeView.Name = "_treeView";
            this._treeView.Size = new System.Drawing.Size(165, 480);
            this._treeView.TabIndex = 1;
            this._treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.onNodeChecked);
            // 
            // tabCtrlImageParam
            // 
            this.tabCtrlImageParam.Controls.Add(this.tabPageDetail);
            this.tabCtrlImageParam.Controls.Add(this.tabPageLargeImg);
            this.tabCtrlImageParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlImageParam.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlImageParam.Name = "tabCtrlImageParam";
            this.tabCtrlImageParam.SelectedIndex = 0;
            this.tabCtrlImageParam.Size = new System.Drawing.Size(165, 130);
            this.tabCtrlImageParam.TabIndex = 0;
            // 
            // tabPageDetail
            // 
            this.tabPageDetail.Controls.Add(this.cbFontSizeDetail);
            this.tabPageDetail.Controls.Add(this.lbFontSizeDetail);
            this.tabPageDetail.Controls.Add(this.cbHTMLSizeDetail);
            this.tabPageDetail.Controls.Add(this.lbHTMLSizeDetail);
            this.tabPageDetail.Controls.Add(this.cbDefinitionDetail);
            this.tabPageDetail.Controls.Add(this.lbDefinitionDetail);
            this.tabPageDetail.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetail.Name = "tabPageDetail";
            this.tabPageDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetail.Size = new System.Drawing.Size(157, 104);
            this.tabPageDetail.TabIndex = 0;
            this.tabPageDetail.Text = "Detail image";
            this.tabPageDetail.UseVisualStyleBackColor = true;
            // 
            // cbFontSizeDetail
            // 
            this.cbFontSizeDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontSizeDetail.FontSizeRatio = 0.01F;
            this.cbFontSizeDetail.FormattingEnabled = true;
            this.cbFontSizeDetail.Location = new System.Drawing.Point(72, 59);
            this.cbFontSizeDetail.Name = "cbFontSizeDetail";
            this.cbFontSizeDetail.Size = new System.Drawing.Size(80, 21);
            this.cbFontSizeDetail.TabIndex = 5;
            // 
            // lbFontSizeDetail
            // 
            this.lbFontSizeDetail.AutoSize = true;
            this.lbFontSizeDetail.Location = new System.Drawing.Point(5, 62);
            this.lbFontSizeDetail.Name = "lbFontSizeDetail";
            this.lbFontSizeDetail.Size = new System.Drawing.Size(49, 13);
            this.lbFontSizeDetail.TabIndex = 4;
            this.lbFontSizeDetail.Text = "Font size";
            // 
            // cbHTMLSizeDetail
            // 
            this.cbHTMLSizeDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHTMLSizeDetail.FormattingEnabled = true;
            this.cbHTMLSizeDetail.Location = new System.Drawing.Point(72, 31);
            this.cbHTMLSizeDetail.Name = "cbHTMLSizeDetail";
            this.cbHTMLSizeDetail.Size = new System.Drawing.Size(80, 21);
            this.cbHTMLSizeDetail.TabIndex = 3;
            // 
            // lbHTMLSizeDetail
            // 
            this.lbHTMLSizeDetail.AutoSize = true;
            this.lbHTMLSizeDetail.Location = new System.Drawing.Point(5, 34);
            this.lbHTMLSizeDetail.Name = "lbHTMLSizeDetail";
            this.lbHTMLSizeDetail.Size = new System.Drawing.Size(58, 13);
            this.lbHTMLSizeDetail.TabIndex = 2;
            this.lbHTMLSizeDetail.Text = "HTML size";
            // 
            // cbDefinitionDetail
            // 
            this.cbDefinitionDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefinitionDetail.FormattingEnabled = true;
            this.cbDefinitionDetail.Location = new System.Drawing.Point(72, 3);
            this.cbDefinitionDetail.Name = "cbDefinitionDetail";
            this.cbDefinitionDetail.Size = new System.Drawing.Size(80, 21);
            this.cbDefinitionDetail.TabIndex = 1;
            // 
            // lbDefinitionDetail
            // 
            this.lbDefinitionDetail.AutoSize = true;
            this.lbDefinitionDetail.Location = new System.Drawing.Point(5, 6);
            this.lbDefinitionDetail.Name = "lbDefinitionDetail";
            this.lbDefinitionDetail.Size = new System.Drawing.Size(51, 13);
            this.lbDefinitionDetail.TabIndex = 0;
            this.lbDefinitionDetail.Text = "Definition";
            // 
            // tabPageLargeImg
            // 
            this.tabPageLargeImg.Controls.Add(this.cbFontSizeLarge);
            this.tabPageLargeImg.Controls.Add(this.cbHTMLSizeLarge);
            this.tabPageLargeImg.Controls.Add(this.cbDefinitionLarge);
            this.tabPageLargeImg.Controls.Add(this.lbFontSizeLarge);
            this.tabPageLargeImg.Controls.Add(this.lbHTMLSizeLarge);
            this.tabPageLargeImg.Controls.Add(this.lbDefinitionLarge);
            this.tabPageLargeImg.Location = new System.Drawing.Point(4, 22);
            this.tabPageLargeImg.Name = "tabPageLargeImg";
            this.tabPageLargeImg.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLargeImg.Size = new System.Drawing.Size(157, 104);
            this.tabPageLargeImg.TabIndex = 1;
            this.tabPageLargeImg.Text = "Large image";
            this.tabPageLargeImg.UseVisualStyleBackColor = true;
            // 
            // cbFontSizeLarge
            // 
            this.cbFontSizeLarge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontSizeLarge.FontSizeRatio = 0.01F;
            this.cbFontSizeLarge.FormattingEnabled = true;
            this.cbFontSizeLarge.Location = new System.Drawing.Point(72, 59);
            this.cbFontSizeLarge.Name = "cbFontSizeLarge";
            this.cbFontSizeLarge.Size = new System.Drawing.Size(80, 21);
            this.cbFontSizeLarge.TabIndex = 5;
            // 
            // cbHTMLSizeLarge
            // 
            this.cbHTMLSizeLarge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHTMLSizeLarge.FormattingEnabled = true;
            this.cbHTMLSizeLarge.Location = new System.Drawing.Point(72, 31);
            this.cbHTMLSizeLarge.Name = "cbHTMLSizeLarge";
            this.cbHTMLSizeLarge.Size = new System.Drawing.Size(80, 21);
            this.cbHTMLSizeLarge.TabIndex = 4;
            // 
            // cbDefinitionLarge
            // 
            this.cbDefinitionLarge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefinitionLarge.FormattingEnabled = true;
            this.cbDefinitionLarge.Location = new System.Drawing.Point(72, 3);
            this.cbDefinitionLarge.Name = "cbDefinitionLarge";
            this.cbDefinitionLarge.Size = new System.Drawing.Size(80, 21);
            this.cbDefinitionLarge.TabIndex = 3;
            // 
            // lbFontSizeLarge
            // 
            this.lbFontSizeLarge.AutoSize = true;
            this.lbFontSizeLarge.Location = new System.Drawing.Point(5, 62);
            this.lbFontSizeLarge.Name = "lbFontSizeLarge";
            this.lbFontSizeLarge.Size = new System.Drawing.Size(49, 13);
            this.lbFontSizeLarge.TabIndex = 2;
            this.lbFontSizeLarge.Text = "Font size";
            // 
            // lbHTMLSizeLarge
            // 
            this.lbHTMLSizeLarge.AutoSize = true;
            this.lbHTMLSizeLarge.Location = new System.Drawing.Point(5, 34);
            this.lbHTMLSizeLarge.Name = "lbHTMLSizeLarge";
            this.lbHTMLSizeLarge.Size = new System.Drawing.Size(58, 13);
            this.lbHTMLSizeLarge.TabIndex = 1;
            this.lbHTMLSizeLarge.Text = "HTML size";
            // 
            // lbDefinitionLarge
            // 
            this.lbDefinitionLarge.AutoSize = true;
            this.lbDefinitionLarge.Location = new System.Drawing.Point(5, 6);
            this.lbDefinitionLarge.Name = "lbDefinitionLarge";
            this.lbDefinitionLarge.Size = new System.Drawing.Size(51, 13);
            this.lbDefinitionLarge.TabIndex = 0;
            this.lbDefinitionLarge.Text = "Definition";
            // 
            // _webBrowser
            // 
            this._webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this._webBrowser.Location = new System.Drawing.Point(0, 0);
            this._webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this._webBrowser.Name = "_webBrowser";
            this._webBrowser.Size = new System.Drawing.Size(715, 614);
            this._webBrowser.TabIndex = 0;
            // 
            // FormReportDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportDesign";
            this.ShowInTaskbar = false;
            this.Text = "Report...";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabCtrlImageParam.ResumeLayout(false);
            this.tabPageDetail.ResumeLayout(false);
            this.tabPageDetail.PerformLayout();
            this.tabPageLargeImg.ResumeLayout(false);
            this.tabPageLargeImg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelDef;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolSBReportWord;
        private System.Windows.Forms.ToolStripButton toolSBReportHTML;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.WebBrowser _webBrowser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolSBDimensions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView _treeView;
        private System.Windows.Forms.TabControl tabCtrlImageParam;
        private System.Windows.Forms.TabPage tabPageDetail;
        private System.Windows.Forms.Label lbDefinitionDetail;
        private System.Windows.Forms.TabPage tabPageLargeImg;
        private System.Windows.Forms.Label lbHTMLSizeDetail;
        private System.Windows.Forms.Label lbFontSizeDetail;
        private System.Windows.Forms.Label lbFontSizeLarge;
        private System.Windows.Forms.Label lbHTMLSizeLarge;
        private System.Windows.Forms.Label lbDefinitionLarge;
        private ComboFontSize cbFontSizeDetail;
        private ComboFontSize cbFontSizeLarge;
        private ComboImageDefinition cbDefinitionDetail;
        private ComboImageDefinition cbDefinitionLarge;
        private ComboImgSize cbHTMLSizeDetail;
        private ComboImgSize cbHTMLSizeLarge;
    }
}