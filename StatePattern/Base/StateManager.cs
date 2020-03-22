using System.Threading.Tasks;

namespace designPatterns.StatePattern.Base
{
    public class StateManager
    {
        private BaseState _state;
        private Booking _context;

        public StateManager(Booking booking) {
            _context = booking;
        }

        public async Task Init(BaseState state) 
        {
            _state = state;
            await TransitionToState(state);
        }

        protected internal Booking Booking => _context;

        public async Task TransitionToState(BaseState state) {
            _state = state;
            await _state.InitState(this);
        }

        public async Task Cancel()
        {
            await _state.Cancel(this);
        }
        public async Task DatePassed()
        {   
            await _state.DatePassed(this);
        }
        public async Task EnterDetails(string attendee, int ticketCount)
        {
            await _state.EnterDetails(this, attendee, ticketCount);
        }
    }
}