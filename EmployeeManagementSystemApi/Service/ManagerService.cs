using EmployeeManagementSystemApi.Controllers;
using EmployeeManagementSystemApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystemApi.Service
{
    public class ManagerService : IManagerService
    {
        IEmployeeService _employeeService;

        public ManagerService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IEnumerable<Employee> GetAllManagers()
        {
            var managers = new List<Employee>();
            var employees = _employeeService.GetAllEmployees();

            var managerIds = _employeeService.GetAllManagerIds();

            foreach (var managerId in managerIds)
            {
                foreach (var employee in employees)
                {
                    if (managerId == employee.Id)
                    {
                        managers.Add(employee);
                        break;
                    }
                }
            }
            return managers;

        }
        public IEnumerable<Employee> GetManagerById(int managerId)
        {
            var managerIds = _employeeService.GetAllManagerIds();
            var employees = _employeeService.GetAllEmployees();
            if (managerIds.Contains(managerId))
                return employees.Where(employee => employee.Id == managerId).ToList();
            else
                throw new ManagerIdNotValidException("Manager Id is not valid");
        }
    }
}
