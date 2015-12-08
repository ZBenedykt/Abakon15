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
    class DepartmentVM : ViewModelBase
    {
        //public bool hasPrivilegePersonEdit
        //{
        //    get
        //    {
        //        return AktRegisteredUser.hasPrivilege(PrivilegeListEnum._projectEdit.ToString());
        //    }
        //}


        Visibility _AllDepartmentsVisibility = Visibility.Collapsed;
        public Visibility AllDepartmentsVisibility
        {
            get { return _AllDepartmentsVisibility; }
            set { SetField(ref _AllDepartmentsVisibility, value, () => AllDepartmentsVisibility); }
        }


        private ViewableObservableCollection<Department> _DepartmentList = new ViewableObservableCollection<Department>();
        public ViewableObservableCollection<Department> DepartmentList
        {
            get { return _DepartmentList; }
            set
            {
                SetField(ref _DepartmentList, value, () => DepartmentList);
            }
        }


        private AbakonDataModel.Department _currentDepartment;
        public AbakonDataModel.Department CurrentDepartment
        {
            get { return _currentDepartment; }
            set
            {
                SetField(ref _currentDepartment, value, () => CurrentDepartment);
            }
        }

        bool _isDepartmentSelected = false;

        public bool isDepartmentSelected
        {
            get { return _isDepartmentSelected; }
            set { SetField(ref _isDepartmentSelected, value, () => isDepartmentSelected); }
        }

        public DepartmentVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                LoadDepartmentList();
            }
        }

        private void LoadDepartmentList()
        {
            DepartmentList = new ViewableObservableCollection<Department>(Department.Load());
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {

                case "CurrentDepartment":
                    {
                        isDepartmentSelected = CurrentDepartment != null;
                        deleteAskObjectName = CurrentDepartment != null ? CurrentDepartment.DepartmentName : "";
                        break;
                    }
                default:
                    break;
            }
        }

        RelayCommand _newDepartmentCommand;
        public RelayCommand NewDepartmentCommand
        {
            get
            {

                return _newDepartmentCommand ??
                       (_newDepartmentCommand = new RelayCommand(
                        param =>
                        {

                            if (param == null)
                            {
                                Department newRec = Department.Create();
                                DepartmentList.Add(newRec);
                                CurrentDepartment = newRec;
                                RaisePropertyChanged("CurrentDepartment");
                            }
                            else if ((param as Department) != null)
                            {
                                Department newRec = Department.Create(param as Department);
                                Guid xGuid = newRec.DepartmentId;

                                DepartmentList = new ViewableObservableCollection<Department>(Department.Load());
                                CurrentDepartment = Department.GetDepartment(xGuid);

                            }
                        },

                        param => true
                        ));
            }
        }

        RelayCommand m_changeParentDepartmentCommand = null;
        public RelayCommand CangeParentDepartmentCommand
        {
            get
            {
                if (m_changeParentDepartmentCommand == null)
                {
                    m_changeParentDepartmentCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        if (param == null)
                                                        {
                                                            CurrentDepartment.ParentDepartment = null; // .ChangeParent();
                                                            DepartmentList.Add(CurrentDepartment);
                                                        }
                                                        else
                                                        {
                                                            DepartmentSelectionWindow win = WindowManagerClass.WindowOpener<DepartmentSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true) as DepartmentSelectionWindow;
                                                            {
                                                                if (win.DialogResult.Value)
                                                                {
                                                                    Department tempDepartment = CurrentDepartment;
                                                                    if (CurrentDepartment.ParentDepartment != null)
                                                                    {
                                                                        CurrentDepartment.ParentDepartment.subordinateList.Remove(CurrentDepartment);
                                                                    }

                                                                    win.department.subordinateList.Add(tempDepartment);
                                                                    DepartmentList = new ViewableObservableCollection<Department>(Department.Load());
                                                                }
                                                            }
                                                        }

                                                    },
                                                    param => CurrentDepartment != null
                                                    );
                }
                return m_changeParentDepartmentCommand;
            }
        }

        protected override bool CanDeleteCommand()
        {
            return base.CanDeleteCommand() && CurrentDepartment != null &&
                (CurrentDepartment.subordinateList == null || !CurrentDepartment.subordinateList.Any());
        }

        protected override void DeleteFromBase()
        {
            Department x = CurrentDepartment;
            CurrentDepartment.Delete();
            if (DepartmentList.Contains(x))
            {
                DepartmentList.Remove(x);
            }
        }

    }
}
