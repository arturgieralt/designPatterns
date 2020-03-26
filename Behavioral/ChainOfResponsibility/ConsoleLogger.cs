using System;

namespace Behavioral.ChainOfResponsibility
{
    public class ConsoleLogger: Logger
    {
        public ConsoleLogger(LogLevel mask, ConsoleProvider provider): base(mask, provider)
        { }
        protected override void WriteMessage(string msg)
        {
            consoleProvider.WriteLine("Writing to console: " + msg);
        }
    }
}