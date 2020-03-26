using System;

namespace Behavioral.ChainOfResponsibility
{
    public class EmailLogger : Logger
    {
        public EmailLogger (LogLevel mask, ConsoleProvider provider): base(mask, provider)
        { }
 
        protected override void WriteMessage(string msg)
        {
            // Placeholder for mail send logic, usually the email configurations are saved in config file.
            consoleProvider.WriteLine("Sending via email: " + msg);
        }
    }
}