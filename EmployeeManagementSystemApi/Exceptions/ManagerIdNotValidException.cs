using System;

namespace EmployeeManagementSystemApi
{
    public class ManagerIdNotValidException : Exception
    {
        public ManagerIdNotValidException(string message) : base(message)
        {

        }
    }
}
