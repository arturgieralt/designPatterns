using System;
using System.Threading;
using designPatterns.StatePattern.Base;

namespace designPatterns.StatePattern.BookingStateImplementation
{
    public class PendingState: BaseState
    {
        CancellationTokenSource cancelToken;

        public override void Cancel(StateManager _stateManager)
        {
            cancelToken.Cancel();
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
            cancelToken = new CancellationTokenSource();
            StaticFunctions.ProcessBooking(_stateManager, ProcessingComplete, cancelToken);
        }

        public void ProcessingComplete(StateManager _stateManager, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Sucess:
                    _stateManager.TransitionToState(new BookedState());
                    break;
                case ProcessingResult.Fail:
                    _stateManager.TransitionToState(new NewState());
                    break;
                case ProcessingResult.Cancel:
                    _stateManager.TransitionToState(new ClosedState("Processing Canceled"));
                    break;
            }
        }   
    }
}