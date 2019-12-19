namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewAnalysisHCylPallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewAnalysisHCylPallet));
            this.tabCtrlContraints = new System.Windows.Forms.TabControl();
            this.tabPageStopCriterions = new System.Windows.Forms.TabPage();
            this.uCtrlOptMaximumWeight = new treeDiM.Basics.UCtrlOptDouble();
            this.uCtrlMaximumHeight = new treeDiM.Basics.UCtrlDouble();
            this.tabPageOverhang = new System.Windows.Forms.TabPage();
            this.uCtrlOverhang = new treeDiM.Basics.UCtrlDualDouble();
            this.cbPallets = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbCylinders = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.lbPallet = new System.Windows.Forms.Label();
            this.lbCylinder = new System.Windows.Forms.Label();
            this.uCtrlPackable = new treeDiM.StackBuilder.Graphics.Controls.UCtrlPackable();
            this.uCtrlHCylLayoutList = new treeDiM.StackBuilder.Graphics.Controls.UCtrlHCylLayoutList();
            this.uCtrlOptMaximumNumber = new treeDiM.Basics.UCtrlOptInt();
            this.tabCtrlContraints.SuspendLayout();
            this.tabPageStopCriterions.SuspendLayout();
            this.tabPageOverhang.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            // 
            // tabCtrlContraints
            // 
            this.tabCtrlContraints.Controls.Add(this.tabPageStopCriterions);
            this.tabCtrlContraints.Controls.Add(this.tabPageOverhang);
            resources.ApplyResources(this.tabCtrlContraints, "tabCtrlContraints");
            this.tabCtrlContraints.Name = "tabCtrlContraints";
            this.tabCtrlContraints.SelectedIndex = 0;
            // 
            // tabPageStopCriterions
            // 
            this.tabPageStopCriterions.Controls.Add(this.uCtrlOptMaximumNumber);
            this.tabPageStopCriterions.Controls.Add(this.uCtrlOptMaximumWeight);
            this.tabPageStopCriterions.Controls.Add(this.uCtrlMaximumHeight);
            resources.ApplyResources(this.tabPageStopCriterions, "tabPageStopCriterions");
            this.tabPageStopCriterions.Name = "tabPageStopCriterions";
            this.tabPageStopCriterions.UseVisualStyleBackColor = true;
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
            // uCtrlMaximumHeight
            // 
            resources.ApplyResources(this.uCtrlMaximumHeight, "uCtrlMaximumHeight");
            this.uCtrlMaximumHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMaximumHeight.Name = "uCtrlMaximumHeight";
            this.uCtrlMaximumHeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            // 
            // tabPageOverhang
            // 
            this.tabPageOverhang.Controls.Add(this.uCtrlOverhang);
            resources.ApplyResources(this.tabPageOverhang, "tabPageOverhang");
            this.tabPageOverhang.Name = "tabPageOverhang";
            this.tabPageOverhang.UseVisualStyleBackColor = true;
            // 
            // uCtrlOverhang
            // 
            resources.ApplyResources(this.uCtrlOverhang, "uCtrlOverhang");
            this.uCtrlOverhang.MinValue = -10000D;
            this.uCtrlOverhang.Name = "uCtrlOverhang";
            this.uCtrlOverhang.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOverhang.ValueX = 0D;
            this.uCtrlOverhang.ValueY = 0D;
            // 
            // cbPallets
            // 
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            resources.ApplyResources(this.cbPallets, "cbPallets");
            this.cbPallets.Name = "cbPallets";
            // 
            // cbCylinders
            // 
            this.cbCylinders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCylinders.FormattingEnabled = true;
            resources.ApplyResources(this.cbCylinders, "cbCylinders");
            this.cbCylinders.Name = "cbCylinders";
            // 
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
            // 
            // lbCylinder
            // 
            resources.ApplyResources(this.lbCylinder, "lbCylinder");
            this.lbCylinder.Name = "lbCylinder";
            // 
            // uCtrlPackable
            // 
            resources.ApplyResources(this.uCtrlPackable, "uCtrlPackable");
            this.uCtrlPackable.Name = "uCtrlPackable";
            // 
            // uCtrlHCylLayoutList
            // 
            resources.ApplyResources(this.uCtrlHCylLayoutList, "uCtrlHCylLayoutList");
            this.uCtrlHCylLayoutList.ButtonSizes = new System.Drawing.Size(150, 150);
            this.uCtrlHCylLayoutList.Name = "uCtrlHCylLayoutList";
            this.uCtrlHCylLayoutList.LayoutSelected += new treeDiM.StackBuilder.Graphics.Controls.UCtrlHCylLayoutList.LayoutButtonClicked(this.OnLayoutSelected);
            // 
            // uCtrlOptMaximumNumber
            // 
            resources.ApplyResources(this.uCtrlOptMaximumNumber, "uCtrlOptMaximumNumber");
            this.uCtrlOptMaximumNumber.Minimum = -10000;
            this.uCtrlOptMaximumNumber.Name = "uCtrlOptMaximumNumber";
            // 
            // FormNewAnalysisHCylPallet
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uCtrlHCylLayoutList);
            this.Controls.Add(this.uCtrlPackable);
            this.Controls.Add(this.tabCtrlContraints);
            this.Controls.Add(this.cbPallets);
            this.Controls.Add(this.cbCylinders);
            this.Controls.Add(this.lbPallet);
            this.Controls.Add(this.lbCylinder);
            this.Name = "FormNewAnalysisHCylPallet";
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.lbCylinder, 0);
            this.Controls.SetChildIndex(this.lbPallet, 0);
            this.Controls.SetChildIndex(this.cbCylinders, 0);
            this.Controls.SetChildIndex(this.cbPallets, 0);
            this.Controls.SetChildIndex(this.tabCtrlContraints, 0);
            this.Controls.SetChildIndex(this.uCtrlPackable, 0);
            this.Controls.SetChildIndex(this.uCtrlHCylLayoutList, 0);
            this.tabCtrlContraints.ResumeLayout(false);
            this.tabPageStopCriterions.ResumeLayout(false);
            this.tabPageOverhang.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrlContraints;
        private System.Windows.Forms.TabPage tabPageStopCriterions;
        private treeDiM.Basics.UCtrlOptDouble uCtrlOptMaximumWeight;
        private treeDiM.Basics.UCtrlDouble uCtrlMaximumHeight;
        private System.Windows.Forms.TabPage tabPageOverhang;
        private treeDiM.Basics.UCtrlDualDouble uCtrlOverhang;
        private Graphics.Controls.CCtrlComboFiltered cbPallets;
        private Graphics.Controls.CCtrlComboFiltered cbCylinders;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.Label lbCylinder;
        private Graphics.Controls.UCtrlPackable uCtrlPackable;
        private Graphics.Controls.UCtrlHCylLayoutList uCtrlHCylLayoutList;
        private treeDiM.Basics.UCtrlOptInt uCtrlOptMaximumNumber;
    }
}