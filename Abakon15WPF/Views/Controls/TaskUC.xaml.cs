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

namespace Abakon15WPF.Views.Controls
{
    /// <summary>
    /// Interaction logic for TaskUC.xaml
    /// </summary>
    public partial class TaskUC : UserControl, ITabbedMDI
    {
        public TaskUC()
        {
            InitializeComponent();
        }

        #region ITabbedMDI Members

        public WindowContextEnum TabGroup
        {
            get
            {
                return WindowContextEnum.activities;
            }
            set
            {

            }
        }

        public string Title
        {
            get { return WindowContextEnum.activities.ToString(); }
        }

        public bool SaveSpliterPositon { get { return false; } set { } }

        #endregion
    }
}
