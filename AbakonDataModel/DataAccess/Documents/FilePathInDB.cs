using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbakonDataModel.DataAccess
{
    class FilePathInDB : DataAccessBaseClass
    {
        internal static IEnumerable<FilePath> Load(PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            var qry = mContext.FilePathDbSet;
            foreach (FilePath item in qry)
            {
                {
                    yield return item;
                }
            }
        }

        internal static void Delete(FilePath filePath, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.FilePathDbSet.Remove(filePath);
            SaveChanges(mContext);
        }

        internal static void AddToContext(FilePath newRec, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.FilePathDbSet.Add(newRec);

            SaveChanges(mContext);
        }

        internal static FilePath GetFilePath(int id, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            return mContext.FilePathDbSet.Find(id);
        }
    }
}
