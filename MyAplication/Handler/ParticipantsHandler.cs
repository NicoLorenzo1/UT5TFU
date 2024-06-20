using ProyectoUT5.Repository;


namespace ProyectoUT5

{
    public static class ParticipantHandler
    {
        public static void ShowParticipants()
        {
            Console.WriteLine("Ingrese el nombre de una disciplina: \nAtletismo \nNatacion \nGimnasia \nClavados \nHalterofilia \nEsgrima \nSurf \nKitesurf");
            string discipline = Console.ReadLine();

            List<Participant> participants = ParticipantRepository.Instance.GetParticipantsByDiscipline(discipline);
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

        public static void AddParticipantToTeamMenu()
        {
            // Solicitar la cédula del participante
            Console.WriteLine("Ingrese la cédula del participante:");
            if (!int.TryParse(Console.ReadLine(), out int ci))
            {
                Console.WriteLine("Cédula inválida.");
                return;
            }

            // Solicitar el nombre del equipo
            Console.WriteLine("Ingrese el nombre del equipo:");
            string equipo = Console.ReadLine();

            TeamRepository.Instance.AddParticipant(ci, equipo);

        }
    }
}