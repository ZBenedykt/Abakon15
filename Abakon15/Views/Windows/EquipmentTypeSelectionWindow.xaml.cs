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

namespace Abakon15.Views.Windows
{
    /// <summary>
    /// Interaction logic for EquipmentTypet.xaml
    /// </summary>
    public partial class EquipmentTypeSelectionWindow : Abakon15.Views.WindowBaseClass
    {
        public EquipmentTypeSelectionWindow()
        {
            InitializeComponent();
        }

        private void c_Tree_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);

            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
            }
        }

        static TreeViewItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);
            return source as TreeViewItem;
        }

        private void c_departnentTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ((EquipmentTypeVM)this.DataContext).CurrentEquipmentType = (EquipmentType)c_typeTree.SelectedItem;
        }


        public EquipmentType EquipmentType { get; set; }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            EquipmentType = (EquipmentType)c_typeTree.SelectedItem;
            this.DialogResult = true;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void acceptNullButton_Click(object sender, RoutedEventArgs e)
        {
            EquipmentType = null;
            this.DialogResult = true;
        }
    }
}
