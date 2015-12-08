using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;
using AbakonDataModel.Infrastructure;
using System.ComponentModel.DataAnnotations;
using AbakonDataModel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Text.RegularExpressions;


namespace Abakon15.Reports
{
    public class PopulateWordTemplate
    {

        public static void openWordDocument(PrzyrzadPomiarowy equipmentItem, ref object fileName)
        {

            string strDoc = fileName.ToString();
            ProcessPatternDocument(strDoc, equipmentItem);
        }

        /*
        public static void openWordDocument(PrzyrzadPomiarowy equipmentItem, ref object fileName , bool wylaczony)
        {

            string strDoc = fileName.ToString();
            string strTxt = "Dopisany text";
            OpenAndAddTextToWordDocument(strDoc,  equipmentItem);




            object missing = System.Reflection.Missing.Value;
            object readOnly = false;
            object isVisible = true;


     //       MessageBox.Show( "1openWordDocument - " +   fileName.ToString());

            Word.Application  wordApplication = new Word.Application();
       
            wordApplication.Visible = true;
            Word.Document wordDocument;// = new Microsoft.Office.Interop.Word.Document();

        //    MessageBox.Show("2openWordDocument - " + fileName.ToString());
            try
            {

                wordDocument = wordApplication.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref  missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                wordDocument.Activate();
                Word.Range rng = wordApplication.Selection.Range; //wordDocument.Range(); //.Paragraphs[2].Range;
                List<string> _FieldsList = FieldsForReports.CreateListOfFields(typeof(PrzyrzadPomiarowy)); //Ustawić typ generyczny
                if (_FieldsList.Count > 0)
                {
                    Word.Find fnd = wordApplication.ActiveWindow.Selection.Find;
                   
                    //fnd.ClearFormatting();
                    //fnd.Replacement.ClearFormatting();
                    fnd.Forward = true;
                   
                    fnd.Wrap = Word.WdFindWrap.wdFindContinue;
                    string zz;

                    foreach (string field in _FieldsList)
                    {
                     object o = field;
                    if (rng.Find.Execute(ref o,
                                   ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                                   ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                                   ref missing, ref missing))
                    {

                        zz = GetItemValue(equipmentItem, field);
                        if (zz.Length > 255)
                        {
                             Word.Range rng1 = wordDocument.Range(rng.Start, rng.Start);
                             rng.Find.Replacement.Text = "";
                             rng.Find.Execute(Replace: Word.WdReplace.wdReplaceAll);
                             rng1.InsertAfter(zz);
                        }
                        else
                        {
                            rng.Find.Replacement.Text = GetItemValue(equipmentItem, field);
                            rng.Find.Execute(Replace: Word.WdReplace.wdReplaceAll);
                        }

                    }

                    rng.Find.Forward = true;
                    rng.Find.Wrap = Word.WdFindWrap.wdFindContinue;
                   // rng.Select();
    
                    }
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show (ex.Message );
              //  wordDocument.Application.Quit(ref missing, ref missing, ref missing);
            }
        }
         * */

        //private static object GetItemValue(object source, string item  )
        //{
        //    string result = GetItemValue(source, item, 0);

        //    return result;
        //}

        //private Microsoft.Office.Interop.Word.Table getTableByBookmarkName(Microsoft.Office.Interop.Word.Document doc,   string bookmarkName)
        //{
        //    Microsoft.Office.Interop.Word.Table tbl = doc.Bookmarks[bookmarkName].Range.Tables[1];
        //    if (tbl != null)
        //        return tbl;
        //    else
        //        return null;
        //}


        //private static object GetItemValue1(object source, string field, int pos)
        //{
        //    string sourceName = "";
        //    int dotPosition = field.LastIndexOf(".");
        //    sourceName = field.Substring(0, dotPosition + 1);

        //    string value = "#";
        //  //  if (source.GetType().BaseType.Name == "EQ.")
        //    {
        //        //if (sourceName == "#EQ.")
        //        {  string fld = field.Substring(0, field.Length - 1);
        //            return GetObjectFieldValue<PrzyrzadPomiarowy>(source, fld); 
        //        }
        //        //if (sourceName == "#EQ.ZakresyPomiarowe.")
        //        //{
        //        //    var xxx = ((PrzyrzadPomiarowy)source).zakresyPomiarowe; 
        //        //    return GetObjectFieldValue<PrzyrzadPomiarowy>(xxx, field);
        //        //}

        //    }
        //    return value;
        //}

