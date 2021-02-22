
namespace treeDiM.StackBuilder.WCFService.Test
{
    partial class FormAddItem
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
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.bnOK = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.bnColor = new System.Windows.Forms.Button();
            this.lbWeight = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.chkbAllowX = new System.Windows.Forms.CheckBox();
            this.chkbAllowY = new System.Windows.Forms.CheckBox();
            this.chkbAllowZ = new System.Windows.Forms.CheckBox();
            this.gbAllowedOrientations = new System.Windows.Forms.GroupBox();
            this.lbColor = new System.Windows.Forms.Label();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            this.gbAllowedOrientations.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dimensions";
            // 
            // nudLength
            // 
            this.nudLength.DecimalPlaces = 1;
            this.nudLength.Location = new System.Drawing.Point(123, 45);
            this.nudLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudLength.Name = "nudLength";
            this.nudLength.Size = new System.Drawing.Size(54, 20);
            this.nudLength.TabIndex = 1;
            // 
            // nudWidth
            // 
            this.nudWidth.DecimalPlaces = 1;
            this.nudWidth.Location = new System.Drawing.Point(183, 45);
            this.nudWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(53, 20);
            this.nudWidth.TabIndex = 2;
            // 
            // nudHeight
            // 
            this.nudHeight.DecimalPlaces = 1;
            this.nudHeight.Location = new System.Drawing.Point(242, 45);
            this.nudHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(54, 20);
            this.nudHeight.TabIndex = 3;
            // 
            // bnOK
            // 
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Location = new System.Drawing.Point(366, 5);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 4;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.Chocolate;
            // 
            // bnColor
            // 
            this.bnColor.Location = new System.Drawing.Point(15, 143);
            this.bnColor.Name = "bnColor";
            this.bnColor.Size = new System.Drawing.Size(75, 23);
            this.bnColor.TabIndex = 5;
            this.bnColor.Text = "Color...";
            this.bnColor.UseVisualStyleBackColor = true;
            this.bnColor.Click += new System.EventHandler(this.OnBnColor);
            // 
            // lbWeight
            // 
            this.lbWeight.AutoSize = true;
            this.lbWeight.Location = new System.Drawing.Point(12, 79);
            this.lbWeight.Name = "lbWeight";
            this.lbWeight.Size = new System.Drawing.Size(41, 13);
            this.lbWeight.TabIndex = 6;
            this.lbWeight.Text = "Weight";
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(12, 112);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(44, 13);
            this.lbNumber.TabIndex = 7;
            this.lbNumber.Text = "Number";
            // 
            // nudWeight
            // 
            this.nudWeight.DecimalPlaces = 3;
            this.nudWeight.Location = new System.Drawing.Point(123, 77);
            this.nudWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(54, 20);
            this.nudWeight.TabIndex = 8;
            // 
            // nudNumber
            // 
            this.nudNumber.Location = new System.Drawing.Point(123, 110);
            this.nudNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNumber.Name = "nudNumber";
            this.nudNumber.Size = new System.Drawing.Size(54, 20);
            this.nudNumber.TabIndex = 9;
            // 
            // chkbAllowX
            // 
            this.chkbAllowX.AutoSize = true;
            this.chkbAllowX.Checked = true;
            this.chkbAllowX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbAllowX.Location = new System.Drawing.Point(25, 18);
            this.chkbAllowX.Name = "chkbAllowX";
            this.chkbAllowX.Size = new System.Drawing.Size(33, 17);
            this.chkbAllowX.TabIndex = 10;
            this.chkbAllowX.Text = "X";
            this.chkbAllowX.UseVisualStyleBackColor = true;
            this.chkbAllowX.CheckedChanged += new System.EventHandler(this.OnOrientationsChanged);
            // 
            // chkbAllowY
            // 
            this.chkbAllowY.AutoSize = true;
            this.chkbAllowY.Checked = true;
            this.chkbAllowY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbAllowY.Location = new System.Drawing.Point(88, 18);
            this.chkbAllowY.Name = "chkbAllowY";
            this.chkbAllowY.Size = new System.Drawing.Size(33, 17);
            this.chkbAllowY.TabIndex = 11;
            this.chkbAllowY.Text = "Y";
            this.chkbAllowY.UseVisualStyleBackColor = true;
            this.chkbAllowY.CheckedChanged += new System.EventHandler(this.OnOrientationsChanged);
            // 
            // chkbAllowZ
            // 
            this.chkbAllowZ.AutoSize = true;
            this.chkbAllowZ.Checked = true;
            this.chkbAllowZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbAllowZ.Location = new System.Drawing.Point(149, 18);
            this.chkbAllowZ.Name = "chkbAllowZ";
            this.chkbAllowZ.Size = new System.Drawing.Size(33, 17);
            this.chkbAllowZ.TabIndex = 12;
            this.chkbAllowZ.Text = "Z";
            this.chkbAllowZ.UseVisualStyleBackColor = true;
            this.chkbAllowZ.CheckedChanged += new System.EventHandler(this.OnOrientationsChanged);
            // 
            // gbAllowedOrientations
            // 
            this.gbAllowedOrientations.Controls.Add(this.chkbAllowX);
            this.gbAllowedOrientations.Controls.Add(this.chkbAllowZ);
            this.gbAllowedOrientations.Controls.Add(this.chkbAllowY);
            this.gbAllowedOrientations.Location = new System.Drawing.Point(15, 172);
            this.gbAllowedOrientations.Name = "gbAllowedOrientations";
            this.gbAllowedOrientations.Size = new System.Drawing.Size(200, 40);
            this.gbAllowedOrientations.TabIndex = 13;
            this.gbAllowedOrientations.TabStop = false;
            this.gbAllowedOrientations.Text = "Allowed orientations";
            // 
            // lbColor
            // 
            this.lbColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbColor.Location = new System.Drawing.Point(120, 143);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(57, 23);
            this.lbColor.TabIndex = 14;
            // 
            // bnCancel
            // 
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(366, 35);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 15;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(12, 15);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 16;
            this.lbName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(123, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(173, 20);
            this.tbName.TabIndex = 17;
            // 
            // FormAddItem
            // 
            this.AcceptButton = this.bnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(453, 216);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.gbAllowedOrientations);
            this.Controls.Add(this.nudNumber);
            this.Controls.Add(this.nudWeight);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.lbWeight);
            this.Controls.Add(this.bnColor);
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.nudHeight);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.nudLength);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddItem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add item...";
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            this.gbAllowedOrientations.ResumeLayout(false);
            this.gbAllowedOrientations.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button bnColor;
        private System.Windows.Forms.Label lbWeight;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.CheckBox chkbAllowX;
        private System.Windows.Forms.CheckBox chkbAllowY;
        private System.Windows.Forms.CheckBox chkbAllowZ;
        private System.Windows.Forms.GroupBox gbAllowedOrientations;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
    }
}