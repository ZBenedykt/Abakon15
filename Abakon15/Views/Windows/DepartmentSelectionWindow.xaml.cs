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
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class DepartmentSelectionWindow : Abakon15.Views.WindowBaseClass
    {

        public DepartmentSelectionWindow()
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
            ((DepartmentVM)this.DataContext).CurrentDepartment = (Department)c_departnentTree.SelectedItem;
        }


        public Department department { get; set; }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            department = (Department)c_departnentTree.SelectedItem;
            this.DialogResult = true;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void acceptNullButton_Click(object sender, RoutedEventArgs e)
        {
            department = null;
            this.DialogResult = true;
        }
    }
}
