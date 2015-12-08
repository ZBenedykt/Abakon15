using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Abakon15
{
    public static class ExtDependencyObjectClass
    {
        public static T FindParent<T>(this DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null) return null;
            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindParent<T>(parentObject);
        }

        public static T FindVisualParent<T>(this UIElement element) where T : UIElement
        {
            var parent = element;
            while (parent != null)
            {
                var correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }

                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }
            return null;
        }


        public static DataGridCell GetDataGridCell(this DataGrid dataGrid, DataGridCellInfo cellInfo)
        {
            if (cellInfo == null || cellInfo.IsValid == false)
            {
                return null;
            }
            var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
            if (cellContent == null)
            {
                return null;
            }
            return cellContent.Parent as DataGridCell;
        }

        public static void SelectDataGridColumn(this DataGrid dataGrid, DataGridCell selectedCell)
        {
            if (dataGrid.SelectionUnit == DataGridSelectionUnit.FullRow) dataGrid.SelectionUnit = DataGridSelectionUnit.CellOrRowHeader;
            {
                dataGrid.SelectedCells.Clear();
                DataGridColumn column = selectedCell.Column;
                for (int i = 0; i < dataGrid.Items.Count; i++)
                {
                    dataGrid.SelectedCells.Add(new DataGridCellInfo(dataGrid.Items[i], column));
                }
            }
        }

        public static DataGridSelectionInfo GetDataGridSelectionInfo(this DataGrid dataGrid, DataGridBoundColumn col)
        {
            DataGridSelectionInfo result = new DataGridSelectionInfo();
            System.Windows.Data.Binding binding = col.Binding as System.Windows.Data.Binding;
            string[] boundPropertyName = binding.Path.Path.Split('.');

            result.DataGridHeader = col.Header.ToString();
            result.PropertyPath = boundPropertyName;

            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(0);
            if (row == null)
            {
                result.PropertyType = typeof(string);
                return result;
            }
            System.ComponentModel.PropertyDescriptorCollection properties = System.ComponentModel.TypeDescriptor.GetProperties(row.Item);
            System.ComponentModel.PropertyDescriptor property = properties[boundPropertyName[0]];
            object value = null;
            if (property != null)
            {
                if (property.GetValue(row.Item) == null)
                {
                    result.PropertyType = typeof(string);
                    return result;
                }

                Type rType = property.GetValue(row.Item).GetType();
                if (rType == typeof(string) || !rType.IsClass)
                {
                    result.PropertyType = rType;
                    return result;
                }
                else
                {
                    value = property.GetValue(row.Item);
                    Type mT = value.GetType();
                    List<Type> LT = new List<Type>();
                    foreach (System.Reflection.PropertyInfo pr in mT.GetProperties())
                    {
                        if (pr.Name == boundPropertyName[1])
                            result.PropertyType = pr.PropertyType;
                    }

                    result.PropertyType = typeof(string);
                    return result;
                }
            }
            else
            {
                result.PropertyType = typeof(string);
                return result;
            }
        }

        public static void CollapseAllTreeViewItems(this TreeViewItem rootTreeViewItem)
        {
            Stack<TreeViewItem> treeViewItemsStack = new Stack<TreeViewItem>();
            treeViewItemsStack.Push(rootTreeViewItem);
            while (treeViewItemsStack.Count != 0)
            {
                TreeViewItem current = treeViewItemsStack.Pop();
                if (current != null)
                {
                    current.IsExpanded = false;
                    for (int i = 0; i < current.Items.Count; i++)
                    {
                        treeViewItemsStack.Push(current.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem);
                    }
                }
            }
        }

        public static void ExpandAllTreeViewItems(this TreeViewItem rootTreeViewItem)
        {
            if (rootTreeViewItem != null && !rootTreeViewItem.IsExpanded)
            {
                rootTreeViewItem.IsExpanded = true;
                rootTreeViewItem.BringIntoView();
                for (int i = 0; i < rootTreeViewItem.Items.Count; i++)
                {
                    TreeViewItem child = (TreeViewItem)rootTreeViewItem.ItemContainerGenerator.ContainerFromIndex(i);
                    child.ExpandAllTreeViewItems();
                }
            }
            else
            {
                if (rootTreeViewItem != null)
                {
                    for (int i = 0; i < rootTreeViewItem.Items.Count; i++)
                    {
                        TreeViewItem child = (TreeViewItem)rootTreeViewItem.ItemContainerGenerator.ContainerFromIndex(i);
                        child.ExpandAllTreeViewItems();
                    }
                }
            }
        }

    }
}
