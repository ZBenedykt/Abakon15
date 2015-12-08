using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows;

namespace Abakon15.Utility
{
    internal enum TypyNodeEnum
    {
        excPathTypeOfDoc,
        test

    }

    internal class XMLUtility
    {
        public static XDocument LoadXMLFromString(string xmlContents)
        {
            TextReader tr = new StringReader(xmlContents);
            XDocument xml = XDocument.Load(tr);
            return xml;
        }

        public static XElement GetParamOfName(XElement elem, string name)
        {
            XElement result = null;
            if (elem != null)
            {
                foreach (XElement e in elem.Elements("Param"))
                {
                    if (e.Attribute("Name").Value == name)
                    {
                        return e;
                    }
                }
            }
            return result;
        }

        public static String GetContent(XDocument document)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Indent = true;


            using (XmlWriter xw = XmlWriter.Create(sb, xws))
            {
                xw.WriteStartElement("Root");
                foreach (var item in document.Root.Element("content").Elements())
                {
                    item.WriteTo(xw);
                }
                xw.WriteEndElement();
            }
            return sb.ToString();
        }

        public static List<string> GetListOfELementsNames(XElement elem, TypyNodeEnum typInf)
        {
            List<string> lista = new List<string>();
            if (elem == null) return lista;
            string typName = typInf.ToString();
            foreach (XElement e in elem.Elements(typName))
            {
                lista.Add(e.Attribute("Name").Value);
            }
            return lista;
        }

        public static List<string> GetListOfELementsNames(XElement elem)
        {
            List<string> lista = new List<string>();
            if (elem == null) return lista;

            foreach (XElement e in elem.Elements("Param"))
            {
                lista.Add(e.Attribute("Name").Value);
            }
            return lista;
        }

        public static XElement CreateXElementInst(string startDate, string name)
        {

            XElement typeElem =
                      new XElement("Inst",
                        new XAttribute("StartDate", startDate),
                        new XAttribute("Name", name));
            return typeElem;
        }

        public static XElement InitExcelLocalizationParameter()
        {
            XElement typeElem =
                  new XElement("Param",
                    new XAttribute("Name", TypyNodeEnum.excPathTypeOfDoc),
                    new XAttribute("Path", ""),
                    new XAttribute("DocClasification", ""),
                    new XAttribute("Description", "_ExcelLocalizationDescription"));
            return typeElem;
        }

        public static XElement InitTestParameter()
        {
            XElement typeElem =
                  new XElement("Param",
                    new XAttribute("Name", TypyNodeEnum.test),
                    new XAttribute("Wartosc", ""));
            return typeElem;
        }




        internal static string CreateInitLicence()
        {
            return Math.Exp(Math.PI).ToString();
        }

        internal static bool CreateInitLicence(string p)
        {
            return p == CreateInitLicence();
        }

        internal static string CreateTryLicence()
        {
            string xmlSTR = string.Format(@"<?xml version='1.0' encoding='utf-16'?> <Licence Type='try' StartDate='{0}' UserId='{1}'></Licence>", DateTime.Today.ToString("dd-MM-yyyy HH:mm:ss"), Guid.NewGuid());
            return RijndaelCrypto.EncryptString(xmlSTR);
        }

        //internal static string CreateUserLicence()
        //{
        //    string xmlSTR = string.Format(@"<?xml version='1.0' encoding='utf-16'?> <Licence Type='user' LoginLimit='5' StartDate='{0}' UserId='{1}'></Licence>", DateTime.Today.ToString("dd-MM-yyyy HH:mm:ss"), Guid.NewGuid());
        //    return RijndaelCrypto.EncryptString(xmlSTR);
        //}

        internal static string UpdateLicence(XElement oldLicence)
        {
            XElement newLicence = oldLicence;
            if (newLicence.Attribute("Type").Value == "try")
            {
                newLicence.Attribute("Type").Value = "user";
            }
            if (newLicence.Attribute("LoginLimit") == null)
            {
                newLicence.Add(new XAttribute("LoginLimit", 5));
            }
            else
            {
                newLicence.Attribute("LoginLimit").Value = "5";
            }
            newLicence.Attribute("StartDate").Value = DateTime.Today.ToString("dd-MM-yyyy HH:mm:ss");

            return RijndaelCrypto.EncryptString(newLicence.ToString()); //XElementToString(newLicence, "Licence"));

        }

        /*
         User licence pattern
         @"<?xml version='1.0' encoding='utf-16'?> <Licence Type='user' StartDate='{0}' UserId='{1}' LoginLimit='{2}'> <UserDescription>{3}</UserDescription></Licence>", DateTime.Today, guid, limit)
         */

        internal static XElement GetLicence(string xmlContentsEncode)
        {
            try
            {
                string xmlContents = RijndaelCrypto.DecryptString(xmlContentsEncode);
                TextReader tr = new StringReader(xmlContents);
                XDocument document = XDocument.Load(tr);

                XElement licence = document.Root; //.Element("Licence");
                return licence;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Licence error  " + ex.Message + Environment.NewLine + ex.InnerException.Message);
                return null;
            }
        }

        internal static XElement GetSessions(string p)
        {
            if (p == null || p.Trim().Length == 0)
            {
                return new XElement("Sessions");
            }
            else
            {

                string xmlStr = p; // RijndaelCrypto.DecryptString(p);
                TextReader tr = new StringReader(xmlStr);
                XElement sessions = XElement.Load(tr);
                return sessions; //.Element("Sessions");
            }
        }

        internal static string SaveSessions(XElement sessions)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Indent = true;


            using (XmlWriter xw = XmlWriter.Create(sb, xws))
            {
                xw.WriteStartElement("Sessions");
                foreach (var item in sessions.Elements())
                {
                    item.WriteTo(xw);
                }
                xw.WriteEndElement();
            }
            return sb.ToString(); // RijndaelCrypto.EncryptString(sb.ToString());
        }



        internal static int LoggedUsersCount(XElement sessions)
        {
            string stat = Environment.UserName + "/" + Environment.MachineName;
            foreach (var item in sessions.Elements("Login"))
            {

                if (DateTime.Parse(item.Attribute("Startdate").Value) < DateTime.Today || item.Attribute("station").Value == stat)
                {
                    item.Remove();
                }
            }
            return sessions.Elements().Count();
        }

        internal static void LoggedUsersAdd(ref XElement sessions)
        {
            string stat = Environment.UserName + "/" + Environment.MachineName;
            XElement x = sessions.Elements("Login").FirstOrDefault(l => l.Attribute("station").Value == stat);
            if (x == null)
            {
                XElement newLogin = new XElement("Login",
                                new XAttribute("station", stat),
                                new XAttribute("Startdate", DateTime.Now));
                sessions.Add(newLogin);
            }
        }

        internal static string LoggedUsersRemove(string psessions)
        {
            XElement xmlSessions = GetSessions(psessions);
            string stat = Environment.UserName + "/" + Environment.MachineName;
            foreach (var item in xmlSessions.Elements("Login"))
            {
                if (item.Attribute("station").Value == stat)
                {
                    item.Remove();
                }
            }
            return SaveSessions(xmlSessions);
        }
    }
}
