using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Structural.Adapter;
using Xunit;

namespace Structural.Tests
{
    public class AdapterTests
    {
        [Fact]
        public async Task WhenGettingSizeInKBForRoot_ShouldReturnWholeTreeSize()
        {
            var characterFileSource = new CharacterFileSource();
            var adapter = new CharacterFileSourceAdapter("People.json", characterFileSource);

            var people = await adapter.GetCharacters();

            people.First().Gender.Should().Be("male");
        }
    }
}