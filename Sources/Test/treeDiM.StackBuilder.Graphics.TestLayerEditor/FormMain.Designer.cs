namespace treeDiM.StackBuilder.Graphics.TestLayerEditor
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.layerEditor = new treeDiM.StackBuilder.Graphics.Graphics2DLayerEditor();
            this.graphics2DLayerEditor1 = new treeDiM.StackBuilder.Graphics.Graphics2DLayerEditor();
            this.SuspendLayout();
            // 
            // layerEditor
            // 
            this.layerEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layerEditor.Location = new System.Drawing.Point(363, 12);
            this.layerEditor.Name = "layerEditor";
            this.layerEditor.Positions = null;
            this.layerEditor.PtMax = ((Sharp3D.Math.Core.Vector2D)(resources.GetObject("layerEditor.PtMax")));
            this.layerEditor.PtMin = ((Sharp3D.Math.Core.Vector2D)(resources.GetObject("layerEditor.PtMin")));
            this.layerEditor.Size = new System.Drawing.Size(425, 426);
            this.layerEditor.TabIndex = 0;
            // 
            // graphics2DLayerEditor1
            // 
            this.graphics2DLayerEditor1.Location = new System.Drawing.Point(0, 0);
            this.graphics2DLayerEditor1.Name = "graphics2DLayerEditor1";
            this.graphics2DLayerEditor1.Positions = null;
            this.graphics2DLayerEditor1.PtMax = ((Sharp3D.Math.Core.Vector2D)(resources.GetObject("graphics2DLayerEditor1.PtMax")));
            this.graphics2DLayerEditor1.PtMin = ((Sharp3D.Math.Core.Vector2D)(resources.GetObject("graphics2DLayerEditor1.PtMin")));
            this.graphics2DLayerEditor1.Size = new System.Drawing.Size(150, 150);
            this.graphics2DLayerEditor1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layerEditor);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Graphics2DLayerEditor graphics2DLayerEditor1;
        private Graphics2DLayerEditor layerEditor;
    }
}

