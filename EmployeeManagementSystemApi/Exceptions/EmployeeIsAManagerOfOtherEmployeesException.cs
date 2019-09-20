using System;

namespace EmployeeManagementSystemApi
{
    public class EmployeeIsAManagerOfOtherEmployeesException : Exception
    {
        public EmployeeIsAManagerOfOtherEmployeesException(string message) : base(message)
        {

        }
    }
}
