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
using System.Windows.Shapes;
using Abakon15.Infrastructure;
using Abakon15.ViewModels;

namespace Abakon15.Views.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        LoginVM mDataContext = new LoginVM();
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = mDataContext;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (RegisteredUser.CurrentUser == null)
            {
                mDataContext.LogIn(_userName.Text);
            }

            mDataContext.isPasswordCorrect = RegisteredUser.PasswordCorrect(_password.Password);
            if (mDataContext.isPasswordCorrect)
            {
                this.DialogResult = true;
            }

        }

        private void RezygnujButton_Click(object sender, RoutedEventArgs e)
        {
            WindowClosingFlag.closingFlag = true;
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _userName.Focusable = true;
            _userName.Focus();
        }


        private void _userName_GotFocus(object sender, RoutedEventArgs e)
        {
            mDataContext.ErrorUserName = "";
        }

        private void _password_GotFocus(object sender, RoutedEventArgs e)
        {
            mDataContext.ErrorPassword = "";

        }

        private void _password_LostFocus(object sender, RoutedEventArgs e)
        {
            mDataContext.isPasswordCorrect = RegisteredUser.PasswordCorrect(_password.Password);
        }


        private void _userName_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (!mDataContext.DBconnected())
            //{
            //    MessageBox.Show("Wprowadź poprawną nazwę serwera i użytkownika !");
            //}
            string str = _userName.Text.Trim();
            mDataContext.InputUserName = str;
        }

        private void _repeatPassword_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            bool result = _newPassword.Password == _repeatPassword.Password && _newPassword.Password.Length >= 6;

            if (!result)
            {
                _newPasswordError.Text = "_passwordConformationError".Translate();
            }
            else
            {
                _newPassword_Button.IsEnabled = true;
                _newPassword_Button.Focus();
            }
        }

        private void _newPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_newPassword.Password.Length < 6)
            {
                _newPasswordError.Text = "_passwordToShort".Translate();
            }
        }

        private void _newPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            _newPasswordError.Text = "";
        }


        private void _repeatPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            bool result = _newPassword.Password == _repeatPassword.Password && _newPassword.Password.Length >= 6; ;

            if (!result)
            {
                _newPasswordError.Text = "_passwordConformationError".Translate();
            }
            else
            {
                _newPassword_Button.IsEnabled = true;
                _newPassword_Button.Focus();
            }
        }

        private void _newPassword_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (_newPassword.Password.Length < 6)
            {
                _newPasswordError.Text = "_passwordToShort".Translate();

            }
        }

        private void Grid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((Grid)sender).IsVisible)
            {
                FocusManager.SetFocusedElement(this, _newPassword);
            }
        }

        private void _newPassword_Button_Click(object sender, RoutedEventArgs e)
        {
            RegisteredUser.ChangePassword(mDataContext.CurrentDbUser, _newPassword.Password, false);
            this.DialogResult = true;
        }

        private void _mainDockPanel_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((DockPanel)sender).IsVisible)
            {
                FocusManager.SetFocusedElement((DockPanel)sender, _userName);
            }
        }

        private void _password_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                mDataContext.isPasswordCorrect = RegisteredUser.PasswordCorrect(_password.Password);
            }
        }

        private void _repeatPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            bool result = _newPassword.Password == _repeatPassword.Password && _newPassword.Password.Length >= 6; ;

            if (!result)
            {
                _newPasswordError.Text = "_passwordConformationError".Translate();
            }
            else
            {
                _newPassword_Button.IsEnabled = true;
                _newPassword_Button.Focus();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DataBaseConnectionWindow dbConn = new DataBaseConnectionWindow();
                dbConn.ShowDialog();
            }
            catch (Exception)
            {
            }

        }

        private void _DBpassword_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            mDataContext.DbPassword = _DBpassword.Password;
        }

    }
}
