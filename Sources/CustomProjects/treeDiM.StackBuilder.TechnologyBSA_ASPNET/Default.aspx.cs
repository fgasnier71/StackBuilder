#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Exporters;

#endregion

namespace treeDiM.StackBuilder.TechnologyBSA_ASPNET
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownListFiles.DataSource = FtpHelpers.GetListOfFiles(ConfigSettings.FtpDirectory, ConfigSettings.FtpUsername, ConfigSettings.FtpPassword);
                DropDownListFiles.DataBind();

                DimCase = new Vector3D(300.0, 280.0, 275.0);
                WeightCase = 1.0;
                DimPallet = new Vector3D(1200.0, 1000.0, 155.0);
                WeightPallet = 23.0;
                MaxPalletHeight = 1700.0;
                BoxPositions = new List<BoxPosition>();
            }
        }

        protected void OnNewProject(object sender, EventArgs e)
        {
            DimCase = new Vector3D(300.0, 280.0, 275.0);
            WeightCase = 1.0;
            DimPallet = new Vector3D(1200.0, 1000.0, 155.0);
            WeightPallet = 23.0;
            MaxPalletHeight = 1700.0;
            LayersMirrorX = false; LayersMirrorY = false;
            Interlayers = "";
            FileName = "Untitled.csv";

            if (ConfigSettings.WebGLMode)
                Response.Redirect("LayerSelectionWebGL.aspx");
            else
                Response.Redirect("LayerSelection.aspx");
        }

        protected void OnOpenProject(object sender, EventArgs e)
        {
            // get selected file name
            var dimCase = Vector3D.Zero;
            double weightCase = 0.0;
            var dimPallet = Vector3D.Zero;
            double weightPallet = 0.0;
            double maxPalletHeight = 0.0;
            bool MirrorX = false, MirrorY = false; ;
            List<BoxPosition> boxPositions = new List<BoxPosition>();
            List<bool> interlayers = new List<bool>();

            string filePath = DropDownListFiles.SelectedValue;
            byte[] fileContent = null;
            FtpHelpers.Download(ref fileContent, ConfigSettings.FtpDirectory, filePath, ConfigSettings.FtpUsername, ConfigSettings.FtpPassword);
            ExporterCSV_TechBSA.Import(new MemoryStream(fileContent),
                ref boxPositions,
                ref dimCase, ref weightCase,
                ref dimPallet, ref weightPallet,
                ref maxPalletHeight,
                ref MirrorX, ref MirrorY,
                ref interlayers);

            DimCase = dimCase; WeightCase = weightCase;
            DimPallet = dimPallet; WeightPallet = weightPallet;
            MaxPalletHeight = maxPalletHeight;
            BoxPositions = boxPositions;
            LayersMirrorX = MirrorX;
            LayersMirrorY = MirrorY;
            FileName = filePath;
            Interlayers = string.Concat(interlayers.Select(p => p ? "1" : "0").ToArray());

            if (ConfigSettings.WebGLMode)
                Response.Redirect("ValidationWebGL.aspx");
            else
                Response.Redirect("Validation.aspx");
        }

        #region Private properties
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
        private List<BoxPosition> BoxPositions
        {
            get => Session[SessionVariables.BoxPositions] as List<BoxPosition>;
            set => Session[SessionVariables.BoxPositions] = value;
        }
        private bool LayersMirrorX
        { set => Session[SessionVariables.LayersMirrorLength] = value; }
        private bool LayersMirrorY
        { set => Session[SessionVariables.LayersMirrorWidth] = value; }
        private string FileName
        { set => Session[SessionVariables.FileName] = value; }
        private string Interlayers
        { set => Session[SessionVariables.Interlayers] = value; }

        #endregion
    }
}