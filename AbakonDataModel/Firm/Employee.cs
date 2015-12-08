using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbakonDataModel.Interfaces;
using AbakonDataModel.DataAccess;

namespace AbakonDataModel
{
    public class Employee : IUpdateSignature
    {
        public Employee()
        {
            LabEmployee = false;
            EmployedFrom = DateTime.Today; ;
            EmployedTo = new DateTime(2050, 12, 31);
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public int PersonId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime EmployedFrom { get; set; }
        public DateTime? EmployedTo { get; set; }
        public bool LabEmployee { get; set; }
        #region IUpdateSignature
        public int? ApplicationId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string UserName { get; set; }
        #endregion

        [ForeignKey("PersonId")]
        public virtual Person person { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department department { get; set; }


        public virtual Department manager { get; set; }
        public virtual Department deputyManager { get; set; }

        public static IEnumerable<Person> LoadEmployeePersons(PgSqlDBContext context = null)
        {
            return PersonInDB.LoadEmployeePersons(context);

        }

        public static Employee Create(Person person, Department department, PgSqlDBContext dbContext = null)
        {
            Employee lastDep = person.employees.OrderByDescending(e => e.EmployedFrom).FirstOrDefault();
            if (lastDep != null)
            {
                lastDep.EmployedTo = DateTime.Today.AddDays(-1);
            }
            Employee newEmployee = new Employee();
            newEmployee.person = person;
            newEmployee.department = department;
            newEmployee.EmployedFrom = DateTime.Today;
            person.employees.Add(newEmployee);
            PersonInDB.SaveChanges(dbContext);
            //  PersonInDB.AddEmployeeToContext(newEmployee, dbContext);
            return newEmployee;
        }

        public static void LoadDepartmentEmployee(Department CurrentDepartment)
        {
            throw new NotImplementedException();
        }

        public void Delete(PgSqlDBContext dbContext = null)
        {
            PersonInDB.DeleteEmployee(this, dbContext);
        }
    }
}
