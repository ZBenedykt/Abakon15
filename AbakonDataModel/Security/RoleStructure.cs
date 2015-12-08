using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace AbakonDataModel
{
    public class RoleStructure : ObservableCollection<GenRole>
    {
        private ObservableCollection<GenPrivilege> m_privList = new ObservableCollection<GenPrivilege>();
        public ObservableCollection<GenPrivilege> PrivList
        {
            get { return m_privList; }
            set { m_privList = value; }
        }

        private static RoleStructure _instance;

        public RoleStructure()
        {
        }

        public static RoleStructure GetRoleFullStructure()
        {
            if (_instance == null)
            {
                _instance = BuildRoleStructure();
            }

            return _instance;
        }


        public RoleStructure GetUserRole(_User user)
        {
            RoleStructure result = new RoleStructure();
            foreach (_Role item in user.RolesOf)
            {
                if (item != null)
                {
                    GenRole role = GetGenRole(item.RoleId);
                    if (role != null)
                    {
                        result.Add(role);
                    }
                }
            }
            return result;
        }

        public void AddGenRole(GenRole genRole)
        {
            this.Add(genRole);
        }


        public void RemoveGenRole(GenRole genRole)
        {
            if (this.Contains(genRole))
            {
                try
                {
                    this.Remove(genRole);
                }
                catch (Exception)
                {
                }
            }
            else
            {
                foreach (GenRole item in this)
                {
                    RemoveGenRole(genRole, item.includedRoles);
                }
            }
        }



        private void RemoveGenRole(GenRole genRole, ObservableCollection<GenRole> roles)
        {
            if (roles.Contains(genRole))
            {
                roles.Remove(genRole);
            }
            else
            {
                foreach (GenRole item in roles)
                {
                    RemoveGenRole(genRole, item.includedRoles);
                }
            }
        }

        public void RemoveRootGenRole(GenRole genRole)
        {
            GenRole actRole = genRole;
            GenRole parentRole;
            if (actRole != null)
            {
                while (actRole.parentRoleKey.HasValue)
                {
                    parentRole = GetGenRole(actRole.parentRoleKey);
                    if (parentRole != null)
                    {
                        actRole = parentRole;
                    }
                    else
                    {
                        break;
                    }
                }
                RemoveGenRole(actRole);
            }
        }


        public RoleStructure GetUserComplementaryRole(_User user)
        {
            RoleStructure rs = BuildRoleStructure();

            return rs;
        }

        public void addRoleWithSubstructure(GenRole prole)
        {
            GenRole role = GetRoleFullStructure().GetGenRole(prole.roleKey);
            this.AddGenRole(role);

        }

        public void AddRole(GenRole prole)
        {
            GenRole parent = GetGenRole(prole.parentRoleKey);
            if (parent != null)
            {
                parent.AddIncludedRole(prole);
            }
            else
            {
                this.AddGenRole(prole);
            }
        }

        public bool hasPrivilege(GenPrivilege pprivilege)
        {
            return m_privList.Contains(pprivilege);
        }

        Collection<_Role> rolesInDB;
        public void RebuildRoles()
        {
            rolesInDB = (Collection<_Role>)_Role.Load();
            foreach (_Role role in rolesInDB)
            {
                GenRole genRole = GetGenRole(role.RoleId);
                if (genRole == null)
                {
                    _Role.Remove(role);
                }
                else
                {
                    if (genRole.roleBaseName != role.RoleName)
                    {
                        role.RoleName = genRole.roleBaseName;
                    }
                }
            }
            rolesInDB = (Collection<_Role>)_Role.Load();
            Collection<GenRole> plainRoleStructure = new Collection<GenRole>();
            RoleStructureToPlain(GetRoleFullStructure(), ref plainRoleStructure);
            foreach (GenRole item in plainRoleStructure)
            {
                if (!_Role.IsRoleExist(item.roleKey))
                {
                    _Role.Create(item);
                }
            }
        }


        private static void RoleStructureToPlain(ObservableCollection<GenRole> list, ref Collection<GenRole> plainRoleStructure)
        {
            foreach (GenRole item in list)
            {
                plainRoleStructure.Add(item);
                if (item.includedRoles.Count > 0)
                {
                    RoleStructureToPlain(item.includedRoles, ref plainRoleStructure);
                }
            }
        }

        internal GenRole GetGenRole(int? roleId)
        {
            GenRole foundGenRole = null;
            foreach (var item in this)
            {
                if (item.roleKey == roleId)
                {
                    foundGenRole = item;

                }
                else if (item.includedRoles.Count > 0)
                {
                    foundGenRole = GetGenRole(roleId, item.includedRoles);
                }

                if (foundGenRole != null)
                {
                    return foundGenRole;
                }
            }
            return foundGenRole;
        }

        private GenRole GetGenRole(int? roleId, ObservableCollection<GenRole> list)
        {
            GenRole foundGenRole = null;
            foreach (GenRole item in list)
            {
                if (item.roleKey == roleId)
                {
                    foundGenRole = item;
                }
                else if (item.includedRoles.Count > 0)
                {
                    foundGenRole = GetGenRole(roleId, item.includedRoles);
                }
                if (foundGenRole != null)
                {
                    return foundGenRole;
                }
            }
            return foundGenRole;
        }



        public RoleStructure ComplementaryRoleStructure()
        {
            RoleStructure roleStr = BuildRoleStructure();
            foreach (GenRole item in this)
            {
                GenRole rol = roleStr.GetGenRole(item.roleKey);
                roleStr.RemoveGenRole(rol);
            }
            return roleStr;
        }

        internal bool HasRole(int p)
        {
            return this.GetGenRole(p) != null;
        }

        #region Base role structure
        public static RoleStructure BuildRoleStructure()
        {
            GenRole role;
            GenRole parentRole;
            RoleStructure roleStructure = new RoleStructure();
            PrivilegeList privilegeList = new PrivilegeList();

            role = new GenRole(1, "_roleAmin", "_roleAmin".Translate(), prevented: true);
            role.privileges.Add(privilegeList.Find(p => p.Name == "_admin"));
            roleStructure.Add(role);

            role = new GenRole(10, "_roleUser", "_roleUser".Translate());
            role.privileges.Add(privilegeList.Find(p => p.Name == "_appUser"));
            roleStructure.Add(role);


            parentRole = new GenRole(100, "_equipmentHeader", "_equipmentHeader".Translate());
            roleStructure.Add(parentRole);
            role = new GenRole(101, "_allEquipmnetAccess", "_allEquipmnetAccess".Translate());
            role.privileges.Add(privilegeList.Find(p => p.Name == "_allEquipmnetAccess"));
            parentRole.AddIncludedRole(role);
            role = new GenRole(102, "_canAddEquipment", "_canAddEquipment".Translate());
            role.privileges.Add(privilegeList.Find(p => p.Name == "_canAddEquipment"));
            parentRole.AddIncludedRole(role);
            role = new GenRole(103, "_canDeleteEquipment", "_canDeleteEquipment".Translate());
            role.privileges.Add(privilegeList.Find(p => p.Name == "_canDeleteEquipment"));
            parentRole.AddIncludedRole(role);
            role = new GenRole(104, "_canUpdateEquipment", "_canUpdateEquipment".Translate());
            role.privileges.Add(privilegeList.Find(p => p.Name == "_canUpdateEquipment"));
            parentRole.AddIncludedRole(role);
            role = new GenRole(105, "_canDisposeEquipmentToEmployee", "_canDisposeEquipmentToEmployee".Translate());
            role.privileges.Add(privilegeList.Find(p => p.Name == "_canDisposeEquipmentToEmployee"));
            parentRole.AddIncludedRole(role);

            parentRole = new GenRole(200, "_partnerHeader", "_partnerHeader".Translate());
            roleStructure.Add(parentRole);
            role = new GenRole(201, "_canAddPartner", "_canAddPartner".Translate());
            role.privileges.Add(privilegeList.Find(p => p.Name == "_canAddPartner"));
            parentRole.AddIncludedRole(role);
            role = new GenRole(202, "_canDeletePartner", "_canDeletePartner".Translate());
            role.privileges.Add(privilegeList.Find(p => p.Name == "_canDeletePartner"));
            parentRole.AddIncludedRole(role);
            role = new GenRole(203, "_canUpdatePartner", "_canUpdatePartner".Translate());
            role.privileges.Add(privilegeList.Find(p => p.Name == "_canUpdatePartner"));
            parentRole.AddIncludedRole(role);


            parentRole = new GenRole(300, "_personHeader", "_personHeader".Translate());
            roleStructure.Add(parentRole);
            role = new GenRole(301, "_canAddPerson", "_canAddPerson".Translate());
            role.privileges.Add(privilegeList.Find(p => p.Name == "_canAddPerson"));
            parentRole.AddIncludedRole(role);
            role = new GenRole(302, "_canDeletePerson", "_canDeletePerson".Translate());
            role.privileges.Add(privilegeList.Find(p => p.Name == "_canDeletePerson"));
            parentRole.AddIncludedRole(role);
            role = new GenRole(303, "_canUpdatePerson", "_canUpdatePerson".Translate());
            role.privileges.Add(privilegeList.Find(p => p.Name == "_canUpdatePerson"));
            parentRole.AddIncludedRole(role);





            #region ==============Data roles =============================

            /*            role = new GenRole(990, "_canPartnerDocumentsReorganize", "_canPartnerDocumentsReorganize".Translate());
            role.privileges.Add(privilegeList.Find(p => p.Name == "_canPartnerDocumentsReorganize"));
            roleStructure.Add(role);

            #region =====================  Document access roles ===================================
            int roleKey = 1001;

            parentRole = new GenRole(1000, "_Dokumenty", "_documentsAccess".Translate());
            roleStructure.Add(parentRole);

            foreach (string item in DocumentClassificationPattern.GetPrivilege().OrderBy(s => s))
            {
                role = new GenRole(roleKey, item + "_R", item + "_read".Translate());
                role.privileges.Add(new GenPrivilege(roleKey, item + "_R"));
                parentRole.AddIncludedRole(role);
                roleKey++;
                role = new GenRole(roleKey, item + "_W", item + "_write".Translate());
                role.privileges.Add(new GenPrivilege(roleKey, item + "_W"));
                parentRole.AddIncludedRole(role);
                roleKey++;
            }

            #endregion
 */
            #endregion

            return roleStructure;

        }
        #endregion


    }
}
