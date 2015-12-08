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
using Abakon15.Views.Windows;
using Abakon15.Utility;

namespace Abakon15.ViewModels
{
    public class PartnerVM : ViewModelBase
    {

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

        Visibility _detailVisibility = Visibility.Hidden;
        public Visibility DetailVisibility
        {
            get { return _detailVisibility; }
            set { SetField(ref _detailVisibility, value, () => DetailVisibility); }
        }


        private Partner _currentPartner;
        public Partner CurrentPartner
        {
            get { return _currentPartner; }
            set { SetField(ref _currentPartner, value, () => CurrentPartner); }
        }

        private ViewableObservableCollection<Partner> _partnerList = new ViewableObservableCollection<Partner>();
        public ViewableObservableCollection<Partner> PartnerList
        {
            get { return _partnerList; }
            set { SetField(ref _partnerList, value, () => PartnerList); }
        }


        private ViewableObservableCollection<PrzyrzadPomiarowy> _PrzyrzadKalibrowanyCollection = new ViewableObservableCollection<PrzyrzadPomiarowy>();
        public ViewableObservableCollection<PrzyrzadPomiarowy> PrzyrzadyPomiaroweCollection
        {
            get { return _PrzyrzadKalibrowanyCollection; }
            set
            {
                SetField(ref _PrzyrzadKalibrowanyCollection, value, () => PrzyrzadyPomiaroweCollection);
            }
        }

        private PrzyrzadPomiarowy _CurrentPrzyrzadKalibrowany;
        public PrzyrzadPomiarowy CurrentPrzyrzad
        {
            get { return _CurrentPrzyrzadKalibrowany; }
            set
            {
                SetField(ref _CurrentPrzyrzadKalibrowany, value, () => CurrentPrzyrzad);
            }
        }

        Document _selectedDocument;
        public Document SelectedDocument
        {
            get { return _selectedDocument; }
            set
            {
                SetField(ref _selectedDocument, value, () => SelectedDocument);
            }

        }


        private FilterPanelVM _myFilteredPanel = new FilterPanelVM();
        public FilterPanelVM MyFilteredPanel
        {
            get { return _myFilteredPanel; }
            set { SetField(ref _myFilteredPanel, value, () => MyFilteredPanel); }
        }

        System.Linq.Expressions.Expression<Func<Partner, bool>> predicate;

        public PartnerVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                this.MyFilteredPanel.FilterChanged += new EventHandler(MyFilteredPanel_FilterChanged);
                this.MyFilteredPanel.isORFieldsFiltered = true;
                FilterField startFieldForFiltering1 = new FilterField { FieldName = "PartnerCode", DisplayText = "_9_PartnerCode_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.NotEmpty };
                FilterField startFieldForFiltering2 = new FilterField { FieldName = "PartnerName", DisplayText = "_9_PartnerName_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.NotEmpty };

                this.MyFilteredPanel.FieldsFiltered.Add(startFieldForFiltering1);
                this.MyFilteredPanel.FieldsFiltered.Add(startFieldForFiltering2);

                this.MyFilteredPanel.FieldsCollection.Add(startFieldForFiltering1);
                this.MyFilteredPanel.FieldsCollection.Add(startFieldForFiltering2);
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "PartnerType", DisplayText = "_9_PartnerType_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "Partnerphone", DisplayText = "_9_Partnerphone_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "PartnerFax", DisplayText = "_9_PartnerFax_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "PartnerEmail", DisplayText = "_9_PartnerEmail_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "PartnerWWW", DisplayText = "_9_PartnerWWW_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "PartnerKeyWords", DisplayText = "_9_PartnerKeyWords_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "PartnerReliabilityRating", DisplayText = "_9_PartnerReliabilityRating_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                Reload();
            }
        }

        void MyFilteredPanel_FilterChanged(object sender, EventArgs e)
        {
            predicate = MyFilteredPanel.BuildPredicate<Partner>();
            PartnerList = new ViewableObservableCollection<Partner>(Partner.Load(predicate));
            if (PartnerList != null && PartnerList.Count > 0)
            {
                CurrentPartner = PartnerList.FirstOrDefault();
            }
        }

