using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbakonDataModel.Interfaces;
using AbakonDataModel.LangKeys;
using System.Collections.ObjectModel;
using AbakonDataModel.DataAccess;

namespace AbakonDataModel
{
    [Table("Person")]
    public class Person : IUpdateSignature
    {

        public Person()
        {
            employees = new ObservableCollection<Employee>();
            partnerList = new ObservableCollection<Partner>();    
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string name { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string sureName { get; set; }
        [MaxLength(12, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth12")]
        public string title { get; set; }
        public bool labWorker { get; set; }
        public short? gender { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string department { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string interests { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string work_phone { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string mobile_phone { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string home_phone { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string pref_contact { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string fax { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string business_email { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string private_email { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string www_address { get; set; }
        [MaxLength(60, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string spoken_lang { get; set; }
        [MaxLength(60, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string written_lang { get; set; }
        [MaxLength(1024, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string notes { get; set; }

        #region IUpdateSignature
        public int? ApplicationId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string UserName { get; set; }
        #endregion
        [NotMapped]
        public bool isEmployee
        {
            get
            {
                return employees.Any();
            }
            set { }
        }
        [NotMapped]
        public bool isAgent
        {
            get
            {
                return partnerList.Any();
            }
            set { }
        }
        [NotMapped]
        public int TaskAllocated
        { get; set; }

        public virtual ICollection<Employee> employees { get; set; }

        public virtual ICollection<Partner> partnerList { get; set; }
        public virtual ICollection<Address> addressList { get; set; }

        [NotMapped]
        public string SureFirstName
        {
            get
            {
                return this.name + " " + this.sureName;
            }
            set { }
        }


        public static IEnumerable<Person> LoadByDepartment(int guid, PgSqlDBContext dbContext = null)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Person> Load(System.Linq.Expressions.Expression<Func<Person, bool>> predicate, PgSqlDBContext dbContext = null)
        {

            return PersonInDB.LoadPersons(predicate, dbContext);
        }

        public static Person GetPerson(int guid, PgSqlDBContext dbContext = null)
        {
            throw new NotImplementedException();
        }

        public void ExtPersonAddPhoto(System.IO.FileInfo fInfo, PgSqlDBContext dbContext = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(PgSqlDBContext dbContext = null)
        {
            PersonInDB.Remove(this, dbContext);
        }

        public static Person Create(PgSqlDBContext dbContext = null)
        {
            Person newRec = new Person();
            PersonInDB.AddToContext(newRec, dbContext);
            return newRec;
        }

        public static IEnumerable<Person> LoadLabWorkers(PgSqlDBContext dbContext = null)
        {
            return PersonInDB.LoadLabWorkers(dbContext);
        }

        public static IEnumerable<Person> LoadEmployee(PgSqlDBContext dbContext = null)
        {
            return PersonInDB.LoadEmployee(dbContext);
        }
    }
}
