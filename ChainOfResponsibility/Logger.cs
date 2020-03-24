using System;

namespace ChainOfResponsibility
{
    [Flags]
    public enum LogLevel
    {
        None = 0,                 //        0
        Info = 1,                 //        1
        Debug = 2,                //       10
        Warning = 4,              //      100
        Error = 8,                //     1000
        FunctionalMessage = 16,   //    10000
        FunctionalError = 32,     //   100000
        All = 63                  //   111111
    }
    public abstract class Logger
    {
        protected LogLevel logMask;
        protected Logger next;

        protected ConsoleProvider consoleProvider;

        public Logger(LogLevel mask, ConsoleProvider provider)
        {
            logMask = mask;
            consoleProvider = provider;
        }

        public Logger SetNext(Logger nextLogger)
        {
            Logger currentLogger = this;

            // iterate to the last logger in chain
            while(currentLogger.next != null) 
            {
                currentLogger = currentLogger.next;
            }

            currentLogger.next = nextLogger;
            return this;
        }

        public void Message(string msg, LogLevel severity)
        {
            if ((severity & logMask) != 0) // True only if any of the logMask bits are set in severity
            {
                WriteMessage(msg);
            }
            if (next != null) 
            {
                next.Message(msg, severity); 
            }
        }
 
        abstract protected void WriteMessage(string msg);
    }
}