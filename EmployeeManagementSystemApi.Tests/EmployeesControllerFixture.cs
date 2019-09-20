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
            int expected = EmployeeDb.employees.Count;

            var employeeController = new EmployeesController();
            var result = employeeController.GetAllEmployees().Count();

            Assert.Equal(expected, result);
        
        }
        [Fact]
        public void GetEmployeesByManagerId_ShouldReturnAllEmployeesUnderTheGivenManager()
        {
            int expected = 3;

            var employeeController = new EmployeesController();
            var result = employeeController.GetEmployeesByManagerId(2);

            Assert.Equal(expected, result);
        }
    }
}
