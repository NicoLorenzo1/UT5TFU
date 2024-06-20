namespace ProyectoUT5
{
    public class TablePoints
    {
        private readonly ShowTablePointsRepository _repository;
         private static TablePoints instance;

        public static TablePoints Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TablePoints();
                }

                return instance;
            }
        }
        public TablePoints()
        {
            _repository = new ShowTablePointsRepository();
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

        public void UpdateScore(int ci, int score)
        {
            // Buscar al participante por CI
            List<Participant> data = _repository.GetData();
            Participant participant = data.FirstOrDefault(p => p.Ci == ci);

            if (participant != null)
            {
                participant.Score = score;
                _repository.SaveData(data);
                Console.WriteLine($"Puntaje actualizado para {participant.FirstName} {participant.LastName}. Nuevo puntaje: {score}");
            }
            else
            {
                Console.WriteLine($"No se encontró al participante con CI {ci}.");
            }
        }
    }
}