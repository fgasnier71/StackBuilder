namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewPalletLabel
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
            this.uCtrlDimensions = new treeDiM.Basics.UCtrlDualDouble();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbColor = new System.Windows.Forms.Label();
            this.bnLoadImage = new System.Windows.Forms.Button();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uCtrlWeight = new treeDiM.Basics.UCtrlDouble();
            this.bnRemoveImage = new System.Windows.Forms.Button();
            this.lbImage = new System.Windows.Forms.Label();
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
            // uCtrlDimensions
            // 
            this.uCtrlDimensions.Location = new System.Drawing.Point(15, 88);
            this.uCtrlDimensions.MinValue = -10000D;
            this.uCtrlDimensions.Name = "uCtrlDimensions";
            this.uCtrlDimensions.Size = new System.Drawing.Size(256, 20);
            this.uCtrlDimensions.TabIndex = 7;
            this.uCtrlDimensions.Text = "Dimensions";
            this.uCtrlDimensions.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDimensions.ValueX = 0D;
            this.uCtrlDimensions.ValueY = 0D;
            // 
            // cbColor
            // 
            this.cbColor.Color = System.Drawing.Color.White;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.IntegralHeight = false;
            this.cbColor.ItemHeight = 16;
            this.cbColor.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color"});
            this.cbColor.Location = new System.Drawing.Point(111, 246);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(62, 22);
            this.cbColor.TabIndex = 8;
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.OnColorChanged);
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(15, 249);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(31, 13);
            this.lbColor.TabIndex = 9;
            this.lbColor.Text = "Color";
            // 
            // bnLoadImage
            // 
            this.bnLoadImage.Location = new System.Drawing.Point(111, 274);
            this.bnLoadImage.Name = "bnLoadImage";
            this.bnLoadImage.Size = new System.Drawing.Size(79, 23);
            this.bnLoadImage.TabIndex = 10;
            this.bnLoadImage.Text = "Load...";
            this.bnLoadImage.UseVisualStyleBackColor = true;
            this.bnLoadImage.Click += new System.EventHandler(this.OnLoadImage);
            // 
            // graphCtrl
            // 
            this.graphCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphCtrl.Location = new System.Drawing.Point(278, 88);
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.Size = new System.Drawing.Size(302, 209);
            this.graphCtrl.TabIndex = 11;
            this.graphCtrl.Viewer = null;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Images (*.bmp;*jpg;*.png)|*.bmp;*.jpg;*.png|All files (*.*)|*.*";
            this.openFileDialog.FilterIndex = 0;
            // 
            // uCtrlWeight
            // 
            this.uCtrlWeight.Location = new System.Drawing.Point(15, 115);
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
            this.uCtrlWeight.Size = new System.Drawing.Size(256, 20);
            this.uCtrlWeight.TabIndex = 12;
            this.uCtrlWeight.Text = "Weight";
            this.uCtrlWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            // 
            // bnRemoveImage
            // 
            this.bnRemoveImage.Location = new System.Drawing.Point(196, 274);
            this.bnRemoveImage.Name = "bnRemoveImage";
            this.bnRemoveImage.Size = new System.Drawing.Size(75, 23);
            this.bnRemoveImage.TabIndex = 13;
            this.bnRemoveImage.Text = "Remove";
            this.bnRemoveImage.UseVisualStyleBackColor = true;
            this.bnRemoveImage.Click += new System.EventHandler(this.OnRemoveImage);
            // 
            // lbImage
            // 
            this.lbImage.AutoSize = true;
            this.lbImage.Location = new System.Drawing.Point(15, 279);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(36, 13);
            this.lbImage.TabIndex = 14;
            this.lbImage.Text = "Image";
            // 
            // FormNewPalletLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.lbImage);
            this.Controls.Add(this.bnRemoveImage);
            this.Controls.Add(this.uCtrlWeight);
            this.Controls.Add(this.graphCtrl);
            this.Controls.Add(this.bnLoadImage);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.uCtrlDimensions);
            this.Name = "FormNewPalletLabel";
            this.Text = "Create new label...";
            this.Controls.SetChildIndex(this.bnOk, 0);
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.uCtrlDimensions, 0);
            this.Controls.SetChildIndex(this.cbColor, 0);
            this.Controls.SetChildIndex(this.lbColor, 0);
            this.Controls.SetChildIndex(this.bnLoadImage, 0);
            this.Controls.SetChildIndex(this.graphCtrl, 0);
            this.Controls.SetChildIndex(this.uCtrlWeight, 0);
            this.Controls.SetChildIndex(this.bnRemoveImage, 0);
            this.Controls.SetChildIndex(this.lbImage, 0);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private treeDiM.Basics.UCtrlDualDouble uCtrlDimensions;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Button bnLoadImage;
        private Graphics.Graphics3DControl graphCtrl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private treeDiM.Basics.UCtrlDouble uCtrlWeight;
        private System.Windows.Forms.Button bnRemoveImage;
        private System.Windows.Forms.Label lbImage;
    }
}