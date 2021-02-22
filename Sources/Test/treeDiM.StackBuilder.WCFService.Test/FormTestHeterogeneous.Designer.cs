
namespace treeDiM.StackBuilder.WCFService.Test
{
    partial class FormTestHeterogeneous
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
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.bnCompute = new System.Windows.Forms.Button();
            this.gbPallet = new System.Windows.Forms.GroupBox();
            this.nudOverhangY = new System.Windows.Forms.NumericUpDown();
            this.lbPalletDim = new System.Windows.Forms.Label();
            this.nudOverhangX = new System.Windows.Forms.NumericUpDown();
            this.nudPalletDimX = new System.Windows.Forms.NumericUpDown();
            this.lbOverhang = new System.Windows.Forms.Label();
            this.nudPalletDimY = new System.Windows.Forms.NumericUpDown();
            this.nudPalletWeight = new System.Windows.Forms.NumericUpDown();
            this.nudPalletDimZ = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMaxPalletHeight = new System.Windows.Forms.NumericUpDown();
            this.lbMaxPalletHeight = new System.Windows.Forms.Label();
            this.gbBoxes = new System.Windows.Forms.GroupBox();
            this.bnRemove = new System.Windows.Forms.Button();
            this.bnAdd = new System.Windows.Forms.Button();
            this.gridContent = new SourceGrid.Grid();
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.pbStackbuilder = new System.Windows.Forms.PictureBox();
            this.lbPalletCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            this.gbPallet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletDimX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletDimY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletDimZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPalletHeight)).BeginInit();
            this.gbBoxes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStackbuilder)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerHoriz
            // 
            this.splitContainerHoriz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerHoriz.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerHoriz.Location = new System.Drawing.Point(0, 0);
            this.splitContainerHoriz.Name = "splitContainerHoriz";
            this.splitContainerHoriz.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerHoriz.Panel1
            // 
            this.splitContainerHoriz.Panel1.Controls.Add(this.bnCompute);
            this.splitContainerHoriz.Panel1.Controls.Add(this.gbPallet);
            this.splitContainerHoriz.Panel1.Controls.Add(this.gbBoxes);
            // 
            // splitContainerHoriz.Panel2
            // 
            this.splitContainerHoriz.Panel2.Controls.Add(this.splitContainerVert);
            this.splitContainerHoriz.Size = new System.Drawing.Size(934, 561);
            this.splitContainerHoriz.SplitterDistance = 200;
            this.splitContainerHoriz.TabIndex = 0;
            // 
            // bnCompute
            // 
            this.bnCompute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCompute.Location = new System.Drawing.Point(781, 157);
            this.bnCompute.Name = "bnCompute";
            this.bnCompute.Size = new System.Drawing.Size(141, 23);
            this.bnCompute.TabIndex = 3;
            this.bnCompute.Text = "Call WCF service";
            this.bnCompute.UseVisualStyleBackColor = true;
            this.bnCompute.Click += new System.EventHandler(this.OnCompute);
            // 
            // gbPallet
            // 
            this.gbPallet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPallet.Controls.Add(this.nudOverhangY);
            this.gbPallet.Controls.Add(this.lbPalletDim);
            this.gbPallet.Controls.Add(this.nudOverhangX);
            this.gbPallet.Controls.Add(this.nudPalletDimX);
            this.gbPallet.Controls.Add(this.lbOverhang);
            this.gbPallet.Controls.Add(this.nudPalletDimY);
            this.gbPallet.Controls.Add(this.nudPalletWeight);
            this.gbPallet.Controls.Add(this.nudPalletDimZ);
            this.gbPallet.Controls.Add(this.label2);
            this.gbPallet.Controls.Add(this.nudMaxPalletHeight);
            this.gbPallet.Controls.Add(this.lbMaxPalletHeight);
            this.gbPallet.Location = new System.Drawing.Point(524, 3);
            this.gbPallet.Name = "gbPallet";
            this.gbPallet.Size = new System.Drawing.Size(398, 147);
            this.gbPallet.TabIndex = 2;
            this.gbPallet.TabStop = false;
            this.gbPallet.Text = "Pallet";
            // 
            // nudOverhangY
            // 
            this.nudOverhangY.DecimalPlaces = 1;
            this.nudOverhangY.Location = new System.Drawing.Point(227, 118);
            this.nudOverhangY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudOverhangY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudOverhangY.Name = "nudOverhangY";
            this.nudOverhangY.Size = new System.Drawing.Size(74, 20);
            this.nudOverhangY.TabIndex = 83;
            // 
            // lbPalletDim
            // 
            this.lbPalletDim.AutoSize = true;
            this.lbPalletDim.Location = new System.Drawing.Point(11, 35);
            this.lbPalletDim.Name = "lbPalletDim";
            this.lbPalletDim.Size = new System.Drawing.Size(55, 13);
            this.lbPalletDim.TabIndex = 73;
            this.lbPalletDim.Text = "Pallet dim.";
            // 
            // nudOverhangX
            // 
            this.nudOverhangX.DecimalPlaces = 1;
            this.nudOverhangX.Location = new System.Drawing.Point(147, 118);
            this.nudOverhangX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudOverhangX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudOverhangX.Name = "nudOverhangX";
            this.nudOverhangX.Size = new System.Drawing.Size(74, 20);
            this.nudOverhangX.TabIndex = 82;
            // 
            // nudPalletDimX
            // 
            this.nudPalletDimX.DecimalPlaces = 1;
            this.nudPalletDimX.Location = new System.Drawing.Point(147, 33);
            this.nudPalletDimX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPalletDimX.Name = "nudPalletDimX";
            this.nudPalletDimX.Size = new System.Drawing.Size(74, 20);
            this.nudPalletDimX.TabIndex = 75;
            // 
            // lbOverhang
            // 
            this.lbOverhang.AutoSize = true;
            this.lbOverhang.Location = new System.Drawing.Point(12, 120);
            this.lbOverhang.Name = "lbOverhang";
            this.lbOverhang.Size = new System.Drawing.Size(54, 13);
            this.lbOverhang.TabIndex = 81;
            this.lbOverhang.Text = "Overhang";
            // 
            // nudPalletDimY
            // 
            this.nudPalletDimY.DecimalPlaces = 1;
            this.nudPalletDimY.Location = new System.Drawing.Point(227, 33);
            this.nudPalletDimY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPalletDimY.Name = "nudPalletDimY";
            this.nudPalletDimY.Size = new System.Drawing.Size(74, 20);
            this.nudPalletDimY.TabIndex = 76;
            // 
            // nudPalletWeight
            // 
            this.nudPalletWeight.DecimalPlaces = 3;
            this.nudPalletWeight.Location = new System.Drawing.Point(147, 61);
            this.nudPalletWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPalletWeight.Name = "nudPalletWeight";
            this.nudPalletWeight.Size = new System.Drawing.Size(74, 20);
            this.nudPalletWeight.TabIndex = 79;
            // 
            // nudPalletDimZ
            // 
            this.nudPalletDimZ.DecimalPlaces = 1;
            this.nudPalletDimZ.Location = new System.Drawing.Point(308, 33);
            this.nudPalletDimZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPalletDimZ.Name = "nudPalletDimZ";
            this.nudPalletDimZ.Size = new System.Drawing.Size(74, 20);
            this.nudPalletDimZ.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Pallet weight";
            // 
            // nudMaxPalletHeight
            // 
            this.nudMaxPalletHeight.DecimalPlaces = 1;
            this.nudMaxPalletHeight.Location = new System.Drawing.Point(147, 90);
            this.nudMaxPalletHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxPalletHeight.Name = "nudMaxPalletHeight";
            this.nudMaxPalletHeight.Size = new System.Drawing.Size(74, 20);
            this.nudMaxPalletHeight.TabIndex = 77;
            // 
            // lbMaxPalletHeight
            // 
            this.lbMaxPalletHeight.AutoSize = true;
            this.lbMaxPalletHeight.Location = new System.Drawing.Point(11, 92);
            this.lbMaxPalletHeight.Name = "lbMaxPalletHeight";
            this.lbMaxPalletHeight.Size = new System.Drawing.Size(90, 13);
            this.lbMaxPalletHeight.TabIndex = 74;
            this.lbMaxPalletHeight.Text = "Max. pallet height";
            // 
            // gbBoxes
            // 
            this.gbBoxes.Controls.Add(this.bnRemove);
            this.gbBoxes.Controls.Add(this.bnAdd);
            this.gbBoxes.Controls.Add(this.gridContent);
            this.gbBoxes.Location = new System.Drawing.Point(3, 3);
            this.gbBoxes.Name = "gbBoxes";
            this.gbBoxes.Size = new System.Drawing.Size(433, 177);
            this.gbBoxes.TabIndex = 1;
            this.gbBoxes.TabStop = false;
            this.gbBoxes.Text = "Boxes";
            // 
            // bnRemove
            // 
            this.bnRemove.Location = new System.Drawing.Point(347, 50);
            this.bnRemove.Name = "bnRemove";
            this.bnRemove.Size = new System.Drawing.Size(75, 23);
            this.bnRemove.TabIndex = 2;
            this.bnRemove.Text = "Remove";
            this.bnRemove.UseVisualStyleBackColor = true;
            this.bnRemove.Click += new System.EventHandler(this.OnBoxesRemove);
            // 
            // bnAdd
            // 
            this.bnAdd.Location = new System.Drawing.Point(347, 20);
            this.bnAdd.Name = "bnAdd";
            this.bnAdd.Size = new System.Drawing.Size(75, 23);
            this.bnAdd.TabIndex = 1;
            this.bnAdd.Text = "Add...";
            this.bnAdd.UseVisualStyleBackColor = true;
            this.bnAdd.Click += new System.EventHandler(this.OnBoxesAdd);
            // 
            // gridContent
            // 
            this.gridContent.EnableSort = true;
            this.gridContent.Location = new System.Drawing.Point(6, 19);
            this.gridContent.Name = "gridContent";
            this.gridContent.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridContent.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridContent.Size = new System.Drawing.Size(334, 152);
            this.gridContent.TabIndex = 0;
            this.gridContent.TabStop = true;
            this.gridContent.ToolTipText = "";
            // 
            // splitContainerVert
            // 
            this.splitContainerVert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVert.Location = new System.Drawing.Point(0, 0);
            this.splitContainerVert.Name = "splitContainerVert";
            // 
            // splitContainerVert.Panel1
            // 
            this.splitContainerVert.Panel1.Controls.Add(this.pbStackbuilder);
            // 
            // splitContainerVert.Panel2
            // 
            this.splitContainerVert.Panel2.Controls.Add(this.lbPalletCount);
            this.splitContainerVert.Size = new System.Drawing.Size(934, 357);
            this.splitContainerVert.SplitterDistance = 664;
            this.splitContainerVert.TabIndex = 0;
            // 
            // pbStackbuilder
            // 
            this.pbStackbuilder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbStackbuilder.Location = new System.Drawing.Point(0, 0);
            this.pbStackbuilder.Name = "pbStackbuilder";
            this.pbStackbuilder.Size = new System.Drawing.Size(664, 357);
            this.pbStackbuilder.TabIndex = 0;
            this.pbStackbuilder.TabStop = false;
            // 
            // lbPalletCount
            // 
            this.lbPalletCount.AutoSize = true;
            this.lbPalletCount.Location = new System.Drawing.Point(19, 22);
            this.lbPalletCount.Name = "lbPalletCount";
            this.lbPalletCount.Size = new System.Drawing.Size(66, 13);
            this.lbPalletCount.TabIndex = 0;
            this.lbPalletCount.Text = "Pallet count:";
            // 
            // FormTestHeterogeneous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.splitContainerHoriz);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTestHeterogeneous";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TabText = "Heterogeneous";
            this.Text = "Heterogeneous";
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.gbPallet.ResumeLayout(false);
            this.gbPallet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletDimX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletDimY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletDimZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPalletHeight)).EndInit();
            this.gbBoxes.ResumeLayout(false);
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            this.splitContainerVert.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStackbuilder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.SplitContainer splitContainerVert;
        private SourceGrid.Grid gridContent;
        private System.Windows.Forms.GroupBox gbPallet;
        private System.Windows.Forms.GroupBox gbBoxes;
        private System.Windows.Forms.Button bnRemove;
        private System.Windows.Forms.Button bnAdd;
        private System.Windows.Forms.NumericUpDown nudOverhangY;
        private System.Windows.Forms.Label lbPalletDim;
        private System.Windows.Forms.NumericUpDown nudOverhangX;
        private System.Windows.Forms.NumericUpDown nudPalletDimX;
        private System.Windows.Forms.Label lbOverhang;
        private System.Windows.Forms.NumericUpDown nudPalletDimY;
        private System.Windows.Forms.NumericUpDown nudPalletWeight;
        private System.Windows.Forms.NumericUpDown nudPalletDimZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMaxPalletHeight;
        private System.Windows.Forms.Label lbMaxPalletHeight;
        private System.Windows.Forms.Button bnCompute;
        private System.Windows.Forms.PictureBox pbStackbuilder;
        private System.Windows.Forms.Label lbPalletCount;
    }
}