namespace treeDiM.StackBuilder.Desktop
{
    partial class FormExporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExporter));
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.bnSave = new System.Windows.Forms.Button();
            this.bnClose = new System.Windows.Forms.Button();
            this.cbCoordinates = new System.Windows.Forms.ComboBox();
            this.lbCoordinates = new System.Windows.Forms.Label();
            this.lbFormat = new System.Windows.Forms.Label();
            this.cbFileFormat = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerLayer = new System.Windows.Forms.SplitContainer();
            this.cbLayers = new System.Windows.Forms.ComboBox();
            this.lbLayers = new System.Windows.Forms.Label();
            this.layerEditor = new treeDiM.StackBuilder.Graphics.Graphics2DRobotDropEditor();
            this.textEditorControl = new ICSharpCode.TextEditor.TextEditorControlEx();
            this.saveExportFile = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLayer)).BeginInit();
            this.splitContainerLayer.Panel1.SuspendLayout();
            this.splitContainerLayer.Panel2.SuspendLayout();
            this.splitContainerLayer.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainerHoriz.Panel1.Controls.Add(this.bnSave);
            this.splitContainerHoriz.Panel1.Controls.Add(this.bnClose);
            this.splitContainerHoriz.Panel1.Controls.Add(this.cbCoordinates);
            this.splitContainerHoriz.Panel1.Controls.Add(this.lbCoordinates);
            this.splitContainerHoriz.Panel1.Controls.Add(this.lbFormat);
            this.splitContainerHoriz.Panel1.Controls.Add(this.cbFileFormat);
            // 
            // splitContainerHoriz.Panel2
            // 
            this.splitContainerHoriz.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerHoriz.Size = new System.Drawing.Size(800, 450);
            this.splitContainerHoriz.SplitterDistance = 75;
            this.splitContainerHoriz.TabIndex = 0;
            // 
            // bnSave
            // 
            this.bnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnSave.Location = new System.Drawing.Point(713, 38);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(75, 23);
            this.bnSave.TabIndex = 5;
            this.bnSave.Text = "Export to file...";
            this.bnSave.UseVisualStyleBackColor = true;
            this.bnSave.Click += new System.EventHandler(this.OnExport);
            // 
            // bnClose
            // 
            this.bnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnClose.Location = new System.Drawing.Point(713, 8);
            this.bnClose.Name = "bnClose";
            this.bnClose.Size = new System.Drawing.Size(75, 23);
            this.bnClose.TabIndex = 4;
            this.bnClose.Text = "Close";
            this.bnClose.UseVisualStyleBackColor = true;
            // 
            // cbCoordinates
            // 
            this.cbCoordinates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoordinates.FormattingEnabled = true;
            this.cbCoordinates.Items.AddRange(new object[] {
            "Case corner",
            "Case center"});
            this.cbCoordinates.Location = new System.Drawing.Point(342, 10);
            this.cbCoordinates.Name = "cbCoordinates";
            this.cbCoordinates.Size = new System.Drawing.Size(140, 21);
            this.cbCoordinates.TabIndex = 3;
            this.cbCoordinates.SelectedIndexChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // lbCoordinates
            // 
            this.lbCoordinates.AutoSize = true;
            this.lbCoordinates.Location = new System.Drawing.Point(256, 13);
            this.lbCoordinates.Name = "lbCoordinates";
            this.lbCoordinates.Size = new System.Drawing.Size(63, 13);
            this.lbCoordinates.TabIndex = 2;
            this.lbCoordinates.Text = "Coordinates";
            // 
            // lbFormat
            // 
            this.lbFormat.AutoSize = true;
            this.lbFormat.Location = new System.Drawing.Point(5, 13);
            this.lbFormat.Name = "lbFormat";
            this.lbFormat.Size = new System.Drawing.Size(55, 13);
            this.lbFormat.TabIndex = 1;
            this.lbFormat.Text = "File format";
            // 
            // cbFileFormat
            // 
            this.cbFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFileFormat.FormattingEnabled = true;
            this.cbFileFormat.Items.AddRange(new object[] {
            "xml",
            "csv (default)",
            "csv (TechnologyBSA)",
            "csv (FM Logistic)"});
            this.cbFileFormat.Location = new System.Drawing.Point(91, 10);
            this.cbFileFormat.Name = "cbFileFormat";
            this.cbFileFormat.Size = new System.Drawing.Size(140, 21);
            this.cbFileFormat.TabIndex = 0;
            this.cbFileFormat.SelectedIndexChanged += new System.EventHandler(this.OnExportFormatChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainerLayer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textEditorControl);
            this.splitContainer1.Size = new System.Drawing.Size(800, 371);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainerLayer
            // 
            this.splitContainerLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLayer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerLayer.IsSplitterFixed = true;
            this.splitContainerLayer.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLayer.Name = "splitContainerLayer";
            this.splitContainerLayer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLayer.Panel1
            // 
            this.splitContainerLayer.Panel1.Controls.Add(this.cbLayers);
            this.splitContainerLayer.Panel1.Controls.Add(this.lbLayers);
            // 
            // splitContainerLayer.Panel2
            // 
            this.splitContainerLayer.Panel2.Controls.Add(this.layerEditor);
            this.splitContainerLayer.Size = new System.Drawing.Size(380, 371);
            this.splitContainerLayer.SplitterDistance = 35;
            this.splitContainerLayer.TabIndex = 3;
            // 
            // cbLayers
            // 
            this.cbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLayers.FormattingEnabled = true;
            this.cbLayers.Location = new System.Drawing.Point(91, 8);
            this.cbLayers.Name = "cbLayers";
            this.cbLayers.Size = new System.Drawing.Size(140, 21);
            this.cbLayers.TabIndex = 1;
            // 
            // lbLayers
            // 
            this.lbLayers.AutoSize = true;
            this.lbLayers.Location = new System.Drawing.Point(5, 11);
            this.lbLayers.Name = "lbLayers";
            this.lbLayers.Size = new System.Drawing.Size(38, 13);
            this.lbLayers.TabIndex = 2;
            this.lbLayers.Text = "Layers";
            // 
            // layerEditor
            // 
            this.layerEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layerEditor.Layer = null;
            this.layerEditor.Location = new System.Drawing.Point(0, 0);
            this.layerEditor.Name = "layerEditor";
            this.layerEditor.Size = new System.Drawing.Size(380, 332);
            this.layerEditor.TabIndex = 0;
            // 
            // textEditorControl
            // 
            this.textEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl.EnableFolding = false;
            this.textEditorControl.Font = new System.Drawing.Font("Courier New", 10F);
            this.textEditorControl.Location = new System.Drawing.Point(0, 0);
            this.textEditorControl.Name = "textEditorControl";
            this.textEditorControl.Size = new System.Drawing.Size(416, 371);
            this.textEditorControl.SyntaxHighlighting = "XML";
            this.textEditorControl.TabIndex = 0;
            // 
            // FormExporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnClose;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainerHoriz);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormExporter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Export...";
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel1.PerformLayout();
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerLayer.Panel1.ResumeLayout(false);
            this.splitContainerLayer.Panel1.PerformLayout();
            this.splitContainerLayer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLayer)).EndInit();
            this.splitContainerLayer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.ComboBox cbCoordinates;
        private System.Windows.Forms.Label lbCoordinates;
        private System.Windows.Forms.Label lbFormat;
        private System.Windows.Forms.ComboBox cbFileFormat;
        private ICSharpCode.TextEditor.TextEditorControlEx textEditorControl;
        private System.Windows.Forms.Button bnSave;
        private System.Windows.Forms.Button bnClose;
        private System.Windows.Forms.SaveFileDialog saveExportFile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Graphics.Graphics2DRobotDropEditor layerEditor;
        private System.Windows.Forms.SplitContainer splitContainerLayer;
        private System.Windows.Forms.Label lbLayers;
        private System.Windows.Forms.ComboBox cbLayers;
    }
}