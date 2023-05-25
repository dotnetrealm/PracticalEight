
namespace Organization.Models
{
    public record Employee
    {
        public Employee() { }
        public Employee(string name, int departmentId, decimal salary, char gender, int roleId, Guid id)
        {
            Id = id;
            Name = name;
            DepartmentId = departmentId;
            Salary = salary;
            Gender = gender;
            RoleId = roleId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public char Gender { get; set; }
        public int RoleId { get; set; }

        //public record Employee(Guid Id = Guid.NewGuid(), string Name, int DepartmentId, decimal Salary, char Gender, int RoleId, int AssignedLeave, int Rae)
    }
}
