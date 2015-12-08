using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbakonDataModel.DataAccess
{
    class DocumentClassificationPatternInDB : DataAccessBaseClass
    {
        internal static IEnumerable<DocumentClassificationPattern> LoadRoots(PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            var qry = mContext.DocumentClassificationPaternDbSet.Where(d => !d.dcpParentId.HasValue);
            foreach (DocumentClassificationPattern item in qry)
            {
                {
                    yield return item;
                }
            }
        }

        internal static void AddToContext(DocumentClassificationPattern newRec, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.DocumentClassificationPaternDbSet.Add(newRec);
            SaveChanges(mContext);
        }

        internal static DocumentClassificationPattern GetDocumentClassificationPattern(int xId, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            return mContext.DocumentClassificationPaternDbSet.Find(xId);
        }

        internal static void Delete(DocumentClassificationPattern documentClassificationPattern, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.DocumentClassificationPaternDbSet.Remove(documentClassificationPattern);
            SaveChanges(mContext);
        }

        internal static DocumentClassificationPattern GetDocumentClassificationPattern(PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            return mContext.DocumentClassificationPaternDbSet.FirstOrDefault(p => p.dcpDefault == true);
        }
    }
}
