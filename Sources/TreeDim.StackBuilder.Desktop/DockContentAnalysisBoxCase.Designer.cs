namespace treeDiM.StackBuilder.Desktop
{
    partial class DockContentAnalysisBoxCase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentAnalysisBoxCase));
            this.gbStopCriterions = new System.Windows.Forms.GroupBox();
            this.uCtrlOptMaxNumber = new treeDiM.Basics.UCtrlOptInt();
            this.uCtrlOptMaximumWeight = new treeDiM.Basics.UCtrlOptDouble();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            this.gbStopCriterions.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphCtrlSolution
            // 
            resources.ApplyResources(this.graphCtrlSolution, "graphCtrlSolution");
            // 
            // splitContainerHoriz
            // 
            // 
            // splitContainerHoriz.Panel2
            // 
            this.splitContainerHoriz.Panel2.Controls.Add(this.gbStopCriterions);
            resources.ApplyResources(this.splitContainerHoriz, "splitContainerHoriz");
            // 
            // splitContainerVert
            // 
            resources.ApplyResources(this.splitContainerVert, "splitContainerVert");
            // 
            // gridSolution
            // 
            resources.ApplyResources(this.gridSolution, "gridSolution");
            // 
            // gbStopCriterions
            // 
            resources.ApplyResources(this.gbStopCriterions, "gbStopCriterions");
            this.gbStopCriterions.Controls.Add(this.uCtrlOptMaxNumber);
            this.gbStopCriterions.Controls.Add(this.uCtrlOptMaximumWeight);
            this.gbStopCriterions.Name = "gbStopCriterions";
            this.gbStopCriterions.TabStop = false;
            // 
            // uCtrlOptMaxNumber
            // 
            resources.ApplyResources(this.uCtrlOptMaxNumber, "uCtrlOptMaxNumber");
            this.uCtrlOptMaxNumber.Minimum = 0;
            this.uCtrlOptMaxNumber.Name = "uCtrlOptMaxNumber";
            // 
            // uCtrlOptMaximumWeight
            // 
            resources.ApplyResources(this.uCtrlOptMaximumWeight, "uCtrlOptMaximumWeight");
            this.uCtrlOptMaximumWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlOptMaximumWeight.Name = "uCtrlOptMaximumWeight";
            this.uCtrlOptMaximumWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            // 
            // DockContentAnalysisBoxCase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DockContentAnalysisBoxCase";
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlSolution)).EndInit();
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            this.gbStopCriterions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStopCriterions;
        private treeDiM.Basics.UCtrlOptInt uCtrlOptMaxNumber;
        private treeDiM.Basics.UCtrlOptDouble uCtrlOptMaximumWeight;
    }
}