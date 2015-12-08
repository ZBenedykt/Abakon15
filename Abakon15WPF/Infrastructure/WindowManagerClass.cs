using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Abakon15WPF.Views;
using Abakon15WPF.ViewModels;
using System.Windows.Controls;

namespace Abakon15WPF.Infrastructure
{
    public delegate System.Windows.Controls.TabItem GetMainWindowTabItem(string name);

    public static class WindowManagerClass
    {

        private static GetMainWindowTabItem getTabItem;
        internal static GetMainWindowTabItem GetTabItem
        {
            get { return WindowManagerClass.getTabItem; }
            set { WindowManagerClass.getTabItem = value; }
        }

        public static Window WindowOpener<T>(WindowContextEnum groupOfWindows = WindowContextEnum.empty, bool singleton = false, bool dialog = false, object dataContext = null, WindowState winState = WindowState.Normal) where T : Window, new()
        {
            if (singleton)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType().Name == typeof(T).Name)
                    {
                        window.Activate();

                        window.WindowState = WindowState.Normal;
                        return window;
                    }
                }
            }

            T wind = new T();
            if (dataContext != null) wind.DataContext = dataContext;
            IRegisteredWindow iwind = wind as IRegisteredWindow;

            if (iwind != null)
            {
                iwind.TabGroup = groupOfWindows;
            }
            wind.Owner = Application.Current.MainWindow;
            if (dialog)
            {
                wind.KeyDown += new System.Windows.Input.KeyEventHandler(wind_KeyDown);
                wind.ShowDialog();
            }
            else
            {
                if (GetTabItem != null && groupOfWindows != WindowContextEnum.empty)
                {
                    wind.Closed += new EventHandler(WindowManagerClass.RegisteredWindow_Closed);
                    wind.Closing += new System.ComponentModel.CancelEventHandler(wind_Closing);

                    TabItem ownerTab = GetTabItem(groupOfWindows.ToString());
                    if (ownerTab != null)
                    {
                        ownerTab.Tag = true;
                    }
                }
                wind.Show();
            }
            wind.Owner.Topmost = false;
            wind.WindowState = winState;
            return wind;
        }

        static void wind_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            WindowBaseClass wind = ((WindowBaseClass)sender);
            var context = wind.DataContext as ViewModelBase;
            //if (context != null && context.UnsavedChanges)
            //{
            //    MessageBox.Show("_UnsavedChangesWillSave".Translate(), "_Caution".Translate(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //    context.SaveCommand.Execute();
            //}
        }

        static void wind_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                ((Window)sender).Close();
            }
        }

        public static void RegisteredWindow_Closed(object sender, EventArgs e)
        {
            var tabGrop = ((WindowBaseClass)sender).TabGroup;
            TabItem ownerTab = getTabItem(tabGrop.ToString());
            if (ownerTab != null)
            {
                if (tabGrop != WindowContextEnum.empty)
                {
                    ownerTab.Tag = CountGroupedWindows(tabGrop.ToString()) > 0;
                }

                //    Window.GetWindow(ownerTab).Topmost = true;
                Window.GetWindow(ownerTab).Activate();
            }
        }

        private static int CountGroupedWindows(String groupName)
        {
            int amount = 0;
            foreach (Window window in Application.Current.Windows)
            {
                WindowBaseClass iwindow = window as WindowBaseClass;

                if (iwindow != null && iwindow.TabGroupName == groupName)
                {
                    amount++;
                }
            }

            return amount;
        }

        public static void CloseMainWindowChildren()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window != Application.Current.MainWindow) window.Close();
            }
        }

        public static void CloseMainWindowChildren<T>() where T : Window
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window != Application.Current.MainWindow && window.GetType().Name == typeof(T).Name) window.Close();
            }

        }

        public static void MinimizeMainWindowChildren()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window != Application.Current.MainWindow) window.WindowState = WindowState.Minimized;
            }
        }

    }
}
