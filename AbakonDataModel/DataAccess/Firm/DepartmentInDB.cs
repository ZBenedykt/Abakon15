using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AbakonDataModel.DataAccess
{
    class DepartmentInDB : DataAccessBaseClass
    {
        internal static IEnumerable<Department> Load(PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            var qry = mContext.DepartmentDbSet.Where(d => d.ParentDepartment == null).OrderBy(p => p.DepartmentCode);
            foreach (Department item in qry)
            {
                //   if (item.active && (item.NeedPrivilege == "" || RegisteredUser.CurrentUser.hasReadPrivilege(item.NeedPrivilege)))
                {
                    yield return item;
                }
            }
        }

        internal static void AddToContext(Department newRec, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.DepartmentDbSet.Add(newRec);
            SaveChanges(mContext);
        }


        internal static void Delete(Department department, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.DepartmentDbSet.Remove(department);
            SaveChanges(mContext);
        }

        internal static Department GetDepartment(int xGuid, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            return mContext.DepartmentDbSet.Find(xGuid);
        }

        internal static List<int> GetGuidList(int? initGuid, bool recursive)
        {
            List<int> result = new List<int>();
            if (initGuid == null)
            {
                var r = defaultContext.DepartmentDbSet.Select(p => p.DepartmentId);
                foreach (var item in r)
                {
                    {
                        result.Add(item);
                    }
                }
            }
            else
            {
                var tempQry = defaultContext.DepartmentDbSet.Select(p => new { p.DepartmentId, p.ParentDepartmentId });
                List<Tuple<int, int?>> tempList = new List<Tuple<int, int?>>();
                foreach (var item in tempQry)
                {
                    tempList.Add(new Tuple<int, int?>(item.DepartmentId, item.ParentDepartmentId));
                }

                var x = tempQry.First(p => p.DepartmentId == initGuid);
                if (x != null) result.Add(x.DepartmentId);

                if (recursive)
                {
                    List<int> parents = new List<int>();
                    parents.AddRange(tempList.Where(p => p.Item2.HasValue && p.Item2.Value == x.DepartmentId).Select(p => p.Item2.Value));
                    List<int> children = GetChildren(tempList, parents);
                    while (children.Any())
                    {
                        foreach (int item in children)
                        {
                            result.Add(item);
                        }
                        children = GetChildren(tempList, children);
                    }
                }
            }

            return result;
        }

        static List<int> GetChildren(List<Tuple<int, int?>> pair, List<int> parents)
        {
            List<int> result = new List<int>();
            foreach (var item in pair.Where(p => p.Item2.HasValue && parents.Contains(p.Item2.Value)))
            {
                result.Add(item.Item1);
            }
            return result;
        }
    }
}
