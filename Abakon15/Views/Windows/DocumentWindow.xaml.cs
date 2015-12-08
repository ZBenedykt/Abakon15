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


namespace Abakon15.Views.Windows
{
    /// <summary>
    /// Interaction logic for DocumentWindow.xaml
    /// </summary>
    public partial class DocumentWindow : WindowBaseClass
    {
        public DocumentWindow()
        {
            InitializeComponent();
        }

        #region IRegisteredWindow Members

        //private string mTabGroupName;
        //public override string TabGroupName
        //{
        //    get { return mTabGroupName; }
        //    set { mTabGroupName = value; }
        //}


        public new WindowContextEnum TabGroup { get { return WindowContextEnum.documents; } } // Tab on MDI to witch window belongs
        public new string TabGroupName { get { return WindowContextEnum.documents.ToString(); } }
        public new string RegisteredDetatilHeader { get { return ((IPartner)this.DataContext).CurrentPartner.ToString(); } }

        #endregion
    }
}
