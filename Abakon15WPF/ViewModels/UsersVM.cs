using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abakon15WPF.Infrastructure;
using System.Windows;
using AbakonDataModel;
using System.ComponentModel;
using System.Windows.Controls;

namespace Abakon15WPF.ViewModels
{
    class UsersVM : ViewModelBase
    {
        private List<Person> _personList;
        public List<Person> PersonList
        {
            get
            {
                if (_personList == null)
                {
                  //  using (AbakonDbContext context = AbakonDbContext.GetModelDbContext(false))
                    {
                        _personList = new List<Person>(Person.LoadLabWorkers());

                    }
                }
                return _personList;
            }
        }

        private ViewableObservableCollection<_User> _users;
        public ViewableObservableCollection<_User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new ViewableObservableCollection<_User>();
                }
                return _users;
            }
            set
            {
                SetField(ref _users, value, () => Users);
            }
        }

        private ViewableObservableCollection<_User> _usersSelected;
        public ViewableObservableCollection<_User> UsersSelected
        {
            get
            {
                if (_usersSelected == null)
                {
                    _usersSelected = new ViewableObservableCollection<_User>();
                }
                return _usersSelected;
            }
            set
            {
                SetField(ref _usersSelected, value, () => UsersSelected);
            }
        }

        private _User _priorCurrentUser;
        private _User _currentUser;
        public _User CurrentUser
        {
            get
            {
                deleteAskObjectName = _currentUser != null ? _currentUser.UserName : "";
                return _currentUser;
            }
            set { SetField(ref _currentUser, value, () => CurrentUser); }
        }

        private _User _userToCopyRoles;
        public _User UserToCopyRoles
        {
            get { return _userToCopyRoles; }
            set { SetField(ref _userToCopyRoles, value, () => UserToCopyRoles); }
        }

        private bool _isSelectedUserToCopyRoles;
        public bool isSelectedUserToCopyRoles
        {
            get { return _isSelectedUserToCopyRoles; }
            set { SetField(ref _isSelectedUserToCopyRoles, value, () => isSelectedUserToCopyRoles); }
        }

        private List<string> _filtrLevelOfConfidency = new List<string>();
        public List<string> FiltrLevelOfConfidency
        {
            get { return _filtrLevelOfConfidency; }
            set { _filtrLevelOfConfidency = value; }
        }

        private string _filtrLevelOfConfidencySelected;
        public string FiltrLevelOfConfidencySelected
        {
            get { return _filtrLevelOfConfidencySelected; }
            set { SetField(ref _filtrLevelOfConfidencySelected, value, () => FiltrLevelOfConfidencySelected); }
        }

        private List<string> _filtrDepartment = new List<string>();
        public List<string> FiltrDepartment
        {
            get { return _filtrDepartment; }
            set { _filtrDepartment = value; }
        }
        private string _filtrDepartmentSelected;
        public string FiltrDepartmentSelected
        {
            get { return _filtrDepartmentSelected; }
            set { SetField(ref _filtrDepartmentSelected, value, () => FiltrDepartmentSelected); }
        }


        protected override bool CanDeleteCommand()
        {
            return CanDeleteUser;
        }

        string _newPassword;
        public string NewPassword
        {
            get { return _newPassword; }
            set { SetField(ref _newPassword, value, () => NewPassword); }
        }

        public bool CanDeleteUser
        {
            get
            {
                return CurrentUser == null ? false : CurrentUser.UserName != RegisteredUser.CurrentUser.UserName;
            }
        }

        public bool isRolesTabItemActive
        {
            get
            {
                return ReadOnly || CanSave();
            }
            set { }
        }

        public UsersVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {

                LoadData();
            }
        }

        //private void LoadPersons()
        //{
        //  //  _personList = new List<Person>();
        //    //Person personNull = new Person();
        //    //personNull.SureName = "???";
        //    //personNull.field_0 = "";
        //    //personNull.id = 0;
        //    using (WisecomData.WisecomDbContext context = WisecomData.WisecomDbContext.GetModelDbContext(false))
        //    {
        //        PersonList = new List<Person>( Employee.LoadEmployeePersons(context));
        //    }
        //}

        private RoleStructure _rolesComplementary;
        public RoleStructure RolesComplementary
        {
            get { return _rolesComplementary; }
            set { SetField(ref _rolesComplementary, value, () => RolesComplementary); }
        }

        private GenRole _currentRoleComplementary;
        public GenRole CurrentRoleComplementary
        {
            get { return _currentRoleComplementary; }
            set { SetField(ref _currentRoleComplementary, value, () => CurrentRoleComplementary); }
        }


        private RoleStructure _rolesActual = new RoleStructure();
        public RoleStructure RolesActual
        {
            get { return _rolesActual; }
            set { SetField(ref _rolesActual, value, () => RolesActual); }
        }

        private GenRole _currentRoleActual;
        public GenRole CurrentRoleActual
        {
            get { return _currentRoleActual; }
            set { SetField(ref _currentRoleActual, value, () => CurrentRoleActual); }
        }

        private bool _flagRolesChanges;

        public string validatingResults
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (CurrentUser != null)
                {
                    foreach (var item in CurrentUser.Validate(null))
                    {
                        sb.AppendLine(item.ErrorMessage);
                    }
                }
                return sb.ToString();
            }
        }

        private void LoadData()
        {
            var coll = _User.Load(); // Dlaczego nie można bezpośrednio podłożyć kolekcji?

            Users = new ViewableObservableCollection<_User>();
            FiltrLevelOfConfidency.Clear();
            FiltrLevelOfConfidency.Add("*");
            FiltrDepartment.Clear();
            FiltrDepartment.Add("*");
            List<int> lint = new List<int>();
            List<string> lDepartment = new List<string>();
            foreach (var item in coll)
            {
                Users.Add(item);
                UsersSelected.Add(item);
                if (item.membership != null)
                {
                    int lc = item.membership.LevelOfConfidence;
                    if (!lint.Contains(lc))
                    {
                        lint.Add(lc);
                    }
                }


            }
            lint.Sort();

            foreach (int k in lint)
            {
                FiltrLevelOfConfidency.Add(k.ToString());
            }
            lDepartment.Sort();
            foreach (var item in lDepartment)
            {
                FiltrDepartment.Add(item);
            }

            FiltrLevelOfConfidencySelected = FiltrLevelOfConfidency.FirstOrDefault();
            FiltrDepartmentSelected = FiltrDepartment.FirstOrDefault();
            CurrentUser = UsersSelected.FirstOrDefault();
        }

        private void FilterData()
        {
            int lcint;
            UsersSelected.Clear();
            bool filterLevel = FiltrLevelOfConfidencySelected == "*";
            bool filterDepartment = FiltrDepartmentSelected == "*";

            if (filterLevel && filterDepartment)
            {

                foreach (var item in Users)
                {
                    UsersSelected.Add(item);
                }
            }
            else
            {
                lcint = filterLevel ? -1 : int.Parse(FiltrLevelOfConfidencySelected);
                foreach (var item in Users)
                {
                    if (filterDepartment)
                    {
                        if (item.membership.LevelOfConfidence == lcint)
                        {
                            UsersSelected.Add(item);
                        }
                    }
                    else if (filterLevel)
                    {

                    }
                    else
                    {
                        if (item.membership.LevelOfConfidence == lcint)
                        {
                            UsersSelected.Add(item);
                        }
                    }
                }
            }
            CurrentUser = UsersSelected.FirstOrDefault();
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {
                case "CurrentUser":
                    {
                        RaisePropertyChanged("CanDeleteUser");
                        if (_flagRolesChanges)
                        {
                            if (MessageBox.Show("_askUpdateRolesChanges".Translate(), "_Caution".Translate(), MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                            {
                                _priorCurrentUser.UpateRoles(RolesActual);
                            }
                            _flagRolesChanges = false;
                            _priorCurrentUser.RerfeshRoles();
                        }

                        if (CurrentUser != null)
                        {
                            RolesActual = CurrentUser.RoleStructure();
                            RolesActual.GetUserRole(CurrentUser);
                            RolesComplementary = RolesActual.ComplementaryRoleStructure();
                        }

                        _priorCurrentUser = CurrentUser;
                        break;
                    }

                case "FiltrLevelOfConfidencySelected":
                case "FiltrDepartmentSelected":
                    {
                        FilterData();
                        break;
                    }

                case "UserToCopyRoles":
                    {
                        isSelectedUserToCopyRoles = _userToCopyRoles != null;
                        break;
                    }


                default:
                    break;
            }
        }

        protected override void DeleteFromBase()
        {
            _User.Remove(CurrentUser);
            Users.Remove(CurrentUser);

        }

        protected override void SaveToDB(object param)
        {
            if (CurrentUser.membership == null)
            {
                CurrentUser.AddMembership();
            }
            base.SaveToDB(param);
            CurrentUser.UpateRoles(RolesActual);
            _flagRolesChanges = false;

        }

        #region ==================== Commands ============================

        public void RebuildRole()
        {
            RolesComplementary.RebuildRoles();
        }

        RelayCommand _clearPasswordCommand;
        public RelayCommand ClearPasswordCommand
        {
            get
            {
                if (_clearPasswordCommand == null)
                {
                    _clearPasswordCommand = new RelayCommand(
                        param =>
                        {
                            string kom = "_clearPasswordAsk".Translate() + ":" + Environment.NewLine + CurrentUser.UserName;
                            string komHeader = "_confirm".Translate();
                            if (MessageBox.Show(kom, komHeader, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                            {
                                CurrentUser.ClearPassword();
                            }
                        },
                        param => true
                        );
                }
                return _clearPasswordCommand;
            }
        }

        public void AddRoleToSelectedUser(_User user)
        {
            CurrentUser = user;
            RolesActual = user.RoleStructure();
            RolesActual.GetUserRole(user);
            RolesActual.AddRole(CurrentRoleComplementary);
            RolesComplementary.RemoveGenRole(CurrentRoleComplementary);
            RolesComplementary = RolesActual.ComplementaryRoleStructure();
            SaveCommand.Execute();

            //   CurrentRoleComplementary = null;
        }

        public void RemoveRoleFromSelectedUser(_User user)
        {
            CurrentUser = user;
            RolesActual = user.RoleStructure();
            RolesActual.RemoveRootGenRole(CurrentRoleActual);

            //RolesActual.GetUserRole(user);
            RolesComplementary = RolesActual.ComplementaryRoleStructure();
            SaveCommand.Execute();
            //      CurrentRoleActual = null;// RolesActual.FirstOrDefault();
        }

        public void RemoveAllRoleFromSelectedUser(_User user)
        {
            CurrentUser = user;
            user.RemoveAllRoles();
            RolesActual = user.RoleStructure();
            RolesComplementary = RolesActual.ComplementaryRoleStructure();
            RolesActual.RemoveRootGenRole(CurrentRoleActual);
            RolesComplementary = RolesActual.ComplementaryRoleStructure();
            SaveCommand.Execute();
            //            CurrentRoleActual = null;
        }

        public void CopyRoles(_User toUser)
        {
            if (UserToCopyRoles != null)
            {
                _User.CopyRolesFromUser(UserToCopyRoles, toUser);

            }
            CurrentUser = UserToCopyRoles;
        }

        RelayCommand _addRoleCommand;
        public RelayCommand AddRoleCommand
        {
            get
            {
                if (_addRoleCommand == null)
                {
                    _addRoleCommand = new RelayCommand(
                        param =>
                        {
                            if (CurrentRoleComplementary != null)
                            {
                                _flagRolesChanges = true;
                                RolesActual.AddRole(CurrentRoleComplementary);
                                RolesComplementary.RemoveGenRole(CurrentRoleComplementary);
                            }
                        },
                        param => CurrentUser != null && !ReadOnly && CurrentUser.IsValid
                        );
                }
                return _addRoleCommand;
            }
        }

        RelayCommand _removeRoleCommand;
        public RelayCommand RemoveRoleCommand
        {
            get
            {
                if (_removeRoleCommand == null)
                {
                    _removeRoleCommand = new RelayCommand(
                        param =>
                        {
                            if (CurrentRoleActual != null)
                            {
                                if (CurrentRoleActual.CanDeleteRole)
                                {
                                    _flagRolesChanges = true;
                                    RolesActual.RemoveRootGenRole(CurrentRoleActual);
                                    RolesComplementary = RolesActual.ComplementaryRoleStructure();
                                    CurrentRoleActual = null;// RolesActual.FirstOrDefault();
                                }
                                else
                                {
                                    MessageBox.Show("_cantRemoveRole".Translate(), "_Caution".Translate(), MessageBoxButton.OK, MessageBoxImage.Warning);
                                }

                            }
                        },
                        param => CurrentUser != null && !ReadOnly && CurrentUser.IsValid
                        );
                }
                return _removeRoleCommand;
            }
        }



        RelayCommand _newUserCommand;
        public RelayCommand NewUserCommand
        {
            get
            {
                if (_newUserCommand == null)
                {
                    _newUserCommand = new RelayCommand(
                        param =>
                        {
                            ListView listView = param as ListView;
                            CurrentUser = _User.Create("");

                            Users.Add(CurrentUser);
                            UsersSelected.Add(CurrentUser);
                            listView.Items.Refresh();
                        },
                        param => !ReadOnly
                        );
                }
                return _newUserCommand;
            }
        }

        RelayCommand _ChangePasswordCommand;
        public RelayCommand ChangePasswordCommand
        {
            get
            {

                return _ChangePasswordCommand ??
                       (_ChangePasswordCommand = new RelayCommand(
                        param =>
                        {
                            string np = ((string)param).Trim();
                            if (np.Length < 6)
                            {
                                MessageBox.Show("_passwordToShort".Translate(), "_error".Translate(), MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {

                                string kom = "_changePasswordAsk".Translate() + ":" + Environment.NewLine + deleteAskObjectName + "_x".Translate();
                                string komHeader = "_confirm".Translate();
                                if (MessageBox.Show(kom, komHeader, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                                {
                                    RegisteredUser.ChangePassword(CurrentUser, np, true);
                                    NewPassword = string.Empty;
                                }
                            }
                        },
                        param => true
                        ));
            }

        }

        protected override bool CanSave()
        {
            RaisePropertyChanged("validatingResults");
            return CurrentUser == null ? false : CurrentUser.IsValid;
        }


        RelayCommand _CopyRolesCommand;
        public RelayCommand CopyRolesCommand
        {
            get
            {

                return _CopyRolesCommand ??
                       (_CopyRolesCommand = new RelayCommand(
                        param =>
                        {
                            CurrentUser.CopyRolesFromUser(UserToCopyRoles);
                            RaisePropertyChanged("CurrentUser");

                        },
                        param => isSelectedUserToCopyRoles
                        ));
            }

        }

        #endregion

    }
}
