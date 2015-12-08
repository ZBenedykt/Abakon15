using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abakon15.Infrastructure;
using System.ComponentModel;
using System.Windows;
using System.Collections.Specialized;
using Abakon15.Interfaces;
using System.Collections.ObjectModel;
using AbakonDataModel;
using Abakon15.Views;
using Abakon15.Views.Windows;
using Abakon15.Utility;
using Abakon15.Reports;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;

namespace Abakon15.ViewModels
{
    public class PrzyrzadPomiarowyVM : ViewModelBase, IPrzyrzadPomiarowy
    {
#if GE
        private Visibility scopePasteVisible = Visibility.Visible;
        public Visibility ScopePasteVisible
        {
            get { return scopePasteVisible; }
            set { }
        }
#else
        private Visibility scopePasteVisible = Visibility.Hidden;
        public Visibility ScopePasteVisible
        {
            get { return scopePasteVisible; }
            set { }
        }
#endif

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

        private FilePath _filePathForNewDocuments;
        public FilePath FilePathForNewDocuments
        {
            get { return _filePathForNewDocuments; }
            set { SetField(ref _filePathForNewDocuments, value, () => FilePathForNewDocuments); }
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


        private List<AirConditionDevice> _AirConditionDeviceList;
        public List<AirConditionDevice> AirConditionDeviceList
        {
            get
            {
                if (_AirConditionDeviceList == null)
                {
                    {
                        _AirConditionDeviceList = new List<AirConditionDevice>(AirConditionDevice.Load());
                    }
                }
                return _AirConditionDeviceList;
            }
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

        private List<Person> _employeeList;
        public List<Person> EmployeeList
        {
            get
            {
                if (_personList == null)
                {
                    {
                        _employeeList = new List<Person>(Person.LoadEmployee());
                    }
                }
                return _employeeList;
            }
        }

        Person _selectedEquipmentUser;
        public Person SelectedEquipmentUser
        {
            get { return _selectedEquipmentUser; }
            set { SetField(ref _selectedEquipmentUser, value, () => SelectedEquipmentUser); }
        }

        List<Tuple<int, string>> _KalibracjaEtapEnumTranslate = new List<Tuple<int, string>>(Abakon15.Infrastructure.EnumHelper.TranslateEnumerator<KalibracjaEtapEnum>());
        public List<Tuple<int, string>> KalibracjaEtapEnumTranslate
        {
            get { return _KalibracjaEtapEnumTranslate; }
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

        List<Tuple<int, string>> _KalibracjaObcaEtapEnumTranslate = new List<Tuple<int, string>>(Abakon15.Infrastructure.EnumHelper.TranslateEnumerator<KalibracjaObcaEtapEnum>());
        public List<Tuple<int, string>> KalibracjaObcaEtapEnumTranslate
        {
            get { return _KalibracjaObcaEtapEnumTranslate; }
        }

        List<Tuple<int, string>> _DokladnoscWgEnumTranslate = new List<Tuple<int, string>>(Abakon15.Infrastructure.EnumHelper.TranslateEnumerator<DokladnoscWgEnum>());
        public List<Tuple<int, string>> DokladnoscWgEnumTranslate
        {
            get { return _DokladnoscWgEnumTranslate; }
        }

        ObservableCollection<Standard> _standardList = new ObservableCollection<Standard>(Standard.Load());
        public ObservableCollection<Standard> StandardList
        {
            get { return _standardList; }
        }

        Standard _selectedStandard;
        public Standard SelectedStandard
        {
            get { return _selectedStandard; }
            set { SetField(ref _selectedStandard, value, () => SelectedStandard); }
        }

        List<KeyValuePair<string, int>> chartList = new List<KeyValuePair<string, int>>();
        public List<KeyValuePair<string, int>> ChartList
        {
            get { return chartList; }
            set { SetField(ref chartList, value, () => ChartList); }
        }

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

        private Kalibracja_Kalibratory _SelectedKalibrator;
        public Kalibracja_Kalibratory SelectedKalibrator
        {
            get { return _SelectedKalibrator; }
            set
            {
                SetField(ref _SelectedKalibrator, value, () => SelectedKalibrator);
            }
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

        bool m_ReadOnlyKalibracje = true;
        public virtual bool ReadOnlyKalibracje
        {
            get { return m_ReadOnlyKalibracje; }
            set
            {
                SetField(ref m_ReadOnlyKalibracje, value, () => ReadOnlyKalibracje);
            }
        }

        private Kalibracja _CurrentKalibracja;
        public Kalibracja CurrentKalibracja
        {
            get { return _CurrentKalibracja; }
            set
            {
                SetField(ref _CurrentKalibracja, value, () => CurrentKalibracja);
            }
        }

        private EquipmentDocument _currentEqDocument;
        public EquipmentDocument CurrentEQDocument
        {
            get { return _currentEqDocument; }
            set { SetField(ref _currentEqDocument, value, () => CurrentEQDocument); }
        }

        private Visibility _VisibleWarunkiSrodowiskowe = Visibility.Visible;
        public Visibility VisibleWarunkiSrodowiskowe
        {
            get { return _VisibleWarunkiSrodowiskowe; }
            set { SetField(ref _VisibleWarunkiSrodowiskowe, value, () => VisibleWarunkiSrodowiskowe); }
        }

        public Visibility _VisibleDetails = Visibility.Collapsed;
        public Visibility VisibleDetails
        {
            get { return _VisibleDetails; }
            set { SetField(ref _VisibleDetails, value, () => VisibleDetails); }
        }

        public Visibility _VisibleElektryczne = Visibility.Collapsed;
        public Visibility VisibleElektryczne
        {
            get { return _VisibleElektryczne; }
            set { SetField(ref _VisibleElektryczne, value, () => VisibleElektryczne); }
        }

        public Visibility _VisibleMechaniczne = Visibility.Collapsed;
        public Visibility VisibleMechaniczne
        {
            get { return _VisibleMechaniczne; }
            set { SetField(ref _VisibleMechaniczne, value, () => VisibleMechaniczne); }
        }

        public Visibility _VisibleSprawdziany = Visibility.Collapsed;
        public Visibility VisibleSprawdziany
        {
            get { return _VisibleSprawdziany; }
            set { SetField(ref _VisibleSprawdziany, value, () => VisibleSprawdziany); }
        }

        public Visibility _VisibleSprawdzianyDoGwintow = Visibility.Collapsed;
        public Visibility VisibleSprawdzianyDoGwintow
        {
            get { return _VisibleSprawdzianyDoGwintow; }
            set { SetField(ref _VisibleSprawdzianyDoGwintow, value, () => VisibleSprawdzianyDoGwintow); }
        }

        public Visibility _VisibleKalibracjaDetails = Visibility.Hidden;
        public Visibility VisibleKalibracjaDetails
        {
            get { return _VisibleKalibracjaDetails; }
            set { SetField(ref _VisibleKalibracjaDetails, value, () => VisibleKalibracjaDetails); }
        }

        public Visibility _VisibleKalibracjaObcaDetails = Visibility.Hidden;
        public Visibility VisibleKalibracjaObcaDetails
        {
            get { return _VisibleKalibracjaObcaDetails; }
            set { SetField(ref _VisibleKalibracjaObcaDetails, value, () => VisibleKalibracjaObcaDetails); }
        }

        public Visibility Visibility_NrInwentarzowy
        {
            get
            {
                return Abakon15.Properties.Settings.Default._1_NrInwentarzowy_ColumnVisibility &&
                            CurrentPrzyrzadPomiarowy != null &&
                            CurrentPrzyrzadPomiarowy.NrInwentarzowy != null &&
                            !ReadOnly ? Visibility.Visible : Visibility.Collapsed;
            }
            set { }
        }

        /*       List<List<KeyValuePair<DateTime, double>>> _chartSource;
               public List<List<KeyValuePair<DateTime, double>>> ChartSource
               {
                   get { return _chartSource; }
                   set { _chartSource = value; }
               }
      */
        public PrzyrzadPomiarowyVM(PrzyrzadPomiarowy przyrzad)
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                CurrentPrzyrzadPomiarowy = przyrzad;

                //=====================================================================================================
                /*        
                            List<KeyValuePair<DateTime, double>> llistaGastats = new List<KeyValuePair<DateTime, double>>();
                            List<KeyValuePair<DateTime, double>> llistaPreu = new List<KeyValuePair<DateTime, double>>();
                            llistaGastats.Add(new KeyValuePair<DateTime, double>(new DateTime(2010,03,31), 75));
                            llistaGastats.Add(new KeyValuePair<DateTime, double>(new DateTime(2011, 03, 31), 70));
                            llistaGastats.Add(new KeyValuePair<DateTime, double>(new DateTime(2012, 03, 31), 72));
                            llistaGastats.Add(new KeyValuePair<DateTime, double>(new DateTime(2013, 03, 31), 73));
                            llistaGastats.Add(new KeyValuePair<DateTime, double>(new DateTime(2014, 03, 31), 71));
                            llistaGastats.Add(new KeyValuePair<DateTime, double>(new DateTime(2015, 03, 31), 70));

                            llistaPreu.Add(new KeyValuePair<DateTime, double>(new DateTime(2010, 03, 31), 65));
                            llistaPreu.Add(new KeyValuePair<DateTime, double>(new DateTime(2011, 03, 31), 60));
                            llistaPreu.Add(new KeyValuePair<DateTime, double>(new DateTime(2012, 03, 31), 65));
                            llistaPreu.Add(new KeyValuePair<DateTime, double>(new DateTime(2013, 03, 31), 66));
                            llistaPreu.Add(new KeyValuePair<DateTime, double>(new DateTime(2014, 03, 31), 62));
                            llistaPreu.Add(new KeyValuePair<DateTime, double>(new DateTime(2015, 03, 31), 54));

                            _chartSource = new List<List<KeyValuePair<DateTime, double>>>();
                            _chartSource.Add(llistaGastats);
                            _chartSource.Add(llistaPreu);
                */
                //=====================================================================================================

                if (CurrentPrzyrzadPomiarowy != null)
                {
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
                else
                {
                    VisibleDetails = Visibility.Collapsed;
                    VisibleElektryczne = VisibleMechaniczne = VisibleSprawdziany = VisibleSprawdzianyDoGwintow = Visibility.Collapsed;
                }
                CurrentFilePath = FilePathList.FirstOrDefault(p => p.FilePathId == Abakon15.Properties.Settings.Default.PathToDocuments_SingleEquipment);
                CurrentTemplatePath = TemplatePathList.FirstOrDefault(p => p.FilePathId == Abakon15.Properties.Settings.Default.PathToPatterns);
                SelectedPattern = TemplateList.FirstOrDefault(p => p == Abakon15.Properties.Settings.Default.LastSelectedPattern_SingleEquipment);
            }
        }


        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {

                case "CurrentKalibracja":
                    {
                        if (CurrentKalibracja != null)
                        {
                            CurrentKalibracja.LoadKalibratory();
                            VisibleWarunkiSrodowiskowe = CurrentKalibracja.KalibracjaObca ? Visibility.Collapsed : Visibility.Visible;
                            VisibleKalibracjaDetails = Visibility.Visible;
                        }
                        else
                        {
                            VisibleKalibracjaDetails = Visibility.Hidden;
                        }
                        break;
                    }

                case "CurrentTemplatePath":
                    {
                        Abakon15.Properties.Settings.Default.PathToPatterns = CurrentTemplatePath.FilePathId;
                        TemplateList = new ViewableObservableCollection<string>(FilesUtility.FilesInPath(CurrentTemplatePath.Path));
                        break;
                    }
                case "CurrentFilePath":
                    {
                        if (CurrentFilePath != null)
                        {
                            Abakon15.Properties.Settings.Default.PathToDocuments_SingleEquipment = CurrentFilePath.FilePathId;
                        }
                        break;
                    }
                case "SelectedPattern":
                    {
                        Abakon15.Properties.Settings.Default.LastSelectedPattern_SingleEquipment = SelectedPattern;
                        break;
                    }
                default:
                    break;
            }
        }

        public void ProceedLabDoers(System.Collections.IList doers)
        {
            List<string> doersName = new List<string>();
            foreach (var item in doers)
            {
                doersName.Add(((Person)item).SureFirstName);
            }
            CurrentKalibracja.Zatwierdzil = string.Join(";", doersName);
            CurrentKalibracja.Wykonawca = CurrentKalibracja.Zatwierdzil;
            RaisePropertyChanged(() => CurrentKalibracja);
        }

        RelayCommand NowaKalibracja;
        public RelayCommand NowaKalibracjaCommand
        {
            get
            {

                return NowaKalibracja ??
                       (NowaKalibracja = new RelayCommand(
                        param =>
                        {
                            Kalibracja newRec = Kalibracja.CreateKalibracja(CurrentPrzyrzadPomiarowy);

                            CurrentPrzyrzadPomiarowy.kalibracjaList.Add(newRec);
                            CurrentKalibracja = newRec;
                        },

                        param => CurrentPrzyrzadPomiarowy != null
                        ));
            }
        }
        RelayCommand m_DeleteKalibracjaCommand;
        public RelayCommand DeleteKalibracjaCommand
        {
            get
            {
                if (m_DeleteKalibracjaCommand == null)
                {
                    m_DeleteKalibracjaCommand = new Abakon15.Infrastructure.RelayCommand(
                        param =>
                        {
                            string kom = "_deleteDataAsk".Translate() + ":" + Environment.NewLine + CurrentKalibracja.DataRozpoczeciaProcesu;
                            string komHeader = "_confirm".Translate();
                            if (MessageBox.Show(kom, komHeader, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                            {
                                CurrentKalibracja.Delete();
                            }
                            var u = param as UIElement;
                            if (u != null) u.Refresh();
                        },
                        param => this.CanDeleteKalibracjaCommand()
                        );
                }
                return m_DeleteKalibracjaCommand;
            }
        }

        protected virtual bool CanDeleteKalibracjaCommand()
        {
            return !this.ReadOnlyKalibracje && _CurrentKalibracja != null;
        }

        RelayCommand m_SelectKalibratorCommand = null;
        public RelayCommand SelectKalibratorCommand
        {
            get
            {
                if (m_SelectKalibratorCommand == null)
                {
                    m_SelectKalibratorCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        PrzyrzadPomiarowyCollectionVM dataContext = new PrzyrzadPomiarowyCollectionVM();
                                                        dataContext.SelectedPrzyrzadPomiarowy = CurrentPrzyrzadPomiarowy;
                                                        dataContext.SelectedKalibracja = CurrentKalibracja;
                                                        var win = WindowManagerClass.WindowOpener<PrzyrzadPomiarowySelect>(WindowContextEnum.measuringDevices, true, true, dataContext);
                                                    },
                                                    param => true
                                                    );
                }
                return m_SelectKalibratorCommand;
            }
        }

        RelayCommand m_DisconnectKalibratorCommand = null;
        public RelayCommand DisconnectKalibratorCommand
        {
            get
            {
                if (m_DisconnectKalibratorCommand == null)
                {
                    m_DisconnectKalibratorCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        SelectedKalibrator.Remove();
                                                    },
                                                    param => SelectedKalibrator != null
                                                    );
                }
                return m_DisconnectKalibratorCommand;
            }
        }

