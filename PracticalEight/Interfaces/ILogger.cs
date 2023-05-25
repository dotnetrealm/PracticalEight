namespace Organization.Interfaces
{
    public interface ILogger
    {
        void Info(string message);
        void Error(string message);
        void Success(string message);
        void Alert(string message);
    }
}
