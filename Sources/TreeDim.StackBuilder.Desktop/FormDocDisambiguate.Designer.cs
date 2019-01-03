namespace treeDiM.StackBuilder.Desktop
{
    partial class FormDocDisambiguate
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
            this.lbApplyToDocument = new System.Windows.Forms.Label();
            this.cbDocuments = new System.Windows.Forms.ComboBox();
            this.bnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbApplyToDocument
            // 
            this.lbApplyToDocument.AutoSize = true;
            this.lbApplyToDocument.Location = new System.Drawing.Point(3, 13);
            this.lbApplyToDocument.Name = "lbApplyToDocument";
            this.lbApplyToDocument.Size = new System.Drawing.Size(95, 13);
            this.lbApplyToDocument.TabIndex = 0;
            this.lbApplyToDocument.Text = "Apply to document";
            // 
            // cbDocuments
            // 
            this.cbDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDocuments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocuments.FormattingEnabled = true;
            this.cbDocuments.Location = new System.Drawing.Point(135, 10);
            this.cbDocuments.Name = "cbDocuments";
            this.cbDocuments.Size = new System.Drawing.Size(168, 21);
            this.cbDocuments.TabIndex = 1;
            this.cbDocuments.SelectedIndexChanged += new System.EventHandler(this.OnDocumentChanged);
            // 
            // bnOK
            // 
            this.bnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Location = new System.Drawing.Point(309, 8);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 2;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // FormDocDisambiguate
            // 
            this.AcceptButton = this.bnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 38);
            this.ControlBox = false;
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.cbDocuments);
            this.Controls.Add(this.lbApplyToDocument);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDocDisambiguate";
            this.ShowIcon = false;
            this.Text = "Disambiguate...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbApplyToDocument;
        private System.Windows.Forms.ComboBox cbDocuments;
        private System.Windows.Forms.Button bnOK;
    }
}