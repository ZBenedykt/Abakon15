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
using System.Windows.Controls;
namespace Abakon15.ViewModels
{
    class _KeyBoardKeyVM : ViewModelBase
    {
        private ObservableCollection<_KeyBoardKey> __KeyBoardKeyCollection;
        public ObservableCollection<_KeyBoardKey> _KeyBoardKeyCollection
        {
            get { return __KeyBoardKeyCollection; }
            set { SetField(ref __KeyBoardKeyCollection, value, () => _KeyBoardKeyCollection); }
        }

        private _KeyBoardKey _current_KeyBoardKey;
        public _KeyBoardKey Current_KeyBoardKey
        {
            get { return _current_KeyBoardKey; }
            set { SetField(ref _current_KeyBoardKey, value, () => Current_KeyBoardKey); }
        }

        public _KeyBoardKeyVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                Load_KeyBoardKeyCollection();
            }
        }

        private void Load_KeyBoardKeyCollection()
        {
            _KeyBoardKeyCollection = new ObservableCollection<_KeyBoardKey>(_KeyBoardKey.Load());
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {

                case "Current_KeyBoardKey":
                    {
                        deleteAskObjectName = Current_KeyBoardKey != null ? Current_KeyBoardKey._KeyValue : "";
                        break;
                    }
                default:
                    break;
            }
        }

        protected override bool CanDeleteCommand()
        {
            return base.CanDeleteCommand() && Current_KeyBoardKey != null;
        }

        protected override void DeleteFromBase()
        {
            _KeyBoardKey x = Current_KeyBoardKey;
            _KeyBoardKey.Delete(x);
            if (_KeyBoardKeyCollection.Contains(x))
            {
                _KeyBoardKeyCollection.Remove(x);
            }
        }

        RelayCommand _new_KeyBoardKey;
        public RelayCommand New_KeyBoardKey
        {
            get
            {

                return _new_KeyBoardKey ??
                       (_new_KeyBoardKey = new RelayCommand(
                        param =>
                        {

                            _KeyBoardKey newRec = _KeyBoardKey.Create();

                            _KeyBoardKeyCollection.Add(newRec);
                            Current_KeyBoardKey = newRec;

                            RaisePropertyChanged("Current_KeyBoardKey");
                            DataGrid dg = param as DataGrid;
                            if (dg != null)
                            {
                                dg.CommitEdit();
                                try
                                {
                                    dg.Items.Refresh();
                                }
                                catch (Exception)
                                {

                                }
                            }
                        },
                        param => true
                        ));
            }
        }

        RelayCommand _InitilizeCommand;
        public RelayCommand InitilizeCommand
        {
            get
            {

                return _InitilizeCommand ??
                       (_InitilizeCommand = new RelayCommand(
                        param =>
                        {
                            _KeyBoardKey.SetDefault();
                            Load_KeyBoardKeyCollection();
                        },
                        param => !_KeyBoardKeyCollection.Any()
                        ));
            }
        }
    }
}
