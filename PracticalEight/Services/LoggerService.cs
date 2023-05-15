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
            _logger.LogAlert(message);
        }

        public void Success(string message)
        {
            _logger.LogSuccess(message);
        }

        public void Info(string message)
        {
            _logger.LogInfo(message);
        }

        public void Error(string message)
        {
            _logger.LogError(message);
        }
    }
}
