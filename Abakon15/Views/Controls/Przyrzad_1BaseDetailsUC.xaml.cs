using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel;
using Abakon15.ViewModels;
using Abakon15.Utility;
using System.Linq;

namespace Abakon15.Views.Controls
{
    /// <summary>
    /// Interaction logic for Przyrzad_1BaseDetailsUC.xaml
    /// </summary>
    public partial class Przyrzad_1BaseDetailsUC : UserControl
    {
        public Przyrzad_1BaseDetailsUC()
        {
            InitializeComponent();
        }
        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void _przyrzadyDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (_scopeDatagrid.SelectedItem != null)
            //{
            //    _scopeDatagrid.ScrollIntoView(_scopeDatagrid.SelectedItem);
            //}
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
                if (e.Key == Key.Delete && !dgr.IsEditing && !((PrzyrzadPomiarowyVM)this.DataContext).ReadOnly)
                {
                    ((PrzyrzadPomiarowyVM)this.DataContext).DeleteZakresCommand.Execute();

                    e.Handled = true;
                }
                else
                {
                    if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    {
                        // Abakon15.Utility.Remains.PasteToDataGrid(_scopeDatagrid);
                        PasteFromExcela();
                    }
                }
            }
        }

        private void PasteFromExcela()
        {
            string[][] clipboardData = ClipboardUtility.ClipboardTable();
            string[] rowStr = new string[clipboardData.Length];
            ;
            for (int i = 0; i < clipboardData.Length; i++)
            {
                var x = clipboardData[i];
                rowStr[i] = string.Join(";", x);
            }
            string cont = string.Join("//", rowStr);
            for (int i = 0; i < clipboardData.Length; i++)
            {
                _scopeDatagrid.Items.Add(new AbakonDataModel.EquipmentScope());

            }
            //_scopeDatagrid.CommitEdit();
            //_scopeDatagrid.Items.Refresh();

            ((PrzyrzadPomiarowyVM)this.DataContext).CurrentPrzyrzadPomiarowy.Reload();
            int startRow = _scopeDatagrid.ItemContainerGenerator.IndexFromContainer(
                            (DataGridRow)_scopeDatagrid.ItemContainerGenerator.ContainerFromItem
                            (_scopeDatagrid.CurrentCell.Item));
            DataGridRow[] rows =
               Enumerable.Range(
                   0, System.Math.Min(_scopeDatagrid.Items.Count, clipboardData.Length))
               .Select(rowIndex =>
                   _scopeDatagrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow)
               .Where(a => a != null).ToArray();

            //// the destination columns 
            ////  (from selected row to either end or max. length of clipboard colums)
            DataGridColumn[] columns =
                _scopeDatagrid.Columns.OrderBy(column => column.DisplayIndex)
                .SkipWhile(column => column != _scopeDatagrid.CurrentCell.Column)
                .Take(clipboardData.Max(row => row.Length)).ToArray();

            for (int rowIndex = 0; rowIndex < clipboardData.Length; rowIndex++)
            {
                string[] rowContent = clipboardData[rowIndex];
                // for (int colIndex = 0; colIndex < columns.Length; colIndex++)
                {
                    string cellContent = rowStr[rowIndex];
                    //colIndex >= rowContent.Length ? "" : rowContent[colIndex];
                    _scopeDatagrid.Columns[_scopeDatagrid.SelectedCells[0].Column.DisplayIndex].OnPastingCellClipboardContent(
                        rows[rowIndex].Item, cellContent);
                }
            }

        }

        private void _KlasaRichTextBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!_KlasaRichTextBox.IsReadOnly)
                this._KlasaRichTextBox.UpdateDocumentBindings();
        }

        private void _uzytkownikPrzyrzadu_Button_Click(object sender, RoutedEventArgs e)
        {
            _equpmentUserPopUP.IsOpen = true;
        }

        private void _equipmentUser_ListView_Loaded(object sender, RoutedEventArgs e)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(_equipmentUser_ListView.ItemsSource);
            if (dataView != null)
            {
                dataView.SortDescriptions.Clear();
                SortDescription sd = new SortDescription("SureFirstName", ListSortDirection.Ascending);
                dataView.SortDescriptions.Add(sd);
                dataView.Refresh();
            }
        }

        private void _hidePopUp_Button_Click(object sender, RoutedEventArgs e)
        {
            _equpmentUserPopUP.IsOpen = false;
        }

        private void _scopeDatagrid_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    Abakon15.Utility.Remains.PasteToDataGrid(_scopeDatagrid);
                }

            }
        }

    }
}
