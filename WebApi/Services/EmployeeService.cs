using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;


namespace WebApi.Services
{
    public class EmployeeService
    {
        private readonly WebApiContext _context;
        public EmployeeService(WebApiContext context)
        {
            _context = context;
        }

        public List<Employee> Get()
        {
            var employee = from d in _context.Employee select d;
            return employee.ToList();
        }

        public void Create(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
        }

        public Employee Get(long id)
        {
            var employee = _context.Employee.FirstOrDefault<Employee>(e => e.EmployeeID == id);
            return employee;
        }

        public void Update(long id, Employee employee)
        {
            var e = this.Get(id);
          

            if(employee.EmployeeName != null)
            {
                e.EmployeeName = employee.EmployeeName;
            }
            if(employee.Department !=null)
            {
                e.Department = employee.Department;
            }
            if (employee.MailID != null)
            {
                e.MailID = employee.MailID;
            }
            if (employee.Dob != null)
            {
                e.Dob = employee.Dob;
            }

            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var employee = this.Get(id);
            _context.Employee.Remove(employee);
        }

    }
}
