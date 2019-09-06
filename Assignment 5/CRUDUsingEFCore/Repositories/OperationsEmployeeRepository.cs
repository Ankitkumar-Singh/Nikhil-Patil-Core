using System.Collections.Generic;
using System.Linq;
using CRUDUsingEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDUsingEFCore.Repositories
{
    public class OperationsEmployeeRepository : IEmployeeRepository
    {
        #region Variable declarations
        private readonly AppDbContext context;
        #endregion

        #region Constructor
        public OperationsEmployeeRepository(AppDbContext context) => this.context = context;
        #endregion

        #region Display all employee
        /// <summary>Gets all employees.</summary>
        public IEnumerable<Employee> GetAllEmployees() => context.Employee.Include(e => e.Department).ToList();
        #endregion

        #region Display single employee details
        /// <summary>Gets the employee.</summary>
        /// <param name="id">The identifier.</param>
        public Employee GetEmployee(int? id) => context.Employee.Include(e => e.Department).Where(e => e.Id == id).SingleOrDefault();
        #endregion

        #region Save employee method
        /// <summary>Creates the employee.</summary>
        /// <param name="employee">The employee.</param>
        public Employee SaveEmployee(Employee employee)
        {
            if (employee != null)
            {
                if (employee.Id == 0)
                    context.Add(employee);
                else
                {
                    var emp = context.Employee.Where(e => e.Id == employee.Id)?.SingleOrDefault();
                    if (emp != null)
                    {
                        emp.Name = employee.Name;
                        emp.Gender = employee.Gender;
                        emp.City = employee.City;
                        emp.Email = employee.Email;
                        emp.DepartmentId = employee.DepartmentId;
                    }
                }

                context.SaveChanges();
            }

            return employee;
        }
        #endregion

        #region Delete employee method
        /// <summary>Deletes the employee.</summary>
        /// <param name="id">The identifier.</param>
        public Employee DeleteEmployee(int? id)
        {
            Employee employee = context.Employee.Include(e => e.Department).Where(e => e.Id == id).SingleOrDefault();

            if (employee != null)
                context.Employee.Remove(employee);

            return employee;
        }
        #endregion
    }
}
