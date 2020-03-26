using System;
using System.Threading.Tasks;
using Behavioral.State.Base;

namespace Behavioral.State.BookingStateImplementation
{
    public class NewState: BaseState
    {
         public async override Task Cancel(StateManager _stateManager)
        {
            await _stateManager.TransitionToState(new ClosedState("Booking Canceled"));
        }

        public async override Task DatePassed(StateManager _stateManager)
        {
            await _stateManager.TransitionToState(new ClosedState("Booking Expired"));
        }

        public async override Task EnterDetails(StateManager _stateManager, string attendee, int ticketCount)
        {
            _stateManager.Booking.Attendee = attendee;
            _stateManager.Booking.TicketCount = ticketCount;
            await _stateManager.TransitionToState(new PendingState());
        }

        public async override Task InitState(StateManager _stateManager)
        {
            _stateManager.Booking.BookingID = new Random().Next();
            _stateManager.Booking.Status = BookingStatus.New;
        }
    }
}