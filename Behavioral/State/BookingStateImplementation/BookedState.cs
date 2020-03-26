using System;
using System.Threading.Tasks;
using Behavioral.State.Base;

namespace Behavioral.State.BookingStateImplementation
{
    public class BookedState: BaseState
    {
        public async override Task Cancel(StateManager _stateManager)
        {
            await _stateManager.TransitionToState(new ClosedState("Booking canceled: Expect a refund"));
        }

        public async override Task DatePassed(StateManager _stateManager)
        {
            await _stateManager.TransitionToState(new ClosedState("We hope you enjoyed the event!"));
        }

        public async override Task EnterDetails(StateManager _stateManager, string attendee, int ticketCount)
        {
            throw new Exception("Invalid action for this state");
        }

        public async override Task InitState(StateManager _stateManager)
        {
            _stateManager.Booking.Status = BookingStatus.Booked;
        }
    }
}