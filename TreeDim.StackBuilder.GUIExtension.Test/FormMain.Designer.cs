namespace treeDiM.StackBuilder.GUIExtension.Test
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
            this.bnCasePalletAnalysis = new System.Windows.Forms.Button();
            this.bnBoxCasePalletOptimization = new System.Windows.Forms.Button();
            this.bnBundlePalletAnalysis = new System.Windows.Forms.Button();
            this.bnBundleCaseAnalysis = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.uCtrlDimensions = new treeDiM.StackBuilder.Basics.UCtrlTriDouble();
            this.bnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bnCasePalletAnalysis
            // 
            this.bnCasePalletAnalysis.Location = new System.Drawing.Point(12, 106);
            this.bnCasePalletAnalysis.Name = "bnCasePalletAnalysis";
            this.bnCasePalletAnalysis.Size = new System.Drawing.Size(178, 22);
            this.bnCasePalletAnalysis.TabIndex = 0;
            this.bnCasePalletAnalysis.Text = "Case / Pallet analysis";
            this.bnCasePalletAnalysis.UseVisualStyleBackColor = true;
            this.bnCasePalletAnalysis.Click += new System.EventHandler(this.onAnalysisCasePallet);
            // 
            // bnBoxCasePalletOptimization
            // 
            this.bnBoxCasePalletOptimization.Location = new System.Drawing.Point(12, 132);
            this.bnBoxCasePalletOptimization.Name = "bnBoxCasePalletOptimization";
            this.bnBoxCasePalletOptimization.Size = new System.Drawing.Size(178, 22);
            this.bnBoxCasePalletOptimization.TabIndex = 1;
            this.bnBoxCasePalletOptimization.Text = "Box / Case / Pallet optimization ";
            this.bnBoxCasePalletOptimization.UseVisualStyleBackColor = true;
            this.bnBoxCasePalletOptimization.Click += new System.EventHandler(this.onBoxCasePalletOptimisation);
            // 
            // bnBundlePalletAnalysis
            // 
            this.bnBundlePalletAnalysis.Location = new System.Drawing.Point(12, 159);
            this.bnBundlePalletAnalysis.Name = "bnBundlePalletAnalysis";
            this.bnBundlePalletAnalysis.Size = new System.Drawing.Size(178, 23);
            this.bnBundlePalletAnalysis.TabIndex = 2;
            this.bnBundlePalletAnalysis.Text = "Bundle / Pallet analysis";
            this.bnBundlePalletAnalysis.UseVisualStyleBackColor = true;
            this.bnBundlePalletAnalysis.Click += new System.EventHandler(this.onAnalysisBundlePallet);
            // 
            // bnBundleCaseAnalysis
            // 
            this.bnBundleCaseAnalysis.Location = new System.Drawing.Point(12, 188);
            this.bnBundleCaseAnalysis.Name = "bnBundleCaseAnalysis";
            this.bnBundleCaseAnalysis.Size = new System.Drawing.Size(178, 23);
            this.bnBundleCaseAnalysis.TabIndex = 3;
            this.bnBundleCaseAnalysis.Text = "Bundle / Case analysis";
            this.bnBundleCaseAnalysis.UseVisualStyleBackColor = true;
            this.bnBundleCaseAnalysis.Click += new System.EventHandler(this.onAnalysisBundleCase);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(13, 13);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(129, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(163, 20);
            this.tbName.TabIndex = 5;
            // 
            // uCtrlDimensions
            // 
            this.uCtrlDimensions.Location = new System.Drawing.Point(13, 40);
            this.uCtrlDimensions.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uCtrlDimensions.Name = "uCtrlDimensions";
            this.uCtrlDimensions.Size = new System.Drawing.Size(350, 20);
            this.uCtrlDimensions.TabIndex = 6;
            this.uCtrlDimensions.Text = "Dimensions";
            this.uCtrlDimensions.Unit = treeDiM.StackBuilder.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDimensions.ValueX = 0D;
            this.uCtrlDimensions.ValueY = 0D;
            this.uCtrlDimensions.ValueZ = 0D;
            // 
            // bnClose
            // 
            this.bnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnClose.Location = new System.Drawing.Point(377, 8);
            this.bnClose.Name = "bnClose";
            this.bnClose.Size = new System.Drawing.Size(75, 23);
            this.bnClose.TabIndex = 7;
            this.bnClose.Text = "Close";
            this.bnClose.UseVisualStyleBackColor = true;
            this.bnClose.Click += new System.EventHandler(this.onClose);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnClose;
            this.ClientSize = new System.Drawing.Size(464, 262);
            this.Controls.Add(this.bnClose);
            this.Controls.Add(this.uCtrlDimensions);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.bnBundleCaseAnalysis);
            this.Controls.Add(this.bnBundlePalletAnalysis);
            this.Controls.Add(this.bnBoxCasePalletOptimization);
            this.Controls.Add(this.bnCasePalletAnalysis);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "GUIExtension.Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnCasePalletAnalysis;
        private System.Windows.Forms.Button bnBoxCasePalletOptimization;
        private System.Windows.Forms.Button bnBundlePalletAnalysis;
        private System.Windows.Forms.Button bnBundleCaseAnalysis;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private Basics.UCtrlTriDouble uCtrlDimensions;
        private System.Windows.Forms.Button bnClose;
    }
}

