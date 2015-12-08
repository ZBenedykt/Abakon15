using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abakon15.Infrastructure
{
    public interface IappState
    {
        int ApplicationId { get; }
        string ApplicationName { get; }
        string LoweredApplicationName { get; }
        string Description { get; }
        string Sessions { get; set; }
        string LicenceDescription { get; set; }
    }

}
