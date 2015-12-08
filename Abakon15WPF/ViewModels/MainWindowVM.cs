using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Abakon15WPF.Views;
using System.Windows;
using Abakon15WPF.Infrastructure;
using Abakon15WPF.Views.Windows;
using AbakonDataModel;

namespace Abakon15WPF.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {

        ObservableCollection<WindowProperties> _openedWindows = new ObservableCollection<WindowProperties>();
        public ObservableCollection<WindowProperties> OpenedWindows
        {
            get { return _openedWindows; }
            set { SetField(ref _openedWindows, value, () => OpenedWindows); }
        }

        public RegisteredUser AktRegisteredUser
        {
            get { return RegisteredUser.CurrentUser; }
        }



        WindowProperties _selectedOpenedWindow;
        public WindowProperties SelectedOpenedWindow
        {
            get { return _selectedOpenedWindow; }
            set { _selectedOpenedWindow = value; }
        }

        public MainWindowVM()
        {

        }

        private Window GetSelectedWindow()
        {
            Window response = null;
            foreach (Window window in Application.Current.Windows)
            {
                response = window as WindowBaseClass;

                if (window.Uid == SelectedOpenedWindow.Uid)
                {
                    response = window;
                    break;
                }
            }
            return response;
        }

        RelayCommand m_CloseWindowCommand = null;
        public RelayCommand CloseWindowCommand
        {
            get
            {
                if (m_CloseWindowCommand == null)
                {
                    m_CloseWindowCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        Window win = GetSelectedWindow();
                                                        if (win != null)
                                                        {
                                                            win.Close();
                                                            OpenedWindows.Remove(SelectedOpenedWindow);
                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_CloseWindowCommand;
            }
        }

        RelayCommand m_MinimizeWindowCommand = null;
        public RelayCommand MinimizeWindowCommand
        {
            get
            {
                if (m_MinimizeWindowCommand == null)
                {
                    m_MinimizeWindowCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        Window win = GetSelectedWindow();
                                                        if (win != null)
                                                        {
                                                            win.WindowState = WindowState.Minimized;
                                                            SelectedOpenedWindow.isMaximized = true;
                                                            SelectedOpenedWindow.isNormal = false;
                                                            RaisePropertyChanged("OpenedWindows");
                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_MinimizeWindowCommand;
            }
        }

        RelayCommand m_NormalWindowCommand = null;
        public RelayCommand NormalWindowCommand
        {
            get
            {
                if (m_NormalWindowCommand == null)
                {
                    m_NormalWindowCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        Window win = GetSelectedWindow();
                                                        if (win != null)
                                                        {
                                                            win.WindowState = WindowState.Normal;
                                                            win.Focus();
                                                            SelectedOpenedWindow.isMaximized = false;
                                                            SelectedOpenedWindow.isNormal = true;
                                                            RaisePropertyChanged("OpenedWindows");
                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_NormalWindowCommand;
            }
        }

        #region =================  Open windows from menu and toolbars region ======================================
        RelayCommand m_ApplicationOptionsCommand = null;
        public RelayCommand ApplicationOptionsCommand
        {
            get
            {
                if (m_ApplicationOptionsCommand == null)
                {
                    m_ApplicationOptionsCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        WindowManagerClass.WindowOpener<AppParametersWindow>(WindowContextEnum.empty, singleton: true);
                                                    },
                                                    param => true
                                                    );
                }
                return m_ApplicationOptionsCommand;
            }
        }

        //VersionInfoCommand

        RelayCommand m_VersionInfoCommand = null;
        public RelayCommand VersionInfoCommand
        {
            get
            {
                if (m_VersionInfoCommand == null)
                {
                    m_VersionInfoCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        //                 WindowManagerClass.WindowOpener<HelpVersionInfoWindow>(groupOfWindows: "", singleton: true, dialog: true);
                                                    },
                                                    param => true
                                                    );
                }
                return m_VersionInfoCommand;
            }
        }

        RelayCommand m_DepartmentDictionaryDefinitionCommand = null;
        public RelayCommand DepartmentDictionaryDefinitionCommand
        {
            get
            {
                if (m_DepartmentDictionaryDefinitionCommand == null)
                {
                    m_DepartmentDictionaryDefinitionCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        WindowManagerClass.WindowOpener<DepartmentWindow>(WindowContextEnum.empty, singleton: true);
                                                        //  WindowManagerClass.WindowOpener<DepartmentSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true);
                                                    },
                                                    param => true
                                                    );
                }
                return m_DepartmentDictionaryDefinitionCommand;
            }
        }

