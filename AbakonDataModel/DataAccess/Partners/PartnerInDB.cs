using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbakonDataModel.DataAccess
{
    class PartnerInDB : DataAccessBaseClass
    {
        internal static void AddToContext(Partner newRec, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.PartnerDbSet.Add(newRec);

        }

        internal static IEnumerable<Partner> Load(System.Linq.Expressions.Expression<Func<Partner, bool>> predicate, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            var qry = mContext.PartnerDbSet.Where(predicate);
            foreach (var item in qry)
            {
                yield return item;
            }
        }

        internal static void Remove(Partner partner, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.PartnerDbSet.Remove(partner);
        }

    }
}
