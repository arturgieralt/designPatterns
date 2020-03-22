using designPatterns.StatePattern.Base;
using designPatterns.StatePattern.BookingStateImplementation;

namespace designPatterns.StatePattern
{
    public class BookingManager
    {
       
        private StateManager _stateManager; 
        private Booking _booking;
        public BookingManager()
        {
            _booking = new Booking();
            _stateManager = new StateManager(
                new NewState(),
               _booking
                );
        }

        public void SubmitDetails(string attendee, int ticketCount)
        {
            _stateManager.EnterDetails(attendee, ticketCount);
        }

        public void Cancel()
        {
            _stateManager.Cancel();
        }

        public void DatePassed()
        {
            _stateManager.DatePassed();
        }
    }
        
}
