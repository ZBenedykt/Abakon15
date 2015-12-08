using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abakon15.Infrastructure;
using AbakonDataModel;
using System.Collections.ObjectModel;

namespace Abakon15.Utility
{
    internal static class NaprawPrzyrzady
    {
        internal static void UstawDatyKalibracji()
        {
            PrzyrzadPomiarowy.UpdateAll();
        }
    }
}
