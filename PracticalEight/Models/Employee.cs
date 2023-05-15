
namespace Organization.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string EmpName { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; } 
        public char Gender { get; set; }
        public int RoleId { get; set; }
        public int AssignedLeave { get; set; }
        public int RemainingLeave { get; set; }
        public List<Leave> Leaves { get; set; } = new List<Leave>();
    }
}
