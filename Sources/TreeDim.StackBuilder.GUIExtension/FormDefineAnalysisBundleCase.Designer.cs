namespace treeDiM.StackBuilder.GUIExtension
{
    partial class FormDefineAnalysisBundleCase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDefineAnalysisBundleCase));
            this.gbFlatDim = new System.Windows.Forms.GroupBox();
            this.uCtrlFlatWeight = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlFlatDimensions = new treeDiM.Basics.UCtrlTriDouble();
            this.nudNumberOfFlats = new System.Windows.Forms.NumericUpDown();
            this.lbNumberOfFlats = new System.Windows.Forms.Label();
            this.gbCaseDim = new System.Windows.Forms.GroupBox();
            this.uCtrlCaseWeight = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlCaseDimensions = new treeDiM.Basics.UCtrlTriDouble();
            this.bnCancel = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.uCtrlLayerList = new treeDiM.StackBuilder.Graphics.UCtrlLayerList();
            this.bnNext = new System.Windows.Forms.Button();
            this.gbFlatDim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfFlats)).BeginInit();
            this.gbCaseDim.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFlatDim
            // 
            this.gbFlatDim.Controls.Add(this.uCtrlFlatWeight);
            this.gbFlatDim.Controls.Add(this.uCtrlFlatDimensions);
            this.gbFlatDim.Controls.Add(this.nudNumberOfFlats);
            this.gbFlatDim.Controls.Add(this.lbNumberOfFlats);
            resources.ApplyResources(this.gbFlatDim, "gbFlatDim");
            this.gbFlatDim.Name = "gbFlatDim";
            this.gbFlatDim.TabStop = false;
            // 
            // uCtrlFlatWeight
            // 
            resources.ApplyResources(this.uCtrlFlatWeight, "uCtrlFlatWeight");
            this.uCtrlFlatWeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlFlatWeight.Name = "uCtrlFlatWeight";
            this.uCtrlFlatWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlFlatWeight.Value = 0D;
            this.uCtrlFlatWeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnInputValueChanged);
            // 
            // uCtrlFlatDimensions
            // 
            resources.ApplyResources(this.uCtrlFlatDimensions, "uCtrlFlatDimensions");
            this.uCtrlFlatDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlFlatDimensions.Name = "uCtrlFlatDimensions";
            this.uCtrlFlatDimensions.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlFlatDimensions.ValueX = 0D;
            this.uCtrlFlatDimensions.ValueY = 0D;
            this.uCtrlFlatDimensions.ValueZ = 0D;
            this.uCtrlFlatDimensions.ValueChanged += new treeDiM.Basics.UCtrlTriDouble.ValueChangedDelegate(this.OnInputValueChanged);
            // 
            // nudNumberOfFlats
            // 
            resources.ApplyResources(this.nudNumberOfFlats, "nudNumberOfFlats");
            this.nudNumberOfFlats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfFlats.Name = "nudNumberOfFlats";
            this.nudNumberOfFlats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfFlats.ValueChanged += new System.EventHandler(this.OnInputValueChanged);
            // 
            // lbNumberOfFlats
            // 
            resources.ApplyResources(this.lbNumberOfFlats, "lbNumberOfFlats");
            this.lbNumberOfFlats.Name = "lbNumberOfFlats";
            // 
            // gbCaseDim
            // 
            this.gbCaseDim.Controls.Add(this.uCtrlCaseWeight);
            this.gbCaseDim.Controls.Add(this.uCtrlCaseDimensions);
            resources.ApplyResources(this.gbCaseDim, "gbCaseDim");
            this.gbCaseDim.Name = "gbCaseDim";
            this.gbCaseDim.TabStop = false;
            // 
            // uCtrlCaseWeight
            // 
            resources.ApplyResources(this.uCtrlCaseWeight, "uCtrlCaseWeight");
            this.uCtrlCaseWeight.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlCaseWeight.Name = "uCtrlCaseWeight";
            this.uCtrlCaseWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlCaseWeight.Value = 0D;
            this.uCtrlCaseWeight.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnInputValueChanged);
            // 
            // uCtrlCaseDimensions
            // 
            resources.ApplyResources(this.uCtrlCaseDimensions, "uCtrlCaseDimensions");
            this.uCtrlCaseDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlCaseDimensions.Name = "uCtrlCaseDimensions";
            this.uCtrlCaseDimensions.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlCaseDimensions.ValueX = 0D;
            this.uCtrlCaseDimensions.ValueY = 0D;
            this.uCtrlCaseDimensions.ValueZ = 0D;
            this.uCtrlCaseDimensions.ValueChanged += new treeDiM.Basics.UCtrlTriDouble.ValueChangedDelegate(this.OnInputValueChanged);
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelDef});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // statusLabelDef
            // 
            this.statusLabelDef.Name = "statusLabelDef";
            resources.ApplyResources(this.statusLabelDef, "statusLabelDef");
            // 
            // uCtrlLayerList
            // 
            resources.ApplyResources(this.uCtrlLayerList, "uCtrlLayerList");
            this.uCtrlLayerList.ButtonSizes = new System.Drawing.Size(150, 150);
            this.uCtrlLayerList.Name = "uCtrlLayerList";
            this.uCtrlLayerList.Show3D = true;
            this.uCtrlLayerList.SingleSelection = false;
            // 
            // bnNext
            // 
            resources.ApplyResources(this.bnNext, "bnNext");
            this.bnNext.Name = "bnNext";
            this.bnNext.UseVisualStyleBackColor = true;
            this.bnNext.Click += new System.EventHandler(this.OnNext);
            // 
            // FormDefineAnalysisBundleCase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.bnNext);
            this.Controls.Add(this.uCtrlLayerList);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.gbCaseDim);
            this.Controls.Add(this.gbFlatDim);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDefineAnalysisBundleCase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.gbFlatDim.ResumeLayout(false);
            this.gbFlatDim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfFlats)).EndInit();
            this.gbCaseDim.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFlatDim;
        private System.Windows.Forms.NumericUpDown nudNumberOfFlats;
        private System.Windows.Forms.Label lbNumberOfFlats;
        private System.Windows.Forms.GroupBox gbCaseDim;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private treeDiM.Basics.UCtrlDouble uCtrlFlatWeight;
        private treeDiM.Basics.UCtrlTriDouble uCtrlFlatDimensions;
        private treeDiM.Basics.UCtrlDouble uCtrlCaseWeight;
        private treeDiM.Basics.UCtrlTriDouble uCtrlCaseDimensions;
        private Graphics.UCtrlLayerList uCtrlLayerList;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelDef;
        private System.Windows.Forms.Button bnNext;
    }
}