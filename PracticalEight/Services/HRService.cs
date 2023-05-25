using Organization.Enums;
using Organization.Interfaces;
using Organization.Logger;
using Organization.Models;

namespace Organization.Services
{
    public sealed class HRService : IHRService
    {
        readonly EmployeeBase _employeeServices;
        readonly ILeaveRequestServices _leaveRequestServices;
        static readonly LoggerService _consoleLogger = new(new ConsoleLogger());

        public HRService(EmployeeBase employeeServices, ILeaveRequestServices leaveRequestServices)
        {
            _employeeServices = employeeServices;
            _leaveRequestServices = leaveRequestServices;
        }
        public void AddEmployee(string empName, int department, char gender, int roleId)
        {
            string name = ((Roles)roleId).ToString();
            SalaryPack empPack = (SalaryPack)Enum.Parse(typeof(SalaryPack), name);
            Employee employee = new Employee(name, department, (decimal)empPack, gender, roleId, Guid.NewGuid());
            _employeeServices!.AddEmployee(employee);
        }
        public void RemoveEmployee(Guid empId)
        {
            _employeeServices!.RemoveEmployee(empId);
        }
        public List<Employee> GetEmployeeList()
        {
            return _employeeServices!.GetEmployeesList().ToList();
        }
        public List<Leave> GetLeaveRequestsList()
        {
            return _leaveRequestServices.GetAllLeaveRequests().ToList();
        }
        public void GetEmployeeListByRole(int roleId)
        {
            _employeeServices!.GetEmployeesList(roleId);
        }
        public void GetLeaveRequestStatus(Guid leaveReqId)
        {
            int? status = _leaveRequestServices.GetLeaveStatus(leaveReqId);
            if (status == null) _consoleLogger.Alert("No leave request founded with ID: " + leaveReqId);
            else _consoleLogger.Info("Status of Leave request is " + (LeaveStatus)status);
        }
        public void ApproveLeaveRequest(Guid leaveReqId)
        {
            if (_leaveRequestServices.ApproveLeave(leaveReqId))
                _consoleLogger.Success("Leave request approved successfully.\n\n");
            else
                _consoleLogger.Alert("No leave request found with ID: " + leaveReqId);
        }
        public void RejectLeaveRequest(Guid leaveReqId)
        {
            _leaveRequestServices.RejectLeave(leaveReqId);
        }
    }
}
