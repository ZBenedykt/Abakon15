using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbakonDataModel.Interfaces
{
    internal interface IUpdateSignature
    {
        int? ApplicationId { get; set; }
        DateTime? CreateDate { get; set; }
        DateTime? LastUpdateDate { get; set; }
        string UserName { get; set; }
    }
}