        RelayCommand m_DocumentClassificationPatternDefinitionCommand = null;
        public RelayCommand DocumentClassificationPatternDefinitionCommand
        {
            get
            {
                if (m_DocumentClassificationPatternDefinitionCommand == null)
                {
                    m_DocumentClassificationPatternDefinitionCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        WindowManagerClass.WindowOpener<DocumentClassificationPatterenWindow>(WindowContextEnum.empty, singleton: true);
                                                        //  WindowManagerClass.WindowOpener<DepartmentSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true);
                                                    },
                                                    param => true
                                                    );
                }
                return m_DocumentClassificationPatternDefinitionCommand;
            }
        }

        RelayCommand m_PathsFileCommand = null;
        public RelayCommand PathsFileCommand
        {
            get
            {
                if (m_PathsFileCommand == null)
                {
                    m_PathsFileCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        WindowManagerClass.WindowOpener<FilePathWindow>(WindowContextEnum.empty, singleton: true);
                                                        //  WindowManagerClass.WindowOpener<DepartmentSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true);
                                                    },
                                                    param => true
                                                    );
                }
                return m_PathsFileCommand;
            }
        }

        RelayCommand m_StandardCommand = null;
        public RelayCommand StandardCommand
        {
            get
            {
                if (m_StandardCommand == null)
                {
                    m_StandardCommand = new RelayCommand(
                                                    param =>
                                                    {

                                                        WindowManagerClass.WindowOpener<StandardWindow>(WindowContextEnum.empty, singleton: true);
                                                    },
                                                    param => true
                                                    );
                }
                return m_StandardCommand;
            }
        }


        //UsersCommand
        RelayCommand m_UsersCommand = null;
        public RelayCommand UsersCommand
        {
            get
            {
                if (m_UsersCommand == null)
                {
                    m_UsersCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        WindowManagerClass.WindowOpener<UserWindow>(WindowContextEnum.empty, singleton: true);
                                                        //  WindowManagerClass.WindowOpener<DepartmentSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true);
                                                    },
                                                    param => true
                                                    );
                }
                return m_UsersCommand;
            }
        }


        //KeyboardCommand

        RelayCommand m_KeyBoardCommand = null;
        public RelayCommand KeyBoardCommand
        {
            get
            {
                if (m_KeyBoardCommand == null)
                {
                    m_KeyBoardCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        WindowManagerClass.WindowOpener<KeyBoardContentWindow>(WindowContextEnum.empty, singleton: true);
                                                        //  WindowManagerClass.WindowOpener<DepartmentSelectionWindow>(WindowContextEnum.empty, singleton: true, dialog: true);
                                                    },
                                                    param => true
                                                    );
                }
                return m_KeyBoardCommand;
            }
        }



        RelayCommand m_ChangePasswordCommand = null;
        public RelayCommand ChangePasswordCommand
        {
            get
            {
                if (m_ChangePasswordCommand == null)
                {
                    m_ChangePasswordCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        WindowManagerClass.WindowOpener<ChangePasswordWindow>(WindowContextEnum.empty, singleton: true, dialog: true);
                                                    },
                                                    param => true
                                                    );
                }
                return m_ChangePasswordCommand;
            }
        }

        //ChangeDBCommand
        RelayCommand m_ChangeDBCommand = null;
        public RelayCommand ChangeDBCommand
        {
            get
            {
                if (m_ChangeDBCommand == null)
                {
                    m_ChangeDBCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        DataBaseConnectionWindow dbConn = new DataBaseConnectionWindow();
                                                        if (dbConn.ShowDialog().Value == true)
                                                        {
                                                            Application.Current.Shutdown();
                                                        }
                                                    },
                                                    param => true
                                                    );
                }
                return m_ChangeDBCommand;
            }
        }

        #endregion

    }
}
