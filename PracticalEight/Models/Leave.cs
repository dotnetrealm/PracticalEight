namespace Organization.Models
{
    public class Leave
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateOnly? From { get; set; }
        public DateOnly? To { get; set; }
        public int NumberOfDays { get; set; }
        public string Reason { get; set; }
        public int LeaveStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
