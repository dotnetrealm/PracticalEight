using Organization.Enums;
using Organization.Interfaces;
using Organization.Logger;
using Organization.Models;
using Organization.Services;

namespace Organization
{
    internal class Program
    {
        public static readonly LoggerService _logger = new(new ConsoleLogger());
        public static readonly LeaveRequestServices _leaveRequest = new LeaveRequestServices();
        public static readonly IEmployeeServices _employeeService = new EmployeeServices();
        public static readonly IHRService _HRService = new HRService(_employeeService, _leaveRequest);

        static void Main(string[] args)
        {
            StartProcess();
            Console.ReadLine();
        }

        public static void StartProcess()
        {
            int service;
            Console.WriteLine("Welcome to HR Service \n\n");
            Console.WriteLine("1. Add Leave Request");
            Console.WriteLine("2. Approve Leave Request");
            Console.WriteLine("3. Reject Leave Request");
            Console.WriteLine("4. Get Employee list");
            Console.WriteLine("5. Add Employee");
            Console.WriteLine("6. Remove Employee\n");

            do
            {
                Console.Write("\nPlease enter your choice: ");

                while (!int.TryParse(Console.ReadLine(), out service) || service > 5 || service < 1)
                {
                    _logger.Info("Please choose correct option: ");
                }

                switch (service)
                {
                    case 1:
                        AddLeaveRequest();
                        break;
                    case 2:
                        ApproveLeaveRequest();
                        break;
                    case 3:
                        RejectLeaveRequest();
                        break;
                    case 4:
                        GetEmployeeList();
                        break;
                    case 5:
                        AddNewEmployee();
                        break;
                    case 6:
                        RemoveEmployee();
                        break;
                }
            } while (true);
        }

        private static void RemoveEmployee()
        {
            _logger.Info("====================");
            Console.WriteLine("Remove Employee");
            _logger.Info("====================");
            Console.Write("Enter Employee Guid: ");
            Guid EmpId = Guid.Parse(Console.ReadLine()!);
            _HRService.RemoveEmployee(EmpId);
        }

        private static void AddNewEmployee()
        {
            _logger.Info("====================");
            Console.WriteLine("Add new Employee");
            _logger.Info("====================");
            Console.Write("Enter full name: ");
            string EmpName = Console.ReadLine()!.ToString();

            Console.Write("Enter department: ");
            var department = Console.ReadLine()!.ToString();
            int DepartmentId = department switch
            {
                "DOTNET" => (int)Department.DOTNET,
                "JAVA" => (int)Department.JAVA,
                "PHP" => (int)Department.PHP,
                "MEAN" => (int)Department.MEAN,
                "MERN" => (int)Department.MERN,
                _ => -99
            };

            Console.Write("Enter your gender: ");
            char Gender = Console.ReadKey()!.KeyChar;

            Console.Write("Enter your role: ");
            var role = Console.ReadLine()!.ToString();
            int RoleId = role switch
            {
                "LEAD" => (int)Roles.LEAD,
                "ADMINISTRATIOR" => (int)Roles.ADMINISTRATOR,
                "MANAGER" => (int)Roles.MANAGER,
                "SENIOR" => (int)Roles.SENIOR,
                "TRAINEE" => (int)Roles.TRAINEE,
                _ => -99
            };

            _HRService.AddEmployee(EmpName, DepartmentId, Gender, RoleId);
        }

        private static void RejectLeaveRequest()
        {
            _logger.Info("====================");
            Console.WriteLine("Reject Leave Request");
            _logger.Info("====================");
            Console.Write("Enter Leave Request Guid: ");
            Guid LeaveReqId = Guid.Parse(Console.ReadLine()!);
            _HRService.RejectLeaveRequest(LeaveReqId);
        }

        private static void ApproveLeaveRequest()
        {
            _logger.Info("====================");
            Console.WriteLine("Approve Leave Request");
            _logger.Info("====================");
            Console.Write("Enter Leave Request Guid: ");
            Guid LeaveReqId = Guid.Parse(Console.ReadLine()!);
            _HRService.ApproveLeaveRequest(LeaveReqId);
        }

        private static void GetEmployeeList()
        {
            List<Employee> list = _employeeService.GetEmployeesList().ToList();
            list.ForEach(e =>
            {
                Console.WriteLine($"Guid: {e.Id} && Name: {e.EmpName}");
            });
        }

        private static void AddLeaveRequest()
        {
            Leave leave = new Leave();

            _logger.Info("====================");
            Console.WriteLine("Create New Leave Request");
            _logger.Info("====================");
            Console.Write("Enter Employee Guid: ");
            leave.EmployeeId = Guid.Parse(Console.ReadLine()!);

            Console.Write("Enter from where you want leaves(MM/DD/YYYY): ");
            leave.From = DateOnly.Parse(Console.ReadLine()!);

            Console.Write("How many days leave you want?: ");
            leave.NumberOfDays = int.Parse(Console.ReadLine()!);

            Console.Write("Kindly share the reason: ");
            leave.Reason = Console.ReadLine()!.ToString();
            _logger.Info("====================");

            _leaveRequest.AddLeaveRequest(leave);
        }
    }
}