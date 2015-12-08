using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Xps.Packaging;
using Microsoft.Office.Interop.Word;

namespace Abakon15WPF.Utility
{
    class WordToXPSConverter
    {
        public static XpsDocument ConvertWordDocToXPSDoc(string wordDocName, string xpsDocName)
        {
            // Create a WordApplication and add Document to it
            Microsoft.Office.Interop.Word.Application
                wordApplication = new Microsoft.Office.Interop.Word.Application();
            wordApplication.Documents.Add(wordDocName);


            Document doc = wordApplication.ActiveDocument;
            // You must make sure you have Microsoft.Office.Interop.Word.Dll version 12.
            // Version 11 or previous versions do not have WdSaveFormat.wdFormatXPS option
            try
            {
                doc.SaveAs(xpsDocName, WdSaveFormat.wdFormatXPS);
                //   wordApplication.Quit();

                XpsDocument xpsDoc = new XpsDocument(xpsDocName, System.IO.FileAccess.Read);
                return xpsDoc;
            }
            catch (Exception exp)
            {
                string str = exp.Message;
            }
            return null;
        }
    }
}
