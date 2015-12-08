using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbakonDataModel.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbakonDataModel.LangKeys;

namespace AbakonDataModel
{
    [Table("Address")]
    public class Address : IUpdateSignature
    {
        public Address()
        {
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public int AddressKind { get; set; } //do korespondencji, handlowy, prywatny itp 
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string AddressStreet { get; set; }
        [MaxLength(12, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth12")]
        public string AddressNumber { get; set; }
        [MaxLength(12, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth12")]
        public string AddressPostalCode { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string AddressCity { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string AddressCountry { get; set; }

        #region IUpdateSignature
        public int? ApplicationId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string UserName { get; set; }
        #endregion

        public virtual Partner partner { get; set; }
        public virtual Person person { get; set; }
    }
}
