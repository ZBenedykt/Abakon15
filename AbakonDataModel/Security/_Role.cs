using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AbakonDataModel.DataAccess;
using System.ComponentModel;
using AbakonDataModel.Interfaces;

namespace AbakonDataModel
{
    [Table("_Role")]
    public partial class _Role : IUpdateSignature
    {
        public _Role()
        {
            this.UsersOf = new HashSet<_User>();
            this.CreatingStamp();
        }
       [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleKey { get; set; }  
        public int ApplicationIdent { get; set; }
        public int RoleId { get; set; }
        public int? ParentRoleId { get; set; }
        [MaxLength(100)]
        public string RoleName { get; set; }
        [MaxLength(120)]
        public string LoweredRoleName { get; set; }
        public string Description { get; set; }

        #region IUpdateSignature
        public int? ApplicationId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string UserName { get; set; }
        #endregion

        public _Application application { get; set; }
        public virtual ICollection<_User> UsersOf { get; set; }

        public static ICollection<_Role> Load()
        {
            return _RoleInDB.Load();
        }

        internal static void Remove(_Role role)
        {
            _RoleInDB.Remove(role);
        }

        internal static bool IsRoleExist(int roleId)
        {
            return _RoleInDB.IsRoleExist(roleId);
        }

        internal static _Role Create(GenRole item)
        {
            _Role newRole = new _Role();
            newRole.ApplicationIdent = _Application.ThisApplication().ApplicationId; ;
            newRole.RoleId = item.roleKey;
            newRole.ParentRoleId = item.parentRoleKey;
            newRole.RoleName = item.roleBaseName;
            _RoleInDB.Create(newRole);
            return newRole;
        }

        internal static _Role GetRole(int roleId)
        {
            return _RoleInDB.GetRole(roleId);
        }



        internal static int CountUsers(int roleId)
        {
            return _RoleInDB.CountUsers(roleId);
        }

    }
}
