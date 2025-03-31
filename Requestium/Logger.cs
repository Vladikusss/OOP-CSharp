using System;
using System.IO;

namespace Requestium;

internal class Logger
{
    private static string _root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    private static string _logFile = Path.Combine(_root, "logs.txt");
    private static string logMessage;
    
    static DateTime timestamp = DateTime.Now;

    internal static void Log(string level, string message, int? extra = null)
    {
        if (extra != null) {
            logMessage = $"{timestamp} -- {level} -- {message}: {extra}";
        } else {
            logMessage = $"{timestamp} -- {level} -- {message}";
        }

        using (StreamWriter writeObj = new StreamWriter(_logFile, append: true))
        {
            writeObj.WriteLine(logMessage);
        }
    }

    internal static void ClearLogs()
    {
        using (StreamWriter writeObj = new StreamWriter(_logFile, append: false))
        {
            writeObj.WriteLine("Log file has been Cleared at " + timestamp + '\n');
        }
    }
}