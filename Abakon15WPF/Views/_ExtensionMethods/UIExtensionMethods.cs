using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace Abakon15WPF.Views
{
    public static class UIExtensionMethods
    {
        private static Action EmptyDelegate = delegate() { };
        public static void Refresh(this UIElement uiElement)
        {
            if (uiElement != null)
            {
                uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
            }
        }
    }
}
