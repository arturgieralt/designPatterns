using System.Collections.Generic;
using System.Threading.Tasks;

namespace Structural.Adapter
{
    public interface ICharacterSourceAdapter
    {
        Task<IEnumerable<Person>> GetCharacters();
    }
}