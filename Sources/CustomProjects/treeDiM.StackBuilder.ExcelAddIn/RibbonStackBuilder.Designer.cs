namespace treeDiM.StackBuilder.ExcelAddIn
{
    partial class RibbonStackBuilder : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonStackBuilder()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonStackBuilder));
            this.tabAddInStackBuilder = this.Factory.CreateRibbonTab();
            this.gpStackBuilder = this.Factory.CreateRibbonGroup();
            this.toggleRowSheet = this.Factory.CreateRibbonToggleButton();
            this.bnParameters = this.Factory.CreateRibbonButton();
            this.bnCompute = this.Factory.CreateRibbonButton();
            this.gpHelp = this.Factory.CreateRibbonGroup();
            this.bnOpenSampleFile = this.Factory.CreateRibbonButton();
            this.bnWebSite = this.Factory.CreateRibbonButton();
            this.tabAddInStackBuilder.SuspendLayout();
            this.gpStackBuilder.SuspendLayout();
            this.gpHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAddInStackBuilder
            // 
            this.tabAddInStackBuilder.Groups.Add(this.gpStackBuilder);
            this.tabAddInStackBuilder.Groups.Add(this.gpHelp);
            this.tabAddInStackBuilder.Label = "StackBuilder";
            this.tabAddInStackBuilder.Name = "tabAddInStackBuilder";
            // 
            // gpStackBuilder
            // 
            this.gpStackBuilder.Items.Add(this.toggleRowSheet);
            this.gpStackBuilder.Items.Add(this.bnParameters);
            this.gpStackBuilder.Items.Add(this.bnCompute);
            this.gpStackBuilder.Label = "StackBuilder Add-in";
            this.gpStackBuilder.Name = "gpStackBuilder";
            // 
            // toggleRowSheet
            // 
            this.toggleRowSheet.Checked = true;
            this.toggleRowSheet.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleRowSheet.Image = ((System.Drawing.Image)(resources.GetObject("toggleRowSheet.Image")));
            this.toggleRowSheet.Label = "Per row mode";
            this.toggleRowSheet.Name = "toggleRowSheet";
            this.toggleRowSheet.ShowImage = true;
            this.toggleRowSheet.SuperTip = "Switch analysis per row / per sheet";
            this.toggleRowSheet.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OnModeChanged);
            // 
            // bnParameters
            // 
            this.bnParameters.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bnParameters.Image = ((System.Drawing.Image)(resources.GetObject("bnParameters.Image")));
            this.bnParameters.Label = "Settings";
            this.bnParameters.Name = "bnParameters";
            this.bnParameters.ScreenTip = "Settings";
            this.bnParameters.ShowImage = true;
            this.bnParameters.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OnParameters);
            // 
            // bnCompute
            // 
            this.bnCompute.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bnCompute.Image = ((System.Drawing.Image)(resources.GetObject("bnCompute.Image")));
            this.bnCompute.Label = "Compute";
            this.bnCompute.Name = "bnCompute";
            this.bnCompute.ShowImage = true;
            this.bnCompute.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OnCompute);
            // 
            // gpHelp
            // 
            this.gpHelp.Items.Add(this.bnOpenSampleFile);
            this.gpHelp.Items.Add(this.bnWebSite);
            this.gpHelp.Label = "Help";
            this.gpHelp.Name = "gpHelp";
            // 
            // bnOpenSampleFile
            // 
            this.bnOpenSampleFile.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bnOpenSampleFile.Image = ((System.Drawing.Image)(resources.GetObject("bnOpenSampleFile.Image")));
            this.bnOpenSampleFile.Label = "Open sample file";
            this.bnOpenSampleFile.Name = "bnOpenSampleFile";
            this.bnOpenSampleFile.ShowImage = true;
            this.bnOpenSampleFile.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OnOpenSample);
            // 
            // bnWebSite
            // 
            this.bnWebSite.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bnWebSite.Image = ((System.Drawing.Image)(resources.GetObject("bnWebSite.Image")));
            this.bnWebSite.Label = "Web Site";
            this.bnWebSite.Name = "bnWebSite";
            this.bnWebSite.ShowImage = true;
            this.bnWebSite.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OnShowWebSite);
            // 
            // RibbonStackBuilder
            // 
            this.Name = "RibbonStackBuilder";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabAddInStackBuilder);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonStackBuilder_Load);
            this.tabAddInStackBuilder.ResumeLayout(false);
            this.tabAddInStackBuilder.PerformLayout();
            this.gpStackBuilder.ResumeLayout(false);
            this.gpStackBuilder.PerformLayout();
            this.gpHelp.ResumeLayout(false);
            this.gpHelp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabAddInStackBuilder;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup gpStackBuilder;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bnCompute;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bnParameters;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup gpHelp;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bnWebSite;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bnOpenSampleFile;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleRowSheet;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonStackBuilder RibbonStackBuilder
        {
            get { return this.GetRibbon<RibbonStackBuilder>(); }
        }
    }
}
