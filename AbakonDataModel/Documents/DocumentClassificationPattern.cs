using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AbakonDataModel.Utility;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AbakonDataModel.LangKeys;
using AbakonDataModel.Interfaces;
using AbakonDataModel.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace AbakonDataModel
{
    [Table("DocumentClassificationPattern")]
    public class DocumentClassificationPattern : IUpdateSignature, IDataErrorInfo, IValidatableObject
    {
        #region DB region
        public DocumentClassificationPattern()
        {
            dcChildren = new SortableObservableCollection<DocumentClassificationPattern>();
            documents = new ObservableCollection<Document>();
            dcpActive = true;
            dcpLeaf = true;
        }

        public DocumentClassificationPattern(DocumentClassificationPattern _parent)
            : base()
        {
            this.parent = _parent;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int dcpId { get; set; }
        public int? dcpParentId { get; set; }
        public int? dcpSequenceNumber { get; set; }
        [MaxLength(60, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth60")]
        public string dcpName { get; set; }
        public bool dcpLeaf { get; set; }
        public bool dcpActive { get; set; }
        public bool? dcpForEquipmnet { get; set; }
        public bool? dcpForPerson { get; set; }
        public bool? dcpForPartner { get; set; }
        public bool? dcpForStandard { get; set; }
        public bool? dcpForProduct { get; set; }
        public bool? dcpForTask { get; set; }
        public bool dcpDefault { get; set; }
        [RegularExpression(@"^[a-z,A-Z,\d]*$", ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errRegexNoMatched")]
        public string dcpPrivilage { get; set; }
        public bool isRoot
        {
            get
            {
                return !dcpParentId.HasValue;
            }
        }

        [NotMapped]
        public bool dcpActivePath
        {
            get
            {
                if (parent != null)
                {
                    return dcpActive && parent.dcpActivePath;
                }
                else
                {
                    return dcpActive;
                }
            }
            set { }
        }

        #region IUpdateSignature
        public int? ApplicationId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string UserName { get; set; }
        #endregion

        [ForeignKey("dcpParentId")]
        public virtual SortableObservableCollection<DocumentClassificationPattern> dcChildren { get; set; }

        [ForeignKey("dcpParentId")]
        public virtual DocumentClassificationPattern parent { get; set; }
        public virtual ICollection<Document> documents { get; set; }

        #endregion


        string _ClassificationPath = "";
        [NotMapped]
        public string ClassificationPath
        {
            get
            {
                if (_ClassificationPath == "")
                {
                    _ClassificationPath = CountClassificationPath();
                }
                return _ClassificationPath;
            }
            set
            {
                _ClassificationPath = value;
            }
        }

        private string CountClassificationPath()
        {
            DocumentClassificationPattern rr = this;
            List<string> names = new List<string>();
            while (rr != null)
            {
                names.Add(rr.dcpName);
                if (rr.parent != null)
                {
                    rr = rr.parent;
                }
                else
                {
                    break;
                }
            }
            names.Reverse();
            return string.Join("/", names);
        }

        #region IDataErrorInfo Members ==========================================================================

        public string Error
        {
            get
            {
                return dcpId.ToString();
            }
        }

        public string this[string columnName]
        {
            get
            {
                var results = new List<ValidationResult>();


                switch (columnName)
                {
                    case "dcpName":

                        if (!Validator.TryValidateProperty(this.dcpName,
                                     new ValidationContext(this, null, null) { MemberName = columnName }, results))
                            return results[0].ErrorMessage;
                        ClassificationPath = CountClassificationPath();

                        break;
                    case "dcpPrivilage":

                        if (!Validator.TryValidateProperty(this.dcpPrivilage,
                                     new ValidationContext(this, null, null) { MemberName = columnName }, results))
                            return results[0].ErrorMessage;
                        break;
                    default:
                        break;

                }

                return string.Empty;
            }
        }


        #endregion

        #region IValidatableObject Members

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();


            return results;
        }
        public bool IsValid
        {
            get
            {
                return true; //todo ProductClassificationInDB.IsValid(this);
            }
        }

        #endregion


        //=======================================================================================================================

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
            DocumentClassificationPattern rr = this;
            List<string> names = new List<string>();
            while (rr != null)
            {
                names.Add(rr.dcpName);
                if (rr.parent != null)
                {
                    rr = rr.parent;
                }
                else
                {
                    break;
                }
            }
            names.Reverse();
            return string.Join("/" + System.Environment.NewLine, names);
        }


        DocumentClassifierForEntitiesEnum _documentClassifierForEntities = DocumentClassifierForEntitiesEnum.unspecified;
        [NotMapped]
        public DocumentClassifierForEntitiesEnum DocumentClassifierForEntities
        {
            get
            {
                //if (_documentClassifierForEntities == DocumentClassifierForEntitiesEnum.unspecified)
                {
                    _documentClassifierForEntities = 0;
                    DocumentClassificationPattern rr = this;
                    while (rr.dcpParentId.HasValue)
                    {
                        if (GetDocumentClassificationPattern(rr.dcpParentId.Value) == null) break;
                        rr = GetDocumentClassificationPattern(rr.dcpParentId.Value);
                    }
                    if (rr.dcpForEquipmnet.HasValue && rr.dcpForEquipmnet.Value) _documentClassifierForEntities = _documentClassifierForEntities | DocumentClassifierForEntitiesEnum.forEquipment;
                    if (rr.dcpForPerson.HasValue && rr.dcpForPerson.Value) _documentClassifierForEntities = _documentClassifierForEntities | DocumentClassifierForEntitiesEnum.forPerson;
                    if (rr.dcpForPartner.HasValue && rr.dcpForPartner.Value) _documentClassifierForEntities = _documentClassifierForEntities | DocumentClassifierForEntitiesEnum.forPartner;
                    if (rr.dcpForStandard.HasValue && rr.dcpForStandard.Value) _documentClassifierForEntities = _documentClassifierForEntities | DocumentClassifierForEntitiesEnum.forStandard;
                    if (rr.dcpForProduct.HasValue && rr.dcpForProduct.Value) _documentClassifierForEntities = _documentClassifierForEntities | DocumentClassifierForEntitiesEnum.forProduct;
                    if (rr.dcpForTask.HasValue && rr.dcpForTask.Value) _documentClassifierForEntities = _documentClassifierForEntities | DocumentClassifierForEntitiesEnum.forTask;
                }
                return _documentClassifierForEntities;
            }
        }

        //=================================================================================================

        public static IEnumerable<DocumentClassificationPattern> LoadRoots(PgSqlDBContext dbContext = null)
        {
            return DocumentClassificationPatternInDB.LoadRoots(dbContext);
        }

        public void Delete(PgSqlDBContext dbContext = null)
        {
            DocumentClassificationPatternInDB.Delete(this, dbContext);
        }

        public static DocumentClassificationPattern Create(DocumentClassificationPattern parent = null, PgSqlDBContext dbContext = null)
        {
            DocumentClassificationPattern newRec = parent == null ? new DocumentClassificationPattern() : new DocumentClassificationPattern(parent);
            DocumentClassificationPatternInDB.AddToContext(newRec, dbContext);
            return newRec;
        }


        public static DocumentClassificationPattern GetDocumentClassificationPattern(int xId, PgSqlDBContext dbContext = null)
        {
            return DocumentClassificationPatternInDB.GetDocumentClassificationPattern(xId, dbContext);
        }

        public static DocumentClassificationPattern GetDefaultDocumentClassificationPattern(PgSqlDBContext dbContext = null)
        {
            return DocumentClassificationPatternInDB.GetDocumentClassificationPattern(dbContext);
        }

    }
}
