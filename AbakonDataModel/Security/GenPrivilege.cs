using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbakonDataModel
{
    public class GenPrivilege : IComparable
    {
        public PrivilegeListEnum Key { get; private set; }
        public string Name { get; private set; }
        public string Descriptions { get; private set; }


        public GenPrivilege(PrivilegeListEnum key, string name, string description = "")
        {
            Key = key;
            Name = name;
            Descriptions = description;
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return this.Name.CompareTo(((GenPrivilege)obj).Name);
        }

        #endregion
    }
}
