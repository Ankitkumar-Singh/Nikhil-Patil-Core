using System.Collections.Generic;
using Test.Models;

namespace Test.RepositoryInterfaces
{
    public interface IEmployeeRepository
    {
        /// <summary>Gets all employees.</summary>
        IEnumerable<Employee> GetAllEmployees();

        /// <summary>Gets the employee.</summary>
        /// <param name="id">The identifier.</param>
        Employee GetEmployee(int? id);

        /// <summary>Creates the employee.</summary>
        /// <param name="employee">The employee.</param>
        Employee SaveEmployee(Employee employee);

        /// <summary>Deletes the employee.</summary>
        /// <param name="id">The identifier.</param>
        Employee DeleteEmployee(int? id);
    }
}
