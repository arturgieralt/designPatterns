namespace Behavioral.MediatorPattern.Base
{
    public abstract class Colleague
    {
        protected Mediator mediator;
        public void SetMediator(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            this.mediator.Send(message, this);
        }

        public virtual void Send<T>(string message) where T: Colleague
        {
            this.mediator.Send<T>(message, this);
        }

        public abstract void Receive(string message);
    }
}