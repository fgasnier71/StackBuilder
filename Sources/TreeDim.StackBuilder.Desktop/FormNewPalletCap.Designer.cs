namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewPalletCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewPalletCap));
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.label1 = new System.Windows.Forms.Label();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.uCtrlDimensionsOuter = new treeDiM.Basics.UCtrlTriDouble();
            this.uCtrlDimensionsInner = new treeDiM.Basics.UCtrlTriDouble();
            this.uCtrlWeight = new treeDiM.Basics.UCtrlDouble();
            this.bnSendToDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // bnOk
            // 
            resources.ApplyResources(this.bnOk, "bnOk");
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            // 
            // cbColor
            // 
            this.cbColor.Color = System.Drawing.Color.Chocolate;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
            resources.ApplyResources(this.cbColor, "cbColor");
            this.cbColor.Items.AddRange(new object[] {
            resources.GetString("cbColor.Items"),
            resources.GetString("cbColor.Items1"),
            resources.GetString("cbColor.Items2"),
            resources.GetString("cbColor.Items3"),
            resources.GetString("cbColor.Items4"),
            resources.GetString("cbColor.Items5"),
            resources.GetString("cbColor.Items6"),
            resources.GetString("cbColor.Items7"),
            resources.GetString("cbColor.Items8"),
            resources.GetString("cbColor.Items9"),
            resources.GetString("cbColor.Items10"),
            resources.GetString("cbColor.Items11"),
            resources.GetString("cbColor.Items12"),
            resources.GetString("cbColor.Items13"),
            resources.GetString("cbColor.Items14"),
            resources.GetString("cbColor.Items15"),
            resources.GetString("cbColor.Items16")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.OnColorChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // graphCtrl
            // 
            resources.ApplyResources(this.graphCtrl, "graphCtrl");
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.TabStop = false;
            this.graphCtrl.Viewer = null;
            // 
            // uCtrlDimensionsOuter
            // 
            resources.ApplyResources(this.uCtrlDimensionsOuter, "uCtrlDimensionsOuter");
            this.uCtrlDimensionsOuter.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlDimensionsOuter.Name = "uCtrlDimensionsOuter";
            this.uCtrlDimensionsOuter.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDimensionsOuter.ValueX = 0D;
            this.uCtrlDimensionsOuter.ValueY = 0D;
            this.uCtrlDimensionsOuter.ValueZ = 0D;
            this.uCtrlDimensionsOuter.ValueChanged += new treeDiM.Basics.UCtrlTriDouble.ValueChangedDelegate(this.UpdateThicknesses);
            // 
            // uCtrlDimensionsInner
            // 
            resources.ApplyResources(this.uCtrlDimensionsInner, "uCtrlDimensionsInner");
            this.uCtrlDimensionsInner.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlDimensionsInner.Name = "uCtrlDimensionsInner";
            this.uCtrlDimensionsInner.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDimensionsInner.ValueX = 0D;
            this.uCtrlDimensionsInner.ValueY = 0D;
            this.uCtrlDimensionsInner.ValueZ = 0D;
            this.uCtrlDimensionsInner.ValueChanged += new treeDiM.Basics.UCtrlTriDouble.ValueChangedDelegate(this.UpdateThicknesses);
            // 
            // uCtrlWeight
            // 
            resources.ApplyResources(this.uCtrlWeight, "uCtrlWeight");
            this.uCtrlWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlWeight.Name = "uCtrlWeight";
            this.uCtrlWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlWeight.Value = 0D;
            // 
            // bnSendToDB
            // 
            resources.ApplyResources(this.bnSendToDB, "bnSendToDB");
            this.bnSendToDB.Name = "bnSendToDB";
            this.bnSendToDB.UseVisualStyleBackColor = true;
            this.bnSendToDB.Click += new System.EventHandler(this.OnSendToDatabase);
            // 
            // FormNewPalletCap
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.bnSendToDB);
            this.Controls.Add(this.uCtrlWeight);
            this.Controls.Add(this.uCtrlDimensionsInner);
            this.Controls.Add(this.uCtrlDimensionsOuter);
            this.Controls.Add(this.graphCtrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbColor);
            this.Name = "FormNewPalletCap";
            this.Controls.SetChildIndex(this.bnOk, 0);
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.cbColor, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.graphCtrl, 0);
            this.Controls.SetChildIndex(this.uCtrlDimensionsOuter, 0);
            this.Controls.SetChildIndex(this.uCtrlDimensionsInner, 0);
            this.Controls.SetChildIndex(this.uCtrlWeight, 0);
            this.Controls.SetChildIndex(this.bnSendToDB, 0);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.Label label1;
        private treeDiM.StackBuilder.Graphics.Graphics3DControl graphCtrl;
        private treeDiM.Basics.UCtrlTriDouble uCtrlDimensionsOuter;
        private treeDiM.Basics.UCtrlTriDouble uCtrlDimensionsInner;
        private treeDiM.Basics.UCtrlDouble uCtrlWeight;
        private System.Windows.Forms.Button bnSendToDB;
    }
}
