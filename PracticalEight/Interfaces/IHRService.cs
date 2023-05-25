namespace Organization.Services
{
    public interface IHRService
    {
        void AddEmployee(string empName, int department, char gender, int roleId);
        void ApproveLeaveRequest(Guid leaveReqId);
        void RejectLeaveRequest(Guid leaveReqId);
        void GetLeaveRequestStatus(Guid leaveReqId);
        void RemoveEmployee(Guid empId);
    }
}