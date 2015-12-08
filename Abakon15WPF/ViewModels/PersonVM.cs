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
using AbakonDataModel.Utility;
using System.Windows.Threading;
using System.IO;
using System.Windows.Controls;
using Abakon15WPF.Views.Windows;

namespace Abakon15WPF.ViewModels
{
    class PersonVM : ViewModelBase
    {
        public enum KindOfPersonsEnum
        {
            NieOkreślony,
            Agent,
            Employee
        }

        KindOfPersonsEnum _kindOfView = KindOfPersonsEnum.NieOkreślony;
        public KindOfPersonsEnum KindOfView
        {
            get { return _kindOfView; }
            set { SetField(ref _kindOfView, value, () => KindOfView); }
        }

        Visibility _agentVisibility;
        public Visibility AgentVisibility
        {
            get { return _agentVisibility; }
            set { SetField(ref _agentVisibility, value, () => AgentVisibility); }
        }

        Visibility _employeeVisibility;
        public Visibility EmployeeVisibility
        {
            get { return _employeeVisibility; }
            set { SetField(ref _employeeVisibility, value, () => EmployeeVisibility); }
        }

        Visibility _detailVisibility = Visibility.Hidden;
        public Visibility DetailVisibility
        {
            get { return _detailVisibility; }
            set { SetField(ref _detailVisibility, value, () => DetailVisibility); }
        }



        bool _isEmployee = true;
        public bool isEmployee
        {
            get { return _isEmployee; }
            set
            {
                SetField(ref _isEmployee, value, () => isEmployee);
                RaisePropertyChanged("EmployeeAgent");
                RaisePropertyChanged("CanAddToEmployee");
            }
        }

        bool _canAddToEmployee = true;
        public bool CanAddToEmployee
        {
            get { return !isEmployee && RegisteredUser.CurrentUser.hasPrivilege(PrivilegeListEnum._canUpdatePerson); }
            set
            {
                SetField(ref _isEmployee, value, () => _canAddToEmployee);
            }
        }


        public string EmployeeAgent
        {
            get { return _isEmployee ? "_employees".Translate() : "_agents".Translate(); }
        }

        private string _isSelectedBy = "_isSelectByDepartment";
        public string isSelectedBy
        {
            get { return _isSelectedBy; }
            set { SetField(ref _isSelectedBy, value, () => isSelectedBy); }
        }

        private bool _isSelectByPerson = true;
        public bool isSelectByPerson
        {
            get { return _isSelectByPerson; }
            set
            {
                SetField(ref _isSelectByPerson, value, () => isSelectByPerson);

                if (value)
                {
                    isSelectedBy = "isSelectByPerson";

                }
            }
        }

        private bool _isSelectByDepartment = false;
        public bool isSelectByDepartment
        {
            get { return _isSelectByDepartment; }
            set
            {
                SetField(ref _isSelectByDepartment, value, () => isSelectByDepartment);

                if (value)
                {
                    isSelectedBy = "isSelectByDepartment";

                }
            }
        }

        private bool _isSelectByPost = false;
        public bool isSelectByPost
        {
            get { return _isSelectByPost; }
            set
            {
                SetField(ref _isSelectByPost, value, () => isSelectByPost);

                if (value)
                {
                    isSelectedBy = "isSelectByPost";

                }
            }
        }

        private bool _EnableDeleteEmployee = true;
        public bool EnableDeleteEmployee
        {
            get { return _EnableDeleteEmployee; }
            set { SetField(ref _EnableDeleteEmployee, value, () => EnableDeleteEmployee); }
        }

        private SortableObservableCollection<Employee> _listOfEmploye = new SortableObservableCollection<Employee>();
        public SortableObservableCollection<Employee> ListOfEmploye
        {
            get { return _listOfEmploye; }
            set
            {
                SetField(ref _listOfEmploye, value, () => ListOfEmploye);
                // _listOfEmploye = value;
            }
        }



        private ViewableObservableCollection<Department> _listOfDepartment = new ViewableObservableCollection<Department>();
        public ViewableObservableCollection<Department> ListOfDepartment
        {
            get { return _listOfDepartment; }
            set { _listOfDepartment = value; }
        }

        private Department _CurrentDepartment;
        public Department CurrentDepartment
        {
            get { return _CurrentDepartment; }
            set
            {
                SetField(ref _CurrentDepartment, value, () => CurrentDepartment);
                PersonList = new ViewableObservableCollection<Person>(Person.LoadByDepartment(CurrentDepartment.DepartmentId));
            }
        }

