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
using System.ComponentModel;
using Abakon15.Infrastructure;

namespace Abakon15.Views.Windows
{
    /// <summary>
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class BalanceFeaturesWindow : Abakon15.Views.WindowBaseClass
    {
        AdornerLayer adornerLayer;

        public BalanceFeaturesWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            adornerLayer = AdornerLayer.GetAdornerLayer(elementsGrid);
            adornerLayer.Add(new ResizingAdorner(textWid1));
            adornerLayer.Add(new ResizingAdorner(textWid2));

        }
    }
}
