namespace designPatterns.StatePattern
{
    public enum BookingStatus {
            New,
            Pending,
            Booked,
            Closed
    }

    public class Booking
    {
        public string Attendee { get; set; }
        public int TicketCount { get; set; }
        public int BookingID { get; set; }
        public BookingStatus Status {get; set; }
    }
}