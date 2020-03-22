using designPatterns.StatePattern.Base;

namespace designPatterns.StatePattern.BookingStateImplementation
{
    public abstract class BookingState: IState
    {
        public abstract void InitState(IContext context);
        public abstract void Cancel(BookingContext booking);
        public abstract void DatePassed(BookingContext booking);
        public abstract void EnterDetails(BookingContext booking, string attendee, int ticketCount);
    }
}