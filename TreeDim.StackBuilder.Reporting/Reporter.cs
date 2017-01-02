#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using System.Xml.Xsl;
using System.Xml.Schema;
using System.IO;

using System.Drawing;

using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;

using log4net;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
#endregion

namespace treeDiM.StackBuilder.Reporting
{
    #region MyXmlUrlResolver
    class MyXmlUrlResolver : XmlUrlResolver
    {
        public override Uri ResolveUri(Uri baseUri, string relativeUri)
        {
            if (baseUri != null)
                return base.ResolveUri(baseUri, relativeUri);
            else
                return base.ResolveUri(new Uri(@"K:\GitHub\StackBuilder\treeDiM.StackBuilder.Reporting\ReportTemplates"), relativeUri);
        }
    }
    #endregion

    #region Exceptions
    public class ReportExceptionInvalidAnalysis : Exception
    {
        public ReportExceptionInvalidAnalysis()
        { 
        }
    }

    public class ReportExceptionUnexpectedItem : Exception
    {
        #region Constructor
        public ReportExceptionUnexpectedItem(ItemBase item)
            : base(string.Format("Unexpected item : {0}", item.Name))
        {
        }
        #endregion
    }
    #endregion

    #region ReportData
    /// <summary>
    /// class used to encapsulate an analysis and a solution
    /// </summary>
    public class ReportData
    {
        #region Data members
        private Analysis _analysis;
        private Solution _solution;
        #endregion

        #region Constructors
        public ReportData(Analysis analysis)
        {
            _analysis = analysis;
            _solution = analysis.Solution;
        }
        #endregion

        #region Public accessors
        public Document Document
        {
            get
            {
                if (null != _analysis)
                    return _analysis.ParentDocument;
                return null;
            }
        }

        public string Title
        {
            get
            {
                if (null != _analysis)
                    return _analysis.Name;
                return null;
            }
        }
        public Analysis MainAnalysis
        {
            get
            {
                if (null == _analysis) throw new ReportExceptionInvalidAnalysis();
                return _analysis;
            }
        }
        public bool IsValid
        {
            get { return null != _analysis && null != _solution; }
        }
        #endregion

        #region IItemListener related methods
        public void AddListener(IItemListener listener)
        {
            _analysis.AddListener(listener);
        }

        public void RemoveListener(IItemListener listener)
        {
            _analysis.RemoveListener(listener);
        }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (obj is ReportData)
            {
                ReportData reportObject = obj as ReportData;
                return _analysis == reportObject._analysis;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return _analysis.GetHashCode();
        }
        #endregion
    }
    #endregion

    #region Reporter
    /// <summary>
    /// Generates pallet analyses reports
    /// </summary>
    abstract public class Reporter
    {
        #region Enums
        public enum eImageSize
        {
            IMAGESIZE_DEFAULT
            , IMAGESIZE_SMALL
        };
        #endregion

        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(Reporter));
        protected static bool _validateAgainstSchema = false;
        protected string _imageDirectory;
        protected static string _companyLogo;
        protected static eImageSize _imageSize = eImageSize.IMAGESIZE_DEFAULT;
        protected static int _imageIndex = 0;
        #endregion

        #region Abstract members
        abstract public bool WriteNamespace { get; }
        abstract public bool WriteImageFiles { get; }
        #endregion

