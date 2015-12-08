using System;
using System.Collections.Generic;
using System.Text;
using AbakonDataModel.Interfaces;
using AbakonDataModel.LangKeys;
using AbakonDataModel.DataAccess;
using System.ComponentModel;
using System.Collections.ObjectModel;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbakonDataModel
{
    [Table("FilePath")]
    public class FilePath : IUpdateSignature, IDataErrorInfo, IValidatableObject
    {
        public FilePath()
        {
            documents = new ObservableCollection<Document>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilePathId { get; set; }
        [MaxLength(30, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth30")]
        public string Name { get; set; }
        [MaxLength(255, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth255")]
        public string Path { get; set; }
        [MaxLength(255, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth255")]
        public string Description { get; set; }


        #region IUpdateSignature
        public int? ApplicationId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string UserName { get; set; }
        #endregion

        public ICollection<Document> documents { get; set; }

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
                    case "Path":

                        Validator.TryValidateProperty(this.Path,
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
                return FilePathInDB.IsValid(this);
            }
        }

        #endregion


        public static IEnumerable<FilePath> Load(PgSqlDBContext dbContext = null)
        {
            return FilePathInDB.Load(dbContext);
        }

        public void Delete(PgSqlDBContext dbContext = null)
        {
            FilePathInDB.Delete(this, dbContext);
        }

        public static FilePath Create(PgSqlDBContext dbContext = null)
        {
            FilePath newRec = new FilePath();
            newRec.Name = "New path";
            FilePathInDB.AddToContext(newRec, dbContext);
            return newRec;
        }

        public static FilePath GetFilePath(int id, PgSqlDBContext dbContext = null)
        {
            return FilePathInDB.GetFilePath(id, dbContext);
        }
    }
}
