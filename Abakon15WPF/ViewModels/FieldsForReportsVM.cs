using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abakon15WPF.Reports;
using AbakonDataModel;
using System.ComponentModel;
using System.Windows;

namespace Abakon15WPF.ViewModels
{
    class FieldsForReportsVM<E> : ViewModelBase
    {
        List<string> _FieldsList = FieldsForReports.CreateListOfFields(typeof(E));
        public List<string> FieldsList
        {
            get { return _FieldsList; }
        }

        public FieldsForReportsVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            { }
        }
    }
}
