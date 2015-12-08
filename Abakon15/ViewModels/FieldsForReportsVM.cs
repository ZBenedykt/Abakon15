using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abakon15.Reports;
using AbakonDataModel;
using System.ComponentModel;
using System.Windows;

namespace Abakon15.ViewModels
{
    class FieldsForReportsVM : ViewModelBase
    {
        List<string> _FieldsList = FieldsForReports.CreateListOfFields(typeof(PrzyrzadPomiarowy));
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
