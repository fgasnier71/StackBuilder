#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using treeDiM.PLMPack.DBClient;
using treeDiM.StackBuilder.GUIExtension;
using treeDiM.StackBuilder.GUIExtension.Test.Properties;
#endregion

namespace treeDiM.StackBuilder.GUIExtension.Test
{
    public partial class FormMain : Form
    {
        #region Constructor
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string userName = WCFClientSingleton.Instance.User.Name;
            Text = Application.ProductName + " (" + userName + ")";

            tbName.Text = Settings.Default.Name;
            uCtrlDimensions.ValueX = Settings.Default.Length;
            uCtrlDimensions.ValueY = Settings.Default.Width;
            uCtrlDimensions.ValueZ = Settings.Default.Height;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            Settings.Default.Name = tbName.Text;
            Settings.Default.Length = uCtrlDimensions.ValueX;
            Settings.Default.Width = uCtrlDimensions.ValueY;
            Settings.Default.Height = uCtrlDimensions.ValueZ;
            Settings.Default.Save();
        }
        #endregion

        #region Event handlers
        private void onAnalysisCasePallet(object sender, EventArgs e)
        {
            try
            {
                Palletization.StartCasePalletization(
                    tbName.Text
                    , uCtrlDimensions.ValueX
                    , uCtrlDimensions.ValueY
                    , uCtrlDimensions.ValueZ);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void onBoxCasePalletOptimisation(object sender, EventArgs e)
        {
            try
            {
                Palletization.StartCaseOptimization(
                    tbName.Text
                    , uCtrlDimensions.ValueX
                    , uCtrlDimensions.ValueY
                    , uCtrlDimensions.ValueZ);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void onAnalysisBundlePallet(object sender, EventArgs e)
        {
            try
            {
                Palletization.StartBundlePalletAnalysis(
                    tbName.Text
                    , uCtrlDimensions.ValueX
                    , uCtrlDimensions.ValueY
                    , uCtrlDimensions.ValueZ);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void onAnalysisBundleCase(object sender, EventArgs e)
        {
            try
            {
                Palletization.StartBundleCaseAnalysis(
                    tbName.Text
                    , uCtrlDimensions.ValueX
                    , uCtrlDimensions.ValueY
                    , uCtrlDimensions.ValueZ);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void onClose(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