        #region Public properties
        static public string CompanyLogo
        {
            get
            {
                if (!File.Exists(_companyLogo))
                {
                    _companyLogo = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                        , "ReportTemplates\\YourLogoHere.png");
                    Properties.Settings.Default.CompanyLogoPath = _companyLogo;
                    Properties.Settings.Default.Save();

                    if (!File.Exists(_companyLogo))
                        return string.Empty;
                }
                return _companyLogo; 
            }
            set { _companyLogo = File.Exists(value) ? value : string.Empty; }
        }
        static public eImageSize ImageSizeSetting
        {
            get { return _imageSize; }
            set { _imageSize = value; }
        }
        static public string TemplatePath
        {
            get
            {
                string templatePath = Properties.Settings.Default.TemplatePath;
                if (string.IsNullOrEmpty(templatePath) || !File.Exists(templatePath))
                {
                    templatePath = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                        , "ReportTemplates\\ReportTemplateHtml.xsl");
                    Properties.Settings.Default.TemplatePath = templatePath;
                    Properties.Settings.Default.Save();
                    return templatePath;
                }
                return templatePath;
            }
        }

        #endregion

        #region Private properties
        private string ImageDirectory
        {
            set {   _imageDirectory = value;}
            get {   return _imageDirectory;  }
        }
        private int ImageSizeDetail
        {
            get
            {
                switch (_imageSize)
                {
                    case eImageSize.IMAGESIZE_DEFAULT: return 256;
                    case eImageSize.IMAGESIZE_SMALL: return 128;
                    default: return 256;
                }
            }
        }
        private int ImageSizeWide
        {
            get
            {
                switch (_imageSize)
                {
                    case eImageSize.IMAGESIZE_DEFAULT: return 768;
                    case eImageSize.IMAGESIZE_SMALL: return 384;
                    default: return 768;
                }
            }
        }
        #endregion

        #region Report generation
        public void BuildAnalysisReport(ReportData inputData, string reportTemplatePath, string outputFilePath)
        {
            // initialize image index
            _imageIndex = 0;
            // verify if inputData is a valid entry
            if (!inputData.IsValid)
                throw new Exception("Reporter.BuildAnalysisReport(): ReportData argument is invalid!");
            // absolute path
            string absOutputFilePath = ToAbsolute(outputFilePath);
            string absReportTemplatePath = ToAbsolute(reportTemplatePath);
            // create directory if needed
            ImageDirectory = Path.Combine(Path.GetDirectoryName(absOutputFilePath), "Images");
            if (WriteImageFiles && !Directory.Exists(ImageDirectory))
                Directory.CreateDirectory(ImageDirectory); 
            // create xml data file + XmlTextReader
            string xmlFilePath = Path.ChangeExtension(System.IO.Path.GetTempFileName(), "xml");
            CreateAnalysisDataFile(inputData, xmlFilePath, WriteNamespace);
            XmlTextReader xmlData = new XmlTextReader(new FileStream(xmlFilePath, FileMode.Open, FileAccess.Read));
            // validate against schema
            // note xml file validation against xml schema produces a large number of errors
            // For the moment, I can not remove all errors
            if (_validateAgainstSchema)
                Reporter.ValidateXmlDocument(xmlData, Path.Combine(Path.GetDirectoryName(absReportTemplatePath), "ReportSchema.xsd"));
            // check availibility of files
            if (!File.Exists(absReportTemplatePath))
                throw new System.IO.FileNotFoundException(string.Format("Report template path ({0}) is invalid", absReportTemplatePath));
            // load generated xslt
            XmlTextReader xsltReader = new XmlTextReader(new FileStream(absReportTemplatePath, FileMode.Open, FileAccess.Read));
            string threeLetterLanguageAbbrev = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName;
            if (!File.Exists(Path.Combine(Path.GetDirectoryName(absReportTemplatePath), threeLetterLanguageAbbrev + ".xml")))
            {
                _log.Warn(string.Format("Language file {0}.xml could not be found! Trying ENU.xml...", threeLetterLanguageAbbrev));
                threeLetterLanguageAbbrev = "ENU";
            }
            if (!File.Exists(Path.Combine(Path.GetDirectoryName(absReportTemplatePath), threeLetterLanguageAbbrev + ".xml")))
                _log.Warn(string.Format("Language file {0}.xml could not be found!", threeLetterLanguageAbbrev));
            // generate word document
            byte[] wordDoc = GetReport(xmlData, xsltReader, Path.Combine(Path.GetDirectoryName(absReportTemplatePath), threeLetterLanguageAbbrev));
            // write resulting array to HDD, show process information
            using (FileStream fs = new FileStream(absOutputFilePath, FileMode.Create))
                fs.Write(wordDoc, 0, wordDoc.Length);
        }
        #endregion

        #region Xml transformation using xsl template
        /// <summary>
        /// Creates document from XML using XSLT
        /// </summary>
        /// <param name="xmlData">Report data as XML</param>
        /// <param name="xsltReader">XSLT transformation as Stream, used for document creation</param>
        /// <returns>Resulting document as byte[]</returns>
        private static byte[] GetReport(XmlReader xmlData, XmlReader xsltReader, string threeLetterLanguageAbbrev)
        {
            // Initialize needed variables
            XslCompiledTransform xslt = new XslCompiledTransform();
            XsltArgumentList args = new XsltArgumentList();
            args.AddParam("lang", "", threeLetterLanguageAbbrev);

            XsltSettings xslt_set = new XsltSettings();
            xslt_set.EnableScript = true;
            xslt_set.EnableDocumentFunction = true;
          

            using (MemoryStream swResult = new MemoryStream())
            {
                // Load XSLT to reader and perform transformation
                xslt.Load(xsltReader, xslt_set, new MyXmlUrlResolver());
                xslt.Transform(xmlData, args, swResult);
                return swResult.ToArray();
            }
        }
        #endregion

        #region Static methods to build xml report
        public void CreateAnalysisDataFile(ReportData inputData, string xmlDataFilePath, bool writeNamespace)
        {
            // instantiate XmlDocument
            XmlDocument xmlDoc = new XmlDocument();
            // set declaration
            XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "no");
            xmlDoc.AppendChild(declaration);
            // report (root) element
            XmlElement elemDocument;
            if (writeNamespace)
                elemDocument = xmlDoc.CreateElement("report", "http://treeDim/StackBuilder/ReportSchema.xsd");
            else
                elemDocument = xmlDoc.CreateElement("report");
            xmlDoc.AppendChild(elemDocument);

            string ns = xmlDoc.DocumentElement.NamespaceURI;
            Document doc = inputData.Document;
            // name element
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = doc.Name;
            elemDocument.AppendChild(elemName);
            // description element
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = doc.Description;
            elemDocument.AppendChild(elemDescription);
            // author element
            XmlElement elemAuthor = xmlDoc.CreateElement("author", ns);
            elemAuthor.InnerText = doc.Author;
            elemDocument.AppendChild(elemAuthor);
            // date of creation element
            XmlElement elemDateOfCreation = xmlDoc.CreateElement("dateOfCreation", ns);
            elemDateOfCreation.InnerText = doc.DateOfCreation.Year < 2000 ? DateTime.Now.ToShortDateString() : doc.DateOfCreation.ToShortDateString();
            elemDocument.AppendChild(elemDateOfCreation);
            // CompanyLogo
            if (!string.IsNullOrEmpty(CompanyLogo))
            {
                System.Drawing.Bitmap logoBitmap = new Bitmap(System.Drawing.Bitmap.FromFile(CompanyLogo));

                XmlElement elemCompanyLogo = xmlDoc.CreateElement("companyLogo", ns);
                elemDocument.AppendChild(elemCompanyLogo);



                string imagePath = SaveImageAs(logoBitmap);
            }
            // main analysis
            AppendAnalysisElement(inputData.MainAnalysis, elemDocument, xmlDoc);
            // finally save xml document
            _log.Debug(string.Format("Generating xml data file {0}", xmlDataFilePath));
            xmlDoc.Save(xmlDataFilePath);
        }
        #endregion

        #region Analyses
        private void AppendAnalysisElement(Analysis analysis, XmlElement elemDocument, XmlDocument xmlDoc)
        { 
            Packable content = analysis.Content;

            bool hasContent = false;
            // check for inner analysis
            Analysis innerAnalysis = null;
            if (content.InnerAnalysis(ref innerAnalysis))
            {
                // -> proceed recursively
                AppendAnalysisElement(innerAnalysis, elemDocument, xmlDoc);
            }
            else
                hasContent = true;
            
            // ### 0. ANALYSIS ELT
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            XmlElement eltAnalysis = xmlDoc.CreateElement("analysis", ns);
            elemDocument.AppendChild(eltAnalysis);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = analysis.Name;
            eltAnalysis.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = analysis.Description;
            eltAnalysis.AppendChild(elemDescription);

            // ### 1. CONTENT
            if (hasContent)
                AppendContentElement(content, eltAnalysis, xmlDoc);
  
            // ### 2. CONTAINER
            AppendContainerElement(analysis.Container, eltAnalysis, xmlDoc);

            // ### 3. INTERLAYERS
            foreach (InterlayerProperties interlayer in analysis.Interlayers)
                AppendInterlayerElement(interlayer, eltAnalysis, xmlDoc);

            // ### 4. CONSTRAINTSET
            AppendConstraintSet(analysis.ConstraintSet, eltAnalysis, xmlDoc);

            // ### 5. SOLUTION
            AppendSolutionElement(analysis.Solution, eltAnalysis, xmlDoc);
        }

        private void AppendContentElement(Packable packable, XmlElement elemAnalysis, XmlDocument xmlDoc)
        {
            if (packable is BoxProperties)
            {
                BoxProperties boxProperties = packable as BoxProperties;
                if (boxProperties.HasInsideDimensions)
                    AppendCaseElement(boxProperties, elemAnalysis, xmlDoc);
                else
                    AppendBoxElement(boxProperties, elemAnalysis, xmlDoc);
            }
            else if (packable is BundleProperties)
                AppendBundleElement(packable as BundleProperties, elemAnalysis, xmlDoc);
            else if (packable is PackProperties)
                AppendPackElement(packable as PackProperties, elemAnalysis, xmlDoc);
            else if (packable is CylinderProperties)
                AppendCylinderElement(packable as CylinderProperties, elemAnalysis, xmlDoc);
            else if (packable is LoadedCase)
            { 
            }
            else
                throw new ReportExceptionUnexpectedItem(packable);
        }
        private void AppendContainerElement(ItemBase container, XmlElement elemAnalysis, XmlDocument xmlDoc)
        {
            if (container is PalletProperties)
                AppendPalletElement(container as PalletProperties, elemAnalysis, xmlDoc);
            else if (container is BoxProperties)
                AppendCaseElement(container as BoxProperties, elemAnalysis, xmlDoc);
            else if (container is TruckProperties)
                AppendTruckElement(container as TruckProperties, elemAnalysis, xmlDoc);
        }
        private void AppendConstraintSet(ConstraintSetAbstract constraintSet, XmlElement elemAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            XmlElement elemConstraintSet = xmlDoc.CreateElement("constraintSet", ns);
            elemAnalysis.AppendChild(elemConstraintSet);

            if (constraintSet is ConstraintSetCasePallet)
            {
                ConstraintSetCasePallet constraintSetCasePallet = constraintSet as ConstraintSetCasePallet;
                AppendElementValue(xmlDoc, elemConstraintSet, "overhangX", UnitsManager.UnitType.UT_LENGTH, constraintSetCasePallet.Overhang.X);
                AppendElementValue(xmlDoc, elemConstraintSet, "overhangY", UnitsManager.UnitType.UT_LENGTH, constraintSetCasePallet.Overhang.Y);
            }

            if (constraintSet is ConstraintSetCasePallet && constraintSet.OptMaxHeight.Activated)
                AppendElementValue(xmlDoc, elemConstraintSet, "maximumHeight", UnitsManager.UnitType.UT_LENGTH, constraintSet.OptMaxHeight.Value);
            if (constraintSet.OptMaxWeight.Activated)
                AppendElementValue(xmlDoc, elemConstraintSet, "maximumWeight", UnitsManager.UnitType.UT_MASS, constraintSet.OptMaxWeight.Value);
            if (constraintSet.OptMaxNumber.Activated)
                AppendElementValue(xmlDoc, elemConstraintSet, "maximumNumber", constraintSet.OptMaxNumber.Value);
        }
        private void AppendSolutionElement(Solution sol, XmlElement elemAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            XmlElement elemSolution = xmlDoc.CreateElement("solution", ns);
            elemAnalysis.AppendChild(elemSolution);

            // *** Item # (Recursive count)
            Analysis analysis = sol.Analysis;
            Packable content = analysis.Content;
            int itemCount = sol.ItemCount;
            int number = 1;
            do
            {
                itemCount *= number;
                AppendContentItem(xmlDoc, elemSolution, content.DetailedName, itemCount);
            }
            while (null != content && content.InnerContent(ref content, ref number));
            // ***

            if (sol.HasNetWeight)
                Reporter.AppendElementValue(xmlDoc, elemSolution, "netWeight", UnitsManager.UnitType.UT_MASS, sol.NetWeight.Value);
            Reporter.AppendElementValue(xmlDoc, elemSolution, "loadWeight", UnitsManager.UnitType.UT_MASS, sol.LoadWeight);
            Reporter.AppendElementValue(xmlDoc, elemSolution, "totalWeight", UnitsManager.UnitType.UT_MASS, sol.Weight);
            Reporter.AppendElementValue(xmlDoc, elemSolution, "efficiencyVolume", sol.VolumeEfficiency);

            // --- case images
            for (int i = 0; i < 5; ++i)
            {
                // initialize drawing values
                string viewName = string.Empty;
                Vector3D cameraPos = Vector3D.Zero;
                int imageWidth = ImageSizeDetail;
                bool showDimensions = false;
                switch (i)
                {
                    case 0: viewName = "view_solution_front"; cameraPos = Graphics3D.Front; imageWidth = ImageSizeDetail; break;
                    case 1: viewName = "view_solution_left"; cameraPos = Graphics3D.Left; imageWidth = ImageSizeDetail; break;
                    case 2: viewName = "view_solution_right"; cameraPos = Graphics3D.Right; imageWidth = ImageSizeDetail; break;
                    case 3: viewName = "view_solution_back"; cameraPos = Graphics3D.Back; imageWidth = ImageSizeDetail; break;
                    case 4: viewName = "view_solution_iso"; cameraPos = Graphics3D.Corner_0; imageWidth = ImageSizeWide; showDimensions = true; break;
                    default: break;
                }
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(imageWidth, imageWidth));
                // set camera position 
                graphics.CameraPosition = cameraPos;

                // instantiate solution viewer
                ViewerSolution sv = new ViewerSolution(sol);
                sv.Draw(graphics, Transform3D.Identity, showDimensions);
                graphics.Flush();
                // image path
                string imagePath = SaveImageAs(graphics.Bitmap);

                // ---
                XmlElement elemImage = xmlDoc.CreateElement(viewName, ns);
                elemSolution.AppendChild(elemImage);
                XmlElement elemImagePath = xmlDoc.CreateElement("imagePath");
                elemImage.AppendChild(elemImagePath);
                elemImagePath.InnerText = imagePath;
                XmlElement elemWidth = xmlDoc.CreateElement("width");
                elemImage.AppendChild(elemWidth);
                elemWidth.InnerText = imageWidth.ToString();
                XmlElement elemHeight = xmlDoc.CreateElement("height");
                elemImage.AppendChild(elemHeight);
                elemHeight.InnerText = imageWidth.ToString();
            }
            // layers
            XmlElement elemLayers = xmlDoc.CreateElement("layers", ns);
            elemSolution.AppendChild(elemLayers);

            List<LayerSummary> layerSummaries = sol.ListLayerSummary;
            foreach (LayerSummary layerSum in layerSummaries)
            {
                // layer
                XmlElement elemLayer = xmlDoc.CreateElement("layer", ns);
                elemLayers.AppendChild(elemLayer);
                // layerIndexes
                XmlElement elemLayerIndexes = xmlDoc.CreateElement("layerIndexes", ns);
                elemLayer.AppendChild(elemLayerIndexes);
                elemLayerIndexes.InnerText = layerSum.LayerIndexesString;
                // item count
                content = sol.Analysis.Content;
                itemCount = layerSum.ItemCount;
                number = 1;
                do
                {
                    itemCount *= number;
                    AppendContentItem(xmlDoc, elemLayer, content.DetailedName, itemCount);
                }
                while (null != content && content.InnerContent(ref content, ref number));
                // ***
                // layerLength
                Reporter.AppendElementValue(xmlDoc, elemLayer, "layerLength", UnitsManager.UnitType.UT_LENGTH, layerSum.LayerDimensions.X);
                // layerWidth
                Reporter.AppendElementValue(xmlDoc, elemLayer, "layerWidth", UnitsManager.UnitType.UT_LENGTH, layerSum.LayerDimensions.Y);
                // layerHeight
                Reporter.AppendElementValue(xmlDoc, elemLayer, "layerHeight", UnitsManager.UnitType.UT_LENGTH, layerSum.LayerDimensions.Z);
                // layerWeight
                Reporter.AppendElementValue(xmlDoc, elemLayer, "layerWeight", UnitsManager.UnitType.UT_MASS, layerSum.LayerWeight);
                // layerNetWeight
                if (sol.HasNetWeight)
                    Reporter.AppendElementValue(xmlDoc, elemLayer, "layerNetWeight", UnitsManager.UnitType.UT_MASS, layerSum.LayerNetWeight);
                // layer spaces
                Reporter.AppendElementValue(xmlDoc, elemLayer, "layerSpaces", UnitsManager.UnitType.UT_LENGTH, layerSum.Space);
                // layer image
                Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
                ViewerSolution.DrawILayer(graphics, layerSum.Layer3D, sol.Analysis.Content, false);
                graphics.Flush();
                // imageThumb
                AppendThumbnailElement(xmlDoc, elemLayer, graphics.Bitmap);
            }
        }

        private void AppendPalletElement(PalletProperties palletProp, XmlElement elemAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            if (null == palletProp) return;
            // pallet
            XmlElement elemPallet = xmlDoc.CreateElement("pallet", ns);
            elemAnalysis.AppendChild(elemPallet);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = palletProp.Name;
            elemPallet.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = palletProp.Description;
            elemPallet.AppendChild(elemDescription);

            AppendElementValue(xmlDoc, elemPallet, "length", UnitsManager.UnitType.UT_LENGTH, palletProp.Length);
            AppendElementValue(xmlDoc, elemPallet, "width", UnitsManager.UnitType.UT_LENGTH, palletProp.Width);
            AppendElementValue(xmlDoc, elemPallet, "height", UnitsManager.UnitType.UT_LENGTH, palletProp.Height);
            AppendElementValue(xmlDoc, elemPallet, "weight", UnitsManager.UnitType.UT_MASS, palletProp.Weight);
            AppendElementValue(xmlDoc, elemPallet, "admissibleLoad", UnitsManager.UnitType.UT_MASS, palletProp.AdmissibleLoadWeight);

            // type
            XmlElement elemType = xmlDoc.CreateElement("type", ns);
            elemType.InnerText = palletProp.TypeName;
            elemPallet.AppendChild(elemType);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(512, 512));
            graphics.CameraPosition = Graphics3D.Corner_0;
            Pallet pallet = new Pallet(palletProp);
            pallet.Draw(graphics, Transform3D.Identity);
            graphics.AddDimensions(new DimensionCube(palletProp.Length, palletProp.Width, palletProp.Height));
            graphics.Flush();
            // ---
            // imageThumb
            AppendThumbnailElement(xmlDoc, elemPallet, graphics.Bitmap);
        }

        private void AppendCaseElement(Analysis analysis, CasePalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get BoxProperties
            BoxProperties boxProp = analysis.Content as BoxProperties;
            if (null == boxProp) return;
            // case
            XmlElement elemCase = xmlDoc.CreateElement("case", ns);
            elemPalletAnalysis.AppendChild(elemCase);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = boxProp.Name;
            elemCase.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = boxProp.Description;
            elemCase.AppendChild(elemDescription);

            AppendElementValue(xmlDoc, elemCase, "length", UnitsManager.UnitType.UT_LENGTH, boxProp.Length);
            AppendElementValue(xmlDoc, elemCase, "width", UnitsManager.UnitType.UT_LENGTH, boxProp.Width);
            AppendElementValue(xmlDoc, elemCase, "height", UnitsManager.UnitType.UT_LENGTH, boxProp.Height);
            AppendElementValue(xmlDoc, elemCase, "weight", UnitsManager.UnitType.UT_MASS, boxProp.Weight);
            AppendElementValue(xmlDoc, elemCase, "admissibleLoadOnTop", UnitsManager.UnitType.UT_MASS, 0.0);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            Box box = new Box(0, boxProp);
            graphics.AddBox(box);
            DimensionCube dc = new DimensionCube(box.Length, box.Width, box.Height);    dc.FontSize = 6.0f;
            graphics.AddDimensions(dc);
            graphics.Flush();
            // ---
            // imageThumb
            AppendThumbnailElement(xmlDoc, elemCase, graphics.Bitmap);
        }

        private void AppendCylinderElement(CylinderProperties cylProperties, XmlElement elemAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get CylinderProperties
            XmlElement elemCylinder = xmlDoc.CreateElement("cylinder", ns);
            elemAnalysis.AppendChild(elemCylinder);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = cylProperties.Name;
            elemCylinder.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = cylProperties.Description;
            elemCylinder.AppendChild(elemDescription);

            AppendElementValue(xmlDoc, elemCylinder, "radius", UnitsManager.UnitType.UT_LENGTH, cylProperties.RadiusOuter);
            AppendElementValue(xmlDoc, elemCylinder, "width", UnitsManager.UnitType.UT_LENGTH, cylProperties.Height);
            AppendElementValue(xmlDoc, elemCylinder, "height", UnitsManager.UnitType.UT_MASS, cylProperties.Weight);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            Cylinder cyl = new Cylinder(0, cylProperties);
            graphics.AddCylinder(cyl);
            DimensionCube dc = new DimensionCube(cyl.DiameterOuter, cyl.DiameterOuter, cyl.Height);   dc.FontSize = 6.0f;
            graphics.AddDimensions(dc);
            graphics.Flush();
            // ---
            // imageThumb
            AppendThumbnailElement(xmlDoc, elemCylinder, graphics.Bitmap);
        }

        private void AppendBundleElement(BundleProperties bundleProp, XmlElement elemAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            if (null == bundleProp) return;
            // bundle
            XmlElement elemBundle = CreateElement("bundle", null, elemAnalysis, xmlDoc, ns);
            elemAnalysis.AppendChild(elemBundle);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = bundleProp.Name;
            elemBundle.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = bundleProp.Description;
            elemBundle.AppendChild(elemDescription);
            // length / width / number of flats / unit thickness / unit weight / total thickness / total weight
            AppendElementValue(xmlDoc, elemBundle, "length", UnitsManager.UnitType.UT_LENGTH, bundleProp.Length);
            AppendElementValue(xmlDoc, elemBundle, "width", UnitsManager.UnitType.UT_LENGTH, bundleProp.Width);
            AppendElementValue(xmlDoc, elemBundle, "numberOfFlats", bundleProp.NoFlats);
            AppendElementValue(xmlDoc, elemBundle, "unitThickness", UnitsManager.UnitType.UT_LENGTH, bundleProp.UnitThickness);
            AppendElementValue(xmlDoc, elemBundle, "unitWeight", UnitsManager.UnitType.UT_MASS, bundleProp.UnitWeight);
            AppendElementValue(xmlDoc, elemBundle, "totalThickness", UnitsManager.UnitType.UT_LENGTH, bundleProp.UnitThickness * bundleProp.NoFlats);
            AppendElementValue(xmlDoc, elemBundle, "totalWeight", UnitsManager.UnitType.UT_MASS, bundleProp.UnitWeight * bundleProp.NoFlats);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
            graphics.CameraPosition = Graphics3D.Corner_0;
            Box box = new Box(0, bundleProp);
            graphics.AddBox(box);
            DimensionCube dc = new DimensionCube(bundleProp.Length, bundleProp.Width, bundleProp.Height);   dc.FontSize = 6.0f;
            graphics.AddDimensions(dc);
            graphics.Flush();
            // ---
            // imageThumb
            AppendThumbnailElement(xmlDoc, elemBundle, graphics.Bitmap);
        }

        private void AppendConstraintSet(CasePalletAnalysis analysis, CasePalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            PalletConstraintSet cs = analysis.ConstraintSet;
            // solution
            XmlElement elemConstraintSet = xmlDoc.CreateElement("constraintSet", ns);
            elemPalletAnalysis.AppendChild(elemConstraintSet);
            // overhangX, overhangY
            AppendElementValue(xmlDoc, elemConstraintSet, "overhangX", UnitsManager.UnitType.UT_LENGTH, cs.OverhangX);
            AppendElementValue(xmlDoc, elemConstraintSet, "overhangY", UnitsManager.UnitType.UT_LENGTH, cs.OverhangY);
            // allowedPatterns
            XmlElement elemAllowedPatterns = xmlDoc.CreateElement("allowedPatterns", ns);
            elemAllowedPatterns.InnerText = cs.AllowedPatternString;
            elemConstraintSet.AppendChild(elemAllowedPatterns);
            // allowedBoxAxis
            XmlElement elemAllowedBoxAxis = xmlDoc.CreateElement("allowedOrthoAxis", ns);
            elemAllowedBoxAxis.InnerText = cs.AllowOrthoAxisString;
            elemConstraintSet.AppendChild(elemAllowedBoxAxis);
            // allowAlternateLayers
            XmlElement elemAllowAlternateLayers = xmlDoc.CreateElement("allowAlternateLayers", ns);
            elemAllowAlternateLayers.InnerText = cs.AllowAlternateLayers.ToString();
            elemConstraintSet.AppendChild(elemAllowAlternateLayers);
            // allowAlignedLayers
            XmlElement elemAllowAlignedLayers = xmlDoc.CreateElement("allowAlignedLayers", ns);
            elemAllowAlignedLayers.InnerText = cs.AllowAlignedLayers.ToString();
            elemConstraintSet.AppendChild(elemAllowAlignedLayers);
            // interlayerPeriod
            if (cs.HasInterlayer)
            {
                XmlElement elemInterlayerPeriodGroup = xmlDoc.CreateElement("interlayerPeriodGroup", ns);
                elemConstraintSet.AppendChild(elemInterlayerPeriodGroup);
                XmlElement elemInterlayerPeriod = xmlDoc.CreateElement("interlayerPeriod", ns);
                elemInterlayerPeriod.InnerText = string.Format("{0}", cs.InterlayerPeriod);
                elemInterlayerPeriodGroup.AppendChild(elemInterlayerPeriod);
            }
            // stopCriterion
            if (cs.UseMaximumHeight)
            {
                XmlElement maximumPalletHeightGroup = xmlDoc.CreateElement("maximumPalletHeightGroup", ns);
                elemConstraintSet.AppendChild(maximumPalletHeightGroup);
                // maximum pallet height
                AppendElementValue(xmlDoc, maximumPalletHeightGroup, "maximumPalletHeight", UnitsManager.UnitType.UT_LENGTH, cs.MaximumHeight);
            }
            if (cs.UseMaximumNumberOfCases)
            {
                XmlElement maximumNumberOfItemsGroup = xmlDoc.CreateElement("maximumNumberOfItemsGroup", ns);
                elemConstraintSet.AppendChild(maximumNumberOfItemsGroup);
                XmlElement maximumNumberOfItems = xmlDoc.CreateElement("maximumNumberOfItems", ns);
                maximumNumberOfItems.InnerText = string.Format("{0}", cs.MaximumNumberOfItems);
                maximumNumberOfItemsGroup.AppendChild(maximumNumberOfItems);
            }
            if (cs.UseMaximumPalletWeight)
            {
                XmlElement maximumPalletWeightGroup = xmlDoc.CreateElement("maximumPalletWeightGroup", ns);
                elemConstraintSet.AppendChild(maximumPalletWeightGroup);
                // pallet weight
                AppendElementValue(xmlDoc, maximumPalletWeightGroup, "maximumPalletHeight", UnitsManager.UnitType.UT_MASS, cs.MaximumPalletWeight);
            }
            if (cs.UseMaximumWeightOnBox)
            {
                XmlElement maximumWeightOnBoxGroup = xmlDoc.CreateElement("maximumWeightOnBoxGroup", ns);
                elemConstraintSet.AppendChild(maximumWeightOnBoxGroup);
                // admissible load on top
                AppendElementValue(xmlDoc, maximumWeightOnBoxGroup, "admissibleLoadOnTop", UnitsManager.UnitType.UT_MASS, cs.MaximumWeightOnBox);
            }
        }
        private void AppendCylinderPalletConstraintSet(CylinderPalletConstraintSet cs, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // solution
            XmlElement elemConstraintSet = xmlDoc.CreateElement("constraintSet", ns);
            elemPalletAnalysis.AppendChild(elemConstraintSet);
            AppendElementValue(xmlDoc, elemConstraintSet, "overhangX", UnitsManager.UnitType.UT_LENGTH, cs.OverhangX);
            AppendElementValue(xmlDoc, elemConstraintSet, "overhangY", UnitsManager.UnitType.UT_LENGTH, cs.OverhangY);
            // stopCriterion
            if (cs.UseMaximumPalletHeight)
            {
                XmlElement maximumPalletHeightGroup = xmlDoc.CreateElement("maximumPalletHeightGroup", ns);
                elemConstraintSet.AppendChild(maximumPalletHeightGroup);
                // max pallet height
                AppendElementValue(xmlDoc, maximumPalletHeightGroup, "maximumPalletHeight", UnitsManager.UnitType.UT_LENGTH, cs.MaximumPalletHeight);
            }
            if (cs.UseMaximumNumberOfItems)
            {
                XmlElement maximumNumberOfItemsGroup = xmlDoc.CreateElement("maximumNumberOfItemsGroup", ns);
                elemConstraintSet.AppendChild(maximumNumberOfItemsGroup);
                XmlElement maximumNumberOfItems = xmlDoc.CreateElement("maximumNumberOfItems", ns);
                maximumNumberOfItems.InnerText = string.Format("{0}", cs.MaximumNumberOfItems);
                maximumNumberOfItemsGroup.AppendChild(maximumNumberOfItems);
            }
            if (cs.UseMaximumPalletWeight)
            {
                XmlElement maximumPalletWeightGroup = xmlDoc.CreateElement("maximumPalletWeightGroup", ns);
                elemConstraintSet.AppendChild(maximumPalletWeightGroup);
                // max pallet weight
                AppendElementValue(xmlDoc, maximumPalletWeightGroup, "maximumPalletHeight", UnitsManager.UnitType.UT_MASS, cs.MaximumPalletWeight);
            }
            if (cs.UseMaximumLoadOnLowerCylinder)
            {
                XmlElement maximumWeightOnBoxGroup = xmlDoc.CreateElement("maximumWeightOnCylinderGroup", ns);
                elemConstraintSet.AppendChild(maximumWeightOnBoxGroup);
                // admissible load on top
                AppendElementValue(xmlDoc, maximumWeightOnBoxGroup, "maximumPalletHeight", UnitsManager.UnitType.UT_MASS, cs.MaximumLoadOnLowerCylinder);
            }
        }

        private void AppendHCylinderPalletConstraintSet(HCylinderPalletConstraintSet cs, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // solution
            XmlElement elemConstraintSet = xmlDoc.CreateElement("constraintSet", ns);
            elemPalletAnalysis.AppendChild(elemConstraintSet);
            AppendElementValue(xmlDoc, elemConstraintSet, "overhangX", UnitsManager.UnitType.UT_LENGTH, cs.OverhangX);
            AppendElementValue(xmlDoc, elemConstraintSet, "overhangY", UnitsManager.UnitType.UT_LENGTH, cs.OverhangY);
            // stopCriterion
            if (cs.UseMaximumPalletHeight)
            {
                XmlElement maximumPalletHeightGroup = xmlDoc.CreateElement("maximumPalletHeightGroup", ns);
                elemConstraintSet.AppendChild(maximumPalletHeightGroup);
                // max pallet height
                AppendElementValue(xmlDoc, maximumPalletHeightGroup, "maximumPalletHeight", UnitsManager.UnitType.UT_LENGTH, cs.MaximumPalletHeight);
            }
            if (cs.UseMaximumNumberOfItems)
            {
                XmlElement maximumNumberOfItemsGroup = xmlDoc.CreateElement("maximumNumberOfItemsGroup", ns);
                elemConstraintSet.AppendChild(maximumNumberOfItemsGroup);
                XmlElement maximumNumberOfItems = xmlDoc.CreateElement("maximumNumberOfItems", ns);
                maximumNumberOfItems.InnerText = string.Format("{0}", cs.MaximumNumberOfItems);
                maximumNumberOfItemsGroup.AppendChild(maximumNumberOfItems);
            }
            if (cs.UseMaximumPalletWeight)
            {
                XmlElement maximumPalletWeightGroup = xmlDoc.CreateElement("maximumPalletWeightGroup", ns);
                elemConstraintSet.AppendChild(maximumPalletWeightGroup);
                // max pallet weight
                AppendElementValue(xmlDoc, maximumPalletWeightGroup, "maximumPalletHeight", UnitsManager.UnitType.UT_MASS, cs.MaximumPalletWeight);
            }
        }
        #endregion

        #region Dimensions
        private void AppendInsideBoxElement(Analysis analysis, CasePalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get caseOfBoxProperties
            CaseOfBoxesProperties caseOfBoxes = analysis.Content as CaseOfBoxesProperties;
            // get box properties
            BoxProperties boxProperties = caseOfBoxes.InsideBoxProperties;
            // elemBoxes
            XmlElement elemBox = xmlDoc.CreateElement("box", ns);
            elemPalletAnalysis.AppendChild(elemBox);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = boxProperties.Name;
            elemBox.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = boxProperties.Description;
            elemBox.AppendChild(elemDescription);

            AppendElementValue(xmlDoc, elemBox, "length", UnitsManager.UnitType.UT_LENGTH, boxProperties.Length);
            AppendElementValue(xmlDoc, elemBox, "width", UnitsManager.UnitType.UT_LENGTH, boxProperties.Width);
            AppendElementValue(xmlDoc, elemBox, "height", UnitsManager.UnitType.UT_LENGTH, boxProperties.Height);
            AppendElementValue(xmlDoc, elemBox, "weight", UnitsManager.UnitType.UT_MASS, boxProperties.Weight);

            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            Box box = new Box(0, boxProperties);
            graphics.AddBox(box);
            DimensionCube dc = new DimensionCube(box.Length, box.Width, box.Height);    dc.FontSize = 6.0f;
            graphics.AddDimensions(dc);
            graphics.Flush();
            // ---
            // imageThumb
            AppendThumbnailElement(xmlDoc, elemBox, graphics.Bitmap);
        }

        private void AppendInterlayerElement(InterlayerProperties interlayerProp, XmlElement elemAnalysis, XmlDocument xmlDoc)
        {
            // sanity check
            if (null == interlayerProp) return;
            // namespace
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // interlayer
            XmlElement elemInterlayer = xmlDoc.CreateElement("interlayer", ns);
            elemAnalysis.AppendChild(elemInterlayer);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = interlayerProp.Name;
            elemInterlayer.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = interlayerProp.Description;
            elemInterlayer.AppendChild(elemDescription);

            AppendElementValue(xmlDoc, elemInterlayer, "length", UnitsManager.UnitType.UT_LENGTH, interlayerProp.Length);
            AppendElementValue(xmlDoc, elemInterlayer, "width", UnitsManager.UnitType.UT_LENGTH, interlayerProp.Width);
            AppendElementValue(xmlDoc, elemInterlayer, "thickness", UnitsManager.UnitType.UT_LENGTH, interlayerProp.Thickness);
            AppendElementValue(xmlDoc, elemInterlayer, "weight", UnitsManager.UnitType.UT_MASS, interlayerProp.Weight);

            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
            graphics.CameraPosition = Graphics3D.Corner_0;
            Box box = new Box(0, interlayerProp);
            graphics.AddBox(box);
            DimensionCube dc = new DimensionCube(interlayerProp.Length, interlayerProp.Width, interlayerProp.Thickness); dc.FontSize = 6.0f;
            graphics.AddDimensions(dc);
            graphics.Flush();
            // ---
            // imageThumb
            AppendThumbnailElement(xmlDoc, elemInterlayer, graphics.Bitmap);
        }

        private void AppendPalletCornerElement(PalletCornerProperties palletCornerProp, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            // sanity check
            if (null == palletCornerProp) return;
            // namespace
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // interlayer
            XmlElement elemPalletCorner = xmlDoc.CreateElement("palletCorner", ns);
            elemPalletAnalysis.AppendChild(elemPalletCorner);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = palletCornerProp.Name;
            elemPalletCorner.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = palletCornerProp.Description;
            elemPalletCorner.AppendChild(elemDescription);

            AppendElementValue(xmlDoc, elemPalletCorner, "length", UnitsManager.UnitType.UT_LENGTH, palletCornerProp.Length);
            AppendElementValue(xmlDoc, elemPalletCorner, "width", UnitsManager.UnitType.UT_LENGTH, palletCornerProp.Width);
            AppendElementValue(xmlDoc, elemPalletCorner, "thickness", UnitsManager.UnitType.UT_LENGTH, palletCornerProp.Thickness);
            AppendElementValue(xmlDoc, elemPalletCorner, "weight", UnitsManager.UnitType.UT_LENGTH, palletCornerProp.Weight);
            // ---
            // view_palletCorner_iso
            // build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
            graphics.CameraPosition = Graphics3D.Corner_0;
            Corner corner = new Corner(0, palletCornerProp);
            corner.Draw(graphics);
            graphics.Flush();
            // imageThumb
            AppendThumbnailElement(xmlDoc, elemPalletCorner, graphics.Bitmap);
        }

        private void AppendPalletCapElement(PalletCapProperties palletCapProp, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            // sanity check
            if (null == palletCapProp) return;
            // namespace
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // interlayer
            XmlElement elemPalletCap = xmlDoc.CreateElement("palletCap", ns);
            elemPalletAnalysis.AppendChild(elemPalletCap);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = palletCapProp.Name;
            elemPalletCap.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = palletCapProp.Description;
            elemPalletCap.AppendChild(elemDescription);

            AppendElementValue(xmlDoc, elemPalletCap, "length", UnitsManager.UnitType.UT_LENGTH, palletCapProp.Length);
            AppendElementValue(xmlDoc, elemPalletCap, "width", UnitsManager.UnitType.UT_LENGTH, palletCapProp.Width);
            AppendElementValue(xmlDoc, elemPalletCap, "height", UnitsManager.UnitType.UT_LENGTH, palletCapProp.Height);
            AppendElementValue(xmlDoc, elemPalletCap, "innerLength", UnitsManager.UnitType.UT_LENGTH, palletCapProp.InsideLength);
            AppendElementValue(xmlDoc, elemPalletCap, "innerWidth", UnitsManager.UnitType.UT_LENGTH, palletCapProp.InsideWidth);
            AppendElementValue(xmlDoc, elemPalletCap, "innerHeight", UnitsManager.UnitType.UT_LENGTH, palletCapProp.InsideHeight);
            AppendElementValue(xmlDoc, elemPalletCap, "weight", UnitsManager.UnitType.UT_MASS, palletCapProp.Weight);
            // ---
            // view_palletCap_iso
            // build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
            graphics.CameraPosition = Graphics3D.Corner_0;
            PalletCap palletCap = new PalletCap(0, palletCapProp, BoxPosition.Zero);
            palletCap.Draw(graphics);
            graphics.AddDimensions(new DimensionCube(palletCapProp.Length, palletCapProp.Width, palletCapProp.Height));
            graphics.Flush();
            // imageThumb
            AppendThumbnailElement(xmlDoc, elemPalletCap, graphics.Bitmap);
        }

        private void AppendPalletFilmElement(PalletFilmProperties palletFilmProp, Analysis analyis, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            // sanity check
            if (null == palletFilmProp) return;
            // namespace
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // interlayer
            XmlElement elemPalletFilm = xmlDoc.CreateElement("palletFilm", ns);
            elemPalletAnalysis.AppendChild(elemPalletFilm);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = palletFilmProp.Name;
            elemPalletFilm.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = palletFilmProp.Description;
            elemPalletFilm.AppendChild(elemDescription);
            // number of turns
            ConstraintSetCasePallet constaintSet = analyis.ConstraintSet as ConstraintSetCasePallet;
            XmlElement elemNumberOfTurns = xmlDoc.CreateElement("numberOfTurns", ns);
            elemNumberOfTurns.InnerText = constaintSet.PalletFilmTurns.ToString();
            elemPalletFilm.AppendChild(elemNumberOfTurns);
        }

        #region Helpers
        private void AppendThumbnailElement(XmlDocument xmlDoc, XmlElement parentElement, Bitmap bmp)
        {
            // get image path
            string imagePath = SaveImageAs(bmp);
            // namespace
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // imageThumb element
            XmlElement elemImage = xmlDoc.CreateElement("imageThumb", ns);
            parentElement.AppendChild(elemImage);
            // imagePath element
            XmlElement elemImagePath = xmlDoc.CreateElement("imagePath", ns);
            elemImage.AppendChild(elemImagePath);
            elemImagePath.InnerText = imagePath;
        }
        #endregion
        /*
        private void AppendSolutionElement(ReportData inputData, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;

            SelCasePalletSolution selSolution = inputData.SelSolution;
            CasePalletSolution sol = inputData.CasePalletSolution;

            // solution
            XmlElement elemSolution = xmlDoc.CreateElement("palletSolution", ns);
            elemPalletAnalysis.AppendChild(elemSolution);
            // title
            XmlElement elemTitle = xmlDoc.CreateElement("title", ns);
            elemTitle.InnerText = sol.Title;
            elemSolution.AppendChild(elemTitle);
            // homogeneousLayer
            XmlElement elemHomogeneousLayer = xmlDoc.CreateElement("homogeneousLayer", ns);
            elemHomogeneousLayer.InnerText = sol.HasHomogeneousLayers.ToString();
            elemSolution.AppendChild(elemHomogeneousLayer);
            // efficiency
            XmlElement elemEfficiency = xmlDoc.CreateElement("efficiency", ns);
            elemEfficiency.InnerText = string.Format("{0:F}", sol.VolumeEfficiencyCases);
            elemSolution.AppendChild(elemEfficiency);

            AppendElementValue(xmlDoc, elemSolution, "palletWeight", UnitsManager.UnitType.UT_MASS, inputData.ActualPalletWeight);
            AppendElementValue(xmlDoc, elemSolution, "palletLength", UnitsManager.UnitType.UT_LENGTH, sol.PalletLength);
            AppendElementValue(xmlDoc, elemSolution, "palletWidth", UnitsManager.UnitType.UT_LENGTH, sol.PalletWidth);
            AppendElementValue(xmlDoc, elemSolution, "palletHeight", UnitsManager.UnitType.UT_LENGTH, sol.PalletHeight);

            // caseCount
            XmlElement elemCaseCount = xmlDoc.CreateElement("caseCount", ns);
            elemCaseCount.InnerText = string.Format("{0}", sol.CaseCount);
            elemSolution.AppendChild(elemCaseCount);
            // if case of boxes, add box count + box efficiency
            if (sol.Analysis.BProperties is CaseOfBoxesProperties)
            {
                CaseOfBoxesProperties caseOfBoxes = sol.Analysis.BProperties as CaseOfBoxesProperties;
                XmlElement elemBoxCount = xmlDoc.CreateElement("boxCount", ns);
                elemBoxCount.InnerText = string.Format("{0:F}", caseOfBoxes.NumberOfBoxes);
                elemSolution.AppendChild(elemBoxCount);
                XmlElement elemBoxEfficiency = xmlDoc.CreateElement("boxEfficiency", ns);
                elemBoxEfficiency.InnerText = string.Format("{0:F}", sol.VolumeEfficiencyCases);
            }
            // layerCount
            XmlElement elemLayerCount = xmlDoc.CreateElement("layerCount", ns);
            elemLayerCount.InnerText = string.Format("{0}", sol.CaseLayersCount);
            elemSolution.AppendChild(elemLayerCount);
            // layer1_caseCount / layer2_caseCount
            XmlElement elemLayer1_caseCount = xmlDoc.CreateElement("layer1_caseCount", ns);
            elemLayer1_caseCount.InnerText = string.Format("{0}", sol.CaseLayerFirst.BoxCount);
            elemSolution.AppendChild(elemLayer1_caseCount);
            if (sol.Count > 1 && (sol.CaseLayerFirst.BoxCount != sol.CaseLayerSecond.BoxCount))
            {
                XmlElement elemLayer2_caseCount = xmlDoc.CreateElement("layer2_caseCount", ns);
                elemLayer2_caseCount.InnerText = string.Format("{0}", sol.CaseLayerSecond.BoxCount);
                elemSolution.AppendChild(elemLayer2_caseCount);
            }
            // interlayer count
            if (sol.Analysis.ConstraintSet.HasInterlayer)
            {
                XmlElement elemInterlayerCount = xmlDoc.CreateElement("interlayerCount", ns);
                elemInterlayerCount.InnerText = string.Format("{0}", sol.InterlayerCount);
                elemSolution.AppendChild(elemInterlayerCount);
            }
            // --- layer images
            for (int i = 0; i < Math.Min(sol.Count, (sol.HasHomogeneousLayers ? 1 : 2)); ++i)
            {
                XmlElement elemLayer = xmlDoc.CreateElement("layer", ns);
                // layerId
                XmlElement xmlLayerId = xmlDoc.CreateElement("layerId", ns);
                xmlLayerId.InnerText = string.Format("{0}", i + 1);
                elemLayer.AppendChild(xmlLayerId);
                // --- build layer image
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
                // set camera position 
                graphics.CameraPosition = Graphics3D.Top;
                // instantiate solution viewer
                CasePalletSolutionViewer sv = new CasePalletSolutionViewer(sol);
                sv.DrawLayers(graphics, true, i );
                // ---
                // layerImage
                XmlElement elemLayerImage = xmlDoc.CreateElement("layerImage", ns);
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                elemLayerImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
                XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
                styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 2, graphics.Bitmap.Height / 2);
                elemLayerImage.Attributes.Append(styleAttribute);
                elemLayer.AppendChild(elemLayerImage);
                // layerCaseCount
                XmlElement elemLayerBoxCount = xmlDoc.CreateElement("layerCaseCount", ns);
                elemLayerBoxCount.InnerText = sol[i].BoxCount.ToString();
                elemLayer.AppendChild(elemLayerBoxCount);

                elemSolution.AppendChild(elemLayer);
                // save image
                SaveImageAs(graphics.Bitmap, string.Format("layerImage{0}.png", i + 1));
            }
            // --- pallet images
            for (int i = 0; i < 5; ++i)
            {
                // initialize drawing values
                string viewName = string.Empty;
                Vector3D cameraPos = Vector3D.Zero;
                int imageWidth = ImageSizeDetail;
                bool showDimensions = false;
                switch (i)
                {
                    case 0:
                        viewName = "view_palletsolution_front"; cameraPos = Graphics3D.Front; imageWidth = ImageSizeDetail;
                        break;
                    case 1:
                        viewName = "view_palletsolution_left"; cameraPos = Graphics3D.Left; imageWidth = ImageSizeDetail;
                        break;
                    case 2:
                        viewName = "view_palletsolution_right"; cameraPos = Graphics3D.Right; imageWidth = ImageSizeDetail;
                        break;
                    case 3:
                        viewName = "view_palletsolution_back"; cameraPos = Graphics3D.Back; imageWidth = ImageSizeDetail;
                        break;
                    case 4:
                        viewName = "view_palletsolution_iso"; cameraPos = Graphics3D.Corner_180; imageWidth = ImageSizeWide; showDimensions = true;
                        break;
                    default:
                        break;
                }
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(imageWidth, imageWidth));
                // set camera position 
                graphics.CameraPosition = cameraPos;
                // instantiate solution viewer
                CasePalletSolutionViewer sv = new CasePalletSolutionViewer(sol);
                sv.ShowDimensions = showDimensions;
                sv.Draw(graphics);
                graphics.Flush();
                SaveImageAs(graphics.Bitmap, viewName + ".png");
                // ---
                XmlElement elemImage = xmlDoc.CreateElement(viewName, ns);
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
                XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
                styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 3, graphics.Bitmap.Height / 3);
                elemImage.Attributes.Append(styleAttribute);
                elemSolution.AppendChild(elemImage);
            }
        }

        private void AppendPackPalletSolutionElement(ReportData inputData, XmlElement elemPackPalletAnalysis, XmlDocument xmlDoc)
        {
            if (!inputData.IsPackPalletAnalysis) return;

            string ns = xmlDoc.DocumentElement.NamespaceURI;

            SelPackPalletSolution selSolution = inputData.SelPackPalletSolution;
            PackPalletSolution sol = inputData.PackPalletSolution;

            // solution
            XmlElement elemSolution = xmlDoc.CreateElement("packPalletSolution", ns);
            elemPackPalletAnalysis.AppendChild(elemSolution);
            // title
            XmlElement elemTitle = xmlDoc.CreateElement("title", ns);
            elemTitle.InnerText = sol.Title;
            elemSolution.AppendChild(elemTitle);
            // efficiency
            XmlElement elemEfficiency = xmlDoc.CreateElement("efficiency", ns);
            elemEfficiency.InnerText = string.Format( "{0:F}", sol.VolumeEfficiency );
            elemSolution.AppendChild(elemEfficiency);
            // length / width / height
            AppendElementValue(xmlDoc, elemSolution, "length", UnitsManager.UnitType.UT_LENGTH, sol.PalletLength);
            AppendElementValue(xmlDoc, elemSolution, "width", UnitsManager.UnitType.UT_LENGTH, sol.PalletWidth);
            AppendElementValue(xmlDoc, elemSolution, "height", UnitsManager.UnitType.UT_LENGTH, sol.PalletHeight);
            // counts
            AppendElementValue(xmlDoc, elemSolution, "palletPackCount", sol.PackCount);
            AppendElementValue(xmlDoc, elemSolution, "palletCSUCount", sol.CSUCount);
            AppendElementValue(xmlDoc, elemSolution, "palletInterlayerCount", sol.InterlayerCount);
            // 
            AppendElementValue(xmlDoc, elemSolution, "palletWeight", UnitsManager.UnitType.UT_MASS, sol.PalletWeight);
            AppendElementValue(xmlDoc, elemSolution, "palletLoadWeight", UnitsManager.UnitType.UT_MASS, sol.PalletLoadWeight);
            AppendElementValue(xmlDoc, elemSolution, "palletNetWeight", UnitsManager.UnitType.UT_MASS, sol.PalletNetWeight);
            AppendElementValue(xmlDoc, elemSolution, "overhangX", UnitsManager.UnitType.UT_LENGTH, sol.OverhangX);
            AppendElementValue(xmlDoc, elemSolution, "overhangY", UnitsManager.UnitType.UT_LENGTH, sol.OverhangY);
            // --- pallet images
            for (int i = 0; i < 5; ++i)
            {
                // initialize drawing values
                string viewName = string.Empty;
                Vector3D cameraPos = Vector3D.Zero;
                int imageWidth = ImageSizeDetail;
                bool showDimensions = false;
                switch (i)
                {
                    case 0: viewName = "view_palletsolution_front"; cameraPos = Graphics3D.Front; imageWidth = ImageSizeDetail; break;
                    case 1: viewName = "view_palletsolution_left"; cameraPos = Graphics3D.Left; imageWidth = ImageSizeDetail;   break;
                    case 2: viewName = "view_palletsolution_right"; cameraPos = Graphics3D.Right; imageWidth = ImageSizeDetail; break;
                    case 3: viewName = "view_palletsolution_back"; cameraPos = Graphics3D.Back; imageWidth = ImageSizeDetail;   break;
                    case 4: viewName = "view_palletsolution_iso"; cameraPos = Graphics3D.Corner_180; imageWidth = ImageSizeWide; showDimensions = true; break;
                    default:  break;
                }
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(imageWidth, imageWidth));
                // set camera position 
                graphics.CameraPosition = cameraPos;
                // instantiate solution viewer
                PackPalletSolutionViewer sv = new PackPalletSolutionViewer(sol);
                sv.ShowDimensions = showDimensions;
                sv.Draw(graphics);
                graphics.Flush();
                SaveImageAs(graphics.Bitmap, viewName + ".png");
                // ---
                XmlElement elemImage = xmlDoc.CreateElement(viewName, ns);
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
                XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
                styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 3, graphics.Bitmap.Height / 3);
                elemImage.Attributes.Append(styleAttribute);
                elemSolution.AppendChild(elemImage);
            }

            // --- layers
            for (int i=0; i<sol.NoLayerTypes; ++i)
            {
                XmlElement elemLayerPack = xmlDoc.CreateElement("layerPack", ns);
                elemSolution.AppendChild(elemLayerPack);

                LayerType layerType = sol.GetLayerType(i);
                AppendElementValue(xmlDoc, elemLayerPack, "layerPackCount", layerType.PackCount);
                AppendElementValue(xmlDoc, elemLayerPack, "layerCSUCount", layerType.CSUCount);
                AppendElementValue(xmlDoc, elemLayerPack, "layerWeight", UnitsManager.UnitType.UT_MASS, layerType.LayerWeight);
                AppendElementValue(xmlDoc, elemLayerPack, "layerNetWeight", UnitsManager.UnitType.UT_MASS, layerType.LayerNetWeight);
                AppendElementValue(xmlDoc, elemLayerPack, "layerLength", UnitsManager.UnitType.UT_LENGTH, layerType.Length);
                AppendElementValue(xmlDoc, elemLayerPack, "layerWidth", UnitsManager.UnitType.UT_LENGTH, layerType.Width);
                AppendElementValue(xmlDoc, elemLayerPack, "layerHeight", UnitsManager.UnitType.UT_LENGTH, layerType.Height);
                AppendElementValue(xmlDoc, elemLayerPack, "maximumSpace", UnitsManager.UnitType.UT_LENGTH, layerType.MaximumSpace);
                AppendElementValue(xmlDoc, elemLayerPack, "layerIndexes", layerType.LayerIndexes);

                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
                // set camera position 
                graphics.CameraPosition = Graphics3D.Corner_180;
                // instantiate solution viewer
                PackPalletSolutionViewer sv = new PackPalletSolutionViewer(sol);
                sv.ShowDimensions = true;
                sv.DrawLayer(graphics, i);
                graphics.Flush();
                string viewName = string.Format("view_layer_iso{0}", i);
                SaveImageAs(graphics.Bitmap, viewName + ".png");
                // ---
                XmlElement elemImage = xmlDoc.CreateElement("imagePackLayer", ns);
                elemImage.InnerText = "images\\" + viewName + ".png";
                elemLayerPack.AppendChild(elemImage);
            }
        }

        private void AppendCylinderPalletSolutionElement(ReportData inputData, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            if (!inputData.IsCylinderPalletAnalysis) return;

            string ns = xmlDoc.DocumentElement.NamespaceURI;

            SelCylinderPalletSolution selSolution = inputData.SelCylinderPalletSolution;
            CylinderPalletSolution sol = inputData.CylinderPalletSolution;

            // solution
            XmlElement elemSolution = xmlDoc.CreateElement("palletSolution", ns);
            elemPalletAnalysis.AppendChild(elemSolution);
            // title
            XmlElement elemTitle = xmlDoc.CreateElement("title", ns);
            elemTitle.InnerText = sol.Title;
            elemSolution.AppendChild(elemTitle);
            // efficiency
            XmlElement elemEfficiency = xmlDoc.CreateElement("efficiency", ns);
            elemEfficiency.InnerText = string.Format("{0:F}", sol.VolumeEfficiency);
            elemSolution.AppendChild(elemEfficiency);

            AppendElementValue(xmlDoc, elemSolution, "palletWeight", UnitsManager.UnitType.UT_MASS, inputData.ActualPalletWeight);
            AppendElementValue(xmlDoc, elemSolution, "palletHeight", UnitsManager.UnitType.UT_LENGTH, sol.PalletHeight);

            // cylinderCount
            XmlElement elemCaseCount = xmlDoc.CreateElement("cylinderCount", ns);
            elemCaseCount.InnerText = string.Format("{0}", sol.CylinderCount);
            elemSolution.AppendChild(elemCaseCount);
            // layerCount
            XmlElement elemLayerCount = xmlDoc.CreateElement("layerCount", ns);
            elemCaseCount.InnerText = string.Format("{0}", sol.CylinderLayersCount);
            elemSolution.AppendChild(elemCaseCount);
            // interlayer count
            if (sol.Analysis.ConstraintSet.HasInterlayer)
            {
                XmlElement elemInterlayerCount = xmlDoc.CreateElement("interlayerCount", ns);
                elemInterlayerCount.InnerText = string.Format("{0}", sol.InterlayerCount);
                elemSolution.AppendChild(elemInterlayerCount);
            }
            // layer (single)
            {
                // --- layer image
                XmlElement elemLayer = xmlDoc.CreateElement("layer", ns);
                // layerId
                XmlElement xmlLayerId = xmlDoc.CreateElement("layerId", ns);
                xmlLayerId.InnerText = string.Format("{0}", 1);
                elemLayer.AppendChild(xmlLayerId);
                // --- build layer image
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
                // set camera position 
                graphics.CameraPosition = Graphics3D.Top;
                // instantiate solution viewer
                CylinderPalletSolutionViewer sv = new CylinderPalletSolutionViewer(sol);
                sv.DrawLayers(graphics, true, 0 );
                // ---
                // layerImage
                XmlElement elemLayerImage = xmlDoc.CreateElement("layerImage", ns);
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                elemLayerImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
                XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
                styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 2, graphics.Bitmap.Height / 2);
                elemLayerImage.Attributes.Append(styleAttribute);
                elemLayer.AppendChild(elemLayerImage);
                // layerCylinderCount
                XmlElement elemLayerBoxCount = xmlDoc.CreateElement("layerCylinderCount", ns);
                elemLayerBoxCount.InnerText = string.Format("{0}", sol.CylinderPerLayerCount);
                elemLayer.AppendChild(elemLayerBoxCount);
                elemSolution.AppendChild(elemLayer);
                // save image
                SaveImageAs(graphics.Bitmap, string.Format("layerImage{0}.png", 1));
            }
            // --- pallet images
            for (int i = 0; i < 5; ++i)
            {
                // initialize drawing values
                string viewName = string.Empty;
                Vector3D cameraPos = Vector3D.Zero;
                int imageWidth = ImageSizeDetail;
                bool showDimensions = false;
                switch (i)
                {
                    case 0:
                        viewName = "view_palletsolution_front"; cameraPos = Graphics3D.Front; imageWidth = ImageSizeDetail;
                        break;
                    case 1:
                        viewName = "view_palletsolution_left"; cameraPos = Graphics3D.Left; imageWidth = ImageSizeDetail;
                        break;
                    case 2:
                        viewName = "view_palletsolution_right"; cameraPos = Graphics3D.Right; imageWidth = ImageSizeDetail;
                        break;
                    case 3:
                        viewName = "view_palletsolution_back"; cameraPos = Graphics3D.Back; imageWidth = ImageSizeDetail;
                        break;
                    case 4:
                        viewName = "view_palletsolution_iso"; cameraPos = Graphics3D.Corner_0; imageWidth = ImageSizeWide; showDimensions = true;
                        break;
                    default:
                        break;
                }
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(imageWidth, imageWidth));
                // set camera position 
                graphics.CameraPosition = cameraPos;
                // instantiate solution viewer
                CylinderPalletSolutionViewer sv = new CylinderPalletSolutionViewer(sol);
                sv.ShowDimensions = showDimensions;
                sv.Draw(graphics);
                // ---
                XmlElement elemImage = xmlDoc.CreateElement(viewName, ns);
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
                XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
                styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 3, graphics.Bitmap.Height / 3);
                elemImage.Attributes.Append(styleAttribute);
                elemSolution.AppendChild(elemImage);
                // Save image ?
                SaveImageAs(graphics.Bitmap, viewName + ".png");
            }
        }

        private void AppendHCylinderPalletSolutionElement(ReportData inputData, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            if (!inputData.IsHCylinderPalletAnalysis) return;

            string ns = xmlDoc.DocumentElement.NamespaceURI;

            SelHCylinderPalletSolution selSolution = inputData.SelHCylinderPalletSolution;
            HCylinderPalletSolution sol = inputData.HCylinderPalletSolution;

            // solution
            XmlElement elemSolution = xmlDoc.CreateElement("palletSolution", ns);
            elemPalletAnalysis.AppendChild(elemSolution);
            // title
            XmlElement elemTitle = xmlDoc.CreateElement("title", ns);
            elemTitle.InnerText = sol.Title;
            elemSolution.AppendChild(elemTitle);

            AppendElementValue(xmlDoc, elemSolution, "palletWeight", UnitsManager.UnitType.UT_MASS, inputData.ActualPalletWeight);
            AppendElementValue(xmlDoc, elemSolution, "palletHeight", UnitsManager.UnitType.UT_LENGTH, sol.PalletHeight);

            // cylinderCount
            XmlElement elemCaseCount = xmlDoc.CreateElement("cylinderCount", ns);
            elemCaseCount.InnerText = string.Format("{0}", sol.CylinderCount);
            elemSolution.AppendChild(elemCaseCount);
            // --- pallet images
            for (int i = 0; i < 5; ++i)
            {
                // initialize drawing values
                string viewName = string.Empty;
                Vector3D cameraPos = Vector3D.Zero;
                int imageWidth = ImageSizeDetail;
                bool showDimensions = false;
                switch (i)
                {
                    case 0:
                        viewName = "view_palletsolution_front"; cameraPos = Graphics3D.Front; imageWidth = ImageSizeDetail;
                        break;
                    case 1:
                        viewName = "view_palletsolution_left"; cameraPos = Graphics3D.Left; imageWidth = ImageSizeDetail;
                        break;
                    case 2:
                        viewName = "view_palletsolution_right"; cameraPos = Graphics3D.Right; imageWidth = ImageSizeDetail;
                        break;
                    case 3:
                        viewName = "view_palletsolution_back"; cameraPos = Graphics3D.Back; imageWidth = ImageSizeDetail;
                        break;
                    case 4:
                        viewName = "view_palletsolution_iso"; cameraPos = Graphics3D.Corner_0; imageWidth = ImageSizeWide; showDimensions = true;
                        break;
                    default:
                        break;
                }
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(imageWidth, imageWidth));
                // set camera position 
                graphics.CameraPosition = cameraPos;
                // instantiate solution viewer
                HCylinderPalletSolutionViewer sv = new HCylinderPalletSolutionViewer(sol);
                sv.ShowDimensions = showDimensions;
                sv.Draw(graphics);
                // ---
                XmlElement elemImage = xmlDoc.CreateElement(viewName, ns);
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
                XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
                styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 3, graphics.Bitmap.Height / 3);
                elemImage.Attributes.Append(styleAttribute);
                elemSolution.AppendChild(elemImage);
                // Save image ?
                SaveImageAs(graphics.Bitmap, viewName + ".png");
            }
        }

        private void AppendTruckAnalysisElement(ReportData inputData, XmlElement elemDocument, XmlDocument xmlDoc)
        {
            if (!inputData.IsCasePalletAnalysis) return;
            CasePalletAnalysis analysis = inputData.CasePalletAnalysis;
            SelCasePalletSolution selSolution = inputData.SelSolution;

            // retrieve truck analysis if any
            if (!selSolution.HasTruckAnalyses) return;  // no truck analysis available -> exit

            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // truckAnalysis
            XmlElement elemTruckAnalysis = xmlDoc.CreateElement("truckAnalysis", ns);
            elemDocument.AppendChild(elemTruckAnalysis);

            TruckAnalysis truckAnalysis = selSolution.TruckAnalyses[0];
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = analysis.Name;
            elemTruckAnalysis.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = analysis.Description;
            elemTruckAnalysis.AppendChild(elemDescription);
            // truck
            AppendTruckElement(truckAnalysis, elemTruckAnalysis, xmlDoc);
            // solution
            AppendTruckSolutionElement(inputData, elemTruckAnalysis, xmlDoc);
        }

        private void AppendEctAnalysisElement(ReportData inputData, XmlElement elemDocument, XmlDocument xmlDoc)
        {

            if (!inputData.IsCasePalletAnalysis)
                return;
            CasePalletAnalysis analysis = inputData.CasePalletAnalysis;
            SelCasePalletSolution selSolution = inputData.SelSolution;

            // retrieve ect analysis if any
            if (!selSolution.HasECTAnalyses) return;

            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // ectAnalysis
            XmlElement elemEctAnalysis = xmlDoc.CreateElement("ectAnalysis", ns);
            elemDocument.AppendChild(elemEctAnalysis);

            ECTAnalysis ectAnalysis = selSolution.EctAnalyses[0];
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = ectAnalysis.Name;
            elemEctAnalysis.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = ectAnalysis.Description;
            elemEctAnalysis.AppendChild(elemDescription);
             // cardboard
            XmlElement elemCardboard = xmlDoc.CreateElement("cardboard", ns);
            elemEctAnalysis.AppendChild(elemCardboard);
            XmlElement elemCardboardName = xmlDoc.CreateElement("name", ns);
            elemCardboardName.InnerText = ectAnalysis.Cardboard.Name;
            elemCardboard.AppendChild(elemCardboardName);

            AppendElementValue(xmlDoc, elemCardboard, "thickness", UnitsManager.UnitType.UT_LENGTH, ectAnalysis.Cardboard.Thickness);

            XmlElement elemCardboadECT = xmlDoc.CreateElement("ect", ns);
            elemCardboadECT.InnerText = string.Format("{0:0.00}", ectAnalysis.Cardboard.ECT);
            elemCardboard.AppendChild(elemCardboadECT);
            XmlElement elemCardboardStiffnessX = xmlDoc.CreateElement("stiffnessX", ns);
            elemCardboardStiffnessX.InnerText = string.Format("{0:0.00}", ectAnalysis.Cardboard.RigidityDX);
            elemCardboard.AppendChild(elemCardboardStiffnessX);
            XmlElement elemCardboardStiffnessY = xmlDoc.CreateElement("stiffnessY", ns);
            elemCardboardStiffnessY.InnerText = string.Format("{0:0.00}", ectAnalysis.Cardboard.RigidityDY);
            elemCardboard.AppendChild(elemCardboardStiffnessY);
            // case type
            XmlElement elemCaseType = xmlDoc.CreateElement("caseType", ns);
            elemCaseType.InnerText = ectAnalysis.CaseType;
            elemEctAnalysis.AppendChild(elemCaseType);
            // printed surface
            XmlElement elemPrintedSurface = xmlDoc.CreateElement("printedSurface", ns);
            elemPrintedSurface.InnerText = ectAnalysis.PrintSurface;
            elemEctAnalysis.AppendChild(elemPrintedSurface);
            // mc kee formula mode
            XmlElement elemMcKeeFormula = xmlDoc.CreateElement("mcKeeFormulaMode", ns);
            elemMcKeeFormula.InnerText = ectAnalysis.McKeeFormulaText;
            elemEctAnalysis.AppendChild(elemMcKeeFormula);
            // bct_static
            XmlElement elemStaticBCT = xmlDoc.CreateElement("bct_static", ns);
            elemEctAnalysis.AppendChild(elemStaticBCT);
            XmlElement elemStaticValue = xmlDoc.CreateElement("static_value", ns);
            elemStaticValue.InnerText = string.Format("{0:0.00}", ectAnalysis.StaticBCT);
            elemStaticBCT.AppendChild(elemStaticValue);
            // bct_dynamic
            XmlElement elemDynamicBCT = xmlDoc.CreateElement("bct_dynamic", ns);
            elemEctAnalysis.AppendChild(elemDynamicBCT);
            Dictionary<KeyValuePair<string, string>, double> ectDictionary = ectAnalysis.DynamicBCTDictionary;
            foreach (string storageKey in treeDiM.EdgeCrushTest.McKeeFormula.StockCoefDictionary.Keys)
            {
                XmlElement elemBCTStorage = xmlDoc.CreateElement("bct_dynamic_storage", ns);
                elemDynamicBCT.AppendChild(elemBCTStorage);
                // duration
                XmlElement elemStorageDuration = xmlDoc.CreateElement("duration", ns);
                elemStorageDuration.InnerText = storageKey;
                elemBCTStorage.AppendChild(elemStorageDuration);
                // humidity rate -> values
                string[] elementHumidityNames
                    = {
                      "humidity_0_45"
                      , "humidity_46_55"
                      , "humidity_56_65"
                      , "humidity_66_75"
                      , "humidity_76_85"
                      , "humidity_86_100"
                   };
                int indexHumidity = 0;
                foreach (string humidityKey in treeDiM.EdgeCrushTest.McKeeFormula.HumidityCoefDictionary.Keys)
                {
                    // get value of ect for "storage time" + "humidity"
                    double ectValue = ectDictionary[new KeyValuePair<string, string>(storageKey, humidityKey)];
                    XmlElement elemHumidity = xmlDoc.CreateElement(elementHumidityNames[indexHumidity++], ns);
                    elemHumidity.InnerText = string.Format("{0:0.00}", ectValue);
                    elemBCTStorage.AppendChild(elemHumidity);

                    // attribute stating if value is correct or below admissible value
                    XmlAttribute attributeAdmissible = xmlDoc.CreateAttribute("admissible");
                    attributeAdmissible.Value = selSolution.Solution.AverageLoadOnFirstLayerCase < ectValue ? "true" : "false";
                    elemHumidity.Attributes.Append(attributeAdmissible);
                } 
            }
        }
*/
        private void AppendTruckElement(TruckProperties truckProp, XmlElement elemAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get truckProperties
            if (null == truckProp) return;
            // create "truck" element
            XmlElement elemTruck = xmlDoc.CreateElement("truck", ns);
            elemAnalysis.AppendChild(elemTruck);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = truckProp.Name;
            elemTruck.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = truckProp.Description;
            elemTruck.AppendChild(elemDescription);

            AppendElementValue(xmlDoc, elemTruck, "length", UnitsManager.UnitType.UT_LENGTH, truckProp.Length);
            AppendElementValue(xmlDoc, elemTruck, "width", UnitsManager.UnitType.UT_LENGTH, truckProp.Width);
            AppendElementValue(xmlDoc, elemTruck, "height", UnitsManager.UnitType.UT_LENGTH, truckProp.Height);
            AppendElementValue(xmlDoc, elemTruck, "admissibleLoad", UnitsManager.UnitType.UT_MASS, truckProp.AdmissibleLoadWeight);

            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
            graphics.CameraPosition = Graphics3D.Corner_0;
            Truck truck = new Truck(truckProp);
            truck.DrawBegin(graphics);
            truck.DrawEnd(graphics);
            DimensionCube dc = new DimensionCube(truckProp.Length, truckProp.Width, truckProp.Height);      dc.FontSize = 6.0f;
            graphics.AddDimensions(dc);
            graphics.Flush();
            AppendThumbnailElement(xmlDoc, elemTruck, graphics.Bitmap);
        }
        /*
        private void AppendTruckSolutionElement(ReportData inputData, XmlElement elemTruckAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;

            CasePalletSolution palletSolution = inputData.CasePalletSolution;
            TruckAnalysis truckAnalysis = inputData.SelSolution.TruckAnalyses[0];

            // retrieve selected truckSolution
            TruckSolution truckSolution = truckAnalysis.SelectedSolution;
            if (null == truckSolution) return;
            // create "truckSolution" element
            XmlElement elemTruckSolution = xmlDoc.CreateElement("truckSolution", ns);
            elemTruckAnalysis.AppendChild(elemTruckSolution);
            if (!string.IsNullOrEmpty(truckSolution.Title))
            {
                // title
                XmlElement elemTitle = xmlDoc.CreateElement("title", ns);
                elemTitle.InnerText = truckSolution.Title;
                elemTruckSolution.AppendChild(elemTitle);
            }
            // palletCount
            XmlElement elemPalletCount = xmlDoc.CreateElement("palletCount", ns);
            elemPalletCount.InnerText = string.Format("{0}", truckSolution.PalletCount);
            elemTruckSolution.AppendChild(elemPalletCount);
            // boxCount
            XmlElement elemBoxCount = xmlDoc.CreateElement("caseCount", ns);
            elemBoxCount.InnerText = string.Format("{0}", truckSolution.BoxCount);
            elemTruckSolution.AppendChild(elemBoxCount);

            double loadWeight = truckSolution.PalletCount * inputData.ActualPalletWeight;
            AppendElementValue(xmlDoc, elemTruckSolution, "loadWeight", UnitsManager.UnitType.UT_MASS, loadWeight);

            // loadEfficiency
            XmlElement elemLoadEfficiency = xmlDoc.CreateElement("loadEfficiency", ns);
            elemLoadEfficiency.InnerText = string.Format("{0:F}", 100.0 * loadWeight / truckAnalysis.TruckProperties.AdmissibleLoadWeight);
            elemTruckSolution.AppendChild(elemLoadEfficiency);
            // volumeEfficiency
            XmlElement elemVolumeEfficiency = xmlDoc.CreateElement("volumeEfficiency", ns);
            elemVolumeEfficiency.InnerText = string.Format("{0:F}", truckSolution.Efficiency);
            elemTruckSolution.AppendChild(elemVolumeEfficiency);

            // --- truck images
            for (int i = 0; i < 2; ++i)
            {
                // initialize drawing values
                string viewName = string.Empty;
                Vector3D cameraPos = Vector3D.Zero;
                int imageWidth = ImageSizeWide;
                switch (i)
                {
                    case 0: viewName = "view_trucksolution_top"; cameraPos = Graphics3D.Top; imageWidth = ImageSizeWide; break;
                    case 1: viewName = "view_trucksolution_iso"; cameraPos = Graphics3D.Corner_0; imageWidth = ImageSizeWide; break;
                    default: break;
                }
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(imageWidth, imageWidth));
                // set camera position 
                graphics.CameraPosition = cameraPos;
                // dimensions
                if (1 == i)
                {
                    TruckProperties truckProp = truckSolution.ParentTruckAnalysis.TruckProperties;
                    graphics.AddDimensions(new DimensionCube(truckSolution.LoadBoundingBox, Color.Red, false));
                    graphics.AddDimensions(new DimensionCube(Vector3D.Zero, truckProp.Length, truckProp.Width, truckProp.Height, Color.Black, true));
                }
                // instantiate solution viewer
                TruckSolutionViewer sv = new TruckSolutionViewer(truckSolution);
                sv.Draw(graphics);
                graphics.Flush();
                // ---
                XmlElement elemImage = xmlDoc.CreateElement(viewName, ns);
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
                XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
                styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 3, graphics.Bitmap.Height / 3);
                elemImage.Attributes.Append(styleAttribute);
                elemTruckSolution.AppendChild(elemImage);
                // Save image ?
                SaveImageAs(graphics.Bitmap, viewName + ".png");
            }
        }
        */ 
        #endregion

        #region Case analysis
        /*
        private void AppendCaseAnalysisElement(ReportData inputData, XmlElement elemDocument, XmlDocument xmlDoc)
        {
            // check if case analysis
            if (!inputData.IsBoxCasePalletAnalysis)
                return;
            BoxCasePalletAnalysis caseAnalysis = inputData.CaseAnalysis;
            SelBoxCasePalletSolution selSolution = inputData.SelCaseSolution;

            if (null == selSolution.Solution.PalletSolutionDesc.LoadPalletSolution())
                return;
            
            // namespace
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // caseAnalysis
            XmlElement elemCaseAnalysis = xmlDoc.CreateElement("boxCasePalletAnalysis", ns);
            elemDocument.AppendChild(elemCaseAnalysis);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = caseAnalysis.Name;
            elemCaseAnalysis.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = caseAnalysis.Description;
            elemCaseAnalysis.AppendChild(elemDescription);
            // box
            AppendBoxElement(caseAnalysis.BoxProperties, elemCaseAnalysis, xmlDoc);
            // case
            AppendCaseElement(selSolution, elemCaseAnalysis, xmlDoc);
            // constraint set
            AppendCaseConstraintSet(caseAnalysis, elemCaseAnalysis, xmlDoc);
            // case solution
            AppendCaseSolutionElement(selSolution, elemCaseAnalysis, xmlDoc);
        }
        */ 
        #endregion

        #region BoxCaseAnalysis
        /*
        private void AppendBoxCaseAnalysisElement(ReportData inputData, XmlElement elemDocument, XmlDocument xmlDoc)
        {
            // check if case analysis
            if (!inputData.IsBoxCaseAnalysis)
                return;
            BoxCaseAnalysis boxCaseAnalysis = inputData.BoxCaseAnalysis;
            SelBoxCaseSolution selBoxCaseSolution = inputData.SelBoxCaseSolution;
            // namespace
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // caseAnalysis
            XmlElement elemBoxCaseAnalysis = xmlDoc.CreateElement("boxCaseAnalysis", ns);
            elemDocument.AppendChild(elemBoxCaseAnalysis);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = boxCaseAnalysis.Name;
            elemBoxCaseAnalysis.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = boxCaseAnalysis.Description;
            elemBoxCaseAnalysis.AppendChild(elemDescription);
            // box
            if (boxCaseAnalysis.BProperties is BoxProperties)
                AppendBoxElement(boxCaseAnalysis.BProperties as BoxProperties, elemBoxCaseAnalysis, xmlDoc);
            else if (boxCaseAnalysis.BProperties is BundleProperties)
                AppendBundleElement(boxCaseAnalysis.BProperties as BundleProperties, elemBoxCaseAnalysis, xmlDoc);
            // case
            AppendCaseElement(boxCaseAnalysis.CaseProperties, elemBoxCaseAnalysis, xmlDoc);
            // constraint set
            AppendBoxCaseConstraintSet(boxCaseAnalysis.ConstraintSet, elemBoxCaseAnalysis, xmlDoc);
            // solution
            AppendBoxCaseSolutionElement(selBoxCaseSolution.Solution, elemBoxCaseAnalysis, xmlDoc);
        }
        */ 
        #endregion

        #region BoxProperties / PackProperties
        private void AppendCaseElement(BoxProperties caseProperties, XmlElement elemAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // case element
            XmlElement elemCase = CreateElement("caseWithInnerDims", null, elemAnalysis, xmlDoc, ns);
            // name
            CreateElement("name", caseProperties.Name, elemCase, xmlDoc, ns);
            // description
            CreateElement("description", caseProperties.Description, elemCase, xmlDoc, ns);
            // unit width
            // length / width /height
            AppendElementValue(xmlDoc, elemCase, "length", UnitsManager.UnitType.UT_LENGTH, caseProperties.Length);
            AppendElementValue(xmlDoc, elemCase, "width", UnitsManager.UnitType.UT_LENGTH, caseProperties.Width);
            AppendElementValue(xmlDoc, elemCase, "height", UnitsManager.UnitType.UT_LENGTH, caseProperties.Height);
            // innerLength / innerWidth / innerHeight
            AppendElementValue(xmlDoc, elemCase, "innerLength", UnitsManager.UnitType.UT_LENGTH, caseProperties.InsideLength);
            AppendElementValue(xmlDoc, elemCase, "innerWidth", UnitsManager.UnitType.UT_LENGTH, caseProperties.InsideWidth);
            AppendElementValue(xmlDoc, elemCase, "innerHeight", UnitsManager.UnitType.UT_LENGTH, caseProperties.InsideHeight);
            // weight
            AppendElementValue(xmlDoc, elemCase, "weight", UnitsManager.UnitType.UT_MASS, caseProperties.Weight);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            Box box = new Box(0, caseProperties);
            graphics.AddBox(box);
            DimensionCube dc = new DimensionCube(box.Length, box.Width, box.Height);        dc.FontSize = 6.0f;
            graphics.AddDimensions(dc);
            graphics.Flush();
            // ---
            // imageThumb
            AppendThumbnailElement(xmlDoc, elemCase, graphics.Bitmap);
        }
        private void AppendPackElement(PackProperties packProperties, XmlElement elemPackAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // pack element
            XmlElement elemPack = CreateElement("pack", null, elemPackAnalysis, xmlDoc, ns);
            // name
            CreateElement("name", packProperties.Name, elemPack, xmlDoc, ns);
            // description
            CreateElement("description", packProperties.Description, elemPack, xmlDoc, ns);
            // arrangement
            PackArrangement arrangement = packProperties.Arrangement;
            CreateElement(
                "arrangement"
                , string.Format("{0} * {1} * {2}", arrangement.Length, arrangement.Width, arrangement.Height)
                , elemPack, xmlDoc, ns);
            // length / width /height
            AppendElementValue(xmlDoc, elemPack, "length", UnitsManager.UnitType.UT_LENGTH, packProperties.Length);
            AppendElementValue(xmlDoc, elemPack, "width", UnitsManager.UnitType.UT_LENGTH, packProperties.Width);
            AppendElementValue(xmlDoc, elemPack, "height", UnitsManager.UnitType.UT_LENGTH, packProperties.Height);
            // weight
            AppendElementValue(xmlDoc, elemPack, "netWeight", UnitsManager.UnitType.UT_MASS, packProperties.NetWeight);
            AppendElementValue(xmlDoc, elemPack, "wrapperWeight", UnitsManager.UnitType.UT_MASS, packProperties.Wrap.Weight);
            AppendElementValue(xmlDoc, elemPack, "weight", UnitsManager.UnitType.UT_MASS, packProperties.Weight);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            Pack pack = new Pack(0, packProperties);
            pack.ForceTransparency = true;
            graphics.AddBox(pack);
            DimensionCube dc = new DimensionCube(pack.Length, pack.Width, pack.Height); dc.FontSize = 6.0f;
            graphics.AddDimensions(dc);
            graphics.Flush();
            // imageThumb
            AppendThumbnailElement(xmlDoc, elemPack, graphics.Bitmap);
        }

        private void AppendBoxElement(BoxProperties boxProperties, XmlElement elemAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // box element
            XmlElement elemBox = CreateElement("box", null, elemAnalysis, xmlDoc, ns);
            // name
            CreateElement("name", boxProperties.Name, elemBox, xmlDoc, ns);
            // description
            CreateElement("description", boxProperties.Description, elemBox, xmlDoc, ns);

            AppendElementValue(xmlDoc, elemBox, "length", UnitsManager.UnitType.UT_LENGTH, boxProperties.Length);
            AppendElementValue(xmlDoc, elemBox, "width", UnitsManager.UnitType.UT_LENGTH, boxProperties.Width);
            AppendElementValue(xmlDoc, elemBox, "height", UnitsManager.UnitType.UT_LENGTH, boxProperties.Height);
            AppendElementValue(xmlDoc, elemBox, "weight", UnitsManager.UnitType.UT_MASS, boxProperties.Weight);
            // view_box_iso
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(ImageSizeDetail, ImageSizeDetail));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            Box box = new Box(0, boxProperties);
            graphics.AddBox(box);
            graphics.AddDimensions(new DimensionCube(box.Length, box.Width, box.Height));
            graphics.Flush();
            // ---
            // imageThumb
            AppendThumbnailElement(xmlDoc, elemBox, graphics.Bitmap);
        }
        #endregion

        #region Constraint sets : Box/Case
        private void AppendBoxCaseConstraintSet(BCaseConstraintSet bCaseConstraintSet, XmlElement elemDocument, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // caseConstraintSet element
            XmlElement elemCaseConstraintSet = null;
            if (bCaseConstraintSet is BoxCaseConstraintSet)
            {
                elemCaseConstraintSet = CreateElement("boxCaseConstraintSet", null, elemDocument, xmlDoc, ns);
                // down cast
                BoxCaseConstraintSet boxCaseConstraintSet = bCaseConstraintSet as BoxCaseConstraintSet;
                // allowedOrthoAxis
                CreateElement("allowedOrthoAxis", boxCaseConstraintSet.AllowOrthoAxisString, elemCaseConstraintSet, xmlDoc, ns);
            }
            else if (bCaseConstraintSet is BundleCaseConstraintSet)
            {
                elemCaseConstraintSet = CreateElement("bundleCaseConstraintSet", null, elemDocument, xmlDoc, ns);
            }
            // maximumCaseWeightGroup
            if (bCaseConstraintSet.UseMaximumCaseWeight)
            {
                XmlElement maximumCaseWeightGroup = CreateElement("maximumCaseWeightGroup", null, elemCaseConstraintSet, xmlDoc, ns);
                AppendElementValue(xmlDoc, maximumCaseWeightGroup, "maximumCaseWeight", UnitsManager.UnitType.UT_MASS, bCaseConstraintSet.MaximumCaseWeight);
            }
            // minimumBoxPerCaseGroup
            if (bCaseConstraintSet.UseMaximumNumberOfBoxes)
            {
                XmlElement maximumBoxPerCaseGroup = CreateElement("MaximumNumberOfBoxesGroup", null, elemCaseConstraintSet, xmlDoc, ns);
                CreateElement("maximumBoxPerCase", bCaseConstraintSet.MaximumNumberOfBoxes, maximumBoxPerCaseGroup, xmlDoc, ns);
            }
        }
        #endregion // BoxCaseAnalysis

        #region Case constraint set
        private void AppendCaseConstraintSet(BoxCasePalletAnalysis caseAnalysis, XmlElement elemCaseAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            BoxCasePalletConstraintSet cs = caseAnalysis.ConstraintSet;
            // caseConstraintSet element
            XmlElement elemCaseConstraintSet = CreateElement("caseConstraintSet", null, elemCaseAnalysis, xmlDoc, ns);
            // allowedPatterns
            CreateElement("allowedPatterns", cs.AllowedPatternString, elemCaseConstraintSet, xmlDoc, ns);
            // allowedOrthoAxis
            CreateElement("allowedOrthoAxis", cs.AllowOrthoAxisString, elemCaseConstraintSet, xmlDoc, ns);
            // allowAlignedLayers
            CreateElement("allowAlignedLayers", cs.AllowAlignedLayers ? "Y" : "N", elemCaseConstraintSet, xmlDoc, ns);
            // allowAlternateLayers
            CreateElement("allowAlternateLayers", cs.AllowAlternateLayers ? "Y" : "N", elemCaseConstraintSet, xmlDoc, ns);
            // maximumCaseWeightGroup
            if (cs.UseMaximumCaseWeight)
            {
                XmlElement maximumCaseWeightGroup = CreateElement("maximumCaseWeightGroup", null, elemCaseConstraintSet, xmlDoc, ns);
                AppendElementValue(xmlDoc, maximumCaseWeightGroup, "maximumCaseWeight", UnitsManager.UnitType.UT_MASS, cs.MaximumCaseWeight);
            }
            // minimumBoxPerCaseGroup
            if (cs.UseMinimumNumberOfItems)
            {
                XmlElement minimumBoxPerCaseGroup = CreateElement("minimumBoxPerCaseGroup", null, elemCaseConstraintSet, xmlDoc, ns);
                CreateElement("minimumBoxPerCase", cs.MinimumNumberOfItems, minimumBoxPerCaseGroup, xmlDoc, ns);
            }
            // maximumBoxPerCaseGroup
            if (cs.UseMaximumNumberOfItems)
            {
                XmlElement maximumBoxPerCaseGroup = CreateElement("minimumBoxPerCaseGroup", null, elemCaseConstraintSet, xmlDoc, ns);
                CreateElement("maximumBoxPerCase", cs.MinimumNumberOfItems, maximumBoxPerCaseGroup, xmlDoc, ns);
            }
        }
        #endregion


        #region Helpers
        private static XmlElement CreateElement(string eltName, string innerValue, XmlElement parentElt, XmlDocument xmlDoc, string ns)
        {
            XmlElement elt = xmlDoc.CreateElement(eltName, ns);
            if (!string.IsNullOrEmpty(innerValue))
                elt.InnerText = innerValue;
            parentElt.AppendChild(elt);
            return elt;
        }
        private static XmlElement CreateElement(string eltName, double v, XmlElement parentElt, XmlDocument xmlDoc, string ns)
        {
            XmlElement elt = xmlDoc.CreateElement(eltName, ns);
            elt.InnerText = string.Format("{0:F}", v);
            parentElt.AppendChild(elt);
            return elt;
        }
        private static XmlElement CreateElement(string eltName, int v, XmlElement parentElt, XmlDocument xmlDoc, string ns)
        {
            XmlElement elt = xmlDoc.CreateElement(eltName, ns);
            elt.InnerText = string.Format("{0}", v);
            parentElt.AppendChild(elt);
            return elt;
        }
        private static void AppendElementValue(XmlDocument xmlDoc, XmlElement parent, string eltName, UnitsManager.UnitType unitType, OptDouble optValue)
        {
            if (optValue.Activated)
            {
                // eltName
                XmlElement createdElement = xmlDoc.CreateElement(eltName, xmlDoc.DocumentElement.NamespaceURI);
                parent.AppendChild(createdElement);
                // unit
                XmlElement unitElement = xmlDoc.CreateElement("unit", xmlDoc.DocumentElement.NamespaceURI);
                unitElement.InnerText = UnitsManager.UnitString(unitType);
                createdElement.AppendChild(unitElement);
                // value
                XmlElement valueElement = xmlDoc.CreateElement("value", xmlDoc.DocumentElement.NamespaceURI);
                valueElement.InnerText = string.Format(UnitsManager.UnitFormat(unitType), optValue.Value);
                createdElement.AppendChild(valueElement);
            }
        }
        private static void AppendElementValue(XmlDocument xmlDoc, XmlElement parent, string eltName, UnitsManager.UnitType unitType, double eltValue)
        {
            // eltName
            XmlElement createdElement = xmlDoc.CreateElement(eltName, xmlDoc.DocumentElement.NamespaceURI);
            parent.AppendChild(createdElement);
            // unit
            XmlElement unitElement = xmlDoc.CreateElement("unit", xmlDoc.DocumentElement.NamespaceURI);
            unitElement.InnerText = UnitsManager.UnitString(unitType);
            createdElement.AppendChild(unitElement);
            // value
            XmlElement valueElement = xmlDoc.CreateElement("value", xmlDoc.DocumentElement.NamespaceURI);
            valueElement.InnerText = string.Format(UnitsManager.UnitFormat(unitType), eltValue);
            createdElement.AppendChild(valueElement);
        }
        private static void AppendElementValue(XmlDocument xmlDoc, XmlElement parent, string eltName, double eltValue)
        {
            XmlElement createdElement = xmlDoc.CreateElement(eltName, xmlDoc.DocumentElement.NamespaceURI);
            createdElement.InnerText = string.Format("{0:0.#}", eltValue);
            parent.AppendChild(createdElement);
        }
        private static void AppendElementValue(XmlDocument xmlDoc, XmlElement parent, string eltName, int eltValue)
        {
            XmlElement createdElement = xmlDoc.CreateElement(eltName, xmlDoc.DocumentElement.NamespaceURI);
            createdElement.InnerText = string.Format("{0}", eltValue);
            parent.AppendChild(createdElement);
        }
        private static void AppendElementValue(XmlDocument xmlDoc, XmlElement parent, string eltName, string eltValue)
        {
            XmlElement createdElement = xmlDoc.CreateElement(eltName, xmlDoc.DocumentElement.NamespaceURI);
            createdElement.InnerText = string.Format("{0}", eltValue);
            parent.AppendChild(createdElement);
        }
        private static void AppendContentItem(XmlDocument xmlDoc, XmlElement parent, string itemName, int itemNumber)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            XmlElement elemItem = xmlDoc.CreateElement("item", ns);
            parent.AppendChild(elemItem);
            // itemName
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = itemName;
            elemItem.AppendChild(elemName);
            // itemNumber
            XmlElement elemValue = xmlDoc.CreateElement("value", ns);
            elemValue.InnerText = itemNumber.ToString();
            elemItem.AppendChild(elemValue);
        }
        private string SaveImageAs(Bitmap bmp)
        {
            if (!WriteImageFiles) return string.Empty;
            string fileName = string.Format("image_{0}.png", ++_imageIndex);
            try { bmp.Save(Path.Combine(ImageDirectory, fileName), System.Drawing.Imaging.ImageFormat.Png); }
            catch (Exception ex) { _log.Error(ex.ToString()); }
            return @"images\" + fileName;
        }
        public string ToAbsolute(string pathString)
        {
            if (Path.IsPathRooted(pathString))
                return pathString;
            else
                return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), pathString));
        }
        #endregion

        #region Deleting methods
        public void DeleteImageDirectory()
        {
            try { System.IO.Directory.Delete(_imageDirectory, true); }
            catch (Exception ex) { _log.Error(ex.Message); }
        }
        #endregion

        #region XML validator
        // Validation Error Count
        static int ErrorsCount = 0;
        // Validation Error Message
        static string ErrorMessage = "";

        private static void ValidateXmlDocument(XmlReader documentToValidate, string schemaPath)
        {
            XmlSchema schema;
            using (var schemaReader = XmlReader.Create(schemaPath))
            {
                schema = XmlSchema.Read(schemaReader, ValidationEventHandler);
            }

            var schemas = new XmlSchemaSet();
            schemas.Add(schema);
            var settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = schemas;
            settings.ValidationFlags =
                XmlSchemaValidationFlags.ProcessIdentityConstraints |
                XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += ValidationEventHandler;

            using (var validationReader = XmlReader.Create(documentToValidate, settings))
            { while (validationReader.Read()) { } }

            if (ErrorsCount > 0)
                throw new Exception(ErrorMessage);
        }

        private static void ValidationEventHandler(
            object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Error)
            {
                ErrorMessage = ErrorMessage + args.Message + "\r\n";
                ErrorsCount++;
            }
        }
        #endregion
    }
    #endregion
}
