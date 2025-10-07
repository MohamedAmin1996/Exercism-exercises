// TODO: define the 'LogLevel' enum

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        logLine = logLine.Substring(logLine.IndexOf("[") + 1, logLine.IndexOf("]") - 1);
        switch (logLine)
        {
            case "TRC": return LogLevel.Trace;
            case "DBG": return LogLevel.Debug;
            case "INF": return LogLevel.Info;
            case "WRN": return LogLevel.Warning;
            case "ERR": return LogLevel.Error;
            case "FTL": return LogLevel.Fatal;
            default: return LogLevel.Unknown;
        }
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return ($"{(int)logLevel}:{message}");
    }
}
enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}
