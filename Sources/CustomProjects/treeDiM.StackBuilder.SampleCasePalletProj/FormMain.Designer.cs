namespace treeDiM.StackBuilder.SampleCasePalletProj
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.gbCase = new System.Windows.Forms.GroupBox();
            this.uCtrlCaseWeight = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlTriCaseDim = new treeDiM.Basics.UCtrlTriDouble();
            this.gbPallet = new System.Windows.Forms.GroupBox();
            this.uCtrlPalletWeight = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlPalletDim = new treeDiM.Basics.UCtrlTriDouble();
            this.gbConstraints = new System.Windows.Forms.GroupBox();
            this.uCtrlOverhang = new treeDiM.Basics.UCtrlDualDouble();
            this.chkbZ = new System.Windows.Forms.CheckBox();
            this.chkbY = new System.Windows.Forms.CheckBox();
            this.chkbX = new System.Windows.Forms.CheckBox();
            this.uCtrlMaxNumber = new treeDiM.Basics.UCtrlOptInt();
            this.uCtrlMaxHeight = new treeDiM.Basics.UCtrlDouble();
            this.gbLayer = new System.Windows.Forms.GroupBox();
            this.chkbAlternateLayers = new System.Windows.Forms.CheckBox();
            this.chkbBestLayers = new System.Windows.Forms.CheckBox();
            this.cbLayers = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboLayer();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.rtbResults = new System.Windows.Forms.RichTextBox();
            this.pbPalletization = new System.Windows.Forms.PictureBox();
            this.bnLayerImage = new System.Windows.Forms.Button();
            this.gbCase.SuspendLayout();
            this.gbPallet.SuspendLayout();
            this.gbConstraints.SuspendLayout();
            this.gbLayer.SuspendLayout();
            this.gbResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPalletization)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCase
            // 
            this.gbCase.Controls.Add(this.uCtrlCaseWeight);
            this.gbCase.Controls.Add(this.uCtrlTriCaseDim);
            this.gbCase.Location = new System.Drawing.Point(5, 5);
            this.gbCase.Name = "gbCase";
            this.gbCase.Size = new System.Drawing.Size(362, 75);
            this.gbCase.TabIndex = 1;
            this.gbCase.TabStop = false;
            this.gbCase.Text = "Case";
            // 
            // uCtrlCaseWeight
            // 
            this.uCtrlCaseWeight.Location = new System.Drawing.Point(7, 47);
            this.uCtrlCaseWeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlCaseWeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlCaseWeight.Name = "uCtrlCaseWeight";
            this.uCtrlCaseWeight.Size = new System.Drawing.Size(340, 20);
            this.uCtrlCaseWeight.TabIndex = 1;
            this.uCtrlCaseWeight.Text = "Weight";
            this.uCtrlCaseWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlCaseWeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnInputChanged);
            // 
            // uCtrlTriCaseDim
            // 
            this.uCtrlTriCaseDim.Location = new System.Drawing.Point(7, 20);
            this.uCtrlTriCaseDim.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlTriCaseDim.Name = "uCtrlTriCaseDim";
            this.uCtrlTriCaseDim.Size = new System.Drawing.Size(340, 20);
            this.uCtrlTriCaseDim.TabIndex = 0;
            this.uCtrlTriCaseDim.Text = "Dimensions";
            this.uCtrlTriCaseDim.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlTriCaseDim.ValueX = 0D;
            this.uCtrlTriCaseDim.ValueY = 0D;
            this.uCtrlTriCaseDim.ValueZ = 0D;
            this.uCtrlTriCaseDim.ValueChanged += new treeDiM.Basics.UCtrlTriDouble.ValueChangedDelegate(this.OnInputChanged);
            // 
            // gbPallet
            // 
            this.gbPallet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPallet.Controls.Add(this.uCtrlPalletWeight);
            this.gbPallet.Controls.Add(this.uCtrlPalletDim);
            this.gbPallet.Location = new System.Drawing.Point(374, 5);
            this.gbPallet.Name = "gbPallet";
            this.gbPallet.Size = new System.Drawing.Size(404, 75);
            this.gbPallet.TabIndex = 2;
            this.gbPallet.TabStop = false;
            this.gbPallet.Text = "Pallet";
            // 
            // uCtrlPalletWeight
            // 
            this.uCtrlPalletWeight.Location = new System.Drawing.Point(7, 47);
            this.uCtrlPalletWeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlPalletWeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlPalletWeight.Name = "uCtrlPalletWeight";
            this.uCtrlPalletWeight.Size = new System.Drawing.Size(312, 20);
            this.uCtrlPalletWeight.TabIndex = 1;
            this.uCtrlPalletWeight.Text = "Weight";
            this.uCtrlPalletWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlPalletWeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnInputChanged);
            // 
            // uCtrlPalletDim
            // 
            this.uCtrlPalletDim.Location = new System.Drawing.Point(7, 19);
            this.uCtrlPalletDim.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlPalletDim.Name = "uCtrlPalletDim";
            this.uCtrlPalletDim.Size = new System.Drawing.Size(312, 20);
            this.uCtrlPalletDim.TabIndex = 0;
            this.uCtrlPalletDim.Text = "Dimensions";
            this.uCtrlPalletDim.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlPalletDim.ValueX = 0D;
            this.uCtrlPalletDim.ValueY = 0D;
            this.uCtrlPalletDim.ValueZ = 0D;
            this.uCtrlPalletDim.ValueChanged += new treeDiM.Basics.UCtrlTriDouble.ValueChangedDelegate(this.OnInputChanged);
            // 
            // gbConstraints
            // 
            this.gbConstraints.Controls.Add(this.uCtrlOverhang);
            this.gbConstraints.Controls.Add(this.chkbZ);
            this.gbConstraints.Controls.Add(this.chkbY);
            this.gbConstraints.Controls.Add(this.chkbX);
            this.gbConstraints.Controls.Add(this.uCtrlMaxNumber);
            this.gbConstraints.Controls.Add(this.uCtrlMaxHeight);
            this.gbConstraints.Location = new System.Drawing.Point(5, 86);
            this.gbConstraints.Name = "gbConstraints";
            this.gbConstraints.Size = new System.Drawing.Size(362, 110);
            this.gbConstraints.TabIndex = 3;
            this.gbConstraints.TabStop = false;
            this.gbConstraints.Text = "Constraints";
            // 
            // uCtrlOverhang
            // 
            this.uCtrlOverhang.Location = new System.Drawing.Point(7, 15);
            this.uCtrlOverhang.MinValue = -10000D;
            this.uCtrlOverhang.Name = "uCtrlOverhang";
            this.uCtrlOverhang.Size = new System.Drawing.Size(340, 20);
            this.uCtrlOverhang.TabIndex = 5;
            this.uCtrlOverhang.Text = "Overhang";
            this.uCtrlOverhang.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOverhang.ValueX = 0D;
            this.uCtrlOverhang.ValueY = 0D;
            this.uCtrlOverhang.ValueChanged += new treeDiM.Basics.UCtrlDualDouble.ValueChangedDelegate(this.OnInputChanged);
            // 
            // chkbZ
            // 
            this.chkbZ.AutoSize = true;
            this.chkbZ.Checked = true;
            this.chkbZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbZ.Location = new System.Drawing.Point(87, 89);
            this.chkbZ.Name = "chkbZ";
            this.chkbZ.Size = new System.Drawing.Size(33, 17);
            this.chkbZ.TabIndex = 4;
            this.chkbZ.Text = "Z";
            this.chkbZ.UseVisualStyleBackColor = true;
            this.chkbZ.CheckedChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // chkbY
            // 
            this.chkbY.AutoSize = true;
            this.chkbY.Checked = true;
            this.chkbY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbY.Location = new System.Drawing.Point(47, 89);
            this.chkbY.Name = "chkbY";
            this.chkbY.Size = new System.Drawing.Size(33, 17);
            this.chkbY.TabIndex = 3;
            this.chkbY.Text = "Y";
            this.chkbY.UseVisualStyleBackColor = true;
            this.chkbY.CheckedChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // chkbX
            // 
            this.chkbX.AutoSize = true;
            this.chkbX.Checked = true;
            this.chkbX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbX.Location = new System.Drawing.Point(7, 89);
            this.chkbX.Name = "chkbX";
            this.chkbX.Size = new System.Drawing.Size(33, 17);
            this.chkbX.TabIndex = 2;
            this.chkbX.Text = "X";
            this.chkbX.UseVisualStyleBackColor = true;
            this.chkbX.CheckedChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // uCtrlMaxNumber
            // 
            this.uCtrlMaxNumber.Location = new System.Drawing.Point(7, 65);
            this.uCtrlMaxNumber.Minimum = -10000;
            this.uCtrlMaxNumber.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMaxNumber.Name = "uCtrlMaxNumber";
            this.uCtrlMaxNumber.Size = new System.Drawing.Size(340, 20);
            this.uCtrlMaxNumber.TabIndex = 1;
            this.uCtrlMaxNumber.Text = "Maximum number";
            this.uCtrlMaxNumber.ValueChanged += new treeDiM.Basics.UCtrlOptInt.ValueChangedDelegate(this.OnInputChanged);
            // 
            // uCtrlMaxHeight
            // 
            this.uCtrlMaxHeight.Location = new System.Drawing.Point(7, 40);
            this.uCtrlMaxHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMaxHeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMaxHeight.Name = "uCtrlMaxHeight";
            this.uCtrlMaxHeight.Size = new System.Drawing.Size(340, 20);
            this.uCtrlMaxHeight.TabIndex = 0;
            this.uCtrlMaxHeight.Text = "Maximum pallet height";
            this.uCtrlMaxHeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMaxHeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnInputChanged);
            // 
            // gbLayer
            // 
            this.gbLayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLayer.Controls.Add(this.bnLayerImage);
            this.gbLayer.Controls.Add(this.chkbAlternateLayers);
            this.gbLayer.Controls.Add(this.chkbBestLayers);
            this.gbLayer.Controls.Add(this.cbLayers);
            this.gbLayer.Location = new System.Drawing.Point(375, 86);
            this.gbLayer.Name = "gbLayer";
            this.gbLayer.Size = new System.Drawing.Size(403, 110);
            this.gbLayer.TabIndex = 4;
            this.gbLayer.TabStop = false;
            this.gbLayer.Text = "Layers";
            // 
            // chkbAlternateLayers
            // 
            this.chkbAlternateLayers.AutoSize = true;
            this.chkbAlternateLayers.Checked = true;
            this.chkbAlternateLayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbAlternateLayers.Location = new System.Drawing.Point(147, 40);
            this.chkbAlternateLayers.Name = "chkbAlternateLayers";
            this.chkbAlternateLayers.Size = new System.Drawing.Size(98, 17);
            this.chkbAlternateLayers.TabIndex = 3;
            this.chkbAlternateLayers.Text = "Alternate layers";
            this.chkbAlternateLayers.UseVisualStyleBackColor = true;
            this.chkbAlternateLayers.CheckedChanged += new System.EventHandler(this.OnSelectedLayerChanged);
            // 
            // chkbBestLayers
            // 
            this.chkbBestLayers.AutoSize = true;
            this.chkbBestLayers.Location = new System.Drawing.Point(147, 19);
            this.chkbBestLayers.Name = "chkbBestLayers";
            this.chkbBestLayers.Size = new System.Drawing.Size(128, 17);
            this.chkbBestLayers.TabIndex = 2;
            this.chkbBestLayers.Text = "Show best layers only";
            this.chkbBestLayers.UseVisualStyleBackColor = true;
            this.chkbBestLayers.CheckedChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // cbLayers
            // 
            this.cbLayers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLayers.FormattingEnabled = true;
            this.cbLayers.ItemHeight = 80;
            this.cbLayers.Location = new System.Drawing.Point(6, 19);
            this.cbLayers.Name = "cbLayers";
            this.cbLayers.Size = new System.Drawing.Size(121, 86);
            this.cbLayers.TabIndex = 1;
            this.cbLayers.SelectedIndexChanged += new System.EventHandler(this.OnSelectedLayerChanged);
            // 
            // gbResults
            // 
            this.gbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResults.Controls.Add(this.rtbResults);
            this.gbResults.Controls.Add(this.pbPalletization);
            this.gbResults.Location = new System.Drawing.Point(7, 202);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(771, 507);
            this.gbResults.TabIndex = 5;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Results";
            // 
            // rtbResults
            // 
            this.rtbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbResults.Location = new System.Drawing.Point(580, 12);
            this.rtbResults.Name = "rtbResults";
            this.rtbResults.ReadOnly = true;
            this.rtbResults.Size = new System.Drawing.Size(185, 489);
            this.rtbResults.TabIndex = 1;
            this.rtbResults.Text = "";
            // 
            // pbPalletization
            // 
            this.pbPalletization.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPalletization.Location = new System.Drawing.Point(7, 12);
            this.pbPalletization.Name = "pbPalletization";
            this.pbPalletization.Size = new System.Drawing.Size(567, 489);
            this.pbPalletization.TabIndex = 0;
            this.pbPalletization.TabStop = false;
            // 
            // bnLayerImage
            // 
            this.bnLayerImage.Location = new System.Drawing.Point(147, 81);
            this.bnLayerImage.Name = "bnLayerImage";
            this.bnLayerImage.Size = new System.Drawing.Size(154, 23);
            this.bnLayerImage.TabIndex = 4;
            this.bnLayerImage.Text = "Generate layer image";
            this.bnLayerImage.UseVisualStyleBackColor = true;
            this.bnLayerImage.Click += new System.EventHandler(this.OnGenerateLayerImage);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 711);
            this.Controls.Add(this.gbResults);
            this.Controls.Add(this.gbLayer);
            this.Controls.Add(this.gbConstraints);
            this.Controls.Add(this.gbPallet);
            this.Controls.Add(this.gbCase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 750);
            this.Name = "FormMain";
            this.Text = "Sample case/pallet palletization...";
            this.gbCase.ResumeLayout(false);
            this.gbPallet.ResumeLayout(false);
            this.gbConstraints.ResumeLayout(false);
            this.gbConstraints.PerformLayout();
            this.gbLayer.ResumeLayout(false);
            this.gbLayer.PerformLayout();
            this.gbResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPalletization)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbCase;
        private treeDiM.Basics.UCtrlDouble uCtrlCaseWeight;
        private treeDiM.Basics.UCtrlTriDouble uCtrlTriCaseDim;
        private System.Windows.Forms.GroupBox gbPallet;
        private treeDiM.Basics.UCtrlDouble uCtrlPalletWeight;
        private treeDiM.Basics.UCtrlTriDouble uCtrlPalletDim;
        private System.Windows.Forms.GroupBox gbConstraints;
        private System.Windows.Forms.GroupBox gbLayer;
        private Graphics.Controls.CCtrlComboLayer cbLayers;
        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.RichTextBox rtbResults;
        private System.Windows.Forms.PictureBox pbPalletization;
        private treeDiM.Basics.UCtrlOptInt uCtrlMaxNumber;
        private treeDiM.Basics.UCtrlDouble uCtrlMaxHeight;
        private System.Windows.Forms.CheckBox chkbX;
        private System.Windows.Forms.CheckBox chkbZ;
        private System.Windows.Forms.CheckBox chkbY;
        private System.Windows.Forms.CheckBox chkbBestLayers;
        private treeDiM.Basics.UCtrlDualDouble uCtrlOverhang;
        private System.Windows.Forms.CheckBox chkbAlternateLayers;
        private System.Windows.Forms.Button bnLayerImage;
    }
}

