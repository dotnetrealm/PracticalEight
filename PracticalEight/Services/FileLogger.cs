using Organization.Interfaces;

namespace Organization.Services
{
    public class FileLogger : ILogger
    {
        private static readonly string _logPath = Directory.GetCurrentDirectory() + "/Logs/"+ DateTime.Now.ToShortDateString() +"/";
        private static readonly string _fileName = ConfigService.GetSection("Logger").GetSection("FileName").Value!;

        static FileLogger()
        {
            if (!Directory.Exists(_logPath))
            {
                Directory.CreateDirectory(_logPath);
            }
            if (!File.Exists(_logPath + _fileName))
            {
                File.Create(_logPath + _fileName);
            }
        }
        public void LogAlert(string message)
        {
            using StreamWriter sw = File.CreateText(_logPath + _fileName);
            sw.WriteLine();
            sw.WriteLine("Guid: " + Guid.NewGuid());
            sw.WriteLine("Type: ALERT");
            sw.WriteLine("TimeStamp: " + DateTime.Now);
            sw.WriteLine("Message: " + message);
            sw.WriteLine();
            sw!.Dispose();
        }

        public void LogError(string message)
        {
            using StreamWriter sw = File.CreateText(_logPath + _fileName);
            sw.WriteLine();
            sw.WriteLine("Guid: " + Guid.NewGuid());
            sw.WriteLine("Type: ERROR");
            sw.WriteLine("TimeStamp: " + DateTime.Now);
            sw.WriteLine("Message: " + message);
            sw.WriteLine();
            sw!.Dispose();
        }

        public void LogInfo(string message)
        {
            using StreamWriter sw = File.CreateText(_logPath + _fileName);
            sw.WriteLine();
            sw.WriteLine("Guid: " + Guid.NewGuid());
            sw.WriteLine("Type: INFORMATION");
            sw.WriteLine("TimeStamp: " + DateTime.Now);
            sw.WriteLine("Message: " + message);
            sw.WriteLine();
            sw!.Dispose();
        }

        public void LogSuccess(string message)
        {
            using StreamWriter sw = File.CreateText(_logPath + _fileName);
            sw.WriteLine();
            sw.WriteLine("Guid: " + Guid.NewGuid());
            sw.WriteLine("Type: SUCCESS");
            sw.WriteLine("TimeStamp: " + DateTime.Now);
            sw.WriteLine("Message: " + message );
            sw.WriteLine();
            sw!.Dispose();
        }
    }
}
