using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Employee
    {
        public long EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public string Department { get; set; }

        public string MailID { get; set; }

        public DateTime? Dob { get; set; }

    }
}
