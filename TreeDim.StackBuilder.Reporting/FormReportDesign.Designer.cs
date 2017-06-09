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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._treeView = new System.Windows.Forms.TreeView();
            this._webBrowser = new System.Windows.Forms.WebBrowser();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSBDimensions = new System.Windows.Forms.ToolStripButton();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.toolSBDimensions});
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._treeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._webBrowser);
            this.splitContainer1.Size = new System.Drawing.Size(884, 614);
            this.splitContainer1.SplitterDistance = 165;
            this.splitContainer1.TabIndex = 2;
            // 
            // _treeView
            // 
            this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeView.Location = new System.Drawing.Point(0, 0);
            this._treeView.Name = "_treeView";
            this._treeView.Size = new System.Drawing.Size(165, 614);
            this._treeView.TabIndex = 0;
            this._treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.onNodeChecked);
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
        private System.Windows.Forms.TreeView _treeView;
        private System.Windows.Forms.WebBrowser _webBrowser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolSBDimensions;
    }
}