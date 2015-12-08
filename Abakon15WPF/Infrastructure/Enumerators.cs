using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abakon15WPF.Infrastructure;

namespace Abakon15WPF
{

    public enum WindowContextEnum
    {
        empty,
        persons,
        employees,
        measuringLabs,
        measuringDevices,
        documents,
        activities
    }

    public enum EquipmentTypeEnum
    {
        PrzyrzadyWszystkie = 0,
        Elektryczne = 1,
        Mechaniczne = 2,
        Sprawdziany = 3,
        SprawdzianyDoGwintow = 4
    }

}
