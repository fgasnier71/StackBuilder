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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolSBReportWord = new System.Windows.Forms.ToolStripButton();
            this.toolSBReportPDF = new System.Windows.Forms.ToolStripButton();
            this.toolSBReportHTML = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSBReportPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSBDimensions = new System.Windows.Forms.ToolStripButton();
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
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._webBrowser);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this._treeView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabCtrlImageParam);
            // 
            // _treeView
            // 
            resources.ApplyResources(this._treeView, "_treeView");
            this._treeView.Name = "_treeView";
            this._treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.OnNodeChecked);
            // 
            // tabCtrlImageParam
            // 
            this.tabCtrlImageParam.Controls.Add(this.tabPageDetail);
            this.tabCtrlImageParam.Controls.Add(this.tabPageLargeImg);
            resources.ApplyResources(this.tabCtrlImageParam, "tabCtrlImageParam");
            this.tabCtrlImageParam.Name = "tabCtrlImageParam";
            this.tabCtrlImageParam.SelectedIndex = 0;
            // 
            // tabPageDetail
            // 
            this.tabPageDetail.Controls.Add(this.cbFontSizeDetail);
            this.tabPageDetail.Controls.Add(this.lbFontSizeDetail);
            this.tabPageDetail.Controls.Add(this.cbHTMLSizeDetail);
            this.tabPageDetail.Controls.Add(this.lbHTMLSizeDetail);
            this.tabPageDetail.Controls.Add(this.cbDefinitionDetail);
            this.tabPageDetail.Controls.Add(this.lbDefinitionDetail);
            resources.ApplyResources(this.tabPageDetail, "tabPageDetail");
            this.tabPageDetail.Name = "tabPageDetail";
            this.tabPageDetail.UseVisualStyleBackColor = true;
            // 
            // cbFontSizeDetail
            // 
            this.cbFontSizeDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontSizeDetail.FontSizeRatio = 0.01F;
            this.cbFontSizeDetail.FormattingEnabled = true;
            resources.ApplyResources(this.cbFontSizeDetail, "cbFontSizeDetail");
            this.cbFontSizeDetail.Name = "cbFontSizeDetail";
            // 
            // lbFontSizeDetail
            // 
            resources.ApplyResources(this.lbFontSizeDetail, "lbFontSizeDetail");
            this.lbFontSizeDetail.Name = "lbFontSizeDetail";
            // 
            // cbHTMLSizeDetail
            // 
            this.cbHTMLSizeDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHTMLSizeDetail.FormattingEnabled = true;
            resources.ApplyResources(this.cbHTMLSizeDetail, "cbHTMLSizeDetail");
            this.cbHTMLSizeDetail.Name = "cbHTMLSizeDetail";
            // 
            // lbHTMLSizeDetail
            // 
            resources.ApplyResources(this.lbHTMLSizeDetail, "lbHTMLSizeDetail");
            this.lbHTMLSizeDetail.Name = "lbHTMLSizeDetail";
            // 
            // cbDefinitionDetail
            // 
            this.cbDefinitionDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefinitionDetail.FormattingEnabled = true;
            resources.ApplyResources(this.cbDefinitionDetail, "cbDefinitionDetail");
            this.cbDefinitionDetail.Name = "cbDefinitionDetail";
            // 
            // lbDefinitionDetail
            // 
            resources.ApplyResources(this.lbDefinitionDetail, "lbDefinitionDetail");
            this.lbDefinitionDetail.Name = "lbDefinitionDetail";
            // 
            // tabPageLargeImg
            // 
            this.tabPageLargeImg.Controls.Add(this.cbFontSizeLarge);
            this.tabPageLargeImg.Controls.Add(this.cbHTMLSizeLarge);
            this.tabPageLargeImg.Controls.Add(this.cbDefinitionLarge);
            this.tabPageLargeImg.Controls.Add(this.lbFontSizeLarge);
            this.tabPageLargeImg.Controls.Add(this.lbHTMLSizeLarge);
            this.tabPageLargeImg.Controls.Add(this.lbDefinitionLarge);
            resources.ApplyResources(this.tabPageLargeImg, "tabPageLargeImg");
            this.tabPageLargeImg.Name = "tabPageLargeImg";
            this.tabPageLargeImg.UseVisualStyleBackColor = true;
            // 
            // cbFontSizeLarge
            // 
            this.cbFontSizeLarge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontSizeLarge.FontSizeRatio = 0.01F;
            this.cbFontSizeLarge.FormattingEnabled = true;
            resources.ApplyResources(this.cbFontSizeLarge, "cbFontSizeLarge");
            this.cbFontSizeLarge.Name = "cbFontSizeLarge";
            // 
            // cbHTMLSizeLarge
            // 
            this.cbHTMLSizeLarge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHTMLSizeLarge.FormattingEnabled = true;
            resources.ApplyResources(this.cbHTMLSizeLarge, "cbHTMLSizeLarge");
            this.cbHTMLSizeLarge.Name = "cbHTMLSizeLarge";
            // 
            // cbDefinitionLarge
            // 
            this.cbDefinitionLarge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefinitionLarge.FormattingEnabled = true;
            resources.ApplyResources(this.cbDefinitionLarge, "cbDefinitionLarge");
            this.cbDefinitionLarge.Name = "cbDefinitionLarge";
            // 
            // lbFontSizeLarge
            // 
            resources.ApplyResources(this.lbFontSizeLarge, "lbFontSizeLarge");
            this.lbFontSizeLarge.Name = "lbFontSizeLarge";
            // 
            // lbHTMLSizeLarge
            // 
            resources.ApplyResources(this.lbHTMLSizeLarge, "lbHTMLSizeLarge");
            this.lbHTMLSizeLarge.Name = "lbHTMLSizeLarge";
            // 
            // lbDefinitionLarge
            // 
            resources.ApplyResources(this.lbDefinitionLarge, "lbDefinitionLarge");
            this.lbDefinitionLarge.Name = "lbDefinitionLarge";
            // 
            // _webBrowser
            // 
            resources.ApplyResources(this._webBrowser, "_webBrowser");
            this._webBrowser.Name = "_webBrowser";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelDef});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // statusLabelDef
            // 
            this.statusLabelDef.Name = "statusLabelDef";
            resources.ApplyResources(this.statusLabelDef, "statusLabelDef");
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSBReportWord,
            this.toolSBReportPDF,
            this.toolSBReportHTML,
            this.toolStripSeparator2,
            this.toolSBReportPrint,
            this.toolStripSeparator1,
            this.toolSBDimensions});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // toolSBReportWord
            // 
            this.toolSBReportWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolSBReportWord, "toolSBReportWord");
            this.toolSBReportWord.Name = "toolSBReportWord";
            this.toolSBReportWord.Click += new System.EventHandler(this.OnReportMSWord);
            // 
            // toolSBReportPDF
            // 
            this.toolSBReportPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolSBReportPDF, "toolSBReportPDF");
            this.toolSBReportPDF.Name = "toolSBReportPDF";
            this.toolSBReportPDF.Click += new System.EventHandler(this.OnReportPDF);
            // 
            // toolSBReportHTML
            // 
            this.toolSBReportHTML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolSBReportHTML, "toolSBReportHTML");
            this.toolSBReportHTML.Name = "toolSBReportHTML";
            this.toolSBReportHTML.Click += new System.EventHandler(this.OnReportHTML);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolSBReportPrint
            // 
            this.toolSBReportPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolSBReportPrint, "toolSBReportPrint");
            this.toolSBReportPrint.Name = "toolSBReportPrint";
            this.toolSBReportPrint.Click += new System.EventHandler(this.OnReportPrint);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolSBDimensions
            // 
            this.toolSBDimensions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolSBDimensions, "toolSBDimensions");
            this.toolSBDimensions.Name = "toolSBDimensions";
            this.toolSBDimensions.Click += new System.EventHandler(this.OnShowDimensions);
            // 
            // FormReportDesign
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportDesign";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
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
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolSBReportPrint;
        private System.Windows.Forms.ToolStripButton toolSBReportPDF;
    }
}