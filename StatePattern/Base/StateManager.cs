namespace designPatterns.StatePattern.Base
{
    public class StateManager
    {
        private BaseState _state;
        private Booking _context;

        public StateManager(BaseState initialState, Booking booking) {
            _context = booking;
            TransitionToState(initialState);
        }

        protected internal Booking Booking => _context;

        public void TransitionToState(BaseState state) {
            _state = state;
            _state.InitState(this);
        }

        public void Cancel()
        {
            _state.Cancel(this);
        }
        public void DatePassed()
        {   
            _state.DatePassed(this);
        }
        public void EnterDetails(string attendee, int ticketCount)
        {
            _state.EnterDetails(this, attendee, ticketCount);
        }
    }
}