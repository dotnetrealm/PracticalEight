using Organization.Logger;

namespace Organization.Services
{
    public class InputServices
    {
        readonly LoggerService _consoleLogger;
        public InputServices()
        {
            _consoleLogger = new(new ConsoleLogger());
        }
        public Guid GetGUID()
        {
            Guid guid;
            while (!Guid.TryParse(Console.ReadLine(), out guid))
            {
                _consoleLogger.Error("Invalid format, please try again!!: ");
            }
            return guid;
        }
    }
}
