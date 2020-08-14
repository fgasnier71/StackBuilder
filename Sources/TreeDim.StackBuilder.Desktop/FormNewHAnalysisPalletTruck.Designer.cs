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
            this.chkbAllowMultipleLayers = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Size = new System.Drawing.Size(682, 20);
            // 
            // lbTrucks
            // 
            this.lbTrucks.AutoSize = true;
            this.lbTrucks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTrucks.Location = new System.Drawing.Point(426, 63);
            this.lbTrucks.Name = "lbTrucks";
            this.lbTrucks.Size = new System.Drawing.Size(40, 13);
            this.lbTrucks.TabIndex = 17;
            this.lbTrucks.Text = "Trucks";
            // 
            // cbTrucks
            // 
            this.cbTrucks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrucks.FormattingEnabled = true;
            this.cbTrucks.Location = new System.Drawing.Point(623, 60);
            this.cbTrucks.Name = "cbTrucks";
            this.cbTrucks.Size = new System.Drawing.Size(163, 21);
            this.cbTrucks.TabIndex = 18;
            // 
            // uCtrlMinDistanceLoadWall
            // 
            this.uCtrlMinDistanceLoadWall.Location = new System.Drawing.Point(429, 87);
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
            this.uCtrlMinDistanceLoadRoof.Location = new System.Drawing.Point(429, 111);
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
            this.rbSinglePalletType.Location = new System.Drawing.Point(8, 61);
            this.rbSinglePalletType.Name = "rbSinglePalletType";
            this.rbSinglePalletType.Size = new System.Drawing.Size(105, 17);
            this.rbSinglePalletType.TabIndex = 23;
            this.rbSinglePalletType.TabStop = true;
            this.rbSinglePalletType.Text = "Single pallet type";
            this.rbSinglePalletType.UseVisualStyleBackColor = true;
            // 
            // rbMultiPalletType
            // 
            this.rbMultiPalletType.AutoSize = true;
            this.rbMultiPalletType.Location = new System.Drawing.Point(8, 87);
            this.rbMultiPalletType.Name = "rbMultiPalletType";
            this.rbMultiPalletType.Size = new System.Drawing.Size(98, 17);
            this.rbMultiPalletType.TabIndex = 24;
            this.rbMultiPalletType.TabStop = true;
            this.rbMultiPalletType.Text = "Multi pallet type";
            this.rbMultiPalletType.UseVisualStyleBackColor = true;
            // 
            // cbPallets
            // 
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            this.cbPallets.Location = new System.Drawing.Point(130, 60);
            this.cbPallets.Name = "cbPallets";
            this.cbPallets.Size = new System.Drawing.Size(145, 21);
            this.cbPallets.TabIndex = 25;
            // 
            // gridPallets
            // 
            this.gridContent.EnableSort = true;
            this.gridContent.Location = new System.Drawing.Point(130, 89);
            this.gridContent.Name = "gridPallets";
            this.gridContent.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridContent.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridContent.Size = new System.Drawing.Size(284, 125);
            this.gridContent.TabIndex = 26;
            this.gridContent.TabStop = true;
            this.gridContent.ToolTipText = "";
            // 
            // uCtrlMaxNoPallets
            // 
            this.uCtrlMaxNoPallets.Location = new System.Drawing.Point(429, 159);
            this.uCtrlMaxNoPallets.Minimum = 0;
            this.uCtrlMaxNoPallets.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMaxNoPallets.Name = "uCtrlMaxNoPallets";
            this.uCtrlMaxNoPallets.Size = new System.Drawing.Size(292, 20);
            this.uCtrlMaxNoPallets.TabIndex = 28;
            this.uCtrlMaxNoPallets.Text = "Maximum number of pallets";
            // 
            // chkbAllowMultipleLayers
            // 
            this.chkbAllowMultipleLayers.AutoSize = true;
            this.chkbAllowMultipleLayers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkbAllowMultipleLayers.Location = new System.Drawing.Point(429, 137);
            this.chkbAllowMultipleLayers.Name = "chkbAllowMultipleLayers";
            this.chkbAllowMultipleLayers.Size = new System.Drawing.Size(119, 17);
            this.chkbAllowMultipleLayers.TabIndex = 27;
            this.chkbAllowMultipleLayers.Text = "Allow multiple layers";
            this.chkbAllowMultipleLayers.UseVisualStyleBackColor = true;
            // 
            // FormNewHAnalysisPalletTruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uCtrlMaxNoPallets);
            this.Controls.Add(this.chkbAllowMultipleLayers);
            this.Controls.Add(this.gridContent);
            this.Controls.Add(this.cbPallets);
            this.Controls.Add(this.rbMultiPalletType);
            this.Controls.Add(this.rbSinglePalletType);
            this.Controls.Add(this.uCtrlMinDistanceLoadWall);
            this.Controls.Add(this.uCtrlMinDistanceLoadRoof);
            this.Controls.Add(this.cbTrucks);
            this.Controls.Add(this.lbTrucks);
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
            this.Controls.SetChildIndex(this.chkbAllowMultipleLayers, 0);
            this.Controls.SetChildIndex(this.uCtrlMaxNoPallets, 0);
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
        private System.Windows.Forms.CheckBox chkbAllowMultipleLayers;
    }
}