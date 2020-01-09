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
        [Required]
        public long EmployeeID { get; set; }
        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string MailID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Dob { get; set; }

    }
}
