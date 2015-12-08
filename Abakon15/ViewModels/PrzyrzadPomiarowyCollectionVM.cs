using System;
using System.Collections.Generic;
using System.Linq;
using Abakon15.Infrastructure;
using System.ComponentModel;
using System.Windows;
using Abakon15.Interfaces;
using System.Collections.ObjectModel;
using AbakonDataModel;
using Abakon15.Views.Windows;
using System.Windows.Documents;
using Abakon15.Utility;
using Abakon15.Reports;
using AbakonDataModel.Infrastructure;
using Microsoft.Office.Interop.Word;
namespace Abakon15.ViewModels
{
    public class PrzyrzadPomiarowyCollectionVM : ViewModelBase, IPrzyrzadPomiarowy
    {

        public enum SelectionTab
        {
            None,
            ByFilter,
            ByKalibratory,
            ByResposibilities,
            ByTasks
        }

        public enum DetailSelectionTab
        {
            None,
            ByDetails,
            ByCalibratedEquipment
        }

        public int IloscZapisowWBazie
        {
            get { return PrzyrzadPomiarowy.IloscZapisowWBazie; }
            set { }
        }

        private List<Person> _personList;
        public List<Person> PersonList
        {
            get
            {
                if (_personList == null)
                {
                    {
                        _personList = new List<Person>(Person.LoadLabWorkers());
                    }
                }
                return _personList;
            }
        }

        Visibility _visibileAllEquipmentAccess;
        public Visibility VisibleAllEquipmentAccess
        {
            get { return _visibileAllEquipmentAccess; }
            set { _visibileAllEquipmentAccess = value; }
        }


        List<KeyValuePair<string, int>> chartList = new List<KeyValuePair<string, int>>();
        public List<KeyValuePair<string, int>> ChartList
        {
            get { return chartList; }
            set { SetField(ref chartList, value, () => ChartList); }
        }

        List<Tuple<int, string>> _EquipmentTypeEnumTranslate = new List<Tuple<int, string>>(Abakon15.Infrastructure.EnumHelper.TranslateEnumerator<EquipmentTypeEnum>());
        public List<Tuple<int, string>> EquipmentTypeEnumTranslate
        {
            get { return _EquipmentTypeEnumTranslate; }
        }

        List<Tuple<int, string>> _LegalizacjaEnumTranslate = new List<Tuple<int, string>>(Abakon15.Infrastructure.EnumHelper.TranslateEnumerator<LegalizacjaEnum>());
        public List<Tuple<int, string>> LegalizacjaEnumTranslate
        {
            get { return _LegalizacjaEnumTranslate; }
        }

        List<Tuple<int, string>> _TypWlasnosciEnumTranslate = new List<Tuple<int, string>>(Abakon15.Infrastructure.EnumHelper.TranslateEnumerator<TypWlasnosciEnum>());
        public List<Tuple<int, string>> TypWlasnosciEnumTranslate
        {
            get { return _TypWlasnosciEnumTranslate; }
        }

        List<Tuple<int, string>> _DokladnoscWgEnumTranslate = new List<Tuple<int, string>>(Abakon15.Infrastructure.EnumHelper.TranslateEnumerator<DokladnoscWgEnum>());
        public List<Tuple<int, string>> DokladnoscWgEnumTranslate
        {
            get { return _DokladnoscWgEnumTranslate; }
        }

        private int _SelectedEquipmentType = (int)EquipmentTypeEnum.PrzyrzadyWszystkie;
        public int SelectedEquipmentTypeOld
        {
            get { return _SelectedEquipmentType; }
            set
            {
                SetField(ref _SelectedEquipmentType, value, () => SelectedEquipmentTypeOld);
                TypeVisibility = SelectedEquipmentTypeEnum == EquipmentTypeEnum.PrzyrzadyWszystkie ? Visibility.Visible : Visibility.Collapsed;
                Abakon15.Properties.Settings.Default._1_SelectedEquipmentType_ColumnVisibility = SelectedEquipmentTypeEnum == EquipmentTypeEnum.PrzyrzadyWszystkie; //Sztuczka z bindowaniem widocznosci kolumny w DataGrid
                RaisePropertyChanged("SelectedEquipmentTypeEnum");
            }
        }

        public EquipmentTypeEnum SelectedEquipmentTypeEnum
        {
            get { return (EquipmentTypeEnum)SelectedEquipmentTypeOld; }
        }

        private EquipmentScope _SelectedZakres;
        public EquipmentScope SelectedZakres
        {
            get { return _SelectedZakres; }
            set
            {
                SetField(ref _SelectedZakres, value, () => SelectedZakres);
            }
        }

        bool _canAddRecords = false;
        public bool CanAddRecords
        {
            get { return _canAddRecords; }
            set { SetField(ref _canAddRecords, value, () => CanAddRecords); }
        }



        #region Widoczność UC dla wybranego typu przyrządu

        Visibility _TypeVisibility;
        public Visibility TypeVisibility
        {
            get { return _TypeVisibility; }
            set { SetField(ref _TypeVisibility, value, () => TypeVisibility); }
        }

        Visibility _VisibleDetails = Visibility.Collapsed;
        public Visibility VisibleDetails
        {
            get { return _VisibleDetails; }
            set { SetField(ref _VisibleDetails, value, () => VisibleDetails); }
        }

        Visibility _VisibleElektryczne = Visibility.Collapsed;
        public Visibility VisibleElektryczne
        {
            get { return _VisibleElektryczne; }
            set { SetField(ref _VisibleElektryczne, value, () => VisibleElektryczne); }
        }

        Visibility _VisibleMechaniczne = Visibility.Collapsed;
        public Visibility VisibleMechaniczne
        {
            get { return _VisibleMechaniczne; }
            set { SetField(ref _VisibleMechaniczne, value, () => VisibleMechaniczne); }
        }

        Visibility _VisibleSprawdziany = Visibility.Collapsed;
        public Visibility VisibleSprawdziany
        {
            get { return _VisibleSprawdziany; }
            set { SetField(ref _VisibleSprawdziany, value, () => VisibleSprawdziany); }
        }

        Visibility _VisibleSprawdzianyDoGwintow = Visibility.Collapsed;
        public Visibility VisibleSprawdzianyDoGwintow
        {
            get { return _VisibleSprawdzianyDoGwintow; }
            set { SetField(ref _VisibleSprawdzianyDoGwintow, value, () => VisibleSprawdzianyDoGwintow); }
        }


        Visibility _VisibleCopyButton = Visibility.Collapsed;
        public Visibility VisibleCopyButton
        {
            get { return _VisibleCopyButton; }
            set { SetField(ref _VisibleCopyButton, value, () => VisibleCopyButton); }
        }

        Visibility _VisibleEraseButton = Visibility.Collapsed;
        public Visibility VisibleEraseButton
        {
            get { return _VisibleEraseButton; }
            set { SetField(ref _VisibleEraseButton, value, () => VisibleEraseButton); }
        }

        #endregion

        #region  Filter TabItem selection region

        private SelectionTab _isSelectedBy = SelectionTab.ByFilter;
        public SelectionTab isSelectedBy
        {
            get { return _isSelectedBy; }
            set { SetField(ref _isSelectedBy, value, () => isSelectedBy); }
        }

        private bool _isSelectedByKalibratory = false;
        public bool isSelectedByKalibratory
        {
            get { return _isSelectedByKalibratory; }
            set
            {
                _isSelectedByKalibratory = value;
                if (value)
                {
                    isSelectedBy = SelectionTab.ByKalibratory;

                }
            }
        }

