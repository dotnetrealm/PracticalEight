using Organization.Interfaces;

namespace Organization.Services
{
    internal sealed class LoggerService
    {
        private readonly ILogger _logger;

        public LoggerService(ILogger logger)
        {
            _logger = logger;
        }
        public void Alert(string message)
        {
            _logger.Alert(message);
        }
        public void Success(string message)
        {
            _logger.Success(message);
        }
        public void Info(string message)
        {
            _logger.Info(message);
        }
        public void Error(string message)
        {
            _logger.Error(message);
        }
    }
}
