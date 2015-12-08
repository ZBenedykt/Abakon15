using AbakonDataModel;
using Abakon15.Views;
using Abakon15.Views.Windows;
using Abakon15.Infrastructure;
using System.ComponentModel;
using System.Windows;

namespace Abakon15.ViewModels
{
    class DocumentClassificationPatternVM : ViewModelBase
    {
        private ViewableObservableCollection<DocumentClassificationPattern> _DocumentClassificationPatternList = new ViewableObservableCollection<DocumentClassificationPattern>();
        public ViewableObservableCollection<DocumentClassificationPattern> DocumentClassificationPatternList
        {
            get { return _DocumentClassificationPatternList; }
            set
            {
                SetField(ref _DocumentClassificationPatternList, value, () => DocumentClassificationPatternList);
            }
        }


        private AbakonDataModel.DocumentClassificationPattern _currentDocumentClassificationPattern;
        public AbakonDataModel.DocumentClassificationPattern CurrentDocumentClassificationPattern
        {
            get { return _currentDocumentClassificationPattern; }
            set
            {
                SetField(ref _currentDocumentClassificationPattern, value, () => CurrentDocumentClassificationPattern);
            }
        }

        bool _isDocumentClassificationPatternSelected = false;

        public bool isDocumentClassificationPatternSelected
        {
            get { return _isDocumentClassificationPatternSelected; }
            set { SetField(ref _isDocumentClassificationPatternSelected, value, () => isDocumentClassificationPatternSelected); }
        }

        public DocumentClassificationPatternVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                LoadDocumentClassificationPatternList();
            }
        }

        private void LoadDocumentClassificationPatternList()
        {
            DocumentClassificationPatternList = new ViewableObservableCollection<DocumentClassificationPattern>(DocumentClassificationPattern.LoadRoots());
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {

                case "CurrentDocumentClassificationPattern":
                    {
                        isDocumentClassificationPatternSelected = CurrentDocumentClassificationPattern != null;
                        deleteAskObjectName = CurrentDocumentClassificationPattern != null ? CurrentDocumentClassificationPattern.dcpName : "";
                        break;
                    }
                default:
                    break;
            }
        }

        RelayCommand _newDocumentClassificationPatternCommand;
        public RelayCommand NewDocumentClassificationPatternCommand
        {
            get
            {

                return _newDocumentClassificationPatternCommand ??
                       (_newDocumentClassificationPatternCommand = new RelayCommand(
                        param =>
                        {

                            if (param == null)
                            {
                                DocumentClassificationPattern newRec = DocumentClassificationPattern.Create();
                                DocumentClassificationPatternList.Add(newRec);
                                CurrentDocumentClassificationPattern = newRec;
                                RaisePropertyChanged("CurrentDocumentClassificationPattern");
                            }
                            else if ((param as DocumentClassificationPattern) != null)
                            {
                                DocumentClassificationPattern newRec = DocumentClassificationPattern.Create(param as DocumentClassificationPattern);
                                int xdcpId = newRec.dcpId;

                                DocumentClassificationPatternList = new ViewableObservableCollection<DocumentClassificationPattern>(DocumentClassificationPattern.LoadRoots());
                                CurrentDocumentClassificationPattern = DocumentClassificationPattern.GetDocumentClassificationPattern(xdcpId);

                            }
                        },

                        param => true
                        ));
            }
        }

        RelayCommand m_changeParentDocumentClassificationPatternCommand = null;
        public RelayCommand CangeParentDocumentClassificationPatternCommand
        {
            get
            {
                if (m_changeParentDocumentClassificationPatternCommand == null)
                {
                    m_changeParentDocumentClassificationPatternCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        if (param == null)
                                                        {
                                                            CurrentDocumentClassificationPattern.parent = null; // .ChangeParent();
                                                            DocumentClassificationPatternList.Add(CurrentDocumentClassificationPattern);
                                                        }
                                                        else
                                                        {
                                                            DocumentClassificationPatternSelectionWindow win = WindowManagerClass.WindowOpener<DocumentClassificationPatternSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true) as DocumentClassificationPatternSelectionWindow;
                                                            {
                                                                if (win.DialogResult.Value)
                                                                {
                                                                    DocumentClassificationPattern tempType = CurrentDocumentClassificationPattern;

                                                                    if (CurrentDocumentClassificationPattern.parent != null)
                                                                    {
                                                                        CurrentDocumentClassificationPattern.parent.dcChildren.Remove(CurrentDocumentClassificationPattern);
                                                                    }
                                                                    win.documentClassificationPattern.dcChildren.Add(tempType);
                                                                    if (DocumentClassificationPatternList.Contains(CurrentDocumentClassificationPattern))
                                                                    {
                                                                        DocumentClassificationPatternList.Remove(CurrentDocumentClassificationPattern);
                                                                    }
                                                                    DocumentClassificationPatternList = new ViewableObservableCollection<DocumentClassificationPattern>(DocumentClassificationPattern.LoadRoots());
                                                                }
                                                            }
                                                        }

                                                    },
                                                    param => CurrentDocumentClassificationPattern != null
                                                    );
                }
                return m_changeParentDocumentClassificationPatternCommand;
            }
        }

        protected override bool CanDeleteCommand()
        {
            return base.CanDeleteCommand() && CurrentDocumentClassificationPattern != null &&
                (CurrentDocumentClassificationPattern.dcChildren == null || CurrentDocumentClassificationPattern.dcChildren.Count == 0);
        }

        protected override void DeleteFromBase()
        {
            DocumentClassificationPattern x = CurrentDocumentClassificationPattern;
            CurrentDocumentClassificationPattern.Delete();
            if (DocumentClassificationPatternList.Contains(x))
            {
                DocumentClassificationPatternList.Remove(x);
            }
        }
    }
}
