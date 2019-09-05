using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystemApi.Model;
using System.Linq;

namespace EmployeeManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
       
        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return EmployeeDb.employees;
        }

        // GET api/values/5
        [HttpGet("{managerId}")]
        public ActionResult<IEnumerable<Employee>> GetEmployeesByManagerId(int managerId)
        {
            var managerIds = EmployeeDb.employees.Select(employee => employee.ManagerId).ToList().Distinct();
            if (managerIds.Contains(managerId))
                return EmployeeDb.employees.Where(employee => employee.ManagerId == managerId).ToList();
            return NotFound("Manager Id is not valid");          
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            EmployeeDb.employees.Add(employee);
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
