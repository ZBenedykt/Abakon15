using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Data.SqlClient;
using Abakon15WPF.Utility;
using AbakonDataModel;

namespace Abakon15WPF.ViewModels
{
    public class DataBaseConnectionViewModel : ViewModelBase
    {

        MyEntityConnection _ec;
        bool _serweryZaladowane = false;

        List<string> _serwery = new List<string>();

        public List<string> Serwery
        {
            get { return _serwery; }
            private set
            {
                _serwery = value;
                RaisePropertyChanged("Serwery");
            }
        }


        String _wybranySerwer;
        public String WybranySerwer
        {
            get
            {
                return _wybranySerwer;
            }
            set
            {
                _wybranySerwer = value;
                if (value != null && value != "Undefined")
                {

                    RaisePropertyChanged("WybranySerwer");
                }
            }
        }


        List<string> _bazy = new List<string>();
        public List<string> Bazy
        {
            get { return _bazy; }
            private set
            {
                _bazy = value;
                RaisePropertyChanged("Bazy");
            }
        }


        private String _wybranaBaza;
        public String WybranaBaza
        {
            get
            {
                return _wybranaBaza;
            }
            set
            {
                _wybranaBaza = value;
                RaisePropertyChanged("WybranaBaza");
            }
        }

        bool _dbAut;
        public bool DbAut
        {
            get { return _dbAut; }
            set
            {
                _dbAut = value;
                RaisePropertyChanged("DbAut");
            }
        }

        string _user;

        public string User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged("User");
            }
        }


        string _pSW;
        public string PSW
        {
            get { return _pSW; }
            set
            {
                _pSW = value;
                RaisePropertyChanged("PSW");
            }
        }

        #region Konstruktor

        public DataBaseConnectionViewModel()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                _ec = MyEntityConnection.GetMyEntityConnection();

                WybranySerwer = _ec.ServerName;
                WybranaBaza = _ec.DatabaseName;
                DbAut = _ec.DbAuth;
                User = _ec.User;
                PSW = _ec.PSW;
                if (WybranySerwer == "" || WybranySerwer == "Undefined")
                {
                    SzukajSerwery();
                }
            }
        }

        #endregion

        public void SzukajSerwery()
        {
            if (!_serweryZaladowane)
            {
                try
                {
                    System.ServiceProcess.ServiceController myService = new System.ServiceProcess.ServiceController();
                    myService.ServiceName = "SQLBrowser";
                    System.Data.DataTable dt = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
                    foreach (System.Data.DataRow dr in dt.Rows)
                    {
                        Serwery.Add(string.Concat(dr["ServerName"], "\\", dr["InstanceName"]));
                    }

                    WybranySerwer = Serwery.FirstOrDefault();
                    if (WybranySerwer == null || WybranySerwer == "") { WybranySerwer = @"LocalHost\SQLEXPRESS"; }

                    _serweryZaladowane = true;

                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }

        }

        public void WyliczBazy(string WybranySerwer)
        {

            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.UserID = "";
                builder.IntegratedSecurity = true;
                builder.Password = "";
                builder.DataSource = WybranySerwer;
                builder.InitialCatalog = "master";
                SqlDataAdapter adp = new SqlDataAdapter("select name from master.dbo.sysdatabases", new System.Data.SqlClient.SqlConnection(builder.ConnectionString));
                System.Data.DataTable dbs = new System.Data.DataTable("Bazy");
                adp.Fill(dbs);
                System.Data.DataRow[] b = dbs.Select("true", "name");

                List<string> lb = new List<string>();
                foreach (System.Data.DataRow item in b)
                {
                    lb.Add(item["name"].ToString());
                }

                Bazy = lb;
            }

            catch (Exception e)
            {
                MessageBox.Show("Server: " + WybranySerwer + System.Environment.NewLine + System.Environment.NewLine + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool saveSettings()
        {
            bool result = false;
            _ec.ServerName = WybranySerwer;
            _ec.DatabaseName = WybranaBaza;
            _ec.User = User;
            _ec.DbAuth = DbAut;
            _ec.PSW = PSW;

            if (TestConnection(_ec.ServerName, _ec.DatabaseName, _ec.DbAuth, _ec.User, _ec.PSW))
            {
                result = true;
                _ec.SaveParameters();
            }
            return result;
        }


        string CreateConnectionString(string server, string DbName = "OmetrisisDB", bool dbAuthent = false, string user = "", string password = "")
        {
            string instance = "";
            if (dbAuthent)
            {
                instance = string.Format(@"Server={0}; Trusted_Connection=true; Database={1}", server, DbName);
            }
            else
            {
                instance = string.Format(@"Server={0}; User ID={1}; Password={3}; Database={2}", server, user, DbName, password);
            }
            return instance;

        }

        bool TestConnection(string server, string DbName = "OmetrisisDB", bool authent = false, string user = "", string password = "")
        {
            bool result = false;
            AbakonDataModel.ConnectionString.CreateConnectionString(server, DbName, authent, user, password);

            if (!Bazy.Contains(DbName))
            {
                if (MessageBox.Show("Czy utworzyć nową bazę?", "brak bazy", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    _Application app = _Application.ThisApplication();
                    _Application.CanConnectToDB();
                }
                else
                {
                    return result;

                }
            }


            using (SqlConnection con = new SqlConnection(AbakonDataModel.ConnectionString.GetConnectionString()))
            {
                try
                {
                    con.Open();
                }
                catch (Exception)
                {
                    return result;
                }

                using (SqlCommand command = new SqlCommand("SELECT Count(*) FROM [_Application] Where ApplicationName = 'Ometrisis'", con))
                {
                    try
                    {
                        result = (int)command.ExecuteScalar() == 1;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return result;
        }

    }
}
