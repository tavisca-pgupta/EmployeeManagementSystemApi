using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystemApi.Model;
using EmployeeManagementSystemApi.Service;
using System;
using System.Threading.Tasks;
using EmployeeManagementSystemApi.Cache;
using Microsoft.Extensions.Caching.Distributed;

namespace EmployeeManagementSystemApi.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _employeeService;
        const int maxEmployeesPageSize = 20;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees([FromQuery] int pageNumber=1,[FromQuery] int pageSize=10)
        {
            pageSize = pageSize > maxEmployeesPageSize ? maxEmployeesPageSize : pageSize;
            return Ok(_employeeService.GetAllEmployees(pageNumber,pageSize));
        }

        [HttpGet("{employeeId}",Name = "GetEmployeeByEmployeeId")]
        public async  Task<ActionResult<Employee>> GetEmployeeByEmployeeId(long employeeId)
        {
                try
                {
                    return Ok(await _employeeService.GetEmployeeByEmployeeId(employeeId));
                }
                catch (ManagerIdNotValidException ex)
                {
                    return NotFound(ex.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
        }

        [HttpPost]
        public ActionResult AddEmployee([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeService.AddEmployee(employee);
                    return CreatedAtRoute("GetEmployeeByEmployeeId", new { employeeId = employee.Id }, employee);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest();
           
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                _employeeService.DeleteEmployee(id);
                return NoContent();
            }
            catch(EmployeeIsAManagerOfOtherEmployeesException e)
            {
                return BadRequest(e.Message);
            }
            catch(EmployeeNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
