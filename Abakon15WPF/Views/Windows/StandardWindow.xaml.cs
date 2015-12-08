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
using Abakon15WPF.Interfaces;
using Abakon15WPF.ViewModels;
using AbakonDataModel;
using System.ComponentModel;

namespace Abakon15WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class StandardWindow : Abakon15WPF.Views.WindowBaseClass
    {
        public StandardWindow()
        {
            InitializeComponent();
        }

        private void _scopeDatagrid_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(_scopeDatagrid.ItemsSource);
        }

        void _scopeDatagrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (dg != null)
            {
                DataGridRow dgr = (DataGridRow)(dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex));
                if (e.Key == Key.Delete && !dgr.IsEditing && !((StandardVM)this.DataContext).ReadOnly)
                {
                    ((StandardVM)this.DataContext).DeleteCommand.Execute();

                    e.Handled = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _scopeDatagrid.Items.Refresh();
        }

        private void Button_LostFocus(object sender, RoutedEventArgs e)
        {
            _scopeDatagrid.Items.Refresh();
        }

    }
}
