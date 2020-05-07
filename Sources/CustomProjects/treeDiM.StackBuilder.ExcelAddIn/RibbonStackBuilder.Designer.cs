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
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl1 = this.Factory.CreateRibbonDropDownItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonStackBuilder));
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl2 = this.Factory.CreateRibbonDropDownItem();
            this.tabAddInStackBuilder = this.Factory.CreateRibbonTab();
            this.gpStackBuilder = this.Factory.CreateRibbonGroup();
            this.cbMode = this.Factory.CreateRibbonDropDown();
            this.gpSettings = this.Factory.CreateRibbonGroup();
            this.bnParameters = this.Factory.CreateRibbonButton();
            this.gpHelp = this.Factory.CreateRibbonGroup();
            this.bnOpenSampleFile = this.Factory.CreateRibbonButton();
            this.bnHelp = this.Factory.CreateRibbonButton();
            this.tabAddInStackBuilder.SuspendLayout();
            this.gpStackBuilder.SuspendLayout();
            this.gpSettings.SuspendLayout();
            this.gpHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAddInStackBuilder
            // 
            this.tabAddInStackBuilder.Groups.Add(this.gpStackBuilder);
            this.tabAddInStackBuilder.Groups.Add(this.gpSettings);
            this.tabAddInStackBuilder.Groups.Add(this.gpHelp);
            this.tabAddInStackBuilder.Label = "StackBuilder";
            this.tabAddInStackBuilder.Name = "tabAddInStackBuilder";
            // 
            // gpStackBuilder
            // 
            this.gpStackBuilder.Items.Add(this.cbMode);
            this.gpStackBuilder.Label = "StackBuilder Add-in";
            this.gpStackBuilder.Name = "gpStackBuilder";
            // 
            // cbMode
            // 
            ribbonDropDownItemImpl1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonDropDownItemImpl1.Image")));
            ribbonDropDownItemImpl1.Label = "Per sheet";
            ribbonDropDownItemImpl1.ScreenTip = "Per sheet";
            ribbonDropDownItemImpl2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonDropDownItemImpl2.Image")));
            ribbonDropDownItemImpl2.Label = "Per row";
            ribbonDropDownItemImpl2.ScreenTip = "Per row";
            this.cbMode.Items.Add(ribbonDropDownItemImpl1);
            this.cbMode.Items.Add(ribbonDropDownItemImpl2);
            this.cbMode.Label = "Mode";
            this.cbMode.Name = "cbMode";
            this.cbMode.SelectionChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OnModeChanged);
            // 
            // gpSettings
            // 
            this.gpSettings.Items.Add(this.bnParameters);
            this.gpSettings.Label = "Settings";
            this.gpSettings.Name = "gpSettings";
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
            // gpHelp
            // 
            this.gpHelp.Items.Add(this.bnOpenSampleFile);
            this.gpHelp.Items.Add(this.bnHelp);
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
            // bnHelp
            // 
            this.bnHelp.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bnHelp.Image = ((System.Drawing.Image)(resources.GetObject("bnHelp.Image")));
            this.bnHelp.Label = "Help";
            this.bnHelp.Name = "bnHelp";
            this.bnHelp.ShowImage = true;
            this.bnHelp.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OnShowHelpPage);
            // 
            // RibbonStackBuilder
            // 
            this.Name = "RibbonStackBuilder";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabAddInStackBuilder);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.OnRibbonStackBuilderLoad);
            this.tabAddInStackBuilder.ResumeLayout(false);
            this.tabAddInStackBuilder.PerformLayout();
            this.gpStackBuilder.ResumeLayout(false);
            this.gpStackBuilder.PerformLayout();
            this.gpSettings.ResumeLayout(false);
            this.gpSettings.PerformLayout();
            this.gpHelp.ResumeLayout(false);
            this.gpHelp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabAddInStackBuilder;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup gpStackBuilder;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup gpHelp;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bnOpenSampleFile;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup gpSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown cbMode;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bnParameters;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bnHelp;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonStackBuilder RibbonStackBuilder
        {
            get { return this.GetRibbon<RibbonStackBuilder>(); }
        }
    }
}
