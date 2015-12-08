using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace AbakonDataModel.DataAccess
{
    public class _UserInDB : DataAccessBaseClass
    {
        static PgSqlDBContext mContext = defaultContext;



        internal static IEnumerable<_User> Load()
        {
            int idApp = _Application.ThisApplication().ApplicationId;
            var qry = mContext._UserDbSet.Include("membership").Where(u => u.ApplicationId == idApp).OrderBy(d => d.UserName);
            foreach (var item in qry)
            {
                yield return item;
            }

        }

        internal static _User GetUser(int userId)
        {
            return mContext._UserDbSet.Find(_Application.ThisApplication(), userId);
        }

        internal static void AddToContext(_User newUser)
        {
            mContext._UserDbSet.Add(newUser);
            AddMembership(newUser);

        }

        internal static void AddMembership(_User user)
        {
            if (user.IsValid && user.membership == null)
            {
                mContext._MembershipDbSet.Add(new _Membership() { ApplicationId = _Application.ThisApplication().ApplicationId, userMemb = user });
            }

        }

        internal static void Remove(_User user)
        {
            mContext._UserDbSet.Remove(user);
            SaveChanges();
        }


        internal static void RefreshRoles(_User users)
        {
            mContext.Entry(users).Collection<_Role>("RolesOf").Load();
        }

        internal static _User GetUser(string userName)
        {
            int idApp = _Application.ThisApplication().ApplicationId;
            return mContext._UserDbSet.FirstOrDefault(u => u.ApplicationId == idApp && u.UserName == userName && (!u.membership.IsRetired.HasValue || !u.membership.IsRetired.Value));
        }


        internal static bool isDuplicateUserName(string userName)
        {
            return mContext._UserDbSet.Local.Count(us => us.UserName == userName) > 1;
        }


        internal static void CreateFirstAdmin(int appId)
        {
            _Role adminRole = mContext._RoleDbSet.FirstOrDefault(r => r.RoleName == "_roleAmin");
            if (adminRole == null)
            {
                adminRole = new _Role();
                adminRole.RoleName = "_roleAmin";
                adminRole.ApplicationId = appId;
                adminRole.CreateDate = DateTime.Now;
                mContext._RoleDbSet.Add(adminRole);
                mContext.SaveChanges();
            }


            if (!adminRole.UsersOf.Any())
            {
                try
                {
                    _User tAdmin = _User.Create("Admin");
                    mContext._UserDbSet.Add(tAdmin);
                    tAdmin.RolesOf.Add(adminRole);
                    mContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    string m = ex.Message;
                }
            }
        }
    }
}
