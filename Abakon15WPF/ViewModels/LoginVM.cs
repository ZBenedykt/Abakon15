using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abakon15WPF.Infrastructure;
using System.ComponentModel;
using System.Windows;
using System.Threading.Tasks;
using AbakonDataModel;
using Abakon15WPF.Utility;
using Abakon15WPF.Views.Windows;
using System.Threading;

namespace Abakon15WPF.ViewModels
{
    class LoginVM : ViewModelBase
    {
      //  MyEntityConnection _ec = MyEntityConnection.GetMyEntityConnection();

        private RegisteredUser _currentUser;
        public RegisteredUser CurrentUser
        {
            get { return _currentUser; }
            set
            {
                SetField(ref _currentUser, value, () => CurrentUser);
            }
        }

        private _User _currentDbUser;
        public _User CurrentDbUser
        {
            get { return _currentDbUser; }
            set { SetField(ref _currentDbUser, value, () => CurrentDbUser); }
        }

        private string _inputUserName = string.Empty;
        public string InputUserName
        {
            get { return _inputUserName; }
            set { SetField(ref _inputUserName, value, () => InputUserName); }
        }


        public bool _isUserNameCorrect;
        public bool isUserNameCorrect
        {
            get { return _isUserNameCorrect; }
            set { SetField(ref _isUserNameCorrect, value, () => isUserNameCorrect); }
        }

        private bool _isPasswordCorrect = false;
        public bool isPasswordCorrect
        {
            get { return _isPasswordCorrect; }
            set
            {
                _isPasswordCorrect = value;
                RaisePropertyChanged("isPasswordCorrect");
            }
        }

        private bool _isNeedChangePassword;
        public bool isNeedChangePassword
        {
            get { return _isNeedChangePassword; }
            set { SetField(ref _isNeedChangePassword, value, () => isNeedChangePassword); }
        }

        private bool _isTaskFinished;
        public bool isTaskFinished
        {
            get { return _isTaskFinished; }
            set { SetField(ref _isTaskFinished, value, () => isTaskFinished); }
        }

        private string _errorUserName = string.Empty; //_incorrectUserNameMessage
        public string ErrorUserName
        {
            get { return _errorUserName; }
            set { SetField(ref _errorUserName, value, () => ErrorUserName); }
        }

        private string _errorPassword = string.Empty; //_incorrectPasswordMessage
        public string ErrorPassword
        {
            get { return _errorPassword; }
            set { SetField(ref _errorPassword, value, () => ErrorPassword); }
        }

        private bool _StartImage = false;
        public bool StartImage
        {
            get { return _StartImage; }
            set { SetField(ref _StartImage, value, () => StartImage); }
        }


        private string _DbServer = Abakon15WPF.Properties.Settings.Default._DB_server;
        public string DbServer
        {
            get { return _DbServer; }
            set { SetField(ref _DbServer, value, () => DbServer); }
        }

        private string _DbUser = Abakon15WPF.Properties.Settings.Default._DB_user;
        public string DbUser
        {
            get { return _DbUser; }
            set { SetField(ref _DbUser, value, () => DbUser); }
        }

        private string _DbPassword = Abakon15WPF.Properties.Settings.Default._DB_psw;
        public string DbPassword
        {
            get { return _DbPassword; }
            set { SetField(ref _DbPassword, value, () => DbPassword); }
        }

        private string _DbName = Abakon15WPF.Properties.Settings.Default._DB_Name;
        public string DbName
        {
            get { return _DbName; }
            set { SetField(ref _DbName, value, () => DbName); }
        }

        internal LoginVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
        //        MyEntityConnection.GetMyEntityConnection();
                //try
                //{
                //    Task.Factory.StartNew(() =>
                //                                {
                //                                    ConnectionString.TestConnection();
                //                                    StartImage = false;                                                   
                //                                }
                //                         );   
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}              
            }
        }

#if GE
        private Visibility logoVisible =  Visibility.Visible;
        public Visibility LogoVisible
        {
            get { return logoVisible; }
            set {  }
        }
