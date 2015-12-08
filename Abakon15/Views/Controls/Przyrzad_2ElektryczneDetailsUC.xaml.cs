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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;
using Abakon15.ViewModels;

namespace Abakon15.Views.Controls
{
    /// <summary>
    /// Interaction logic for Przyrzad_2ElektryczneDetailsUC.xaml
    /// </summary>
    public partial class Przyrzad_2ElektryczneDetailsUC : UserControl
    {
        public Przyrzad_2ElektryczneDetailsUC()
        {
            InitializeComponent();
        }
        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        //private void _KlasaRichTextBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    this._KlasaRichTextBox.UpdateDocumentBindings();          
        //}


    }
}
