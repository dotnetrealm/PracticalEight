using Organization.Enums;
using Organization.Logger;
using Organization.Models;

namespace Organization.Services
{
    public sealed class LeaveRequestServices : ILeaveRequestServices
    {
        static List<Leave> LeaveRequests = new List<Leave>();
        readonly LoggerService FileLogger = new(new FileLogger());
        readonly LoggerService ConsoleLogger = new(new ConsoleLogger());
        public bool AddLeaveRequest(Leave leave)
        {
            try
            {
                LeaveRequests.Add(
                    new Leave
                    {
                        Id = Guid.NewGuid(),
                        From = leave.From,
                        To = new DateOnly(leave.From!.Value.Year, leave.From.Value.Month, leave.From.Value.Day).AddDays(leave.NumberOfDays),
                        Reason = leave.Reason,
                        EmployeeId = leave.EmployeeId,
                        CreatedAt = DateTime.Now,
                        NumberOfDays = leave.NumberOfDays,
                        LeaveStatus = (int)LeaveStatus.Pending,
                    }
                );
                ConsoleLogger.Success("Employee added successfully.\n\n");
                return true;
            }
            catch (Exception ex)
            {
                FileLogger.Error(ex.Message);
                return false;
            }
        }
        public int GetLeaveStatus(Guid leaveId)
        {
            return LeaveRequests.Where(e => e.Id == leaveId).First().LeaveStatus;
        }
        public void ApproveLeave(Guid leaveId)
        {
            LeaveRequests.First(e => e.Id == leaveId).LeaveStatus = (int)LeaveStatus.Approve;
            ConsoleLogger.Success("Leave request approved successfully.\n\n");
        }
        public void RejectLeave(Guid leaveId)
        {
            LeaveRequests.Where(e => e.Id == leaveId).First().LeaveStatus = (int)LeaveStatus.Reject;
            ConsoleLogger.Info("Leave request rejected.\n\n");
        }
    }
}
