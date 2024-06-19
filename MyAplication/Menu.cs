using System;
using ProyectoUT5.Repository;

namespace ProyectoUT5
{
    public class Menu
    {
        private UserRepository userRepository;

        public Menu(){
            userRepository = new UserRepository();
        }

         public void ShowMenu()
        {
            Console.WriteLine("Elige una opción \n 1- /Registrarse \n 2- /Iniciar sesion \n 3- /Salir");

            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
                return;
            }

            switch (option)
            {
                case 1:
                    RegisterUser();
                    break;
                case 2:
                    LoginUser();
                    break;
                case 3:
                    Console.WriteLine("Gracias por usar el sistema. ¡Adiós!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }

            private void RegisterUser()
        {
            Console.WriteLine("Registro de nuevo participante:");
            
            Console.Write("CI: ");
            int ci;
            while (!int.TryParse(Console.ReadLine(), out ci))
            {
                Console.WriteLine("CI debe ser un número. Inténtalo de nuevo:");
            }

            Console.Write("Nombre: ");
            string firstName = Console.ReadLine();

            Console.Write("Apellido: ");
            string lastName = Console.ReadLine();

            Console.Write("Edad: ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("La edad debe ser un número entero. Inténtalo de nuevo:");
            }

            Console.Write("Género: ");
            string genre = Console.ReadLine();

            Console.Write("País: ");
            string country = Console.ReadLine();

            Console.Write("Contraseña: ");
            string password = Console.ReadLine();

            this.userRepository.RegisterParticipant(ci, password, firstName, lastName, age, genre, country);
            Console.WriteLine("¡Registro exitoso!");
        }

        private void LoginUser()
        {
            Console.WriteLine("Inicio de sesión:");
            
            Console.Write("CI: ");
            int ci;
            while (!int.TryParse(Console.ReadLine(), out ci))
            {
                Console.WriteLine("CI debe ser un número. Inténtalo de nuevo:");
            }

            Console.Write("Contraseña: ");
            string password = Console.ReadLine();

            bool loginSuccess = this.userRepository.LoginParticipant(ci, password) || this.userRepository.LoginJuez(ci, password);
            bool isJudge = userRepository.IsJudge(ci);
            if (loginSuccess && isJudge)
            {
                Console.WriteLine("¡Bienvenido Juez!");
                JudgeInterface();
            }
            else if(loginSuccess){
                Console.WriteLine("¡Bienvenido Participante!");
                ParticipantInterface();
            }
            else
            {
                Console.WriteLine("Inicio de sesión fallido. Verifica tus datos.");
            }

            
        }
        }
    }
