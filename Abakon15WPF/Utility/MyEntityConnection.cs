using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Abakon15WPF.Views.Windows;

namespace Abakon15WPF.Utility
{
    public class MyEntityConnection
    {

        string _serverName;
        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; }
        }

        string _databaseName;
        public string DatabaseName
        {
            get { return _databaseName; }
            set { _databaseName = value; }
        }

        bool _DbAuth;
        public bool DbAuth
        {
            get { return _DbAuth; }
            set { _DbAuth = value; }
        }

        string _User;
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }

        string _PSW;
        public string PSW
        {
            get { return _PSW; }
            set { _PSW = value; }
        }

        bool _ConnectionOK;
        public bool ConnectionOK
        {
            get { return _ConnectionOK; }
            set { _ConnectionOK = value; }
        }

        private static MyEntityConnection _instance;
        public static MyEntityConnection GetMyEntityConnection()
        {
            if (_instance == null)
            {
                _instance = new MyEntityConnection();
                //   _instance.Database.Log = Console.Write; 
            }
            return _instance;
        }

        private MyEntityConnection()
        {
            _instance = this;
            LoadParameters();
            if (_serverName == "Undefined" || _databaseName == "Undefined")
            {
                DataBaseConnectionWindow dbConn = new DataBaseConnectionWindow();
                dbConn.ShowDialog();
            }
            ConnectionOK = AbakonDataModel.ConnectionString.TestConnection();
        }

        public void SaveParameters()
        {

            Properties.Settings.Default._DB_server = _serverName;
            Abakon15WPF.Properties.Settings.Default._DB_Name = _databaseName;
            Abakon15WPF.Properties.Settings.Default._DB_Authetification = !_DbAuth;
            if (_DbAuth)
            {
                Abakon15WPF.Properties.Settings.Default._DB_user = string.Empty;
            }
            else
            {
                Abakon15WPF.Properties.Settings.Default._DB_user = _User;
            }

            if (_PSW == string.Empty || _PSW == null)
            {
                Abakon15WPF.Properties.Settings.Default._DB_psw = string.Empty;
            }
            else
            {
                Abakon15WPF.Properties.Settings.Default._DB_psw = Abakon15WPF.Utility.RijndaelCrypto.EncryptString(_PSW);
            }
            Abakon15WPF.Properties.Settings.Default.Save();
        }

        private void LoadParameters()
        {
            _serverName = Abakon15WPF.Properties.Settings.Default._DB_server;
            _databaseName = Abakon15WPF.Properties.Settings.Default._DB_Name;
            _DbAuth = !Abakon15WPF.Properties.Settings.Default._DB_Authetification;
            _User = Abakon15WPF.Properties.Settings.Default._DB_user;

            if (_serverName == "Undefined" || _databaseName == "Undefined")
            {
                DataBaseConnectionWindow dbConn = new DataBaseConnectionWindow();
                dbConn.ShowDialog();
            }
            else
            {
                if (Abakon15WPF.Properties.Settings.Default._DB_psw == string.Empty)
                {
                    _PSW = string.Empty;
                }
                else
                {
                    _PSW = Abakon15WPF.Utility.RijndaelCrypto.DecryptString(Abakon15WPF.Properties.Settings.Default._DB_psw);
                }
                AbakonDataModel.ConnectionString.CreateConnectionString(_serverName, _databaseName, _DbAuth, _User, _PSW);
            }

        }
      //  public EntityConnection Connection { get; set; }
        public string SQLStringConnection { get; private set; }

    }
}
