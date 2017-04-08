namespace treeDiM.StackBuilder.Desktop
{
    partial class FormShowDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShowDatabase));
            this.tabCtrlDBItems = new System.Windows.Forms.TabControl();
            this.tabPagePallet = new System.Windows.Forms.TabPage();
            this.tabPageDeco = new System.Windows.Forms.TabPage();
            this.tabPageCase = new System.Windows.Forms.TabPage();
            this.tabPageBundle = new System.Windows.Forms.TabPage();
            this.tabPageCylinder = new System.Windows.Forms.TabPage();
            this.tabPageTruck = new System.Windows.Forms.TabPage();
            this.splitContainerTrucks = new System.Windows.Forms.SplitContainer();
            this.bnImportTruck = new System.Windows.Forms.Button();
            this.graphCtrlTrucks = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.gridTrucks = new SourceGrid.Grid();
            this.tabCtrlDBItems.SuspendLayout();
            this.tabPageTruck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTrucks)).BeginInit();
            this.splitContainerTrucks.Panel1.SuspendLayout();
            this.splitContainerTrucks.Panel2.SuspendLayout();
            this.splitContainerTrucks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlTrucks)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCtrlDBItems
            // 
            this.tabCtrlDBItems.Controls.Add(this.tabPagePallet);
            this.tabCtrlDBItems.Controls.Add(this.tabPageDeco);
            this.tabCtrlDBItems.Controls.Add(this.tabPageCase);
            this.tabCtrlDBItems.Controls.Add(this.tabPageBundle);
            this.tabCtrlDBItems.Controls.Add(this.tabPageCylinder);
            this.tabCtrlDBItems.Controls.Add(this.tabPageTruck);
            this.tabCtrlDBItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlDBItems.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlDBItems.Name = "tabCtrlDBItems";
            this.tabCtrlDBItems.SelectedIndex = 0;
            this.tabCtrlDBItems.Size = new System.Drawing.Size(634, 461);
            this.tabCtrlDBItems.TabIndex = 0;
            this.tabCtrlDBItems.SelectedIndexChanged += new System.EventHandler(this.onSelectedTabChanged);
            // 
            // tabPagePallet
            // 
            this.tabPagePallet.Location = new System.Drawing.Point(4, 22);
            this.tabPagePallet.Name = "tabPagePallet";
            this.tabPagePallet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePallet.Size = new System.Drawing.Size(626, 435);
            this.tabPagePallet.TabIndex = 0;
            this.tabPagePallet.Text = "Pallets";
            this.tabPagePallet.ToolTipText = "Pallets";
            this.tabPagePallet.UseVisualStyleBackColor = true;
            // 
            // tabPageDeco
            // 
            this.tabPageDeco.Location = new System.Drawing.Point(4, 22);
            this.tabPageDeco.Name = "tabPageDeco";
            this.tabPageDeco.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDeco.Size = new System.Drawing.Size(626, 435);
            this.tabPageDeco.TabIndex = 1;
            this.tabPageDeco.Text = "Pallet decoration";
            this.tabPageDeco.UseVisualStyleBackColor = true;
            // 
            // tabPageCase
            // 
            this.tabPageCase.Location = new System.Drawing.Point(4, 22);
            this.tabPageCase.Name = "tabPageCase";
            this.tabPageCase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCase.Size = new System.Drawing.Size(626, 435);
            this.tabPageCase.TabIndex = 2;
            this.tabPageCase.Text = "Case";
            this.tabPageCase.UseVisualStyleBackColor = true;
            // 
            // tabPageBundle
            // 
            this.tabPageBundle.Location = new System.Drawing.Point(4, 22);
            this.tabPageBundle.Name = "tabPageBundle";
            this.tabPageBundle.Size = new System.Drawing.Size(626, 435);
            this.tabPageBundle.TabIndex = 3;
            this.tabPageBundle.Text = "Bundle";
            this.tabPageBundle.UseVisualStyleBackColor = true;
            // 
            // tabPageCylinder
            // 
            this.tabPageCylinder.Location = new System.Drawing.Point(4, 22);
            this.tabPageCylinder.Name = "tabPageCylinder";
            this.tabPageCylinder.Size = new System.Drawing.Size(626, 435);
            this.tabPageCylinder.TabIndex = 4;
            this.tabPageCylinder.Text = "Cylinders";
            this.tabPageCylinder.UseVisualStyleBackColor = true;
            // 
            // tabPageTruck
            // 
            this.tabPageTruck.Controls.Add(this.splitContainerTrucks);
            this.tabPageTruck.Location = new System.Drawing.Point(4, 22);
            this.tabPageTruck.Name = "tabPageTruck";
            this.tabPageTruck.Size = new System.Drawing.Size(626, 435);
            this.tabPageTruck.TabIndex = 5;
            this.tabPageTruck.Text = "Trucks";
            this.tabPageTruck.UseVisualStyleBackColor = true;
            // 
            // splitContainerTrucks
            // 
            this.splitContainerTrucks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTrucks.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTrucks.Name = "splitContainerTrucks";
            this.splitContainerTrucks.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTrucks.Panel1
            // 
            this.splitContainerTrucks.Panel1.Controls.Add(this.bnImportTruck);
            this.splitContainerTrucks.Panel1.Controls.Add(this.graphCtrlTrucks);
            // 
            // splitContainerTrucks.Panel2
            // 
            this.splitContainerTrucks.Panel2.Controls.Add(this.gridTrucks);
            this.splitContainerTrucks.Size = new System.Drawing.Size(626, 435);
            this.splitContainerTrucks.SplitterDistance = 166;
            this.splitContainerTrucks.TabIndex = 0;
            // 
            // bnImportTruck
            // 
            this.bnImportTruck.Location = new System.Drawing.Point(543, 4);
            this.bnImportTruck.Name = "bnImportTruck";
            this.bnImportTruck.Size = new System.Drawing.Size(75, 23);
            this.bnImportTruck.TabIndex = 1;
            this.bnImportTruck.Text = "Import";
            this.bnImportTruck.UseVisualStyleBackColor = true;
            this.bnImportTruck.Click += new System.EventHandler(this.onImportTruck);
            // 
            // graphCtrlTrucks
            // 
            this.graphCtrlTrucks.Location = new System.Drawing.Point(3, 3);
            this.graphCtrlTrucks.Name = "graphCtrlTrucks";
            this.graphCtrlTrucks.Size = new System.Drawing.Size(400, 161);
            this.graphCtrlTrucks.TabIndex = 0;
            this.graphCtrlTrucks.Viewer = null;
            // 
            // gridTrucks
            // 
            this.gridTrucks.AcceptsInputChar = false;
            this.gridTrucks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gridTrucks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTrucks.EnableSort = false;
            this.gridTrucks.Location = new System.Drawing.Point(0, 0);
            this.gridTrucks.Name = "gridTrucks";
            this.gridTrucks.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridTrucks.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridTrucks.Size = new System.Drawing.Size(626, 265);
            this.gridTrucks.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridTrucks.TabIndex = 4;
            this.gridTrucks.TabStop = true;
            this.gridTrucks.ToolTipText = "";
            // 
            // FormShowDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.tabCtrlDBItems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormShowDatabase";
            this.ShowInTaskbar = false;
            this.Text = "Edit database & import items in project...";
            this.tabCtrlDBItems.ResumeLayout(false);
            this.tabPageTruck.ResumeLayout(false);
            this.splitContainerTrucks.Panel1.ResumeLayout(false);
            this.splitContainerTrucks.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTrucks)).EndInit();
            this.splitContainerTrucks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrlTrucks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrlDBItems;
        private System.Windows.Forms.TabPage tabPagePallet;
        private System.Windows.Forms.TabPage tabPageDeco;
        private System.Windows.Forms.TabPage tabPageCase;
        private System.Windows.Forms.TabPage tabPageBundle;
        private System.Windows.Forms.TabPage tabPageCylinder;
        private System.Windows.Forms.TabPage tabPageTruck;
        private System.Windows.Forms.SplitContainer splitContainerTrucks;
        private Graphics.Graphics3DControl graphCtrlTrucks;
        private SourceGrid.Grid gridTrucks;
        private System.Windows.Forms.Button bnImportTruck;
    }
}