using System;
using System.Collections.Generic;
using System.Linq;

namespace Behavioral.MediatorPattern.Base
{
    public abstract class Mediator
    {
        protected List<Colleague> colleagues = new List<Colleague>();

        public virtual void Send(string message, Colleague sender)
        {
            SendTo(this.colleagues, message, sender);
        }
        public virtual void Send<T>(string message, Colleague sender) where T: Colleague
        {
            SendTo(this.colleagues.OfType<T>(), message, sender);
        }

        private void SendTo(IEnumerable<Colleague> receivers, string message, Colleague sender)
        {
            receivers
            .Where(c => c != sender)
            .ToList()
            .ForEach(c => c.Receive(message));
        }

        public virtual T Register<T>() where T: Colleague, new()
        {
            var colleague = new T();
            colleague.SetMediator(this);
            this.colleagues.Add(colleague);
            
            return colleague;
        }

        public virtual void Register(Colleague colleague)
        {
            colleague.SetMediator(this);
            this.colleagues.Add(colleague);
        }
    }
}