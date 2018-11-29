namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewPack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewPack));
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.lbBox = new System.Windows.Forms.Label();
            this.cbInnerBox = new System.Windows.Forms.ComboBox();
            this.lbDir = new System.Windows.Forms.Label();
            this.cbDir = new System.Windows.Forms.ComboBox();
            this.uCtrlOuterDimensions = new treeDiM.StackBuilder.Basics.UCtrlOptTriDouble();
            this.uCtrlLayout = new treeDiM.StackBuilder.Basics.Controls.UCtrlTriInt();
            this.uCtrlHeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlWalls = new treeDiM.StackBuilder.Basics.Controls.UCtrlTriInt();
            this.chkbTransparent = new System.Windows.Forms.CheckBox();
            this.lbType = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.uCtrlWeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlThickness = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.lbWrapperColor = new System.Windows.Forms.Label();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabWrapper = new System.Windows.Forms.TabPage();
            this.tabStrappers = new System.Windows.Forms.TabPage();
            this.ctrlStrapperSet = new treeDiM.StackBuilder.Basics.Controls.CtrlStrapperSet();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.tabCtrl.SuspendLayout();
            this.tabWrapper.SuspendLayout();
            this.tabStrappers.SuspendLayout();
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
            // graphCtrl
            // 
            resources.ApplyResources(this.graphCtrl, "graphCtrl");
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.Viewer = null;
            // 
            // lbBox
            // 
            resources.ApplyResources(this.lbBox, "lbBox");
            this.lbBox.Name = "lbBox";
            // 
            // cbInnerBox
            // 
            resources.ApplyResources(this.cbInnerBox, "cbInnerBox");
            this.cbInnerBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInnerBox.FormattingEnabled = true;
            this.cbInnerBox.Name = "cbInnerBox";
            // 
            // lbDir
            // 
            resources.ApplyResources(this.lbDir, "lbDir");
            this.lbDir.Name = "lbDir";
            // 
            // cbDir
            // 
            resources.ApplyResources(this.cbDir, "cbDir");
            this.cbDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDir.FormattingEnabled = true;
            this.cbDir.Items.AddRange(new object[] {
            resources.GetString("cbDir.Items"),
            resources.GetString("cbDir.Items1"),
            resources.GetString("cbDir.Items2"),
            resources.GetString("cbDir.Items3"),
            resources.GetString("cbDir.Items4"),
            resources.GetString("cbDir.Items5")});
            this.cbDir.Name = "cbDir";
            this.cbDir.SelectedIndexChanged += new System.EventHandler(this.OnPackChanged);
            // 
            // uCtrlOuterDimensions
            // 
            resources.ApplyResources(this.uCtrlOuterDimensions, "uCtrlOuterDimensions");
            this.uCtrlOuterDimensions.Checked = false;
            this.uCtrlOuterDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlOuterDimensions.Name = "uCtrlOuterDimensions";
            this.uCtrlOuterDimensions.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOuterDimensions.Value = ((Sharp3D.Math.Core.Vector3D)(resources.GetObject("uCtrlOuterDimensions.Value")));
            this.uCtrlOuterDimensions.X = 0D;
            this.uCtrlOuterDimensions.Y = 0D;
            this.uCtrlOuterDimensions.Z = 0D;
            this.uCtrlOuterDimensions.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlOptTriDouble.ValueChangedDelegate(this.OnPackChanged);
            // 
            // uCtrlLayout
            // 
            resources.ApplyResources(this.uCtrlLayout, "uCtrlLayout");
            this.uCtrlLayout.Name = "uCtrlLayout";
            this.uCtrlLayout.NoX = 1;
            this.uCtrlLayout.NoY = 1;
            this.uCtrlLayout.NoZ = 1;
            this.uCtrlLayout.ValueChanged += new treeDiM.StackBuilder.Basics.Controls.UCtrlTriInt.ValueChangedDelegate(this.OnPackChanged);
            // 
            // uCtrlHeight
            // 
            resources.ApplyResources(this.uCtrlHeight, "uCtrlHeight");
            this.uCtrlHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uCtrlHeight.Name = "uCtrlHeight";
            this.uCtrlHeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlHeight.Value = 40D;
            this.uCtrlHeight.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.ValueChangedDelegate(this.OnPackChanged);
            // 
            // uCtrlWalls
            // 
            resources.ApplyResources(this.uCtrlWalls, "uCtrlWalls");
            this.uCtrlWalls.Name = "uCtrlWalls";
            this.uCtrlWalls.NoX = 1;
            this.uCtrlWalls.NoY = 1;
            this.uCtrlWalls.NoZ = 1;
            this.uCtrlWalls.ValueChanged += new treeDiM.StackBuilder.Basics.Controls.UCtrlTriInt.ValueChangedDelegate(this.OnPackChanged);
            // 
            // chkbTransparent
            // 
            resources.ApplyResources(this.chkbTransparent, "chkbTransparent");
            this.chkbTransparent.Name = "chkbTransparent";
            this.chkbTransparent.UseVisualStyleBackColor = true;
            this.chkbTransparent.CheckedChanged += new System.EventHandler(this.OnPackChanged);
            // 
            // lbType
            // 
            resources.ApplyResources(this.lbType, "lbType");
            this.lbType.Name = "lbType";
            // 
            // cbType
            // 
            resources.ApplyResources(this.cbType, "cbType");
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            resources.GetString("cbType.Items"),
            resources.GetString("cbType.Items1"),
            resources.GetString("cbType.Items2"),
            resources.GetString("cbType.Items3")});
            this.cbType.Name = "cbType";
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.OnWrapperTypeChanged);
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
            this.uCtrlWeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlWeight.Value = 0D;
            this.uCtrlWeight.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.ValueChangedDelegate(this.OnPackChanged);
            // 
            // uCtrlThickness
            // 
            resources.ApplyResources(this.uCtrlThickness, "uCtrlThickness");
            this.uCtrlThickness.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlThickness.Name = "uCtrlThickness";
            this.uCtrlThickness.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlThickness.Value = 0D;
            this.uCtrlThickness.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.ValueChangedDelegate(this.OnPackChanged);
            // 
            // lbWrapperColor
            // 
            resources.ApplyResources(this.lbWrapperColor, "lbWrapperColor");
            this.lbWrapperColor.Name = "lbWrapperColor";
            // 
            // cbColor
            // 
            resources.ApplyResources(this.cbColor, "cbColor");
            this.cbColor.Color = System.Drawing.Color.LightGray;
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
            resources.GetString("cbColor.Items35")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.OnPackChanged);
            // 
            // tabCtrl
            // 
            resources.ApplyResources(this.tabCtrl, "tabCtrl");
            this.tabCtrl.Controls.Add(this.tabWrapper);
            this.tabCtrl.Controls.Add(this.tabStrappers);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            // 
            // tabWrapper
            // 
            resources.ApplyResources(this.tabWrapper, "tabWrapper");
            this.tabWrapper.Controls.Add(this.uCtrlHeight);
            this.tabWrapper.Controls.Add(this.lbType);
            this.tabWrapper.Controls.Add(this.uCtrlWalls);
            this.tabWrapper.Controls.Add(this.cbColor);
            this.tabWrapper.Controls.Add(this.chkbTransparent);
            this.tabWrapper.Controls.Add(this.lbWrapperColor);
            this.tabWrapper.Controls.Add(this.uCtrlWeight);
            this.tabWrapper.Controls.Add(this.uCtrlThickness);
            this.tabWrapper.Controls.Add(this.cbType);
            this.tabWrapper.Name = "tabWrapper";
            this.tabWrapper.UseVisualStyleBackColor = true;
            // 
            // tabStrappers
            // 
            resources.ApplyResources(this.tabStrappers, "tabStrappers");
            this.tabStrappers.Controls.Add(this.ctrlStrapperSet);
            this.tabStrappers.Name = "tabStrappers";
            this.tabStrappers.UseVisualStyleBackColor = true;
            // 
            // ctrlStrapperSet
            // 
            resources.ApplyResources(this.ctrlStrapperSet, "ctrlStrapperSet");
            this.ctrlStrapperSet.Name = "ctrlStrapperSet";
            this.ctrlStrapperSet.Number = 0;
            this.ctrlStrapperSet.StrapperSet = null;
            this.ctrlStrapperSet.ValueChanged += new treeDiM.StackBuilder.Basics.Controls.CtrlStrapperSet.OnValueChanged(this.OnPackChanged);
            // 
            // FormNewPack
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.uCtrlLayout);
            this.Controls.Add(this.uCtrlOuterDimensions);
            this.Controls.Add(this.cbDir);
            this.Controls.Add(this.lbDir);
            this.Controls.Add(this.cbInnerBox);
            this.Controls.Add(this.lbBox);
            this.Controls.Add(this.graphCtrl);
            this.Name = "FormNewPack";
            this.Load += new System.EventHandler(this.FormNewPack_Load);
            this.Controls.SetChildIndex(this.bnOk, 0);
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.graphCtrl, 0);
            this.Controls.SetChildIndex(this.lbBox, 0);
            this.Controls.SetChildIndex(this.cbInnerBox, 0);
            this.Controls.SetChildIndex(this.lbDir, 0);
            this.Controls.SetChildIndex(this.cbDir, 0);
            this.Controls.SetChildIndex(this.uCtrlOuterDimensions, 0);
            this.Controls.SetChildIndex(this.uCtrlLayout, 0);
            this.Controls.SetChildIndex(this.tabCtrl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.tabCtrl.ResumeLayout(false);
            this.tabWrapper.ResumeLayout(false);
            this.tabWrapper.PerformLayout();
            this.tabStrappers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Graphics.Graphics3DControl graphCtrl;
        private System.Windows.Forms.Label lbBox;
        private System.Windows.Forms.ComboBox cbInnerBox;
        private System.Windows.Forms.Label lbDir;
        private System.Windows.Forms.ComboBox cbDir;
        private Basics.UCtrlOptTriDouble uCtrlOuterDimensions;
        private Basics.Controls.UCtrlTriInt uCtrlLayout;
        private Basics.UCtrlDouble uCtrlWeight;
        private Basics.UCtrlDouble uCtrlThickness;
        private System.Windows.Forms.Label lbWrapperColor;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.ComboBox cbType;
        private Basics.Controls.UCtrlTriInt uCtrlWalls;
        private System.Windows.Forms.CheckBox chkbTransparent;
        private Basics.UCtrlDouble uCtrlHeight;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabWrapper;
        private System.Windows.Forms.TabPage tabStrappers;
        private Basics.Controls.CtrlStrapperSet ctrlStrapperSet;
    }
}