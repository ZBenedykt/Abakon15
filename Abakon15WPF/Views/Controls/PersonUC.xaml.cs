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
using Abakon15WPF.Infrastructure;
using AbakonDataModel;
using System.ComponentModel;

namespace Abakon15WPF.Views.Controls
{
    /// <summary>
    /// Interaction logic for PersonUC.xaml
    /// </summary>
    public partial class PersonUC : UserControl, ITabbedMDI
    {
        public enum kindOfPersonEnum
        {
            _employee,
            _agent
        }



        public PersonUC()
        {
            InitializeComponent();

        }



        public bool mouseDoubleClickEnabled = true;


        //private void c_departnentTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        //{
        //    ((PersonVM)this.DataContext).CurrentDepartment = (Department)c_departnentTree.SelectedItem;
        //}

        private void _setColumns_Button_Click(object sender, RoutedEventArgs e)
        {
            _popupUserSettins.IsOpen = true;
        }


        private void copyToLocal_Click(object sender, RoutedEventArgs e)
        {
            ViewableObservableCollection<Document> documents = new ViewableObservableCollection<Document>();
            foreach (var item in _employeesDatagrid.SelectedItems)
            {
                Document document = item as Document;
                documents.Add(document);
            }
            //    WindowManagerClass.OpenDocumentsToLocalFolderWindow(documents);
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

        private void _employeesDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_employeesDatagrid.SelectedItem != null)
            {
                _employeesDatagrid.ScrollIntoView(_employeesDatagrid.SelectedItem);
            }
        }


        void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy; // Okay
            else
                e.Effects = DragDropEffects.None; // Unknown data, ignore it
        }




        #region ========================= Search region =============================================
        // working controls   _searchBox _employeesDatagrid
        private void _ProjectDatagrid_KeyDown(object sender, KeyEventArgs e)
        {

        }


        #endregion ===================================================================================



        private void _PartnerDatagrid_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void _PartnerDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_PartnerDatagrid.SelectedItem != null)
            {
                _PartnerDatagrid.ScrollIntoView(_PartnerDatagrid.SelectedItem);
            }
        }



        #region ITabbedMDI Members

        public WindowContextEnum TabGroup
        {
            get
            {
                return WindowContextEnum.persons;
            }
            set
            {

            }
        }
        public bool SaveSpliterPositon { get { return false; } set { } }
        public string Title
        {
            get { return WindowContextEnum.persons.ToString(); }
        }

        #endregion

        private void _employeesDatagrid_Loaded(object sender, RoutedEventArgs e)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(_employeesDatagrid.ItemsSource);
            if (dataView != null)
            {
                dataView.SortDescriptions.Clear();
                SortDescription sd = new SortDescription("EmployedFrom", ListSortDirection.Descending);
                dataView.SortDescriptions.Add(sd);
                dataView.Refresh();
            }
        }

        private void _personDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(_employeesDatagrid.ItemsSource);
            if (dataView != null)
            {
                dataView.SortDescriptions.Clear();
                SortDescription sd = new SortDescription("EmployedFrom", ListSortDirection.Descending);
                dataView.SortDescriptions.Add(sd);
                dataView.Refresh();
            }
        }


    }
}
