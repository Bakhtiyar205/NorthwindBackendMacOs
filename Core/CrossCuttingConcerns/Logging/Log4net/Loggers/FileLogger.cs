namespace Core.CrossCuttingConcerns.Logging.Log4net.Loggers;

public class FileLogger : LoggerServiceBase
{
    public FileLogger(string name) : base("JsonLogger")
    {
    }
}