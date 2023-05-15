using Organization.Enums;
using Organization.Interfaces;
using Organization.Logger;
using Organization.Models;

namespace Organization.Services
{
    public sealed class EmployeeServices : IEmployeeServices
    {
        readonly List<Employee> employees = new List<Employee>();
        readonly LoggerService FileLogger = new(new FileLogger());
        readonly LoggerService ConsoleLogger = new(new ConsoleLogger());

        public EmployeeServices()
        {
            employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                EmpName = "Bhavin",
                Gender = 'M',
                RoleId = (int)Roles.TRAINEE,
                AssignedLeave = 20,
                RemainingLeave = 20,
                DepartmentId = (int)Department.DOTNET,
                Salary = (decimal)SalaryPack.TRAINEE
            });
            employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                EmpName = "Vipul Kumar",
                Gender = 'M',
                RoleId = (int)Roles.SENIOR,
                AssignedLeave = 10,
                RemainingLeave = 10,
                DepartmentId = (int)Department.DOTNET,
                Salary = (decimal)SalaryPack.SENIOR
            });
        }
        public Employee GetEmployeeDetails(Guid empId)
        {
            return employees.First(e => e.Id == empId);
        }

        public IEnumerable<Employee> GetEmployeesList()
        {
            return employees;
        }

        public IEnumerable<Employee> GetEmployeesList(int RoleId)
        {
            return employees.FindAll(e => e.RoleId == RoleId);
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                employees.Add(employee);
                FileLogger.Success("Add new employee with ID: " + employee.Id);
                ConsoleLogger.Success("New employee added");
                return true;
            }
            catch (Exception ex)
            {
                FileLogger.Error(ex.Message);
                return false;
            }
        }

        public bool RemoveEmployee(Guid empId)
        {
            FileLogger.Info("Remove employee of ID: " + empId);
            ConsoleLogger.Info("Employee removed successfully");
            return employees.Remove(employees.First(e => e.Id == empId));
        }

        public void PromoteEmployee(Guid empId)
        {
            employees!.Where(e => e.Id == empId).First().RoleId++;
            ConsoleLogger.Success("Wohooo, Employee got promotion... ");
        }
    }
}
