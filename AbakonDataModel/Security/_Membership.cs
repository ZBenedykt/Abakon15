using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AbakonDataModel.DataAccess;
using System.ComponentModel;

namespace AbakonDataModel
{
    [Table("_Membership")]
    public partial class _Membership
    {
        public _Membership()
        {
            CreateDate = DateTime.Now;
            LastLoginDate = DateTime.Today.AddDays(-1);
            LastPasswordChangedDate = DateTime.Today.AddDays(-1);
            LastLockoutDate = DateTime.Today.AddDays(-1);
        }

        [Key]
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
        [DefaultValue(1)]
        public int LevelOfConfidence { get; set; }
        public string Password { get; set; }
        public string MobilePIN { get; set; }
        public string Email { get; set; }
        public string LoweredEmail { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public bool IsApproved { get; set; }
        [DefaultValue(false)]
        public bool? IsRetired { get; set; }
        public bool IsLockedOut { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime LastLoginDate { get; set; }
        public System.DateTime LastPasswordChangedDate { get; set; }
        public System.DateTime LastLockoutDate { get; set; }

        public virtual _Application applicationMemb { get; set; }
        public virtual _User userMemb { get; set; }
    }
}
