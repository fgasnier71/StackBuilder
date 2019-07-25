namespace treeDiM.EdgeCrushTest
{
    partial class FormComputeECT
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
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.uCtrlLoad = new treeDiM.Basics.UCtrlDouble();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMcKeeFormulaType = new System.Windows.Forms.ComboBox();
            this.uCtrlCaseDimensions = new treeDiM.Basics.UCtrlTriDouble();
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.gridMat = new SourceGrid.Grid();
            this.lbPrintedArea = new System.Windows.Forms.Label();
            this.cbPrintedArea = new System.Windows.Forms.ComboBox();
            this.gridDynamicBCT = new SourceGrid.Grid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnOK
            // 
            this.bnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOK.Location = new System.Drawing.Point(806, 3);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 0;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(806, 32);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 1;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // splitContainerHoriz
            // 
            this.splitContainerHoriz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerHoriz.Location = new System.Drawing.Point(0, 0);
            this.splitContainerHoriz.Name = "splitContainerHoriz";
            this.splitContainerHoriz.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerHoriz.Panel1
            // 
            this.splitContainerHoriz.Panel1.Controls.Add(this.uCtrlLoad);
            this.splitContainerHoriz.Panel1.Controls.Add(this.label1);
            this.splitContainerHoriz.Panel1.Controls.Add(this.cbMcKeeFormulaType);
            this.splitContainerHoriz.Panel1.Controls.Add(this.uCtrlCaseDimensions);
            this.splitContainerHoriz.Panel1.Controls.Add(this.bnOK);
            this.splitContainerHoriz.Panel1.Controls.Add(this.bnCancel);
            // 
            // splitContainerHoriz.Panel2
            // 
            this.splitContainerHoriz.Panel2.Controls.Add(this.splitContainerVert);
            this.splitContainerHoriz.Size = new System.Drawing.Size(884, 561);
            this.splitContainerHoriz.SplitterDistance = 59;
            this.splitContainerHoriz.TabIndex = 2;
            // 
            // uCtrlLoad
            // 
            this.uCtrlLoad.Location = new System.Drawing.Point(490, 6);
            this.uCtrlLoad.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlLoad.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlLoad.Name = "uCtrlLoad";
            this.uCtrlLoad.Size = new System.Drawing.Size(268, 20);
            this.uCtrlLoad.TabIndex = 8;
            this.uCtrlLoad.Text = "Expected load";
            this.uCtrlLoad.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            this.uCtrlLoad.ValueChanged += new treeDiM.Basics.UCtrlDouble.ValueChangedDelegate(this.OnInputChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mc Kee formula";
            // 
            // cbMcKeeFormulaType
            // 
            this.cbMcKeeFormulaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMcKeeFormulaType.FormattingEnabled = true;
            this.cbMcKeeFormulaType.Items.AddRange(new object[] {
            "Classic",
            "Improved"});
            this.cbMcKeeFormulaType.Location = new System.Drawing.Point(123, 33);
            this.cbMcKeeFormulaType.Name = "cbMcKeeFormulaType";
            this.cbMcKeeFormulaType.Size = new System.Drawing.Size(121, 21);
            this.cbMcKeeFormulaType.TabIndex = 3;
            this.cbMcKeeFormulaType.SelectedIndexChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // uCtrlCaseDimensions
            // 
            this.uCtrlCaseDimensions.Location = new System.Drawing.Point(3, 6);
            this.uCtrlCaseDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlCaseDimensions.Name = "uCtrlCaseDimensions";
            this.uCtrlCaseDimensions.Size = new System.Drawing.Size(340, 20);
            this.uCtrlCaseDimensions.TabIndex = 2;
            this.uCtrlCaseDimensions.Text = "Case dimensions";
            this.uCtrlCaseDimensions.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlCaseDimensions.ValueX = 0D;
            this.uCtrlCaseDimensions.ValueY = 0D;
            this.uCtrlCaseDimensions.ValueZ = 0D;
            this.uCtrlCaseDimensions.ValueChanged += new treeDiM.Basics.UCtrlTriDouble.ValueChangedDelegate(this.OnInputChanged);
            // 
            // splitContainerVert
            // 
            this.splitContainerVert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVert.Location = new System.Drawing.Point(0, 0);
            this.splitContainerVert.Name = "splitContainerVert";
            // 
            // splitContainerVert.Panel1
            // 
            this.splitContainerVert.Panel1.Controls.Add(this.gridMat);
            // 
            // splitContainerVert.Panel2
            // 
            this.splitContainerVert.Panel2.Controls.Add(this.lbPrintedArea);
            this.splitContainerVert.Panel2.Controls.Add(this.cbPrintedArea);
            this.splitContainerVert.Panel2.Controls.Add(this.gridDynamicBCT);
            this.splitContainerVert.Size = new System.Drawing.Size(884, 498);
            this.splitContainerVert.SplitterDistance = 483;
            this.splitContainerVert.TabIndex = 0;
            // 
            // gridMat
            // 
            this.gridMat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMat.EnableSort = false;
            this.gridMat.Location = new System.Drawing.Point(0, 0);
            this.gridMat.Name = "gridMat";
            this.gridMat.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridMat.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridMat.Size = new System.Drawing.Size(483, 498);
            this.gridMat.SpecialKeys = SourceGrid.GridSpecialKeys.PageDownUp;
            this.gridMat.TabIndex = 0;
            this.gridMat.TabStop = true;
            this.gridMat.ToolTipText = "";
            // 
            // lbPrintedArea
            // 
            this.lbPrintedArea.AutoSize = true;
            this.lbPrintedArea.Location = new System.Drawing.Point(15, 15);
            this.lbPrintedArea.Name = "lbPrintedArea";
            this.lbPrintedArea.Size = new System.Drawing.Size(64, 13);
            this.lbPrintedArea.TabIndex = 2;
            this.lbPrintedArea.Text = "Printed area";
            // 
            // cbPrintedArea
            // 
            this.cbPrintedArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrintedArea.FormattingEnabled = true;
            this.cbPrintedArea.Location = new System.Drawing.Point(99, 12);
            this.cbPrintedArea.Name = "cbPrintedArea";
            this.cbPrintedArea.Size = new System.Drawing.Size(121, 21);
            this.cbPrintedArea.TabIndex = 1;
            this.cbPrintedArea.SelectedIndexChanged += new System.EventHandler(this.OnMaterialChanged);
            // 
            // gridDynamicBCT
            // 
            this.gridDynamicBCT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDynamicBCT.EnableSort = true;
            this.gridDynamicBCT.Location = new System.Drawing.Point(3, 191);
            this.gridDynamicBCT.Name = "gridDynamicBCT";
            this.gridDynamicBCT.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridDynamicBCT.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridDynamicBCT.Size = new System.Drawing.Size(391, 304);
            this.gridDynamicBCT.TabIndex = 0;
            this.gridDynamicBCT.TabStop = true;
            this.gridDynamicBCT.ToolTipText = "";
            // 
            // FormComputeECT
            // 
            this.AcceptButton = this.bnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.splitContainerHoriz);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormComputeECT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Compute ECT...";
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel1.PerformLayout();
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            this.splitContainerVert.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.SplitContainer splitContainerVert;
        private Basics.UCtrlTriDouble uCtrlCaseDimensions;
        private SourceGrid.Grid gridMat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMcKeeFormulaType;
        private SourceGrid.Grid gridDynamicBCT;
        private System.Windows.Forms.Label lbPrintedArea;
        private System.Windows.Forms.ComboBox cbPrintedArea;
        private Basics.UCtrlDouble uCtrlLoad;
    }
}