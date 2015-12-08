using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abakon15WPF
{
    public class DataGridSelectionInfo
    {
        public string DataGridHeader { get; set; }
        public string[] PropertyPath { get; set; }
        public Type PropertyType { get; set; }
    }
}
