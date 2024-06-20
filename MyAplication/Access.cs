using System;
using ProyectoUT5.Repository;

namespace ProyectoUT5
{
    public class Access
    {
        private IUserMenu userMenu;
        public Access(){
        }

            public void RegisterUser()
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

            Console.Write("Disciplina: ");
            string discipline = Console.ReadLine();

            UserRepository.Instance.AddParticipant(ci, password, firstName, lastName, age, genre, country, discipline);
            Console.WriteLine("¡Registro exitoso!");
        }

        public void LoginUser()
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

            bool loginSuccess = UserRepository.Instance.verifyCredentials(ci, password) || UserRepository.Instance.LoginJuez(ci, password);
            bool isJudge = UserRepository.Instance.IsJudge(ci);
            if (loginSuccess && isJudge)
            {
                Console.WriteLine("¡Bienvenido Juez!");
                userMenu = new JudgeMenu();     //si es juez inicializo menu de juez
            }
            else if(loginSuccess){
                Console.WriteLine("¡Bienvenido Participante!");
                userMenu = new ParticipantMenu();    //si es participante inicializo menu de participante.
            }
            else
            {
                Console.WriteLine("Inicio de sesión fallido. Verifica tus datos.");
            }
        }
        }
    }
