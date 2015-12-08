using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using M = DocumentFormat.OpenXml.Math;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using V = DocumentFormat.OpenXml.Vml;
using A = DocumentFormat.OpenXml.Drawing;

namespace Abakon15.Reports
{
    public class GeneratedDocument
    {
        // Creates a WordprocessingDocument.
        public static WordprocessingDocument CreatePackage(string filePath)
        {

            WordprocessingDocument package = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);

            CreateParts(package);
            return package;

        }

        // Adds child parts and generates content of the specified part.
        private static void CreateParts(WordprocessingDocument document)
        {
            ExtendedFilePropertiesPart extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId3");
            GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);

            MainDocumentPart mainDocumentPart1 = document.AddMainDocumentPart();
            GenerateMainDocumentPart1Content(mainDocumentPart1);

            DocumentSettingsPart documentSettingsPart1 = mainDocumentPart1.AddNewPart<DocumentSettingsPart>("rId3");
            GenerateDocumentSettingsPart1Content(documentSettingsPart1);

            StylesWithEffectsPart stylesWithEffectsPart1 = mainDocumentPart1.AddNewPart<StylesWithEffectsPart>("rId2");
            GenerateStylesWithEffectsPart1Content(stylesWithEffectsPart1);

            StyleDefinitionsPart styleDefinitionsPart1 = mainDocumentPart1.AddNewPart<StyleDefinitionsPart>("rId1");
            GenerateStyleDefinitionsPart1Content(styleDefinitionsPart1);

            ThemePart themePart1 = mainDocumentPart1.AddNewPart<ThemePart>("rId6");
            GenerateThemePart1Content(themePart1);

            FontTablePart fontTablePart1 = mainDocumentPart1.AddNewPart<FontTablePart>("rId5");
            GenerateFontTablePart1Content(fontTablePart1);

            WebSettingsPart webSettingsPart1 = mainDocumentPart1.AddNewPart<WebSettingsPart>("rId4");
            GenerateWebSettingsPart1Content(webSettingsPart1);

