using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbakonDataModel
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

    public enum TypeNameEnum
    {
        asString,
        asBool,
        asInteger,
        asIntegerRangeIntersect,
        asIntegerRangeNotIntersect,
        asDecimal,
        asDecimalRangeIntersect,
        asDecimalRangeNotIntersect
    }

    [Flags]
    public enum DocumentClassifierForEntitiesEnum
    {
        unspecified = 1,
        forEquipment = 2,
        forPartner = 4,
        forPerson = 8,
        forStandard = 16,
        forProduct = 32,
        forTask = 64
    }

    public enum KalibracjaEtapEnum  //żądanie dostarczenie przyrządu, przyrząd dostarczony, zakończono itp.
    {
        start = 0,
        sentRequest = 1,
        delivered = 2,
        proceed = 4,
        redyToReceive = 8,
        finished = 16
    }

    //KalibracjaObcaEtapZałatwiania
    public enum KalibracjaObcaEtapEnum
    {
        start = 0,
        seekingLab = 1,
        seekingBroker = 2,
        acceptedContractors = 4,
        sentEquipment = 8,
        obtainedAfterCalibration = 16,
        affordedCertificate = 32,
        finished = 64
    }

    public enum EquipmentTypeEnum
    {
        PrzyrzadyWszystkie = 0,
        Elektryczne = 1,
        Mechaniczne = 2,
        Sprawdziany = 3,
        SprawdzianyDoGwintow = 4
    }

    public enum LegalizacjaEnum
    // 0-we własnym zakresie, 1 - zlecana zawsze, 2 = do decyzji w odpowiednim czasie , 4 - nie podlega legalizacji
    {
        LegalizacjaWlasna = 0,
        NiePodlegaLegalizacji = 1,
        ZawszeZlecana = 2,
        DoDecyzji = 4
    }

    public enum TypWlasnosciEnum
    //  0-własny; 1-wzorzec (kalibrator) wykonawcy usług; 2-narzędzie obce (zleceniodawcy usług)
    {
        przyrzadWlasny_0 = 0,
        kalibratorObceLab_1 = 1,
        przyrzadObcy_2 = 2,
        przyrzadNierejestrowany_3 = 3
    }

    public enum DokladnoscWgEnum
    //  0-własny; 1-wzorzec (kalibrator) wykonawcy usług; 2-narzędzie obce (zleceniodawcy usług)
    {
        normy_0 = 0,
        uzytkownika_1 = 1,
        producenta_2 = 2,
        rysunku_4 = 4
    }
}
