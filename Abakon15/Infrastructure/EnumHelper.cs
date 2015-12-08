using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abakon15.Infrastructure
{
    public static class EnumHelper
    {
        public static IEnumerable<Tuple<int, string>> TranslateEnumerator<T>()
        {
            foreach (Enum value in Enum.GetValues(typeof(T)))
            {
                yield return new Tuple<int, string>((int)(object)value, value.ToString().Translate());
            }
        }


        public static string GetDisplayText(Type enumType, int enumValue)
        {
            return GetDisplayText((Enum)Enum.ToObject(enumType, enumValue));
        }


        public static System.Collections.Specialized.StringCollection GetDisplayTexts(Type enumType)
        {
            System.Collections.Specialized.StringCollection texts = new System.Collections.Specialized.StringCollection();
            foreach (int key in Enum.GetValues(enumType))
            {
                texts.Add(EnumHelper.GetDisplayText((Enum)Enum.ToObject(enumType, key)));
            }
            return texts;
        }

        public static string GetDisplayText(Type enumType, byte enumValue)
        {
            return GetDisplayText((Enum)Enum.ToObject(enumType, enumValue));
        }

        public static string GetDisplayText(Enum enumValue)
        {
            string displayText;
            displayText = enumValue.ToString();
            return displayText;
        }

        public static Enum ParseDisplayText(Type typEnumeratora, string displayText)
        {

            Enum value;
            TryParseDisplayText(typEnumeratora, displayText, out value);
            return value;
        }

        public static bool TryParseDisplayText(Type typEnumeratora, string displayText, out Enum enumValue)
        {
            int i = 0;
            return TryParseDisplayText(typEnumeratora, displayText, out enumValue, out i);
        }

        public static bool TryParseDisplayText(Type typEnumeratora, string displayText, out Enum enumValue, out int intValue)
        {
            bool ok = false;
            enumValue = (Enum)Enum.ToObject(typEnumeratora, Enum.GetValues(typEnumeratora).GetValue(0));
            intValue = -1;
            foreach (int key in Enum.GetValues(typEnumeratora))
            {

                if (displayText == EnumHelper.GetDisplayText((Enum)Enum.ToObject(typEnumeratora, key)))
                {
                    enumValue = (Enum)Enum.ToObject(typEnumeratora, key);
                    intValue = key;
                    ok = true;
                    break;
                }

            }
            return ok;
        }



    }
}
