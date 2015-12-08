using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace AbakonDataModel
{
    public class GenRole
    {
        public int roleKey { get; private set; }
        public int? parentRoleKey { get; private set; }
        public string roleName { get; private set; }
        public string roleBaseName { get; private set; }
        public bool mustPreventByUser { get; set; }
        public ObservableCollection<GenPrivilege> privileges { get; set; }
        public ObservableCollection<GenRole> includedRoles { get; set; }

        public GenRole(int key, string baseName, string name, bool prevented = false)
        {
            mustPreventByUser = prevented;
            roleKey = key;
            roleBaseName = baseName;
            roleName = name;
            this.includedRoles = new ObservableCollection<GenRole>();
            this.privileges = new ObservableCollection<GenPrivilege>();
        }

        public void AddPrivilege(GenPrivilege privilege)
        {
            if (!privileges.Contains(privilege))
            {
                privileges.Add(privilege);
            }
        }

        public void AddIncludedRole(GenRole role)
        {
            if (!includedRoles.Contains(role))
            {
                role.parentRoleKey = this.roleKey;
                includedRoles.Add(role);
            }
        }

        public int CountUsers
        {
            get
            {
                return _Role.CountUsers(this.roleKey);
            }
        }

        public bool CanDeleteRole
        {
            get
            {
                bool response = true;

                if (this.mustPreventByUser)
                {
                    if (this.CountUsers < 2) response = false;
                }

                return response;
            }
        }
    }
}
