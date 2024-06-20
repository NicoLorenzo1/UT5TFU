using System;

namespace ProyectoUT5
{
    public class ParticipantMenu : IUserMenu
    {

        public ParticipantMenu(){
            ShowMenu();
        }  

        public void ShowMenu()
        {
            //Console.WriteLine("¡Bienvenido Participante!");
        }

                private void ShowDisciplines()
        {
            ShowDisciplies.showDisciplies();

            /*
            Console.WriteLine("Elige una opción \n 1- Atletismo\n 2- Natación \n 3- Esgrima \n 4- Salir");

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
                    UpdateScore();
                    break;
                case 3:
                    Console.WriteLine("Gracias por usar el sistema. ¡Adiós!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
            */
        }

    }
}