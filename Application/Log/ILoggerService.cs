
namespace Application.Log
{
    public interface ILoggerService<T>
    {
        void LogError(Exception ex, string message, params object[] args);
        void LogInfo(string message, params object[] args);
    }
}