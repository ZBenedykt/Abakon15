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

namespace Abakon15.Views.Windows
{
    /// <summary>
    /// Interaction logic for DataBaseConnectionWindow.xaml
    /// </summary>
    public partial class DataBaseConnectionWindow : Window
    {



        public DataBaseConnectionWindow()
        {
            InitializeComponent();

        }

        bool closingFlag = true;
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {

            _etBlednePlaczenie.Visibility = System.Windows.Visibility.Hidden;
            if (!_dataBaseConnectionViewModel.saveSettings())
            {
                _etBlednePlaczenie.Visibility = System.Windows.Visibility.Visible;
                _etInfo.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                WindowClosingFlag.closingFlag = true;
                Application.Current.Shutdown();
                // this.DialogResult = true;
            }
        }

        private void RezygnujButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            WindowClosingFlag.closingFlag = true;

            try
            {
                Application.Current.Windows[1].Close();
            }
            catch (Exception)
            {
            }
            Application.Current.Shutdown();

        }

        private void _serweryComboBox_DropDownOpened(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Wait;
            _dataBaseConnectionViewModel.SzukajSerwery();
            this.Cursor = Cursors.Arrow;

        }

        private void _PSWTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _dataBaseConnectionViewModel.PSW = _PSWTextBox.Password;
        }

        private void _serweryComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            RefreshBases();
        }

        private void _docelowaBazaComboBox_DropDownOpened(object sender, EventArgs e)
        {
            RefreshBases();
        }

        private void _serweryComboBox_DropDownClosed(object sender, EventArgs e)
        {
            RefreshBases();
        }

        private void RefreshBases()
        {
            this.Cursor = Cursors.Wait;
            _dataBaseConnectionViewModel.WyliczBazy(_dataBaseConnectionViewModel.WybranySerwer);
            this.Cursor = Cursors.Arrow;
        }
    }
}
