using System.Collections.Generic;

namespace Structural.Decorator
{
    public interface IUserService
    {
        IEnumerable<string> GetAll();
    }
}