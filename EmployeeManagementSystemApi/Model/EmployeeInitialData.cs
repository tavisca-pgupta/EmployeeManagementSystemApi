namespace EmployeeManagementSystemApi.Model
{
    public static class EmployeeInitialData
    {
        //private static  EmployeeContext _context;
        public static void SeedInitialData(this EmployeeContext _context)
        {
            _context.Employees.Add(new Employee() { Name = "Prakhar", Salary = 600000, Age = 21 });
            _context.Employees.Add(new Employee() { Name = "Rahul", Salary = 600000, Age = 23, ManagerId = 1 });
            _context.Employees.Add(new Employee() { Name = "Raunak", Salary = 300000, Age = 20, ManagerId = 2 });
            _context.Employees.Add(new Employee() { Name = "Deepak", Salary = 300000, Age = 20, ManagerId = 2 });
            _context.Employees.Add(new Employee() { Name = "Rohit", Salary = 300000, Age = 20, ManagerId = 2 });
            _context.SaveChanges();
        }
    }
}
