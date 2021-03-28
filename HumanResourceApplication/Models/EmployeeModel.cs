using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace HumanResourceApplication.Models
{
    public class EmployeeModel
    {
            [Key]
        public int EmployeeId { get; set; }

        //[Required (ErrorMessage = "Enter Employee Name")]
       // [Display(Name = "Employee Name")]
        public string FirstName { get; set; }
       // [Required(ErrorMessage = "Enter Employee Name")]
      //  [Display(Name = "Employee Name")]
        public string LastName { get; set; }
       // [Required(ErrorMessage = "Enter Employee Name")]
       // [Display(Name = "Employee Name")]
        public string MiddleName { get; set; }
       // [Required(ErrorMessage = "Enter Employee Name")]
       // [Display(Name = "Employee Name")]
        public string Jobtitle { get; set; }
       // [Required(ErrorMessage = "Enter Employee Name")]
       // [Display(Name = "Employee Name")]
        public int EmployeeLevel { get; set; }

        //[Required(ErrorMessage = "Enter Age")]
       // [Range( 20,50)]
        public int Age { get; set; }
        
    }
}
