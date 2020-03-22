using System.Threading.Tasks;
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
               _booking
            );
        }

        public Booking Booking => _booking;
        
        public async Task Create()
        {
            await _stateManager.Init(new NewState());
        }

        public async Task SubmitDetails(string attendee, int ticketCount)
        {
            await _stateManager.EnterDetails(attendee, ticketCount);
        }

        public async Task Cancel()
        {
            await _stateManager.Cancel();
        }

        public async Task DatePassed()
        {
            await _stateManager.DatePassed();
        }
    }
        
}
