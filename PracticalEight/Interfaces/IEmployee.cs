using Organization.Models;

namespace Organization.Interfaces
{
    public abstract class EmployeeBase
    {
        public abstract void AddEmployee(Employee employee);
        public abstract bool RemoveEmployee(Guid empId);
        public abstract void PromoteEmployee(Guid empId);
        public abstract IEnumerable<Employee> FindEmployee(Guid? empId, string? empName);
    }
}
