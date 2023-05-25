using Organization.Enums;
using Organization.Interfaces;
using Organization.Logger;
using Organization.Models;

namespace Organization.Services
{
    public sealed class EmployeeServices : EmployeeBase
    {
        readonly List<Employee> _employees = new List<Employee>();
        readonly LoggerService _fileLogger = new(new FileLogger());
        readonly LoggerService _consoleLogger = new(new ConsoleLogger());

        public EmployeeServices()
        {
            _employees.Add(new Employee("Bhavin", (int)Department.DOTNET, (decimal)SalaryPack.TRAINEE, 'M', (int)Roles.TRAINEE, new Guid("481c1957-1e87-4d93-930d-03b53a0fc976")));
            _employees.Add(new Employee("Vipul Kumar", (int)Department.DOTNET, (decimal)SalaryPack.SENIOR, 'M', (int)Roles.SENIOR, new Guid("f6ec2d9d-ce0e-440a-aa61-df3b3f3e2914")));
        }
        public override Employee GetEmployeeDetails(Guid empId)
        {
            return _employees.First(e => e.Id == empId);
        }
        public override List<Employee> GetEmployeesList()
        {
            return _employees;
        }
        public override List<Employee> GetEmployeesList(int departmentId)
        {
            return _employees.FindAll(e => e.DepartmentId == departmentId);
        }
        public override bool AddEmployee(Employee employee)
        {
            try
            {
                _employees.Add(employee);
                _fileLogger.Success("Add new employee with ID: " + employee.Id);
                _consoleLogger.Success("New employee added");
                return true;
            }
            catch (Exception ex)
            {
                _fileLogger.Error(ex.Message);
                return false;
            }
        }
        public override bool RemoveEmployee(Guid empId)
        {
            _fileLogger.Info("Remove employee of ID: " + empId);
            _consoleLogger.Info("Employee removed successfully");
            return _employees.Remove(_employees.First(e => e.Id == empId));
        }
        public override void PromoteEmployee(Guid empId)
        {
            _employees!.First(e => e.Id == empId).RoleId++;
            _consoleLogger.Success("Wohooo, Employee got promotion... ");
        }

        public override IEnumerable<Employee> FindEmployee(Guid? empId, string? empName)
        {
            return _employees.FindAll(e => e.Id.ToString().Contains(empId.ToString()!) || e.Name.Contains(empName!));
        }
    }
}
