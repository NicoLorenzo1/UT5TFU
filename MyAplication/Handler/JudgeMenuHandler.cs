using System;
using ProyectoUT5.Repository;
using ProyectoUT5.Handler;


namespace ProyectoUT5
{
    //implementa la interfaz IUserMenu que tiene la firma del metodo ShowMenu()
    public class JudgeMenuHandler : IUserMenu
    {
        public JudgeMenuHandler()
        {
            ShowMenu();
        }

        public void ShowMenu()
        {
            Console.WriteLine("Elige una opción \n 1- Ver Participantes de la disciplina \n 2- Ingresar puntaje \n 3- Añadir participante a un equipo \n 4- Ver tabla de participantes \n 5- Ver tabla de equipos \n 6- Salir");

            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
                return;
            }

            switch (option)
            {
                 case 1:
                    ParticipantHandler.ShowParticipants();
                    ShowMenu();
                    break;
                case 2:
                    TableHandler.UpdateScoreMenu();
                    ShowMenu();
                    break;
                case 3:
                    ParticipantHandler.AddParticipantToTeamMenu();
                    ShowMenu();
                    break;
                case 4:
                    TableHandler.DisplayPointsTable();
                    ShowMenu();
                    break;
                case 5:
                    TableHandler.DisplayTeamPointsTable();
                    ShowMenu();
                    break;
                case 6:
                    Console.WriteLine("Gracias por usar el sistema. ¡Adiós!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }


        
    }
}


