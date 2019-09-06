using System.Collections.Generic;

namespace CRUDUsingEFCore.Models
{
    public class Department
    {
        public Department()
        {
            this.Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
