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
using Abakon15.ViewModels;
using AbakonDataModel;

namespace Abakon15.Views.Controls
{
    /// <summary>
    /// Interaction logic for GraphsElementUC.xaml
    /// </summary>
    public partial class GraphsElementUC : UserControl
    {
        GraphsElementVM myDataContext;
        public GraphsElementUC()
        {
            InitializeComponent();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            myDataContext = this.DataContext as GraphsElementVM;
        }

        private void _symmetric_ToggleButton_SourceUpdated(object sender, DataTransferEventArgs e)
        {

            myDataContext.RaisePropertyChanged(() => myDataContext.isColLimitsSymmetricText);
        }




    }
}
