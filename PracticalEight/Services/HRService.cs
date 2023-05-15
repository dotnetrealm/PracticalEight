using Organization.Enums;
using Organization.Interfaces;
using Organization.Models;

namespace Organization.Services
{
    public sealed class HRService : IHRService
    {
        readonly IEmployeeServices employeeServices;
        readonly ILeaveRequestServices leaveRequestServices;
        public HRService(IEmployeeServices employeeServices, ILeaveRequestServices leaveRequestServices)
        {
            this.employeeServices = employeeServices;
            this.leaveRequestServices = leaveRequestServices;
        }

        public void AddEmployee(string empName, int department, char gender, int roleId)
        {
            string name = ((Roles)roleId).ToString();
            SalaryPack empPack = (SalaryPack)Enum.Parse(typeof(SalaryPack), name);

            Employee employee = new Employee();
            employee.EmpName = empName;
            employee.DepartmentId = department;
            employee.Salary = (decimal)empPack;
            employee.AssignedLeave = 15;
            employee.RemainingLeave = 15;
            employee.Gender = gender;
            employeeServices!.AddEmployee(employee);
        }

        public void RemoveEmployee(Guid empId)
        {
            employeeServices!.RemoveEmployee(empId);
        }

        public void GetEmployeeList()
        {
            employeeServices!.GetEmployeesList();
        }

        public void GetEmployeeListByRole(int roleId)
        {
            employeeServices!.GetEmployeesList(roleId);
        }

        public void ApproveLeaveRequest(Guid leaveReqId)
        {
            leaveRequestServices.ApproveLeave(leaveReqId);
        }

        public void RejectLeaveRequest(Guid leaveReqId)
        {
            leaveRequestServices.RejectLeave(leaveReqId);
        }
    }
}