            SetPackageProperties(document);
        }

        // Generates content of extendedFilePropertiesPart1.
        private static void GenerateExtendedFilePropertiesPart1Content(ExtendedFilePropertiesPart extendedFilePropertiesPart1)
        {
            Ap.Properties properties1 = new Ap.Properties();
            properties1.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
            Ap.Template template1 = new Ap.Template();
            template1.Text = "Normal.dotm";
            Ap.TotalTime totalTime1 = new Ap.TotalTime();
            totalTime1.Text = "0";
            Ap.Pages pages1 = new Ap.Pages();
            pages1.Text = "1";
            Ap.Words words1 = new Ap.Words();
            words1.Text = "2";
            Ap.Characters characters1 = new Ap.Characters();
            characters1.Text = "13";
            Ap.Application application1 = new Ap.Application();
            application1.Text = "Microsoft Office Word";
            Ap.DocumentSecurity documentSecurity1 = new Ap.DocumentSecurity();
            documentSecurity1.Text = "0";
            Ap.Lines lines1 = new Ap.Lines();
            lines1.Text = "1";
            Ap.Paragraphs paragraphs1 = new Ap.Paragraphs();
            paragraphs1.Text = "1";
            Ap.ScaleCrop scaleCrop1 = new Ap.ScaleCrop();
            scaleCrop1.Text = "false";
            Ap.Company company1 = new Ap.Company();
            company1.Text = "";
            Ap.LinksUpToDate linksUpToDate1 = new Ap.LinksUpToDate();
            linksUpToDate1.Text = "false";
            Ap.CharactersWithSpaces charactersWithSpaces1 = new Ap.CharactersWithSpaces();
            charactersWithSpaces1.Text = "14";
            Ap.SharedDocument sharedDocument1 = new Ap.SharedDocument();
            sharedDocument1.Text = "false";
            Ap.HyperlinksChanged hyperlinksChanged1 = new Ap.HyperlinksChanged();
            hyperlinksChanged1.Text = "false";
            Ap.ApplicationVersion applicationVersion1 = new Ap.ApplicationVersion();
            applicationVersion1.Text = "14.0000";

            properties1.Append(template1);
            properties1.Append(totalTime1);
            properties1.Append(pages1);
            properties1.Append(words1);
            properties1.Append(characters1);
            properties1.Append(application1);
            properties1.Append(documentSecurity1);
            properties1.Append(lines1);
            properties1.Append(paragraphs1);
            properties1.Append(scaleCrop1);
            properties1.Append(company1);
            properties1.Append(linksUpToDate1);
            properties1.Append(charactersWithSpaces1);
            properties1.Append(sharedDocument1);
            properties1.Append(hyperlinksChanged1);
            properties1.Append(applicationVersion1);

            extendedFilePropertiesPart1.Properties = properties1;
        }

        // Generates content of mainDocumentPart1.
        private static void GenerateMainDocumentPart1Content(MainDocumentPart mainDocumentPart1)
        {
            Document document1 = new Document() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            document1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            document1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            document1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            document1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            document1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            document1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            document1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            document1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            document1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            document1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            document1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            document1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            document1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            Body body1 = new Body();

            document1.Append(body1);

            mainDocumentPart1.Document = document1;
        }

        // Generates content of documentSettingsPart1.
        private static void GenerateDocumentSettingsPart1Content(DocumentSettingsPart documentSettingsPart1)
        {
            DocumentFormat.OpenXml.Wordprocessing.Settings settings1 = new DocumentFormat.OpenXml.Wordprocessing.Settings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
            settings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            settings1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            settings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            settings1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            settings1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            settings1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            settings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            settings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            settings1.AddNamespaceDeclaration("sl", "http://schemas.openxmlformats.org/schemaLibrary/2006/main");
            Zoom zoom1 = new Zoom() { Val = PresetZoomValues.BestFit, Percent = "199" };
            DefaultTabStop defaultTabStop1 = new DefaultTabStop() { Val = 708 };
            HyphenationZone hyphenationZone1 = new HyphenationZone() { Val = "425" };
            CharacterSpacingControl characterSpacingControl1 = new CharacterSpacingControl() { Val = CharacterSpacingValues.DoNotCompress };

            Compatibility compatibility1 = new Compatibility();
            CompatibilitySetting compatibilitySetting1 = new CompatibilitySetting() { Name = CompatSettingNameValues.CompatibilityMode, Uri = "http://schemas.microsoft.com/office/word", Val = "14" };
            CompatibilitySetting compatibilitySetting2 = new CompatibilitySetting() { Name = CompatSettingNameValues.OverrideTableStyleFontSizeAndJustification, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
            CompatibilitySetting compatibilitySetting3 = new CompatibilitySetting() { Name = CompatSettingNameValues.EnableOpenTypeFeatures, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
            CompatibilitySetting compatibilitySetting4 = new CompatibilitySetting() { Name = CompatSettingNameValues.DoNotFlipMirrorIndents, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };

            compatibility1.Append(compatibilitySetting1);
            compatibility1.Append(compatibilitySetting2);
            compatibility1.Append(compatibilitySetting3);
            compatibility1.Append(compatibilitySetting4);

            Rsids rsids1 = new Rsids();
            RsidRoot rsidRoot1 = new RsidRoot() { Val = "00474AA4" };
            Rsid rsid1 = new Rsid() { Val = "000044D3" };
            Rsid rsid2 = new Rsid() { Val = "0001417F" };
            Rsid rsid3 = new Rsid() { Val = "00085CAD" };
            Rsid rsid4 = new Rsid() { Val = "001066A2" };
            Rsid rsid5 = new Rsid() { Val = "00283876" };
            Rsid rsid6 = new Rsid() { Val = "003A75F2" };
            Rsid rsid7 = new Rsid() { Val = "00474AA4" };
            Rsid rsid8 = new Rsid() { Val = "005C7FDE" };
            Rsid rsid9 = new Rsid() { Val = "006D3B18" };
            Rsid rsid10 = new Rsid() { Val = "00B0602C" };
            Rsid rsid11 = new Rsid() { Val = "00FC7B9B" };

            rsids1.Append(rsidRoot1);
            rsids1.Append(rsid1);
            rsids1.Append(rsid2);
            rsids1.Append(rsid3);
            rsids1.Append(rsid4);
            rsids1.Append(rsid5);
            rsids1.Append(rsid6);
            rsids1.Append(rsid7);
            rsids1.Append(rsid8);
            rsids1.Append(rsid9);
            rsids1.Append(rsid10);
            rsids1.Append(rsid11);

            M.MathProperties mathProperties1 = new M.MathProperties();
            M.MathFont mathFont1 = new M.MathFont() { Val = "Cambria Math" };
            M.BreakBinary breakBinary1 = new M.BreakBinary() { Val = M.BreakBinaryOperatorValues.Before };
            M.BreakBinarySubtraction breakBinarySubtraction1 = new M.BreakBinarySubtraction() { Val = M.BreakBinarySubtractionValues.MinusMinus };
            M.SmallFraction smallFraction1 = new M.SmallFraction() { Val = M.BooleanValues.Zero };
            M.DisplayDefaults displayDefaults1 = new M.DisplayDefaults();
            M.LeftMargin leftMargin1 = new M.LeftMargin() { Val = (UInt32Value)0U };
            M.RightMargin rightMargin1 = new M.RightMargin() { Val = (UInt32Value)0U };
            M.DefaultJustification defaultJustification1 = new M.DefaultJustification() { Val = M.JustificationValues.CenterGroup };
            M.WrapIndent wrapIndent1 = new M.WrapIndent() { Val = (UInt32Value)1440U };
            M.IntegralLimitLocation integralLimitLocation1 = new M.IntegralLimitLocation() { Val = M.LimitLocationValues.SubscriptSuperscript };
            M.NaryLimitLocation naryLimitLocation1 = new M.NaryLimitLocation() { Val = M.LimitLocationValues.UnderOver };

            mathProperties1.Append(mathFont1);
            mathProperties1.Append(breakBinary1);
            mathProperties1.Append(breakBinarySubtraction1);
            mathProperties1.Append(smallFraction1);
            mathProperties1.Append(displayDefaults1);
            mathProperties1.Append(leftMargin1);
            mathProperties1.Append(rightMargin1);
            mathProperties1.Append(defaultJustification1);
            mathProperties1.Append(wrapIndent1);
            mathProperties1.Append(integralLimitLocation1);
            mathProperties1.Append(naryLimitLocation1);
            ThemeFontLanguages themeFontLanguages1 = new ThemeFontLanguages() { Val = "pl-PL" };
            ColorSchemeMapping colorSchemeMapping1 = new ColorSchemeMapping() { Background1 = ColorSchemeIndexValues.Light1, Text1 = ColorSchemeIndexValues.Dark1, Background2 = ColorSchemeIndexValues.Light2, Text2 = ColorSchemeIndexValues.Dark2, Accent1 = ColorSchemeIndexValues.Accent1, Accent2 = ColorSchemeIndexValues.Accent2, Accent3 = ColorSchemeIndexValues.Accent3, Accent4 = ColorSchemeIndexValues.Accent4, Accent5 = ColorSchemeIndexValues.Accent5, Accent6 = ColorSchemeIndexValues.Accent6, Hyperlink = ColorSchemeIndexValues.Hyperlink, FollowedHyperlink = ColorSchemeIndexValues.FollowedHyperlink };

            ShapeDefaults shapeDefaults1 = new ShapeDefaults();
            Ovml.ShapeDefaults shapeDefaults2 = new Ovml.ShapeDefaults() { Extension = V.ExtensionHandlingBehaviorValues.Edit, MaxShapeId = 1026 };

            Ovml.ShapeLayout shapeLayout1 = new Ovml.ShapeLayout() { Extension = V.ExtensionHandlingBehaviorValues.Edit };
            Ovml.ShapeIdMap shapeIdMap1 = new Ovml.ShapeIdMap() { Extension = V.ExtensionHandlingBehaviorValues.Edit, Data = "1" };

            shapeLayout1.Append(shapeIdMap1);

            shapeDefaults1.Append(shapeDefaults2);
            shapeDefaults1.Append(shapeLayout1);
            DecimalSymbol decimalSymbol1 = new DecimalSymbol() { Val = "," };
            ListSeparator listSeparator1 = new ListSeparator() { Val = ";" };

            settings1.Append(zoom1);
            settings1.Append(defaultTabStop1);
            settings1.Append(hyphenationZone1);
            settings1.Append(characterSpacingControl1);
            settings1.Append(compatibility1);
            settings1.Append(rsids1);
            settings1.Append(mathProperties1);
            settings1.Append(themeFontLanguages1);
            settings1.Append(colorSchemeMapping1);
            settings1.Append(shapeDefaults1);
            settings1.Append(decimalSymbol1);
            settings1.Append(listSeparator1);

            documentSettingsPart1.Settings = settings1;
        }

        // Generates content of stylesWithEffectsPart1.
        private static void GenerateStylesWithEffectsPart1Content(StylesWithEffectsPart stylesWithEffectsPart1)
        {
            DocumentFormat.OpenXml.Wordprocessing.Styles styles1 = new DocumentFormat.OpenXml.Wordprocessing.Styles() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            styles1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            styles1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            styles1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            styles1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            styles1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            styles1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            styles1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            styles1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            styles1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            styles1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            styles1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            styles1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            styles1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            styles1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            styles1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            DocDefaults docDefaults1 = new DocDefaults();

            RunPropertiesDefault runPropertiesDefault1 = new RunPropertiesDefault();

            RunPropertiesBaseStyle runPropertiesBaseStyle1 = new RunPropertiesBaseStyle();
            RunFonts runFonts1 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi, EastAsiaTheme = ThemeFontValues.MinorHighAnsi, ComplexScriptTheme = ThemeFontValues.MinorBidi };
            FontSize fontSize1 = new FontSize() { Val = "22" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "22" };
            Languages languages1 = new Languages() { Val = "pl-PL", EastAsia = "en-US", Bidi = "ar-SA" };

            runPropertiesBaseStyle1.Append(runFonts1);
            runPropertiesBaseStyle1.Append(fontSize1);
            runPropertiesBaseStyle1.Append(fontSizeComplexScript1);
            runPropertiesBaseStyle1.Append(languages1);

            runPropertiesDefault1.Append(runPropertiesBaseStyle1);

            ParagraphPropertiesDefault paragraphPropertiesDefault1 = new ParagraphPropertiesDefault();

            ParagraphPropertiesBaseStyle paragraphPropertiesBaseStyle1 = new ParagraphPropertiesBaseStyle();
            SpacingBetweenLines spacingBetweenLines1 = new SpacingBetweenLines() { After = "200", Line = "276", LineRule = LineSpacingRuleValues.Auto };

            paragraphPropertiesBaseStyle1.Append(spacingBetweenLines1);

            paragraphPropertiesDefault1.Append(paragraphPropertiesBaseStyle1);

            docDefaults1.Append(runPropertiesDefault1);
            docDefaults1.Append(paragraphPropertiesDefault1);

            LatentStyles latentStyles1 = new LatentStyles() { DefaultLockedState = false, DefaultUiPriority = 99, DefaultSemiHidden = true, DefaultUnhideWhenUsed = true, DefaultPrimaryStyle = false, Count = 267 };
            LatentStyleExceptionInfo latentStyleExceptionInfo1 = new LatentStyleExceptionInfo() { Name = "Normal", UiPriority = 0, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo2 = new LatentStyleExceptionInfo() { Name = "heading 1", UiPriority = 9, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo3 = new LatentStyleExceptionInfo() { Name = "heading 2", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo4 = new LatentStyleExceptionInfo() { Name = "heading 3", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo5 = new LatentStyleExceptionInfo() { Name = "heading 4", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo6 = new LatentStyleExceptionInfo() { Name = "heading 5", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo7 = new LatentStyleExceptionInfo() { Name = "heading 6", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo8 = new LatentStyleExceptionInfo() { Name = "heading 7", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo9 = new LatentStyleExceptionInfo() { Name = "heading 8", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo10 = new LatentStyleExceptionInfo() { Name = "heading 9", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo11 = new LatentStyleExceptionInfo() { Name = "toc 1", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo12 = new LatentStyleExceptionInfo() { Name = "toc 2", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo13 = new LatentStyleExceptionInfo() { Name = "toc 3", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo14 = new LatentStyleExceptionInfo() { Name = "toc 4", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo15 = new LatentStyleExceptionInfo() { Name = "toc 5", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo16 = new LatentStyleExceptionInfo() { Name = "toc 6", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo17 = new LatentStyleExceptionInfo() { Name = "toc 7", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo18 = new LatentStyleExceptionInfo() { Name = "toc 8", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo19 = new LatentStyleExceptionInfo() { Name = "toc 9", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo20 = new LatentStyleExceptionInfo() { Name = "caption", UiPriority = 35, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo21 = new LatentStyleExceptionInfo() { Name = "Title", UiPriority = 10, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo22 = new LatentStyleExceptionInfo() { Name = "Default Paragraph Font", UiPriority = 1 };
            LatentStyleExceptionInfo latentStyleExceptionInfo23 = new LatentStyleExceptionInfo() { Name = "Subtitle", UiPriority = 11, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo24 = new LatentStyleExceptionInfo() { Name = "Strong", UiPriority = 22, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo25 = new LatentStyleExceptionInfo() { Name = "Emphasis", UiPriority = 20, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo26 = new LatentStyleExceptionInfo() { Name = "Table Grid", UiPriority = 59, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo27 = new LatentStyleExceptionInfo() { Name = "Placeholder Text", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo28 = new LatentStyleExceptionInfo() { Name = "No Spacing", UiPriority = 1, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo29 = new LatentStyleExceptionInfo() { Name = "Light Shading", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo30 = new LatentStyleExceptionInfo() { Name = "Light List", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo31 = new LatentStyleExceptionInfo() { Name = "Light Grid", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo32 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo33 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo34 = new LatentStyleExceptionInfo() { Name = "Medium List 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo35 = new LatentStyleExceptionInfo() { Name = "Medium List 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo36 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo37 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo38 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo39 = new LatentStyleExceptionInfo() { Name = "Dark List", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo40 = new LatentStyleExceptionInfo() { Name = "Colorful Shading", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo41 = new LatentStyleExceptionInfo() { Name = "Colorful List", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo42 = new LatentStyleExceptionInfo() { Name = "Colorful Grid", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo43 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 1", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo44 = new LatentStyleExceptionInfo() { Name = "Light List Accent 1", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo45 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 1", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo46 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo47 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 1", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo48 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo49 = new LatentStyleExceptionInfo() { Name = "Revision", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo50 = new LatentStyleExceptionInfo() { Name = "List Paragraph", UiPriority = 34, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo51 = new LatentStyleExceptionInfo() { Name = "Quote", UiPriority = 29, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo52 = new LatentStyleExceptionInfo() { Name = "Intense Quote", UiPriority = 30, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo53 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 1", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo54 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo55 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 1", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo56 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 1", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo57 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 1", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo58 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 1", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo59 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 1", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo60 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 1", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo61 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 2", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo62 = new LatentStyleExceptionInfo() { Name = "Light List Accent 2", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo63 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 2", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo64 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 2", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo65 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo66 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 2", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo67 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo68 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 2", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo69 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo70 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 2", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo71 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 2", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo72 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 2", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo73 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 2", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo74 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 2", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo75 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 3", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo76 = new LatentStyleExceptionInfo() { Name = "Light List Accent 3", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo77 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 3", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo78 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 3", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo79 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 3", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo80 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 3", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo81 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 3", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo82 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 3", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo83 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 3", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo84 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo85 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 3", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo86 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 3", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo87 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 3", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo88 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 3", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo89 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 4", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo90 = new LatentStyleExceptionInfo() { Name = "Light List Accent 4", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo91 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 4", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo92 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 4", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo93 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 4", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo94 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 4", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo95 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 4", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo96 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 4", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo97 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 4", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo98 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 4", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo99 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 4", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo100 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 4", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo101 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 4", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo102 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 4", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo103 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 5", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo104 = new LatentStyleExceptionInfo() { Name = "Light List Accent 5", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo105 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 5", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo106 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 5", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo107 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 5", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo108 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 5", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo109 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 5", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo110 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 5", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo111 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 5", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo112 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 5", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo113 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 5", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo114 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 5", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo115 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 5", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo116 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 5", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo117 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 6", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo118 = new LatentStyleExceptionInfo() { Name = "Light List Accent 6", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo119 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 6", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo120 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 6", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo121 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 6", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo122 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 6", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo123 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 6", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo124 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 6", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo125 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 6", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo126 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 6", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo127 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 6", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo128 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 6", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo129 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 6", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo130 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 6", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo131 = new LatentStyleExceptionInfo() { Name = "Subtle Emphasis", UiPriority = 19, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo132 = new LatentStyleExceptionInfo() { Name = "Intense Emphasis", UiPriority = 21, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo133 = new LatentStyleExceptionInfo() { Name = "Subtle Reference", UiPriority = 31, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo134 = new LatentStyleExceptionInfo() { Name = "Intense Reference", UiPriority = 32, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo135 = new LatentStyleExceptionInfo() { Name = "Book Title", UiPriority = 33, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo136 = new LatentStyleExceptionInfo() { Name = "Bibliography", UiPriority = 37 };
            LatentStyleExceptionInfo latentStyleExceptionInfo137 = new LatentStyleExceptionInfo() { Name = "TOC Heading", UiPriority = 39, PrimaryStyle = true };

            latentStyles1.Append(latentStyleExceptionInfo1);
            latentStyles1.Append(latentStyleExceptionInfo2);
            latentStyles1.Append(latentStyleExceptionInfo3);
            latentStyles1.Append(latentStyleExceptionInfo4);
            latentStyles1.Append(latentStyleExceptionInfo5);
            latentStyles1.Append(latentStyleExceptionInfo6);
            latentStyles1.Append(latentStyleExceptionInfo7);
            latentStyles1.Append(latentStyleExceptionInfo8);
            latentStyles1.Append(latentStyleExceptionInfo9);
            latentStyles1.Append(latentStyleExceptionInfo10);
            latentStyles1.Append(latentStyleExceptionInfo11);
            latentStyles1.Append(latentStyleExceptionInfo12);
            latentStyles1.Append(latentStyleExceptionInfo13);
            latentStyles1.Append(latentStyleExceptionInfo14);
            latentStyles1.Append(latentStyleExceptionInfo15);
            latentStyles1.Append(latentStyleExceptionInfo16);
            latentStyles1.Append(latentStyleExceptionInfo17);
            latentStyles1.Append(latentStyleExceptionInfo18);
            latentStyles1.Append(latentStyleExceptionInfo19);
            latentStyles1.Append(latentStyleExceptionInfo20);
            latentStyles1.Append(latentStyleExceptionInfo21);
            latentStyles1.Append(latentStyleExceptionInfo22);
            latentStyles1.Append(latentStyleExceptionInfo23);
            latentStyles1.Append(latentStyleExceptionInfo24);
            latentStyles1.Append(latentStyleExceptionInfo25);
            latentStyles1.Append(latentStyleExceptionInfo26);
            latentStyles1.Append(latentStyleExceptionInfo27);
            latentStyles1.Append(latentStyleExceptionInfo28);
            latentStyles1.Append(latentStyleExceptionInfo29);
            latentStyles1.Append(latentStyleExceptionInfo30);
            latentStyles1.Append(latentStyleExceptionInfo31);
            latentStyles1.Append(latentStyleExceptionInfo32);
            latentStyles1.Append(latentStyleExceptionInfo33);
            latentStyles1.Append(latentStyleExceptionInfo34);
            latentStyles1.Append(latentStyleExceptionInfo35);
            latentStyles1.Append(latentStyleExceptionInfo36);
            latentStyles1.Append(latentStyleExceptionInfo37);
            latentStyles1.Append(latentStyleExceptionInfo38);
            latentStyles1.Append(latentStyleExceptionInfo39);
            latentStyles1.Append(latentStyleExceptionInfo40);
            latentStyles1.Append(latentStyleExceptionInfo41);
            latentStyles1.Append(latentStyleExceptionInfo42);
            latentStyles1.Append(latentStyleExceptionInfo43);
            latentStyles1.Append(latentStyleExceptionInfo44);
            latentStyles1.Append(latentStyleExceptionInfo45);
            latentStyles1.Append(latentStyleExceptionInfo46);
            latentStyles1.Append(latentStyleExceptionInfo47);
            latentStyles1.Append(latentStyleExceptionInfo48);
            latentStyles1.Append(latentStyleExceptionInfo49);
            latentStyles1.Append(latentStyleExceptionInfo50);
            latentStyles1.Append(latentStyleExceptionInfo51);
            latentStyles1.Append(latentStyleExceptionInfo52);
            latentStyles1.Append(latentStyleExceptionInfo53);
            latentStyles1.Append(latentStyleExceptionInfo54);
            latentStyles1.Append(latentStyleExceptionInfo55);
            latentStyles1.Append(latentStyleExceptionInfo56);
            latentStyles1.Append(latentStyleExceptionInfo57);
            latentStyles1.Append(latentStyleExceptionInfo58);
            latentStyles1.Append(latentStyleExceptionInfo59);
            latentStyles1.Append(latentStyleExceptionInfo60);
            latentStyles1.Append(latentStyleExceptionInfo61);
            latentStyles1.Append(latentStyleExceptionInfo62);
            latentStyles1.Append(latentStyleExceptionInfo63);
            latentStyles1.Append(latentStyleExceptionInfo64);
            latentStyles1.Append(latentStyleExceptionInfo65);
            latentStyles1.Append(latentStyleExceptionInfo66);
            latentStyles1.Append(latentStyleExceptionInfo67);
            latentStyles1.Append(latentStyleExceptionInfo68);
            latentStyles1.Append(latentStyleExceptionInfo69);
            latentStyles1.Append(latentStyleExceptionInfo70);
            latentStyles1.Append(latentStyleExceptionInfo71);
            latentStyles1.Append(latentStyleExceptionInfo72);
            latentStyles1.Append(latentStyleExceptionInfo73);
            latentStyles1.Append(latentStyleExceptionInfo74);
            latentStyles1.Append(latentStyleExceptionInfo75);
            latentStyles1.Append(latentStyleExceptionInfo76);
            latentStyles1.Append(latentStyleExceptionInfo77);
            latentStyles1.Append(latentStyleExceptionInfo78);
            latentStyles1.Append(latentStyleExceptionInfo79);
            latentStyles1.Append(latentStyleExceptionInfo80);
            latentStyles1.Append(latentStyleExceptionInfo81);
            latentStyles1.Append(latentStyleExceptionInfo82);
            latentStyles1.Append(latentStyleExceptionInfo83);
            latentStyles1.Append(latentStyleExceptionInfo84);
            latentStyles1.Append(latentStyleExceptionInfo85);
            latentStyles1.Append(latentStyleExceptionInfo86);
            latentStyles1.Append(latentStyleExceptionInfo87);
            latentStyles1.Append(latentStyleExceptionInfo88);
            latentStyles1.Append(latentStyleExceptionInfo89);
            latentStyles1.Append(latentStyleExceptionInfo90);
            latentStyles1.Append(latentStyleExceptionInfo91);
            latentStyles1.Append(latentStyleExceptionInfo92);
            latentStyles1.Append(latentStyleExceptionInfo93);
            latentStyles1.Append(latentStyleExceptionInfo94);
            latentStyles1.Append(latentStyleExceptionInfo95);
            latentStyles1.Append(latentStyleExceptionInfo96);
            latentStyles1.Append(latentStyleExceptionInfo97);
            latentStyles1.Append(latentStyleExceptionInfo98);
            latentStyles1.Append(latentStyleExceptionInfo99);
            latentStyles1.Append(latentStyleExceptionInfo100);
            latentStyles1.Append(latentStyleExceptionInfo101);
            latentStyles1.Append(latentStyleExceptionInfo102);
            latentStyles1.Append(latentStyleExceptionInfo103);
            latentStyles1.Append(latentStyleExceptionInfo104);
            latentStyles1.Append(latentStyleExceptionInfo105);
            latentStyles1.Append(latentStyleExceptionInfo106);
            latentStyles1.Append(latentStyleExceptionInfo107);
            latentStyles1.Append(latentStyleExceptionInfo108);
            latentStyles1.Append(latentStyleExceptionInfo109);
            latentStyles1.Append(latentStyleExceptionInfo110);
            latentStyles1.Append(latentStyleExceptionInfo111);
            latentStyles1.Append(latentStyleExceptionInfo112);
            latentStyles1.Append(latentStyleExceptionInfo113);
            latentStyles1.Append(latentStyleExceptionInfo114);
            latentStyles1.Append(latentStyleExceptionInfo115);
            latentStyles1.Append(latentStyleExceptionInfo116);
            latentStyles1.Append(latentStyleExceptionInfo117);
            latentStyles1.Append(latentStyleExceptionInfo118);
            latentStyles1.Append(latentStyleExceptionInfo119);
            latentStyles1.Append(latentStyleExceptionInfo120);
            latentStyles1.Append(latentStyleExceptionInfo121);
            latentStyles1.Append(latentStyleExceptionInfo122);
            latentStyles1.Append(latentStyleExceptionInfo123);
            latentStyles1.Append(latentStyleExceptionInfo124);
            latentStyles1.Append(latentStyleExceptionInfo125);
            latentStyles1.Append(latentStyleExceptionInfo126);
            latentStyles1.Append(latentStyleExceptionInfo127);
            latentStyles1.Append(latentStyleExceptionInfo128);
            latentStyles1.Append(latentStyleExceptionInfo129);
            latentStyles1.Append(latentStyleExceptionInfo130);
            latentStyles1.Append(latentStyleExceptionInfo131);
            latentStyles1.Append(latentStyleExceptionInfo132);
            latentStyles1.Append(latentStyleExceptionInfo133);
            latentStyles1.Append(latentStyleExceptionInfo134);
            latentStyles1.Append(latentStyleExceptionInfo135);
            latentStyles1.Append(latentStyleExceptionInfo136);
            latentStyles1.Append(latentStyleExceptionInfo137);

            Style style1 = new Style() { Type = StyleValues.Paragraph, StyleId = "Normalny", Default = true };
            StyleName styleName1 = new StyleName() { Val = "Normal" };
            PrimaryStyle primaryStyle1 = new PrimaryStyle();
            Rsid rsid12 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties1 = new StyleRunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman" };

            styleRunProperties1.Append(runFonts2);

            style1.Append(styleName1);
            style1.Append(primaryStyle1);
            style1.Append(rsid12);
            style1.Append(styleRunProperties1);

            Style style2 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek1" };
            StyleName styleName2 = new StyleName() { Val = "heading 1" };
            BasedOn basedOn1 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle1 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle1 = new LinkedStyle() { Val = "Nagwek1Znak" };
            UIPriority uIPriority1 = new UIPriority() { Val = 9 };
            PrimaryStyle primaryStyle2 = new PrimaryStyle();
            Rsid rsid13 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties1 = new StyleParagraphProperties();
            KeepNext keepNext1 = new KeepNext();
            KeepLines keepLines1 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines2 = new SpacingBetweenLines() { Before = "480", After = "0" };
            OutlineLevel outlineLevel1 = new OutlineLevel() { Val = 0 };

            styleParagraphProperties1.Append(keepNext1);
            styleParagraphProperties1.Append(keepLines1);
            styleParagraphProperties1.Append(spacingBetweenLines2);
            styleParagraphProperties1.Append(outlineLevel1);

            StyleRunProperties styleRunProperties2 = new StyleRunProperties();
            RunFonts runFonts3 = new RunFonts() { EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold1 = new Bold();
            BoldComplexScript boldComplexScript1 = new BoldComplexScript();
            FontSize fontSize2 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "28" };

            styleRunProperties2.Append(runFonts3);
            styleRunProperties2.Append(bold1);
            styleRunProperties2.Append(boldComplexScript1);
            styleRunProperties2.Append(fontSize2);
            styleRunProperties2.Append(fontSizeComplexScript2);

            style2.Append(styleName2);
            style2.Append(basedOn1);
            style2.Append(nextParagraphStyle1);
            style2.Append(linkedStyle1);
            style2.Append(uIPriority1);
            style2.Append(primaryStyle2);
            style2.Append(rsid13);
            style2.Append(styleParagraphProperties1);
            style2.Append(styleRunProperties2);

            Style style3 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek2" };
            StyleName styleName3 = new StyleName() { Val = "heading 2" };
            BasedOn basedOn2 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle2 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle2 = new LinkedStyle() { Val = "Nagwek2Znak" };
            UIPriority uIPriority2 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden1 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed1 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle3 = new PrimaryStyle();
            Rsid rsid14 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties2 = new StyleParagraphProperties();
            KeepNext keepNext2 = new KeepNext();
            KeepLines keepLines2 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines3 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel2 = new OutlineLevel() { Val = 1 };

            styleParagraphProperties2.Append(keepNext2);
            styleParagraphProperties2.Append(keepLines2);
            styleParagraphProperties2.Append(spacingBetweenLines3);
            styleParagraphProperties2.Append(outlineLevel2);

            StyleRunProperties styleRunProperties3 = new StyleRunProperties();
            RunFonts runFonts4 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold2 = new Bold();
            BoldComplexScript boldComplexScript2 = new BoldComplexScript();
            Color color1 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            FontSize fontSize3 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "26" };

            styleRunProperties3.Append(runFonts4);
            styleRunProperties3.Append(bold2);
            styleRunProperties3.Append(boldComplexScript2);
            styleRunProperties3.Append(color1);
            styleRunProperties3.Append(fontSize3);
            styleRunProperties3.Append(fontSizeComplexScript3);

            style3.Append(styleName3);
            style3.Append(basedOn2);
            style3.Append(nextParagraphStyle2);
            style3.Append(linkedStyle2);
            style3.Append(uIPriority2);
            style3.Append(semiHidden1);
            style3.Append(unhideWhenUsed1);
            style3.Append(primaryStyle3);
            style3.Append(rsid14);
            style3.Append(styleParagraphProperties2);
            style3.Append(styleRunProperties3);

            Style style4 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek3" };
            StyleName styleName4 = new StyleName() { Val = "heading 3" };
            BasedOn basedOn3 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle3 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle3 = new LinkedStyle() { Val = "Nagwek3Znak" };
            UIPriority uIPriority3 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden2 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed2 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle4 = new PrimaryStyle();
            Rsid rsid15 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties3 = new StyleParagraphProperties();
            KeepNext keepNext3 = new KeepNext();
            KeepLines keepLines3 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines4 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel3 = new OutlineLevel() { Val = 2 };

            styleParagraphProperties3.Append(keepNext3);
            styleParagraphProperties3.Append(keepLines3);
            styleParagraphProperties3.Append(spacingBetweenLines4);
            styleParagraphProperties3.Append(outlineLevel3);

            StyleRunProperties styleRunProperties4 = new StyleRunProperties();
            RunFonts runFonts5 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold3 = new Bold();
            BoldComplexScript boldComplexScript3 = new BoldComplexScript();
            Color color2 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties4.Append(runFonts5);
            styleRunProperties4.Append(bold3);
            styleRunProperties4.Append(boldComplexScript3);
            styleRunProperties4.Append(color2);

            style4.Append(styleName4);
            style4.Append(basedOn3);
            style4.Append(nextParagraphStyle3);
            style4.Append(linkedStyle3);
            style4.Append(uIPriority3);
            style4.Append(semiHidden2);
            style4.Append(unhideWhenUsed2);
            style4.Append(primaryStyle4);
            style4.Append(rsid15);
            style4.Append(styleParagraphProperties3);
            style4.Append(styleRunProperties4);

            Style style5 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek4" };
            StyleName styleName5 = new StyleName() { Val = "heading 4" };
            BasedOn basedOn4 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle4 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle4 = new LinkedStyle() { Val = "Nagwek4Znak" };
            UIPriority uIPriority4 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden3 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed3 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle5 = new PrimaryStyle();
            Rsid rsid16 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties4 = new StyleParagraphProperties();
            KeepNext keepNext4 = new KeepNext();
            KeepLines keepLines4 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines5 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel4 = new OutlineLevel() { Val = 3 };

            styleParagraphProperties4.Append(keepNext4);
            styleParagraphProperties4.Append(keepLines4);
            styleParagraphProperties4.Append(spacingBetweenLines5);
            styleParagraphProperties4.Append(outlineLevel4);

            StyleRunProperties styleRunProperties5 = new StyleRunProperties();
            RunFonts runFonts6 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold4 = new Bold();
            BoldComplexScript boldComplexScript4 = new BoldComplexScript();
            Italic italic1 = new Italic();
            ItalicComplexScript italicComplexScript1 = new ItalicComplexScript();
            Color color3 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties5.Append(runFonts6);
            styleRunProperties5.Append(bold4);
            styleRunProperties5.Append(boldComplexScript4);
            styleRunProperties5.Append(italic1);
            styleRunProperties5.Append(italicComplexScript1);
            styleRunProperties5.Append(color3);

            style5.Append(styleName5);
            style5.Append(basedOn4);
            style5.Append(nextParagraphStyle4);
            style5.Append(linkedStyle4);
            style5.Append(uIPriority4);
            style5.Append(semiHidden3);
            style5.Append(unhideWhenUsed3);
            style5.Append(primaryStyle5);
            style5.Append(rsid16);
            style5.Append(styleParagraphProperties4);
            style5.Append(styleRunProperties5);

            Style style6 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek5" };
            StyleName styleName6 = new StyleName() { Val = "heading 5" };
            BasedOn basedOn5 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle5 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle5 = new LinkedStyle() { Val = "Nagwek5Znak" };
            UIPriority uIPriority5 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden4 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed4 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle6 = new PrimaryStyle();
            Rsid rsid17 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties5 = new StyleParagraphProperties();
            KeepNext keepNext5 = new KeepNext();
            KeepLines keepLines5 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines6 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel5 = new OutlineLevel() { Val = 4 };

            styleParagraphProperties5.Append(keepNext5);
            styleParagraphProperties5.Append(keepLines5);
            styleParagraphProperties5.Append(spacingBetweenLines6);
            styleParagraphProperties5.Append(outlineLevel5);

            StyleRunProperties styleRunProperties6 = new StyleRunProperties();
            RunFonts runFonts7 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color4 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties6.Append(runFonts7);
            styleRunProperties6.Append(color4);

            style6.Append(styleName6);
            style6.Append(basedOn5);
            style6.Append(nextParagraphStyle5);
            style6.Append(linkedStyle5);
            style6.Append(uIPriority5);
            style6.Append(semiHidden4);
            style6.Append(unhideWhenUsed4);
            style6.Append(primaryStyle6);
            style6.Append(rsid17);
            style6.Append(styleParagraphProperties5);
            style6.Append(styleRunProperties6);

            Style style7 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek6" };
            StyleName styleName7 = new StyleName() { Val = "heading 6" };
            BasedOn basedOn6 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle6 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle6 = new LinkedStyle() { Val = "Nagwek6Znak" };
            UIPriority uIPriority6 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden5 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed5 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle7 = new PrimaryStyle();
            Rsid rsid18 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties6 = new StyleParagraphProperties();
            KeepNext keepNext6 = new KeepNext();
            KeepLines keepLines6 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines7 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel6 = new OutlineLevel() { Val = 5 };

            styleParagraphProperties6.Append(keepNext6);
            styleParagraphProperties6.Append(keepLines6);
            styleParagraphProperties6.Append(spacingBetweenLines7);
            styleParagraphProperties6.Append(outlineLevel6);

            StyleRunProperties styleRunProperties7 = new StyleRunProperties();
            RunFonts runFonts8 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic2 = new Italic();
            ItalicComplexScript italicComplexScript2 = new ItalicComplexScript();
            Color color5 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties7.Append(runFonts8);
            styleRunProperties7.Append(italic2);
            styleRunProperties7.Append(italicComplexScript2);
            styleRunProperties7.Append(color5);

            style7.Append(styleName7);
            style7.Append(basedOn6);
            style7.Append(nextParagraphStyle6);
            style7.Append(linkedStyle6);
            style7.Append(uIPriority6);
            style7.Append(semiHidden5);
            style7.Append(unhideWhenUsed5);
            style7.Append(primaryStyle7);
            style7.Append(rsid18);
            style7.Append(styleParagraphProperties6);
            style7.Append(styleRunProperties7);

            Style style8 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek7" };
            StyleName styleName8 = new StyleName() { Val = "heading 7" };
            BasedOn basedOn7 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle7 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle7 = new LinkedStyle() { Val = "Nagwek7Znak" };
            UIPriority uIPriority7 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden6 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed6 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle8 = new PrimaryStyle();
            Rsid rsid19 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties7 = new StyleParagraphProperties();
            KeepNext keepNext7 = new KeepNext();
            KeepLines keepLines7 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines8 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel7 = new OutlineLevel() { Val = 6 };

            styleParagraphProperties7.Append(keepNext7);
            styleParagraphProperties7.Append(keepLines7);
            styleParagraphProperties7.Append(spacingBetweenLines8);
            styleParagraphProperties7.Append(outlineLevel7);

            StyleRunProperties styleRunProperties8 = new StyleRunProperties();
            RunFonts runFonts9 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic3 = new Italic();
            ItalicComplexScript italicComplexScript3 = new ItalicComplexScript();
            Color color6 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };

            styleRunProperties8.Append(runFonts9);
            styleRunProperties8.Append(italic3);
            styleRunProperties8.Append(italicComplexScript3);
            styleRunProperties8.Append(color6);

            style8.Append(styleName8);
            style8.Append(basedOn7);
            style8.Append(nextParagraphStyle7);
            style8.Append(linkedStyle7);
            style8.Append(uIPriority7);
            style8.Append(semiHidden6);
            style8.Append(unhideWhenUsed6);
            style8.Append(primaryStyle8);
            style8.Append(rsid19);
            style8.Append(styleParagraphProperties7);
            style8.Append(styleRunProperties8);

            Style style9 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek8" };
            StyleName styleName9 = new StyleName() { Val = "heading 8" };
            BasedOn basedOn8 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle8 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle8 = new LinkedStyle() { Val = "Nagwek8Znak" };
            UIPriority uIPriority8 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden7 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed7 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle9 = new PrimaryStyle();
            Rsid rsid20 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties8 = new StyleParagraphProperties();
            KeepNext keepNext8 = new KeepNext();
            KeepLines keepLines8 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines9 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel8 = new OutlineLevel() { Val = 7 };

            styleParagraphProperties8.Append(keepNext8);
            styleParagraphProperties8.Append(keepLines8);
            styleParagraphProperties8.Append(spacingBetweenLines9);
            styleParagraphProperties8.Append(outlineLevel8);

            StyleRunProperties styleRunProperties9 = new StyleRunProperties();
            RunFonts runFonts10 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color7 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            FontSize fontSize4 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript4 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties9.Append(runFonts10);
            styleRunProperties9.Append(color7);
            styleRunProperties9.Append(fontSize4);
            styleRunProperties9.Append(fontSizeComplexScript4);

            style9.Append(styleName9);
            style9.Append(basedOn8);
            style9.Append(nextParagraphStyle8);
            style9.Append(linkedStyle8);
            style9.Append(uIPriority8);
            style9.Append(semiHidden7);
            style9.Append(unhideWhenUsed7);
            style9.Append(primaryStyle9);
            style9.Append(rsid20);
            style9.Append(styleParagraphProperties8);
            style9.Append(styleRunProperties9);

            Style style10 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek9" };
            StyleName styleName10 = new StyleName() { Val = "heading 9" };
            BasedOn basedOn9 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle9 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle9 = new LinkedStyle() { Val = "Nagwek9Znak" };
            UIPriority uIPriority9 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden8 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed8 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle10 = new PrimaryStyle();
            Rsid rsid21 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties9 = new StyleParagraphProperties();
            KeepNext keepNext9 = new KeepNext();
            KeepLines keepLines9 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines10 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel9 = new OutlineLevel() { Val = 8 };

            styleParagraphProperties9.Append(keepNext9);
            styleParagraphProperties9.Append(keepLines9);
            styleParagraphProperties9.Append(spacingBetweenLines10);
            styleParagraphProperties9.Append(outlineLevel9);

            StyleRunProperties styleRunProperties10 = new StyleRunProperties();
            RunFonts runFonts11 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic4 = new Italic();
            ItalicComplexScript italicComplexScript4 = new ItalicComplexScript();
            Color color8 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };
            FontSize fontSize5 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript5 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties10.Append(runFonts11);
            styleRunProperties10.Append(italic4);
            styleRunProperties10.Append(italicComplexScript4);
            styleRunProperties10.Append(color8);
            styleRunProperties10.Append(fontSize5);
            styleRunProperties10.Append(fontSizeComplexScript5);

            style10.Append(styleName10);
            style10.Append(basedOn9);
            style10.Append(nextParagraphStyle9);
            style10.Append(linkedStyle9);
            style10.Append(uIPriority9);
            style10.Append(semiHidden8);
            style10.Append(unhideWhenUsed8);
            style10.Append(primaryStyle10);
            style10.Append(rsid21);
            style10.Append(styleParagraphProperties9);
            style10.Append(styleRunProperties10);

            Style style11 = new Style() { Type = StyleValues.Character, StyleId = "Domylnaczcionkaakapitu", Default = true };
            StyleName styleName11 = new StyleName() { Val = "Default Paragraph Font" };
            UIPriority uIPriority10 = new UIPriority() { Val = 1 };
            SemiHidden semiHidden9 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed9 = new UnhideWhenUsed();

            style11.Append(styleName11);
            style11.Append(uIPriority10);
            style11.Append(semiHidden9);
            style11.Append(unhideWhenUsed9);

            Style style12 = new Style() { Type = StyleValues.Table, StyleId = "Standardowy", Default = true };
            StyleName styleName12 = new StyleName() { Val = "Normal Table" };
            UIPriority uIPriority11 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden10 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed10 = new UnhideWhenUsed();

            StyleTableProperties styleTableProperties1 = new StyleTableProperties();
            TableIndentation tableIndentation1 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

            TableCellMarginDefault tableCellMarginDefault1 = new TableCellMarginDefault();
            TopMargin topMargin1 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin1 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin1 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

            tableCellMarginDefault1.Append(topMargin1);
            tableCellMarginDefault1.Append(tableCellLeftMargin1);
            tableCellMarginDefault1.Append(bottomMargin1);
            tableCellMarginDefault1.Append(tableCellRightMargin1);

            styleTableProperties1.Append(tableIndentation1);
            styleTableProperties1.Append(tableCellMarginDefault1);

            style12.Append(styleName12);
            style12.Append(uIPriority11);
            style12.Append(semiHidden10);
            style12.Append(unhideWhenUsed10);
            style12.Append(styleTableProperties1);

            Style style13 = new Style() { Type = StyleValues.Numbering, StyleId = "Bezlisty", Default = true };
            StyleName styleName13 = new StyleName() { Val = "No List" };
            UIPriority uIPriority12 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden11 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed11 = new UnhideWhenUsed();

            style13.Append(styleName13);
            style13.Append(uIPriority12);
            style13.Append(semiHidden11);
            style13.Append(unhideWhenUsed11);

            Style style14 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek1Znak", CustomStyle = true };
            StyleName styleName14 = new StyleName() { Val = "Nagłówek 1 Znak" };
            BasedOn basedOn10 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle10 = new LinkedStyle() { Val = "Nagwek1" };
            UIPriority uIPriority13 = new UIPriority() { Val = 9 };
            Rsid rsid22 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties11 = new StyleRunProperties();
            RunFonts runFonts12 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold5 = new Bold();
            BoldComplexScript boldComplexScript5 = new BoldComplexScript();
            FontSize fontSize6 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript6 = new FontSizeComplexScript() { Val = "28" };

            styleRunProperties11.Append(runFonts12);
            styleRunProperties11.Append(bold5);
            styleRunProperties11.Append(boldComplexScript5);
            styleRunProperties11.Append(fontSize6);
            styleRunProperties11.Append(fontSizeComplexScript6);

            style14.Append(styleName14);
            style14.Append(basedOn10);
            style14.Append(linkedStyle10);
            style14.Append(uIPriority13);
            style14.Append(rsid22);
            style14.Append(styleRunProperties11);

            Style style15 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek2Znak", CustomStyle = true };
            StyleName styleName15 = new StyleName() { Val = "Nagłówek 2 Znak" };
            BasedOn basedOn11 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle11 = new LinkedStyle() { Val = "Nagwek2" };
            UIPriority uIPriority14 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden12 = new SemiHidden();
            Rsid rsid23 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties12 = new StyleRunProperties();
            RunFonts runFonts13 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold6 = new Bold();
            BoldComplexScript boldComplexScript6 = new BoldComplexScript();
            Color color9 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            FontSize fontSize7 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript7 = new FontSizeComplexScript() { Val = "26" };

            styleRunProperties12.Append(runFonts13);
            styleRunProperties12.Append(bold6);
            styleRunProperties12.Append(boldComplexScript6);
            styleRunProperties12.Append(color9);
            styleRunProperties12.Append(fontSize7);
            styleRunProperties12.Append(fontSizeComplexScript7);

            style15.Append(styleName15);
            style15.Append(basedOn11);
            style15.Append(linkedStyle11);
            style15.Append(uIPriority14);
            style15.Append(semiHidden12);
            style15.Append(rsid23);
            style15.Append(styleRunProperties12);

            Style style16 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek3Znak", CustomStyle = true };
            StyleName styleName16 = new StyleName() { Val = "Nagłówek 3 Znak" };
            BasedOn basedOn12 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle12 = new LinkedStyle() { Val = "Nagwek3" };
            UIPriority uIPriority15 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden13 = new SemiHidden();
            Rsid rsid24 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties13 = new StyleRunProperties();
            RunFonts runFonts14 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold7 = new Bold();
            BoldComplexScript boldComplexScript7 = new BoldComplexScript();
            Color color10 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties13.Append(runFonts14);
            styleRunProperties13.Append(bold7);
            styleRunProperties13.Append(boldComplexScript7);
            styleRunProperties13.Append(color10);

            style16.Append(styleName16);
            style16.Append(basedOn12);
            style16.Append(linkedStyle12);
            style16.Append(uIPriority15);
            style16.Append(semiHidden13);
            style16.Append(rsid24);
            style16.Append(styleRunProperties13);

            Style style17 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek4Znak", CustomStyle = true };
            StyleName styleName17 = new StyleName() { Val = "Nagłówek 4 Znak" };
            BasedOn basedOn13 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle13 = new LinkedStyle() { Val = "Nagwek4" };
            UIPriority uIPriority16 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden14 = new SemiHidden();
            Rsid rsid25 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties14 = new StyleRunProperties();
            RunFonts runFonts15 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold8 = new Bold();
            BoldComplexScript boldComplexScript8 = new BoldComplexScript();
            Italic italic5 = new Italic();
            ItalicComplexScript italicComplexScript5 = new ItalicComplexScript();
            Color color11 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties14.Append(runFonts15);
            styleRunProperties14.Append(bold8);
            styleRunProperties14.Append(boldComplexScript8);
            styleRunProperties14.Append(italic5);
            styleRunProperties14.Append(italicComplexScript5);
            styleRunProperties14.Append(color11);

            style17.Append(styleName17);
            style17.Append(basedOn13);
            style17.Append(linkedStyle13);
            style17.Append(uIPriority16);
            style17.Append(semiHidden14);
            style17.Append(rsid25);
            style17.Append(styleRunProperties14);

            Style style18 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek5Znak", CustomStyle = true };
            StyleName styleName18 = new StyleName() { Val = "Nagłówek 5 Znak" };
            BasedOn basedOn14 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle14 = new LinkedStyle() { Val = "Nagwek5" };
            UIPriority uIPriority17 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden15 = new SemiHidden();
            Rsid rsid26 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties15 = new StyleRunProperties();
            RunFonts runFonts16 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color12 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties15.Append(runFonts16);
            styleRunProperties15.Append(color12);

            style18.Append(styleName18);
            style18.Append(basedOn14);
            style18.Append(linkedStyle14);
            style18.Append(uIPriority17);
            style18.Append(semiHidden15);
            style18.Append(rsid26);
            style18.Append(styleRunProperties15);

            Style style19 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek6Znak", CustomStyle = true };
            StyleName styleName19 = new StyleName() { Val = "Nagłówek 6 Znak" };
            BasedOn basedOn15 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle15 = new LinkedStyle() { Val = "Nagwek6" };
            UIPriority uIPriority18 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden16 = new SemiHidden();
            Rsid rsid27 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties16 = new StyleRunProperties();
            RunFonts runFonts17 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic6 = new Italic();
            ItalicComplexScript italicComplexScript6 = new ItalicComplexScript();
            Color color13 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties16.Append(runFonts17);
            styleRunProperties16.Append(italic6);
            styleRunProperties16.Append(italicComplexScript6);
            styleRunProperties16.Append(color13);

            style19.Append(styleName19);
            style19.Append(basedOn15);
            style19.Append(linkedStyle15);
            style19.Append(uIPriority18);
            style19.Append(semiHidden16);
            style19.Append(rsid27);
            style19.Append(styleRunProperties16);

            Style style20 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek7Znak", CustomStyle = true };
            StyleName styleName20 = new StyleName() { Val = "Nagłówek 7 Znak" };
            BasedOn basedOn16 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle16 = new LinkedStyle() { Val = "Nagwek7" };
            UIPriority uIPriority19 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden17 = new SemiHidden();
            Rsid rsid28 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties17 = new StyleRunProperties();
            RunFonts runFonts18 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic7 = new Italic();
            ItalicComplexScript italicComplexScript7 = new ItalicComplexScript();
            Color color14 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };

            styleRunProperties17.Append(runFonts18);
            styleRunProperties17.Append(italic7);
            styleRunProperties17.Append(italicComplexScript7);
            styleRunProperties17.Append(color14);

            style20.Append(styleName20);
            style20.Append(basedOn16);
            style20.Append(linkedStyle16);
            style20.Append(uIPriority19);
            style20.Append(semiHidden17);
            style20.Append(rsid28);
            style20.Append(styleRunProperties17);

            Style style21 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek8Znak", CustomStyle = true };
            StyleName styleName21 = new StyleName() { Val = "Nagłówek 8 Znak" };
            BasedOn basedOn17 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle17 = new LinkedStyle() { Val = "Nagwek8" };
            UIPriority uIPriority20 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden18 = new SemiHidden();
            Rsid rsid29 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties18 = new StyleRunProperties();
            RunFonts runFonts19 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color15 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            FontSize fontSize8 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript8 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties18.Append(runFonts19);
            styleRunProperties18.Append(color15);
            styleRunProperties18.Append(fontSize8);
            styleRunProperties18.Append(fontSizeComplexScript8);

            style21.Append(styleName21);
            style21.Append(basedOn17);
            style21.Append(linkedStyle17);
            style21.Append(uIPriority20);
            style21.Append(semiHidden18);
            style21.Append(rsid29);
            style21.Append(styleRunProperties18);

            Style style22 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek9Znak", CustomStyle = true };
            StyleName styleName22 = new StyleName() { Val = "Nagłówek 9 Znak" };
            BasedOn basedOn18 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle18 = new LinkedStyle() { Val = "Nagwek9" };
            UIPriority uIPriority21 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden19 = new SemiHidden();
            Rsid rsid30 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties19 = new StyleRunProperties();
            RunFonts runFonts20 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic8 = new Italic();
            ItalicComplexScript italicComplexScript8 = new ItalicComplexScript();
            Color color16 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };
            FontSize fontSize9 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript9 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties19.Append(runFonts20);
            styleRunProperties19.Append(italic8);
            styleRunProperties19.Append(italicComplexScript8);
            styleRunProperties19.Append(color16);
            styleRunProperties19.Append(fontSize9);
            styleRunProperties19.Append(fontSizeComplexScript9);

            style22.Append(styleName22);
            style22.Append(basedOn18);
            style22.Append(linkedStyle18);
            style22.Append(uIPriority21);
            style22.Append(semiHidden19);
            style22.Append(rsid30);
            style22.Append(styleRunProperties19);

            Style style23 = new Style() { Type = StyleValues.Paragraph, StyleId = "Legenda" };
            StyleName styleName23 = new StyleName() { Val = "caption" };
            BasedOn basedOn19 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle10 = new NextParagraphStyle() { Val = "Normalny" };
            UIPriority uIPriority22 = new UIPriority() { Val = 35 };
            SemiHidden semiHidden20 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed12 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle11 = new PrimaryStyle();
            Rsid rsid31 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties10 = new StyleParagraphProperties();
            SpacingBetweenLines spacingBetweenLines11 = new SpacingBetweenLines() { Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties10.Append(spacingBetweenLines11);

            StyleRunProperties styleRunProperties20 = new StyleRunProperties();
            Bold bold9 = new Bold();
            BoldComplexScript boldComplexScript9 = new BoldComplexScript();
            Color color17 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            FontSize fontSize10 = new FontSize() { Val = "18" };
            FontSizeComplexScript fontSizeComplexScript10 = new FontSizeComplexScript() { Val = "18" };

            styleRunProperties20.Append(bold9);
            styleRunProperties20.Append(boldComplexScript9);
            styleRunProperties20.Append(color17);
            styleRunProperties20.Append(fontSize10);
            styleRunProperties20.Append(fontSizeComplexScript10);

            style23.Append(styleName23);
            style23.Append(basedOn19);
            style23.Append(nextParagraphStyle10);
            style23.Append(uIPriority22);
            style23.Append(semiHidden20);
            style23.Append(unhideWhenUsed12);
            style23.Append(primaryStyle11);
            style23.Append(rsid31);
            style23.Append(styleParagraphProperties10);
            style23.Append(styleRunProperties20);

            Style style24 = new Style() { Type = StyleValues.Paragraph, StyleId = "Tytu" };
            StyleName styleName24 = new StyleName() { Val = "Title" };
            BasedOn basedOn20 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle11 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle19 = new LinkedStyle() { Val = "TytuZnak" };
            UIPriority uIPriority23 = new UIPriority() { Val = 10 };
            PrimaryStyle primaryStyle12 = new PrimaryStyle();
            Rsid rsid32 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties11 = new StyleParagraphProperties();

            ParagraphBorders paragraphBorders1 = new ParagraphBorders();
            BottomBorder bottomBorder1 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", ThemeColor = ThemeColorValues.Text1, Size = (UInt32Value)8U, Space = (UInt32Value)1U };

            paragraphBorders1.Append(bottomBorder1);
            SpacingBetweenLines spacingBetweenLines12 = new SpacingBetweenLines() { After = "300", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            ContextualSpacing contextualSpacing1 = new ContextualSpacing();

            styleParagraphProperties11.Append(paragraphBorders1);
            styleParagraphProperties11.Append(spacingBetweenLines12);
            styleParagraphProperties11.Append(contextualSpacing1);

            StyleRunProperties styleRunProperties21 = new StyleRunProperties();
            RunFonts runFonts21 = new RunFonts() { EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Spacing spacing1 = new Spacing() { Val = 5 };
            Kern kern1 = new Kern() { Val = (UInt32Value)28U };
            FontSize fontSize11 = new FontSize() { Val = "36" };
            FontSizeComplexScript fontSizeComplexScript11 = new FontSizeComplexScript() { Val = "52" };

            styleRunProperties21.Append(runFonts21);
            styleRunProperties21.Append(spacing1);
            styleRunProperties21.Append(kern1);
            styleRunProperties21.Append(fontSize11);
            styleRunProperties21.Append(fontSizeComplexScript11);

            style24.Append(styleName24);
            style24.Append(basedOn20);
            style24.Append(nextParagraphStyle11);
            style24.Append(linkedStyle19);
            style24.Append(uIPriority23);
            style24.Append(primaryStyle12);
            style24.Append(rsid32);
            style24.Append(styleParagraphProperties11);
            style24.Append(styleRunProperties21);

            Style style25 = new Style() { Type = StyleValues.Character, StyleId = "TytuZnak", CustomStyle = true };
            StyleName styleName25 = new StyleName() { Val = "Tytuł Znak" };
            BasedOn basedOn21 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle20 = new LinkedStyle() { Val = "Tytu" };
            UIPriority uIPriority24 = new UIPriority() { Val = 10 };
            Rsid rsid33 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties22 = new StyleRunProperties();
            RunFonts runFonts22 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Spacing spacing2 = new Spacing() { Val = 5 };
            Kern kern2 = new Kern() { Val = (UInt32Value)28U };
            FontSize fontSize12 = new FontSize() { Val = "36" };
            FontSizeComplexScript fontSizeComplexScript12 = new FontSizeComplexScript() { Val = "52" };

            styleRunProperties22.Append(runFonts22);
            styleRunProperties22.Append(spacing2);
            styleRunProperties22.Append(kern2);
            styleRunProperties22.Append(fontSize12);
            styleRunProperties22.Append(fontSizeComplexScript12);

            style25.Append(styleName25);
            style25.Append(basedOn21);
            style25.Append(linkedStyle20);
            style25.Append(uIPriority24);
            style25.Append(rsid33);
            style25.Append(styleRunProperties22);

            Style style26 = new Style() { Type = StyleValues.Paragraph, StyleId = "Podtytu" };
            StyleName styleName26 = new StyleName() { Val = "Subtitle" };
            BasedOn basedOn22 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle12 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle21 = new LinkedStyle() { Val = "PodtytuZnak" };
            UIPriority uIPriority25 = new UIPriority() { Val = 11 };
            PrimaryStyle primaryStyle13 = new PrimaryStyle();
            Rsid rsid34 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties12 = new StyleParagraphProperties();

            NumberingProperties numberingProperties1 = new NumberingProperties();
            NumberingLevelReference numberingLevelReference1 = new NumberingLevelReference() { Val = 1 };

            numberingProperties1.Append(numberingLevelReference1);

            styleParagraphProperties12.Append(numberingProperties1);

            StyleRunProperties styleRunProperties23 = new StyleRunProperties();
            RunFonts runFonts23 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic9 = new Italic();
            ItalicComplexScript italicComplexScript9 = new ItalicComplexScript();
            Color color18 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            Spacing spacing3 = new Spacing() { Val = 15 };
            FontSize fontSize13 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript13 = new FontSizeComplexScript() { Val = "24" };

            styleRunProperties23.Append(runFonts23);
            styleRunProperties23.Append(italic9);
            styleRunProperties23.Append(italicComplexScript9);
            styleRunProperties23.Append(color18);
            styleRunProperties23.Append(spacing3);
            styleRunProperties23.Append(fontSize13);
            styleRunProperties23.Append(fontSizeComplexScript13);

            style26.Append(styleName26);
            style26.Append(basedOn22);
            style26.Append(nextParagraphStyle12);
            style26.Append(linkedStyle21);
            style26.Append(uIPriority25);
            style26.Append(primaryStyle13);
            style26.Append(rsid34);
            style26.Append(styleParagraphProperties12);
            style26.Append(styleRunProperties23);

            Style style27 = new Style() { Type = StyleValues.Character, StyleId = "PodtytuZnak", CustomStyle = true };
            StyleName styleName27 = new StyleName() { Val = "Podtytuł Znak" };
            BasedOn basedOn23 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle22 = new LinkedStyle() { Val = "Podtytu" };
            UIPriority uIPriority26 = new UIPriority() { Val = 11 };
            Rsid rsid35 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties24 = new StyleRunProperties();
            RunFonts runFonts24 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic10 = new Italic();
            ItalicComplexScript italicComplexScript10 = new ItalicComplexScript();
            Color color19 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            Spacing spacing4 = new Spacing() { Val = 15 };
            FontSize fontSize14 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript14 = new FontSizeComplexScript() { Val = "24" };

            styleRunProperties24.Append(runFonts24);
            styleRunProperties24.Append(italic10);
            styleRunProperties24.Append(italicComplexScript10);
            styleRunProperties24.Append(color19);
            styleRunProperties24.Append(spacing4);
            styleRunProperties24.Append(fontSize14);
            styleRunProperties24.Append(fontSizeComplexScript14);

            style27.Append(styleName27);
            style27.Append(basedOn23);
            style27.Append(linkedStyle22);
            style27.Append(uIPriority26);
            style27.Append(rsid35);
            style27.Append(styleRunProperties24);

            Style style28 = new Style() { Type = StyleValues.Character, StyleId = "Pogrubienie" };
            StyleName styleName28 = new StyleName() { Val = "Strong" };
            BasedOn basedOn24 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority27 = new UIPriority() { Val = 22 };
            PrimaryStyle primaryStyle14 = new PrimaryStyle();
            Rsid rsid36 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties25 = new StyleRunProperties();
            Bold bold10 = new Bold();
            BoldComplexScript boldComplexScript10 = new BoldComplexScript();

            styleRunProperties25.Append(bold10);
            styleRunProperties25.Append(boldComplexScript10);

            style28.Append(styleName28);
            style28.Append(basedOn24);
            style28.Append(uIPriority27);
            style28.Append(primaryStyle14);
            style28.Append(rsid36);
            style28.Append(styleRunProperties25);

            Style style29 = new Style() { Type = StyleValues.Character, StyleId = "Uwydatnienie" };
            StyleName styleName29 = new StyleName() { Val = "Emphasis" };
            BasedOn basedOn25 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority28 = new UIPriority() { Val = 20 };
            PrimaryStyle primaryStyle15 = new PrimaryStyle();
            Rsid rsid37 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties26 = new StyleRunProperties();
            Italic italic11 = new Italic();
            ItalicComplexScript italicComplexScript11 = new ItalicComplexScript();

            styleRunProperties26.Append(italic11);
            styleRunProperties26.Append(italicComplexScript11);

            style29.Append(styleName29);
            style29.Append(basedOn25);
            style29.Append(uIPriority28);
            style29.Append(primaryStyle15);
            style29.Append(rsid37);
            style29.Append(styleRunProperties26);

            Style style30 = new Style() { Type = StyleValues.Paragraph, StyleId = "Bezodstpw" };
            StyleName styleName30 = new StyleName() { Val = "No Spacing" };
            LinkedStyle linkedStyle23 = new LinkedStyle() { Val = "BezodstpwZnak" };
            UIPriority uIPriority29 = new UIPriority() { Val = 1 };
            PrimaryStyle primaryStyle16 = new PrimaryStyle();
            Rsid rsid38 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties13 = new StyleParagraphProperties();
            SpacingBetweenLines spacingBetweenLines13 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties13.Append(spacingBetweenLines13);

            style30.Append(styleName30);
            style30.Append(linkedStyle23);
            style30.Append(uIPriority29);
            style30.Append(primaryStyle16);
            style30.Append(rsid38);
            style30.Append(styleParagraphProperties13);

            Style style31 = new Style() { Type = StyleValues.Character, StyleId = "BezodstpwZnak", CustomStyle = true };
            StyleName styleName31 = new StyleName() { Val = "Bez odstępów Znak" };
            BasedOn basedOn26 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle24 = new LinkedStyle() { Val = "Bezodstpw" };
            UIPriority uIPriority30 = new UIPriority() { Val = 1 };
            Rsid rsid39 = new Rsid() { Val = "0001417F" };

            style31.Append(styleName31);
            style31.Append(basedOn26);
            style31.Append(linkedStyle24);
            style31.Append(uIPriority30);
            style31.Append(rsid39);

            Style style32 = new Style() { Type = StyleValues.Paragraph, StyleId = "Akapitzlist" };
            StyleName styleName32 = new StyleName() { Val = "List Paragraph" };
            BasedOn basedOn27 = new BasedOn() { Val = "Normalny" };
            UIPriority uIPriority31 = new UIPriority() { Val = 34 };
            PrimaryStyle primaryStyle17 = new PrimaryStyle();
            Rsid rsid40 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties14 = new StyleParagraphProperties();
            Indentation indentation1 = new Indentation() { Left = "720" };
            ContextualSpacing contextualSpacing2 = new ContextualSpacing();

            styleParagraphProperties14.Append(indentation1);
            styleParagraphProperties14.Append(contextualSpacing2);

            style32.Append(styleName32);
            style32.Append(basedOn27);
            style32.Append(uIPriority31);
            style32.Append(primaryStyle17);
            style32.Append(rsid40);
            style32.Append(styleParagraphProperties14);

            Style style33 = new Style() { Type = StyleValues.Paragraph, StyleId = "Cytat" };
            StyleName styleName33 = new StyleName() { Val = "Quote" };
            BasedOn basedOn28 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle13 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle25 = new LinkedStyle() { Val = "CytatZnak" };
            UIPriority uIPriority32 = new UIPriority() { Val = 29 };
            PrimaryStyle primaryStyle18 = new PrimaryStyle();
            Rsid rsid41 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties27 = new StyleRunProperties();
            RunFonts runFonts25 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi };
            Italic italic12 = new Italic();
            ItalicComplexScript italicComplexScript12 = new ItalicComplexScript();
            Color color20 = new Color() { Val = "000000", ThemeColor = ThemeColorValues.Text1 };

            styleRunProperties27.Append(runFonts25);
            styleRunProperties27.Append(italic12);
            styleRunProperties27.Append(italicComplexScript12);
            styleRunProperties27.Append(color20);

            style33.Append(styleName33);
            style33.Append(basedOn28);
            style33.Append(nextParagraphStyle13);
            style33.Append(linkedStyle25);
            style33.Append(uIPriority32);
            style33.Append(primaryStyle18);
            style33.Append(rsid41);
            style33.Append(styleRunProperties27);

            Style style34 = new Style() { Type = StyleValues.Character, StyleId = "CytatZnak", CustomStyle = true };
            StyleName styleName34 = new StyleName() { Val = "Cytat Znak" };
            BasedOn basedOn29 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle26 = new LinkedStyle() { Val = "Cytat" };
            UIPriority uIPriority33 = new UIPriority() { Val = 29 };
            Rsid rsid42 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties28 = new StyleRunProperties();
            Italic italic13 = new Italic();
            ItalicComplexScript italicComplexScript13 = new ItalicComplexScript();
            Color color21 = new Color() { Val = "000000", ThemeColor = ThemeColorValues.Text1 };

            styleRunProperties28.Append(italic13);
            styleRunProperties28.Append(italicComplexScript13);
            styleRunProperties28.Append(color21);

            style34.Append(styleName34);
            style34.Append(basedOn29);
            style34.Append(linkedStyle26);
            style34.Append(uIPriority33);
            style34.Append(rsid42);
            style34.Append(styleRunProperties28);

            Style style35 = new Style() { Type = StyleValues.Paragraph, StyleId = "Cytatintensywny" };
            StyleName styleName35 = new StyleName() { Val = "Intense Quote" };
            BasedOn basedOn30 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle14 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle27 = new LinkedStyle() { Val = "CytatintensywnyZnak" };
            UIPriority uIPriority34 = new UIPriority() { Val = 30 };
            PrimaryStyle primaryStyle19 = new PrimaryStyle();
            Rsid rsid43 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties15 = new StyleParagraphProperties();

            ParagraphBorders paragraphBorders2 = new ParagraphBorders();
            BottomBorder bottomBorder2 = new BottomBorder() { Val = BorderValues.Single, Color = "4F81BD", ThemeColor = ThemeColorValues.Accent1, Size = (UInt32Value)4U, Space = (UInt32Value)4U };

            paragraphBorders2.Append(bottomBorder2);
            SpacingBetweenLines spacingBetweenLines14 = new SpacingBetweenLines() { Before = "200", After = "280" };
            Indentation indentation2 = new Indentation() { Left = "936", Right = "936" };

            styleParagraphProperties15.Append(paragraphBorders2);
            styleParagraphProperties15.Append(spacingBetweenLines14);
            styleParagraphProperties15.Append(indentation2);

            StyleRunProperties styleRunProperties29 = new StyleRunProperties();
            RunFonts runFonts26 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi };
            Bold bold11 = new Bold();
            BoldComplexScript boldComplexScript11 = new BoldComplexScript();
            Italic italic14 = new Italic();
            ItalicComplexScript italicComplexScript14 = new ItalicComplexScript();
            Color color22 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties29.Append(runFonts26);
            styleRunProperties29.Append(bold11);
            styleRunProperties29.Append(boldComplexScript11);
            styleRunProperties29.Append(italic14);
            styleRunProperties29.Append(italicComplexScript14);
            styleRunProperties29.Append(color22);

            style35.Append(styleName35);
            style35.Append(basedOn30);
            style35.Append(nextParagraphStyle14);
            style35.Append(linkedStyle27);
            style35.Append(uIPriority34);
            style35.Append(primaryStyle19);
            style35.Append(rsid43);
            style35.Append(styleParagraphProperties15);
            style35.Append(styleRunProperties29);

            Style style36 = new Style() { Type = StyleValues.Character, StyleId = "CytatintensywnyZnak", CustomStyle = true };
            StyleName styleName36 = new StyleName() { Val = "Cytat intensywny Znak" };
            BasedOn basedOn31 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle28 = new LinkedStyle() { Val = "Cytatintensywny" };
            UIPriority uIPriority35 = new UIPriority() { Val = 30 };
            Rsid rsid44 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties30 = new StyleRunProperties();
            Bold bold12 = new Bold();
            BoldComplexScript boldComplexScript12 = new BoldComplexScript();
            Italic italic15 = new Italic();
            ItalicComplexScript italicComplexScript15 = new ItalicComplexScript();
            Color color23 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties30.Append(bold12);
            styleRunProperties30.Append(boldComplexScript12);
            styleRunProperties30.Append(italic15);
            styleRunProperties30.Append(italicComplexScript15);
            styleRunProperties30.Append(color23);

            style36.Append(styleName36);
            style36.Append(basedOn31);
            style36.Append(linkedStyle28);
            style36.Append(uIPriority35);
            style36.Append(rsid44);
            style36.Append(styleRunProperties30);

            Style style37 = new Style() { Type = StyleValues.Character, StyleId = "Wyrnieniedelikatne" };
            StyleName styleName37 = new StyleName() { Val = "Subtle Emphasis" };
            BasedOn basedOn32 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority36 = new UIPriority() { Val = 19 };
            PrimaryStyle primaryStyle20 = new PrimaryStyle();
            Rsid rsid45 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties31 = new StyleRunProperties();
            Italic italic16 = new Italic();
            ItalicComplexScript italicComplexScript16 = new ItalicComplexScript();
            Color color24 = new Color() { Val = "808080", ThemeColor = ThemeColorValues.Text1, ThemeTint = "7F" };

            styleRunProperties31.Append(italic16);
            styleRunProperties31.Append(italicComplexScript16);
            styleRunProperties31.Append(color24);

            style37.Append(styleName37);
            style37.Append(basedOn32);
            style37.Append(uIPriority36);
            style37.Append(primaryStyle20);
            style37.Append(rsid45);
            style37.Append(styleRunProperties31);

            Style style38 = new Style() { Type = StyleValues.Character, StyleId = "Wyrnienieintensywne" };
            StyleName styleName38 = new StyleName() { Val = "Intense Emphasis" };
            BasedOn basedOn33 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority37 = new UIPriority() { Val = 21 };
            PrimaryStyle primaryStyle21 = new PrimaryStyle();
            Rsid rsid46 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties32 = new StyleRunProperties();
            Bold bold13 = new Bold();
            BoldComplexScript boldComplexScript13 = new BoldComplexScript();
            Italic italic17 = new Italic();
            ItalicComplexScript italicComplexScript17 = new ItalicComplexScript();
            Color color25 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties32.Append(bold13);
            styleRunProperties32.Append(boldComplexScript13);
            styleRunProperties32.Append(italic17);
            styleRunProperties32.Append(italicComplexScript17);
            styleRunProperties32.Append(color25);

            style38.Append(styleName38);
            style38.Append(basedOn33);
            style38.Append(uIPriority37);
            style38.Append(primaryStyle21);
            style38.Append(rsid46);
            style38.Append(styleRunProperties32);

            Style style39 = new Style() { Type = StyleValues.Character, StyleId = "Odwoaniedelikatne" };
            StyleName styleName39 = new StyleName() { Val = "Subtle Reference" };
            BasedOn basedOn34 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority38 = new UIPriority() { Val = 31 };
            PrimaryStyle primaryStyle22 = new PrimaryStyle();
            Rsid rsid47 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties33 = new StyleRunProperties();
            SmallCaps smallCaps1 = new SmallCaps();
            Color color26 = new Color() { Val = "C0504D", ThemeColor = ThemeColorValues.Accent2 };
            Underline underline1 = new Underline() { Val = UnderlineValues.Single };

            styleRunProperties33.Append(smallCaps1);
            styleRunProperties33.Append(color26);
            styleRunProperties33.Append(underline1);

            style39.Append(styleName39);
            style39.Append(basedOn34);
            style39.Append(uIPriority38);
            style39.Append(primaryStyle22);
            style39.Append(rsid47);
            style39.Append(styleRunProperties33);

            Style style40 = new Style() { Type = StyleValues.Character, StyleId = "Odwoanieintensywne" };
            StyleName styleName40 = new StyleName() { Val = "Intense Reference" };
            BasedOn basedOn35 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority39 = new UIPriority() { Val = 32 };
            PrimaryStyle primaryStyle23 = new PrimaryStyle();
            Rsid rsid48 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties34 = new StyleRunProperties();
            Bold bold14 = new Bold();
            BoldComplexScript boldComplexScript14 = new BoldComplexScript();
            SmallCaps smallCaps2 = new SmallCaps();
            Color color27 = new Color() { Val = "C0504D", ThemeColor = ThemeColorValues.Accent2 };
            Spacing spacing5 = new Spacing() { Val = 5 };
            Underline underline2 = new Underline() { Val = UnderlineValues.Single };

            styleRunProperties34.Append(bold14);
            styleRunProperties34.Append(boldComplexScript14);
            styleRunProperties34.Append(smallCaps2);
            styleRunProperties34.Append(color27);
            styleRunProperties34.Append(spacing5);
            styleRunProperties34.Append(underline2);

            style40.Append(styleName40);
            style40.Append(basedOn35);
            style40.Append(uIPriority39);
            style40.Append(primaryStyle23);
            style40.Append(rsid48);
            style40.Append(styleRunProperties34);

            Style style41 = new Style() { Type = StyleValues.Character, StyleId = "Tytuksiki" };
            StyleName styleName41 = new StyleName() { Val = "Book Title" };
            BasedOn basedOn36 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority40 = new UIPriority() { Val = 33 };
            PrimaryStyle primaryStyle24 = new PrimaryStyle();
            Rsid rsid49 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties35 = new StyleRunProperties();
            Bold bold15 = new Bold();
            BoldComplexScript boldComplexScript15 = new BoldComplexScript();
            SmallCaps smallCaps3 = new SmallCaps();
            Spacing spacing6 = new Spacing() { Val = 5 };

            styleRunProperties35.Append(bold15);
            styleRunProperties35.Append(boldComplexScript15);
            styleRunProperties35.Append(smallCaps3);
            styleRunProperties35.Append(spacing6);

            style41.Append(styleName41);
            style41.Append(basedOn36);
            style41.Append(uIPriority40);
            style41.Append(primaryStyle24);
            style41.Append(rsid49);
            style41.Append(styleRunProperties35);

            Style style42 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwekspisutreci" };
            StyleName styleName42 = new StyleName() { Val = "TOC Heading" };
            BasedOn basedOn37 = new BasedOn() { Val = "Nagwek1" };
            NextParagraphStyle nextParagraphStyle15 = new NextParagraphStyle() { Val = "Normalny" };
            UIPriority uIPriority41 = new UIPriority() { Val = 39 };
            SemiHidden semiHidden21 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed13 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle25 = new PrimaryStyle();
            Rsid rsid50 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties16 = new StyleParagraphProperties();
            OutlineLevel outlineLevel10 = new OutlineLevel() { Val = 9 };

            styleParagraphProperties16.Append(outlineLevel10);

            style42.Append(styleName42);
            style42.Append(basedOn37);
            style42.Append(nextParagraphStyle15);
            style42.Append(uIPriority41);
            style42.Append(semiHidden21);
            style42.Append(unhideWhenUsed13);
            style42.Append(primaryStyle25);
            style42.Append(rsid50);
            style42.Append(styleParagraphProperties16);

            styles1.Append(docDefaults1);
            styles1.Append(latentStyles1);
            styles1.Append(style1);
            styles1.Append(style2);
            styles1.Append(style3);
            styles1.Append(style4);
            styles1.Append(style5);
            styles1.Append(style6);
            styles1.Append(style7);
            styles1.Append(style8);
            styles1.Append(style9);
            styles1.Append(style10);
            styles1.Append(style11);
            styles1.Append(style12);
            styles1.Append(style13);
            styles1.Append(style14);
            styles1.Append(style15);
            styles1.Append(style16);
            styles1.Append(style17);
            styles1.Append(style18);
            styles1.Append(style19);
            styles1.Append(style20);
            styles1.Append(style21);
            styles1.Append(style22);
            styles1.Append(style23);
            styles1.Append(style24);
            styles1.Append(style25);
            styles1.Append(style26);
            styles1.Append(style27);
            styles1.Append(style28);
            styles1.Append(style29);
            styles1.Append(style30);
            styles1.Append(style31);
            styles1.Append(style32);
            styles1.Append(style33);
            styles1.Append(style34);
            styles1.Append(style35);
            styles1.Append(style36);
            styles1.Append(style37);
            styles1.Append(style38);
            styles1.Append(style39);
            styles1.Append(style40);
            styles1.Append(style41);
            styles1.Append(style42);

            stylesWithEffectsPart1.Styles = styles1;
        }

        // Generates content of styleDefinitionsPart1.
        private static void GenerateStyleDefinitionsPart1Content(StyleDefinitionsPart styleDefinitionsPart1)
        {
            DocumentFormat.OpenXml.Wordprocessing.Styles styles2 = new DocumentFormat.OpenXml.Wordprocessing.Styles() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
            styles2.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            styles2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            styles2.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            styles2.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");

            DocDefaults docDefaults2 = new DocDefaults();

            RunPropertiesDefault runPropertiesDefault2 = new RunPropertiesDefault();

            RunPropertiesBaseStyle runPropertiesBaseStyle2 = new RunPropertiesBaseStyle();
            RunFonts runFonts27 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi, EastAsiaTheme = ThemeFontValues.MinorHighAnsi, ComplexScriptTheme = ThemeFontValues.MinorBidi };
            FontSize fontSize15 = new FontSize() { Val = "22" };
            FontSizeComplexScript fontSizeComplexScript15 = new FontSizeComplexScript() { Val = "22" };
            Languages languages2 = new Languages() { Val = "pl-PL", EastAsia = "en-US", Bidi = "ar-SA" };

            runPropertiesBaseStyle2.Append(runFonts27);
            runPropertiesBaseStyle2.Append(fontSize15);
            runPropertiesBaseStyle2.Append(fontSizeComplexScript15);
            runPropertiesBaseStyle2.Append(languages2);

            runPropertiesDefault2.Append(runPropertiesBaseStyle2);

            ParagraphPropertiesDefault paragraphPropertiesDefault2 = new ParagraphPropertiesDefault();

            ParagraphPropertiesBaseStyle paragraphPropertiesBaseStyle2 = new ParagraphPropertiesBaseStyle();
            SpacingBetweenLines spacingBetweenLines15 = new SpacingBetweenLines() { After = "200", Line = "276", LineRule = LineSpacingRuleValues.Auto };

            paragraphPropertiesBaseStyle2.Append(spacingBetweenLines15);

            paragraphPropertiesDefault2.Append(paragraphPropertiesBaseStyle2);

            docDefaults2.Append(runPropertiesDefault2);
            docDefaults2.Append(paragraphPropertiesDefault2);

            LatentStyles latentStyles2 = new LatentStyles() { DefaultLockedState = false, DefaultUiPriority = 99, DefaultSemiHidden = true, DefaultUnhideWhenUsed = true, DefaultPrimaryStyle = false, Count = 267 };
            LatentStyleExceptionInfo latentStyleExceptionInfo138 = new LatentStyleExceptionInfo() { Name = "Normal", UiPriority = 0, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo139 = new LatentStyleExceptionInfo() { Name = "heading 1", UiPriority = 9, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo140 = new LatentStyleExceptionInfo() { Name = "heading 2", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo141 = new LatentStyleExceptionInfo() { Name = "heading 3", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo142 = new LatentStyleExceptionInfo() { Name = "heading 4", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo143 = new LatentStyleExceptionInfo() { Name = "heading 5", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo144 = new LatentStyleExceptionInfo() { Name = "heading 6", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo145 = new LatentStyleExceptionInfo() { Name = "heading 7", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo146 = new LatentStyleExceptionInfo() { Name = "heading 8", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo147 = new LatentStyleExceptionInfo() { Name = "heading 9", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo148 = new LatentStyleExceptionInfo() { Name = "toc 1", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo149 = new LatentStyleExceptionInfo() { Name = "toc 2", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo150 = new LatentStyleExceptionInfo() { Name = "toc 3", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo151 = new LatentStyleExceptionInfo() { Name = "toc 4", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo152 = new LatentStyleExceptionInfo() { Name = "toc 5", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo153 = new LatentStyleExceptionInfo() { Name = "toc 6", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo154 = new LatentStyleExceptionInfo() { Name = "toc 7", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo155 = new LatentStyleExceptionInfo() { Name = "toc 8", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo156 = new LatentStyleExceptionInfo() { Name = "toc 9", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo157 = new LatentStyleExceptionInfo() { Name = "caption", UiPriority = 35, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo158 = new LatentStyleExceptionInfo() { Name = "Title", UiPriority = 10, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo159 = new LatentStyleExceptionInfo() { Name = "Default Paragraph Font", UiPriority = 1 };
            LatentStyleExceptionInfo latentStyleExceptionInfo160 = new LatentStyleExceptionInfo() { Name = "Subtitle", UiPriority = 11, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo161 = new LatentStyleExceptionInfo() { Name = "Strong", UiPriority = 22, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo162 = new LatentStyleExceptionInfo() { Name = "Emphasis", UiPriority = 20, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo163 = new LatentStyleExceptionInfo() { Name = "Table Grid", UiPriority = 59, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo164 = new LatentStyleExceptionInfo() { Name = "Placeholder Text", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo165 = new LatentStyleExceptionInfo() { Name = "No Spacing", UiPriority = 1, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo166 = new LatentStyleExceptionInfo() { Name = "Light Shading", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo167 = new LatentStyleExceptionInfo() { Name = "Light List", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo168 = new LatentStyleExceptionInfo() { Name = "Light Grid", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo169 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo170 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo171 = new LatentStyleExceptionInfo() { Name = "Medium List 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo172 = new LatentStyleExceptionInfo() { Name = "Medium List 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo173 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo174 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo175 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo176 = new LatentStyleExceptionInfo() { Name = "Dark List", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo177 = new LatentStyleExceptionInfo() { Name = "Colorful Shading", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo178 = new LatentStyleExceptionInfo() { Name = "Colorful List", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo179 = new LatentStyleExceptionInfo() { Name = "Colorful Grid", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo180 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 1", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo181 = new LatentStyleExceptionInfo() { Name = "Light List Accent 1", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo182 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 1", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo183 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo184 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 1", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo185 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo186 = new LatentStyleExceptionInfo() { Name = "Revision", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo187 = new LatentStyleExceptionInfo() { Name = "List Paragraph", UiPriority = 34, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo188 = new LatentStyleExceptionInfo() { Name = "Quote", UiPriority = 29, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo189 = new LatentStyleExceptionInfo() { Name = "Intense Quote", UiPriority = 30, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo190 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 1", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo191 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo192 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 1", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo193 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 1", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo194 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 1", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo195 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 1", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo196 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 1", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo197 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 1", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo198 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 2", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo199 = new LatentStyleExceptionInfo() { Name = "Light List Accent 2", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo200 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 2", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo201 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 2", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo202 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo203 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 2", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo204 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo205 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 2", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo206 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo207 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 2", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo208 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 2", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo209 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 2", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo210 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 2", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo211 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 2", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo212 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 3", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo213 = new LatentStyleExceptionInfo() { Name = "Light List Accent 3", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo214 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 3", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo215 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 3", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo216 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 3", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo217 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 3", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo218 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 3", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo219 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 3", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo220 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 3", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo221 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo222 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 3", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo223 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 3", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo224 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 3", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo225 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 3", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo226 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 4", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo227 = new LatentStyleExceptionInfo() { Name = "Light List Accent 4", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo228 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 4", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo229 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 4", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo230 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 4", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo231 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 4", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo232 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 4", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo233 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 4", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo234 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 4", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo235 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 4", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo236 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 4", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo237 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 4", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo238 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 4", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo239 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 4", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo240 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 5", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo241 = new LatentStyleExceptionInfo() { Name = "Light List Accent 5", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo242 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 5", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo243 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 5", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo244 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 5", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo245 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 5", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo246 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 5", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo247 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 5", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo248 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 5", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo249 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 5", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo250 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 5", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo251 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 5", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo252 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 5", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo253 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 5", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo254 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 6", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo255 = new LatentStyleExceptionInfo() { Name = "Light List Accent 6", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo256 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 6", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo257 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 6", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo258 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 6", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo259 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 6", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo260 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 6", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo261 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 6", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo262 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 6", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo263 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 6", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo264 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 6", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo265 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 6", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo266 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 6", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo267 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 6", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo268 = new LatentStyleExceptionInfo() { Name = "Subtle Emphasis", UiPriority = 19, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo269 = new LatentStyleExceptionInfo() { Name = "Intense Emphasis", UiPriority = 21, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo270 = new LatentStyleExceptionInfo() { Name = "Subtle Reference", UiPriority = 31, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo271 = new LatentStyleExceptionInfo() { Name = "Intense Reference", UiPriority = 32, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo272 = new LatentStyleExceptionInfo() { Name = "Book Title", UiPriority = 33, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo273 = new LatentStyleExceptionInfo() { Name = "Bibliography", UiPriority = 37 };
            LatentStyleExceptionInfo latentStyleExceptionInfo274 = new LatentStyleExceptionInfo() { Name = "TOC Heading", UiPriority = 39, PrimaryStyle = true };

            latentStyles2.Append(latentStyleExceptionInfo138);
            latentStyles2.Append(latentStyleExceptionInfo139);
            latentStyles2.Append(latentStyleExceptionInfo140);
            latentStyles2.Append(latentStyleExceptionInfo141);
            latentStyles2.Append(latentStyleExceptionInfo142);
            latentStyles2.Append(latentStyleExceptionInfo143);
            latentStyles2.Append(latentStyleExceptionInfo144);
            latentStyles2.Append(latentStyleExceptionInfo145);
            latentStyles2.Append(latentStyleExceptionInfo146);
            latentStyles2.Append(latentStyleExceptionInfo147);
            latentStyles2.Append(latentStyleExceptionInfo148);
            latentStyles2.Append(latentStyleExceptionInfo149);
            latentStyles2.Append(latentStyleExceptionInfo150);
            latentStyles2.Append(latentStyleExceptionInfo151);
            latentStyles2.Append(latentStyleExceptionInfo152);
            latentStyles2.Append(latentStyleExceptionInfo153);
            latentStyles2.Append(latentStyleExceptionInfo154);
            latentStyles2.Append(latentStyleExceptionInfo155);
            latentStyles2.Append(latentStyleExceptionInfo156);
            latentStyles2.Append(latentStyleExceptionInfo157);
            latentStyles2.Append(latentStyleExceptionInfo158);
            latentStyles2.Append(latentStyleExceptionInfo159);
            latentStyles2.Append(latentStyleExceptionInfo160);
            latentStyles2.Append(latentStyleExceptionInfo161);
            latentStyles2.Append(latentStyleExceptionInfo162);
            latentStyles2.Append(latentStyleExceptionInfo163);
            latentStyles2.Append(latentStyleExceptionInfo164);
            latentStyles2.Append(latentStyleExceptionInfo165);
            latentStyles2.Append(latentStyleExceptionInfo166);
            latentStyles2.Append(latentStyleExceptionInfo167);
            latentStyles2.Append(latentStyleExceptionInfo168);
            latentStyles2.Append(latentStyleExceptionInfo169);
            latentStyles2.Append(latentStyleExceptionInfo170);
            latentStyles2.Append(latentStyleExceptionInfo171);
            latentStyles2.Append(latentStyleExceptionInfo172);
            latentStyles2.Append(latentStyleExceptionInfo173);
            latentStyles2.Append(latentStyleExceptionInfo174);
            latentStyles2.Append(latentStyleExceptionInfo175);
            latentStyles2.Append(latentStyleExceptionInfo176);
            latentStyles2.Append(latentStyleExceptionInfo177);
            latentStyles2.Append(latentStyleExceptionInfo178);
            latentStyles2.Append(latentStyleExceptionInfo179);
            latentStyles2.Append(latentStyleExceptionInfo180);
            latentStyles2.Append(latentStyleExceptionInfo181);
            latentStyles2.Append(latentStyleExceptionInfo182);
            latentStyles2.Append(latentStyleExceptionInfo183);
            latentStyles2.Append(latentStyleExceptionInfo184);
            latentStyles2.Append(latentStyleExceptionInfo185);
            latentStyles2.Append(latentStyleExceptionInfo186);
            latentStyles2.Append(latentStyleExceptionInfo187);
            latentStyles2.Append(latentStyleExceptionInfo188);
            latentStyles2.Append(latentStyleExceptionInfo189);
            latentStyles2.Append(latentStyleExceptionInfo190);
            latentStyles2.Append(latentStyleExceptionInfo191);
            latentStyles2.Append(latentStyleExceptionInfo192);
            latentStyles2.Append(latentStyleExceptionInfo193);
            latentStyles2.Append(latentStyleExceptionInfo194);
            latentStyles2.Append(latentStyleExceptionInfo195);
            latentStyles2.Append(latentStyleExceptionInfo196);
            latentStyles2.Append(latentStyleExceptionInfo197);
            latentStyles2.Append(latentStyleExceptionInfo198);
            latentStyles2.Append(latentStyleExceptionInfo199);
            latentStyles2.Append(latentStyleExceptionInfo200);
            latentStyles2.Append(latentStyleExceptionInfo201);
            latentStyles2.Append(latentStyleExceptionInfo202);
            latentStyles2.Append(latentStyleExceptionInfo203);
            latentStyles2.Append(latentStyleExceptionInfo204);
            latentStyles2.Append(latentStyleExceptionInfo205);
            latentStyles2.Append(latentStyleExceptionInfo206);
            latentStyles2.Append(latentStyleExceptionInfo207);
            latentStyles2.Append(latentStyleExceptionInfo208);
            latentStyles2.Append(latentStyleExceptionInfo209);
            latentStyles2.Append(latentStyleExceptionInfo210);
            latentStyles2.Append(latentStyleExceptionInfo211);
            latentStyles2.Append(latentStyleExceptionInfo212);
            latentStyles2.Append(latentStyleExceptionInfo213);
            latentStyles2.Append(latentStyleExceptionInfo214);
            latentStyles2.Append(latentStyleExceptionInfo215);
            latentStyles2.Append(latentStyleExceptionInfo216);
            latentStyles2.Append(latentStyleExceptionInfo217);
            latentStyles2.Append(latentStyleExceptionInfo218);
            latentStyles2.Append(latentStyleExceptionInfo219);
            latentStyles2.Append(latentStyleExceptionInfo220);
            latentStyles2.Append(latentStyleExceptionInfo221);
            latentStyles2.Append(latentStyleExceptionInfo222);
            latentStyles2.Append(latentStyleExceptionInfo223);
            latentStyles2.Append(latentStyleExceptionInfo224);
            latentStyles2.Append(latentStyleExceptionInfo225);
            latentStyles2.Append(latentStyleExceptionInfo226);
            latentStyles2.Append(latentStyleExceptionInfo227);
            latentStyles2.Append(latentStyleExceptionInfo228);
            latentStyles2.Append(latentStyleExceptionInfo229);
            latentStyles2.Append(latentStyleExceptionInfo230);
            latentStyles2.Append(latentStyleExceptionInfo231);
            latentStyles2.Append(latentStyleExceptionInfo232);
            latentStyles2.Append(latentStyleExceptionInfo233);
            latentStyles2.Append(latentStyleExceptionInfo234);
            latentStyles2.Append(latentStyleExceptionInfo235);
            latentStyles2.Append(latentStyleExceptionInfo236);
            latentStyles2.Append(latentStyleExceptionInfo237);
            latentStyles2.Append(latentStyleExceptionInfo238);
            latentStyles2.Append(latentStyleExceptionInfo239);
            latentStyles2.Append(latentStyleExceptionInfo240);
            latentStyles2.Append(latentStyleExceptionInfo241);
            latentStyles2.Append(latentStyleExceptionInfo242);
            latentStyles2.Append(latentStyleExceptionInfo243);
            latentStyles2.Append(latentStyleExceptionInfo244);
            latentStyles2.Append(latentStyleExceptionInfo245);
            latentStyles2.Append(latentStyleExceptionInfo246);
            latentStyles2.Append(latentStyleExceptionInfo247);
            latentStyles2.Append(latentStyleExceptionInfo248);
            latentStyles2.Append(latentStyleExceptionInfo249);
            latentStyles2.Append(latentStyleExceptionInfo250);
            latentStyles2.Append(latentStyleExceptionInfo251);
            latentStyles2.Append(latentStyleExceptionInfo252);
            latentStyles2.Append(latentStyleExceptionInfo253);
            latentStyles2.Append(latentStyleExceptionInfo254);
            latentStyles2.Append(latentStyleExceptionInfo255);
            latentStyles2.Append(latentStyleExceptionInfo256);
            latentStyles2.Append(latentStyleExceptionInfo257);
            latentStyles2.Append(latentStyleExceptionInfo258);
            latentStyles2.Append(latentStyleExceptionInfo259);
            latentStyles2.Append(latentStyleExceptionInfo260);
            latentStyles2.Append(latentStyleExceptionInfo261);
            latentStyles2.Append(latentStyleExceptionInfo262);
            latentStyles2.Append(latentStyleExceptionInfo263);
            latentStyles2.Append(latentStyleExceptionInfo264);
            latentStyles2.Append(latentStyleExceptionInfo265);
            latentStyles2.Append(latentStyleExceptionInfo266);
            latentStyles2.Append(latentStyleExceptionInfo267);
            latentStyles2.Append(latentStyleExceptionInfo268);
            latentStyles2.Append(latentStyleExceptionInfo269);
            latentStyles2.Append(latentStyleExceptionInfo270);
            latentStyles2.Append(latentStyleExceptionInfo271);
            latentStyles2.Append(latentStyleExceptionInfo272);
            latentStyles2.Append(latentStyleExceptionInfo273);
            latentStyles2.Append(latentStyleExceptionInfo274);

            Style style43 = new Style() { Type = StyleValues.Paragraph, StyleId = "Normalny", Default = true };
            StyleName styleName43 = new StyleName() { Val = "Normal" };
            PrimaryStyle primaryStyle26 = new PrimaryStyle();
            Rsid rsid51 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties36 = new StyleRunProperties();
            RunFonts runFonts28 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman" };

            styleRunProperties36.Append(runFonts28);

            style43.Append(styleName43);
            style43.Append(primaryStyle26);
            style43.Append(rsid51);
            style43.Append(styleRunProperties36);

            Style style44 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek1" };
            StyleName styleName44 = new StyleName() { Val = "heading 1" };
            BasedOn basedOn38 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle16 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle29 = new LinkedStyle() { Val = "Nagwek1Znak" };
            UIPriority uIPriority42 = new UIPriority() { Val = 9 };
            PrimaryStyle primaryStyle27 = new PrimaryStyle();
            Rsid rsid52 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties17 = new StyleParagraphProperties();
            KeepNext keepNext10 = new KeepNext();
            KeepLines keepLines10 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines16 = new SpacingBetweenLines() { Before = "480", After = "0" };
            OutlineLevel outlineLevel11 = new OutlineLevel() { Val = 0 };

            styleParagraphProperties17.Append(keepNext10);
            styleParagraphProperties17.Append(keepLines10);
            styleParagraphProperties17.Append(spacingBetweenLines16);
            styleParagraphProperties17.Append(outlineLevel11);

            StyleRunProperties styleRunProperties37 = new StyleRunProperties();
            RunFonts runFonts29 = new RunFonts() { EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold16 = new Bold();
            BoldComplexScript boldComplexScript16 = new BoldComplexScript();
            FontSize fontSize16 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript16 = new FontSizeComplexScript() { Val = "28" };

            styleRunProperties37.Append(runFonts29);
            styleRunProperties37.Append(bold16);
            styleRunProperties37.Append(boldComplexScript16);
            styleRunProperties37.Append(fontSize16);
            styleRunProperties37.Append(fontSizeComplexScript16);

            style44.Append(styleName44);
            style44.Append(basedOn38);
            style44.Append(nextParagraphStyle16);
            style44.Append(linkedStyle29);
            style44.Append(uIPriority42);
            style44.Append(primaryStyle27);
            style44.Append(rsid52);
            style44.Append(styleParagraphProperties17);
            style44.Append(styleRunProperties37);

            Style style45 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek2" };
            StyleName styleName45 = new StyleName() { Val = "heading 2" };
            BasedOn basedOn39 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle17 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle30 = new LinkedStyle() { Val = "Nagwek2Znak" };
            UIPriority uIPriority43 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden22 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed14 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle28 = new PrimaryStyle();
            Rsid rsid53 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties18 = new StyleParagraphProperties();
            KeepNext keepNext11 = new KeepNext();
            KeepLines keepLines11 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines17 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel12 = new OutlineLevel() { Val = 1 };

            styleParagraphProperties18.Append(keepNext11);
            styleParagraphProperties18.Append(keepLines11);
            styleParagraphProperties18.Append(spacingBetweenLines17);
            styleParagraphProperties18.Append(outlineLevel12);

            StyleRunProperties styleRunProperties38 = new StyleRunProperties();
            RunFonts runFonts30 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold17 = new Bold();
            BoldComplexScript boldComplexScript17 = new BoldComplexScript();
            Color color28 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            FontSize fontSize17 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript17 = new FontSizeComplexScript() { Val = "26" };

            styleRunProperties38.Append(runFonts30);
            styleRunProperties38.Append(bold17);
            styleRunProperties38.Append(boldComplexScript17);
            styleRunProperties38.Append(color28);
            styleRunProperties38.Append(fontSize17);
            styleRunProperties38.Append(fontSizeComplexScript17);

            style45.Append(styleName45);
            style45.Append(basedOn39);
            style45.Append(nextParagraphStyle17);
            style45.Append(linkedStyle30);
            style45.Append(uIPriority43);
            style45.Append(semiHidden22);
            style45.Append(unhideWhenUsed14);
            style45.Append(primaryStyle28);
            style45.Append(rsid53);
            style45.Append(styleParagraphProperties18);
            style45.Append(styleRunProperties38);

            Style style46 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek3" };
            StyleName styleName46 = new StyleName() { Val = "heading 3" };
            BasedOn basedOn40 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle18 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle31 = new LinkedStyle() { Val = "Nagwek3Znak" };
            UIPriority uIPriority44 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden23 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed15 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle29 = new PrimaryStyle();
            Rsid rsid54 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties19 = new StyleParagraphProperties();
            KeepNext keepNext12 = new KeepNext();
            KeepLines keepLines12 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines18 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel13 = new OutlineLevel() { Val = 2 };

            styleParagraphProperties19.Append(keepNext12);
            styleParagraphProperties19.Append(keepLines12);
            styleParagraphProperties19.Append(spacingBetweenLines18);
            styleParagraphProperties19.Append(outlineLevel13);

            StyleRunProperties styleRunProperties39 = new StyleRunProperties();
            RunFonts runFonts31 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold18 = new Bold();
            BoldComplexScript boldComplexScript18 = new BoldComplexScript();
            Color color29 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties39.Append(runFonts31);
            styleRunProperties39.Append(bold18);
            styleRunProperties39.Append(boldComplexScript18);
            styleRunProperties39.Append(color29);

            style46.Append(styleName46);
            style46.Append(basedOn40);
            style46.Append(nextParagraphStyle18);
            style46.Append(linkedStyle31);
            style46.Append(uIPriority44);
            style46.Append(semiHidden23);
            style46.Append(unhideWhenUsed15);
            style46.Append(primaryStyle29);
            style46.Append(rsid54);
            style46.Append(styleParagraphProperties19);
            style46.Append(styleRunProperties39);

            Style style47 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek4" };
            StyleName styleName47 = new StyleName() { Val = "heading 4" };
            BasedOn basedOn41 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle19 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle32 = new LinkedStyle() { Val = "Nagwek4Znak" };
            UIPriority uIPriority45 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden24 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed16 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle30 = new PrimaryStyle();
            Rsid rsid55 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties20 = new StyleParagraphProperties();
            KeepNext keepNext13 = new KeepNext();
            KeepLines keepLines13 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines19 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel14 = new OutlineLevel() { Val = 3 };

            styleParagraphProperties20.Append(keepNext13);
            styleParagraphProperties20.Append(keepLines13);
            styleParagraphProperties20.Append(spacingBetweenLines19);
            styleParagraphProperties20.Append(outlineLevel14);

            StyleRunProperties styleRunProperties40 = new StyleRunProperties();
            RunFonts runFonts32 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold19 = new Bold();
            BoldComplexScript boldComplexScript19 = new BoldComplexScript();
            Italic italic18 = new Italic();
            ItalicComplexScript italicComplexScript18 = new ItalicComplexScript();
            Color color30 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties40.Append(runFonts32);
            styleRunProperties40.Append(bold19);
            styleRunProperties40.Append(boldComplexScript19);
            styleRunProperties40.Append(italic18);
            styleRunProperties40.Append(italicComplexScript18);
            styleRunProperties40.Append(color30);

            style47.Append(styleName47);
            style47.Append(basedOn41);
            style47.Append(nextParagraphStyle19);
            style47.Append(linkedStyle32);
            style47.Append(uIPriority45);
            style47.Append(semiHidden24);
            style47.Append(unhideWhenUsed16);
            style47.Append(primaryStyle30);
            style47.Append(rsid55);
            style47.Append(styleParagraphProperties20);
            style47.Append(styleRunProperties40);

            Style style48 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek5" };
            StyleName styleName48 = new StyleName() { Val = "heading 5" };
            BasedOn basedOn42 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle20 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle33 = new LinkedStyle() { Val = "Nagwek5Znak" };
            UIPriority uIPriority46 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden25 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed17 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle31 = new PrimaryStyle();
            Rsid rsid56 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties21 = new StyleParagraphProperties();
            KeepNext keepNext14 = new KeepNext();
            KeepLines keepLines14 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines20 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel15 = new OutlineLevel() { Val = 4 };

            styleParagraphProperties21.Append(keepNext14);
            styleParagraphProperties21.Append(keepLines14);
            styleParagraphProperties21.Append(spacingBetweenLines20);
            styleParagraphProperties21.Append(outlineLevel15);

            StyleRunProperties styleRunProperties41 = new StyleRunProperties();
            RunFonts runFonts33 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color31 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties41.Append(runFonts33);
            styleRunProperties41.Append(color31);

            style48.Append(styleName48);
            style48.Append(basedOn42);
            style48.Append(nextParagraphStyle20);
            style48.Append(linkedStyle33);
            style48.Append(uIPriority46);
            style48.Append(semiHidden25);
            style48.Append(unhideWhenUsed17);
            style48.Append(primaryStyle31);
            style48.Append(rsid56);
            style48.Append(styleParagraphProperties21);
            style48.Append(styleRunProperties41);

            Style style49 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek6" };
            StyleName styleName49 = new StyleName() { Val = "heading 6" };
            BasedOn basedOn43 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle21 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle34 = new LinkedStyle() { Val = "Nagwek6Znak" };
            UIPriority uIPriority47 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden26 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed18 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle32 = new PrimaryStyle();
            Rsid rsid57 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties22 = new StyleParagraphProperties();
            KeepNext keepNext15 = new KeepNext();
            KeepLines keepLines15 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines21 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel16 = new OutlineLevel() { Val = 5 };

            styleParagraphProperties22.Append(keepNext15);
            styleParagraphProperties22.Append(keepLines15);
            styleParagraphProperties22.Append(spacingBetweenLines21);
            styleParagraphProperties22.Append(outlineLevel16);

            StyleRunProperties styleRunProperties42 = new StyleRunProperties();
            RunFonts runFonts34 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic19 = new Italic();
            ItalicComplexScript italicComplexScript19 = new ItalicComplexScript();
            Color color32 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties42.Append(runFonts34);
            styleRunProperties42.Append(italic19);
            styleRunProperties42.Append(italicComplexScript19);
            styleRunProperties42.Append(color32);

            style49.Append(styleName49);
            style49.Append(basedOn43);
            style49.Append(nextParagraphStyle21);
            style49.Append(linkedStyle34);
            style49.Append(uIPriority47);
            style49.Append(semiHidden26);
            style49.Append(unhideWhenUsed18);
            style49.Append(primaryStyle32);
            style49.Append(rsid57);
            style49.Append(styleParagraphProperties22);
            style49.Append(styleRunProperties42);

            Style style50 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek7" };
            StyleName styleName50 = new StyleName() { Val = "heading 7" };
            BasedOn basedOn44 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle22 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle35 = new LinkedStyle() { Val = "Nagwek7Znak" };
            UIPriority uIPriority48 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden27 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed19 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle33 = new PrimaryStyle();
            Rsid rsid58 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties23 = new StyleParagraphProperties();
            KeepNext keepNext16 = new KeepNext();
            KeepLines keepLines16 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines22 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel17 = new OutlineLevel() { Val = 6 };

            styleParagraphProperties23.Append(keepNext16);
            styleParagraphProperties23.Append(keepLines16);
            styleParagraphProperties23.Append(spacingBetweenLines22);
            styleParagraphProperties23.Append(outlineLevel17);

            StyleRunProperties styleRunProperties43 = new StyleRunProperties();
            RunFonts runFonts35 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic20 = new Italic();
            ItalicComplexScript italicComplexScript20 = new ItalicComplexScript();
            Color color33 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };

            styleRunProperties43.Append(runFonts35);
            styleRunProperties43.Append(italic20);
            styleRunProperties43.Append(italicComplexScript20);
            styleRunProperties43.Append(color33);

            style50.Append(styleName50);
            style50.Append(basedOn44);
            style50.Append(nextParagraphStyle22);
            style50.Append(linkedStyle35);
            style50.Append(uIPriority48);
            style50.Append(semiHidden27);
            style50.Append(unhideWhenUsed19);
            style50.Append(primaryStyle33);
            style50.Append(rsid58);
            style50.Append(styleParagraphProperties23);
            style50.Append(styleRunProperties43);

            Style style51 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek8" };
            StyleName styleName51 = new StyleName() { Val = "heading 8" };
            BasedOn basedOn45 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle23 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle36 = new LinkedStyle() { Val = "Nagwek8Znak" };
            UIPriority uIPriority49 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden28 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed20 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle34 = new PrimaryStyle();
            Rsid rsid59 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties24 = new StyleParagraphProperties();
            KeepNext keepNext17 = new KeepNext();
            KeepLines keepLines17 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines23 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel18 = new OutlineLevel() { Val = 7 };

            styleParagraphProperties24.Append(keepNext17);
            styleParagraphProperties24.Append(keepLines17);
            styleParagraphProperties24.Append(spacingBetweenLines23);
            styleParagraphProperties24.Append(outlineLevel18);

            StyleRunProperties styleRunProperties44 = new StyleRunProperties();
            RunFonts runFonts36 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color34 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            FontSize fontSize18 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript18 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties44.Append(runFonts36);
            styleRunProperties44.Append(color34);
            styleRunProperties44.Append(fontSize18);
            styleRunProperties44.Append(fontSizeComplexScript18);

            style51.Append(styleName51);
            style51.Append(basedOn45);
            style51.Append(nextParagraphStyle23);
            style51.Append(linkedStyle36);
            style51.Append(uIPriority49);
            style51.Append(semiHidden28);
            style51.Append(unhideWhenUsed20);
            style51.Append(primaryStyle34);
            style51.Append(rsid59);
            style51.Append(styleParagraphProperties24);
            style51.Append(styleRunProperties44);

            Style style52 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwek9" };
            StyleName styleName52 = new StyleName() { Val = "heading 9" };
            BasedOn basedOn46 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle24 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle37 = new LinkedStyle() { Val = "Nagwek9Znak" };
            UIPriority uIPriority50 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden29 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed21 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle35 = new PrimaryStyle();
            Rsid rsid60 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties25 = new StyleParagraphProperties();
            KeepNext keepNext18 = new KeepNext();
            KeepLines keepLines18 = new KeepLines();
            SpacingBetweenLines spacingBetweenLines24 = new SpacingBetweenLines() { Before = "200", After = "0" };
            OutlineLevel outlineLevel19 = new OutlineLevel() { Val = 8 };

            styleParagraphProperties25.Append(keepNext18);
            styleParagraphProperties25.Append(keepLines18);
            styleParagraphProperties25.Append(spacingBetweenLines24);
            styleParagraphProperties25.Append(outlineLevel19);

            StyleRunProperties styleRunProperties45 = new StyleRunProperties();
            RunFonts runFonts37 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic21 = new Italic();
            ItalicComplexScript italicComplexScript21 = new ItalicComplexScript();
            Color color35 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };
            FontSize fontSize19 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript19 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties45.Append(runFonts37);
            styleRunProperties45.Append(italic21);
            styleRunProperties45.Append(italicComplexScript21);
            styleRunProperties45.Append(color35);
            styleRunProperties45.Append(fontSize19);
            styleRunProperties45.Append(fontSizeComplexScript19);

            style52.Append(styleName52);
            style52.Append(basedOn46);
            style52.Append(nextParagraphStyle24);
            style52.Append(linkedStyle37);
            style52.Append(uIPriority50);
            style52.Append(semiHidden29);
            style52.Append(unhideWhenUsed21);
            style52.Append(primaryStyle35);
            style52.Append(rsid60);
            style52.Append(styleParagraphProperties25);
            style52.Append(styleRunProperties45);

            Style style53 = new Style() { Type = StyleValues.Character, StyleId = "Domylnaczcionkaakapitu", Default = true };
            StyleName styleName53 = new StyleName() { Val = "Default Paragraph Font" };
            UIPriority uIPriority51 = new UIPriority() { Val = 1 };
            SemiHidden semiHidden30 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed22 = new UnhideWhenUsed();

            style53.Append(styleName53);
            style53.Append(uIPriority51);
            style53.Append(semiHidden30);
            style53.Append(unhideWhenUsed22);

            Style style54 = new Style() { Type = StyleValues.Table, StyleId = "Standardowy", Default = true };
            StyleName styleName54 = new StyleName() { Val = "Normal Table" };
            UIPriority uIPriority52 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden31 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed23 = new UnhideWhenUsed();

            StyleTableProperties styleTableProperties2 = new StyleTableProperties();
            TableIndentation tableIndentation2 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

            TableCellMarginDefault tableCellMarginDefault2 = new TableCellMarginDefault();
            TopMargin topMargin2 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin2 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin2 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin2 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

            tableCellMarginDefault2.Append(topMargin2);
            tableCellMarginDefault2.Append(tableCellLeftMargin2);
            tableCellMarginDefault2.Append(bottomMargin2);
            tableCellMarginDefault2.Append(tableCellRightMargin2);

            styleTableProperties2.Append(tableIndentation2);
            styleTableProperties2.Append(tableCellMarginDefault2);

            style54.Append(styleName54);
            style54.Append(uIPriority52);
            style54.Append(semiHidden31);
            style54.Append(unhideWhenUsed23);
            style54.Append(styleTableProperties2);

            Style style55 = new Style() { Type = StyleValues.Numbering, StyleId = "Bezlisty", Default = true };
            StyleName styleName55 = new StyleName() { Val = "No List" };
            UIPriority uIPriority53 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden32 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed24 = new UnhideWhenUsed();

            style55.Append(styleName55);
            style55.Append(uIPriority53);
            style55.Append(semiHidden32);
            style55.Append(unhideWhenUsed24);

            Style style56 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek1Znak", CustomStyle = true };
            StyleName styleName56 = new StyleName() { Val = "Nagłówek 1 Znak" };
            BasedOn basedOn47 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle38 = new LinkedStyle() { Val = "Nagwek1" };
            UIPriority uIPriority54 = new UIPriority() { Val = 9 };
            Rsid rsid61 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties46 = new StyleRunProperties();
            RunFonts runFonts38 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold20 = new Bold();
            BoldComplexScript boldComplexScript20 = new BoldComplexScript();
            FontSize fontSize20 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript20 = new FontSizeComplexScript() { Val = "28" };

            styleRunProperties46.Append(runFonts38);
            styleRunProperties46.Append(bold20);
            styleRunProperties46.Append(boldComplexScript20);
            styleRunProperties46.Append(fontSize20);
            styleRunProperties46.Append(fontSizeComplexScript20);

            style56.Append(styleName56);
            style56.Append(basedOn47);
            style56.Append(linkedStyle38);
            style56.Append(uIPriority54);
            style56.Append(rsid61);
            style56.Append(styleRunProperties46);

            Style style57 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek2Znak", CustomStyle = true };
            StyleName styleName57 = new StyleName() { Val = "Nagłówek 2 Znak" };
            BasedOn basedOn48 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle39 = new LinkedStyle() { Val = "Nagwek2" };
            UIPriority uIPriority55 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden33 = new SemiHidden();
            Rsid rsid62 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties47 = new StyleRunProperties();
            RunFonts runFonts39 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold21 = new Bold();
            BoldComplexScript boldComplexScript21 = new BoldComplexScript();
            Color color36 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            FontSize fontSize21 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript21 = new FontSizeComplexScript() { Val = "26" };

            styleRunProperties47.Append(runFonts39);
            styleRunProperties47.Append(bold21);
            styleRunProperties47.Append(boldComplexScript21);
            styleRunProperties47.Append(color36);
            styleRunProperties47.Append(fontSize21);
            styleRunProperties47.Append(fontSizeComplexScript21);

            style57.Append(styleName57);
            style57.Append(basedOn48);
            style57.Append(linkedStyle39);
            style57.Append(uIPriority55);
            style57.Append(semiHidden33);
            style57.Append(rsid62);
            style57.Append(styleRunProperties47);

            Style style58 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek3Znak", CustomStyle = true };
            StyleName styleName58 = new StyleName() { Val = "Nagłówek 3 Znak" };
            BasedOn basedOn49 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle40 = new LinkedStyle() { Val = "Nagwek3" };
            UIPriority uIPriority56 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden34 = new SemiHidden();
            Rsid rsid63 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties48 = new StyleRunProperties();
            RunFonts runFonts40 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold22 = new Bold();
            BoldComplexScript boldComplexScript22 = new BoldComplexScript();
            Color color37 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties48.Append(runFonts40);
            styleRunProperties48.Append(bold22);
            styleRunProperties48.Append(boldComplexScript22);
            styleRunProperties48.Append(color37);

            style58.Append(styleName58);
            style58.Append(basedOn49);
            style58.Append(linkedStyle40);
            style58.Append(uIPriority56);
            style58.Append(semiHidden34);
            style58.Append(rsid63);
            style58.Append(styleRunProperties48);

            Style style59 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek4Znak", CustomStyle = true };
            StyleName styleName59 = new StyleName() { Val = "Nagłówek 4 Znak" };
            BasedOn basedOn50 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle41 = new LinkedStyle() { Val = "Nagwek4" };
            UIPriority uIPriority57 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden35 = new SemiHidden();
            Rsid rsid64 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties49 = new StyleRunProperties();
            RunFonts runFonts41 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Bold bold23 = new Bold();
            BoldComplexScript boldComplexScript23 = new BoldComplexScript();
            Italic italic22 = new Italic();
            ItalicComplexScript italicComplexScript22 = new ItalicComplexScript();
            Color color38 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties49.Append(runFonts41);
            styleRunProperties49.Append(bold23);
            styleRunProperties49.Append(boldComplexScript23);
            styleRunProperties49.Append(italic22);
            styleRunProperties49.Append(italicComplexScript22);
            styleRunProperties49.Append(color38);

            style59.Append(styleName59);
            style59.Append(basedOn50);
            style59.Append(linkedStyle41);
            style59.Append(uIPriority57);
            style59.Append(semiHidden35);
            style59.Append(rsid64);
            style59.Append(styleRunProperties49);

            Style style60 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek5Znak", CustomStyle = true };
            StyleName styleName60 = new StyleName() { Val = "Nagłówek 5 Znak" };
            BasedOn basedOn51 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle42 = new LinkedStyle() { Val = "Nagwek5" };
            UIPriority uIPriority58 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden36 = new SemiHidden();
            Rsid rsid65 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties50 = new StyleRunProperties();
            RunFonts runFonts42 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color39 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties50.Append(runFonts42);
            styleRunProperties50.Append(color39);

            style60.Append(styleName60);
            style60.Append(basedOn51);
            style60.Append(linkedStyle42);
            style60.Append(uIPriority58);
            style60.Append(semiHidden36);
            style60.Append(rsid65);
            style60.Append(styleRunProperties50);

            Style style61 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek6Znak", CustomStyle = true };
            StyleName styleName61 = new StyleName() { Val = "Nagłówek 6 Znak" };
            BasedOn basedOn52 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle43 = new LinkedStyle() { Val = "Nagwek6" };
            UIPriority uIPriority59 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden37 = new SemiHidden();
            Rsid rsid66 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties51 = new StyleRunProperties();
            RunFonts runFonts43 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic23 = new Italic();
            ItalicComplexScript italicComplexScript23 = new ItalicComplexScript();
            Color color40 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };

            styleRunProperties51.Append(runFonts43);
            styleRunProperties51.Append(italic23);
            styleRunProperties51.Append(italicComplexScript23);
            styleRunProperties51.Append(color40);

            style61.Append(styleName61);
            style61.Append(basedOn52);
            style61.Append(linkedStyle43);
            style61.Append(uIPriority59);
            style61.Append(semiHidden37);
            style61.Append(rsid66);
            style61.Append(styleRunProperties51);

            Style style62 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek7Znak", CustomStyle = true };
            StyleName styleName62 = new StyleName() { Val = "Nagłówek 7 Znak" };
            BasedOn basedOn53 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle44 = new LinkedStyle() { Val = "Nagwek7" };
            UIPriority uIPriority60 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden38 = new SemiHidden();
            Rsid rsid67 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties52 = new StyleRunProperties();
            RunFonts runFonts44 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic24 = new Italic();
            ItalicComplexScript italicComplexScript24 = new ItalicComplexScript();
            Color color41 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };

            styleRunProperties52.Append(runFonts44);
            styleRunProperties52.Append(italic24);
            styleRunProperties52.Append(italicComplexScript24);
            styleRunProperties52.Append(color41);

            style62.Append(styleName62);
            style62.Append(basedOn53);
            style62.Append(linkedStyle44);
            style62.Append(uIPriority60);
            style62.Append(semiHidden38);
            style62.Append(rsid67);
            style62.Append(styleRunProperties52);

            Style style63 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek8Znak", CustomStyle = true };
            StyleName styleName63 = new StyleName() { Val = "Nagłówek 8 Znak" };
            BasedOn basedOn54 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle45 = new LinkedStyle() { Val = "Nagwek8" };
            UIPriority uIPriority61 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden39 = new SemiHidden();
            Rsid rsid68 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties53 = new StyleRunProperties();
            RunFonts runFonts45 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Color color42 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            FontSize fontSize22 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript22 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties53.Append(runFonts45);
            styleRunProperties53.Append(color42);
            styleRunProperties53.Append(fontSize22);
            styleRunProperties53.Append(fontSizeComplexScript22);

            style63.Append(styleName63);
            style63.Append(basedOn54);
            style63.Append(linkedStyle45);
            style63.Append(uIPriority61);
            style63.Append(semiHidden39);
            style63.Append(rsid68);
            style63.Append(styleRunProperties53);

            Style style64 = new Style() { Type = StyleValues.Character, StyleId = "Nagwek9Znak", CustomStyle = true };
            StyleName styleName64 = new StyleName() { Val = "Nagłówek 9 Znak" };
            BasedOn basedOn55 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle46 = new LinkedStyle() { Val = "Nagwek9" };
            UIPriority uIPriority62 = new UIPriority() { Val = 9 };
            SemiHidden semiHidden40 = new SemiHidden();
            Rsid rsid69 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties54 = new StyleRunProperties();
            RunFonts runFonts46 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic25 = new Italic();
            ItalicComplexScript italicComplexScript25 = new ItalicComplexScript();
            Color color43 = new Color() { Val = "404040", ThemeColor = ThemeColorValues.Text1, ThemeTint = "BF" };
            FontSize fontSize23 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript23 = new FontSizeComplexScript() { Val = "20" };

            styleRunProperties54.Append(runFonts46);
            styleRunProperties54.Append(italic25);
            styleRunProperties54.Append(italicComplexScript25);
            styleRunProperties54.Append(color43);
            styleRunProperties54.Append(fontSize23);
            styleRunProperties54.Append(fontSizeComplexScript23);

            style64.Append(styleName64);
            style64.Append(basedOn55);
            style64.Append(linkedStyle46);
            style64.Append(uIPriority62);
            style64.Append(semiHidden40);
            style64.Append(rsid69);
            style64.Append(styleRunProperties54);

            Style style65 = new Style() { Type = StyleValues.Paragraph, StyleId = "Legenda" };
            StyleName styleName65 = new StyleName() { Val = "caption" };
            BasedOn basedOn56 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle25 = new NextParagraphStyle() { Val = "Normalny" };
            UIPriority uIPriority63 = new UIPriority() { Val = 35 };
            SemiHidden semiHidden41 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed25 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle36 = new PrimaryStyle();
            Rsid rsid70 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties26 = new StyleParagraphProperties();
            SpacingBetweenLines spacingBetweenLines25 = new SpacingBetweenLines() { Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties26.Append(spacingBetweenLines25);

            StyleRunProperties styleRunProperties55 = new StyleRunProperties();
            Bold bold24 = new Bold();
            BoldComplexScript boldComplexScript24 = new BoldComplexScript();
            Color color44 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            FontSize fontSize24 = new FontSize() { Val = "18" };
            FontSizeComplexScript fontSizeComplexScript24 = new FontSizeComplexScript() { Val = "18" };

            styleRunProperties55.Append(bold24);
            styleRunProperties55.Append(boldComplexScript24);
            styleRunProperties55.Append(color44);
            styleRunProperties55.Append(fontSize24);
            styleRunProperties55.Append(fontSizeComplexScript24);

            style65.Append(styleName65);
            style65.Append(basedOn56);
            style65.Append(nextParagraphStyle25);
            style65.Append(uIPriority63);
            style65.Append(semiHidden41);
            style65.Append(unhideWhenUsed25);
            style65.Append(primaryStyle36);
            style65.Append(rsid70);
            style65.Append(styleParagraphProperties26);
            style65.Append(styleRunProperties55);

            Style style66 = new Style() { Type = StyleValues.Paragraph, StyleId = "Tytu" };
            StyleName styleName66 = new StyleName() { Val = "Title" };
            BasedOn basedOn57 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle26 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle47 = new LinkedStyle() { Val = "TytuZnak" };
            UIPriority uIPriority64 = new UIPriority() { Val = 10 };
            PrimaryStyle primaryStyle37 = new PrimaryStyle();
            Rsid rsid71 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties27 = new StyleParagraphProperties();

            ParagraphBorders paragraphBorders3 = new ParagraphBorders();
            BottomBorder bottomBorder3 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", ThemeColor = ThemeColorValues.Text1, Size = (UInt32Value)8U, Space = (UInt32Value)1U };

            paragraphBorders3.Append(bottomBorder3);
            SpacingBetweenLines spacingBetweenLines26 = new SpacingBetweenLines() { After = "300", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            ContextualSpacing contextualSpacing3 = new ContextualSpacing();

            styleParagraphProperties27.Append(paragraphBorders3);
            styleParagraphProperties27.Append(spacingBetweenLines26);
            styleParagraphProperties27.Append(contextualSpacing3);

            StyleRunProperties styleRunProperties56 = new StyleRunProperties();
            RunFonts runFonts47 = new RunFonts() { EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Spacing spacing7 = new Spacing() { Val = 5 };
            Kern kern3 = new Kern() { Val = (UInt32Value)28U };
            FontSize fontSize25 = new FontSize() { Val = "36" };
            FontSizeComplexScript fontSizeComplexScript25 = new FontSizeComplexScript() { Val = "52" };

            styleRunProperties56.Append(runFonts47);
            styleRunProperties56.Append(spacing7);
            styleRunProperties56.Append(kern3);
            styleRunProperties56.Append(fontSize25);
            styleRunProperties56.Append(fontSizeComplexScript25);

            style66.Append(styleName66);
            style66.Append(basedOn57);
            style66.Append(nextParagraphStyle26);
            style66.Append(linkedStyle47);
            style66.Append(uIPriority64);
            style66.Append(primaryStyle37);
            style66.Append(rsid71);
            style66.Append(styleParagraphProperties27);
            style66.Append(styleRunProperties56);

            Style style67 = new Style() { Type = StyleValues.Character, StyleId = "TytuZnak", CustomStyle = true };
            StyleName styleName67 = new StyleName() { Val = "Tytuł Znak" };
            BasedOn basedOn58 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle48 = new LinkedStyle() { Val = "Tytu" };
            UIPriority uIPriority65 = new UIPriority() { Val = 10 };
            Rsid rsid72 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties57 = new StyleRunProperties();
            RunFonts runFonts48 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Spacing spacing8 = new Spacing() { Val = 5 };
            Kern kern4 = new Kern() { Val = (UInt32Value)28U };
            FontSize fontSize26 = new FontSize() { Val = "36" };
            FontSizeComplexScript fontSizeComplexScript26 = new FontSizeComplexScript() { Val = "52" };

            styleRunProperties57.Append(runFonts48);
            styleRunProperties57.Append(spacing8);
            styleRunProperties57.Append(kern4);
            styleRunProperties57.Append(fontSize26);
            styleRunProperties57.Append(fontSizeComplexScript26);

            style67.Append(styleName67);
            style67.Append(basedOn58);
            style67.Append(linkedStyle48);
            style67.Append(uIPriority65);
            style67.Append(rsid72);
            style67.Append(styleRunProperties57);

            Style style68 = new Style() { Type = StyleValues.Paragraph, StyleId = "Podtytu" };
            StyleName styleName68 = new StyleName() { Val = "Subtitle" };
            BasedOn basedOn59 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle27 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle49 = new LinkedStyle() { Val = "PodtytuZnak" };
            UIPriority uIPriority66 = new UIPriority() { Val = 11 };
            PrimaryStyle primaryStyle38 = new PrimaryStyle();
            Rsid rsid73 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties28 = new StyleParagraphProperties();

            NumberingProperties numberingProperties2 = new NumberingProperties();
            NumberingLevelReference numberingLevelReference2 = new NumberingLevelReference() { Val = 1 };

            numberingProperties2.Append(numberingLevelReference2);

            styleParagraphProperties28.Append(numberingProperties2);

            StyleRunProperties styleRunProperties58 = new StyleRunProperties();
            RunFonts runFonts49 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic26 = new Italic();
            ItalicComplexScript italicComplexScript26 = new ItalicComplexScript();
            Color color45 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            Spacing spacing9 = new Spacing() { Val = 15 };
            FontSize fontSize27 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript27 = new FontSizeComplexScript() { Val = "24" };

            styleRunProperties58.Append(runFonts49);
            styleRunProperties58.Append(italic26);
            styleRunProperties58.Append(italicComplexScript26);
            styleRunProperties58.Append(color45);
            styleRunProperties58.Append(spacing9);
            styleRunProperties58.Append(fontSize27);
            styleRunProperties58.Append(fontSizeComplexScript27);

            style68.Append(styleName68);
            style68.Append(basedOn59);
            style68.Append(nextParagraphStyle27);
            style68.Append(linkedStyle49);
            style68.Append(uIPriority66);
            style68.Append(primaryStyle38);
            style68.Append(rsid73);
            style68.Append(styleParagraphProperties28);
            style68.Append(styleRunProperties58);

            Style style69 = new Style() { Type = StyleValues.Character, StyleId = "PodtytuZnak", CustomStyle = true };
            StyleName styleName69 = new StyleName() { Val = "Podtytuł Znak" };
            BasedOn basedOn60 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle50 = new LinkedStyle() { Val = "Podtytu" };
            UIPriority uIPriority67 = new UIPriority() { Val = 11 };
            Rsid rsid74 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties59 = new StyleRunProperties();
            RunFonts runFonts50 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
            Italic italic27 = new Italic();
            ItalicComplexScript italicComplexScript27 = new ItalicComplexScript();
            Color color46 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
            Spacing spacing10 = new Spacing() { Val = 15 };
            FontSize fontSize28 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript28 = new FontSizeComplexScript() { Val = "24" };

            styleRunProperties59.Append(runFonts50);
            styleRunProperties59.Append(italic27);
            styleRunProperties59.Append(italicComplexScript27);
            styleRunProperties59.Append(color46);
            styleRunProperties59.Append(spacing10);
            styleRunProperties59.Append(fontSize28);
            styleRunProperties59.Append(fontSizeComplexScript28);

            style69.Append(styleName69);
            style69.Append(basedOn60);
            style69.Append(linkedStyle50);
            style69.Append(uIPriority67);
            style69.Append(rsid74);
            style69.Append(styleRunProperties59);

            Style style70 = new Style() { Type = StyleValues.Character, StyleId = "Pogrubienie" };
            StyleName styleName70 = new StyleName() { Val = "Strong" };
            BasedOn basedOn61 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority68 = new UIPriority() { Val = 22 };
            PrimaryStyle primaryStyle39 = new PrimaryStyle();
            Rsid rsid75 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties60 = new StyleRunProperties();
            Bold bold25 = new Bold();
            BoldComplexScript boldComplexScript25 = new BoldComplexScript();

            styleRunProperties60.Append(bold25);
            styleRunProperties60.Append(boldComplexScript25);

            style70.Append(styleName70);
            style70.Append(basedOn61);
            style70.Append(uIPriority68);
            style70.Append(primaryStyle39);
            style70.Append(rsid75);
            style70.Append(styleRunProperties60);

            Style style71 = new Style() { Type = StyleValues.Character, StyleId = "Uwydatnienie" };
            StyleName styleName71 = new StyleName() { Val = "Emphasis" };
            BasedOn basedOn62 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority69 = new UIPriority() { Val = 20 };
            PrimaryStyle primaryStyle40 = new PrimaryStyle();
            Rsid rsid76 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties61 = new StyleRunProperties();
            Italic italic28 = new Italic();
            ItalicComplexScript italicComplexScript28 = new ItalicComplexScript();

            styleRunProperties61.Append(italic28);
            styleRunProperties61.Append(italicComplexScript28);

            style71.Append(styleName71);
            style71.Append(basedOn62);
            style71.Append(uIPriority69);
            style71.Append(primaryStyle40);
            style71.Append(rsid76);
            style71.Append(styleRunProperties61);

            Style style72 = new Style() { Type = StyleValues.Paragraph, StyleId = "Bezodstpw" };
            StyleName styleName72 = new StyleName() { Val = "No Spacing" };
            LinkedStyle linkedStyle51 = new LinkedStyle() { Val = "BezodstpwZnak" };
            UIPriority uIPriority70 = new UIPriority() { Val = 1 };
            PrimaryStyle primaryStyle41 = new PrimaryStyle();
            Rsid rsid77 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties29 = new StyleParagraphProperties();
            SpacingBetweenLines spacingBetweenLines27 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties29.Append(spacingBetweenLines27);

            style72.Append(styleName72);
            style72.Append(linkedStyle51);
            style72.Append(uIPriority70);
            style72.Append(primaryStyle41);
            style72.Append(rsid77);
            style72.Append(styleParagraphProperties29);

            Style style73 = new Style() { Type = StyleValues.Character, StyleId = "BezodstpwZnak", CustomStyle = true };
            StyleName styleName73 = new StyleName() { Val = "Bez odstępów Znak" };
            BasedOn basedOn63 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle52 = new LinkedStyle() { Val = "Bezodstpw" };
            UIPriority uIPriority71 = new UIPriority() { Val = 1 };
            Rsid rsid78 = new Rsid() { Val = "0001417F" };

            style73.Append(styleName73);
            style73.Append(basedOn63);
            style73.Append(linkedStyle52);
            style73.Append(uIPriority71);
            style73.Append(rsid78);

            Style style74 = new Style() { Type = StyleValues.Paragraph, StyleId = "Akapitzlist" };
            StyleName styleName74 = new StyleName() { Val = "List Paragraph" };
            BasedOn basedOn64 = new BasedOn() { Val = "Normalny" };
            UIPriority uIPriority72 = new UIPriority() { Val = 34 };
            PrimaryStyle primaryStyle42 = new PrimaryStyle();
            Rsid rsid79 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties30 = new StyleParagraphProperties();
            Indentation indentation3 = new Indentation() { Left = "720" };
            ContextualSpacing contextualSpacing4 = new ContextualSpacing();

            styleParagraphProperties30.Append(indentation3);
            styleParagraphProperties30.Append(contextualSpacing4);

            style74.Append(styleName74);
            style74.Append(basedOn64);
            style74.Append(uIPriority72);
            style74.Append(primaryStyle42);
            style74.Append(rsid79);
            style74.Append(styleParagraphProperties30);

            Style style75 = new Style() { Type = StyleValues.Paragraph, StyleId = "Cytat" };
            StyleName styleName75 = new StyleName() { Val = "Quote" };
            BasedOn basedOn65 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle28 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle53 = new LinkedStyle() { Val = "CytatZnak" };
            UIPriority uIPriority73 = new UIPriority() { Val = 29 };
            PrimaryStyle primaryStyle43 = new PrimaryStyle();
            Rsid rsid80 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties62 = new StyleRunProperties();
            RunFonts runFonts51 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi };
            Italic italic29 = new Italic();
            ItalicComplexScript italicComplexScript29 = new ItalicComplexScript();
            Color color47 = new Color() { Val = "000000", ThemeColor = ThemeColorValues.Text1 };

            styleRunProperties62.Append(runFonts51);
            styleRunProperties62.Append(italic29);
            styleRunProperties62.Append(italicComplexScript29);
            styleRunProperties62.Append(color47);

            style75.Append(styleName75);
            style75.Append(basedOn65);
            style75.Append(nextParagraphStyle28);
            style75.Append(linkedStyle53);
            style75.Append(uIPriority73);
            style75.Append(primaryStyle43);
            style75.Append(rsid80);
            style75.Append(styleRunProperties62);

            Style style76 = new Style() { Type = StyleValues.Character, StyleId = "CytatZnak", CustomStyle = true };
            StyleName styleName76 = new StyleName() { Val = "Cytat Znak" };
            BasedOn basedOn66 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle54 = new LinkedStyle() { Val = "Cytat" };
            UIPriority uIPriority74 = new UIPriority() { Val = 29 };
            Rsid rsid81 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties63 = new StyleRunProperties();
            Italic italic30 = new Italic();
            ItalicComplexScript italicComplexScript30 = new ItalicComplexScript();
            Color color48 = new Color() { Val = "000000", ThemeColor = ThemeColorValues.Text1 };

            styleRunProperties63.Append(italic30);
            styleRunProperties63.Append(italicComplexScript30);
            styleRunProperties63.Append(color48);

            style76.Append(styleName76);
            style76.Append(basedOn66);
            style76.Append(linkedStyle54);
            style76.Append(uIPriority74);
            style76.Append(rsid81);
            style76.Append(styleRunProperties63);

            Style style77 = new Style() { Type = StyleValues.Paragraph, StyleId = "Cytatintensywny" };
            StyleName styleName77 = new StyleName() { Val = "Intense Quote" };
            BasedOn basedOn67 = new BasedOn() { Val = "Normalny" };
            NextParagraphStyle nextParagraphStyle29 = new NextParagraphStyle() { Val = "Normalny" };
            LinkedStyle linkedStyle55 = new LinkedStyle() { Val = "CytatintensywnyZnak" };
            UIPriority uIPriority75 = new UIPriority() { Val = 30 };
            PrimaryStyle primaryStyle44 = new PrimaryStyle();
            Rsid rsid82 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties31 = new StyleParagraphProperties();

            ParagraphBorders paragraphBorders4 = new ParagraphBorders();
            BottomBorder bottomBorder4 = new BottomBorder() { Val = BorderValues.Single, Color = "4F81BD", ThemeColor = ThemeColorValues.Accent1, Size = (UInt32Value)4U, Space = (UInt32Value)4U };

            paragraphBorders4.Append(bottomBorder4);
            SpacingBetweenLines spacingBetweenLines28 = new SpacingBetweenLines() { Before = "200", After = "280" };
            Indentation indentation4 = new Indentation() { Left = "936", Right = "936" };

            styleParagraphProperties31.Append(paragraphBorders4);
            styleParagraphProperties31.Append(spacingBetweenLines28);
            styleParagraphProperties31.Append(indentation4);

            StyleRunProperties styleRunProperties64 = new StyleRunProperties();
            RunFonts runFonts52 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi };
            Bold bold26 = new Bold();
            BoldComplexScript boldComplexScript26 = new BoldComplexScript();
            Italic italic31 = new Italic();
            ItalicComplexScript italicComplexScript31 = new ItalicComplexScript();
            Color color49 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties64.Append(runFonts52);
            styleRunProperties64.Append(bold26);
            styleRunProperties64.Append(boldComplexScript26);
            styleRunProperties64.Append(italic31);
            styleRunProperties64.Append(italicComplexScript31);
            styleRunProperties64.Append(color49);

            style77.Append(styleName77);
            style77.Append(basedOn67);
            style77.Append(nextParagraphStyle29);
            style77.Append(linkedStyle55);
            style77.Append(uIPriority75);
            style77.Append(primaryStyle44);
            style77.Append(rsid82);
            style77.Append(styleParagraphProperties31);
            style77.Append(styleRunProperties64);

            Style style78 = new Style() { Type = StyleValues.Character, StyleId = "CytatintensywnyZnak", CustomStyle = true };
            StyleName styleName78 = new StyleName() { Val = "Cytat intensywny Znak" };
            BasedOn basedOn68 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            LinkedStyle linkedStyle56 = new LinkedStyle() { Val = "Cytatintensywny" };
            UIPriority uIPriority76 = new UIPriority() { Val = 30 };
            Rsid rsid83 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties65 = new StyleRunProperties();
            Bold bold27 = new Bold();
            BoldComplexScript boldComplexScript27 = new BoldComplexScript();
            Italic italic32 = new Italic();
            ItalicComplexScript italicComplexScript32 = new ItalicComplexScript();
            Color color50 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties65.Append(bold27);
            styleRunProperties65.Append(boldComplexScript27);
            styleRunProperties65.Append(italic32);
            styleRunProperties65.Append(italicComplexScript32);
            styleRunProperties65.Append(color50);

            style78.Append(styleName78);
            style78.Append(basedOn68);
            style78.Append(linkedStyle56);
            style78.Append(uIPriority76);
            style78.Append(rsid83);
            style78.Append(styleRunProperties65);

            Style style79 = new Style() { Type = StyleValues.Character, StyleId = "Wyrnieniedelikatne" };
            StyleName styleName79 = new StyleName() { Val = "Subtle Emphasis" };
            BasedOn basedOn69 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority77 = new UIPriority() { Val = 19 };
            PrimaryStyle primaryStyle45 = new PrimaryStyle();
            Rsid rsid84 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties66 = new StyleRunProperties();
            Italic italic33 = new Italic();
            ItalicComplexScript italicComplexScript33 = new ItalicComplexScript();
            Color color51 = new Color() { Val = "808080", ThemeColor = ThemeColorValues.Text1, ThemeTint = "7F" };

            styleRunProperties66.Append(italic33);
            styleRunProperties66.Append(italicComplexScript33);
            styleRunProperties66.Append(color51);

            style79.Append(styleName79);
            style79.Append(basedOn69);
            style79.Append(uIPriority77);
            style79.Append(primaryStyle45);
            style79.Append(rsid84);
            style79.Append(styleRunProperties66);

            Style style80 = new Style() { Type = StyleValues.Character, StyleId = "Wyrnienieintensywne" };
            StyleName styleName80 = new StyleName() { Val = "Intense Emphasis" };
            BasedOn basedOn70 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority78 = new UIPriority() { Val = 21 };
            PrimaryStyle primaryStyle46 = new PrimaryStyle();
            Rsid rsid85 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties67 = new StyleRunProperties();
            Bold bold28 = new Bold();
            BoldComplexScript boldComplexScript28 = new BoldComplexScript();
            Italic italic34 = new Italic();
            ItalicComplexScript italicComplexScript34 = new ItalicComplexScript();
            Color color52 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };

            styleRunProperties67.Append(bold28);
            styleRunProperties67.Append(boldComplexScript28);
            styleRunProperties67.Append(italic34);
            styleRunProperties67.Append(italicComplexScript34);
            styleRunProperties67.Append(color52);

            style80.Append(styleName80);
            style80.Append(basedOn70);
            style80.Append(uIPriority78);
            style80.Append(primaryStyle46);
            style80.Append(rsid85);
            style80.Append(styleRunProperties67);

            Style style81 = new Style() { Type = StyleValues.Character, StyleId = "Odwoaniedelikatne" };
            StyleName styleName81 = new StyleName() { Val = "Subtle Reference" };
            BasedOn basedOn71 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority79 = new UIPriority() { Val = 31 };
            PrimaryStyle primaryStyle47 = new PrimaryStyle();
            Rsid rsid86 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties68 = new StyleRunProperties();
            SmallCaps smallCaps4 = new SmallCaps();
            Color color53 = new Color() { Val = "C0504D", ThemeColor = ThemeColorValues.Accent2 };
            Underline underline3 = new Underline() { Val = UnderlineValues.Single };

            styleRunProperties68.Append(smallCaps4);
            styleRunProperties68.Append(color53);
            styleRunProperties68.Append(underline3);

            style81.Append(styleName81);
            style81.Append(basedOn71);
            style81.Append(uIPriority79);
            style81.Append(primaryStyle47);
            style81.Append(rsid86);
            style81.Append(styleRunProperties68);

            Style style82 = new Style() { Type = StyleValues.Character, StyleId = "Odwoanieintensywne" };
            StyleName styleName82 = new StyleName() { Val = "Intense Reference" };
            BasedOn basedOn72 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority80 = new UIPriority() { Val = 32 };
            PrimaryStyle primaryStyle48 = new PrimaryStyle();
            Rsid rsid87 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties69 = new StyleRunProperties();
            Bold bold29 = new Bold();
            BoldComplexScript boldComplexScript29 = new BoldComplexScript();
            SmallCaps smallCaps5 = new SmallCaps();
            Color color54 = new Color() { Val = "C0504D", ThemeColor = ThemeColorValues.Accent2 };
            Spacing spacing11 = new Spacing() { Val = 5 };
            Underline underline4 = new Underline() { Val = UnderlineValues.Single };

            styleRunProperties69.Append(bold29);
            styleRunProperties69.Append(boldComplexScript29);
            styleRunProperties69.Append(smallCaps5);
            styleRunProperties69.Append(color54);
            styleRunProperties69.Append(spacing11);
            styleRunProperties69.Append(underline4);

            style82.Append(styleName82);
            style82.Append(basedOn72);
            style82.Append(uIPriority80);
            style82.Append(primaryStyle48);
            style82.Append(rsid87);
            style82.Append(styleRunProperties69);

            Style style83 = new Style() { Type = StyleValues.Character, StyleId = "Tytuksiki" };
            StyleName styleName83 = new StyleName() { Val = "Book Title" };
            BasedOn basedOn73 = new BasedOn() { Val = "Domylnaczcionkaakapitu" };
            UIPriority uIPriority81 = new UIPriority() { Val = 33 };
            PrimaryStyle primaryStyle49 = new PrimaryStyle();
            Rsid rsid88 = new Rsid() { Val = "0001417F" };

            StyleRunProperties styleRunProperties70 = new StyleRunProperties();
            Bold bold30 = new Bold();
            BoldComplexScript boldComplexScript30 = new BoldComplexScript();
            SmallCaps smallCaps6 = new SmallCaps();
            Spacing spacing12 = new Spacing() { Val = 5 };

            styleRunProperties70.Append(bold30);
            styleRunProperties70.Append(boldComplexScript30);
            styleRunProperties70.Append(smallCaps6);
            styleRunProperties70.Append(spacing12);

            style83.Append(styleName83);
            style83.Append(basedOn73);
            style83.Append(uIPriority81);
            style83.Append(primaryStyle49);
            style83.Append(rsid88);
            style83.Append(styleRunProperties70);

            Style style84 = new Style() { Type = StyleValues.Paragraph, StyleId = "Nagwekspisutreci" };
            StyleName styleName84 = new StyleName() { Val = "TOC Heading" };
            BasedOn basedOn74 = new BasedOn() { Val = "Nagwek1" };
            NextParagraphStyle nextParagraphStyle30 = new NextParagraphStyle() { Val = "Normalny" };
            UIPriority uIPriority82 = new UIPriority() { Val = 39 };
            SemiHidden semiHidden42 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed26 = new UnhideWhenUsed();
            PrimaryStyle primaryStyle50 = new PrimaryStyle();
            Rsid rsid89 = new Rsid() { Val = "0001417F" };

            StyleParagraphProperties styleParagraphProperties32 = new StyleParagraphProperties();
            OutlineLevel outlineLevel20 = new OutlineLevel() { Val = 9 };

            styleParagraphProperties32.Append(outlineLevel20);

            style84.Append(styleName84);
            style84.Append(basedOn74);
            style84.Append(nextParagraphStyle30);
            style84.Append(uIPriority82);
            style84.Append(semiHidden42);
            style84.Append(unhideWhenUsed26);
            style84.Append(primaryStyle50);
            style84.Append(rsid89);
            style84.Append(styleParagraphProperties32);

            styles2.Append(docDefaults2);
            styles2.Append(latentStyles2);
            styles2.Append(style43);
            styles2.Append(style44);
            styles2.Append(style45);
            styles2.Append(style46);
            styles2.Append(style47);
            styles2.Append(style48);
            styles2.Append(style49);
            styles2.Append(style50);
            styles2.Append(style51);
            styles2.Append(style52);
            styles2.Append(style53);
            styles2.Append(style54);
            styles2.Append(style55);
            styles2.Append(style56);
            styles2.Append(style57);
            styles2.Append(style58);
            styles2.Append(style59);
            styles2.Append(style60);
            styles2.Append(style61);
            styles2.Append(style62);
            styles2.Append(style63);
            styles2.Append(style64);
            styles2.Append(style65);
            styles2.Append(style66);
            styles2.Append(style67);
            styles2.Append(style68);
            styles2.Append(style69);
            styles2.Append(style70);
            styles2.Append(style71);
            styles2.Append(style72);
            styles2.Append(style73);
            styles2.Append(style74);
            styles2.Append(style75);
            styles2.Append(style76);
            styles2.Append(style77);
            styles2.Append(style78);
            styles2.Append(style79);
            styles2.Append(style80);
            styles2.Append(style81);
            styles2.Append(style82);
            styles2.Append(style83);
            styles2.Append(style84);

            styleDefinitionsPart1.Styles = styles2;
        }

        // Generates content of themePart1.
        private static void GenerateThemePart1Content(ThemePart themePart1)
        {
            A.Theme theme1 = new A.Theme() { Name = "Motyw pakietu Office" };
            theme1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.ThemeElements themeElements1 = new A.ThemeElements();

            A.ColorScheme colorScheme1 = new A.ColorScheme() { Name = "Pakiet Office" };

            A.Dark1Color dark1Color1 = new A.Dark1Color();
            A.SystemColor systemColor1 = new A.SystemColor() { Val = A.SystemColorValues.WindowText, LastColor = "000000" };

            dark1Color1.Append(systemColor1);

            A.Light1Color light1Color1 = new A.Light1Color();
            A.SystemColor systemColor2 = new A.SystemColor() { Val = A.SystemColorValues.Window, LastColor = "FFFFFF" };

            light1Color1.Append(systemColor2);

            A.Dark2Color dark2Color1 = new A.Dark2Color();
            A.RgbColorModelHex rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "1F497D" };

            dark2Color1.Append(rgbColorModelHex1);

            A.Light2Color light2Color1 = new A.Light2Color();
            A.RgbColorModelHex rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "EEECE1" };

            light2Color1.Append(rgbColorModelHex2);

            A.Accent1Color accent1Color1 = new A.Accent1Color();
            A.RgbColorModelHex rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "4F81BD" };

            accent1Color1.Append(rgbColorModelHex3);

            A.Accent2Color accent2Color1 = new A.Accent2Color();
            A.RgbColorModelHex rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "C0504D" };

            accent2Color1.Append(rgbColorModelHex4);

            A.Accent3Color accent3Color1 = new A.Accent3Color();
            A.RgbColorModelHex rgbColorModelHex5 = new A.RgbColorModelHex() { Val = "9BBB59" };

            accent3Color1.Append(rgbColorModelHex5);

            A.Accent4Color accent4Color1 = new A.Accent4Color();
            A.RgbColorModelHex rgbColorModelHex6 = new A.RgbColorModelHex() { Val = "8064A2" };

            accent4Color1.Append(rgbColorModelHex6);

            A.Accent5Color accent5Color1 = new A.Accent5Color();
            A.RgbColorModelHex rgbColorModelHex7 = new A.RgbColorModelHex() { Val = "4BACC6" };

            accent5Color1.Append(rgbColorModelHex7);

            A.Accent6Color accent6Color1 = new A.Accent6Color();
            A.RgbColorModelHex rgbColorModelHex8 = new A.RgbColorModelHex() { Val = "F79646" };

            accent6Color1.Append(rgbColorModelHex8);

            A.Hyperlink hyperlink1 = new A.Hyperlink();
            A.RgbColorModelHex rgbColorModelHex9 = new A.RgbColorModelHex() { Val = "0000FF" };

            hyperlink1.Append(rgbColorModelHex9);

            A.FollowedHyperlinkColor followedHyperlinkColor1 = new A.FollowedHyperlinkColor();
            A.RgbColorModelHex rgbColorModelHex10 = new A.RgbColorModelHex() { Val = "800080" };

            followedHyperlinkColor1.Append(rgbColorModelHex10);

            colorScheme1.Append(dark1Color1);
            colorScheme1.Append(light1Color1);
            colorScheme1.Append(dark2Color1);
            colorScheme1.Append(light2Color1);
            colorScheme1.Append(accent1Color1);
            colorScheme1.Append(accent2Color1);
            colorScheme1.Append(accent3Color1);
            colorScheme1.Append(accent4Color1);
            colorScheme1.Append(accent5Color1);
            colorScheme1.Append(accent6Color1);
            colorScheme1.Append(hyperlink1);
            colorScheme1.Append(followedHyperlinkColor1);

            A.FontScheme fontScheme1 = new A.FontScheme() { Name = "Pakiet Office" };

            A.MajorFont majorFont1 = new A.MajorFont();
            A.LatinFont latinFont1 = new A.LatinFont() { Typeface = "Cambria" };
            A.EastAsianFont eastAsianFont1 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont1 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont1 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ ゴシック" };
            A.SupplementalFont supplementalFont2 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont3 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
            A.SupplementalFont supplementalFont4 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont5 = new A.SupplementalFont() { Script = "Arab", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont6 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont7 = new A.SupplementalFont() { Script = "Thai", Typeface = "Angsana New" };
            A.SupplementalFont supplementalFont8 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont9 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont10 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont11 = new A.SupplementalFont() { Script = "Khmr", Typeface = "MoolBoran" };
            A.SupplementalFont supplementalFont12 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont13 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont14 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont15 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont16 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont17 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont18 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont19 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont20 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont21 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont22 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont23 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont24 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont25 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont26 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont27 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont28 = new A.SupplementalFont() { Script = "Viet", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont29 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont30 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            majorFont1.Append(latinFont1);
            majorFont1.Append(eastAsianFont1);
            majorFont1.Append(complexScriptFont1);
            majorFont1.Append(supplementalFont1);
            majorFont1.Append(supplementalFont2);
            majorFont1.Append(supplementalFont3);
            majorFont1.Append(supplementalFont4);
            majorFont1.Append(supplementalFont5);
            majorFont1.Append(supplementalFont6);
            majorFont1.Append(supplementalFont7);
            majorFont1.Append(supplementalFont8);
            majorFont1.Append(supplementalFont9);
            majorFont1.Append(supplementalFont10);
            majorFont1.Append(supplementalFont11);
            majorFont1.Append(supplementalFont12);
            majorFont1.Append(supplementalFont13);
            majorFont1.Append(supplementalFont14);
            majorFont1.Append(supplementalFont15);
            majorFont1.Append(supplementalFont16);
            majorFont1.Append(supplementalFont17);
            majorFont1.Append(supplementalFont18);
            majorFont1.Append(supplementalFont19);
            majorFont1.Append(supplementalFont20);
            majorFont1.Append(supplementalFont21);
            majorFont1.Append(supplementalFont22);
            majorFont1.Append(supplementalFont23);
            majorFont1.Append(supplementalFont24);
            majorFont1.Append(supplementalFont25);
            majorFont1.Append(supplementalFont26);
            majorFont1.Append(supplementalFont27);
            majorFont1.Append(supplementalFont28);
            majorFont1.Append(supplementalFont29);
            majorFont1.Append(supplementalFont30);

            A.MinorFont minorFont1 = new A.MinorFont();
            A.LatinFont latinFont2 = new A.LatinFont() { Typeface = "Calibri" };
            A.EastAsianFont eastAsianFont2 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont2 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont31 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ 明朝" };
            A.SupplementalFont supplementalFont32 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont33 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
            A.SupplementalFont supplementalFont34 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont35 = new A.SupplementalFont() { Script = "Arab", Typeface = "Arial" };
            A.SupplementalFont supplementalFont36 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Arial" };
            A.SupplementalFont supplementalFont37 = new A.SupplementalFont() { Script = "Thai", Typeface = "Cordia New" };
            A.SupplementalFont supplementalFont38 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont39 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont40 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont41 = new A.SupplementalFont() { Script = "Khmr", Typeface = "DaunPenh" };
            A.SupplementalFont supplementalFont42 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont43 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont44 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont45 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont46 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont47 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont48 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont49 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont50 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont51 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont52 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont53 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont54 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont55 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont56 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont57 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont58 = new A.SupplementalFont() { Script = "Viet", Typeface = "Arial" };
            A.SupplementalFont supplementalFont59 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont60 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            minorFont1.Append(latinFont2);
            minorFont1.Append(eastAsianFont2);
            minorFont1.Append(complexScriptFont2);
            minorFont1.Append(supplementalFont31);
            minorFont1.Append(supplementalFont32);
            minorFont1.Append(supplementalFont33);
            minorFont1.Append(supplementalFont34);
            minorFont1.Append(supplementalFont35);
            minorFont1.Append(supplementalFont36);
            minorFont1.Append(supplementalFont37);
            minorFont1.Append(supplementalFont38);
            minorFont1.Append(supplementalFont39);
            minorFont1.Append(supplementalFont40);
            minorFont1.Append(supplementalFont41);
            minorFont1.Append(supplementalFont42);
            minorFont1.Append(supplementalFont43);
            minorFont1.Append(supplementalFont44);
            minorFont1.Append(supplementalFont45);
            minorFont1.Append(supplementalFont46);
            minorFont1.Append(supplementalFont47);
            minorFont1.Append(supplementalFont48);
            minorFont1.Append(supplementalFont49);
            minorFont1.Append(supplementalFont50);
            minorFont1.Append(supplementalFont51);
            minorFont1.Append(supplementalFont52);
            minorFont1.Append(supplementalFont53);
            minorFont1.Append(supplementalFont54);
            minorFont1.Append(supplementalFont55);
            minorFont1.Append(supplementalFont56);
            minorFont1.Append(supplementalFont57);
            minorFont1.Append(supplementalFont58);
            minorFont1.Append(supplementalFont59);
            minorFont1.Append(supplementalFont60);

            fontScheme1.Append(majorFont1);
            fontScheme1.Append(minorFont1);

            A.FormatScheme formatScheme1 = new A.FormatScheme() { Name = "Pakiet Office" };

            A.FillStyleList fillStyleList1 = new A.FillStyleList();

            A.SolidFill solidFill1 = new A.SolidFill();
            A.SchemeColor schemeColor1 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill1.Append(schemeColor1);

            A.GradientFill gradientFill1 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList1 = new A.GradientStopList();

            A.GradientStop gradientStop1 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor2 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint1 = new A.Tint() { Val = 50000 };
            A.SaturationModulation saturationModulation1 = new A.SaturationModulation() { Val = 300000 };

            schemeColor2.Append(tint1);
            schemeColor2.Append(saturationModulation1);

            gradientStop1.Append(schemeColor2);

            A.GradientStop gradientStop2 = new A.GradientStop() { Position = 35000 };

            A.SchemeColor schemeColor3 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint2 = new A.Tint() { Val = 37000 };
            A.SaturationModulation saturationModulation2 = new A.SaturationModulation() { Val = 300000 };

            schemeColor3.Append(tint2);
            schemeColor3.Append(saturationModulation2);

            gradientStop2.Append(schemeColor3);

            A.GradientStop gradientStop3 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor4 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint3 = new A.Tint() { Val = 15000 };
            A.SaturationModulation saturationModulation3 = new A.SaturationModulation() { Val = 350000 };

            schemeColor4.Append(tint3);
            schemeColor4.Append(saturationModulation3);

            gradientStop3.Append(schemeColor4);

            gradientStopList1.Append(gradientStop1);
            gradientStopList1.Append(gradientStop2);
            gradientStopList1.Append(gradientStop3);
            A.LinearGradientFill linearGradientFill1 = new A.LinearGradientFill() { Angle = 16200000, Scaled = true };

            gradientFill1.Append(gradientStopList1);
            gradientFill1.Append(linearGradientFill1);

            A.GradientFill gradientFill2 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList2 = new A.GradientStopList();

            A.GradientStop gradientStop4 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor5 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade1 = new A.Shade() { Val = 51000 };
            A.SaturationModulation saturationModulation4 = new A.SaturationModulation() { Val = 130000 };

            schemeColor5.Append(shade1);
            schemeColor5.Append(saturationModulation4);

            gradientStop4.Append(schemeColor5);

            A.GradientStop gradientStop5 = new A.GradientStop() { Position = 80000 };

            A.SchemeColor schemeColor6 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade2 = new A.Shade() { Val = 93000 };
            A.SaturationModulation saturationModulation5 = new A.SaturationModulation() { Val = 130000 };

            schemeColor6.Append(shade2);
            schemeColor6.Append(saturationModulation5);

            gradientStop5.Append(schemeColor6);

            A.GradientStop gradientStop6 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor7 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade3 = new A.Shade() { Val = 94000 };
            A.SaturationModulation saturationModulation6 = new A.SaturationModulation() { Val = 135000 };

            schemeColor7.Append(shade3);
            schemeColor7.Append(saturationModulation6);

            gradientStop6.Append(schemeColor7);

            gradientStopList2.Append(gradientStop4);
            gradientStopList2.Append(gradientStop5);
            gradientStopList2.Append(gradientStop6);
            A.LinearGradientFill linearGradientFill2 = new A.LinearGradientFill() { Angle = 16200000, Scaled = false };

            gradientFill2.Append(gradientStopList2);
            gradientFill2.Append(linearGradientFill2);

            fillStyleList1.Append(solidFill1);
            fillStyleList1.Append(gradientFill1);
            fillStyleList1.Append(gradientFill2);

            A.LineStyleList lineStyleList1 = new A.LineStyleList();

            A.Outline outline1 = new A.Outline() { Width = 9525, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill2 = new A.SolidFill();

            A.SchemeColor schemeColor8 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade4 = new A.Shade() { Val = 95000 };
            A.SaturationModulation saturationModulation7 = new A.SaturationModulation() { Val = 105000 };

            schemeColor8.Append(shade4);
            schemeColor8.Append(saturationModulation7);

            solidFill2.Append(schemeColor8);
            A.PresetDash presetDash1 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline1.Append(solidFill2);
            outline1.Append(presetDash1);

            A.Outline outline2 = new A.Outline() { Width = 25400, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill3 = new A.SolidFill();
            A.SchemeColor schemeColor9 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill3.Append(schemeColor9);
            A.PresetDash presetDash2 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline2.Append(solidFill3);
            outline2.Append(presetDash2);

            A.Outline outline3 = new A.Outline() { Width = 38100, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill4 = new A.SolidFill();
            A.SchemeColor schemeColor10 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill4.Append(schemeColor10);
            A.PresetDash presetDash3 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline3.Append(solidFill4);
            outline3.Append(presetDash3);

            lineStyleList1.Append(outline1);
            lineStyleList1.Append(outline2);
            lineStyleList1.Append(outline3);

            A.EffectStyleList effectStyleList1 = new A.EffectStyleList();

            A.EffectStyle effectStyle1 = new A.EffectStyle();

            A.EffectList effectList1 = new A.EffectList();

            A.OuterShadow outerShadow1 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex11 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha1 = new A.Alpha() { Val = 38000 };

            rgbColorModelHex11.Append(alpha1);

            outerShadow1.Append(rgbColorModelHex11);

            effectList1.Append(outerShadow1);

            effectStyle1.Append(effectList1);

            A.EffectStyle effectStyle2 = new A.EffectStyle();

            A.EffectList effectList2 = new A.EffectList();

            A.OuterShadow outerShadow2 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex12 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha2 = new A.Alpha() { Val = 35000 };

            rgbColorModelHex12.Append(alpha2);

            outerShadow2.Append(rgbColorModelHex12);

            effectList2.Append(outerShadow2);

            effectStyle2.Append(effectList2);

            A.EffectStyle effectStyle3 = new A.EffectStyle();

            A.EffectList effectList3 = new A.EffectList();

            A.OuterShadow outerShadow3 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex13 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha3 = new A.Alpha() { Val = 35000 };

            rgbColorModelHex13.Append(alpha3);

            outerShadow3.Append(rgbColorModelHex13);

            effectList3.Append(outerShadow3);

            A.Scene3DType scene3DType1 = new A.Scene3DType();

            A.Camera camera1 = new A.Camera() { Preset = A.PresetCameraValues.OrthographicFront };
            A.Rotation rotation1 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 0 };

            camera1.Append(rotation1);

            A.LightRig lightRig1 = new A.LightRig() { Rig = A.LightRigValues.ThreePoints, Direction = A.LightRigDirectionValues.Top };
            A.Rotation rotation2 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 1200000 };

            lightRig1.Append(rotation2);

            scene3DType1.Append(camera1);
            scene3DType1.Append(lightRig1);

            A.Shape3DType shape3DType1 = new A.Shape3DType();
            A.BevelTop bevelTop1 = new A.BevelTop() { Width = 63500L, Height = 25400L };

            shape3DType1.Append(bevelTop1);

            effectStyle3.Append(effectList3);
            effectStyle3.Append(scene3DType1);
            effectStyle3.Append(shape3DType1);

            effectStyleList1.Append(effectStyle1);
            effectStyleList1.Append(effectStyle2);
            effectStyleList1.Append(effectStyle3);

            A.BackgroundFillStyleList backgroundFillStyleList1 = new A.BackgroundFillStyleList();

            A.SolidFill solidFill5 = new A.SolidFill();
            A.SchemeColor schemeColor11 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill5.Append(schemeColor11);

            A.GradientFill gradientFill3 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList3 = new A.GradientStopList();

            A.GradientStop gradientStop7 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor12 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint4 = new A.Tint() { Val = 40000 };
            A.SaturationModulation saturationModulation8 = new A.SaturationModulation() { Val = 350000 };

            schemeColor12.Append(tint4);
            schemeColor12.Append(saturationModulation8);

            gradientStop7.Append(schemeColor12);

            A.GradientStop gradientStop8 = new A.GradientStop() { Position = 40000 };

            A.SchemeColor schemeColor13 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint5 = new A.Tint() { Val = 45000 };
            A.Shade shade5 = new A.Shade() { Val = 99000 };
            A.SaturationModulation saturationModulation9 = new A.SaturationModulation() { Val = 350000 };

            schemeColor13.Append(tint5);
            schemeColor13.Append(shade5);
            schemeColor13.Append(saturationModulation9);

            gradientStop8.Append(schemeColor13);

            A.GradientStop gradientStop9 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor14 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade6 = new A.Shade() { Val = 20000 };
            A.SaturationModulation saturationModulation10 = new A.SaturationModulation() { Val = 255000 };

            schemeColor14.Append(shade6);
            schemeColor14.Append(saturationModulation10);

            gradientStop9.Append(schemeColor14);

            gradientStopList3.Append(gradientStop7);
            gradientStopList3.Append(gradientStop8);
            gradientStopList3.Append(gradientStop9);

            A.PathGradientFill pathGradientFill1 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
            A.FillToRectangle fillToRectangle1 = new A.FillToRectangle() { Left = 50000, Top = -80000, Right = 50000, Bottom = 180000 };

            pathGradientFill1.Append(fillToRectangle1);

            gradientFill3.Append(gradientStopList3);
            gradientFill3.Append(pathGradientFill1);

            A.GradientFill gradientFill4 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList4 = new A.GradientStopList();

            A.GradientStop gradientStop10 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor15 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint6 = new A.Tint() { Val = 80000 };
            A.SaturationModulation saturationModulation11 = new A.SaturationModulation() { Val = 300000 };

            schemeColor15.Append(tint6);
            schemeColor15.Append(saturationModulation11);

            gradientStop10.Append(schemeColor15);

            A.GradientStop gradientStop11 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor16 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade7 = new A.Shade() { Val = 30000 };
            A.SaturationModulation saturationModulation12 = new A.SaturationModulation() { Val = 200000 };

            schemeColor16.Append(shade7);
            schemeColor16.Append(saturationModulation12);

            gradientStop11.Append(schemeColor16);

            gradientStopList4.Append(gradientStop10);
            gradientStopList4.Append(gradientStop11);

            A.PathGradientFill pathGradientFill2 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
            A.FillToRectangle fillToRectangle2 = new A.FillToRectangle() { Left = 50000, Top = 50000, Right = 50000, Bottom = 50000 };

            pathGradientFill2.Append(fillToRectangle2);

            gradientFill4.Append(gradientStopList4);
            gradientFill4.Append(pathGradientFill2);

            backgroundFillStyleList1.Append(solidFill5);
            backgroundFillStyleList1.Append(gradientFill3);
            backgroundFillStyleList1.Append(gradientFill4);

            formatScheme1.Append(fillStyleList1);
            formatScheme1.Append(lineStyleList1);
            formatScheme1.Append(effectStyleList1);
            formatScheme1.Append(backgroundFillStyleList1);

            themeElements1.Append(colorScheme1);
            themeElements1.Append(fontScheme1);
            themeElements1.Append(formatScheme1);
            A.ObjectDefaults objectDefaults1 = new A.ObjectDefaults();
            A.ExtraColorSchemeList extraColorSchemeList1 = new A.ExtraColorSchemeList();

            theme1.Append(themeElements1);
            theme1.Append(objectDefaults1);
            theme1.Append(extraColorSchemeList1);

            themePart1.Theme = theme1;
        }

        // Generates content of fontTablePart1.
        private static void GenerateFontTablePart1Content(FontTablePart fontTablePart1)
        {
            Fonts fonts1 = new Fonts() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
            fonts1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            fonts1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            fonts1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            fonts1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");

            Font font1 = new Font() { Name = "Calibri" };
            Panose1Number panose1Number1 = new Panose1Number() { Val = "020F0502020204030204" };
            FontCharSet fontCharSet1 = new FontCharSet() { Val = "EE" };
            FontFamily fontFamily1 = new FontFamily() { Val = FontFamilyValues.Swiss };
            Pitch pitch1 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature1 = new FontSignature() { UnicodeSignature0 = "E00002FF", UnicodeSignature1 = "4000ACFF", UnicodeSignature2 = "00000001", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

            font1.Append(panose1Number1);
            font1.Append(fontCharSet1);
            font1.Append(fontFamily1);
            font1.Append(pitch1);
            font1.Append(fontSignature1);

            Font font2 = new Font() { Name = "Times New Roman" };
            Panose1Number panose1Number2 = new Panose1Number() { Val = "02020603050405020304" };
            FontCharSet fontCharSet2 = new FontCharSet() { Val = "EE" };
            FontFamily fontFamily2 = new FontFamily() { Val = FontFamilyValues.Roman };
            Pitch pitch2 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature2 = new FontSignature() { UnicodeSignature0 = "E0002AFF", UnicodeSignature1 = "C0007841", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

            font2.Append(panose1Number2);
            font2.Append(fontCharSet2);
            font2.Append(fontFamily2);
            font2.Append(pitch2);
            font2.Append(fontSignature2);

            Font font3 = new Font() { Name = "Cambria" };
            Panose1Number panose1Number3 = new Panose1Number() { Val = "02040503050406030204" };
            FontCharSet fontCharSet3 = new FontCharSet() { Val = "EE" };
            FontFamily fontFamily3 = new FontFamily() { Val = FontFamilyValues.Roman };
            Pitch pitch3 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature3 = new FontSignature() { UnicodeSignature0 = "E00002FF", UnicodeSignature1 = "400004FF", UnicodeSignature2 = "00000000", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

            font3.Append(panose1Number3);
            font3.Append(fontCharSet3);
            font3.Append(fontFamily3);
            font3.Append(pitch3);
            font3.Append(fontSignature3);

            fonts1.Append(font1);
            fonts1.Append(font2);
            fonts1.Append(font3);

            fontTablePart1.Fonts = fonts1;
        }

        // Generates content of webSettingsPart1.
        private static void GenerateWebSettingsPart1Content(WebSettingsPart webSettingsPart1)
        {
            WebSettings webSettings1 = new WebSettings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
            webSettings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            webSettings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            webSettings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            webSettings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            OptimizeForBrowser optimizeForBrowser1 = new OptimizeForBrowser();
            AllowPNG allowPNG1 = new AllowPNG();

            webSettings1.Append(optimizeForBrowser1);
            webSettings1.Append(allowPNG1);

            webSettingsPart1.WebSettings = webSettings1;
        }

        private static void SetPackageProperties(OpenXmlPackage document)
        {
            document.PackageProperties.Creator = "ZbyszekB";
            document.PackageProperties.Title = "";
            document.PackageProperties.Subject = "";
            document.PackageProperties.Keywords = "";
            document.PackageProperties.Description = "";
            document.PackageProperties.Revision = "3";
            document.PackageProperties.Created = System.Xml.XmlConvert.ToDateTime("2014-12-03T09:15:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.Modified = System.Xml.XmlConvert.ToDateTime("2014-12-03T09:15:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.LastModifiedBy = "ZbyszekB";
        }


    }

}
