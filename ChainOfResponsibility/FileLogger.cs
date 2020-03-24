using System;

namespace ChainOfResponsibility
{
    public class FileLogger : Logger
    {
        public FileLogger (LogLevel mask, ConsoleProvider provider): base(mask, provider)
        { }
 
        protected override void WriteMessage(string msg)
        {
            // Placeholder for File writing logic
            consoleProvider.WriteLine("Writing to Log File: " + msg);
        }
    }
}