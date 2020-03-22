using System;
using designPatterns.StatePattern.Base;

namespace designPatterns.StatePattern.BookingStateImplementation
{
    public class NewState: BaseState
    {
         public override void Cancel(StateManager _stateManager)
        {
            _stateManager.TransitionToState(new ClosedState("Booking Canceled"));
        }

        public override void DatePassed(StateManager _stateManager)
        {
            _stateManager.TransitionToState(new ClosedState("Booking Expired"));
        }

        public override void EnterDetails(StateManager _stateManager, string attendee, int ticketCount)
        {
            _stateManager.Booking.Attendee = attendee;
            _stateManager.Booking.TicketCount = ticketCount;
            _stateManager.TransitionToState(new PendingState());
        }

        public override void InitState(StateManager _stateManager)
        {
            _stateManager.Booking.BookingID = new Random().Next();
            _stateManager.Booking.Status = BookingStatus.New;
        }
    }
}