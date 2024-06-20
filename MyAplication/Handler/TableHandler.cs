using ProyectoUT5.Repository;

namespace ProyectoUT5.Handler
{
    public static class TableHandler
    {
        public static void UpdateScoreMenu()
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
                    TablePointsRepository.Instance.UpdateScore(ci, newScore);
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


        public static void DisplayPointsTable()
        {
            Dictionary<string, List<Participant>> pointsByDiscipline = TablePointsRepository.Instance.GetPointsByDiscipline();

            foreach (var discipline in pointsByDiscipline)
            {
                Console.WriteLine($"Disciplina: {discipline.Key}");
                Console.WriteLine($"{"Participante",-30} {"Puntaje",-5}");
                Console.WriteLine(new string('-', 40));
                foreach (var participant in discipline.Value)
                {
                    Console.WriteLine($"{participant.FirstName} {participant.LastName,-30} {participant.Score,-5}");
                }
                Console.WriteLine();
            }
        }
            public static void DisplayTeamPointsTable()
        {
            Dictionary<string, List<Team>> pointsByDiscipline = TablePointsRepository.Instance.GetTeamPointsByDiscipline();

            foreach (var discipline in pointsByDiscipline)
            {
               Console.WriteLine($"Disciplina: {discipline.Key}");
                Console.WriteLine($"{"Equipo",-20} {"Puntaje",-10}"); 
                Console.WriteLine(new string('-', 30)); 
                foreach (var team in discipline.Value)
                {
                    Console.WriteLine($"{team.TeamName,-20} {team.Score,-10}"); 
                }
                Console.WriteLine();
                    }
        }
    }
}