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
using System.ComponentModel;

namespace Abakon15.Views.Controls
{
    /// <summary>
    /// Interaction logic for PartnerUC.xaml
    /// </summary>
    public partial class PartnerUC : UserControl, ITabbedMDI
    {
        public PartnerUC()
        {
            InitializeComponent();
        }

        private void _setColumns_Button_Click(object sender, RoutedEventArgs e)
        {
            _popupUserSettins.IsOpen = true;
        }

        #region ITabbedMDI Members

        public WindowContextEnum TabGroup
        {
            get
            {
                return WindowContextEnum.measuringLabs;
            }
            set
            {

            }
        }
        public bool SaveSpliterPositon { get { return false; } set { } }
        public string Title
        {
            get { return WindowContextEnum.measuringLabs.ToString(); }
        }

        #endregion

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

        private void Row_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((PartnerVM)this.DataContext).CurrentPrzyrzad != null)
            {
                ((PartnerVM)this.DataContext).PrzyrzadPomiarowySingleWindowOpenCommand.Execute(((PartnerVM)this.DataContext).CurrentPrzyrzad);
            }
        }

        private void _przyrzadyKalibrowaneDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_przyrzadyKalibrowaneDatagrid.SelectedItem != null)
            {
                _przyrzadyKalibrowaneDatagrid.ScrollIntoView(_przyrzadyKalibrowaneDatagrid.SelectedItem);
            }
        }

        private void _test_Button_Click(object sender, RoutedEventArgs e)
        {
            var x = AbakonDataModel.DataModelUtility.DbContextHasChanges();
        }
    }
}
