using Organization.Models;

namespace Organization.Services
{
    public interface ILeaveRequestServices
    {
        bool AddLeaveRequest(Leave leave);
        void ApproveLeave(Guid leaveId);
        int GetLeaveStatus(Guid leaveId);
        void RejectLeave(Guid leaveId);
    }
}