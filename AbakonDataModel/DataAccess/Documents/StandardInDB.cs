using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbakonDataModel.DataAccess
{
    class StandardInDB : DataAccessBaseClass
    {
        internal static IEnumerable<Standard> Load(PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            var qry = mContext.StandardDbSet;
            foreach (Standard item in qry)
            {
                {
                    yield return item;
                }
            }
        }

        internal static void Delete(Standard standard, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.StandardDbSet.Remove(standard);
            SaveChanges(mContext);
        }

        internal static void AddToContext(Standard newRec, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.StandardDbSet.Add(newRec);
            SaveChanges(mContext);
        }
    }
}
