using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Abakon15WPF.ViewModels;
using Abakon15WPF.Views;
using Abakon15WPF.Infrastructure;
using Infralution.Localization.Wpf;
using Abakon15WPF.Settings;
using Abakon15WPF.Utility;
using Abakon15WPF.Views.Controls.Standard;
using Abakon15WPF.Views.Controls;
using Abakon15WPF.Views.Windows;
using Abakon15WPF.Interfaces;

namespace Abakon15WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IVirtualKeyboardInjectable
    {

        List<WindowBaseClass> mOpenedWindows = new List<WindowBaseClass>();

        public MainWindow()
        {
            InitializeComponent();
            UstawieniaAplikacji.LoadParameters();
            ConverterCultureBinding(Abakon15WPF.Properties.Settings.Default._Language);
            mWindowDataContext = (MainWindowVM)this.DataContext;
        }

        private void _englishMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ConverterCultureBinding("en-US");
            UstawieniaAplikacji.SaveParameters();
        }

        private void _polishMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ConverterCultureBinding("pl-PL");
            UstawieniaAplikacji.SaveParameters();
        }

        private void ConverterCultureBinding(string lang)
        {
            Abakon15WPF.Settings.UstawieniaAplikacji.myConverterCulture cc = new Abakon15WPF.Settings.UstawieniaAplikacji.myConverterCulture(lang);
            CultureManager.UICulture = cc.ConverterCulture;
            //   ReBindAfterCultureChange();
            Settings.UstawieniaAplikacji.SaveParameters();
        }
        /*
                private void ReBindAfterCultureChange()
                {

                    //   ReBindAfterCultureChange(_dd, TextBlock.TextProperty);
                }


                private void ReBindAfterCultureChange(FrameworkElement frameworkElem, DependencyProperty prop)
                {
                    Binding bind = new Binding();
                    Binding bp = frameworkElem.GetBindingExpression(TextBlock.TextProperty).ParentBinding;

                    bind.AsyncState = bp.AsyncState;
                    bind.BindingGroupName = bp.BindingGroupName;
                    bind.BindsDirectlyToSource = bp.BindsDirectlyToSource;
                    bind.Converter = bp.Converter;
                    bind.ConverterParameter = bp.ConverterParameter;
                    bind.ElementName = bp.ElementName;
                    bind.FallbackValue = bp.FallbackValue;
                    bind.IsAsync = bp.IsAsync;
                    bind.Mode = bp.Mode;
                    bind.NotifyOnSourceUpdated = bp.NotifyOnSourceUpdated;
                    bind.NotifyOnTargetUpdated = bp.NotifyOnTargetUpdated;
                    bind.NotifyOnValidationError = bp.NotifyOnValidationError;
                    bind.Path = bp.Path;
                    bind.StringFormat = bp.StringFormat;
                    bind.TargetNullValue = bp.TargetNullValue;
                    bind.UpdateSourceExceptionFilter = bp.UpdateSourceExceptionFilter;
                    bind.UpdateSourceTrigger = bp.UpdateSourceTrigger;
                    bind.ValidatesOnDataErrors = bp.ValidatesOnDataErrors;
                    bind.ValidatesOnExceptions = bp.ValidatesOnExceptions;
                    bind.XPath = bp.XPath;

                    frameworkElem.SetBinding(prop, bind);

               }
         */
        private void HelpMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Abakon15WPF.Views.Forms.HELPWindow wind = new Views.Forms.HELPWindow();
        }

        private void ZakonczMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Ustawienia widoczności elementów okna w zależności od uprawnień użytkownika
            //  _mProductsButton.Visibility = mProducts.Visibility = RegisteredUser.CurrentUser.hasPrivilege(PrivilegeListEnum._products.ToString()) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }


        internal void UpdateStatusBar()
        {
            this.Title += "   v. " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + "          " + "_logged".Translate() + ": " + ((MainWindowVM)this.DataContext).AktRegisteredUser.UserName;
            //      _user.Text = ((MainWindowVM)this.DataContext).AktRegisteredUser.UserName;
            //      _userName.Text = ((MainWindowVM)this.DataContext).AktRegisteredUser.LoweredUserName; // +" ".PadRight(20) + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "   v. " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            _menuAdministracja.IsEnabled = ((MainWindowVM)this.DataContext).AktRegisteredUser.isAdmin;
            //  string v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        #region ========================= Tabbed region =============================================


        private Dictionary<WindowContextEnum, string> _mdiChildren = new Dictionary<WindowContextEnum, string>();

        private bool CanAdd(ITabbedMDI mdiChild)
        {
            return !_mdiChildren.ContainsKey(mdiChild.TabGroup);
        }

        private TabItem GetTab(String uniqueTabName)
        {
            TabItem requestTab = null;
            for (int i = 0; i < tcMdi.Items.Count; i++)
            {

                if (((TabItem)tcMdi.Items[i]).Name == uniqueTabName)
                {
                    requestTab = (TabItem)tcMdi.Items[i];
                    break;
                }
            }
            return requestTab;
        }

        private int CountTabItem(String uniqueTabName)
        {
            int amount = 0;

            foreach (Window window in Application.Current.Windows)
            {
                WindowBaseClass iwindow = window as WindowBaseClass;

                if (iwindow != null && iwindow.TabGroupName == uniqueTabName)
                {
                    amount++;
                }
            }

            return amount;
        }

        private void AddTab(ITabbedMDI mdiChild)
        {
            if (WindowManagerClass.GetTabItem == null)
            {
                WindowManagerClass.GetTabItem = GetTab;
            }
            WindowManagerClass.MinimizeMainWindowChildren();
            //Check if the user control is already opened
            if (_mdiChildren.ContainsKey(mdiChild.TabGroup))
            {
                //user control is already opened in tab. 
                //So set focus to the tab item where the control hosted
                for (int i = 0; i < tcMdi.Items.Count; i++)
                {
                    if (((TabItem)tcMdi.Items[i]).Name == mdiChild.Title)
                    {
                        var tabItem = tcMdi.Items[i];
                        tcMdi.Items.RemoveAt(i);
                        tcMdi.Items.Insert(0, tabItem);
                        ((TabItem)tabItem).IsSelected = true;

                        return;
                    }
                }

            }
            else
            {
                tcMdi.Visibility = Visibility.Visible;

                TabItem ti = new TabItem();
                ti.Name = ((ITabbedMDI)mdiChild).TabGroup.ToString(); // TODO.Translate();
                ti.Tag = false;
                StackPanel headerStackPanel = new StackPanel();
                headerStackPanel.Orientation = Orientation.Horizontal;
                headerStackPanel.Height = 22;
                TextBlock txtHeader = new TextBlock();
                txtHeader.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                txtHeader.FontSize = 12;
                txtHeader.Margin = new Thickness(10, 0, 15, 0);
                txtHeader.Text = ((ITabbedMDI)mdiChild).Title.Translate();
                Button windowsButton = new Button();
                windowsButton.Content = ImageUtility.ImageFromResource("Okna.png", 24);
                windowsButton.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                windowsButton.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                windowsButton.Width = 16;
                windowsButton.Height = 16;
                windowsButton.Margin = new Thickness(10, 0, 0, 0);
                windowsButton.ToolTip = "_showWindowsTabItem".Translate();
                windowsButton.Style = (Style)Application.Current.Resources["SmallGlassButton"];
                windowsButton.Click += new RoutedEventHandler(windowsButton_Click);

                windowsButton.SetBinding(Button.VisibilityProperty,
                         new Binding("Tag")
                         {
                             RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(TabItem), 1),
                             Converter = new Abakon15WPF.Infrastructure.BooleanToVisibilityConverter()
                         });

                Button closeButton = new Button();
                closeButton.Content = ImageUtility.ImageFromResource("Zamknij1.png", 24); // "X";
                closeButton.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                closeButton.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                closeButton.Width = 16;
                closeButton.Height = 16;
                closeButton.Margin = new Thickness(10, 0, 0, 0);
                closeButton.ToolTip = "_closeTabItem".Translate();
                closeButton.Style = (Style)Application.Current.Resources["SmallGlassButton"];

                closeButton.Click += new RoutedEventHandler(closeButton_Click);

                closeButton.SetBinding(Button.VisibilityProperty,
                                         new Binding("IsSelected")
                                         {
                                             RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(TabItem), 1),
                                             Converter = new Abakon15WPF.Infrastructure.BooleanToVisibilityConverter()
                                         });


                headerStackPanel.Children.Add(txtHeader);
                headerStackPanel.Children.Add(windowsButton);
                headerStackPanel.Children.Add(closeButton);
                ti.Header = headerStackPanel;

                ti.Content = mdiChild;
                ti.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                ti.VerticalContentAlignment = VerticalAlignment.Stretch;

                tcMdi.Items.Insert(0, ti);
                ti.IsSelected = true;
                _mdiChildren.Add(((ITabbedMDI)mdiChild).TabGroup, ((ITabbedMDI)mdiChild).Title);

            }
        }

        void windowsButton_Click(object sender, RoutedEventArgs e)
        {
            TabItem tab = ((Button)sender).FindParent<TabItem>();
            GetWindowsFromTab(tab, out mOpenedWindows);
            if (mWindowDataContext.OpenedWindows.Count > 0)
            {
                _popUpHeaderText.Text = "_openedWIndows".Translate();
            }
            else
            {
                _popUpHeaderText.Text = "_noOpenedWIndows".Translate();
            }
            _PopUp.IsOpen = true;
        }

        private void GetWindowsFromTab(TabItem tab, out List<WindowBaseClass> listOfWindows)
        {
            listOfWindows = new List<WindowBaseClass>();
            mWindowDataContext.OpenedWindows.Clear();
            foreach (Window window in Application.Current.Windows)
            {
                WindowBaseClass iwindow = window as WindowBaseClass;

                if (iwindow != null && tab.Name == iwindow.TabGroup.ToString())
                {
                    listOfWindows.Add(iwindow);
                    WindowProperties prop = new WindowProperties();
                    prop.isMaximized = iwindow.WindowState == System.Windows.WindowState.Maximized;
                    prop.isMinimized = iwindow.WindowState == System.Windows.WindowState.Minimized;
                    prop.isNormal = iwindow.WindowState == System.Windows.WindowState.Normal;
                    prop.RegisteredDetatilHeader = iwindow.RegisteredDetatilHeader;
                    prop.TabGroupName = iwindow.TabGroupName;
                    prop.title = iwindow.Title;
                    prop.Uid = iwindow.Uid;

                    mWindowDataContext.OpenedWindows.Add(prop);
                }
            }
        }


        void closeButton_Click(object sender, RoutedEventArgs e)
        {
            TabItem tab = ((Button)sender).FindParent<TabItem>();
            if (tab != null)
            {
                GetWindowsFromTab(tab, out mOpenedWindows);
                foreach (Window wind in mOpenedWindows)
                {
                    wind.Close();
                }
                //   WindowContextEnum tabKey;
                Enum tabKey;
                if (EnumHelper.TryParseDisplayText(typeof(WindowContextEnum), tab.Name, out tabKey))
                {
                    _mdiChildren.Remove((WindowContextEnum)tabKey);
                    tcMdi.Items.Remove(tab);
                }
            }
        }

        private void CloseTab(ITabbedMDI tab, EventArgs e)
        {
            ClosableTab ti = null;
            foreach (ClosableTab item in tcMdi.Items)
            {
                if (tab.TabGroup == ((ITabbedMDI)item.Content).TabGroup)
                {
                    ti = item;
                    break;
                }
            }
            if (ti != null)
            {
                _mdiChildren.Remove(((ITabbedMDI)ti.Content).TabGroup);
                tcMdi.Items.Remove(ti);
            }
        }

        private void TabItem_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var tabItem = e.Source as TabItem;

            if (tabItem == null)
                return;

            if (Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(tabItem, tabItem, DragDropEffects.All);
            }
        }


        private void TabItem_Drop(object sender, DragEventArgs e)
        {
            var tabItemTarget = e.Source as TabItem;

            var tabItemSource = e.Data.GetData(typeof(TabItem)) as TabItem;

            if (tabItemTarget != null && !tabItemTarget.Equals(tabItemSource))
            {
                var tabControl = tabItemTarget.Parent as TabControl;
                int sourceIndex = tabControl.Items.IndexOf(tabItemSource);
                int targetIndex = tabControl.Items.IndexOf(tabItemTarget);

                tabControl.Items.Remove(tabItemSource);
                tabControl.Items.Insert(targetIndex, tabItemSource);

                tabControl.Items.Remove(tabItemTarget);
                tabControl.Items.Insert(sourceIndex, tabItemTarget);
            }
        }


        #endregion


        private void _closeWindow_Click(object sender, RoutedEventArgs e)
        {
            mWindowDataContext.CloseWindowCommand.Execute(null);
        }

        private void _minimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            mWindowDataContext.MinimizeWindowCommand.Execute(null);
        }

        private void _normalWindow_Click(object sender, RoutedEventArgs e)
        {
            mWindowDataContext.NormalWindowCommand.Execute(null);
        }


        #region =============================== open tab / windows =====================================================
        // -------------------- Task -----------------------------------------------------------------------------

        private void mTasks_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenTab<TaskUC>(sender, e);
        }

        private void mTasksPlus_Button_Click(object sender, RoutedEventArgs e)
        {
            openWindow_Click<TaskUC, TaskWindow>(sender, e);
        }

        // -------------------- Partner -----------------------------------------------------------------------------

        private void mPartner_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenTab<PartnerUC>(sender, e);
        }

        private void mPartnerPlus_Button_Click(object sender, RoutedEventArgs e)
        {
            openWindow_Click<PartnerUC, PartnerWindow>(sender, e);
        }

        // -------------------- Person -----------------------------------------------------------------------------
        private void mPerson_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenTab<PersonUC>(sender, e);
        }

        private void mPersonPlus_Button_Click(object sender, RoutedEventArgs e)
        {
            openWindow_Click<PersonUC, PersonWindow>(sender, e);
        }

        // --------------------  Documents -----------------------------------------------------------------------------
        private void mDocument_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenTab<DocumentUC>(sender, e);
        }

        private void mDocumentPlus_Button_Click(object sender, RoutedEventArgs e)
        {
            openWindow_Click<DocumentUC, DocumentWindow>(sender, e);
        }



        //===========================================================================

        public UC OpenTab<UC>(object sender, RoutedEventArgs e, WindowContextEnum tabId = WindowContextEnum.empty) where UC : UserControl, ITabbedMDI, new()
        {
            UC mdiChild = new UC();
            if (tabId != WindowContextEnum.empty)
            { mdiChild.TabGroup = tabId; }

            mdiChild.SaveSpliterPositon = true;
            AddTab(mdiChild);
            e.Handled = true;
            return mdiChild;
        }

        private Window openWindow_Click<UC, W>(object sender, RoutedEventArgs e, WindowContextEnum tabId = WindowContextEnum.empty)
            where UC : UserControl, ITabbedMDI, new()
            where W : Window, new()
        {
            UC win = new UC();
            if (tabId != WindowContextEnum.empty)
            { win.TabGroup = tabId; }
            win.SaveSpliterPositon = false;
            if (!CanAdd(win))
            {
                var newWIn = WindowManagerClass.WindowOpener<W>(groupOfWindows: win.TabGroup);
                newWIn.Title = win.Title;
                e.Handled = true;
                return newWIn;
            }
            return null;
        }


        #endregion

        private void Window_Activated(object sender, EventArgs e)
        {
            //    this.Topmost = true;
            _menuAdministracja.Visibility = RegisteredUser.CurrentUser.isAdmin ? Visibility.Visible : Visibility.Collapsed;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.UstawieniaAplikacji.SaveParameters();
            if (!WindowClosingFlag.closingFlag)
            {
                string kom = "_closeApplicationAsk".Translate();
                string komHeader = "_confirm".Translate();
                if (MessageBox.Show(kom, komHeader, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void excelRename_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mKeyboard_Button_Click(object sender, RoutedEventArgs e)
        {
            WindowManagerClass.WindowOpener<KeyBoardWindow>(WindowContextEnum.empty, singleton: true, dialog: false);
        }




        #region IVirtualKeyboardInjectable Members
        KeyBoardWindow _virtualKeyboard;
        public Control _txtLastToHaveFocus;

        public Control ControlToInjectInto
        {
            get { return _txtLastToHaveFocus; }
        }

        public KeyBoardWindow TheVirtualKeyboard
        {
            get { return _virtualKeyboard; }
            set { _virtualKeyboard = value; }
        }

        #endregion

        bool _closingFlag = WindowClosingFlag.closingFlag = false;


        private void _closeApp_Click(object sender, RoutedEventArgs e)
        {
            _closingFlag = true;
            Application.Current.Shutdown();
        }
    }
}
