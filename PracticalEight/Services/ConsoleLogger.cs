using Organization.Interfaces;

namespace Organization.Services
{
    internal class ConsoleLogger : ILogger
    {
        public void LogAlert(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[ALERT]: {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error]: {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[Info]: {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void LogSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[Success]: {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