        private static object GetItemValue<T>(object source, string field)
        {
            string sourceName = "";
            int dotPosition = field.LastIndexOf(".");
            sourceName = field.Substring(0, dotPosition + 1);

            string fld = field.Substring(0, field.Length - 1);
            return GetObjectFieldValue<T>(source, fld);
        }



        private static object FindType<T>(object source, string field)
        {
            object result = null;
            string sourceName = "";
            int dotPosition = field.IndexOf('.');// +1;
            sourceName = field.Substring(0, dotPosition); //"#" + field.Substring(dotPosition).TrimEnd('#');
            Type t = typeof(T);
            var props = t.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(PrintAttribute)));
            foreach (System.Reflection.PropertyInfo item in props) // source.GetType().GetProperties())
            {
                var propName = ((PrintAttribute)item.GetCustomAttributes(typeof(PrintAttribute), false)[0]).PatternName;

                try
                {
                    if (propName == sourceName)
                    {
                        result = item.GetValue(source, null);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + System.Environment.NewLine + ex.InnerException);
                }
            }


            // GetObjectFieldValue (source, field);
            return result;
        }

        //==================================================
        //http://stackoverflow.com/questions/1900353/how-to-get-the-type-contained-in-a-collection-through-reflection

        internal static Type GetElementType(Type seqType)
        {
            Type ienum = FindIEnumerable(seqType);
            if (ienum == null) return seqType;
            return ienum.GetGenericArguments()[0];
        }
        private static Type FindIEnumerable(Type seqType)
        {
            if (seqType == null || seqType == typeof(string))
                return null;
            if (seqType.IsArray)
                return typeof(IEnumerable<>).MakeGenericType(seqType.GetElementType());
            if (seqType.IsGenericType)
            {
                foreach (Type arg in seqType.GetGenericArguments())
                {
                    Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                    if (ienum.IsAssignableFrom(seqType))
                    {
                        return ienum;
                    }
                }
            }
            Type[] ifaces = seqType.GetInterfaces();
            if (ifaces != null && ifaces.Length > 0)
            {
                foreach (Type iface in ifaces)
                {
                    Type ienum = FindIEnumerable(iface);
                    if (ienum != null) return ienum;
                }
            }
            if (seqType.BaseType != null && seqType.BaseType != typeof(object))
            {
                return FindIEnumerable(seqType.BaseType);
            }
            return null;
        }
        //==================================================

        private static object GetObjectFieldValue<T>(object source, string field)
        {
            if (source == null) return "???";
            string value = "???";
            Type t = typeof(T);
            var props = t.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(PrintAttribute)));
            var x = props.FirstOrDefault(p => p.Name == field);
            foreach (System.Reflection.PropertyInfo item in props) // source.GetType().GetProperties())
            {
                var propName = ((PrintAttribute)item.GetCustomAttributes(typeof(PrintAttribute), false)[0]).PatternName;

                try
                {
                    if (propName == field)
                    {
                        object o = item.GetValue(source, null);
                        return o;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + System.Environment.NewLine + ex.InnerException);
                }

            }

            return value;
        }



        private static object GetDynamicItemValue(dynamic source, string field)
        {
            object result = null;
            bool dobrane = false;
            Type itemType = GetElementType(source.GetType());
            var props = itemType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(PrintAttribute)));
            foreach (System.Reflection.PropertyInfo propName in props)
            {
                for (int i = 0; i < propName.GetCustomAttributesData().Count; i++)
                {
                    foreach (var xxAtt in propName.GetCustomAttributesData()[i].NamedArguments)
                    {
                        var yy = xxAtt.TypedValue.Value + "#";
                        if (field == yy)
                        {
                            return source.GetType().GetProperty(propName.Name).GetValue(source, null);
                        }
                    }
                    if (dobrane) break;
                }
            }
            return result;
        }


        public static void ProcessPatternDocument<T>(string fileName, T sourceItem)
        {
            // Open a WordprocessingDocument for editing using the filepath.
            WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(fileName, true);

            // Assign a reference to the existing document body.
            Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

            List<string> _FieldsList = FieldsForReports.CreateListOfFields(typeof(T));

            #region Wypełnij pola nie należące do tabel
            foreach (string field in _FieldsList.Where(f => !f.Contains(".")))
            {
                object o = GetItemValue<T>(sourceItem, field);
                string zz = "________";

                if (o != null)
                {
                    if (o is DateTime)
                    {
                        zz = ((DateTime)o).ToString("d");
                    }
                    else
                    {
                        zz = o.ToString();
                    }
                }

                //if (field == "#Charakterystyka#")
                //{
                //  System.Windows.Documents.FlowDocument  flowDocument = (System.Windows.Documents.FlowDocument)System.Windows.Markup.XamlReader.Parse(zz);
                //  foreach (var item in flowDocument.Blocks)
                //  {
                //      var xxx = item;
                //  }
                //}
                foreach (var text in body.Descendants<Text>())
                {
                    if (text.Text.Contains(field))
                    {
                        text.Text = text.Text.Replace(field, zz);
                    }
                }
            }
            #endregion

            #region Wypełnij tabele

            var tables = body.Descendants<Table>().ToList();

            foreach (Table repTable in tables)
            {
                //  object o = GetItemValue(equipmentItem, field, 0); ustalić typ encji i enumerować po liście pozycji
                var tableRows = repTable.Descendants<TableRow>();
                TableRow lastRow = (TableRow)tableRows.LastOrDefault();
                int Lp = 1;
                if (lastRow != null)
                {
                    TableRow wrkRow = (TableRow)lastRow.CloneNode(true);
                    var rowCells = lastRow.Descendants<TableCell>();
                    List<Tuple<string, string>> cellsText = new List<Tuple<string, string>>();

                    Match match;
                    foreach (var cell in rowCells) //ustalić parametry wchodzące do tabeli
                    {
                        var textInCell = cell.Descendants<Text>();
                        foreach (var tx in textInCell)
                        {
                            if (tx.Text == "###")
                            {
                                cellsText.Add(new Tuple<string, string>(tx.Text, "###"));
                            }
                            else
                            {
                                match = Regex.Match(tx.Text, @"(?<tab>#[^.]+).(?<elem>.+#)");
                                if (match.Success)
                                {
                                    cellsText.Add(new Tuple<string, string>(tx.Text, "#" + match.Groups["elem"].Value));
                                }
                            }
                        }
                    }
                    //todo spradzić czy wszystkie pola są z tej samej listy encji
                    if (cellsText.Any())
                    {

                        dynamic tableObject = FindType<T>(sourceItem, cellsText.First(p => p.Item1 != "###").Item1);

                        Type elemType = GetElementType(tableObject.GetType());

                        TableRow r = lastRow;
                        foreach (var entTable in tableObject)
                        {
                            Type itemType = GetElementType(entTable.GetType());
                            foreach (var field in cellsText)
                            {
                                string zz = "____";
                                if (field.Item1 == "###")
                                {
                                    zz = Lp.ToString();
                                    Lp++;
                                }
                                else
                                {
                                    var oRField = GetDynamicItemValue(entTable, field.Item2);

                                    if (oRField != null)
                                    {
                                        if (oRField is DateTime)
                                        {
                                            zz = ((DateTime)oRField).ToString("d");
                                        }
                                        else
                                        {
                                            zz = oRField.ToString();
                                        }
                                    }
                                }
                                foreach (var t in r.Descendants<Text>().Where(t => t.Text == field.Item1))
                                {
                                    t.Text = zz;
                                }
                            }
                            try
                            {
                                repTable.Append(r);
                            }
                            catch (Exception)
                            {

                            }

                            r = (TableRow)wrkRow.CloneNode(true);
                        }
                    }
                }
            }
            #endregion
            wordprocessingDocument.Close();

            OpenWordDocument(fileName);

            //http://stackoverflow.com/questions/16114137/retrieve-specific-table-element-from-open-xml-word-document-mainpart

            //http://msdn.microsoft.com/en-us/library/office/cc850835(v=office.15).aspx
        }

        public static void AddTable(Body body, string[,] data)
        {
            //           using (var document = WordprocessingDocument.Open(fileName, true))
            {

                var doc = body;

                Table table = new Table();

                TableProperties props = new TableProperties(
                    new TableBorders(
                    new TopBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new BottomBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new LeftBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new RightBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new InsideHorizontalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new InsideVerticalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    }));

                table.AppendChild<TableProperties>(props);

                for (var i = 0; i <= data.GetUpperBound(0); i++)
                {
                    var tr = new TableRow();
                    for (var j = 0; j <= data.GetUpperBound(1); j++)
                    {
                        var tc = new TableCell();
                        tc.Append(new Paragraph(new Run(new Text(data[i, j]))));

                        // Assume you want columns that are automatically sized.
                        tc.Append(new TableCellProperties(
                            new TableCellWidth { Type = TableWidthUnitValues.Auto }));

                        tr.Append(tc);
                    }
                    table.Append(tr);
                }
                doc.Append(table);
                //doc.Save();
            }
        }


        public static void CreateWordDocument(string filepath, string initText)
        {
            List<string> _FieldsList = FieldsForReports.CreateListOfFields(typeof(PrzyrzadPomiarowy)); //Ustawić typ generyczny
            WordprocessingDocument wordprocessingDocument = GeneratedDocument.CreatePackage(filepath);
            // Add new text.
            Body body = wordprocessingDocument.MainDocumentPart.Document.Body;
            Paragraph para = body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            run.AppendChild(new Text(initText));
            wordprocessingDocument.Close();
        }

        public static void CreateDocumentTemplate(string patternName, string patterDescription, Type _type)
        {
            List<string> _FieldsList = FieldsForReports.CreateListOfFields(_type); //Ustawić typ generyczny
            WordprocessingDocument wordprocessingDocument = GeneratedDocument.CreatePackage(patternName);
            // Add new text.
            Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

            Paragraph paragraph1 = new Paragraph() { RsidParagraphAddition = "00E01865", RsidParagraphProperties = "0075436D", RsidRunAdditionDefault = "0075436D" };
            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "Nagwek1" };
            paragraphProperties1.Append(paragraphStyleId1);

            Run run1 = new Run();
            Text text1 = new Text();
            text1.Text = patterDescription;
            run1.Append(text1);
            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);
            body.Append(paragraph1);

            Paragraph paragraph2 = new Paragraph() { RsidParagraphAddition = "00E01865", RsidRunAdditionDefault = "0075436D" };
            Run run2 = new Run() { RsidRunProperties = "0075436D" };
            RunProperties runProperties2 = new RunProperties();
            Color color1 = new Color() { Val = "FF0000" };
            runProperties2.Append(color1);
            Text text2 = new Text();
            text2.Text = "Uwaga: przed rozpoczęciem edycji należy wyłączyć sprawdzanie pisowni i gramatyki!";
            run2.Append(runProperties2);
            run2.Append(text2);
            paragraph2.Append(run2);
            body.Append(paragraph2);

            Paragraph paragraph3 = new Paragraph() { RsidParagraphAddition = "00E01865", RsidRunAdditionDefault = "0075436D" };
            Run run3 = new Run() { RsidRunProperties = "0075436D" };
            RunProperties runProperties3 = new RunProperties();

            Text text3 = new Text();
            text3.Text = "Numerację wierszy tabeli można otrzymać wprowadzając ### jako pole celi ";

            run3.Append(runProperties3);
            run3.Append(text3);
            paragraph3.Append(run3);
            body.Append(paragraph3);

            Paragraph listPar = body.AppendChild(new Paragraph());
            foreach (string param in _FieldsList)
            {
                body.Append(new Paragraph(new Run(new Text(param))));
            }
            wordprocessingDocument.Close();

            // Otwórz wzorzec w programie MS Word
            //=======================================================================
            OpenWordDocument(patternName);
        }

        private static void OpenWordDocument(string fileName)
        {
            object opatternName = fileName;
            object missing = System.Reflection.Missing.Value;
            object readOnly = false;
            object isVisible = true;
            Word.Application wordApplication = new Word.Application();
            wordApplication.Visible = true;
            Word.Document wordDocument;
            try
            {
                wordDocument = wordApplication.Documents.Open(ref opatternName, ref missing, ref readOnly, ref missing, ref  missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                wordDocument.Activate();
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void OpenDocument(string docName)
        {
            object opatternName = docName;
            object missing = System.Reflection.Missing.Value;
            object readOnly = true;
            object isVisible = true;
            Word.Application wordApplication = new Word.Application();
            wordApplication.Visible = true;
            Word.Document wordDocument;
            try
            {
                wordDocument = wordApplication.Documents.Open(ref opatternName, ref missing, ref readOnly, ref missing, ref  missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                wordDocument.Activate();
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //=================================================================================================================

        private void FindAndReplace(Microsoft.Office.Interop.Word.Application doc, object findText, object replaceWithText)
        {

            //options
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            //execute find and replace
            doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);

            /* Usage
  *      object fileName = Path.Combine(System.Windows.Forms.Application.StartupPath, "document.docx");
 Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application { Visible = true };
 Microsoft.Office.Interop.Word.Document aDoc = wordApp.Documents.Open(ref fileName, ReadOnly: false, Visible: true);
 aDoc.Activate();
 FindAndReplace(word, "{id}", "12345");*/
        }

    }
}
