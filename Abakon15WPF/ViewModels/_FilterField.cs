using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abakon15WPF.Infrastructure;
using System.Windows.Controls;
using System.ComponentModel;


namespace Abakon15WPF.ViewModels
{
    public class FilterField : ViewModelBase, IDataErrorInfo
    {
        public event EventHandler FilterChanged;
        protected void OnFilterChanged()
        {
            if (FilterChanged != null) FilterChanged(this, EventArgs.Empty);
        }

        public FilterField()
        {
            this.SzukaneSlowa = "";
            TypDanych = FilterTypyDanych.String;
        }


        public FilterField Clone()
        {
            FilterField clone = new FilterField();
            clone.ApplyInFilter = this.ApplyInFilter;
            clone.DisplayText = this.DisplayText;
            clone.EnumType = this.EnumType;
            clone.FieldName = this.FieldName;
            clone.FieldName2 = this.FieldName2;
            clone.FieldNameWithPrefix = this.FieldNameWithPrefix;
            clone.ReferencePropertyFieldName = this.ReferencePropertyFieldName;
            clone.SzukaneSlowa = this.SzukaneSlowa;
            clone.TypDanych = this.TypDanych;
            clone.TypLiczby = this.TypLiczby;
            clone.MetodaKomparacji = this.MetodaKomparacji;
            return clone;
        }

        public void SetFieldNameWithPrefix()
        {
            FieldNameWithPrefix = FieldName;
        }

        string m_FieldName = "";
        public string FieldName
        {
            get { return m_FieldName; }
            set
            {
                SetField(ref m_FieldName, value, () => this.FieldName);
                OnFilterChanged();
            }
        }

        string m_FieldName2 = "";
        public string FieldName2
        {
            get { return m_FieldName2; }
            set
            {
                SetField(ref m_FieldName2, value, () => this.FieldName2);
                OnFilterChanged();
            }
        }

        string m_FieldNameWithPrefix = "";
        public string FieldNameWithPrefix
        {
            get { return m_FieldNameWithPrefix; }
            set
            {
                m_FieldNameWithPrefix = value;
                SetField(ref  m_FieldNameWithPrefix, value, () => this.FieldNameWithPrefix);
                OnFilterChanged();
            }
        }

        string m_DisplayText;
        public string DisplayText
        {
            get { return m_DisplayText; }
            set
            {
                SetField(ref m_DisplayText, value, () => DisplayText);
                OnFilterChanged();
            }
        }

        private EnumValuesCollection m_DostepneMetodyKomparacji = null;
        public EnumValuesCollection DostepneMetodyKomparacji
        {
            get
            {
                if (m_DostepneMetodyKomparacji == null)
                {
                    m_DostepneMetodyKomparacji = new EnumValuesCollection();
                    OperatoryRelacjiEnum[] metody = { };
                    switch (this.TypDanych)
                    {
                        case FilterTypyDanych.String:
                            metody = (new OperatoryRelacjiEnum[] 
                            { OperatoryRelacjiEnum.Equal, OperatoryRelacjiEnum.NotEqual,  OperatoryRelacjiEnum.LessEqual, OperatoryRelacjiEnum.Less, OperatoryRelacjiEnum.Greater , OperatoryRelacjiEnum.GreaterEqual , 
                             OperatoryRelacjiEnum.Contains, OperatoryRelacjiEnum.NotContains,  OperatoryRelacjiEnum.BeginsWith, OperatoryRelacjiEnum.NotBeginsWith, OperatoryRelacjiEnum.Empty, OperatoryRelacjiEnum.NotEmpty
                             }); //OperatoryRelacjiEnum.Empty, OperatoryRelacjiEnum.NotEmpty
                            break;
                        case FilterTypyDanych.Integer:
                        case FilterTypyDanych.BigInteger:
                        case FilterTypyDanych.Decimal:
                        case FilterTypyDanych.Double:
                            metody = (new OperatoryRelacjiEnum[] { OperatoryRelacjiEnum.Equal, OperatoryRelacjiEnum.LessEqual, OperatoryRelacjiEnum.Less
                            , OperatoryRelacjiEnum.Greater , OperatoryRelacjiEnum.GreaterEqual ,  OperatoryRelacjiEnum.NotEqual
                            });
                            break;
                        case FilterTypyDanych.Date:
                        case FilterTypyDanych.DateTime:
                            metody = (new OperatoryRelacjiEnum[] { OperatoryRelacjiEnum.Equal, OperatoryRelacjiEnum.LessEqual, OperatoryRelacjiEnum.Less
                            , OperatoryRelacjiEnum.Greater , OperatoryRelacjiEnum.GreaterEqual ,  OperatoryRelacjiEnum.NotEqual, OperatoryRelacjiEnum.Empty
                            });
                            break;

                        case FilterTypyDanych.Bool:
                        case FilterTypyDanych.Enumeration:
                            metody = (new OperatoryRelacjiEnum[] { OperatoryRelacjiEnum.Equal, OperatoryRelacjiEnum.NotEqual });
                            break;

                        default:
                            break;
                    }
                    m_DostepneMetodyKomparacji.FillByValues(metody.Cast<Enum>());
                }
                return m_DostepneMetodyKomparacji;
            }

        }

