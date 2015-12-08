using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abakon15.Infrastructure;
using System.ComponentModel;
using System.Windows;
using System.Collections.Specialized;
using Abakon15.Interfaces;
using System.Collections.ObjectModel;
using AbakonDataModel;

namespace Abakon15.ViewModels
{
    public class TaskVM : ViewModelBase, ITask
    {
        #region ITask Members

        public ITask CurrentTask
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
        public TaskVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {

            }
        }
    }
}
