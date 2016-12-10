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
            this.uCtrlOptMaximumWeight = new treeDiM.StackBuilder.Basics.UCtrlOptDouble();
            this.uCtrlMaximumHeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.tabPageOverhang = new System.Windows.Forms.TabPage();
            this.uCtrlOverhang = new treeDiM.StackBuilder.Basics.UCtrlDualDouble();
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
            this.tbDescription.Size = new System.Drawing.Size(592, 20);
            // 
            // bnCancel
            // 
            this.bnCancel.Location = new System.Drawing.Point(706, 4);
            // 
            // uCtrlLayerList
            // 
            this.uCtrlLayerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uCtrlLayerList.AutoScroll = true;
            this.uCtrlLayerList.ButtonSizes = new System.Drawing.Size(150, 150);
            this.uCtrlLayerList.Location = new System.Drawing.Point(0, 218);
            this.uCtrlLayerList.Name = "uCtrlLayerList";
            this.uCtrlLayerList.Size = new System.Drawing.Size(784, 289);
            this.uCtrlLayerList.TabIndex = 13;
            // 
            // lbCylinder
            // 
            this.lbCylinder.AutoSize = true;
            this.lbCylinder.Location = new System.Drawing.Point(6, 66);
            this.lbCylinder.Name = "lbCylinder";
            this.lbCylinder.Size = new System.Drawing.Size(44, 13);
            this.lbCylinder.TabIndex = 14;
            this.lbCylinder.Text = "Cylinder";
            // 
            // lbPallet
            // 
            this.lbPallet.AutoSize = true;
            this.lbPallet.Location = new System.Drawing.Point(304, 66);
            this.lbPallet.Name = "lbPallet";
            this.lbPallet.Size = new System.Drawing.Size(33, 13);
            this.lbPallet.TabIndex = 15;
            this.lbPallet.Text = "Pallet";
            // 
            // cbCylinders
            // 
            this.cbCylinders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCylinders.FormattingEnabled = true;
            this.cbCylinders.Location = new System.Drawing.Point(104, 63);
            this.cbCylinders.Name = "cbCylinders";
            this.cbCylinders.Size = new System.Drawing.Size(142, 21);
            this.cbCylinders.TabIndex = 16;
            this.cbCylinders.SelectedIndexChanged += new System.EventHandler(this.onCylinderChanged);
            // 
            // cbPallets
            // 
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            this.cbPallets.Location = new System.Drawing.Point(376, 63);
            this.cbPallets.Name = "cbPallets";
            this.cbPallets.Size = new System.Drawing.Size(142, 21);
            this.cbPallets.TabIndex = 17;
            this.cbPallets.SelectedIndexChanged += new System.EventHandler(this.onInputChanged);
            // 
            // tabCtrlContraints
            // 
            this.tabCtrlContraints.Controls.Add(this.tabPageStopCriterions);
            this.tabCtrlContraints.Controls.Add(this.tabPageOverhang);
            this.tabCtrlContraints.Location = new System.Drawing.Point(307, 92);
            this.tabCtrlContraints.Name = "tabCtrlContraints";
            this.tabCtrlContraints.SelectedIndex = 0;
            this.tabCtrlContraints.Size = new System.Drawing.Size(477, 100);
            this.tabCtrlContraints.TabIndex = 18;
            // 
            // tabPageStopCriterions
            // 
            this.tabPageStopCriterions.Controls.Add(this.uCtrlOptMaximumWeight);
            this.tabPageStopCriterions.Controls.Add(this.uCtrlMaximumHeight);
            this.tabPageStopCriterions.Location = new System.Drawing.Point(4, 22);
            this.tabPageStopCriterions.Name = "tabPageStopCriterions";
            this.tabPageStopCriterions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStopCriterions.Size = new System.Drawing.Size(469, 74);
            this.tabPageStopCriterions.TabIndex = 0;
            this.tabPageStopCriterions.Text = "Stop criterions";
            this.tabPageStopCriterions.UseVisualStyleBackColor = true;
            // 
            // uCtrlOptMaximumWeight
            // 
            this.uCtrlOptMaximumWeight.Location = new System.Drawing.Point(9, 33);
            this.uCtrlOptMaximumWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlOptMaximumWeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlOptMaximumWeight.Name = "uCtrlOptMaximumWeight";
            this.uCtrlOptMaximumWeight.Size = new System.Drawing.Size(349, 20);
            this.uCtrlOptMaximumWeight.TabIndex = 25;
            this.uCtrlOptMaximumWeight.Text = "Maximum pallet weight";
            this.uCtrlOptMaximumWeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlOptMaximumWeight.Value = ((treeDiM.StackBuilder.Basics.OptDouble)(resources.GetObject("uCtrlOptMaximumWeight.Value")));
            this.uCtrlOptMaximumWeight.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlOptDouble.onValueChanged(this.onInputChanged);
            // 
            // uCtrlMaximumHeight
            // 
            this.uCtrlMaximumHeight.Location = new System.Drawing.Point(9, 7);
            this.uCtrlMaximumHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMaximumHeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMaximumHeight.Name = "uCtrlMaximumHeight";
            this.uCtrlMaximumHeight.Size = new System.Drawing.Size(349, 20);
            this.uCtrlMaximumHeight.TabIndex = 0;
            this.uCtrlMaximumHeight.Text = "Maximum pallet height";
            this.uCtrlMaximumHeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMaximumHeight.Value = 0D;
            this.uCtrlMaximumHeight.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.onValueChanged(this.onInputChanged);
            // 
            // tabPageOverhang
            // 
            this.tabPageOverhang.Controls.Add(this.uCtrlOverhang);
            this.tabPageOverhang.Location = new System.Drawing.Point(4, 22);
            this.tabPageOverhang.Name = "tabPageOverhang";
            this.tabPageOverhang.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOverhang.Size = new System.Drawing.Size(469, 74);
            this.tabPageOverhang.TabIndex = 1;
            this.tabPageOverhang.Text = "Overhang";
            this.tabPageOverhang.UseVisualStyleBackColor = true;
            // 
            // uCtrlOverhang
            // 
            this.uCtrlOverhang.Location = new System.Drawing.Point(5, 6);
            this.uCtrlOverhang.Name = "uCtrlOverhang";
            this.uCtrlOverhang.Size = new System.Drawing.Size(283, 22);
            this.uCtrlOverhang.TabIndex = 22;
            this.uCtrlOverhang.Text = "Overhang";
            this.uCtrlOverhang.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOverhang.ValueX = 0D;
            this.uCtrlOverhang.ValueY = 0D;
            this.uCtrlOverhang.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDualDouble.onValueChanged(this.onInputChanged);
            // 
            // lbSelect
            // 
            this.lbSelect.AutoSize = true;
            this.lbSelect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbSelect.Location = new System.Drawing.Point(5, 200);
            this.lbSelect.Name = "lbSelect";
            this.lbSelect.Size = new System.Drawing.Size(216, 13);
            this.lbSelect.TabIndex = 30;
            this.lbSelect.Text = "Select one or more layers and click \'Next>\'...";
            // 
            // checkBoxBestLayersOnly
            // 
            this.checkBoxBestLayersOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxBestLayersOnly.AutoSize = true;
            this.checkBoxBestLayersOnly.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxBestLayersOnly.Location = new System.Drawing.Point(8, 516);
            this.checkBoxBestLayersOnly.Name = "checkBoxBestLayersOnly";
            this.checkBoxBestLayersOnly.Size = new System.Drawing.Size(128, 17);
            this.checkBoxBestLayersOnly.TabIndex = 31;
            this.checkBoxBestLayersOnly.Text = "Show best layers only";
            this.checkBoxBestLayersOnly.UseVisualStyleBackColor = true;
            this.checkBoxBestLayersOnly.CheckedChanged += new System.EventHandler(this.onInputChanged);
            // 
            // uCtrlPackable
            // 
            this.uCtrlPackable.Location = new System.Drawing.Point(106, 91);
            this.uCtrlPackable.Name = "uCtrlPackable";
            this.uCtrlPackable.Size = new System.Drawing.Size(142, 101);
            this.uCtrlPackable.TabIndex = 32;
            // 
            // FormNewAnalysisCylinderPallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
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
            this.Text = "Create new cylinder/pallet analysis...";
            this.Controls.SetChildIndex(this.bnCancel, 0);
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
        private Basics.UCtrlDouble uCtrlMaximumHeight;
        private Basics.UCtrlOptDouble uCtrlOptMaximumWeight;
        private Basics.UCtrlDualDouble uCtrlOverhang;
        private System.Windows.Forms.CheckBox checkBoxBestLayersOnly;
        private Graphics.Controls.UCtrlPackable uCtrlPackable;
    }
}