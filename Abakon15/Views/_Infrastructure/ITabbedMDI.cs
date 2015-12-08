using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abakon15.Views
{
    public interface ITabbedMDI
    {
        /// <summary>
        /// This event will be fired from user control and will be listened
        /// by parent MDI form. when this event will be fired from child control
        /// parent will close the form
        /// </summary>
        WindowContextEnum TabGroup { get; set; }

        /// <summary>
        /// This is the tile will be shown in the tile when this control
        /// will be show in parent
        /// </summary>
        string Title { get; }
        bool SaveSpliterPositon { get; set; }
    }

    public interface IRegisteredWindow
    {
        WindowContextEnum TabGroup { get; set; } // Tab on MDI to witch window belongs
        string TabGroupName { get; set; }
        string RegisteredDetatilHeader { get; }

    }
}
