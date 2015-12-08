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
using Abakon15.ViewModels;
using Abakon15.Infrastructure;
using System.Windows.Media.Animation;


namespace Abakon15.Views.Windows
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        DoubleAnimation pulseAnimation = new DoubleAnimation();


        public ChangePasswordWindow()
        {
            InitializeComponent();
            pulseAnimation.From = 00;
            pulseAnimation.To = 15;
            pulseAnimation.AutoReverse = true;
            pulseAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
            pulseAnimation.RepeatBehavior = RepeatBehavior.Forever;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            RegisteredUser.ChangePassword(_newPassword.Password);
            MessageBox.Show("_passwordChanges".Translate(), "_Caution".Translate(), MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;

        }



        private void RezygnujButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FocusManager.SetFocusedElement(this, _oldPassword);
        }



        private bool ValidatePassword()
        {
            bool result = RegisteredUser.PasswordCorrect(_oldPassword.Password);
            if (!result)
            {
                _etBledneHaslo.Visibility = System.Windows.Visibility.Visible;

                _etBledneHaslo.BeginAnimation(Ellipse.HeightProperty, pulseAnimation);
                _etBledneHaslo.BeginAnimation(Ellipse.WidthProperty, pulseAnimation);
            }
            else
            {
                _etBledneHaslo.BeginAnimation(Ellipse.HeightProperty, null);
                _etBledneHaslo.BeginAnimation(Ellipse.WidthProperty, null);
                _etBledneHaslo.Visibility = System.Windows.Visibility.Collapsed;
            }
            return result;
        }

        private bool ValidateNewPassword()
        {
            return _newPassword.Password == _repeatPassword.Password && _newPassword.Password.Length >= 6;
        }

        private void _oldPassword_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!ValidatePassword())
            {
                e.Handled = true;
                Keyboard.Focus(_oldPassword);
            }
        }



        private void _newPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            _newPasswordError.Content = "";
        }

        private void _newPassword_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (_newPassword.Password.Length < 6)
            {
                _newPasswordError.Content = "_passwordToShort".Translate();

            }
        }

        private void _repeatPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            bool result = ValidateNewPassword();

            if (!result)
            {
                _newPasswordError.Content = "_passwordConformationError".Translate();
            }
            else
            {
                _newPassword_Button.IsEnabled = true;
                FocusManager.SetFocusedElement(this, _newPassword_Button);
                _newPassword_Button.Focus();
            }
        }
    }
}
