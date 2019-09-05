using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystemApi.Model;
using System.Linq;

namespace EmployeeManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        List<Employee> employees = EmployeeDb.employees;
        [HttpGet]
        public IEnumerable<Employee> GetAllManagers()
        {
            List<Employee> managers = new List<Employee>();
            var managerIds = employees.Select(employee => employee.ManagerId).ToList().Distinct();
            foreach (var managerId in managerIds)
            {
                foreach (var employee in employees)
                {
                    if (managerId == employee.EmployeeId)
                    {
                        managers.Add(employee);
                    }
                }
            }
            return managers;

        }

        [HttpGet("{managerId}")]
        public ActionResult<IEnumerable<Employee>> GetManagerById(int managerId)
        {
            var managerIds = employees.Select(employee => employee.ManagerId).ToList().Distinct();
            if (managerIds.Contains(managerId))
                return employees.Where(employee => employee.EmployeeId == managerId).ToList();
            return NotFound("Manager Id is not valid");
        }

        // POST api/values
    //    [HttpPost]
        //public void Post([FromBody] string value)
        //{

        //}

        //// PUT api/values/5
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
