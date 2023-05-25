using Organization.Models;

namespace Organization.Services
{
    public interface ILeaveRequestServices
    {
        List<Leave> GetAllLeaveRequests();
        bool AddLeaveRequest(Leave leave);
        bool ApproveLeave(Guid leaveId);
        int? GetLeaveStatus(Guid leaveId);
        bool RejectLeave(Guid leaveId);
    }
}