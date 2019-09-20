using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystemApi.Model;
using System.Linq;
using EmployeeManagementSystemApi.Service;
using System;

namespace EmployeeManagementSystemApi.Controllers
{
    [Route("api/managers")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private IManagerService _managerService;
        private IEmployeeService _employeeService;

        public ManagersController(IManagerService managerService, IEmployeeService employeeService)
        {
            _managerService = managerService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllManagers()
        {
            return Ok(_managerService.GetAllManagers());
        }

        [HttpGet("{managerId}")]
        public ActionResult<IEnumerable<Employee>> GetManagerById(int managerId)
        {
           try
            {
                return Ok(_managerService.GetManagerById(managerId));
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

        [HttpGet("{managerId}/employees")]
        public ActionResult<IEnumerable<Employee>> GetEmployeesByManagerId(int managerId)
        {
            try
            {
                return Ok(_employeeService.GetEmployeesByManagerId(managerId));
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
    }
}
