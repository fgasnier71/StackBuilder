namespace treeDiM.Basics
{
    partial class UCtrlOptInt
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkbOpt = new System.Windows.Forms.CheckBox();
            this.nudInt = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudInt)).BeginInit();
            this.SuspendLayout();
            // 
            // chkbOpt
            // 
            this.chkbOpt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbOpt.AutoEllipsis = true;
            this.chkbOpt.Location = new System.Drawing.Point(0, 2);
            this.chkbOpt.Name = "chkbOpt";
            this.chkbOpt.Size = new System.Drawing.Size(234, 20);
            this.chkbOpt.TabIndex = 0;
            this.chkbOpt.Text = "Optional value";
            this.chkbOpt.UseVisualStyleBackColor = true;
            this.chkbOpt.CheckedChanged += new System.EventHandler(this.OnCheckChanged);
            // 
            // nudInt
            // 
            this.nudInt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudInt.Location = new System.Drawing.Point(240, 0);
            this.nudInt.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudInt.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudInt.Name = "nudInt";
            this.nudInt.Size = new System.Drawing.Size(60, 20);
            this.nudInt.TabIndex = 1;
            this.nudInt.ValueChanged += new System.EventHandler(this.OnValueChangedLocal);
            this.nudInt.Enter += new System.EventHandler(this.OnEnter);
            this.nudInt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            // 
            // UCtrlOptInt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudInt);
            this.Controls.Add(this.chkbOpt);
            this.MinimumSize = new System.Drawing.Size(100, 20);
            this.Name = "UCtrlOptInt";
            this.Size = new System.Drawing.Size(340, 20);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nudInt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkbOpt;
        private System.Windows.Forms.NumericUpDown nudInt;
    }
}
