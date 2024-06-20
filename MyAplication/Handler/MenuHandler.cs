using System;
using ProyectoUT5.Repository;

namespace ProyectoUT5.Handler
{
    //implementa la interfaz IUserMenu que tiene la firma del metodo ShowMenu()
    public class MenuHandler : IUserMenu
    {
        private AccessHandler access;

        public MenuHandler(){
            this.access = AccessHandler.Instance;
        }

         public void ShowMenu()
        {
            
            Console.WriteLine("Elige una opción \n 1- Registrarse \n 2- Iniciar sesion \n 3- Salir");

            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
                return;
            }

            switch (option)
            {
                case 1:
                    this.access.RegisterUser();
                    break;
                case 2:
                    this.access.LoginUser();
                    break;
                case 3:
                    Console.WriteLine("Gracias por usar el sistema. ¡Adiós!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }

     }
}
    
