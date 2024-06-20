using System;
using ProyectoUT5.Repository;

namespace ProyectoUT5
{
    //implementa la interfaz IUserMenu que tiene la firma del metodo ShowMenu()
    public class JudgeMenu : IUserMenu
    {
        public JudgeMenu()
        {
            ShowMenu();
        }

        public void ShowMenu()
        {
            Console.WriteLine("Elige una opción \n 1- Ver Participantes de la disciplina \n 2- Ingresar puntaje \n 3- Añadir participante a un equipo \n 4- Salir");

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
                    ScoreHandler.UpdateScore();
                    ShowMenu();
                    break;
                case 3:
                    ParticipantHandler.AddParticipantToTeam();
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
