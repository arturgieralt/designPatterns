using System;
using System.Threading.Tasks;
using designPatterns.StatePattern.Base;

namespace designPatterns.StatePattern.BookingStateImplementation
{
    public class ClosedState: BaseState
    {
        private string reasonClosed;

        public ClosedState(string reason)
        {
            reasonClosed = reason;
        }

        public async override Task Cancel(StateManager _stateManager)
        {
            throw new Exception("Invalid action for this state");
        }

        public async override Task DatePassed(StateManager _stateManager)
        {
            throw new Exception("Invalid action for this state");
        }

        public async override Task EnterDetails(StateManager _stateManager, string attendee, int ticketCount)
        {
            throw new Exception("Invalid action for this state");
        }

        public async override Task InitState(StateManager _stateManager)
        {
            _stateManager.Booking.Status = BookingStatus.Closed;
        } 
    }
}