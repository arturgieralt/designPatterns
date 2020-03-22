using System;
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

        public override void Cancel(StateManager _stateManager)
        {
            throw new Exception("Invalid action for this state");
        }

        public override void DatePassed(StateManager _stateManager)
        {
            throw new Exception("Invalid action for this state");
        }

        public override void EnterDetails(StateManager _stateManager, string attendee, int ticketCount)
        {
            throw new Exception("Invalid action for this state");
        }

        public override void InitState(StateManager _stateManager)
        {
            _stateManager.Booking.Status = BookingStatus.Closed;
        } 
    }
}