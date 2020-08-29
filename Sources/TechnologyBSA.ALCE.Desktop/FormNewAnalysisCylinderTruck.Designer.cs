namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewAnalysisCylinderTruck
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
            this.cbTrucks = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbCylinders = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.lbTruck = new System.Windows.Forms.Label();
            this.lbCylinder = new System.Windows.Forms.Label();
            this.lbSelect = new System.Windows.Forms.Label();
            this.checkBoxBestLayersOnly = new System.Windows.Forms.CheckBox();
            this.uCtrlLayerList = new treeDiM.StackBuilder.Graphics.UCtrlLayerList();
            this.uCtrlMinDistanceLoadRoof = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlMinDistanceLoadWall = new treeDiM.Basics.UCtrlDualDouble();
            this.uCtrlPackable = new treeDiM.StackBuilder.Graphics.Controls.UCtrlPackable();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Size = new System.Drawing.Size(666, 20);
            // 
            // cbTrucks
            // 
            this.cbTrucks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrucks.FormattingEnabled = true;
            this.cbTrucks.Location = new System.Drawing.Point(432, 59);
            this.cbTrucks.Name = "cbTrucks";
            this.cbTrucks.Size = new System.Drawing.Size(145, 21);
            this.cbTrucks.TabIndex = 20;
            this.cbTrucks.SelectedIndexChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // cbCylinders
            // 
            this.cbCylinders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCylinders.FormattingEnabled = true;
            this.cbCylinders.Location = new System.Drawing.Point(104, 60);
            this.cbCylinders.Name = "cbCylinders";
            this.cbCylinders.Size = new System.Drawing.Size(145, 21);
            this.cbCylinders.TabIndex = 19;
            this.cbCylinders.SelectedIndexChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // lbTruck
            // 
            this.lbTruck.AutoSize = true;
            this.lbTruck.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTruck.Location = new System.Drawing.Point(367, 63);
            this.lbTruck.Name = "lbTruck";
            this.lbTruck.Size = new System.Drawing.Size(35, 13);
            this.lbTruck.TabIndex = 18;
            this.lbTruck.Text = "Truck";
            // 
            // lbCylinder
            // 
            this.lbCylinder.AutoSize = true;
            this.lbCylinder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCylinder.Location = new System.Drawing.Point(5, 63);
            this.lbCylinder.Name = "lbCylinder";
            this.lbCylinder.Size = new System.Drawing.Size(44, 13);
            this.lbCylinder.TabIndex = 17;
            this.lbCylinder.Text = "Cylinder";
            // 
            // lbSelect
            // 
            this.lbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSelect.AutoSize = true;
            this.lbSelect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbSelect.Location = new System.Drawing.Point(8, 200);
            this.lbSelect.Name = "lbSelect";
            this.lbSelect.Size = new System.Drawing.Size(216, 13);
            this.lbSelect.TabIndex = 33;
            this.lbSelect.Text = "Select one or more layers and click \'Next>\'...";
            // 
            // checkBoxBestLayersOnly
            // 
            this.checkBoxBestLayersOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxBestLayersOnly.AutoSize = true;
            this.checkBoxBestLayersOnly.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxBestLayersOnly.Location = new System.Drawing.Point(8, 519);
            this.checkBoxBestLayersOnly.Name = "checkBoxBestLayersOnly";
            this.checkBoxBestLayersOnly.Size = new System.Drawing.Size(128, 17);
            this.checkBoxBestLayersOnly.TabIndex = 34;
            this.checkBoxBestLayersOnly.Text = "Show best layers only";
            this.checkBoxBestLayersOnly.UseVisualStyleBackColor = true;
            // 
            // uCtrlLayerList
            // 
            this.uCtrlLayerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uCtrlLayerList.AutoScroll = true;
            this.uCtrlLayerList.ButtonSizes = new System.Drawing.Size(150, 150);
            this.uCtrlLayerList.Location = new System.Drawing.Point(0, 218);
            this.uCtrlLayerList.Name = "uCtrlLayerList";
            this.uCtrlLayerList.Show3D = true;
            this.uCtrlLayerList.SingleSelection = false;
            this.uCtrlLayerList.Size = new System.Drawing.Size(784, 289);
            this.uCtrlLayerList.TabIndex = 35;
            // 
            // uCtrlMinDistanceLoadRoof
            // 
            this.uCtrlMinDistanceLoadRoof.Location = new System.Drawing.Point(370, 113);
            this.uCtrlMinDistanceLoadRoof.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMinDistanceLoadRoof.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMinDistanceLoadRoof.Name = "uCtrlMinDistanceLoadRoof";
            this.uCtrlMinDistanceLoadRoof.Size = new System.Drawing.Size(322, 20);
            this.uCtrlMinDistanceLoadRoof.TabIndex = 38;
            this.uCtrlMinDistanceLoadRoof.Text = "Minimum distance load/roof";
            this.uCtrlMinDistanceLoadRoof.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMinDistanceLoadRoof.Value = 0D;
            // 
            // uCtrlMinDistanceLoadWall
            // 
            this.uCtrlMinDistanceLoadWall.Location = new System.Drawing.Point(370, 86);
            this.uCtrlMinDistanceLoadWall.MinValue = -10000D;
            this.uCtrlMinDistanceLoadWall.Name = "uCtrlMinDistanceLoadWall";
            this.uCtrlMinDistanceLoadWall.Size = new System.Drawing.Size(322, 20);
            this.uCtrlMinDistanceLoadWall.TabIndex = 37;
            this.uCtrlMinDistanceLoadWall.Text = "Minimum distance load/wall";
            this.uCtrlMinDistanceLoadWall.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMinDistanceLoadWall.ValueX = 0D;
            this.uCtrlMinDistanceLoadWall.ValueY = 0D;
            // 
            // uCtrlPackable
            // 
            this.uCtrlPackable.Location = new System.Drawing.Point(104, 86);
            this.uCtrlPackable.Name = "uCtrlPackable";
            this.uCtrlPackable.Size = new System.Drawing.Size(145, 107);
            this.uCtrlPackable.TabIndex = 39;
            // 
            // FormNewAnalysisCylinderTruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.uCtrlPackable);
            this.Controls.Add(this.uCtrlMinDistanceLoadRoof);
            this.Controls.Add(this.uCtrlMinDistanceLoadWall);
            this.Controls.Add(this.uCtrlLayerList);
            this.Controls.Add(this.checkBoxBestLayersOnly);
            this.Controls.Add(this.lbSelect);
            this.Controls.Add(this.cbTrucks);
            this.Controls.Add(this.cbCylinders);
            this.Controls.Add(this.lbTruck);
            this.Controls.Add(this.lbCylinder);
            this.Name = "FormNewAnalysisCylinderTruck";
            this.Text = "Create new cylinder/truck analysis...";
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.lbCylinder, 0);
            this.Controls.SetChildIndex(this.lbTruck, 0);
            this.Controls.SetChildIndex(this.cbCylinders, 0);
            this.Controls.SetChildIndex(this.cbTrucks, 0);
            this.Controls.SetChildIndex(this.lbSelect, 0);
            this.Controls.SetChildIndex(this.checkBoxBestLayersOnly, 0);
            this.Controls.SetChildIndex(this.uCtrlLayerList, 0);
            this.Controls.SetChildIndex(this.uCtrlMinDistanceLoadWall, 0);
            this.Controls.SetChildIndex(this.uCtrlMinDistanceLoadRoof, 0);
            this.Controls.SetChildIndex(this.uCtrlPackable, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Graphics.Controls.CCtrlComboFiltered cbTrucks;
        private Graphics.Controls.CCtrlComboFiltered cbCylinders;
        private System.Windows.Forms.Label lbTruck;
        private System.Windows.Forms.Label lbCylinder;
        private System.Windows.Forms.Label lbSelect;
        private System.Windows.Forms.CheckBox checkBoxBestLayersOnly;
        private Graphics.UCtrlLayerList uCtrlLayerList;
        private treeDiM.Basics.UCtrlDouble uCtrlMinDistanceLoadRoof;
        private treeDiM.Basics.UCtrlDualDouble uCtrlMinDistanceLoadWall;
        private Graphics.Controls.UCtrlPackable uCtrlPackable;
    }
}