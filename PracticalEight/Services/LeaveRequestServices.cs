using Organization.Enums;
using Organization.Logger;
using Organization.Models;

namespace Organization.Services
{
    public sealed class LeaveRequestServices : ILeaveRequestServices
    {
        static List<Leave> _leaveRequests = new List<Leave>();
        readonly LoggerService _fileLogger = new(new FileLogger());
        readonly LoggerService _consoleLogger = new(new ConsoleLogger());

        public LeaveRequestServices()
        {
            _leaveRequests.Add(new Leave(Guid.NewGuid(), new Guid("f6ec2d9d-ce0e-440a-aa61-df3b3f3e2914"), new DateOnly().AddDays(5), new DateOnly().AddDays(8), 3, "Leg Injury", DateTime.Now));
            _leaveRequests.Add(new Leave(Guid.NewGuid(), new Guid("481c1957-1e87-4d93-930d-03b53a0fc976"), new DateOnly().AddDays(5), new DateOnly().AddDays(12), 7, "Trip to manali", DateTime.Now));
        }
        public List<Leave> GetAllLeaveRequests()
        {
            return _leaveRequests;
        }
        public bool AddLeaveRequest(Leave leave)
        {
            try
            {
                _leaveRequests.Add(new Leave(Guid.NewGuid(), leave.EmployeeId, leave.From, new DateOnly(leave.From!.Value.Year, leave.From.Value.Month, leave.From.Value.Day).AddDays(leave.NumberOfDays), leave.NumberOfDays, leave.Reason, DateTime.Now));
                _consoleLogger.Success("Employee added successfully.\n\n");
                return true;
            }
            catch (Exception ex)
            {
                _fileLogger.Error(ex.Message);
                return false;
            }
        }
        public int? GetLeaveStatus(Guid leaveId)
        {
            Leave? leave = _leaveRequests.Find(e => e.Id == leaveId);
            if (leave == null) return null;
            return leave.LeaveStatus;
        }
        public bool ApproveLeave(Guid leaveId)
        {
            Leave? leave = _leaveRequests.Find(e => e.Id == leaveId);
            if (leave == null) return false;
            leave.LeaveStatus = (int)LeaveStatus.Approved;
            return true;
        }
        public bool RejectLeave(Guid leaveId)
        {
            Leave? leave = _leaveRequests.Find(e => e.Id == leaveId);
            if (leave == null) return false;
            leave.LeaveStatus = (int)LeaveStatus.Rejected;
            return true;
        }
    }
}
