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
using Abakon15WPF.Infrastructure;
using AbakonDataModel;
using Abakon15WPF.ViewModels;

namespace Abakon15WPF.Views.Controls
{
    /// <summary>
    /// Interaction logic for DocumentUC.xaml
    /// </summary>
    public partial class DocumentUC : UserControl, ITabbedMDI
    {
        public DocumentUC()
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

        private void _DocumentsDatagrid_Loaded(object sender, RoutedEventArgs e)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(_DocumentsDatagrid.ItemsSource);
            if (dataView != null)
            {

                dataView.SortDescriptions.Clear();
                SortDescription sd = new SortDescription("CreateDate", ListSortDirection.Descending);
                dataView.SortDescriptions.Add(sd);
                if (_DocumentsDatagrid.Items.Count > 0)
                {
                    _DocumentsDatagrid.SelectedIndex = 0;
                }
                dataView.Refresh();
            }
        }

        #region ITabbedMDI Members

        #region ========================= Search region =============================================
        // working controls   _searchBox _przyrzadyDatagrid
        private void _DocumentsDatagrid_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.F)
            {
                var dc = _DocumentsDatagrid.GetDataGridCell(((DataGrid)e.Source).CurrentCell);
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
                        _DocumentsDatagrid.SelectDataGridColumn(dc);
                    }
                }
            }
        }

        private void _searchDown_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_searchBox.Text == null || _searchBox.Text.Trim() == string.Empty) return;
            var selCells = _DocumentsDatagrid.SelectedCells;
            var sC = selCells.ToArray<DataGridCellInfo>();
            if (sC.Count() == 0) return;
            if (_DocumentsDatagrid.SelectionUnit == DataGridSelectionUnit.FullRow) { _DocumentsDatagrid.SelectionUnit = DataGridSelectionUnit.Cell; }
            selCells.Clear();
            _DocumentsDatagrid.SelectionUnit = DataGridSelectionUnit.FullRow;

            var selColumns = sC.Select(c => c.Column).Distinct(); //= dc.Column;
            DataGridRow row = (DataGridRow)_DocumentsDatagrid.ItemContainerGenerator.ContainerFromIndex(0);

            List<DataGridSelectionInfo> selectedColumns = new List<DataGridSelectionInfo>();
            foreach (var item in selColumns)
            {
                selectedColumns.Add(_DocumentsDatagrid.GetDataGridSelectionInfo((DataGridBoundColumn)item));
            }

            ViewableObservableCollection<Document> _PrzyrzadPomiarowyCollection = new ViewableObservableCollection<Document>();
            foreach (var item in _DocumentsDatagrid.Items)
            {
                if (EntityComparer.Compare(item, _searchBox.Text, selectedColumns))
                {
                    _PrzyrzadPomiarowyCollection.Add((Document)item);
                    // ((PrzyrzadPomiarowyCollectionVM)this.DataContext).PrzyrzadPomiarowyCollection.Remove((PrzyrzadPomiarowy)item);

                }
            }
            ((DocumentVM)this.DataContext).DocumentCollection = _PrzyrzadPomiarowyCollection;
            _DocumentsDatagrid.Items.Refresh();
        }
        #endregion ===================================================================================



        public WindowContextEnum TabGroup
        {
            get
            {
                return WindowContextEnum.documents;
            }
            set
            {

            }
        }
        public bool SaveSpliterPositon { get { return false; } set { } }
        public string Title
        {
            get { return WindowContextEnum.documents.ToString(); }
        }

        #endregion

    }
}
