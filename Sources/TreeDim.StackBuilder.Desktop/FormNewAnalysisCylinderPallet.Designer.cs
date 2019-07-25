namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewAnalysisCylinderPallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewAnalysisCylinderPallet));
            this.uCtrlLayerList = new treeDiM.StackBuilder.Graphics.UCtrlLayerList();
            this.lbCylinder = new System.Windows.Forms.Label();
            this.lbPallet = new System.Windows.Forms.Label();
            this.cbCylinders = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbPallets = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.tabCtrlContraints = new System.Windows.Forms.TabControl();
            this.tabPageStopCriterions = new System.Windows.Forms.TabPage();
            this.uCtrlOptMaximumWeight = new treeDiM.Basics.UCtrlOptDouble();
            this.uCtrlMaximumHeight = new treeDiM.Basics.UCtrlDouble();
            this.tabPageOverhang = new System.Windows.Forms.TabPage();
            this.uCtrlOverhang = new treeDiM.Basics.UCtrlDualDouble();
            this.lbSelect = new System.Windows.Forms.Label();
            this.checkBoxBestLayersOnly = new System.Windows.Forms.CheckBox();
            this.uCtrlPackable = new treeDiM.StackBuilder.Graphics.Controls.UCtrlPackable();
            this.tabCtrlContraints.SuspendLayout();
            this.tabPageStopCriterions.SuspendLayout();
            this.tabPageOverhang.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            // 
            // lbDescription
            // 
            resources.ApplyResources(this.lbDescription, "lbDescription");
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            // 
            // uCtrlLayerList
            // 
            resources.ApplyResources(this.uCtrlLayerList, "uCtrlLayerList");
            this.uCtrlLayerList.Name = "uCtrlLayerList";
            this.uCtrlLayerList.SingleSelection = false;
            // 
            // lbCylinder
            // 
            resources.ApplyResources(this.lbCylinder, "lbCylinder");
            this.lbCylinder.Name = "lbCylinder";
            // 
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
            // 
            // cbCylinders
            // 
            resources.ApplyResources(this.cbCylinders, "cbCylinders");
            this.cbCylinders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCylinders.FormattingEnabled = true;
            this.cbCylinders.Name = "cbCylinders";
            this.cbCylinders.SelectedIndexChanged += new System.EventHandler(this.onCylinderChanged);
            // 
            // cbPallets
            // 
            resources.ApplyResources(this.cbPallets, "cbPallets");
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            this.cbPallets.Name = "cbPallets";
            this.cbPallets.SelectedIndexChanged += new System.EventHandler(this.onInputChanged);
            // 
            // tabCtrlContraints
            // 
            resources.ApplyResources(this.tabCtrlContraints, "tabCtrlContraints");
            this.tabCtrlContraints.Controls.Add(this.tabPageStopCriterions);
            this.tabCtrlContraints.Controls.Add(this.tabPageOverhang);
            this.tabCtrlContraints.Name = "tabCtrlContraints";
            this.tabCtrlContraints.SelectedIndex = 0;
            // 
            // tabPageStopCriterions
            // 
            resources.ApplyResources(this.tabPageStopCriterions, "tabPageStopCriterions");
            this.tabPageStopCriterions.Controls.Add(this.uCtrlOptMaximumWeight);
            this.tabPageStopCriterions.Controls.Add(this.uCtrlMaximumHeight);
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
            this.uCtrlOptMaximumWeight.ValueChanged += new treeDiM.Basics.UCtrlOptDouble.ValueChangedDelegate(this.onInputChanged);
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
            this.uCtrlMaximumHeight.Value = 0D;
            this.uCtrlMaximumHeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.onInputChanged);
            // 
            // tabPageOverhang
            // 
            resources.ApplyResources(this.tabPageOverhang, "tabPageOverhang");
            this.tabPageOverhang.Controls.Add(this.uCtrlOverhang);
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
            this.uCtrlOverhang.ValueChanged += new treeDiM.Basics.UCtrlDualDouble.ValueChangedDelegate(this.onInputChanged);
            // 
            // lbSelect
            // 
            resources.ApplyResources(this.lbSelect, "lbSelect");
            this.lbSelect.Name = "lbSelect";
            // 
            // checkBoxBestLayersOnly
            // 
            resources.ApplyResources(this.checkBoxBestLayersOnly, "checkBoxBestLayersOnly");
            this.checkBoxBestLayersOnly.Name = "checkBoxBestLayersOnly";
            this.checkBoxBestLayersOnly.UseVisualStyleBackColor = true;
            this.checkBoxBestLayersOnly.CheckedChanged += new System.EventHandler(this.onInputChanged);
            // 
            // uCtrlPackable
            // 
            resources.ApplyResources(this.uCtrlPackable, "uCtrlPackable");
            this.uCtrlPackable.Name = "uCtrlPackable";
            // 
            // FormNewAnalysisCylinderPallet
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uCtrlPackable);
            this.Controls.Add(this.checkBoxBestLayersOnly);
            this.Controls.Add(this.lbSelect);
            this.Controls.Add(this.tabCtrlContraints);
            this.Controls.Add(this.cbPallets);
            this.Controls.Add(this.cbCylinders);
            this.Controls.Add(this.lbPallet);
            this.Controls.Add(this.lbCylinder);
            this.Controls.Add(this.uCtrlLayerList);
            this.Name = "FormNewAnalysisCylinderPallet";
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.uCtrlLayerList, 0);
            this.Controls.SetChildIndex(this.lbCylinder, 0);
            this.Controls.SetChildIndex(this.lbPallet, 0);
            this.Controls.SetChildIndex(this.cbCylinders, 0);
            this.Controls.SetChildIndex(this.cbPallets, 0);
            this.Controls.SetChildIndex(this.tabCtrlContraints, 0);
            this.Controls.SetChildIndex(this.lbSelect, 0);
            this.Controls.SetChildIndex(this.checkBoxBestLayersOnly, 0);
            this.Controls.SetChildIndex(this.uCtrlPackable, 0);
            this.tabCtrlContraints.ResumeLayout(false);
            this.tabPageStopCriterions.ResumeLayout(false);
            this.tabPageOverhang.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Graphics.UCtrlLayerList uCtrlLayerList;
        private System.Windows.Forms.Label lbCylinder;
        private System.Windows.Forms.Label lbPallet;
        private Graphics.Controls.CCtrlComboFiltered cbCylinders;
        private Graphics.Controls.CCtrlComboFiltered cbPallets;
        private System.Windows.Forms.TabControl tabCtrlContraints;
        private System.Windows.Forms.TabPage tabPageStopCriterions;
        private System.Windows.Forms.TabPage tabPageOverhang;
        private System.Windows.Forms.Label lbSelect;
        private treeDiM.Basics.UCtrlDouble uCtrlMaximumHeight;
        private treeDiM.Basics.UCtrlOptDouble uCtrlOptMaximumWeight;
        private treeDiM.Basics.UCtrlDualDouble uCtrlOverhang;
        private System.Windows.Forms.CheckBox checkBoxBestLayersOnly;
        private Graphics.Controls.UCtrlPackable uCtrlPackable;
    }
}