        private FilterPanelVM _myFilteredPanel = new FilterPanelVM();
        public FilterPanelVM MyFilteredPanel
        {
            get { return _myFilteredPanel; }
            set { SetField(ref _myFilteredPanel, value, () => MyFilteredPanel); }
        }

        private ViewableObservableCollection<Person> _personList = new ViewableObservableCollection<Person>();
        public ViewableObservableCollection<Person> PersonList
        {
            get { return _personList; }
            set
            {
                SetField(ref _personList, value, () => PersonList);
            }
        }

        private Person _currentPerson;
        public Person CurrentPerson
        {
            get { return _currentPerson; }
            set
            {
                SetField(ref _currentPerson, value, () => CurrentPerson);
                if (CurrentPerson != null)
                {
                    ListOfEmploye = new SortableObservableCollection<Employee>(CurrentPerson.employees);
                    ListOfEmploye.SortDescending(p => p.EmployedFrom);
                    isEmployee = _listOfEmploye.Count > 0;
                }
            }
        }

        private Employee _currentEmployee;
        public Employee CurrentEmployee
        {
            get { return _currentEmployee; }
            set
            {

                SetField(ref _currentEmployee, value, () => CurrentEmployee);

            }
        }

        public PersonVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {

                ListOfDepartment = new ViewableObservableCollection<Department>(Department.Load());
                this.MyFilteredPanel.FilterChanged += new EventHandler(MyFilteredPanel_FilterChanged);
                this.MyFilteredPanel.isORFieldsFiltered = false;
                FilterField startFieldForFiltering1 = new FilterField { FieldName = "name", DisplayText = "_8_name_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.NotEmpty };
                FilterField startFieldForFiltering2 = new FilterField { FieldName = "sureName", DisplayText = "_8_sureName_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.NotEmpty };

                this.MyFilteredPanel.FieldsCollection.Add(startFieldForFiltering1);
                this.MyFilteredPanel.FieldsFiltered.Add(startFieldForFiltering1);
                this.MyFilteredPanel.FieldsCollection.Add(startFieldForFiltering2);
                this.MyFilteredPanel.FieldsFiltered.Add(startFieldForFiltering2);
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "labWorker", DisplayText = "_8_labWorker_Label".Translate(), TypDanych = FilterTypyDanych.Bool, MetodaKomparacji = OperatoryRelacjiEnum.Equal });

                //         this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "name", DisplayText = "_8_name_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                //         this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "sureName", DisplayText = "_8_sureName_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "title", DisplayText = "_8_title_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "gender", DisplayText = "_8_gender_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "department", DisplayText = "_8_department_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "interests", DisplayText = "_8_interests_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "work_phone", DisplayText = "_8_work_phone_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "mobile_phone", DisplayText = "_8_mobile_phone_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "home_phone", DisplayText = "_8_home_phone_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "pref_contact", DisplayText = "_8_pref_contact_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "fax", DisplayText = "_8_fax_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "business_email", DisplayText = "_8_business_email_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "private_email", DisplayText = "_8_private_email_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "www_address", DisplayText = "_8_www_address_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "spoken_lang", DisplayText = "_8_spoken_lang_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "written_lang", DisplayText = "_8_written_lang_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "CreateDate", DisplayText = "_8_CreateDate_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "LastUpdateDate", DisplayText = "_8_LastUpdateDate_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });
                this.MyFilteredPanel.FieldsCollection.Add(new FilterField { FieldName = "UserName", DisplayText = "_8_UserName_Label".Translate(), TypDanych = FilterTypyDanych.String, MetodaKomparacji = OperatoryRelacjiEnum.Contains });

                PersonList = new ViewableObservableCollection<Person>(Person.Load(p => true));


            }
        }

        System.Linq.Expressions.Expression<Func<Person, bool>> predicate;


        void MyFilteredPanel_FilterChanged(object sender, EventArgs e)
        {
           // predicate = MyFilteredPanel.BuildPredicate<Person>();

            PersonList = new ViewableObservableCollection<Person>(Person.Load(p=> true));
            if (PersonList != null && PersonList.Count > 0)
            {
                CurrentPerson = PersonList.FirstOrDefault();
            }

        }

