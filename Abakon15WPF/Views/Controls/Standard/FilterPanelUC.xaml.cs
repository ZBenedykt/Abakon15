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
using Abakon15WPF.ViewModels;

namespace Abakon15WPF.Views.Controls.Standard
{
    /// <summary>
    /// Interaction logic for FilterPanelUC.xaml
    /// </summary>
    public partial class FilterPanelUC : UserControl
    {
        public FilterPanelUC()
        {
            InitializeComponent();
        }

        private void _FieldsCollection_ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((FilterPanelVM)this.DataContext).AddToFieldsFiltered();
        }

        private void _FieldsFiltered_ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((FilterPanelVM)this.DataContext).RemoveFromFieldsFiltered();
        }

        private void _FieldsCollection_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_FieldsCollection_ListView.SelectedItem != null)
            {
                _FieldsCollection_ListView.ScrollIntoView(_FieldsCollection_ListView.SelectedItem);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((FilterPanelVM)this.DataContext).CurrentFromFieldsFiltered = (FilterField)((ListBoxItem)_FieldsFiltered_ListBox.ContainerFromElement((Button)sender)).Content;
            ((FilterPanelVM)this.DataContext).RemoveFromFieldsFiltered();
        }

        private void _upButton_Click(object sender, RoutedEventArgs e)
        {
            ((FilterPanelVM)this.DataContext).CurrentFromFieldsCollection = (FilterField)((ListBoxItem)_FieldsCollection_ListView.ContainerFromElement((Button)sender)).Content;
            ((FilterPanelVM)this.DataContext).AddToFieldsFiltered();
        }
    }
}
