using log4net.Core;

namespace Core.CrossCuttingConcerns.Logging.Log4net;

[Serializable]
public class SerializableLogEvent
{
    private LoggingEvent _loggingEvent;

    public SerializableLogEvent(LoggingEvent loggingEvent)
    {
        _loggingEvent = loggingEvent;
    }

    public object Messages => _loggingEvent.MessageObject;
}