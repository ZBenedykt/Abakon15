using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abakon15WPF.Infrastructure;
using System.ComponentModel;
using System.Windows;
using System.Collections.Specialized;
using Abakon15WPF.Interfaces;
using System.Collections.ObjectModel;
using AbakonDataModel;
namespace Abakon15WPF.ViewModels
{
    public class TaskCollectionVM : ViewModelBase, ITask
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

        private FilterPanelVM _myFilteredPanel = new FilterPanelVM();
        public FilterPanelVM MyFilteredPanel
        {
            get { return _myFilteredPanel; }
            set { SetField(ref _myFilteredPanel, value, () => MyFilteredPanel); }
        }

        public TaskCollectionVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {

            }
        }
    }
}
