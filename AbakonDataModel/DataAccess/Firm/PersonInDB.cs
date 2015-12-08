using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbakonDataModel.DataAccess
{
    class PersonInDB : DataAccessBaseClass
    {
        internal static void AddToContext(Person newRec, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.PersonDbSet.Add(newRec);

        }



        internal static IEnumerable<Person> LoadEmployeePersons(PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            var qry = dbContext.PersonDbSet.Where(p => p.employees.Any());
            foreach (var item in qry)
            {
                yield return item;
            }

        }

        internal static IEnumerable<Person> LoadPersons(System.Linq.Expressions.Expression<Func<Person, bool>> predicate, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            var qry = mContext.PersonDbSet.Where(predicate);
            foreach (var item in qry)
            {
                yield return item;
            }
        }


        internal static void AddEmployeeToContext(Employee newEmployee, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.EmployeeDbSet.Add(newEmployee);

        }

        internal static IEnumerable<Person> LoadLabWorkers(PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            var qry = mContext.PersonDbSet.Where(p => p.labWorker);
            foreach (var item in qry)
            {
                yield return item;
            }
        }



        internal static IEnumerable<Person> LoadEmployee(PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            var qry = mContext.PersonDbSet.Where(p => p.employees.Any(e => e.EmployedTo > DateTime.Today));
            foreach (var item in qry)
            {
                yield return item;
            }
        }

        internal static void Remove(Person person, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.PersonDbSet.Remove(person);
        }

        internal static void DeleteEmployee(Employee employee, PgSqlDBContext dbContext)
        {
            PgSqlDBContext mContext = dbContext ?? defaultContext;
            mContext.EmployeeDbSet.Remove(employee);
        }
    }
}
