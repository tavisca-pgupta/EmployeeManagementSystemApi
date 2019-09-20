using EmployeeManagementSystemApi.Cache;
using EmployeeManagementSystemApi.Controllers;
using EmployeeManagementSystemApi.Model;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystemApi.Service
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
        public IEnumerable<Employee> GetAllEmployees(int pageNumber, int pageSize)
        {
            return _context.Employees.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
        }


        public IEnumerable<Employee> GetEmployeesByManagerId(int managerId)
        {
            var managerIds = GetAllManagerIds();
            if (managerIds.Contains(managerId))
                return GetAllEmployees().Where(employee => employee.ManagerId == managerId).ToList();
            else
                throw new Exception("Manager ID is not valid");
        }
        public void AddEmployee(Employee employee)
        {
            
             _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public async Task<Employee> GetEmployeeByEmployeeId(IDistributedCache cache,long employeeId)
        {
            Employee emp = _context.Employees.Find(employeeId);
            if (emp == null)                                                
                throw new EmployeeNotFoundException("Employee not found");
            else
            {
                await RedisCache.SetObjectAsync<Employee>(cache,$"employees-{employeeId}",emp);
                return emp;
            }             
        }

        public List<long> GetAllManagerIds()
        {
            return GetAllEmployees().Select(employee => employee.ManagerId).Distinct().ToList();
        }

        public void DeleteEmployee(long id)
        {
            Employee emp = _context.Employees.Find(id);
            if (emp == null)
                throw new EmployeeNotFoundException("Employee not found");
            else
            {
                if (!GetAllManagerIds().Contains(id))
                {
                    _context.Employees.Remove(emp);
                    _context.SaveChanges();
                }
                else
                    throw new EmployeeIsAManagerOfOtherEmployeesException("Employee is a manager of other employees!!");
            }
        } 
    }
}
