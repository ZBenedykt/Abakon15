using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;


namespace Abakon15WPF.Styles
{
    partial class GeneralStyles
    {
        private void SelectColumn(object sender, RoutedEventArgs e)
        {
            var myDataGrid = FindVisualParent<DataGrid>((Button)sender);

            if (myDataGrid.SelectionUnit == DataGridSelectionUnit.FullRow) myDataGrid.SelectionUnit = DataGridSelectionUnit.CellOrRowHeader;
            {
                DataGridColumnHeader header = FindVisualParent<DataGridColumnHeader>((Button)sender);
                if (header != null)
                {
                    if (!((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))))
                    {
                        myDataGrid.SelectedCells.Clear();
                    }

                    DataGridColumn column = header.Column;
                    for (int i = 0; i < myDataGrid.Items.Count; i++)
                    {
                        DataGridCellInfo cellInfo = new DataGridCellInfo(myDataGrid.Items[i], column);
                        if (!myDataGrid.SelectedCells.Contains(cellInfo))
                        {
                            myDataGrid.SelectedCells.Add(cellInfo);
                        }
                    }
                }
            }
        }

        private static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            UIElement parent = element;
            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }

                parent = System.Windows.Media.VisualTreeHelper.GetParent(parent) as UIElement;
            }

            return null;
        }


    }
}
