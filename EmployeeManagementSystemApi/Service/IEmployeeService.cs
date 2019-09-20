using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagementSystemApi.Model;
using Microsoft.Extensions.Caching.Distributed;

namespace EmployeeManagementSystemApi.Service
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        void DeleteEmployee(long id);
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Employee> GetAllEmployees(int pageNumber, int pageSize);
        List<long> GetAllManagerIds();
        Task<Employee> GetEmployeeByEmployeeId(IDistributedCache cache, long employeeId);
        IEnumerable<Employee> GetEmployeesByManagerId(int managerId);
    }
}