using EmployeeManagementSystemApi.Controllers;
using EmployeeManagementSystemApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EmployeeManagementSystemApi.Tests
{
    public class EmployeesControllerFixture
    {
        [Fact]
        public void GetAllEmployees_ShouldReturnAllEmployees()
        {
            IEnumerable<Employee> expected = new List<Employee>()
            {
            new Employee(){EmployeeId=1,Name="Prakhar",Salary=600000,Age=21},
            new Employee(){EmployeeId=2,Name="Rahul",Salary=600000,Age=23,ManagerId=1},
            new Employee(){EmployeeId=3,Name="Raunak",Salary=300000,Age=20,ManagerId=2},
            new Employee(){EmployeeId=4,Name="Deepak",Salary=300000,Age=20,ManagerId=2},
            new Employee(){EmployeeId=5,Name="Rohit",Salary=300000,Age=20,ManagerId=2}
            };

            var employeeController = new EmployeesController();
            var result = employeeController.GetAllEmployees();

            Assert.Equal(expected, result);
        
        }
        [Fact]
        public void GetEmployeesByManagerId_ShouldReturn()
        {

        }
    }
}
