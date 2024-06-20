namespace ProyectoUT5
{
    public class ShowTablePoints
    {
        private readonly ShowTablePointsRepository _repository;

        public ShowTablePoints(ShowTablePointsRepository repository)
        {
            _repository = repository;
        }

        public Dictionary<string, List<Participant>> GetPointsByDiscipline()
        {
            List<Participant> data = _repository.GetData();
            Dictionary<string, List<Participant>> disciplinePoints = new Dictionary<string, List<Participant>>();

            foreach (var participant in data)
            {
                if (!disciplinePoints.ContainsKey(participant.Discipline))
                {
                    disciplinePoints[participant.Discipline] = new List<Participant>();
                }
                disciplinePoints[participant.Discipline].Add(participant);
            }

            return disciplinePoints;
        }

        public void DisplayPointsTable()
        {
            Dictionary<string, List<Participant>> pointsByDiscipline = GetPointsByDiscipline();

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
    }
}