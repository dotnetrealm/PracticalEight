namespace Organization.Services
{
    public interface IHRService
    {
        void AddEmployee(string empName, int department, char gender, int roleId);
        void ApproveLeaveRequest(Guid leaveReqId);
        void GetEmployeeList();
        void GetEmployeeListByRole(int roleId);
        void RejectLeaveRequest(Guid leaveReqId);
        void RemoveEmployee(Guid empId);
    }
}