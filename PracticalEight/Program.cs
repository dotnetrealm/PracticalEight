using Organization.Enums;
using Organization.Interfaces;
using Organization.Logger;
using Organization.Models;
using Organization.Services;

namespace Organization
{
    internal class Program
    {
        public static readonly LoggerService _consoleLogger = new(new ConsoleLogger());
        public static readonly LoggerService _fileLogger = new(new ConsoleLogger());
        public static readonly InputServices _inputService = new InputServices();
        public static readonly ILeaveRequestServices _leaveRequest = new LeaveRequestServices();
        public static readonly EmployeeBase _employeeServices = new EmployeeServices();
        public static readonly IHRService _HRService = new HRService(_employeeServices, _leaveRequest);

        protected Program() { }
        static void Main(string[] args)
        {
            StartProcess();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        static void StartProcess()
        {
            int service;
            bool flag = true;
            Console.WriteLine("Welcome to HR Service \n");
            Console.WriteLine("1. Get list of Leave requests");
            Console.WriteLine("2. Approve Leave Request");
            Console.WriteLine("3. Reject Leave Request");
            Console.WriteLine("4. Get leave request status");
            Console.WriteLine("5. Add Employee");
            Console.WriteLine("6. Remove Employee");
            Console.WriteLine("7. Get Employee list");
            Console.WriteLine("8. Get Employee list by department\n");

            do
            {
                Console.Write("Please enter your choice: ");

                
                //while (!int.TryParse(Console.ReadLine(), out service) || service > 8 || service < 1)
                //{
                //    _consoleLogger.Error("Invalid user input");
                //    Console.Write("Please choose correct option: ");
                //}

                int.TryParse(Console.ReadLine(), out service);

                switch (service)
                {
                    case 1:
                        GetLeaveRequestsList();
                        break;
                    case 2:
                        ApproveLeaveRequest();
                        break;
                    case 3:
                        RejectLeaveRequest();
                        break;
                    case 4:
                        GetLeaveRequestStatus();
                        break;
                    case 5:
                        AddNewEmployee();
                        break;
                    case 6:
                        RemoveEmployee();
                        break;
                    case 7:
                        GetEmployeeList();
                        break;
                    case 8:
                        Console.Write("Please enter department name: ");
                        GetEmployeeList(Console.ReadLine()!.ToString());
                        break;
                    default:
                        flag = false;
                        break;
                }
            } while (flag);

        }
        static void RemoveEmployee()
        {
            GetEmployeeList();
            _consoleLogger.Info("====================");
            Console.WriteLine("Remove Employee");
            _consoleLogger.Info("====================");
            Console.Write("Enter Employee Guid: ");
            try
            {
                Guid EmpId = Guid.Parse(Console.ReadLine()!);
                _HRService.RemoveEmployee(EmpId);
            }
            catch (FormatException)
            {
                _fileLogger.Error("Guid format is not valid.");
                _consoleLogger.Error("Guid format is not valid.");
            }
        }
        static void AddNewEmployee()
        {
            try
            {
                _consoleLogger.Info("====================");
                Console.WriteLine("Add new Employee");
                _consoleLogger.Info("====================");
                Console.Write("Enter full name: ");
                string empName = Console.ReadLine()!.ToString();

                Console.Write("Enter department(DOTNET/JAVA/PHP/MEAN/MERN): ");
                var department = Console.ReadLine()!.ToString().ToUpper();
                int departmentId = (int)Enum.Parse(typeof(Department), department);

                Console.Write("Enter your gender (M/F): ");
                char gender = Console.ReadLine()!.ToString().ToUpper()[0];
                if (gender != 'M' && gender != 'F')
                {
                    throw new InvalidDataException("Transgender not allowed!!");
                }

                Console.Write("Enter your role(MANAGER/LEAD/SENIOR/TRAINEE): ");
                var role = Console.ReadLine()!.ToString().ToUpper();
                int roleId = (int)Enum.Parse(typeof(Roles), role);

                _HRService.AddEmployee(empName, departmentId, gender, roleId);
            }
            catch (Exception e)
            {
                _consoleLogger.Error(e.Message);
            }
        }
        static void RejectLeaveRequest()
        {
            GetLeaveRequestsList();
            _consoleLogger.Info("====================");
            Console.WriteLine("Reject Leave Request");
            _consoleLogger.Info("====================");
            Console.Write("Enter Leave Request Guid: ");
            Guid LeaveReqId = Guid.Parse(Console.ReadLine()!);
            _HRService.RejectLeaveRequest(LeaveReqId);
        }
        static void ApproveLeaveRequest()
        {
            GetLeaveRequestsList();
            _consoleLogger.Info("====================");
            Console.WriteLine("Approve Leave Request");
            _consoleLogger.Info("====================");
            Console.Write("Enter Leave Request Guid: ");
            Guid leaveReqId = _inputService.GetGUID();
            _HRService.ApproveLeaveRequest(leaveReqId);
        }
        static void GetLeaveRequestsList()
        {
            List<Leave> list = _leaveRequest.GetAllLeaveRequests().ToList();
            List<Employee> employees = _employeeServices.GetEmployeesList().ToList();
            list.ForEach(e =>
            {
                _consoleLogger.Info($"Guid: {e.Id} \nName: {employees.First(emp => emp.Id == e.EmployeeId).Name} \nReason: {e.Reason} \nDate: {e.From} \nTo: {e.To} \nStatus: {(LeaveStatus)e.LeaveStatus}");
                Console.WriteLine();
            });
        }
        static void GetLeaveRequestStatus() {
            Console.Clear();
            _consoleLogger.Info("====================");
            Console.WriteLine("Know status of leave request");
            _consoleLogger.Info("====================");
            GetLeaveRequestsList();
            Console.Write("Please enter request GUID: ");
            Guid id = _inputService.GetGUID();
            _HRService.GetLeaveRequestStatus(id);
        }
        static void GetEmployeeList()
        {
            List<Employee> list = _employeeServices.GetEmployeesList().ToList();
            if (list.Count == 0) _consoleLogger.Alert("No employee found in this organization!");
            list.ForEach(e =>
            {
                _consoleLogger.Info($"Guid: {e.Id.ToString("N")} \nName: {e.Name} \nDepartment: {(Department)e.DepartmentId} \nRole: {(Roles)e.RoleId}");
                Console.WriteLine();
            });
        }
        static void GetEmployeeList(string department)
        {
            try
            {
                int departmentId = (int)Enum.Parse(typeof(Department), department.ToUpper());
                List<Employee> list = _employeeServices.GetEmployeesList(departmentId).ToList();
                if (list.Count == 0)
                {
                    _consoleLogger.Alert("No employee registered under this department!!");
                }
                list.ForEach(e =>
                {
                    _consoleLogger.Info($"Guid: {e.Id} \nName: {e.Name} \nDepartment: {(Department)e.DepartmentId} \nRole: {(Roles)e.RoleId}");
                    Console.WriteLine();
                });
            }
            catch (ArgumentException)
            {
                _fileLogger.Error("Sorry, Department not found!");
                _consoleLogger.Error("Sorry, Department not found!");
            }
        }
    }
}