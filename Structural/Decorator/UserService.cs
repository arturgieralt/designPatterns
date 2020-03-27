using System.Collections.Generic;

namespace Structural.Decorator
{
    public class UserService: IUserService
    {
        private IEnumerable<string> Users = new List<string>() {"user1", "user2"};

        public IEnumerable<string> GetAll()
        {
            return Users;
        }
    }
}