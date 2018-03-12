namespace treeDiM.StackBuilder.Desktop
{
    partial class FormHPalletisation
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
            this.lbPallet = new System.Windows.Forms.Label();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.cbPallets = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.gridInput = new SourceGrid.Grid();
            this.uCtrlMaxPalletHeight = new treeDiM.StackBuilder.Basics.UCtrlDouble();
            this.bnAddRow = new System.Windows.Forms.Button();
            this.grid1 = new SourceGrid.Grid();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Size = new System.Drawing.Size(666, 20);
            // 
            // lbPallet
            // 
            this.lbPallet.AutoSize = true;
            this.lbPallet.Location = new System.Drawing.Point(8, 65);
            this.lbPallet.Name = "lbPallet";
            this.lbPallet.Size = new System.Drawing.Size(33, 13);
            this.lbPallet.TabIndex = 14;
            this.lbPallet.Text = "Pallet";
            // 
            // graphCtrl
            // 
            this.graphCtrl.Location = new System.Drawing.Point(342, 60);
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.Size = new System.Drawing.Size(438, 445);
            this.graphCtrl.TabIndex = 16;
            this.graphCtrl.Viewer = null;
            // 
            // cbPallets
            // 
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            this.cbPallets.Location = new System.Drawing.Point(104, 61);
            this.cbPallets.Name = "cbPallets";
            this.cbPallets.Size = new System.Drawing.Size(121, 21);
            this.cbPallets.TabIndex = 17;
            this.cbPallets.SelectedIndexChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // gridInput
            // 
            this.gridInput.EnableSort = true;
            this.gridInput.Location = new System.Drawing.Point(8, 114);
            this.gridInput.Name = "gridInput";
            this.gridInput.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridInput.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridInput.Size = new System.Drawing.Size(325, 230);
            this.gridInput.TabIndex = 18;
            this.gridInput.TabStop = true;
            this.gridInput.ToolTipText = "";
            // 
            // uCtrlMaxPalletHeight
            // 
            this.uCtrlMaxPalletHeight.Location = new System.Drawing.Point(8, 88);
            this.uCtrlMaxPalletHeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMaxPalletHeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMaxPalletHeight.Name = "uCtrlMaxPalletHeight";
            this.uCtrlMaxPalletHeight.Size = new System.Drawing.Size(256, 20);
            this.uCtrlMaxPalletHeight.TabIndex = 19;
            this.uCtrlMaxPalletHeight.Text = "Max. pallet height";
            this.uCtrlMaxPalletHeight.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMaxPalletHeight.Value = 0D;
            // 
            // bnAddRow
            // 
            this.bnAddRow.Location = new System.Drawing.Point(8, 350);
            this.bnAddRow.Name = "bnAddRow";
            this.bnAddRow.Size = new System.Drawing.Size(22, 23);
            this.bnAddRow.TabIndex = 20;
            this.bnAddRow.Text = "+";
            this.bnAddRow.UseVisualStyleBackColor = true;
            this.bnAddRow.Click += new System.EventHandler(this.OnCaseAdded);
            // 
            // grid1
            // 
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(8, 379);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(325, 126);
            this.grid1.TabIndex = 21;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // FormHPalletisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.bnAddRow);
            this.Controls.Add(this.uCtrlMaxPalletHeight);
            this.Controls.Add(this.gridInput);
            this.Controls.Add(this.cbPallets);
            this.Controls.Add(this.graphCtrl);
            this.Controls.Add(this.lbPallet);
            this.Name = "FormHPalletisation";
            this.Text = "FormHPalletisation";
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.lbPallet, 0);
            this.Controls.SetChildIndex(this.graphCtrl, 0);
            this.Controls.SetChildIndex(this.cbPallets, 0);
            this.Controls.SetChildIndex(this.gridInput, 0);
            this.Controls.SetChildIndex(this.uCtrlMaxPalletHeight, 0);
            this.Controls.SetChildIndex(this.bnAddRow, 0);
            this.Controls.SetChildIndex(this.grid1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label lbPallet;
        private Graphics.Graphics3DControl graphCtrl;
        private Graphics.Controls.CCtrlComboFiltered cbPallets;
        private SourceGrid.Grid gridInput;
        private Basics.UCtrlDouble uCtrlMaxPalletHeight;
        private System.Windows.Forms.Button bnAddRow;
        private SourceGrid.Grid grid1;
    }
}