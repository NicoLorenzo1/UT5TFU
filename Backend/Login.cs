namespace ProyectoUT5
{
    public class Login : ILoginService
    {
        public LoginService()
        {
            //singleton de userRepository
        }

        public bool Login(string username, string password)
        {
            var user = userRepository.GetUserByUsername(username);
            if (user == null || user.Password != password)
            {
                // Usuario no encontrado o contraseña incorrecta
                return false;
            }

            return true;
        }
    }
}
