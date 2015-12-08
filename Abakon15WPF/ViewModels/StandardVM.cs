using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using AbakonDataModel;
using System.ComponentModel;
using System.Windows;
using Abakon15WPF.Infrastructure;
using Abakon15WPF.Utility;

namespace Abakon15WPF.ViewModels
{
    public class StandardVM : ViewModelBase
    {

        private ObservableCollection<FilePath> _filePaths;
        public ObservableCollection<FilePath> FilePaths
        {
            get { return _filePaths; }
            set { SetField(ref _filePaths, value, () => FilePaths); }
        }

        List<Tuple<int, string>> _KalibracjaEtapEnumTranslate = new List<Tuple<int, string>>(Abakon15WPF.Infrastructure.EnumHelper.TranslateEnumerator<KalibracjaEtapEnum>());
        public List<Tuple<int, string>> KalibracjaEtapEnumTranslate
        {
            get { return _KalibracjaEtapEnumTranslate; }
        }

        private ObservableCollection<Standard> _StandardList = new ObservableCollection<Standard>();
        public ObservableCollection<Standard> StandardList
        {
            get { return _StandardList; }
            set
            {
                SetField(ref _StandardList, value, () => StandardList);
            }
        }

        private Standard _currentStandard;
        public Standard CurrentStandard
        {
            get { return _currentStandard; }
            set
            {
                SetField(ref _currentStandard, value, () => CurrentStandard);
            }
        }

        public StandardVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                FilePaths = new ObservableCollection<FilePath>(FilePath.Load());
                LoadStandardList();
            }
        }
        private void LoadStandardList()
        {
            StandardList = new ObservableCollection<Standard>(Standard.Load());
        }


        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {

                case "CurrentStandard":
                    {
                        deleteAskObjectName = CurrentStandard != null ? CurrentStandard.Name : "";
                        break;
                    }
                default:
                    break;
            }
        }

        protected override bool CanDeleteCommand()
        {
            return base.CanDeleteCommand() && CurrentStandard != null;

        }

        protected override void DeleteFromBase()
        {
            Standard x = CurrentStandard;
            CurrentStandard.Delete();
            if (StandardList.Contains(x))
            {
                StandardList.Remove(x);
            }
        }


        //NewStandardCommand

        RelayCommand _newStandardCommand;
        public RelayCommand NewStandardCommand
        {
            get
            {

                return _newStandardCommand ??
                       (_newStandardCommand = new RelayCommand(
                        param =>
                        {

                            Standard newRec = Standard.Create();
                            StandardList.Add(newRec);
                            StandardList = new ObservableCollection<Standard>(Standard.Load());
                            CurrentStandard = newRec;
                            RaisePropertyChanged("CurrentStandard");

                        },

                        param => true
                        ));
            }
        }

        RelayCommand m_showPathCommand;
        public RelayCommand ShowPathCommand
        {
            get
            {
                if (m_showPathCommand == null)
                {
                    m_showPathCommand = new RelayCommand(

                        param =>
                        {
                            FilePath tempFilePath = FilePath.GetFilePath(CurrentStandard.FilePathId);
                            string selFile = FilesUtility.OpenFileDialog(CurrentStandard.FileName, initialDir: tempFilePath.Path);
                            if (tempFilePath.Path == FilesUtility.DirectoryNameFromFullName(selFile))
                            {
                                CurrentStandard.FileName = FilesUtility.FileNameFromFullName(selFile);
                                RaisePropertyChanged(() => CurrentStandard);
                            }
                            else
                            {
                                MessageBox.Show("Niezgodność ścieżki");
                            }
                            System.Windows.Controls.DataGrid ctrl = param as System.Windows.Controls.DataGrid;

                            try
                            {

                                if (ctrl != null)
                                {
                                    ctrl.CommitEdit();
                                    ctrl.Items.Refresh();
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                        },
                        param => CurrentStandard != null && !ReadOnly && (FilePath.GetFilePath(CurrentStandard.FilePathId) != null)
                        );
                }
                return m_showPathCommand;
            }
        }

        RelayCommand m_OpenFileCommand = null;
        public RelayCommand OpenFileCommand
        {
            get
            {
                if (m_OpenFileCommand == null)
                {
                    m_OpenFileCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        if (Uri.IsWellFormedUriString(CurrentStandard.FileName, UriKind.Absolute))
                                                        {
                                                            System.Diagnostics.Process.Start(CurrentStandard.FileName);
                                                        }
                                                        else
                                                        {

                                                            try
                                                            {
                                                                FilePath tempFilePath = FilePath.GetFilePath(CurrentStandard.FilePathId);
                                                                FilesUtility.OpenFile(tempFilePath.Path + "/" + CurrentStandard.FileName);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                MessageBox.Show(ex.Message);
                                                            }
                                                        }
                                                    },
                                                    param => CurrentStandard != null
                                                    );
                }
                return m_OpenFileCommand;
            }
        }
    }
}

