using System;

namespace ChainOfResponsibility
{
    public class ConsoleProvider
    {
        public virtual void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}