        private bool _isSelectedByResposibilities = false;
        public bool isSelectedByResposibilities
        {
            get { return _isSelectedByResposibilities; }
            set
            {
                _isSelectedByResposibilities = value;
                if (value)
                {
                    isSelectedBy = SelectionTab.ByResposibilities;

                }
            }
        }

        private bool _isSelectedByTasks = false;
        public bool isSelectedByTasks
        {
            get { return _isSelectedByTasks; }
            set
            {
                _isSelectedByTasks = value;
                if (value)
                {
                    isSelectedBy = SelectionTab.ByTasks;

                }
            }
        }

        private bool _isSelectedByFilter = true;
        public bool isSelectedByFilter
        {
            get { return _isSelectedByFilter; }
            set
            {
                _isSelectedByFilter = value;
                if (value)
                {
                    isSelectedBy = SelectionTab.ByFilter;
                }

            }
        }


        #endregion

        #region  Details TabItem selection region

        private DetailSelectionTab _isDetailsSelectedBy = DetailSelectionTab.ByDetails;
        public DetailSelectionTab isDetailsSelectedBy
        {
            get { return _isDetailsSelectedBy; }
            set { SetField(ref _isDetailsSelectedBy, value, () => isDetailsSelectedBy); }
        }

        private bool _isDetailsSelectedByDetails = true;
        public bool isDetailsSelectedByDetails
        {
            get { return _isDetailsSelectedByDetails; }
            set
            {
                _isDetailsSelectedByDetails = value;
                if (value)
                {
                    isDetailsSelectedBy = DetailSelectionTab.ByDetails;

                }
            }
        }

        private bool _isDetailsSelectedyCalibratedEquipment = false;
        public bool isDetailsSelectedyCalibratedEquipment
        {
            get { return _isDetailsSelectedyCalibratedEquipment; }
            set
            {
                _isDetailsSelectedyCalibratedEquipment = value;
                if (value)
                {
                    isDetailsSelectedBy = DetailSelectionTab.ByCalibratedEquipment;
                }

            }
        }


        #endregion


        #region IPrzyrzadPomiarowy Members
        private PrzyrzadPomiarowy _CurrentPrzyrzadPomiarowy;
        public PrzyrzadPomiarowy CurrentPrzyrzadPomiarowy
        {
            get { return _CurrentPrzyrzadPomiarowy; }
            set
            {
                SetField(ref _CurrentPrzyrzadPomiarowy, value, () => CurrentPrzyrzadPomiarowy);
            }
        }


        #endregion

        #region Patterns & documents properties
        private ObservableCollection<FilePath> _FilePathList = new ObservableCollection<FilePath>(FilePath.Load());
        public ObservableCollection<FilePath> FilePathList
        {
            get { return _FilePathList; }
            set
            {
                SetField(ref _FilePathList, value, () => FilePathList);
            }
        }

        private FilePath _currentFilePath;
        public FilePath CurrentFilePath
        {
            get { return _currentFilePath; }
            set
            {
                SetField(ref _currentFilePath, value, () => CurrentFilePath);
            }
        }

        private ObservableCollection<FilePath> _TemplatePathList = new ObservableCollection<FilePath>(FilePath.Load());
        public ObservableCollection<FilePath> TemplatePathList
        {
            get { return _TemplatePathList; }
            set
            {
                SetField(ref _TemplatePathList, value, () => TemplatePathList);
            }
        }
        private FilePath _currentTemplatePath;
        public FilePath CurrentTemplatePath
        {
            get { return _currentTemplatePath; }
            set
            {
                SetField(ref _currentTemplatePath, value, () => CurrentTemplatePath);
            }
        }

        private ObservableCollection<string> _TemplateListList = new ObservableCollection<string>();
        public ObservableCollection<string> TemplateList
        {
            get { return _TemplateListList; }
            set
            {
                SetField(ref _TemplateListList, value, () => TemplateList);
            }
        }

        private string _selectedPattern;
        public string SelectedPattern
        {
            get { return _selectedPattern; }
            set { SetField(ref _selectedPattern, value, () => SelectedPattern); }
        }


        #endregion

        private PrzyrzadPomiarowy _SelectedPrzyrzadPomiarowy;
        public PrzyrzadPomiarowy SelectedPrzyrzadPomiarowy //używany gdy do niego dobiera się kalibratory - okno PrzyrzadPomiarowySelect
        {
            get { return _SelectedPrzyrzadPomiarowy; }
            set
            {
                SetField(ref _SelectedPrzyrzadPomiarowy, value, () => SelectedPrzyrzadPomiarowy);
            }
        }

        private Kalibracja _SelectedKalibracja;
        public Kalibracja SelectedKalibracja //używany gdy do niego dobiera się kalibratory - okno KalibracjaSelect
        {
            get { return _SelectedKalibracja; }
            set
            {
                SetField(ref _SelectedKalibracja, value, () => SelectedKalibracja);
            }
        }

        Department _selectedDepartment = null;
        public Department SelectedDepartment
        {
            get { return _selectedDepartment; }
            set { SetField(ref _selectedDepartment, value, () => SelectedDepartment); }
        }

        string _selectedDepartmentPath = "Wszystkie";
        [PrintAttribute(PatternName = "#Dział")]
        public string SelectedDepartmentPath
        {
            get { return _selectedDepartmentPath; }
            set { SetField(ref _selectedDepartmentPath, value, () => SelectedDepartmentPath); }
        }

        EquipmentType _selectedEquipmentType = null;
        public EquipmentType SelectedEquipmentType
        {
            get { return _selectedEquipmentType; }
            set { SetField(ref _selectedEquipmentType, value, () => SelectedEquipmentType); }
        }

        string _selectedEquipmentTypePath = "Wszystkie";
        [PrintAttribute(PatternName = "#Typ")]
        public string SelectedEquipmentTypePath
        {
            get { return _selectedEquipmentTypePath; }
            set { SetField(ref _selectedEquipmentTypePath, value, () => SelectedEquipmentTypePath); }
        }


        private string _predicateString = "";
        [PrintAttribute(PatternName = "#WarunekWyboru")]
        public string PredicateString
        {
            get { return _predicateString; }
            set { SetField(ref _predicateString, value, () => PredicateString); }
        }

        private ViewableObservableCollection<PrzyrzadPomiarowy> _PrzyrzadPomiarowyCollection = new ViewableObservableCollection<PrzyrzadPomiarowy>();
        [PrintAttribute(PatternName = "#Przyrzady")]
        public ViewableObservableCollection<PrzyrzadPomiarowy> PrzyrzadPomiarowyCollection
        {
            get { return _PrzyrzadPomiarowyCollection; }
            set
            {
                SetField(ref _PrzyrzadPomiarowyCollection, value, () => PrzyrzadPomiarowyCollection);
            }
        }


        // todo dynamiczna kolekcja wypełnienie
        //public ObservableCollection<dynamic> PrzyrzadPomiarowySQLCollection
        //{ get; set; }



        private ViewableObservableCollection<PrzyrzadPomiarowy> _PrzyrzadKalibrowanyCollection = new ViewableObservableCollection<PrzyrzadPomiarowy>();
        public ViewableObservableCollection<PrzyrzadPomiarowy> PrzyrzadKalibrowanyCollection
        {
            get { return _PrzyrzadKalibrowanyCollection; }
            set
            {
                SetField(ref _PrzyrzadKalibrowanyCollection, value, () => PrzyrzadKalibrowanyCollection);
            }
        }

