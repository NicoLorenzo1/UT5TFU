using System;

namespace ProyectoUT5.Handler
{
    //implementa la interfaz IUserMenu que tiene la firma del metodo ShowMenu()
    public class ParticipantMenuHandler : IUserMenu
    {

        public ParticipantMenuHandler(){
            ShowMenu();
        }  

        public void ShowMenu()
        {
            Console.WriteLine("Elige una opción \n 1- Ver disciplinas \n 2- Ver tabla de puntuación de participantes \n 3- Ver tabla de puntuación de equipos \n 4- Salir");

            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
                return;
            }

            switch (option)
            {
                 case 1:
                    DisciplinesHandler.showDisciplies();
                    ShowMenu();
                    break;
                case 2:
                    TableHandler.DisplayPointsTable();
                    ShowMenu();
                    break;
                case 3:
                    TableHandler.DisplayTeamPointsTable();
                    ShowMenu();
                    break;
                case 4:
                    Console.WriteLine("Gracias por usar el sistema. ¡Adiós!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }

        }
    }
}
