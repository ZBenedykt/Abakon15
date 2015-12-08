using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace Abakon15WPF.Infrastructure
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class BoolRevertConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool vart = !((bool)value);
            return vart;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool vart = !((bool)value);
            return vart;
        }

        #endregion
    }

    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = false;
            if (value is bool)
            {
                flag = (bool)value;
            }
            else if (value is bool?)
            {
                var nullable = (bool?)value;
                flag = nullable.GetValueOrDefault();
            }
            if (parameter != null)
            {
                if (!bool.Parse((string)parameter))
                {
                    flag = !flag;
                }
            }
            if (flag)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var back = ((value is Visibility) && (((Visibility)value) == Visibility.Visible));
            if (parameter != null)
            {
                if ((bool)parameter)
                {
                    back = !back;
                }
            }
            return back;
        }
    }

    [ValueConversion(typeof(double), typeof(double))]
    public class WielokrotnoscDoubleConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double factor = 1;

            double.TryParse(parameter.ToString(), NumberStyles.AllowDecimalPoint, culture, out factor);
            double vart = (double)value / factor;
            return vart;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double factor = 1;
            double.TryParse(parameter.ToString(), NumberStyles.AllowDecimalPoint, culture, out factor);
            double val = 0;
            double.TryParse(value.ToString(), out val);
            double vart = val * factor;
            return vart;
        }

        #endregion

    }

    [ValueConversion(typeof(int), typeof(int))]
    public class ZeroBaseIndexConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int vart = (int)value + 1;
            return vart;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int val = 0;
            int.TryParse(value.ToString(), out val);
            int vart = val - 1;
            return vart;
        }

        #endregion

    }


    public class NullToBooleanConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

    }

    [ValueConversion(typeof(DataGridSelectionUnit), typeof(bool))]
    public class SelectionUnitConverter : IValueConverter
    {
        #region IValueConverter Members


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if ((DataGridSelectionUnit)value == (DataGridSelectionUnit)Enum.Parse(typeof(DataGridSelectionUnit), parameter.ToString()))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if ((bool)value)
                {
                    return Enum.Parse(typeof(DataGridSelectionUnit), parameter.ToString());
                }
                else
                {
                    return DataGridSelectionUnit.FullRow;
                }
            }
            catch (Exception)
            {

                return DataGridSelectionUnit.FullRow;
            }
        }
        #endregion

    }

    [ValueConversion(typeof(string), typeof(FlowDocument))]
    public class FlowDocumentToXamlConverter : IValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        /// Converts from XAML markup to a WPF FlowDocument.
        /// </summary>
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            /* See http://stackoverflow.com/questions/897505/getting-a-flowdocument-from-a-xaml-template-file */

            var flowDocument = new FlowDocument();
            if (value != null)
            {
                var xamlText = (string)value;
                try
                {
                    flowDocument = (FlowDocument)XamlReader.Parse(xamlText);
                }
                catch (Exception)
                {
                    xamlText = "<FlowDocument PagePadding=\"5,0,5,0\" AllowDrop=\"True\" "
                 + "xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">"
                 + "<Paragraph Foreground=\"Maroon\">Błędny format tekstu !</Paragraph><Paragraph>Proszę wprowdzić poprawny!</Paragraph></FlowDocument>";

                    flowDocument = (FlowDocument)XamlReader.Parse(xamlText);
                }
            }

            // Set return value
            return flowDocument;
        }

        /// <summary>
        /// Converts from a WPF FlowDocument to a XAML markup string.
        /// </summary>
        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            /* This converter does not insert returns or indentation into the XAML. If you need to 
             * indent the XAML in a text box, see http://www.knowdotnet.com/articles/indentxml.html */

            // Exit if FlowDocument is null
            if (value == null) return string.Empty;

            // Get flow document from value passed in
            var flowDocument = (FlowDocument)value;

            // Convert to XAML and return
            return XamlWriter.Save(flowDocument);
        }

        #endregion
    }

    class MultiBooleanToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values,
                                Type targetType,
                                object parameter,
                                System.Globalization.CultureInfo culture)
        {
            if (values[0] is bool && (bool)values[0] == false) { return System.Windows.Visibility.Visible; }
            bool visible = true;
            foreach (object value in values)
                if (value is bool)
                    visible = visible && (bool)value;

            if (visible)
                return System.Windows.Visibility.Visible;
            else
                return System.Windows.Visibility.Collapsed;
        }

        public object[] ConvertBack(object value,
                                    Type[] targetTypes,
                                    object parameter,
                                    System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class UpadateSignatureFormatter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("{0}: {1}  {2}: {3} \n {4}: {5}", "_8_CreateDate_Label".Translate(), values[0],
                "_8_LastUpdateDate_Label".Translate(), values[1], "_8_UserName_Label".Translate(), values[2]);
        }
        public object[] ConvertBack(object value,
                                Type[] targetTypes,
                                object parameter,
                                System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(GridLength), typeof(double))]
    public class GridLengthConverter : IValueConverter
    {
        #region IValueConverter Members


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new GridLength((double)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((GridLength)value).Value;
        }
        #endregion

    }
}
