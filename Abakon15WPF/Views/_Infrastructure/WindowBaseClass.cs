using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Abakon15WPF.ViewModels;
using Abakon15WPF.Infrastructure;

namespace Abakon15WPF.Views
{
    public class WindowBaseClass : Window, IRegisteredWindow
    {
        private static int counter = 0;


        public WindowBaseClass()
            : base()
        {
            this.Uid = (counter++).ToString();
            this.Closing += new System.ComponentModel.CancelEventHandler(Window_Closing);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool mod = System.Windows.Interop.ComponentDispatcher.IsThreadModal;

            var context = this.DataContext as ViewModelBase;
            if (!mod && context != null ) //&& context.UnsavedChanges)
            {
                string kom = "_UnsavedChangesWillSave".Translate();
                string komHeader = "_confirm".Translate();
                if (MessageBox.Show(kom, komHeader, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                    context.SaveCommand.Execute();
                }
                else
                {
                    AbakonDataModel.DataModelUtility.UndoChangesOfDbContext();
                }
                // MessageBox.Show("_UnsavedChangesWillSave".Translate(), "_Caution".Translate(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //context.SaveCommand.Execute();
            }
        }



        #region IRegisteredWindow Members

        public WindowContextEnum TabGroup
        { get; set; }

        public virtual string TabGroupName
        {
            get
            {
                return TabGroup.ToString().Translate();
            }
            set { }
        }

        public virtual string RegisteredDetatilHeader
        { get; set; }

        #endregion
    }
}
