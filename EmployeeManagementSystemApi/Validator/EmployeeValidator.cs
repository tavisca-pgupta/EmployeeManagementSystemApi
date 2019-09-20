using EmployeeManagementSystemApi.Model;
using FluentValidation;

namespace EmployeeManagementSystemApi
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Salary).NotEmpty().InclusiveBetween(200000, 1200000);
            RuleFor(x => x.Name).NotEmpty().Length(1, 20);
            RuleFor(x => x.Age).NotEmpty().GreaterThanOrEqualTo(18);
        }
    }
}
