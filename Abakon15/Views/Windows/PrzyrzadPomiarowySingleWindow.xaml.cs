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
using Abakon15.Interfaces;


namespace Abakon15.Views.Windows
{
    /// <summary>
    /// Interaction logic for PrzyrzadPomiarowySingleWindow.xaml
    /// </summary>
    public partial class PrzyrzadPomiarowySingleWindow : WindowBaseClass
    {
        public PrzyrzadPomiarowySingleWindow()
        {
            InitializeComponent();
        }

        #region IRegisteredWindow Members

        private string mTabGroupName;
        public override string TabGroupName
        {
            get { return mTabGroupName; }
            set { mTabGroupName = value; }
        }

        string mRegisteredDetatilHeader = "";
        public override string RegisteredDetatilHeader
        {
            get { return mRegisteredDetatilHeader; }
        }

        #endregion



        private void PrzyrzadPomiarowySingleUC_Loaded(object sender, RoutedEventArgs e)
        {
            string zz = ((IPrzyrzadPomiarowy)this.DataContext).CurrentPrzyrzadPomiarowy.PrzyrzadPomiarowyNrKod + " - " + ((IPrzyrzadPomiarowy)this.DataContext).CurrentPrzyrzadPomiarowy.Nazwa;
            mRegisteredDetatilHeader = zz;
            cScrollViewer.ScrollToEnd();
        }


    }
}
