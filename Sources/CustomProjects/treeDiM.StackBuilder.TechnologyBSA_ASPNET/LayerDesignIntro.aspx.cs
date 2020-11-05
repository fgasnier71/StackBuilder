#region Using directives
using System;
using System.Web.UI;
using System.Globalization;

using Sharp3D.Math.Core;
#endregion


namespace treeDiM.StackBuilder.TechnologyBSA_ASPNET
{
    public partial class LayerDesignIntro : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DimCaseCtrl = DimCase;
                WeightCaseCtrl = WeightCase;
                DimPalletCtrl = DimPallet;
                WeightPalletCtrl = WeightPallet;
                MaxPalletHeightCtrl = MaxPalletHeight;
            }
        }
        protected void OnNext(object sender, EventArgs e)
        {
            DimCase = DimCaseCtrl;
            WeightCase = WeightCaseCtrl;
            DimPallet = DimPalletCtrl;
            WeightPallet = WeightPalletCtrl;
            MaxPalletHeight = MaxPalletHeightCtrl;

            Session[SessionVariables.LayerEdited] = true;
            Response.Redirect("LayerDesign.aspx");
        }

        private Vector3D DimCaseCtrl
        {
            get => new Vector3D(double.Parse(TBCaseLength.Text), double.Parse(TBCaseWidth.Text), double.Parse(TBCaseHeight.Text));
            set
            {
                TBCaseLength.Text = value.X.ToString();
                TBCaseWidth.Text = value.Y.ToString();
                TBCaseHeight.Text = value.Z.ToString();
            }
        }
        private double WeightCaseCtrl
        {
            get => double.Parse(TBCaseWeight.Text);
            set => TBCaseWeight.Text = value.ToString();
        }
        private Vector3D DimPalletCtrl
        {
            get => new Vector3D(double.Parse(TBPalletLength.Text), double.Parse(TBPalletWidth.Text), double.Parse(TBPalletHeight.Text));
            set
            {
                TBPalletLength.Text = value.X.ToString(CultureInfo.InvariantCulture);
                TBPalletWidth.Text = value.Y.ToString(CultureInfo.InvariantCulture);
                TBPalletHeight.Text = value.Z.ToString(CultureInfo.InvariantCulture);
            }
        }
        private double WeightPalletCtrl
        {
            get => double.Parse(TBPalletWeight.Text);
            set => TBPalletWeight.Text = value.ToString();
        }
        private double MaxPalletHeightCtrl
        {
            get => double.Parse(TBMaxPalletHeight.Text);
            set => TBMaxPalletHeight.Text = value.ToString();
        }
        private Vector3D DimCase
        {
            get => Vector3D.Parse((string)Session[SessionVariables.DimCase]);
            set => Session[SessionVariables.DimCase] = value.ToString();
        }
        private double WeightCase
        {
            get => (double)Session[SessionVariables.WeightCase];
            set => Session[SessionVariables.WeightCase] = value;
        }
        private Vector3D DimPallet
        {
            get => Vector3D.Parse((string)Session[SessionVariables.DimPallet]);
            set => Session[SessionVariables.DimPallet] = value.ToString();
        }
        private double WeightPallet
        {
            get => (double)Session[SessionVariables.WeightPallet];
            set => Session[SessionVariables.WeightPallet] = value;
        }
        private double MaxPalletHeight
        {
            get => (double)Session[SessionVariables.MaxPalletHeight];
            set => Session[SessionVariables.MaxPalletHeight] = value;
        }
    }
}