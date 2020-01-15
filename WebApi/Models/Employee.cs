using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Employee iD is required")]
        public long EmployeeID { get; set; }
        [Required(ErrorMessage = "Employee name is required")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Employee department  is required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Employee email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string MailID { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime? Dob { get; set; }

    }
}
