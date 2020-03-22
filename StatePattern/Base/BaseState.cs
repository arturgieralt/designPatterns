using System.Threading.Tasks;

namespace designPatterns.StatePattern.Base
{
    public abstract class BaseState
    {
        public abstract Task InitState(StateManager _stateManager);
        public abstract Task Cancel(StateManager _stateManager);
        public abstract Task DatePassed(StateManager _stateManager);
        public abstract Task EnterDetails(StateManager _stateManager, string attendee, int ticketCount);
    }
}