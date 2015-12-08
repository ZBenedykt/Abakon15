using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using AbakonDataModel.Interfaces;
using AbakonDataModel.DataAccess;
using AbakonDataModel.Infrastructure;

namespace AbakonDataModel
{
    public class Department : IUpdateSignature
    {
        public Department()
        {
            subordinateList = new ObservableCollection<Department>();
            managerList = new ObservableCollection<Employee>();
            deputyManagerList = new ObservableCollection<Employee>();
        }

        public Department(Department parent)
            : base()
        {
            this.ParentDepartment = parent;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        public int DepartmentCode { get; set; }
        public bool DepartmentSendMail { get; set; }
        [PrintAttribute(PatternName = "#Nazwa")]
        public string DepartmentName { get; set; }
        public int? ParentDepartmentId { get; set; }

        #region IUpdateSignature
        public int? ApplicationId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string UserName { get; set; }
        #endregion


        public virtual ICollection<Employee> managerList { get; set; }
        public virtual ICollection<Employee> deputyManagerList { get; set; }

        [ForeignKey("ParentDepartmentId")]
        public virtual Department ParentDepartment { get; set; }

        [ForeignKey("ParentDepartmentId")]
        public virtual ObservableCollection<Department> subordinateList { get; set; }
    


        private string _fullPath = "";
        [NotMapped]
        public string FullPath
        {
            get
            {
                if (_fullPath == "")
                {
                    _fullPath = GetPath();
                }
                return _fullPath;
            }
            set { _fullPath = value; }
        }

        private string GetPath()
        {
            Department rr = this;
            List<string> names = new List<string>();
            while (rr != null)
            {
                names.Add(rr.DepartmentName);
                if (rr.ParentDepartment != null)
                {
                    rr = rr.ParentDepartment;
                }
                else
                {
                    break;
                }
            }
            names.Reverse();
            return string.Join("/" + System.Environment.NewLine, names);
        }

        public static IEnumerable<Department> Load(PgSqlDBContext dbContext = null)
        {
            return DepartmentInDB.Load(dbContext);
        }

        public static Department Create(Department parent = null, PgSqlDBContext dbContext = null)
        {
            Department newRec = parent == null ? new Department() : new Department(parent);
            DepartmentInDB.AddToContext(newRec, dbContext);
            return newRec;
        }

        public void ChangeParent(Department parent = null, PgSqlDBContext dbContext = null)
        {
            this.ParentDepartment = parent;
        }

        public void Delete(PgSqlDBContext dbContext = null)
        {
            DepartmentInDB.Delete(this, dbContext);
        }

        public static Department GetDepartment(int xGuid, PgSqlDBContext dbContext = null)
        {
            return DepartmentInDB.GetDepartment(xGuid, dbContext);
        }

        public static List<int> GetGuidList(int? initGuid = null, bool recursive = true)
        {
            return DepartmentInDB.GetGuidList(initGuid, recursive);
        }
    }
}
