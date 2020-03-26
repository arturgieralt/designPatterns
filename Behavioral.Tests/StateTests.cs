using System;
using System.Threading.Tasks;
using Behavioral.State;
using FluentAssertions;
using Xunit;

namespace Behavioral.Tests
{
    public class BookingManagerTests
    {
        private BookingManager _bookingManger;

        public BookingManagerTests()
        {
            _bookingManger = new BookingManager();
        }

        [Fact]
        public async Task WhenCreated_ShouldSetBookingStatusToNew()
        {
            await _bookingManger.Create();
            var status = _bookingManger.Booking.Status;
            status.Should().Be(BookingStatus.New);
        }

        [Fact]
        public async Task WhenSettingPending_AndBookingIsProccessed_ShouldSetBookingStatusToBooked()
        {
            await _bookingManger.Create();
            await _bookingManger.SubmitDetails("Artur", 2);

            var status = _bookingManger.Booking.Status;
            status.Should().Be(BookingStatus.Booked);
        }

        [Fact]
        public async Task WhenSettingPending_AndBookingIsNotProccessed_ShouldSetBookingStatusToNew()
        {
            await _bookingManger.Create();
            StaticFunctions.WithResult(ProcessingResult.Fail);
            await _bookingManger.SubmitDetails("Artur", 2);

            var status = _bookingManger.Booking.Status;
            status.Should().Be(BookingStatus.New);
            StaticFunctions.WithResult(ProcessingResult.Sucess); // potential problem with testing is this class
        }

        [Fact]
        public async Task WhenSettingPending_AndBookingIsCancelled_ShouldSetBookingStatusToClosed()
        {
            await _bookingManger.Create();
            await _bookingManger.SubmitDetails("Artur", 2);
            await _bookingManger.Cancel();


            var status = _bookingManger.Booking.Status;
            status.Should().Be(BookingStatus.Closed);
        }

        [Fact]
        public async Task WhenCancelling_AndBookingIsAlreadyClosed_ShouldThrowException()
        {
            await _bookingManger.Create();
            await _bookingManger.Cancel();

            Func<Task> act = async () => { await _bookingManger.Cancel(); };

            await act.Should().ThrowAsync<Exception>();
        }
    }
}
