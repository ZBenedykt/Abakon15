using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using AbakonDataModel;
using System.ComponentModel;
using System.Windows;
using Abakon15.Infrastructure;
using Abakon15.Utility;

namespace Abakon15.ViewModels
{
    public class FilePathVM : ViewModelBase
    {

        private ObservableCollection<FilePath> _FilePathList = new ObservableCollection<FilePath>();
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

        public FilePathVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                LoadFilePathList();
            }
        }
        private void LoadFilePathList()
        {
            FilePathList = new ObservableCollection<FilePath>(FilePath.Load());
        }


        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {

                case "CurrentFilePath":
                    {
                        deleteAskObjectName = CurrentFilePath != null ? CurrentFilePath.Name : "";
                        break;
                    }
                default:
                    break;
            }
        }

        protected override bool CanDeleteCommand()
        {
            return base.CanDeleteCommand() && CurrentFilePath != null;

        }

        protected override void DeleteFromBase()
        {
            FilePath x = CurrentFilePath;
            CurrentFilePath.Delete();
            if (FilePathList.Contains(x))
            {
                FilePathList.Remove(x);
            }
        }


        //NewFilePathCommand

        RelayCommand _newFilePathCommand;
        public RelayCommand NewFilePathCommand
        {
            get
            {

                return _newFilePathCommand ??
                       (_newFilePathCommand = new RelayCommand(
                        param =>
                        {

                            FilePath newRec = FilePath.Create();
                            FilePathList.Add(newRec);
                            FilePathList = new ObservableCollection<FilePath>(FilePath.Load());
                            CurrentFilePath = newRec;
                            RaisePropertyChanged("CurrentFilePath");

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
                            CurrentFilePath.Path = FilesUtility.SelectFolderName(CurrentFilePath.Path);

                            RaisePropertyChanged(() => CurrentFilePath);
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
                        param => CurrentFilePath != null && !ReadOnly
                        );
                }
                return m_showPathCommand;
            }
        }
    }
}
