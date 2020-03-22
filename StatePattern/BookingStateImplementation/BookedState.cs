using System;
using designPatterns.StatePattern.Base;

namespace designPatterns.StatePattern.BookingStateImplementation
{
    public class BookedState: BaseState
    {
        public override void Cancel(StateManager _stateManager)
        {
            _stateManager.TransitionToState(new ClosedState("Booking canceled: Expect a refund"));
        }

        public override void DatePassed(StateManager _stateManager)
        {
            _stateManager.TransitionToState(new ClosedState("We hope you enjoyed the event!"));
        }

        public override void EnterDetails(StateManager _stateManager, string attendee, int ticketCount)
        {
            throw new Exception("Invalid action for this state");
        }

        public override void InitState(StateManager _stateManager)
        {
            _stateManager.Booking.Status = BookingStatus.Booked;
        }
    }
}