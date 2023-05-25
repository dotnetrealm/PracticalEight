namespace Organization.Models
{
    public record Leave
    {
        public Leave(Guid id, Guid employeeId, DateOnly? from, DateOnly? to, int numberOfDays, string reason, DateTime createdAt)
        {
            Id = id;
            EmployeeId = employeeId;
            From = from;
            To = to;
            NumberOfDays = numberOfDays;
            Reason = reason;
            CreatedAt = createdAt;
        }

        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateOnly? From { get; set; }
        public DateOnly? To { get; set; }
        public int NumberOfDays { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int LeaveStatus { get; set; } = (int)Organization.Enums.LeaveStatus.Pending;
        public DateTime CreatedAt { get; set; }
    }
}
