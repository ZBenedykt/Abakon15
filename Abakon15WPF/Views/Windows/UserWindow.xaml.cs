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
using Abakon15WPF.ViewModels;

using System.ComponentModel;
using AbakonDataModel;

namespace Abakon15WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
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

        private void c_userRolesTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //  ((UsersVM)this.DataContext).CurrentRoleActual = (GenRole)c_userRolesTree.SelectedItem;
            //    MessageBox.Show("Użytkowników : " + ((UsersVM)this.DataContext).CurrentRoleActual.CountUsers().ToString());
        }

        private void c_allowedRolesTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ((UsersVM)this.DataContext).CurrentRoleComplementary = (GenRole)c_allowedRolesTree.SelectedItem;
        }

        private void _RebuildRoles_Click(object sender, RoutedEventArgs e)
        {
            ((UsersVM)this.DataContext).RebuildRole();

        }

        private void c_copyRolesToAllSelected_Click(object sender, RoutedEventArgs e)
        {
            var selectedUsers = _Users_ListView.SelectedItems;
            List<_User> list = new List<_User>();
            foreach (var item in selectedUsers)
            {
                list.Add((_User)item);
            }
            for (int i = 0; i < list.Count; i++)
            {
                ((UsersVM)this.DataContext).CopyRoles((_User)list[i]);
            }

            ((UsersVM)this.DataContext).SaveCommand.Execute();
            foreach (var item in list)
            {
                _Users_ListView.SelectedItems.Add(item);
            }
        }

        private void _addRole_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedUsers = _Users_ListView.SelectedItems;
            List<_User> list = new List<_User>();
            foreach (var item in selectedUsers)
            {
                list.Add((_User)item);
            }
            for (int i = 0; i < list.Count; i++)
            {
                ((UsersVM)this.DataContext).AddRoleToSelectedUser((_User)list[i]);
            }
            foreach (var item in list)
            {
                _Users_ListView.SelectedItems.Add(item);
            }
        }

        private void _removeRole_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedUsers = _Users_ListView.SelectedItems;
            List<_User> list = new List<_User>();
            foreach (var item in selectedUsers)
            {
                list.Add((_User)item);
            }
            for (int i = 0; i < list.Count; i++)
            {
                ((UsersVM)this.DataContext).RemoveRoleFromSelectedUser((_User)list[i]);
            }

            foreach (var item in list)
            {
                _Users_ListView.SelectedItems.Add(item);
            }


        }

        private void _removeRoles_Click(object sender, RoutedEventArgs e)
        {

            var selectedUsers = _Users_ListView.SelectedItems;
            List<_User> list = new List<_User>();
            foreach (var item in selectedUsers)
            {
                list.Add((_User)item);
            }
            for (int i = 0; i < list.Count; i++)
            {
                ((UsersVM)this.DataContext).RemoveAllRoleFromSelectedUser((_User)list[i]);
            }

            foreach (var item in list)
            {
                _Users_ListView.SelectedItems.Add(item);
            }

        }

        private void _Users_ListView_Loaded(object sender, RoutedEventArgs e)
        {
            ICollectionView dataView =
             CollectionViewSource.GetDefaultView(_Users_ListView.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription("UserName", ListSortDirection.Ascending);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }



    }
}
