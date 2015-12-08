using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbakonDataModel.DataAccess
{
    class _KeyBoardKeyInDB : DataAccessBaseClass
    {
        internal static IEnumerable<_KeyBoardKey> Load(PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            var qry = mContext._KeyBoardKeyDbSet;
            foreach (_KeyBoardKey item in qry)
            {
                {
                    yield return item;
                }
            }
        }

        internal static _KeyBoardKey AddToContext(_KeyBoardKey newRec, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext._KeyBoardKeyDbSet.Add(newRec);
            return newRec;
        }

        internal static void Delete(_KeyBoardKey delRec, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext._KeyBoardKeyDbSet.Remove(delRec);
            SaveChanges(mContext);
        }
    }
}
