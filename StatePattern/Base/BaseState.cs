namespace designPatterns.StatePattern.Base
{
    public abstract class BaseState
    {
        public abstract void InitState(StateManager _stateManager);
        public abstract void Cancel(StateManager _stateManager);
        public abstract void DatePassed(StateManager _stateManager);
        public abstract void EnterDetails(StateManager _stateManager, string attendee, int ticketCount);
    }
}