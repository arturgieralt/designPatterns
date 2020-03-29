using System;
using Behavioral.MediatorPattern.Base;

namespace Behavioral.MediatorPattern
{
    public class ConcreteColleague3: Colleague
    {
        public override void Receive(string message)
        {
            Console.WriteLine($"Colleague 3 received message: {message}");
        } 
    }
}