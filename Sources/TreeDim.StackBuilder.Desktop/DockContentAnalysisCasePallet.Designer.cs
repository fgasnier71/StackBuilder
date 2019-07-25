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
            this.gbStopCriterions = new System.Windows.Forms.GroupBox();
            this.uCtrlOptMaxNumber = new treeDiM.Basics.UCtrlOptInt();
            this.uCtrlOptMaximumWeight = new treeDiM.Basics.UCtrlOptDouble();
            this.uCtrlMaxPalletHeight = new treeDiM.Basics.UCtrlDouble();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPagePalletCorners = new System.Windows.Forms.TabPage();
            this.cbPalletCorners = new System.Windows.Forms.ComboBox();
            this.chkbPalletCorners = new System.Windows.Forms.CheckBox();
            this.tabPagePalletCap = new System.Windows.Forms.TabPage();
            this.cbPalletCap = new System.Windows.Forms.ComboBox();
            this.chkbPalletCap = new System.Windows.Forms.CheckBox();
            this.tabPagePalletFilm = new System.Windows.Forms.TabPage();
            this.cbPalletFilm = new System.Windows.Forms.ComboBox();
            this.chkbPalletFilm = new System.Windows.Forms.CheckBox();
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
            this.tabCtrl.SuspendLayout();
            this.tabPagePalletCorners.SuspendLayout();
            this.tabPagePalletCap.SuspendLayout();
            this.tabPagePalletFilm.SuspendLayout();
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
            this.splitContainerHoriz.Panel2.Controls.Add(this.tabCtrl);
            // 
            // splitContainerVert
            // 
            resources.ApplyResources(this.splitContainerVert, "splitContainerVert");
            // 
            // gridSolutions
            // 
            resources.ApplyResources(this.gridSolutions, "gridSolutions");
            // 
            // gbStopCriterions
            // 
            resources.ApplyResources(this.gbStopCriterions, "gbStopCriterions");
            this.gbStopCriterions.Controls.Add(this.uCtrlOptMaxNumber);
            this.gbStopCriterions.Controls.Add(this.uCtrlOptMaximumWeight);
            this.gbStopCriterions.Controls.Add(this.uCtrlMaxPalletHeight);
            this.gbStopCriterions.Name = "gbStopCriterions";
            this.gbStopCriterions.TabStop = false;
            // 
            // uCtrlOptMaxNumber
            // 
            resources.ApplyResources(this.uCtrlOptMaxNumber, "uCtrlOptMaxNumber");
            this.uCtrlOptMaxNumber.Minimum = 0;
            this.uCtrlOptMaxNumber.Name = "uCtrlOptMaxNumber";
            this.uCtrlOptMaxNumber.ValueChanged += new treeDiM.Basics.UCtrlOptInt.ValueChangedDelegate(this.OnCriterionChanged);
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
            // uCtrlMaxPalletHeight
            // 
            resources.ApplyResources(this.uCtrlMaxPalletHeight, "uCtrlMaxPalletHeight");
            this.uCtrlMaxPalletHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMaxPalletHeight.Name = "uCtrlMaxPalletHeight";
            this.uCtrlMaxPalletHeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMaxPalletHeight.Value = 0D;
            // 
            // tabCtrl
            // 
            resources.ApplyResources(this.tabCtrl, "tabCtrl");
            this.tabCtrl.Controls.Add(this.tabPagePalletCorners);
            this.tabCtrl.Controls.Add(this.tabPagePalletCap);
            this.tabCtrl.Controls.Add(this.tabPagePalletFilm);
            this.tabCtrl.Multiline = true;
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            // 
            // tabPagePalletCorners
            // 
            this.tabPagePalletCorners.Controls.Add(this.cbPalletCorners);
            this.tabPagePalletCorners.Controls.Add(this.chkbPalletCorners);
            resources.ApplyResources(this.tabPagePalletCorners, "tabPagePalletCorners");
            this.tabPagePalletCorners.Name = "tabPagePalletCorners";
            this.tabPagePalletCorners.UseVisualStyleBackColor = true;
            // 
            // cbPalletCorners
            // 
            this.cbPalletCorners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalletCorners.FormattingEnabled = true;
            resources.ApplyResources(this.cbPalletCorners, "cbPalletCorners");
            this.cbPalletCorners.Name = "cbPalletCorners";
            this.cbPalletCorners.SelectedIndexChanged += new System.EventHandler(this.OnPalletProtectionChanged);
            // 
            // chkbPalletCorners
            // 
            resources.ApplyResources(this.chkbPalletCorners, "chkbPalletCorners");
            this.chkbPalletCorners.Name = "chkbPalletCorners";
            this.chkbPalletCorners.UseVisualStyleBackColor = true;
            this.chkbPalletCorners.CheckedChanged += new System.EventHandler(this.OnPalletProtectionChanged);
            // 
            // tabPagePalletCap
            // 
            this.tabPagePalletCap.Controls.Add(this.cbPalletCap);
            this.tabPagePalletCap.Controls.Add(this.chkbPalletCap);
            resources.ApplyResources(this.tabPagePalletCap, "tabPagePalletCap");
            this.tabPagePalletCap.Name = "tabPagePalletCap";
            this.tabPagePalletCap.UseVisualStyleBackColor = true;
            // 
            // cbPalletCap
            // 
            this.cbPalletCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalletCap.FormattingEnabled = true;
            resources.ApplyResources(this.cbPalletCap, "cbPalletCap");
            this.cbPalletCap.Name = "cbPalletCap";
            this.cbPalletCap.SelectedIndexChanged += new System.EventHandler(this.OnPalletProtectionChanged);
            // 
            // chkbPalletCap
            // 
            resources.ApplyResources(this.chkbPalletCap, "chkbPalletCap");
            this.chkbPalletCap.Name = "chkbPalletCap";
            this.chkbPalletCap.UseVisualStyleBackColor = true;
            this.chkbPalletCap.CheckedChanged += new System.EventHandler(this.OnPalletProtectionChanged);
            // 
            // tabPagePalletFilm
            // 
            this.tabPagePalletFilm.Controls.Add(this.cbPalletFilm);
            this.tabPagePalletFilm.Controls.Add(this.chkbPalletFilm);
            resources.ApplyResources(this.tabPagePalletFilm, "tabPagePalletFilm");
            this.tabPagePalletFilm.Name = "tabPagePalletFilm";
            this.tabPagePalletFilm.UseVisualStyleBackColor = true;
            // 
            // cbPalletFilm
            // 
            this.cbPalletFilm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalletFilm.FormattingEnabled = true;
            resources.ApplyResources(this.cbPalletFilm, "cbPalletFilm");
            this.cbPalletFilm.Name = "cbPalletFilm";
            this.cbPalletFilm.SelectedIndexChanged += new System.EventHandler(this.OnPalletProtectionChanged);
            // 
            // chkbPalletFilm
            // 
            resources.ApplyResources(this.chkbPalletFilm, "chkbPalletFilm");
            this.chkbPalletFilm.Name = "chkbPalletFilm";
            this.chkbPalletFilm.UseVisualStyleBackColor = true;
            this.chkbPalletFilm.CheckedChanged += new System.EventHandler(this.OnPalletProtectionChanged);
            // 
            // DockContentAnalysisCasePallet
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DockContentAnalysisCasePallet";
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
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
            this.tabCtrl.ResumeLayout(false);
            this.tabPagePalletCorners.ResumeLayout(false);
            this.tabPagePalletCorners.PerformLayout();
            this.tabPagePalletCap.ResumeLayout(false);
            this.tabPagePalletCap.PerformLayout();
            this.tabPagePalletFilm.ResumeLayout(false);
            this.tabPagePalletFilm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPagePalletCorners;
        private System.Windows.Forms.ComboBox cbPalletCorners;
        private System.Windows.Forms.CheckBox chkbPalletCorners;
        private System.Windows.Forms.TabPage tabPagePalletCap;
        private System.Windows.Forms.ComboBox cbPalletCap;
        private System.Windows.Forms.CheckBox chkbPalletCap;
        private System.Windows.Forms.TabPage tabPagePalletFilm;
        private System.Windows.Forms.ComboBox cbPalletFilm;
        private System.Windows.Forms.CheckBox chkbPalletFilm;
        private System.Windows.Forms.GroupBox gbStopCriterions;
        private treeDiM.Basics.UCtrlDouble uCtrlMaxPalletHeight;
        private treeDiM.Basics.UCtrlOptDouble uCtrlOptMaximumWeight;
        private treeDiM.Basics.UCtrlOptInt uCtrlOptMaxNumber;
    }
}