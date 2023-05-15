using Organization.Models;

namespace Organization.Interfaces
{
    public interface IEmployeeServices
    {
        bool AddEmployee(Employee employee);
        Employee GetEmployeeDetails(Guid empId);
        IEnumerable<Employee> GetEmployeesList();
        IEnumerable<Employee> GetEmployeesList(int RoleId);
        void PromoteEmployee(Guid empId);
        bool RemoveEmployee(Guid empId);
    }
}