        private void Reload()
        {
          //  predicate = MyFilteredPanel.BuildPredicate<Person>();
            PersonList = new ViewableObservableCollection<Person>(Person.Load(p => true));
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {
                case "CurrentEmployee":
                    {
                        break;
                    }
                case "CurrentPerson":
                    {
                        DetailVisibility = CurrentPerson == null ? Visibility.Hidden : Visibility.Visible;

                        if (CurrentPerson != null) deleteAskObjectName = CurrentPerson.name;

                        break;
                    }
                case "CurrentDepartment":
                    {
                        Employee.LoadDepartmentEmployee(CurrentDepartment);
                        break;
                    }

                case "isEmployee":
                    {
                        if (!isEmployee)
                        {
                            isSelectByPerson = true;
                        }
                        break;
                    }


                case "KindOfView":
                    {

                        if (KindOfView == KindOfPersonsEnum.Agent)
                        {
                            AgentVisibility = Visibility.Visible;
                            EmployeeVisibility = Visibility.Collapsed;
                            isSelectByPerson = true;

                        }
                        else
                        {
                            AgentVisibility = Visibility.Collapsed;
                            EmployeeVisibility = Visibility.Visible;
                            isSelectByPerson = false;
                        }
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

        RelayCommand _NewPersonCommand;
        public RelayCommand NewPersonCommand
        {
            get
            {

                return _NewPersonCommand ??
                       (_NewPersonCommand = new RelayCommand(
                        param =>
                        {
                            Person newPerson = Person.Create();
                            PersonList.Add(newPerson);
                            CurrentPerson = newPerson;


                        },
                        param => RegisteredUser.CurrentUser.hasPrivilege(PrivilegeListEnum._canAddPerson)
                        ));
            }

        }

        RelayCommand _NewEmployeeCommand;
        public RelayCommand NewEmployeeCommand
        {
            get
            {

                return _NewEmployeeCommand ??
                       (_NewEmployeeCommand = new RelayCommand(
                        param =>
                        {
                            //Employee newEmployee = Employee.Create(CurrentPerson.PersonId);
                            //EmployeeFullInfoVM dataContext = new EmployeeFullInfoVM(newEmployee, true);
                            //EmployeeFullWindow win = WindowManagerClass.WindowOpener<EmployeeFullWindow>("_personsWindow", false, true, dataContext) as EmployeeFullWindow;
                            //if (win.DialogResult == true)
                            //{
                            //    Employee.Save(CurrentPerson.PersonId);
                            //    //   Employee.Save();
                            //}



                        },
                        param => RegisteredUser.CurrentUser.hasPrivilege(PrivilegeListEnum._canUpdatePerson)
                        ));
            }

        }



        RelayCommand _EditEmployeeCommand;
        public RelayCommand EditEmployeeCommand
        {
            get
            {
                return _EditEmployeeCommand ??
                    (_EditEmployeeCommand = new RelayCommand(
                        param =>
                        {
                            //EmployeeFullInfoVM dataContext = new EmployeeFullInfoVM(CurrentEmployee, false);
                            //EmployeeFullWindow win = WindowManagerClass.WindowOpener<EmployeeFullWindow>("_personsWindow", false, true, dataContext) as EmployeeFullWindow;
                            //if (win.DialogResult == true)
                            //{
                            //    if (win.RemoveEmploye)
                            //    {
                            //        Delete();
                            //    }
                            //    Employee.Save();
                            //}



                        },
                        param => CanEditEmployee()
                        ));
            }

        }

        private bool CanEditEmployee()
        {
            return (CurrentEmployee != null && CurrentEmployee.EmployedTo == null);
        }



        // base.deleteAskObjectName = CurrentEmployee.EmployeeDescr;

        RelayCommand m_PhotoCommand;
        public RelayCommand PhotoCommand
        {
            get
            {
                if (m_PhotoCommand == null)
                {
                    m_PhotoCommand = new RelayCommand(
                        param => this.LoadPhoto()

                        );
                }
                return m_PhotoCommand;
            }
        }

        private void LoadPhoto()
        {
            string fileName = string.Empty;
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".odt"; // Rozszerzenie domyślne
            dlg.Filter = " odt |*.odt| png |*.png| wszystkie |*.*"; // Filtr wg rozszerzeń

            // Wyświetl dialog
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                fileName = dlg.FileName;
                FileInfo fInfo = new FileInfo(fileName);
                this.CurrentPerson.ExtPersonAddPhoto(fInfo);
                Reload();
            }
        }


        protected override bool CanDeleteCommand()
        {
            return CurrentPerson != null && !ReadOnly;
        }

        protected override void DeleteFromBase()
        {
            CurrentPerson.Remove();
            PersonList.Remove(CurrentPerson);
        }

        RelayCommand m_LabWorkerCommand = null;
        public RelayCommand LabWorkerCommand
        {
            get
            {
                if (m_LabWorkerCommand == null)
                {
                    m_LabWorkerCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        CurrentPerson.labWorker = !CurrentPerson.labWorker;
                                                        DataGrid dg = param as DataGrid;
                                                        if (dg != null) { dg.Items.Refresh(); }
                                                    },
                                                    param => !ReadOnly && CurrentPerson != null
                                                    );
                }
                return m_LabWorkerCommand;
            }
        }

