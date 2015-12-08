using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace Abakon15WPF.Settings
{
    class UstawieniaAplikacji
    {
        public static void SaveParameters()
        {
            Abakon15WPF.Properties.Settings.Default._Language = myConverterCulture.CultureString;
            Abakon15WPF.Properties.Settings.Default._partnerId_DGHeader = !Abakon15WPF.Properties.Settings.Default._partnerId_DGHeader;
            Abakon15WPF.Properties.Settings.Default._partnerCode_DGHeader = !Abakon15WPF.Properties.Settings.Default._partnerId_DGHeader;
            Abakon15WPF.Properties.Settings.Default.Save();
        }

        public static void LoadParameters()
        {
            myConverterCulture.GetCulture(Abakon15WPF.Properties.Settings.Default._Language);
        }

        public class myConverterCulture : Binding
        {
            private static myConverterCulture instance;

            static CultureInfo currentCulture;
            public static CultureInfo CurrentCulture
            {
                get { return myConverterCulture.currentCulture; }
                set { myConverterCulture.currentCulture = value; }
            }

            static string _cultureString;
            public static string CultureString
            {
                get { return _cultureString; }
                private set { _cultureString = value; }
            }

            public myConverterCulture()
            {
                if (instance == null)
                {
                    currentCulture = ConverterCulture = new CultureInfo(_culStr);
                }
            }

            public myConverterCulture(string path)
                : base(path)
            {
                _cultureString = _culStr = path;
                currentCulture = ConverterCulture = new CultureInfo(_culStr);
                //  FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(path)));
            }

            public static myConverterCulture GetCulture()
            {
                if (instance == null)
                {
                    instance = new myConverterCulture();
                }
                return instance;
            }


            public static myConverterCulture GetCulture(string lang)
            {
                if (instance == null)
                {
                    instance = new myConverterCulture(lang);
                }
                return instance;
            }

            private string _culStr = "pl";
            private string CulStr
            {
                get { return _culStr; }
                set
                {
                    _culStr = value;
                    ConverterCulture = new CultureInfo(_culStr);
                }
            }
        }
    }
}
