namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewHAnalysis
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.bnNext = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.splitContainerHoriz1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerHoriz2 = new System.Windows.Forms.SplitContainer();
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.bnAddRow = new System.Windows.Forms.Button();
            this.gridContent = new SourceGrid.Grid();
            this.splitContainerSolutions = new System.Windows.Forms.SplitContainer();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.gridSolutions = new SourceGrid.Grid();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz1)).BeginInit();
            this.splitContainerHoriz1.Panel1.SuspendLayout();
            this.splitContainerHoriz1.Panel2.SuspendLayout();
            this.splitContainerHoriz1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz2)).BeginInit();
            this.splitContainerHoriz2.Panel1.SuspendLayout();
            this.splitContainerHoriz2.Panel2.SuspendLayout();
            this.splitContainerHoriz2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSolutions)).BeginInit();
            this.splitContainerSolutions.Panel1.SuspendLayout();
            this.splitContainerSolutions.Panel2.SuspendLayout();
            this.splitContainerSolutions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // bnNext
            // 
            this.bnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnNext.Location = new System.Drawing.Point(707, 1);
            this.bnNext.Name = "bnNext";
            this.bnNext.Size = new System.Drawing.Size(74, 24);
            this.bnNext.TabIndex = 17;
            this.bnNext.Text = "Next >";
            this.bnNext.UseVisualStyleBackColor = true;
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(102, 31);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(680, 20);
            this.tbDescription.TabIndex = 16;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(102, 3);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(145, 20);
            this.tbName.TabIndex = 14;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDescription.Location = new System.Drawing.Point(3, 31);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(60, 13);
            this.lbDescription.TabIndex = 15;
            this.lbDescription.Text = "Description";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbName.Location = new System.Drawing.Point(4, 6);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 13;
            this.lbName.Text = "Name";
            // 
            // splitContainerHoriz1
            // 
            this.splitContainerHoriz1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerHoriz1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerHoriz1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerHoriz1.Name = "splitContainerHoriz1";
            this.splitContainerHoriz1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerHoriz1.Panel1
            // 
            this.splitContainerHoriz1.Panel1.Controls.Add(this.tbName);
            this.splitContainerHoriz1.Panel1.Controls.Add(this.lbName);
            this.splitContainerHoriz1.Panel1.Controls.Add(this.tbDescription);
            this.splitContainerHoriz1.Panel1.Controls.Add(this.lbDescription);
            // 
            // splitContainerHoriz1.Panel2
            // 
            this.splitContainerHoriz1.Panel2.Controls.Add(this.splitContainerHoriz2);
            this.splitContainerHoriz1.Size = new System.Drawing.Size(784, 539);
            this.splitContainerHoriz1.SplitterDistance = 54;
            this.splitContainerHoriz1.TabIndex = 18;
            // 
            // splitContainerHoriz2
            // 
            this.splitContainerHoriz2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerHoriz2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerHoriz2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerHoriz2.Name = "splitContainerHoriz2";
            this.splitContainerHoriz2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerHoriz2.Panel1
            // 
            this.splitContainerHoriz2.Panel1.Controls.Add(this.splitContainerVert);
            // 
            // splitContainerHoriz2.Panel2
            // 
            this.splitContainerHoriz2.Panel2.Controls.Add(this.bnNext);
            this.splitContainerHoriz2.Size = new System.Drawing.Size(784, 481);
            this.splitContainerHoriz2.SplitterDistance = 449;
            this.splitContainerHoriz2.TabIndex = 18;
            // 
            // splitContainerVert
            // 
            this.splitContainerVert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVert.Location = new System.Drawing.Point(0, 0);
            this.splitContainerVert.Name = "splitContainerVert";
            // 
            // splitContainerVert.Panel1
            // 
            this.splitContainerVert.Panel1.Controls.Add(this.bnAddRow);
            this.splitContainerVert.Panel1.Controls.Add(this.gridContent);
            // 
            // splitContainerVert.Panel2
            // 
            this.splitContainerVert.Panel2.Controls.Add(this.splitContainerSolutions);
            this.splitContainerVert.Size = new System.Drawing.Size(784, 449);
            this.splitContainerVert.SplitterDistance = 261;
            this.splitContainerVert.TabIndex = 0;
            // 
            // bnAddRow
            // 
            this.bnAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnAddRow.Location = new System.Drawing.Point(171, 420);
            this.bnAddRow.Name = "bnAddRow";
            this.bnAddRow.Size = new System.Drawing.Size(75, 23);
            this.bnAddRow.TabIndex = 1;
            this.bnAddRow.Text = "Add";
            this.bnAddRow.UseVisualStyleBackColor = true;
            this.bnAddRow.Click += new System.EventHandler(this.OnAddRow);
            // 
            // gridContent
            // 
            this.gridContent.EnableSort = true;
            this.gridContent.Location = new System.Drawing.Point(0, 171);
            this.gridContent.Name = "gridContent";
            this.gridContent.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridContent.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridContent.Size = new System.Drawing.Size(259, 243);
            this.gridContent.TabIndex = 0;
            this.gridContent.TabStop = true;
            this.gridContent.ToolTipText = "";
            // 
            // splitContainerSolutions
            // 
            this.splitContainerSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSolutions.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerSolutions.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSolutions.Name = "splitContainerSolutions";
            this.splitContainerSolutions.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSolutions.Panel1
            // 
            this.splitContainerSolutions.Panel1.Controls.Add(this.graphCtrl);
            // 
            // splitContainerSolutions.Panel2
            // 
            this.splitContainerSolutions.Panel2.Controls.Add(this.gridSolutions);
            this.splitContainerSolutions.Size = new System.Drawing.Size(519, 449);
            this.splitContainerSolutions.SplitterDistance = 368;
            this.splitContainerSolutions.TabIndex = 0;
            // 
            // graphCtrl
            // 
            this.graphCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphCtrl.Location = new System.Drawing.Point(0, 0);
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.Size = new System.Drawing.Size(519, 368);
            this.graphCtrl.TabIndex = 0;
            this.graphCtrl.Viewer = null;
            // 
            // gridSolutions
            // 
            this.gridSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSolutions.EnableSort = true;
            this.gridSolutions.Location = new System.Drawing.Point(0, 0);
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridSolutions.Size = new System.Drawing.Size(519, 77);
            this.gridSolutions.TabIndex = 0;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // FormNewHAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainerHoriz1);
            this.Controls.Add(this.statusStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewHAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "New heterogeneous analysis... ";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainerHoriz1.Panel1.ResumeLayout(false);
            this.splitContainerHoriz1.Panel1.PerformLayout();
            this.splitContainerHoriz1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz1)).EndInit();
            this.splitContainerHoriz1.ResumeLayout(false);
            this.splitContainerHoriz2.Panel1.ResumeLayout(false);
            this.splitContainerHoriz2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz2)).EndInit();
            this.splitContainerHoriz2.ResumeLayout(false);
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            this.splitContainerSolutions.Panel1.ResumeLayout(false);
            this.splitContainerSolutions.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSolutions)).EndInit();
            this.splitContainerSolutions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button bnNext;
        protected System.Windows.Forms.TextBox tbDescription;
        protected System.Windows.Forms.TextBox tbName;
        protected System.Windows.Forms.Label lbDescription;
        protected System.Windows.Forms.Label lbName;
        private System.Windows.Forms.SplitContainer splitContainerHoriz1;
        private System.Windows.Forms.SplitContainer splitContainerHoriz2;
        private System.Windows.Forms.SplitContainer splitContainerVert;
        private SourceGrid.Grid gridContent;
        private System.Windows.Forms.SplitContainer splitContainerSolutions;
        private Graphics.Graphics3DControl graphCtrl;
        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.Button bnAddRow;
    }
}