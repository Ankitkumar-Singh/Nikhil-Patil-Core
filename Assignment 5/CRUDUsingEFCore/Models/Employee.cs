using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDUsingEFCore.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select your gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select your department")]
        [Display(Name = "Department")]
        public Nullable<int> DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
