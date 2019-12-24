namespace treeDiM.StackBuilder.Desktop
{
    partial class FormNewAnalysisHCylTruck
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbCylinders = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.cbTrucks = new treeDiM.StackBuilder.Graphics.Controls.CCtrlComboFiltered();
            this.uCtrlMinDistanceLoadRoof = new treeDiM.Basics.UCtrlDouble();
            this.uCtrlMinDistanceLoadWall = new treeDiM.Basics.UCtrlDualDouble();
            this.uCtrlPackable = new treeDiM.StackBuilder.Graphics.Controls.UCtrlPackable();
            this.uCtrlHCylLayoutList = new treeDiM.StackBuilder.Graphics.Controls.UCtrlHCylLayoutList();
            this.tabControlConstraints = new System.Windows.Forms.TabControl();
            this.tabPageStopCriterions = new System.Windows.Forms.TabPage();
            this.uCtrlOptMaximumNumber = new treeDiM.Basics.UCtrlOptInt();
            this.uCtrlOptMaximumWeight = new treeDiM.Basics.UCtrlOptDouble();
            this.tbPageMargins = new System.Windows.Forms.TabPage();
            this.tabControlConstraints.SuspendLayout();
            this.tabPageStopCriterions.SuspendLayout();
            this.tbPageMargins.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Size = new System.Drawing.Size(666, 20);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cylinders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Trucks";
            // 
            // cbCylinders
            // 
            this.cbCylinders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCylinders.FormattingEnabled = true;
            this.cbCylinders.Location = new System.Drawing.Point(104, 63);
            this.cbCylinders.Name = "cbCylinders";
            this.cbCylinders.Size = new System.Drawing.Size(145, 21);
            this.cbCylinders.TabIndex = 15;
            // 
            // cbTrucks
            // 
            this.cbTrucks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrucks.FormattingEnabled = true;
            this.cbTrucks.Location = new System.Drawing.Point(487, 63);
            this.cbTrucks.Name = "cbTrucks";
            this.cbTrucks.Size = new System.Drawing.Size(195, 21);
            this.cbTrucks.TabIndex = 16;
            // 
            // uCtrlMinDistanceLoadRoof
            // 
            this.uCtrlMinDistanceLoadRoof.Location = new System.Drawing.Point(6, 32);
            this.uCtrlMinDistanceLoadRoof.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlMinDistanceLoadRoof.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlMinDistanceLoadRoof.Name = "uCtrlMinDistanceLoadRoof";
            this.uCtrlMinDistanceLoadRoof.Size = new System.Drawing.Size(322, 20);
            this.uCtrlMinDistanceLoadRoof.TabIndex = 40;
            this.uCtrlMinDistanceLoadRoof.Text = "Minimum distance load/roof";
            this.uCtrlMinDistanceLoadRoof.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            // 
            // uCtrlMinDistanceLoadWall
            // 
            this.uCtrlMinDistanceLoadWall.Location = new System.Drawing.Point(6, 6);
            this.uCtrlMinDistanceLoadWall.MinValue = -10000D;
            this.uCtrlMinDistanceLoadWall.Name = "uCtrlMinDistanceLoadWall";
            this.uCtrlMinDistanceLoadWall.Size = new System.Drawing.Size(322, 20);
            this.uCtrlMinDistanceLoadWall.TabIndex = 39;
            this.uCtrlMinDistanceLoadWall.Text = "Minimum distance load/wall";
            this.uCtrlMinDistanceLoadWall.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlMinDistanceLoadWall.ValueX = 0D;
            this.uCtrlMinDistanceLoadWall.ValueY = 0D;
            // 
            // uCtrlPackable
            // 
            this.uCtrlPackable.Location = new System.Drawing.Point(104, 90);
            this.uCtrlPackable.Name = "uCtrlPackable";
            this.uCtrlPackable.Size = new System.Drawing.Size(145, 78);
            this.uCtrlPackable.TabIndex = 41;
            // 
            // uCtrlHCylLayoutList
            // 
            this.uCtrlHCylLayoutList.AutoScroll = true;
            this.uCtrlHCylLayoutList.ButtonSizes = new System.Drawing.Size(150, 150);
            this.uCtrlHCylLayoutList.Location = new System.Drawing.Point(0, 174);
            this.uCtrlHCylLayoutList.Name = "uCtrlHCylLayoutList";
            this.uCtrlHCylLayoutList.Size = new System.Drawing.Size(782, 335);
            this.uCtrlHCylLayoutList.TabIndex = 42;
            this.uCtrlHCylLayoutList.LayoutSelected += new treeDiM.StackBuilder.Graphics.Controls.UCtrlHCylLayoutList.LayoutButtonClicked(this.OnLayoutSelected);
            // 
            // tabControlConstraints
            // 
            this.tabControlConstraints.Controls.Add(this.tabPageStopCriterions);
            this.tabControlConstraints.Controls.Add(this.tbPageMargins);
            this.tabControlConstraints.Location = new System.Drawing.Point(399, 90);
            this.tabControlConstraints.Name = "tabControlConstraints";
            this.tabControlConstraints.SelectedIndex = 0;
            this.tabControlConstraints.Size = new System.Drawing.Size(387, 84);
            this.tabControlConstraints.TabIndex = 43;
            // 
            // tabPageStopCriterions
            // 
            this.tabPageStopCriterions.Controls.Add(this.uCtrlOptMaximumNumber);
            this.tabPageStopCriterions.Controls.Add(this.uCtrlOptMaximumWeight);
            this.tabPageStopCriterions.Location = new System.Drawing.Point(4, 22);
            this.tabPageStopCriterions.Name = "tabPageStopCriterions";
            this.tabPageStopCriterions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStopCriterions.Size = new System.Drawing.Size(379, 58);
            this.tabPageStopCriterions.TabIndex = 0;
            this.tabPageStopCriterions.Text = "Stop criterions";
            this.tabPageStopCriterions.UseVisualStyleBackColor = true;
            // 
            // uCtrlOptMaximumNumber
            // 
            this.uCtrlOptMaximumNumber.Location = new System.Drawing.Point(15, 33);
            this.uCtrlOptMaximumNumber.Minimum = -10000;
            this.uCtrlOptMaximumNumber.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlOptMaximumNumber.Name = "uCtrlOptMaximumNumber";
            this.uCtrlOptMaximumNumber.Size = new System.Drawing.Size(349, 20);
            this.uCtrlOptMaximumNumber.TabIndex = 28;
            this.uCtrlOptMaximumNumber.Text = "Maximum number";
            // 
            // uCtrlOptMaximumWeight
            // 
            this.uCtrlOptMaximumWeight.Location = new System.Drawing.Point(15, 6);
            this.uCtrlOptMaximumWeight.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.uCtrlOptMaximumWeight.MinimumSize = new System.Drawing.Size(100, 20);
            this.uCtrlOptMaximumWeight.Name = "uCtrlOptMaximumWeight";
            this.uCtrlOptMaximumWeight.Size = new System.Drawing.Size(349, 20);
            this.uCtrlOptMaximumWeight.TabIndex = 27;
            this.uCtrlOptMaximumWeight.Text = "Maximum pallet weight";
            this.uCtrlOptMaximumWeight.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_MASS;
            // 
            // tbPageMargins
            // 
            this.tbPageMargins.Controls.Add(this.uCtrlMinDistanceLoadWall);
            this.tbPageMargins.Controls.Add(this.uCtrlMinDistanceLoadRoof);
            this.tbPageMargins.Location = new System.Drawing.Point(4, 22);
            this.tbPageMargins.Name = "tbPageMargins";
            this.tbPageMargins.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageMargins.Size = new System.Drawing.Size(379, 58);
            this.tbPageMargins.TabIndex = 1;
            this.tbPageMargins.Text = "Margins";
            this.tbPageMargins.UseVisualStyleBackColor = true;
            // 
            // FormNewAnalysisHCylTruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControlConstraints);
            this.Controls.Add(this.uCtrlHCylLayoutList);
            this.Controls.Add(this.uCtrlPackable);
            this.Controls.Add(this.cbTrucks);
            this.Controls.Add(this.cbCylinders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormNewAnalysisHCylTruck";
            this.Text = "Create new Cylinder/Truck analysis...";
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.lbDescription, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbCylinders, 0);
            this.Controls.SetChildIndex(this.cbTrucks, 0);
            this.Controls.SetChildIndex(this.uCtrlPackable, 0);
            this.Controls.SetChildIndex(this.uCtrlHCylLayoutList, 0);
            this.Controls.SetChildIndex(this.tabControlConstraints, 0);
            this.tabControlConstraints.ResumeLayout(false);
            this.tabPageStopCriterions.ResumeLayout(false);
            this.tbPageMargins.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Graphics.Controls.CCtrlComboFiltered cbCylinders;
        private Graphics.Controls.CCtrlComboFiltered cbTrucks;
        private treeDiM.Basics.UCtrlDouble uCtrlMinDistanceLoadRoof;
        private treeDiM.Basics.UCtrlDualDouble uCtrlMinDistanceLoadWall;
        private Graphics.Controls.UCtrlPackable uCtrlPackable;
        private Graphics.Controls.UCtrlHCylLayoutList uCtrlHCylLayoutList;
        private System.Windows.Forms.TabControl tabControlConstraints;
        private System.Windows.Forms.TabPage tabPageStopCriterions;
        private System.Windows.Forms.TabPage tbPageMargins;
        private treeDiM.Basics.UCtrlOptInt uCtrlOptMaximumNumber;
        private treeDiM.Basics.UCtrlOptDouble uCtrlOptMaximumWeight;
    }
}