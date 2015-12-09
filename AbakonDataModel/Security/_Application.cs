using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AbakonDataModel.DataAccess;

namespace AbakonDataModel
{
    [Table("_Application")]
    public partial class _Application
    {



        public _Application()
        {
            this.memberships = new HashSet<_Membership>();
            this.roles = new HashSet<_Role>();
            this.users = new HashSet<_User>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationId { get; set; }
        [MaxLength(160)]
        public string ApplicationName { get; set; }
        [MaxLength(120)]
        public string LoweredApplicationName { get; set; }
        public string Description { get; set; }
        public string Sessions { get; set; }
        public string LicenceDescription { get; set; }
        public string Parameters { get; set; }

        public virtual ICollection<_Membership> memberships { get; set; }
        public virtual ICollection<_Role> roles { get; set; }
        public virtual ICollection<_User> users { get; set; }

        private static _Application m_ThisApplication = null;
        public static _Application ThisApplication()
        {
            if (m_ThisApplication == null)
            {
                m_ThisApplication = _ApplicationInDB.ThisApplication();
                RoleStructure.GetRoleFullStructure().RebuildRoles();
            }
            return m_ThisApplication;
        }

        public static bool CanConnectToDB()
        {
            return _ApplicationInDB.CanConnectToDB();
        }


        public void SaveData()
        {
            _ApplicationInDB.SaveChanges();
        }
    }
}
