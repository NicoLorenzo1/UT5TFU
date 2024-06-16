using System;

namespace ProyectoUT5
{
    public class Register : IRegistrationService
    {

        public Register()
        {
            //singleton de userRepository
        }

        public bool Register(string username, string password, string email)
        {
            if (userRepository.GetUserByUsername(username) != null)
            {
                // El usuario ya existe
                return false;
            }

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = username,
                Password = password,
                Email = email
            };

            _userRepository.AddUser(user);
            return true;
        }
    }
}
