using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abakon15WPF.Infrastructure;
using System.ComponentModel;
using System.Windows;
using System.Collections.Specialized;
using Abakon15WPF.Interfaces;
using System.Collections.ObjectModel;
using AbakonDataModel;
using Abakon15WPF.Utility;
using Abakon15WPF.Views.Windows;
using System.Windows.Controls;
namespace Abakon15WPF.ViewModels
{
    public class DocumentVM : ViewModelBase
    {


        private Document _currentDocument;
        public Document CurrentDocument
        {
            get { return _currentDocument; }
            set { SetField(ref _currentDocument, value, () => CurrentDocument); }
        }

        private ViewableObservableCollection<Document> _documentCollection;
        public ViewableObservableCollection<Document> DocumentCollection
        {
            get { return _documentCollection; }
            set { SetField(ref _documentCollection, value, () => DocumentCollection); }
        }

        private FilterPanelVM _myFilteredPanel = new FilterPanelVM();
        public FilterPanelVM MyFilteredPanel
        {
            get { return _myFilteredPanel; }
            set { SetField(ref _myFilteredPanel, value, () => MyFilteredPanel); }
        }

        private string _predicateString = "";
        public string PredicateString
        {
            get { return _predicateString; }
            set { SetField(ref _predicateString, value, () => PredicateString); }
        }

        System.Linq.Expressions.Expression<Func<Document, bool>> predicateDocument;

        Collection<FilterField> FieldsCollectionDocument = new Collection<FilterField>();

        public DocumentVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                this.MyFilteredPanel.FilterChanged += new EventHandler(MyFilteredPanel_FilterChanged);

                FilterField startFieldForFiltering = new FilterField { FieldName = "FileName", DisplayText = "_5_fileName_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains };
                this.MyFilteredPanel.FieldsFiltered.Add(startFieldForFiltering);

                MyFilteredPanel.FieldsCollection.Add(startFieldForFiltering);
                MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "docDescription", DisplayText = "_5_description_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "CreateDate", DisplayText = "_5_createDate_Label".Translate(), TypDanych = FilterTypyDanych.DateTime, MetodaKomparacji = OperatoryRelacjiEnum.GreaterEqual });
                MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "UserName", DisplayText = "_5_uerName_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });




            }
        }

        void MyFilteredPanel_FilterChanged(object sender, EventArgs e)
        {
            PredicateString = MyFilteredPanel.FilterTextApplied;
            FiltrujWgWyboru();
        }

        private void FiltrujWgWyboru()
        {
            predicateDocument = MyFilteredPanel.BuildPredicate<Document>();

            DocumentCollection = new ViewableObservableCollection<Document>(Document.Load(predicateDocument));
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
                                                        CurrentDocument.Remove();
                                                    },
                                                     param => CurrentDocument != null
                                                    );
                }
                return m_DeleteDocumentCommand;
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
                            string attachFile = CurrentDocument.filePath.Path + "/" + CurrentDocument.FileName;

                            MAPI mapi = new MAPI();
                            mapi.AddAttachment(attachFile);
                            mapi.SendMailPopup(CurrentDocument.FileName, "Witam");
                        },
                        param => true
                        );
                }
                return m_sendEmailCommand;
            }
        }

        RelayCommand m_clearDocumentsCommand;
        public RelayCommand ClearDocumentsCommand
        {
            get
            {
                if (m_clearDocumentsCommand == null)
                {
                    m_clearDocumentsCommand = new RelayCommand(
                        param =>
                        {
                            DataGrid gr = param as DataGrid;
                            List<Document> deletedFiles = new List<Document>();
                           
                            Document.Clear(deletedFiles);
                            deletedFiles = new List<Document>();

                            foreach (Document item in DocumentCollection)
                            {
                                if (item.filePath != null)
                                {
                                    if (!FilesUtility.ifFileExist(item.filePath.Path, item.FileName))
                                    {
                                        deletedFiles.Add(item);
                                    }
                                }
                            }
                            Document.Clear(deletedFiles);
                            if (gr != null)
                            {
                                gr.CommitEdit();
                                gr.Items.Refresh();
                            }
                        },
                        param => true
                        );
                }
                return m_clearDocumentsCommand;
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
            if (CurrentDocument != null)
            {
                try
                {
                    string fileName = CurrentDocument.filePath.Path + "/" + CurrentDocument.FileName;

                    FilesUtility.OpenFile(fileName);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "_Caution".Translate(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        RelayCommand m_showFolderCommand;
        public RelayCommand ShowFolderCommand
        {
            get
            {
                if (m_showFolderCommand == null)
                {
                    m_showFolderCommand = new RelayCommand(
                        param => this.ShowFolder(),
                        param => true
                        );
                }
                return m_showFolderCommand;
            }
        }

        private void ShowFolder()
        {
            FileFolderDialog fdialog = new FileFolderDialog();

            if (CurrentDocument != null)
            {
                fdialog.Dialog.InitialDirectory = CurrentDocument.filePath.Path;
            }
            fdialog.Dialog.ShowDialog();
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
                                                                CurrentDocument.documentClassificationPattern = win.documentClassificationPattern;
                                                                System.Windows.Controls.DataGrid ctrl = param as System.Windows.Controls.DataGrid;
                                                                if (ctrl != null)
                                                                {
                                                                    ctrl.CommitEdit();
                                                                    ctrl.Items.Refresh();
                                                                }
                                                                SaveToDB();
                                                            }
                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_SelectDocumentClassifierCommand;
            }
        }


        private ObservableCollection<FilePath> _FilePathList = new ObservableCollection<FilePath>(FilePath.Load());
        public ObservableCollection<FilePath> FilePathList
        {
            get { return _FilePathList; }
            set
            {
                SetField(ref _FilePathList, value, () => FilePathList);
            }
        }

        private FilePath _filePathForNewDocuments;
        public FilePath FilePathForNewDocuments
        {
            get { return _filePathForNewDocuments; }
            set { SetField(ref _filePathForNewDocuments, value, () => FilePathForNewDocuments); }
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
                            AbakonDataModel.Document.Create(FilePathForNewDocuments, FilesUtility.FileNameFromFullName(file), partner: null);
                        }
                        else
                        {

                            MessageBox.Show(result.ExceptionMsg);
                        }
                    }
                }
            }
        }




        RelayCommand m_ConnectPartnerToDocumentCommand = null;
        public RelayCommand ConnectPartnerToDocumentCommand
        {
            get
            {
                if (m_ConnectPartnerToDocumentCommand == null)
                {
                    m_ConnectPartnerToDocumentCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        PartnerSelectionWindow win = WindowManagerClass.WindowOpener<PartnerSelectionWindow>(WindowContextEnum.persons, true, true) as PartnerSelectionWindow;
                                                        if (win.DialogResult.HasValue && win.partner != null)
                                                        {
                                                            CurrentDocument.partners.Add(win.partner);
                                                            CurrentDocument.SaveToDb();
                                                            DataGrid dg = param as DataGrid;
                                                            if (dg != null) { dg.Items.Refresh(); }
                                                        }

                                                    },
                                                    param => CurrentDocument != null
                                                    );
                }
                return m_ConnectPartnerToDocumentCommand;
            }
        }

    }
}
