using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Structural.Decorator;
using Xunit;

namespace Structural.Tests
{
    public class DecoratorTests
    {
        private IUserService _userService;
        private Mock<IMemoryCache> _cacheServiceMock;

// https://stackoverflow.com/questions/42381018/mock-imemorycache-with-moq-throwing-exception

        public DecoratorTests()
        {
            _cacheServiceMock = new Mock<IMemoryCache>();
            var cachEntry = Mock.Of<ICacheEntry>();

            _cacheServiceMock
                .Setup(m => m.CreateEntry(It.IsAny<object>()))
                .Returns(cachEntry);
            
            _userService = new CachedUserService(
                new UserService(),
                _cacheServiceMock.Object
            );
        }

        [Fact]
        public void WhenGettingUserListForFirstTime_ShouldReturnList()
        {
            _userService.GetAll().Should().BeEquivalentTo(
                new List<string>() {"user1", "user2"});
        }
    }
}