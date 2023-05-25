using Organization.Models;

namespace Organization.Interfaces
{
    public abstract class EmployeeBase
    {
        public abstract bool AddEmployee(Employee employee);
        public abstract bool RemoveEmployee(Guid empId);
        public abstract void PromoteEmployee(Guid empId);
        public abstract IEnumerable<Employee> FindEmployee(Guid? empId, string? empName);
        public abstract Employee GetEmployeeDetails(Guid empId);
        public abstract List<Employee> GetEmployeesList();
        public abstract List<Employee> GetEmployeesList(int departmentId);
    }
}
