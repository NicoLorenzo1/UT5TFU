using System;

namespace ProyectoUT5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola, Mundo!");

            UserRepository userRepository = new UserRepository();
            getParticipants(userRepository);

        }

        public static void getParticipants(UserRepository userRepository){
            var result = userRepository.GetUserByUsername("Nombre1");
            Console.WriteLine(result);
        }
    }
}
