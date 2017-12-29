namespace treeDiM.StackBuilder.Graphics
{
    partial class UCtrlLayerList
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
            this.components = new System.ComponentModel.Container();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripMBR = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3D = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemX75 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemX100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemX150 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemX200 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripMBR.SuspendLayout();
            this.SuspendLayout();
            // 
            // _timer
            // 
            this._timer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // contextMenuStripMBR
            // 
            this.contextMenuStripMBR.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3D,
            this.toolStripSeparator1,
            this.toolStripMenuItemX75,
            this.toolStripMenuItemX100,
            this.toolStripMenuItemX150,
            this.toolStripMenuItemX200});
            this.contextMenuStripMBR.Name = "contextMenuStripMBR";
            this.contextMenuStripMBR.Size = new System.Drawing.Size(153, 142);
            // 
            // toolStripMenuItem3D
            // 
            this.toolStripMenuItem3D.Name = "toolStripMenuItem3D";
            this.toolStripMenuItem3D.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3D.Text = "3D";
            this.toolStripMenuItem3D.Click += new System.EventHandler(this.On3DClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItemX75
            // 
            this.toolStripMenuItemX75.Name = "toolStripMenuItemX75";
            this.toolStripMenuItemX75.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemX75.Text = "75 x 75";
            this.toolStripMenuItemX75.Click += new System.EventHandler(this.OnButtonSizeChange);
            // 
            // toolStripMenuItemX100
            // 
            this.toolStripMenuItemX100.Name = "toolStripMenuItemX100";
            this.toolStripMenuItemX100.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemX100.Text = "100 x 100";
            this.toolStripMenuItemX100.Click += new System.EventHandler(this.OnButtonSizeChange);
            // 
            // toolStripMenuItemX150
            // 
            this.toolStripMenuItemX150.Name = "toolStripMenuItemX150";
            this.toolStripMenuItemX150.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemX150.Text = "150 x 150";
            this.toolStripMenuItemX150.Click += new System.EventHandler(this.OnButtonSizeChange);
            // 
            // toolStripMenuItemX200
            // 
            this.toolStripMenuItemX200.Name = "toolStripMenuItemX200";
            this.toolStripMenuItemX200.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemX200.Text = "200 x 200";
            this.toolStripMenuItemX200.Click += new System.EventHandler(this.OnButtonSizeChange);
            // 
            // UCtrlLayerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UCtrlLayerList";
            this.Size = new System.Drawing.Size(300, 300);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.contextMenuStripMBR.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMBR;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3D;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemX100;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemX150;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemX200;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemX75;
    }
}
