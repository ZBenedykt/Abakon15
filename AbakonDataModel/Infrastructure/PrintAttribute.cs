using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbakonDataModel.Infrastructure
{
    public class PrintAttribute : Attribute
    {
        public string PatternName { get; set; }
        public string typeName { get; set; }
    }
}
