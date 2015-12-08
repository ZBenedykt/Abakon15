using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Abakon15WPF.Properties;
using System.Windows.Markup;
using System.Globalization;
using Abakon15WPF.Views.Windows;
using System.Data.Common;
using AbakonDataModel;
using System.Windows.Controls;


namespace Abakon15WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
     //   public Devart.Data.PostgreSql.PgSqlMonitor myMonitor = new Devart.Data.PostgreSql.PgSqlMonitor();

        static App()
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }
        public MainWindow main;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Niezbędne dla EntityFramework do pracy z własnym obiektem konfiguracyjnym 
            //=========================================================================
          //  DbConfiguration.SetConfiguration(new MyConfiguration());
            Settings.UstawieniaAplikacji.LoadParameters();
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<PgSqlDBContext, PostgreConfiguration<PgSqlDBContext>>());
            //=========================================================================
       //     myMonitor.IsActive = true;
            main = new MainWindow();
            LoginWindow login = new LoginWindow();
            login.ShowDialog();
            
            if ((!login.DialogResult.HasValue || !login.DialogResult.Value) && Application.Current != null) //!login.DialogResult.Value &&
            {
                Application.Current.Shutdown();
            }
            else
            {
                // main.UpdateStatusBar();
                try
                {
                    this.MainWindow = main;
                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                    main.Show();
                }
                catch (Exception)
                {
                }
            }

        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show(ex.Message + System.Environment.NewLine + ex.InnerException.Message + System.Environment.NewLine +
                                "...", "", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        protected override void OnStartup(StartupEventArgs e)
        {

            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.GotFocusEvent, new RoutedEventHandler(TextBox_GotFocus));
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.LostFocusEvent, new RoutedEventHandler(TextBox_LostFocus));
            base.OnStartup(e);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((MainWindow)this.MainWindow)._txtLastToHaveFocus = sender as TextBox;
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ((MainWindow)this.MainWindow)._txtLastToHaveFocus = null;
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                Settings.UstawieniaAplikacji.SaveParameters();
                _Application.ThisApplication().Sessions = Abakon15WPF.Utility.XMLUtility.LoggedUsersRemove(_Application.ThisApplication().Sessions);
                _Application.ThisApplication().SaveData();
            }
            catch (Exception)
            {
            }
        }



    }
}
