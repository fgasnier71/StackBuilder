namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewTruck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewTruck));
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbColor = new System.Windows.Forms.Label();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.bnSendToDB = new System.Windows.Forms.Button();
            this.uCtrlInnerDimensions = new treeDiM.StackBuilder.Basics.UCtrlTriDouble();
            this.uCtrlMaxLoadWeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
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
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            // 
            // lbDescription
            // 
            resources.ApplyResources(this.lbDescription, "lbDescription");
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
            resources.ApplyResources(this.cbColor, "cbColor");
            this.cbColor.Color = System.Drawing.Color.Gold;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
            this.cbColor.FormattingEnabled = true;
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
            resources.GetString("cbColor.Items16"),
            resources.GetString("cbColor.Items17"),
            resources.GetString("cbColor.Items18"),
            resources.GetString("cbColor.Items19"),
            resources.GetString("cbColor.Items20"),
            resources.GetString("cbColor.Items21"),
            resources.GetString("cbColor.Items22"),
            resources.GetString("cbColor.Items23"),
            resources.GetString("cbColor.Items24"),
            resources.GetString("cbColor.Items25"),
            resources.GetString("cbColor.Items26"),
            resources.GetString("cbColor.Items27"),
            resources.GetString("cbColor.Items28"),
            resources.GetString("cbColor.Items29"),
            resources.GetString("cbColor.Items30"),
            resources.GetString("cbColor.Items31"),
            resources.GetString("cbColor.Items32"),
            resources.GetString("cbColor.Items33"),
            resources.GetString("cbColor.Items34"),
            resources.GetString("cbColor.Items35"),
            resources.GetString("cbColor.Items36"),
            resources.GetString("cbColor.Items37"),
            resources.GetString("cbColor.Items38"),
            resources.GetString("cbColor.Items39"),
            resources.GetString("cbColor.Items40"),
            resources.GetString("cbColor.Items41"),
            resources.GetString("cbColor.Items42"),
            resources.GetString("cbColor.Items43"),
            resources.GetString("cbColor.Items44"),
            resources.GetString("cbColor.Items45"),
            resources.GetString("cbColor.Items46"),
            resources.GetString("cbColor.Items47"),
            resources.GetString("cbColor.Items48"),
            resources.GetString("cbColor.Items49")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.onTruckPropertyChanged);
            // 
            // lbColor
            // 
            resources.ApplyResources(this.lbColor, "lbColor");
            this.lbColor.Name = "lbColor";
            // 
            // graphCtrl
            // 
            resources.ApplyResources(this.graphCtrl, "graphCtrl");
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.TabStop = false;
            this.graphCtrl.Viewer = null;
            // 
            // bnSendToDB
            // 
            resources.ApplyResources(this.bnSendToDB, "bnSendToDB");
            this.bnSendToDB.Name = "bnSendToDB";
            this.bnSendToDB.UseVisualStyleBackColor = true;
            this.bnSendToDB.Click += new System.EventHandler(this.onSendToDatabase);
            // 
            // uCtrlInnerDimensions
            // 
            resources.ApplyResources(this.uCtrlInnerDimensions, "uCtrlInnerDimensions");
            this.uCtrlInnerDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlInnerDimensions.Name = "uCtrlInnerDimensions";
            this.uCtrlInnerDimensions.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlInnerDimensions.ValueX = 0D;
            this.uCtrlInnerDimensions.ValueY = 0D;
            this.uCtrlInnerDimensions.ValueZ = 0D;
            // 
            // uCtrlMaxLoadWeight
            // 
            resources.ApplyResources(this.uCtrlMaxLoadWeight, "uCtrlMaxLoadWeight");
            this.uCtrlMaxLoadWeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlMaxLoadWeight.Name = "uCtrlMaxLoadWeight";
            this.uCtrlMaxLoadWeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlMaxLoadWeight.Value = 0D;
            // 
            // FormNewTruck
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uCtrlMaxLoadWeight);
            this.Controls.Add(this.uCtrlInnerDimensions);
            this.Controls.Add(this.bnSendToDB);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.graphCtrl);
            this.Name = "FormNewTruck";
            this.Controls.SetChildIndex(this.graphCtrl, 0);
            this.Controls.SetChildIndex(this.lbColor, 0);
            this.Controls.SetChildIndex(this.cbColor, 0);
            this.Controls.SetChildIndex(this.bnSendToDB, 0);
            this.Controls.SetChildIndex(this.bnOk, 0);
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.uCtrlInnerDimensions, 0);
            this.Controls.SetChildIndex(this.uCtrlMaxLoadWeight, 0);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private treeDiM.StackBuilder.Graphics.Graphics3DControl graphCtrl;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Button bnSendToDB;
        private Basics.UCtrlTriDouble uCtrlInnerDimensions;
        private Basics.UCtrlDouble uCtrlMaxLoadWeight;
    }
}