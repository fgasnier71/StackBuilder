namespace treeDiM.EdgeCrushTest
{
    partial class FormEditCardboardQualityData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditCardboardQualityData));
            this.bnOk = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.lbProfile = new System.Windows.Forms.Label();
            this.lbThickness = new System.Windows.Forms.Label();
            this.lbECT = new System.Windows.Forms.Label();
            this.lbRigidityX = new System.Windows.Forms.Label();
            this.lbRigidityY = new System.Windows.Forms.Label();
            this.nudThickness = new System.Windows.Forms.NumericUpDown();
            this.nudStiffnessX = new System.Windows.Forms.NumericUpDown();
            this.nudStiffnessY = new System.Windows.Forms.NumericUpDown();
            this.nudECT = new System.Windows.Forms.NumericUpDown();
            this.lbThicknessUnit = new System.Windows.Forms.Label();
            this.lbStiffnessXUnit = new System.Windows.Forms.Label();
            this.lbStiffnessYUnit = new System.Windows.Forms.Label();
            this.lbECTUnit = new System.Windows.Forms.Label();
            this.tbQualityName = new System.Windows.Forms.TextBox();
            this.tbProfile = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStiffnessX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStiffnessY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudECT)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnOk
            // 
            resources.ApplyResources(this.bnOk, "bnOk");
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Name = "bnOk";
            this.bnOk.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Name = "lbName";
            // 
            // lbProfile
            // 
            resources.ApplyResources(this.lbProfile, "lbProfile");
            this.lbProfile.Name = "lbProfile";
            // 
            // lbThickness
            // 
            resources.ApplyResources(this.lbThickness, "lbThickness");
            this.lbThickness.Name = "lbThickness";
            // 
            // lbECT
            // 
            resources.ApplyResources(this.lbECT, "lbECT");
            this.lbECT.Name = "lbECT";
            // 
            // lbRigidityX
            // 
            resources.ApplyResources(this.lbRigidityX, "lbRigidityX");
            this.lbRigidityX.Name = "lbRigidityX";
            // 
            // lbRigidityY
            // 
            resources.ApplyResources(this.lbRigidityY, "lbRigidityY");
            this.lbRigidityY.Name = "lbRigidityY";
            // 
            // nudThickness
            // 
            this.nudThickness.DecimalPlaces = 2;
            resources.ApplyResources(this.nudThickness, "nudThickness");
            this.nudThickness.Name = "nudThickness";
            this.nudThickness.ValueChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // nudStiffnessX
            // 
            this.nudStiffnessX.DecimalPlaces = 2;
            resources.ApplyResources(this.nudStiffnessX, "nudStiffnessX");
            this.nudStiffnessX.Name = "nudStiffnessX";
            this.nudStiffnessX.ValueChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // nudStiffnessY
            // 
            this.nudStiffnessY.DecimalPlaces = 2;
            resources.ApplyResources(this.nudStiffnessY, "nudStiffnessY");
            this.nudStiffnessY.Name = "nudStiffnessY";
            this.nudStiffnessY.ValueChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // nudECT
            // 
            this.nudECT.DecimalPlaces = 2;
            resources.ApplyResources(this.nudECT, "nudECT");
            this.nudECT.Name = "nudECT";
            this.nudECT.ValueChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // lbThicknessUnit
            // 
            resources.ApplyResources(this.lbThicknessUnit, "lbThicknessUnit");
            this.lbThicknessUnit.Name = "lbThicknessUnit";
            // 
            // lbStiffnessXUnit
            // 
            resources.ApplyResources(this.lbStiffnessXUnit, "lbStiffnessXUnit");
            this.lbStiffnessXUnit.Name = "lbStiffnessXUnit";
            // 
            // lbStiffnessYUnit
            // 
            resources.ApplyResources(this.lbStiffnessYUnit, "lbStiffnessYUnit");
            this.lbStiffnessYUnit.Name = "lbStiffnessYUnit";
            // 
            // lbECTUnit
            // 
            resources.ApplyResources(this.lbECTUnit, "lbECTUnit");
            this.lbECTUnit.Name = "lbECTUnit";
            // 
            // tbQualityName
            // 
            resources.ApplyResources(this.tbQualityName, "tbQualityName");
            this.tbQualityName.Name = "tbQualityName";
            this.tbQualityName.TextChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // tbProfile
            // 
            resources.ApplyResources(this.tbProfile, "tbProfile");
            this.tbProfile.Name = "tbProfile";
            this.tbProfile.TextChanged += new System.EventHandler(this.OnInputChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            resources.ApplyResources(this.statusLabel, "statusLabel");
            // 
            // FormEditCardboardQualityData
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tbProfile);
            this.Controls.Add(this.tbQualityName);
            this.Controls.Add(this.lbECTUnit);
            this.Controls.Add(this.lbStiffnessYUnit);
            this.Controls.Add(this.lbStiffnessXUnit);
            this.Controls.Add(this.lbThicknessUnit);
            this.Controls.Add(this.nudECT);
            this.Controls.Add(this.nudStiffnessY);
            this.Controls.Add(this.nudStiffnessX);
            this.Controls.Add(this.nudThickness);
            this.Controls.Add(this.lbRigidityY);
            this.Controls.Add(this.lbRigidityX);
            this.Controls.Add(this.lbECT);
            this.Controls.Add(this.lbThickness);
            this.Controls.Add(this.lbProfile);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditCardboardQualityData";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStiffnessX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStiffnessY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudECT)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbProfile;
        private System.Windows.Forms.Label lbThickness;
        private System.Windows.Forms.Label lbECT;
        private System.Windows.Forms.Label lbRigidityX;
        private System.Windows.Forms.Label lbRigidityY;
        private System.Windows.Forms.NumericUpDown nudThickness;
        private System.Windows.Forms.NumericUpDown nudStiffnessX;
        private System.Windows.Forms.NumericUpDown nudStiffnessY;
        private System.Windows.Forms.NumericUpDown nudECT;
        private System.Windows.Forms.Label lbThicknessUnit;
        private System.Windows.Forms.Label lbStiffnessXUnit;
        private System.Windows.Forms.Label lbStiffnessYUnit;
        private System.Windows.Forms.Label lbECTUnit;
        private System.Windows.Forms.TextBox tbQualityName;
        private System.Windows.Forms.TextBox tbProfile;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}