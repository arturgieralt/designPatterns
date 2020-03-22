using designPatterns.StatePattern.Base;

namespace designPatterns.StatePattern.BookingStateImplementation
{
    public class BookingContext: BaseContext<BookingState>
    {
        public string Attendee { get; set; }
        public int TicketCount { get; set; }
        public int BookingID { get; set; }

        public BookingContext(BookingState state): base(state) 
        {
        }

        public void SubmitDetails(string attendee, int ticketCount)
        {
            currentState.EnterDetails(this, attendee, ticketCount);
        }

        public void Cancel()
        {
            currentState.Cancel(this);
        }

        public void DatePassed()
        {
            currentState.DatePassed(this);
        }
    }
        
}
