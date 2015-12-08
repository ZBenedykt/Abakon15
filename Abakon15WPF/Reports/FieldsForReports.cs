using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbakonDataModel.Infrastructure;

namespace Abakon15WPF.Reports
{
    public class FieldsForReports
    {

        public static List<string> CreateListOfFields(Type entity)
        {
            List<string> listOfFields = new List<string>();
            List<string> listOfFieldsR = new List<string>();
            System.ComponentModel.TypeDescriptor.GetProperties(entity);
            foreach (var item in entity.GetProperties())
            {
                System.Reflection.PropertyInfo pi = item;
                Attribute att = Attribute.GetCustomAttribute(item, typeof(PrintAttribute));
                if (att == null)
                {
                    continue;
                }
                string patternName = ((PrintAttribute)att).PatternName;


                bool isPrimitiv = pi.PropertyType.IsPrimitive;
                if (item.PropertyType.IsEnum) continue;
                if (item.PropertyType.IsValueType)
                {
                    listOfFields.Add(patternName + "#");
                    listOfFieldsR.Add(patternName + "#");
                    continue;
                }

                if (GetElementType(item.PropertyType).IsPrimitive || GetElementType(item.PropertyType) == typeof(string)
                                                  || GetElementType(item.PropertyType) == typeof(DateTime))
                {
                    listOfFields.Add(patternName + "#");
                    listOfFieldsR.Add(patternName + "#");
                }
                else
                {
                    Type t = GetElementType(pi.PropertyType);
                    AddToList(t, patternName, listOfFields, listOfFieldsR);
                }
            }

            return listOfFields;
        }
        private static void AddToList(Type ot, string oName, List<string> list, List<string> listR)
        {
            foreach (System.Reflection.PropertyInfo item in ot.GetProperties())
            {
                Attribute att = Attribute.GetCustomAttribute(item, typeof(PrintAttribute));
                if (att == null)
                {
                    continue;
                }
                string patternName = oName + "." + ((PrintAttribute)att).PatternName.Replace("#", "");

                if (item.PropertyType.IsEnum) continue;
                if (GetElementType(item.PropertyType).IsPrimitive || GetElementType(item.PropertyType) == typeof(string)
                                                                  || GetElementType(item.PropertyType) == typeof(DateTime))
                {
                    list.Add(patternName + "#");
                    listR.Add(patternName + "#");
                }
            }
        }

        internal static Type GetElementType(Type seqType)
        {
            Type ienum = FindIEnumerable(seqType);
            if (ienum == null) return seqType;
            return ienum.GetGenericArguments()[0];
        }

        private static Type FindIEnumerable(Type seqType)
        {
            if (seqType == null || seqType == typeof(string))
                return null;
            if (seqType.IsArray)
                return typeof(IEnumerable<>).MakeGenericType(seqType.GetElementType());
            if (seqType.IsGenericType)
            {
                foreach (Type arg in seqType.GetGenericArguments())
                {
                    Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                    if (ienum.IsAssignableFrom(seqType))
                    {
                        return ienum;
                    }
                }
            }
            Type[] ifaces = seqType.GetInterfaces();
            if (ifaces != null && ifaces.Length > 0)
            {
                foreach (Type iface in ifaces)
                {
                    Type ienum = FindIEnumerable(iface);
                    if (ienum != null) return ienum;
                }
            }
            if (seqType.BaseType != null && seqType.BaseType != typeof(object))
            {
                return FindIEnumerable(seqType.BaseType);
            }
            return null;
        }

    }
}
