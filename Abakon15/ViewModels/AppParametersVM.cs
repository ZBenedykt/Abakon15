using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abakon15.Infrastructure;
using System.Windows;
using AbakonDataModel;
using System.ComponentModel;
using Abakon15.Utility;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using Abakon15.Views.Windows;

namespace Abakon15.ViewModels
{
    class AppParametersVM : ViewModelBase
    {
        _Application _currentApplication = _Application.ThisApplication();

        IEnumerable<string> paramNameList;

        ObservableCollection<Tuple<string, string>> paramNameDictionary = new ObservableCollection<Tuple<string, string>>();
        public ObservableCollection<Tuple<string, string>> ParamNameDictionary
        {
            get { return paramNameDictionary; }
            set { SetField(ref paramNameDictionary, value, () => ParamNameDictionary); }
        }

        Tuple<string, string> selectedParamNameDictionary;
        public Tuple<string, string> SelectedParamNameDictionary
        {
            get { return selectedParamNameDictionary; }
            set { SetField(ref selectedParamNameDictionary, value, () => SelectedParamNameDictionary); }
        }

        XDocument paramDokument;
        public XDocument ParamDokument
        {
            get { return paramDokument; }
            set { SetField(ref paramDokument, value, () => ParamDokument); }
        }

        #region  Parametr excPathTypeOfDoc
        //==============================================================
        private List<FilePath> _FilePathList = new List<FilePath>(FilePath.Load());
        public List<FilePath> FilePathList
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

        private DocumentClassificationPattern _selectedPattern;
        public DocumentClassificationPattern SelectedPattern
        {
            get { return _selectedPattern; }
            set { SetField(ref _selectedPattern, value, () => SelectedPattern); }
        }

        #endregion



        #region =================== TabItem selection region ===========================
        private TypyNodeEnum _isSelectedBy = TypyNodeEnum.excPathTypeOfDoc;
        public TypyNodeEnum isSelectedBy
        {
            get { return _isSelectedBy; }
            set { SetField(ref _isSelectedBy, value, () => isSelectedBy); }
        }

        private bool _isexcPathTypeOfDocTab = true;
        public bool isexcPathTypeOfDocTab
        {
            get { return _isexcPathTypeOfDocTab; }
            set
            {
                _isexcPathTypeOfDocTab = value;
                if (value)
                {
                    isSelectedBy = TypyNodeEnum.excPathTypeOfDoc;
                }
                RaisePropertyChanged(() => isexcPathTypeOfDocTab);
            }
        }

        private bool _istestTab = false;
        public bool istestTab
        {
            get { return _istestTab; }
            set
            {
                _istestTab = value;
                if (value)
                {
                    isSelectedBy = TypyNodeEnum.test;
                }
                RaisePropertyChanged(() => istestTab);
            }
        }
        // Dalsze parametry
        //========================================

        #endregion

        public AppParametersVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                LoadData();
            }
        }

        private void LoadData()
        {

            #region Sprawdź xml dla parametrów utworzono
            if (_currentApplication.Parameters == null || _currentApplication.Parameters.Trim().Length == 0)
            {
                string xmlSTR = string.Format(@"<?xml version='1.0' encoding='utf-16'?><ParametryApp></ParametryApp>");
                ParamDokument = XMLUtility.LoadXMLFromString(xmlSTR);
                _currentApplication.Parameters = ParamDokument.ToString();
            }
            else
            {
                ParamDokument = XMLUtility.LoadXMLFromString(_currentApplication.Parameters);
            }
            #endregion

            paramNameList = XMLUtility.GetListOfELementsNames(ParamDokument.Root);


            #region Sprawdzanie istnienia potrzebnych parametrów
            //  Jeśli nie istnieje parametr excPathTypeOfDoc, to go utwórz
            if (paramNameList.FirstOrDefault(p => p == TypyNodeEnum.excPathTypeOfDoc.ToString()) == null)
            {
                XElement x = XMLUtility.InitExcelLocalizationParameter();
                ParamDokument.Root.Add(x);
                _currentApplication.Parameters = ParamDokument.ToString();
            }

            if (paramNameList.FirstOrDefault(p => p == TypyNodeEnum.test.ToString()) == null)
            {
                XElement x = XMLUtility.InitTestParameter();
                ParamDokument.Root.Add(x);
                _currentApplication.Parameters = ParamDokument.ToString();
            }

            // Spradzenie ewentualnych pozostałych parametrów

            //=========================================== 

            paramNameList = XMLUtility.GetListOfELementsNames(ParamDokument.Root);
            #endregion

            string par1 = TypyNodeEnum.excPathTypeOfDoc.ToString();

            //nazwy zgodne z wersją językową
            foreach (string item in paramNameList)
            {
                if (item == par1)
                {
                    ParamNameDictionary.Add(new Tuple<string, string>(item, item.Translate()));
                }
            }
            SelectedParamNameDictionary = ParamNameDictionary.FirstOrDefault();

        }


        private void ProceedParameters()
        {
            if (SelectedParamNameDictionary != null)
            {
                TypyNodeEnum selectedParam;
                if (Enum.TryParse<TypyNodeEnum>(selectedParamNameDictionary.Item1, out selectedParam))
                {
                    isSelectedBy = selectedParam;
                    switch (selectedParam)
                    {
                        case TypyNodeEnum.excPathTypeOfDoc:
                            var XElementParam = XMLUtility.GetParamOfName(paramDokument.Root, TypyNodeEnum.excPathTypeOfDoc.ToString());
                            XElementParam.SetAttributeValue("Path", CurrentFilePath.FilePathId);
                            XElementParam.SetAttributeValue("DocClasification", SelectedPattern.dcpId);
                            _currentApplication.Parameters = paramDokument.ToString();
                            break;
                        case TypyNodeEnum.test:

                            break;
                        default:
                            break;
                    }
                }
            }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {
                case "SelectedParamNameDictionary":
                    {
                        if (SelectedParamNameDictionary != null)
                        {
                            TypyNodeEnum selectedParam;
                            if (Enum.TryParse<TypyNodeEnum>(selectedParamNameDictionary.Item1, out selectedParam))
                            {

                                isSelectedBy = selectedParam;
                                switch (selectedParam)
                                {
                                    case TypyNodeEnum.excPathTypeOfDoc:
                                        var XElementParam = XMLUtility.GetParamOfName(paramDokument.Root, TypyNodeEnum.excPathTypeOfDoc.ToString());
                                        Guid pathId = Guid.Empty;
                                        if (Guid.TryParse(XElementParam.Attribute("Path").Value, out pathId))
                                        {
                                            CurrentFilePath = FilePath.GetFilePath(pathId);
                                        }
                                        int ClassifierId;
                                        if (int.TryParse(XElementParam.Attribute("DocClasification").Value, out ClassifierId))
                                        {
                                            SelectedPattern = DocumentClassificationPattern.GetDocumentClassificationPattern(ClassifierId);
                                        }



                                        isexcPathTypeOfDocTab = true;
                                        break;
                                    case TypyNodeEnum.test:
                                        istestTab = true;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        break;
                    }
                default:
                    break;
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
                                                                SelectedPattern = win.documentClassificationPattern;
                                                            }
                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_SelectDocumentClassifierCommand;
            }
        }

        protected override void SaveToDB(object param = null)
        {
            ProceedParameters();
            base.SaveToDB(param);
        }



    }
}
