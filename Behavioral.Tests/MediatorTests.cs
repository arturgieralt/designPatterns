using Behavioral.MediatorPattern;
using Moq;
using Xunit;
using FluentAssertions;

namespace Behavioral.Tests
{
    public class MediatorTests
    {
        [Fact]
        public void WhenSendingMessage_ShouldSendMessageToAllExceptOriginalSender()
        {
            var mediator = new ConcreteMediator();
            var colleague1Mock = new Mock<ConcreteColleague1>(){CallBase = true};
            var colleague2Mock = new Mock<ConcreteColleague2>(){CallBase = true};
            var colleague3Mock = new Mock<ConcreteColleague3>(){CallBase = true};
       
            colleague1Mock.Setup(c => c.Receive(It.IsAny<string>()));
            colleague2Mock.Setup(c => c.Receive(It.IsAny<string>()));
            colleague3Mock.Setup(c => c.Receive(It.IsAny<string>()));

            var colleague1 = colleague1Mock.Object;
            var colleague2 = colleague2Mock.Object;
            var colleague3 = colleague3Mock.Object;

            mediator.Register(colleague1);
            mediator.Register(colleague2);
            mediator.Register(colleague3);

            colleague1.Send("Custom message");

            colleague1Mock.Verify(c => c.Receive(It.IsAny<string>()), Times.Never);
            colleague2Mock.Verify(c => c.Receive("Custom message"), Times.Once);
            colleague3Mock.Verify(c => c.Receive("Custom message"), Times.Once);
        }

        [Fact]
        public void WhenSendingMessageToSpecificTypeOfReceiver_ShouldSendMessageToAllFromTypeExceptOriginalSender()
        {
            var mediator = new ConcreteMediator();
            var colleague1Mock = new Mock<ConcreteColleague1>(){CallBase = true};
            var colleague2Mock = new Mock<ConcreteColleague1>(){CallBase = true};
            var colleague3Mock = new Mock<ConcreteColleague3>(){CallBase = true};
       
            colleague1Mock.Setup(c => c.Receive(It.IsAny<string>()));
            colleague2Mock.Setup(c => c.Receive(It.IsAny<string>()));
            colleague3Mock.Setup(c => c.Receive(It.IsAny<string>()));

            var colleague1 = colleague1Mock.Object;
            var colleague2 = colleague2Mock.Object;
            var colleague3 = colleague3Mock.Object;

            mediator.Register(colleague1);
            mediator.Register(colleague2);
            mediator.Register(colleague3);

            colleague1.Send<ConcreteColleague1>("Custom message");

            colleague1Mock.Verify(c => c.Receive(It.IsAny<string>()), Times.Never);
            colleague2Mock.Verify(c => c.Receive("Custom message"), Times.Once);
            colleague3Mock.Verify(c => c.Receive(It.IsAny<string>()), Times.Never);
        }
    }
}