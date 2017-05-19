namespace treeDiM.StackBuilder.GUIExtension
{
    partial class FormDefineAnalysisCasePallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDefineAnalysisCasePallet));
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnNext = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbCase = new System.Windows.Forms.GroupBox();
            this.uCtrlCaseOrientation = new treeDiM.StackBuilder.Graphics.uCtrlCaseOrientation();
            this.uCtrlMass = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlDimensions = new treeDiM.StackBuilder.Basics.UCtrlTriDouble();
            this.gpPallet = new System.Windows.Forms.GroupBox();
            this.uCtrlOverhang = new treeDiM.StackBuilder.Basics.UCtrlDualDouble();
            this.graphCtrlPallet = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.cbPallet = new treeDiM.StackBuilder.GUIExtension.CtrlComboDBPallet();
            this.lbPallets = new System.Windows.Forms.Label();
            this.gpConstraintSet = new System.Windows.Forms.GroupBox();
            this.uCtrlOptMaximumWeight = new treeDiM.StackBuilder.Basics.UCtrlOptDouble();
            this.uCtrlMaximumHeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.uCtrlLayerList = new treeDiM.StackBuilder.Graphics.UCtrlLayerList();
            this.statusStrip.SuspendLayout();
            this.gbCase.SuspendLayout();
            this.gpPallet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlPallet)).BeginInit();
            this.gpConstraintSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(553, 4);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 0;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnNext
            // 
            this.bnNext.Location = new System.Drawing.Point(553, 613);
            this.bnNext.Name = "bnNext";
            this.bnNext.Size = new System.Drawing.Size(75, 23);
            this.bnNext.TabIndex = 1;
            this.bnNext.Text = "Next >";
            this.bnNext.UseVisualStyleBackColor = true;
            this.bnNext.Click += new System.EventHandler(this.onNext);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStrip.Location = new System.Drawing.Point(0, 639);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(634, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            this.toolStripStatusLabelDef.Size = new System.Drawing.Size(84, 17);
            this.toolStripStatusLabelDef.Text = "statusLabelDef";
            // 
            // gbCase
            // 
            this.gbCase.Controls.Add(this.uCtrlCaseOrientation);
            this.gbCase.Controls.Add(this.uCtrlMass);
            this.gbCase.Controls.Add(this.uCtrlDimensions);
            this.gbCase.Location = new System.Drawing.Point(3, 28);
            this.gbCase.Name = "gbCase";
            this.gbCase.Size = new System.Drawing.Size(313, 183);
            this.gbCase.TabIndex = 3;
            this.gbCase.TabStop = false;
            this.gbCase.Text = "Case";
            // 
            // uCtrlCaseOrientation
            // 
            this.uCtrlCaseOrientation.AllowedOrientations = new bool[] {
        false,
        false,
        true};
            this.uCtrlCaseOrientation.Location = new System.Drawing.Point(10, 65);
            this.uCtrlCaseOrientation.Name = "uCtrlCaseOrientation";
            this.uCtrlCaseOrientation.Size = new System.Drawing.Size(280, 110);
            this.uCtrlCaseOrientation.TabIndex = 2;
            // 
            // uCtrlMass
            // 
            this.uCtrlMass.Location = new System.Drawing.Point(10, 40);
            this.uCtrlMass.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMass.MinimumSize = new System.Drawing.Size(50, 20);
            this.uCtrlMass.Name = "uCtrlMass";
            this.uCtrlMass.Size = new System.Drawing.Size(176, 20);
            this.uCtrlMass.TabIndex = 1;
            this.uCtrlMass.Text = "Weight";
            this.uCtrlMass.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlMass.Value = 0D;
            this.uCtrlMass.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.onValueChanged(this.onInputChanged);
            // 
            // uCtrlDimensions
            // 
            this.uCtrlDimensions.Location = new System.Drawing.Point(10, 14);
            this.uCtrlDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlDimensions.Name = "uCtrlDimensions";
            this.uCtrlDimensions.Size = new System.Drawing.Size(300, 20);
            this.uCtrlDimensions.TabIndex = 0;
            this.uCtrlDimensions.Text = "Dimensions";
            this.uCtrlDimensions.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDimensions.ValueX = 0D;
            this.uCtrlDimensions.ValueY = 0D;
            this.uCtrlDimensions.ValueZ = 0D;
            this.uCtrlDimensions.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlTriDouble.onValueChanged(this.onInputChanged);
            // 
            // gpPallet
            // 
            this.gpPallet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpPallet.Controls.Add(this.uCtrlOverhang);
            this.gpPallet.Controls.Add(this.graphCtrlPallet);
            this.gpPallet.Controls.Add(this.cbPallet);
            this.gpPallet.Controls.Add(this.lbPallets);
            this.gpPallet.Location = new System.Drawing.Point(319, 28);
            this.gpPallet.Name = "gpPallet";
            this.gpPallet.Size = new System.Drawing.Size(309, 183);
            this.gpPallet.TabIndex = 4;
            this.gpPallet.TabStop = false;
            this.gpPallet.Text = "Pallet";
            // 
            // uCtrlOverhang
            // 
            this.uCtrlOverhang.Location = new System.Drawing.Point(11, 157);
            this.uCtrlOverhang.Name = "uCtrlOverhang";
            this.uCtrlOverhang.Size = new System.Drawing.Size(274, 20);
            this.uCtrlOverhang.TabIndex = 0;
            this.uCtrlOverhang.Text = "Overhang";
            this.uCtrlOverhang.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlOverhang.ValueX = 0D;
            this.uCtrlOverhang.ValueY = 0D;
            this.uCtrlOverhang.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDualDouble.onValueChanged(this.onInputChanged);
            // 
            // graphCtrlPallet
            // 
            this.graphCtrlPallet.Location = new System.Drawing.Point(74, 40);
            this.graphCtrlPallet.Name = "graphCtrlPallet";
            this.graphCtrlPallet.Size = new System.Drawing.Size(211, 111);
            this.graphCtrlPallet.TabIndex = 2;
            this.graphCtrlPallet.Viewer = null;
            // 
            // cbPallet
            // 
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.FormattingEnabled = true;
            this.cbPallet.Location = new System.Drawing.Point(74, 16);
            this.cbPallet.Name = "cbPallet";
            this.cbPallet.Size = new System.Drawing.Size(211, 21);
            this.cbPallet.TabIndex = 1;
            this.cbPallet.SelectedIndexChanged += new System.EventHandler(this.onPalletChanged);
            // 
            // lbPallets
            // 
            this.lbPallets.AutoSize = true;
            this.lbPallets.Location = new System.Drawing.Point(8, 19);
            this.lbPallets.Name = "lbPallets";
            this.lbPallets.Size = new System.Drawing.Size(33, 13);
            this.lbPallets.TabIndex = 0;
            this.lbPallets.Text = "Pallet";
            // 
            // gpConstraintSet
            // 
            this.gpConstraintSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpConstraintSet.Controls.Add(this.uCtrlOptMaximumWeight);
            this.gpConstraintSet.Controls.Add(this.uCtrlMaximumHeight);
            this.gpConstraintSet.Location = new System.Drawing.Point(3, 215);
            this.gpConstraintSet.Name = "gpConstraintSet";
            this.gpConstraintSet.Size = new System.Drawing.Size(625, 65);
            this.gpConstraintSet.TabIndex = 5;
            this.gpConstraintSet.TabStop = false;
            this.gpConstraintSet.Text = "Constraint set";
            // 
            // uCtrlOptMaximumWeight
            // 
            this.uCtrlOptMaximumWeight.Location = new System.Drawing.Point(10, 41);
            this.uCtrlOptMaximumWeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlOptMaximumWeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlOptMaximumWeight.Name = "uCtrlOptMaximumWeight";
            this.uCtrlOptMaximumWeight.Size = new System.Drawing.Size(303, 20);
            this.uCtrlOptMaximumWeight.TabIndex = 1;
            this.uCtrlOptMaximumWeight.Text = "Maximum pallet weight";
            this.uCtrlOptMaximumWeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlOptMaximumWeight.Value = ((treeDiM.StackBuilder.Basics.OptDouble)(resources.GetObject("uCtrlOptMaximumWeight.Value")));
            this.uCtrlOptMaximumWeight.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlOptDouble.onValueChanged(this.onInputChanged);
            // 
            // uCtrlMaximumHeight
            // 
            this.uCtrlMaximumHeight.Location = new System.Drawing.Point(10, 16);
            this.uCtrlMaximumHeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlMaximumHeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMaximumHeight.Name = "uCtrlMaximumHeight";
            this.uCtrlMaximumHeight.Size = new System.Drawing.Size(303, 20);
            this.uCtrlMaximumHeight.TabIndex = 0;
            this.uCtrlMaximumHeight.Text = "Maximum pallet height";
            this.uCtrlMaximumHeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMaximumHeight.Value = 0D;
            this.uCtrlMaximumHeight.ValueChanged += new treeDiM.StackBuilder.Basics.UCtrlDouble.onValueChanged(this.onInputChanged);
            // 
            // uCtrlLayerList
            // 
            this.uCtrlLayerList.AutoScroll = true;
            this.uCtrlLayerList.ButtonSizes = new System.Drawing.Size(150, 150);
            this.uCtrlLayerList.Location = new System.Drawing.Point(0, 286);
            this.uCtrlLayerList.Name = "uCtrlLayerList";
            this.uCtrlLayerList.Show3D = true;
            this.uCtrlLayerList.SingleSelection = false;
            this.uCtrlLayerList.Size = new System.Drawing.Size(634, 321);
            this.uCtrlLayerList.TabIndex = 6;
            this.uCtrlLayerList.LayerSelected += new treeDiM.StackBuilder.Graphics.UCtrlLayerList.LayerButtonClicked(this.onLayerSelected);
            // 
            // FormDefineAnalysisCasePallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(634, 661);
            this.Controls.Add(this.uCtrlLayerList);
            this.Controls.Add(this.gpConstraintSet);
            this.Controls.Add(this.gpPallet);
            this.Controls.Add(this.gbCase);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.bnNext);
            this.Controls.Add(this.bnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDefineAnalysisCasePallet";
            this.ShowInTaskbar = false;
            this.Text = "Define case/pallet analysis...";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gbCase.ResumeLayout(false);
            this.gpPallet.ResumeLayout(false);
            this.gpPallet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlPallet)).EndInit();
            this.gpConstraintSet.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnNext;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private System.Windows.Forms.GroupBox gbCase;
        private Basics.UCtrlTriDouble uCtrlDimensions;
        private Basics.UCtrlDouble uCtrlMass;
        private Graphics.uCtrlCaseOrientation uCtrlCaseOrientation;
        private System.Windows.Forms.GroupBox gpPallet;
        private System.Windows.Forms.Label lbPallets;
        private System.Windows.Forms.GroupBox gpConstraintSet;
        private CtrlComboDBPallet cbPallet;
        private Graphics.Graphics3DControl graphCtrlPallet;
        private Graphics.UCtrlLayerList uCtrlLayerList;
        private Basics.UCtrlDualDouble uCtrlOverhang;
        private Basics.UCtrlOptDouble uCtrlOptMaximumWeight;
        private Basics.UCtrlDouble uCtrlMaximumHeight;
    }
}