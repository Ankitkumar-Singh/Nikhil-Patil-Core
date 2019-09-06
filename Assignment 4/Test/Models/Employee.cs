using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public enum Department
    {
        SALES,
        FINANCE,
        ENGINEERING,
        MARKETING
    }
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public Department Department { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public bool TermsAndConditions { get; set; }
    }
}
