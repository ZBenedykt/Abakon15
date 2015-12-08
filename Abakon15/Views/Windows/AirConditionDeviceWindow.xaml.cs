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
using Abakon15.Interfaces;
using Abakon15.ViewModels;
using AbakonDataModel;
using System.ComponentModel;

namespace Abakon15.Views.Windows
{
    /// <summary>
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class AirConditionDeviceWindow : Abakon15.Views.WindowBaseClass
    {
        public AirConditionDeviceWindow()
        {
            InitializeComponent();
        }

        private void _cDatagrid_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(_cDatagrid.ItemsSource);
        }

        void _cDatagrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (dg != null)
            {
                DataGridRow dgr = (DataGridRow)(dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex));
                if (e.Key == Key.Delete && !dgr.IsEditing && !((FilePathVM)this.DataContext).ReadOnly)
                {
                    ((FilePathVM)this.DataContext).DeleteCommand.Execute();

                    e.Handled = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _cDatagrid.Items.Refresh();
        }

        private void Button_LostFocus(object sender, RoutedEventArgs e)
        {
            _cDatagrid.Items.Refresh();
        }

    }
}
