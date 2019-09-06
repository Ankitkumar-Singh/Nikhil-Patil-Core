using System.Collections.Generic;
using System.Linq;
using Test.Models;
using Test.RepositoryInterfaces;

namespace Test.Repositories
{
    public class OperationsEmployeeRepository : IEmployeeRepository
    {
        #region Variable declarations
        /// <summary>The employee list</summary>
        private readonly List<Employee> _employeeList;
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="OperationsEmployeeRepository"/> class.</summary>
        public OperationsEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Nikhil", Gender="Male", Department = Department.ENGINEERING },
                new Employee() { Id = 2, Name = "Punam", Department = Department.ENGINEERING },
                new Employee() { Id = 3, Name = "Ragini", Department = Department.ENGINEERING },
                new Employee() { Id = 4, Name = "Suraj", Department = Department.ENGINEERING }
            };
        }
        #endregion

        #region Display all employee
        /// <summary>Gets all employees.</summary>
        public IEnumerable<Employee> GetAllEmployees() => _employeeList.ToList();
        #endregion

        #region Display single employee details
        /// <summary>Gets the employee.</summary>
        /// <param name="id">The identifier.</param>
        public Employee GetEmployee(int? id) => _employeeList.FirstOrDefault(e => e.Id == id);
        #endregion

        #region Save employee method
        /// <summary>Creates the employee.</summary>
        /// <param name="employee">The employee.</param>
        public Employee SaveEmployee(Employee employee)
        {
            if(employee.Id == 0)
            {
                employee.Id = _employeeList.Max(e => e.Id) + 1;

                if (employee != null)
                    _employeeList.Add(employee);

                return employee;
            }
            else
            {
                Employee emp = _employeeList.Find(e => e.Id == employee.Id);
                if (employee != null)
                {
                    emp.Name = employee.Name;
                    emp.Gender = employee.Gender;
                    emp.Department = employee.Department;
                    emp.Address = employee.Address;
                    emp.TermsAndConditions = employee.TermsAndConditions;
                }
                return emp;
            }
        }
        #endregion

        #region Delete employee method
        /// <summary>Deletes the employee.</summary>
        /// <param name="id">The identifier.</param>
        public Employee DeleteEmployee(int? id)
        {
            Employee employee = _employeeList.Find(e => e.Id == id);

            if (employee != null)
                _employeeList.Remove(employee);

            return employee;
        }
        #endregion
    }
}
