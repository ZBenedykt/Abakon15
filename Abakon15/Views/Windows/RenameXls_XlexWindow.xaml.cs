using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Abakon15.Utility;
using AbakonDataModel;
using System.IO;

namespace Abakon15.Views.Windows
{
    /// <summary>
    /// Interaction logic for RenameXls_XlexWindow.xaml
    /// </summary>
    public partial class RenameXls_XlexWindow : Window
    {
        public RenameXls_XlexWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Guid selPath = Guid.Empty;
            selPath = AppParameters.ExcelLocalizationParameter.FilePathId;
            FilePath fp = FilePath.GetFilePath(selPath);
            List<string> xmlFilesName = FilesUtility.GetXmlFiles(fp.Path);
            foreach (var item in xmlFilesName)
            {
                try
                {
                    File.Move(item, item + "x");
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
