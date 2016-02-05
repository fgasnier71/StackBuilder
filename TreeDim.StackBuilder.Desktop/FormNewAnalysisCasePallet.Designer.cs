namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewAnalysisCasePallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewAnalysisCasePallet));
            this.cbPallets = new System.Windows.Forms.ComboBox();
            this.cbCases = new System.Windows.Forms.ComboBox();
            this.lbBox = new System.Windows.Forms.Label();
            this.uCtrlOptMaximumWeight = new treeDiM.StackBuilder.Basics.UCtrlOptDouble();
            this.uCtrlOptMaximumHeight = new treeDiM.StackBuilder.Basics.UCtrlOptDouble();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uCtrlOverhang = new treeDiM.StackBuilder.Basics.UCtrlDualDouble();
            this.lbPallet = new System.Windows.Forms.Label();
            this.uCtrlCaseOrientation = new treeDiM.StackBuilder.Graphics.uCtrlCaseOrientation();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPallets
            // 
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            resources.ApplyResources(this.cbPallets, "cbPallets");
            this.cbPallets.Name = "cbPallets";
            this.cbPallets.SelectedIndexChanged += new System.EventHandler(this.onPalletChanged);
            // 
            // cbCases
            // 
            this.cbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCases.FormattingEnabled = true;
            resources.ApplyResources(this.cbCases, "cbCases");
            this.cbCases.Name = "cbCases";
            this.cbCases.SelectedIndexChanged += new System.EventHandler(this.onCaseChanged);
            // 
            // lbBox
            // 
            resources.ApplyResources(this.lbBox, "lbBox");
            this.lbBox.Name = "lbBox";
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
            this.uCtrlOptMaximumWeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlOptMaximumWeight.Value = ((treeDiM.StackBuilder.Basics.OptDouble)(resources.GetObject("uCtrlOptMaximumWeight.Value")));
            // 
            // uCtrlOptMaximumHeight
            // 
            resources.ApplyResources(this.uCtrlOptMaximumHeight, "uCtrlOptMaximumHeight");
            this.uCtrlOptMaximumHeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.uCtrlOptMaximumHeight.Name = "uCtrlOptMaximumHeight";
            this.uCtrlOptMaximumHeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOptMaximumHeight.Value = ((treeDiM.StackBuilder.Basics.OptDouble)(resources.GetObject("uCtrlOptMaximumHeight.Value")));
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uCtrlOptMaximumWeight);
            this.groupBox1.Controls.Add(this.uCtrlOptMaximumHeight);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // uCtrlOverhang
            // 
            resources.ApplyResources(this.uCtrlOverhang, "uCtrlOverhang");
            this.uCtrlOverhang.Name = "uCtrlOverhang";
            this.uCtrlOverhang.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOverhang.ValueX = 0D;
            this.uCtrlOverhang.ValueY = 0D;
            this.uCtrlOverhang.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDualDouble.onValueChanged(this.onOverhangChanged);
            // 
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
            // 
            // uCtrlCaseOrientation
            // 
            resources.ApplyResources(this.uCtrlCaseOrientation, "uCtrlCaseOrientation");
            this.uCtrlCaseOrientation.Name = "uCtrlCaseOrientation";
            // 
            // FormNewAnalysisCasePallet
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uCtrlCaseOrientation);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uCtrlOverhang);
            this.Controls.Add(this.cbPallets);
            this.Controls.Add(this.cbCases);
            this.Controls.Add(this.lbPallet);
            this.Controls.Add(this.lbBox);
            this.Name = "FormNewAnalysisCasePallet";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.lbBox, 0);
            this.Controls.SetChildIndex(this.lbPallet, 0);
            this.Controls.SetChildIndex(this.cbCases, 0);
            this.Controls.SetChildIndex(this.cbPallets, 0);
            this.Controls.SetChildIndex(this.uCtrlOverhang, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.uCtrlCaseOrientation, 0);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPallets;
        private System.Windows.Forms.ComboBox cbCases;
        private System.Windows.Forms.Label lbBox;
        private Basics.UCtrlOptDouble uCtrlOptMaximumWeight;
        private Basics.UCtrlOptDouble uCtrlOptMaximumHeight;
        private System.Windows.Forms.GroupBox groupBox1;
        private Basics.UCtrlDualDouble uCtrlOverhang;
        private System.Windows.Forms.Label lbPallet;
        private Graphics.uCtrlCaseOrientation uCtrlCaseOrientation;
    }
}