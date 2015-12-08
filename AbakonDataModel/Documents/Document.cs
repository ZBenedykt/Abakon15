using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbakonDataModel.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.IO;
using AbakonDataModel.DataAccess;

namespace AbakonDataModel
{
    [Table("Document")]
    public class Document : IUpdateSignature //, IInfoFile
    {
        public Document()
        {
            folder = false;
            active = true;
            collateVersions = true;
            partners = new ObservableCollection<Partner>();
       
        }


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int docId { get; set; }
        [DefaultValue(0)]
        public int LevelOfSecurity { get; set; }
        public bool folder { get; set; }
        public int documentClassificationPatternId { get; set; }
        public int FilePathId { get; set; }
        public string FileName { get; set; }
        public bool active { get; set; }
        public int fromDocument { get; set; }
        public bool collateVersions { get; set; }
        public int version { get; set; }
        public int userLibraryId { get; set; }
        [MaxLength(8)]
        public string docCode { get; set; }
        [MaxLength(180)]
        public string docSignature { get; set; }
        public string docDescription { get; set; }
        public byte[] docImage { get; set; }
        [MaxLength(80)]
        public string docPrimaryComputer { get; set; }
        //   public InfoFile infoFile { get; set; }
        #region IUpdateSignature
        public int? ApplicationId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string UserName { get; set; }
        #endregion

        [NotMapped]
        public int? TagPartner { get; set; }
        [ForeignKey("documentClassificationPatternId")]
        public virtual DocumentClassificationPattern documentClassificationPattern { get; set; }
        [ForeignKey("FilePathId")]
        public virtual FilePath filePath { get; set; }


       
        public virtual ICollection<Partner> partners { get; set; }
  

        //============================================================================================

        private bool isCheckPrivilege = false;
        private string _NeedPrivilege = "";
        public string NeedPrivilege
        {
            get
            {
                if (!isCheckPrivilege)
                {
                    _NeedPrivilege = DocumentClassificationPattern.GetDocumentClassificationPattern(this.documentClassificationPatternId) == null ? "" : ""; //todo DocumentClassificationPattern.GetPattern(this.documentClassificationPatternId).NeedPrivilege;
                    isCheckPrivilege = true;
                }
                return _NeedPrivilege;
            }
        }

        public static Document Create(DocumentClassificationPattern patern)
        {
            Document newDocument = new Document();
            try
            {
                newDocument.docCode = GetCodeOfLastDocument();
                newDocument.documentClassificationPatternId = patern.dcpId;
                //   DocumentInDB.AddToContext(newDocument);
            }
            catch (Exception)
            {
            }
            return newDocument;
        }



        public static Document Create(int classfier)
        {
            Document newDocument = new Document();
            try
            {
                newDocument.docCode = GetCodeOfLastDocument();
                newDocument.documentClassificationPatternId = classfier;
                //   DocumentInDB.AddToContext(newDocument);
            }
            catch (Exception)
            {
            }
            return newDocument;
        }



        public void ConnectToPartnerAndPattern(Partner partner, DocumentClassificationPattern patern)
        {
            this.documentClassificationPatternId = patern.dcpId;
            //      DocumentInDB.ConnectDocumentToPartner(this, partner);
        }




        public string MainClassificationPath
        {
            get
            {
                var pattern = DocumentClassificationPattern.GetDocumentClassificationPattern(this.documentClassificationPatternId);
                return pattern == null ? "_missingPattern".Translate() : "--------------"; //todo pattern.ClassificationPath;
            }
        }


        public void SaveToDb(PgSqlDBContext dbContext = null)
        {
            DocumentInDB.SaveToDB(dbContext);
        }


        internal static string GetCodeOfLastDocument()
        {

            string code = DocumentInDB.GetCodeOfLastDocument();
            string[] codeElems = { string.Empty, string.Empty };
            Match m = Regex.Match(code, @"([A-Z]*)(\d{4})");

            codeElems[0] = m.Groups[1].Value;
            codeElems[1] = m.Groups[2].Value;

            if (codeElems[0].Trim() == string.Empty)
            {
                codeElems[0] = "A";
                if (codeElems[1].Trim() == string.Empty) codeElems[1] = "0001";
                return codeElems[0] + codeElems[1];
            }

            int numPart = int.Parse(codeElems[1]);
            if (numPart < 9999)
            {
                numPart++;
            }
            else
            {
                numPart = 1;
                codeElems[0] = GetNextCode(codeElems[0]);

            }
            codeElems[1] = numPart.ToString("0000");

            return codeElems[0] + codeElems[1];
        }
        private static string GetNextCode(string code)
        {
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'W', 'X', 'Y', 'Z' };
            string result = string.Empty;
            bool trans = false;
            int b = letters.Length;
            char currChar;
            int currCharPosition;

            for (int i = code.Length - 1; i >= 0; i--)
            {
                currChar = code[i];
                currCharPosition = Array.IndexOf(letters, currChar);
                if (currCharPosition < b - 1)
                {
                    currChar = letters[currCharPosition + 1];
                    result = currChar + result;
                    for (int k = i - 1; k >= 0; k--)
                    {
                        result = code[k] + result;
                    }
                    trans = false;
                    break;
                }
                else
                {
                    currChar = letters[0];
                    result = currChar + result;
                    trans = true;
                }
            }
            if (trans) result = letters[0] + result;
            return result;
        }

        public static void ChangeDocumentPattern(int oldPatternId, int newPatternId)
        {
            throw new NotImplementedException();
        }



        public event EventHandler RelocatedFolder;

        public void RaiseRelocatedFolder()
        {
            OnRaiseRelocatedFolder(new EventArgs());
        }

        protected virtual void OnRaiseRelocatedFolder(EventArgs e)
        {
            EventHandler handler = RelocatedFolder;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        public static IEnumerable<Document> Load(System.Linq.Expressions.Expression<Func<Document, bool>> predicate, PgSqlDBContext dbContext = null)
        {
            return DocumentInDB.Load(predicate, dbContext);

        }


   
        public static Document Create(FilePath CurrentFilePath, string fileName, Partner partner, DocumentClassificationPattern dcp = null, PgSqlDBContext dbContext = null)
        {
            Document newDocument = null;
            DocumentClassificationPattern docClassifier = dcp == null ? DocumentClassificationPattern.GetDefaultDocumentClassificationPattern() : dcp;
            if (docClassifier != null)
            {
                newDocument = Create(docClassifier.dcpId);
                newDocument.docCode = GetCodeOfLastDocument();
                newDocument.filePath = CurrentFilePath;
                newDocument.FileName = fileName;
                DocumentInDB.AddToContext(newDocument, dbContext);
                if (partner != null)
                {
                    newDocument.partners.Add(partner);
                }

            }
            return newDocument;
        }

        public void Remove(PgSqlDBContext dbContext = null)
        {
            DocumentInDB.Remove(this, dbContext);
        }


        public static void Clear(List<Document> deletedFiles, PgSqlDBContext dbContext = null)
        {
            DocumentInDB.Clear(deletedFiles, dbContext);
        }


    }
}
