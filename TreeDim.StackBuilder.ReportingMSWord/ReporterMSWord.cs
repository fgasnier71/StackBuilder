﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;

using Sharp3D.Math.Core;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Reporting
{
    /// <summary>
    /// Builds a word file from a Microsoft Word template file
    /// Ideas are from a codeproject article:
    /// http://www.codeproject.com/KB/office/Generating_Word_Reports.aspx
    /// Template production process decomposes as follow:
    /// 1. Create Report.doc
    /// 2. Import xml schema (xsd)
    /// 3. Map data on the document
    /// 4. Save the document as xml (Word ML)
    /// 5. Convert to xslt document template using the following command line:
    ///     WML2XSLT.EXE "Report.xml" -o "Report.xslt"
    /// 6. Edit generated xslt file and add conditions when necessary (e.g. missing xml data elements)
    ///     using <!-- <xsl:if test="ElementName"></xsl:if> -->
    /// 7. Edit generated xslt images and replace template definition with:
    /*
       <xsl:template match="/ns0:report/ns0:palletAnalysis/ns0:case/ns0:view_case_iso">
         <ns0:view_case_iso>
          <xsl:for-each select="@ns1:*|@*[namespace-uri()='']">
            <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
              <xsl:value-of select="." />
            </xsl:attribute>
          </xsl:for-each>
          <w:r>
            <w:pict>
			    <w:binData w:name="wordml://01000001.gif">
			      <xsl:value-of select="." />
			    </w:binData>
			    <v:shape id="_x0000_i1025" type="#_x0000_t75">
				    <xsl:attribute name="style">
					    <xsl:value-of select="@style"/>
				    </xsl:attribute>
				    <v:imagedata src="wordml://01000001.gif" o:title="convert" />
			    </v:shape>
            </w:pict>
          </w:r>
        </ns0:view_case_iso>
      </xsl:template>
    */
    /// </summary>
    public class ReporterMSWord : Reporter
    {
        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(ReporterMSWord));
        protected static bool _validateAgainstSchema = false;
        #endregion

        #region Static helpers
        private static void AppendElementValue(XmlDocument xmlDoc, XmlElement parent, string eltName, double eltValue)
        {
            XmlElement createdElement = xmlDoc.CreateElement(eltName, xmlDoc.DocumentElement.NamespaceURI);
            createdElement.InnerText = string.Format("{0}", eltValue);
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
        #endregion

        #region Xslt template file generation methods
        public static bool BuildXsltFromWml(string reportTemplatePath, out string xsltFilePath)
        {
            // report file name
            string wmlFileName = string.Format("ReportTemplateMSWord_{0}.xml"
                , System.Globalization.CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName);
            // report file path
            string wmlFilePath = Path.Combine(reportTemplatePath, wmlFileName);
            // check if file can be found, else get default
            if (!File.Exists(wmlFilePath))
                wmlFilePath = Path.Combine(reportTemplatePath, "ReportTemplate_ENU.xml");
            // check template file existence
            if (!File.Exists(wmlFilePath))
                throw new FileNotFoundException(string.Format("Failed to find template file {0}", wmlFilePath), wmlFilePath);
            // get path of wml2xslt.exe
            string wml2xsltPath = Path.Combine(reportTemplatePath, "WML2XSLT.EXE");
            // temp xslt from wml
            string tempXslt = Path.GetTempFileName();
            ProcessStartInfo startInfo = new ProcessStartInfo(
                string.Format("\"{0}\"", wml2xsltPath)
                , string.Format("\"{0}\" -o \"{1}\" -ns \"http://treeDim/StackBuilder/ReportSchema.xsd\""
                , wmlFilePath
                , tempXslt));
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardOutput = true;
            Process procWml2xslt = Process.Start(startInfo);
            _log.Info(procWml2xslt.StandardOutput.ReadToEnd());
            // check xslt existence
            if (!File.Exists(tempXslt))
                throw new FileNotFoundException("Failed to generate .xslt file", tempXslt);
            // create new xslt document
            xsltFilePath = Path.ChangeExtension(Path.GetTempFileName(), "xslt");
            // load xml file in document and parse document
            using (FileStream fileStream = new FileStream(tempXslt, FileMode.Open))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileStream);
                XmlElement xmlRootElement = xmlDoc.DocumentElement;

                XmlNamespaceManager nsm = new XmlNamespaceManager(xmlDoc.NameTable);
                nsm.AddNamespace("w", "http://schemas.microsoft.com/office/word/2003/wordml");
                nsm.AddNamespace("xls", "http://www.w3.org/1999/XSL/Transform");
                nsm.AddNamespace("v", "urn:schemas-microsoft-com:vml");
                nsm.AddNamespace("o", "urn:schemas-microsoft-com:office:office");

                ModifyXslt(xmlDoc, xmlRootElement, nsm);
                // finally save XmlDocument
                XmlTextWriter writer = new XmlTextWriter(xsltFilePath, System.Text.Encoding.UTF8);
                xmlDoc.Save(writer);
                writer.Close();
            }
            return true;
        }

        static public void ModifyXslt(XmlDocument doc, XmlElement rootElement, XmlNamespaceManager nsm)
        {
            XmlNodeList nodeList = rootElement.SelectNodes("//w:pict", nsm);
            _log.DebugFormat("Modifying {0} nodes...", nodeList.Count);

            int imageCounter = 0;

            foreach (XmlNode node in nodeList)
            {
                string imageName = string.Format("wordml://010000{0}.gif", ++imageCounter);
                // ### insert w:binData element
                XmlElement binDataElement = doc.CreateElement("w:binData", "http://schemas.microsoft.com/office/word/2003/wordml");
                // append w:name attribute
                XmlAttribute nameAttribute = doc.CreateAttribute("w:name", "http://schemas.microsoft.com/office/word/2003/wordml");
                nameAttribute.Value = imageName;
                binDataElement.Attributes.Append(nameAttribute);
                // append xsl:value-of element
                XmlElement valueofElement = doc.CreateElement("value-of", "http://www.w3.org/1999/XSL/Transform");
                // append "select" attribute
                XmlAttribute selectAttribute = doc.CreateAttribute("select");
                selectAttribute.Value = ".";
                valueofElement.Attributes.Append(selectAttribute);
                binDataElement.AppendChild(valueofElement);
                // insert v:binary element
                XmlElement pictElement = node as XmlElement;
                pictElement.AppendChild(binDataElement);

                // ### insert imagedata elt in  v:shape
                foreach (XmlNode pictChildNode in node.ChildNodes)
                {
                    XmlElement shapeElt = pictChildNode as XmlElement;
                    if (null == shapeElt) continue;
                    if (0 != string.Compare(shapeElt.Name, "v:shape")) continue;

                    // create imagedata elt
                    XmlElement imageDataElt = doc.CreateElement("imageData", "urn:schemas-microsoft-com:vml");
                    // create src attribute
                    XmlAttribute srcAttribute = doc.CreateAttribute("src");
                    srcAttribute.Value = imageName;
                    imageDataElt.Attributes.Append(srcAttribute);
                    // create title attribute
                    XmlAttribute titleAttribute = doc.CreateAttribute("title", "urn:schemas-microsoft-com:office:office");
                    titleAttribute.Value = "convert";
                    imageDataElt.Attributes.Append(titleAttribute);
                    shapeElt.AppendChild(imageDataElt);
                }

                // ### remove following w:p element
                // get parent node
                XmlNode pNode = node.ParentNode;
                // get grand parent node
                XmlNode ppNode = pNode.ParentNode;
                XmlElement eltToRemove = null;
                foreach (XmlNode childNode in ppNode.ChildNodes)
                {
                    eltToRemove = childNode as XmlElement;
                    if (0 == string.Compare(eltToRemove.Name, "w:p", true))
                    {
                        break;
                    }
                    else
                        eltToRemove = null;
                }
                // remove w:p element
                if (null != eltToRemove)
                    ppNode.RemoveChild(eltToRemove);

                // ### remove following w:r element if it contains w:t
                foreach (XmlNode childNode in ppNode.ChildNodes)
                {
                    eltToRemove = childNode as XmlElement;
                    if (0 == string.Compare(eltToRemove.Name, "w:r", true))
                    {
                        bool hasTChild = false;
                        foreach (XmlNode cNode in eltToRemove.ChildNodes)
                        {
                            if (0 == string.Compare(cNode.Name, "w:t", true))
                            {
                                hasTChild = true;
                                break;
                            }
                        }
                        if (hasTChild == true)
                            break;
                        else
                            eltToRemove = null;
                    }
                    else
                        eltToRemove = null;
                }
                // remove w:r element
                if (null != eltToRemove)
                    ppNode.RemoveChild(eltToRemove);
            }
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

        #region Static report building methods
        /// <summary>
        /// Creates Word document from XML using XSLT
        /// </summary>
        /// <param name="xmlData">Report data as XML</param>
        /// <param name="xsltReader">XSLT transformation as Stream, used for document creation</param>
        /// <returns>Resulting Word document as byte[]</returns>
        public static byte[] GetWord(XmlReader xmlData, XmlReader xsltReader)
        {
            // Initialize needed variables
            XslCompiledTransform xslt = new XslCompiledTransform();
            XsltArgumentList args = new XsltArgumentList();

            using (MemoryStream swResult = new MemoryStream())
            {
                // Load XSLT to reader and perform transformation
                xslt.Load(xsltReader);
                xslt.Transform(xmlData, args, swResult);

                return swResult.ToArray();
            }
        }
        public static void BuildAnalysisReport(PalletAnalysis analysis, SelSolution sol, string reportTemplatePath, string outputFilePath)
        {
            // create xml data file + XmlTextReader
            string xmlFilePath = Path.ChangeExtension(System.IO.Path.GetTempFileName(), "xml");
            CreateAnalysisDataFile(analysis, sol, xmlFilePath);
            XmlTextReader xmlData = new XmlTextReader(new FileStream(xmlFilePath, FileMode.Open, FileAccess.Read));
            // validate against schema
            // note xml file validation against xml schema produces a large number of errors
            // For the moment, I can not remove all errors
            if (_validateAgainstSchema)
                ValidateXmlDocument(xmlData, Path.Combine(reportTemplatePath, "ReportSchema.xsd"));
            // build xslt file
            string xsltTemplateFilePath = string.Empty;
            if (!BuildXsltFromWml(reportTemplatePath, out xsltTemplateFilePath))
                throw new Exception("Failed to build xslt template");
            // check availibility of files
            if (!File.Exists(xsltTemplateFilePath))
                throw new Exception(string.Format("Report template path ({0}) is invalid", xsltTemplateFilePath));
            // load generated xslt
            XmlTextReader xsltReader = new XmlTextReader(new FileStream(xsltTemplateFilePath, FileMode.Open, FileAccess.Read));
            // generate word document
            byte[] wordDoc = GetWord(xmlData, xsltReader);
            // write resulting array to HDD, show process information
            using (FileStream fs = new FileStream(outputFilePath, FileMode.Create))
                fs.Write(wordDoc, 0, wordDoc.Length);
        }
        private static void CreateAnalysisDataFile(PalletAnalysis analysis, SelSolution sol, string xmlDataFilePath)
        {
            // instantiate XmlDocument
            XmlDocument xmlDoc = new XmlDocument();
            // set declaration
            XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "no");
            xmlDoc.AppendChild(declaration);
            // report (root) element
            XmlElement elemDocument = xmlDoc.CreateElement("report", "http://treeDim/StackBuilder/ReportSchema.xsd");
            xmlDoc.AppendChild(elemDocument);

            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // name element
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = analysis.ParentDocument.Name;
            elemDocument.AppendChild(elemName);
            // description element
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = analysis.ParentDocument.Description;
            elemDocument.AppendChild(elemDescription);
            // author element
            XmlElement elemAuthor = xmlDoc.CreateElement("author", ns);
            elemAuthor.InnerText = analysis.ParentDocument.Author;
            elemDocument.AppendChild(elemAuthor);
            // date of creation element
            XmlElement elemDateOfCreation = xmlDoc.CreateElement("dateOfCreation", ns);
            elemDateOfCreation.InnerText = analysis.ParentDocument.DateOfCreation.ToString();
            elemDocument.AppendChild(elemDateOfCreation);

            // palletAnalysis
            AppendPalletAnalysisElement(analysis, sol, elemDocument, xmlDoc);
            // truckAnalysis
            AppendTruckAnalysisElement(analysis, sol, elemDocument, xmlDoc);

            // finally save xml document
            _log.Debug(string.Format("Generating xml data file {0}", xmlDataFilePath));
            xmlDoc.Save(xmlDataFilePath);
        }

        private static void AppendPalletAnalysisElement(PalletAnalysis analysis, SelSolution selSolution, XmlElement elemDocument, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // palletAnalysis
            XmlElement elemPalletAnalysis = xmlDoc.CreateElement("palletAnalysis", ns);
            elemDocument.AppendChild(elemPalletAnalysis);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = analysis.Name;
            elemPalletAnalysis.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = analysis.Description;
            elemPalletAnalysis.AppendChild(elemDescription);
            // pallet
            AppendPalletElement(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
            // case
            if (analysis.BProperties is CaseOfBoxesProperties)
            {
                AppendInsideBoxElement(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
                AppendCaseOfBoxesElement(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
            }
            else if (analysis.BProperties is BoxProperties)
                AppendCaseElement(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
            else if (analysis.BProperties is BundleProperties)
                AppendBundleElement(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
            // interlayer
            AppendInterlayerElement(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
            // constraintSet
            AppendConstraintSet(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
            // solution
            AppendSolutionElement(selSolution.Solution, elemPalletAnalysis, xmlDoc);
        }

        private static void AppendPalletElement(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get PalletProperties
            PalletProperties palletProp = analysis.PalletProperties;
            if (null == palletProp) return;
            // pallet
            XmlElement elemPallet = xmlDoc.CreateElement("pallet", ns);
            elemPalletAnalysis.AppendChild(elemPallet);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = analysis.PalletProperties.Name;
            elemPallet.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = analysis.PalletProperties.Description;
            elemPallet.AppendChild(elemDescription);
            // length
            XmlElement elemLength = xmlDoc.CreateElement("length", ns);
            elemLength.InnerText = string.Format("{0:F}", palletProp.Length);
            elemPallet.AppendChild(elemLength);
            // width
            XmlElement elemWidth = xmlDoc.CreateElement("width", ns);
            elemWidth.InnerText = string.Format("{0:F}", palletProp.Width);
            elemPallet.AppendChild(elemWidth);
            // height
            XmlElement elemHeight = xmlDoc.CreateElement("height", ns);
            elemHeight.InnerText = string.Format("{0:F}", palletProp.Height);
            elemPallet.AppendChild(elemHeight);
            // weight
            XmlElement elemWeight = xmlDoc.CreateElement("weight", ns);
            elemWeight.InnerText = string.Format("{0:F}", palletProp.Weight);
            elemPallet.AppendChild(elemWeight);
            // admissibleLoad
            XmlElement elemLoad = xmlDoc.CreateElement("admissibleLoad", ns);
            elemLoad.InnerText = string.Format("{0:F}", palletProp.AdmissibleLoadWeight);
            elemPallet.AppendChild(elemLoad);
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
            // view_pallet_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_pallet_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemPallet.AppendChild(elemImage);
        }

        private static void AppendCaseElement(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get BoxProperties
            BoxProperties boxProp = analysis.BProperties as BoxProperties;
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
            // length
            XmlElement elemLength = xmlDoc.CreateElement("length", ns);
            elemLength.InnerText = string.Format("{0:F}", boxProp.Length);
            elemCase.AppendChild(elemLength);
            // width
            XmlElement elemWidth = xmlDoc.CreateElement("width", ns);
            elemWidth.InnerText = string.Format("{0:F}", boxProp.Width);
            elemCase.AppendChild(elemWidth);
            // height
            XmlElement elemHeight = xmlDoc.CreateElement("height", ns);
            elemHeight.InnerText = string.Format("{0:F}", boxProp.Height);
            elemCase.AppendChild(elemHeight);
            // weight
            XmlElement elemWeight = xmlDoc.CreateElement("weight", ns);
            elemWeight.InnerText = string.Format("{0:F}", boxProp.Weight);
            elemCase.AppendChild(elemWeight);
            // admissible load
            XmlElement elemAdmissibleLoad = xmlDoc.CreateElement("admissibleLoadOnTop", ns);
            elemAdmissibleLoad.InnerText = string.Format("{0:F}", 0.0);
            elemCase.AppendChild(elemAdmissibleLoad);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            Box box = new Box(0, boxProp);
            graphics.AddBox(box);
            graphics.AddDimensions(new DimensionCube(box.Length, box.Width, box.Height));
            graphics.Flush();
            // ---
            // view_case_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_case_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemCase.AppendChild(elemImage);
        }

        private static void AppendBundleElement(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get BundleProperties
            BundleProperties bundleProp = analysis.BProperties as BundleProperties;
            if (null == bundleProp) return;
            // bundle
            XmlElement elemBundle = xmlDoc.CreateElement("bundle", ns);
            elemPalletAnalysis.AppendChild(elemBundle);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = bundleProp.Name;
            elemBundle.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = bundleProp.Description;
            elemBundle.AppendChild(elemDescription);
            // length
            XmlElement elemLength = xmlDoc.CreateElement("length", ns);
            elemLength.InnerText = string.Format("{0:F}", bundleProp.Length);
            elemBundle.AppendChild(elemLength);
            // width
            XmlElement elemWidth = xmlDoc.CreateElement("width", ns);
            elemWidth.InnerText = string.Format("{0:F}", bundleProp.Width);
            elemBundle.AppendChild(elemWidth);
            // numberOfFlats
            XmlElement elemNumber = xmlDoc.CreateElement("numberOfFlats", ns);
            elemNumber.InnerText = string.Format("{0}", bundleProp.NoFlats);
            elemBundle.AppendChild(elemNumber);
            // unitThickness
            XmlElement elemUnitThickness = xmlDoc.CreateElement("unitThickness", ns);
            elemUnitThickness.InnerText = string.Format("{0:F}", bundleProp.UnitThickness);
            elemBundle.AppendChild(elemUnitThickness);
            // unitWeight
            XmlElement elemUnitWeight = xmlDoc.CreateElement("unitWeight", ns);
            elemUnitWeight.InnerText = string.Format("{0:F}", bundleProp.UnitWeight);
            elemBundle.AppendChild(elemUnitWeight);
            // totalThickness
            XmlElement elemTotalThickness = xmlDoc.CreateElement("totalThickness", ns);
            elemTotalThickness.InnerText = string.Format("{0:F}", bundleProp.UnitThickness * bundleProp.NoFlats);
            elemBundle.AppendChild(elemTotalThickness);
            // totalWeight
            XmlElement elemTotalWeight = xmlDoc.CreateElement("totalWeight", ns);
            elemTotalWeight.InnerText = string.Format("{0:F}", bundleProp.UnitWeight * bundleProp.NoFlats);
            elemBundle.AppendChild(elemTotalWeight);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Corner_0;
            Box box = new Box(0, bundleProp);
            graphics.AddBox(box);
            graphics.AddDimensions(new DimensionCube(bundleProp.Length, bundleProp.Width, bundleProp.Height));
            graphics.Flush();
            // ---
            // view_bundle_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_bundle_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemBundle.AppendChild(elemImage);
        }

        private static void AppendConstraintSet(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            PalletConstraintSet cs = analysis.ConstraintSet;
            // solution
            XmlElement elemConstraintSet = xmlDoc.CreateElement("constraintSet", ns);
            elemPalletAnalysis.AppendChild(elemConstraintSet);
            AppendElementValue(xmlDoc, elemConstraintSet, "overhangX", cs.OverhangX);
            AppendElementValue(xmlDoc, elemConstraintSet, "overhangY", cs.OverhangY);
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
                XmlElement maximumPalletHeight = xmlDoc.CreateElement("maximumPalletHeight", ns);
                maximumPalletHeight.InnerText = string.Format("{0:F}", cs.MaximumHeight);
                maximumPalletHeightGroup.AppendChild(maximumPalletHeight);
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
                XmlElement maximumPalletWeight = xmlDoc.CreateElement("maximumPalletWeight", ns);
                maximumPalletWeight.InnerText = string.Format("{0:F}", cs.MaximumPalletWeight);
                maximumPalletWeightGroup.AppendChild(maximumPalletWeight);
            }
            if (cs.UseMaximumWeightOnBox)
            {
                XmlElement maximumWeightOnBoxGroup = xmlDoc.CreateElement("maximumWeightOnBoxGroup", ns);
                elemConstraintSet.AppendChild(maximumWeightOnBoxGroup);
                XmlElement admissibleLoadOnTop = xmlDoc.CreateElement("admissibleLoadOnTop", ns);
                admissibleLoadOnTop.InnerText = string.Format("{0:F}", cs.MaximumWeightOnBox);
                maximumWeightOnBoxGroup.AppendChild(admissibleLoadOnTop);
            }

        }
        private static void AppendInsideBoxElement(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get caseOfBoxProperties
            CaseOfBoxesProperties caseOfBoxes = analysis.BProperties as CaseOfBoxesProperties;
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
            // length
            XmlElement elemLength = xmlDoc.CreateElement("length", ns);
            elemLength.InnerText = string.Format("{0:F}", boxProperties.Length);
            elemBox.AppendChild(elemLength);
            // width
            XmlElement elemWidth = xmlDoc.CreateElement("width", ns);
            elemWidth.InnerText = string.Format("{0:F}", boxProperties.Width);
            elemBox.AppendChild(elemWidth);
            // height
            XmlElement elemHeight = xmlDoc.CreateElement("height", ns);
            elemHeight.InnerText = string.Format("{0:F}", boxProperties.Height);
            elemBox.AppendChild(elemHeight);
            // weight
            XmlElement elemWeight = xmlDoc.CreateElement("weight", ns);
            elemWeight.InnerText = string.Format("{0:F}", boxProperties.Weight);
            elemBox.AppendChild(elemWeight);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            Box box = new Box(0, boxProperties);
            graphics.AddBox(box);
            graphics.AddDimensions(new DimensionCube(box.Length, box.Width, box.Height));
            graphics.Flush();
            // ---
            // view_box_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_box_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemBox.AppendChild(elemImage);
        }
        private static void AppendCaseOfBoxesElement(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get CaseOfBoxProperties
            CaseOfBoxesProperties caseOfBoxes = analysis.BProperties as CaseOfBoxesProperties;
            if (null == caseOfBoxes) return;
            // elemCaseOfBoxes
            XmlElement elemCaseOfBoxes = xmlDoc.CreateElement("caseOfBoxes", ns);
            elemPalletAnalysis.AppendChild(elemCaseOfBoxes);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = caseOfBoxes.Name;
            elemCaseOfBoxes.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = caseOfBoxes.Description;
            elemCaseOfBoxes.AppendChild(elemDescription);
            // length
            XmlElement elemNoX = xmlDoc.CreateElement("noX", ns);
            elemNoX.InnerText = string.Format("{0}", caseOfBoxes.CaseDefinition.Arrangement._iLength);
            elemCaseOfBoxes.AppendChild(elemNoX);
            // width
            XmlElement elemNoY = xmlDoc.CreateElement("noY", ns);
            elemNoY.InnerText = string.Format("{0}", caseOfBoxes.CaseDefinition.Arrangement._iWidth);
            elemCaseOfBoxes.AppendChild(elemNoY);
            // height
            XmlElement elemNoZ = xmlDoc.CreateElement("noZ", ns);
            elemNoZ.InnerText = string.Format("{0}", caseOfBoxes.CaseDefinition.Arrangement._iHeight);
            elemCaseOfBoxes.AppendChild(elemNoZ);
            // number of boxes
            XmlElement elemNoBoxes = xmlDoc.CreateElement("numberOfBoxes", ns);
            elemNoBoxes.InnerText = string.Format("{0}", caseOfBoxes.NumberOfBoxes);
            elemCaseOfBoxes.AppendChild(elemNoBoxes);
            // dim0
            XmlElement eltDim0 = xmlDoc.CreateElement("dim0", ns);
            eltDim0.InnerText = string.Format("{0}", caseOfBoxes.CaseDefinition.Dim0);
            elemCaseOfBoxes.AppendChild(eltDim0);
            // dim1
            XmlElement eltDim1 = xmlDoc.CreateElement("dim1", ns);
            eltDim1.InnerText = string.Format("{0}", caseOfBoxes.CaseDefinition.Dim1);
            elemCaseOfBoxes.AppendChild(eltDim1);
            // inner length
            XmlElement eltInnerLength = xmlDoc.CreateElement("innerLength", ns);
            eltInnerLength.InnerText = string.Format("{0}", caseOfBoxes.InsideLength);
            elemCaseOfBoxes.AppendChild(eltInnerLength);
            // inner width
            XmlElement eltInnerWidth = xmlDoc.CreateElement("innerWidth", ns);
            eltInnerWidth.InnerText = string.Format("{0}", caseOfBoxes.InsideWidth);
            elemCaseOfBoxes.AppendChild(eltInnerWidth);
            // inner height
            XmlElement eltInnerHeight = xmlDoc.CreateElement("innerHeight", ns);
            eltInnerHeight.InnerText = string.Format("{0}", caseOfBoxes.InsideHeight);
            elemCaseOfBoxes.AppendChild(eltInnerHeight);
            // inner volume
            XmlElement eltInnerVolume = xmlDoc.CreateElement("innerVolume", ns);
            eltInnerVolume.InnerText = string.Format("{0:F}", caseOfBoxes.InsideVolume * 1.0E-06);
            elemCaseOfBoxes.AppendChild(eltInnerVolume);
            // outer length
            XmlElement eltOuterLength = xmlDoc.CreateElement("outerLength", ns);
            eltOuterLength.InnerText = string.Format("{0:F}", caseOfBoxes.Length);
            elemCaseOfBoxes.AppendChild(eltOuterLength);
            // outer width
            XmlElement eltOuterWidth = xmlDoc.CreateElement("outerWidth", ns);
            eltOuterWidth.InnerText = string.Format("{0:F}", caseOfBoxes.Width);
            elemCaseOfBoxes.AppendChild(eltOuterWidth);
            // outer height
            XmlElement eltOuterHeight = xmlDoc.CreateElement("outerHeight", ns);
            eltOuterHeight.InnerText = string.Format("{0:F}", caseOfBoxes.Height);
            elemCaseOfBoxes.AppendChild(eltOuterHeight);
            // outer volume
            XmlElement eltOuterVolume = xmlDoc.CreateElement("outerVolume", ns);
            eltOuterVolume.InnerText = string.Format("{0:F}", caseOfBoxes.Volume * 1.0E-06);
            elemCaseOfBoxes.AppendChild(eltOuterVolume);
            // empty weight
            XmlElement eltEmptyWeight = xmlDoc.CreateElement("emptyWeight", ns);
            eltEmptyWeight.InnerText = string.Format("{0:F}", caseOfBoxes.Weight);
            elemCaseOfBoxes.AppendChild(eltEmptyWeight);
            // weight
            XmlElement eltWeight = xmlDoc.CreateElement("weight", ns);
            eltWeight.InnerText = string.Format("{0:F}", caseOfBoxes.Weight);
            elemCaseOfBoxes.AppendChild(eltWeight);
            // type converter
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            // view case of boxes iso1
            Graphics3DImage graphics1 = new Graphics3DImage(new Size(256, 256));
            graphics1.CameraPosition = Graphics3D.Corner_0;
            CaseDefinitionViewer viewer = new CaseDefinitionViewer(caseOfBoxes.CaseDefinition, caseOfBoxes.InsideBoxProperties, caseOfBoxes.CaseOptimConstraintSet);
            viewer.CaseProperties = caseOfBoxes;
            viewer.Orientation = sol.FirstCaseOrientation;
            viewer.Draw(graphics1);
            graphics1.Flush();
            // view case of boxes iso2
            Graphics3DImage graphics2 = new Graphics3DImage(new Size(256, 256));
            graphics2.CameraPosition = Graphics3D.Corner_0;
            Box box = new Box(0, caseOfBoxes);
            graphics2.AddBox(box);
            graphics2.AddDimensions(new DimensionCube(caseOfBoxes.Length, caseOfBoxes.Width, caseOfBoxes.Height));
            graphics2.Flush();
            // view_caseOfBoxes_iso1
            XmlElement elemImage1 = xmlDoc.CreateElement("view_caseOfBoxes_iso1", ns);
            elemImage1.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics1.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute1 = xmlDoc.CreateAttribute("style");
            styleAttribute1.Value = string.Format("width:{0}pt;height:{1}pt", graphics1.Bitmap.Width / 3, graphics1.Bitmap.Height / 3);
            elemImage1.Attributes.Append(styleAttribute1);
            elemCaseOfBoxes.AppendChild(elemImage1);
            // view_caseOfBoxes_iso2
            XmlElement elemImage2 = xmlDoc.CreateElement("view_caseOfBoxes_iso2", ns);
            elemImage2.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics2.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute2 = xmlDoc.CreateAttribute("style");
            styleAttribute2.Value = string.Format("width:{0}pt;height:{1}pt", graphics2.Bitmap.Width / 3, graphics2.Bitmap.Height / 3);
            elemImage2.Attributes.Append(styleAttribute2);
            elemCaseOfBoxes.AppendChild(elemImage2);
        }

        private static void AppendInterlayerElement(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get BoxProperties
            InterlayerProperties interlayerProp = analysis.InterlayerProperties;
            if (null == interlayerProp) return;
            // interlayer
            XmlElement elemInterlayer = xmlDoc.CreateElement("interlayer", ns);
            elemPalletAnalysis.AppendChild(elemInterlayer);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = interlayerProp.Name;
            elemInterlayer.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = interlayerProp.Description;
            elemInterlayer.AppendChild(elemDescription);
            // length
            XmlElement elemLength = xmlDoc.CreateElement("length", ns);
            elemLength.InnerText = string.Format("{0:F}", interlayerProp.Length);
            elemInterlayer.AppendChild(elemLength);
            // width
            XmlElement elemWidth = xmlDoc.CreateElement("width", ns);
            elemWidth.InnerText = string.Format("{0:F}", interlayerProp.Width);
            elemInterlayer.AppendChild(elemWidth);
            // height
            XmlElement elemThickness = xmlDoc.CreateElement("thickness", ns);
            elemThickness.InnerText = string.Format("{0:F}", interlayerProp.Thickness);
            elemInterlayer.AppendChild(elemThickness);
            // weight
            XmlElement elemWeight = xmlDoc.CreateElement("weight", ns);
            elemWeight.InnerText = string.Format("{0:F}", interlayerProp.Weight);
            elemInterlayer.AppendChild(elemWeight);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Corner_0;
            Box box = new Box(0, interlayerProp);
            graphics.AddBox(box);
            graphics.Flush();
            // ---
            // view_interlayer_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_interlayer_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemInterlayer.AppendChild(elemImage);
        }

        private static void AppendSolutionElement(PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;

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
            elemEfficiency.InnerText = string.Format("{0:F}", sol.Efficiency);
            elemSolution.AppendChild(elemEfficiency);
            // palletWeight
            XmlElement elemPalletWeight = xmlDoc.CreateElement("palletWeight", ns);
            elemPalletWeight.InnerText = string.Format("{0:F}", sol.PalletWeight);
            elemSolution.AppendChild(elemPalletWeight);
            // palletHeight
            XmlElement elemPalletHeight = xmlDoc.CreateElement("palletHeight", ns);
            elemPalletHeight.InnerText = string.Format("{0:F}", sol.PalletHeight);
            elemSolution.AppendChild(elemPalletHeight);
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
                elemBoxEfficiency.InnerText = string.Format("{0:F}", sol.Efficiency);
            }
            // interlayer count
            if (sol.Analysis.ConstraintSet.HasInterlayer)
            {
                XmlElement elemInterlayerCount = xmlDoc.CreateElement("interlayerCount", ns);
                elemInterlayerCount.InnerText = string.Format("{0}", sol.InterlayerCount);
                elemSolution.AppendChild(elemInterlayerCount);
            }
            // --- layer images
            for (int i = 0; i < (sol.HasHomogeneousLayers ? 1 : 2); ++i)
            {
                XmlElement elemLayer = xmlDoc.CreateElement("layer", ns);
                // layerId
                XmlElement xmlLayerId = xmlDoc.CreateElement("layerId", ns);
                xmlLayerId.InnerText = string.Format("{0}", i + 1);
                elemLayer.AppendChild(xmlLayerId);

                // --- build layer image
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
                // set camera position 
                graphics.CameraPosition = Graphics3D.Top;
                // instantiate solution viewer
                SolutionViewer sv = new SolutionViewer(sol);
                sv.DrawLayers(graphics, true, i /* layer index*/);
                // ---
                // layerImage
                XmlElement elemLayerImage = xmlDoc.CreateElement("layerImage", ns);
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                elemLayerImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
                XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
                styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 2, graphics.Bitmap.Height / 2);
                elemLayerImage.Attributes.Append(styleAttribute);
                elemLayer.AppendChild(elemLayerImage);
                // layerBoxCount
                XmlElement elemLayerBoxCount = xmlDoc.CreateElement("layerCaseCount", ns);
                elemLayerBoxCount.InnerText = "0";
                elemLayer.AppendChild(elemLayerBoxCount);

                elemSolution.AppendChild(elemLayer);
            }
            // --- pallet images
            for (int i = 0; i < 5; ++i)
            {
                // initialize drawing values
                string viewName = string.Empty;
                Vector3D cameraPos = Vector3D.Zero;
                int imageWidth = 256;
                bool showDimensions = false;
                switch (i)
                {
                    case 0:
                        viewName = "view_palletsolution_front"; cameraPos = Graphics3D.Front; imageWidth = 256;
                        break;
                    case 1:
                        viewName = "view_palletsolution_left"; cameraPos = Graphics3D.Left; imageWidth = 256;
                        break;
                    case 2:
                        viewName = "view_palletsolution_right"; cameraPos = Graphics3D.Right; imageWidth = 256;
                        break;
                    case 3:
                        viewName = "view_palletsolution_back"; cameraPos = Graphics3D.Back; imageWidth = 256;
                        break;
                    case 4:
                        viewName = "view_palletsolution_iso"; cameraPos = Graphics3D.Corner_0; imageWidth = 768; showDimensions = true;
                        break;
                    default:
                        break;
                }
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(imageWidth, imageWidth));
                // set camera position 
                graphics.CameraPosition = cameraPos;
                // instantiate solution viewer
                SolutionViewer sv = new SolutionViewer(sol);
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
            }
        }
        private static void AppendTruckAnalysisElement(PalletAnalysis analysis, SelSolution selSolution, XmlElement elemDocument, XmlDocument xmlDoc)
        {
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
            AppendTruckSolutionElement(truckAnalysis, elemTruckAnalysis, xmlDoc);
        }

        private static void AppendTruckElement(TruckAnalysis truckAnalysis, XmlElement elemTruckAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get PalletProperties
            TruckProperties truckProp = truckAnalysis.TruckProperties;
            if (null == truckProp) return;
            // create "truck" element
            XmlElement elemTruck = xmlDoc.CreateElement("truck", ns);
            elemTruckAnalysis.AppendChild(elemTruck);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = truckProp.Name;
            elemTruck.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = truckProp.Description;
            elemTruck.AppendChild(elemDescription);
            // length
            XmlElement elemLength = xmlDoc.CreateElement("length", ns);
            elemLength.InnerText = string.Format("{0:F}", truckProp.Length);
            elemTruck.AppendChild(elemLength);
            // width
            XmlElement elemWidth = xmlDoc.CreateElement("width", ns);
            elemWidth.InnerText = string.Format("{0:F}", truckProp.Width);
            elemTruck.AppendChild(elemWidth);
            // height
            XmlElement elemHeight = xmlDoc.CreateElement("height", ns);
            elemHeight.InnerText = string.Format("{0:F}", truckProp.Height);
            elemTruck.AppendChild(elemHeight);
            // admissibleLoad
            XmlElement elemWeight = xmlDoc.CreateElement("admissibleLoad", ns);
            elemWeight.InnerText = string.Format("{0:F}", truckProp.AdmissibleLoadWeight);
            elemTruck.AppendChild(elemWeight);

            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Corner_0;
            Truck truck = new Truck(truckProp);
            truck.DrawBegin(graphics);
            truck.DrawEnd(graphics);
            graphics.AddDimensions(new DimensionCube(truckProp.Length, truckProp.Width, truckProp.Height));
            graphics.Flush();
            // ---
            // view_truck_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_truck_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemTruck.AppendChild(elemImage);
        }
        private static void AppendTruckSolutionElement(TruckAnalysis truckAnalysis, XmlElement elemTruckAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // retrieve selected truckSolution
            TruckSolution truckSolution = truckAnalysis.SelectedSolution;
            if (null == truckSolution) return;
            // create "truckSolution" element
            XmlElement elemTruckSolution = xmlDoc.CreateElement("truckSolution", ns);
            elemTruckAnalysis.AppendChild(elemTruckSolution);
            // title
            XmlElement elemTitle = xmlDoc.CreateElement("title", ns);
            elemTitle.InnerText = truckSolution.Title;
            elemTruckSolution.AppendChild(elemTitle);
            // palletCount
            XmlElement elemPalletCount = xmlDoc.CreateElement("palletCount", ns);
            elemPalletCount.InnerText = string.Format("{0}", truckSolution.PalletCount);
            elemTruckSolution.AppendChild(elemPalletCount);
            // boxCount
            XmlElement elemBoxCount = xmlDoc.CreateElement("caseCount", ns);
            elemBoxCount.InnerText = string.Format("{0}", truckSolution.BoxCount);
            elemTruckSolution.AppendChild(elemBoxCount);
            // loadWeight
            XmlElement elemLoadWeight = xmlDoc.CreateElement("loadWeight", ns);
            elemLoadWeight.InnerText = string.Format("{0:F}", truckSolution.LoadWeight);
            elemTruckSolution.AppendChild(elemLoadWeight);
            // loadEfficiency
            XmlElement elemLoadEfficiency = xmlDoc.CreateElement("loadEfficiency", ns);
            elemLoadEfficiency.InnerText = string.Format("{0:F}", 100.0 * truckSolution.LoadWeight / truckAnalysis.TruckProperties.AdmissibleLoadWeight);
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
                int imageWidth = 768;
                switch (i)
                {
                    case 0: viewName = "view_trucksolution_top"; cameraPos = Graphics3D.Top; imageWidth = 768; break;
                    case 1: viewName = "view_trucksolution_iso"; cameraPos = Graphics3D.Corner_0; imageWidth = 768; break;
                    default: break;
                }
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(imageWidth, imageWidth));
                // set camera position 
                graphics.CameraPosition = cameraPos;
                // instantiate solution viewer
                TruckSolutionViewer sv = new TruckSolutionViewer(truckSolution);
                sv.Draw(graphics);
                // ---
                XmlElement elemImage = xmlDoc.CreateElement(viewName, ns);
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
                XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
                styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 3, graphics.Bitmap.Height / 3);
                elemImage.Attributes.Append(styleAttribute);
                elemTruckSolution.AppendChild(elemImage);
            }
        }
        #endregion
    }
}
