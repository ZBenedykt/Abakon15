using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using AbakonDataModel;

namespace Abakon15WPF.Views
{
    public class LabWorkerTemplateSelector : DataTemplateSelector
    {

        public DataTemplate ActivePropertyTemplate
        { get; set; }


        public DataTemplate NotActivePropertyTemplate
        { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Person p = item as Person;

            if (p != null && p.labWorker)
                return ActivePropertyTemplate;
            else
                return NotActivePropertyTemplate;
        }
    }

    public class EmployeeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ActivePropertyTemplate
        { get; set; }


        public DataTemplate NotActivePropertyTemplate
        { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Person p = item as Person;

            if (p != null && p.isEmployee)
                return ActivePropertyTemplate;
            else
                return NotActivePropertyTemplate;
        }
    }

    public class AgentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ActivePropertyTemplate
        { get; set; }


        public DataTemplate NotActivePropertyTemplate
        { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Person p = item as Person;

            if (p != null && p.isAgent)
                return ActivePropertyTemplate;
            else
                return NotActivePropertyTemplate;
        }
    }
}
