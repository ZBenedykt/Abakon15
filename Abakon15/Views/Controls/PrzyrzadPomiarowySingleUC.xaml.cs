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
using System.ComponentModel;
using Abakon15.ViewModels;
using Abakon15.Infrastructure;
using Abakon15.Views.Windows;

namespace Abakon15.Views.Controls
{
    /// <summary>
    /// Interaction logic for PrzyrzadPomiarowySingleUC.xaml
    /// </summary>
    public partial class PrzyrzadPomiarowySingleUC : UserControl
    {
        public PrzyrzadPomiarowySingleUC()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //if (_cElektryczne.Visibility == System.Windows.Visibility.Visible)
            //{
            // //   this._cElektryczne._KlasaRichTextBox.UpdateDocumentBindings(); 
            //}

        }

        private void _legalizacje_ListView_Loaded(object sender, RoutedEventArgs e)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(_legalizacje_ListView.ItemsSource);
            if (dataView != null)
            {

                dataView.SortDescriptions.Clear();
                SortDescription sd = new SortDescription("DataRozpoczeciaProcesu", ListSortDirection.Descending);
                dataView.SortDescriptions.Add(sd);
                if (_legalizacje_ListView.Items.Count > 0)
                {
                    _legalizacje_ListView.SelectedIndex = 0;
                }
                dataView.Refresh();
            }
        }

        private void _kalibracje_SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _kalibracjaUwagiRichTextBox.UpdateDocumentBindings();
        }

        private void _kalibratory_ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((PrzyrzadPomiarowyVM)this.DataContext).KalibratorOpenCommand != null)
            {
                ((PrzyrzadPomiarowyVM)this.DataContext).KalibratorOpenCommand.Execute(null);
            }
        }

        private void _DOcumentsDatagrid_Loaded(object sender, RoutedEventArgs e)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(_DOcumentsDatagrid.ItemsSource);
            if (dataView != null)
            {

                dataView.SortDescriptions.Clear();
                SortDescription sd = new SortDescription("CreateDate", ListSortDirection.Descending);
                dataView.SortDescriptions.Add(sd);
                if (_DOcumentsDatagrid.Items.Count > 0)
                {
                    _DOcumentsDatagrid.SelectedIndex = 0;
                }
                dataView.Refresh();
            }
        }

        private void _rpt_Button_Click(object sender, RoutedEventArgs e)
        {
            _pathOfDocuments_ComboBox.SelectedValue = ((PrzyrzadPomiarowyVM)this.DataContext).FilePathList.FirstOrDefault(p => p.FilePathId == Abakon15.Properties.Settings.Default.PathToDocuments_SingleEquipment);
            //  ((PrzyrzadPomiarowyVM)this.DataContext).CurrentFilePath;
            _reportPopUP.IsOpen = true;
        }

        private void _labWorkers_Button_Click(object sender, RoutedEventArgs e)
        {
            _pathOfDocuments_ComboBox.SelectedValue = ((PrzyrzadPomiarowyVM)this.DataContext).CurrentFilePath;
            _labWorkersPopUP.IsOpen = true;
        }

        private void _labWorkers_ListView_Loaded(object sender, RoutedEventArgs e)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(_labWorkers_ListView.ItemsSource);
            if (dataView != null)
            {
                dataView.SortDescriptions.Clear();
                SortDescription sd = new SortDescription("SureFirstName", ListSortDirection.Ascending);
                dataView.SortDescriptions.Add(sd);
                dataView.Refresh();
            }
        }

        private void _selectLabWorkers_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedDoers = _labWorkers_ListView.SelectedItems;
            ((PrzyrzadPomiarowyVM)this.DataContext).ProceedLabDoers(selectedDoers);
            _labWorkersPopUP.IsOpen = false;

        }

        private void _normy_Datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((PrzyrzadPomiarowyVM)this.DataContext).NormaOpenCommand != null)
            {
                ((PrzyrzadPomiarowyVM)this.DataContext).NormaOpenCommand.Execute(null);
            }
        }

        private void _dataZarejestrowania_button_Click(object sender, RoutedEventArgs e)
        {
            ((PrzyrzadPomiarowyVM)this.DataContext).CurrentKalibracja.DataRozpoczeciaProcesu = ((PrzyrzadPomiarowyVM)this.DataContext).CurrentKalibracja.DataBadania;
            _legalizacje_ListView.Items.Refresh();
        }

        private void mKeyboard_Button_Click(object sender, RoutedEventArgs e)
        {
            WindowManagerClass.WindowOpener<KeyBoardWindow>(WindowContextEnum.empty, singleton: true, dialog: false);
        }

        private void _pathOfDocuments_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sel = _pathOfDocuments_ComboBox.SelectedValue;
            var fp = ((PrzyrzadPomiarowyVM)this.DataContext).CurrentFilePath;
        }

        private void _pathOfPattern_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sel = _pathOfPattern_ComboBox.SelectedValue;
            var fp = ((PrzyrzadPomiarowyVM)this.DataContext).CurrentTemplatePath;
        }

    }
}
