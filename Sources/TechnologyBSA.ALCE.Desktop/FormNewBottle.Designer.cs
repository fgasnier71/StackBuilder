namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewBottle
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
            this.uCtrlNetWeight = new treeDiM.Basics.UCtrlOptDouble();
            this.gbWeight = new System.Windows.Forms.GroupBox();
            this.uCtrlWeight = new treeDiM.Basics.UCtrlDouble();
            this.lbColor = new System.Windows.Forms.Label();
            this.cbColorTop = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.gridProfile = new SourceGrid.Grid();
            this.bnInsert = new System.Windows.Forms.Button();
            this.bnRemove = new System.Windows.Forms.Button();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.cbBottleType = new System.Windows.Forms.ComboBox();
            this.bnInitialize = new System.Windows.Forms.Button();
            this.lbMaxDiameter = new System.Windows.Forms.Label();
            this.lbMaxDiameterValue = new System.Windows.Forms.Label();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbHeightValue = new System.Windows.Forms.Label();
            this.gbWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // bnOk
            // 
            this.bnOk.Location = new System.Drawing.Point(505, 10);
            // 
            // bnCancel
            // 
            this.bnCancel.Location = new System.Drawing.Point(505, 38);
            // 
            // tbDescription
            // 
            this.tbDescription.Size = new System.Drawing.Size(384, 20);
            // 
            // uCtrlNetWeight
            // 
            this.uCtrlNetWeight.Location = new System.Drawing.Point(9, 35);
            this.uCtrlNetWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlNetWeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlNetWeight.Name = "uCtrlNetWeight";
            this.uCtrlNetWeight.Size = new System.Drawing.Size(221, 20);
            this.uCtrlNetWeight.TabIndex = 1;
            this.uCtrlNetWeight.Text = "Net weight";
            this.uCtrlNetWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            // 
            // gbWeight
            // 
            this.gbWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbWeight.Controls.Add(this.uCtrlNetWeight);
            this.gbWeight.Controls.Add(this.uCtrlWeight);
            this.gbWeight.Location = new System.Drawing.Point(4, 375);
            this.gbWeight.Name = "gbWeight";
            this.gbWeight.Size = new System.Drawing.Size(252, 59);
            this.gbWeight.TabIndex = 24;
            this.gbWeight.TabStop = false;
            this.gbWeight.Text = "Weight";
            // 
            // uCtrlWeight
            // 
            this.uCtrlWeight.Location = new System.Drawing.Point(9, 12);
            this.uCtrlWeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.uCtrlWeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlWeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlWeight.Name = "uCtrlWeight";
            this.uCtrlWeight.Size = new System.Drawing.Size(221, 20);
            this.uCtrlWeight.TabIndex = 0;
            this.uCtrlWeight.Text = "Weight";
            this.uCtrlWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            // 
            // lbColor
            // 
            this.lbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(12, 356);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(31, 13);
            this.lbColor.TabIndex = 25;
            this.lbColor.Text = "Color";
            // 
            // cbColorTop
            // 
            this.cbColorTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbColorTop.Color = System.Drawing.Color.SkyBlue;
            this.cbColorTop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColorTop.DropDownHeight = 1;
            this.cbColorTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorTop.DropDownWidth = 1;
            this.cbColorTop.IntegralHeight = false;
            this.cbColorTop.ItemHeight = 16;
            this.cbColorTop.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color"});
            this.cbColorTop.Location = new System.Drawing.Point(131, 347);
            this.cbColorTop.Name = "cbColorTop";
            this.cbColorTop.Size = new System.Drawing.Size(75, 22);
            this.cbColorTop.TabIndex = 26;
            this.cbColorTop.SelectedColorChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // gridProfile
            // 
            this.gridProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridProfile.EnableSort = true;
            this.gridProfile.Location = new System.Drawing.Point(4, 93);
            this.gridProfile.Name = "gridProfile";
            this.gridProfile.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridProfile.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridProfile.Size = new System.Drawing.Size(252, 170);
            this.gridProfile.TabIndex = 27;
            this.gridProfile.TabStop = true;
            this.gridProfile.ToolTipText = "";
            // 
            // bnInsert
            // 
            this.bnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnInsert.Location = new System.Drawing.Point(4, 270);
            this.bnInsert.Name = "bnInsert";
            this.bnInsert.Size = new System.Drawing.Size(75, 23);
            this.bnInsert.TabIndex = 28;
            this.bnInsert.Text = "Insert";
            this.bnInsert.UseVisualStyleBackColor = true;
            this.bnInsert.Click += new System.EventHandler(this.OnRowInsert);
            // 
            // bnRemove
            // 
            this.bnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnRemove.Location = new System.Drawing.Point(85, 269);
            this.bnRemove.Name = "bnRemove";
            this.bnRemove.Size = new System.Drawing.Size(75, 23);
            this.bnRemove.TabIndex = 29;
            this.bnRemove.Text = "Remove";
            this.bnRemove.UseVisualStyleBackColor = true;
            this.bnRemove.Click += new System.EventHandler(this.OnRowRemove);
            // 
            // graphCtrl
            // 
            this.graphCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphCtrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.graphCtrl.Location = new System.Drawing.Point(262, 64);
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.Size = new System.Drawing.Size(318, 334);
            this.graphCtrl.TabIndex = 22;
            this.graphCtrl.TabStop = false;
            this.graphCtrl.Viewer = null;
            // 
            // cbBottleType
            // 
            this.cbBottleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBottleType.FormattingEnabled = true;
            this.cbBottleType.Items.AddRange(new object[] {
            "Wine 1",
            "Wine 2",
            "Milk",
            "Water",
            "Coca-Cola can"});
            this.cbBottleType.Location = new System.Drawing.Point(4, 64);
            this.cbBottleType.Name = "cbBottleType";
            this.cbBottleType.Size = new System.Drawing.Size(146, 21);
            this.cbBottleType.TabIndex = 30;
            // 
            // bnInitialize
            // 
            this.bnInitialize.Location = new System.Drawing.Point(156, 64);
            this.bnInitialize.Name = "bnInitialize";
            this.bnInitialize.Size = new System.Drawing.Size(100, 23);
            this.bnInitialize.TabIndex = 31;
            this.bnInitialize.Text = "Initialize";
            this.bnInitialize.UseVisualStyleBackColor = true;
            this.bnInitialize.Click += new System.EventHandler(this.OnInitialize);
            // 
            // lbMaxDiameter
            // 
            this.lbMaxDiameter.AutoSize = true;
            this.lbMaxDiameter.Location = new System.Drawing.Point(10, 296);
            this.lbMaxDiameter.Name = "lbMaxDiameter";
            this.lbMaxDiameter.Size = new System.Drawing.Size(94, 13);
            this.lbMaxDiameter.TabIndex = 32;
            this.lbMaxDiameter.Text = "Maximum diameter";
            // 
            // lbMaxDiameterValue
            // 
            this.lbMaxDiameterValue.AutoSize = true;
            this.lbMaxDiameterValue.Location = new System.Drawing.Point(156, 296);
            this.lbMaxDiameterValue.Name = "lbMaxDiameterValue";
            this.lbMaxDiameterValue.Size = new System.Drawing.Size(47, 13);
            this.lbMaxDiameterValue.TabIndex = 33;
            this.lbMaxDiameterValue.Text = ": 0.0 mm";
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(10, 313);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(38, 13);
            this.lbHeight.TabIndex = 34;
            this.lbHeight.Text = "Height";
            // 
            // lbHeightValue
            // 
            this.lbHeightValue.AutoSize = true;
            this.lbHeightValue.Location = new System.Drawing.Point(156, 313);
            this.lbHeightValue.Name = "lbHeightValue";
            this.lbHeightValue.Size = new System.Drawing.Size(47, 13);
            this.lbHeightValue.TabIndex = 35;
            this.lbHeightValue.Text = ": 0.0 mm";
            // 
            // FormNewBottle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.lbHeightValue);
            this.Controls.Add(this.lbHeight);
            this.Controls.Add(this.lbMaxDiameterValue);
            this.Controls.Add(this.lbMaxDiameter);
            this.Controls.Add(this.bnInitialize);
            this.Controls.Add(this.cbBottleType);
            this.Controls.Add(this.bnRemove);
            this.Controls.Add(this.bnInsert);
            this.Controls.Add(this.gridProfile);
            this.Controls.Add(this.cbColorTop);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.gbWeight);
            this.Controls.Add(this.graphCtrl);
            this.Name = "FormNewBottle";
            this.Text = "Define a new bottle...";
            this.Controls.SetChildIndex(this.bnOk, 0);
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.graphCtrl, 0);
            this.Controls.SetChildIndex(this.gbWeight, 0);
            this.Controls.SetChildIndex(this.lbColor, 0);
            this.Controls.SetChildIndex(this.cbColorTop, 0);
            this.Controls.SetChildIndex(this.gridProfile, 0);
            this.Controls.SetChildIndex(this.bnInsert, 0);
            this.Controls.SetChildIndex(this.bnRemove, 0);
            this.Controls.SetChildIndex(this.cbBottleType, 0);
            this.Controls.SetChildIndex(this.bnInitialize, 0);
            this.Controls.SetChildIndex(this.lbMaxDiameter, 0);
            this.Controls.SetChildIndex(this.lbMaxDiameterValue, 0);
            this.Controls.SetChildIndex(this.lbHeight, 0);
            this.Controls.SetChildIndex(this.lbHeightValue, 0);
            this.gbWeight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Graphics.Graphics3DControl graphCtrl;
        private treeDiM.Basics.UCtrlOptDouble uCtrlNetWeight;
        private System.Windows.Forms.GroupBox gbWeight;
        private treeDiM.Basics.UCtrlDouble uCtrlWeight;
        private System.Windows.Forms.Label lbColor;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColorTop;
        private SourceGrid.Grid gridProfile;
        private System.Windows.Forms.Button bnInsert;
        private System.Windows.Forms.Button bnRemove;
        private System.Windows.Forms.ComboBox cbBottleType;
        private System.Windows.Forms.Button bnInitialize;
        private System.Windows.Forms.Label lbMaxDiameter;
        private System.Windows.Forms.Label lbMaxDiameterValue;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbHeightValue;
    }
}