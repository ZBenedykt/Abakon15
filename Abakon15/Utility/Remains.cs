using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls.Primitives;

namespace Abakon15.Utility
{
    //Różne fragmenty z sieci do ewentualnego wykorzystania
    public class Remains
    {

        public static void PasteToDataGrid(DataGrid dataGrid)
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

            // dataGrid.SelectedCells[0].Item = (Object)clipboardData.ToString();

            dataGrid.Columns[dataGrid.SelectedCells[0].Column.DisplayIndex].OnPastingCellClipboardContent(
                        dataGrid.SelectedCells[0].Item, (Object)cont);



            int startRow = dataGrid.ItemContainerGenerator.IndexFromContainer(
                (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem
                (dataGrid.CurrentCell.Item));

            //// the destination rows 
            //  (from startRow to either end or length of clipboard rows)
            DataGridRow[] rows =
                Enumerable.Range(
                    startRow, Math.Min(dataGrid.Items.Count, clipboardData.Length))
                .Select(rowIndex =>
                    dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow)
                .Where(a => a != null).ToArray();

            //// the destination columns 
            ////  (from selected row to either end or max. length of clipboard colums)
            DataGridColumn[] columns =
                dataGrid.Columns.OrderBy(column => column.DisplayIndex)
                .SkipWhile(column => column != dataGrid.CurrentCell.Column)
                .Take(clipboardData.Max(row => row.Length)).ToArray();

            for (int rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                string[] rowContent = clipboardData[rowIndex];
                // for (int colIndex = 0; colIndex < columns.Length; colIndex++)
                {
                    string cellContent = rowStr[rowIndex];
                    //colIndex >= rowContent.Length ? "" : rowContent[colIndex];
                    dataGrid.Columns[dataGrid.SelectedCells[0].Column.DisplayIndex].OnPastingCellClipboardContent(
                        rows[rowIndex].Item, cellContent);
                }
            }
        }
        //======================================================================


        public static void SelectCellByIndex(DataGrid dataGrid, int rowIndex, int columnIndex)
        {
            if (!dataGrid.SelectionUnit.Equals(DataGridSelectionUnit.Cell))
                throw new ArgumentException("The SelectionUnit of the DataGrid must be set to Cell.");

            if (rowIndex < 0 || rowIndex > (dataGrid.Items.Count - 1))
                throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));

            if (columnIndex < 0 || columnIndex > (dataGrid.Columns.Count - 1))
                throw new ArgumentException(string.Format("{0} is an invalid column index.", columnIndex));

            dataGrid.SelectedCells.Clear();

            object item = dataGrid.Items[rowIndex]; //=Product X
            DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            if (row == null)
            {
                dataGrid.ScrollIntoView(item);
                row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            }
            if (row != null)
            {
                DataGridCell cell = GetCell(dataGrid, row, columnIndex);
                if (cell != null)
                {
                    DataGridCellInfo dataGridCellInfo = new DataGridCellInfo(cell);
                    dataGrid.SelectedCells.Add(dataGridCellInfo);
                    cell.Focus();
                }
            }
        }

        public static DataGridCell GetCell(DataGrid dataGrid, DataGridRow rowContainer, int column)
        {
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                if (presenter == null)
                {
                    /* if the row has been virtualized away, call its ApplyTemplate() method 
                     * to build its visual tree in order for the DataGridCellsPresenter
                     * and the DataGridCells to be created */
                    rowContainer.ApplyTemplate();
                    presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                }
                if (presenter != null)
                {
                    DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    if (cell == null)
                    {
                        /* bring the column into view
                         * in case it has been virtualized away */
                        dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
                        cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    }
                    return cell;
                }
            }
            return null;
        }

        public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        //======================================================================================


    }
}
