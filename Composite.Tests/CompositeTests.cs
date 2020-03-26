using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

namespace Composite.Tests
{
    public class CompositeTests
    {
        private FileSystemBuilder builder;

        public CompositeTests () {
            builder = new FileSystemBuilder("root");
        }
        [Fact]
        public void WhenGettingSizeInKBForRoot_ShouldReturnWholeTreeSize()
        {
            var root = builder
            .AddDirectory("project1")
                .AddFile("file1", 2100)
                .AddFile("file2", 3100)
            .SetCurrentDirectory("root")
            .AddDirectory("project2")
                .AddFile("file3", 6100)
            .Build();

            root.GetSizeInKB().Should().Be((decimal)11.3);

        }

        [Fact]
        public void WhenGettingExistingFileName_ShouldReturnFile()
        {
            var root = builder
            .AddDirectory("project1")
                .AddFile("file1", 2100)
                .AddFile("file2", 3100)
            .SetCurrentDirectory("root")
            .AddDirectory("project2")
                .AddFile("file3", 6100)
            .Build();

            root.GetItem("file2").Should().NotBeNull();

        }

        [Fact]
        public void WhenGettingItemsWithSpecificSize_ShouldReturnListOfItems()
        {
            var root = builder
            .AddDirectory("project1")
                .AddFile("file1", 2100)
                .AddFile("file2", 3100)
            .SetCurrentDirectory("root")
            .AddDirectory("project2")
                .AddFile("file3", 6100)
            .Build();

            root
                .GetItems(item => item.Name.Contains("file"))
                .Should()
                .HaveCount(3);

        }
    }
}
