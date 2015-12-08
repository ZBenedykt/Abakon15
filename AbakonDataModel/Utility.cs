using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace AbakonDataModel
{
    //https://code.msdn.microsoft.com/How-to-undo-the-changes-in-00aed3c4


    public static class DataModelUtility
    {
        public static PgSqlDBContext defaultContext = AbakonDataModel.DataAccess.DataAccessBaseClass.defaultContext;

        public static bool DbContextHasChanges(PgSqlDBContext dbContext = null)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            return mContext.ChangeTracker.HasChanges();
        }


        public static void UndoChangesOfDbContext(PgSqlDBContext dbContext = null)
        {

            PgSqlDBContext mContext = dbContext ?? defaultContext;
            if (mContext.ChangeTracker.HasChanges())
            {
                foreach (DbEntityEntry entry in mContext.ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        // Under the covers, changing the state of an entity from  
                        // Modified to Unchanged first sets the values of all  
                        // properties to the original values that were read from  
                        // the database when it was queried, and then marks the  
                        // entity as Unchanged. This will also reject changes to  
                        // FK relationships since the original value of the FK  
                        // will be restored. 
                        case EntityState.Modified:
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                        // If the EntityState is the Deleted, reload the date from the database.   
                        case EntityState.Deleted:
                            entry.Reload();
                            break;
                        default: break;
                    }
                }
            }
        }

        public static void UndoChangesOfEntity<T>(PgSqlDBContext dbContext = null) where T : class
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            foreach (DbEntityEntry<T> entry in mContext.ChangeTracker.Entries<T>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    default: break;


                }
            }
        }

        public static void UndoChangesOfEntry<T>(T entity, PgSqlDBContext dbContext = null) where T : class
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            DbEntityEntry entry = mContext.Entry(entity);
            if (entry != null)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    default: break;
                }
            }
        }

        public static void UndoChangesOfProperty<T>(T entity, string propertyName, PgSqlDBContext dbContext = null) where T : class
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            DbEntityEntry entry = mContext.Entry(entity);
            if (entry.State == EntityState.Added || entry.State == EntityState.Detached)
            {
                return;
            }

            // Get and Set the Property value by the Property Name. 
            object propertyValue = entry.OriginalValues.GetValue<object>(propertyName);
            entry.Property(propertyName).CurrentValue = entry.Property(propertyName).OriginalValue;
        }
    }
}
