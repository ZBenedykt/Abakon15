using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace AbakonDataModel.DataAccess
{
    class _RoleInDB : DataAccessBaseClass
    {
        static PgSqlDBContext mContext = defaultContext;

        internal static ICollection<_Role> Load()
        {
            int idApp = _Application.ThisApplication().ApplicationId;
            var qry = mContext._RoleDbSet.Where(u => u.ApplicationId == idApp);
            return new ObservableCollection<_Role>(qry);
        }

        internal static void Remove(_Role role)
        {
            mContext._RoleDbSet.Remove(role);
            SaveChanges();
        }

        internal static bool IsRoleExist(int roleId)
        {
            int idApp = _Application.ThisApplication().ApplicationId;
            return mContext._RoleDbSet.Find(roleId) != null;
        }

        internal static void Create(_Role newRole)
        {
            mContext._RoleDbSet.Add(newRole);
            SaveChanges();
        }

        internal static _Role GetRole(int roleId)
        {
            int idApp = _Application.ThisApplication().ApplicationId;
            return mContext._RoleDbSet.Find(roleId);
        }


        internal static int CountUsers(int roleId)
        {
            int idApp = _Application.ThisApplication().ApplicationId;
            return mContext._RoleDbSet.Find(roleId).UsersOf.Count();
        }
    }
}