        private PrzyrzadPomiarowy _CurrentPrzyrzadKalibrowany;
        public PrzyrzadPomiarowy CurrentPrzyrzadKalibrowany
        {
            get { return _CurrentPrzyrzadKalibrowany; }
            set
            {
                SetField(ref _CurrentPrzyrzadKalibrowany, value, () => CurrentPrzyrzadKalibrowany);
            }
        }
        private FilterPanelVM _myFilteredPanel = new FilterPanelVM();
        [PrintAttribute(PatternName = "#Filtr")]
        public FilterPanelVM MyFilteredPanel
        {
            get { return _myFilteredPanel; }
            set { SetField(ref _myFilteredPanel, value, () => MyFilteredPanel); }
        }

        List<Person> _filterResposiblePersons = new List<Person>();
        public List<Person> FilterResposiblePersons
        {
            get { return _filterResposiblePersons; }
            set { SetField(ref _filterResposiblePersons, value, () => FilterResposiblePersons); }
        }

        private bool _filterCheckCalibrationDate = false;
        public bool FilterCheckCalibrationDate
        {
            get { return _filterCheckCalibrationDate; }
            set { SetField(ref _filterCheckCalibrationDate, value, () => FilterCheckCalibrationDate); }
        }

        private DateTime _filterCalibrationDateFrom;
        public DateTime FilterCalibrationDateFrom
        {
            get { return _filterCalibrationDateFrom; }
            set { SetField(ref _filterCalibrationDateFrom, value, () => FilterCalibrationDateFrom); }
        }

        private DateTime _filterCalibrationDateTo;
        public DateTime FilterCalibrationDateTo
        {
            get { return _filterCalibrationDateTo; }
            set { SetField(ref _filterCalibrationDateTo, value, () => FilterCalibrationDateTo); }
        }

        private bool _filterActiveEquipment = true;
        public bool FilterActiveEquipment
        {
            get { return _filterActiveEquipment; }
            set { SetField(ref _filterActiveEquipment, value, () => FilterActiveEquipment); }
        }

        private bool _filterDiscontinuedEquipment = false;
        public bool FilterDiscontinuedEquipment
        {
            get { return _filterDiscontinuedEquipment; }
            set { SetField(ref _filterDiscontinuedEquipment, value, () => FilterDiscontinuedEquipment); }
        }

        Collection<FilterField> FieldsCollectionPrzyrzadyWszystkie = new Collection<FilterField>();
        Collection<FilterField> FieldsCollectionElektryczne = new Collection<FilterField>();
        Collection<FilterField> FieldsCollectionMechaniczne = new Collection<FilterField>();
        Collection<FilterField> FieldsCollectionSprawdziany = new Collection<FilterField>();
        Collection<FilterField> FieldsCollectionSprawdzianyDoGwintow = new Collection<FilterField>();



        public PrzyrzadPomiarowyCollectionVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                _filterCalibrationDateFrom = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
                _filterCalibrationDateTo = _filterCalibrationDateFrom.AddMonths(1).AddDays(-1);
                this.MyFilteredPanel.FilterChanged += new EventHandler(MyFilteredPanel_FilterChanged);

                FilterField startFieldForFiltering = new FilterField { FieldName = "PrzyrzadPomiarowyNrKod", DisplayText = "_1_PrzyrzadPomiarowyNrKod_Label".Translate(), TypDanych = FilterTypyDanych.Integer, MetodaKomparacji = OperatoryRelacjiEnum.Equal };
                this.MyFilteredPanel.FieldsFiltered.Add(startFieldForFiltering);

