
namespace treeDiM.StackBuilder.Graphics
{
    partial class Graphics2DRobotDropEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graphics2DRobotDropEditor));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripBnCaseDrop2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripBnCaseDrop3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripBnSplitDrop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBnReorder = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBnCaseDrop2,
            this.toolStripBnCaseDrop3,
            this.toolStripBnSplitDrop,
            this.toolStripSeparator1,
            this.toolStripBnReorder});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(300, 25);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "Tools";
            // 
            // toolStripBnCaseDrop2
            // 
            this.toolStripBnCaseDrop2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBnCaseDrop2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBnCaseDrop2.Image")));
            this.toolStripBnCaseDrop2.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripBnCaseDrop2.Name = "toolStripBnCaseDrop2";
            this.toolStripBnCaseDrop2.Size = new System.Drawing.Size(23, 22);
            this.toolStripBnCaseDrop2.Text = "Build a 2 case drop";
            this.toolStripBnCaseDrop2.Click += new System.EventHandler(this.OnBuildCaseDropOf2);
            // 
            // toolStripBnCaseDrop3
            // 
            this.toolStripBnCaseDrop3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBnCaseDrop3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBnCaseDrop3.Image")));
            this.toolStripBnCaseDrop3.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripBnCaseDrop3.Name = "toolStripBnCaseDrop3";
            this.toolStripBnCaseDrop3.Size = new System.Drawing.Size(23, 22);
            this.toolStripBnCaseDrop3.Text = "Build a 3 cases drop";
            this.toolStripBnCaseDrop3.Click += new System.EventHandler(this.OnBuildCaseDropOf3);
            // 
            // toolStripBnSplitDrop
            // 
            this.toolStripBnSplitDrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBnSplitDrop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBnSplitDrop.Image")));
            this.toolStripBnSplitDrop.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripBnSplitDrop.Name = "toolStripBnSplitDrop";
            this.toolStripBnSplitDrop.Size = new System.Drawing.Size(23, 22);
            this.toolStripBnSplitDrop.Text = "Split drop";
            this.toolStripBnSplitDrop.Click += new System.EventHandler(this.OnSplitDrop);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBnReorder
            // 
            this.toolStripBnReorder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBnReorder.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBnReorder.Image")));
            this.toolStripBnReorder.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripBnReorder.Name = "toolStripBnReorder";
            this.toolStripBnReorder.Size = new System.Drawing.Size(23, 22);
            this.toolStripBnReorder.Text = "Reorder";
            this.toolStripBnReorder.Click += new System.EventHandler(this.OnReorder);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 278);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(300, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // Graphics2DRobotDropEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStripMain);
            this.Name = "Graphics2DRobotDropEditor";
            this.Size = new System.Drawing.Size(300, 300);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripBnCaseDrop2;
        private System.Windows.Forms.ToolStripButton toolStripBnCaseDrop3;
        private System.Windows.Forms.ToolStripButton toolStripBnSplitDrop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripBnReorder;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}
