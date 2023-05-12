using Microsoft.Extensions.Configuration;
using Organization.Interfaces;
using Organization.Services;

namespace Organization
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new FileLogger();
            logger.LogAlert("Alert");
            logger.LogSuccess("Success");

            logger = new ConsoleLogger();
            logger.LogAlert("Alert");
            logger.LogInfo("Info");
            logger.LogSuccess("Success");

            Console.ReadLine();
        }
    }
}