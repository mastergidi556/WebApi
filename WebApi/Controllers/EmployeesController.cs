using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeesController(EmployeeService service)
        {
            _service = service;
        }
        // GET: api/Employees
        [HttpGet]
        public  ActionResult<IEnumerable<Employee>>  Get()
        {
            var data = _service.Get();
            if (data.Count == 0)
            {
                return NotFound(new { message = "Nothing returned" });
            }
            return Ok(data);
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "getemployee")]
        public ActionResult<Employee> Get(int id)
        {
            var data = _service.Get(id);
            if (data == null)
            {
                return NotFound(new { message = "Nothing returned" });
            }
            return Ok(data);
        }

        // POST: api/Employees
        [HttpPost]
        public ActionResult Post([Bind("EmployeeID, EmployeeName, Department, MailID, Dob")] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(new { message = "Employee not added" });
            }

            _service.Create(employee);
            return Ok(new { message = "Employee was sucessfully created" });
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(new { message = "Update Unsuccessful" });
            }
            _service.Update(id, employee);
            return Ok(new { message = "Employee was sucessfully updated" });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var data = _service.Get(id);
            if (data == null)
            {
                return NotFound(new { message = "Employee not found" });
            }
            _service.Delete(id);
            return Ok(new { message = "Employee was sucessfully deleted" });
        }
    }
}
