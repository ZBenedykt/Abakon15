﻿using System;
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

namespace Abakon15WPF.Views.Controls
{
    /// <summary>
    /// Interaction logic for PartnerDetailsUC.xaml
    /// </summary>
    public partial class PartnerDetailsUC : UserControl
    {
        public PartnerDetailsUC()
        {
            InitializeComponent();
        }
        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
