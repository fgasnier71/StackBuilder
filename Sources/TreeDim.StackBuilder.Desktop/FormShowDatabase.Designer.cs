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
            this.splitContainerForm = new System.Windows.Forms.SplitContainer();
            this.bnClose = new System.Windows.Forms.Button();
            this.bnImport = new System.Windows.Forms.Button();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.chkbSearchDescription = new System.Windows.Forms.CheckBox();
            this.bnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lbCount = new System.Windows.Forms.Label();
            this.bnNext = new System.Windows.Forms.Button();
            this.bnPrev = new System.Windows.Forms.Button();
            this.tabCtrlDBItems = new System.Windows.Forms.TabControl();
            this.tabPageBox = new System.Windows.Forms.TabPage();
            this.gridBoxes = new SourceGrid.Grid();
            this.tabPageCase = new System.Windows.Forms.TabPage();
            this.gridCases = new SourceGrid.Grid();
            this.tabPageBundle = new System.Windows.Forms.TabPage();
            this.gridBundles = new SourceGrid.Grid();
            this.tabPageCylinder = new System.Windows.Forms.TabPage();
            this.gridCylinders = new SourceGrid.Grid();
            this.tabPageInterlayer = new System.Windows.Forms.TabPage();
            this.gridInterlayers = new SourceGrid.Grid();
            this.tabPagePallet = new System.Windows.Forms.TabPage();
            this.gridPallets = new SourceGrid.Grid();
            this.tabPageTruck = new System.Windows.Forms.TabPage();
            this.gridTrucks = new SourceGrid.Grid();
            this.tabPagePalletCorner = new System.Windows.Forms.TabPage();
            this.gridPalletCorners = new SourceGrid.Grid();
            this.tabPagePalletCap = new System.Windows.Forms.TabPage();
            this.gridPalletCaps = new SourceGrid.Grid();
            this.tabPagePalletFilm = new System.Windows.Forms.TabPage();
            this.gridPalletFilms = new SourceGrid.Grid();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripBExcel = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerForm)).BeginInit();
            this.splitContainerForm.Panel1.SuspendLayout();
            this.splitContainerForm.Panel2.SuspendLayout();
            this.splitContainerForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.tabCtrlDBItems.SuspendLayout();
            this.tabPageBox.SuspendLayout();
            this.tabPageCase.SuspendLayout();
            this.tabPageBundle.SuspendLayout();
            this.tabPageCylinder.SuspendLayout();
            this.tabPageInterlayer.SuspendLayout();
            this.tabPagePallet.SuspendLayout();
            this.tabPageTruck.SuspendLayout();
            this.tabPagePalletCorner.SuspendLayout();
            this.tabPagePalletCap.SuspendLayout();
            this.tabPagePalletFilm.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerForm
            // 
            resources.ApplyResources(this.splitContainerForm, "splitContainerForm");
            this.splitContainerForm.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerForm.Name = "splitContainerForm";
            // 
            // splitContainerForm.Panel1
            // 
            resources.ApplyResources(this.splitContainerForm.Panel1, "splitContainerForm.Panel1");
            this.splitContainerForm.Panel1.Controls.Add(this.bnClose);
            this.splitContainerForm.Panel1.Controls.Add(this.bnImport);
            this.splitContainerForm.Panel1.Controls.Add(this.graphCtrl);
            // 
            // splitContainerForm.Panel2
            // 
            resources.ApplyResources(this.splitContainerForm.Panel2, "splitContainerForm.Panel2");
            this.splitContainerForm.Panel2.Controls.Add(this.chkbSearchDescription);
            this.splitContainerForm.Panel2.Controls.Add(this.bnSearch);
            this.splitContainerForm.Panel2.Controls.Add(this.tbSearch);
            this.splitContainerForm.Panel2.Controls.Add(this.lbCount);
            this.splitContainerForm.Panel2.Controls.Add(this.bnNext);
            this.splitContainerForm.Panel2.Controls.Add(this.bnPrev);
            this.splitContainerForm.Panel2.Controls.Add(this.tabCtrlDBItems);
            // 
            // bnClose
            // 
            resources.ApplyResources(this.bnClose, "bnClose");
            this.bnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnClose.Name = "bnClose";
            this.bnClose.UseVisualStyleBackColor = true;
            // 
            // bnImport
            // 
            resources.ApplyResources(this.bnImport, "bnImport");
            this.bnImport.Name = "bnImport";
            this.bnImport.UseVisualStyleBackColor = true;
            this.bnImport.Click += new System.EventHandler(this.OnImport);
            // 
            // graphCtrl
            // 
            resources.ApplyResources(this.graphCtrl, "graphCtrl");
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.Viewer = null;
            // 
            // chkbSearchDescription
            // 
            resources.ApplyResources(this.chkbSearchDescription, "chkbSearchDescription");
            this.chkbSearchDescription.Name = "chkbSearchDescription";
            this.chkbSearchDescription.UseVisualStyleBackColor = true;
            // 
            // bnSearch
            // 
            resources.ApplyResources(this.bnSearch, "bnSearch");
            this.bnSearch.Name = "bnSearch";
            this.bnSearch.UseVisualStyleBackColor = true;
            this.bnSearch.Click += new System.EventHandler(this.OnSearch);
            // 
            // tbSearch
            // 
            resources.ApplyResources(this.tbSearch, "tbSearch");
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.TextChanged += new System.EventHandler(this.OnSearchFieldChanged);
            // 
            // lbCount
            // 
            resources.ApplyResources(this.lbCount, "lbCount");
            this.lbCount.Name = "lbCount";
            // 
            // bnNext
            // 
            resources.ApplyResources(this.bnNext, "bnNext");
            this.bnNext.Name = "bnNext";
            this.bnNext.UseVisualStyleBackColor = true;
            this.bnNext.Click += new System.EventHandler(this.OnButtonNext);
            // 
            // bnPrev
            // 
            resources.ApplyResources(this.bnPrev, "bnPrev");
            this.bnPrev.Name = "bnPrev";
            this.bnPrev.UseVisualStyleBackColor = true;
            this.bnPrev.Click += new System.EventHandler(this.OnButtonPrev);
            // 
            // tabCtrlDBItems
            // 
            resources.ApplyResources(this.tabCtrlDBItems, "tabCtrlDBItems");
            this.tabCtrlDBItems.Controls.Add(this.tabPageBox);
            this.tabCtrlDBItems.Controls.Add(this.tabPageCase);
            this.tabCtrlDBItems.Controls.Add(this.tabPageBundle);
            this.tabCtrlDBItems.Controls.Add(this.tabPageCylinder);
            this.tabCtrlDBItems.Controls.Add(this.tabPageInterlayer);
            this.tabCtrlDBItems.Controls.Add(this.tabPagePallet);
            this.tabCtrlDBItems.Controls.Add(this.tabPageTruck);
            this.tabCtrlDBItems.Controls.Add(this.tabPagePalletCorner);
            this.tabCtrlDBItems.Controls.Add(this.tabPagePalletCap);
            this.tabCtrlDBItems.Controls.Add(this.tabPagePalletFilm);
            this.tabCtrlDBItems.Name = "tabCtrlDBItems";
            this.tabCtrlDBItems.SelectedIndex = 0;
            this.tabCtrlDBItems.SelectedIndexChanged += new System.EventHandler(this.OnSelectedTabChanged);
            // 
            // tabPageBox
            // 
            resources.ApplyResources(this.tabPageBox, "tabPageBox");
            this.tabPageBox.Controls.Add(this.gridBoxes);
            this.tabPageBox.Name = "tabPageBox";
            this.tabPageBox.UseVisualStyleBackColor = true;
            // 
            // gridBoxes
            // 
            resources.ApplyResources(this.gridBoxes, "gridBoxes");
            this.gridBoxes.EnableSort = false;
            this.gridBoxes.Name = "gridBoxes";
            this.gridBoxes.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridBoxes.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridBoxes.TabStop = true;
            this.gridBoxes.ToolTipText = "";
            // 
            // tabPageCase
            // 
            resources.ApplyResources(this.tabPageCase, "tabPageCase");
            this.tabPageCase.Controls.Add(this.gridCases);
            this.tabPageCase.Name = "tabPageCase";
            this.tabPageCase.UseVisualStyleBackColor = true;
            // 
            // gridCases
            // 
            this.gridCases.AcceptsInputChar = false;
            resources.ApplyResources(this.gridCases, "gridCases");
            this.gridCases.EnableSort = false;
            this.gridCases.Name = "gridCases";
            this.gridCases.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridCases.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridCases.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridCases.TabStop = true;
            this.gridCases.ToolTipText = "";
            // 
            // tabPageBundle
            // 
            resources.ApplyResources(this.tabPageBundle, "tabPageBundle");
            this.tabPageBundle.Controls.Add(this.gridBundles);
            this.tabPageBundle.Name = "tabPageBundle";
            this.tabPageBundle.UseVisualStyleBackColor = true;
            // 
            // gridBundles
            // 
            this.gridBundles.AcceptsInputChar = false;
            resources.ApplyResources(this.gridBundles, "gridBundles");
            this.gridBundles.EnableSort = false;
            this.gridBundles.Name = "gridBundles";
            this.gridBundles.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridBundles.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridBundles.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridBundles.TabStop = true;
            this.gridBundles.ToolTipText = "";
            // 
            // tabPageCylinder
            // 
            resources.ApplyResources(this.tabPageCylinder, "tabPageCylinder");
            this.tabPageCylinder.Controls.Add(this.gridCylinders);
            this.tabPageCylinder.Name = "tabPageCylinder";
            this.tabPageCylinder.UseVisualStyleBackColor = true;
            // 
            // gridCylinders
            // 
            this.gridCylinders.AcceptsInputChar = false;
            resources.ApplyResources(this.gridCylinders, "gridCylinders");
            this.gridCylinders.EnableSort = false;
            this.gridCylinders.Name = "gridCylinders";
            this.gridCylinders.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridCylinders.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridCylinders.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridCylinders.TabStop = true;
            this.gridCylinders.ToolTipText = "";
            // 
            // tabPageInterlayer
            // 
            resources.ApplyResources(this.tabPageInterlayer, "tabPageInterlayer");
            this.tabPageInterlayer.Controls.Add(this.gridInterlayers);
            this.tabPageInterlayer.Name = "tabPageInterlayer";
            this.tabPageInterlayer.UseVisualStyleBackColor = true;
            // 
            // gridInterlayers
            // 
            this.gridInterlayers.AcceptsInputChar = false;
            resources.ApplyResources(this.gridInterlayers, "gridInterlayers");
            this.gridInterlayers.EnableSort = false;
            this.gridInterlayers.Name = "gridInterlayers";
            this.gridInterlayers.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridInterlayers.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridInterlayers.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridInterlayers.TabStop = true;
            this.gridInterlayers.ToolTipText = "";
            // 
            // tabPagePallet
            // 
            resources.ApplyResources(this.tabPagePallet, "tabPagePallet");
            this.tabPagePallet.Controls.Add(this.gridPallets);
            this.tabPagePallet.Name = "tabPagePallet";
            this.tabPagePallet.UseVisualStyleBackColor = true;
            // 
            // gridPallets
            // 
            this.gridPallets.AcceptsInputChar = false;
            resources.ApplyResources(this.gridPallets, "gridPallets");
            this.gridPallets.EnableSort = false;
            this.gridPallets.Name = "gridPallets";
            this.gridPallets.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridPallets.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridPallets.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridPallets.TabStop = true;
            this.gridPallets.ToolTipText = "";
            // 
            // tabPageTruck
            // 
            resources.ApplyResources(this.tabPageTruck, "tabPageTruck");
            this.tabPageTruck.Controls.Add(this.gridTrucks);
            this.tabPageTruck.Name = "tabPageTruck";
            this.tabPageTruck.UseVisualStyleBackColor = true;
            // 
            // gridTrucks
            // 
            this.gridTrucks.AcceptsInputChar = false;
            resources.ApplyResources(this.gridTrucks, "gridTrucks");
            this.gridTrucks.EnableSort = false;
            this.gridTrucks.Name = "gridTrucks";
            this.gridTrucks.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridTrucks.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridTrucks.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridTrucks.TabStop = true;
            this.gridTrucks.ToolTipText = "";
            // 
            // tabPagePalletCorner
            // 
            resources.ApplyResources(this.tabPagePalletCorner, "tabPagePalletCorner");
            this.tabPagePalletCorner.Controls.Add(this.gridPalletCorners);
            this.tabPagePalletCorner.Name = "tabPagePalletCorner";
            this.tabPagePalletCorner.UseVisualStyleBackColor = true;
            // 
            // gridPalletCorners
            // 
            this.gridPalletCorners.AcceptsInputChar = false;
            resources.ApplyResources(this.gridPalletCorners, "gridPalletCorners");
            this.gridPalletCorners.EnableSort = false;
            this.gridPalletCorners.Name = "gridPalletCorners";
            this.gridPalletCorners.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridPalletCorners.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridPalletCorners.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridPalletCorners.TabStop = true;
            this.gridPalletCorners.ToolTipText = "";
            // 
            // tabPagePalletCap
            // 
            resources.ApplyResources(this.tabPagePalletCap, "tabPagePalletCap");
            this.tabPagePalletCap.Controls.Add(this.gridPalletCaps);
            this.tabPagePalletCap.Name = "tabPagePalletCap";
            this.tabPagePalletCap.UseVisualStyleBackColor = true;
            // 
            // gridPalletCaps
            // 
            this.gridPalletCaps.AcceptsInputChar = false;
            resources.ApplyResources(this.gridPalletCaps, "gridPalletCaps");
            this.gridPalletCaps.EnableSort = false;
            this.gridPalletCaps.Name = "gridPalletCaps";
            this.gridPalletCaps.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridPalletCaps.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridPalletCaps.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridPalletCaps.TabStop = true;
            this.gridPalletCaps.ToolTipText = "";
            // 
            // tabPagePalletFilm
            // 
            resources.ApplyResources(this.tabPagePalletFilm, "tabPagePalletFilm");
            this.tabPagePalletFilm.Controls.Add(this.gridPalletFilms);
            this.tabPagePalletFilm.Name = "tabPagePalletFilm";
            this.tabPagePalletFilm.UseVisualStyleBackColor = true;
            // 
            // gridPalletFilms
            // 
            this.gridPalletFilms.AcceptsInputChar = false;
            resources.ApplyResources(this.gridPalletFilms, "gridPalletFilms");
            this.gridPalletFilms.EnableSort = false;
            this.gridPalletFilms.Name = "gridPalletFilms";
            this.gridPalletFilms.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridPalletFilms.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridPalletFilms.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridPalletFilms.TabStop = true;
            this.gridPalletFilms.ToolTipText = "";
            // 
            // toolStripMain
            // 
            resources.ApplyResources(this.toolStripMain, "toolStripMain");
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBExcel});
            this.toolStripMain.Name = "toolStripMain";
            // 
            // toolStripBExcel
            // 
            resources.ApplyResources(this.toolStripBExcel, "toolStripBExcel");
            this.toolStripBExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBExcel.Name = "toolStripBExcel";
            this.toolStripBExcel.Click += new System.EventHandler(this.OnImportFromExcelFile);
            // 
            // FormShowDatabase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnClose;
            this.Controls.Add(this.splitContainerForm);
            this.Controls.Add(this.toolStripMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormShowDatabase";
            this.ShowInTaskbar = false;
            this.splitContainerForm.Panel1.ResumeLayout(false);
            this.splitContainerForm.Panel2.ResumeLayout(false);
            this.splitContainerForm.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerForm)).EndInit();
            this.splitContainerForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.tabCtrlDBItems.ResumeLayout(false);
            this.tabPageBox.ResumeLayout(false);
            this.tabPageBox.PerformLayout();
            this.tabPageCase.ResumeLayout(false);
            this.tabPageBundle.ResumeLayout(false);
            this.tabPageCylinder.ResumeLayout(false);
            this.tabPageInterlayer.ResumeLayout(false);
            this.tabPagePallet.ResumeLayout(false);
            this.tabPageTruck.ResumeLayout(false);
            this.tabPagePalletCorner.ResumeLayout(false);
            this.tabPagePalletCap.ResumeLayout(false);
            this.tabPagePalletFilm.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TabControl tabCtrlDBItems;
        private System.Windows.Forms.TabPage tabPagePallet;
        private System.Windows.Forms.TabPage tabPagePalletCap;
        private System.Windows.Forms.TabPage tabPageCase;
        private System.Windows.Forms.TabPage tabPageBundle;
        private System.Windows.Forms.TabPage tabPageCylinder;
        private System.Windows.Forms.TabPage tabPageTruck;
        private System.Windows.Forms.TabPage tabPagePalletCorner;
        private System.Windows.Forms.TabPage tabPagePalletFilm;
        private System.Windows.Forms.TabPage tabPageBox;
        private Graphics.Graphics3DControl graphCtrl;
        private System.Windows.Forms.Button bnClose;
        private System.Windows.Forms.Button bnImport;
        private System.Windows.Forms.TabPage tabPageInterlayer;
        private SourceGrid.Grid gridTrucks;
        private SourceGrid.Grid gridPallets;
        private SourceGrid.Grid gridInterlayers;
        private SourceGrid.Grid gridCases;
        private SourceGrid.Grid gridBundles;
        private SourceGrid.Grid gridCylinders;
        private SourceGrid.Grid gridPalletCorners;
        private SourceGrid.Grid gridPalletCaps;
        private SourceGrid.Grid gridPalletFilms;
        private SourceGrid.Grid gridBoxes;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripBExcel;
        protected System.Windows.Forms.SplitContainer splitContainerForm;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Button bnNext;
        private System.Windows.Forms.Button bnPrev;
        private System.Windows.Forms.Button bnSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.CheckBox chkbSearchDescription;
    }
}