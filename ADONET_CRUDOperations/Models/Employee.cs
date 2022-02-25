using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADONET_CRUDOperations.Models
{
    public class Employee
    {
        [Key]
        public int tEmpID { get; set; }

        [Required(ErrorMessage = "Enter Employee ID")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Enter Employee Name")]
        public string EmpName { get; set; }
        
        [Required(ErrorMessage = "Enter Employee Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Employee Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter Employee CNIC")]
        public string CNIC { get; set; }

        [Required(ErrorMessage = "Enter Employee Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Select Current Status ")]
        public string Status { get; set; }


        [Required(ErrorMessage = "Select Value ")]
        public string isActive { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        public List<Employee> ShowAllEmployee { get; set; }
    }
}