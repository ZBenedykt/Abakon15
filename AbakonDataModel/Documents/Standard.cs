using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using AbakonDataModel.Interfaces;
using System.ComponentModel.DataAnnotations;
using AbakonDataModel.LangKeys;
using AbakonDataModel.DataAccess;
using System.ComponentModel;
using System.Collections.ObjectModel;
using AbakonDataModel.Infrastructure;

namespace AbakonDataModel
{
    [Table("Standard")]
    public class Standard : IUpdateSignature, IDataErrorInfo, IValidatableObject
    {
        public Standard()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StandardId { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        [PrintAttribute(PatternName = "#SymbolNormy")]
        public string Name { get; set; }
        public int FilePathId { get; set; }
        [MaxLength(255, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth255")]
        public string FileName { get; set; }
        [MaxLength(255, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth255")]
        [PrintAttribute(PatternName = "#OpisNormy")]
        public string Description { get; set; }
        [MaxLength(255, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth255")]
        [PrintAttribute(PatternName = "#URLAdres")]
        public string URL { get; set; }

        #region IUpdateSignature
        public int? ApplicationId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string UserName { get; set; }
        #endregion

    
        #region IDataErrorInfo Members

        public string Error
        {
            get
            {
                return this.Name.ToString();
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

                    case "Name":

                        Validator.TryValidateProperty(this.Name,
                                      new ValidationContext(this, null, null) { MemberName = columnName }, results);
                        break;
                    case "FileName":

                        Validator.TryValidateProperty(this.FileName,
                                      new ValidationContext(this, null, null) { MemberName = columnName }, results);
                        break;

                    case "Description":

                        Validator.TryValidateProperty(this.Description,
                                      new ValidationContext(this, null, null) { MemberName = columnName }, results);
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

            foreach (var item in results)
            {
                yield return item;
            }
        }

        public bool IsValid
        {
            get
            {
                return StandardInDB.IsValid(this);
            }
        }

        #endregion


        public static IEnumerable<Standard> Load(PgSqlDBContext dbContext = null)
        {
            return StandardInDB.Load(dbContext);
        }

        public void Delete(PgSqlDBContext dbContext = null)
        {
            StandardInDB.Delete(this, dbContext);
        }

        public static Standard Create(PgSqlDBContext dbContext = null)
        {
            Standard newRec = new Standard();
            newRec.Name = "New name";
            newRec.FilePathId = 0;
            StandardInDB.AddToContext(newRec, dbContext);
            return newRec;
        }
    }
}
