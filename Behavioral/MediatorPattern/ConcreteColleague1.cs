using System;
using Behavioral.MediatorPattern.Base;

namespace Behavioral.MediatorPattern
{
    public class ConcreteColleague1: Colleague
    {
        public override void Receive(string message)
        {
            Console.WriteLine($"Colleague 1 received message: {message}");
        }
    }
}