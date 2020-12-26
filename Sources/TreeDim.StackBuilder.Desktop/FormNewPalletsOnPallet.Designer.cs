
namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewPalletsOnPallet
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
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.lbInputPallet1 = new System.Windows.Forms.Label();
            this.lbInputPallet2 = new System.Windows.Forms.Label();
            this.lbInputPallet3 = new System.Windows.Forms.Label();
            this.lbInputPallet4 = new System.Windows.Forms.Label();
            this.graphCtrl = new treeDiM.StackBuilder.Graphics.Graphics3DControl();
            this.cbInputPallet1 = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbInputPallet2 = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbInputPallet3 = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbInputPallet4 = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbDestinationPallet = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // bnOk
            // 
            this.bnOk.Location = new System.Drawing.Point(576, 10);
            // 
            // bnCancel
            // 
            this.bnCancel.Location = new System.Drawing.Point(575, 38);
            // 
            // tbDescription
            // 
            this.tbDescription.Size = new System.Drawing.Size(453, 20);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Destination pallet";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 67);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(111, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Load 2 half pallets";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 90);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(127, 17);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Load 4 quarter pallets";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // lbInputPallet1
            // 
            this.lbInputPallet1.AutoSize = true;
            this.lbInputPallet1.Location = new System.Drawing.Point(21, 125);
            this.lbInputPallet1.Name = "lbInputPallet1";
            this.lbInputPallet1.Size = new System.Drawing.Size(68, 13);
            this.lbInputPallet1.TabIndex = 16;
            this.lbInputPallet1.Text = "Input pallet 1";
            // 
            // lbInputPallet2
            // 
            this.lbInputPallet2.AutoSize = true;
            this.lbInputPallet2.Location = new System.Drawing.Point(21, 151);
            this.lbInputPallet2.Name = "lbInputPallet2";
            this.lbInputPallet2.Size = new System.Drawing.Size(68, 13);
            this.lbInputPallet2.TabIndex = 17;
            this.lbInputPallet2.Text = "Input pallet 2";
            // 
            // lbInputPallet3
            // 
            this.lbInputPallet3.AutoSize = true;
            this.lbInputPallet3.Location = new System.Drawing.Point(21, 177);
            this.lbInputPallet3.Name = "lbInputPallet3";
            this.lbInputPallet3.Size = new System.Drawing.Size(68, 13);
            this.lbInputPallet3.TabIndex = 18;
            this.lbInputPallet3.Text = "Input pallet 3";
            // 
            // lbInputPallet4
            // 
            this.lbInputPallet4.AutoSize = true;
            this.lbInputPallet4.Location = new System.Drawing.Point(21, 203);
            this.lbInputPallet4.Name = "lbInputPallet4";
            this.lbInputPallet4.Size = new System.Drawing.Size(68, 13);
            this.lbInputPallet4.TabIndex = 19;
            this.lbInputPallet4.Text = "Input pallet 4";
            // 
            // graphCtrl
            // 
            this.graphCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphCtrl.AngleHoriz = 45D;
            this.graphCtrl.Location = new System.Drawing.Point(309, 125);
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.Size = new System.Drawing.Size(338, 225);
            this.graphCtrl.TabIndex = 20;
            this.graphCtrl.Viewer = null;
            // 
            // cbInputPallet1
            // 
            this.cbInputPallet1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputPallet1.FormattingEnabled = true;
            this.cbInputPallet1.Location = new System.Drawing.Point(111, 122);
            this.cbInputPallet1.Name = "cbInputPallet1";
            this.cbInputPallet1.Size = new System.Drawing.Size(158, 21);
            this.cbInputPallet1.TabIndex = 21;
            // 
            // cbInputPallet2
            // 
            this.cbInputPallet2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputPallet2.FormattingEnabled = true;
            this.cbInputPallet2.Location = new System.Drawing.Point(111, 148);
            this.cbInputPallet2.Name = "cbInputPallet2";
            this.cbInputPallet2.Size = new System.Drawing.Size(158, 21);
            this.cbInputPallet2.TabIndex = 22;
            // 
            // cbInputPallet3
            // 
            this.cbInputPallet3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputPallet3.FormattingEnabled = true;
            this.cbInputPallet3.Location = new System.Drawing.Point(111, 174);
            this.cbInputPallet3.Name = "cbInputPallet3";
            this.cbInputPallet3.Size = new System.Drawing.Size(158, 21);
            this.cbInputPallet3.TabIndex = 23;
            // 
            // cbInputPallet4
            // 
            this.cbInputPallet4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputPallet4.FormattingEnabled = true;
            this.cbInputPallet4.Location = new System.Drawing.Point(111, 200);
            this.cbInputPallet4.Name = "cbInputPallet4";
            this.cbInputPallet4.Size = new System.Drawing.Size(158, 21);
            this.cbInputPallet4.TabIndex = 24;
            // 
            // cbDestinationPallet
            // 
            this.cbDestinationPallet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDestinationPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestinationPallet.FormattingEnabled = true;
            this.cbDestinationPallet.Location = new System.Drawing.Point(426, 68);
            this.cbDestinationPallet.Name = "cbDestinationPallet";
            this.cbDestinationPallet.Size = new System.Drawing.Size(138, 21);
            this.cbDestinationPallet.TabIndex = 25;
            // 
            // FormNewPalletsOnPallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 375);
            this.Controls.Add(this.cbDestinationPallet);
            this.Controls.Add(this.cbInputPallet4);
            this.Controls.Add(this.cbInputPallet3);
            this.Controls.Add(this.cbInputPallet2);
            this.Controls.Add(this.cbInputPallet1);
            this.Controls.Add(this.graphCtrl);
            this.Controls.Add(this.lbInputPallet4);
            this.Controls.Add(this.lbInputPallet3);
            this.Controls.Add(this.lbInputPallet2);
            this.Controls.Add(this.lbInputPallet1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Name = "FormNewPalletsOnPallet";
            this.Text = "Pallets on pallet...";
            this.Controls.SetChildIndex(this.bnOk, 0);
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.radioButton1, 0);
            this.Controls.SetChildIndex(this.radioButton2, 0);
            this.Controls.SetChildIndex(this.lbInputPallet1, 0);
            this.Controls.SetChildIndex(this.lbInputPallet2, 0);
            this.Controls.SetChildIndex(this.lbInputPallet3, 0);
            this.Controls.SetChildIndex(this.lbInputPallet4, 0);
            this.Controls.SetChildIndex(this.graphCtrl, 0);
            this.Controls.SetChildIndex(this.cbInputPallet1, 0);
            this.Controls.SetChildIndex(this.cbInputPallet2, 0);
            this.Controls.SetChildIndex(this.cbInputPallet3, 0);
            this.Controls.SetChildIndex(this.cbInputPallet4, 0);
            this.Controls.SetChildIndex(this.cbDestinationPallet, 0);
            ((System.ComponentModel.ISupportInitialize)(this.graphCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label lbInputPallet1;
        private System.Windows.Forms.Label lbInputPallet2;
        private System.Windows.Forms.Label lbInputPallet3;
        private System.Windows.Forms.Label lbInputPallet4;
        private Graphics.Graphics3DControl graphCtrl;
        private treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered cbInputPallet1;
        private treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered cbInputPallet2;
        private treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered cbInputPallet3;
        private treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered cbInputPallet4;
        private treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered cbDestinationPallet;
    }
}