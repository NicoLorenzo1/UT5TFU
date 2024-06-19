using System;
using ProyectoUT5.Repository;

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

            if (result != null)
            {
                Console.WriteLine("Usuario encontrado: " + result.FirstName + " " + result.LastName);
            }
            else
            {
                Console.WriteLine("Usuario no encontrado");
            }
        }
    }
}
