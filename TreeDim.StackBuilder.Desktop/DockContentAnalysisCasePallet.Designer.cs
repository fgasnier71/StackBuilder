namespace treeDiM.StackBuilder.Desktop
{
    partial class DockContentAnalysisCasePallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentAnalysisCasePallet));
            this.graphCtrlSolution = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.toolStripAnalysis = new System.Windows.Forms.ToolStrip();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).BeginInit();
            this.SuspendLayout();
            // 
            // graphCtrlSolution
            // 
            this.graphCtrlSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphCtrlSolution.Location = new System.Drawing.Point(0, 28);
            this.graphCtrlSolution.Name = "graphCtrlSolution";
            this.graphCtrlSolution.Size = new System.Drawing.Size(683, 387);
            this.graphCtrlSolution.TabIndex = 0;
            this.graphCtrlSolution.Viewer = null;
            // 
            // toolStripAnalysis
            // 
            this.toolStripAnalysis.Location = new System.Drawing.Point(0, 0);
            this.toolStripAnalysis.Name = "toolStripAnalysis";
            this.toolStripAnalysis.Size = new System.Drawing.Size(684, 25);
            this.toolStripAnalysis.TabIndex = 1;
            this.toolStripAnalysis.Text = "toolStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Double-click a layer...";
            // 
            // DockContentAnalysisCasePallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStripAnalysis);
            this.Controls.Add(this.graphCtrlSolution);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DockContentAnalysisCasePallet";
            this.Text = "Case/Pallet analysis...";
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Graphics.Graphics3DControl graphCtrlSolution;
        private System.Windows.Forms.ToolStrip toolStripAnalysis;
        private System.Windows.Forms.Label label1;

    }
}