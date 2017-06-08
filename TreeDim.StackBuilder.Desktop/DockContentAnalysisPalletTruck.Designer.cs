namespace treeDiM.StackBuilder.Desktop
{
    partial class DockContentAnalysisPalletTruck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentAnalysisPalletTruck));
            this.toolStripAnalysis = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReportMSWord = new System.Windows.Forms.ToolStripButton();
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.graphCtrlSolution = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.gridSolution = new SourceGrid.Grid();
            this.toolStripAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripAnalysis
            // 
            this.toolStripAnalysis.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonBack,
            this.toolStripButtonReportMSWord});
            this.toolStripAnalysis.Location = new System.Drawing.Point(0, 0);
            this.toolStripAnalysis.Name = "toolStripAnalysis";
            this.toolStripAnalysis.Size = new System.Drawing.Size(784, 25);
            this.toolStripAnalysis.TabIndex = 0;
            this.toolStripAnalysis.Text = "toolStrip1";
            // 
            // toolStripButtonBack
            // 
            this.toolStripButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBack.Image")));
            this.toolStripButtonBack.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonBack.Name = "toolStripButtonBack";
            this.toolStripButtonBack.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBack.Text = "Back...";
            this.toolStripButtonBack.Click += new System.EventHandler(this.onBack);
            // 
            // toolStripButtonReportMSWord
            // 
            this.toolStripButtonReportMSWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReportMSWord.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReportMSWord.Image")));
            this.toolStripButtonReportMSWord.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonReportMSWord.Name = "toolStripButtonReportMSWord";
            this.toolStripButtonReportMSWord.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonReportMSWord.Text = "Generate report...";
            this.toolStripButtonReportMSWord.Click += new System.EventHandler(this.onGenerateReport);
            // 
            // splitContainerHoriz
            // 
            this.splitContainerHoriz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerHoriz.Location = new System.Drawing.Point(0, 25);
            this.splitContainerHoriz.Name = "splitContainerHoriz";
            this.splitContainerHoriz.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerHoriz.Panel1
            // 
            this.splitContainerHoriz.Panel1.Controls.Add(this.splitContainerVert);
            this.splitContainerHoriz.Size = new System.Drawing.Size(784, 536);
            this.splitContainerHoriz.SplitterDistance = 464;
            this.splitContainerHoriz.TabIndex = 1;
            // 
            // splitContainerVert
            // 
            this.splitContainerVert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVert.Location = new System.Drawing.Point(0, 0);
            this.splitContainerVert.Name = "splitContainerVert";
            // 
            // splitContainerVert.Panel1
            // 
            this.splitContainerVert.Panel1.Controls.Add(this.graphCtrlSolution);
            // 
            // splitContainerVert.Panel2
            // 
            this.splitContainerVert.Panel2.Controls.Add(this.gridSolution);
            this.splitContainerVert.Size = new System.Drawing.Size(784, 464);
            this.splitContainerVert.SplitterDistance = 529;
            this.splitContainerVert.TabIndex = 0;
            // 
            // graphCtrlSolution
            // 
            this.graphCtrlSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphCtrlSolution.Location = new System.Drawing.Point(0, 0);
            this.graphCtrlSolution.Name = "graphCtrlSolution";
            this.graphCtrlSolution.Size = new System.Drawing.Size(529, 464);
            this.graphCtrlSolution.TabIndex = 0;
            this.graphCtrlSolution.Viewer = null;
            // 
            // gridSolution
            // 
            this.gridSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSolution.EnableSort = true;
            this.gridSolution.Location = new System.Drawing.Point(0, 0);
            this.gridSolution.Name = "gridSolution";
            this.gridSolution.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolution.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridSolution.Size = new System.Drawing.Size(251, 464);
            this.gridSolution.TabIndex = 0;
            this.gridSolution.TabStop = true;
            this.gridSolution.ToolTipText = "";
            // 
            // DockContentAnalysisPalletTruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainerHoriz);
            this.Controls.Add(this.toolStripAnalysis);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DockContentAnalysisPalletTruck";
            this.Text = "Pallet/Truck analysis...";
            this.toolStripAnalysis.ResumeLayout(false);
            this.toolStripAnalysis.PerformLayout();
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripAnalysis;
        private System.Windows.Forms.ToolStripButton toolStripButtonBack;
        private System.Windows.Forms.ToolStripButton toolStripButtonReportMSWord;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.SplitContainer splitContainerVert;
        private Graphics.Graphics3DControl graphCtrlSolution;
        private SourceGrid.Grid gridSolution;
    }
}