                FieldsCollectionPrzyrzadyWszystkie.Add(startFieldForFiltering);
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "NrEwid", DisplayText = "_1_NrEwid_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "Nazwa", DisplayText = "_1_Nazwa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "DataNastepnegoBadania", DisplayText = "_1_DataNastepnegoBadania_Label".Translate(), TypDanych = FilterTypyDanych.Date, MetodaKomparacji = OperatoryRelacjiEnum.LessEqual });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "DataOstatniegoBadania", DisplayText = "_1_DataOstatniegoBadania_Label".Translate(), TypDanych = FilterTypyDanych.Date, MetodaKomparacji = OperatoryRelacjiEnum.LessEqual });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "SymbolProducenta", DisplayText = "_1_SymbolProducenta_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "UserName", DisplayText = "_1_UserName_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "producent", DisplayText = "_1_producent_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "Flow2", DisplayText = "_1_Flow2Test_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "NrFabryczny", DisplayText = "_1_NrFabryczny_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "SubGrupa", DisplayText = "_1_SubGrupa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "RokProdukcji", DisplayText = "_1_RokProdukcji_Label".Translate(), TypDanych = FilterTypyDanych.Integer, MetodaKomparacji = OperatoryRelacjiEnum.Equal });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "TypWlasnosci", DisplayText = "_1_TypWlasnosci_Label".Translate(), TypDanych = FilterTypyDanych.Integer, MetodaKomparacji = OperatoryRelacjiEnum.Equal });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "Legalizacja", DisplayText = "_1_Legalizacja_Label".Translate(), TypDanych = FilterTypyDanych.Integer, MetodaKomparacji = OperatoryRelacjiEnum.Equal });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "CzasokresSprawdzania", DisplayText = "_1_CzasokresSprawdzania_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "CreateDate", DisplayText = "_1_CreateDate_Label".Translate(), TypDanych = FilterTypyDanych.Date, MetodaKomparacji = OperatoryRelacjiEnum.GreaterEqual });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "LastUpdateDate", DisplayText = "_1_LastUpdateDate_Label".Translate(), TypDanych = FilterTypyDanych.Date, MetodaKomparacji = OperatoryRelacjiEnum.GreaterEqual });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "NrInwentarzowy", DisplayText = "_1_NrInwentarzowy_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "NrSAP", DisplayText = "_1_NrSAP_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "Note1", DisplayText = "_1_Note1_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionPrzyrzadyWszystkie.Add(new FilterField { FieldName = "Note2", DisplayText = "_1_Note2_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });

                //----------------------------------------------------------------------------------    Elektryczne
                FieldsCollectionElektryczne.Add(new FilterField { FieldName = "budowa", DisplayText = "_1_budowa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionElektryczne.Add(new FilterField { FieldName = "dzialka", DisplayText = "_1_dzialka_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionElektryczne.Add(new FilterField { FieldName = "obszar", DisplayText = "_1_obszar_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionElektryczne.Add(new FilterField { FieldName = "zakresy", DisplayText = "_1_zakresy_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionElektryczne.Add(new FilterField { FieldName = "klasa", DisplayText = "_1_klasa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionElektryczne.Add(new FilterField { FieldName = "napiecie", DisplayText = "_1_napiecie_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionElektryczne.Add(new FilterField { FieldName = "pradRob", DisplayText = "_1_pradRob_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionElektryczne.Add(new FilterField { FieldName = "pradStaly", DisplayText = "_1_pradStaly_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionElektryczne.Add(new FilterField { FieldName = "pradZmienny", DisplayText = "_1_pradZmienny_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });

                //----------------------------------------------------------------------------------    Mechaniczne
                FieldsCollectionMechaniczne.Add(new FilterField { FieldName = "dzialka1", DisplayText = "_1_dzialka1_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionMechaniczne.Add(new FilterField { FieldName = "obszar1", DisplayText = "_1_obszar1_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionMechaniczne.Add(new FilterField { FieldName = "wgran", DisplayText = "_1_wgran_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionMechaniczne.Add(new FilterField { FieldName = "wysieg", DisplayText = "_1_wysieg_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionMechaniczne.Add(new FilterField { FieldName = "nacisk", DisplayText = "_1_nacisk_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionMechaniczne.Add(new FilterField { FieldName = "klasa1", DisplayText = "_1_klasa1_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionMechaniczne.Add(new FilterField { FieldName = "Mwzorzec", DisplayText = "_1_wzorzec_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionMechaniczne.Add(new FilterField { FieldName = "Zrodlo", DisplayText = "_1_Zrodlo_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionMechaniczne.Add(new FilterField { FieldName = "grupa", DisplayText = "_1_grupa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionMechaniczne.Add(new FilterField { FieldName = "rodzaj", DisplayText = "_1_rodzaj_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionMechaniczne.Add(new FilterField { FieldName = "gr-wz", DisplayText = "_1_gr-wz_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionMechaniczne.Add(new FilterField { FieldName = "Muzykownik", DisplayText = "_1_Muzytkownik_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionMechaniczne.Add(new FilterField { FieldName = "sprawdz", DisplayText = "_1_sprawdz_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });


                //----------------------------------------------------------------------------------    Sprawdziany
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par1Nazwa", DisplayText = "_1_par1Nazwa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par1Wartosc", DisplayText = "_1_par1Wartosc_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par1Wynik", DisplayText = "_1_par1Wynik_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par2Nazwa", DisplayText = "_1_par2Nazwa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par2Wartosc", DisplayText = "_1_par2Wartosc_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par2Wynik", DisplayText = "_1_par2Wynik_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par3Wartosc", DisplayText = "_1_par3Wartosc_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par3Wynik", DisplayText = "_1_par3Wynik_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par4Nazwa", DisplayText = "_1_par4Nazwa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par4Wartosc", DisplayText = "_1_par4Wartosc_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par4Wynik", DisplayText = "_1_par4Wynik_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par5Nazwa", DisplayText = "_1_par5Nazwa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par5Wartosc", DisplayText = "_1_par5Wartosc_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par5Wynik", DisplayText = "_1_par5Wynik_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par6Nazwa", DisplayText = "_1_par6Nazwa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par6Wartosc", DisplayText = "_1_par6Wartosc_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par6Wynik", DisplayText = "_1_par6Wynik_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par7Nazwa", DisplayText = "_1_par7Nazwa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par7Wartosc", DisplayText = "_1_par7Wartosc_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par7Wynik", DisplayText = "_1_par7Wynik_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par8Nazwa", DisplayText = "_1_par8Nazwa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par8Wartosc", DisplayText = "_1_par8Wartosc_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par8Wynik", DisplayText = "_1_par8Wynik_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par9Nazwa", DisplayText = "_1_par9Nazwa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par9Wartosc", DisplayText = "_1_par9Wartosc_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par9Wynik", DisplayText = "_1_par9Wynik_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par10Nazwa", DisplayText = "_1_par10Nazwa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par10Wartosc", DisplayText = "_1_par10Wartosc_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par10Wynik", DisplayText = "_1_par10Wynik_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par11Nazwa", DisplayText = "_1_par11Nazwa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par11Wartosc", DisplayText = "_1_par11Wartosc_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par11Wynik", DisplayText = "_1_par11Wynik_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par12Nazwa", DisplayText = "_1_par12Nazwa_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par12Wartosc", DisplayText = "_1_par12Wartosc_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdziany.Add(new FilterField { FieldName = "par12Wynik", DisplayText = "_1_par12Wynik_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                //----------------------------------------------------------------------------------   Sprawdziany do gwintów
                FieldsCollectionSprawdzianyDoGwintow.Add(new FilterField { FieldName = "TypSprGwintow", DisplayText = "_1_TypSprGwintow_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdzianyDoGwintow.Add(new FilterField { FieldName = "TypGwintu", DisplayText = "_1_TypGwintu_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdzianyDoGwintow.Add(new FilterField { FieldName = "NumerNormyNaGwint", DisplayText = "_1_NumerNormyNaGwint_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdzianyDoGwintow.Add(new FilterField { FieldName = "Wewn_Zewn", DisplayText = "_1_Wewn_Zewn_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdzianyDoGwintow.Add(new FilterField { FieldName = "Srednica", DisplayText = "_1_Srednica_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdzianyDoGwintow.Add(new FilterField { FieldName = "Skok", DisplayText = "_1_Skok_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                FieldsCollectionSprawdzianyDoGwintow.Add(new FilterField { FieldName = "Discriminator", DisplayText = "_1_Discriminator_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });

                // todo dynamiczna kolekcja wypełnienie  PrzyrzadPomiarowySQLCollection = new ObservableCollection<dynamic>(PrzyrzadPomiarowy.LoadSQL("zz","TestType"));

                foreach (var item in FieldsCollectionPrzyrzadyWszystkie)
                {
                    this.MyFilteredPanel.FieldsCollection.Add(item);
                }

                VisibleAllEquipmentAccess = RegisteredUser.CurrentUser.hasPrivilege(PrivilegeListEnum._allEquipmnetAccess) ? Visibility.Visible : Visibility.Collapsed;

                CurrentFilePath = FilePathList.FirstOrDefault(p => p.FilePathId == Abakon15.Properties.Settings.Default.PathToDocuments_CollectionOfEquipment);
                CurrentTemplatePath = TemplatePathList.FirstOrDefault(p => p.FilePathId == Abakon15.Properties.Settings.Default.PathToPatterns);
                SelectedPattern = TemplateList.FirstOrDefault(p => p == Abakon15.Properties.Settings.Default.LastSelectedPattern_CollectionOfEquipment);
            }
        }

        System.Linq.Expressions.Expression<Func<Elektryczne, bool>> predicateElektr;
        System.Linq.Expressions.Expression<Func<Mechaniczne, bool>> predicateMech;
        System.Linq.Expressions.Expression<Func<Sprawdziany, bool>> predicateSprawdz;
        System.Linq.Expressions.Expression<Func<SprawdzianyDoGwintow, bool>> predicateSprawdzGwint;
        System.Linq.Expressions.Expression<Func<PrzyrzadPomiarowy, bool>> predicateWszystkie;
        void MyFilteredPanel_FilterChanged(object sender, EventArgs e)
        {
            PredicateString = MyFilteredPanel.FilterTextApplied;
            FiltrujWgWyboru();
        }

        private void FiltrujWgWyboru()
        {

            switch (SelectedEquipmentTypeEnum)
            {
                case EquipmentTypeEnum.PrzyrzadyWszystkie:
                    predicateWszystkie = MyFilteredPanel.BuildPredicate<PrzyrzadPomiarowy>();
                    PredicateString = MyFilteredPanel.FilterText;
                    PrzyrzadPomiarowyCollection = new ViewableObservableCollection<PrzyrzadPomiarowy>((PrzyrzadPomiarowy.Load(SelectedEquipmentType, SelectedDepartment, predicateWszystkie, FilterDiscontinuedEquipment, FilterActiveEquipment)).OrderBy(p => p.PrzyrzadPomiarowyNrKod));
                    break;


                case EquipmentTypeEnum.Elektryczne:
                    predicateElektr = MyFilteredPanel.BuildPredicate<Elektryczne>();
                    PredicateString = MyFilteredPanel.FilterText;
                    var ElektryczneCollection = new ViewableObservableCollection<Elektryczne>(Elektryczne.Load(predicateElektr));
                    PrzyrzadPomiarowyCollection.Clear();
                    foreach (var item in ElektryczneCollection)
                    {
                        PrzyrzadPomiarowyCollection.Add(item as PrzyrzadPomiarowy);
                    }
                    break;
                case EquipmentTypeEnum.Mechaniczne:
                    predicateMech = MyFilteredPanel.BuildPredicate<Mechaniczne>();
                    PredicateString = MyFilteredPanel.FilterText;
                    var MechaniczneCollection = new ViewableObservableCollection<Mechaniczne>(Mechaniczne.Load(predicateMech));
                    PrzyrzadPomiarowyCollection.Clear();
                    foreach (var item in MechaniczneCollection)
                    {
                        PrzyrzadPomiarowyCollection.Add(item as PrzyrzadPomiarowy);
                    }
                    break;
                case EquipmentTypeEnum.Sprawdziany:
                    predicateSprawdz = MyFilteredPanel.BuildPredicate<Sprawdziany>();
                    PredicateString = MyFilteredPanel.FilterText;
                    var SprawdzianyCollection = new ViewableObservableCollection<Sprawdziany>(Sprawdziany.Load(predicateSprawdz));
                    PrzyrzadPomiarowyCollection.Clear();
                    foreach (var item in SprawdzianyCollection)
                    {
                        PrzyrzadPomiarowyCollection.Add(item as PrzyrzadPomiarowy);
                    }
                    break;
                case EquipmentTypeEnum.SprawdzianyDoGwintow:
                    predicateSprawdzGwint = MyFilteredPanel.BuildPredicate<SprawdzianyDoGwintow>();
                    PredicateString = MyFilteredPanel.FilterText;
                    var SprawdzianyGwintCollection = new ViewableObservableCollection<SprawdzianyDoGwintow>(SprawdzianyDoGwintow.Load(predicateSprawdzGwint));
                    PrzyrzadPomiarowyCollection.Clear();
                    foreach (var item in SprawdzianyGwintCollection)
                    {
                        PrzyrzadPomiarowyCollection.Add(item as PrzyrzadPomiarowy);
                    }
                    break;
                default:
                    break;
            }
        }


        private void FiltrujOdpowiedzialnosci()
        {
            PredicateString = MyFilteredPanel.FilterText;
            //lista pracowników, czy uwzględnić datę kalibracji, data kalibracjiOd, data kalibracjiDo

            PrzyrzadPomiarowyCollection = new ViewableObservableCollection<PrzyrzadPomiarowy>
                (PrzyrzadPomiarowy.Load(SelectedEquipmentType, SelectedDepartment, FilterResposiblePersons, FilterCheckCalibrationDate, FilterCalibrationDateFrom, FilterCalibrationDateTo, FilterDiscontinuedEquipment, FilterActiveEquipment).OrderBy(p => p.PrzyrzadPomiarowyNrKod));
            TaskBalance();
        }

        private void FiltrujWielokrotneOdpowiedzialnosci()
        {
            PrzyrzadPomiarowyCollection = new ViewableObservableCollection<PrzyrzadPomiarowy>
      (PrzyrzadPomiarowy.LoadMultipleResponsibilities(SelectedEquipmentType, SelectedDepartment, FilterCheckCalibrationDate, FilterCalibrationDateFrom, FilterCalibrationDateTo, FilterDiscontinuedEquipment, FilterActiveEquipment).OrderBy(p => p.PrzyrzadPomiarowyNrKod));

        }


        #region Bilans przydziałów
        System.Windows.Controls.ListView labWorkers;
        public System.Windows.Controls.ListView LabWorkers
        {
            get { return labWorkers; }
            set { SetField(ref labWorkers, value, () => LabWorkers); }
        }

        //Total, TotalAllocated, NotAllocated
        int _Total;
        public int Total
        {
            get { return _Total; }
            set { SetField(ref _Total, value, () => Total); }
        }
        int _TotalAllocated;
        public int TotalAllocated
        {
            get { return _TotalAllocated; }
            set { SetField(ref _TotalAllocated, value, () => TotalAllocated); }
        }
        int _NotAllocated;

        public int NotAllocated
        {
            get { return _NotAllocated; }
            set { SetField(ref _NotAllocated, value, () => NotAllocated); }
        }

        internal void TaskBalance()
        {

            Total = PrzyrzadPomiarowy.Count(SelectedEquipmentType, SelectedDepartment, true, null, FilterCheckCalibrationDate, FilterCalibrationDateFrom, FilterCalibrationDateTo, FilterDiscontinuedEquipment, FilterActiveEquipment);
            NotAllocated = PrzyrzadPomiarowy.Count(SelectedEquipmentType, SelectedDepartment, false, null, FilterCheckCalibrationDate, FilterCalibrationDateFrom, FilterCalibrationDateTo, FilterDiscontinuedEquipment, FilterActiveEquipment);
            TotalAllocated = 0;
            foreach (var item in this.PersonList)
            {
                item.TaskAllocated = PrzyrzadPomiarowy.Count(SelectedEquipmentType, SelectedDepartment, true, item, FilterCheckCalibrationDate, FilterCalibrationDateFrom, FilterCalibrationDateTo, FilterDiscontinuedEquipment, FilterActiveEquipment);
                TotalAllocated += item.TaskAllocated;
            }
            LabWorkers.Items.Refresh();

        }
        #endregion


        private void FiltrujZadania()
        {
            List<Person> persons = new List<Person>();

            PrzyrzadPomiarowyCollection = new ViewableObservableCollection<PrzyrzadPomiarowy>
              (PrzyrzadPomiarowy.Load(SelectedEquipmentType, SelectedDepartment, RegisteredUser.CurrentUser.allowedEquipments, FilterCheckCalibrationDate, FilterCalibrationDateFrom, FilterCalibrationDateTo, FilterDiscontinuedEquipment, FilterActiveEquipment).OrderBy(p => p.PrzyrzadPomiarowyNrKod));
        }

        private void LoadPrzyrzadyKalibrowane(PrzyrzadPomiarowy kalibrator)
        {
            PrzyrzadKalibrowanyCollection = new ViewableObservableCollection<PrzyrzadPomiarowy>(PrzyrzadPomiarowy.LoadKalibrowane(kalibrator).OrderBy(p => p.PrzyrzadPomiarowyNrKod));
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {
                case "CurrentTemplatePath":
                    {
                        try
                        {
                            Abakon15.Properties.Settings.Default.PathToPatterns = CurrentTemplatePath.FilePathId;
                            TemplateList = new ViewableObservableCollection<string>(FilesUtility.FilesInPath(CurrentTemplatePath.Path));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error".Translate(), MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    }
                case "CurrentFilePath":
                    {
                        Abakon15.Properties.Settings.Default.PathToDocuments_CollectionOfEquipment = CurrentFilePath.FilePathId;
                        break;
                    }

                case "SelectedPattern":
                    {
                        Abakon15.Properties.Settings.Default.LastSelectedPattern_CollectionOfEquipment = SelectedPattern;
                        break;
                    }

                case "isSelectedBy":
                    {
                        switch (isSelectedBy)
                        {
                            case SelectionTab.None:
                                break;
                            case SelectionTab.ByKalibratory:
                                PrzyrzadPomiarowyCollection = new ViewableObservableCollection<PrzyrzadPomiarowy>(PrzyrzadPomiarowy.LoadKalibratory(SelectedEquipmentType));
                                break;
                            case SelectionTab.ByFilter:
                                FiltrujWgWyboru();
                                break;
                            case SelectionTab.ByResposibilities:
                                PrzyrzadPomiarowyCollection.Clear();
                                break;
                            case SelectionTab.ByTasks:
                                RegisteredUser.RequeryAllowedEquipment();
                                PrzyrzadPomiarowyCollection.Clear();
                                break;

                            default:
                                break;
                        }

                        break;
                    }

                case "FilterCheckCalibrationDate":
                case "FilterCalibrationDateFrom":
                case "FilterCalibrationDateTo":
                case "FilterResposiblePersons":
                case "SelectedDepartment":
                case "FilterActiveEquipment":
                case "FilterDiscontinuedEquipment":
                    //   case "SelectedEquipmentType":
                    {

                        PrzyrzadPomiarowyCollection.Clear();
                        break;
                    }
                case "SelectedEquipmentType":
                    {
                        if (isSelectedBy == SelectionTab.ByKalibratory)
                        {
                            PrzyrzadPomiarowyCollection.Clear();
                            PrzyrzadPomiarowyCollection = new ViewableObservableCollection<PrzyrzadPomiarowy>(PrzyrzadPomiarowy.LoadKalibratory(SelectedEquipmentType));
                        }
                        break;
                    }

                case "isDetailsSelectedBy":
                    {
                        switch (isDetailsSelectedBy)
                        {
                            case DetailSelectionTab.None:
                                break;
                            case DetailSelectionTab.ByDetails:
                                break;
                            case DetailSelectionTab.ByCalibratedEquipment:
                                if (CurrentPrzyrzadPomiarowy != null)
                                {
                                    LoadPrzyrzadyKalibrowane(CurrentPrzyrzadPomiarowy);
                                }
                                break;

                            default:
                                break;
                        }
                        break;
                    }

                case "CanAddRecords":
                    {
                        VisibleCopyButton = CanAddRecords && CurrentPrzyrzadPomiarowy != null ? Visibility.Visible : Visibility.Collapsed;
                    }
                    break;
                case "SelectedEquipmentTypeEnum":
                    {
                        PrzyrzadPomiarowyCollection.Clear();
                        this.MyFilteredPanel.FieldsCollection.Clear();


                        foreach (var item in FieldsCollectionPrzyrzadyWszystkie)
                        {
                            this.MyFilteredPanel.FieldsCollection.Add(item);
                        }
                        if (isSelectedBy == SelectionTab.ByFilter)
                        {
                            switch (SelectedEquipmentTypeEnum)
                            {
                                case EquipmentTypeEnum.PrzyrzadyWszystkie:
                                    Abakon15.Properties.Settings.Default._1_SelectedEquipmentType_ColumnVisibility = true;//Sztuczka z bindowaniem widocznosci kolumny w DataGrid
                                    break;
                                case EquipmentTypeEnum.Elektryczne:
                                    Abakon15.Properties.Settings.Default._1_SelectedEquipmentType_ColumnVisibility = false;
                                    foreach (var item in FieldsCollectionElektryczne)
                                    {
                                        this.MyFilteredPanel.FieldsCollection.Add(item);
                                    }
                                    break;
                                case EquipmentTypeEnum.Mechaniczne:
                                    Abakon15.Properties.Settings.Default._1_SelectedEquipmentType_ColumnVisibility = false;
                                    foreach (var item in FieldsCollectionMechaniczne)
                                    {
                                        this.MyFilteredPanel.FieldsCollection.Add(item);
                                    }
                                    break;
                                case EquipmentTypeEnum.Sprawdziany:
                                    Abakon15.Properties.Settings.Default._1_SelectedEquipmentType_ColumnVisibility = false;
                                    foreach (var item in FieldsCollectionSprawdziany)
                                    {
                                        this.MyFilteredPanel.FieldsCollection.Add(item);
                                    }
                                    break;
                                case EquipmentTypeEnum.SprawdzianyDoGwintow:
                                    Abakon15.Properties.Settings.Default._1_SelectedEquipmentType_ColumnVisibility = false;
                                    foreach (var item in FieldsCollectionSprawdziany)
                                    {
                                        this.MyFilteredPanel.FieldsCollection.Add(item);
                                    }
                                    foreach (var item in FieldsCollectionSprawdzianyDoGwintow)
                                    {
                                        this.MyFilteredPanel.FieldsCollection.Add(item);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else if (isSelectedBy == SelectionTab.ByKalibratory)
                        {
                            PrzyrzadPomiarowyCollection = new ViewableObservableCollection<PrzyrzadPomiarowy>(PrzyrzadPomiarowy.LoadKalibratory(SelectedEquipmentType));
                        }
                        VisibleCopyButton = CanAddRecords && CurrentPrzyrzadPomiarowy != null ? Visibility.Visible : Visibility.Collapsed;
                        VisibleEraseButton = CurrentPrzyrzadPomiarowy != null ? Visibility.Visible : Visibility.Collapsed;
                        break;
                    }

                case "CurrentPrzyrzadPomiarowy": //TypPrzyrzadu
                    {

                        VisibleCopyButton = CanAddRecords && CurrentPrzyrzadPomiarowy != null ? Visibility.Visible : Visibility.Collapsed;
                        VisibleEraseButton = CurrentPrzyrzadPomiarowy != null ? Visibility.Visible : Visibility.Collapsed;
                        deleteAskObjectName = "";
                        if (CurrentPrzyrzadPomiarowy != null)
                        {
                            CurrentPrzyrzadPomiarowy.Reload();


                            //ChartList.Add(new KeyValuePair<string, int>("2000", 95));
                            //ChartList.Add(new KeyValuePair<string, int>("2002", 90));
                            //ChartList.Add(new KeyValuePair<string, int>("2004", 80));
                            //ChartList.Add(new KeyValuePair<string, int>("2006", 75));
                            ChartList.Add(new KeyValuePair<string, int>("2008", 80));
                            ChartList.Add(new KeyValuePair<string, int>("2012", 75));

                            if (isDetailsSelectedBy == DetailSelectionTab.ByDetails)
                            {
                                deleteAskObjectName = CurrentPrzyrzadPomiarowy.PrzyrzadPomiarowyNrKod + " " + CurrentPrzyrzadPomiarowy.Nazwa;
                                EquipmentTypeEnum wybranyTyp = (EquipmentTypeEnum)CurrentPrzyrzadPomiarowy.TypPrzyrzadu;
                                VisibleDetails = Visibility.Visible;
                                if (wybranyTyp == EquipmentTypeEnum.Elektryczne)
                                { VisibleElektryczne = Visibility.Visible; }
                                else
                                { VisibleElektryczne = Visibility.Collapsed; };
                                if (wybranyTyp == EquipmentTypeEnum.Mechaniczne)
                                { VisibleMechaniczne = Visibility.Visible; }
                                else
                                { VisibleMechaniczne = Visibility.Collapsed; };
                                if (wybranyTyp == EquipmentTypeEnum.Sprawdziany)
                                { VisibleSprawdziany = Visibility.Visible; }
                                else
                                { VisibleSprawdziany = Visibility.Collapsed; };
                                if (wybranyTyp == EquipmentTypeEnum.SprawdzianyDoGwintow)
                                { VisibleSprawdzianyDoGwintow = Visibility.Visible; }
                                else
                                { VisibleSprawdzianyDoGwintow = Visibility.Collapsed; };
                            }
                            else if (isDetailsSelectedBy == DetailSelectionTab.ByCalibratedEquipment)
                            {
                                LoadPrzyrzadyKalibrowane(CurrentPrzyrzadPomiarowy);
                            }

                        }
                        else
                        {
                            VisibleDetails = Visibility.Collapsed;
                            VisibleElektryczne = VisibleMechaniczne = VisibleSprawdziany = VisibleSprawdzianyDoGwintow = Visibility.Collapsed;
                        }

                        break;
                    }
                default:
                    break;
            }
        }


        RelayCommand _createEquipmentCommand;
        public RelayCommand CreateEquipmentCommand
        {
            get
            {
                return _createEquipmentCommand ??
                       (_createEquipmentCommand = new RelayCommand(
                        param =>
                        {
                            string rodzaj = param.ToString();
                            PrzyrzadPomiarowy newRek = null;
                            switch (rodzaj)
                            {
                                case "Elektryczne":
                                    newRek = Elektryczne.CreateElektryczne();
                                    break;
                                case "Mechaniczne":
                                    newRek = Mechaniczne.CreateMechaniczne();

                                    break;
                                case "Sprawdziany":
                                    newRek = Sprawdziany.CreateSprawdzian();

                                    break;
                                case "SprawdzianyDoGwintow":
                                    newRek = SprawdzianyDoGwintow.CreateSprawdzianyDoGwintow();

                                    break;

                                default:
                                    break;
                            }
                            if (newRek != null)
                            {
                                PrzyrzadPomiarowyCollection.Add(newRek);
                                RaisePropertyChanged(() => IloscZapisowWBazie);
                                CurrentPrzyrzadPomiarowy = newRek;
                                PrzyrzadPomiarowyVM dataContext = new PrzyrzadPomiarowyVM(CurrentPrzyrzadPomiarowy);
                                WindowManagerClass.WindowOpener<PrzyrzadPomiarowySingleWindow>(WindowContextEnum.measuringDevices, false, false, dataContext);
                            }
                        }
                        ));
            }
        }

        RelayCommand _createByCopyEquipmentCommand;
        public RelayCommand CreateByCopyEquipmentCommand
        {
            get
            {

                return _createByCopyEquipmentCommand ??
                       (_createByCopyEquipmentCommand = new RelayCommand(
                        param =>
                        {
                            string rodzaj = CurrentPrzyrzadPomiarowy.GetType().BaseType.Name;
                            PrzyrzadPomiarowy newRek = null;
                            switch (rodzaj)
                            {
                                case "Elektryczne":
                                    newRek = ((Elektryczne)CurrentPrzyrzadPomiarowy).Copy();
                                    Elektryczne.AddToContext((Elektryczne)newRek);
                                    break;
                                case "Mechaniczne":
                                    newRek = ((Mechaniczne)CurrentPrzyrzadPomiarowy).Copy();
                                    Mechaniczne.AddToContext((Mechaniczne)newRek);
                                    break;
                                case "Sprawdziany":
                                    newRek = ((Sprawdziany)CurrentPrzyrzadPomiarowy).Copy();
                                    Sprawdziany.AddToContext((Sprawdziany)newRek);
                                    break;
                                case "SprawdzianyDoGwintow":
                                    newRek = ((SprawdzianyDoGwintow)CurrentPrzyrzadPomiarowy).Copy();
                                    SprawdzianyDoGwintow.AddToContext((SprawdzianyDoGwintow)newRek);
                                    break;
                                default:
                                    newRek = new PrzyrzadPomiarowy();
                                    CurrentPrzyrzadPomiarowy.Copy(newRek);
                                    newRek = PrzyrzadPomiarowy.AddToContext(newRek);
                                    break;
                            }
                            RaisePropertyChanged(() => IloscZapisowWBazie);
                            if (newRek != null)
                            {
                                PrzyrzadPomiarowyCollection.Add(newRek);
                                CurrentPrzyrzadPomiarowy = newRek;
                                PrzyrzadPomiarowyVM dataContext = new PrzyrzadPomiarowyVM(CurrentPrzyrzadPomiarowy);
                                WindowManagerClass.WindowOpener<PrzyrzadPomiarowySingleWindow>(WindowContextEnum.measuringDevices, false, false, dataContext);
                            }
                        },
                          param => CurrentPrzyrzadPomiarowy != null

                        ));
            }
        }

        protected override bool CanDeleteCommand()
        {
            return CurrentPrzyrzadPomiarowy != null;// && hasPrivilegeProjectEdit;

        }

        protected override void DeleteFromBase()
        {
            CurrentPrzyrzadPomiarowy.Delete();
            PrzyrzadPomiarowyCollection.Remove(CurrentPrzyrzadPomiarowy);
            RaisePropertyChanged(() => IloscZapisowWBazie);

        }

        RelayCommand m_PrzyrzadPomiarowySingleWindowOpenCommand = null;
        public RelayCommand PrzyrzadPomiarowySingleWindowOpenCommand
        {
            get
            {
                if (m_PrzyrzadPomiarowySingleWindowOpenCommand == null)
                {
                    m_PrzyrzadPomiarowySingleWindowOpenCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        PrzyrzadPomiarowy p = param as PrzyrzadPomiarowy;
                                                        if (p != null)
                                                        {
                                                            PrzyrzadPomiarowyVM dataContext = new PrzyrzadPomiarowyVM(p);
                                                            WindowManagerClass.WindowOpener<PrzyrzadPomiarowySingleWindow>(WindowContextEnum.measuringDevices, false, false, dataContext, winState: WindowState.Maximized);
                                                        }
                                                    },
                                                    param => CurrentPrzyrzadPomiarowy != null
                                                    );
                }
                return m_PrzyrzadPomiarowySingleWindowOpenCommand;
            }
        }

        RelayCommand m_AddKalibratorCommand = null;
        public RelayCommand AddKalibratorCommand
        {
            get
            {
                if (m_AddKalibratorCommand == null)
                {
                    m_AddKalibratorCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        SelectedKalibracja.kalibratory.Add(new Kalibracja_Kalibratory(SelectedKalibracja, CurrentPrzyrzadPomiarowy));
                                                    },
                                                    param => CurrentPrzyrzadPomiarowy != null && CurrentPrzyrzadPomiarowy != SelectedPrzyrzadPomiarowy & SelectedKalibracja != null
                                                    );
                }
                return m_AddKalibratorCommand;
            }
        }



        RelayCommand m_SelectDepartmentCommand = null;
        public RelayCommand SelectDepartmentCommand
        {
            get
            {
                if (m_SelectDepartmentCommand == null)
                {
                    m_SelectDepartmentCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        DepartmentVM dvm = new DepartmentVM();
                                                        dvm.AllDepartmentsVisibility = Visibility.Visible;
                                                        DepartmentSelectionWindow win = WindowManagerClass.WindowOpener<DepartmentSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true, dataContext: dvm) as DepartmentSelectionWindow;
                                                        {

                                                            if (win.DialogResult.Value)
                                                            {
                                                                SelectedDepartment = win.department;
                                                                if (SelectedDepartment == null)
                                                                {
                                                                    SelectedDepartment = null;
                                                                    SelectedDepartmentPath = "Wszystkie";
                                                                }
                                                                else
                                                                {
                                                                    SelectedDepartmentPath = SelectedDepartment.FullPath;
                                                                }
                                                            }
                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_SelectDepartmentCommand;
            }
        }

        RelayCommand m_selectEquipmentTypeCommand = null;
        public RelayCommand SelectEquipmentTypeCommand
        {
            get
            {
                if (m_selectEquipmentTypeCommand == null)
                {
                    m_selectEquipmentTypeCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        EquipmentTypeVM EQTvm = new EquipmentTypeVM();
                                                        EQTvm.AllEquipmentTypeVisibility = Visibility.Visible;
                                                        EquipmentTypeSelectionWindow win = WindowManagerClass.WindowOpener<EquipmentTypeSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true, dataContext: EQTvm) as EquipmentTypeSelectionWindow;
                                                        if (win.DialogResult.Value)
                                                        {
                                                            SelectedEquipmentType = win.EquipmentType;
                                                            if (SelectedEquipmentType != null)
                                                            {
                                                                SelectedEquipmentTypePath = SelectedEquipmentType.FullPath;
                                                            }

                                                            else
                                                            {
                                                                SelectedEquipmentType = null;
                                                                SelectedEquipmentTypePath = "Wszystkie";
                                                            }
                                                        }



                                                    },
                                                    param => true
                                                    );
                }
                return m_selectEquipmentTypeCommand;
            }
        }

        RelayCommand m_OpenRptFieldsWindowCommand = null;
        public RelayCommand OpenRptFieldsWindowCommand
        {
            get
            {
                if (m_OpenRptFieldsWindowCommand == null)
                {
                    m_OpenRptFieldsWindowCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        FieldsForReportsWindow win = WindowManagerClass.WindowOpener<FieldsForReportsWindow>(WindowContextEnum.measuringDevices, singleton: true, dialog: true) as FieldsForReportsWindow;
                                                    },
                                                    param => true
                                                    );
                }
                return m_OpenRptFieldsWindowCommand;
            }
        }

        string _rptPath = FilesUtility.GetOmetrisisRptFileName();
        public string RptPath
        {
            get { return _rptPath; }
            set { SetField(ref _rptPath, value, () => RptPath); }
        }

        RelayCommand m_RptFromPatternCommand = null;
        public RelayCommand RptFromPatternCommand
        {
            get
            {
                if (m_RptFromPatternCommand == null)
                {
                    m_RptFromPatternCommand = new RelayCommand(
                                                    param =>
                                                    {

                                                        string fileName1 = FilesUtility.FileCopyWithVersionControl(CurrentTemplatePath.Path + "/" + SelectedPattern, RptPath, "Raport_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString(), "docx");
                                                        PopulateWordTemplate.ProcessPatternDocument(RptPath + "/" + fileName1, this);
                                                        //   AbakonDataModel.Document.Create(CurrentTemplatePath, FilesUtility.FileNameFromFullName(fileName1), null);
                                                    },
                                                    param => CurrentPrzyrzadPomiarowy != null
                                                    );
                }
                return m_RptFromPatternCommand;
            }
        }

        RelayCommand m_newReportPatternCommand = null;
        public RelayCommand newReportPatternCommand
        {
            get
            {
                if (m_newReportPatternCommand == null)
                {
                    m_newReportPatternCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        string patternName = FilesUtility.SaveFileDialog(initialDir: CurrentTemplatePath.Path, extensions: "docx");
                                                        if (patternName.Trim() != "")
                                                        {
                                                            object oPatternName = patternName as object;
                                                            PopulateWordTemplate.CreateDocumentTemplate(patternName, "List pól do użycia w zestwieniach przyrządów", typeof(PrzyrzadPomiarowyCollectionVM));
                                                            AbakonDataModel.Document.Create(CurrentTemplatePath, FilesUtility.FileNameFromFullName(patternName), equipment: null);
                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_newReportPatternCommand;
            }
        }

        RelayCommand m_showFileCommand = null;
        public RelayCommand showFileCommand
        {
            get
            {
                if (m_showFileCommand == null)
                {
                    m_showFileCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        PopulateWordTemplate.OpenDocument(CurrentTemplatePath.Path + "/" + SelectedPattern);
                                                    },
                                                    param => true
                                                    );
                }
                return m_showFileCommand;
            }
        }

        RelayCommand m_filterResponsibilityCommand = null;
        public RelayCommand filterResponsibilityCommand
        {
            get
            {
                if (m_filterResponsibilityCommand == null)
                {
                    m_filterResponsibilityCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        FiltrujOdpowiedzialnosci();

                                                    },
                                                    param => true
                                                    );
                }
                return m_filterResponsibilityCommand;
            }
        }

        RelayCommand m_filterMultipleResponsibilityCommand = null;
        public RelayCommand filterMultipleResponsibilityCommand
        {
            get
            {
                if (m_filterMultipleResponsibilityCommand == null)
                {
                    m_filterMultipleResponsibilityCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        FiltrujWielokrotneOdpowiedzialnosci();

                                                    },
                                                    param => true
                                                    );
                }
                return m_filterMultipleResponsibilityCommand;
            }
        }



        RelayCommand m_filterTaskCommand = null;
        public RelayCommand filterTaskCommand
        {
            get
            {
                if (m_filterTaskCommand == null)
                {
                    m_filterTaskCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        FiltrujZadania();

                                                    },
                                                    param => true
                                                    );
                }
                return m_filterTaskCommand;
            }
        }

        RelayCommand m_UstawFlow2Command = null;
        public RelayCommand UstawFlow2Command
        {
            get
            {
                if (m_UstawFlow2Command == null)
                {
                    m_UstawFlow2Command = new RelayCommand(
                                                    param =>
                                                    {
                                                        foreach (var item in PrzyrzadPomiarowyCollection)
                                                        {
                                                            //Kalibracja ostKalibracja = item.kalibracjaList.OrderByDescending(d => d.DataNastepnegoBadania).FirstOrDefault();
                                                            //if (ostKalibracja != null)
                                                            //{
                                                            //    item.AktualnaKalibracjaId = ostKalibracja.KalibracjaId;
                                                            //}
                                                            //if (item.AktualnaKalibracja != null)
                                                            //{
                                                            //    item.DataOstatniegoBadania = item.AktualnaKalibracja.DataBadania;
                                                            //    item.DataNastepnegoBadania = item.AktualnaKalibracja.DataNastepnegoBadania;
                                                            //}
                                                            //   item.Flow2 = item.Flow2Test;
                                                            //  item.kalibracjaList.Add(new Kalibracja(item));
                                                            // var kk = item.kalibracjaList.FirstOrDefault();
                                                            // if (kk != null)
                                                            // {
                                                            //     string xamlText = "<FlowDocument PagePadding=\"5,0,5,0\" AllowDrop=\"True\" "
                                                            //+ "xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">"
                                                            //+ "<Paragraph >" + item.Uwagi + "</Paragraph></FlowDocument>";
                                                            //     kk.Uwagi = xamlText;
                                                            // }

                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_UstawFlow2Command;
            }
        }

        internal void ConnectLabWorkerToEquipment(List<Person> personList, List<PrzyrzadPomiarowy> equipmentList)
        {
            PersonEquipment.ConnectLabWorkerToEquipment(personList, equipmentList);
            //  FiltrujOdpowiedzialnosci();
            TaskBalance();

        }

        internal void DisconnectLabWorkerFromEquipment(List<PersonEquipment> labWorkerEquipmentList)
        {
            PersonEquipment.DisconnectLabWorkerFromEquipment(labWorkerEquipmentList);
            //   FiltrujOdpowiedzialnosci();
            TaskBalance();
        }

        #region powiązanie przyrządów z dokumentami
        private AbakonDataModel.Document _currentDocument;
        public AbakonDataModel.Document CurrentDocument
        {
            get { return _currentDocument; }
            set { SetField(ref _currentDocument, value, () => CurrentDocument); }
        }

        RelayCommand m_ConnectPrzyrzadToDocumentCommand = null;
        public RelayCommand ConnectPrzyrzadToDocumentCommand
        {
            get
            {
                if (m_ConnectPrzyrzadToDocumentCommand == null)
                {
                    m_ConnectPrzyrzadToDocumentCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        AbakonDataModel.Document.ConnectEquipment(CurrentDocument, CurrentPrzyrzadPomiarowy);
                                                        RaisePropertyChanged(() => CurrentDocument);
                                                    },
                                                    param => CurrentDocument != null && CurrentPrzyrzadPomiarowy != null
                                                    );
                }
                return m_ConnectPrzyrzadToDocumentCommand;
            }
        }



        #endregion


        RelayCommand m_GraphsOpenCommand = null;
        public RelayCommand GraphsOpenCommand
        {
            get
            {
                if (m_GraphsOpenCommand == null)
                {
                    m_GraphsOpenCommand = new RelayCommand(
                                                    param =>
                                                    {

                                                        GraphsVM dataContext = new GraphsVM(CurrentPrzyrzadPomiarowy);
                                                        WindowManagerClass.WindowOpener<GraphsWindow>(WindowContextEnum.measuringDevices, false, false, dataContext);

                                                    },
                                                    param => CurrentPrzyrzadPomiarowy != null
                                                    );
                }
                return m_GraphsOpenCommand;
            }
        }
    }
}
