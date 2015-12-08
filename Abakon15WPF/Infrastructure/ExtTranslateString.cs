using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using Abakon15WPF.LangKeys;

namespace Abakon15WPF.Infrastructure
{
    public static class ExtTranslateStringClass
    {
        public static ResourceManager m_resourceManager = new ResourceManager("Abakon15WPF.LangKeys.ResourceLang", typeof(ResourceLang).Assembly);

        public static string Translate(this string str)
        {
            return m_resourceManager.GetString(str, System.Globalization.CultureInfo.CurrentCulture);
        }

        public static int[] ToTableInt(this string str)
        {
            List<int> wrkList = new List<int>();
            if (str != null && str.Length > 0)
            {
                string[] wStrTab = str.Split(';');
                foreach (string item in wStrTab)
                {
                    int id = -1;
                    if (int.TryParse(item, out id))
                    {
                        wrkList.Add(id);
                    }
                }
            }
            return wrkList.ToArray<int>();
        }

        public static string ToSeparableString(this int[] intTab)
        {
            return string.Join<int>(";", intTab);
        }


    }
}
