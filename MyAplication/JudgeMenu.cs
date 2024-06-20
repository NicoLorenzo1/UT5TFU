using System;
using ProyectoUT5.Repository;

namespace ProyectoUT5
{
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
                    ShowParticipants();
                    break;
                case 2:
                    UpdateScore();
                    break;
                case 3:
                    Console.WriteLine("Gracias por usar el sistema. ¡Adiós!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }


        private void UpdateScore()
        {
            // Solicita el CI del participante
            Console.WriteLine("Ingrese el CI del participante:");
            if (int.TryParse(Console.ReadLine(), out int ci))
            {
                // Solicita el nuevo puntaje del participante
                Console.WriteLine("Ingrese el nuevo puntaje:");
                if (int.TryParse(Console.ReadLine(), out int newScore))
                {
                    // Actualiza el puntaje del participante utilizando la instancia de TablePoints
                    TablePoints.Instance.UpdateScore(ci, newScore);
                    // Muestra el menú nuevamente después de actualizar el puntaje
                    ShowMenu();
                }
                else
                {
                    // Mensaje de error si el puntaje ingresado no es válido
                    Console.WriteLine("Puntaje inválido.");
                }
            }
            else
            {
                // Mensaje de error si el CI ingresado no es válido
                Console.WriteLine("CI inválido.");
            }
        }

        public void ShowParticipants()
        {
            Console.WriteLine("Ingrese el nombre de una disciplina: \nAtletismo \nNatacion \nGimnasia \nClavados \nHalterofilia \nEsgrima \nSurf \nKitesurf");
            string discipline = Console.ReadLine();

            List<Participant> participants = UserRepository.Instance.GetParticipantsByDiscipline(discipline);
            if (participants.Count > 0)
            {
                Console.WriteLine($"Lista de participantes de {discipline}:");
                foreach (var participant in participants)
                {
                    Console.WriteLine($"CI: {participant.Ci}, Nombre: {participant.FirstName} {participant.LastName}");
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron participantes de {discipline}.");
            }
        }
    }
}
