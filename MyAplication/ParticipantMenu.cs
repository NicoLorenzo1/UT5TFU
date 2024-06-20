using System;

namespace ProyectoUT5
{
    //implementa la interfaz IUserMenu que tiene la firma del metodo ShowMenu()
    public class ParticipantMenu : IUserMenu
    {

        public ParticipantMenu(){
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
                    ShowDisciplies.showDisciplies();
                    ShowMenu();
                    break;
                case 2:
                    TablePoints.Instance.DisplayPointsTable();
                    ShowMenu();
                    break;
                case 3:
                    TablePoints.Instance.DisplayTeamPointsTable();
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
