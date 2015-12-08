using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Abakon15WPF.Utility;
using AbakonDataModel;

namespace Abakon15WPF
{

    public struct ExcelLocalizationParameterStructure
    {
        public int FilePathId;
        public int dcpId;
    }

    public static class AppParameters
    {
        static XDocument paramDokument;

        static ExcelLocalizationParameterStructure _ExcelLocalizationParameter = new ExcelLocalizationParameterStructure() { FilePathId = 0, dcpId = 0 };
        public static ExcelLocalizationParameterStructure ExcelLocalizationParameter { get { return _ExcelLocalizationParameter; } }
        static bool _ExcelLocalizationParameterOK = false;
        public static bool ExcelLocalizationParameterOK { get { return _ExcelLocalizationParameterOK; } }

        static string _TestParam;
        public static ExcelLocalizationParameterStructure TestParam { get { return _ExcelLocalizationParameter; } }
        static bool _TestParamOK = false;
        public static bool TestParamOK { get { return _TestParamOK; } }

        static AppParameters()
        {
            List<string> paramNameList = new List<string>();

            try
            {
                paramDokument = XMLUtility.LoadXMLFromString(_Application.ThisApplication().Parameters);
                paramNameList = XMLUtility.GetListOfELementsNames(paramDokument.Root);
            }
            catch (Exception)
            {
                return;
            }

            if (paramNameList.FirstOrDefault(p => p == TypyNodeEnum.excPathTypeOfDoc.ToString()) == null)
            {
                _ExcelLocalizationParameter.FilePathId = 0;
                _ExcelLocalizationParameter.dcpId = 0;
            }
            else
            {
                XElement paramExcPathTypeOfDoc = XMLUtility.GetParamOfName(paramDokument.Root, TypyNodeEnum.excPathTypeOfDoc.ToString());
                if (int.TryParse(paramExcPathTypeOfDoc.Attribute("Path").Value, out _ExcelLocalizationParameter.FilePathId) &&
                    int.TryParse(paramExcPathTypeOfDoc.Attribute("DocClasification").Value, out _ExcelLocalizationParameter.dcpId))
                {
                    _ExcelLocalizationParameterOK = true;
                }
            }

            if (paramNameList.FirstOrDefault(p => p == TypyNodeEnum.test.ToString()) == null)
            {
                _TestParam = "Pusto";
            }
            else
            {
                XElement tt = XMLUtility.GetParamOfName(paramDokument.Root, TypyNodeEnum.test.ToString());
                _TestParam = tt.Attribute("Wartosc").Value;
                _TestParamOK = true;
            }

        }



    }
}
