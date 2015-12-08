using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abakon15WPF.Infrastructure
{
    public static class EntityComparer
    {
        public static bool Compare(object item, string findingValue, List<DataGridSelectionInfo> selectedColumns)
        {
            bool result = false;
            Type actType;
            //string cleanString = System.Text.RegularExpressions.Regex.Replace(findingValue, @"\s+", " ");
            string[] forFind = { findingValue.Trim() }; // = cleanString.Trim().Split(' ', ';', ',');


            for (int i = 0; i < forFind.Length; i++)
            {
                forFind[i] = forFind[i].ToLower().Trim();
            }
            Type itemType = item.GetType();
            System.ComponentModel.PropertyDescriptorCollection properties;

            foreach (DataGridSelectionInfo colInfo in selectedColumns)
            {
                int k = 0;
                properties = System.ComponentModel.TypeDescriptor.GetProperties(item);
                System.ComponentModel.PropertyDescriptor property = properties[colInfo.PropertyPath[k]];
                object value = null;
                if (property != null)
                {
                    value = property.GetValue(item);
                    while (value != null && k < colInfo.PropertyPath.Length)
                    {
                        actType = value.GetType();
                        properties = System.ComponentModel.TypeDescriptor.GetProperties(value);
                        property = properties[colInfo.PropertyPath[k++]];
                        if (property != null)
                        {
                            value = property.GetValue(value);
                        }
                    }

                    if (value != null)
                    {
                        string stringValue = value.ToString().ToLower().Trim();
                        for (int i = 0; i < forFind.Length; i++)
                        {
                            result = stringValue.Contains(forFind[i]);
                            if (result) return result;
                        }
                    }
                }
            }
            return result;
        }
    }
}
