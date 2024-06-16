using System.Collections.Generic;
using System.Linq;

namespace ProyectoUT5
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }
    }
}