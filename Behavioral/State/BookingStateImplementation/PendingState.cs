using System;
using System.Threading;
using System.Threading.Tasks;
using Behavioral.State.Base;

namespace Behavioral.State.BookingStateImplementation
{
    public class PendingState: BaseState
    {
        CancellationTokenSource cancelToken;

        public async override Task Cancel(StateManager _stateManager)
        {
            cancelToken.Cancel();
        }

        public async override Task DatePassed(StateManager _stateManager)
        {
           throw new Exception("Invalid action for this state");
        }

        public async override Task EnterDetails(StateManager _stateManager, string attendee, int ticketCount)
        {
           throw new Exception("Invalid action for this state");
        }

        public async  override Task InitState(StateManager _stateManager)
        {
            cancelToken = new CancellationTokenSource();
            _stateManager.Booking.Status = BookingStatus.Pending;
            await StaticFunctions.ProcessBooking(_stateManager, ProcessingComplete, cancelToken);
        }

        public async void ProcessingComplete(StateManager _stateManager, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Sucess:
                    await _stateManager.TransitionToState(new BookedState());
                    break;
                case ProcessingResult.Fail:
                    await _stateManager.TransitionToState(new NewState());
                    break;
                case ProcessingResult.Cancel:
                    await _stateManager.TransitionToState(new ClosedState("Processing Canceled"));
                    break;
            }
        }   
    }
}