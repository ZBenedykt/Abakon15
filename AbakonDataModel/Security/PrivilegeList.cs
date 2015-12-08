using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbakonDataModel
{
    public enum PrivilegeListEnum
    {
        _admin,
        _appUser,
        _allEquipmnetAccess,
        _canAddEquipment,
        _canDeleteEquipment,
        _canUpdateEquipment,
        _canDisposeEquipmentToEmployee,
        _canAddPartner,
        _canDeletePartner,
        _canUpdatePartner,
        _canAddPerson,
        _canDeletePerson,
        _canUpdatePerson,
    }


    public class PrivilegeList : List<GenPrivilege>
    {
        public PrivilegeList()
        {
            // wykaz wszystkich uprawnień
            this.Add(new GenPrivilege(PrivilegeListEnum._admin, "_admin", "_adminComment".Translate()));
            this.Add(new GenPrivilege(PrivilegeListEnum._appUser, "_appUser", "_appUserComment".Translate()));

            this.Add(new GenPrivilege(PrivilegeListEnum._allEquipmnetAccess, "_allEquipmnetAccess", "_allEquipmnetAccess".Translate()));
            this.Add(new GenPrivilege(PrivilegeListEnum._canAddEquipment, "_canAddEquipment", "_canAddEquipment".Translate()));
            this.Add(new GenPrivilege(PrivilegeListEnum._canDeleteEquipment, "_canDeleteEquipment", "_canDeleteEquipment".Translate()));
            this.Add(new GenPrivilege(PrivilegeListEnum._canUpdateEquipment, "_canUpdateEquipment", "_canUpdateEquipment".Translate()));
            this.Add(new GenPrivilege(PrivilegeListEnum._canDisposeEquipmentToEmployee, "_canDisposeEquipmentToEmployee", "_canDisposeEquipmentToEmployee".Translate()));

            this.Add(new GenPrivilege(PrivilegeListEnum._canAddPartner, "_canAddPartner", "_canAddPartner".Translate()));
            this.Add(new GenPrivilege(PrivilegeListEnum._canDeletePartner, "_canDeletePartner", "_canDeletePartner".Translate()));
            this.Add(new GenPrivilege(PrivilegeListEnum._canUpdatePartner, "_canUpdatePartner", "_canUpdatePartner".Translate()));

            this.Add(new GenPrivilege(PrivilegeListEnum._canAddPerson, "_canAddPerson", "_canAddPerson".Translate()));
            this.Add(new GenPrivilege(PrivilegeListEnum._canDeletePerson, "_canDeletePerson", "_canDeletePerson".Translate()));
            this.Add(new GenPrivilege(PrivilegeListEnum._canUpdatePerson, "_canUpdatePerson", "_canUpdatePerson".Translate()));


        }
    }
}
