using System;
using ProyectoUT5.Repository;

namespace ProyectoUT5
{
    public class JudgeMenu : IUserMenu
    {
        public JudgeMenu(){
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
                   ShowDisciplines();
                    break;
                case 2:
                    updateScore();
                    break;
                case 3:
                    Console.WriteLine("Gracias por usar el sistema. ¡Adiós!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }

        private void ShowDisciplines()
    {
        Console.WriteLine("Elige una opción \n 1- atletismo\n 2- Natación \n 3- esgrima \n 4- Salir");

            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
                return;
            }

            switch (option)
            {
                case 1:
                        List<Participant> participants = UserRepository.Instance.GetParticipantsByDiscipline("atletismo");
                            if (participants.Count > 0)
                            {
                                Console.WriteLine("Lista de participantes de atletismo:");
                                foreach (var participant in participants)
                                {
                                    Console.WriteLine($"CI: {participant.Ci}, Nombre: {participant.FirstName} {participant.LastName}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron participantes de atletismo.");
                            }
                            break;
                case 2:
                        updateScore();
                        break;
                case 3:
                    Console.WriteLine("Gracias por usar el sistema. ¡Adiós!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }

        }   

        public void updateScore(){
                        Console.WriteLine("Ingrese el CI del participante:");
                        if (int.TryParse(Console.ReadLine(), out int ci))
                        {
                            Console.WriteLine("Ingrese el nuevo puntaje:");
                            if (int.TryParse(Console.ReadLine(), out int newScore))
                            {
                                TablePoints.Instance.UpdateScore(ci, newScore);
                            }
                            else
                            {
                                Console.WriteLine("Puntaje inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("CI inválido.");
                        }
                        
        }
    }
}