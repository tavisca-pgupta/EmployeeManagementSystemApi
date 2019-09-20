using EmployeeManagementSystemApi.Controllers;
using Xunit;
using System.Linq;
using EmployeeManagementSystemApi.Service;
using EmployeeManagementSystemApi.Model;
using FluentAssertions;
using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemApi.Tests
{
    public class EmployeesServiceFixture
    {
        //private IEmployeeService _employeeService = new EmployeeService(new EmployeeContext(new DbContextOptionsBuilder<EmployeeContext>().UseInMemoryDatabase("EmployeeDB").Options));
        

        //[Fact]
        //public void GetAllEmployees_ShouldReturnAllEmployees()
        //{
        //    int expected = 5;

        //    var result = _employeeService.GetAllEmployees().Count();

        //    result.Should().Be(expected);

        //}
        //[Fact]
        //public void GetEmployeesByManagerId_ShouldReturnAllEmployeesUnderTheGivenManager()
        //{
        //    int expected = 1;

        //    var result = _employeeService.GetEmployeesByManagerId(1).Count();

        //    result.Should().Be(expected);

        //}
        //[Fact]
        //public void GetEmployeeByEmployeeId_ShouldReturnEmployee()
        //{
        //    var expected = new Employee() {Name="Prakhar",Id=1,Age=21,Salary=600000,ManagerId=0};

        //    var result = employeeService.GetEmployeeByEmployeeId(1);

        //    result.Should().BeEquivalentTo(expected);
        //}
        //[Fact]
        //public void AddEmployee_ShouldAddEmployee()
        //{
        //    var expected = new Employee() { Name = "Tiwari", Id = 6, Age = 21, Salary = 600000, ManagerId = 2 };

        //    employeeService.AddEmployee(new Employee() {  Name = "Tiwari",Age = 21, Salary = 600000, ManagerId = 2 });

        //    employeeService.GetEmployeeByEmployeeId(6).Should().BeEquivalentTo(expected);
        //}
        //[Fact]
        //public void DeleteEmployee_ShouldDeleteEmployee()
        //{
        //    employeeService.DeleteEmployee(5);
        //    Action action = () => employeeService.GetEmployeeByEmployeeId(5);
        //    action.Should().Throw<EmployeeNotFoundException>().WithMessage("Employee not found");
        //}
        //[Fact]
        //public void DeleteEmployee_ShouldNotDeleteEmployeeIfEmployeeIsManager()
        //{
            
        //    Action action = () => employeeService.DeleteEmployee(2);
        //    action.Should().Throw<EmployeeIsAManagerOfOtherEmployeesException>().WithMessage("Employee is a manager of other employees!!");
        //}
    }
}
