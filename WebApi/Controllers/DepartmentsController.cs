using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentService _service;

        public DepartmentsController(DepartmentService service)
        {
            _service = service;
        }
        // GET: api/Departments
        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            var data = _service.Get();
            if(data.Count == 0)
            {
                return NotFound(new { message = "Nothing returned"});
            }
            return Ok(data);
        }

        // GET: api/Departments/5
        [HttpGet("{id}", Name = "getdepartment")]
        public  ActionResult<Department> Get(int id)
        {
            var data = _service.Get(id);
            if (data == null)
            {
                return NotFound(new { message = "Nothing returned" });
            }
            return Ok(data);
        }

        // POST: api/Departments
        [HttpPost]
        public ActionResult Post([Bind("DepartmentID, DepartmentName")] Department department)
        {
            if(!ModelState.IsValid)
            {
                return NotFound(new { message = "Department not added" });
            }

            _service.Create(department);
            return Ok(new { message = "Department was sucessfully created" });
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [Bind("DepartmentID, DepartmentName")] Department department)
        {
            if(!ModelState.IsValid)
            {
                return NotFound(new { message = "Update Unsuccessful" });
            }
            _service.Update(id, department);
            return Ok(new { message = "Department was sucessfully updated" });
        }
    

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var data = _service.Get(id);
            if (data == null)
            {
                return NotFound(new { message = "Department not found" });
            }
            _service.Delete(id);
            return Ok(new { message = "Department was sucessfully deleted" });
        }
    }
}
