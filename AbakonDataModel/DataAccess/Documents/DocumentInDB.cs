using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbakonDataModel.DataAccess
{
    class DocumentInDB : DataAccessBaseClass
    {
        internal static void AddToContext(Document newRec, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.DocumentDbSet.Add(newRec);

            SaveChanges(mContext);
        }

        internal static IEnumerable<Document> Load(System.Linq.Expressions.Expression<Func<Document, bool>> predicate, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            var qry = mContext.DocumentDbSet.Where(predicate);
            foreach (Document item in qry)
            {
                {
                    yield return item;
                }
            }
        }

        internal static void Delete(Document filePath, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.DocumentDbSet.Remove(filePath);
            SaveChanges(mContext);
        }



        internal static string GetCodeOfLastDocument()
        {
            PgSqlDBContext mContext = defaultContext;
            Document lastDoc = mContext.DocumentDbSet.OrderByDescending(p => p.CreateDate).FirstOrDefault();
            if (lastDoc != null)
            {
                return lastDoc.docCode;

            }
            else
            {
                return "";
            }
        }

        internal static void Remove(Document document, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.DocumentDbSet.Remove(document);
            mContext.SaveChanges();
        }

        internal static void Clear(List<Document> deletedFiles, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.DocumentDbSet.RemoveRange(deletedFiles);
            mContext.SaveChanges();
        }

        internal static void SaveToDB(PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = defaultContext;
            mContext.SaveChanges();
        }
    }
}
