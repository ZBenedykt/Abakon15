using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbakonDataModel.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbakonDataModel.LangKeys;
using System.Collections.ObjectModel;
using AbakonDataModel.DataAccess;

namespace AbakonDataModel
{
    [Table("Partner")]
    public class Partner : IUpdateSignature
    {
        public Partner()
        {
            addressList = new ObservableCollection<Address>();
            agentList = new ObservableCollection<Person>();
            documents = new ObservableCollection<Document>();


        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartnerId { get; set; }

        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string PartnerCode { get; set; }
        [MaxLength(256, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth256")]
        public string PartnerName { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string PartnerType { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string Partnerphone { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string PartnerFax { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string PartnerEmail { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string PartnerWWW { get; set; }
        [MaxLength(256, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth256")]
        public string PartnerKeyWords { get; set; }
        public string PartnerReliabilityRating { get; set; }

        #region IUpdateSignature
        public int? ApplicationId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string UserName { get; set; }
        #endregion

        public virtual ICollection<Address> addressList { get; set; }
        public virtual ICollection<Person> agentList { get; set; }
        public virtual ICollection<Document> documents { get; set; }

        public static IEnumerable<Partner> Load(System.Linq.Expressions.Expression<Func<Partner, bool>> predicate, PgSqlDBContext dbContext = null)
        {
            return PartnerInDB.Load(predicate, dbContext);
        }

        public static Partner Create(PgSqlDBContext dbContext = null)
        {
            Partner newRec = new Partner();
            PartnerInDB.AddToContext(newRec, dbContext);
            return newRec;
        }

        public void Remove(PgSqlDBContext dbContext = null)
        {
            PartnerInDB.Remove(this, dbContext);
        }

    }
}
