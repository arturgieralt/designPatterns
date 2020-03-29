using System;
using Behavioral.MediatorPattern.Base;

namespace Behavioral.MediatorPattern
{
    public class ConcreteColleague2: Colleague
    {
        public override void Receive(string message)
        {
            Console.WriteLine($"Colleague 2 received message: {message}");
        } 
    }
}