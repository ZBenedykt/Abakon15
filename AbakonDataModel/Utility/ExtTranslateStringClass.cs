using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using AbakonDataModel.LangKeys;

namespace AbakonDataModel
{
    internal static class ExtTranslateStringClass
    {
        public static ResourceManager m_resourceManager = new ResourceManager("AbakonDataModel.LangKeys.ResourceLang", typeof(ResourceLang).Assembly);

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

        public static string TestTypeOfValue(this string val, TypeNameEnum typeName)
        {
            string strVal = val;
            switch (typeName)
            {
                case TypeNameEnum.asBool:
                    {
                        bool boolResult;
                        if (!bool.TryParse(strVal, out boolResult))
                        {
                            return "_mustBeTrueOrFalse".Translate();
                        }
                        break;
                    }
                case TypeNameEnum.asDecimal:
                    {
                        decimal decimalResult;
                        if (!decimal.TryParse(strVal, out decimalResult))
                        {
                            return "_mustBeDecimal".Translate();
                        }
                        break;
                    }
                case TypeNameEnum.asInteger:
                    {
                        Int32 intResult;
                        if (!int.TryParse(strVal, out intResult))
                        {
                            return "_mustBeInteger".Translate();
                        }
                        break;
                    }

                default:
                    return string.Empty;
            }
            return string.Empty;
        }
    }
}
