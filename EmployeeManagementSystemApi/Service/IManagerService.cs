using System.Collections.Generic;
using EmployeeManagementSystemApi.Model;

namespace EmployeeManagementSystemApi.Service
{
    public interface IManagerService
    {
        IEnumerable<Employee> GetAllManagers();
        IEnumerable<Employee> GetManagerById(int managerId);
    }
}