        RelayCommand m_DisconnectDocumentCommand = null;
        public RelayCommand DisconnectDocumentCommand
        {
            get
            {
                if (m_DisconnectDocumentCommand == null)
                {
                    m_DisconnectDocumentCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        CurrentEQDocument.DisconnectFromEquipment();
                                                    },
                                                    param => CurrentEQDocument != null
                                                    );
                }
                return m_DisconnectDocumentCommand;
            }
        }

        RelayCommand m_DeleteDocumentCommand = null;
        public RelayCommand DeleteDocumentCommand
        {
            get
            {
                if (m_DeleteDocumentCommand == null)
                {
                    m_DeleteDocumentCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        CurrentEQDocument.document.Remove();
                                                    },
                                                     param => CurrentEQDocument != null
                                                    );
                }
                return m_DeleteDocumentCommand;
            }
        }

        RelayCommand m_KalibratorOpenCommand = null;
        public RelayCommand KalibratorOpenCommand
        {
            get
            {
                if (m_KalibratorOpenCommand == null)
                {
                    m_KalibratorOpenCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        PrzyrzadPomiarowy currPrzyrzad = PrzyrzadPomiarowy.Find(SelectedKalibrator.PrzyrzadPomiarowyNrKod);
                                                        PrzyrzadPomiarowyVM dataContext = new PrzyrzadPomiarowyVM(currPrzyrzad);
                                                        WindowManagerClass.WindowOpener<PrzyrzadPomiarowySingleWindow>(WindowContextEnum.measuringDevices, false, false, dataContext);
                                                    },
                                                    param => SelectedKalibrator != null
                                                    );
                }
                return m_KalibratorOpenCommand;
            }
        }

        RelayCommand m_NormaOpenCommand = null;
        public RelayCommand NormaOpenCommand
        {
            get
            {
                if (m_NormaOpenCommand == null)
                {
                    m_NormaOpenCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        if (Uri.IsWellFormedUriString(SelectedStandard.FileName, UriKind.Absolute))
                                                        {
                                                            System.Diagnostics.Process.Start(SelectedStandard.FileName);
                                                        }
                                                        else
                                                        {

                                                            try
                                                            {
                                                                FilePath tempFilePath = FilePath.GetFilePath(SelectedStandard.FilePathId);
                                                                FilesUtility.OpenFile(tempFilePath.Path + "/" + SelectedStandard.FileName);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                MessageBox.Show(ex.Message);
                                                            }
                                                        }


                                                    },
                                                    param => SelectedStandard != null
                                                    );
                }
                return m_NormaOpenCommand;
            }
        }

        RelayCommand m_SelectStandardForCalibrationCommand = null;
        public RelayCommand SelectStandardForCalibrationCommand
        {
            get
            {
                if (m_SelectStandardForCalibrationCommand == null)
                {
                    m_SelectStandardForCalibrationCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        //PrzyrzadPomiarowyVM dataContext = new PrzyrzadPomiarowyVM(SelectedKalibrator.kalibrator);
                                                        var win = WindowManagerClass.WindowOpener<StandardSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true) as StandardSelectionWindow;

                                                        if (win.DialogResult.Value)
                                                        {
                                                            foreach (var item in win.SelectedStandards)
                                                            {
                                                                CurrentKalibracja.normy.Add(item);
                                                            }
                                                        }

                                                        ListView p = param as ListView;
                                                        if (p != null)
                                                        {
                                                            p.Items.Refresh();
                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_SelectStandardForCalibrationCommand;
            }
        }

        //DisconnectStandardForCalibrationCommand

        RelayCommand m_DisconnectStandardForCalibrationCommand = null;
        public RelayCommand DisconnectStandardForCalibrationCommand
        {
            get
            {
                if (m_DisconnectStandardForCalibrationCommand == null)
                {
                    m_DisconnectStandardForCalibrationCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        CurrentKalibracja.normy.Remove(SelectedStandard);
                                                        ListView p = param as ListView;
                                                        if (p != null)
                                                        {
                                                            p.Items.Refresh();
                                                        }
                                                    },
                                                    param => SelectedStandard != null
                                                    );
                }
                return m_DisconnectStandardForCalibrationCommand;
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
                                                        DepartmentSelectionWindow win = WindowManagerClass.WindowOpener<DepartmentSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true) as DepartmentSelectionWindow;
                                                        {
                                                            if (win.DialogResult.Value)
                                                            {
                                                                CurrentPrzyrzadPomiarowy.miejsceUzytkowania = win.department;
                                                                RaisePropertyChanged(() => CurrentPrzyrzadPomiarowy);
                                                            }

                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_SelectDepartmentCommand;
            }
        }

        RelayCommand m_SelectEquipmentTypeCommand = null;
        public RelayCommand SelectEquipmentTypeCommand
        {
            get
            {
                if (m_SelectEquipmentTypeCommand == null)
                {
                    m_SelectEquipmentTypeCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        EquipmentTypeSelectionWindow win = WindowManagerClass.WindowOpener<EquipmentTypeSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true) as EquipmentTypeSelectionWindow;
                                                        {
                                                            if (win.DialogResult.Value)
                                                            {
                                                                CurrentPrzyrzadPomiarowy.equipmentType = win.EquipmentType;
                                                                RaisePropertyChanged(() => CurrentPrzyrzadPomiarowy);
                                                            }
                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_SelectEquipmentTypeCommand;
            }
        }

        RelayCommand m_SelectPartnerCommand = null;
        public RelayCommand SelectPartnerCommand
        {
            get
            {
                if (m_SelectPartnerCommand == null)
                {
                    m_SelectPartnerCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        bool empt = (param != null) && (param.ToString() == "empty");

                                                        if (!empt)
                                                        {
                                                            PartnerSelectionWindow win = WindowManagerClass.WindowOpener<PartnerSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true) as PartnerSelectionWindow;
                                                            {
                                                                if (win.DialogResult.Value)
                                                                {
                                                                    CurrentKalibracja.kalibrujacy = win.partner;
                                                                    if (win.partner != null)
                                                                    {
                                                                        CurrentKalibracja.KalibrujeFirmaId = win.partner.PartnerId;
                                                                        CurrentKalibracja.kalibrujacy = win.partner;
                                                                        CurrentKalibracja.Wykonawca = win.partner.PartnerName;
                                                                    }
                                                                    else
                                                                    {
                                                                        CurrentKalibracja.KalibrujeFirmaId = Guid.Empty;
                                                                        CurrentKalibracja.kalibrujacy = null;
                                                                        CurrentKalibracja.Wykonawca = string.Empty;
                                                                    }
                                                                    RaisePropertyChanged(() => CurrentKalibracja);
                                                                }

                                                            }
                                                        }
                                                        else
                                                        {
                                                            CurrentKalibracja.KalibrujeFirmaId = Guid.Empty;
                                                            CurrentKalibracja.kalibrujacy = null;
                                                            CurrentKalibracja.Wykonawca = string.Empty;
                                                            RaisePropertyChanged(() => CurrentKalibracja);
                                                        }

                                                    },
                                                    param => true
                                                    );
                }
                return m_SelectPartnerCommand;
            }
        }

        RelayCommand m_SelectPartnerPosrednikCommand = null;
        public RelayCommand SelectPartnerPosrednikCommand
        {
            get
            {
                if (m_SelectPartnerPosrednikCommand == null)
                {
                    m_SelectPartnerPosrednikCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        bool empt = (param != null) && (param.ToString() == "empty");
                                                        if (!empt)
                                                        {
                                                            PartnerSelectionWindow win = WindowManagerClass.WindowOpener<PartnerSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true) as PartnerSelectionWindow;
                                                            if (win.DialogResult.Value)
                                                            {
                                                                CurrentKalibracja.posrednikKalibracji = win.partner;
                                                                if (win.partner != null)
                                                                {
                                                                    CurrentKalibracja.PosredniczyFirmaId = win.partner.PartnerId;
                                                                }
                                                                else
                                                                {
                                                                    CurrentKalibracja.PosredniczyFirmaId = Guid.Empty;
                                                                    CurrentKalibracja.posrednikKalibracji = null;
                                                                }
                                                                RaisePropertyChanged(() => CurrentKalibracja);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            CurrentKalibracja.PosredniczyFirmaId = Guid.Empty;
                                                            CurrentKalibracja.posrednikKalibracji = null;
                                                            RaisePropertyChanged(() => CurrentKalibracja);
                                                        }


                                                    },
                                                    param => true
                                                    );
                }
                return m_SelectPartnerPosrednikCommand;
            }
        }

        RelayCommand m_DeleteZakresCommand;
        public RelayCommand DeleteZakresCommand
        {
            get
            {
                if (m_DeleteZakresCommand == null)
                {
                    m_DeleteZakresCommand = new Abakon15.Infrastructure.RelayCommand(
                        param =>
                        {
                            string kom = "_deleteDataAsk".Translate() + ":" + Environment.NewLine + SelectedZakres.Nastawa;
                            string komHeader = "_confirm".Translate();
                            if (MessageBox.Show(kom, komHeader, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                            {
                                SelectedZakres.DeleteEquipmentScope();
                            }
                            var u = param as UIElement;
                            if (u != null) u.Refresh();
                        },
                        param => this.CanDeleteZakresCommand()
                        );
                }
                return m_DeleteZakresCommand;
            }
        }

        protected virtual bool CanDeleteZakresCommand()
        {
            return !this.ReadOnly && SelectedZakres != null;
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
                                                        //  CurrentFilePath = FilePathList.FirstOrDefault(p => p.FilePathId == Abakon15.Properties.Settings.Default.PathToDocuments_SingleEquipment);
                                                        string fileName = FilesUtility.FileCopyWithVersionControl(CurrentTemplatePath.Path + "/" + SelectedPattern, CurrentFilePath.Path, "ID_" + CurrentPrzyrzadPomiarowy.PrzyrzadPomiarowyNrKod.ToString(), "docx");
                                                        PopulateWordTemplate.ProcessPatternDocument(CurrentFilePath.Path + "\\" + fileName, CurrentPrzyrzadPomiarowy);
                                                        AbakonDataModel.Document.Create(CurrentFilePath, fileName, CurrentPrzyrzadPomiarowy);
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
                                                        object oPatternName = patternName as object;                                                       //     PopulateWordTemplate.CreateDocumentTemplate(patternName, typeof(PrzyrzadPomiarowyCollectionVM));
                                                        PopulateWordTemplate.CreateDocumentTemplate(patternName, "Lista pól, które można użyć w szablonach do raportu pojedynczego przyrządu", typeof(PrzyrzadPomiarowy));
                                                        AbakonDataModel.Document.Create(CurrentTemplatePath, FilesUtility.FileNameFromFullName(patternName), equipment: null);
                                                    },
                                                    param => true
                                                    );
                }
                return m_newReportPatternCommand;
            }
        }

        RelayCommand m_sendEmailCommand;
        public RelayCommand sendEmailCommand
        {
            get
            {
                if (m_sendEmailCommand == null)
                {
                    m_sendEmailCommand = new RelayCommand(
                        param =>
                        {
                            string attachFile = CurrentEQDocument.document.filePath.Path + "/" + CurrentEQDocument.document.FileName;

                            MAPI mapi = new MAPI();
                            mapi.AddAttachment(attachFile);
                            mapi.SendMailPopup(CurrentPrzyrzadPomiarowy.Nazwa + " -  Id= " + CurrentPrzyrzadPomiarowy.PrzyrzadPomiarowyNrKod, "Witam");
                        },
                        param => true
                        );
                }
                return m_sendEmailCommand;
            }
        }

        RelayCommand m_showSheetsCommand;
        public RelayCommand showSheetsCommand
        {
            get
            {
                if (m_showSheetsCommand == null)
                {
                    m_showSheetsCommand = new RelayCommand(
                        param =>
                        {
                            if (CurrentEQDocument != null)
                            {
                                try
                                {
                                    string fileName = CurrentEQDocument.document.filePath.Path + "/" + CurrentEQDocument.document.FileName;
                                    List<string> sheetNames = ExcelDocument.GetSheetsNames(fileName);

                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show(ex.Message, "_Caution".Translate(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                }
                            }
                        },
                        param => true
                        );
                }
                return m_showSheetsCommand;
            }
        }

        RelayCommand m_showFileCommand;
        public RelayCommand ShowFileCommand
        {
            get
            {
                if (m_showFileCommand == null)
                {
                    m_showFileCommand = new RelayCommand(
                        param => this.ShowFile(),
                        param => true
                        );
                }
                return m_showFileCommand;
            }
        }

        private void ShowFile()
        {
            if (CurrentEQDocument != null)
            {
                try
                {
                    string fileName = CurrentEQDocument.document.filePath.Path + "/" + CurrentEQDocument.document.FileName;
                    FilesUtility.OpenFile(fileName);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "_Caution".Translate(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        RelayCommand m_SelectDocumentClassifierCommand = null;
        public RelayCommand SelectDocumentClassifierCommand
        {
            get
            {
                if (m_SelectDocumentClassifierCommand == null)
                {
                    m_SelectDocumentClassifierCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        DocumentClassificationPatternSelectionWindow win = WindowManagerClass.WindowOpener<DocumentClassificationPatternSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true) as DocumentClassificationPatternSelectionWindow;
                                                        {
                                                            if (win.DialogResult.Value)
                                                            {
                                                                CurrentEQDocument.document.documentClassificationPattern = win.documentClassificationPattern;
                                                            }
                                                            RaisePropertyChanged(() => CurrentEQDocument);
                                                            System.Windows.Controls.DataGrid ctrl = param as System.Windows.Controls.DataGrid;
                                                            try
                                                            {
                                                                if (ctrl != null)
                                                                {
                                                                    ctrl.CommitEdit();
                                                                    ctrl.Items.Refresh();
                                                                }
                                                            }
                                                            catch (Exception)
                                                            {
                                                            }
                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_SelectDocumentClassifierCommand;
            }
        }

        RelayCommand m_RegisterCalibrationCommand = null;
        public RelayCommand RegisterCalibrationCommand
        {
            get
            {
                if (m_RegisterCalibrationCommand == null)
                {
                    m_RegisterCalibrationCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        CurrentPrzyrzadPomiarowy.AktualnaKalibracjaId = CurrentKalibracja.KalibracjaId;
                                                        CurrentPrzyrzadPomiarowy.DataOstatniegoBadania = CurrentKalibracja.DataBadania;
                                                        CurrentPrzyrzadPomiarowy.DataNastepnegoBadania = CurrentKalibracja.DataNastepnegoBadania;
                                                        CurrentKalibracja.KalibracjaEtap = (int)KalibracjaEtapEnum.finished;
                                                        RaisePropertyChanged(() => CurrentPrzyrzadPomiarowy);
                                                        SaveToDB();
                                                    },
                                                    param => CurrentKalibracja != null && CurrentKalibracja.DataNastepnegoBadania != null
                                                    );
                }
                return m_RegisterCalibrationCommand;
            }
        }

        //RegisterCalibrationCommand

        RelayCommand m_EquipmentUserChangeCommand = null;
        public RelayCommand EquipmentUserChangeCommand
        {
            get
            {
                if (m_EquipmentUserChangeCommand == null)
                {
                    m_EquipmentUserChangeCommand = new RelayCommand(
                                                    param =>
                                                    {

                                                        if (param.ToString() == "Clear")
                                                        {
                                                            CurrentPrzyrzadPomiarowy.uzytkownik = null;
                                                            CurrentPrzyrzadPomiarowy.UzytkownikId = null;
                                                            CurrentPrzyrzadPomiarowy.UzytkownikNazwa = "";
                                                            RaisePropertyChanged(() => CurrentPrzyrzadPomiarowy);
                                                        }
                                                        else
                                                        {
                                                            CurrentPrzyrzadPomiarowy.uzytkownik = SelectedEquipmentUser;
                                                            CurrentPrzyrzadPomiarowy.UzytkownikId = SelectedEquipmentUser.PersonId;
                                                            CurrentPrzyrzadPomiarowy.UzytkownikNazwa = SelectedEquipmentUser.SureFirstName;
                                                            RaisePropertyChanged(() => CurrentPrzyrzadPomiarowy);
                                                        }

                                                    },
                                                    param => true
                                                    );
                }
                return m_EquipmentUserChangeCommand;
            }
        }

        RelayCommand m_XMLButtonCommand = null;
        public RelayCommand XMLButtonCommand
        {
            get
            {
                if (m_XMLButtonCommand == null)
                {
                    m_XMLButtonCommand = new RelayCommand(
                                        param =>
                                        {
                                            Guid selPath = Guid.Empty;
                                            int selClassifier = -1;

                                            if (AppParameters.ExcelLocalizationParameterOK)
                                            {
                                                selPath = AppParameters.ExcelLocalizationParameter.FilePathId;
                                                selClassifier = AppParameters.ExcelLocalizationParameter.dcpId;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Parametr ExcelLocalizationParameter nie ustawiony");
                                            }

                                            try
                                            {
                                                if (selPath.CompareTo(Guid.Empty) != 0)
                                                {
                                                    FilePath fp = FilePath.GetFilePath(selPath);
                                                    if (fp != null)
                                                    {
                                                        List<string> xmlFilesName = FilesUtility.GetXmlFile(CurrentPrzyrzadPomiarowy, fp.Path);
                                                        string xmlFileName = SelectFile(xmlFilesName);
                                                        if (xmlFileName != null && xmlFileName.Length > 0)
                                                        {
                                                            if (!CurrentKalibracja.hasXlsFile(FilesUtility.FileNameFromFullName(xmlFileName)))
                                                            {
                                                                DocumentClassificationPattern dcp = DocumentClassificationPattern.GetDocumentClassificationPattern(selClassifier);
                                                                CurrentKalibracja.RegisterXmlFile(FilesUtility.FileNameFromFullName(xmlFileName), fp, dcp);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            xmlFileName = string.Format("{0}\\EX{1}_{2}.xlsx", fp.Path, CurrentPrzyrzadPomiarowy.PrzyrzadPomiarowyNrKod.ToString(), CurrentPrzyrzadPomiarowy.NrEwid);
                                                            ExcelDocument exDoc = new ExcelDocument();
                                                            exDoc.CreateSpreadsheetDocument(xmlFileName, CurrentPrzyrzadPomiarowy);
                                                            DocumentClassificationPattern dcp = DocumentClassificationPattern.GetDocumentClassificationPattern(selClassifier);
                                                            CurrentKalibracja.RegisterXmlFile(FilesUtility.FileNameFromFullName(xmlFileName), fp, dcp);
                                                        }


                                                        FilesUtility.OpenFile(xmlFileName);
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message, "_Caution".Translate(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                            }
                                        },
                                        param => true
                                        );
                }
                return m_XMLButtonCommand;
            }
        }

        private string SelectFile(List<string> xmlFilesName)
        {
            return xmlFilesName.OrderByDescending(s => s).FirstOrDefault();
        }


        protected override void AddFromClipboard(object param, bool init = true)
        {
            if (FilePathForNewDocuments == null)
            {
                MessageBox.Show("_selectFilePath_Message".Translate(), "_Caution", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (Clipboard.ContainsFileDropList())
                {
                    System.Collections.Specialized.StringCollection files = Clipboard.GetFileDropList();
                    foreach (var file in files)
                    {
                        StateOfExecution result = FilesUtility.FileCopy(file, FilePathForNewDocuments.Path);
                        if (result.OperationOK)
                        {
                            AbakonDataModel.Document.Create(FilePathForNewDocuments, FilesUtility.FileNameFromFullName(file), CurrentPrzyrzadPomiarowy);
                        }
                        else
                        {
                            MessageBox.Show(result.ExceptionMsg);
                        }

                    }
                }

            }
        }



        //KasujDokumentCommand
        RelayCommand m_KasujDokumentCommand;
        public RelayCommand KasujDokumentCommand
        {
            get
            {
                if (m_KasujDokumentCommand == null)
                {
                    m_KasujDokumentCommand = new RelayCommand(
                        param =>
                        {


                            CurrentKalibracja.DeleteDocument();
                        },
                        param => true
                        );
                }
                return m_KasujDokumentCommand;
            }
        }

        protected override void RaiseChanged()
        {
            base.RaiseChanged();
            RaisePropertyChanged(() => CurrentPrzyrzadPomiarowy);
            RaisePropertyChanged(() => CurrentKalibracja);
        }


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