        //AddAgentCommand AddEmployeeCommand

        RelayCommand m_AddAgentCommand = null;
        public RelayCommand AddAgentCommand
        {
            get
            {
                if (m_AddAgentCommand == null)
                {
                    m_AddAgentCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        PartnerSelectionWindow win = WindowManagerClass.WindowOpener<PartnerSelectionWindow>(WindowContextEnum.persons, true, true) as PartnerSelectionWindow;
                                                        if (win.DialogResult.HasValue && win.partner != null)
                                                        {
                                                            CurrentPerson.partnerList.Add(win.partner);
                                                            DataGrid dg = param as DataGrid;
                                                            if (dg != null) { dg.Items.Refresh(); }
                                                        }
                                                    },
                                                     param => !ReadOnly && CurrentPerson != null
                                                    );
                }
                return m_AddAgentCommand;
            }
        }

        RelayCommand m_AddEmployeeCommand = null;
        public RelayCommand AddEmployeeCommand
        {
            get
            {
                if (m_AddEmployeeCommand == null)
                {
                    m_AddEmployeeCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        DepartmentSelectionWindow win = WindowManagerClass.WindowOpener<DepartmentSelectionWindow>(WindowContextEnum.persons, true, true) as DepartmentSelectionWindow;
                                                        if (win.DialogResult.HasValue && win.department != null)
                                                        {
                                                            Employee newEmployee = Employee.Create(CurrentPerson, win.department);
                                                            DataGrid dg = param as DataGrid;
                                                            if (dg != null) { dg.Items.Refresh(); }
                                                        }
                                                    },
                                                     param => !ReadOnly && CurrentPerson != null
                                                    );
                }
                return m_AddEmployeeCommand;
            }
        }

        RelayCommand m_DeleteEmployeeCommand = null;
        public RelayCommand DeleteEmployeeCommand
        {
            get
            {
                if (m_DeleteEmployeeCommand == null)
                {
                    m_DeleteEmployeeCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        string kom = "_deleteDataAsk".Translate() + ":" + Environment.NewLine + CurrentEmployee.EmployedFrom + " - " + CurrentEmployee.EmployedTo;
                                                        string komHeader = "_confirm".Translate();
                                                        if (MessageBox.Show(kom, komHeader, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                                                        {
                                                            CurrentEmployee.Delete();
                                                        }


                                                    },
                                                     param => !ReadOnly && CurrentEmployee != null
                                                    );
                }
                return m_DeleteEmployeeCommand;
            }
        }

        Partner _selectedPartner;
        public Partner SelectedPartner
        {
            get { return _selectedPartner; }
            set { SetField(ref _selectedPartner, value, () => SelectedPartner); }
        }

        RelayCommand m_DeleteAgentCommand = null;
        public RelayCommand DeleteAgentCommand
        {
            get
            {
                if (m_DeleteAgentCommand == null)
                {
                    m_DeleteAgentCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        // string kom = "_deleteDataAsk".Translate() + ":" + Environment.NewLine + SelectedPartner.PartnerName + " - " + CurrentPerson.SureFirstName;
                                                        string kom = CurrentPerson.SureFirstName + Environment.NewLine + "_deleteAgentAsk".Translate() + Environment.NewLine + SelectedPartner.PartnerName;
                                                        string komHeader = "_confirm".Translate();
                                                        if (MessageBox.Show(kom, komHeader, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                                                        {
                                                            CurrentPerson.partnerList.Remove(SelectedPartner);
                                                        }


                                                    },
                                                     param => !ReadOnly && CurrentPerson != null && SelectedPartner != null
                                                    );
                }
                return m_DeleteAgentCommand;
            }
        }
    }
}
