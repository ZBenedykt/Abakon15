using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abakon15.Infrastructure;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Abakon15.ViewModels
{
    public class FilterPanelVM : ViewModelBase
    {

        ObservableCollection<FilterField> _FieldsCollection = null;
        public ObservableCollection<FilterField> FieldsCollection
        {
            get
            {
                if (_FieldsCollection == null)
                {
                    _FieldsCollection = new ObservableCollection<FilterField>();
                }
                return _FieldsCollection;
            }
            set { SetField(ref _FieldsCollection, value, () => FieldsCollection); }
        }

        FilterField _currentFromFieldsCollection;
        public FilterField CurrentFromFieldsCollection
        {
            get { return _currentFromFieldsCollection; }
            set { SetField(ref _currentFromFieldsCollection, value, () => CurrentFromFieldsCollection); }
        }


        bool _isORFieldsFiltered = true;
        public bool isORFieldsFiltered
        {
            get { return _isORFieldsFiltered; }
            set
            {
                SetField(ref _isORFieldsFiltered, value, () => isORFieldsFiltered);
                RaisePropertyChanged("AND_OR");
            }
        }

        public string AND_OR
        {
            get { return _isORFieldsFiltered ? "OR" : "AND"; }
        }

        ObservableCollection<FilterField> _FieldsFiltered = null;
        public ObservableCollection<FilterField> FieldsFiltered
        {
            get
            {
                if (_FieldsFiltered == null)
                {
                    _FieldsFiltered = new ObservableCollection<FilterField>();
                }
                return _FieldsFiltered;
            }
            set { SetField(ref _FieldsFiltered, value, () => FieldsFiltered); }
        }

        FilterField _currentFromFieldsFiltered;
        public FilterField CurrentFromFieldsFiltered
        {
            get { return _currentFromFieldsFiltered; }
            set { SetField(ref _currentFromFieldsFiltered, value, () => CurrentFromFieldsFiltered); }
        }



        string _FilterText = "";
        public string FilterText
        {
            get
            {
                return _FilterText;
            }
            set { SetField(ref _FilterText, value, () => FilterText); }
        }

        private string GetFIlterText()
        {
            string result = "";
            List<FilterField> mainFields = new List<FilterField>();
            List<FilterField> subFields = new List<FilterField>();
            foreach (var item in FieldsFiltered)
            {
                if (item.FieldNameWithPrefix.StartsWith("&"))
                {
                    subFields.Add(item);
                }
                else
                {
                    mainFields.Add(item);
                }
            }
            string mainGroup = mainFields.Count == 0 ? "" : GetFilterText(mainFields);
            string subGroup = subFields.Count == 0 ? "" : GetFilterText(subFields);
            result = subGroup == "" ? mainGroup : (mainGroup == "" ? subGroup : "(" + mainGroup + ") AND (" + subGroup + ")");
            FilterText = result;
            return result;
        }

        string GetFilterText(List<FilterField> fields)
        {
            StringBuilder sb = new StringBuilder();

            string op = isORFieldsFiltered ? " OR " : " AND ";
            string ConstObjectText = "";

            var items = fields.ToArray<FilterField>();
            if (items.Length > 0)
            {
                ConstObjectText = (items[0].ConstObject != null) ? items[0].ConstObject.ToString() : "~~";
                if (items[0].TypDanych == FilterTypyDanych.Integer || items[0].TypDanych == FilterTypyDanych.BigInteger || items[0].TypDanych == FilterTypyDanych.Decimal)
                {
                    sb = sb.AppendFormat("[{0}] {1} {2} ", items[0].DisplayText, items[0].MetodaKomparacji.ToString().Translate(), (items[0].MetodaKomparacji == OperatoryRelacjiEnum.Empty || items[0].MetodaKomparacji == OperatoryRelacjiEnum.NotEmpty) ? "" : ConstObjectText);
                }
                else
                {
                    sb = sb.AppendFormat("[{0}] {1} {2} ", items[0].DisplayText, items[0].MetodaKomparacji.ToString().Translate(), (items[0].MetodaKomparacji == OperatoryRelacjiEnum.Empty || items[0].MetodaKomparacji == OperatoryRelacjiEnum.NotEmpty) ? "" : "\"" + ConstObjectText + "\"");
                }

                int i = 1;
                while (i < items.Length)
                {
                    ConstObjectText = (items[i].ConstObject != null) ? items[i].ConstObject.ToString() : "~~";
                    if (items[i].TypDanych == FilterTypyDanych.Integer || items[i].TypDanych == FilterTypyDanych.BigInteger || items[i].TypDanych == FilterTypyDanych.Decimal)
                    {
                        sb = sb.AppendFormat("{0} [{1}] {2} {3} ", op, items[i].DisplayText, items[i].MetodaKomparacji.ToString().Translate(), ConstObjectText);
                    }
                    else
                    {
                        sb = sb.AppendFormat("{0} [{1}] {2} {3} ", op, items[i].DisplayText, items[i].MetodaKomparacji.ToString().Translate(),
                            (items[i].MetodaKomparacji == OperatoryRelacjiEnum.Empty || items[i].MetodaKomparacji == OperatoryRelacjiEnum.NotEmpty) ? "" : "\"" + ConstObjectText + "\"");
                    }
                    i++;
                }
            }

            return sb.ToString();
        }

        private string _FilterTextApplied;
        public string FilterTextApplied
        {
            get { return _FilterTextApplied; }
            set { SetField(ref _FilterTextApplied, value, () => FilterTextApplied); }
        }


        public void AddToFieldsFiltered()
        {
            if (_currentFromFieldsCollection != null)
            {
                FieldsFiltered.Add(_currentFromFieldsCollection.Clone());
            }
        }

        public void RemoveFromFieldsFiltered()
        {
            if (_currentFromFieldsFiltered != null && FieldsFiltered.Contains(_currentFromFieldsFiltered))
            {
                FieldsFiltered.Remove(_currentFromFieldsFiltered);
            }
        }


        public Expression<Func<T, bool>> BuildPredicate<T>(string prefix = "", bool field2 = false)
        {
            Expression<Func<T, bool>> predicate;


            List<FilterField> selItems = new List<FilterField>();
            if (!field2)
            {
                foreach (var item in FieldsFiltered.Where(p => p.FieldName != ""))
                {
                    if (item.FieldNameWithPrefix == "") item.SetFieldNameWithPrefix();
                    if (prefix != "")
                    {
                        Match m = Regex.Match(item.FieldNameWithPrefix, @"(" + prefix + @")\.([a-z,A-Z,\d,_,-]*)");
                        if (m.Success)
                        {
                            item.FieldName = m.Groups[2].Value;
                            selItems.Add(item);
                        }
                    }
                    else
                    {
                        if (!item.FieldNameWithPrefix.Contains('&'))
                        {
                            selItems.Add(item);
                        }
                    }
                }
            }
            else
            {
                foreach (var item in FieldsFiltered.Where(p => p.FieldName2 != ""))
                {
                    if (item.FieldNameWithPrefix == "") item.SetFieldNameWithPrefix();
                    if (prefix != "")
                    {
                        Match m = Regex.Match(item.FieldNameWithPrefix, @"(" + prefix + @")\.([a-z,A-Z,\d,_,-]*)");
                        if (m.Success)
                        {
                            item.FieldName2 = m.Groups[2].Value;
                            selItems.Add(item);
                        }
                    }
                    else
                    {
                        if (!item.FieldNameWithPrefix.Contains('&'))
                        {
                            selItems.Add(item);
                        }
                    }
                }
            }

            FilterText = GetFIlterText();
            var items = !field2 ? selItems.Where(p => p.FieldName != "").ToArray<FilterField>() : selItems.Where(p => p.FieldName2 != "").ToArray<FilterField>();
            if (items.Length > 0)
            {
                var itemInit = items[0]; // FieldsFiltered.First();

                if (!field2)
                {
                    predicate = PredicateBuilder.BuildExpression<T>(items[0].FieldName, items[0].MetodaKomparacji, items[0].ConstObject);

                    if (isORFieldsFiltered)
                    {
                        for (int i = 1; i < items.Length; i++)
                        {
                            var predicateRel = PredicateBuilder.BuildExpression<T>(items[i].FieldName, items[i].MetodaKomparacji, items[i].ConstObject);
                            predicate = PredicateBuilder.Or<T>(predicate, predicateRel);
                        }
                    }
                    else
                    {
                        for (int i = 1; i < items.Length; i++)
                        {
                            var predicateRel = PredicateBuilder.BuildExpression<T>(items[i].FieldName, items[i].MetodaKomparacji, items[i].ConstObject);
                            predicate = PredicateBuilder.And<T>(predicate, predicateRel);
                        }
                    }
                    FilterTextApplied = FilterText;
                    return predicate;
                }

                else
                {
                    predicate = PredicateBuilder.BuildExpression<T>(items[0].FieldName2, items[0].MetodaKomparacji, items[0].ConstObject);

                    if (isORFieldsFiltered)
                    {
                        for (int i = 1; i < items.Length; i++)
                        {
                            var predicateRel = PredicateBuilder.BuildExpression<T>(items[i].FieldName2, items[i].MetodaKomparacji, items[i].ConstObject);
                            predicate = PredicateBuilder.Or<T>(predicate, predicateRel);
                        }
                    }
                    else
                    {
                        for (int i = 1; i < items.Length; i++)
                        {
                            var predicateRel = PredicateBuilder.BuildExpression<T>(items[i].FieldName2, items[i].MetodaKomparacji, items[i].ConstObject);
                            predicate = PredicateBuilder.And<T>(predicate, predicateRel);
                        }
                    }
                    FilterTextApplied = FilterText;
                    return predicate;
                }
            }
            else
            {
                FilterTextApplied = "";
                return PredicateBuilder.False<T>();
            }



        }


        public event EventHandler FilterChanged;
        RelayCommand _FilterChangedCommand;
        public RelayCommand FilterChangedCommand
        {
            get
            {

                return _FilterChangedCommand ??
                       (_FilterChangedCommand = new RelayCommand(
                        param =>
                        {
                            OnFilterChanged();
                        },
                        param => true
                        ));
            }

        }

        protected void OnFilterChanged()
        {
            if (FilterChanged != null) FilterChanged(this, EventArgs.Empty);
        }

        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {
                case "FieldsFiltered":
                    RaisePropertyChanged("FilterText");
                    break;
                default:
                    break;
            }
        }
    }
}