        private void Reload()
        {
            predicate = MyFilteredPanel.BuildPredicate<Partner>();
            PartnerList = new ViewableObservableCollection<Partner>(Partner.Load(predicate).OrderBy(p => p.PartnerName));

        }

        private void LoadPrzyrzadyKalibrowane()
        {
            if (CurrentPartner != null)
            {
                PrzyrzadyPomiaroweCollection = new ViewableObservableCollection<PrzyrzadPomiarowy>(Partner.LoadPrzyrzady(CurrentPartner).OrderBy(p => p.PrzyrzadPomiarowyNrKod));
            }
        }


        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {
                case "CurrentPartner":
                    {
                        DetailVisibility = CurrentPartner == null ? Visibility.Hidden : Visibility.Visible;
                        if (CurrentPartner != null) deleteAskObjectName = CurrentPartner.PartnerCode;
                        LoadPrzyrzadyKalibrowane();
                        break;
                    }


                case "isSelectedBy":
                    {
                        //switch (isSelectedBy)
                        //{
                        //    case SelectionTab.None:
                        //        break;
                        //    case SelectionTab.ByClassification:
                        //        break;
                        //    case SelectionTab.ByFilter:
                        //        break;
                        //    case SelectionTab.DeletedItems:
                        //        break;
                        //    default:
                        //        break;
                        //}
                        break;
                    }



                default:
                    break;
            }
        }

        RelayCommand _NewPartnerCommand;
        public RelayCommand NewPartnerCommand
        {
            get
            {

                return _NewPartnerCommand ??
                       (_NewPartnerCommand = new RelayCommand(
                        param =>
                        {
                            Partner newPartner = Partner.Create();
                            PartnerList.Add(newPartner);
                            CurrentPartner = newPartner;
                        },
                        param => RegisteredUser.CurrentUser.hasPrivilege(PrivilegeListEnum._canAddPartner)
                        ));
            }
        }

        protected override bool CanDeleteCommand()
        {

            return CurrentPartner != null && !CurrentPartner.kalibracjaList.Any() &&
                !ReadOnly && RegisteredUser.CurrentUser.hasPrivilege(PrivilegeListEnum._canDeletePartner);
        }

        protected override void DeleteFromBase()
        {
            CurrentPartner.Remove();
            PartnerList.Remove(CurrentPartner);
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
                                                        PrzyrzadPomiarowyVM dataContext = new PrzyrzadPomiarowyVM(CurrentPrzyrzad);
                                                        WindowManagerClass.WindowOpener<PrzyrzadPomiarowySingleWindow>(WindowContextEnum.measuringLabs, false, false, dataContext);
                                                    },
                                                    param => CurrentPrzyrzad != null
                                                    );
                }
                return m_PrzyrzadPomiarowySingleWindowOpenCommand;
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
                            string attachFile = SelectedDocument.filePath.Path + "/" + SelectedDocument.FileName;

                            Abakon15.Utility.MAPI mapi = new Abakon15.Utility.MAPI();
                            mapi.AddAttachment(attachFile);
                            mapi.SendMailPopup(SelectedDocument.docDescription, "Witam");
                        },
                        param => true
                        );
                }
                return m_sendEmailCommand;
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
            if (SelectedDocument != null)
            {
                try
                {
                    string fileName = SelectedDocument.filePath.Path + "/" + SelectedDocument.FileName;
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
                                                                SelectedDocument.documentClassificationPattern = win.documentClassificationPattern;
                                                            }
                                                            RaisePropertyChanged(() => SelectedDocument);
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
                            AbakonDataModel.Document.Create(FilePathForNewDocuments, FilesUtility.FileNameFromFullName(file), CurrentPartner);
                        }
                        else
                        {
                            MessageBox.Show(result.ExceptionMsg);
                        }

                    }
                }

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
                                                        CurrentPartner.documents.Remove(SelectedDocument);
                                                        RaisePropertyChanged(() => SelectedDocument);
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

                                                    },
                                                    param => SelectedDocument != null
                                                    );
                }
                return m_DisconnectDocumentCommand;
            }
        }


        protected override void RaiseChanged()
        {
            base.RaiseChanged();
            RaisePropertyChanged(() => CurrentPartner);
        }

    }
}
