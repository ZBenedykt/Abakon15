using System;
using System.Linq;
using System.Data.Entity;
using AbakonDataModel.Interfaces;
using System.Data.Entity.Infrastructure;

namespace AbakonDataModel.DataAccess
{
    public class DataAccessBaseClass
    {


        //protected static OmetrisisDbContext mContext = OmetrisisDbContext.GetModelDbContext();
        public static PgSqlDBContext defaultContext = PgSqlDBContext.GetModelDbContext();

        public static void SaveChanges(PgSqlDBContext dbContext = null)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;

            //var errors = mContext.GetValidationErrors();
            //foreach (var item in errors)
            //{
            //    if (item.Entry.State == EntityState.Modified)
            //    {
            //        item.Entry.CurrentValues.SetValues(item.Entry.OriginalValues);
            //    }
            //    item.Entry.State = EntityState.Unchanged;
            //}

            IUpdateSignature updatebleItem;

            int il = mContext.ChangeTracker.Entries().Count();
            int ilmod = mContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).Count();
            int iladd = mContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added).Count();


            foreach (var item in mContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
            {
                updatebleItem = item.Entity as IUpdateSignature;
                if (updatebleItem != null) updatebleItem.UpdatingStamp();

            }
            foreach (var item in mContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            {
                if (item.GetValidationResult().IsValid)
                {
                    updatebleItem = item.Entity as IUpdateSignature;
                    if (updatebleItem != null) updatebleItem.CreatingStamp();
                }
                else
                {
                    item.Reload();
                }
            }

            try
            {
                mContext.SaveChanges();
            }
            catch (DbUpdateException ex) //(DbUpdateConcurrencyException ex)  
            {
                if (ex.GetBaseException().Message.Contains("Violation of PRIMARY KEY constraint 'PK_dbo.StandardKalibracjas'"))
                {
                    string ms = ex.GetBaseException().Message;
                }
                else
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }

            }
            //-2146233087

        }

        internal static bool IsValid(object item, PgSqlDBContext dbContext = null)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            return mContext.Entry(item).GetValidationResult().IsValid;
        }
    }

}
