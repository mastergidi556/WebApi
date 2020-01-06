using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class DepartmentService
    {
        private readonly WebApiContext _context;
        public DepartmentService(WebApiContext context)
        {
            _context = context;
        }
        public long DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public List<Department> Get()
        {
            var departments = from d in _context.Department select d;
            return departments.ToList();
        }

        public void Create(Department department)
        {
            _context.Department.Add(department);
            _context.SaveChanges();
        }

        public Department Get(long id)
        {
            var department = _context.Department.FirstOrDefault<Department>(d => d.DepartmentID == id);
            return department;
        }

        public void Update(long id, Department department)
        {
            var d = this.Get(id);

            if(department.DepartmentName != null)
            {
                d.DepartmentName = department.DepartmentName;

            }
            _context.SaveChanges();
            
        }

        public void Delete(long id)
        {
            var department = this.Get(id);
            _context.Department.Remove(department);
            _context.SaveChanges();
        }
    }
}
