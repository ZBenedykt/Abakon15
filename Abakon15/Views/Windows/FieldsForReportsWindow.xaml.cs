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
using Abakon15.Interfaces;
using Abakon15.ViewModels;
using AbakonDataModel;

namespace Abakon15.Views.Windows
{
    /// <summary>
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class FieldsForReportsWindow : Abakon15.Views.WindowBaseClass
    {
        public FieldsForReportsWindow()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
