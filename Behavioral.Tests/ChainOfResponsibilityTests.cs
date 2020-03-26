using Xunit;
using Behavioral.ChainOfResponsibility;
using Moq;

namespace Behavioral.Tests
{
    public class LoggerTests
    {

        [Fact]
        public void Test1()
        {

            var consoleProviderMock = new Mock<ConsoleProvider>();

            Logger logger;
            logger = new ConsoleLogger(LogLevel.All, consoleProviderMock.Object)
                             .SetNext(new EmailLogger(LogLevel.FunctionalMessage | LogLevel.FunctionalError, consoleProviderMock.Object))
                             .SetNext(new FileLogger(LogLevel.Warning | LogLevel.Error, consoleProviderMock.Object));
 
            
            logger.Message("Entering function ProcessOrder().", LogLevel.Debug);
            consoleProviderMock.Verify(x => x.WriteLine("Writing to console: Entering function ProcessOrder()."), Times.Once);
        }
    }
}
