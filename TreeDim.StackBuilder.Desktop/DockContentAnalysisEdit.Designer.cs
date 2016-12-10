namespace treeDiM.StackBuilder.Desktop
{
    partial class DockContentAnalysisEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentAnalysisEdit));
            this.toolStripAnalysis = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReportWord = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReportHTML = new System.Windows.Forms.ToolStripButton();
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.graphCtrlSolution = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.gridSolutions = new SourceGrid.Grid();
            this.gbLayer = new System.Windows.Forms.GroupBox();
            this.chkbInterlayer = new System.Windows.Forms.CheckBox();
            this.cbInterlayer = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbLayerType = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboLayer();
            this.bnSymmetryX = new System.Windows.Forms.Button();
            this.bnSymetryY = new System.Windows.Forms.Button();
            this.tbClickLayer = new System.Windows.Forms.TextBox();
            this.toolStripAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).BeginInit();
            this.gbLayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripAnalysis
            // 
            this.toolStripAnalysis.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonBack,
            this.toolStripButtonReportWord,
            this.toolStripButtonReportHTML});
            this.toolStripAnalysis.Location = new System.Drawing.Point(0, 0);
            this.toolStripAnalysis.Name = "toolStripAnalysis";
            this.toolStripAnalysis.Size = new System.Drawing.Size(684, 25);
            this.toolStripAnalysis.TabIndex = 2;
            this.toolStripAnalysis.Text = "Generate MS Word report";
            // 
            // toolStripButtonBack
            // 
            this.toolStripButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBack.Image")));
            this.toolStripButtonBack.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonBack.Name = "toolStripButtonBack";
            this.toolStripButtonBack.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBack.Text = "toolStripButtonBack";
            this.toolStripButtonBack.ToolTipText = "Back...";
            this.toolStripButtonBack.Click += new System.EventHandler(this.onBack);
            // 
            // toolStripButtonReportWord
            // 
            this.toolStripButtonReportWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReportWord.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReportWord.Image")));
            this.toolStripButtonReportWord.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonReportWord.Name = "toolStripButtonReportWord";
            this.toolStripButtonReportWord.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonReportWord.Text = "Word report";
            this.toolStripButtonReportWord.Click += new System.EventHandler(this.onGenerateReportMSWord);
            // 
            // toolStripButtonReportHTML
            // 
            this.toolStripButtonReportHTML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReportHTML.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReportHTML.Image")));
            this.toolStripButtonReportHTML.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonReportHTML.Name = "toolStripButtonReportHTML";
            this.toolStripButtonReportHTML.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonReportHTML.Text = "HTML report";
            this.toolStripButtonReportHTML.Click += new System.EventHandler(this.onGenerateReportHTML);
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
            // 
            // splitContainerHoriz.Panel2
            // 
            this.splitContainerHoriz.Panel2.Controls.Add(this.gbLayer);
            this.splitContainerHoriz.Panel2.Controls.Add(this.tbClickLayer);
            this.splitContainerHoriz.Size = new System.Drawing.Size(684, 536);
            this.splitContainerHoriz.SplitterDistance = 411;
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
            this.splitContainerVert.Panel2.Controls.Add(this.gridSolutions);
            this.splitContainerVert.Size = new System.Drawing.Size(684, 411);
            this.splitContainerVert.SplitterDistance = 469;
            this.splitContainerVert.TabIndex = 0;
            // 
            // graphCtrlSolution
            // 
            this.graphCtrlSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphCtrlSolution.Location = new System.Drawing.Point(0, 0);
            this.graphCtrlSolution.Name = "graphCtrlSolution";
            this.graphCtrlSolution.Size = new System.Drawing.Size(469, 411);
            this.graphCtrlSolution.TabIndex = 0;
            this.graphCtrlSolution.Viewer = null;
            // 
            // gridSolutions
            // 
            this.gridSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSolutions.EnableSort = false;
            this.gridSolutions.Location = new System.Drawing.Point(0, 0);
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridSolutions.Size = new System.Drawing.Size(211, 411);
            this.gridSolutions.TabIndex = 0;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // gbLayer
            // 
            this.gbLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbLayer.Controls.Add(this.chkbInterlayer);
            this.gbLayer.Controls.Add(this.cbInterlayer);
            this.gbLayer.Controls.Add(this.cbLayerType);
            this.gbLayer.Controls.Add(this.bnSymmetryX);
            this.gbLayer.Controls.Add(this.bnSymetryY);
            this.gbLayer.Location = new System.Drawing.Point(3, 5);
            this.gbLayer.Name = "gbLayer";
            this.gbLayer.Size = new System.Drawing.Size(246, 113);
            this.gbLayer.TabIndex = 11;
            this.gbLayer.TabStop = false;
            this.gbLayer.Text = "Double-click a layer...";
            // 
            // chkbInterlayer
            // 
            this.chkbInterlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkbInterlayer.AutoSize = true;
            this.chkbInterlayer.Location = new System.Drawing.Point(8, 19);
            this.chkbInterlayer.Name = "chkbInterlayer";
            this.chkbInterlayer.Size = new System.Drawing.Size(69, 17);
            this.chkbInterlayer.TabIndex = 3;
            this.chkbInterlayer.Text = "Interlayer";
            this.chkbInterlayer.UseVisualStyleBackColor = true;
            this.chkbInterlayer.CheckedChanged += new System.EventHandler(this.onChkbInterlayerClicked);
            // 
            // cbInterlayer
            // 
            this.cbInterlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbInterlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterlayer.FormattingEnabled = true;
            this.cbInterlayer.Location = new System.Drawing.Point(119, 17);
            this.cbInterlayer.Name = "cbInterlayer";
            this.cbInterlayer.Size = new System.Drawing.Size(121, 21);
            this.cbInterlayer.TabIndex = 4;
            this.cbInterlayer.SelectedIndexChanged += new System.EventHandler(this.onInterlayerChanged);
            // 
            // cbLayerType
            // 
            this.cbLayerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbLayerType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLayerType.FormattingEnabled = true;
            this.cbLayerType.ItemHeight = 58;
            this.cbLayerType.Location = new System.Drawing.Point(8, 45);
            this.cbLayerType.Name = "cbLayerType";
            this.cbLayerType.Size = new System.Drawing.Size(96, 64);
            this.cbLayerType.TabIndex = 7;
            this.cbLayerType.SelectedIndexChanged += new System.EventHandler(this.onLayerTypeChanged);
            // 
            // bnSymmetryX
            // 
            this.bnSymmetryX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnSymmetryX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnSymmetryX.Image = ((System.Drawing.Image)(resources.GetObject("bnSymmetryX.Image")));
            this.bnSymmetryX.Location = new System.Drawing.Point(107, 45);
            this.bnSymmetryX.Name = "bnSymmetryX";
            this.bnSymmetryX.Size = new System.Drawing.Size(64, 64);
            this.bnSymmetryX.TabIndex = 5;
            this.bnSymmetryX.UseVisualStyleBackColor = true;
            this.bnSymmetryX.Click += new System.EventHandler(this.onReflectionX);
            // 
            // bnSymetryY
            // 
            this.bnSymetryY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnSymetryY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnSymetryY.Image = ((System.Drawing.Image)(resources.GetObject("bnSymetryY.Image")));
            this.bnSymetryY.Location = new System.Drawing.Point(175, 45);
            this.bnSymetryY.Name = "bnSymetryY";
            this.bnSymetryY.Size = new System.Drawing.Size(64, 64);
            this.bnSymetryY.TabIndex = 6;
            this.bnSymetryY.UseVisualStyleBackColor = true;
            this.bnSymetryY.Click += new System.EventHandler(this.onReflectionY);
            // 
            // tbClickLayer
            // 
            this.tbClickLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbClickLayer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbClickLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClickLayer.Location = new System.Drawing.Point(2, 41);
            this.tbClickLayer.Multiline = true;
            this.tbClickLayer.Name = "tbClickLayer";
            this.tbClickLayer.Size = new System.Drawing.Size(246, 57);
            this.tbClickLayer.TabIndex = 14;
            this.tbClickLayer.Text = "Double-click a layer to edit pattern / orientation / interlayer.";
            this.tbClickLayer.Visible = false;
            // 
            // DockContentAnalysisEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.splitContainerHoriz);
            this.Controls.Add(this.toolStripAnalysis);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DockContentAnalysisEdit";
            this.Text = "Analysis...";
            this.toolStripAnalysis.ResumeLayout(false);
            this.toolStripAnalysis.PerformLayout();
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).EndInit();
            this.gbLayer.ResumeLayout(false);
            this.gbLayer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Graphics.Graphics3DControl graphCtrlSolution;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.SplitContainer splitContainerVert;
        private System.Windows.Forms.ToolStrip toolStripAnalysis;
        private System.Windows.Forms.ToolStripButton toolStripButtonReportWord;
        private System.Windows.Forms.GroupBox gbLayer;
        private System.Windows.Forms.CheckBox chkbInterlayer;
        protected Graphics.Controls.CCtrlComboFiltered cbInterlayer;
        private Graphics.Controls.CCtrlComboLayer cbLayerType;
        private System.Windows.Forms.Button bnSymmetryX;
        private System.Windows.Forms.Button bnSymetryY;
        private System.Windows.Forms.TextBox tbClickLayer;
        protected SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.ToolStripButton toolStripButtonBack;
        private System.Windows.Forms.ToolStripButton toolStripButtonReportHTML;
    }
}