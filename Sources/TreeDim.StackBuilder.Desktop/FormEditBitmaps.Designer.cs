namespace treeDiM.StackBuilder.Desktop
{
    partial class FormEditBitmaps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditBitmaps));
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.labelFace = new System.Windows.Forms.Label();
            this.cbFace = new System.Windows.Forms.ComboBox();
            this.lbAngle = new System.Windows.Forms.Label();
            this.nudAngle = new System.Windows.Forms.NumericUpDown();
            this.lbUnitAngle = new System.Windows.Forms.Label();
            this.bnMoveUp = new System.Windows.Forms.Button();
            this.bnMoveDown = new System.Windows.Forms.Button();
            this.bnAdd = new System.Windows.Forms.Button();
            this.bnRemove = new System.Windows.Forms.Button();
            this.openImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listBoxTextures = new treeDiM.StackBuilder.Desktop.ListBoxImages();
            this.lbImage = new System.Windows.Forms.Label();
            this.uCtrlOrigin = new treeDiM.StackBuilder.Basics.UCtrlDualDouble();
            this.uCtrlSize = new treeDiM.StackBuilder.Basics.UCtrlDualDouble();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // bnOK
            // 
            resources.ApplyResources(this.bnOK, "bnOK");
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Name = "bnOK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // labelFace
            // 
            resources.ApplyResources(this.labelFace, "labelFace");
            this.labelFace.Name = "labelFace";
            // 
            // cbFace
            // 
            this.cbFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFace.FormattingEnabled = true;
            this.cbFace.Items.AddRange(new object[] {
            resources.GetString("cbFace.Items"),
            resources.GetString("cbFace.Items1"),
            resources.GetString("cbFace.Items2"),
            resources.GetString("cbFace.Items3"),
            resources.GetString("cbFace.Items4"),
            resources.GetString("cbFace.Items5")});
            resources.ApplyResources(this.cbFace, "cbFace");
            this.cbFace.Name = "cbFace";
            this.cbFace.SelectedIndexChanged += new System.EventHandler(this.OnSelectedFaceChanged);
            // 
            // lbAngle
            // 
            resources.ApplyResources(this.lbAngle, "lbAngle");
            this.lbAngle.Name = "lbAngle";
            // 
            // nudAngle
            // 
            resources.ApplyResources(this.nudAngle, "nudAngle");
            this.nudAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAngle.Name = "nudAngle";
            this.nudAngle.ValueChanged += new System.EventHandler(this.OnTexturePositionChanged);
            // 
            // lbUnitAngle
            // 
            resources.ApplyResources(this.lbUnitAngle, "lbUnitAngle");
            this.lbUnitAngle.Name = "lbUnitAngle";
            // 
            // bnMoveUp
            // 
            resources.ApplyResources(this.bnMoveUp, "bnMoveUp");
            this.bnMoveUp.Name = "bnMoveUp";
            this.bnMoveUp.UseVisualStyleBackColor = true;
            this.bnMoveUp.Click += new System.EventHandler(this.OnBnMoveUpDown);
            // 
            // bnMoveDown
            // 
            resources.ApplyResources(this.bnMoveDown, "bnMoveDown");
            this.bnMoveDown.Name = "bnMoveDown";
            this.bnMoveDown.UseVisualStyleBackColor = true;
            this.bnMoveDown.Click += new System.EventHandler(this.OnBnMoveUpDown);
            // 
            // bnAdd
            // 
            resources.ApplyResources(this.bnAdd, "bnAdd");
            this.bnAdd.Name = "bnAdd";
            this.bnAdd.UseVisualStyleBackColor = true;
            this.bnAdd.Click += new System.EventHandler(this.OnBnAdd);
            // 
            // bnRemove
            // 
            resources.ApplyResources(this.bnRemove, "bnRemove");
            this.bnRemove.Name = "bnRemove";
            this.bnRemove.UseVisualStyleBackColor = true;
            this.bnRemove.Click += new System.EventHandler(this.OnBnRemove);
            // 
            // openImageFileDialog
            // 
            this.openImageFileDialog.AddExtension = false;
            this.openImageFileDialog.DefaultExt = "jpg";
            resources.ApplyResources(this.openImageFileDialog, "openImageFileDialog");
            // 
            // listBoxTextures
            // 
            this.listBoxTextures.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            resources.ApplyResources(this.listBoxTextures, "listBoxTextures");
            this.listBoxTextures.Name = "listBoxTextures";
            this.listBoxTextures.SelectedIndexChanged += new System.EventHandler(this.OnSelectedTextureChanged);
            // 
            // lbImage
            // 
            resources.ApplyResources(this.lbImage, "lbImage");
            this.lbImage.Name = "lbImage";
            // 
            // uCtrlOrigin
            // 
            resources.ApplyResources(this.uCtrlOrigin, "uCtrlOrigin");
            this.uCtrlOrigin.MinValue = -10000D;
            this.uCtrlOrigin.Name = "uCtrlOrigin";
            this.uCtrlOrigin.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOrigin.ValueX = 0D;
            this.uCtrlOrigin.ValueY = 0D;
            this.uCtrlOrigin.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDualDouble.ValueChangedDelegate(this.OnTexturePositionChanged);
            // 
            // uCtrlSize
            // 
            resources.ApplyResources(this.uCtrlSize, "uCtrlSize");
            this.uCtrlSize.MinValue = -10000D;
            this.uCtrlSize.Name = "uCtrlSize";
            this.uCtrlSize.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlSize.ValueX = 0D;
            this.uCtrlSize.ValueY = 0D;
            this.uCtrlSize.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDualDouble.ValueChangedDelegate(this.OnTexturePositionChanged);
            // 
            // graphCtrl
            // 
            resources.ApplyResources(this.graphCtrl, "graphCtrl");
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.Viewer = null;
            // 
            // FormEditBitmaps
            // 
            this.AcceptButton = this.bnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.graphCtrl);
            this.Controls.Add(this.uCtrlSize);
            this.Controls.Add(this.uCtrlOrigin);
            this.Controls.Add(this.lbImage);
            this.Controls.Add(this.bnRemove);
            this.Controls.Add(this.bnAdd);
            this.Controls.Add(this.bnMoveDown);
            this.Controls.Add(this.bnMoveUp);
            this.Controls.Add(this.lbUnitAngle);
            this.Controls.Add(this.nudAngle);
            this.Controls.Add(this.lbAngle);
            this.Controls.Add(this.listBoxTextures);
            this.Controls.Add(this.cbFace);
            this.Controls.Add(this.labelFace);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditBitmaps";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label labelFace;
        private System.Windows.Forms.ComboBox cbFace;
        private treeDiM.StackBuilder.Desktop.ListBoxImages listBoxTextures;
        private System.Windows.Forms.Label lbAngle;
        private System.Windows.Forms.NumericUpDown nudAngle;
        private System.Windows.Forms.Label lbUnitAngle;
        private System.Windows.Forms.Button bnMoveUp;
        private System.Windows.Forms.Button bnMoveDown;
        private System.Windows.Forms.Button bnAdd;
        private System.Windows.Forms.Button bnRemove;
        private System.Windows.Forms.OpenFileDialog openImageFileDialog;
        private System.Windows.Forms.Label lbImage;
        private Basics.UCtrlDualDouble uCtrlOrigin;
        private Basics.UCtrlDualDouble uCtrlSize;
        private Graphics.Graphics3DControl graphCtrl;
    }
}