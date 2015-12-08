using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AbakonDataModel.DataAccess;
using System.ComponentModel;
using AbakonDataModel.LangKeys;
using System.Collections.ObjectModel;

namespace AbakonDataModel
{
    public interface IappUser
    {
        int ApplicationId { get; }
        int UserId { get; }
        string Password { get; }
        bool IsNeedChangePassword { get; }
        int LevelOfConfidence { get; }
        string UserName { get; }
        string LoweredUserName { get; }
        Guid? PersonId { get; }
        string FirstName { get; }
        string LastName { get; }
        _Membership membership { get; set; }
        List<GenPrivilege> privilegeList { get; }
        //Iperson person { get; }
    }

    [Table("_User")]
    public partial class _User : IDataErrorInfo, IValidatableObject, IappUser
    {
        public _User()
        {
            this.RolesOf = new ObservableCollection<_Role>();
            LoweredUserName = "";
            LastActivityDate = DateTime.Now;
        }

        public int ApplicationId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        [MinLength(3, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMinLegth3")]
        public string UserName { get; set; }
        [RegularExpression(@"^[A-Z][A-Z]$", ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errRegexInitialsNoMatched")]
        public string LoweredUserName { get; set; }
        public Guid? PersonId { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        [DefaultValue("")]
        public string FirstName { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        [DefaultValue("")]
        public string LastName { get; set; }
        [DefaultValue(true)]
        public bool? IsActive { get; set; }

        public bool IsAnonymous { get; set; }
        public System.DateTime LastActivityDate { get; set; }


        [NotMapped]
        [DefaultValue(false)]
        public bool IsSelected { get; set; }

        public virtual _Application application { get; set; }
        public virtual _Membership membership { get; set; }
        public virtual ICollection<_Role> RolesOf { get; set; }
        public virtual Person person { get; set; }

        [NotMapped]
        public string Password
        { get { return membership.Password; } }
        [NotMapped]
        public int LevelOfConfidence
        { get { return membership.LevelOfConfidence; } }

        [NotMapped]
        public bool IsNeedChangePassword
        { get { return membership.IsLockedOut; } }


        public static IEnumerable<_User> Load()
        {
            return _UserInDB.Load();
        }

        public static _User GetUser(int userId)
        {
            return _UserInDB.GetUser(userId);
        }

        public static _User GetUser(string userName)
        {
            return _UserInDB.GetUser(userName);
        }

        public static _User Create(String userName)
        {
            _User newUser = new _User();
            newUser.UserName = userName;
            newUser.ApplicationId = _Application.ThisApplication().ApplicationId;
            _UserInDB.AddToContext(newUser);
            return newUser;
        }

        public void AddMembership()
        {
            _UserInDB.AddMembership(this);
        }


        public void Update()
        {
            _UserInDB.SaveChanges();
        }

        public void ClearPassword()
        {
            this.membership.Password = string.Empty;
            _UserInDB.SaveChanges();
        }

        public static void Remove(_User user)
        {
            _UserInDB.Remove(user);
        }

        public void UpateRoles(RoleStructure RolesActual)
        {
            ObservableCollection<_Role> forDelete = new ObservableCollection<_Role>();

            foreach (_Role item in this.RolesOf)
            {
                if (item != null)
                {
                    if (!RolesActual.HasRole(item.RoleId))
                    {
                        forDelete.Add(item);
                    }
                }
            }

            foreach (_Role item in forDelete)
            {
                this.RolesOf.Remove(item);
                _UserInDB.SaveChanges();
            }

            foreach (GenRole item in RolesActual)
            {
                _Role role = _Role.GetRole(item.roleKey);
                if (this.RolesOf.FirstOrDefault(r => r.RoleId == item.roleKey) == null)
                {
                    this.RolesOf.Add(role);
                    _UserInDB.SaveChanges();
                }
            }
        }

        public RoleStructure RoleStructure()
        {
            RoleStructure roleStruct = new RoleStructure();
            foreach (_Role item in this.RolesOf)
            {
                if (item != null)
                {
                    roleStruct.addRoleWithSubstructure(new GenRole(item.RoleId, item.RoleName, item.RoleName.Translate()));
                }
            }
            this.LastActivityDate = DateTime.Now;
            return roleStruct;
        }

        private List<GenPrivilege> _privilegeList;
        [NotMapped]
        public List<GenPrivilege> privilegeList
        {
            get
            {
                if (_privilegeList == null)
                {
                    _privilegeList = new List<GenPrivilege>();
                    BuildListOfPrivilage();
                }
                return _privilegeList;
            }
        }

        private void BuildListOfPrivilage()
        {
            foreach (var item in RoleStructure())
            {
                if (item != null)
                {
                    _privilegeList.AddRange(item.privileges);
                    BuildListOfPrivilage(item.includedRoles);
                }
            }

        }

        private void BuildListOfPrivilage(ObservableCollection<GenRole> roles)
        {
            foreach (var item in roles)
            {
                if (item != null)
                {
                    _privilegeList.AddRange(item.privileges);
                    BuildListOfPrivilage(item.includedRoles);
                }
            }
        }





        public void RerfeshRoles()
        {
            _UserInDB.RefreshRoles(this);
        }


        public void CopyRolesFromUser(_User baseRoleUser)
        {
            foreach (var item in baseRoleUser.RolesOf)
            {
                if (!this.RolesOf.Contains(item))
                {
                    this.RolesOf.Add(item);
                }
            }
        }

        public static void CopyRolesFromUser(_User baseRoleUser, _User toUser)
        {
            foreach (var item in baseRoleUser.RolesOf)
            {
                if (!toUser.RolesOf.Contains(item))
                {
                    toUser.RolesOf.Add(item);
                }
            }
        }


        #region IDataErrorInfo Members ==========================================================================

        public string Error
        {
            get
            {
                return UserName;
            }
        }

        public string this[string columnName]
        {
            get
            {
                var results = new List<ValidationResult>();
                StringBuilder errStrBuilder = new StringBuilder();
                errStrBuilder.Clear();
                switch (columnName)
                {
                    case "UserName":

                        //     new ValidationResult("_duplicateUserName".Translate(), new[] { "UserName" });
                        Validator.TryValidateProperty(this.UserName, new ValidationContext(this, null, null) { MemberName = columnName }, results);
                        break;

                    case "FirstName":
                        Validator.TryValidateProperty(this.FirstName, new ValidationContext(this, null, null) { MemberName = columnName }, results);
                        break;
                    case "LastName":
                        Validator.TryValidateProperty(this.LastName, new ValidationContext(this, null, null) { MemberName = columnName }, results);
                        break;
                    case "LoweredUserName":
                        Validator.TryValidateProperty(this.LoweredUserName, new ValidationContext(this, null, null) { MemberName = columnName }, results);
                        break;

                    default:
                        break;

                }

                foreach (ValidationResult item in results)
                {
                    errStrBuilder.AppendLine(item.ErrorMessage);
                }
                return errStrBuilder.ToString();
            }
        }


        #endregion

        #region IValidatableObject Members

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();


            if (isDuplicateUserName(this.UserName))
                yield return new ValidationResult("_duplicateUserName".Translate() + this.UserName, new[] { "UserName" });

            //Validator.TryValidateProperty(this.UserName, new ValidationContext(this, null, null) { MemberName = "UserName" },  results);
            //Validator.TryValidateProperty(this.FirstName, new ValidationContext(this, null, null) { MemberName = "FirstName", DisplayName ="_FirstName".Translate() }, results);
            //Validator.TryValidateProperty(this.LastName, new ValidationContext(this, null, null) { MemberName = "LastName"  }, results);


            foreach (var item in results)
            {
                yield return item;
            }
            //  yield return string.Join(System.Environment.NewLine, results);
            //new ValidationResult("Description has bad words: " + string.Join(";", ""), new[] { "Description" });
        }

        public bool IsValid
        {
            get
            {
                return _UserInDB.IsValid(this);
            }
        }

        public static bool isDuplicateUserName(string userName)
        {
            return _UserInDB.isDuplicateUserName(userName);
        }

        #endregion



        public void RemoveAllRoles()
        {
            this.RolesOf.Clear();
            _UserInDB.SaveChanges();
        }

        internal static void CreateFirstAdmin(int appId)
        {
            _UserInDB.CreateFirstAdmin(appId);
        }
    }
}
