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
using Abakon15.ViewModels;
using AbakonDataModel;
using System.ComponentModel;
using Abakon15.Infrastructure;

namespace Abakon15.Views.Controls
{
    /// <summary>
    /// Interaction logic for PrzyrzadPomiarowyUC.xaml
    /// </summary>
    public partial class PrzyrzadPomiarowyUC : UserControl, ITabbedMDI
    {
        public PrzyrzadPomiarowyUC()
        {
            InitializeComponent();

        }


        #region ITabbedMDI Members

        public WindowContextEnum TabGroup
        {
            get
            {
                return WindowContextEnum.measuringDevices;
            }
            set
            {

            }
        }
        //bool _SaveSpliterPositon = false;
        //public bool SaveSpliterPositon { get { return _SaveSpliterPositon; } set { value = SaveSpliterPositon; } }
        public bool SaveSpliterPositon { get; set; }
        public string Title
        {
            get { return WindowContextEnum.measuringDevices.ToString(); }
        }

        #endregion

        private void _setColumns_Button_Click(object sender, RoutedEventArgs e)
        {
            _popupUserSettins.IsOpen = true;
        }



        private void Row_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((PrzyrzadPomiarowyCollectionVM)this.DataContext).CurrentPrzyrzadPomiarowy != null)
            {
                ((PrzyrzadPomiarowyCollectionVM)this.DataContext).PrzyrzadPomiarowySingleWindowOpenCommand.Execute(((PrzyrzadPomiarowyCollectionVM)this.DataContext).CurrentPrzyrzadPomiarowy);
            }
        }


        private void RowKalibrowane_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((PrzyrzadPomiarowyCollectionVM)this.DataContext).CurrentPrzyrzadKalibrowany != null)
            {
                ((PrzyrzadPomiarowyCollectionVM)this.DataContext).PrzyrzadPomiarowySingleWindowOpenCommand.Execute(((PrzyrzadPomiarowyCollectionVM)this.DataContext).CurrentPrzyrzadKalibrowany);
            }
        }

        private void _przyrzadyDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (_przyrzadyDatagrid.SelectedItem != null)
            {
                _przyrzadyDatagrid.ScrollIntoView(_przyrzadyDatagrid.SelectedItem);
            }
        }

        private void _przyrzadyKalibrowaneDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_przyrzadyKalibrowaneDatagrid.SelectedItem != null)
            {
                _przyrzadyKalibrowaneDatagrid.ScrollIntoView(_przyrzadyKalibrowaneDatagrid.SelectedItem);
            }
        }

        private void _rpt_Button_Click(object sender, RoutedEventArgs e)
        {
            _reportPopUP.IsOpen = true;
        }




        private void _Users_ListView_Loaded(object sender, RoutedEventArgs e)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(_Users_ListView.ItemsSource);
            if (dataView != null)
            {
                dataView.SortDescriptions.Clear();
                SortDescription sd = new SortDescription("SureFirstName", ListSortDirection.Ascending);
                dataView.SortDescriptions.Add(sd);
                dataView.Refresh();
            }
            ((PrzyrzadPomiarowyCollectionVM)this.DataContext).LabWorkers = this._LabWorkers_ListView;
        }

        private void _connectEmployees_Click(object sender, RoutedEventArgs e)
        {
            List<Person> personList = new List<Person>();
            foreach (var item in _Users_ListView.SelectedItems)
            {
                personList.Add((Person)item);
            }

            List<PrzyrzadPomiarowy> EquipmentList = new List<PrzyrzadPomiarowy>();
            foreach (var item in _przyrzadyDatagrid.SelectedItems)
            {

                EquipmentList.Add((PrzyrzadPomiarowy)item);
            }
            ((PrzyrzadPomiarowyCollectionVM)this.DataContext).ConnectLabWorkerToEquipment(personList, EquipmentList);
            _LabWorkers_ListView.Items.Refresh();
        }

        private void _disconectEmployees_Click(object sender, RoutedEventArgs e)
        {
            List<PersonEquipment> labWorkerEquipmentList = new List<PersonEquipment>();
            foreach (var item in _allowedEmployeeDatagrid.SelectedItems)
            {
                labWorkerEquipmentList.Add((PersonEquipment)item);
            }
            ((PrzyrzadPomiarowyCollectionVM)this.DataContext).DisconnectLabWorkerFromEquipment(labWorkerEquipmentList);
            _LabWorkers_ListView.Items.Refresh();
        }

        private void _LabWorkers_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Person> persons = new List<Person>();
            foreach (var item in _LabWorkers_ListView.SelectedItems)
            {
                persons.Add((Person)item);
            }

            ((PrzyrzadPomiarowyCollectionVM)this.DataContext).FilterResposiblePersons = persons;
        }

        #region ========================= Search region =============================================
        // working controls   _searchBox _przyrzadyDatagrid
        private void _przyrzadyDatagrid_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.F)
            {
                var dc = _przyrzadyDatagrid.GetDataGridCell(((DataGrid)e.Source).CurrentCell);
                if (dc != null)
                {
                    TextBlock tb = dc.Content as TextBlock;
                    if (tb == null)
                    {
                        _searchBox.Text = string.Empty;
                    }
                    else
                    {
                        _searchBox.Text = tb.Text;
                        _searchBox.Focus();
                        _przyrzadyDatagrid.SelectDataGridColumn(dc);
                    }
                }
            }
        }

        private void _searchDown_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_searchBox.Text == null || _searchBox.Text.Trim() == string.Empty) return;
            var selCells = _przyrzadyDatagrid.SelectedCells;
            var sC = selCells.ToArray<DataGridCellInfo>();
            if (sC.Count() == 0) return;
            if (_przyrzadyDatagrid.SelectionUnit == DataGridSelectionUnit.FullRow) { _przyrzadyDatagrid.SelectionUnit = DataGridSelectionUnit.Cell; }
            selCells.Clear();
            _przyrzadyDatagrid.SelectionUnit = DataGridSelectionUnit.FullRow;

            var selColumns = sC.Select(c => c.Column).Distinct(); //= dc.Column;
            DataGridRow row = (DataGridRow)_przyrzadyDatagrid.ItemContainerGenerator.ContainerFromIndex(0);

            List<DataGridSelectionInfo> selectedColumns = new List<DataGridSelectionInfo>();
            foreach (var item in selColumns)
            {
                selectedColumns.Add(_przyrzadyDatagrid.GetDataGridSelectionInfo((DataGridBoundColumn)item));
            }

            ViewableObservableCollection<PrzyrzadPomiarowy> _PrzyrzadPomiarowyCollection = new ViewableObservableCollection<PrzyrzadPomiarowy>();
            foreach (var item in _przyrzadyDatagrid.Items)
            {
                if (EntityComparer.Compare(item, _searchBox.Text, selectedColumns))
                {
                    _PrzyrzadPomiarowyCollection.Add((PrzyrzadPomiarowy)item);
                    // ((PrzyrzadPomiarowyCollectionVM)this.DataContext).PrzyrzadPomiarowyCollection.Remove((PrzyrzadPomiarowy)item);

                }
            }
            ((PrzyrzadPomiarowyCollectionVM)this.DataContext).PrzyrzadPomiarowyCollection = _PrzyrzadPomiarowyCollection;
            _przyrzadyDatagrid.Items.Refresh();
        }
        #endregion ===================================================================================

        private void _przyrzadyDatagrid_Loaded(object sender, RoutedEventArgs e)
        {
            ICollectionView dataView =
  CollectionViewSource.GetDefaultView(_przyrzadyDatagrid.ItemsSource);
            if (dataView != null)
            {
                dataView.SortDescriptions.Clear();
                SortDescription sd = new SortDescription("PrzyrzadPomiarowyNrKod", ListSortDirection.Ascending);
                dataView.SortDescriptions.Add(sd);
                dataView.Refresh();
            }

        }

        private void _spliter1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SaveSpliterPositon)
            {
                double h = Math.Min(_GridHoryzontalSpliter.ActualHeight - _spliter1.ActualHeight, _GridHoryzontalSpliter.RowDefinitions[0].Height.Value);
                Abakon15.Properties.Settings.Default.EquipmentSpliter = h;
            }
        }

        private void _GridHoryzontalSpliter_Loaded(object sender, RoutedEventArgs e)
        {
            if (SaveSpliterPositon)
            {
                double h = Math.Min(_GridHoryzontalSpliter.ActualHeight - _spliter1.ActualHeight, Abakon15.Properties.Settings.Default.EquipmentSpliter);
                _GridHoryzontalSpliter.RowDefinitions[0].Height = new GridLength(h);

            }
        }

        private void _GridVerticalSpliter_Loaded(object sender, RoutedEventArgs e)
        {
            if (SaveSpliterPositon)
            {
                double w = Math.Min(_GridHoryzontalSpliter.ActualWidth - _spliterV1.ActualWidth, Abakon15.Properties.Settings.Default.EquipmentSpliterV);
                _GridVerticalSpliter.ColumnDefinitions[0].Width = new GridLength(w);

            }
        }

        private void _spliterV1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SaveSpliterPositon)
            {
                double w = Math.Min(_GridHoryzontalSpliter.ActualWidth - _spliterV1.ActualWidth, _GridVerticalSpliter.ColumnDefinitions[0].Width.Value);
                Abakon15.Properties.Settings.Default.EquipmentSpliterV = w;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _przyrzadyDatagrid.Items.Refresh();
        }


    }
}
