namespace treeDiM.EdgeCrushTest
{
    partial class FormPalletsDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPalletsDatabase));
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.bnExit = new System.Windows.Forms.Button();
            this.lbCount = new System.Windows.Forms.Label();
            this.bnNext = new System.Windows.Forms.Button();
            this.gridPallets = new SourceGrid.Grid();
            this.bnPrev = new System.Windows.Forms.Button();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainerHoriz.Panel1.Controls.Add(this.graphCtrl);
            this.splitContainerHoriz.Panel1.Controls.Add(this.bnExit);
            // 
            // splitContainerHoriz.Panel2
            // 
            this.splitContainerHoriz.Panel2.Controls.Add(this.lbCount);
            this.splitContainerHoriz.Panel2.Controls.Add(this.bnNext);
            this.splitContainerHoriz.Panel2.Controls.Add(this.gridPallets);
            this.splitContainerHoriz.Panel2.Controls.Add(this.bnPrev);
            this.splitContainerHoriz.Size = new System.Drawing.Size(800, 425);
            this.splitContainerHoriz.SplitterDistance = 220;
            this.splitContainerHoriz.TabIndex = 0;
            // 
            // graphCtrl
            // 
            this.graphCtrl.Location = new System.Drawing.Point(3, 28);
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.Size = new System.Drawing.Size(704, 202);
            this.graphCtrl.TabIndex = 2;
            this.graphCtrl.Viewer = null;
            // 
            // bnExit
            // 
            this.bnExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnExit.Location = new System.Drawing.Point(722, 3);
            this.bnExit.Name = "bnExit";
            this.bnExit.Size = new System.Drawing.Size(75, 23);
            this.bnExit.TabIndex = 0;
            this.bnExit.Text = "Exit";
            this.bnExit.UseVisualStyleBackColor = true;
            // 
            // lbCount
            // 
            this.lbCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCount.AutoSize = true;
            this.lbCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCount.Location = new System.Drawing.Point(640, 179);
            this.lbCount.Name = "lbCount";
            this.lbCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCount.Size = new System.Drawing.Size(67, 13);
            this.lbCount.TabIndex = 6;
            this.lbCount.Text = "1-20 out of 0";
            this.lbCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bnNext
            // 
            this.bnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnNext.Location = new System.Drawing.Point(761, 174);
            this.bnNext.Name = "bnNext";
            this.bnNext.Size = new System.Drawing.Size(31, 23);
            this.bnNext.TabIndex = 5;
            this.bnNext.Text = ">";
            this.bnNext.UseVisualStyleBackColor = true;
            // 
            // gridPallets
            // 
            this.gridPallets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPallets.EnableSort = true;
            this.gridPallets.Location = new System.Drawing.Point(3, 3);
            this.gridPallets.Name = "gridPallets";
            this.gridPallets.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridPallets.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridPallets.Size = new System.Drawing.Size(797, 167);
            this.gridPallets.TabIndex = 0;
            this.gridPallets.TabStop = true;
            this.gridPallets.ToolTipText = "";
            // 
            // bnPrev
            // 
            this.bnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnPrev.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnPrev.Location = new System.Drawing.Point(728, 174);
            this.bnPrev.Name = "bnPrev";
            this.bnPrev.Size = new System.Drawing.Size(31, 23);
            this.bnPrev.TabIndex = 4;
            this.bnPrev.Text = "<";
            this.bnPrev.UseVisualStyleBackColor = true;
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(800, 25);
            this.toolStripMain.TabIndex = 0;
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNew.Image")));
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNew.Text = "toolStripButtonAddNew";
            this.toolStripButtonNew.Click += new System.EventHandler(this.OnAddNewPallet);
            // 
            // FormPalletsDatabase
            // 
            this.AcceptButton = this.bnExit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainerHoriz);
            this.Controls.Add(this.toolStripMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPalletsDatabase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Pallets database...";
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.Button bnExit;
        private StackBuilder.Graphics.Graphics3DControl graphCtrl;
        private SourceGrid.Grid gridPallets;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Button bnNext;
        private System.Windows.Forms.Button bnPrev;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
    }
}