        public string GetFieldPath()
        {
            return string.IsNullOrEmpty(m_ReferencePropertyFieldName) ? this.FieldName : this.FieldName + "." + this.ReferencePropertyFieldName;
        }

        string m_ReferencePropertyFieldName;
        public string ReferencePropertyFieldName
        {
            get { return m_ReferencePropertyFieldName; }
            set { SetField(ref m_ReferencePropertyFieldName, value, () => ReferencePropertyFieldName); }
        }

        Type m_EnumType;
        public Type EnumType
        {
            get { return m_EnumType; }
            set { SetField(ref m_EnumType, value, () => EnumType); }
        }


        bool m_ApplyInFilter;
        public bool ApplyInFilter
        {
            get { return m_ApplyInFilter; }
            set { SetField(ref m_ApplyInFilter, value, () => ApplyInFilter); }
        }

        FilterTypyDanych m_TypDanych;
        public FilterTypyDanych TypDanych
        {
            get
            {
                return m_TypDanych;
            }
            set
            {
                SetField(ref m_TypDanych, value, () => TypDanych);
                if (value == FilterTypyDanych.String)
                {
                    MetodaKomparacji = OperatoryRelacjiEnum.Contains;
                }
                else
                {
                    MetodaKomparacji = OperatoryRelacjiEnum.Equal;
                }
            }
        }

        FilterTypLiczby m_TypLiczby = FilterTypLiczby.Default;
        public FilterTypLiczby TypLiczby
        {
            get { return m_TypLiczby; }
            set { m_TypLiczby = value; }
        }

        OperatoryRelacjiEnum m_MetodaKomparacji;
        public OperatoryRelacjiEnum MetodaKomparacji
        {
            get { return m_MetodaKomparacji; }
            set
            {
                SetField(ref m_MetodaKomparacji, value, () => MetodaKomparacji);

                RaisePropertyChanged("isVisibleSzukaneSlowa");
                OnFilterChanged();
            }
        }

        string m_SzukaneSlowa;
        public string SzukaneSlowa
        {
            get { return m_SzukaneSlowa; }
            set { SetField(ref m_SzukaneSlowa, value, () => SzukaneSlowa); }
        }

        object m_constObject;
        public object ConstObject
        {
            get { return m_constObject; }
            set
            {
                SetField(ref m_constObject, value, () => ConstObject);
                OnFilterChanged();
            }
        }

        public System.Windows.Visibility isVisibleSzukaneSlowa
        {
            get
            {
                if (MetodaKomparacji == OperatoryRelacjiEnum.Empty || MetodaKomparacji == OperatoryRelacjiEnum.NotEmpty)
                {
                    return System.Windows.Visibility.Collapsed;
                }
                else
                {
                    return System.Windows.Visibility.Visible;
                }
            }
        }

        #region IDataErrorInfo Members ==========================================================================

        public string Error
        {
            get
            {
                return FieldName;
            }
        }

        public string this[string columnName]
        {
            get
            {
                var results = new List<ValidationResult>();
                StringBuilder errStrBuilder = new StringBuilder();
                errStrBuilder.Clear();
                switch (columnName)
                {
                    case "SzukaneSlowa":
                        FilterValidation(results);
                        break;

                    default:
                        break;

                }

                foreach (ValidationResult item in results)
                {
                    errStrBuilder.AppendLine(item.ErrorContent.ToString());
                }
                return errStrBuilder.ToString();
            }
        }