#else
        private Visibility logoVisible = Visibility.Hidden;
        public Visibility LogoVisible
        {
            get { return logoVisible; }
            set { }
        }
#endif

        internal bool LogIn(string userName)
        {
            bool response = false;

            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                try
                {
                    CurrentUser = GetUser(userName);
                    if (CurrentUser != null)
                    {
                        ErrorUserName = "";
                        response = true;
                    }
                    else
                    {
                        ErrorUserName = "_incorrectUserNameMessage".Translate();
                    }
                }
                catch (Exception ex)
                {
                    ErrorUserName = ex.Message;
                }

            }
            isUserNameCorrect = response;
            return response;
        }

        private static void RegisterConnectionString()
        {
            //DataBaseConnectionWindow dbConn = new DataBaseConnectionWindow();
            //if (dbConn.ShowDialog().Value == true)
            //{
            //    Application.Current.Shutdown();
            //}
        }



        private RegisteredUser GetUser(string userName)
        {

            StateOfExecution result = new StateOfExecution();
            CurrentDbUser = _User.GetUser(userName);
            if (CurrentDbUser != null)
            {
                result = RegisteredUser.CreateRegisteredUser(_Application.ThisApplication(), CurrentDbUser);
                if (!result.OperationOK)
                {
                    throw result.Exception;
                }
            }

            if (result.OperationOK)
            {
                SaveToDB();
                return RegisteredUser.CurrentUser;
            }
            else
            {
                return null;
            }


        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {
                case "DbServer":
                case "DbUser":
                    {
                        break;
                    }
                case "DbPassword":
                    {
                        if (DbPassword != "" && DbPassword != null)
                        {
                            Abakon15WPF.Properties.Settings.Default._DB_psw = Abakon15WPF.Utility.RijndaelCrypto.EncryptString(DbPassword);
                        }
                        else
                        {
                            Abakon15WPF.Properties.Settings.Default._DB_psw = "";
                        }
                        Settings.UstawieniaAplikacji.SaveParameters();
                        break;
                    }

                case "InputUserName":
                    {
                        if (!StartImage)
                        {
                            isUserNameCorrect = LogIn(InputUserName);
                            LoginOKCommand.CanExecute(null);
                        }
                        break;
                    }
                case "isPasswordCorrect":
                    {
                        ErrorPassword = !isUserNameCorrect ? "" : isPasswordCorrect ? "" : "_incorrectPasswordMessage".Translate();
                        if (CurrentUser != null)
                        {
                            isNeedChangePassword = isPasswordCorrect && CurrentUser.IsNeedChangePassword; // && CurrentUser.aspnet_Membership.IsLockedOut;
                        }
                        break;
                    }
                case "StartImage":
                    {
                        if (!StartImage && InputUserName.Length > 0)
                        {
                            LogIn(InputUserName);
                            LoginOKCommand.CanExecute(null);
                        }
                        break;
                    }

                default:
                    break;
            }

        }


        RelayCommand m_LoginOKCommand = null;
        public RelayCommand LoginOKCommand
        {
            get
            {
                if (m_LoginOKCommand == null)
                {
                    m_LoginOKCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                    },
                                                    param => true
                                                    );
                }
                return m_LoginOKCommand;
            }
        }



        internal bool DBconnected()
        {
            bool result = true;
            // if (_DbServer == "" || _DbUser == "") return false;

            //if (_ec.ServerName == "Undefined")
            //{
            //    DataBaseConnectionWindow dbConn = new DataBaseConnectionWindow();
            //    if (dbConn.ShowDialog().Value == true)
            //    {
            //        Application.Current.Shutdown();
            //    }
            //}
            //else
            //{
            //    ConnectionString.CreateConnectionString(_ec.ServerName, _ec.DatabaseName, _ec.DbAuth, _ec.User, _ec.PSW);
            //    result = _Application.CanConnectToDB();
            //}

            return result;
        }
    }
}
