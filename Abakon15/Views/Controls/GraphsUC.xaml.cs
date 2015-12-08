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
using Abakon15.Infrastructure;

namespace Abakon15.Views.Controls
{
    /// <summary>
    /// Interaction logic for GraphsUC.xaml
    /// </summary>
    public partial class GraphsUC : UserControl
    {
        GraphsVM myDataContext;

        public GraphsUC()
        {
            InitializeComponent();
        }


        private void _addDomain_Button_Click(object sender, RoutedEventArgs e)
        {
            GraphsElementVM elDataContext = new GraphsElementVM(myDataContext.CurrentPrzyrzadPomiarowy, myDataContext.ExcelFile);
            GraphsElementUC scope = new GraphsElementUC();
            elDataContext.CurrentEquipmentGraph.ScopeName = "_scope".Translate() + (_graphs_WrapPanel.Children.Count + 1).ToString();
            scope.DataContext = elDataContext;

            ((GraphsElementVM)scope.DataContext).CurrentPrzyrzadPomiarowy = myDataContext.CurrentPrzyrzadPomiarowy;
            ((GraphsElementVM)scope.DataContext).ExcelFile = myDataContext.ExcelFile;
            ((GraphsElementVM)scope.DataContext).MyChart = scope._chart;
            var binding = new Binding("ActualWidth");
            binding.Source = this;
            scope.SetBinding(UserControl.WidthProperty, binding);
            ((GraphsElementVM)scope.DataContext).isOpenMainExpander = true;
            ((GraphsElementVM)scope.DataContext).isOpenSubExpander = true;
            _graphs_WrapPanel.Children.Add(scope);



        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            myDataContext = this.DataContext as GraphsVM;

            foreach (var item in myDataContext.CurrentPrzyrzadPomiarowy.graphs)
            {
                GraphsElementUC scope = new GraphsElementUC();
                GraphsElementVM elDataContext = new GraphsElementVM(item);

                _graphs_WrapPanel.Children.Add(scope);
                scope.DataContext = elDataContext;
                elDataContext.DataGridBuilder(scope._scopeDatGrid);
                elDataContext.ChartBuilder(scope._chart);
                var binding = new Binding("ActualWidth");
                binding.Source = this;
                scope.SetBinding(UserControl.WidthProperty, binding);
                scope.Refresh();
            }
        }


    }
}