        private void FilterValidation(List<ValidationResult> results)
        {
            ConstObject = "";
            switch (TypDanych)
            {
                case FilterTypyDanych.String:
                    if (SzukaneSlowa == null || SzukaneSlowa.Trim().Length == 0)
                    {
                        results.Add(new ValidationResult(false, "_fildCanNotBeBlank".Translate()));
                    }
                    ConstObject = SzukaneSlowa;
                    break;
                case FilterTypyDanych.Integer:
                    int i = 0;

                    if (!int.TryParse(SzukaneSlowa, out i))
                    {
                        results.Add(new ValidationResult(false, "_needInteger".Translate()));
                    }
                    else
                    {
                        ConstObject = i;
                    }
                    break;
                case FilterTypyDanych.BigInteger:
                    long iLong = 0;
                    if (!long.TryParse(SzukaneSlowa, out iLong))
                    {
                        results.Add(new ValidationResult(false, "_needInteger".Translate()));
                    }
                    else
                    {
                        ConstObject = iLong;
                    }
                    break;
                case FilterTypyDanych.Decimal:
                    decimal d = 0;
                    if (!decimal.TryParse(SzukaneSlowa, out d))
                    {
                        results.Add(new ValidationResult(false, "_needDecimal".Translate()));
                    }
                    else
                    {
                        ConstObject = d;
                    }
                    break;
                case FilterTypyDanych.Double:
                    double doubleValue = 0;
                    if (!double.TryParse(SzukaneSlowa, out doubleValue))
                    {
                        results.Add(new ValidationResult(false, "_needDecimal".Translate()));
                    }
                    else
                    {
                        ConstObject = doubleValue;
                    }
                    break;
                case FilterTypyDanych.Date:
                case FilterTypyDanych.DateTime:
                    DateTime date = DateTime.MinValue;
                    if (!DateTime.TryParse(SzukaneSlowa, System.Globalization.CultureInfo.CurrentUICulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out date))
                    {
                        results.Add(new ValidationResult(false, "_needDate".Translate()));
                    }
                    else
                    {
                        ConstObject = date;
                    }
                    break;
                case FilterTypyDanych.Bool:
                    bool ok = false;
                    string value = SzukaneSlowa.Trim().ToLower();
                    if (value == "tak" || value == "prawda" || value == "true") { ConstObject = true; ok = true; }
                    if (value == "nie" || value == "fałsz" || value == "false") { ConstObject = false; ok = true; }

                    if (!ok)
                    {
                        results.Add(new ValidationResult(false, "_needLogical".Translate()));
                    }

                    break;
                case FilterTypyDanych.Enumeration:
                    break;
                default:
                    break;
            }
        }

        #endregion

    }


    public enum OperatoryRelacjiEnum   //for PredicateBuilder
    {
        Equal,
        NotEqual,
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Contains,
        NotContains,
        BeginsWith,
        NotBeginsWith,
        Empty,
        NotEmpty
    }

    public enum FilterTypyDanych
    {
        String,
        Integer,
        BigInteger,
        Double,
        Decimal,
        Date,
        DateTime,
        Bool,
        Enumeration
    }

    public enum FilterTypLiczby // dor filterePanelVM
    {
        Default,
        Integer,
        Byte,
        Decimal,
        Float,
        Double,

    }


    public class EnumValuesCollection : List<EnumListItem>
    {
        protected Type m_TypPolaValue = typeof(int);

        public EnumValuesCollection()
        {

        }

        public void FillByValues(IEnumerable<Enum> values)
        {
            EnumListItem itm;
            int key = 0;
            Type t;
            foreach (Enum v in values)
            {
                t = v.GetType();
                key = Convert.ToInt32(v);
                itm = new EnumListItem
                {

                    ValueInt = key,
                    ValueByte = Convert.ToByte(key),
                    ValueEnum = (Enum)Enum.ToObject(t, key),
                    DisplayValue = EnumHelper.GetDisplayText((Enum)Enum.ToObject(t, key)).Translate(),
                };
                this.Add(itm);
            }
        }

        //    public EnumValuesCollection(Type typEnumeratora)
        //    {
        //        FillByEnumerator(typEnumeratora);
        //    }

        //    public EnumValuesCollection(Type typEnumeratora, int[] selected)
        //    {

        //        FillByEnumerator(typEnumeratora, selected);
        //    }



        //    public void FillByEnumerator(Type typEnumeratora)
        //    {
        //        FillByValues(Enum.GetValues(typEnumeratora).Cast<Enum>());   
        //    }




        //    public void FillByEnumerator(Type typEnumeratora, int[] selected)
        //    {
        //        EnumListItem itm;
        //        for (int key = 0; key < selected.Length; key++)
        //        {
        //            itm = new EnumListItem
        //            {
        //                ValueInt = key,
        //                ValueEnum = (Enum)Enum.ToObject(typEnumeratora, key),
        //                DisplayValue = EnumHelper.GetDisplayText((Enum)Enum.ToObject(typEnumeratora, key)).Translate(),

        //            };
        //            this.Add(itm);
        //        }

        //    }
    }

    public class EnumListItem
    {
        public Enum ValueEnum { get; set; }
        public int ValueInt { get; set; }
        public byte ValueByte { get; set; }
        public string DisplayValue { get; set; }
        public override string ToString()
        {
            return DisplayValue;
        }


    }
}
