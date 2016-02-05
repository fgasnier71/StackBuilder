namespace treeDiM.StackBuilder.Desktop
{
    partial class FormEditPalletSolutionDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditPalletSolutionDB));
            this.btClose = new System.Windows.Forms.Button();
            this.lbPalletDimensions = new System.Windows.Forms.Label();
            this.cbPalletDimensions = new System.Windows.Forms.ComboBox();
            this.gridSolutions = new SourceGrid.Grid();
            this.pictureBoxCase = new System.Windows.Forms.PictureBox();
            this.pictureBoxSolution = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            resources.ApplyResources(this.btClose, "btClose");
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Name = "btClose";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // lbPalletDimensions
            // 
            resources.ApplyResources(this.lbPalletDimensions, "lbPalletDimensions");
            this.lbPalletDimensions.Name = "lbPalletDimensions";
            // 
            // cbPalletDimensions
            // 
            resources.ApplyResources(this.cbPalletDimensions, "cbPalletDimensions");
            this.cbPalletDimensions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalletDimensions.FormattingEnabled = true;
            this.cbPalletDimensions.Name = "cbPalletDimensions";
            this.cbPalletDimensions.SelectedIndexChanged += new System.EventHandler(this.cbPalletDimensions_SelectedIndexChanged);
            // 
            // gridSolutions
            // 
            this.gridSolutions.AcceptsInputChar = false;
            resources.ApplyResources(this.gridSolutions, "gridSolutions");
            this.gridSolutions.EnableSort = false;
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridSolutions.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // pictureBoxCase
            // 
            resources.ApplyResources(this.pictureBoxCase, "pictureBoxCase");
            this.pictureBoxCase.Name = "pictureBoxCase";
            this.pictureBoxCase.TabStop = false;
            this.pictureBoxCase.SizeChanged += new System.EventHandler(this.pictureBoxSolution_SizeChanged);
            // 
            // pictureBoxSolution
            // 
            resources.ApplyResources(this.pictureBoxSolution, "pictureBoxSolution");
            this.pictureBoxSolution.Name = "pictureBoxSolution";
            this.pictureBoxSolution.TabStop = false;
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.gridSolutions);
            this.splitContainer1.Panel1.Controls.Add(this.btClose);
            this.splitContainer1.Panel1.Controls.Add(this.cbPalletDimensions);
            this.splitContainer1.Panel1.Controls.Add(this.lbPalletDimensions);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            this.splitContainer2.Panel1.Controls.Add(this.pictureBoxCase);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.Controls.Add(this.pictureBoxSolution);
            // 
            // FormEditPalletSolutionDB
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditPalletSolutionDB";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormEditPalletSolutionDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label lbPalletDimensions;
        private System.Windows.Forms.ComboBox cbPalletDimensions;
        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.PictureBox pictureBoxCase;
        private System.Windows.Forms.PictureBox pictureBoxSolution;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}