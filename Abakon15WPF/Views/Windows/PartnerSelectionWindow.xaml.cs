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
using Abakon15WPF.Interfaces;
using Abakon15WPF.ViewModels;
using AbakonDataModel;

namespace Abakon15WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class PartnerSelectionWindow : Abakon15WPF.Views.WindowBaseClass
    {
        public PartnerSelectionWindow()
        {
            InitializeComponent();
        }


        public Partner partner { get; set; }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            partner = ((PartnerVM)DataContext).CurrentPartner;
            this.DialogResult = true;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void acceptNullButton_Click(object sender, RoutedEventArgs e)
        {
            partner = null;
            this.DialogResult = true;
        }
    }
}
