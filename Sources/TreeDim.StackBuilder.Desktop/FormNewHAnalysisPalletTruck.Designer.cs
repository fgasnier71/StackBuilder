namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewHAnalysisPalletTruck
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
            this.lbTrucks = new System.Windows.Forms.Label();
            this.cbTrucks = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.uCtrlMinDistanceLoadWall = new treeDiM.Basics.UCtrlDualDouble();
            this.uCtrlMinDistanceLoadRoof = new treeDiM.Basics.UCtrlDouble();
            this.rbSinglePalletType = new System.Windows.Forms.RadioButton();
            this.rbMultiPalletType = new System.Windows.Forms.RadioButton();
            this.cbPallets = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.gridContent = new SourceGrid.Grid();
            this.uCtrlMaxNoPallets = new treeDiM.Basics.UCtrlOptInt();
            this.gridRules = new SourceGrid.Grid();
            this.lbRules = new System.Windows.Forms.Label();
            this.bnAddStackingRule = new System.Windows.Forms.Button();
            this.gridPalletStack = new SourceGrid.Grid();
            this.grid1 = new SourceGrid.Grid();
            this.chkbSortPalletStacks = new System.Windows.Forms.CheckBox();
            this.bnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Size = new System.Drawing.Size(689, 20);
            // 
            // lbTrucks
            // 
            this.lbTrucks.AutoSize = true;
            this.lbTrucks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTrucks.Location = new System.Drawing.Point(8, 63);
            this.lbTrucks.Name = "lbTrucks";
            this.lbTrucks.Size = new System.Drawing.Size(35, 13);
            this.lbTrucks.TabIndex = 17;
            this.lbTrucks.Text = "Truck";
            // 
            // cbTrucks
            // 
            this.cbTrucks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrucks.FormattingEnabled = true;
            this.cbTrucks.Location = new System.Drawing.Point(106, 60);
            this.cbTrucks.Name = "cbTrucks";
            this.cbTrucks.Size = new System.Drawing.Size(145, 21);
            this.cbTrucks.TabIndex = 18;
            // 
            // uCtrlMinDistanceLoadWall
            // 
            this.uCtrlMinDistanceLoadWall.Location = new System.Drawing.Point(340, 61);
            this.uCtrlMinDistanceLoadWall.MinValue = 0D;
            this.uCtrlMinDistanceLoadWall.Name = "uCtrlMinDistanceLoadWall";
            this.uCtrlMinDistanceLoadWall.Size = new System.Drawing.Size(355, 20);
            this.uCtrlMinDistanceLoadWall.TabIndex = 22;
            this.uCtrlMinDistanceLoadWall.Text = "Minimum distance load/wall";
            this.uCtrlMinDistanceLoadWall.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMinDistanceLoadWall.ValueX = 0D;
            this.uCtrlMinDistanceLoadWall.ValueY = 0D;
            // 
            // uCtrlMinDistanceLoadRoof
            // 
            this.uCtrlMinDistanceLoadRoof.Location = new System.Drawing.Point(340, 85);
            this.uCtrlMinDistanceLoadRoof.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.uCtrlMinDistanceLoadRoof.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlMinDistanceLoadRoof.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMinDistanceLoadRoof.Name = "uCtrlMinDistanceLoadRoof";
            this.uCtrlMinDistanceLoadRoof.Size = new System.Drawing.Size(355, 20);
            this.uCtrlMinDistanceLoadRoof.TabIndex = 21;
            this.uCtrlMinDistanceLoadRoof.Text = "Minimum distance load/roof";
            this.uCtrlMinDistanceLoadRoof.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            // 
            // rbSinglePalletType
            // 
            this.rbSinglePalletType.AutoSize = true;
            this.rbSinglePalletType.Location = new System.Drawing.Point(6, 122);
            this.rbSinglePalletType.Name = "rbSinglePalletType";
            this.rbSinglePalletType.Size = new System.Drawing.Size(94, 17);
            this.rbSinglePalletType.TabIndex = 23;
            this.rbSinglePalletType.TabStop = true;
            this.rbSinglePalletType.Text = "Homogeneous";
            this.rbSinglePalletType.UseVisualStyleBackColor = true;
            this.rbSinglePalletType.CheckedChanged += new System.EventHandler(this.OnSingleMultiplePalletTypeChanged);
            // 
            // rbMultiPalletType
            // 
            this.rbMultiPalletType.AutoSize = true;
            this.rbMultiPalletType.Location = new System.Drawing.Point(6, 153);
            this.rbMultiPalletType.Name = "rbMultiPalletType";
            this.rbMultiPalletType.Size = new System.Drawing.Size(98, 17);
            this.rbMultiPalletType.TabIndex = 24;
            this.rbMultiPalletType.TabStop = true;
            this.rbMultiPalletType.Text = "Heterogeneous";
            this.rbMultiPalletType.UseVisualStyleBackColor = true;
            // 
            // cbPallets
            // 
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            this.cbPallets.Location = new System.Drawing.Point(106, 121);
            this.cbPallets.Name = "cbPallets";
            this.cbPallets.Size = new System.Drawing.Size(145, 21);
            this.cbPallets.TabIndex = 25;
            // 
            // gridContent
            // 
            this.gridContent.EnableSort = true;
            this.gridContent.Location = new System.Drawing.Point(106, 150);
            this.gridContent.Name = "gridContent";
            this.gridContent.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridContent.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridContent.Size = new System.Drawing.Size(210, 91);
            this.gridContent.TabIndex = 26;
            this.gridContent.TabStop = true;
            this.gridContent.ToolTipText = "";
            // 
            // uCtrlMaxNoPallets
            // 
            this.uCtrlMaxNoPallets.Location = new System.Drawing.Point(340, 122);
            this.uCtrlMaxNoPallets.Minimum = 0;
            this.uCtrlMaxNoPallets.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMaxNoPallets.Name = "uCtrlMaxNoPallets";
            this.uCtrlMaxNoPallets.Size = new System.Drawing.Size(292, 20);
            this.uCtrlMaxNoPallets.TabIndex = 28;
            this.uCtrlMaxNoPallets.Text = "Maximum number of pallets";
            // 
            // gridRules
            // 
            this.gridRules.EnableSort = true;
            this.gridRules.Location = new System.Drawing.Point(456, 150);
            this.gridRules.Name = "gridRules";
            this.gridRules.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridRules.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridRules.Size = new System.Drawing.Size(263, 91);
            this.gridRules.TabIndex = 29;
            this.gridRules.TabStop = true;
            this.gridRules.ToolTipText = "";
            // 
            // lbRules
            // 
            this.lbRules.AutoSize = true;
            this.lbRules.Location = new System.Drawing.Point(340, 150);
            this.lbRules.Name = "lbRules";
            this.lbRules.Size = new System.Drawing.Size(74, 13);
            this.lbRules.TabIndex = 30;
            this.lbRules.Text = "Stacking rules";
            // 
            // bnAddStackingRule
            // 
            this.bnAddStackingRule.Location = new System.Drawing.Point(727, 150);
            this.bnAddStackingRule.Name = "bnAddStackingRule";
            this.bnAddStackingRule.Size = new System.Drawing.Size(68, 23);
            this.bnAddStackingRule.TabIndex = 31;
            this.bnAddStackingRule.Text = "Add...";
            this.bnAddStackingRule.UseVisualStyleBackColor = true;
            // 
            // gridPalletStack
            // 
            this.gridPalletStack.EnableSort = true;
            this.gridPalletStack.Location = new System.Drawing.Point(456, 251);
            this.gridPalletStack.Name = "gridPalletStack";
            this.gridPalletStack.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridPalletStack.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridPalletStack.Size = new System.Drawing.Size(263, 100);
            this.gridPalletStack.TabIndex = 33;
            this.gridPalletStack.TabStop = true;
            this.gridPalletStack.ToolTipText = "";
            // 
            // grid1
            // 
            this.grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(0, 365);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(807, 141);
            this.grid1.TabIndex = 34;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // chkbSortPalletStacks
            // 
            this.chkbSortPalletStacks.AutoSize = true;
            this.chkbSortPalletStacks.Location = new System.Drawing.Point(343, 251);
            this.chkbSortPalletStacks.Name = "chkbSortPalletStacks";
            this.chkbSortPalletStacks.Size = new System.Drawing.Size(107, 17);
            this.chkbSortPalletStacks.TabIndex = 36;
            this.chkbSortPalletStacks.Text = "Sort pallet stacks";
            this.chkbSortPalletStacks.UseVisualStyleBackColor = true;
            // 
            // bnEdit
            // 
            this.bnEdit.Location = new System.Drawing.Point(625, 512);
            this.bnEdit.Name = "bnEdit";
            this.bnEdit.Size = new System.Drawing.Size(75, 23);
            this.bnEdit.TabIndex = 37;
            this.bnEdit.Text = "Edit";
            this.bnEdit.UseVisualStyleBackColor = true;
            // 
            // FormNewHAnalysisPalletTruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 561);
            this.Controls.Add(this.bnEdit);
            this.Controls.Add(this.chkbSortPalletStacks);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.gridPalletStack);
            this.Controls.Add(this.bnAddStackingRule);
            this.Controls.Add(this.lbRules);
            this.Controls.Add(this.gridRules);
            this.Controls.Add(this.uCtrlMaxNoPallets);
            this.Controls.Add(this.gridContent);
            this.Controls.Add(this.cbPallets);
            this.Controls.Add(this.rbMultiPalletType);
            this.Controls.Add(this.rbSinglePalletType);
            this.Controls.Add(this.uCtrlMinDistanceLoadWall);
            this.Controls.Add(this.uCtrlMinDistanceLoadRoof);
            this.Controls.Add(this.cbTrucks);
            this.Controls.Add(this.lbTrucks);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormNewHAnalysisPalletTruck";
            this.Text = "Create new analysis Pallet/Truck...";
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.lbTrucks, 0);
            this.Controls.SetChildIndex(this.cbTrucks, 0);
            this.Controls.SetChildIndex(this.uCtrlMinDistanceLoadRoof, 0);
            this.Controls.SetChildIndex(this.uCtrlMinDistanceLoadWall, 0);
            this.Controls.SetChildIndex(this.rbSinglePalletType, 0);
            this.Controls.SetChildIndex(this.rbMultiPalletType, 0);
            this.Controls.SetChildIndex(this.cbPallets, 0);
            this.Controls.SetChildIndex(this.gridContent, 0);
            this.Controls.SetChildIndex(this.uCtrlMaxNoPallets, 0);
            this.Controls.SetChildIndex(this.gridRules, 0);
            this.Controls.SetChildIndex(this.lbRules, 0);
            this.Controls.SetChildIndex(this.bnAddStackingRule, 0);
            this.Controls.SetChildIndex(this.gridPalletStack, 0);
            this.Controls.SetChildIndex(this.grid1, 0);
            this.Controls.SetChildIndex(this.chkbSortPalletStacks, 0);
            this.Controls.SetChildIndex(this.bnEdit, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTrucks;
        private Graphics.Controls.CCtrlComboFiltered cbTrucks;
        private treeDiM.Basics.UCtrlDualDouble uCtrlMinDistanceLoadWall;
        private treeDiM.Basics.UCtrlDouble uCtrlMinDistanceLoadRoof;
        private System.Windows.Forms.RadioButton rbSinglePalletType;
        private System.Windows.Forms.RadioButton rbMultiPalletType;
        private Graphics.Controls.CCtrlComboFiltered cbPallets;
        private SourceGrid.Grid gridContent;
        private treeDiM.Basics.UCtrlOptInt uCtrlMaxNoPallets;
        private SourceGrid.Grid gridRules;
        private System.Windows.Forms.Label lbRules;
        private System.Windows.Forms.Button bnAddStackingRule;
        private SourceGrid.Grid gridPalletStack;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.CheckBox chkbSortPalletStacks;
        private System.Windows.Forms.Button bnEdit;
    }
}