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

namespace Abakon15.ViewModels
{
    public class EquipmentTypeVM : ViewModelBase
    {

        Visibility _AllEquipmentTypeVisibility = Visibility.Collapsed;
        public Visibility AllEquipmentTypeVisibility
        {
            get { return _AllEquipmentTypeVisibility; }
            set { SetField(ref _AllEquipmentTypeVisibility, value, () => AllEquipmentTypeVisibility); }
        }


        private ViewableObservableCollection<EquipmentType> _EquipmentTypeList = new ViewableObservableCollection<EquipmentType>();
        public ViewableObservableCollection<EquipmentType> EquipmentTypeList
        {
            get { return _EquipmentTypeList; }
            set
            {
                SetField(ref _EquipmentTypeList, value, () => EquipmentTypeList);
            }
        }


        private AbakonDataModel.EquipmentType _currentEquipmentType;
        public AbakonDataModel.EquipmentType CurrentEquipmentType
        {
            get { return _currentEquipmentType; }
            set
            {
                SetField(ref _currentEquipmentType, value, () => CurrentEquipmentType);
            }
        }

        bool _isEquipmentTypeSelected = false;

        public bool isEquipmentTypeSelected
        {
            get { return _isEquipmentTypeSelected; }
            set { SetField(ref _isEquipmentTypeSelected, value, () => isEquipmentTypeSelected); }
        }

        public EquipmentTypeVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                LoadEquipmentTypeList();
            }
        }

        private void LoadEquipmentTypeList()
        {
            EquipmentTypeList = new ViewableObservableCollection<EquipmentType>(EquipmentType.Load());
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {

                case "CurrentEquipmentType":
                    {
                        isEquipmentTypeSelected = CurrentEquipmentType != null;
                        deleteAskObjectName = CurrentEquipmentType != null ? CurrentEquipmentType.EquipmentTypeName : "";
                        break;
                    }
                default:
                    break;
            }
        }

        RelayCommand _newEquipmentTypeCommand;
        public RelayCommand NewEquipmentTypeCommand
        {
            get
            {

                return _newEquipmentTypeCommand ??
                       (_newEquipmentTypeCommand = new RelayCommand(
                        param =>
                        {

                            if (param == null)
                            {
                                EquipmentType newRec = EquipmentType.Create();
                                EquipmentTypeList.Add(newRec);
                                CurrentEquipmentType = newRec;
                                RaisePropertyChanged("CurrentEquipmentType");
                            }
                            else if ((param as EquipmentType) != null)
                            {
                                EquipmentType newRec = EquipmentType.Create(param as EquipmentType);
                                Guid xGuid = newRec.EquipmentTypeId;

                                EquipmentTypeList = new ViewableObservableCollection<EquipmentType>(EquipmentType.Load());
                                CurrentEquipmentType = EquipmentType.GetEquipmentType(xGuid);

                            }
                        },

                        param => true
                        ));
            }
        }

        RelayCommand m_changeParentEquipmentTypeCommand = null;
        public RelayCommand CangeParentEquipmentTypeCommand
        {
            get
            {
                if (m_changeParentEquipmentTypeCommand == null)
                {
                    m_changeParentEquipmentTypeCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        if (param == null)
                                                        {
                                                            CurrentEquipmentType.parentEquipmentType = null; // .ChangeParent();
                                                            EquipmentTypeList.Add(CurrentEquipmentType);
                                                        }
                                                        else
                                                        {
                                                            EquipmentTypeSelectionWindow win = WindowManagerClass.WindowOpener<EquipmentTypeSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true) as EquipmentTypeSelectionWindow;
                                                            {
                                                                if (win.DialogResult.Value)
                                                                {
                                                                    EquipmentType tempType = CurrentEquipmentType;
                                                                    if (CurrentEquipmentType.parentEquipmentType != null)
                                                                    {
                                                                        CurrentEquipmentType.parentEquipmentType.subordinateList.Remove(CurrentEquipmentType);
                                                                    }
                                                                    win.EquipmentType.subordinateList.Add(tempType);
                                                                    EquipmentTypeList = new ViewableObservableCollection<EquipmentType>(EquipmentType.Load());
                                                                }
                                                            }
                                                        }

                                                    },
                                                    param => CurrentEquipmentType != null
                                                    );
                }
                return m_changeParentEquipmentTypeCommand;
            }
        }

        protected override bool CanDeleteCommand()
        {
            return base.CanDeleteCommand() && CurrentEquipmentType != null &&
                (CurrentEquipmentType.subordinateList == null || !CurrentEquipmentType.subordinateList.Any());
        }

        protected override void DeleteFromBase()
        {
            EquipmentType x = CurrentEquipmentType;
            CurrentEquipmentType.Delete();
            if (EquipmentTypeList.Contains(x))
            {
                EquipmentTypeList.Remove(x);
            }
        }

        RelayCommand m_BalanceFeatureWindowOpenCommand = null;
        public RelayCommand BalanceFeatureWindowOpenCommand
        {
            get
            {
                if (m_BalanceFeatureWindowOpenCommand == null)
                {
                    m_BalanceFeatureWindowOpenCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        //PrzyrzadPomiarowy p = param as PrzyrzadPomiarowy;
                                                        //if (p != null)
                                                        {
                                                            //         PrzyrzadPomiarowyVM dataContext = new PrzyrzadPomiarowyVM(p);
                                                            WindowManagerClass.WindowOpener<BalanceFeaturesWindow>(WindowContextEnum.empty, false, false);
                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_BalanceFeatureWindowOpenCommand;
            }
        }
    }
}
