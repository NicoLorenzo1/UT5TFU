namespace ProyectoUT5
{
    public class Login : ILogin
    {
        public Login()
        {
            //singleton de userRepository
        }

       public bool LoginUser(string username, string password, string email)
        {
            /*
            var user = userRepository.GetUserByUsername(username);
            if (user == null || user.Password != password || user.Email != email)
            {
                // Usuario no encontrado, contraseña incorrecta o email incorrecto
                return false;
            }

            */
            return true;

        }
    }
}
