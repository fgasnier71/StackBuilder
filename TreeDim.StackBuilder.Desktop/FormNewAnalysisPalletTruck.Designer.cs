namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewAnalysisPalletTruck
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
            this.lbPallets = new System.Windows.Forms.Label();
            this.lbTrucks = new System.Windows.Forms.Label();
            this.cbTrucks = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbPallets = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.uCtrlLayerList = new treeDiM.StackBuilder.Graphics.UCtrlLayerList();
            this.checkBoxBestLayersOnly = new System.Windows.Forms.CheckBox();
            this.uCtrlMinDistLoadRoof = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlMinDistanceLoadWall = new treeDiM.StackBuilder.Basics.UCtrlDualDouble();
            this.chkbAllowMultipleLayers = new System.Windows.Forms.CheckBox();
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
            // lbPallets
            // 
            this.lbPallets.AutoSize = true;
            this.lbPallets.Location = new System.Drawing.Point(5, 68);
            this.lbPallets.Name = "lbPallets";
            this.lbPallets.Size = new System.Drawing.Size(76, 13);
            this.lbPallets.TabIndex = 15;
            this.lbPallets.Text = "Loaded pallets";
            // 
            // label1
            // 
            this.lbTrucks.AutoSize = true;
            this.lbTrucks.Location = new System.Drawing.Point(453, 68);
            this.lbTrucks.Name = "label1";
            this.lbTrucks.Size = new System.Drawing.Size(40, 13);
            this.lbTrucks.TabIndex = 16;
            this.lbTrucks.Text = "Trucks";
            // 
            // cbTrucks
            // 
            this.cbTrucks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrucks.FormattingEnabled = true;
            this.cbTrucks.Location = new System.Drawing.Point(548, 65);
            this.cbTrucks.Name = "cbTrucks";
            this.cbTrucks.Size = new System.Drawing.Size(148, 21);
            this.cbTrucks.TabIndex = 14;
            this.cbTrucks.SelectedIndexChanged += new System.EventHandler(this.onInputChanged);
            // 
            // cbPallets
            // 
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            this.cbPallets.Location = new System.Drawing.Point(104, 65);
            this.cbPallets.Name = "cbPallets";
            this.cbPallets.Size = new System.Drawing.Size(145, 21);
            this.cbPallets.TabIndex = 13;
            this.cbPallets.SelectedIndexChanged += new System.EventHandler(this.onInputChanged);
            // 
            // uCtrlLayerList
            // 
            this.uCtrlLayerList.AutoScroll = true;
            this.uCtrlLayerList.ButtonSizes = new System.Drawing.Size(150, 150);
            this.uCtrlLayerList.Location = new System.Drawing.Point(0, 149);
            this.uCtrlLayerList.Name = "uCtrlLayerList";
            this.uCtrlLayerList.Show3D = true;
            this.uCtrlLayerList.Size = new System.Drawing.Size(784, 351);
            this.uCtrlLayerList.TabIndex = 17;
            // 
            // checkBoxBestLayersOnly
            // 
            this.checkBoxBestLayersOnly.AutoSize = true;
            this.checkBoxBestLayersOnly.Location = new System.Drawing.Point(4, 517);
            this.checkBoxBestLayersOnly.Name = "checkBoxBestLayersOnly";
            this.checkBoxBestLayersOnly.Size = new System.Drawing.Size(128, 17);
            this.checkBoxBestLayersOnly.TabIndex = 18;
            this.checkBoxBestLayersOnly.Text = "Show best layers only";
            this.checkBoxBestLayersOnly.UseVisualStyleBackColor = true;
            this.checkBoxBestLayersOnly.CheckedChanged += new System.EventHandler(this.onInputChanged);
            // 
            // uCtrlMinDistLoadRoof
            // 
            this.uCtrlMinDistLoadRoof.Location = new System.Drawing.Point(5, 123);
            this.uCtrlMinDistLoadRoof.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlMinDistLoadRoof.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMinDistLoadRoof.Name = "uCtrlMinDistLoadRoof";
            this.uCtrlMinDistLoadRoof.Size = new System.Drawing.Size(355, 20);
            this.uCtrlMinDistLoadRoof.TabIndex = 19;
            this.uCtrlMinDistLoadRoof.Text = "Minimum distance load/roof";
            this.uCtrlMinDistLoadRoof.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMinDistLoadRoof.Value = 0D;
            // 
            // uCtrlMinDistanceLoadWall
            // 
            this.uCtrlMinDistanceLoadWall.Location = new System.Drawing.Point(5, 97);
            this.uCtrlMinDistanceLoadWall.Name = "uCtrlMinDistanceLoadWall";
            this.uCtrlMinDistanceLoadWall.Size = new System.Drawing.Size(355, 20);
            this.uCtrlMinDistanceLoadWall.TabIndex = 20;
            this.uCtrlMinDistanceLoadWall.Text = "Minimum distances load/wall";
            this.uCtrlMinDistanceLoadWall.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMinDistanceLoadWall.ValueX = 0D;
            this.uCtrlMinDistanceLoadWall.ValueY = 0D;
            // 
            // chkbAllowMultipleLayers
            // 
            this.chkbAllowMultipleLayers.AutoSize = true;
            this.chkbAllowMultipleLayers.Location = new System.Drawing.Point(456, 125);
            this.chkbAllowMultipleLayers.Name = "chkbAllowMultipleLayers";
            this.chkbAllowMultipleLayers.Size = new System.Drawing.Size(119, 17);
            this.chkbAllowMultipleLayers.TabIndex = 21;
            this.chkbAllowMultipleLayers.Text = "Allow multiple layers";
            this.chkbAllowMultipleLayers.UseVisualStyleBackColor = true;
            // 
            // FormNewAnalysisPalletTruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.chkbAllowMultipleLayers);
            this.Controls.Add(this.uCtrlMinDistanceLoadWall);
            this.Controls.Add(this.uCtrlMinDistLoadRoof);
            this.Controls.Add(this.checkBoxBestLayersOnly);
            this.Controls.Add(this.uCtrlLayerList);
            this.Controls.Add(this.lbTrucks);
            this.Controls.Add(this.lbPallets);
            this.Controls.Add(this.cbTrucks);
            this.Controls.Add(this.cbPallets);
            this.Name = "FormNewAnalysisPalletTruck";
            this.Text = "Create new pallet/truck analysis...";
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.cbPallets, 0);
            this.Controls.SetChildIndex(this.cbTrucks, 0);
            this.Controls.SetChildIndex(this.lbPallets, 0);
            this.Controls.SetChildIndex(this.lbTrucks, 0);
            this.Controls.SetChildIndex(this.uCtrlLayerList, 0);
            this.Controls.SetChildIndex(this.checkBoxBestLayersOnly, 0);
            this.Controls.SetChildIndex(this.uCtrlMinDistLoadRoof, 0);
            this.Controls.SetChildIndex(this.uCtrlMinDistanceLoadWall, 0);
            this.Controls.SetChildIndex(this.chkbAllowMultipleLayers, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Graphics.Controls.CCtrlComboFiltered cbPallets;
        private Graphics.Controls.CCtrlComboFiltered cbTrucks;
        private System.Windows.Forms.Label lbPallets;
        private System.Windows.Forms.Label lbTrucks;
        private Graphics.UCtrlLayerList uCtrlLayerList;
        private System.Windows.Forms.CheckBox checkBoxBestLayersOnly;
        private Basics.UCtrlDouble uCtrlMinDistLoadRoof;
        private Basics.UCtrlDualDouble uCtrlMinDistanceLoadWall;
        private System.Windows.Forms.CheckBox chkbAllowMultipleLayers;
    }
}